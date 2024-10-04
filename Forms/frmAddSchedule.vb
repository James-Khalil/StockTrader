Public Class frmAddSchedule

    Dim m_bAdd As Boolean
    Dim m_iJobScheduleID As Integer

    Private Enum Enum_Days
        eMonday = 0
        eTuesday = 1
        eWednesday = 2
        eThursday = 3
        eFriday = 4
        eSaturday = 5
        eSunday = 6
    End Enum

    Public Sub New(bAdd As Boolean, Optional iJobScheduleID As Integer = 0)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        m_bAdd = bAdd
        m_iJobScheduleID = iJobScheduleID

    End Sub

    Private Sub btnSaveClick(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim oSchedule As New DB.clsSchedule
        Dim bMonday As Boolean = lstDays.GetItemChecked(0)
        Dim bTuesday As Boolean = lstDays.GetItemChecked(1)
        Dim bWednesday As Boolean = lstDays.GetItemChecked(2)
        Dim bThursday As Boolean = lstDays.GetItemChecked(3)
        Dim bFriday As Boolean = lstDays.GetItemChecked(4)
        Dim bSaturday As Boolean = lstDays.GetItemChecked(5)
        Dim bSunday As Boolean = lstDays.GetItemChecked(6)
        Dim dtNextRunTime As DateTime

        dtNextRunTime = DateTime.Today.AddDays(1) + dtScheduleTime.Value.TimeOfDay
        If (m_bAdd) Then
            oSchedule.AddJobSchedule(cmbJobType.SelectedIndex + 1, bMonday, bTuesday, bWednesday, bThursday, bFriday, bSaturday, bSunday,
                            dtScheduleTime.Value.TimeOfDay, dtNextRunTime, True)
        Else
            oSchedule.UpdateJobScheduleByID(cmbJobType.SelectedIndex + 1, bMonday, bTuesday, bWednesday, bThursday, bFriday, bSaturday, bSunday,
                            dtScheduleTime.Value.TimeOfDay, dtNextRunTime, True)
        End If
        Close()
    End Sub

    Private Sub frmAddSchedule_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim oSchedule As New DB.clsSchedule
        Dim oTable As DataTable
        Dim oRow As DataRow

        FillJobTypeCombo()

        If (m_bAdd) Then
            chkActive.Checked = True
            dtScheduleTime.Value = DateTime.Now
        Else
            oTable = oSchedule.GetJobScheduleByID(m_iJobScheduleID)
            If (oTable.Rows.Count = 1) Then
                oRow = oTable.Rows(0)
                cmbJobType.SelectedValue = oRow("JobTypeID")
                chkActive.Checked = oRow("ActiveFlag")
                lstDays.SetItemChecked(Enum_Days.eMonday, oRow("Monday"))
                lstDays.SetItemChecked(Enum_Days.eTuesday, oRow("Tuesday"))
                lstDays.SetItemChecked(Enum_Days.eWednesday, oRow("Wednesday"))
                lstDays.SetItemChecked(Enum_Days.eThursday, oRow("Thursday"))
                lstDays.SetItemChecked(Enum_Days.eFriday, oRow("Friday"))
                lstDays.SetItemChecked(Enum_Days.eSaturday, oRow("Saturday"))
                lstDays.SetItemChecked(Enum_Days.eSunday, oRow("Sunday"))
                dtScheduleTime.Value = oRow("NextRunTime")
            End If
        End If

    End Sub

    Private Sub FillJobTypeCombo()
        Dim oJob As New DB.clsJob

        cmbJobType.DisplayMember = "Description"
        cmbJobType.ValueMember = "JobTypeID"
        cmbJobType.SelectedIndex = 0
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

End Class