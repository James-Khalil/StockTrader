Namespace DB
    Public Class clsSchedule
        Public Function AddJobSchedule(iJobTypeID As Integer, bMonday As Boolean, bTuesday As Boolean, bWednesday As Boolean, bThursday As Boolean,
                                       bFriday As Boolean, bSaturday As Boolean, bSunday As Boolean, oScheduleTime As System.TimeSpan,
                                       dtNextRunTime As DateTime, bActiveFlag As Boolean,
                                       Optional oConn As SqlConnection = Nothing)
            Dim iJobScheduleID As Integer
            Dim al_oParams As New List(Of SqlParameter)

            With al_oParams
                .Add(GetSQLParam("@JobTypeID", SqlDbType.Int, iJobTypeID))
                .Add(GetSQLParam("@Monday", SqlDbType.Bit, bMonday))
                .Add(GetSQLParam("@Tuesday", SqlDbType.Bit, bTuesday))
                .Add(GetSQLParam("@Wednesday", SqlDbType.Bit, bWednesday))
                .Add(GetSQLParam("@Thursday", SqlDbType.Bit, bThursday))
                .Add(GetSQLParam("@Friday", SqlDbType.Bit, bFriday))
                .Add(GetSQLParam("@Saturday", SqlDbType.Bit, bSaturday))
                .Add(GetSQLParam("@Sunday", SqlDbType.Bit, bSunday))
                .Add(GetSQLParam("@ScheduleTime", SqlDbType.Time, oScheduleTime))
                .Add(GetSQLParam("@NextRunTime", SqlDbType.SmallDateTime, dtNextRunTime))
                .Add(GetSQLParam("@ActiveFlag", SqlDbType.Bit, bActiveFlag))
                .Add(GetSQLParamOut("@JobScheduleID", SqlDbType.Int, iJobScheduleID))
            End With
            iJobScheduleID = Exec_SP("sp_AddJobSchedule", al_oParams, oConn)

            Return iJobScheduleID
        End Function

        Public Function GetJobScheduleByID(JobScheduleID As Integer) As DataTable
            Dim oTable As DataTable
            Dim al_oParams As New List(Of SqlParameter)

            With al_oParams
                .Add(GetSQLParam("@JobScheduleID", SqlDbType.Int, JobScheduleID))
            End With
            oTable = GetDataTable_SP("sp_GetJobSchedule_ID", al_oParams)
            Return oTable
        End Function

        Public Function GetJobSchedule(Optional oConn As SqlConnection = Nothing) As DataTable
            Dim oTable As DataTable

            oTable = GetDataTable_SP("sp_GetJobSchedule", oConn)
            Return oTable
        End Function

        Public Function GetJobSchedules(Optional oConn As SqlConnection = Nothing) As DataTable
            Dim oTable As DataTable

            oTable = GetDataTable_SP("sp_GetJobSchedules", oConn)
            Return oTable
        End Function

        Public Function UpdateJobScheduleByID(iJobTypeID As Integer, bMonday As Boolean, bTuesday As Boolean, bWednesday As Boolean, bThursday As Boolean,
                                       bFriday As Boolean, bSaturday As Boolean,
                                        bSunday As Boolean, oScheduleTime As System.TimeSpan,
                                       dtNextRunTime As DateTime,
                                       bActiveFlag As Boolean, Optional oConn As SqlConnection = Nothing)
            Dim iJobScheduleID As Integer
            Dim al_oParams As New List(Of SqlParameter)

            With al_oParams
                .Add(GetSQLParam("@JobScheduleID", SqlDbType.Int, iJobScheduleID))
                .Add(GetSQLParam("@JobTypeID", SqlDbType.Int, iJobTypeID))
                .Add(GetSQLParam("@Monday", SqlDbType.Bit, bMonday))
                .Add(GetSQLParam("@Tuesday", SqlDbType.Bit, bTuesday))
                .Add(GetSQLParam("@Wednesday", SqlDbType.Bit, bWednesday))
                .Add(GetSQLParam("@Thursday", SqlDbType.Bit, bThursday))
                .Add(GetSQLParam("@Friday", SqlDbType.Bit, bFriday))
                .Add(GetSQLParam("@Saturday", SqlDbType.Bit, bSaturday))
                .Add(GetSQLParam("@Sunday", SqlDbType.Bit, bSunday))
                .Add(GetSQLParam("@ScheduleTime", SqlDbType.Time, oScheduleTime))
                .Add(GetSQLParam("@NextRunTime", SqlDbType.SmallDateTime, dtNextRunTime))
                .Add(GetSQLParam("@ActiveFlag", SqlDbType.Bit, bActiveFlag))
            End With
            iJobScheduleID = Exec_SP("sp_UpdateJobSchedule_ID", al_oParams, oConn)
            Return iJobScheduleID
        End Function

        Public Function UpdateLastJobSchedule(iJobScheduleID As Integer, iLastJobID As Integer, dtNextRunTime As DateTime,
                                              Optional oConn As SqlConnection = Nothing) As Boolean
            Dim al_oParams As New List(Of SqlParameter)

            With al_oParams
                .Add(GetSQLParam("@JobScheduleID", SqlDbType.Int, iJobScheduleID))
                .Add(GetSQLParam("@LastJobID", SqlDbType.Int, iLastJobID))
                .Add(GetSQLParam("@NextRunTime", SqlDbType.SmallDateTime, dtNextRunTime))
            End With
            Return Exec_SP("dbo.sp_UpdateLastJobSchedule", al_oParams, oConn)
        End Function
    End Class
End Namespace