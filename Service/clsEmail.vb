Imports System.Net.Mail

Namespace Service
    Friend Class clsEmail
        Public Const SHAW_EMAIL_ADDR As String = "SECRET"
        Public Const SHAW_SMTP_SERVER As String = "SECRET"
        Public Const SHAW_SMTP_PWD As String = "SECRET"
        Public Const MAX_ATTEMPTS As Integer = 5

        Public Sub SendJobEmail(sJobName As String, bSuccess As Boolean, bNameOnly As Boolean,
                                Optional sMessage As String = "", Optional bHTML As Boolean = False,
                                Optional bAlert As Boolean = False, Optional iReportID As ENUM_ReportID = ENUM_ReportID.eJobOutcome)
            Dim sSubject, sBody As String
            Dim oPriority As MailPriority
            Dim sServerName As String = System.Environment.MachineName

            If (bSuccess) Then
                oPriority = If(bAlert, MailPriority.High, MailPriority.Normal)
                sSubject = sJobName & If(bNameOnly, "", " Ran Successfully...")

                sBody = "Date: " & Date.Now.ToString("MMM dd, yyyy H:mm:ss") &
                        If(bHTML, "<BR>", vbCrLf) & "Server: " & sServerName &
                        If(bHTML, "<BR>", vbCrLf) & sJobName & If(bNameOnly, "", " completed with no errors.")
            Else
                oPriority = MailPriority.High
                sSubject = sJobName & If(bNameOnly, "", " Failed...")
                sBody = "Date: " & Date.Now.ToString("MMM dd, yyyy H:mm:ss")
                sBody &= If(bHTML, "<BR>", vbCrLf) & "Server: " & sServerName
                If (sMessage.Length = 0) Then
                    sBody &= vbCrLf & sJobName & " failed with no error"
                Else
                    sBody &= vbCrLf & sJobName & " failed for the following reason: " & If(bHTML, "<BR><BR>", vbCrLf & vbCrLf) & sMessage
                End If
            End If
            SendReport(iReportID, sSubject, sBody, bHTML, oPriority)
        End Sub

        Public Sub SendServiceStatus(sJobName As String, Optional sMessage As String = "", Optional bHTML As Boolean = False,
                                    Optional bAlert As Boolean = False, Optional iReportID As ENUM_ReportID = ENUM_ReportID.eJobOutcome)
            Dim sSubject, sBody As String
            Dim oPriority As MailPriority
            Dim sServerName As String = Environment.MachineName

            oPriority = If(bAlert, MailPriority.High, MailPriority.Normal)

            sSubject = sServerName & " - " & sJobName & " has been started."
            sBody = "Date: " & Date.Now.ToString("MMM dd, yyyy H:mm:ss")
            sBody &= If(bHTML, "<BR>", vbCrLf) & "Job: " & sJobName

            If (sMessage.Length > 0) Then
                sBody &= If(bHTML, "<BR>", vbCrLf) & sMessage
            End If

            SendReport(iReportID, sSubject, sBody, bHTML, oPriority)
        End Sub

        Public Function SendMail(oMail As MailMessage) As Boolean
            Dim bSuccess As Boolean

            Try
                If (oMail.To.Count > 0) Then
                    Dim oSMTP As New SmtpClient(SHAW_SMTP_SERVER) 'With {
                    '    .Credentials = New Net.NetworkCredential(SHAW_EMAIL_ADDR, SHAW_SMTP_PWD),
                    '  .EnableSsl = True
                    '}
                    oSMTP.Send(oMail)
                End If
                bSuccess = True
            Catch ex As Exception
                bSuccess = False
                LogEvent(ex.ToString, EventLogEntryType.Error)
            End Try

            Return bSuccess
        End Function

        Public Sub SendReport(iReportID As ENUM_ReportID, sSubject As String, sBody As String, bHTML As Boolean, oPriority As MailPriority)

            Dim oMail As New MailMessage
            Dim al_Recepients As List(Of String)
            Dim sRecepient As String

            al_Recepients = GetRecipients(iReportID)
            For Each sRecepient In al_Recepients
                oMail.To.Add(New MailAddress(sRecepient))
            Next

            oMail.From = New MailAddress(SHAW_EMAIL_ADDR)
            oMail.Subject = sSubject
            oMail.IsBodyHtml = bHTML
            oMail.Body = sBody
            oMail.Priority = oPriority

            For iAttempt As Integer = 1 To MAX_ATTEMPTS
                If SendMail(oMail) Then Exit For
            Next
        End Sub

        Public Function GetRecipients(iReportID As Integer, Optional iUserID As Integer = 0) As List(Of String)
            Dim oTable As DataTable
            Dim oRow As DataRow
            Dim sSQL As String
            Dim al_EmailAddr As New List(Of String)

            sSQL = "Select DISTINCT U.Email " &
                   "FROM tbl_ReportSchedule S " &
                   "INNER JOIN tbl_Report R On R.ReportID=S.ReportID " &
                   "INNER JOIN tbl_User U On U.UserID=S.UserID " &
                   "WHERE (U.ActiveFlag=1) And (R.ReportID = " & CStr(iReportID) & ") " &
                   "And (S." & WeekdayName(Weekday(Date.Today)) & "=1) "
            If (iUserID > 0) Then
                sSQL &= "And (U.UserID=" & CStr(iUserID)
            End If
            sSQL &= "ORDER BY U.Email "

            oTable = DB.GetDataTable_SQL(sSQL)
            For Each oRow In oTable.Rows
                al_EmailAddr.Add(oRow("Email"))
            Next
            oTable.Dispose()

            Return al_EmailAddr
        End Function



    End Class
End Namespace
