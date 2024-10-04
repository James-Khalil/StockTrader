Imports System.Runtime.InteropServices
Imports System.Security.Principal

Public Module modSecurity
    Public Const DOMAIN_NAME As String = SECRET"
    Public Const DOMAIN_USER As String = "SECRET"
    Public Const DOMAIN_PWRD As String = "SECRET"

    Public Enum LogonType As Integer
        LOGON32_LOGON_INTERACTIVE = 2
        LOGON32_LOGON_NETWORK = 3
        LOGON32_LOGON_BATCH = 4
        LOGON32_LOGON_SERVICE = 5
        LOGON32_LOGON_UNLOCK = 7
        LOGON32_LOGON_NETWORK_CLEARTEXT = 8
        ' Only for Win2K or higher
        LOGON32_LOGON_NEW_CREDENTIALS = 9
        ' Only for Win2K or higher
    End Enum

    Public Enum LogonProvider As Integer
        LOGON32_PROVIDER_DEFAULT = 0
        LOGON32_PROVIDER_WINNT35 = 1
        LOGON32_PROVIDER_WINNT40 = 2
        LOGON32_PROVIDER_WINNT50 = 3
    End Enum

    <DllImport("advapi32.dll", SetLastError:=True)>
    Public Function LogonUser(ByVal lpszUsername As [String], ByVal lpszDomain As [String], ByVal lpszPassword As [String], ByVal dwLogonType As Integer, ByVal dwLogonProvider As Integer, ByRef TokenHandle As IntPtr) As Boolean
    End Function

    <DllImport("kernel32.dll", CharSet:=CharSet.Auto)>
    Public Function CloseHandle(ByVal handle As IntPtr) As Boolean
    End Function

    <DllImport("advapi32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Public Function DuplicateToken(ByVal ExistingTokenHandle As IntPtr, ByVal SECURITY_IMPERSONATION_LEVEL As Integer, ByRef DuplicateTokenHandle As IntPtr) As Boolean
    End Function

    Public Function ImpersonateSvcBotTrader() As WindowsImpersonationContext
        Dim tokenHandle As New IntPtr(0)
        Dim dupeTokenHandle As New IntPtr(0)
        Try
            Const SecurityImpersonation As Integer = 2
            tokenHandle = IntPtr.Zero
            dupeTokenHandle = IntPtr.Zero
            ' Call LogonUser to obtain a handle to an access token.
            Dim returnValue As Boolean = LogonUser(DOMAIN_USER, DOMAIN_NAME, DOMAIN_PWRD, LogonType.LOGON32_LOGON_INTERACTIVE,
                                                   LogonProvider.LOGON32_PROVIDER_DEFAULT, tokenHandle)
            If False = returnValue Then
                Dim ret As Integer = Marshal.GetLastWin32Error()
                Dim strErr As String = [String].Format("LogonUser failed with error code : {0}", ret)
                Throw New ApplicationException(strErr, Nothing)
            End If
            Dim retVal As Boolean = DuplicateToken(tokenHandle, SecurityImpersonation, dupeTokenHandle)
            If False = retVal Then
                CloseHandle(tokenHandle)
                Throw New ApplicationException("Failed to duplicate token", Nothing)
            End If
            ' The token that is passed to the following constructor must
            ' be a primary token in order to use it for impersonation.
            Dim newId As New WindowsIdentity(dupeTokenHandle)
            Dim impersonatedUser As WindowsImpersonationContext = newId.Impersonate()
            Return impersonatedUser
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return Nothing
    End Function

End Module
