Module modMain

    Public g_oSplash As New frmSplash
    Public g_frmBotTrade As frmMain
    Public g_eRunMode As ENUM_RunMode = ENUM_RunMode.eThreaded
    Public g_bJobMgrRunning As Boolean = False
    Public g_bServiceMode As Boolean = False

    Public Sub Main(a_sCmdArgs() As String)
        Dim oDataLoad As New DB.clsDataLoad

        'Application.EnableVisualStyles()
        If (Debugger.IsAttached) Then g_eRunMode = ENUM_RunMode.eDebug
        If (a_sCmdArgs.Length > 0) Then
            RunService(a_sCmdArgs)
        Else
            RunUI()
        End If
    End Sub

    Private Sub RunUI()
        Dim oDataLoad As New DB.clsDataLoad

        g_oSplash.Show()
        oDataLoad.LoadCodeStruct()
        Application.DoEvents()
        DB.DBConn()
        g_frmBotTrade = New frmMain
        g_oSplash.Owner = g_frmBotTrade
        Application.Run(g_frmBotTrade)
        DB.DBDisConn()
    End Sub

    Private Sub RunService(a_sArgs() As String)
        Dim oManager As New clsService
        Dim oDataLoad As New DB.clsDataLoad
        Dim sArg1 As String = UCase(a_sArgs(0))
        Dim oEmail As New Service.clsEmail

        Try
            g_bServiceMode = True
            oDataLoad.LoadCodeStruct()
            If (sArg1 = "/SERVICE") Then
                DB.DBConn()
                Dim oRunService() As ServiceProcess.ServiceBase
                oRunService = New ServiceProcess.ServiceBase() {New svcManager}
                ServiceProcess.ServiceBase.Run(oRunService)
                DB.DBDisConn()
            ElseIf (sArg1 = "/SERVICE_DEBUG") Then
                Dim myService As New svcManager()
                myService.OnDebug()
            End If
        Catch ex As Exception
            oEmail.SendJobEmail("Service Failed to Start", False, True, ex.ToString)
        End Try
    End Sub

End Module
