Imports System.Data.SqlClient

Namespace DB
    Module modDB

        Public Const SQL_BT_SERVER As String = "SECRET" 'Prod SQL Server   
        Public Const SQL_BT_DB As String = "SECRET"
        Public Const SQL_BT_USER As String = "SECRET"
        Public Const SQL_BT_PASSWORD As String = "SECRET"
        Private Const SQL_COMMAND_TIMEOUT As Integer = 0 'This is the # of seconds for command to time out (0=unlimited)
        Private Const SQL_CONN_TIMEOUT As Integer = 60 'This is the # of seconds for connection opening to time out (default 10s)
        Private Const SQL_CONN_RETRY_COUNT As Integer = 5 'This is the # of retry attempts to open a connection (default 1)
        Private Const MAX_FRAGMENT_PERCENT As Double = 5.0

        Private m_oConn As SqlConnection
        Private m_oTxn As SqlTransaction = Nothing
        Private m_bIsTransacting As Boolean

        Private Function GetSQLConnectionString() As String
            Return "Data Source=" & SQL_BT_SERVER &
               ";Initial Catalog=" & SQL_BT_DB &
               ";User Id=" & SQL_BT_USER &
               ";Password=" & SQL_BT_PASSWORD &
               ";Connection Timeout=" & SQL_CONN_TIMEOUT &
               ";ConnectRetryCount=" & SQL_CONN_RETRY_COUNT


            'Return "Data Source=" & SQL_BT_SERVER &
            '   ";Initial Catalog=" & SQL_BT_DB &
            '   ";Integrated Security = SSPI" &
            '   ";Connection Timeout=" & SQL_CONN_TIMEOUT &
            '   ";ConnectRetryCount=" & SQL_CONN_RETRY_COUNT
        End Function

        Public Function DBConn() As SqlConnection
            Try
                If (IsNothing(m_oConn)) Then
                    m_oConn = New SqlConnection(GetSQLConnectionString())
                    m_oConn.Open()
                    InitConnectionSettings(m_oConn)
                Else
                    If ((m_oConn.State = ConnectionState.Broken) Or (m_oConn.State = ConnectionState.Closed)) Then
                        m_oConn = New SqlConnection(GetSQLConnectionString())
                        m_oConn.Open()
                        InitConnectionSettings(m_oConn)
                    End If
                End If
            Catch ex As Exception
                Throw
            End Try
            Return m_oConn
        End Function

        Public Function NewConnection() As SqlConnection
            Dim oConn As New SqlConnection(GetSQLConnectionString())
            Try
                oConn.Open()
                InitConnectionSettings(oConn)
            Catch ex As Exception
                oConn = Nothing
                Throw
            End Try
            Return oConn
        End Function

        Public Function NewConnection(sServer As String) As SqlConnection
            Dim oConn As New SqlConnection(GetSQLConnectionString())
            Try
                oConn.Open()
                InitConnectionSettings(oConn)
            Catch ex As Exception
                oConn = Nothing
                Throw
            End Try
            Return oConn
        End Function

        Private Sub InitConnectionSettings(oConn As SqlConnection)
            Exec_SQL("SET ARITHABORT ON;", oConn)
            Exec_SQL("SET ANSI_NULLS ON;", oConn)
            Exec_SQL("SET QUOTED_IDENTIFIER ON;", oConn)
            Exec_SQL("SET XACT_ABORT ON;", oConn)
        End Sub

        Public Sub CloneDataBase(sSourceDB As String, sDestinationDB As String, Optional oConn As SqlConnection = Nothing)
            Dim sSQL As String
            Try
                oConn = If(IsNothing(oConn), NewConnection(), oConn)
                If (IsDBAttached(sSourceDB, , oConn)) Then
                    sSQL = "DBCC CloneDatabase('" & sSourceDB & "','" & sDestinationDB & "')"
                    Exec_SQL(sSQL, oConn)
                    sSQL = "ALTER DATABASE " & sDestinationDB & " Set READ_WRITE"
                    Exec_SQL(sSQL, oConn)
                End If
            Catch ex As Exception
                Throw
            Finally
                oConn.Close()
                oConn.Dispose()
                DBConn()
            End Try

        End Sub

        Public Function OpenTransaction(Optional oConn As SqlConnection = Nothing) As SqlTransaction
            oConn = If(IsNothing(oConn), NewConnection(), oConn)
            If m_bIsTransacting Then
                Throw New ApplicationException("A transaction is already open")
            End If
            m_oTxn = oConn.BeginTransaction()
            m_bIsTransacting = True
            Return m_oTxn
        End Function

        Public Sub CommitTransaction()
            If Not m_bIsTransacting Then
                Throw New ApplicationException("No Transaction is open yet")
            End If
            Try
                m_bIsTransacting = False
                m_oTxn.Commit()
            Catch ex As Exception
                Throw
            End Try
        End Sub

        Public Sub RollbackTransaction()
            If Not m_bIsTransacting Then
                Throw New ApplicationException("No Transaction is open yet")
            End If
            Try
                m_bIsTransacting = False
                m_oTxn.Rollback()
            Catch ex As Exception
                Throw
            End Try
        End Sub

        Public Sub DBDisConn()
            DBDisConn(m_oConn)
        End Sub

        Public Sub DBDisConn(oConn As SqlConnection)
            If ((Not IsNothing(oConn)) AndAlso (oConn.State = ConnectionState.Open)) Then
                oConn.Close()
            End If
        End Sub

        Public Function Exec_SQL(sSQL As String, Optional oConn As SqlConnection = Nothing) As Boolean
            Dim oCmd As New SqlCommand(sSQL, If(IsNothing(oConn), DBConn(), oConn))

            Try
                oCmd.CommandType = CommandType.Text
                oCmd.CommandTimeout = SQL_COMMAND_TIMEOUT
                If m_bIsTransacting Then oCmd.Transaction = m_oTxn

                oCmd.ExecuteNonQuery()

                Return True
            Catch ex As Exception
                Throw
            Finally
                oCmd.Dispose()
            End Try

        End Function

        Public Function Exec_SP(sStoredProc As String, oParameters As List(Of SqlParameter),
                                Optional oConn As SqlConnection = Nothing) As Object
            Dim oCmd As New SqlCommand(sStoredProc, If(IsNothing(oConn), DBConn(), oConn))
            Dim oParam As New SqlParameter

            Try
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = SQL_COMMAND_TIMEOUT
                For Each oParam In oParameters
                    oCmd.Parameters.Add(oParam)
                Next
                If m_bIsTransacting Then oCmd.Transaction = m_oTxn

                oCmd.ExecuteNonQuery()

                If (oParam.Direction = ParameterDirection.Output) Then
                    Return oCmd.Parameters(oParam.ParameterName).Value()
                Else
                    Return True
                End If

            Catch ex As Exception
                Throw
            Finally
                oCmd.Dispose()
            End Try

        End Function

        Public Function Exec_SP(sStoredProc As String, Optional oConn As SqlConnection = Nothing) As Boolean
            Dim oCmd As New SqlCommand(sStoredProc, If(IsNothing(oConn), DBConn(), oConn))
            Dim bSuccess As Boolean = False

            Try
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = SQL_COMMAND_TIMEOUT
                If m_bIsTransacting Then oCmd.Transaction = m_oTxn
                oCmd.ExecuteNonQuery()
                bSuccess = True
            Catch ex As Exception
                Throw
            Finally
                oCmd.Dispose()
            End Try

            Return bSuccess
        End Function

        Public Function GetDataTable_SP(sStoredProc As String, oParameters As List(Of SqlParameter),
                                        Optional oConn As SqlConnection = Nothing) As DataTable
            Dim oCmd As New SqlCommand(sStoredProc, If(IsNothing(oConn), DBConn(), oConn))
            Dim oTable As New DataTable
            Dim oAdapter As New SqlDataAdapter
            Dim oParam As SqlParameter

            Try
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = SQL_COMMAND_TIMEOUT
                For Each oParam In oParameters
                    oCmd.Parameters.Add(oParam)
                Next
                If m_bIsTransacting Then oCmd.Transaction = m_oTxn
                oAdapter.SelectCommand = oCmd
                oAdapter.Fill(oTable)

                Return oTable
            Catch ex As Exception
                Throw
            Finally
                oCmd.Dispose()
            End Try

        End Function

        Public Function GetDataTable_SP(sStoredProc As String, Optional oConn As SqlConnection = Nothing) As DataTable
            Dim oCmd As New SqlCommand(sStoredProc, If(IsNothing(oConn), DBConn(), oConn))
            Dim oTable As New DataTable
            Dim oAdapter As New SqlDataAdapter

            Try
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = SQL_COMMAND_TIMEOUT
                If m_bIsTransacting Then oCmd.Transaction = m_oTxn
                oAdapter.SelectCommand = oCmd
                oAdapter.Fill(oTable)

                Return oTable
            Catch ex As Exception
                Throw
            Finally
                oCmd.Dispose()
            End Try

        End Function

        Public Function GetDataTable_SQL(sSQL As String, Optional oConn As SqlConnection = Nothing, Optional bAllowConcur As Boolean = False) As DataTable
            Dim oCmd As New SqlCommand(sSQL, If(IsNothing(oConn), DBConn(), oConn))
            Dim oTable As New DataTable
            Dim oAdapter As New SqlDataAdapter

            Try
                oCmd.CommandType = CommandType.Text
                oCmd.CommandTimeout = SQL_COMMAND_TIMEOUT
                If m_bIsTransacting And Not bAllowConcur Then oCmd.Transaction = m_oTxn
                oAdapter.SelectCommand = oCmd
                oAdapter.Fill(oTable)
                Return oTable
            Catch ex As Exception
                Throw
            Finally
                oCmd.Dispose()
            End Try
        End Function

        Public Function GetDataReader_SP(sStoredProc As String, oParameters As List(Of SqlParameter),
                                         Optional oConn As SqlConnection = Nothing) As SqlDataReader
            Dim oCmd As New SqlCommand(sStoredProc, If(IsNothing(oConn), DBConn(), oConn))
            Dim oDataReader As SqlDataReader
            Dim oParam As SqlParameter

            Try
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = SQL_COMMAND_TIMEOUT
                For Each oParam In oParameters
                    oCmd.Parameters.Add(oParam)
                Next
                If m_bIsTransacting Then oCmd.Transaction = m_oTxn

                oDataReader = oCmd.ExecuteReader()

                Return oDataReader
            Catch ex As Exception
                Throw
            Finally
                oCmd.Dispose()
            End Try

        End Function

        Public Function GetDataReader_SP(sStoredProc As String, Optional oConn As SqlConnection = Nothing) As SqlDataReader
            Dim oCmd As New SqlCommand(sStoredProc, If(IsNothing(oConn), DBConn(), oConn))
            Dim oDataReader As SqlDataReader

            Try
                oCmd.CommandType = CommandType.StoredProcedure
                oCmd.CommandTimeout = SQL_COMMAND_TIMEOUT
                If m_bIsTransacting Then oCmd.Transaction = m_oTxn
                oDataReader = oCmd.ExecuteReader()

                Return oDataReader
            Catch ex As Exception
                Throw
            Finally
                oCmd.Dispose()
            End Try

        End Function

        Public Function GetDataReader_SQL(sSQL As String, Optional oConn As SqlConnection = Nothing) As SqlDataReader
            Dim oCmd As New SqlCommand(sSQL, If(IsNothing(oConn), DBConn(), oConn))
            Dim oDataReader As SqlDataReader

            Try
                oCmd.CommandType = CommandType.Text
                oCmd.CommandTimeout = SQL_COMMAND_TIMEOUT
                If m_bIsTransacting Then oCmd.Transaction = m_oTxn
                oDataReader = oCmd.ExecuteReader()

                Return oDataReader
            Catch ex As Exception
                Throw
            Finally
                oCmd.Dispose()
            End Try

        End Function

        Public Function GetSQLParam(sParam As String, dbType As SqlDbType,
                                        iSize As Integer, oValue As Object,
                                        Optional iParamDirection As ParameterDirection = ParameterDirection.Input) As SqlParameter

            Dim oSQLParam As New SqlParameter(sParam, dbType, iSize)

            oSQLParam.Direction = iParamDirection
            oSQLParam.Value = oValue

            Return oSQLParam
        End Function

        Public Function GetSQLParam(sParam As String, dbType As SqlDbType, oValue As Object,
                                        Optional iParamDirection As ParameterDirection = ParameterDirection.Input) As SqlParameter

            Dim oSQLParam As New SqlParameter(sParam, dbType)

            oSQLParam.Direction = iParamDirection
            oSQLParam.Value = oValue

            Return oSQLParam
        End Function

        Public Function GetSQLParamOut(sParam As String, dbType As SqlDbType,
                                       Optional iSize As Integer = 0) As SqlParameter

            Dim oSQLParam As SqlParameter

            If (iSize > 0) Then
                oSQLParam = New SqlParameter(sParam, dbType, iSize)
            Else
                oSQLParam = New SqlParameter(sParam, dbType)
            End If
            oSQLParam.Direction = ParameterDirection.Output

            Return oSQLParam
        End Function

        Private Function LinkedServerExists(sServer As String, oConn As SqlConnection) As Boolean
            Dim sSQL As String
            Dim oTable As DataTable
            Dim bExists As Boolean = False

            Try
                sSQL = "Select * from master.sys.servers with(nolock) Where name='" & sServer & "'"
                oTable = GetDataTable_SQL(sSQL, oConn)
                bExists = (oTable.Rows.Count > 0)
                oTable.Dispose()
            Catch ex As Exception
                Throw
            End Try

            Return bExists
        End Function

        Public Sub AddLinkedServer(sServer As String, sUser As String, sPassword As String,
                                   Optional oConn As SqlConnection = Nothing)
            Dim sSQL As String

            Try
                oConn = If(IsNothing(oConn), DBConn(), oConn)
                If (Not LinkedServerExists(sServer, oConn)) Then
                    sSQL = "EXEC sp_addlinkedserver '" & sServer & "', N'SQL Server'"
                    Exec_SQL(sSQL, oConn)
                    sSQL = "EXEC sp_addlinkedsrvlogin '" & sServer & "', 'false', NULL, '" & sUser & "', '" & sPassword & "'"
                    Exec_SQL(sSQL, oConn)
                    sSQL = "EXEC sp_serveroption @server='" & sServer & "', @optname='rpc', @optvalue='true'"
                    Exec_SQL(sSQL, oConn)
                    sSQL = "EXEC sp_serveroption @server='" & sServer & "', @optname='rpc out', @optvalue='true'"
                    Exec_SQL(sSQL, oConn)

                End If
            Catch ex As Exception
                Throw
            End Try

        End Sub

        Public Sub DeleteLinkedServer(sServer As String, Optional oConn As SqlConnection = Nothing)
            Dim sSQL As String

            Try
                oConn = If(IsNothing(oConn), DBConn(), oConn)
                If (Not LinkedServerExists(sServer, oConn)) Then
                    sSQL = "sp_dropserver @server='" & sServer & "', @droplogins='droplogins'"
                    Exec_SQL(sSQL, oConn)
                End If
            Catch ex As Exception
                Throw
            End Try
        End Sub

        Public Sub BulkInsert(sTable As String, sbData As System.Text.StringBuilder, Optional oConn As SqlConnection = Nothing)
            'Dim sFileName, sBIPath, sTmpPath As String
            'Dim oOutStream As IO.StreamWriter

            'If (sbData.Length > 0) Then
            '    oConn = If(IsNothing(oConn), DBConn(), oConn)
            '    sFileName = modUtil.GetUniqueFileName(True, modUtil.ENUM_FILETYPE.eText)
            '    sBIPath = g_strAppConst.sBI_Path & sFileName
            '    sTmpPath = GetLocalAppDataPath()
            '    oOutStream = New IO.StreamWriter(sTmpPath, False, System.Text.Encoding.GetEncoding(g_strAppConst.iCodePage))
            '    oOutStream.Write(sbData.ToString())
            '    oOutStream.Close()

            '    IO.File.Copy(sTmpPath, sBIPath, True)
            '    Exec_SQL("BULK INSERT " & sTable & " FROM '" & sBIPath & "' WITH (CHECK_CONSTRAINTS, CODEPAGE='" & g_strAppConst.iCodePage & "')", oConn)
            '    IO.File.Delete(sTmpPath)
            '    IO.File.Delete(sBIPath)
            'End If
        End Sub

        Public Function TruncateTable(sTableName As String, bTruncate As Boolean, Optional oConn As SqlConnection = Nothing) As Boolean
            Dim sSQL As String

            oConn = If(IsNothing(oConn), DBConn(), oConn)
            sSQL = If(bTruncate, "Truncate Table ", "Delete ") & sTableName
            Return DB.modDB.Exec_SQL(sSQL, oConn)
        End Function

        Public Function DropTable(sTableName As String, Optional oConn As SqlConnection = Nothing) As Boolean
            Dim sSQL As String

            If (sTableName.Length > 0) Then
                oConn = If(IsNothing(oConn), DBConn(), oConn)
                sSQL = "DROP TABLE IF EXISTS " & sTableName
                Return DB.Exec_SQL(sSQL, oConn)
            Else
                Return False
            End If
        End Function

        Public Function KillActiveUsers(sDBName As String, Optional oConn As SqlConnection = Nothing) As Boolean
            Dim oParameters As New List(Of SqlParameter)
            Dim sSql As String
            Dim bSuccess As Boolean
            Dim oTable As DataTable
            Try
                oConn = If(IsNothing(oConn), DBConn(), oConn)
                If DBExists(sDBName, oConn) Then

                    sSql = "Select Convert(varchar(5), session_id) As UserID
                              From sys.dm_exec_sessions
	                          Where database_id  = db_id('" & sDBName & "')"


                    oTable = DB.GetDataTable_SQL(sSql, oConn)
                    For Each oRow As DataRow In oTable.Rows
                        DB.Exec_SQL("Kill " & oRow("UserID"), oConn)
                    Next
                End If

                bSuccess = True
            Catch ex As Exception
                bSuccess = False
            End Try

            Return bSuccess
        End Function

        Public Sub ReIndexDB(Optional oConn As SqlConnection = Nothing)
            Dim sSQL, sTable, sIndexName As String
            Dim oTable As DataTable
            Dim oRow As DataRow
            Dim dFragmentPct As Double

            oConn = If(IsNothing(oConn), DBConn(), oConn)
            sSQL = "SELECT B.name,i.name AS IndexName,A.avg_fragmentation_in_percent AS FragmentPct " &
                    "FROM sys.dm_db_index_physical_stats (DB_ID(), NULL, NULL , NULL, 'LIMITED') A " &
                    "INNER JOIN (Select * From sys.objects Where (type='U') AND (name NOT LIKE '[_]%') " &
                    "And lower(Name) in (select lower(TABLE_NAME) from INFORMATION_SCHEMA.TABLES Where lower(TABLE_SCHEMA) = 'dbo')) B ON B.object_id=A.object_id " &
                    "Inner Join sys.sysindexes i ON i.id=A.object_id AND i.indid=A.index_id " &
                    "WHERE avg_fragmentation_in_percent > 0 And index_id > 0 "
            oTable = GetDataTable_SQL(sSQL, oConn)
            For Each oRow In oTable.Rows
                sTable = oRow("name")
                sIndexName = oRow("IndexName")
                dFragmentPct = oRow("FragmentPct")
                If (dFragmentPct > MAX_FRAGMENT_PERCENT) Then
                    sSQL = "ALTER INDEX " & sIndexName & " ON " & sTable & " REBUILD "
                    Exec_SQL(sSQL, oConn)
                Else
                    sSQL = "ALTER INDEX " & sIndexName & " ON " & sTable & " REORGANIZE "
                    Exec_SQL(sSQL, oConn)
                End If
            Next
            oTable.Dispose()
        End Sub

        Public Sub AttachDB(sMDFPath As String, sDBName As String, Optional oConn As SqlConnection = Nothing)
            Dim sSQL As String

            If (Not DB.IsDBAttached(sDBName, , oConn)) Then
                oConn = If(IsNothing(oConn), DBConn(), oConn)
                'CREATE DATABASE FOR ATTACH is recommended instead of sp_attach_db
                sSQL = "CREATE DATABASE " & sDBName & " ON (FILENAME = '" & sMDFPath & "') FOR ATTACH "
                Exec_SQL(sSQL, oConn)
            Else
                Throw New Exception("AttchDB(): Database '" & sDBName & "' already exists.")
            End If
        End Sub

        Public Sub CreateDB(sDBName As String, Optional oConn As SqlConnection = Nothing)
            Dim sSQL As String

            If (Not DB.IsDBAttached(sDBName, , oConn)) Then
                oConn = If(IsNothing(oConn), DBConn(), oConn)
                sSQL = "CREATE DATABASE [" & sDBName & "] "
                DB.Exec_SQL(sSQL, oConn)
            Else
                Throw New Exception("CreateDB(): Database '" & sDBName & "' already exists.")
            End If
        End Sub

        Public Function GetSQLDataPath(bData As Boolean, Optional oConn As SqlConnection = Nothing) As String
            Dim sSQL, sPathEnum As String
            Dim sDataPath As String = ""
            Dim oTable As DataTable
            Dim oRow As DataRow

            oConn = If(IsNothing(oConn), DBConn(), oConn)
            sPathEnum = If(bData, "INSTANCEDEFAULTDATAPATH", "INSTANCEDEFAULTLOGPATH")
            sSQL = "SELECT SERVERPROPERTY('" & sPathEnum & "') as DataPath"
            oTable = DB.GetDataTable_SQL(sSQL, oConn)
            If (oTable.Rows.Count = 1) Then
                oRow = oTable.Rows(0)
                sDataPath = oRow("DataPath")
            End If
            oTable.Dispose()

            Return sDataPath
        End Function

        Public Sub BackupDB(sBackupPath As String, sDBName As String, sBackupName As String,
                            Optional sDescription As String = Nothing, Optional oConn As SqlConnection = Nothing)
            Dim sSQL As String

            oConn = If(IsNothing(oConn), DBConn(), oConn)
            sDescription = If(IsNothing(sDescription), sDBName, sDescription)

            'BACKUP DATABASE to DISK
            sSQL = "BACKUP DATABASE " & sDBName & " TO DISK = '" & sBackupPath & "' " &
                   "WITH COMPRESSION, DESCRIPTION = '" & sDescription & "', NOFORMAT, NOINIT, " &
                   "NAME = '" & sBackupName & "', SKIP, NOREWIND, NOUNLOAD,  STATS = 10;"
            Exec_SQL(sSQL, oConn)
        End Sub

        Public Sub RestoreDB(sBackupPath As String, sDBName As String, sSrcDataName As String, sSrcLogName As String,
                             sDestDataPath As String, sDestLogPath As String, Optional oConn As SqlConnection = Nothing)
            Dim sSQL As String

            DropDB(sDBName, oConn)
            oConn = If(IsNothing(oConn), DBConn(), oConn)

            sSQL = "RESTORE DATABASE " & sDBName & " FROM DISK = '" & sBackupPath & "' WITH FILE = 1, " &
                       "MOVE '" & sSrcDataName & "' TO '" & sDestDataPath & "', MOVE '" & sSrcLogName & "' TO '" & sDestLogPath & "', " &
                       "NOUNLOAD, REPLACE, STATS = 10 "
            Exec_SQL(sSQL, oConn)
        End Sub

        Public Sub RestoreDBToServer(sDBName As String, sServer As String, sSrcBackupPath As String, sDestCopyPathUNC As String, sDestCopyPath As String, sSQLDataPath As String, sSQLLogPath As String,
                                      bDeleteBackup As Boolean)
            Dim oConn As New SqlConnection("Data Source=" & sServer & ";Initial Catalog=master" & ";User Id=" & SQL_BT_USER & ";Password=" & SQL_BT_PASSWORD & ";")
            Dim sBackupDesc As String = sDBName & " " & Date.Now
            Dim sSrcDataName As String = ""
            Dim sSrcLogName As String = ""
            Dim sDestDataPath As String = ""
            Dim sDestLogPath As String = ""

            Try
                oConn.Open()
                If (IO.File.Exists(sDestCopyPath)) Then IO.File.Delete(sDestCopyPath)
                If Not IO.File.Exists(sDestCopyPath) Then IO.File.Copy(sSrcBackupPath, sDestCopyPath, True)

                GetLogicalDBLogName(sDestCopyPathUNC, sSrcDataName, sSrcLogName, oConn)
                sDestDataPath = sSQLDataPath & sDBName & ".mdf"
                sDestLogPath = sSQLLogPath & sDBName & ".ldf"
                KillActiveUsers(sDBName, oConn)

                RestoreDB(sDestCopyPathUNC, sDBName, sSrcDataName, sSrcLogName, sDestDataPath, sDestLogPath, oConn)
                oConn.Close()
            Catch ex As Exception
                If Not IsNothing(oConn) Then oConn.Close()
                Throw
            Finally
                If (IO.File.Exists(sSrcBackupPath) And bDeleteBackup) Then IO.File.Delete(sSrcBackupPath)
                If (IO.File.Exists(sDestCopyPath)) Then IO.File.Delete(sDestCopyPath)
            End Try
        End Sub

        Public Sub RestoreDBToServer(sDBName As String, sServer As String, sSrcBackupPath As String, sDestCopyPath As String, sSQLDataPath As String, sSQLLogPath As String,
                                      bDeleteBackup As Boolean)
            Dim oConn As New SqlConnection("Data Source=" & sServer & ";Initial Catalog=master" & ";User Id=" & SQL_BT_USER & ";Password=" & SQL_BT_PASSWORD & ";")
            Dim sBackupDesc As String = sDBName & " " & Date.Now
            Dim sSrcDataName As String = ""
            Dim sSrcLogName As String = ""
            Dim sDestDataPath As String = ""
            Dim sDestLogPath As String = ""

            Try
                oConn.Open()
                If (IO.File.Exists(sDestCopyPath)) Then IO.File.Delete(sDestCopyPath)
                If Not IO.File.Exists(sDestCopyPath) Then IO.File.Copy(sSrcBackupPath, sDestCopyPath, True)

                GetLogicalDBLogName(sDestCopyPath, sSrcDataName, sSrcLogName, oConn)
                sDestDataPath = sSQLDataPath & sDBName & ".mdf"
                sDestLogPath = sSQLLogPath & sDBName & ".ldf"
                KillActiveUsers(sDBName, oConn)

                RestoreDB(sDestCopyPath, sDBName, sSrcDataName, sSrcLogName, sDestDataPath, sDestLogPath, oConn)
                oConn.Close()
            Catch ex As Exception
                If Not IsNothing(oConn) Then oConn.Close()
                Throw
            Finally
                If (IO.File.Exists(sSrcBackupPath) And bDeleteBackup) Then IO.File.Delete(sSrcBackupPath)
                If (IO.File.Exists(sDestCopyPath)) Then IO.File.Delete(sDestCopyPath)
            End Try
        End Sub


        Public Sub DetachDB(sDBName As String, Optional oConn As SqlConnection = Nothing, Optional bShrinkDB As Boolean = True)
            Dim sSQL As String

            oConn = If(IsNothing(oConn), DBConn(), oConn)
            If (IsDBAttached(sDBName, , oConn)) Then
                sSQL = "DBCC SHRINKDATABASE('" & sDBName & "', 2 )"
                If bShrinkDB Then Exec_SQL(sSQL, oConn)
                sSQL = "sp_detach_db '" & sDBName & "', 'true'"
                Exec_SQL(sSQL, oConn)
            End If
        End Sub

        Public Function IsDBAttached(sDBName As String, Optional sServer As String = "",
                                     Optional oConn As SqlConnection = Nothing) As Boolean
            Dim sSQL As String
            Dim oTable As DataTable
            Dim bAttached As Boolean = False

            oConn = If(IsNothing(oConn), DBConn(), oConn)
            sServer = If(sServer.Length > 0, "[" & sServer & "].", "")
            sSQL = "Select * From " & sServer & "master.sys.databases with(nolock) where name='" & sDBName & "'"
            oTable = DB.GetDataTable_SQL(sSQL, oConn)
            bAttached = (oTable.Rows.Count > 0)
            oTable.Dispose()

            Return bAttached
        End Function

        Public Function IsDBLocked(sDBName As String, Optional sServer As String = "", Optional oConn As SqlConnection = Nothing) As Boolean
            Dim sSQL As String
            Dim oTable As DataTable
            Dim bLocked As Boolean = False

            oConn = If(IsNothing(oConn), DBConn(), oConn)
            sServer = If(sServer.Length > 0, "[" & sServer & "].", "")
            sSQL = "SELECT request_session_id " &
                   "FROM " & sServer & "master.sys.dm_tran_locks with(nolock) " &
                   "WHERE resource_database_id IN (SELECT database_id from " & sServer & "master.sys.databases where name='" & sDBName & "')"
            oTable = DB.GetDataTable_SQL(sSQL, oConn)
            bLocked = (oTable.Rows.Count > 0)
            oTable.Dispose()

            Return bLocked
        End Function

        Public Sub GetLogicalDBLogName(sLocalPath As String, ByRef sLogicalDBName As String, ByRef sLogicalLogName As String, Optional oConn As SqlConnection = Nothing)
            Dim oTable As DataTable
            Dim oRow As DataRow
            Dim sType, sSQL As String

            oConn = If(IsNothing(oConn), DBConn(), oConn)
            sSQL = "RESTORE FILELISTONLY FROM DISK = '" & sLocalPath & "' WITH FILE = 1"
            oTable = DB.GetDataTable_SQL(sSQL, oConn)
            For Each oRow In oTable.Rows
                sType = oRow("Type")
                If sType = "D" Then sLogicalDBName = oRow("LogicalName")
                If sType = "L" Then sLogicalLogName = oRow("LogicalName")
            Next
            oTable.Dispose()
        End Sub

        Public Sub DropDB(sDBName As String, Optional oConn As SqlConnection = Nothing)
            Dim sSQL As String
            oConn = If(IsNothing(oConn), DBConn(), oConn)

            sSQL = "DROP DATABASE IF EXISTS [" & sDBName & "]"
            Exec_SQL(sSQL, oConn)

        End Sub

        Public Sub ReIndexAllTables(sDBName As String, Optional oConn As SqlConnection = Nothing)
            oConn = If(IsNothing(oConn), DBConn(), oConn)
            Dim al_oParams As New List(Of SqlParameter)

            al_oParams.Add(GetSQLParam("@DBName", SqlDbType.NVarChar, 159, sDBName))
            DB.Exec_SP("sp_ReIndexAllTables", al_oParams, oConn)
        End Sub

        Public Sub ReIndexTable(sTableName As String, Optional oConn As SqlConnection = Nothing)
            oConn = If(IsNothing(oConn), DBConn(), oConn)

            DB.Exec_SQL("ALTER INDEX ALL ON " & sTableName & " REBUILD WITH (MAXDOP=8) ", oConn)
        End Sub

        Public Function TableExists(sDB As String, sTableName As String, Optional oConn As SqlConnection = Nothing) As Boolean
            oConn = If(IsNothing(oConn), DBConn(), oConn)
            Dim bExists As Boolean = False
            Dim sSQL As String
            Dim oTable As DataTable

            sSQL = "SELECT * From " & sDB & ".sys.objects Where object_id = OBJECT_ID(N'" & sTableName & "') AND type in (N'U')"
            oTable = DB.GetDataTable_SQL(sSQL, oConn)
            bExists = (oTable.Rows.Count > 0)

            Return bExists
        End Function

        Public Function TableHasRecords(sTableName As String, Optional oConn As SqlConnection = Nothing) As Boolean
            oConn = If(IsNothing(oConn), DBConn(), oConn)
            Dim bHasRecords As Boolean = False
            Dim sSQL As String
            Dim oTable As DataTable

            sSQL = "SELECT TOP (1) * From " & sTableName
            oTable = DB.GetDataTable_SQL(sSQL, oConn)
            bHasRecords = (oTable.Rows.Count > 0)

            Return bHasRecords
        End Function

        Public Function DBExists(sDBName As String, Optional oConn As SqlConnection = Nothing) As Boolean
            oConn = If(IsNothing(oConn), DBConn(), oConn)
            Dim bExists As Boolean = False
            Dim sSQL As String
            Dim oTable As DataTable

            sSQL = "Select name From sys.databases Where database_id = DB_ID('" & sDBName & "')"

            oTable = DB.GetDataTable_SQL(sSQL, oConn)
            bExists = (oTable.Rows.Count > 0)

            Return bExists
        End Function

        Public Function DBExistsLinkedServer(sDBName As String, sServerName As String, Optional oConn As SqlConnection = Nothing) As Boolean
            oConn = If(IsNothing(oConn), DBConn(), oConn)
            Dim bExists As Boolean = False
            Dim sSQL As String
            Dim oTable As DataTable
            Dim sLinkedServer As String = If(sServerName.Length > 0, sServerName & ".", "")

            sSQL = "Select name From " & sLinkedServer & "master.sys.databases Where name = '" & sDBName & "'"

            oTable = DB.GetDataTable_SQL(sSQL, oConn)
            bExists = (oTable.Rows.Count > 0)

            Return bExists
        End Function

    End Module
End Namespace
