Imports Newtonsoft.Json.Linq

Namespace RestAPI
    Friend Class clsFearGreed
        'https://www.cnn.com/markets/fear-and-greed
        Private Const FEAR_GREED_URL As String = "https://production.dataviz.cnn.io/index/fearandgreed/graphdata/"
        Public Function GetFearAndGreed(dtEffDate As Date) As STRUCT_FearGreed
            Dim sURL, sJson As String
            Dim oRoot As JObject
            Dim strFearGreed As New STRUCT_FearGreed
            Dim oWebClient As New Net.WebClient()

            sURL = FEAR_GREED_URL & Format(dtEffDate, "yyyy-MM-dd")
            oWebClient.Headers.Add("Content-Type", "application/json")
            oWebClient.Headers.Add("Upgrade-Insecure-Request", "1")
            oWebClient.Headers.Add("Accept-Language", "es-ES,es;q=0.9")
            oWebClient.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9")
            oWebClient.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/109.0.0.0 Safari/537.36")
            sJson = oWebClient.DownloadString(sURL)
            oRoot = JObject.Parse(sJson)

            strFearGreed.dtEffDate = GetFearGreedValue(oRoot, "fear_and_greed", "timestamp", DEFAULT_DATE)
            strFearGreed.dScore_Today = GetFearGreedValue(oRoot, "fear_and_greed", "score", -1)
            strFearGreed.sRating_Today = GetFearGreedValue(oRoot, "fear_and_greed", "rating", "Unknown")
            strFearGreed.dScore_Yesterday = GetFearGreedValue(oRoot, "fear_and_greed", "previous_close", -1)
            strFearGreed.sRating_Yesterday = GetFGRating(strFearGreed.dScore_Yesterday)
            strFearGreed.dScore_PrevWeek = GetFearGreedValue(oRoot, "fear_and_greed", "previous_1_week", -1)
            strFearGreed.sRating_PrevWeek = GetFGRating(strFearGreed.dScore_PrevWeek)
            strFearGreed.dScore_PrevMonth = GetFearGreedValue(oRoot, "fear_and_greed", "previous_close", -1)
            strFearGreed.sRating_PrevMonth = GetFGRating(strFearGreed.dScore_PrevMonth)
            strFearGreed.dScore_PrevYear = GetFearGreedValue(oRoot, "fear_and_greed", "previous_close", -1)
            strFearGreed.sRating_PrevYear = GetFGRating(strFearGreed.dScore_PrevYear)
            strFearGreed.dScore_SP500 = GetFearGreedValue(oRoot, "market_momentum_sp500", "score", -1)
            strFearGreed.sRating_SP500 = GetFearGreedValue(oRoot, "market_momentum_sp500", "rating", "Unknown")
            strFearGreed.dScore_SP125 = GetFearGreedValue(oRoot, "market_momentum_sp125", "score", -1)
            strFearGreed.sRating_SP125 = GetFearGreedValue(oRoot, "market_momentum_sp125", "rating", "Unknown")
            strFearGreed.dScore_SPS = GetFearGreedValue(oRoot, "stock_price_strength", "score", -1)
            strFearGreed.sRating_SPS = GetFearGreedValue(oRoot, "stock_price_strength", "rating", "Unknown")
            strFearGreed.dScore_MVV = GetFearGreedValue(oRoot, "market_volatility_vix", "score", -1)
            strFearGreed.sRating_MVV = GetFearGreedValue(oRoot, "market_volatility_vix", "rating", "Unknown")
            strFearGreed.dScore_SHD = GetFearGreedValue(oRoot, "safe_haven_demand", "score", -1)
            strFearGreed.sRating_SHD = GetFearGreedValue(oRoot, "safe_haven_demand", "rating", "Unknown")

            Return strFearGreed
        End Function

        Private Function GetFearGreedValue(oRoot As JObject, sNode As String, sField As String, vReplace As Object) As Object
            Dim oNode As JObject
            Dim vValue As Object = vReplace

            oNode = oRoot(sNode)
            If (Not IsNothing(oNode)) Then
                vValue = ConvertNothing(oNode(sField), vReplace)
            End If

            If (sField = "rating") Then
                vValue = Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(vValue)
            End If

            Return vValue
        End Function

        Private Function ConvertNothing(vValue As Object, vReplace As Object) As Object
            Dim vReturn As Object

            vReturn = If(IsNothing(vValue), vReplace, vValue)

            Return vReturn
        End Function

        Private Function GetFGRating(dScore As Double) As String
            Dim sRating As String = "Unknown"

            If (dScore >= 0) Then
                If (dScore < 25) Then
                    sRating = "Extreme Fear"
                ElseIf (dScore >= 25 And dScore < 45) Then
                    sRating = "Fear"
                ElseIf (dScore >= 45 And dScore < 55) Then
                    sRating = "Neutral"
                ElseIf (dScore >= 55 And dScore < 75) Then
                    sRating = "Greed"
                ElseIf (dScore > 75) Then
                    sRating = "Extreme Greed"
                End If
            End If

            Return sRating
        End Function

        Public Function SaveFearGreed(dtEffDate As Date, strFearGreed As STRUCT_FearGreed, Optional oConn As SqlConnection = Nothing) As Boolean
            Dim oFearGreed As New DB.clsFearGreed
            Dim oTable As DataTable
            Dim oRow As DataRow

            oTable = oFearGreed.GetFearGreed_Date(dtEffDate, oConn)
            If (oTable.Rows.Count = 1) Then
                oRow = oTable.Rows(0)
                strFearGreed.iFearGreedID = oRow("FearGreedID")
                oFearGreed.UpdateFearGreed(strFearGreed, oConn)
            Else
                strFearGreed.iFearGreedID = oFearGreed.AddFearGreed(strFearGreed, oConn)
            End If
            oTable.Dispose()

            Return True
        End Function


    End Class
End Namespace