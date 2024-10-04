Imports System.Net
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports Bottrader.RestAPI.clsFMPStruct

Namespace RestAPI
    Public Class clsFMP

        Private Const API_KEY As String = "SECRET"
        Private Const STOCK_TYPE As String = "stock"
        Private Const ALL_STOCKS_URL As String = "https://financialmodelingprep.com/api/v3/symbol/"
        Private Const ALL_FIN_STAT_STOCKS_URL As String = "https://financialmodelingprep.com/api/v3/financial-statement-symbol-lists"
        Private Const ALL_TRADE_STOCKS_URL As String = "https://financialmodelingprep.com/api/v3/available-traded/list"
        Private Const COMPANY_PROFILE_URL As String = "https://financialmodelingprep.com/api/v3/profile/"
        Private Const SPLIT_URL As String = "https://financialmodelingprep.com/api/v3/historical-price-full/stock_split/"
        Private Const DIVIDEND_URL As String = "https://financialmodelingprep.com/api/v3/historical-price-full/stock_dividend/"
        Private Const TECH_IND_URL As String = "https://financialmodelingprep.com/api/v3/technical_indicator/1day/"
        Private Const INCOME_STMT_URL As String = "https://financialmodelingprep.com/api/v3/income-statement/"
        Private Const BALANCE_SHEET_URL As String = "https://financialmodelingprep.com/api/v3/balance-sheet-statement/"
        Private Const STOCK_GRADE As String = "https://financialmodelingprep.com/api/v3/grade/"
        Private Const ANALYST_RECOMMEND_URL As String = "https://financialmodelingprep.com/api/v3/analyst-stock-recommendations/"
        Private Const DISCOUNTED_CASH_FLOW_URL As String = "https://financialmodelingprep.com/api/v3/discounted-cash-flow/"

        Private al_sExchnge As List(Of String) = New List(Of String)(New String() {"NASDAQ", "NYSE", "TSX"})

        Public Enum Enum_TechIndType
            eSMA50 = 1
            eSMA200 = 2
            eEMA100 = 3
            eEMA200 = 4
            eRSI = 5
        End Enum

        Public Function GetAllStocks() As List(Of STRUCT_Ticker)
            Dim oWebClient As New WebClient
            Dim sJson, sURL, sExchange As String
            Dim al_strTicker As List(Of STRUCT_Ticker)
            Dim al_strStocks As New List(Of STRUCT_Ticker)
            Dim ht_sFinStatSymbol As Dictionary(Of String, String)
            Dim ht_sTradabeStock As Dictionary(Of String, String)
            Dim ht_sSymbol As New Dictionary(Of String, String)

            ht_sFinStatSymbol = GetAllFinStatSymbols()
            For Each sExchange In al_sExchnge
                ht_sTradabeStock = GetAllTradableStocks(sExchange)
                sURL = ALL_STOCKS_URL & sExchange & "?apikey=" & API_KEY
                sJson = oWebClient.DownloadString(sURL)
                al_strTicker = FromJSON(Of List(Of STRUCT_Ticker))(sJson)
                For Each strTicker In al_strTicker
                    If (IsValidStock(strTicker, ht_sFinStatSymbol, ht_sTradabeStock)) Then
                        al_strStocks.Add(strTicker)
                        ht_sSymbol.Add(strTicker.sSymbol, strTicker.sSymbol)
                    End If
                Next
            Next

            Return al_strStocks
        End Function

        Private Function IsValidStock(strTicker As STRUCT_Ticker, ht_sFinStatSymbol As Dictionary(Of String, String),
                                      ht_sTradabeStock As Dictionary(Of String, String)) As Boolean
            If (ht_sFinStatSymbol.ContainsKey(strTicker.sSymbol) AndAlso ht_sTradabeStock.ContainsKey(strTicker.sSymbol)) Then
                If ((Not IsNothing(strTicker.sCompanyName)) AndAlso (strTicker.sCompanyName.Length > 0)) Then
                    Return True
                End If
            End If

            Return False
        End Function

        Public Function GetAllTradableStocks(sExchange As String) As Dictionary(Of String, String)
            Dim oWebClient As New WebClient
            Dim sJson, sURL As String
            Dim al_strTradeStock As List(Of STRUCT_TradeStock)
            Dim strTradeStock As STRUCT_TradeStock
            Dim ht_sSymbol As New Dictionary(Of String, String)

            sURL = ALL_TRADE_STOCKS_URL & "?apikey=" & API_KEY
            sJson = oWebClient.DownloadString(sURL)
            al_strTradeStock = FromJSON(Of List(Of STRUCT_TradeStock))(sJson)

            For Each strTradeStock In al_strTradeStock
                If ((strTradeStock.sExchangeAbbr = sExchange) AndAlso (strTradeStock.sType = STOCK_TYPE)) Then
                    If (Not ht_sSymbol.ContainsKey(strTradeStock.sSymbol)) Then
                        ht_sSymbol.Add(strTradeStock.sSymbol, strTradeStock.sSymbol)
                    End If
                End If
            Next

            Return ht_sSymbol
        End Function

        Public Function GetAllFinStatSymbols() As Dictionary(Of String, String)
            Dim oWebClient As New WebClient
            Dim sJson, sURL As String
            Dim al_sSymbol As List(Of String)
            Dim ht_sSymbol As New Dictionary(Of String, String)

            sURL = ALL_FIN_STAT_STOCKS_URL & "?apikey=" & API_KEY
            sJson = oWebClient.DownloadString(sURL)
            al_sSymbol = FromJSON(Of List(Of String))(sJson)

            For Each sSymbol In al_sSymbol
                If (Not ht_sSymbol.ContainsKey(sSymbol)) Then
                    ht_sSymbol.Add(sSymbol, sSymbol)
                End If
            Next

            Return ht_sSymbol
        End Function

        Public Function GetStockDetail(sSymbol As String) As STRUCT_StockDetail
            Dim oWebClient As New WebClient
            Dim sJson, sURL As String
            Dim strCompanyInfo As STRUCT_StockDetail
            Dim oRoot As JArray
            Dim oStockNode As JObject

            sURL = COMPANY_PROFILE_URL & sSymbol & "?apikey=" & API_KEY
            sJson = oWebClient.DownloadString(sURL)
            oRoot = JArray.Parse(sJson)
            oStockNode = oRoot(0)
            strCompanyInfo = FromJSON(Of STRUCT_StockDetail)(oStockNode.ToString)

            Return strCompanyInfo
        End Function

        Public Function GetIncomeStmt(sSymbol As String) As List(Of STRUCT_IncomeStmt)
            Dim oWebClient As New WebClient
            Dim sJson, sURL As String
            Dim al_strFinStmt As List(Of STRUCT_IncomeStmt)

            sURL = INCOME_STMT_URL & sSymbol & "?period=annual" & "&apikey=" & API_KEY
            sJson = oWebClient.DownloadString(sURL)
            al_strFinStmt = FromJSON(Of List(Of STRUCT_IncomeStmt))(sJson)

            Return al_strFinStmt
        End Function

        Public Function GetBalanceSheet(sSymbol As String) As List(Of STRUCT_BalanceSheet)
            Dim oWebClient As New WebClient
            Dim sJson, sURL As String
            Dim al_strBalanceSheet As List(Of STRUCT_BalanceSheet)

            sURL = BALANCE_SHEET_URL & sSymbol & "?period=annual" & "&apikey=" & API_KEY
            sJson = oWebClient.DownloadString(sURL)
            al_strBalanceSheet = FromJSON(Of List(Of STRUCT_BalanceSheet))(sJson)

            Return al_strBalanceSheet
        End Function

        Public Function GetDividends(sSymbol As String) As List(Of STRUCT_Dividend)
            Dim oWebClient As New WebClient
            Dim sJson, sURL As String
            Dim al_strDividend As List(Of STRUCT_Dividend)
            Dim strDividend As STRUCT_Dividend
            Dim oRoot As JObject
            Dim oHistNode As JArray
            Dim oJsonSerializer As New JsonSerializer()

            sURL = DIVIDEND_URL & sSymbol & "?apikey=" & API_KEY
            sJson = oWebClient.DownloadString(sURL)
            oRoot = JObject.Parse(sJson)
            oHistNode = oRoot.GetValue("historical")
            oJsonSerializer.NullValueHandling = NullValueHandling.Ignore
            al_strDividend = FromJSON(Of List(Of STRUCT_Dividend))(oHistNode.ToString)

            For iIndex = 0 To al_strDividend.Count - 1
                strDividend = al_strDividend(iIndex)
                al_strDividend(iIndex) = strDividend
            Next

            Return al_strDividend
        End Function

        Public Function GetSplits(sSymbol As String) As List(Of STRUCT_Split)
            Dim oWebClient As New WebClient
            Dim sJson, sURL As String
            Dim al_strSplit As List(Of STRUCT_Split)
            Dim strSplit As STRUCT_Split
            Dim oRoot As JObject
            Dim oHistNode As JArray

            sURL = SPLIT_URL & sSymbol & "?apikey=" & API_KEY
            sJson = oWebClient.DownloadString(sURL)
            oRoot = JObject.Parse(sJson)
            oHistNode = oRoot.GetValue("historical")
            al_strSplit = FromJSON(Of List(Of STRUCT_Split))(oHistNode.ToString)

            For iIndex = 0 To al_strSplit.Count - 1
                strSplit = al_strSplit(iIndex)
                al_strSplit(iIndex) = strSplit
            Next

            Return al_strSplit
        End Function

        Public Function GetTechIndType(eTechndType As Enum_TechIndType) As String
            Dim sTechIndType As String = ""

            If ((eTechndType = Enum_TechIndType.eSMA50) Or (eTechndType = Enum_TechIndType.eSMA200)) Then
                sTechIndType = "sma"
            ElseIf ((eTechndType = Enum_TechIndType.eEMA100) Or (eTechndType = Enum_TechIndType.eEMA200)) Then
                sTechIndType = "ema"
            ElseIf (eTechndType = Enum_TechIndType.eRSI) Then
                sTechIndType = "rsi"
            End If

            Return sTechIndType
        End Function

        Public Function GetTechIndPeriod(eTechndType As Enum_TechIndType) As Integer
            Dim iTechIndPeriod As Integer = 0

            If ((eTechndType = Enum_TechIndType.eSMA50)) Then
                iTechIndPeriod = 50
            ElseIf (eTechndType = Enum_TechIndType.eSMA200) Then
                iTechIndPeriod = 200
            ElseIf ((eTechndType = Enum_TechIndType.eEMA100)) Then
                iTechIndPeriod = 100
            ElseIf (eTechndType = Enum_TechIndType.eEMA200) Then
                iTechIndPeriod = 200
            ElseIf (eTechndType = Enum_TechIndType.eRSI) Then
                iTechIndPeriod = 50
            End If

            Return iTechIndPeriod
        End Function

        Public Function GetTechInd(sSymbol As String, eTechndType As Enum_TechIndType) As List(Of STRUCT_TechInd)
            Dim oWebClient As New WebClient
            Dim sJson, sURL, sTechIndType As String
            Dim iTechIndPeriod As Integer
            Dim al_strTechInd As List(Of STRUCT_TechInd)

            sTechIndType = GetTechIndType(eTechndType)
            iTechIndPeriod = GetTechIndPeriod(eTechndType)
            sURL = TECH_IND_URL & sSymbol & "?type=" & sTechIndType & "&period=" & iTechIndPeriod & "&apikey=" & API_KEY
            sJson = oWebClient.DownloadString(sURL)
            al_strTechInd = FromJSON(Of List(Of STRUCT_TechInd))(sJson)

            Return al_strTechInd
        End Function

        Public Function GetStockBuySell(sSymbol As String) As List(Of STRUCT_StockBuySell)
            Dim oWebClient As New WebClient
            Dim sJson, sURL As String
            Dim al_strStockBuySell As List(Of STRUCT_StockBuySell)

            sURL = ANALYST_RECOMMEND_URL & sSymbol & "?limit=1" & "&apikey=" & API_KEY
            sJson = oWebClient.DownloadString(sURL)
            al_strStockBuySell = FromJSON(Of List(Of STRUCT_StockBuySell))(sJson)

            Return al_strStockBuySell
        End Function

        Public Function GetDCFData(sSymbol As String) As STRUCT_DCF
            Dim oWebClient As New WebClient()
            Dim sJson, sURL As String
            Dim dcfList As List(Of STRUCT_DCF)

            sURL = DISCOUNTED_CASH_FLOW_URL & sSymbol & "?apikey=" & API_KEY
            sJson = oWebClient.DownloadString(sURL)

            ' Check if the JSON is empty or an empty array
            If String.IsNullOrEmpty(sJson) OrElse sJson.Trim() = "[]" Then
                Return New STRUCT_DCF() ' Return a default STRUCT_DCF if JSON is empty
            End If

            ' Deserialize JSON array into a List(Of STRUCT_DCF)
            dcfList = JsonConvert.DeserializeObject(Of List(Of STRUCT_DCF))(sJson)

            ' Check if the deserialized list is empty
            If dcfList Is Nothing OrElse dcfList.Count = 0 Then
                Return New STRUCT_DCF() ' Return a default STRUCT_DCF if the list is empty
            End If

            ' Return the first item in the list
            Return dcfList(0)
        End Function

    End Class
End Namespace
