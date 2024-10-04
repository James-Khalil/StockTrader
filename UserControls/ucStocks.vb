Imports System.Windows.Forms.DataVisualization.Charting
Imports Alpaca.Markets

Public Class ucStocks
    Public Enum Enum_TimeSpan
        eMinute = 1
        eHour = 2
        eDay = 3
        eWeek = 4
        eMonth = 5
        eQuarter = 6
        eYear = 7
    End Enum

    Public Enum Enum_SeriesType
        eOpen = 1
        eHigh = 2
        eLow = 3
        eClose = 4
    End Enum

    Private m_oPrice As New Series("Price")
    Private m_oSMA As New Series("SMA")
    Private m_oEMA As New Series("EMA")
    Private m_oRSI As New Series("RSI")
    Private m_al_sSymbol As List(Of String)
    Private m_sSymbol As String
    Private m_eTimeSpan As Enum_TimeSpan
    Private m_dDate As DateTime
    Private m_oFMP As New RestAPI.clsFMP

    Public Sub InitControl()
        Dim al_oAsset As List(Of IAsset)
        Dim oAlpaca As New RestAPI.clsAlpaca

        '-- Graph --
        chrtExtras.Series.Clear()
        chrtPrice.Series.Clear()

        chrtPrice.Series.Add(m_oPrice)
        m_oPrice.ChartType = SeriesChartType.Line
        m_oPrice.Color = Color.Blue
        'm_oPrice.XValueType = ChartValueType.DateTime

        chrtPrice.Series.Add(m_oSMA)
        m_oSMA.ChartType = SeriesChartType.Line
        m_oSMA.Color = Color.Red
        'm_oSMA.XValueType = ChartValueType.DateTime

        chrtPrice.Series.Add(m_oEMA)
        m_oEMA.ChartType = SeriesChartType.Line
        m_oEMA.Color = Color.Black
        m_oEMA.XValueType = ChartValueType.DateTime

        m_oRSI.ChartType = SeriesChartType.Line
        m_oRSI.Color = Color.Green
        m_oRSI.XValueType = ChartValueType.DateTime

        '-- Search bar --
        al_oAsset = oAlpaca.GetAllAssets()
        m_al_sSymbol = New List(Of String)
        For Each oAsset In al_oAsset
            If oAsset.IsTradable Then
                m_al_sSymbol.Add(oAsset.Symbol)
            End If
        Next
        tbSearch.AutoCompleteCustomSource.AddRange(m_al_sSymbol.ToArray)
        tbSearch.AutoCompleteSource = AutoCompleteSource.CustomSource
        tbSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    End Sub

    Private Sub cboxPortPrfm_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboxPortPrfm.SelectedIndexChanged
        SetTimeFrame()
        'PopulateChart()
    End Sub

    Private Sub tbSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles tbSearch.KeyDown
        If e.KeyCode = Keys.Enter AndAlso m_al_sSymbol.Contains(tbSearch.Text.ToUpper) Then
            m_sSymbol = tbSearch.Text.ToUpper
            If Not cboxPortPrfm.SelectedIndex = Enum_TimeFrame.eDay Then
                cboxPortPrfm.SelectedIndex = Enum_TimeFrame.eDay
            Else
                SetTimeFrame()
                'PopulateChart()
            End If
            cboxPortPrfm.Enabled = True
            btnBuy.Enabled = True
        Else
            For Each series In chrtPrice.Series
                    series.Points.Clear()
                Next
                For Each series In chrtExtras.Series
                    series.Points.Clear()
                Next
            cboxPortPrfm.Enabled = False
            btnBuy.Enabled = False
        End If
    End Sub

    Private Sub SetTimeFrame()
        Dim dtStartDate As DateTime
        Dim dtEndDate As DateTime

        dtStartDate = Date.UtcNow
        dtEndDate = DateTime.UtcNow.AddMinutes(-15)

        Select Case cboxPortPrfm.SelectedIndex
            Case Enum_TimeFrame.eDay
                m_eTimeSpan = Enum_TimeSpan.eMinute
                m_dDate = dtStartDate
            Case Enum_TimeFrame.eWeek
                m_eTimeSpan = Enum_TimeSpan.eHour
                m_dDate = dtStartDate.AddDays(-7)
            Case Enum_TimeFrame.eMonth
                m_eTimeSpan = Enum_TimeSpan.eDay
                m_dDate = dtStartDate.AddMonths(-1)
            Case Enum_TimeFrame.eYear
                m_eTimeSpan = Enum_TimeSpan.eDay
                m_dDate = dtStartDate.AddYears(-1)
            Case Enum_TimeFrame.e5Year
                m_eTimeSpan = Enum_TimeSpan.eDay
                m_dDate = dtStartDate.AddYears(-5)
            Case Else
        End Select
    End Sub

    'Private Sub PopulateChart()
    '    Dim al_strBar As List(Of STRUCT_METRICS)
    '    Dim strSMA As STRUCT_TECH_IND
    '    Dim strEMA As STRUCT_TECH_IND
    '    Dim strRSI As STRUCT_TECH_IND
    '    Dim iLimit As Integer = 1000 'Maybe make constant

    '    strSMA = m_oFMP.GetTechInd(m_sSymbol, RestAPI.clsFMP.Enum_TechIndType.eSMA50)
    '    strEMA = m_oFMP.GetTechInd(m_sSymbol, RestAPI.clsFMP.Enum_TechIndType.eEMA100)
    '    strRSI = m_oFMP.GetTechInd(m_sSymbol, RestAPI.clsFMP.Enum_TechIndType.eRSI)

    '    al_strBar = m_oPolygon.GetAggregateBars(m_sSymbol, m_dDate, m_eTimeSpan, iLimit)

    '    m_oPrice.Points.Clear()
    '    For Each oPoint In al_strBar
    '        m_oPrice.Points.AddXY(oPoint.dtTimeStamp.ToString, oPoint.dTechInd)
    '    Next

    '    m_oSMA.Points.Clear()
    '    For Each oSMA In strSMA.al_Metrics
    '        m_oSMA.Points.AddXY(oSMA.dtTimeStamp.ToString, oSMA.dTechInd)
    '    Next

    '    m_oEMA.Points.Clear()
    '    For Each oEMA In strEMA.al_Metrics
    '        m_oEMA.Points.AddXY(oEMA.dtTimeStamp.ToString, oEMA.dTechInd)
    '    Next

    '    m_oRSI.Points.Clear()
    '    For Each oRSI In strRSI.al_Metrics
    '        m_oRSI.Points.AddXY(oRSI.dtTimeStamp, oRSI.dTechInd)
    '    Next
    'End Sub

    Private Sub btnBuy_Click(sender As Object, e As EventArgs) Handles btnBuy.Click
        Dim frmOrder As New frmOrder()
        frmOrder.InitControl(OrderSide.Buy, m_sSymbol)
        Dim dialogResult As DialogResult = frmOrder.ShowDialog()
    End Sub

    Public Function AddtoWatchlist() As Task(Of IWatchList)
        Dim oAlpaca As New RestAPI.clsAlpaca

        Return oAlpaca.AddtoWatchList(m_sSymbol, "Primary Watchlist")
    End Function

End Class