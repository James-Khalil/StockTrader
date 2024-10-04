Imports Alpaca.Markets
Imports Bottrader.RestAPI.clsFMPStruct

Namespace Job
    Public Class clsAsset
        Private m_oAssetDB As New DB.clsAsset
        Private m_oFMP As New RestAPI.clsFMP

        Public Sub RefreshAssetData(iJobID As Integer, iJobTypeID As Integer)
            Dim iNumThreads As Integer = g_strLookup.ht_strJobType(iJobTypeID).iNumThreads
            Dim iCurrThread, iStartIndex, iChunkSize, iSize, iChunkRem As Integer
            Dim al_strTicker As New List(Of STRUCT_TICKER)
            Dim al_oTask As New List(Of Task)
            Dim oConn As SqlConnection = DB.NewConnection
            Dim oReports As New Reports.clsReports
            Dim strFearGreed As STRUCT_FearGreed
            Dim oFearGreed As New RestAPI.clsFearGreed
            Dim dtEffDate As Date = DateTime.Today()

            Try
                strFearGreed = oFearGreed.GetFearAndGreed(dtEffDate)
                oFearGreed.SaveFearGreed(dtEffDate, strFearGreed, oConn)

                m_oAssetDB.DeleteAllAssets(oConn)
                al_strTicker = m_oFMP.GetAllStocks()
                iChunkSize = al_strTicker.Count \ iNumThreads
                iChunkRem = al_strTicker.Count - (iChunkSize * iNumThreads)

                For iCurrThread = 0 To iNumThreads
                    iStartIndex = iCurrThread * iChunkSize
                    iSize = If(iCurrThread < iNumThreads, iChunkSize, iChunkRem)
                    If (iSize > 0) Then
                        Dim al_oTickerChunk As List(Of STRUCT_TICKER) = al_strTicker.GetRange(iStartIndex, iSize - 1)
                        If (g_eRunMode = ENUM_RunMode.eDebug) Then
                            RefreshAssetDataThread(iJobID, iCurrThread, al_oTickerChunk)
                        Else
                            Dim iNum As Integer = iCurrThread
                            al_oTask.Add(Task.Run(Sub() RefreshAssetDataThread(iJobID, iNum, al_oTickerChunk)))
                        End If
                    End If
                Next
                Task.WaitAll(al_oTask.ToArray)
                m_oAssetDB.DeleteDuplicateAssets()
                DB.ReIndexAllTables(DB.SQL_BT_DB, oConn)
                oReports.SendTop50Assets(oConn)
            Catch ex As Exception
                Throw
            End Try
        End Sub

        Public Sub RefreshAssetScore(iJobID As Integer, iJobTypeID As Integer)
            Dim al_strAsset As List(Of STRUCT_Asset)
            Dim oAssetScore As New TechInd.clsAssetScore
            Dim oConn As SqlConnection = DB.NewConnection
            Dim oReports As New Reports.clsReports
            Dim iCurrThread, iStartIndex, iChunkSize, iSize, iChunkRem As Integer
            Dim iNumThreads As Integer = g_strLookup.ht_strJobType(iJobTypeID).iNumThreads
            Dim al_oTask As New List(Of Task)

            Try
                al_strAsset = LoadAllAssets(oConn)
                iChunkSize = al_strAsset.Count \ iNumThreads
                iChunkRem = al_strAsset.Count - (iChunkSize * iNumThreads)

                For iCurrThread = 0 To iNumThreads
                    iStartIndex = iCurrThread * iChunkSize
                    iSize = If(iCurrThread < iNumThreads, iChunkSize, iChunkRem)
                    If (iSize > 0) Then
                        Dim al_oAssetChunk As List(Of STRUCT_Asset) = al_strAsset.GetRange(iStartIndex, iSize - 1)
                    End If
                Next
                Task.WaitAll(al_oTask.ToArray)
                oReports.SendTop50Assets(oConn)
            Catch ex As Exception
                Throw
            End Try
        End Sub

        Private Function LoadAllAssets(oConn As SqlConnection) As List(Of STRUCT_Asset)
            Dim oTable As DataTable
            Dim strAsset As STRUCT_Asset
            Dim oRow As DataRow
            Dim al_strAsset As New List(Of STRUCT_Asset)
            oTable = m_oAssetDB.GetAllAssets(oConn)
            For Each oRow In oTable.Rows
                strAsset = m_oAssetDB.LoadAssetStruct(oRow)
                al_strAsset.Add(strAsset)
            Next

            Return al_strAsset
        End Function

        Private Sub RefreshAssetDataThread(iJobID As Integer, iThread As Integer, al_strTicker As List(Of STRUCT_Ticker))
            Dim iErrSeq, iIndex, currentRetry, maxRetries As Integer
            Dim sError As String
            Dim oAssetScore As New TechInd.clsAssetScore
            Dim strTicker As STRUCT_Ticker
            Dim strAsset As New STRUCT_Asset
            Dim oJob As New DB.clsJob
            Dim oConn As SqlConnection = DB.NewConnection

            maxRetries = 5

            Try
                While al_strTicker.Count > 0
                    strTicker = al_strTicker(0)
                    al_strTicker.RemoveAt(0)

                    currentRetry = 0
                    While currentRetry < maxRetries
                        Try
                            strAsset = InitAsset(strTicker)
                            GetAssetDetail(strAsset)
                            GetAssetFinancials(strAsset)

                            If (ValidAsset(strAsset)) Then
                                GetAssetTechInd(strAsset)
                                GetAssetSplits(strAsset)
                                GetAssetDividends(strAsset)
                                GetAssetBySell(strAsset)
                                ' GetAssetNews(strAsset) ' Need AI to interpret News
                                GetAssetDCFRatio(strAsset)

                                oAssetScore.CalcAssetScore(strAsset)
                                AddAsset(strAsset, oConn)
                            End If

                            ' Break the retry loop if successful
                            Exit While
                        Catch ex As Exception
                            If IsRateLimitExceeded(ex) Then
                                currentRetry += 1
                                Dim delay As Integer = 1000 * currentRetry
                                Threading.Thread.Sleep(delay)
                            End If
                        End Try
                    End While


                    ' If max retries reached, handle accordingly
                    If currentRetry = maxRetries Then
                        iErrSeq = GetHashKey(iThread, iIndex)
                        sError = "Max retries reached for Asset: " & strAsset.sSymbol
                        oJob.AddJobError(iJobID, iErrSeq, Date.Now, sError, "API rate limit exceeded or 502 Bad Gateway after retries.", oConn)
                    End If
                End While
            Catch ex As Exception
                iErrSeq = GetHashKey(iThread, iIndex)
                sError = If(strAsset.sSymbol.Length = 0, "RefreshAssetDataThread() Failed", "Asset: " & strAsset.sSymbol & " - Failed to Refresh")
                oJob.AddJobError(iJobID, iErrSeq, Date.Now, sError, ex.ToString, oConn)
            Finally
                DB.DBDisConn(oConn)
            End Try
        End Sub

        Private Function IsRateLimitExceeded(ex As Exception) As Boolean
            If ex.Message.Contains("429") OrElse ex.Message.Contains("Too Many Requests") OrElse
                ex.Message.Contains("502") OrElse ex.Message.Contains("Bad Gateway") OrElse
                ex.Message.Contains("rate limit") Then
                Return True
            End If

            Return False
        End Function

        Private Sub RefreshAssetScoreThread(iJobID As Integer, iThread As Integer, al_strAsset As List(Of STRUCT_Asset))
            Dim iErrSeq, iIndex As Integer
            Dim sError As String
            Dim oAssetScore As New TechInd.clsAssetScore
            Dim strAsset As New STRUCT_Asset
            Dim oJob As New DB.clsJob
            Dim oConn As SqlConnection = DB.NewConnection

            Try
                For Each strAsset In al_strAsset
                    oAssetScore.CalcAssetScore(strAsset)
                    m_oAssetDB.UpdateAssetScore(strAsset, oConn)
                Next
            Catch ex As Exception
                iErrSeq = GetHashKey(iThread, iIndex)
                sError = If(strAsset.sSymbol.Length = 0, "RefreshAssetScoreThread() Failed", "Asset: " & strAsset.sSymbol & " - Failed to Refresh")
                oJob.AddJobError(iJobID, iErrSeq, Date.Now, sError, ex.ToString, oConn)
            Finally
                DB.DBDisConn(oConn)
            End Try
        End Sub


        Private Function AddAsset(strAsset As STRUCT_Asset, Optional oConn As SqlConnection = Nothing) As Boolean
            Dim strAssetFinStmt As STRUCT_AssetFinStmt
            Dim strAssetTechInd As STRUCT_AssetTechInd
            Dim strAssetSplit As STRUCT_AssetSplit
            Dim strAssetDividend As STRUCT_AssetDividend

            m_oAssetDB.AddAsset(strAsset, oConn)
            For Each strAssetFinStmt In strAsset.al_strAssetFinStmt
                m_oAssetDB.AddAssetFinStmt(strAsset.sSymbol, strAssetFinStmt, oConn)
            Next

            For Each strAssetTechInd In strAsset.al_strAssetTechInd
                m_oAssetDB.AddAssetTechInd(strAsset.sSymbol, strAssetTechInd, oConn)
            Next

            For Each strAssetSplit In strAsset.al_strAssetSplit
                m_oAssetDB.AddAssetSplit(strAsset.sSymbol, strAssetSplit, oConn)
            Next

            For Each strAssetDividend In strAsset.al_strAssetDividend
                m_oAssetDB.AddAssetDividend(strAsset.sSymbol, strAssetDividend, oConn)
            Next

            Return True
        End Function

        Private Function InitAsset(strTicker As STRUCT_Ticker) As STRUCT_Asset
            Dim strAsset As New STRUCT_Asset

            With strAsset
                .sSymbol = ConvertNull(strTicker.sSymbol, "")
                .sCIK = ""
                .sISIN = ""
                .sCUSIP = ""
                .sExchange = ConvertNull(strTicker.sExchange, "")
                .sCompanyName = ConvertNull(strTicker.sCompanyName, "")
                .sCEO = ""
                .sDescription = ""
                .sCurrencyCode = ""
                .dPrice = ConvertNull(strTicker.dPrice, 0)
                .dYearLow = ConvertNull(strTicker.dYearLow, 0)
                .dYearHigh = ConvertNull(strTicker.dYearHigh, 0)
                .iVolume = ConvertNull(strTicker.iVolume, 0)
                .iAvgVolume = ConvertNull(strTicker.iAvgVolume, 0)
                .iNumEmployees = 0
                .iNumShares = ConvertNull(strTicker.iNumShares, 0)
                .dMarketCap = ConvertNull(strTicker.dMarketCap, 0)
                .dAvgGrossMargin = 0
                .dAvgNetMargin = 0
                .dAvgROE = 0
                .dAvgEBITDARatio = 0
                .dEPS = ConvertNull(strTicker.dEPS, 0)
                .dEPSRatio = DivideWCheck(.dEPS, .dPrice)
                .sIndustry = ""
                .sSector = ""
                .sWebsite = ""
                .sCity = ""
                .sState = ""
                .sZip = ""
                .sCountry = ""
                .dtIPODate = DEFAULT_DATE
                .dSMA50 = ConvertNull(strTicker.dSMA50, 0)
                .dSMA200 = ConvertNull(strTicker.dSMA200, 0)
                .dEMA100 = 0
                .dEMA200 = 0
                .dRSI = 0
                .dSplitFactor = 0
                .dDividendFactor = 0
                .dNewsFactor = 0
                .dAnalystFactor = 0
                .dTechScore = 0
                .dSoftScore = 0
                .dFinScore = 0
                .dTotalScore = 0
                .bIsActive = False
                .bIsADR = False
                .bIsETF = False
                .bIsFund = False
                .dCashFlowRatio = 0

                .al_strAssetFinStmt = New List(Of STRUCT_AssetFinStmt)
                .al_strAssetTechInd = New List(Of STRUCT_AssetTechInd)
                .al_strAssetSplit = New List(Of STRUCT_AssetSplit)
                .al_strAssetDividend = New List(Of STRUCT_AssetDividend)
            End With
            Return strAsset
        End Function

        Private Function ValidAsset(strAsset As STRUCT_Asset) As Boolean
            Dim iDaysListed As Integer

            With strAsset
                If ((Not .bIsActive) OrElse (.bIsETF) OrElse (.bIsFund)) Then
                    Return False
                End If

                If ((.dAvgGrossMargin = 0) AndAlso (.dAvgNetMargin = 0) AndAlso (.dAvgEBITDARatio = 0) AndAlso (.dAvgROE = 0)) Then
                    Return False
                End If

                iDaysListed = DateDiff(DateInterval.Day, .dtIPODate, Now)
                If (iDaysListed < 365) Then
                    Return False
                End If
            End With

            Return True
        End Function

        Private Sub GetAssetDetail(ByRef strAsset As STRUCT_Asset)
            Dim strStockDetail As STRUCT_StockDetail

            Try
                strStockDetail = m_oFMP.GetStockDetail(strAsset.sSymbol)
                strAsset.sCIK = ConvertNull(strStockDetail.sCIK, "")
                strAsset.sISIN = ConvertNull(strStockDetail.sISIN, "")
                strAsset.sCUSIP = ConvertNull(strStockDetail.sCUSIP, "")
                strAsset.sExchange = ConvertNull(strStockDetail.sExchange, "")
                strAsset.sDescription = ConvertNull(strStockDetail.sDescription, "")
                strAsset.sCEO = ConvertNull(strStockDetail.sCEO, "")
                strAsset.sCurrencyCode = ConvertNull(strStockDetail.sCurrencyCode, "USD").ToUpper
                strAsset.iNumEmployees = ConvertNull(strStockDetail.iNumEmployees, 0)
                strAsset.sIndustry = ConvertNull(strStockDetail.sIndustry, "")
                strAsset.sSector = ConvertNull(strStockDetail.sSector, "")
                strAsset.sWebsite = ConvertNull(strStockDetail.sWebsite, "")
                strAsset.sCity = ConvertNull(strStockDetail.sCity, "")
                strAsset.sState = ConvertNull(strStockDetail.sState, "")
                strAsset.sZip = ConvertNull(strStockDetail.sZip, "")
                strAsset.sCountry = ConvertNull(strStockDetail.sCountry, "")
                strAsset.dtIPODate = ConvertNull(strStockDetail.dtIPODate, DEFAULT_DATE)
                strAsset.bIsActive = ConvertNull(strStockDetail.bIsActive, False)
                strAsset.bIsADR = ConvertNull(strStockDetail.bIsADR, False)
                strAsset.bIsETF = ConvertNull(strStockDetail.bIsFund, False)
                strAsset.bIsFund = ConvertNull(strStockDetail.bIsFund, False)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub GetAssetFinancials(ByRef strAsset As STRUCT_Asset)
            Dim al_strIncomeStmt As List(Of STRUCT_IncomeStmt)
            Dim al_strBalanceSheet As List(Of STRUCT_BalanceSheet)
            Dim strIncomeStmt As STRUCT_IncomeStmt
            Dim strBalanceSheet As STRUCT_BalanceSheet
            Dim strAssetFinStmt As STRUCT_AssetFinStmt
            Dim iMinLength As Integer
            Dim dtDate As Date
            Dim dWeight As Double

            Try
                al_strIncomeStmt = m_oFMP.GetIncomeStmt(strAsset.sSymbol)
                al_strBalanceSheet = m_oFMP.GetBalanceSheet(strAsset.sSymbol)
                iMinLength = Math.Min(al_strIncomeStmt.Count, al_strBalanceSheet.Count)
                iMinLength = Math.Min(iMinLength, 10) 'Limit to 10 years
                For iIndex = 0 To iMinLength - 1
                    strIncomeStmt = al_strIncomeStmt(iIndex)
                    dtDate = ConvertNull(strIncomeStmt.dtDate, DEFAULT_DATE)
                    strAssetFinStmt.dtReportDate = dtDate
                    strAssetFinStmt.dRevenue = ConvertNull(strIncomeStmt.dRevenue, 0)
                    strAssetFinStmt.dGrossProfit = ConvertNull(strIncomeStmt.dGrossProfit, 0)
                    strAssetFinStmt.dGrossMargin = ConvertNull(strIncomeStmt.dGrossMargin, 0)
                    strAssetFinStmt.dNetIncome = ConvertNull(strIncomeStmt.dNetIncome, 0)
                    strAssetFinStmt.dNetMargin = ConvertNull(strIncomeStmt.dNetMargin, 0)
                    strAssetFinStmt.dEBITDA = ConvertNull(strIncomeStmt.dEBITDA, 0)
                    strAssetFinStmt.dEBITDARatio = ConvertNull(strIncomeStmt.dEBITDARatio, 0)

                    strBalanceSheet = al_strBalanceSheet(iIndex)
                    strAssetFinStmt.dEquity = If(strBalanceSheet.dtDate = dtDate, strBalanceSheet.dEquity, 0)
                    strAssetFinStmt.dROE = DivideWCheck(strAssetFinStmt.dNetIncome, strAssetFinStmt.dEquity)

                    If (iIndex < 4) Then 'Weighted Average 4 year of financials
                        dWeight = (4 - iIndex) * 0.1
                        strAsset.dAvgGrossMargin += dWeight * If(strAssetFinStmt.dRevenue < 0, -1, strAssetFinStmt.dGrossMargin)
                        strAsset.dAvgNetMargin += dWeight * If(strAssetFinStmt.dRevenue < 0, -1, strAssetFinStmt.dNetMargin)
                        strAsset.dAvgEBITDARatio += dWeight * If(strAssetFinStmt.dRevenue < 0, -1, strAssetFinStmt.dEBITDARatio)
                        strAsset.dAvgROE += dWeight * If(strAssetFinStmt.dEquity < 0, -1, strAssetFinStmt.dEBITDARatio)
                    End If
                    strAsset.al_strAssetFinStmt.Add(strAssetFinStmt)
                Next
            Catch ex As Exception
                Throw
            End Try
        End Sub

        Private Sub GetAssetTechInd(ByRef strAsset As STRUCT_Asset)
            Dim al_strSMA50, al_strSMA200, al_strEMA100, al_strEMA200, al_strRSI As List(Of STRUCT_TechInd)
            Dim iMinLength As Integer
            Dim strAssetTechInd As STRUCT_AssetTechInd
            Dim dtDate As Date
            Dim strTechInd As STRUCT_TechInd

            al_strSMA50 = m_oFMP.GetTechInd(strAsset.sSymbol, RestAPI.clsFMP.Enum_TechIndType.eSMA50)
            al_strSMA200 = m_oFMP.GetTechInd(strAsset.sSymbol, RestAPI.clsFMP.Enum_TechIndType.eSMA200)
            al_strEMA100 = m_oFMP.GetTechInd(strAsset.sSymbol, RestAPI.clsFMP.Enum_TechIndType.eEMA100)
            al_strEMA200 = m_oFMP.GetTechInd(strAsset.sSymbol, RestAPI.clsFMP.Enum_TechIndType.eEMA200)
            al_strRSI = m_oFMP.GetTechInd(strAsset.sSymbol, RestAPI.clsFMP.Enum_TechIndType.eRSI)

            iMinLength = Math.Min(Math.Min(Math.Min(al_strSMA50.Count, al_strSMA200.Count),
                         Math.Min(al_strEMA100.Count, al_strEMA200.Count)), al_strRSI.Count)
            iMinLength = Math.Min(iMinLength, 50) 'Limit to 50 days

            For iIndex = 0 To iMinLength - 1
                strTechInd = al_strSMA50(iIndex)
                dtDate = ConvertNull(strTechInd.dtDate, DEFAULT_DATE)
                strAssetTechInd.dtDateStamp = dtDate
                strAssetTechInd.dPrice = ConvertNull(strTechInd.dPrice, 0)
                strAssetTechInd.dSMA50 = ConvertNull(strTechInd.dSMA, 0)

                strTechInd = al_strSMA200(iIndex)
                strAssetTechInd.dSMA200 = If(strTechInd.dtDate = dtDate, ConvertNull(strTechInd.dSMA, 0), 0)

                strTechInd = al_strEMA100(iIndex)
                strAssetTechInd.dEMA100 = If(strTechInd.dtDate = dtDate, ConvertNull(strTechInd.dEMA, 0), 0)

                strTechInd = al_strEMA200(iIndex)
                strAssetTechInd.dEMA200 = If(strTechInd.dtDate = dtDate, ConvertNull(strTechInd.dEMA, 0), 0)

                strTechInd = al_strRSI(iIndex)
                strAssetTechInd.dRSI = If(strTechInd.dtDate = dtDate, ConvertNull(strTechInd.dRSI, 0), 0)

                If (iIndex = 0) Then
                    strAsset.dSMA50 = strAssetTechInd.dSMA50
                    strAsset.dSMA200 = strAssetTechInd.dSMA200
                    strAsset.dEMA100 = strAssetTechInd.dEMA100
                    strAsset.dEMA200 = strAssetTechInd.dEMA200
                    strAsset.dRSI = strAssetTechInd.dRSI
                End If
                strAsset.al_strAssetTechInd.Add(strAssetTechInd)
            Next
        End Sub

        Private Sub GetAssetSplits(ByRef strAsset As STRUCT_Asset)
            Dim al_strSplit As List(Of STRUCT_Split)
            Dim strSplit As STRUCT_Split
            Dim strAssetSplit As New STRUCT_AssetSplit
            Dim dtThreshold As Date = DateAdd(DateInterval.Year, -3, Today)

            Try
                al_strSplit = m_oFMP.GetSplits(strAsset.sSymbol)
                For iIndex = 0 To al_strSplit.Count - 1
                    strSplit = al_strSplit(iIndex)
                    strAssetSplit.dtSplitDate = ConvertNull(strSplit.dtSplitDate, DEFAULT_DATE)
                    strAssetSplit.dSplitFrom = ConvertNull(strSplit.dSplitFrom, 0)
                    strAssetSplit.dSplitTo = ConvertNull(strSplit.dSplitTo, 0)
                    strAsset.al_strAssetSplit.Add(strAssetSplit)

                    If (iIndex = 0) Then
                        If (strAssetSplit.dtSplitDate > dtThreshold) Then
                            strAsset.dSplitFactor = (strAssetSplit.dSplitTo - strAssetSplit.dSplitFrom) / strAssetSplit.dSplitFrom
                        End If
                    End If
                Next
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub GetAssetDividends(ByRef strAsset As STRUCT_Asset)
            Dim al_strDividend As List(Of STRUCT_Dividend)
            Dim strDividend As STRUCT_Dividend
            Dim strAssetDividend As New STRUCT_AssetDividend
            Dim dtThreshold As Date = DateAdd(DateInterval.Year, -1, Today)

            Try
                al_strDividend = m_oFMP.GetDividends(strAsset.sSymbol)
                For iIndex = 0 To al_strDividend.Count - 1
                    strDividend = al_strDividend(iIndex)
                    strAssetDividend.dtDividendDate = ConvertNull(strDividend.dtDividendDate, DEFAULT_DATE)
                    strAssetDividend.dDividend = ConvertNull(strDividend.dDividend, 0)
                    strAssetDividend.dAdjDividend = ConvertNull(strDividend.dAdjDividend, 0)
                    strAssetDividend.dtRecordDate = ConvertNull(strDividend.dtRecordDate, DEFAULT_DATE)
                    strAssetDividend.dtPayDate = ConvertNull(strDividend.dtPayDate, DEFAULT_DATE)
                    strAssetDividend.dtDeclDate = ConvertNull(strDividend.dtDeclDate, DEFAULT_DATE)
                    strAsset.al_strAssetDividend.Add(strAssetDividend)

                    If (iIndex = 0) Then
                        If (strAssetDividend.dtDividendDate > dtThreshold) Then
                            strAsset.dDividendFactor = strAssetDividend.dAdjDividend / strAsset.dPrice
                        End If
                    End If
                Next
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub GetAssetBySell(ByRef strAsset As STRUCT_Asset)
            Dim al_strStockBuySell As List(Of STRUCT_StockBuySell)
            Dim strStockBuySell As STRUCT_StockBuySell
            Dim dtThreshold As Date = DateAdd(DateInterval.Month, -1, Today)
            Dim iNumAnalysts As Integer
            Dim dWeightSum As Double

            Try
                al_strStockBuySell = m_oFMP.GetStockBuySell(strAsset.sSymbol)
                For Each strStockBuySell In al_strStockBuySell
                    With strStockBuySell
                        .dtDate = ConvertNull(.dtDate, DEFAULT_DATE)
                        .iStrongBuy = ConvertNull(.iStrongBuy, 0)
                        .iBuy = ConvertNull(.iBuy, 0)
                        .iHold = ConvertNull(.iHold, 0)
                        .iSell = ConvertNull(.iSell, 0)
                        .iStrongSell = ConvertNull(.iStrongSell, 0)

                        If (.dtDate > dtThreshold) Then
                            iNumAnalysts = .iStrongBuy + .iBuy + .iHold + .iSell + .iStrongSell
                            dWeightSum = (.iStrongBuy * 1) + (.iBuy * 0.5) + (.iHold * 0) + (.iSell * -0.5) + (.iStrongSell * -1)
                            strAsset.dAnalystFactor = DivideWCheck(dWeightSum, iNumAnalysts)
                        End If
                    End With
                Next
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        'Private Sub GetAssetNews(ByRef strAsset As STRUCT_Asset)
        '    Dim al_sSymbol As New List(Of String)
        '    Dim al_strDividend As List(Of STRUCT_DIVIDEND)
        '    Dim strDividend As STRUCT_DIVIDEND
        '    Dim dtThreshold As Date = DateAdd(DateInterval.Year, -1, Today)

        '    Try
        '        al_strDividend = m_oPolygon.GetNews(strAsset.sSymbol, DEFAULT_DATE)
        '        If (al_strDividend.Count > 0) Then
        '            strDividend = al_strDividend(0)
        '            strAsset.bDividendFlag = (strDividend.dtDividendDate > dtThreshold)
        '        End If

        '        For Each strDividend In al_strDividend
        '            m_oAssetDB.AddAssetDividend(strDividend, oConn)
        '        Next
        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        'End Sub

        Private Sub GetAssetDCFRatio(ByRef strAsset As STRUCT_Asset)
            Dim strDCF As STRUCT_DCF

            Try
                strDCF = m_oFMP.GetDCFData(strAsset.sSymbol)

                If strDCF.dDCF = 0 AndAlso strDCF.dStockPrice = 0 Then
                    ' No valid DCF data returned, skip the calculation
                    Exit Sub
                End If

                ' Perform the calculation if valid data exists
                strAsset.dCashFlowRatio = (strDCF.dDCF - strDCF.dStockPrice) / strDCF.dStockPrice

            Catch ex As Exception
                ' Handle the exception (rethrowing in this case)
                Throw ex
            End Try
        End Sub

    End Class
End Namespace