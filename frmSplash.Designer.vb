<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSplash
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSplash))
        Me.pMain = New System.Windows.Forms.Panel()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.lblWinVer = New System.Windows.Forms.Label()
        Me.lblSystemDesc = New System.Windows.Forms.Label()
        Me.lblCopyright = New System.Windows.Forms.Label()
        Me.lblDatabase = New System.Windows.Forms.Label()
        Me.picboxLogo = New System.Windows.Forms.PictureBox()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.lblSQLServer = New System.Windows.Forms.Label()
        Me.pMain.SuspendLayout()
        CType(Me.picboxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pMain
        '
        Me.pMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pMain.Controls.Add(Me.lblVersion)
        Me.pMain.Controls.Add(Me.lblWinVer)
        Me.pMain.Controls.Add(Me.lblSystemDesc)
        Me.pMain.Controls.Add(Me.lblCopyright)
        Me.pMain.Controls.Add(Me.lblDatabase)
        Me.pMain.Controls.Add(Me.picboxLogo)
        Me.pMain.Controls.Add(Me.lblTitle)
        Me.pMain.Controls.Add(Me.btnOK)
        Me.pMain.Controls.Add(Me.lblSQLServer)
        Me.pMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pMain.Location = New System.Drawing.Point(0, 0)
        Me.pMain.Margin = New System.Windows.Forms.Padding(2)
        Me.pMain.Name = "pMain"
        Me.pMain.Size = New System.Drawing.Size(453, 281)
        Me.pMain.TabIndex = 0
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.Location = New System.Drawing.Point(247, 93)
        Me.lblVersion.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(105, 17)
        Me.lblVersion.TabIndex = 8
        Me.lblVersion.Text = "Version: 1.65"
        '
        'lblWinVer
        '
        Me.lblWinVer.AutoSize = True
        Me.lblWinVer.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWinVer.Location = New System.Drawing.Point(246, 70)
        Me.lblWinVer.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblWinVer.Name = "lblWinVer"
        Me.lblWinVer.Size = New System.Drawing.Size(153, 17)
        Me.lblWinVer.TabIndex = 7
        Me.lblWinVer.Text = "Windows 11 (64 Bit)"
        '
        'lblSystemDesc
        '
        Me.lblSystemDesc.AutoSize = True
        Me.lblSystemDesc.Location = New System.Drawing.Point(246, 51)
        Me.lblSystemDesc.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSystemDesc.Name = "lblSystemDesc"
        Me.lblSystemDesc.Size = New System.Drawing.Size(80, 13)
        Me.lblSystemDesc.TabIndex = 6
        Me.lblSystemDesc.Text = "AI Algo Trading"
        '
        'lblCopyright
        '
        Me.lblCopyright.AutoSize = True
        Me.lblCopyright.Location = New System.Drawing.Point(9, 254)
        Me.lblCopyright.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblCopyright.Name = "lblCopyright"
        Me.lblCopyright.Size = New System.Drawing.Size(196, 13)
        Me.lblCopyright.TabIndex = 5
        Me.lblCopyright.Text = "Copyright © Pyramid Analytics Ltd. 2023"
        '
        'lblDatabase
        '
        Me.lblDatabase.AutoSize = True
        Me.lblDatabase.Location = New System.Drawing.Point(9, 235)
        Me.lblDatabase.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblDatabase.Name = "lblDatabase"
        Me.lblDatabase.Size = New System.Drawing.Size(106, 13)
        Me.lblDatabase.TabIndex = 4
        Me.lblDatabase.Text = "Database: BotTrader"
        '
        'picboxLogo
        '
        Me.picboxLogo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picboxLogo.Image = CType(resources.GetObject("picboxLogo.Image"), System.Drawing.Image)
        Me.picboxLogo.Location = New System.Drawing.Point(8, 9)
        Me.picboxLogo.Margin = New System.Windows.Forms.Padding(2)
        Me.picboxLogo.Name = "picboxLogo"
        Me.picboxLogo.Size = New System.Drawing.Size(183, 187)
        Me.picboxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picboxLogo.TabIndex = 3
        Me.picboxLogo.TabStop = False
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(244, 18)
        Me.lblTitle.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(116, 25)
        Me.lblTitle.TabIndex = 2
        Me.lblTitle.Text = "BotTrader"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(351, 233)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(2)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(90, 31)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        Me.btnOK.Visible = False
        '
        'lblSQLServer
        '
        Me.lblSQLServer.AutoSize = True
        Me.lblSQLServer.Location = New System.Drawing.Point(9, 216)
        Me.lblSQLServer.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSQLServer.Name = "lblSQLServer"
        Me.lblSQLServer.Size = New System.Drawing.Size(118, 13)
        Me.lblSQLServer.TabIndex = 0
        Me.lblSQLServer.Text = "SQL Server: ABCDEFG"
        '
        'frmSplash
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(453, 281)
        Me.ControlBox = False
        Me.Controls.Add(Me.pMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSplash"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmSplash"
        Me.pMain.ResumeLayout(False)
        Me.pMain.PerformLayout()
        CType(Me.picboxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pMain As Panel
    Friend WithEvents lblSQLServer As Label
    Friend WithEvents btnOK As Button
    Friend WithEvents lblTitle As Label
    Friend WithEvents picboxLogo As PictureBox
    Friend WithEvents lblVersion As Label
    Friend WithEvents lblWinVer As Label
    Friend WithEvents lblSystemDesc As Label
    Friend WithEvents lblCopyright As Label
    Friend WithEvents lblDatabase As Label
End Class
