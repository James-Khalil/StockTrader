Public Class clsCombo

    Private sName As String
    Private oID As Object

    Public Sub New()
        sName = ""
        oID = 0
    End Sub

    Public Sub New(Name As String, ID As Object)
        sName = Name
        oID = ID
    End Sub

    Public Property Name() As String
        Get
            Return sName
        End Get
        Set(sValue As String)
            sName = sValue
        End Set
    End Property

    Public Property ItemData() As Object
        Get
            Return oID
        End Get
        Set(oValue As Object)
            oID = oValue
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return sName
    End Function
End Class
