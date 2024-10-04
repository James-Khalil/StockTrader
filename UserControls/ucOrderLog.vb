Imports Alpaca.Markets
Public Class ucOrderLog
    Private m_al_oOrder As List(Of IOrder)
    Private m_oAlpaca As New RestAPI.clsAlpaca

    Public Sub InitControl()
        Dim oColHeader As ColumnHeader
        Dim al_oOrdersHeaders As New List(Of (String, String))

        dtpOrdersStart.Value = DateAdd(DateInterval.Day, -7, DateTime.Now)
        dtpOrdersEnd.Value = DateTime.Now
        m_al_oOrder = m_oAlpaca.GetOrderList

        '-- Listview --
        al_oOrdersHeaders.Add(("Symbol", "Symbol"))
        al_oOrdersHeaders.Add(("Submission Time", "SubmittedAtUtc"))
        al_oOrdersHeaders.Add(("Status", "OrderStatus"))
        al_oOrdersHeaders.Add(("Price", "AverageFillPrice"))
        al_oOrdersHeaders.Add(("Order Type", "OrderSide"))
        al_oOrdersHeaders.Add(("Time in Force", "TimeInForce"))
        lvOrders.Clear()
        For Each oAssetHeader In al_oOrdersHeaders
            oColHeader = New ColumnHeader() With {
            .Text = oAssetHeader.Item1,
            .Tag = oAssetHeader.Item2
            }
            lvOrders.Columns.Add(oColHeader)
        Next

        FillOrderList()
        lvOrders.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
        lvOrders.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent)
        lvOrders.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent)
        lvOrders.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.ColumnContent)

        '-- Combo Box Filter --
        clstboxFilter.Items.Add("Symbol")
    End Sub

    Private Sub lvFilledOrders_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lvOrders.ColumnClick
        Static s_iSortedFlag As Integer = -1
        Dim sColumnHeader As String = lvOrders.Columns(e.Column).Text

        If s_iSortedFlag = e.Column Then
            m_al_oOrder.Reverse()
            If sColumnHeader.Contains("▼") Then
                lvOrders.Columns(e.Column).Text = sColumnHeader.Replace("▼", "▲")
            Else
                lvOrders.Columns(e.Column).Text = sColumnHeader.Replace("▲", "▼")
            End If
        Else
            If Not s_iSortedFlag = -1 Then
                lvOrders.Columns(s_iSortedFlag).Text = lvOrders.Columns(s_iSortedFlag).Text.Remove(lvOrders.Columns(s_iSortedFlag).Text.Length - 1, 1)
            End If
            SortByColumn(lvOrders.Columns(e.Column).Tag)
            lvOrders.Columns(e.Column).Text &= "▼"
        End If

        FillOrderList()
        s_iSortedFlag = e.Column
    End Sub

    Private Sub SortByColumn(sTag As String)
        m_al_oOrder.Sort(Function(oCol1, oCol2)
                             Dim oVal1 As Object = oCol1.GetType().GetProperty(sTag).GetValue(oCol1)
                             Dim oVal2 As Object = oCol2.GetType().GetProperty(sTag).GetValue(oCol2)
                             Return Comparer.Default.Compare(oVal1, oVal2)
                         End Function)
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        m_al_oOrder = m_oAlpaca.GetOrderList(, cboxOrderStatus.SelectedIndex(), dtpOrdersStart.Value, dtpOrdersEnd.Value)

        Select Case cboxSearch.SelectedIndex
            Case 0
                m_al_oOrder.RemoveAll(Function(str) Not str.Symbol.Contains(txtboxSearch.Text.ToUpper))
            Case 1
                m_al_oOrder.RemoveAll(Function(str) Not str.ClientOrderId.Contains(txtboxSearch.Text.ToUpper))
            Case Else
        End Select

        FillOrderList()
    End Sub

    Private Sub clstboxFilter_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles clstboxFilter.ItemCheck
        Dim checkedListBox As CheckedListBox = DirectCast(sender, CheckedListBox)
        Dim checkedItem As String = checkedListBox.Items(e.Index).ToString()

        If e.NewValue = CheckState.Checked Then
            lvOrders.Columns(e.Index).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
        Else
            lvOrders.Columns(e.Index).Width = 0
        End If
    End Sub

    Private Sub tsmiCancelOrder_Click(sender As Object, e As EventArgs) Handles tsmiCancelOrder.Click
        tsOrders.Show()
    End Sub

    Private Sub lvOrders_MouseDown(sender As Object, e As MouseEventArgs) Handles lvOrders.MouseDown
        Dim oListItem As ListViewItem

        If e.Button = MouseButtons.Right Then
            oListItem = lvOrders.GetItemAt(e.X, e.Y)
            If (Not IsNothing(oListItem)) Then
                If oListItem.SubItems(2).Text = "Filled" Or
                    oListItem.SubItems(2).Text = "Canceled" Then
                    cmsOrders.Items(0).Enabled = False
                Else
                    cmsOrders.Items(0).Enabled = True
                End If
            End If
        End If
    End Sub

    Private Sub tsOrders_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles tsOrders.ItemClicked
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            ' Perform the delete action
            ' ...
        End If
    End Sub

    Private Sub FillOrderList()
        Dim oLstViewItem As ListViewItem

        lvOrders.Items.Clear()
        For Each oOrder In m_al_oOrder
            oLstViewItem = New ListViewItem(oOrder.Symbol)
            oLstViewItem.SubItems.Add(oOrder.SubmittedAtUtc)
            oLstViewItem.SubItems.Add([Enum].GetName(GetType(OrderStatus), oOrder.OrderStatus))
            If oOrder.AverageFillPrice IsNot Nothing Then
                oLstViewItem.SubItems.Add(oOrder.AverageFillPrice)
            Else
                oLstViewItem.SubItems.Add("")
            End If
            oLstViewItem.SubItems.Add([Enum].GetName(GetType(OrderSide), oOrder.OrderSide))
            oLstViewItem.SubItems.Add([Enum].GetName(GetType(TimeInForce), oOrder.TimeInForce))
            lvOrders.Items.Add(oLstViewItem)
        Next
    End Sub
End Class
