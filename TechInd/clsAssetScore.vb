Namespace TechInd
    Public Class clsAssetScore

        Friend Sub CalcAssetScore(ByRef strAsset As STRUCT_Asset)
            strAsset.dTechScore = CalcTechScore(strAsset)
            strAsset.dSoftScore = CalcSoftScore(strAsset)
            strAsset.dFinScore = CalcFinScore(strAsset)
            strAsset.dTotalScore = strAsset.dTechScore + strAsset.dSoftScore + strAsset.dFinScore
        End Sub

        Friend Function CalcTechScore(strAsset As STRUCT_Asset) As Double
            Dim dScore As Double = 0

            With strAsset
                If (g_strAppConst.bPrice_EMA100_Flag) Then
                    dScore += CalcTechIndScore(.dPrice, .dEMA100, g_strAppConst.dPrice_EMA100_Score)
                End If

                If (g_strAppConst.bPrice_EMA200_Flag) Then
                    dScore += CalcTechIndScore(.dPrice, .dEMA200, g_strAppConst.dPrice_EMA200_Score)
                End If

                If (g_strAppConst.bEMA100_EMA200_Flag) Then
                    dScore += CalcTechIndScore(.dEMA100, .dEMA200, g_strAppConst.dEMA100_EMA200_Score)
                End If

                If (g_strAppConst.bSMA50_SMA200_Flag) Then
                    dScore += CalcTechIndScore(.dSMA50, .dSMA200, g_strAppConst.dSMA50_SMA200_Score)
                End If

                If (g_strAppConst.bRSI_Flag) Then
                    dScore += CalcRSIScore(.dRSI, g_strAppConst.dRSI_Score)
                End If
            End With

            Return dScore
        End Function

        Private Function CalcTechIndScore(dTechInd1 As Double, dTechInd2 As Double, dTechIndScore As Double) As Double
            Dim dRatio, dScore As Double

            If (dTechInd1 <= 0) OrElse (dTechInd2 <= 0) Then
                dRatio = -1
            Else
                dRatio = (dTechInd2 - dTechInd1) / dTechInd2
            End If
            dScore += dTechIndScore * CapRatio(dRatio)

            Return dScore
        End Function

        Private Function CalcRSIScore(dRSI As Double, dTechIndScore As Double) As Double
            Dim dRatio, dScore As Double

            If (dRSI < 0) Then
                dRatio = -1
            Else
                dRatio = (30 - dRSI) / 30
            End If
            dScore += dTechIndScore * CapRatio(dRatio)

            Return dScore
        End Function


        Friend Function CalcSoftScore(strAsset As STRUCT_Asset) As Double
            Dim dScore As Double = 0

            If (g_strAppConst.bSplit_Flag) Then
                dScore += g_strAppConst.dSplit_Score * CapRatio(strAsset.dSplitFactor)
            End If

            If (g_strAppConst.bDividend_Flag) Then
                dScore += g_strAppConst.dDividend_Score * CapRatio(strAsset.dDividendFactor)
            End If

            If (g_strAppConst.bAnalyst_Flag) Then
                dScore += g_strAppConst.dAnalyst_Score * CapRatio(strAsset.dAnalystFactor)
            End If

            'News needs to be evaluated by AI, so it's currently disabled
            If (g_strAppConst.bNews_Flag) Then
                dScore += g_strAppConst.dNews_Score * CapRatio(strAsset.dNewsFactor)
            End If

            Return dScore
        End Function

        Friend Function CalcFinScore(strAsset As STRUCT_Asset) As Double
            Dim dScore As Double = 0
            Dim dRatio As Double
            Dim iNumMonths As Integer

            If (g_strAppConst.bListedYears_Flag) Then
                iNumMonths = DateDiff(DateInterval.Month, strAsset.dtIPODate, Now)
                dRatio = (iNumMonths / 300) '25 years = 300 months
                dScore += g_strAppConst.dListedYears_Score * CapRatio(dRatio)
            End If

            If (g_strAppConst.bNumEmp_Flag) Then
                dRatio = (strAsset.iNumEmployees / 10000)
                dScore += g_strAppConst.dNumEmp_Score * CapRatio(dRatio)
            End If

            If (g_strAppConst.bMarketCap_Flag) Then
                dRatio = (strAsset.dMarketCap / 10000000000)
                dScore += g_strAppConst.dMarketCap_Score * CapRatio(dRatio)
            End If

            If (g_strAppConst.bGrossMargin_Flag) Then
                'GrossProfit/Revenue
                dRatio = strAsset.dAvgGrossMargin 
                dScore += g_strAppConst.dGrossMargin_Score * CapRatio(dRatio)
            End If

            If (g_strAppConst.bNetMargin_Flag) Then
                'NetIncome/Profit
                dRatio = strAsset.dAvgNetMargin
                dScore += g_strAppConst.dNetMargin_Score * CapRatio(dRatio)
            End If

            If (g_strAppConst.bROE_Flag) Then
                'NetIncome/Equity
                dRatio = strAsset.dAvgROE
                dScore += g_strAppConst.dROE_Score * CapRatio(dRatio)
            End If

            If (g_strAppConst.bEBITDARatio_Flag) Then
                'EBITDA = Earnings Before Interest, Taxes, Depreciation, and Amortization
                'EBITDA/Revenue
                dRatio = strAsset.dAvgEBITDARatio
                dScore += g_strAppConst.dEBITDARatio_Score * CapRatio(dRatio)
            End If

            If (g_strAppConst.bEPSRatio_Flag) Then
                'EPS/Price
                dRatio = strAsset.dEPSRatio
                dScore += g_strAppConst.dEPSRatio_Score * CapRatio(dRatio)
            End If

            If (g_strAppConst.bDCFRatio_Flag) Then
                'EPS/Price
                dRatio = strAsset.dCashFlowRatio / MAX_RATIO
                dScore += g_strAppConst.dDCFRatio_Score * CapRatio(dRatio)
            End If

            Return dScore
        End Function

        Private Function CapRatio(dRatio As Double) As Double
            Dim dCapRatio As Double

            dCapRatio = Math.Max(Math.Min(dRatio, 1), -1)

            Return dCapRatio
        End Function

    End Class
End Namespace