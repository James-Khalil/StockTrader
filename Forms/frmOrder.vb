Imports System.Windows.Forms.DataVisualization.Charting
Imports Alpaca.Markets

Public Class frmOrder
    Private m_oTrade As ITrade
    Private m_eSide As OrderSide
    Private m_oAlpaca As New RestAPI.clsAlpaca

    Public Sub InitControl(eSide As OrderSide, sSymbol As String)
        m_eSide = eSide
        txtAsset.Text = sSymbol
        m_oTrade = m_oAlpaca.GetLastTrade(txtAsset.Text)
        txtTrade.Text = "$" & m_oTrade.Price
        '-- Combo box --
        cbOrderType.Items.AddRange({"Market", "Stop", "Limit", "Stop Limit", "Trailing Stop"})
        cbTimeInForce.Items.AddRange({"Day", "Good Till Canceled", "At the Open",
                                     "Immediate or Cancel", "Fill or Kill", "At the Close"})
        cbOrderType.SelectedIndex = 0
        cbTimeInForce.SelectedIndex = 0
    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        Dim oOrder As IOrder
        Dim oYesNo As DialogResult

        oYesNo = MessageBox.Show(m_eSide & " " & tbQuantity.Text & " shares of " & txtAsset.Text & "?", "Confirmation", MessageBoxButtons.YesNo)

        If oYesNo = DialogResult.Yes Then
            MessageBox.Show("You clicked Yes!")
            oOrder = m_oAlpaca.PlaceOrder(txtAsset.Text, CDbl(tbQuantity.Text), m_eSide,
                                                        cbOrderType.SelectedIndex, cbTimeInForce.SelectedIndex)
        ElseIf oYesNo = DialogResult.No Then
            MessageBox.Show("Order Canceled")
        End If
    End Sub

    Private Sub tbPrice_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles tbPrice.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            tbPrice.Text &= e.KeyChar
        ElseIf e.KeyChar = ControlChars.Back Then
            If tbPrice.Text.Length > 0 Then
                tbPrice.Text = tbPrice.Text.Substring(0, tbPrice.Text.Length - 1)
            End If
        End If
        If tbPrice.Text = "" Then
            tbQuantity.Text = ""
            btnConfirm.Enabled = False
        Else
            tbQuantity.Text = CDbl(tbPrice.Text) / m_oTrade.Price
            btnConfirm.Enabled = True
        End If
        e.Handled = True
    End Sub

    Private Sub tbQuantity_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles tbQuantity.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            tbQuantity.Text &= e.KeyChar
        ElseIf e.KeyChar = ControlChars.Back Then
            If tbQuantity.Text.Length > 0 Then
                tbQuantity.Text = tbQuantity.Text.Substring(0, tbQuantity.Text.Length - 1)
            End If
        End If
        If tbQuantity.Text = "" Then
            tbPrice.Text = ""
            btnConfirm.Enabled = False
        Else
            tbPrice.Text = CDbl(tbQuantity.Text) * m_oTrade.Price
            btnConfirm.Enabled = True
        End If
        e.Handled = True
    End Sub
End Class