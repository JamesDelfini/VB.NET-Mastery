Imports MySql.Data.MySqlClient

Public Class Login
    Dim conn As New MySqlConnection
    Dim command As MySqlCommand
    Dim reader As MySqlDataReader
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        conn.ConnectionString = "server=localhost;userid=root;password=;database=review;sslmode=none"
        Try
            conn.Open()
            'MessageBox.Show("Successful Connection")
            Dim query As String = "SELECT * FROM review.users WHERE BINARY username='" & txtUsername.Text & "' AND BINARY password='" & txtPassword.Text & "'"
            command = New MySqlCommand(query, conn)
            reader = command.ExecuteReader
            Dim count As Integer = 0

            While reader.Read
                count += 1
            End While

            If count Then
                MessageBox.Show("Login Successful!")
                SecondForm.Show()
                Me.Hide()
            Else
                MessageBox.Show("Login Failed!")
            End If
            conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conn.Dispose()
        End Try
    End Sub
End Class
