Imports System.Threading

Namespace Job
    Friend Class clsJob

        Const SKD_JOB_BUFFER_MINUTES As Integer = 60
        Private m_oJob As New DB.clsJob
        Private m_oSchedule As New DB.clsSchedule
        Private m_oEmail As New Service.clsEmail

        Public Sub RunJobManager()
            Dim al_oTask As New List(Of Task)
            Dim iJobID, iJobTypeID As Integer
            Dim oConn As SqlConnection = DB.NewConnection
            Dim oDataTable As DataTable
            Dim oRow As DataRow

            Try
                While (g_bJobMgrRunning)
                    oDataTable = m_oJob.GetNextJob(oConn)
                    If (oDataTable.Rows.Count = 1) Then
                        oRow = oDataTable.Rows(0)
                        iJobID = oRow("JobID")
                        iJobTypeID = oRow("JobTypeID")
                        m_oJob.UpdateJobStatus(iJobID, ENUM_JobStatusID.eInProgress, oConn)
                        al_oTask.Add(Task.Run(Sub() RunJob(iJobID, iJobTypeID)))
                    End If
                    oDataTable.Dispose()
                    Thread.Sleep(5000)
                End While
            Catch ex As Exception
                m_oEmail.SendJobEmail("Job Manager", False, False, ex.ToString)
            Finally
                DB.DBDisConn(oConn)
            End Try
        End Sub

        Public Sub RunJob(iJobID As Integer, iJobTypeID As Integer)
            Dim oAlgoTrade As New clsAlgo
            Dim sJobName As String = g_strLookup.ht_strJobType(iJobTypeID).sDescription
            Dim oConn As SqlConnection = DB.NewConnection

            Try
                m_oJob.UpdateJob(iJobID, ENUM_JobStatusID.eInProgress, DateTime.Now, True, oConn)
                Select Case iJobTypeID
                    Case ENUM_JobTypeID.eRefreshAssetData
                        RefreshAssetData(iJobID, iJobTypeID)
                    Case ENUM_JobTypeID.eRefreshAssetScore
                        RefreshAssetScore(iJobID, iJobTypeID)
                    Case ENUM_JobTypeID.ePaperTrade
                        oAlgoTrade.PaperTrade(iJobID, iJobTypeID)
                    Case ENUM_JobTypeID.eLiveTrade
                        oAlgoTrade.LiveTrade(iJobID, iJobTypeID)
                    Case ENUM_JobTypeID.eDataCleanup
                        m_oJob.DataCleanup()
                End Select
                m_oJob.UpdateJob(iJobID, ENUM_JobStatusID.eCompleted, DateTime.Now, False)
            Catch ex As Exception
                m_oEmail.SendJobEmail(sJobName, False, False, ex.ToString)
                m_oJob.UpdateJob(iJobID, ENUM_JobStatusID.eFailed, DateTime.Now, False)
            Finally
                DB.DBDisConn(oConn)
            End Try
        End Sub

        Public Function SendJobOutcome(iJobID As Integer, sJobName As String) As ENUM_JobStatusID
            Dim oTable As DataTable
            Dim oRow As DataRow
            Dim eJobStatusID As ENUM_JobStatusID = ENUM_JobStatusID.eCompleted
            Dim sHTMLBody, sHeader, sDesc As String

            oTable = m_oJob.GetJobErrorByJobID(iJobID)
            If (oTable.Rows.Count = 0) Then
                m_oEmail.SendJobEmail(sJobName, True, False)
            Else
                eJobStatusID = ENUM_JobStatusID.eFailed
                sHTMLBody = "<table border=1 Cellpadding=0 cellspacing=0>"
                For Each oRow In oTable.Rows
                    sHeader = oRow("Error")
                    sDesc = oRow("Exception")

                    Dim rowHtml As String = "<tr><th>" & sHeader & "</th><td>" & sDesc & "</td></tr>"
                    sHTMLBody += rowHtml
                Next
                sHTMLBody += "</table>"
                m_oEmail.SendJobEmail(sJobName, False, False, sHTMLBody)
            End If
            oTable.Dispose()

            Return eJobStatusID
        End Function

        Public Sub RunJobScheduleManager()
            Dim al_task As New List(Of Task)
            Dim oDataTable As DataTable
            Dim iLastJobID As Integer
            Dim dtNextRunTime As DateTime
            Dim oConn As SqlConnection = DB.NewConnection
            Dim lDateDiff As Long

            Try
                While (g_bJobMgrRunning)
                    oDataTable = m_oSchedule.GetJobSchedules(oConn)
                    For Each oRow In oDataTable.Rows
                        iLastJobID = If(Not IsDBNull(oRow("LastJobID")), oRow("LastJobID"), 0)
                        lDateDiff = DateDiff(DateInterval.Minute, oRow("NextRunTime"), DateTime.UtcNow)
                        If (lDateDiff > SKD_JOB_BUFFER_MINUTES) Then
                            iLastJobID = m_oJob.AddJob(oRow("JobTypeID"), "Scheduled Job", g_strCurrUser.sName, oConn)
                            dtNextRunTime = UpdateNextRunTime(oRow)
                            m_oSchedule.UpdateLastJobSchedule(oRow("JobScheduleID"), iLastJobID, dtNextRunTime, oConn)
                        Else
                            dtNextRunTime = oRow("NextRunTime")
                            dtNextRunTime = dtNextRunTime.AddHours(1)
                            m_oSchedule.UpdateLastJobSchedule(oRow("JobScheduleID"), iLastJobID, dtNextRunTime, oConn)
                        End If
                    Next
                    oDataTable.Dispose()
                    Thread.Sleep(30000)
                End While
            Catch ex As Exception
                m_oEmail.SendJobEmail("Job Scheduler", False, False, ex.ToString)
            Finally
                DB.DBDisConn(oConn)
            End Try
        End Sub

        Public Function UpdateNextRunTime(oDataRow As DataRow) As DateTime
            Dim dtDate As DateTime = DateTime.UtcNow.AddDays(1)
            Dim tsScheduledTime As TimeSpan = oDataRow("ScheduleTime")
            Dim sWeekDay As String = dtDate.ToString("dddd")
            Dim dtNextScheduledTime As DateTime
            Dim iCounter As Integer = 0

            Do While iCounter < 7 And Not oDataRow(sWeekDay)
                dtDate = dtDate.AddDays(1)
                sWeekDay = dtDate.ToString("dddd")
                iCounter += 1
            Loop

            If iCounter < 7 Then
                dtNextScheduledTime = dtDate.Date + tsScheduledTime
            Else
                dtNextScheduledTime = Date.Now.AddDays(1)
            End If
            Return dtNextScheduledTime
        End Function

        Private Sub RefreshAssetData(iJobID As Integer, iJobTypeID As Integer)
            Dim strJobType As STRUCT_JobType = g_strLookup.ht_strJobType(iJobTypeID)
            Dim sJobName As String = strJobType.sDescription

            Try
                m_oEmail.SendJobEmail(sJobName & " Started", True, True)
                Dim oAsset As New clsAsset()
                oAsset.RefreshAssetData(iJobID, iJobTypeID)
                SendJobOutcome(iJobID, sJobName)
            Catch ex As Exception
                m_oEmail.SendJobEmail(sJobName, False, False, ex.ToString)
            End Try
        End Sub

        Private Sub RefreshAssetScore(iJobID As Integer, iJobTypeID As Integer)
            Dim strJobType As STRUCT_JobType = g_strLookup.ht_strJobType(iJobTypeID)
            Dim sJobName As String = strJobType.sDescription

            Try
                m_oEmail.SendJobEmail(sJobName & " Started", True, True)
                Dim oAsset As New clsAsset()
                oAsset.RefreshAssetScore(iJobID, iJobTypeID)
                SendJobOutcome(iJobID, sJobName)
            Catch ex As Exception
                m_oEmail.SendJobEmail(sJobName, False, False, ex.ToString)
            End Try
        End Sub

        'Fake job to test if jobs can be ran (use for scheduler)
        Private Sub JobTest()

            Try
                m_oEmail.SendJobEmail("TEST JOB", True, True)
            Catch ex As Exception
                m_oEmail.SendJobEmail("TEST JOB", False, False, ex.ToString)
            End Try
        End Sub

    End Class
End Namespace