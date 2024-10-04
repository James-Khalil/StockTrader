Imports System.IO.Compression
Imports System.Security.Cryptography
Imports System.Text
Imports System.IO
Imports Newtonsoft.Json

Module modUtil
    Private Const ZIP_BUFFER_SIZE As Integer = 4096 '4K is the most effective way to buffer
    <Runtime.InteropServices.DllImport("user32.dll")>
    Public Function GetAsyncKeyState(key As Keys) As Short
    End Function

    Public Function FromJSON(Of StructType)(sJSON As String) As StructType
        Dim strStruct As StructType
        Dim oSettings As New JsonSerializerSettings()

        oSettings.NullValueHandling = NullValueHandling.Ignore
        strStruct = JsonConvert.DeserializeObject(Of StructType)(sJSON, oSettings)

        Return strStruct
    End Function

    Public Function ToJSON(Of StructType)(strDividend As StructType) As String
        Return JsonConvert.SerializeObject(strDividend, Formatting.None)
    End Function

    Public Function GetUniqueFileName(bUserName As Boolean, eFileType As ENUM_FileType, Optional sReportName As String = "") As String
        Dim dtCurrDate As Date = Date.Now
        Dim sUniqueName As String = ""

        If (bUserName) Then
            sUniqueName = "" 'Replace(Replace(g_strCurrUser.sLoginID, ".", ""), "-", "")
        Else
            sUniqueName = sReportName
        End If

        sUniqueName &= "_Y" & dtCurrDate.Year & "_M" & dtCurrDate.Month & "_D" & dtCurrDate.Day &
                      "_H" & dtCurrDate.Hour & "_M" & dtCurrDate.Minute & "_S" & dtCurrDate.Second &
                      "_N" & dtCurrDate.Millisecond & "_P" & Process.GetCurrentProcess.Id & "_" & GetUniqueKey(8)

        If (eFileType = ENUM_FileType.eText) Then
            sUniqueName &= ".txt"
        ElseIf (eFileType = ENUM_FileType.eSQL) Then
            sUniqueName &= ".mdf"
        ElseIf (eFileType = ENUM_FileType.eExcel) Then
            sUniqueName &= ".xls"
        ElseIf (eFileType = ENUM_FileType.eExcelx) Then
            sUniqueName &= ".xlsx"
        ElseIf (eFileType = ENUM_FileType.eExcelm) Then
            sUniqueName &= ".xlsm"
        ElseIf (eFileType = ENUM_FileType.eKML) Then
            sUniqueName &= ".kml"
        ElseIf (eFileType = ENUM_FileType.eCSV) Then
            sUniqueName &= ".csv"
        End If

        Return sUniqueName
    End Function

    Public Function ZipString(sText As String) As Byte()
        Dim oTextStream As New IO.MemoryStream
        Dim oZipStream As New IO.MemoryStream
        Dim oZipper As DeflateStream
        Dim oEncoding As New System.Text.UTF8Encoding

        Try
            Dim arrBytData() As Byte = oEncoding.GetBytes(CStr(sText))
            oTextStream.Write(arrBytData, 0, arrBytData.Length)
            oTextStream.Position = 0
            oZipper = New DeflateStream(oZipStream, CompressionMode.Compress)
            oTextStream.WriteTo(oZipper)

            oZipper.Close()
            oTextStream.Close()
            oZipStream.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return oZipStream.ToArray
    End Function

    Private Function UnzipString(a_bText As Byte()) As String
        Dim oTextStream As New IO.MemoryStream
        Dim oZipStream As New IO.MemoryStream
        Dim oZipper As DeflateStream  'GZipStream 
        Dim iNumRead As Integer = 1
        Dim a_Buffer(ZIP_BUFFER_SIZE) As Byte
        Dim sText As String = ""

        Try
            If Not (IsNothing(a_bText)) Then
                oTextStream.Write(a_bText, 0, a_bText.Length)
                oTextStream.Position = 0
                oZipper = New DeflateStream(oTextStream, CompressionMode.Decompress, False)

                While (iNumRead > 0)
                    iNumRead = oZipper.Read(a_Buffer, 0, ZIP_BUFFER_SIZE)
                    If (iNumRead > 0) Then oZipStream.Write(a_Buffer, 0, iNumRead)
                End While
                oZipStream.Position = 0
                sText = System.Text.Encoding.UTF8.GetString(oZipStream.ToArray)

                oZipper.Close()
                oZipStream.Close()
            End If
        Catch ex As Exception
            sText = ""
            MsgBox(ex.ToString)
        End Try

        Return sText
    End Function

    Public Function GetIDListString(al_iID As List(Of Integer)) As String
        Dim sIDs As String = ""
        Dim iID As Integer

        If (al_iID.Count = 0) Then
            sIDs = "0"
        Else
            For Each iID In al_iID
                sIDs &= If(sIDs.Length > 0, ", ", "") & CStr(iID)
            Next
        End If

        Return sIDs
    End Function

    Public Function GetIDListString(ht_iID As IDictionary) As String
        Dim sIDs As String = ""
        Dim iID As Integer

        If (ht_iID.Count = 0) Then
            sIDs = "0"
        Else
            For Each iID In ht_iID.Keys
                sIDs &= If(sIDs.Length > 0, ", ", "") & CStr(iID)
            Next
        End If

        Return sIDs
    End Function

    Public Function GetIDListString(hs_iID As HashSet(Of Integer)) As String
        Dim sIDs As String = ""
        Dim iID As Integer

        If (hs_iID.Count = 0) Then
            sIDs = "0"
        Else
            For Each iID In hs_iID
                sIDs &= If(sIDs.Length > 0, ", ", "") & iID
            Next
        End If

        Return sIDs
    End Function

    Public Function GetLocalAppDataPath() As String
        Dim sFolderPath As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & Application.ProductName & "\"
        If (Not Directory.Exists(sFolderPath)) Then Directory.CreateDirectory(sFolderPath)
        Return sFolderPath
    End Function


    Public Function GetUniqueKey(KeyLength As Integer) As String
        Dim a As String = "ABCDEFGHJKLMNOPQRSTUVWXYZ234567890"
        Dim chars() As Char = New Char((a.Length) - 1) {}
        Dim data() As Byte = New Byte((KeyLength) - 1) {}
        Dim crypto As RNGCryptoServiceProvider = New RNGCryptoServiceProvider
        Dim result As StringBuilder = New StringBuilder(KeyLength)

        chars = a.ToCharArray
        crypto.GetNonZeroBytes(data)
        For Each b As Byte In data
            result.Append(chars(b Mod (chars.Length - 1)))
        Next

        Return result.ToString
    End Function

    Public Function GetHashKey(iID1 As Integer, iID2 As Integer) As Integer
        Return (iID1 * 100000) + iID2
    End Function

    Public Function GetHashKey(iID1 As Integer, iID2 As Integer, iID3 As Integer) As Integer
        Return (iID1 * 1000000) + (iID2 * 1000) + iID3
    End Function

    Public Function GetHashKey(iID1 As Integer, iID2 As Integer, iID3 As Integer, iID4 As Integer) As Integer
        Return (iID1 * 10000000) + (iID2 * 100000) + (iID3 * 1000) + iID4
    End Function

    Public Function ConvertDBNull(vValue As Object, vReplace As Object) As Object
        If IsDBNull(vValue) Then
            ConvertDBNull = vReplace
        Else
            ConvertDBNull = vValue
        End If
    End Function

    Public Function ConvertNull(vValue As Object, vReplace As Object) As Object
        If IsNothing(vValue) Then
            ConvertNull = vReplace
        Else
            ConvertNull = vValue
        End If
    End Function

    Public Function GetComboBoxIndex(oCombo As ComboBox, oValue As Object) As Integer
        Dim iIndex As Integer

        For iIndex = 0 To oCombo.Items.Count - 1
            If (oCombo.Items(iIndex).ItemData = oValue) Then
                Return iIndex
            End If
        Next

        Return -1
    End Function

    Public Function GetComboBoxSelectedValue(oCombo As ComboBox) As Object
        If (oCombo.SelectedIndex >= 0) Then
            Return oCombo.SelectedItem.ItemData
        Else
            Return 0
        End If
    End Function

    Public Sub SetListViewSortIndicator(lvList As ListView, iColumn As Integer, eSortOrder As Forms.SortOrder, iAscImage As Integer, iDescImage As Integer)
        Dim iCol As Integer

        lvList.Tag = CStr(iColumn) & ";" & CStr(eSortOrder)
        For iCol = 0 To lvList.Columns.Count - 1
            If (iCol = iColumn) Then
                lvList.Columns(iCol).ImageIndex = If(eSortOrder = Forms.SortOrder.Ascending, iAscImage, iDescImage)
            Else
                lvList.Columns(iCol).ImageIndex = -1
                lvList.Columns(iCol).TextAlign = lvList.Columns(iCol).TextAlign
            End If
        Next
    End Sub

    Public Sub LogEvent(sEvent As String, eEntryType As EventLogEntryType)
        Dim oEventLog As New EventLog("Application")
        Dim sSource As String = Application.ProductName

        Try
            If EventLog.SourceExists(sSource) Then
                If sEvent.Length > Short.MaxValue Then sEvent = sEvent.Substring(0, Short.MaxValue)
                oEventLog.Source = sSource
                oEventLog.WriteEntry(sEvent, eEntryType)
            Else
                EventLog.CreateEventSource(sSource, "Application")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Function DivideWCheck(dNumerator As Double, dDenominator As Double) As Double
        If (dDenominator = 0) Then
            Return 0
        Else
            Return (dNumerator / dDenominator)
        End If
    End Function

    Public Function FormatNumberUnits(Num As Double) As String
        Dim tmp As String
        Dim UnitLabel As String

        If ((Num >= 1000000000000) Or (Num <= -1000000000000)) Then
            tmp = Format(Num / 1000000000000, "##,##0.##")
            UnitLabel = "T"
        ElseIf ((Num >= 1000000000) Or (Num <= -1000000000)) Then
            tmp = Format(Num / 1000000000, "##,##0.##")
            UnitLabel = "B"
        ElseIf ((Num >= 1000000) Or (Num <= -1000000)) Then
            tmp = Format(Num / 1000000, "##,##0.##")
            UnitLabel = "M"
        ElseIf ((Num >= 1000) Or (Num <= -1000)) Then
            tmp = Format(Num / 1000, "##,##0.##")
            UnitLabel = "K"
        Else
            tmp = FormatNumber(Num, 0)
            UnitLabel = ""
        End If
        If Right(tmp, 1) = "." Then tmp = Left(tmp, Len(tmp) - 1)

        Return (tmp & UnitLabel)
    End Function

End Module
