Public Class frmAlgoSettings
    Private Sub cb100EMA_CheckedChanged(sender As Object, e As EventArgs) Handles cb100EMA.CheckedChanged

    End Sub

    Private Sub gboxAlgoSettings_Enter(sender As Object, e As EventArgs) Handles gboxAlgoSettings.Enter

    End Sub

    Private Sub frmAlgoSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        num100EMA.Value = g_strAppConst.dPrice_EMA100_Score
        cb100EMA.Checked = g_strAppConst.bPrice_EMA100_Flag

        num200EMA.Value = g_strAppConst.dPrice_EMA200_Score
        cb200EMA.Checked = g_strAppConst.bPrice_EMA200_Flag

        num100vs200EMA.Value = g_strAppConst.dEMA100_EMA200_Score
        cb100vs200EMA.Checked = g_strAppConst.bEMA100_EMA200_Flag

        num50vs200SMA.Value = g_strAppConst.dSMA50_SMA200_Score
        cb50vs200SMA.Checked = g_strAppConst.bSMA50_SMA200_Flag

        cbRSI.Checked = g_strAppConst.bRSI_Flag
        numRSI.Value = g_strAppConst.dRSI_Score

        cbSplit.Checked = g_strAppConst.bSplit_Flag
        numSplit.Value = g_strAppConst.dSplit_Score

        cbDividend.Checked = g_strAppConst.bDividend_Flag
        numDividend.Value = g_strAppConst.dDividend_Score

        cbPositiveNews.Checked = g_strAppConst.bNews_Flag
        numPositiveNews.Value = g_strAppConst.dNews_Score

        'Missing F&G
        'Missing Tech Industry (delete?)

        cbListedYear.Checked = g_strAppConst.bListedYears_Flag
        numListedYear.Value = g_strAppConst.dListedYears_Score

        cbEmployees.Checked = g_strAppConst.bNumEmp_Flag
        numEmployee.Value = g_strAppConst.dNumEmp_Score

        cbMarketCap.Checked = g_strAppConst.bMarketCap_Flag
        numMarketCap.Value = g_strAppConst.dMarketCap_Score

        cbGrossMargin.Checked = g_strAppConst.bGrossMargin_Flag
        numGrossMargin.Value = g_strAppConst.dGrossMargin_Score

        cbNetMargin.Checked = g_strAppConst.bNetMargin_Flag
        numNetMargin.Value = g_strAppConst.dNetMargin_Score

        cbROE.Checked = g_strAppConst.bROE_Flag
        numROE.Value = g_strAppConst.dROE_Score

        cbEBITDA.Checked = g_strAppConst.bROE_Flag
        numROE.Value = g_strAppConst.dROE_Score

        cbEPS.Checked = g_strAppConst.bEPSRatio_Flag
        numEPS.Value = g_strAppConst.dEPSRatio_Score

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SaveIndicators()
    End Sub

    Private Sub SaveIndicators()
        Dim oLookup As New DB.clsLookup
        ' Send values to the database

        ' EMA 100
        g_strAppConst.dPrice_EMA100_Score = num100EMA.Value
        g_strAppConst.bPrice_EMA100_Flag = cb100EMA.Checked

        ' EMA 200
        g_strAppConst.dPrice_EMA200_Score = num200EMA.Value
        g_strAppConst.bPrice_EMA200_Flag = cb200EMA.Checked

        ' 100 vs 200 EMA
        g_strAppConst.dEMA100_EMA200_Score = num100vs200EMA.Value
        g_strAppConst.bEMA100_EMA200_Flag = cb100vs200EMA.Checked

        ' 50 vs 200 SMA
        g_strAppConst.dSMA50_SMA200_Score = num50vs200SMA.Value
        g_strAppConst.bSMA50_SMA200_Flag = cb50vs200SMA.Checked

        ' RSI
        g_strAppConst.dRSI_Score = numRSI.Value
        g_strAppConst.bRSI_Flag = cbRSI.Checked

        ' Split
        g_strAppConst.dSplit_Score = numSplit.Value
        g_strAppConst.bSplit_Flag = cbSplit.Checked

        ' Dividend
        g_strAppConst.dDividend_Score = numDividend.Value
        g_strAppConst.bDividend_Flag = cbDividend.Checked

        ' Positive News
        g_strAppConst.dNews_Score = numPositiveNews.Value
        g_strAppConst.bNews_Flag = cbPositiveNews.Checked

        ' Listed Years
        g_strAppConst.dListedYears_Score = numListedYear.Value
        g_strAppConst.bListedYears_Flag = cbListedYear.Checked

        ' Number of Employees
        g_strAppConst.dNumEmp_Score = numEmployee.Value
        g_strAppConst.bNumEmp_Flag = cbEmployees.Checked

        ' Market Cap
        g_strAppConst.dMarketCap_Score = numMarketCap.Value
        g_strAppConst.bMarketCap_Flag = cbMarketCap.Checked

        ' Gross Margin
        g_strAppConst.dGrossMargin_Score = numGrossMargin.Value
        g_strAppConst.bGrossMargin_Flag = cbGrossMargin.Checked

        ' Net Margin
        g_strAppConst.dNetMargin_Score = numNetMargin.Value
        g_strAppConst.bNetMargin_Flag = cbNetMargin.Checked

        ' ROE
        g_strAppConst.dROE_Score = numROE.Value
        g_strAppConst.bROE_Flag = cbROE.Checked

        ' EBITDA
        g_strAppConst.dEBITDARatio_Score = numEBITDA.Value
        g_strAppConst.bEBITDARatio_Flag = cbEBITDA.Checked

        ' EPS Ratio
        g_strAppConst.dEPSRatio_Score = numEPS.Value
        g_strAppConst.bEPSRatio_Flag = cbEPS.Checked

        ' Additional code to save these settings to the database would go here
        ' Example: Database.SaveSettings(g_strAppConst)

        oLookup.UpdateAppConstInd(g_strAppConst)
    End Sub


    'Private Sub IndicatorChanged(oTrackBar As TrackBar, oLabel As Label)
    '    If (oTrackBar.Value > 15) Then
    '        oTrackBar.BackColor = Color.Red
    '    ElseIf (oTrackBar.Value > 7) Then
    '        oTrackBar.BackColor = Color.Green
    '    Else
    '        oTrackBar.BackColor = Control.DefaultBackColor
    '    End If
    '    oLabel.Text = oTrackBar.Value & "%"
    'End Sub

    'Private Sub tbar100EMA_Scroll(sender As Object, e As EventArgs) Handles tbar100EMA.Scroll
    '    IndicatorChanged(tbar100EMA, lbl100EMA)
    'End Sub

    'Private Sub tbar200EMA_Scroll(sender As Object, e As EventArgs) Handles tbar200EMA.Scroll
    '    IndicatorChanged(tbar200EMA, lbl200EMA)
    'End Sub

    'Private Sub tbar100vs200EMA_Scroll(sender As Object, e As EventArgs) Handles tbar100vs200EMA.Scroll
    '    IndicatorChanged(tbar100vs200EMA, lbl100vs200EMA)
    'End Sub

    'Private Sub tbarMACDvs200EMA_Scroll(sender As Object, e As EventArgs) Handles tbarMACDvs200EMA.Scroll
    '    IndicatorChanged(tbarMACDvs200EMA, lblMACDvs200EMA)
    'End Sub

    'Private Sub tbar50vs200SMA_Scroll(sender As Object, e As EventArgs) Handles tbar50vs200SMA.Scroll
    '    IndicatorChanged(tbar50vs200SMA, lbl50vs200SMA)
    'End Sub

    'Private Sub tbarRSI_Scroll(sender As Object, e As EventArgs) Handles tbarRSI.Scroll
    '    IndicatorChanged(tbarRSI, lblRSI)
    'End Sub

End Class