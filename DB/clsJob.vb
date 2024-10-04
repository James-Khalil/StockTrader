Namespace DB

    Public Class clsJob

        Public Function AddJob(iJobTypeID As Integer, sDescription As String, sCreateUser As String,
                               Optional oConn As SqlConnection = Nothing) As Integer
            Dim al_oParams As New List(Of SqlParameter)
            Dim iJobID As Integer
            Dim oJob As New Job.clsJob

            With al_oParams
                .Add(GetSQLParam("@JobTypeID", SqlDbType.Int, iJobTypeID))
                .Add(GetSQLParam("@Description", SqlDbType.VarChar, 200, sDescription))
                .Add(GetSQLParam("@CreateUser", SqlDbType.VarChar, 25, sCreateUser))
                .Add(GetSQLParamOut("@JobID", SqlDbType.Int))
            End With
            iJobID = Exec_SP("sp_AddJob", al_oParams, oConn)

            If (g_eRunMode = ENUM_RunMode.eDebug) Then oJob.RunJob(iJobID, iJobTypeID)

            Return iJobID
        End Function

        Public Function GetJob(iJobTypeID As Integer, iJobStatusID As Integer, Optional oConn As SqlConnection = Nothing) As DataTable
            Dim oTable As DataTable
            Dim sSQL As String

            sSQL = "Select J.JobID, T.Description 'JobType', S.Description 'JobStatus', J.Description JobDescription, J.CreateUser, J.CreateTime,
                    J.StartTime, J.FinishTime
                    From tbl_Job J
                    Inner Join tbl_JobType T On J.JobTypeID = T.JobTypeID
                    Inner Join tbl_JobStatus S On J.JobStatusID = S.JobStatusID
                    Where J.JobTypeID = " & iJobTypeID & " And J.JobStatusID = " & iJobStatusID


            oTable = GetDataTable_SQL(sSQL, oConn)
            Return oTable
        End Function

        Public Function GetNextJob(Optional oConn As SqlConnection = Nothing) As DataTable
            Dim oTable As DataTable

            oTable = GetDataTable_SP("sp_GetNextJob", oConn)
            Return oTable
        End Function

        Public Function AddJobError(iJobID As Integer, iSequenceID As Integer, dtErrorDate As DateTime, sError As String,
                                    sException As String, Optional oConn As SqlConnection = Nothing) As Boolean
            Dim al_oParams As New List(Of SqlParameter)

            With al_oParams
                .Add(GetSQLParam("@JobID", SqlDbType.Int, iJobID))
                .Add(GetSQLParam("@SequenceID", SqlDbType.Int, iSequenceID))
                .Add(GetSQLParam("@ErrorDate", SqlDbType.DateTime, dtErrorDate))
                .Add(GetSQLParam("@Error", SqlDbType.VarChar, 250, sError))
                .Add(GetSQLParam("@Exception", SqlDbType.VarChar, 1000, sException))
            End With
            Return Exec_SP("sp_AddJobError", al_oParams, oConn)
        End Function

        Public Function GetJobErrorByJobID(iJobID As Integer) As DataTable
            Dim al_oParams As New List(Of SqlParameter)
            Dim oTable As DataTable

            With al_oParams
                .Add(GetSQLParam("@JobID", SqlDbType.Int, iJobID))
            End With
            oTable = GetDataTable_SP("sp_GetJobError_JobID", al_oParams)
            Return oTable
        End Function

        Public Function DataCleanup(Optional oConn As SqlConnection = Nothing) As Boolean
            Return Exec_SP("sp_CleanJob", oConn)
        End Function

        Public Function GetJobType() As DataTable
            Dim sSQL As String
            Dim oDataTable As DataTable

            sSQL = "Select * From tbl_JobType Order By Description"
            oDataTable = GetDataTable_SQL(sSQL)

            Return oDataTable
        End Function

        Public Function GetJobStatus() As DataTable
            Dim sSQL As String
            Dim oDataTable As DataTable

            sSQL = "Select * From tbl_JobStatus"
            oDataTable = GetDataTable_SQL(sSQL)

            Return oDataTable
        End Function

        Public Function UpdateJob(iJobID As Integer, iJobStatusID As Integer, dtTimeStamp As DateTime, bStartFlag As Boolean,
                                  Optional oConn As SqlConnection = Nothing) As Boolean
            Dim al_oParams As New List(Of SqlParameter)

            With al_oParams
                .Add(GetSQLParam("@JobID", SqlDbType.Int, iJobID))
                .Add(GetSQLParam("@JobStatusID", SqlDbType.Int, iJobStatusID))
                .Add(GetSQLParam("@TimeStamp", SqlDbType.DateTime, dtTimeStamp))
                .Add(GetSQLParam("@StartFlag", SqlDbType.Bit, bStartFlag))
            End With
            Return Exec_SP("sp_UpdateJob_ID", al_oParams, oConn)
        End Function

        Public Function UpdateJobStatus(iJobID As Integer, iJobStatusID As Integer, Optional oConn As SqlConnection = Nothing) As Boolean
            Dim al_oParams As New List(Of SqlParameter)

            With al_oParams
                .Add(GetSQLParam("@JobID", SqlDbType.Int, iJobID))
                .Add(GetSQLParam("@JobStatusID", SqlDbType.Int, iJobStatusID))
            End With
            Return Exec_SP("sp_UpdateJobStatus_ID", al_oParams, oConn)
        End Function
    End Class
End Namespace