Namespace DB
    Friend Class clsFearGreed

        Public Function GetFearGreed_Date(dtEffDate As Date, Optional oConn As SqlConnection = Nothing) As DataTable
            Dim sSQL As String
            Dim oTable As DataTable

            sSQL = "SELECT top 1 * FROM tbl_FearGreed Where EffDate >= '" & dtEffDate & "'"
            oTable = DB.GetDataTable_SQL(sSQL, oConn)
            Return oTable
        End Function

        Public Function GetLatestFearGreed(Optional oConn As SqlConnection = Nothing) As DataTable
            Dim sSQL As String
            Dim oTable As DataTable

            sSQL = "SELECT top 1 * FROM tbl_FearGreed Order By FearGreedID DESC"
            oTable = DB.GetDataTable_SQL(sSQL, oConn)
            Return oTable
        End Function

        Public Function AddFearGreed(strFearGreed As STRUCT_FearGreed, Optional oConn As SqlConnection = Nothing) As Integer
            Dim iFearGreedID As Integer
            Dim al_oParams As New List(Of SqlParameter)

            With al_oParams
                .Add(GetSQLParam("@EffDate", SqlDbType.SmallDateTime, strFearGreed.dtEffDate))
                .Add(GetSQLParam("@Score_Today", SqlDbType.Float, strFearGreed.dScore_Today))
                .Add(GetSQLParam("@Rating_Today", SqlDbType.VarChar, 25, strFearGreed.sRating_Today))
                .Add(GetSQLParam("@Score_Yesterday", SqlDbType.Float, strFearGreed.dScore_Yesterday))
                .Add(GetSQLParam("@Rating_Yesterday", SqlDbType.VarChar, 25, strFearGreed.sRating_Yesterday))
                .Add(GetSQLParam("@Score_PrevWeek", SqlDbType.Float, strFearGreed.dScore_PrevWeek))
                .Add(GetSQLParam("@Rating_PrevWeek", SqlDbType.VarChar, 25, strFearGreed.sRating_PrevWeek))
                .Add(GetSQLParam("@Score_PrevMonth", SqlDbType.Float, strFearGreed.dScore_PrevMonth))
                .Add(GetSQLParam("@Rating_PrevMonth", SqlDbType.VarChar, 25, strFearGreed.sRating_PrevMonth))
                .Add(GetSQLParam("@Score_PrevYear", SqlDbType.Float, strFearGreed.dScore_PrevYear))
                .Add(GetSQLParam("@Rating_PrevYear", SqlDbType.VarChar, 25, strFearGreed.sRating_PrevYear))
                .Add(GetSQLParam("@Score_SP500", SqlDbType.Float, strFearGreed.dScore_SP500))
                .Add(GetSQLParam("@Rating_SP500", SqlDbType.VarChar, 25, strFearGreed.sRating_SP500))
                .Add(GetSQLParam("@Score_SP125", SqlDbType.Float, strFearGreed.dScore_SP125))
                .Add(GetSQLParam("@Rating_SP125", SqlDbType.VarChar, 25, strFearGreed.sRating_SP125))
                .Add(GetSQLParam("@Score_SPS", SqlDbType.Float, strFearGreed.dScore_SPS))
                .Add(GetSQLParam("@Rating_SPS", SqlDbType.VarChar, 25, strFearGreed.sRating_SPS))
                .Add(GetSQLParam("@Score_MVV", SqlDbType.Float, strFearGreed.dScore_MVV))
                .Add(GetSQLParam("@Rating_MVV", SqlDbType.VarChar, 25, strFearGreed.sRating_MVV))
                .Add(GetSQLParam("@Score_SHD", SqlDbType.Float, strFearGreed.dScore_SHD))
                .Add(GetSQLParam("@Rating_SHD", SqlDbType.VarChar, 25, strFearGreed.sRating_SHD))
                .Add(GetSQLParamOut("@FearGreedID", SqlDbType.Int))
            End With
            iFearGreedID = DB.Exec_SP("sp_AddFearGreed", al_oParams, oConn)

            Return iFearGreedID
        End Function

        Public Function UpdateFearGreed(strFearGreed As STRUCT_FearGreed, Optional oConn As SqlConnection = Nothing) As Boolean
            Dim bSuccess As Boolean
            Dim al_oParams As New List(Of SqlParameter)

            With al_oParams
                .Add(GetSQLParam("@FearGreedID", SqlDbType.Int, strFearGreed.iFearGreedID))
                .Add(GetSQLParam("@EffDate", SqlDbType.SmallDateTime, strFearGreed.dtEffDate))
                .Add(GetSQLParam("@Score_Today", SqlDbType.Float, strFearGreed.dScore_Today))
                .Add(GetSQLParam("@Rating_Today", SqlDbType.VarChar, 25, strFearGreed.sRating_Today))
                .Add(GetSQLParam("@Score_Yesterday", SqlDbType.Float, strFearGreed.dScore_Yesterday))
                .Add(GetSQLParam("@Rating_Yesterday", SqlDbType.VarChar, 25, strFearGreed.sRating_Yesterday))
                .Add(GetSQLParam("@Score_PrevWeek", SqlDbType.Float, strFearGreed.dScore_PrevWeek))
                .Add(GetSQLParam("@Rating_PrevWeek", SqlDbType.VarChar, 25, strFearGreed.sRating_PrevWeek))
                .Add(GetSQLParam("@Score_PrevMonth", SqlDbType.Float, strFearGreed.dScore_PrevMonth))
                .Add(GetSQLParam("@Rating_PrevMonth", SqlDbType.VarChar, 25, strFearGreed.sRating_PrevMonth))
                .Add(GetSQLParam("@Score_PrevYear", SqlDbType.Float, strFearGreed.dScore_PrevYear))
                .Add(GetSQLParam("@Rating_PrevYear", SqlDbType.VarChar, 25, strFearGreed.sRating_PrevYear))
                .Add(GetSQLParam("@Score_SP500", SqlDbType.Float, strFearGreed.dScore_SP500))
                .Add(GetSQLParam("@Rating_SP500", SqlDbType.VarChar, 25, strFearGreed.sRating_SP500))
                .Add(GetSQLParam("@Score_SP125", SqlDbType.Float, strFearGreed.dScore_SP125))
                .Add(GetSQLParam("@Rating_SP125", SqlDbType.VarChar, 25, strFearGreed.sRating_SP125))
                .Add(GetSQLParam("@Score_SPS", SqlDbType.Float, strFearGreed.dScore_SPS))
                .Add(GetSQLParam("@Rating_SPS", SqlDbType.VarChar, 25, strFearGreed.sRating_SPS))
                .Add(GetSQLParam("@Score_MVV", SqlDbType.Float, strFearGreed.dScore_MVV))
                .Add(GetSQLParam("@Rating_MVV", SqlDbType.VarChar, 25, strFearGreed.sRating_MVV))
                .Add(GetSQLParam("@Score_SHD", SqlDbType.Float, strFearGreed.dScore_SHD))
                .Add(GetSQLParam("@Rating_SHD", SqlDbType.VarChar, 25, strFearGreed.sRating_SHD))
            End With

            bSuccess = DB.Exec_SP("sp_UpdateFearGreed_ID", al_oParams, oConn)
            Return bSuccess
        End Function

    End Class
End Namespace