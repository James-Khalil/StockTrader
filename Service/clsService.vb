Imports System.ServiceProcess
Imports System.Security.Principal

Public Class clsService
    Public Const SERVICE_NAME As String = "SECRET"
    Private Const SERVICE_USER As String = "SECRET"
    Private Const SERVICE_PWD As String = "SECRET"

    Public Function IsServiceStarted() As Boolean
        Dim oUser As WindowsImpersonationContext
        Dim oService As New ServiceController(SERVICE_NAME)
        Dim bRunning As Boolean

        oUser = modSecurity.ImpersonateSvcBotTrader
        oService.MachineName = Environment.MachineName
        oService.Refresh()
        bRunning = (oService.Status = ServiceControllerStatus.Running)
        oUser.Undo()

        Return bRunning
    End Function

    Public Function IsServiceStopped() As Boolean
        Dim oUser As WindowsImpersonationContext
        Dim oService As New ServiceController(SERVICE_NAME)
        Dim bStopped As Boolean

        oUser = modSecurity.ImpersonateSvcBotTrader
        oService.MachineName = Environment.MachineName
        oService.Refresh()
        bStopped = (oService.Status = ServiceControllerStatus.Stopped)
        oUser.Undo()

        Return bStopped
    End Function

    Public Sub StartService()
        Dim oService As New ServiceController(SERVICE_NAME)
        Dim oUser As WindowsImpersonationContext

        oUser = modSecurity.ImpersonateSvcBotTrader
        oService.MachineName = Environment.MachineName
        oService.Refresh()
        If (oService.Status = ServiceControllerStatus.Stopped) Then
            oService.Start()
        End If
        oUser.Undo()
    End Sub

    Public Sub StopService()
        Dim oService As New ServiceController(SERVICE_NAME)
        Dim oUser As WindowsImpersonationContext

        oUser = modSecurity.ImpersonateSvcBotTrader
        oService.MachineName = Environment.MachineName
        oService.Refresh()
        If (oService.Status = ServiceControllerStatus.Running) Then
            oService.Stop()
        End If
        oUser.Undo()
    End Sub

    Public Function GetJobServiceStatusID() As ServiceControllerStatus
        Dim oService As New ServiceController(SERVICE_NAME)
        Dim iStatusID As ServiceControllerStatus
        Dim oUser As WindowsImpersonationContext

        oUser = modSecurity.ImpersonateSvcBotTrader
        oService.MachineName = Environment.MachineName
        oService.Refresh()
        iStatusID = oService.Status
        oUser.Undo()

        Return iStatusID
    End Function

End Class
