Imports Alpaca.Markets

Module modStruct

    Public g_strLookup As STRUCT_Lookup
    Public g_strAppConst As STRUCT_AppConst
    Public g_strCurrUser As STRUCT_User

    Public Structure STRUCT_Lookup
        Dim ht_strJobType As Dictionary(Of Integer, STRUCT_JobType)
        Dim ht_sJobStatus As Dictionary(Of Integer, String)
        Dim ht_sSecurity As Dictionary(Of Integer, String)
    End Structure

    Public Structure STRUCT_JobType
        Dim iJobTypeID As Integer
        Dim sDescription As String
        Dim iNumThreads As Integer
        Dim iDaysRetainLog As Integer
    End Structure

    Public Structure STRUCT_User
        Dim iUserID As Integer
        Dim sLogin As String
        Dim sName As String
        Dim sEmail As String
        Dim iSecurityID As Integer
        Dim bActiveFlag As Boolean
    End Structure

    Public Structure STRUCT_AppConst
        Dim iAppConstID As Integer
        Dim sBaseCurrency As String
        Dim bPrice_EMA100_Flag As Boolean
        Dim dPrice_EMA100_Score As Double
        Dim bPrice_EMA200_Flag As Boolean
        Dim dPrice_EMA200_Score As Double
        Dim bSMA50_SMA200_Flag As Boolean
        Dim dSMA50_SMA200_Score As Double
        Dim bEMA100_EMA200_Flag As Boolean
        Dim dEMA100_EMA200_Score As Double
        Dim bRSI_Flag As Boolean
        Dim dRSI_Score As Double
        Dim bSplit_Flag As Boolean
        Dim dSplit_Score As Double
        Dim bDividend_Flag As Boolean
        Dim dDividend_Score As Double
        Dim bNews_Flag As Boolean
        Dim dNews_Score As Double
        Dim bAnalyst_Flag As Boolean
        Dim dAnalyst_Score As Double
        Dim bListedYears_Flag As Boolean
        Dim dListedYears_Score As Double
        Dim bNumEmp_Flag As Boolean
        Dim dNumEmp_Score As Double
        Dim bMarketCap_Flag As Boolean
        Dim dMarketCap_Score As Double
        Dim bGrossMargin_Flag As Boolean
        Dim dGrossMargin_Score As Double
        Dim bNetMargin_Flag As Boolean
        Dim dNetMargin_Score As Double
        Dim bROE_Flag As Boolean
        Dim dROE_Score As Double
        Dim bEBITDARatio_Flag As Boolean
        Dim dEBITDARatio_Score As Double
        Dim bEPSRatio_Flag As Boolean
        Dim dEPSRatio_Score As Double
    End Structure

    Public Structure STRUCT_Asset
        Dim sSymbol As String
        Dim sExchange As String
        Dim sCompanyName As String
        Dim sDescription As String
        Dim dtIPODate As DateTime
        Dim sIndustry As String
        Dim sSector As String
        Dim sCEO As String
        Dim sCIK As String
        Dim sISIN As String
        Dim sCUSIP As String
        Dim sCity As String
        Dim sState As String
        Dim sZip As String
        Dim sCountry As String
        Dim sWebsite As String
        Dim sCurrencyCode As String
        Dim dPrice As Double
        Dim dYearLow As Double
        Dim dYearHigh As Double
        Dim iVolume As Long
        Dim iAvgVolume As Long
        Dim iNumEmployees As Integer
        Dim iNumShares As Long
        Dim dMarketCap As Double
        Dim dAvgGrossMargin As Double
        Dim dAvgNetMargin As Double
        Dim dAvgROE As Double
        Dim dAvgEBITDARatio As Double
        Dim dEPS As Double
        Dim dEPSRatio As Double
        Dim dSMA50 As Double
        Dim dSMA200 As Double
        Dim dEMA100 As Double
        Dim dEMA200 As Double
        Dim dRSI As Double
        Dim dSplitFactor As Double
        Dim dDividendFactor As Double
        Dim dNewsFactor As Double
        Dim dAnalystFactor As Double
        Dim dTechScore As Double
        Dim dSoftScore As Double
        Dim dFinScore As Double
        Dim dTotalScore As Double
        Dim bIsActive As Boolean
        Dim bIsADR As Boolean
        Dim bIsETF As Boolean
        Dim bIsFund As Boolean
        Dim dCashFlowRatio As Double

        Dim al_strAssetFinStmt As List(Of STRUCT_AssetFinStmt)
        Dim al_strAssetTechInd As List(Of STRUCT_AssetTechInd)
        Dim al_strAssetSplit As List(Of STRUCT_AssetSplit)
        Dim al_strAssetDividend As List(Of STRUCT_AssetDividend)
    End Structure

    Public Structure STRUCT_AssetFinStmt
        Dim dtReportDate As Date
        Dim dRevenue As Double
        Dim dEquity As Double
        Dim dGrossProfit As Double
        Dim dGrossMargin As Double
        Dim dNetIncome As Double
        Dim dNetMargin As Double
        Dim dROE As Double
        Dim dEBITDA As Double
        Dim dEBITDARatio As Double
    End Structure

    Public Structure STRUCT_AssetTechInd
        Dim dtDateStamp As DateTime
        Dim dPrice As Double
        Dim dSMA50 As Double
        Dim dSMA200 As Double
        Dim dEMA100 As Double
        Dim dEMA200 As Double
        Dim dRSI As Double
    End Structure

    Public Structure STRUCT_AssetSplit
        Dim dtSplitDate As DateTime
        Dim dSplitFrom As Double
        Dim dSplitTo As Double
    End Structure

    Public Structure STRUCT_AssetDividend
        Dim dtDividendDate As DateTime
        Dim dDividend As Double
        Dim dAdjDividend As Double
        Dim dtRecordDate As Date
        Dim dtPayDate As Date
        Dim dtDeclDate As Date
    End Structure

    Public Structure STRUCT_TransHist
        Dim sSymbol As String
        Dim dtTransDate As DateTime
        Dim dPrice As Double
        Dim dVolume As Double
        Dim iOrderTypeID As OrderType
        Friend iOrderSideID As OrderSide
    End Structure

    Public Structure STRUCT_WeekFlags
        Dim bMonday As Boolean
        Dim bTuesday As Boolean
        Dim bWednesday As Boolean
        Dim bThursday As Boolean
        Dim bFriday As Boolean
        Dim bSaturday As Boolean
        Dim bSunday As Boolean
    End Structure

    Public Structure STRUCT_FearGreed
        Dim iFearGreedID As Integer
        Dim dtEffDate As DateTime
        Dim dScore_Today As Double
        Dim sRating_Today As String
        Dim dScore_Yesterday As Double
        Dim sRating_Yesterday As String
        Dim dScore_PrevWeek As Double
        Dim sRating_PrevWeek As String
        Dim dScore_PrevMonth As Double
        Dim sRating_PrevMonth As String
        Dim dScore_PrevYear As Double
        Dim sRating_PrevYear As String
        Dim dScore_SP500 As Double
        Dim sRating_SP500 As String
        Dim dScore_SP125 As Double
        Dim sRating_SP125 As String
        Dim dScore_SPS As Double
        Dim sRating_SPS As String
        Dim dScore_MVV As Double
        Dim sRating_MVV As String
        Dim dScore_SHD As Double
        Dim sRating_SHD As String
    End Structure

End Module
