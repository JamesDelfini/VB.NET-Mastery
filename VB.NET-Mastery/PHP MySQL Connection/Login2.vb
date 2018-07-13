
Imports Newtonsoft.Json.Linq

Public Class Login2
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim httpRequest As New cHttpRequest("http://localhost:8080/review/login.php")
        Dim request As New Dictionary(Of String, String)
        Dim serverResponse As JObject = Nothing
        request.Add("username", txtUsername.Text)
        request.Add("password", txtPassword.Text)
        httpRequest._PostRequest(request, serverResponse)

        Try
            MsgBox(serverResponse.ToString)
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