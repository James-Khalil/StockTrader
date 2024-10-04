Imports System.Windows.Forms.DataVisualization.Charting
Imports Alpaca.Markets

Public Class ucBacktesting
    Private m_oSeries As New Series()
    Private m_bInProgress As Boolean = False
    Public Sub InitControl()
        Dim al_oAssetHeaders As New List(Of (String, String))

        '-- Graph --
        cBoxDuration.SelectedIndex = 0
        chrtPortPrfm.Series.Add(m_oSeries)
        m_oSeries.ChartType = SeriesChartType.Spline
        m_oSeries.Color = Color.Blue

        '-- WatchList --
        al_oAssetHeaders.Add(("Symbol", "Symbol"))
        al_oAssetHeaders.Add(("Date", "TransDate"))
        al_oAssetHeaders.Add(("Order Quantity", "Volume"))
        al_oAssetHeaders.Add(("Order Value", "Price"))
        al_oAssetHeaders.Add(("Type", "OrderTypeID"))
        al_oAssetHeaders.Add(("Side", "OrderSideID"))


    End Sub

    Private Const GIGA_BYTE As Double = 1073741824
    Dim iRamGB As Long = ((My.Computer.Info.TotalPhysicalMemory - My.Computer.Info.AvailablePhysicalMemory) \ GIGA_BYTE)
    Dim iCPU As Double = GetCPUUtil()

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
