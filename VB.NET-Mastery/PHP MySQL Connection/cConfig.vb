Public Class cConfig
    Private _DB_Server As String = "localhost"
    Private _DB_Username As String = "root"
    Private _DB_Password As String = ""
    Private _DB_Name As String = "review"

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

End Class
