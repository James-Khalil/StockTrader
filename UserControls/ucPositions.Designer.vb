<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucPositions
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
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea3 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend3 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.tlpMain = New System.Windows.Forms.TableLayoutPanel()
        Me.lvAssets = New System.Windows.Forms.ListView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chrtSectors = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.chrtSide = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.chrtClass = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.tlpMain.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.chrtSectors, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chrtSide, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chrtClass, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlpMain
        '
        Me.tlpMain.ColumnCount = 2
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpMain.Controls.Add(Me.lvAssets, 0, 1)
        Me.tlpMain.Controls.Add(Me.Panel1, 1, 1)
        Me.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMain.Location = New System.Drawing.Point(0, 0)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.RowCount = 3
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpMain.Size = New System.Drawing.Size(1357, 622)
        Me.tlpMain.TabIndex = 0
        '
        'lvAssets
        '
        Me.lvAssets.AllowColumnReorder = True
        Me.lvAssets.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvAssets.FullRowSelect = True
        Me.lvAssets.HideSelection = False
        Me.lvAssets.Location = New System.Drawing.Point(4, 24)
        Me.lvAssets.Margin = New System.Windows.Forms.Padding(4)
        Me.lvAssets.MultiSelect = False
        Me.lvAssets.Name = "lvAssets"
        Me.lvAssets.Size = New System.Drawing.Size(670, 574)
        Me.lvAssets.TabIndex = 2
        Me.lvAssets.UseCompatibleStateImageBehavior = False
        Me.lvAssets.View = System.Windows.Forms.View.Details
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.chrtSectors)
        Me.Panel1.Controls.Add(Me.chrtSide)
        Me.Panel1.Controls.Add(Me.chrtClass)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(681, 23)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(673, 576)
        Me.Panel1.TabIndex = 0
        '
        'chrtSectors
        '
        ChartArea1.Name = "ChartArea1"
        Me.chrtSectors.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.chrtSectors.Legends.Add(Legend1)
        Me.chrtSectors.Location = New System.Drawing.Point(438, 66)
        Me.chrtSectors.Name = "chrtSectors"
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.chrtSectors.Series.Add(Series1)
        Me.chrtSectors.Size = New System.Drawing.Size(338, 236)
        Me.chrtSectors.TabIndex = 2
        Me.chrtSectors.Text = "Chart2"
        '
        'chrtSide
        '
        ChartArea2.Name = "ChartArea1"
        Me.chrtSide.ChartAreas.Add(ChartArea2)
        Legend2.Name = "Legend1"
        Me.chrtSide.Legends.Add(Legend2)
        Me.chrtSide.Location = New System.Drawing.Point(15, 337)
        Me.chrtSide.Name = "chrtSide"
        Series2.ChartArea = "ChartArea1"
        Series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
        Series2.Legend = "Legend1"
        Series2.Name = "Series1"
        Me.chrtSide.Series.Add(Series2)
        Me.chrtSide.Size = New System.Drawing.Size(326, 236)
        Me.chrtSide.TabIndex = 1
        Me.chrtSide.Text = "Chart2"
        '
        'chrtClass
        '
        ChartArea3.Name = "ChartArea1"
        Me.chrtClass.ChartAreas.Add(ChartArea3)
        Legend3.Name = "Legend1"
        Me.chrtClass.Legends.Add(Legend3)
        Me.chrtClass.Location = New System.Drawing.Point(15, 66)
        Me.chrtClass.Name = "chrtClass"
        Me.chrtClass.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent
        Series3.ChartArea = "ChartArea1"
        Series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
        Series3.CustomProperties = "PieLabelStyle=Disabled"
        Series3.Legend = "Legend1"
        Series3.Name = "oSeriesClass"
        Me.chrtClass.Series.Add(Series3)
        Me.chrtClass.Size = New System.Drawing.Size(338, 236)
        Me.chrtClass.TabIndex = 0
        Me.chrtClass.Text = "Chart1"
        '
        'ucPositions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tlpMain)
        Me.Name = "ucPositions"
        Me.Size = New System.Drawing.Size(1357, 622)
        Me.tlpMain.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.chrtSectors, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chrtSide, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chrtClass, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tlpMain As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents chrtClass As DataVisualization.Charting.Chart
    Friend WithEvents chrtSide As DataVisualization.Charting.Chart
    Friend WithEvents lvAssets As ListView
    Friend WithEvents chrtSectors As DataVisualization.Charting.Chart
End Class
