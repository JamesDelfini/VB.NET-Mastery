
Imports Newtonsoft.Json.Linq

Public Class Login2
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim config As New cConfig
        Dim httpRequest As New cHttpRequest(config.SERVER & "/thesis/login.php")
        Dim request As New Dictionary(Of String, String)
        Dim serverResponse As JObject = Nothing
        request.Add("user", txtUsername.Text)
        request.Add("pass", txtPassword.Text)
        httpRequest._PostRequest(request, serverResponse)

        Try
            If Not Convert.ToBoolean(serverResponse.SelectToken("error").ToString) Then
                ' Login Successful
                MsgBox(serverResponse.SelectToken("message"))
            Else
                ' Login Failed
                MsgBox(serverResponse.SelectToken("message"))
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub
End Class