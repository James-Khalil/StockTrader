<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucOrderLog
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucOrderLog))
        Me.tlpOrders = New System.Windows.Forms.TableLayoutPanel()
        Me.lvOrders = New System.Windows.Forms.ListView()
        Me.cmsOrders = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmiCancelOrder = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiCancelAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.clstboxFilter = New System.Windows.Forms.CheckedListBox()
        Me.cboxOrderStatus = New System.Windows.Forms.ComboBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtboxSearch = New System.Windows.Forms.TextBox()
        Me.cboxSearch = New System.Windows.Forms.ComboBox()
        Me.dtpOrdersStart = New System.Windows.Forms.DateTimePicker()
        Me.dtpOrdersEnd = New System.Windows.Forms.DateTimePicker()
        Me.tsOrders = New System.Windows.Forms.ToolStrip()
        Me.tlpOrders.SuspendLayout()
        Me.cmsOrders.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlpOrders
        '
        Me.tlpOrders.ColumnCount = 1
        Me.tlpOrders.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpOrders.Controls.Add(Me.lvOrders, 0, 1)
        Me.tlpOrders.Controls.Add(Me.Panel1, 0, 0)
        Me.tlpOrders.Controls.Add(Me.tsOrders, 0, 3)
        Me.tlpOrders.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpOrders.Location = New System.Drawing.Point(0, 0)
        Me.tlpOrders.Margin = New System.Windows.Forms.Padding(4)
        Me.tlpOrders.Name = "tlpOrders"
        Me.tlpOrders.RowCount = 4
        Me.tlpOrders.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 98.0!))
        Me.tlpOrders.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpOrders.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62.0!))
        Me.tlpOrders.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpOrders.Size = New System.Drawing.Size(1696, 700)
        Me.tlpOrders.TabIndex = 1
        '
        'lvOrders
        '
        Me.lvOrders.AllowColumnReorder = True
        Me.tlpOrders.SetColumnSpan(Me.lvOrders, 2)
        Me.lvOrders.ContextMenuStrip = Me.cmsOrders
        Me.lvOrders.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvOrders.FullRowSelect = True
        Me.lvOrders.GridLines = True
        Me.lvOrders.HideSelection = False
        Me.lvOrders.Location = New System.Drawing.Point(4, 102)
        Me.lvOrders.Margin = New System.Windows.Forms.Padding(4)
        Me.lvOrders.MultiSelect = False
        Me.lvOrders.Name = "lvOrders"
        Me.lvOrders.Size = New System.Drawing.Size(1688, 507)
        Me.lvOrders.TabIndex = 1
        Me.lvOrders.UseCompatibleStateImageBehavior = False
        Me.lvOrders.View = System.Windows.Forms.View.Details
        '
        'cmsOrders
        '
        Me.cmsOrders.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.cmsOrders.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiCancelOrder, Me.tsmiCancelAll})
        Me.cmsOrders.Name = "cmsOrderTbl"
        Me.cmsOrders.Size = New System.Drawing.Size(145, 52)
        '
        'tsmiCancelOrder
        '
        Me.tsmiCancelOrder.Name = "tsmiCancelOrder"
        Me.tsmiCancelOrder.Size = New System.Drawing.Size(144, 24)
        Me.tsmiCancelOrder.Text = "Cancel"
        '
        'tsmiCancelAll
        '
        Me.tsmiCancelAll.Name = "tsmiCancelAll"
        Me.tsmiCancelAll.Size = New System.Drawing.Size(144, 24)
        Me.tsmiCancelAll.Text = "Cancel All"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.clstboxFilter)
        Me.Panel1.Controls.Add(Me.cboxOrderStatus)
        Me.Panel1.Controls.Add(Me.btnSearch)
        Me.Panel1.Controls.Add(Me.txtboxSearch)
        Me.Panel1.Controls.Add(Me.cboxSearch)
        Me.Panel1.Controls.Add(Me.dtpOrdersStart)
        Me.Panel1.Controls.Add(Me.dtpOrdersEnd)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(4, 4)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1688, 90)
        Me.Panel1.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(848, 39)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 17)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Symbol"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(679, 39)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 17)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Type "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Maroon
        Me.Label3.Location = New System.Drawing.Point(4, 65)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(113, 18)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Orders (1234)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(413, 39)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 17)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "End Date"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(209, 39)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 17)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Start Date"
        '
        'clstboxFilter
        '
        Me.clstboxFilter.FormattingEnabled = True
        Me.clstboxFilter.Location = New System.Drawing.Point(1507, 21)
        Me.clstboxFilter.Margin = New System.Windows.Forms.Padding(4)
        Me.clstboxFilter.Name = "clstboxFilter"
        Me.clstboxFilter.Size = New System.Drawing.Size(159, 38)
        Me.clstboxFilter.TabIndex = 6
        '
        'cboxOrderStatus
        '
        Me.cboxOrderStatus.FormattingEnabled = True
        Me.cboxOrderStatus.Items.AddRange(New Object() {"Open", "Closed", "All"})
        Me.cboxOrderStatus.Location = New System.Drawing.Point(1507, 65)
        Me.cboxOrderStatus.Margin = New System.Windows.Forms.Padding(4)
        Me.cboxOrderStatus.Name = "cboxOrderStatus"
        Me.cboxOrderStatus.Size = New System.Drawing.Size(160, 24)
        Me.cboxOrderStatus.TabIndex = 5
        Me.cboxOrderStatus.Text = "Filter"
        '
        'btnSearch
        '
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSearch.Location = New System.Drawing.Point(1039, 57)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(95, 28)
        Me.btnSearch.TabIndex = 4
        Me.btnSearch.Text = "Filter"
        Me.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtboxSearch
        '
        Me.txtboxSearch.Location = New System.Drawing.Point(852, 59)
        Me.txtboxSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.txtboxSearch.Name = "txtboxSearch"
        Me.txtboxSearch.Size = New System.Drawing.Size(160, 22)
        Me.txtboxSearch.TabIndex = 3
        '
        'cboxSearch
        '
        Me.cboxSearch.FormattingEnabled = True
        Me.cboxSearch.Items.AddRange(New Object() {"Symbol", "ClientID"})
        Me.cboxSearch.Location = New System.Drawing.Point(683, 58)
        Me.cboxSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.cboxSearch.Name = "cboxSearch"
        Me.cboxSearch.Size = New System.Drawing.Size(160, 24)
        Me.cboxSearch.TabIndex = 2
        '
        'dtpOrdersStart
        '
        Me.dtpOrdersStart.Location = New System.Drawing.Point(208, 59)
        Me.dtpOrdersStart.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpOrdersStart.Name = "dtpOrdersStart"
        Me.dtpOrdersStart.Size = New System.Drawing.Size(187, 22)
        Me.dtpOrdersStart.TabIndex = 1
        '
        'dtpOrdersEnd
        '
        Me.dtpOrdersEnd.Location = New System.Drawing.Point(417, 58)
        Me.dtpOrdersEnd.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpOrdersEnd.Name = "dtpOrdersEnd"
        Me.dtpOrdersEnd.Size = New System.Drawing.Size(189, 22)
        Me.dtpOrdersEnd.TabIndex = 0
        '
        'tsOrders
        '
        Me.tsOrders.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsOrders.Location = New System.Drawing.Point(0, 675)
        Me.tsOrders.Name = "tsOrders"
        Me.tsOrders.Size = New System.Drawing.Size(1696, 25)
        Me.tsOrders.TabIndex = 5
        Me.tsOrders.Text = "Are you sure you want to delete?"
        '
        'ucOrderLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tlpOrders)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "ucOrderLog"
        Me.Size = New System.Drawing.Size(1696, 700)
        Me.tlpOrders.ResumeLayout(False)
        Me.tlpOrders.PerformLayout()
        Me.cmsOrders.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tlpOrders As TableLayoutPanel
    Friend WithEvents lvOrders As ListView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents clstboxFilter As CheckedListBox
    Friend WithEvents cboxOrderStatus As ComboBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents txtboxSearch As TextBox
    Friend WithEvents cboxSearch As ComboBox
    Friend WithEvents dtpOrdersStart As DateTimePicker
    Friend WithEvents dtpOrdersEnd As DateTimePicker
    Friend WithEvents cmsOrders As ContextMenuStrip
    Friend WithEvents tsmiCancelOrder As ToolStripMenuItem
    Friend WithEvents tsmiCancelAll As ToolStripMenuItem
    Friend WithEvents tsOrders As ToolStrip
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class
