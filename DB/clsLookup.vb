Namespace DB
    Friend Class clsLookup
        Public Function GetAppSecurity()
            Dim oDataTable As DataTable
            Dim sSQL As String

            sSQL = "Select * from tbl_Security"
            oDataTable = GetDataTable_SQL(sSQL)
            Return oDataTable
        End Function

        Public Function LoadAppConst() As STRUCT_AppConst
            Dim strAppConst As New STRUCT_AppConst
            Dim oTable As DataTable
            Dim oRow As DataRow
            Dim sSQL, sError As String

            sSQL = "Select * from tbl_AppConst"
            oTable = GetDataTable_SQL(sSQL)

            If (oTable.Rows.Count = 1) Then
                oRow = oTable.Rows(0)
                With strAppConst
                    .iAppConstID = oRow("AppConstID")
                    .sBaseCurrency = oRow("BaseCurrency")
                    .bPrice_EMA100_Flag = oRow("Price_EMA100_Flag")
                    .dPrice_EMA100_Score = oRow("Price_EMA100_Score")
                    .bPrice_EMA200_Flag = oRow("Price_EMA200_Flag")
                    .dPrice_EMA200_Score = oRow("Price_EMA200_Score")
                    .bSMA50_SMA200_Flag = oRow("SMA50_SMA200_Flag")
                    .dSMA50_SMA200_Score = oRow("SMA50_SMA200_Score")
                    .bEMA100_EMA200_Flag = oRow("EMA100_EMA200_Flag")
                    .dEMA100_EMA200_Score = oRow("EMA100_EMA200_Score")
                    .bRSI_Flag = oRow("RSI_Flag")
                    .dRSI_Score = oRow("RSI_Score")
                    .bSplit_Flag = oRow("Split_Flag")
                    .dSplit_Score = oRow("Split_Score")
                    .bDividend_Flag = oRow("Dividend_Flag")
                    .dDividend_Score = oRow("Dividend_Score")
                    .bNews_Flag = oRow("News_Flag")
                    .dNews_Score = oRow("News_Score")
                    .bAnalyst_Flag = oRow("Analyst_Flag")
                    .dAnalyst_Score = oRow("Analyst_Score")
                    .bListedYears_Flag = oRow("ListedYears_Flag")
                    .dListedYears_Score = oRow("ListedYears_Score")
                    .bNumEmp_Flag = oRow("NumEmp_Flag")
                    .dNumEmp_Score = oRow("NumEmp_Score")
                    .bMarketCap_Flag = oRow("MarketCap_Flag")
                    .dMarketCap_Score = oRow("MarketCap_Score")
                    .bGrossMargin_Flag = oRow("GrossMargin_Flag")
                    .dGrossMargin_Score = oRow("GrossMargin_Score")
                    .bNetMargin_Flag = oRow("NetMargin_Flag")
                    .dNetMargin_Score = oRow("NetMargin_Score")
                    .bROE_Flag = oRow("ROE_Flag")
                    .dROE_Score = oRow("ROE_Score")
                    .bEBITDARatio_Flag = oRow("EBITDARatio_Flag")
                    .dEBITDARatio_Score = oRow("EBITDARatio_Score")
                    .bEPSRatio_Flag = oRow("EPSRatio_Flag")
                    .dEPSRatio_Score = oRow("EPSRatio_Score")
                End With
            Else
                sError = "Error, AppConst does not have exactly one record"
                If (g_bServiceMode) Then Throw New Exception(sError) Else MsgBox(sError)
            End If
            oTable.Dispose()
            Return strAppConst
        End Function

        Public Function UpdateAppConstInd(strAppConst As STRUCT_AppConst) As Boolean
            Dim al_oParams As New List(Of SqlParameter)
            Dim bSuccess As Boolean

            With al_oParams
                .Add(GetSQLParam("@AppConstID", SqlDbType.Int, strAppConst.iAppConstID))
                .Add(GetSQLParam("@BaseCurrency", SqlDbType.VarChar, 3, strAppConst.sBaseCurrency))
                .Add(GetSQLParam("@Price_EMA100_Flag", SqlDbType.Bit, strAppConst.bPrice_EMA100_Flag))
                .Add(GetSQLParam("@Price_EMA100_Score", SqlDbType.Float, strAppConst.dPrice_EMA100_Score))
                .Add(GetSQLParam("@Price_EMA200_Flag", SqlDbType.Bit, strAppConst.bPrice_EMA200_Flag))
                .Add(GetSQLParam("@Price_EMA200_Score", SqlDbType.Float, strAppConst.dPrice_EMA200_Score))
                .Add(GetSQLParam("@SMA50_SMA200_Flag", SqlDbType.Bit, strAppConst.bSMA50_SMA200_Flag))
                .Add(GetSQLParam("@SMA50_SMA200_Score", SqlDbType.Float, strAppConst.dSMA50_SMA200_Score))
                .Add(GetSQLParam("@EMA100_EMA200_Flag", SqlDbType.Bit, strAppConst.bEMA100_EMA200_Flag))
                .Add(GetSQLParam("@EMA100_EMA200_Score", SqlDbType.Float, strAppConst.dEMA100_EMA200_Score))
                .Add(GetSQLParam("@RSI_Flag", SqlDbType.Bit, strAppConst.bRSI_Flag))
                .Add(GetSQLParam("@RSI_Score", SqlDbType.Float, strAppConst.dRSI_Score))
                .Add(GetSQLParam("@Split_Flag", SqlDbType.Bit, strAppConst.bSplit_Flag))
                .Add(GetSQLParam("@Split_Score", SqlDbType.Float, strAppConst.dSplit_Score))
                .Add(GetSQLParam("@Dividend_Flag", SqlDbType.Bit, strAppConst.bDividend_Flag))
                .Add(GetSQLParam("@Dividend_Score", SqlDbType.Float, strAppConst.dDividend_Score))
                .Add(GetSQLParam("@News_Flag", SqlDbType.Bit, strAppConst.bNews_Flag))
                .Add(GetSQLParam("@News_Score", SqlDbType.Float, strAppConst.dNews_Score))
                .Add(GetSQLParam("@Analyst_Flag", SqlDbType.Bit, strAppConst.bAnalyst_Flag))
                .Add(GetSQLParam("@Analyst_Score", SqlDbType.Float, strAppConst.dAnalyst_Score))
                .Add(GetSQLParam("@ListedYears_Flag", SqlDbType.Bit, strAppConst.bListedYears_Flag))
                .Add(GetSQLParam("@ListedYears_Score", SqlDbType.Float, strAppConst.dListedYears_Score))
                .Add(GetSQLParam("@NumEmp_Flag", SqlDbType.Bit, strAppConst.bNumEmp_Flag))
                .Add(GetSQLParam("@NumEmp_Score", SqlDbType.Float, strAppConst.dNumEmp_Score))
                .Add(GetSQLParam("@MarketCap_Flag", SqlDbType.Bit, strAppConst.bMarketCap_Flag))
                .Add(GetSQLParam("@MarketCap_Score", SqlDbType.Float, strAppConst.dMarketCap_Score))
                .Add(GetSQLParam("@GrossMargin_Flag", SqlDbType.Bit, strAppConst.bGrossMargin_Flag))
                .Add(GetSQLParam("@GrossMargin_Score", SqlDbType.Float, strAppConst.dGrossMargin_Score))
                .Add(GetSQLParam("@NetMargin_Flag", SqlDbType.Bit, strAppConst.bNetMargin_Flag))
                .Add(GetSQLParam("@NetMargin_Score", SqlDbType.Float, strAppConst.dNetMargin_Score))
                .Add(GetSQLParam("@ROE_Flag", SqlDbType.Bit, strAppConst.bROE_Flag))
                .Add(GetSQLParam("@ROE_Score", SqlDbType.Float, strAppConst.dROE_Score))
                .Add(GetSQLParam("@EBITDARatio_Flag", SqlDbType.Bit, strAppConst.bEBITDARatio_Flag))
                .Add(GetSQLParam("@EBITDARatio_Score", SqlDbType.Float, strAppConst.dEBITDARatio_Score))
                .Add(GetSQLParam("@EPSRatio_Flag", SqlDbType.Bit, strAppConst.bEPSRatio_Flag))
                .Add(GetSQLParam("@EPSRatio_Score", SqlDbType.Float, strAppConst.dEPSRatio_Score))
            End With

            bSuccess = DB.Exec_SP("sp_UpdateAppConst", al_oParams)
            Return bSuccess
        End Function

    End Class
End Namespace
