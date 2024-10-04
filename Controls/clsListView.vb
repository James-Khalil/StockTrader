
Class ListViewItemComparer
    Implements IComparer

    Public Enum ENUM_ColType
        eString = 1
        eNumeric = 2
        eDate = 3
        eImageIndex = 4
        eCheckBox = 5
    End Enum

    Private m_icol As Integer
    Private m_eType As ENUM_ColType
    Private m_eSortOrder As Forms.SortOrder

    Public Sub New()
        m_icol = 0
    End Sub

    Public Sub New(column As Integer, eType As ENUM_ColType, eSortOrder As Forms.SortOrder)
        m_icol = column
        m_eType = eType
        m_eSortOrder = eSortOrder
    End Sub

    Public Function Compare(oItem1 As Object, oItem2 As Object) As Integer Implements IComparer.Compare
        Dim sItem1 As String
        Dim sItem2 As String
        Dim lvItem1 As ListViewItem
        Dim lvItem2 As ListViewItem

        If m_eType = ENUM_ColType.eImageIndex Or m_eType = ENUM_ColType.eCheckBox Then
            If (m_eSortOrder = Forms.SortOrder.Ascending) Then
                lvItem1 = DirectCast(oItem1, ListViewItem)
                lvItem2 = DirectCast(oItem2, ListViewItem)
            Else
                lvItem1 = DirectCast(oItem2, ListViewItem)
                lvItem2 = DirectCast(oItem1, ListViewItem)
            End If

            If m_eType = ENUM_ColType.eImageIndex Then
                Return lvItem1.ImageIndex.CompareTo(lvItem2.ImageIndex)
            ElseIf m_eType = ENUM_ColType.eCheckBox Then
                Return lvItem1.Checked.CompareTo(lvItem2.Checked)
            End If
        End If

        If (m_eSortOrder = Forms.SortOrder.Ascending) Then
            sItem1 = CType(oItem1, ListViewItem).SubItems(m_icol).Text
            sItem2 = CType(oItem2, ListViewItem).SubItems(m_icol).Text
        Else
            sItem1 = CType(oItem2, ListViewItem).SubItems(m_icol).Text
            sItem2 = CType(oItem1, ListViewItem).SubItems(m_icol).Text
        End If

        If IsNumeric(sItem1) AndAlso IsNumeric(sItem2) Then
            m_eType = ENUM_ColType.eNumeric
        ElseIf IsDate(sItem1) AndAlso IsDate(sItem2) Then
            m_eType = ENUM_ColType.eDate
        Else
            m_eType = ENUM_ColType.eString
        End If

        If (m_eType = ENUM_ColType.eString) Then
            Return sItem1.CompareTo(sItem2)
        ElseIf (m_eType = ENUM_ColType.eNumeric) Then
            Return CType(sItem1, Double).CompareTo(CType(sItem2, Double))
        ElseIf (m_eType = ENUM_ColType.eDate) Then
            Return Date.Compare(Convert.ToDateTime(sItem1), Convert.ToDateTime(sItem2))
        End If
        Return 0
    End Function
End Class


Public Class clsListView

    Public Sub BoldSelection(oListView As ListView, ByRef iPrevSelected As Integer)
        Dim oListItem As ListViewItem

        'Deselect the old
        If ((iPrevSelected < oListView.Items.Count) And (iPrevSelected <> -1)) Then
            oListItem = oListView.Items(iPrevSelected)
            SetLVRowBold(oListItem, False)
        Else
            iPrevSelected = -1
        End If

        'Select the new
        If (oListView.SelectedItems.Count > 0) Then
            If (oListView.SelectedItems(0).Selected) Then
                SetLVRowBold(oListView.SelectedItems(0), True)
            End If
            iPrevSelected = oListView.SelectedItems(0).Index
        Else
            iPrevSelected = -1
        End If

        oListView.Refresh()
    End Sub

    Public Sub SetLVRowColor(oListItem As ListViewItem, oColor As Color)
        oListItem.ForeColor = oColor
        oListItem.UseItemStyleForSubItems = True
    End Sub

    Public Sub SetLVRowBold(oListItem As ListViewItem, bBold As Boolean)
        oListItem.Font = New Font(oListItem.Font, If(bBold, FontStyle.Bold, FontStyle.Regular))
        oListItem.UseItemStyleForSubItems = True
    End Sub

    Public Function FindItem(oListView As ListView, sText As String,
                              Optional bPartial As Boolean = False,
                              Optional iCol As Integer = 0) As ListViewItem
        Dim oListItem As ListViewItem
        Dim sColText As String

        sText = sText.ToUpper
        For Each oListItem In oListView.Items
            sColText = oListItem.SubItems(iCol).Text.ToUpper
            If (bPartial) Then
                If (sColText.Contains(sText)) Then
                    Return oListItem
                End If
            Else
                If (sColText.StartsWith(sText)) Then
                    Return oListItem
                End If
            End If
        Next

        Return Nothing
    End Function

    Public Function FindTag(oListView As ListView, sText As String) As ListViewItem
        Dim oListItem As ListViewItem

        For Each oListItem In oListView.Items
            If (oListItem.Tag = sText) Then
                Return oListItem
            End If
        Next

        Return Nothing
    End Function

End Class