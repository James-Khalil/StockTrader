Public Class frmJobManager
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
        FillJobTypeCombo()
        FillJobStatusCombo()
        FillJobList()
    End Sub

    Private Sub FillJobList()
        Dim oRow As DataRow
        Dim oTable As DataTable
        Dim oJob As New DB.clsJob
        Dim iJobTypeID As Integer
        Dim iJobStatusID As Integer

        iJobTypeID = cmbJobType.SelectedValue
        iJobStatusID = cmbJobStatus.SelectedValue
        oTable = oJob.GetJob(iJobTypeID, iJobStatusID)
        lvJobs.Items.Clear()
        Dim a_oListItem(oTable.Rows.Count - 1) As ListViewItem
        Dim oListItem As ListViewItem

        For iRow As Integer = 0 To oTable.DefaultView.Count - 1
            oRow = oTable.Rows(iRow)
            oListItem = GetJobRow(oRow)
            a_oListItem(iRow) = oListItem
        Next
        lvJobs.Items.AddRange(a_oListItem)
    End Sub

    Private Function GetJobRow(oRow As DataRow) As ListViewItem
        Dim oListItem As ListViewItem
        Dim sJobType As String

        sJobType = oRow("JobID")
        oListItem = New ListViewItem(sJobType)
        oListItem.SubItems.Add(ConvertDBNull(oRow("JobType"), 0))
        oListItem.SubItems.Add(ConvertDBNull(oRow("JobStatus"), ""))
        oListItem.SubItems.Add(ConvertDBNull(oRow("JobDescription"), ""))
        oListItem.SubItems.Add(ConvertDBNull(oRow("CreateUser"), ""))
        oListItem.SubItems.Add(ConvertDBNull(oRow("CreateTime"), DEFAULT_DATE))
        oListItem.SubItems.Add(ConvertDBNull(oRow("StartTime"), DEFAULT_DATE))
        oListItem.SubItems.Add(ConvertDBNull(oRow("FinishTime"), DEFAULT_DATE))

        Return oListItem
    End Function

    Private Sub FillJobTypeCombo()
        Dim oJob As New DB.clsJob

        cmbJobType.DisplayMember = "Description"
        cmbJobType.ValueMember = "JobTypeID"
        cmbJobType.DataSource = oJob.GetJobType
        cmbJobType.SelectedValue = ENUM_JobTypeID.eRefreshAssetData
    End Sub

    Private Sub FillJobStatusCombo()
        Dim oJob As New DB.clsJob

        cmbJobStatus.DisplayMember = "Description"
        cmbJobStatus.ValueMember = "JobStatusID"
        cmbJobStatus.DataSource = oJob.GetJobStatus
        cmbJobStatus.SelectedValue = ENUM_JobStatusID.eInQueue
    End Sub

    Private Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click
        FillJobList()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub
End Class