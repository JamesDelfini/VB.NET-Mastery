Public Class cConfig
    Private _DB_Server As String = "localhost"
    Private _DB_Username As String = "id6583267_jaymarkrey"
    Private _DB_Password As String = "JairiJaymark"
    Private _DB_Name As String = "id6583267_thesisfjj"
    Private _SERVER As String = "http://thesis-fjj.000webhostapp.com"

    Public ReadOnly Property DB_Server As String
        Get
            Return _DB_Server
        End Get
    End Property

    Public ReadOnly Property DB_Username As String
        Get
            Return _DB_Username
        End Get
    End Property

    Public ReadOnly Property DB_Password As String
        Get
            Return _DB_Password
        End Get
    End Property

    Public ReadOnly Property DB_Name As String
        Get
            Return _DB_Name
        End Get
    End Property

    Public ReadOnly Property SERVER As String
        Get
            Return _SERVER
        End Get
    End Property
End Class
