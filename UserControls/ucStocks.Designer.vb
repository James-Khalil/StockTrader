<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucStocks
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
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.tlpMain = New System.Windows.Forms.TableLayoutPanel()
        Me.chrtPrice = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnBuy = New System.Windows.Forms.Button()
        Me.tbSearch = New System.Windows.Forms.TextBox()
        Me.cboxPortPrfm = New System.Windows.Forms.ComboBox()
        Me.chrtExtras = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.tlpMain.SuspendLayout()
        CType(Me.chrtPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.chrtExtras, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlpMain
        '
        Me.tlpMain.ColumnCount = 1
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlpMain.Controls.Add(Me.chrtPrice, 0, 1)
        Me.tlpMain.Controls.Add(Me.Panel1, 0, 0)
        Me.tlpMain.Controls.Add(Me.chrtExtras, 0, 2)
        Me.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMain.Location = New System.Drawing.Point(0, 0)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.RowCount = 4
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.66666!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.tlpMain.Size = New System.Drawing.Size(1058, 559)
        Me.tlpMain.TabIndex = 0
        '
        'chrtPrice
        '
        ChartArea1.AxisX.IsStartedFromZero = False
        ChartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray
        ChartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash
        ChartArea1.AxisY.IsStartedFromZero = False
        ChartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray
        ChartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash
        ChartArea1.Name = "chrtAreaPrice"
        Me.chrtPrice.ChartAreas.Add(ChartArea1)
        Me.chrtPrice.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chrtPrice.Location = New System.Drawing.Point(3, 53)
        Me.chrtPrice.Name = "chrtPrice"
        Me.chrtPrice.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright
        Series1.ChartArea = "chrtAreaPrice"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series1.Name = "Series1"
        Me.chrtPrice.Series.Add(Series1)
        Me.chrtPrice.Size = New System.Drawing.Size(1052, 300)
        Me.chrtPrice.TabIndex = 2
        Me.chrtPrice.Text = "Chart1"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.btnBuy)
        Me.Panel1.Controls.Add(Me.tbSearch)
        Me.Panel1.Controls.Add(Me.cboxPortPrfm)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(2, 2)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1054, 46)
        Me.Panel1.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(299, 1)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Duration"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(183, 1)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Search"
        '
        'btnBuy
        '
        Me.btnBuy.Enabled = False
        Me.btnBuy.Location = New System.Drawing.Point(10, 5)
        Me.btnBuy.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnBuy.Name = "btnBuy"
        Me.btnBuy.Size = New System.Drawing.Size(71, 33)
        Me.btnBuy.TabIndex = 7
        Me.btnBuy.Text = "Buy"
        Me.btnBuy.UseVisualStyleBackColor = True
        '
        'tbSearch
        '
        Me.tbSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.tbSearch.Location = New System.Drawing.Point(185, 20)
        Me.tbSearch.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.tbSearch.Name = "tbSearch"
        Me.tbSearch.Size = New System.Drawing.Size(73, 20)
        Me.tbSearch.TabIndex = 4
        '
        'cboxPortPrfm
        '
        Me.cboxPortPrfm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxPortPrfm.Enabled = False
        Me.cboxPortPrfm.FormattingEnabled = True
        Me.cboxPortPrfm.Items.AddRange(New Object() {"Day", "Week", "Month", "Year", "5 Years"})
        Me.cboxPortPrfm.Location = New System.Drawing.Point(302, 19)
        Me.cboxPortPrfm.Name = "cboxPortPrfm"
        Me.cboxPortPrfm.Size = New System.Drawing.Size(64, 21)
        Me.cboxPortPrfm.TabIndex = 3
        '
        'chrtExtras
        '
        ChartArea2.AxisX.IsStartedFromZero = False
        ChartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray
        ChartArea2.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash
        ChartArea2.AxisY.IsStartedFromZero = False
        ChartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray
        ChartArea2.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash
        ChartArea2.Name = "chrtAreaExtras"
        Me.chrtExtras.ChartAreas.Add(ChartArea2)
        Me.chrtExtras.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chrtExtras.Location = New System.Drawing.Point(3, 359)
        Me.chrtExtras.Name = "chrtExtras"
        Me.chrtExtras.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright
        Series2.ChartArea = "chrtAreaExtras"
        Series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series2.Name = "Series1"
        Me.chrtExtras.Series.Add(Series2)
        Me.chrtExtras.Size = New System.Drawing.Size(1052, 147)
        Me.chrtExtras.TabIndex = 5
        Me.chrtExtras.Text = "Chart1"
        '
        'ucStocks
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tlpMain)
        Me.Name = "ucStocks"
        Me.Size = New System.Drawing.Size(1058, 559)
        Me.tlpMain.ResumeLayout(False)
        CType(Me.chrtPrice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.chrtExtras, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tlpMain As TableLayoutPanel
    Friend WithEvents chrtPrice As DataVisualization.Charting.Chart
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnBuy As Button
    Friend WithEvents tbSearch As TextBox
    Friend WithEvents cboxPortPrfm As ComboBox
    Friend WithEvents chrtExtras As DataVisualization.Charting.Chart
End Class
