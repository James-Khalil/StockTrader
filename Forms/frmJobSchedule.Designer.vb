<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJobSchedule
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmJobSchedule))
        Me.tlpMain = New System.Windows.Forms.TableLayoutPanel()
        Me.lvSchedule = New System.Windows.Forms.ListView()
        Me.JobTypeID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.LastJobID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.NextRunTime = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Monday = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Tuesday = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Wednesday = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Thursday = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Friday = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Saturday = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Sunday = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ActiveFlag = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.mnuSchedule = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuAddSchedule = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEditSchedule = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDeleteSchedule = New System.Windows.Forms.ToolStripMenuItem()
        Me.ilSchedule = New System.Windows.Forms.ImageList(Me.components)
        Me.btnClose = New System.Windows.Forms.Button()
        Me.tlpMain.SuspendLayout()
        Me.mnuSchedule.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlpMain
        '
        Me.tlpMain.ColumnCount = 1
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.Controls.Add(Me.lvSchedule, 0, 0)
        Me.tlpMain.Controls.Add(Me.btnClose, 0, 1)
        Me.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMain.Location = New System.Drawing.Point(0, 0)
        Me.tlpMain.Margin = New System.Windows.Forms.Padding(4)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.RowCount = 2
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.tlpMain.Size = New System.Drawing.Size(1398, 511)
        Me.tlpMain.TabIndex = 17
        '
        'lvSchedule
        '
        Me.lvSchedule.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.JobTypeID, Me.LastJobID, Me.NextRunTime, Me.Monday, Me.Tuesday, Me.Wednesday, Me.Thursday, Me.Friday, Me.Saturday, Me.Sunday, Me.ActiveFlag})
        Me.lvSchedule.ContextMenuStrip = Me.mnuSchedule
        Me.lvSchedule.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvSchedule.FullRowSelect = True
        Me.lvSchedule.GridLines = True
        Me.lvSchedule.HideSelection = False
        Me.lvSchedule.Location = New System.Drawing.Point(3, 3)
        Me.lvSchedule.MultiSelect = False
        Me.lvSchedule.Name = "lvSchedule"
        Me.lvSchedule.Size = New System.Drawing.Size(1392, 469)
        Me.lvSchedule.TabIndex = 0
        Me.lvSchedule.UseCompatibleStateImageBehavior = False
        Me.lvSchedule.View = System.Windows.Forms.View.Details
        '
        'JobTypeID
        '
        Me.JobTypeID.Tag = "JobTypeID"
        Me.JobTypeID.Text = "Job Type"
        Me.JobTypeID.Width = 130
        '
        'LastJobID
        '
        Me.LastJobID.Tag = "LastJobID"
        Me.LastJobID.Text = "Last Job ID"
        Me.LastJobID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.LastJobID.Width = 85
        '
        'NextRunTime
        '
        Me.NextRunTime.Tag = "NextRunTime"
        Me.NextRunTime.Text = "Next Run"
        Me.NextRunTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NextRunTime.Width = 130
        '
        'Monday
        '
        Me.Monday.Tag = "Monday"
        Me.Monday.Text = "Monday"
        Me.Monday.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Monday.Width = 90
        '
        'Tuesday
        '
        Me.Tuesday.Tag = "Tuesday"
        Me.Tuesday.Text = "Tuesday"
        Me.Tuesday.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Tuesday.Width = 90
        '
        'Wednesday
        '
        Me.Wednesday.Tag = "Wednesday"
        Me.Wednesday.Text = "Wednesday"
        Me.Wednesday.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Wednesday.Width = 90
        '
        'Thursday
        '
        Me.Thursday.Tag = "Thursday"
        Me.Thursday.Text = "Thursday"
        Me.Thursday.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Thursday.Width = 90
        '
        'Friday
        '
        Me.Friday.Tag = "Friday"
        Me.Friday.Text = "Friday"
        Me.Friday.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Friday.Width = 90
        '
        'Saturday
        '
        Me.Saturday.Tag = "Saturday"
        Me.Saturday.Text = "Saturday"
        Me.Saturday.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Saturday.Width = 90
        '
        'Sunday
        '
        Me.Sunday.Tag = "Sunday"
        Me.Sunday.Text = "Sunday"
        Me.Sunday.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Sunday.Width = 90
        '
        'ActiveFlag
        '
        Me.ActiveFlag.Tag = "ActiveFlag"
        Me.ActiveFlag.Text = "Active"
        Me.ActiveFlag.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'mnuSchedule
        '
        Me.mnuSchedule.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.mnuSchedule.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAddSchedule, Me.mnuEditSchedule, Me.mnuDeleteSchedule})
        Me.mnuSchedule.Name = "ContextMenuStrip1"
        Me.mnuSchedule.Size = New System.Drawing.Size(168, 76)
        '
        'mnuAddSchedule
        '
        Me.mnuAddSchedule.Name = "mnuAddSchedule"
        Me.mnuAddSchedule.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.mnuAddSchedule.Size = New System.Drawing.Size(167, 24)
        Me.mnuAddSchedule.Text = "&Add..."
        '
        'mnuEditSchedule
        '
        Me.mnuEditSchedule.Name = "mnuEditSchedule"
        Me.mnuEditSchedule.Size = New System.Drawing.Size(167, 24)
        Me.mnuEditSchedule.Text = "&Edit..."
        '
        'mnuDeleteSchedule
        '
        Me.mnuDeleteSchedule.Name = "mnuDeleteSchedule"
        Me.mnuDeleteSchedule.Size = New System.Drawing.Size(167, 24)
        Me.mnuDeleteSchedule.Text = "&Delete..."
        '
        'ilSchedule
        '
        Me.ilSchedule.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ilSchedule.ImageSize = New System.Drawing.Size(16, 16)
        Me.ilSchedule.TransparentColor = System.Drawing.Color.Transparent
        '
        'btnClose
        '
        Me.btnClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(1302, 478)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(93, 30)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "  &Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'frmScheduleManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1398, 511)
        Me.Controls.Add(Me.tlpMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmScheduleManager"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Schedule Manager"
        Me.tlpMain.ResumeLayout(False)
        Me.mnuSchedule.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tlpMain As TableLayoutPanel
    Friend WithEvents lvSchedule As ListView
    Friend WithEvents btnClose As Button
    Friend WithEvents mnuSchedule As ContextMenuStrip
    Friend WithEvents mnuAddSchedule As ToolStripMenuItem
    Friend WithEvents mnuEditSchedule As ToolStripMenuItem
    Friend WithEvents mnuDeleteSchedule As ToolStripMenuItem
    Friend WithEvents ilSchedule As ImageList
    Friend WithEvents JobTypeID As ColumnHeader
    Friend WithEvents LastJobID As ColumnHeader
    Friend WithEvents NextRunTime As ColumnHeader
    Friend WithEvents Monday As ColumnHeader
    Friend WithEvents Tuesday As ColumnHeader
    Friend WithEvents Wednesday As ColumnHeader
    Friend WithEvents Thursday As ColumnHeader
    Friend WithEvents Friday As ColumnHeader
    Friend WithEvents Saturday As ColumnHeader
    Friend WithEvents Sunday As ColumnHeader
    Friend WithEvents ActiveFlag As ColumnHeader
End Class
