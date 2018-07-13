Imports MySql.Data.MySqlClient

Public Class SecondForm
    Dim conn As New MySqlConnection
    Dim command As MySqlCommand
    Dim reader As MySqlDataReader

    Dim editUserID As Integer = Nothing

    Private Sub SecondForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.ConnectionString = "server=localhost;userid=root;password=;database=review;sslmode=none"
        _Edit(False)
        getListUsers()
    End Sub
    Private Sub SecondForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Login.Close()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If txtUsername.Text <> Nothing And
            txtPassword.Text <> Nothing Then
            Try
                conn.Open()
                Dim query As String = "INSERT INTO users (username, password) values ('" & txtUsername.Text & "', '" & txtPassword.Text & "')"
                command = New MySqlCommand(query, conn)
                reader = command.ExecuteReader
                MsgBox("New User Added!")
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Dispose()
            End Try
        Else
            MsgBox("Empty Information is not Allowed!", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub txtSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            conn.Open()
            Dim query As String = "UPDATE users SET username='" & txtUsername.Text & "', password='" & txtPassword.Text & "' WHERE id = '" & editUserID & "'"
            command = New MySqlCommand(query, conn)
            reader = command.ExecuteScalar
            MsgBox("User Information Updated")
            _Edit(False)
            editUserID = 0
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            conn.Dispose()
            txtUsername.Text = ""
            txtPassword.Text = ""
            getListUsers()
        End Try
    End Sub
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If Not IsNothing(lvUsers.FocusedItem) Then
            editUserID = lvUsers.SelectedItems(0).SubItems(0).Text
            txtUsername.Text = lvUsers.SelectedItems(0).SubItems(1).Text
            txtPassword.Text = lvUsers.SelectedItems(0).SubItems(2).Text
            _Edit(True)
        Else
            MsgBox("Please Select a User", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Not IsNothing(lvUsers.FocusedItem) Then
            Try
                conn.Open()
                Dim query As String = "DELETE FROM users WHERE id='" & lvUsers.SelectedItems(0).SubItems(0).Text & "'"
                command = New MySqlCommand(query, conn)
                reader = command.ExecuteReader
                MsgBox("Account Removed!")
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            Finally
                conn.Dispose()
                getListUsers()
            End Try
        Else
            MsgBox("Please Select a User", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        _Edit(False)
        editUserID = 0
    End Sub

    Sub _Edit(btnStatus As Boolean)
        btnSave.Enabled = btnStatus
        btnCancel.Enabled = btnStatus
        btnAdd.Enabled = Not btnStatus
        btnEdit.Enabled = Not btnStatus
        btnDelete.Enabled = Not btnStatus
    End Sub

    Sub getListUsers()
        lvUsers.Items.Clear()
        Try
            conn.Open()
            Dim query As String = "SELECT * FROM users"
            command = New MySqlCommand(query, conn)
            reader = command.ExecuteReader

            Dim index As Integer = 0
            While reader.Read
                lvUsers.Items.Add(reader.GetString("id"))
                lvUsers.Items(index).SubItems.Add(reader.GetString("username"))
                lvUsers.Items(index).SubItems.Add(reader.GetString("password"))
                index += 1
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Dispose()
        End Try
    End Sub
End Class