<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmOrder
    Inherits System.Windows.Forms.Form

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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblOrderType = New System.Windows.Forms.Label()
        Me.lblQuantity = New System.Windows.Forms.Label()
        Me.lblPrice = New System.Windows.Forms.Label()
        Me.txtTrade = New System.Windows.Forms.TextBox()
        Me.cbTimeInForce = New System.Windows.Forms.ComboBox()
        Me.cbOrderType = New System.Windows.Forms.ComboBox()
        Me.tbPrice = New System.Windows.Forms.TextBox()
        Me.tbQuantity = New System.Windows.Forms.TextBox()
        Me.txtAsset = New System.Windows.Forms.TextBox()
        Me.btnConfirm = New System.Windows.Forms.Button()
        Me.lblTimeInForce = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(574, 254)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblTimeInForce)
        Me.Panel1.Controls.Add(Me.lblOrderType)
        Me.Panel1.Controls.Add(Me.lblQuantity)
        Me.Panel1.Controls.Add(Me.lblPrice)
        Me.Panel1.Controls.Add(Me.txtTrade)
        Me.Panel1.Controls.Add(Me.cbTimeInForce)
        Me.Panel1.Controls.Add(Me.cbOrderType)
        Me.Panel1.Controls.Add(Me.tbPrice)
        Me.Panel1.Controls.Add(Me.tbQuantity)
        Me.Panel1.Controls.Add(Me.txtAsset)
        Me.Panel1.Controls.Add(Me.btnConfirm)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(568, 248)
        Me.Panel1.TabIndex = 0
        '
        'lblOrderType
        '
        Me.lblOrderType.AutoSize = True
        Me.lblOrderType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrderType.Location = New System.Drawing.Point(214, 41)
        Me.lblOrderType.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblOrderType.Name = "lblOrderType"
        Me.lblOrderType.Size = New System.Drawing.Size(81, 17)
        Me.lblOrderType.TabIndex = 15
        Me.lblOrderType.Text = "Order Type"
        '
        'lblQuantity
        '
        Me.lblQuantity.AutoSize = True
        Me.lblQuantity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQuantity.Location = New System.Drawing.Point(214, 163)
        Me.lblQuantity.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblQuantity.Name = "lblQuantity"
        Me.lblQuantity.Size = New System.Drawing.Size(61, 17)
        Me.lblQuantity.TabIndex = 14
        Me.lblQuantity.Text = "Quantity"
        '
        'lblPrice
        '
        Me.lblPrice.AutoSize = True
        Me.lblPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrice.Location = New System.Drawing.Point(21, 163)
        Me.lblPrice.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPrice.Name = "lblPrice"
        Me.lblPrice.Size = New System.Drawing.Size(40, 17)
        Me.lblPrice.TabIndex = 13
        Me.lblPrice.Text = "Price"
        '
        'txtTrade
        '
        Me.txtTrade.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTrade.Location = New System.Drawing.Point(24, 60)
        Me.txtTrade.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTrade.Name = "txtTrade"
        Me.txtTrade.ReadOnly = True
        Me.txtTrade.Size = New System.Drawing.Size(132, 23)
        Me.txtTrade.TabIndex = 12
        '
        'cbTimeInForce
        '
        Me.cbTimeInForce.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTimeInForce.FormattingEnabled = True
        Me.cbTimeInForce.Location = New System.Drawing.Point(400, 64)
        Me.cbTimeInForce.Name = "cbTimeInForce"
        Me.cbTimeInForce.Size = New System.Drawing.Size(136, 24)
        Me.cbTimeInForce.TabIndex = 11
        '
        'cbOrderType
        '
        Me.cbOrderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbOrderType.FormattingEnabled = True
        Me.cbOrderType.Location = New System.Drawing.Point(217, 64)
        Me.cbOrderType.Name = "cbOrderType"
        Me.cbOrderType.Size = New System.Drawing.Size(136, 24)
        Me.cbOrderType.TabIndex = 10
        '
        'tbPrice
        '
        Me.tbPrice.Location = New System.Drawing.Point(24, 185)
        Me.tbPrice.Name = "tbPrice"
        Me.tbPrice.Size = New System.Drawing.Size(136, 22)
        Me.tbPrice.TabIndex = 9
        '
        'tbQuantity
        '
        Me.tbQuantity.Location = New System.Drawing.Point(217, 185)
        Me.tbQuantity.Name = "tbQuantity"
        Me.tbQuantity.Size = New System.Drawing.Size(136, 22)
        Me.tbQuantity.TabIndex = 8
        '
        'txtAsset
        '
        Me.txtAsset.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtAsset.Location = New System.Drawing.Point(24, 19)
        Me.txtAsset.Name = "txtAsset"
        Me.txtAsset.ReadOnly = True
        Me.txtAsset.Size = New System.Drawing.Size(100, 22)
        Me.txtAsset.TabIndex = 5
        '
        'btnConfirm
        '
        Me.btnConfirm.Enabled = False
        Me.btnConfirm.Location = New System.Drawing.Point(400, 174)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(136, 44)
        Me.btnConfirm.TabIndex = 0
        Me.btnConfirm.Text = "Confirm"
        Me.btnConfirm.UseVisualStyleBackColor = True
        '
        'lblTimeInForce
        '
        Me.lblTimeInForce.AutoSize = True
        Me.lblTimeInForce.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTimeInForce.Location = New System.Drawing.Point(397, 44)
        Me.lblTimeInForce.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTimeInForce.Name = "lblTimeInForce"
        Me.lblTimeInForce.Size = New System.Drawing.Size(94, 17)
        Me.lblTimeInForce.TabIndex = 16
        Me.lblTimeInForce.Text = "Time in Force"
        '
        'ucOrderDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(574, 254)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "ucOrderDialog"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnConfirm As Button
    Friend WithEvents txtAsset As TextBox
    Friend WithEvents tbQuantity As TextBox
    Friend WithEvents tbPrice As TextBox
    Friend WithEvents cbTimeInForce As ComboBox
    Friend WithEvents cbOrderType As ComboBox
    Friend WithEvents txtTrade As TextBox
    Friend WithEvents lblQuantity As Label
    Friend WithEvents lblPrice As Label
    Friend WithEvents lblOrderType As Label
    Friend WithEvents lblTimeInForce As Label
End Class
