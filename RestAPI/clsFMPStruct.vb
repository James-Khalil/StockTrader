Imports Newtonsoft.Json

Namespace RestAPI
    Public Class clsFMPStruct

        Public Structure STRUCT_Ticker
            <JsonProperty("symbol")> Dim sSymbol As String
            <JsonProperty("name")> Dim sCompanyName As String
            <JsonProperty("price")> Dim dPrice As Double
            <JsonProperty("yearHigh")> Dim dYearHigh As Double
            <JsonProperty("yearLow")> Dim dYearLow As Double
            <JsonProperty("marketCap")> Dim dMarketCap As Double
            <JsonProperty("priceAvg50")> Dim dSMA50 As Double
            <JsonProperty("priceAvg200")> Dim dSMA200 As Double
            <JsonProperty("exchange")> Dim sExchange As String
            <JsonProperty("volume")> Dim iVolume As Long
            <JsonProperty("avgVolume")> Dim iAvgVolume As Long
            <JsonProperty("eps")> Dim dEPS As Double
            <JsonProperty("sharesOutstanding")> Dim iNumShares As Long
        End Structure

        Public Structure STRUCT_TradeStock
            <JsonProperty("symbol")> Dim sSymbol As String
            <JsonProperty("name")> Dim sName As String
            <JsonProperty("price")> Dim dPrice As Double
            <JsonProperty("exchange")> Dim sExchange As String
            <JsonProperty("exchangeShortName")> Dim sExchangeAbbr As String
            <JsonProperty("type")> Dim sType As String
        End Structure

        Public Structure STRUCT_IncomeStmt
            <JsonProperty("date")> Dim dtDate As Date
            <JsonProperty("revenue")> Dim dRevenue As Double
            <JsonProperty("grossProfit")> Dim dGrossProfit As Double
            <JsonProperty("grossProfitRatio")> Dim dGrossMargin As Double
            <JsonProperty("netIncome")> Dim dNetIncome As Double
            <JsonProperty("netIncomeRatio")> Dim dNetMargin As Double
            <JsonProperty("ebitda")> Dim dEBITDA As Double
            <JsonProperty("ebitdaratio")> Dim dEBITDARatio As Double
        End Structure

        Public Structure STRUCT_BalanceSheet
            <JsonProperty("date")> Dim dtDate As Date
            <JsonProperty("totalEquity")> Dim dEquity As Double
        End Structure

        Public Structure STRUCT_Split
            <JsonProperty("date")> Dim dtSplitDate As Date
            <JsonProperty("label")> Dim sLabel As String
            <JsonProperty("denominator")> Dim dSplitFrom As Double
            <JsonProperty("numerator")> Dim dSplitTo As Double
        End Structure

        Public Structure STRUCT_Dividend
            <JsonProperty("date")> Dim dtDividendDate As Date
            <JsonProperty("label")> Dim sLabel As String
            <JsonProperty("adjDividend")> Dim dAdjDividend As Double
            <JsonProperty("dividend")> Dim dDividend As Double
            <JsonProperty("recordDate")> Dim dtRecordDate As Date
            <JsonProperty("paymentDate")> Dim dtPayDate As Date
            <JsonProperty("declarationDate")> Dim dtDeclDate As Date
        End Structure

        Public Structure STRUCT_StockDetail
            <JsonProperty("symbol")> Dim sSymbol As String
            <JsonProperty("currency")> Dim sCurrencyCode As String
            <JsonProperty("cik")> Dim sCIK As String
            <JsonProperty("isin")> Dim sISIN As String
            <JsonProperty("cusip")> Dim sCUSIP As String
            <JsonProperty("exchangeShortName")> Dim sExchange As String
            <JsonProperty("industry")> Dim sIndustry As String
            <JsonProperty("sector")> Dim sSector As String
            <JsonProperty("website")> Dim sWebsite As String
            <JsonProperty("description")> Dim sDescription As String
            <JsonProperty("ceo")> Dim sCEO As String
            <JsonProperty("fullTimeEmployees")> Dim iNumEmployees As Integer
            <JsonProperty("phone")> Dim sPhone As String
            <JsonProperty("address")> Dim sAddress As String
            <JsonProperty("city")> Dim sCity As String
            <JsonProperty("state")> Dim sState As String
            <JsonProperty("zip")> Dim sZip As String
            <JsonProperty("country")> Dim sCountry As String
            <JsonProperty("image")> Dim sCompanyLogo As String
            <JsonProperty("ipoDate")> Dim dtIPODate As Date
            <JsonProperty("isEtf")> Dim bIsETF As Boolean
            <JsonProperty("isActivelyTrading")> Dim bIsActive As Boolean
            <JsonProperty("isAdr")> Dim bIsADR As Boolean
            <JsonProperty("isFund")> Dim bIsFund As Boolean
        End Structure

        Public Structure STRUCT_TechInd
            <JsonProperty("date")> Dim dtDate As Date
            <JsonProperty("close")> Dim dPrice As Double
            <JsonProperty("sma")> Dim dSMA As Double
            <JsonProperty("ema")> Dim dEMA As Double
            <JsonProperty("rsi")> Dim dRSI As Double
        End Structure

        Public Structure STRUCT_StockBuySell
            <JsonProperty("symbol")> Dim sSymbol As String
            <JsonProperty("date")> Dim dtDate As Date
            <JsonProperty("analystRatingsbuy")> Dim iBuy As Integer
            <JsonProperty("analystRatingsHold")> Dim iHold As Integer
            <JsonProperty("analystRatingsSell")> Dim iSell As Integer
            <JsonProperty("analystRatingsStrongSell")> Dim iStrongSell As Integer
            <JsonProperty("analystRatingsStrongBuy")> Dim iStrongBuy As Integer
        End Structure

        Public Structure STRUCT_DCF
            <JsonProperty("symbol")> Dim sSymbol As String
            <JsonProperty("date")> Dim dtDate As Date
            <JsonProperty("dcf")> Dim dDCF As Double
            <JsonProperty("Stock Price")> Dim dStockPrice As Double
        End Structure

    End Class
End Namespace