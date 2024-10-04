Namespace DB
    Public Class clsUser

        Public Function GetUserByLogin(sLoginName As String) As DataTable
            Dim oTable As DataTable
            Dim al_oParams As New List(Of SqlParameter)

            sLoginName = SystemInformation.UserName
            With al_oParams
                .Add(GetSQLParam("@Login", SqlDbType.VarChar, 50, sLoginName))
            End With
            oTable = GetDataTable_SP("sp_GetUser_Login", al_oParams)

            Return oTable
        End Function

    End Class
End Namespace
