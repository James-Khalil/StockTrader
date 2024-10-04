Imports Alpaca.Markets

Namespace TechInd
    Public Class clsTechInd

        Public Structure STRUCT_PatT
            Dim dtTimeUTC As Date
            Dim dPrice As Double 'Can represent open, close, high, or low (depends on desire)
        End Structure

        Public Function GetPointValueFromIBar(al_oBar As IReadOnlyList(Of IBar)) As List(Of STRUCT_PatT)
            Dim al_strPointVal As New List(Of STRUCT_PatT)

            For Each oBar In al_oBar
                al_strPointVal.Add(New STRUCT_PatT With {
                           .dPrice = oBar.Close, 'We can decide what price to use here
                           .dtTimeUTC = oBar.TimeUtc
                           })
            Next
            Return al_strPointVal
        End Function

        Public Function FindSMA(al_strBar As List(Of STRUCT_PatT), iPeriod As Integer) As List(Of STRUCT_PatT)
            Dim dSum As Double
            Dim al_strPointValue As New List(Of STRUCT_PatT)
            Dim dSMA As Double

            If iPeriod > al_strBar.Count Then
                Return New List(Of STRUCT_PatT)
            End If

            For iStart = 0 To iPeriod - 1
                dSum += al_strBar(iStart).dPrice 'We can decide what price to use here
            Next
            dSMA = dSum / iPeriod
            al_strPointValue.Add(New STRUCT_PatT With {
                           .dPrice = dSMA,
                           .dtTimeUTC = al_strBar(iPeriod - 1).dtTimeUTC
                           })

            For iStart = iPeriod To al_strBar.Count - 1
                dSum -= al_strBar(iStart - iPeriod).dPrice
                dSum += al_strBar(iStart).dPrice
                dSMA = dSum / iPeriod
                al_strPointValue.Add(New STRUCT_PatT With {
                   .dPrice = dSMA,
                   .dtTimeUTC = al_strBar(iStart).dtTimeUTC
                   })
            Next
            Return al_strPointValue
        End Function

        Public Function FindEMA(al_strBar As List(Of STRUCT_PatT), iPeriod As Integer) As List(Of STRUCT_PatT)
            Dim dSum As Double
            Dim al_strPointValue As New List(Of STRUCT_PatT)
            Dim dEMA As Double
            Dim dMultiplier As Double = 2 / (iPeriod + 1)

            If iPeriod > al_strBar.Count Then
                Return New List(Of STRUCT_PatT)
            End If

            For iStart = 0 To iPeriod - 1
                dSum += al_strBar(iStart).dPrice
            Next
            dEMA = dSum / iPeriod

            For iStart = iPeriod To al_strBar.Count - 1
                dEMA = al_strBar(iStart).dPrice * dMultiplier + dEMA * (1 - dMultiplier)
                al_strPointValue.Add(New STRUCT_PatT With {
           .dPrice = dEMA,
           .dtTimeUTC = al_strBar(iStart).dtTimeUTC
           })
            Next
            Return al_strPointValue
        End Function


        Public Function FindMACD(al_strBar As List(Of STRUCT_PatT), iShortPeriod As Double, iLongPeriod As Double) As List(Of STRUCT_PatT)
            Dim al_strShortTerm As List(Of STRUCT_PatT)
            Dim al_strLongTerm As List(Of STRUCT_PatT)
            Dim al_strMACD As New List(Of STRUCT_PatT)
            Dim dDifference As Double
            Dim dShortTerm As Double
            Dim dLongTerm As Double

            al_strShortTerm = FindEMA(al_strBar, iShortPeriod)
            al_strLongTerm = FindEMA(al_strBar, iLongPeriod)

            For i = al_strLongTerm.Count - 1 To 0 Step -1
                dShortTerm = al_strShortTerm(i + 14).dPrice
                dLongTerm = al_strLongTerm(i).dPrice
                dDifference = dShortTerm - dLongTerm

                al_strMACD.Add(New STRUCT_PatT With {
                .dPrice = dDifference,
                .dtTimeUTC = al_strLongTerm(i).dtTimeUTC
            })
            Next
            al_strMACD.Reverse()
            Return al_strMACD
        End Function

        Public Function FindSignalLine(al_oMACD As List(Of STRUCT_PatT)) As List(Of STRUCT_PatT)
            Dim al_strSignal As List(Of STRUCT_PatT)

            al_strSignal = FindEMA(al_oMACD, 9)

            Return al_strSignal
        End Function

        Public Function FindRSI(al_strBar As List(Of STRUCT_PatT), iPeriod As Integer) As List(Of STRUCT_PatT)
            Dim dSumGain As Double
            Dim dSumLoss As Double
            Dim dChange As Double
            Dim dPrevChange As Double
            Dim dAvgGain As Double
            Dim dAvgLoss As Double
            Dim dRS As Double
            Dim dRSI As Double
            Dim al_strRSI As New List(Of STRUCT_PatT)

            If iPeriod > al_strBar.Count Then
                Return New List(Of STRUCT_PatT)
            End If

            For iStart = 1 To iPeriod
                dChange = al_strBar(iStart).dPrice - al_strBar(iStart - 1).dPrice
                If dChange >= 0 Then
                    dSumGain += dChange
                Else
                    dSumLoss -= dChange
                End If
            Next

            If dSumLoss = 0 Then
                dRSI = 100
            ElseIf dSumGain = 0 Then
                dRSI = 0
            Else
                dAvgGain = dSumGain / iPeriod
                dAvgLoss = dSumLoss / iPeriod
                dRS = dAvgGain / dAvgLoss
                dRSI = 100 - (100 / (1 + dRS))
            End If
            al_strRSI.Add(New STRUCT_PatT With {
                           .dPrice = dRSI,
                           .dtTimeUTC = al_strBar(iPeriod - 1).dtTimeUTC
                           })

            For iStart = iPeriod + 1 To al_strBar.Count - 1
                dChange = al_strBar(iStart).dPrice - al_strBar(iStart - 1).dPrice
                dPrevChange = al_strBar(iStart - iPeriod).dPrice - al_strBar(iStart - iPeriod - 1).dPrice
                If dChange >= 0 Then
                    dSumGain += dChange
                Else
                    dSumLoss -= dChange
                End If
                If dPrevChange >= 0 Then
                    dSumGain -= dPrevChange
                Else
                    dSumLoss += dPrevChange
                End If
                If dSumLoss = 0 Then
                    dRSI = 100
                ElseIf dSumGain = 0 Then
                    dRSI = 0
                Else
                    dAvgGain = dSumGain / iPeriod
                    dAvgLoss = dSumLoss / iPeriod
                    dRS = dAvgGain / dAvgLoss
                    dRSI = 100 - (100 / (1 + dRS))
                End If
                al_strRSI.Add(New STRUCT_PatT With {
                           .dPrice = dRSI,
                           .dtTimeUTC = al_strBar(iStart).dtTimeUTC
                           })
            Next

            Return al_strRSI
        End Function

        Public Function FindVar(al_Avg As List(Of STRUCT_PatT)) As List(Of STRUCT_PatT)
            Return Nothing
        End Function

        Public Function FindSTD(al_Var As List(Of STRUCT_PatT)) As List(Of STRUCT_PatT)
            Return Nothing
        End Function

        Function FindBB(al_STD As List(Of STRUCT_PatT)) As List(Of STRUCT_PatT) 'data As Object, windowSize As Integer, numStd As Double) As Object
            Return Nothing
        End Function
        Public Function StandardDeviation(data As Double(), mean As Double) As Double
            Dim sumDeviation As Double = 0.0
            Dim dataSize As Integer = data.Length

            For i As Integer = 0 To dataSize - 1
                sumDeviation += (data(i) - mean) * (data(i) - mean)
            Next

            Return Math.Sqrt(sumDeviation / dataSize)
        End Function

    End Class
End Namespace
