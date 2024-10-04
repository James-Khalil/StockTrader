Imports System.ServiceProcess

Public Class svcManager

    Public Sub OnDebug()
        OnStart(Nothing)
        While True
            Threading.Thread.Sleep(1000)
            Application.DoEvents()
        End While
    End Sub

    Protected Overrides Sub OnStart(args() As String)
        Dim oEmail As New Service.clsEmail

        Try
            Dim oJobTask As Task
            Dim oJobScheduleTask As Task
            Dim oJob As New Job.clsJob

            g_bJobMgrRunning = True
            oJobTask = New Task(Sub() oJob.RunJobManager())
            oJobScheduleTask = New Task(Sub() oJob.RunJobScheduleManager())
            oJobTask.Start()
            oJobScheduleTask.Start()
            oEmail.SendJobEmail("BotTrader Service Started Successfully", True, True)

        Catch ex As Exception
            oEmail.SendJobEmail("BotTrader Service Failed to Start", False, True, ex.ToString)
        End Try
    End Sub

    Protected Overrides Sub OnStop()
        Dim oEmail As New Service.clsEmail

        Try
            ' Add code here to perform any tear-down necessary to stop your service.
            g_bJobMgrRunning = False
            oEmail.SendJobEmail("BotTrader Service Stopped Successfully", True, True)
        Catch ex As Exception
            oEmail.SendJobEmail("Service Failed to Stop", False, True,  ex.ToString)
        End Try
    End Sub




End Class
