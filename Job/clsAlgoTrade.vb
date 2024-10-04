Imports Alpaca.Markets

Namespace Job
    Public Class clsAlgo
        Private HIST_STARTING_CASH As Double = 1000000
        Private CASH_SYMBOL As String = "TRCASH"
        Private m_oAlpaca As New RestAPI.clsAlpaca

        Public Sub LiveTrade(iJobID As Integer, iJobTypeID As Integer)
            Dim iNumThreads As Integer = g_strLookup.ht_strJobType(iJobTypeID).iNumThreads
            Dim iCurrThread, iStartIndex, iChunkSize, iSize, iChunkRem As Integer
            Dim al_oTask As New List(Of Task)
            Dim oConn As SqlConnection = DB.NewConnection
            Dim oAsset As New DB.clsAsset
            Dim oHoldingsTable As New DataTable
            Dim strTransHist As New STRUCT_TransHist
            Dim al_oAsset As List(Of IAsset)
            Try
                al_oAsset = m_oAlpaca.GetActiveAssets()
                iChunkSize = al_oAsset.Count \ iNumThreads
                iChunkRem = al_oAsset.Count - (iChunkSize * iNumThreads)
                For iCurrThread = 0 To iNumThreads - 1
                    iStartIndex = iCurrThread * iChunkSize
                    iSize = If(iCurrThread < iNumThreads - 1, iChunkSize, iChunkRem)
                    Dim al_oAssetChunk As List(Of IAsset) = al_oAsset.GetRange(iStartIndex, iSize)

                    If (g_eRunMode = ENUM_RunMode.eDebug) Then
                        AlgoTradeThread(iJobID, iCurrThread, al_oAssetChunk)
                    Else
                        Dim iNum As Integer = iCurrThread
                        al_oTask.Add(Task.Run(Sub()
                                                  AlgoTradeThread(iJobID, iCurrThread, al_oAssetChunk)
                                              End Sub))
                    End If
                Next
                Task.WaitAll(al_oTask.ToArray)
                MsgBox("Done")
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub AlgoTradeThread(iJobID As Integer, iThread As Integer, al_oAssetRow As List(Of IAsset))

            Try
                For Each oAssetRow In al_oAssetRow
                Next
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub PaperTrade(iJobID As Integer, iJobTypeID As Integer)
            Dim iNumThreads As Integer = g_strLookup.ht_strJobType(iJobTypeID).iNumThreads
            Dim iCurrThread, iStartIndex, iChunkSize, iSize, iChunkRem As Integer
            Dim al_oTask As New List(Of Task)
            Dim oConn As SqlConnection = DB.NewConnection
            Dim oAsset As New DB.clsAsset
            Dim oAssetTable, oHoldingsTable As New DataTable
            Dim oAssetRow As DataRow
            Dim dtCurrDate As Date
            Dim strTransHist As New STRUCT_TransHist
            Dim dCash, dNetChange As Double


            Try
                DB.TruncateTable("tbl_HoldingsHistory", True, oConn)
                DB.TruncateTable("tbl_TransactionHistory", True, oConn)
                oAsset.AddHoldingHist(CASH_SYMBOL, HIST_STARTING_CASH, oConn)

                'dtCurrDate = oAsset.GetFirstDateHist(oConn)
                oAssetTable = oAsset.GetAllAssets(oConn)
                For Each oAssetRow In oAssetTable.Rows
                    oAsset.AddHoldingHist(oAssetRow("Symbol"), 0, oConn)
                Next

                Do
                    'oAssetTable = oAsset.GetAssetHistByDate(dtCurrDate)
                    If (oAssetTable.Rows.Count = 0) Then
                        dtCurrDate = dtCurrDate.AddDays(1)
                        Continue Do
                    End If

                    iChunkSize = oAssetTable.Rows.Count \ iNumThreads
                    iChunkRem = oAssetTable.Rows.Count - (iChunkSize * iNumThreads)
                    dNetChange = 0
                    For iCurrThread = 0 To iNumThreads - 1
                        iStartIndex = iCurrThread * iChunkSize

                        iSize = If(iCurrThread < iNumThreads - 1, iChunkSize, iChunkRem)
                        Dim al_oAssetRow As IEnumerable(Of DataRow) = oAssetTable.Rows.Cast(Of DataRow)().Skip(iStartIndex).Take(iSize)

                        If (g_eRunMode = ENUM_RunMode.eDebug) Then
                            dNetChange += AlgoTradeHistThread(iJobID, iCurrThread, al_oAssetRow)
                        Else
                            Dim iNum As Integer = iCurrThread
                            al_oTask.Add(Task.Run(Sub()
                                                      dNetChange += AlgoTradeHistThread(iJobID, iCurrThread, al_oAssetRow)
                                                  End Sub))
                        End If
                    Next
                    Task.WaitAll(al_oTask.ToArray)
                    oAssetTable = oAsset.GetPositionBySymbol(CASH_SYMBOL, oConn)
                    oAssetRow = oAssetTable(0)
                    dCash = oAssetRow("Shares")
                    If (dCash + dNetChange < 0) Then
                        'This is the negative scenario
                    Else

                    End If

                    dCash += dNetChange
                    strTransHist.sSymbol = CASH_SYMBOL
                    strTransHist.dtTransDate = dtCurrDate
                    strTransHist.dPrice = 1
                    strTransHist.dVolume = Math.Abs(dNetChange)
                    strTransHist.iOrderSideID = If(dNetChange < 0, OrderSide.Buy, OrderSide.Sell)
                    strTransHist.iOrderTypeID = OrderType.Limit
                    oAsset.AddTransHist(strTransHist, oConn)

                    dtCurrDate = dtCurrDate.AddDays(1)
                Loop While (dtCurrDate.CompareTo(Date.Now) < 0)
                oHoldingsTable = oAsset.GetHoldWithPrice()
                'Create the view with the amount (provided it's greater than 1) and the price
                'Then for each symbol multiply price by amount and add it to cash

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Function AlgoTradeHistThread(iJobID As Integer, iThread As Integer, al_oAssetRow As IEnumerable(Of DataRow)) As Double
            Dim sSymbol As String
            Dim dHolding
            Dim oConn As SqlConnection = DB.NewConnection
            Dim oAssetRow, oHoldRow As DataRow
            Dim oHoldTable As DataTable
            Dim oAsset As New DB.clsAsset
            Dim strTransHist As New STRUCT_TransHist
            Dim dNetChange As Double = 0
            Dim oAssetScore As New TechInd.clsAssetScore

            Try
                For Each oAssetRow In al_oAssetRow

                    sSymbol = oAssetRow("Symbol")
                    oHoldTable = oAsset.GetPositionBySymbol(sSymbol, oConn)
                    If oHoldTable.Rows.Count = 1 Then
                        oHoldRow = oHoldTable.Rows(0)
                    Else
                        Continue For
                    End If
                    dHolding = oHoldRow("Shares")

                    strTransHist.sSymbol = sSymbol
                    strTransHist.dPrice = oAssetRow("Price")
                    strTransHist.dtTransDate = oAssetRow("HistDate")
                    strTransHist.iOrderTypeID = OrderType.Market
                    If (oAssetRow("SMA_200") < oAssetRow("SMA_50")) Then
                        If (dHolding = 0) Then
                            strTransHist.dVolume = Math.Ceiling(1000 / oAssetRow("Price"))
                            strTransHist.iOrderSideID = OrderSide.Buy
                            oAsset.MakeTransaction(strTransHist, sSymbol, strTransHist.dVolume, oConn)
                            dNetChange -= strTransHist.dPrice * strTransHist.dVolume
                        End If
                    ElseIf (dHolding > 0) Then
                        strTransHist.dVolume = dHolding
                        strTransHist.iOrderSideID = OrderSide.Sell
                        oAsset.MakeTransaction(strTransHist, sSymbol, 0, oConn)
                        dNetChange += strTransHist.dPrice * strTransHist.dVolume
                    End If
                Next
                Return dNetChange
            Catch ex As Exception
                Throw ex
            End Try
        End Function


    End Class
End Namespace