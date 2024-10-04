Imports Bottrader.RestAPI.clsFMPStruct

Namespace DB
    Friend Class clsAsset

        Friend Function LoadAssetStruct(oRow As DataRow) As STRUCT_Asset
            Dim strAsset As New STRUCT_Asset

            With strAsset
                .sSymbol = ConvertDBNull(oRow("Symbol"), "")
                .sExchange = ConvertDBNull(oRow("Exchange"), "")
                .sCompanyName = ConvertDBNull(oRow("CompanyName"), "")
                .sDescription = ConvertDBNull(oRow("Description"), "")
                .dtIPODate = ConvertDBNull(oRow("IPODate"), DEFAULT_DATE)
                .sIndustry = ConvertDBNull(oRow("Industry"), "")
                .sSector = ConvertDBNull(oRow("Sector"), "")
                .sCEO = ConvertDBNull(oRow("CEO"), "")
                .sCIK = ConvertDBNull(oRow("CIK"), "")
                .sISIN = ConvertDBNull(oRow("ISIN"), "")
                .sCUSIP = ConvertDBNull(oRow("CUSIP"), "")
                .sCity = ConvertDBNull(oRow("City"), "")
                .sState = ConvertDBNull(oRow("State"), "")
                .sZip = ConvertDBNull(oRow("Zip"), "")
                .sCountry = ConvertDBNull(oRow("Country"), "")
                .sWebsite = ConvertDBNull(oRow("Website"), "")
                .sCurrencyCode = ConvertDBNull(oRow("CurrencyCode"), "")
                .dPrice = ConvertDBNull(oRow("Price"), 0)
                .iVolume = ConvertDBNull(oRow("Volume"), 0)
                .iAvgVolume = ConvertDBNull(oRow("AvgVolume"), 0)
                .iNumEmployees = ConvertDBNull(oRow("NumEmployees"), 0)
                .iNumShares = ConvertDBNull(oRow("NumShares"), 0)
                .dMarketCap = ConvertDBNull(oRow("MarketCap"), 0)
                .dAvgGrossMargin = ConvertDBNull(oRow("AvgGrossMargin"), 0)
                .dAvgNetMargin = ConvertDBNull(oRow("AvgNetMargin"), 0)
                .dAvgROE = ConvertDBNull(oRow("AvgROE"), 0)
                .dAvgEBITDARatio = ConvertDBNull(oRow("AvgEBITDARatio"), 0)
                .dEPS = ConvertDBNull(oRow("EPS"), 0)
                .dEPSRatio = ConvertDBNull(oRow("EPSRatio"), 0)
                .dSMA50 = ConvertDBNull(oRow("SMA50"), 0)
                .dSMA50 = ConvertDBNull(oRow("SMA50"), 0)
                .dSMA200 = ConvertDBNull(oRow("SMA200"), 0)
                .dEMA100 = ConvertDBNull(oRow("EMA100"), 0)
                .dRSI = ConvertDBNull(oRow("RSI"), 0)
                .dSplitFactor = ConvertDBNull(oRow("SplitFactor"), 0)
                .dDividendFactor = ConvertDBNull(oRow("DividendFactor"), 0)
                .dNewsFactor = ConvertDBNull(oRow("NewsFactor"), 0)
                .dAnalystFactor = ConvertDBNull(oRow("AnalystFactor"), 0)
                .dTechScore = ConvertDBNull(oRow("TechScore"), 0)
                .dSoftScore = ConvertDBNull(oRow("SoftScore"), 0)
                .dFinScore = ConvertDBNull(oRow("FinScore"), 0)
                .dTotalScore = ConvertDBNull(oRow("TotalScore"), 0)
                .bIsActive = ConvertDBNull(oRow("IsActive"), False)
                .bIsADR = ConvertDBNull(oRow("IsADR"), False)
                .bIsETF = ConvertDBNull(oRow("IsETF"), False)
                .bIsFund = ConvertDBNull(oRow("IsFund"), False)
            End With

            Return strAsset
        End Function

        Public Function AddAsset(strAsset As STRUCT_Asset, Optional oConn As SqlConnection = Nothing) As Boolean
            Dim bSuccess As Boolean
            Dim al_oParams As New List(Of SqlParameter)

            With al_oParams
                .Add(GetSQLParam("@Symbol", SqlDbType.VarChar, 10, strAsset.sSymbol))
                .Add(GetSQLParam("@Exchange", SqlDbType.VarChar, 25, strAsset.sExchange))
                .Add(GetSQLParam("@CompanyName", SqlDbType.VarChar, 100, strAsset.sCompanyName))
                .Add(GetSQLParam("@Description", SqlDbType.VarChar, 500, strAsset.sDescription))
                .Add(GetSQLParam("@IPODate", SqlDbType.Date, strAsset.dtIPODate))
                .Add(GetSQLParam("@Industry", SqlDbType.VarChar, 50, strAsset.sIndustry))
                .Add(GetSQLParam("@Sector", SqlDbType.VarChar, 50, strAsset.sSector))
                .Add(GetSQLParam("@CEO", SqlDbType.VarChar, 50, strAsset.sCEO))
                .Add(GetSQLParam("@CIK", SqlDbType.VarChar, 25, strAsset.sCIK))
                .Add(GetSQLParam("@ISIN", SqlDbType.VarChar, 25, strAsset.sISIN))
                .Add(GetSQLParam("@CUSIP", SqlDbType.VarChar, 25, strAsset.sCUSIP))
                .Add(GetSQLParam("@City", SqlDbType.VarChar, 50, strAsset.sCity))
                .Add(GetSQLParam("@State", SqlDbType.VarChar, 50, strAsset.sState))
                .Add(GetSQLParam("@Zip", SqlDbType.VarChar, 25, strAsset.sZip))
                .Add(GetSQLParam("@Country", SqlDbType.VarChar, 50, strAsset.sCountry))
                .Add(GetSQLParam("@Website", SqlDbType.VarChar, 256, strAsset.sWebsite))
                .Add(GetSQLParam("@CurrencyCode", SqlDbType.VarChar, 10, strAsset.sCurrencyCode))
                .Add(GetSQLParam("@Price", SqlDbType.Float, strAsset.dPrice))
                .Add(GetSQLParam("@Volume", SqlDbType.Float, strAsset.iVolume))
                .Add(GetSQLParam("@AvgVolume", SqlDbType.Float, strAsset.iAvgVolume))
                .Add(GetSQLParam("@NumEmployees", SqlDbType.Int, strAsset.iNumEmployees))
                .Add(GetSQLParam("@NumShares", SqlDbType.BigInt, strAsset.iNumShares))
                .Add(GetSQLParam("@MarketCap", SqlDbType.Float, strAsset.dMarketCap))
                .Add(GetSQLParam("@AvgGrossMargin", SqlDbType.Float, strAsset.dAvgGrossMargin))
                .Add(GetSQLParam("@AvgNetMargin", SqlDbType.Float, strAsset.dAvgNetMargin))
                .Add(GetSQLParam("@AvgROE", SqlDbType.Float, strAsset.dAvgROE))
                .Add(GetSQLParam("@AvgEBITDARatio", SqlDbType.Float, strAsset.dAvgEBITDARatio))
                .Add(GetSQLParam("@EPS", SqlDbType.Float, strAsset.dEPS))
                .Add(GetSQLParam("@EPSRatio", SqlDbType.Float, strAsset.dEPSRatio))
                .Add(GetSQLParam("@SMA50", SqlDbType.Float, strAsset.dSMA50))
                .Add(GetSQLParam("@SMA200", SqlDbType.Float, strAsset.dSMA200))
                .Add(GetSQLParam("@EMA100", SqlDbType.Float, strAsset.dEMA100))
                .Add(GetSQLParam("@EMA200", SqlDbType.Float, strAsset.dEMA200))
                .Add(GetSQLParam("@RSI", SqlDbType.Float, strAsset.dRSI))
                .Add(GetSQLParam("@SplitFactor", SqlDbType.Float, strAsset.dSplitFactor))
                .Add(GetSQLParam("@DividendFactor", SqlDbType.Float, strAsset.dDividendFactor))
                .Add(GetSQLParam("@NewsFactor", SqlDbType.Float, strAsset.dNewsFactor))
                .Add(GetSQLParam("@AnalystFactor", SqlDbType.Float, strAsset.dAnalystFactor))
                .Add(GetSQLParam("@TechScore", SqlDbType.Float, strAsset.dTechScore))
                .Add(GetSQLParam("@SoftScore", SqlDbType.Float, strAsset.dSoftScore))
                .Add(GetSQLParam("@FinScore", SqlDbType.Float, strAsset.dFinScore))
                .Add(GetSQLParam("@TotalScore", SqlDbType.Float, strAsset.dTotalScore))
                .Add(GetSQLParam("@IsActive", SqlDbType.Bit, strAsset.bIsActive))
                .Add(GetSQLParam("@IsADR", SqlDbType.Bit, strAsset.bIsADR))
                .Add(GetSQLParam("@IsETF", SqlDbType.Bit, strAsset.bIsETF))
                .Add(GetSQLParam("@IsFund", SqlDbType.Bit, strAsset.bIsFund))
                .Add(GetSQLParam("@CashFlowRatio", SqlDbType.Float, strAsset.dCashFlowRatio))
            End With

            bSuccess = DB.Exec_SP("sp_AddAsset", al_oParams, oConn)
            Return bSuccess
        End Function

        Public Function UpdateAssetScore(strAsset As STRUCT_Asset, Optional oConn As SqlConnection = Nothing) As Boolean
            Dim bSuccess As Boolean
            Dim al_oParams As New List(Of SqlParameter)

            With al_oParams
                .Add(GetSQLParam("@Symbol", SqlDbType.VarChar, 10, strAsset.sSymbol))
                .Add(GetSQLParam("@TechScore", SqlDbType.Float, strAsset.dTechScore))
                .Add(GetSQLParam("@SoftScore", SqlDbType.Float, strAsset.dSoftScore))
                .Add(GetSQLParam("@FinScore", SqlDbType.Float, strAsset.dFinScore))
                .Add(GetSQLParam("@TotalScore", SqlDbType.Float, strAsset.dTotalScore))
            End With

            bSuccess = DB.Exec_SP("sp_UpdateAssetScore", al_oParams, oConn)
            Return bSuccess
        End Function

        Public Function AddAssetTechInd(sSymbol As String, strAssetTechInd As STRUCT_AssetTechInd,
                                        Optional oConn As SqlConnection = Nothing) As Boolean
            Dim bSuccess As Boolean
            Dim al_oParams As New List(Of SqlParameter)
            al_oParams.Add(GetSQLParam("@Symbol", SqlDbType.VarChar, 10, sSymbol))
            al_oParams.Add(GetSQLParam("@DateStamp", SqlDbType.Date, strAssetTechInd.dtDateStamp))
            al_oParams.Add(GetSQLParam("@Price", SqlDbType.Float, strAssetTechInd.dPrice))
            al_oParams.Add(GetSQLParam("@SMA50", SqlDbType.Float, strAssetTechInd.dSMA50))
            al_oParams.Add(GetSQLParam("@SMA200", SqlDbType.Float, strAssetTechInd.dSMA200))
            al_oParams.Add(GetSQLParam("@EMA100", SqlDbType.Float, strAssetTechInd.dEMA100))
            al_oParams.Add(GetSQLParam("@EMA200", SqlDbType.Float, strAssetTechInd.dEMA200))
            al_oParams.Add(GetSQLParam("@RSI", SqlDbType.Float, strAssetTechInd.dRSI))
            bSuccess = DB.Exec_SP("sp_AddAssetTechInd", al_oParams, oConn)
            Return bSuccess
        End Function

        Public Function AddAssetFinStmt(sSymbol As String, strAssetFinStmt As STRUCT_AssetFinStmt,
                                        Optional oConn As SqlConnection = Nothing) As Boolean
            Dim bSuccess As Boolean
            Dim al_oParams As New List(Of SqlParameter)
            al_oParams.Add(GetSQLParam("@Symbol", SqlDbType.VarChar, 10, sSymbol))
            al_oParams.Add(GetSQLParam("@ReportDate", SqlDbType.Date, strAssetFinStmt.dtReportDate))
            al_oParams.Add(GetSQLParam("@Revenue", SqlDbType.Float, strAssetFinStmt.dRevenue))
            al_oParams.Add(GetSQLParam("@Equity", SqlDbType.Float, strAssetFinStmt.dEquity))
            al_oParams.Add(GetSQLParam("@GrossProfit", SqlDbType.Float, strAssetFinStmt.dGrossProfit))
            al_oParams.Add(GetSQLParam("@GrossMargin", SqlDbType.Float, strAssetFinStmt.dGrossMargin))
            al_oParams.Add(GetSQLParam("@NetIncome", SqlDbType.Float, strAssetFinStmt.dNetIncome))
            al_oParams.Add(GetSQLParam("@NetMargin", SqlDbType.Float, strAssetFinStmt.dNetMargin))
            al_oParams.Add(GetSQLParam("@ROE", SqlDbType.Float, strAssetFinStmt.dROE))
            al_oParams.Add(GetSQLParam("@EBITDA", SqlDbType.Float, strAssetFinStmt.dEBITDA))
            al_oParams.Add(GetSQLParam("@EBITDARatio", SqlDbType.Float, strAssetFinStmt.dEBITDARatio))
            bSuccess = DB.Exec_SP("sp_AddAssetFinStmt", al_oParams, oConn)
            Return bSuccess
        End Function

        Public Function AddAssetSplit(sSymbol As String, strAssetSplit As STRUCT_AssetSplit,
                                      Optional oConn As SqlConnection = Nothing) As Boolean
            Dim bSuccess As Boolean
            Dim al_oParams As New List(Of SqlParameter)

            al_oParams.Add(GetSQLParam("@Symbol", SqlDbType.VarChar, 10, sSymbol))
            al_oParams.Add(GetSQLParam("@SplitDate", SqlDbType.Date, strAssetSplit.dtSplitDate))
            al_oParams.Add(GetSQLParam("@SplitFrom", SqlDbType.Float, strAssetSplit.dSplitFrom))
            al_oParams.Add(GetSQLParam("@SplitTo", SqlDbType.Float, strAssetSplit.dSplitTo))
            bSuccess = DB.Exec_SP("sp_AddAssetSplit", al_oParams, oConn)
            Return bSuccess
        End Function

        Public Function AddAssetDividend(sSymbol As String, strAssetDividend As STRUCT_AssetDividend,
                                         Optional oConn As SqlConnection = Nothing) As Boolean
            Dim bSuccess As Boolean

            Dim al_oParams As New List(Of SqlParameter)
            al_oParams.Add(GetSQLParam("@Symbol", SqlDbType.VarChar, 10, sSymbol))
            al_oParams.Add(GetSQLParam("@DividendDate", SqlDbType.Date, strAssetDividend.dtDividendDate))
            al_oParams.Add(GetSQLParam("@AdjDividend", SqlDbType.Float, strAssetDividend.dAdjDividend))
            al_oParams.Add(GetSQLParam("@Dividend", SqlDbType.Float, strAssetDividend.dDividend))
            al_oParams.Add(GetSQLParam("@RecordDate", SqlDbType.Date, 10, strAssetDividend.dtRecordDate))
            al_oParams.Add(GetSQLParam("@PayDate", SqlDbType.Date, strAssetDividend.dtPayDate))
            al_oParams.Add(GetSQLParam("@DeclDate", SqlDbType.Date, strAssetDividend.dtDeclDate))
            bSuccess = DB.Exec_SP("sp_AddAssetDividend", al_oParams, oConn)
            Return bSuccess
        End Function

        Public Function DeleteAsset(sSymbol As String, Optional oConn As SqlConnection = Nothing) As Boolean
            Dim bSuccess As Boolean
            Dim al_oParams As New List(Of SqlParameter)

            With al_oParams
                .Add(GetSQLParam("@Symbol", SqlDbType.VarChar, 10, sSymbol))
            End With

            bSuccess = DB.Exec_SP("sp_DeleteAsset_Symbol", al_oParams, oConn)
            Return bSuccess
        End Function

        Public Function DeleteAllAssets(Optional oConn As SqlConnection = Nothing) As Boolean
            Dim bSuccess As Boolean

            bSuccess = DB.Exec_SP("sp_DeleteALLAsset", oConn)
            Return bSuccess
        End Function

        Public Function DeleteDuplicateAssets(Optional oConn As SqlConnection = Nothing) As Boolean
            Dim bSuccess As Boolean

            bSuccess = DB.Exec_SP("sp_DeleteDuplicateStock", oConn)
            Return bSuccess
        End Function

        Public Function AddTransHist(strTransHist As STRUCT_TransHist, Optional oConn As SqlConnection = Nothing) As Boolean
            Dim bSuccess As Boolean
            Dim al_oParams As New List(Of SqlParameter)
            al_oParams.Add(GetSQLParam("@Symbol", SqlDbType.VarChar, 10, strTransHist.sSymbol))
            al_oParams.Add(GetSQLParam("@TransDate", SqlDbType.DateTime, strTransHist.dtTransDate))
            al_oParams.Add(GetSQLParam("@Price", SqlDbType.Float, strTransHist.dPrice))
            al_oParams.Add(GetSQLParam("@Volume", SqlDbType.Float, strTransHist.dVolume))
            al_oParams.Add(GetSQLParam("@OrderTypeID", SqlDbType.Int, strTransHist.iOrderTypeID))
            al_oParams.Add(GetSQLParam("@OrderSideID", SqlDbType.Int, strTransHist.iOrderSideID))
            bSuccess = DB.Exec_SP("sp_AddTransHist", al_oParams, oConn)
            Return bSuccess
        End Function

        Friend Function GetAssetTechIndByDate(dtCurrDate As Date, Optional oConn As SqlConnection = Nothing) As DataTable
            Dim sSQL As String
            Dim oTable As DataTable

            sSQL = "SELECT * FROM tbl_AssetTechInd Where DateStamp = '" & dtCurrDate & "'"
            oTable = DB.GetDataTable_SQL(sSQL, oConn)
            Return oTable
        End Function

        Public Function GetFirstDateTechInd(Optional oConn As SqlConnection = Nothing) As DateTime
            Dim sSQL As String
            Dim oTable As DataTable
            Dim oRow As DataRow

            sSQL = "SELECT TOP 1 DateStamp FROM tbl_AssetTechInd ORDER BY DateStamp ASC"
            oTable = DB.GetDataTable_SQL(sSQL, oConn)
            If (oTable.Rows.Count = 1) Then
                oRow = oTable.Rows(0)
                Return oRow("DateStamp")
            Else
                Return Nothing
            End If
        End Function

        Public Function AddHoldingHist(sSymbol As String, dShares As Double, Optional oConn As SqlConnection = Nothing) As Boolean
            Dim bSuccess As Boolean
            Dim al_oParams As New List(Of SqlParameter)
            al_oParams.Add(GetSQLParam("@Symbol", SqlDbType.VarChar, 10, sSymbol))
            al_oParams.Add(GetSQLParam("@Shares", SqlDbType.Float, dShares))
            bSuccess = DB.Exec_SP("sp_AddHoldingHist", al_oParams, oConn)
            Return bSuccess
        End Function

        Public Function GetHoldWithPrice(Optional oConn As SqlConnection = Nothing) As DataTable
            Dim sSQL As String
            Dim oTable As DataTable

            sSQL = "Select A.Symbol, A.Price, H.Amount
            From tbl_AssetHist A
            Join tbl_HoldingsHistory H ON A.Symbol = H.Symbol
            Where H.Amount > 0 And A.HistDate = '2023-06-29'"
            oTable = DB.modDB.GetDataTable_SQL(sSQL, oConn)
            Return oTable
        End Function

        Public Function GetAllAssets(Optional oConn As SqlConnection = Nothing) As DataTable
            Dim sSQL As String

            sSQL = "Select * From tbl_Asset"
            Return DB.modDB.GetDataTable_SQL(sSQL, oConn)
        End Function

        Public Function GetPolygonAssets(Optional oConn As SqlConnection = Nothing) As DataTable
            Dim sSQL As String

            sSQL = "Select Symbol From tbl_Asset Where PolygonFlag = 'True'"
            Return DB.modDB.GetDataTable_SQL(sSQL, oConn)

        End Function

        Public Function GetLastTransaction(sSymbol As String, Optional oConn As SqlConnection = Nothing) As DataTable
            Dim oTable As DataTable
            Dim al_oParams As New List(Of SqlParameter)

            al_oParams.Add(GetSQLParam("@Symbol", SqlDbType.VarChar, 10, sSymbol))
            oTable = DB.modDB.GetDataTable_SP("sp_GetTransHist_Symbol", al_oParams, oConn)
            Return oTable
        End Function

        Friend Function GetPositionBySymbol(sSymbol As String, Optional oConn As SqlConnection = Nothing) As DataTable
            Dim sSQL As String

            sSQL = "Select * From tbl_HoldingsHistory Where Symbol = '" & sSymbol & "'"
            Return DB.modDB.GetDataTable_SQL(sSQL, oConn)
        End Function

        Friend Function UpdatePosition(sSymbol As String, dShares As Integer, Optional oConn As SqlConnection = Nothing) As Boolean
            Dim bSuccess As Boolean
            Dim al_oParams As New List(Of SqlParameter)

            al_oParams.Add(GetSQLParam("@Symbol", SqlDbType.VarChar, 10, sSymbol))
            al_oParams.Add(GetSQLParam("@Shares", SqlDbType.Float, dShares))
            bSuccess = DB.Exec_SP("sp_UpdateHoldingsHist_Symbol", al_oParams, oConn)

            Return bSuccess
        End Function
        Friend Sub MakeTransaction(strTransHist As STRUCT_TransHist, sSymbol As String, dAmount As Integer, oConn As SqlConnection)
            AddTransHist(strTransHist, oConn)
            UpdatePosition(sSymbol, dAmount, oConn)
        End Sub


        Friend Function GetAssetBySymbol(sSymbol As String, Optional oConn As SqlConnection = Nothing) As DataTable
            Dim sSQL As String

            sSQL = "Select * From tbl_Asset Where Symbol = '" & sSymbol & "'"
            Return DB.modDB.GetDataTable_SQL(sSQL, oConn)
        End Function

    End Class
End Namespace