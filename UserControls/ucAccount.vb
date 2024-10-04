Imports System.Windows.Forms.DataVisualization.Charting
Imports Alpaca.Markets
Public Class ucAccount
    Private m_oSeries As New Series()
    Private m_oAlpaca As New RestAPI.clsAlpaca

    Public Sub InitControl()
        Dim oAccount As IAccount


        '-- Account Information --
        oAccount = m_oAlpaca.GetAccount
        txtAcctNum.Text = oAccount.AccountNumber
        txtAcctName.Text = "Ihab Khalil" 'Temp
        txtBuyPwr.Text = FormatCurrency(oAccount.BuyingPower, 0)
        txtCash.Text = FormatCurrency(oAccount.TradableCash, 0)
        txtEqty.Text = FormatCurrency(oAccount.Equity, 0)

        '-- Graph --
        cboxPortPrfm.SelectedIndex = 0
        chrtPortPrfm.Series.Add(m_oSeries)
        m_oSeries.ChartType = SeriesChartType.Spline
        m_oSeries.Color = Color.Blue
    End Sub

    Private Sub cboxPortPrfm_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboxPortPrfm.SelectedIndexChanged
        Dim oPortfolioHistory As IPortfolioHistory

        oPortfolioHistory = m_oAlpaca.GetPortfolioHistory(cboxPortPrfm.SelectedIndex)
        m_oSeries.Points.Clear()
        For Each point In oPortfolioHistory.Items
            m_oSeries.Points.AddXY(point.TimestampUtc.ToString, point.ProfitLoss)
        Next
    End Sub

    Private Const GIGA_BYTE As Double = 1073741824
    Dim iRamGB As Long = ((My.Computer.Info.TotalPhysicalMemory - My.Computer.Info.AvailablePhysicalMemory) \ GIGA_BYTE)
    'Dim iCPU As Double = GetCPUUtil()

    Public Function GetCPUUtil() As Double
        Dim oPerformanceCounter As New PerformanceCounter("Processor", "% Processor Time", "_Total")
        Dim iCPU As Double
        Dim oCS1, oCS2 As CounterSample

        oCS1 = oPerformanceCounter.NextSample
        System.Threading.Thread.Sleep(200)
        oCS2 = oPerformanceCounter.NextSample
        iCPU = CounterSample.Calculate(oCS1, oCS2) / 100
        Return iCPU

    End Function




End Class
