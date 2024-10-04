Imports System.Windows.Forms.DataVisualization.Charting

Public Class ucPositions
    Private m_al_oPosition As List(Of Alpaca.Markets.IPosition)
    Public Sub InitControl()
        Dim oAccount As Alpaca.Markets.IAccount
        Dim oColHeader As ColumnHeader
        Dim al_oAssetHeaders As New List(Of (String, String))
        Dim oAlpaca As New RestAPI.clsAlpaca


        m_al_oPosition = oAlpaca.GetPositions
        oAccount = oAlpaca.GetAccount

        FillCharts(oAccount.TradableCash)

        '-- Listview (Asset) --
        al_oAssetHeaders.Add(("Asset", "Symbol"))
        al_oAssetHeaders.Add(("Price", "AssetCurrentPrice"))
        al_oAssetHeaders.Add(("Qty", "Quantity"))
        al_oAssetHeaders.Add(("Market Value", "MarketValue"))
        al_oAssetHeaders.Add(("Today G/L", "IntradayUnrealizedProfitLoss"))
        al_oAssetHeaders.Add(("Total G/L", "UnrealizedProfitLoss"))

        lvAssets.Clear()
        For Each oAssetHeader In al_oAssetHeaders
            oColHeader = New ColumnHeader() With {
            .Text = oAssetHeader.Item1,
            .Tag = oAssetHeader.Item2
            }
            lvAssets.Columns.Add(oColHeader)
        Next
        FillAssetList()
    End Sub

    Private Sub lvAssets_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lvAssets.ColumnClick
        Static s_iSortedFlag As Integer = -1
        Dim sColumnHeader As String = lvAssets.Columns(e.Column).Text

        If s_iSortedFlag = e.Column Then
            m_al_oPosition.Reverse()
            If sColumnHeader.Contains("▼") Then
                lvAssets.Columns(e.Column).Text = sColumnHeader.Replace("▼", "▲")
            Else
                lvAssets.Columns(e.Column).Text = sColumnHeader.Replace("▲", "▼")
            End If
        Else
            If Not s_iSortedFlag = -1 Then
                lvAssets.Columns(s_iSortedFlag).Text = lvAssets.Columns(s_iSortedFlag).Text.Remove(lvAssets.Columns(s_iSortedFlag).Text.Length - 1, 1)
            End If
            SortByColumn(lvAssets.Columns(e.Column).Tag)
            lvAssets.Columns(e.Column).Text &= "▼"
        End If

        FillAssetList()
        s_iSortedFlag = e.Column
    End Sub

    Private Sub SortByColumn(sTag As String)
        m_al_oPosition.Sort(Function(oObject1, oObject2)
                                Dim propertyValue1 As Object = oObject1.GetType().GetProperty(sTag).GetValue(oObject1)
                                Dim propertyValue2 As Object = oObject2.GetType().GetProperty(sTag).GetValue(oObject2)
                                Return Comparer.Default.Compare(propertyValue1, propertyValue2)
                            End Function)
    End Sub

    Private Sub FillAssetList()
        Dim oLstViewItem As ListViewItem

        lvAssets.Items.Clear()
        For Each oPosition In m_al_oPosition
            oLstViewItem = New ListViewItem(oPosition.Symbol)
            oLstViewItem.SubItems.Add(oPosition.AssetCurrentPrice)
            oLstViewItem.SubItems.Add(oPosition.Quantity)
            oLstViewItem.SubItems.Add(oPosition.MarketValue)
            oLstViewItem.SubItems.Add(oPosition.IntradayUnrealizedProfitLoss)
            oLstViewItem.SubItems.Add(oPosition.UnrealizedProfitLoss)
            lvAssets.Items.Add(oLstViewItem)
        Next
        lvAssets.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
    End Sub

    Private Sub FillCharts(dCash As Double)
        Dim dSumLong As Double
        Dim dSumShort As Double
        Dim oClass As New Series("Class")
        Dim oSide As New Series("Side")

        'Class chart
        For Each oPosition In m_al_oPosition
            dSumLong += oPosition.MarketValue
        Next
        oClass.ChartType = SeriesChartType.Pie
        oClass.Points.AddXY("Cash", dCash)
        oClass.Points.AddXY("Stocks", dSumLong)
        oClass("PieLabelStyle") = "Disabled"
        chrtClass.Series.Add(oClass)

        'Hold chart
        chrtSide.Series.Clear()
        dSumLong = 0
        For Each oPosition In m_al_oPosition
            If (oPosition.Side = Alpaca.Markets.PositionSide.Long) Then
                dSumLong += oPosition.MarketValue
            Else
                dSumShort += oPosition.MarketValue
            End If
        Next
        oSide.ChartType = SeriesChartType.Pie
        oSide.Points.AddXY("Long", dSumLong)
        oSide.Points.AddXY("Short", dSumShort)
        oSide("PieLabelStyle") = "Disabled"
        chrtSide.Series.Add(oSide)
    End Sub

End Class
