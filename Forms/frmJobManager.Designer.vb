<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJobManager
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmJobManager))
        Me.lvJobs = New System.Windows.Forms.ListView()
        Me.JobID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.JobTypeID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.JobStatusID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Description = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CreateUser = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CreateTime = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.StartTime = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FinishTime = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.pSearch = New System.Windows.Forms.Panel()
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.cmbJobStatus = New System.Windows.Forms.ComboBox()
        Me.cmbJobType = New System.Windows.Forms.ComboBox()
        Me.lblJobStatus = New System.Windows.Forms.Label()
        Me.lblJobType = New System.Windows.Forms.Label()
        Me.tlpMain = New System.Windows.Forms.TableLayoutPanel()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.pSearch.SuspendLayout()
        Me.tlpMain.SuspendLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lvJobs
        '
        Me.lvJobs.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.JobID, Me.JobTypeID, Me.JobStatusID, Me.Description, Me.CreateUser, Me.CreateTime, Me.StartTime, Me.FinishTime})
        Me.lvJobs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvJobs.GridLines = True
        Me.lvJobs.HideSelection = False
        Me.lvJobs.Location = New System.Drawing.Point(2, 63)
        Me.lvJobs.Margin = New System.Windows.Forms.Padding(2)
        Me.lvJobs.Name = "lvJobs"
        Me.lvJobs.Size = New System.Drawing.Size(905, 471)
        Me.lvJobs.TabIndex = 0
        Me.lvJobs.UseCompatibleStateImageBehavior = False
        Me.lvJobs.View = System.Windows.Forms.View.Details
        '
        'JobID
        '
        Me.JobID.Tag = "JobID"
        Me.JobID.Text = "ID"
        Me.JobID.Width = 50
        '
        'JobTypeID
        '
        Me.JobTypeID.Tag = "JobTypeID"
        Me.JobTypeID.Text = "Job Type"
        Me.JobTypeID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.JobTypeID.Width = 130
        '
        'JobStatusID
        '
        Me.JobStatusID.Tag = "JobStatusID"
        Me.JobStatusID.Text = "Status"
        Me.JobStatusID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.JobStatusID.Width = 100
        '
        'Description
        '
        Me.Description.Tag = "Description"
        Me.Description.Text = "Description"
        Me.Description.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Description.Width = 100
        '
        'CreateUser
        '
        Me.CreateUser.Tag = "CreateUser"
        Me.CreateUser.Text = "Created By"
        Me.CreateUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.CreateUser.Width = 100
        '
        'CreateTime
        '
        Me.CreateTime.Tag = "CreateTime"
        Me.CreateTime.Text = "Created At"
        Me.CreateTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.CreateTime.Width = 130
        '
        'StartTime
        '
        Me.StartTime.Tag = "StartTime"
        Me.StartTime.Text = "Start Time"
        Me.StartTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.StartTime.Width = 130
        '
        'FinishTime
        '
        Me.FinishTime.Tag = "FinishTime"
        Me.FinishTime.Text = "Finish Time"
        Me.FinishTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.FinishTime.Width = 130
        '
        'pSearch
        '
        Me.pSearch.Controls.Add(Me.btnFilter)
        Me.pSearch.Controls.Add(Me.cmbJobStatus)
        Me.pSearch.Controls.Add(Me.cmbJobType)
        Me.pSearch.Controls.Add(Me.lblJobStatus)
        Me.pSearch.Controls.Add(Me.lblJobType)
        Me.pSearch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pSearch.Location = New System.Drawing.Point(2, 2)
        Me.pSearch.Margin = New System.Windows.Forms.Padding(2)
        Me.pSearch.Name = "pSearch"
        Me.pSearch.Size = New System.Drawing.Size(905, 57)
        Me.pSearch.TabIndex = 1
        '
        'btnFilter
        '
        Me.btnFilter.Image = CType(resources.GetObject("btnFilter.Image"), System.Drawing.Image)
        Me.btnFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFilter.Location = New System.Drawing.Point(349, 22)
        Me.btnFilter.Margin = New System.Windows.Forms.Padding(2)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(82, 24)
        Me.btnFilter.TabIndex = 4
        Me.btnFilter.Text = "Filter"
        Me.btnFilter.UseVisualStyleBackColor = True
        '
        'cmbJobStatus
        '
        Me.cmbJobStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbJobStatus.FormattingEnabled = True
        Me.cmbJobStatus.Location = New System.Drawing.Point(178, 27)
        Me.cmbJobStatus.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbJobStatus.Name = "cmbJobStatus"
        Me.cmbJobStatus.Size = New System.Drawing.Size(150, 21)
        Me.cmbJobStatus.TabIndex = 3
        '
        'cmbJobType
        '
        Me.cmbJobType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbJobType.FormattingEnabled = True
        Me.cmbJobType.Location = New System.Drawing.Point(9, 27)
        Me.cmbJobType.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbJobType.Name = "cmbJobType"
        Me.cmbJobType.Size = New System.Drawing.Size(151, 21)
        Me.cmbJobType.TabIndex = 2
        '
        'lblJobStatus
        '
        Me.lblJobStatus.AutoSize = True
        Me.lblJobStatus.Location = New System.Drawing.Point(176, 11)
        Me.lblJobStatus.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblJobStatus.Name = "lblJobStatus"
        Me.lblJobStatus.Size = New System.Drawing.Size(37, 13)
        Me.lblJobStatus.TabIndex = 1
        Me.lblJobStatus.Text = "Status"
        '
        'lblJobType
        '
        Me.lblJobType.AutoSize = True
        Me.lblJobType.Location = New System.Drawing.Point(10, 11)
        Me.lblJobType.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblJobType.Name = "lblJobType"
        Me.lblJobType.Size = New System.Drawing.Size(51, 13)
        Me.lblJobType.TabIndex = 0
        Me.lblJobType.Text = "Job Type"
        '
        'tlpMain
        '
        Me.tlpMain.ColumnCount = 1
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.Controls.Add(Me.btnClose, 0, 2)
        Me.tlpMain.Controls.Add(Me.lvJobs, 0, 1)
        Me.tlpMain.Controls.Add(Me.pSearch, 0, 0)
        Me.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMain.Location = New System.Drawing.Point(0, 0)
        Me.tlpMain.Margin = New System.Windows.Forms.Padding(2)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.RowCount = 3
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.tlpMain.Size = New System.Drawing.Size(909, 568)
        Me.tlpMain.TabIndex = 2
        '
        'btnClose
        '
        Me.btnClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(837, 538)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(70, 28)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "  &Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'frmJobManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(909, 568)
        Me.Controls.Add(Me.tlpMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmJobManager"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Job Manager"
        Me.pSearch.ResumeLayout(False)
        Me.pSearch.PerformLayout()
        Me.tlpMain.ResumeLayout(False)
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lvJobs As ListView
    Friend WithEvents pSearch As Panel
    Friend WithEvents cmbJobStatus As ComboBox
    Friend WithEvents cmbJobType As ComboBox
    Friend WithEvents lblJobStatus As Label
    Friend WithEvents lblJobType As Label
    Friend WithEvents JobID As ColumnHeader
    Friend WithEvents JobTypeID As ColumnHeader
    Friend WithEvents JobStatusID As ColumnHeader
    Friend WithEvents Description As ColumnHeader
    Friend WithEvents CreateUser As ColumnHeader
    Friend WithEvents CreateTime As ColumnHeader
    Friend WithEvents StartTime As ColumnHeader
    Friend WithEvents FinishTime As ColumnHeader
    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents tlpMain As TableLayoutPanel
    Friend WithEvents btnFilter As Button
    Friend WithEvents btnClose As Button
End Class
