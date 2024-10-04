Namespace Reports
    Public Class clsReports

        Public Sub SendTop50Assets(Optional oConn As SqlConnection = Nothing)
            Dim sSQL As String
            Dim sBody As String = ""
            Dim iIndex As Integer = 0
            Dim oTable As DataTable
            Dim oRow As DataRow
            Dim oEmail As New Service.clsEmail

            sSQL = "Select top 50 * From tbl_Asset Order By TotalScore Desc"
            oTable = DB.GetDataTable_SQL(sSQL)
            sBody = "<B><U>Date:</U></B> " & Date.Now.ToString("MMM dd, yyyy H:mm:ss") & "<BR>"
            sBody &= "<B><U>Disclaimer:</U></B> Scoring is based on undervalued opportunities. Research before investing!<BR><BR>"

            sBody &= "<B><U>Top 50 Pick</U></B><BR>"
            sBody &= "<Table border=""1"" cellpadding=""1"" cellspacing=""0"" style=""white-space:nowrap;"">"
            sBody &= "<TR>"
            sBody &= "<TH width=""50"" align=""middle""><NOBR>Rank</NOBR></TH>"
            sBody &= "<TH width=""100"" align=""middle""><NOBR>Score</NOBR></TH>"
            sBody &= "<TH width=""100"" width=""100"" align=""middle""><NOBR>Symbol</NOBR></TH>"
            sBody &= "<TH width=""125"" width=""85"" align=""middle""><NOBR>Exchange</NOBR></TH>"
            sBody &= "<TH width=""400"" align=""middle""><NOBR>Company</NOBR></TH>"
            sBody &= "<TH width=""400"" align=""middle""><NOBR>Industry</NOBR></TH>"
            sBody &= "<TH width=""400"" align=""middle""><NOBR>Sector</NOBR></TH>"
            sBody &= "<TH width=""150"" align=""middle""><NOBR>IPO</NOBR></TH>"
            sBody &= "<TH width=""125"" align=""middle""><NOBR>Curr</NOBR></TH>"
            sBody &= "<TH width=""150"" align=""middle""><NOBR>Price</NOBR></TH>"
            sBody &= "<TH width=""150"" align=""middle""><NOBR># Emp</NOBR></TH>"
            sBody &= "<TH width=""175"" align=""middle""><NOBR>Market Cap</NOBR></TH>"
            sBody &= "<TH width=""100"" align=""middle""><NOBR>Gross Margin</NOBR></TH>"
            sBody &= "<TH width=""100"" align=""middle""><NOBR>Net Margin</NOBR></TH>"
            sBody &= "<TH width=""100"" align=""middle""><NOBR>ROE</NOBR></TH>"
            sBody &= "<TH width=""100"" align=""middle""><NOBR>EBITDA</NOBR></TH>"
            sBody &= "<TH width=""100"" align=""middle""><NOBR>EPS</NOBR></TH>"
            sBody &= "<TH width=""100"" align=""middle""><NOBR>Score</NOBR></TH>"
            sBody &= "</TR>"

            For iIndex = 0 To oTable.Rows.Count - 1
                oRow = oTable.Rows(iIndex)
                sBody &= "<TR>"
                sBody &= "<TD align=""middle""><NOBR>" & (iIndex + 1) & "</NOBR></TD>"
                sBody &= "<TD align=""right""><NOBR>" & FormatNumber(oRow("TotalScore"), 3) & "</NOBR></TD>"
                sBody &= "<TD align=""left""><NOBR>" & oRow("Symbol") & "</NOBR></TD>"
                sBody &= "<TD align=""left""><NOBR>" & oRow("Exchange") & "</NOBR></TD>"
                sBody &= "<TD align=""left""><NOBR>" & oRow("CompanyName") & "</NOBR></TD>"
                sBody &= "<TD align=""left""><NOBR>" & oRow("Industry") & "</NOBR></TD>"
                sBody &= "<TD align=""left""><NOBR>" & oRow("Sector") & "</NOBR></TD>"
                sBody &= "<TD align=""right""><NOBR>" & GetIPOLength(oRow("IPODate")) & "</NOBR></TD>"
                sBody &= "<TD align=""middle""><NOBR>" & oRow("CurrencyCode") & "</NOBR></TD>"
                sBody &= "<TD align=""right""><NOBR>" & FormatNumber(oRow("Price"), 2) & "</NOBR></TD>"
                sBody &= "<TD align=""right""><NOBR>" & FormatNumberUnits(oRow("NumEmployees")) & "</NOBR></TD>"
                sBody &= "<TD align=""right""><NOBR>" & FormatNumberUnits(oRow("MarketCap")) & "</NOBR></TD>"
                sBody &= "<TD align=""right""><NOBR>" & FormatPercent(oRow("AvgGrossMargin"), 2) & "</NOBR></TD>"
                sBody &= "<TD align=""right""><NOBR>" & FormatPercent(oRow("AvgNetMargin"), 2) & "</NOBR></TD>"
                sBody &= "<TD align=""right""><NOBR>" & FormatPercent(oRow("AvgROE"), 2) & "</NOBR></TD>"
                sBody &= "<TD align=""right""><NOBR>" & FormatPercent(oRow("AvgEBITDARatio"), 2) & "</NOBR></TD>"
                sBody &= "<TD align=""right""><NOBR>" & FormatPercent(oRow("EPSRatio"), 2) & "</NOBR></TD>"
                sBody &= "<TD align=""right""><NOBR>" & FormatNumber(oRow("TotalScore"), 3) & "</NOBR></TD>"
                sBody &= "</TR>"
            Next
            sBody &= "</TABLE>"
            sBody &= "<BR><BR>"
            sBody &= GetMarketSentimentTable(oConn)

            oEmail.SendReport(ENUM_ReportID.eTop50Assets, "Top 50 Assets", sBody, True, Net.Mail.MailPriority.Normal)

            oTable.Dispose()
        End Sub

        Private Function GetIPOLength(dtIPODate As Date) As String
            Dim dNumMonths, dIPOLength As Double
            Dim sIPOLength As String

            dNumMonths = DateDiff(DateInterval.Month, dtIPODate, Now)
            dIPOLength = dNumMonths / 12.0
            sIPOLength = FormatNumber(dIPOLength, If(dIPOLength >= 10, 0, 1)) & "Y"

            Return sIPOLength
        End Function

        Private Function GetMarketSentimentTable(Optional oConn As SqlConnection = Nothing) As String
            Dim sTable As String = ""
            Dim oFearGreed As New DB.clsFearGreed
            Dim oTable As DataTable
            Dim oRow As DataRow

            oTable = oFearGreed.GetLatestFearGreed(oConn)
            If (oTable.Rows.Count = 1) Then
                oRow = oTable.Rows(0)

                sTable = "<Table border=""1"" cellpadding=""1"" cellspacing=""0"">"
                sTable &= "<TR>"
                sTable &= "<TH width=""150"" align=""middle""><NOBR>Market</NOBR></TH>"
                sTable &= "<TH width=""125"" align=""middle""><NOBR>Score (0-100)</NOBR></TH>"
                sTable &= "<TH width=""150"" align=""middle""><NOBR>Sentiment</NOBR></TH>"
                sTable &= "</TR>"

                sTable &= GetSentimentRow(oRow, "Today", "Today")
                sTable &= GetSentimentRow(oRow, "Yesterday", "Yesterday")
                sTable &= GetSentimentRow(oRow, "Prev. Week", "PrevWeek")
                sTable &= GetSentimentRow(oRow, "Prev. Month", "PrevMonth")
                sTable &= GetSentimentRow(oRow, "Prev. Year", "PrevYear")
                sTable &= GetSentimentRow(oRow, "S&P 500", "SP500")
                sTable &= GetSentimentRow(oRow, "S&P 125", "SP125")
                sTable &= GetSentimentRow(oRow, "Price Strength", "SPS")
                sTable &= GetSentimentRow(oRow, "Market Volatility", "MVV")
                sTable &= GetSentimentRow(oRow, "Safe Heaven", "SHD")

                sTable &= "</TABLE>"
                sTable &= "<BR><BR>"
            End If
            Return sTable
        End Function

        Private Function GetSentimentRow(oRow As DataRow, sTitle As String, sFieldSffix As String) As String
            Dim sRow As String = ""
            Dim dScore As Double = oRow("Score" & "_" & sFieldSffix)
            Dim sRating As String = oRow("Rating" & "_" & sFieldSffix)


            sRow &= "<TR>"
            sRow &= "<TD align=""left""><NOBR>" & sTitle & "</NOBR></TD>"
            sRow &= "<TD align=""right""><NOBR>" & FormatNumber(dScore, 2) & "</NOBR></TD>"
            sRow &= "<TD align=""middle""><NOBR>" & sRating & "</NOBR></TD>"
            sRow &= "</TR>"

            Return sRow
        End Function



    End Class
End Namespace
