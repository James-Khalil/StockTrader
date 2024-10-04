<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucBacktesting
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.tlpMain = New System.Windows.Forms.TableLayoutPanel()
        Me.chrtPortPrfm = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.grpboxAcctInfo = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbSearch = New System.Windows.Forms.TextBox()
        Me.cBoxDuration = New System.Windows.Forms.ComboBox()
        Me.lvOrders = New System.Windows.Forms.ListView()
        Me.tlpMain.SuspendLayout()
        CType(Me.chrtPortPrfm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpboxAcctInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlpMain
        '
        Me.tlpMain.ColumnCount = 2
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpMain.Controls.Add(Me.chrtPortPrfm, 0, 3)
        Me.tlpMain.Controls.Add(Me.grpboxAcctInfo, 1, 1)
        Me.tlpMain.Controls.Add(Me.lvOrders, 0, 1)
        Me.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMain.Location = New System.Drawing.Point(0, 0)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.RowCount = 5
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpMain.Size = New System.Drawing.Size(1011, 481)
        Me.tlpMain.TabIndex = 16
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
        Me.tlpMain.SetColumnSpan(Me.chrtPortPrfm, 2)
        Me.chrtPortPrfm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chrtPortPrfm.Location = New System.Drawing.Point(3, 256)
        Me.chrtPortPrfm.Name = "chrtPortPrfm"
        Me.chrtPortPrfm.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright
        Series1.ChartArea = "chrtAreaPortPrfm"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series1.Name = "Series1"
        Me.chrtPortPrfm.Series.Add(Series1)
        Me.chrtPortPrfm.Size = New System.Drawing.Size(1005, 202)
        Me.chrtPortPrfm.TabIndex = 1
        Me.chrtPortPrfm.Text = "Chart1"
        '
        'grpboxAcctInfo
        '
        Me.grpboxAcctInfo.Controls.Add(Me.Label2)
        Me.grpboxAcctInfo.Controls.Add(Me.Label1)
        Me.grpboxAcctInfo.Controls.Add(Me.tbSearch)
        Me.grpboxAcctInfo.Controls.Add(Me.cBoxDuration)
        Me.grpboxAcctInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpboxAcctInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpboxAcctInfo.Location = New System.Drawing.Point(508, 23)
        Me.grpboxAcctInfo.Name = "grpboxAcctInfo"
        Me.grpboxAcctInfo.Size = New System.Drawing.Size(500, 202)
        Me.grpboxAcctInfo.TabIndex = 3
        Me.grpboxAcctInfo.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(125, 6)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Duration"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 6)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Search"
        '
        'tbSearch
        '
        Me.tbSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.tbSearch.Location = New System.Drawing.Point(11, 26)
        Me.tbSearch.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.tbSearch.Name = "tbSearch"
        Me.tbSearch.Size = New System.Drawing.Size(73, 20)
        Me.tbSearch.TabIndex = 11
        '
        'cBoxDuration
        '
        Me.cBoxDuration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cBoxDuration.Enabled = False
        Me.cBoxDuration.FormattingEnabled = True
        Me.cBoxDuration.Items.AddRange(New Object() {"Day", "Week", "Month", "Year", "5 Years"})
        Me.cBoxDuration.Location = New System.Drawing.Point(128, 24)
        Me.cBoxDuration.Name = "cBoxDuration"
        Me.cBoxDuration.Size = New System.Drawing.Size(64, 21)
        Me.cBoxDuration.TabIndex = 10
        '
        'lvOrders
        '
        Me.lvOrders.AllowColumnReorder = True
        Me.lvOrders.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvOrders.FullRowSelect = True
        Me.lvOrders.HideSelection = False
        Me.lvOrders.Location = New System.Drawing.Point(3, 23)
        Me.lvOrders.MultiSelect = False
        Me.lvOrders.Name = "lvOrders"
        Me.lvOrders.Size = New System.Drawing.Size(499, 202)
        Me.lvOrders.TabIndex = 10
        Me.lvOrders.UseCompatibleStateImageBehavior = False
        Me.lvOrders.View = System.Windows.Forms.View.Details
        '
        'ucBacktesting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tlpMain)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "ucBacktesting"
        Me.Size = New System.Drawing.Size(1011, 481)
        Me.tlpMain.ResumeLayout(False)
        CType(Me.chrtPortPrfm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpboxAcctInfo.ResumeLayout(False)
        Me.grpboxAcctInfo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tlpMain As TableLayoutPanel
    Friend WithEvents grpboxAcctInfo As GroupBox
    Friend WithEvents chrtPortPrfm As DataVisualization.Charting.Chart
    Friend WithEvents lvOrders As ListView
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents tbSearch As TextBox
    Friend WithEvents cBoxDuration As ComboBox
End Class
