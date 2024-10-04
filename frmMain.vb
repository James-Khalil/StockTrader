Imports System.ServiceProcess
Imports System.Security.Principal
Imports Alpaca.Markets
Imports System.Threading

Public Class frmMain
    Private Const SVC_STATUS_INTERVAL As Integer = 10000
    Private WithEvents m_oTimer As New System.Timers.Timer

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        InitForm()
    End Sub

    Private Sub frmBotTrader_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'InitForm()
    End Sub

    Private Sub InitForm()
        InitStatusBar()
        ucAccount.InitControl()
        'ucOrder.InitControl()
        'ucStocks.InitControl()
        'ucPositions.InitControl()
        InitSvcStatusTimer()
    End Sub

    Private Sub InitStatusBar()
        Dim oProgBar As ToolStripProgressBar

        sbMain.Items(ENUM_SBPane.eInfo).Text = ""
        oProgBar = sbMain.Items(ENUM_SBPane.eProgressBar)
        oProgBar.Value = 0
        sbMain.Items(ENUM_SBPane.eUser).Text = g_strCurrUser.sName
        sbMain.Items(ENUM_SBPane.ePermission).Text = g_strLookup.ht_sSecurity(g_strCurrUser.iSecurityID)
        SetRunMode()
    End Sub

    Public Sub SetRunMode()
        If (g_eRunMode = ENUM_RunMode.eThreaded) Then
            sbMain.Items(ENUM_SBPane.eRunMode).Text = "Multi-Task"
            sbMain.Items(ENUM_SBPane.eRunMode).BackColor = Color.LightPink
        Else
            sbMain.Items(ENUM_SBPane.eRunMode).Text = "Debug"
            sbMain.Items(ENUM_SBPane.eRunMode).BackColor = sbMain.BackColor
        End If
    End Sub

    Private Async Sub btnWatchList_Click(sender As Object, e As EventArgs) Handles btnWatchList.Click
        Dim oWatchlist As IWatchList

        oWatchlist = Await ucStocks.AddtoWatchlist
        'ucAccount.RefreshWatchList(oWatchlist)
    End Sub

    Private Sub frmBotTrader_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Thread.Sleep(1000)
        g_oSplash.Close()
    End Sub

    Private Sub UpdateServiceStatus() Handles m_oTimer.Elapsed
        Dim oService As New clsService
        Dim sStatus As String
        Dim eServieStatus As ServiceControllerStatus = oService.GetJobServiceStatusID

        m_oTimer.Stop()
        sStatus = [Enum].GetName(GetType(ServiceControllerStatus), eServieStatus)
        sbMain.Items(ENUM_SBPane.eServiceStatus).Text = sStatus
        sbMain.Items(ENUM_SBPane.eServiceStatus).Tag = eServieStatus
        If (eServieStatus = ServiceControllerStatus.Running) Then
            sbMain.Items(ENUM_SBPane.eServiceStatus).BackColor = Color.LightGreen
        Else
            sbMain.Items(ENUM_SBPane.eServiceStatus).BackColor = Color.LightPink
        End If
        m_oTimer.Start()
    End Sub

    Private Sub InitSvcStatusTimer()
        UpdateServiceStatus()
        m_oTimer.SynchronizingObject = Me
        If m_oTimer.Enabled Then m_oTimer.Stop()
        m_oTimer.Interval = SVC_STATUS_INTERVAL
        m_oTimer.Start()
    End Sub

    Private Sub mnuJobSchedule_Click(sender As Object, e As EventArgs) Handles mnuJobSchedule.Click
        Dim frmSchedMgr As New frmJobSchedule()
        Dim dialogResult As DialogResult = frmSchedMgr.ShowDialog()
    End Sub

    Private Sub mnuJobMananger_Click(sender As Object, e As EventArgs) Handles mnuJobMananger.Click
        Dim frmJobMgr As New frmJobManager()
        Dim dialogResult As DialogResult = frmJobMgr.ShowDialog()
    End Sub

    Private Sub mnuAlgoSettings_Click(sender As Object, e As EventArgs) Handles mnuAlgoSettings.Click
        Dim frmAlgoSettings As New frmAlgoSettings()
        Dim dialogResult As DialogResult = frmAlgoSettings.ShowDialog()
    End Sub

    Private Sub mnuAddJob_Click(sender As Object, e As EventArgs)
        Dim frmAddSchedule As New frmAddSchedule(True)
        Dim dialogResult As DialogResult = frmAddSchedule.ShowDialog()
    End Sub


    Private Sub RunJob(iJobTypeID As Integer)
        Dim oJob As New DB.clsJob
        Dim strJobType As STRUCT_JobType = g_strLookup.ht_strJobType(iJobTypeID)
        Dim iJobID, iResponse As Integer
        Dim sDescription = "Manually Added Job"
        Dim sMsg As String

        sMsg = "Are you sure you want to run the following job?" & vbCrLf & vbCrLf &
               "Job Name: " & strJobType.sDescription & vbCrLf &
               "Run Mode: " & sbMain.Items(ENUM_SBPane.eRunMode).Text


        iResponse = MsgBox(sMsg, MsgBoxStyle.YesNo Or MsgBoxStyle.Information, "Run Job")
        If (iResponse = vbYes) Then
            iJobID = oJob.AddJob(iJobTypeID, sDescription, g_strCurrUser.sName)
        End If
    End Sub

    Private Sub mnuItemRefreshAssetData_Click(sender As Object, e As EventArgs) Handles mnuRefreshAssetData.Click
        RunJob(ENUM_JobTypeID.eRefreshAssetData)
    End Sub

    Private Sub mnuLiveTrade_Click(sender As Object, e As EventArgs) Handles mnuLiveTrade.Click
        RunJob(ENUM_JobTypeID.eLiveTrade)
    End Sub

    Private Sub mnuPaperTrade_Click(sender As Object, e As EventArgs) Handles mnuPaperTrade.Click
        RunJob(ENUM_JobTypeID.ePaperTrade)
    End Sub

    Private Sub mnuDataCleanup_Click(sender As Object, e As EventArgs) Handles mnuDataCleanup.Click
        RunJob(ENUM_JobTypeID.eDataCleanup)
    End Sub

    Private Sub mnuHelpAbout_Click(sender As Object, e As EventArgs) Handles mnuHelpAbout.Click
        Dim frmSplash As New frmSplash
        frmSplash.btnOK.Visible = True
        frmSplash.Show()
    End Sub

    Private Sub mnuJobManagerStart_Click(sender As Object, e As EventArgs) Handles mnuJobManagerStart.Click
        Dim sMsg As String = "Are you sure you want to start Windows service: " & clsService.SERVICE_NAME
        Dim al_oJobService As New ArrayList
        Dim oService As New clsService

        Try
            If oService.IsServiceStopped() Then
                If MsgBox(sMsg, vbQuestion Or vbYesNo, "Start Windows Services") = MsgBoxResult.Yes Then
                    System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
                    oService.StartService()
                    Thread.Sleep(2000)
                    System.Windows.Forms.Cursor.Current = Cursors.Default
                    UpdateServiceStatus()
                    MsgBox(clsService.SERVICE_NAME & " has started successfully", vbInformation)
                End If
            Else
                MsgBox("Server must be in the stopped state", vbInformation)
            End If
        Catch ex As Exception
            MsgBox("Errors encountered starting service:" & ex.ToString, vbInformation, "Service Start Errors")
        End Try
    End Sub

    Private Sub mnuJobManagerStop_Click(sender As Object, e As EventArgs) Handles mnuJobManagerStop.Click
        Dim sMsg As String = "Are you sure you want to stop Windows service: " & clsService.SERVICE_NAME
        Dim al_oJobService As New ArrayList
        Dim oService As New clsService

        Try
            If oService.IsServiceStarted() Then
                If MsgBox(sMsg, vbQuestion Or vbYesNo, "Stop Windows Service") = MsgBoxResult.Yes Then
                    System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
                    oService.StopService()
                    Thread.Sleep(2000)
                    System.Windows.Forms.Cursor.Current = Cursors.Default
                    UpdateServiceStatus()
                    MsgBox(clsService.SERVICE_NAME & " has stopped successfully", vbInformation)
                End If
            Else
                MsgBox("Server must be in the started state", vbInformation)
            End If
        Catch ex As Exception
            MsgBox("Errors encountered stopping service:" & ex.ToString, vbInformation, "Service Stop Errors")
        End Try

    End Sub

    Private Sub mnuRunMode_DropDownOpening(sender As Object, e As EventArgs) Handles mnuRunMode.DropDownOpening
        InitARPSRunModeMenu()
    End Sub

    Private Sub mnuRunMode_Click(sender As Object, e As EventArgs) Handles mnuRunModeThreaded.Click, mnuRunModeDebug.Click
        Dim mnuItem As ToolStripMenuItem = sender

        If (mnuItem Is mnuRunModeThreaded) Then
            g_eRunMode = ENUM_RunMode.eThreaded
        ElseIf (mnuItem Is mnuRunModeDebug) Then
            g_eRunMode = ENUM_RunMode.eDebug
        End If
        InitARPSRunModeMenu()
        SetRunMode()
    End Sub

    Private Sub InitARPSRunModeMenu()
        mnuRunModeThreaded.Checked = False
        mnuRunModeDebug.Checked = False

        If (g_eRunMode = ENUM_RunMode.eThreaded) Then
            mnuRunModeThreaded.Checked = True
        ElseIf (g_eRunMode = ENUM_RunMode.eDebug) Then
            mnuRunModeDebug.Checked = True
        End If
    End Sub

    Private Sub mnuJobManager_DropDownOpening(sender As Object, e As EventArgs) Handles mnuJobManager.DropDownOpening
        Dim eServieStatus As ServiceControllerStatus

        eServieStatus = sbMain.Items(ENUM_SBPane.eServiceStatus).Tag
        If (eServieStatus = ServiceControllerStatus.Running) Then
            mnuJobManagerStart.Enabled = False
            mnuJobManagerStop.Enabled = True
        ElseIf (eServieStatus = ServiceControllerStatus.Stopped) Then
            mnuJobManagerStart.Enabled = True
            mnuJobManagerStop.Enabled = False
        Else
            mnuJobManagerStart.Enabled = False
            mnuJobManagerStop.Enabled = False
        End If

    End Sub

    Private Sub mnuRefreshAssetScore_Click(sender As Object, e As EventArgs) Handles mnuRefreshAssetScore.Click
        RunJob(ENUM_JobTypeID.eRefreshAssetScore)
    End Sub

End Class
