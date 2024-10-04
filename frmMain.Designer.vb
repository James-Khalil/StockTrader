<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.sbMain = New System.Windows.Forms.StatusStrip()
        Me.pMsgInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pProgressBar = New System.Windows.Forms.ToolStripProgressBar()
        Me.pUser = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pPermission = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pRunMode = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pServiceStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ilMainTab = New System.Windows.Forms.ImageList(Me.components)
        Me.tpStocks = New System.Windows.Forms.TabPage()
        Me.btnWatchList = New System.Windows.Forms.Button()
        Me.tpPositions = New System.Windows.Forms.TabPage()
        Me.tpOrders = New System.Windows.Forms.TabPage()
        Me.tpMain = New System.Windows.Forms.TabPage()
        Me.tabctrl = New System.Windows.Forms.TabControl()
        Me.mnuMain = New System.Windows.Forms.MenuStrip()
        Me.mnuTools = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuRunMode = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRunModeThreaded = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRunModeDebug = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuJobs = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRefreshAssetData = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRefreshAssetScore = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPaperTrade = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLiveTrade = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDataCleanup = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuJobManager = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuJobManagerStart = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuJobManagerStop = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelpAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuJobSchedule = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuJobMananger = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAlgoSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.ucAccount = New Bottrader.ucAccount()
        Me.ucOrder = New Bottrader.ucOrderLog()
        Me.ucPositions = New Bottrader.ucPositions()
        Me.ucStocks = New Bottrader.ucStocks()
        Me.sbMain.SuspendLayout()
        Me.tpStocks.SuspendLayout()
        Me.tpPositions.SuspendLayout()
        Me.tpOrders.SuspendLayout()
        Me.tpMain.SuspendLayout()
        Me.tabctrl.SuspendLayout()
        Me.mnuMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'sbMain
        '
        Me.sbMain.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.sbMain.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.sbMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.pMsgInfo, Me.pProgressBar, Me.pUser, Me.pPermission, Me.pRunMode, Me.pServiceStatus})
        Me.sbMain.Location = New System.Drawing.Point(0, 559)
        Me.sbMain.Name = "sbMain"
        Me.sbMain.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.sbMain.Size = New System.Drawing.Size(1637, 33)
        Me.sbMain.TabIndex = 1
        '
        'pMsgInfo
        '
        Me.pMsgInfo.AutoSize = False
        Me.pMsgInfo.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.pMsgInfo.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.pMsgInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.pMsgInfo.Name = "pMsgInfo"
        Me.pMsgInfo.Size = New System.Drawing.Size(682, 27)
        Me.pMsgInfo.Spring = True
        Me.pMsgInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pProgressBar
        '
        Me.pProgressBar.AutoSize = False
        Me.pProgressBar.Name = "pProgressBar"
        Me.pProgressBar.Size = New System.Drawing.Size(333, 25)
        '
        'pUser
        '
        Me.pUser.AutoSize = False
        Me.pUser.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.pUser.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.pUser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.pUser.Name = "pUser"
        Me.pUser.Size = New System.Drawing.Size(150, 27)
        Me.pUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pPermission
        '
        Me.pPermission.AutoSize = False
        Me.pPermission.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.pPermission.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.pPermission.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.pPermission.Name = "pPermission"
        Me.pPermission.Size = New System.Drawing.Size(150, 27)
        Me.pPermission.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pRunMode
        '
        Me.pRunMode.AutoSize = False
        Me.pRunMode.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.pRunMode.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.pRunMode.Name = "pRunMode"
        Me.pRunMode.Size = New System.Drawing.Size(150, 27)
        Me.pRunMode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pServiceStatus
        '
        Me.pServiceStatus.AutoSize = False
        Me.pServiceStatus.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.pServiceStatus.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.pServiceStatus.Name = "pServiceStatus"
        Me.pServiceStatus.Size = New System.Drawing.Size(150, 27)
        Me.pServiceStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ilMainTab
        '
        Me.ilMainTab.ImageStream = CType(resources.GetObject("ilMainTab.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilMainTab.TransparentColor = System.Drawing.Color.Transparent
        Me.ilMainTab.Images.SetKeyName(0, "")
        Me.ilMainTab.Images.SetKeyName(1, "")
        Me.ilMainTab.Images.SetKeyName(2, "Currency_Green.ico")
        Me.ilMainTab.Images.SetKeyName(3, "Portfolio.ico")
        '
        'tpStocks
        '
        Me.tpStocks.Controls.Add(Me.btnWatchList)
        Me.tpStocks.Controls.Add(Me.ucStocks)
        Me.tpStocks.ImageIndex = 1
        Me.tpStocks.Location = New System.Drawing.Point(4, 25)
        Me.tpStocks.Margin = New System.Windows.Forms.Padding(4)
        Me.tpStocks.Name = "tpStocks"
        Me.tpStocks.Size = New System.Drawing.Size(1629, 500)
        Me.tpStocks.TabIndex = 5
        Me.tpStocks.Text = "Stocks"
        Me.tpStocks.UseVisualStyleBackColor = True
        '
        'btnWatchList
        '
        Me.btnWatchList.BackColor = System.Drawing.Color.White
        Me.btnWatchList.Location = New System.Drawing.Point(861, 2)
        Me.btnWatchList.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnWatchList.Name = "btnWatchList"
        Me.btnWatchList.Size = New System.Drawing.Size(125, 50)
        Me.btnWatchList.TabIndex = 1
        Me.btnWatchList.Text = "Temp"
        Me.btnWatchList.UseVisualStyleBackColor = False
        '
        'tpPositions
        '
        Me.tpPositions.Controls.Add(Me.ucPositions)
        Me.tpPositions.ImageIndex = 3
        Me.tpPositions.Location = New System.Drawing.Point(4, 25)
        Me.tpPositions.Margin = New System.Windows.Forms.Padding(4)
        Me.tpPositions.Name = "tpPositions"
        Me.tpPositions.Size = New System.Drawing.Size(1629, 500)
        Me.tpPositions.TabIndex = 3
        Me.tpPositions.Text = "Positions"
        Me.tpPositions.UseVisualStyleBackColor = True
        '
        'tpOrders
        '
        Me.tpOrders.Controls.Add(Me.ucOrder)
        Me.tpOrders.ImageIndex = 0
        Me.tpOrders.Location = New System.Drawing.Point(4, 25)
        Me.tpOrders.Margin = New System.Windows.Forms.Padding(4)
        Me.tpOrders.Name = "tpOrders"
        Me.tpOrders.Size = New System.Drawing.Size(1629, 500)
        Me.tpOrders.TabIndex = 2
        Me.tpOrders.Text = "Orders"
        Me.tpOrders.UseVisualStyleBackColor = True
        '
        'tpMain
        '
        Me.tpMain.Controls.Add(Me.ucAccount)
        Me.tpMain.ImageIndex = 2
        Me.tpMain.Location = New System.Drawing.Point(4, 25)
        Me.tpMain.Margin = New System.Windows.Forms.Padding(4)
        Me.tpMain.Name = "tpMain"
        Me.tpMain.Padding = New System.Windows.Forms.Padding(4)
        Me.tpMain.Size = New System.Drawing.Size(1629, 500)
        Me.tpMain.TabIndex = 0
        Me.tpMain.Text = "Account"
        Me.tpMain.ToolTipText = "Account Info"
        Me.tpMain.UseVisualStyleBackColor = True
        '
        'tabctrl
        '
        Me.tabctrl.Controls.Add(Me.tpMain)
        Me.tabctrl.Controls.Add(Me.tpOrders)
        Me.tabctrl.Controls.Add(Me.tpPositions)
        Me.tabctrl.Controls.Add(Me.tpStocks)
        Me.tabctrl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabctrl.ImageList = Me.ilMainTab
        Me.tabctrl.Location = New System.Drawing.Point(0, 30)
        Me.tabctrl.Margin = New System.Windows.Forms.Padding(4)
        Me.tabctrl.Name = "tabctrl"
        Me.tabctrl.SelectedIndex = 0
        Me.tabctrl.ShowToolTips = True
        Me.tabctrl.Size = New System.Drawing.Size(1637, 529)
        Me.tabctrl.TabIndex = 0
        '
        'mnuMain
        '
        Me.mnuMain.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.mnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuTools, Me.mnuJobs, Me.mnuHelp})
        Me.mnuMain.Location = New System.Drawing.Point(0, 0)
        Me.mnuMain.Name = "mnuMain"
        Me.mnuMain.Padding = New System.Windows.Forms.Padding(5, 2, 0, 2)
        Me.mnuMain.Size = New System.Drawing.Size(1637, 30)
        Me.mnuMain.TabIndex = 3
        Me.mnuMain.Text = "MenuStrip1"
        '
        'mnuTools
        '
        Me.mnuTools.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuJobSchedule, Me.mnuJobMananger, Me.mnuAlgoSettings, Me.ToolStripSeparator2, Me.mnuRunMode})
        Me.mnuTools.Name = "mnuTools"
        Me.mnuTools.Size = New System.Drawing.Size(58, 26)
        Me.mnuTools.Text = "&Tools"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(221, 6)
        '
        'mnuRunMode
        '
        Me.mnuRunMode.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuRunModeThreaded, Me.mnuRunModeDebug})
        Me.mnuRunMode.Name = "mnuRunMode"
        Me.mnuRunMode.Size = New System.Drawing.Size(224, 26)
        Me.mnuRunMode.Text = "Run Mode"
        '
        'mnuRunModeThreaded
        '
        Me.mnuRunModeThreaded.Name = "mnuRunModeThreaded"
        Me.mnuRunModeThreaded.Size = New System.Drawing.Size(159, 26)
        Me.mnuRunModeThreaded.Text = "Multi-Task"
        '
        'mnuRunModeDebug
        '
        Me.mnuRunModeDebug.Name = "mnuRunModeDebug"
        Me.mnuRunModeDebug.Size = New System.Drawing.Size(159, 26)
        Me.mnuRunModeDebug.Text = "Debug"
        '
        'mnuJobs
        '
        Me.mnuJobs.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuRefreshAssetData, Me.mnuRefreshAssetScore, Me.mnuPaperTrade, Me.mnuLiveTrade, Me.mnuDataCleanup, Me.ToolStripSeparator1, Me.mnuJobManager})
        Me.mnuJobs.Name = "mnuJobs"
        Me.mnuJobs.Size = New System.Drawing.Size(52, 26)
        Me.mnuJobs.Text = "&Jobs"
        '
        'mnuRefreshAssetData
        '
        Me.mnuRefreshAssetData.Name = "mnuRefreshAssetData"
        Me.mnuRefreshAssetData.Size = New System.Drawing.Size(221, 26)
        Me.mnuRefreshAssetData.Text = "Refresh Asset Data"
        '
        'mnuRefreshAssetScore
        '
        Me.mnuRefreshAssetScore.Name = "mnuRefreshAssetScore"
        Me.mnuRefreshAssetScore.Size = New System.Drawing.Size(221, 26)
        Me.mnuRefreshAssetScore.Text = "Refresh Asset Score"
        '
        'mnuPaperTrade
        '
        Me.mnuPaperTrade.Name = "mnuPaperTrade"
        Me.mnuPaperTrade.Size = New System.Drawing.Size(221, 26)
        Me.mnuPaperTrade.Text = "Paper Trade"
        '
        'mnuLiveTrade
        '
        Me.mnuLiveTrade.Name = "mnuLiveTrade"
        Me.mnuLiveTrade.Size = New System.Drawing.Size(221, 26)
        Me.mnuLiveTrade.Text = "Live Trade"
        '
        'mnuDataCleanup
        '
        Me.mnuDataCleanup.Name = "mnuDataCleanup"
        Me.mnuDataCleanup.Size = New System.Drawing.Size(221, 26)
        Me.mnuDataCleanup.Text = "Data Cleanup"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(218, 6)
        '
        'mnuJobManager
        '
        Me.mnuJobManager.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuJobManagerStart, Me.mnuJobManagerStop})
        Me.mnuJobManager.Name = "mnuJobManager"
        Me.mnuJobManager.Size = New System.Drawing.Size(221, 26)
        Me.mnuJobManager.Text = " Job Manage"
        '
        'mnuJobManagerStart
        '
        Me.mnuJobManagerStart.Name = "mnuJobManagerStart"
        Me.mnuJobManagerStart.Size = New System.Drawing.Size(123, 26)
        Me.mnuJobManagerStart.Text = "Start"
        '
        'mnuJobManagerStop
        '
        Me.mnuJobManagerStop.Name = "mnuJobManagerStop"
        Me.mnuJobManagerStop.Size = New System.Drawing.Size(123, 26)
        Me.mnuJobManagerStop.Text = "Stop"
        '
        'mnuHelp
        '
        Me.mnuHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuHelpAbout})
        Me.mnuHelp.Name = "mnuHelp"
        Me.mnuHelp.Size = New System.Drawing.Size(55, 26)
        Me.mnuHelp.Text = "Help"
        '
        'mnuHelpAbout
        '
        Me.mnuHelpAbout.Name = "mnuHelpAbout"
        Me.mnuHelpAbout.Size = New System.Drawing.Size(133, 26)
        Me.mnuHelpAbout.Text = "About"
        '
        'mnuJobSchedule
        '
        Me.mnuJobSchedule.Image = CType(resources.GetObject("mnuJobSchedule.Image"), System.Drawing.Image)
        Me.mnuJobSchedule.Name = "mnuJobSchedule"
        Me.mnuJobSchedule.Size = New System.Drawing.Size(224, 26)
        Me.mnuJobSchedule.Text = "&Schedule Manager"
        '
        'mnuJobMananger
        '
        Me.mnuJobMananger.Image = CType(resources.GetObject("mnuJobMananger.Image"), System.Drawing.Image)
        Me.mnuJobMananger.Name = "mnuJobMananger"
        Me.mnuJobMananger.Size = New System.Drawing.Size(224, 26)
        Me.mnuJobMananger.Text = "Job &Manager"
        '
        'mnuAlgoSettings
        '
        Me.mnuAlgoSettings.Image = CType(resources.GetObject("mnuAlgoSettings.Image"), System.Drawing.Image)
        Me.mnuAlgoSettings.Name = "mnuAlgoSettings"
        Me.mnuAlgoSettings.Size = New System.Drawing.Size(224, 26)
        Me.mnuAlgoSettings.Text = "&Algo Settings"
        '
        'ucAccount
        '
        Me.ucAccount.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ucAccount.Location = New System.Drawing.Point(4, 4)
        Me.ucAccount.Margin = New System.Windows.Forms.Padding(5)
        Me.ucAccount.Name = "ucAccount"
        Me.ucAccount.Size = New System.Drawing.Size(1621, 492)
        Me.ucAccount.TabIndex = 0
        '
        'ucOrder
        '
        Me.ucOrder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ucOrder.Location = New System.Drawing.Point(0, 0)
        Me.ucOrder.Margin = New System.Windows.Forms.Padding(5)
        Me.ucOrder.Name = "ucOrder"
        Me.ucOrder.Size = New System.Drawing.Size(1629, 500)
        Me.ucOrder.TabIndex = 0
        '
        'ucPositions
        '
        Me.ucPositions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ucPositions.Location = New System.Drawing.Point(0, 0)
        Me.ucPositions.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ucPositions.Name = "ucPositions"
        Me.ucPositions.Size = New System.Drawing.Size(1629, 500)
        Me.ucPositions.TabIndex = 0
        '
        'ucStocks
        '
        Me.ucStocks.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ucStocks.Location = New System.Drawing.Point(0, 0)
        Me.ucStocks.Margin = New System.Windows.Forms.Padding(5)
        Me.ucStocks.Name = "ucStocks"
        Me.ucStocks.Size = New System.Drawing.Size(1629, 500)
        Me.ucStocks.TabIndex = 0
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1637, 592)
        Me.Controls.Add(Me.tabctrl)
        Me.Controls.Add(Me.sbMain)
        Me.Controls.Add(Me.mnuMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BotTrader (Algo Platform)"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.sbMain.ResumeLayout(False)
        Me.sbMain.PerformLayout()
        Me.tpStocks.ResumeLayout(False)
        Me.tpPositions.ResumeLayout(False)
        Me.tpOrders.ResumeLayout(False)
        Me.tpMain.ResumeLayout(False)
        Me.tabctrl.ResumeLayout(False)
        Me.mnuMain.ResumeLayout(False)
        Me.mnuMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents sbMain As StatusStrip
    Friend WithEvents pMsgInfo As ToolStripStatusLabel
    Friend WithEvents pProgressBar As ToolStripProgressBar
    Friend WithEvents pUser As ToolStripStatusLabel
    Friend WithEvents ilMainTab As ImageList
    Friend WithEvents pPermission As ToolStripStatusLabel
    Friend WithEvents pRunMode As ToolStripStatusLabel
    Friend WithEvents tpStocks As TabPage
    Friend WithEvents btnWatchList As Button
    Friend WithEvents ucStocks As ucStocks
    Friend WithEvents tpPositions As TabPage
    Friend WithEvents ucPositions As ucPositions
    Friend WithEvents tpOrders As TabPage
    Friend WithEvents ucOrder As ucOrderLog
    Friend WithEvents tpMain As TabPage
    Friend WithEvents ucAccount As ucAccount
    Friend WithEvents tabctrl As TabControl
    Friend WithEvents mnuMain As MenuStrip
    Friend WithEvents mnuTools As ToolStripMenuItem
    Friend WithEvents mnuJobSchedule As ToolStripMenuItem
    Friend WithEvents mnuJobMananger As ToolStripMenuItem
    Friend WithEvents mnuAlgoSettings As ToolStripMenuItem
    Friend WithEvents mnuJobs As ToolStripMenuItem
    Friend WithEvents mnuRefreshAssetData As ToolStripMenuItem
    Friend WithEvents mnuLiveTrade As ToolStripMenuItem
    Friend WithEvents mnuPaperTrade As ToolStripMenuItem
    Friend WithEvents mnuDataCleanup As ToolStripMenuItem
    Friend WithEvents mnuHelp As ToolStripMenuItem
    Friend WithEvents mnuHelpAbout As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents mnuJobManager As ToolStripMenuItem
    Friend WithEvents mnuJobManagerStart As ToolStripMenuItem
    Friend WithEvents mnuJobManagerStop As ToolStripMenuItem
    Friend WithEvents pServiceStatus As ToolStripStatusLabel
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents mnuRunMode As ToolStripMenuItem
    Friend WithEvents mnuRunModeThreaded As ToolStripMenuItem
    Friend WithEvents mnuRunModeDebug As ToolStripMenuItem
    Friend WithEvents mnuRefreshAssetScore As ToolStripMenuItem
End Class
