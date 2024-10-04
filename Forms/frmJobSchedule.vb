Public Class frmJobSchedule

    Private Enum ENUM_LVCols
        eJobType = 0
        eLastJobID = 1
        eNextRunTime = 2
        eMonday = 3
        eTuesday = 4
        eWednesday = 5
        eThursday = 6
        eFriday = 7
        eSaturday = 8
        eSunday = 9
        eActiveFlag = 10
    End Enum

    Private Sub frmScheduleManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        FillJobScheduleList()
    End Sub

    Private Sub mnuAddSchedule_Click(sender As Object, e As EventArgs) Handles mnuAddSchedule.Click
        Dim frmAddSched As New frmAddSchedule(True)
        Dim dialogResult As DialogResult = frmAddSched.ShowDialog()
        If (dialogResult = DialogResult.OK) Then
            FillJobScheduleList()
        End If
    End Sub

    Private Sub mnuEditSchedule_Click(sender As Object, e As EventArgs) Handles mnuEditSchedule.Click
        Dim iJobScheduleID As Integer
        Dim oListItem As ListViewItem

        oListItem = lvSchedule.SelectedItems(0)
        iJobScheduleID = oListItem.Tag

        Dim frmEditSched As New frmAddSchedule(False, iJobScheduleID)
        Dim dialogResult As DialogResult = frmEditSched.ShowDialog()
        If (dialogResult = DialogResult.OK) Then
            FillJobScheduleList()
        End If
    End Sub

    Private Sub mnuSchedule_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mnuSchedule.Opening
        mnuEditSchedule.Enabled = (lvSchedule.SelectedItems.Count = 1)
        mnuDeleteSchedule.Enabled = (lvSchedule.SelectedItems.Count = 1)
    End Sub

    Private Sub FillJobScheduleList()
        Dim oTable As DataTable
        Dim oRow As DataRow
        Dim oSchedule As New DB.clsSchedule

        lvSchedule.Items.Clear()
        oTable = oSchedule.GetJobSchedule()
        Dim a_oListItem(oTable.Rows.Count - 1) As ListViewItem
        Dim oListItem As ListViewItem

        For iRow As Integer = 0 To oTable.DefaultView.Count - 1
            oRow = oTable.Rows(iRow)
            oListItem = GetScheduleRow(oRow)
            a_oListItem(iRow) = oListItem
        Next
        lvSchedule.Items.AddRange(a_oListItem)
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuDeleteSchedule.Click
        Dim oYesNo As DialogResult
        Dim oListItem As ListViewItem
        Dim sMSG As String

        oListItem = lvSchedule.SelectedItems(0)

        sMSG = "Are you sure you want to delete the following schedule: " & vbCrLf &
               "Schedule ID: " & oListItem.Tag & vbCrLf &
               "Job Type: " & oListItem.Text & vbCrLf &
               "Active: " & oListItem.SubItems(ENUM_LVCols.eActiveFlag).Text
        oYesNo = MessageBox.Show(sMSG, "Delete Schedule", MessageBoxButtons.YesNo)

        If oYesNo = DialogResult.Yes Then
            MessageBox.Show("You clicked Yes!")
            'Delete Schedule
        ElseIf oYesNo = DialogResult.No Then
            MessageBox.Show("Delete Canceled")
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Function GetScheduleRow(oRow As DataRow) As ListViewItem
        Dim oListItem As ListViewItem
        Dim sJobType As String

        sJobType = oRow("Job Type")
        oListItem = New ListViewItem(sJobType)
        oListItem.SubItems.Add(oRow("LastJobID"))
        oListItem.SubItems.Add(oRow("NextRunTime"))
        oListItem.SubItems.Add(CreateBoolSubItem(oRow("Monday")))
        oListItem.SubItems.Add(CreateBoolSubItem(oRow("Tuesday")))
        oListItem.SubItems.Add(CreateBoolSubItem(oRow("Wednesday")))
        oListItem.SubItems.Add(CreateBoolSubItem(oRow("Thursday")))
        oListItem.SubItems.Add(CreateBoolSubItem(oRow("Friday")))
        oListItem.SubItems.Add(CreateBoolSubItem(oRow("Saturday")))
        oListItem.SubItems.Add(CreateBoolSubItem(oRow("Sunday")))
        oListItem.SubItems.Add(CreateBoolSubItem(oRow("ActiveFlag")))
        oListItem.Tag = (oRow("JobScheduleID"))
        Return oListItem
    End Function

    Private Function CreateBoolSubItem(bStatus As Boolean) As ListViewItem.ListViewSubItem
        Dim oListItem As New ListViewItem.ListViewSubItem

        oListItem.ForeColor = If(bStatus, Color.Green, Color.Red)
        oListItem.Text = If(bStatus, "Y", "N")
        Return oListItem
    End Function
End Class