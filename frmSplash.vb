Imports Bottrader.DB

Public Class frmSplash
    Private Sub frmSplash_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sVersion As String()
        'Dim sSystemInfo As String

        sVersion = Split(Application.ProductVersion, ".")
        lblTitle.Text = "BotTrader " & sVersion(0)
        lblVersion.Text = "Version " & sVersion(1) & "." & sVersion(2)
        lblSQLServer.Text = "SQL Server: " & SQL_BT_SERVER
        lblTitle.Text = "BotTrader 2023"
        lblSystemDesc.Text = "AI Algo Trading Platform"
        lblWinVer.Text = "Windows 11 (64 Bit)"
        lblCopyright.Text = "Copyright © Pyramid Analytics Ltd. 2023"
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Close()
    End Sub


End Class