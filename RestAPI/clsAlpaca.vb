Imports Alpaca.Markets

Namespace RestAPI
    Public Class clsAlpaca
        Private Const API_KEY As String = "SECRET"
        Private Const API_SECRET As String = "SECRET"
        'Private Const API_KEY As String = "SECRET"
        'Private Const API_SECRET As String = "SECRET"
        Private Function GetTradingClient() As IAlpacaTradingClient
            Dim oAlpaca As IAlpacaTradingClient = Nothing
            Dim oSecretKey As SecretKey

            Try
                oSecretKey = New SecretKey(API_KEY, API_SECRET)
                oAlpaca = Environments.Paper.GetAlpacaTradingClient(oSecretKey)
            Catch ex As Exception
                MsgBox("GetTradingClient() Failed: " & vbCrLf & ex.ToString)
            End Try
            Return oAlpaca
        End Function

        Private Function GetDataClient() As IAlpacaDataClient
            Dim oAlpaca As IAlpacaDataClient = Nothing
            Dim oSecretKey As SecretKey

            Try
                oSecretKey = New SecretKey(API_KEY, API_SECRET)
                oAlpaca = Environments.Paper.GetAlpacaDataClient(oSecretKey)
            Catch ex As Exception
                MsgBox("GetDataClient() Failed: " & vbCrLf & ex.ToString)
            End Try
            Return oAlpaca
        End Function

        Public Function GetAccount() As IAccount
            Dim oAlpaca As IAlpacaTradingClient = GetTradingClient()
            Dim oAccount As IAccount
            Dim oTask As Task(Of IAccount)

            oTask = oAlpaca.GetAccountAsync()
            oAccount = oTask.Result
            Return oAccount
        End Function

        Public Function GetAsset(sSymbol As String) As IAsset
            Dim oAlpaca As IAlpacaTradingClient = GetTradingClient()
            Dim oAsset As IAsset
            Dim t_oAsset As Task(Of IAsset)

            Try
                t_oAsset = oAlpaca.GetAssetAsync(sSymbol)
                oAsset = t_oAsset.Result
                Return oAsset
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        Public Function GetAllAssets() As List(Of IAsset)
            Dim oAlpaca As IAlpacaTradingClient = GetTradingClient()
            Dim al_oAssets As IReadOnlyList(Of IAsset)
            Dim oTaskAssets As Task(Of IReadOnlyList(Of IAsset))
            Dim oRequest As AssetsRequest
            Dim ht_oAsset As New Dictionary(Of String, IAsset)

            oRequest = New AssetsRequest()
            oTaskAssets = oAlpaca.ListAssetsAsync(oRequest)
            al_oAssets = oTaskAssets.Result
            For Each oAsset In al_oAssets
                If Not (ht_oAsset.ContainsKey(oAsset.Symbol)) Then
                    ht_oAsset.Add(oAsset.Symbol, oAsset)
                End If
            Next

            Return ht_oAsset.Values.ToList()
        End Function

        Public Function GetOrder(sClientOrderID As String) As IOrder
            Dim oAlpaca As IAlpacaTradingClient = GetTradingClient()
            Dim oOrder As IOrder
            Dim t_oOrder As Task(Of IOrder)

            t_oOrder = oAlpaca.GetOrderAsync(sClientOrderID)
            oOrder = t_oOrder.Result
            'Store order in SQL Database

            Return oOrder
        End Function

        Public Function GetPosition(sSymbol As String) As IPosition
            Dim oAlpaca As IAlpacaTradingClient
            Dim oAccount As IPosition
            Dim t_oAccount As Task(Of IPosition)

            oAlpaca = GetTradingClient()
            t_oAccount = oAlpaca.GetPositionAsync(sSymbol)
            oAccount = t_oAccount.Result
            Return oAccount
        End Function

        Public Function GetPortfolioHistory(iTimeSpan As Integer) As IPortfolioHistory
            Dim oAlpaca As IAlpacaTradingClient = GetTradingClient()
            Dim oPortfolioHistory As IPortfolioHistory
            Dim t_oPortfolioHistory As Task(Of IPortfolioHistory)
            Dim oHistoryPeriod As HistoryPeriod
            Dim oRequest As PortfolioHistoryRequest

            oHistoryPeriod = If(iTimeSpan = 4, New HistoryPeriod(5, 3), New HistoryPeriod(1, iTimeSpan))
            oRequest = New PortfolioHistoryRequest With {
                        .Period = oHistoryPeriod}
            t_oPortfolioHistory = oAlpaca.GetPortfolioHistoryAsync(oRequest)
            oPortfolioHistory = t_oPortfolioHistory.Result
            Return oPortfolioHistory
        End Function

        Public Function GetOrderList(Optional iLimitOrder As Integer = 100,
                                           Optional iOrderStatusFilter As Integer = OrderStatusFilter.All,
                                           Optional startDate As DateTime = #2023-01-01#,
                                           Optional endDate As DateTime = #2024-05-09#) As List(Of IOrder)
            Dim oAlpaca As IAlpacaTradingClient = GetTradingClient()
            Dim oOrders As IReadOnlyList(Of IOrder)
            Dim oTaskOrders As Task(Of IReadOnlyList(Of IOrder))
            Dim oRequest As ListOrdersRequest

            oRequest = New ListOrdersRequest With
                {
                    .LimitOrderNumber = iLimitOrder,
                    .OrderStatusFilter = iOrderStatusFilter
                    }
            oRequest.WithInterval(New Interval(Of Date)(startDate, endDate))

            oTaskOrders = oAlpaca.ListOrdersAsync(oRequest)
            oOrders = oTaskOrders.Result
            Return oOrders.ToList
        End Function

        Public Function CancelOrder(gOrderID As Guid) As Boolean
            Dim oAlpaca As IAlpacaTradingClient = GetTradingClient()
            Dim bSuccess As Boolean
            Dim t_bSuccess As Task(Of Boolean)

            t_bSuccess = oAlpaca.CancelOrderAsync(gOrderID)
            bSuccess = t_bSuccess.Result
            Return bSuccess
        End Function

        Public Sub CancelAllOrders()
            Dim oAlpaca As IAlpacaTradingClient = GetTradingClient()

            oAlpaca.CancelAllOrdersAsync()
        End Sub

        Public Function GetHistoricalTrades(sSymbol As String, dtStart As Date, dtEnd As Date) As IMultiPage(Of ITrade)
            Dim oAlpapa As IAlpacaDataClient = GetDataClient()
            Dim oTradeHistory As IMultiPage(Of ITrade)
            Dim t_oTradeHistory As Task(Of IMultiPage(Of ITrade))
            Dim oTradeRequest As New HistoricalTradesRequest(sSymbol,
                New Interval(Of Date)(dtStart, dtEnd))


            t_oTradeHistory = oAlpapa.GetHistoricalTradesAsync(oTradeRequest)
            oTradeHistory = t_oTradeHistory.Result
            Return oTradeHistory
        End Function

        Public Async Function GetHistoricalQuotes(sSymbol As String, dtStart As Date, dtEnd As Date) As Task(Of IMultiPage(Of IQuote))
            Dim oAlpaca As IAlpacaDataClient = GetDataClient()
            Dim oQuoteHistory As IMultiPage(Of IQuote)
            Dim oQuoteRequest As New HistoricalQuotesRequest(sSymbol,
                New Interval(Of Date)(dtStart, dtEnd))
            oQuoteHistory = Await oAlpaca.GetHistoricalQuotesAsync(oQuoteRequest)
            Return oQuoteHistory

        End Function
        Public Function GetHistoricalBars(sSymbol As String, iTimeSpan As BarTimeFrameUnit, dtStartDate As DateTime, dtEndDate As DateTime, Optional iPeriod As Integer = 1) As IMultiPage(Of IBar)
            Dim oAlpaca As IAlpacaDataClient = GetDataClient()
            Dim oBarHistory As IMultiPage(Of IBar)
            Dim oTaskBar As Task(Of IMultiPage(Of IBar))
            Dim oRequest As HistoricalBarsRequest

            oRequest = New HistoricalBarsRequest(sSymbol,
                New BarTimeFrame(iPeriod, iTimeSpan),
                        New Interval(Of Date)(dtStartDate,
                                              dtEndDate))
            oTaskBar = oAlpaca.GetHistoricalBarsAsync(oRequest)
            oBarHistory = oTaskBar.Result
            Return oBarHistory
        End Function

        Public Function GetHistoricalAuctions(sSymbol As String, dtStart As Date, dtEnd As Date) As Task(Of IMultiPage(Of IAuction))
            Dim oAlpaca As IAlpacaDataClient = GetDataClient()
            Dim oAucHistory As IMultiPage(Of IAuction)
            Dim oTaskAuc As Task(Of IMultiPage(Of IAuction))
            Dim oAucRequest As New HistoricalAuctionsRequest(sSymbol,
                New Interval(Of Date)(dtStart, dtEnd))
            oTaskAuc = oAlpaca.GetHistoricalAuctionsAsync(oAucRequest)
            oAucHistory = oTaskAuc.Result
            Return oAucHistory
        End Function

        Public Function GetPositions() As IReadOnlyList(Of IPosition)
            Dim oAlpaca As IAlpacaTradingClient = GetTradingClient()
            Dim oPort As IReadOnlyList(Of IPosition)
            Dim t_oPort As Task(Of IReadOnlyList(Of IPosition))

            t_oPort = oAlpaca.ListPositionsAsync()
            oPort = t_oPort.Result
            Return oPort.ToList()
        End Function

        Public Async Function GetWatchLists() As Task(Of List(Of IWatchList))
            Dim oAlpaca As IAlpacaTradingClient = GetTradingClient()
            Dim al_oWatchList As IReadOnlyList(Of IWatchList)

            al_oWatchList = Await oAlpaca.ListWatchListsAsync
            Return al_oWatchList.ToList()
        End Function

        Public Function GetWatchList(sWatchList As String) As IWatchList
            Dim oAlpaca As IAlpacaTradingClient = GetTradingClient()
            Dim oWatchList As IWatchList
            Dim oTaskWatch As Task(Of IWatchList)

            oTaskWatch = oAlpaca.GetWatchListByNameAsync(sWatchList)
            oWatchList = oTaskWatch.Result
            Return oWatchList
        End Function

        Public Async Function AddWatchList(sWatchList As String) As Task(Of IWatchList)
            Dim oAlpaca As IAlpacaTradingClient = GetTradingClient()
            Dim oWatchList As IWatchList
            Dim oRequest As New NewWatchListRequest(sWatchList)

            oWatchList = Await oAlpaca.CreateWatchListAsync(oRequest)
            Return oWatchList
        End Function

        Public Function AddtoWatchList(sSymbol As String, sWatchList As String) As IWatchList
            Dim oAlpaca As IAlpacaTradingClient = GetTradingClient()
            Dim oRequest As New ChangeWatchListRequest(Of String)(sWatchList, sSymbol)
            Dim oWatchList As IWatchList
            Dim t_oWatchList As Task(Of IWatchList)


            t_oWatchList = oAlpaca.GetWatchListByNameAsync(sWatchList)
            oWatchList = t_oWatchList.Result
            For Each oAsset In oWatchList.Assets
                If oAsset.Symbol = sSymbol Then Return oWatchList
            Next
            t_oWatchList = oAlpaca.AddAssetIntoWatchListByNameAsync(oRequest)
            oWatchList = t_oWatchList.Result
            Return oWatchList
        End Function

        Public Function PlaceOrder(sSymbol As String, iQuantity As Integer, oSide As OrderSide,
                                         Optional oType As OrderType = OrderType.Market, Optional iDuration As TimeInForce = TimeInForce.Day) As IOrder

            'Note: consider making the order type and timeinforce not optional later (unsure if those values will always be filled but likely will be)
            Dim oAlpaca As IAlpacaTradingClient = GetTradingClient()
            Dim oOrder As IOrder
            Dim oTask As Task(Of IOrder)
            Dim oOrderRequest As NewOrderRequest

            oOrderRequest = New NewOrderRequest(sSymbol, iQuantity, oSide, oType, iDuration)

            oTask = oAlpaca.PostOrderAsync(oOrderRequest)
            oOrder = oTask.Result
            Return oOrder
        End Function

        Public Function GetLastTrade(sSymbol As String) As ITrade
            Dim oAlpaca As IAlpacaDataClient = GetDataClient()
            Dim oTrade As ITrade
            Dim t_oTrade As Task(Of ITrade)
            Dim oRequest As LatestMarketDataRequest

            oRequest = New LatestMarketDataRequest(sSymbol)
            Try
                t_oTrade = oAlpaca.GetLatestTradeAsync(oRequest)
                oTrade = t_oTrade.Result
                Return oTrade
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        Public Function GetActiveAssets() As List(Of IAsset)
            Dim al_oAsset As List(Of IAsset)
            Dim al_oTradable As New List(Of IAsset)

            al_oAsset = GetAllAssets()
            For Each oAsset In al_oAsset
                If (oAsset.IsTradable) Then
                    al_oTradable.Add(oAsset)
                End If
            Next
            Return al_oTradable
        End Function


    End Class
End Namespace
