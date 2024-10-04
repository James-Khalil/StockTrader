<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucAccount
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.tlpMain = New System.Windows.Forms.TableLayoutPanel()
        Me.grpboxAcctInfo = New System.Windows.Forms.GroupBox()
        Me.txtCash = New System.Windows.Forms.TextBox()
        Me.lblCash = New System.Windows.Forms.Label()
        Me.txtBuyPwr = New System.Windows.Forms.TextBox()
        Me.lblBuyPower = New System.Windows.Forms.Label()
        Me.txtEqty = New System.Windows.Forms.TextBox()
        Me.lblEquity = New System.Windows.Forms.Label()
        Me.txtAcctName = New System.Windows.Forms.TextBox()
        Me.lblAcctName = New System.Windows.Forms.Label()
        Me.txtAcctNum = New System.Windows.Forms.TextBox()
        Me.lblAcctNum = New System.Windows.Forms.Label()
        Me.chrtPortPrfm = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.cboxPortPrfm = New System.Windows.Forms.ComboBox()
        Me.tlpMain.SuspendLayout()
        Me.grpboxAcctInfo.SuspendLayout()
        CType(Me.chrtPortPrfm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlpMain
        '
        Me.tlpMain.ColumnCount = 1
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpMain.Controls.Add(Me.grpboxAcctInfo, 0, 1)
        Me.tlpMain.Controls.Add(Me.chrtPortPrfm, 0, 3)
        Me.tlpMain.Controls.Add(Me.cboxPortPrfm, 0, 2)
        Me.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMain.Location = New System.Drawing.Point(0, 0)
        Me.tlpMain.Margin = New System.Windows.Forms.Padding(4)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.RowCount = 5
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpMain.Size = New System.Drawing.Size(1163, 761)
        Me.tlpMain.TabIndex = 15
        '
        'grpboxAcctInfo
        '
        Me.grpboxAcctInfo.Controls.Add(Me.txtCash)
        Me.grpboxAcctInfo.Controls.Add(Me.lblCash)
        Me.grpboxAcctInfo.Controls.Add(Me.txtBuyPwr)
        Me.grpboxAcctInfo.Controls.Add(Me.lblBuyPower)
        Me.grpboxAcctInfo.Controls.Add(Me.txtEqty)
        Me.grpboxAcctInfo.Controls.Add(Me.lblEquity)
        Me.grpboxAcctInfo.Controls.Add(Me.txtAcctName)
        Me.grpboxAcctInfo.Controls.Add(Me.lblAcctName)
        Me.grpboxAcctInfo.Controls.Add(Me.txtAcctNum)
        Me.grpboxAcctInfo.Controls.Add(Me.lblAcctNum)
        Me.grpboxAcctInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpboxAcctInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpboxAcctInfo.ForeColor = System.Drawing.Color.Maroon
        Me.grpboxAcctInfo.Location = New System.Drawing.Point(4, 29)
        Me.grpboxAcctInfo.Margin = New System.Windows.Forms.Padding(4)
        Me.grpboxAcctInfo.Name = "grpboxAcctInfo"
        Me.grpboxAcctInfo.Padding = New System.Windows.Forms.Padding(4)
        Me.grpboxAcctInfo.Size = New System.Drawing.Size(1155, 332)
        Me.grpboxAcctInfo.TabIndex = 3
        Me.grpboxAcctInfo.TabStop = False
        Me.grpboxAcctInfo.Text = "Account Information"
        '
        'txtCash
        '
        Me.txtCash.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtCash.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCash.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtCash.Location = New System.Drawing.Point(21, 289)
        Me.txtCash.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCash.Name = "txtCash"
        Me.txtCash.ReadOnly = True
        Me.txtCash.Size = New System.Drawing.Size(145, 24)
        Me.txtCash.TabIndex = 5
        Me.txtCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCash
        '
        Me.lblCash.AutoSize = True
        Me.lblCash.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCash.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCash.Location = New System.Drawing.Point(17, 267)
        Me.lblCash.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCash.Name = "lblCash"
        Me.lblCash.Size = New System.Drawing.Size(43, 18)
        Me.lblCash.TabIndex = 0
        Me.lblCash.Text = "Cash"
        '
        'txtBuyPwr
        '
        Me.txtBuyPwr.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtBuyPwr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBuyPwr.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtBuyPwr.Location = New System.Drawing.Point(21, 229)
        Me.txtBuyPwr.Margin = New System.Windows.Forms.Padding(4)
        Me.txtBuyPwr.Name = "txtBuyPwr"
        Me.txtBuyPwr.ReadOnly = True
        Me.txtBuyPwr.Size = New System.Drawing.Size(145, 24)
        Me.txtBuyPwr.TabIndex = 5
        Me.txtBuyPwr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblBuyPower
        '
        Me.lblBuyPower.AutoSize = True
        Me.lblBuyPower.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBuyPower.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblBuyPower.Location = New System.Drawing.Point(17, 207)
        Me.lblBuyPower.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblBuyPower.Name = "lblBuyPower"
        Me.lblBuyPower.Size = New System.Drawing.Size(99, 18)
        Me.lblBuyPower.TabIndex = 0
        Me.lblBuyPower.Text = "Buying Power"
        '
        'txtEqty
        '
        Me.txtEqty.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtEqty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEqty.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtEqty.Location = New System.Drawing.Point(21, 169)
        Me.txtEqty.Margin = New System.Windows.Forms.Padding(4)
        Me.txtEqty.Name = "txtEqty"
        Me.txtEqty.ReadOnly = True
        Me.txtEqty.Size = New System.Drawing.Size(145, 24)
        Me.txtEqty.TabIndex = 5
        Me.txtEqty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblEquity
        '
        Me.lblEquity.AutoSize = True
        Me.lblEquity.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEquity.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblEquity.Location = New System.Drawing.Point(17, 146)
        Me.lblEquity.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblEquity.Name = "lblEquity"
        Me.lblEquity.Size = New System.Drawing.Size(48, 18)
        Me.lblEquity.TabIndex = 0
        Me.lblEquity.Text = "Equity"
        '
        'txtAcctName
        '
        Me.txtAcctName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAcctName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtAcctName.Location = New System.Drawing.Point(21, 108)
        Me.txtAcctName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAcctName.Name = "txtAcctName"
        Me.txtAcctName.ReadOnly = True
        Me.txtAcctName.Size = New System.Drawing.Size(332, 24)
        Me.txtAcctName.TabIndex = 5
        '
        'lblAcctName
        '
        Me.lblAcctName.AutoSize = True
        Me.lblAcctName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAcctName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAcctName.Location = New System.Drawing.Point(17, 86)
        Me.lblAcctName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAcctName.Name = "lblAcctName"
        Me.lblAcctName.Size = New System.Drawing.Size(106, 18)
        Me.lblAcctName.TabIndex = 0
        Me.lblAcctName.Text = "Account Name"
        '
        'txtAcctNum
        '
        Me.txtAcctNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAcctNum.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtAcctNum.Location = New System.Drawing.Point(21, 48)
        Me.txtAcctNum.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAcctNum.Name = "txtAcctNum"
        Me.txtAcctNum.ReadOnly = True
        Me.txtAcctNum.Size = New System.Drawing.Size(332, 24)
        Me.txtAcctNum.TabIndex = 5
        '
        'lblAcctNum
        '
        Me.lblAcctNum.AutoSize = True
        Me.lblAcctNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAcctNum.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAcctNum.Location = New System.Drawing.Point(17, 27)
        Me.lblAcctNum.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAcctNum.Name = "lblAcctNum"
        Me.lblAcctNum.Size = New System.Drawing.Size(74, 18)
        Me.lblAcctNum.TabIndex = 0
        Me.lblAcctNum.Text = "Account #"
        '
        'chrtPortPrfm
        '
        ChartArea1.AxisX.IsStartedFromZero = False
        ChartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray
        ChartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash
        ChartArea1.AxisY.IsStartedFromZero = False
        ChartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray
        ChartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash
        ChartArea1.Name = "chrtAreaPortPrfm"
        Me.chrtPortPrfm.ChartAreas.Add(ChartArea1)
        Me.chrtPortPrfm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chrtPortPrfm.Location = New System.Drawing.Point(4, 400)
        Me.chrtPortPrfm.Margin = New System.Windows.Forms.Padding(4)
        Me.chrtPortPrfm.Name = "chrtPortPrfm"
        Me.chrtPortPrfm.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright
        Series1.ChartArea = "chrtAreaPortPrfm"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series1.Name = "Series1"
        Me.chrtPortPrfm.Series.Add(Series1)
        Me.chrtPortPrfm.Size = New System.Drawing.Size(1155, 332)
        Me.chrtPortPrfm.TabIndex = 1
        Me.chrtPortPrfm.Text = "Chart1"
        '
        'cboxPortPrfm
        '
        Me.cboxPortPrfm.Dock = System.Windows.Forms.DockStyle.Right
        Me.cboxPortPrfm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxPortPrfm.FormattingEnabled = True
        Me.cboxPortPrfm.Items.AddRange(New Object() {"Day", "Week", "Month", "Year", "5 Years"})
        Me.cboxPortPrfm.Location = New System.Drawing.Point(1048, 369)
        Me.cboxPortPrfm.Margin = New System.Windows.Forms.Padding(4)
        Me.cboxPortPrfm.Name = "cboxPortPrfm"
        Me.cboxPortPrfm.Size = New System.Drawing.Size(111, 24)
        Me.cboxPortPrfm.TabIndex = 2
        '
        'ucAccount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tlpMain)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "ucAccount"
        Me.Size = New System.Drawing.Size(1163, 761)
        Me.tlpMain.ResumeLayout(False)
        Me.grpboxAcctInfo.ResumeLayout(False)
        Me.grpboxAcctInfo.PerformLayout()
        CType(Me.chrtPortPrfm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tlpMain As TableLayoutPanel
    Friend WithEvents grpboxAcctInfo As GroupBox
    Friend WithEvents txtCash As TextBox
    Friend WithEvents lblCash As Label
    Friend WithEvents txtBuyPwr As TextBox
    Friend WithEvents lblBuyPower As Label
    Friend WithEvents txtEqty As TextBox
    Friend WithEvents lblEquity As Label
    Friend WithEvents txtAcctName As TextBox
    Friend WithEvents lblAcctName As Label
    Friend WithEvents txtAcctNum As TextBox
    Friend WithEvents lblAcctNum As Label
    Friend WithEvents chrtPortPrfm As DataVisualization.Charting.Chart
    Friend WithEvents cboxPortPrfm As ComboBox
End Class
