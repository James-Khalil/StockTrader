Namespace DB
    Friend Class clsDataLoad
        Private m_oLookup As New clsLookup
        Private m_oJob As New clsJob
        Private Function LoadCurrUser() As STRUCT_User
            Dim strUser As New STRUCT_User
            Dim oTable As DataTable
            Dim oRow As DataRow
            Dim sLoginName, sError As String
            Dim oUser As New clsUser

            sLoginName = SystemInformation.UserName
            oTable = oUser.GetUserByLogin(sLoginName)
            If (oTable.Rows.Count = 1) Then
                oRow = oTable.Rows(0)
                strUser.iUserID = oRow("UserID")
                strUser.sLogin = oRow("Login")
                strUser.sName = oRow("Name")
                strUser.sEmail = oRow("Email")
                strUser.iSecurityID = oRow("SecurityID")
                strUser.bActiveFlag = oRow("ActiveFlag")
            Else
                sError = "Error, cannot find user " & sLoginName & " in the database"
                If (g_bServiceMode) Then Throw New Exception(sError) Else MsgBox(sError)
            End If
            oTable.Dispose()

            Return strUser
        End Function

        Private Function LoadAppSecurityTable() As Dictionary(Of Integer, String)
            Dim ht_sSecurity As New Dictionary(Of Integer, String)
            Dim sSecurity As String
            Dim iSecurityID As Integer
            Dim oTable As DataTable
            Dim oRow As DataRow

            oTable = m_oLookup.GetAppSecurity
            For Each oRow In oTable.Rows
                iSecurityID = oRow("SecurityID")
                sSecurity = oRow("Description")
                ht_sSecurity.Add(iSecurityID, sSecurity)
            Next
            oTable.Dispose()

            Return ht_sSecurity
        End Function

        Private Function LoadJobStatusTable() As Dictionary(Of Integer, String)
            Dim ht_sJobStatus As New Dictionary(Of Integer, String)
            Dim oTable As DataTable
            Dim iJobStatusID As String
            Dim sDescription As String
            Dim oRow As DataRow

            oTable = m_oJob.GetJobStatus
            For Each oRow In oTable.Rows
                iJobStatusID = oRow("JobStatusID")
                sDescription = oRow("Description")
                ht_sJobStatus.Add(iJobStatusID, sDescription)
            Next
            oTable.Dispose()

            Return ht_sJobStatus
        End Function


        Private Function LoadJobTypeTable() As Dictionary(Of Integer, STRUCT_JobType)
            Dim ht_strJobType As New Dictionary(Of Integer, STRUCT_JobType)
            Dim strJobType As New STRUCT_JobType
            Dim oTable As DataTable
            Dim oRow As DataRow

            oTable = m_oJob.GetJobType
            For Each oRow In oTable.Rows
                strJobType.iJobTypeID = oRow("JobTypeID")
                strJobType.sDescription = oRow("Description")
                strJobType.iNumThreads = oRow("NumThreads")
                strJobType.iDaysRetainLog = oRow("DaysRetainLog")
                ht_strJobType.Add(strJobType.iJobTypeID, strJobType)
            Next
            oTable.Dispose()

            Return ht_strJobType
        End Function

        Public Function LoadLookup() As STRUCT_Lookup
            Dim strLookup As STRUCT_Lookup

            With strLookup
                .ht_sSecurity = LoadAppSecurityTable()
                .ht_sJobStatus = LoadJobStatusTable()
                .ht_strJobType = LoadJobTypeTable()
            End With

            Return strLookup
        End Function

        Public Sub LoadCodeStruct()
            g_strCurrUser = LoadCurrUser()
            g_strAppConst = m_oLookup.LoadAppConst()
            g_strLookup = LoadLookup()
        End Sub

    End Class
End Namespace