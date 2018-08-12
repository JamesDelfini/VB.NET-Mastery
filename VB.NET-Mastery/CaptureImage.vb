Imports Emgu.CV
Imports System.IO
Public Class CaptureImage
    Dim cap As New VideoCapture()

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        Timer.Start()
    End Sub

    Private Sub btnCapture_Click(sender As Object, e As EventArgs) Handles btnCapture.Click
        Timer.Stop()
        'PictureBox1.Image.Save("D:\test.png")
        'Dim num As Integer = 0
        'Dim hasNoMatch As Boolean = False
        'Dim imageName As String = "Image_"

        'Do
        '    If (File.Exists("D:\" & imageName & num.ToString & ".png")) Then
        '        num += 1
        '    Else
        '        pcb.Image.Save("D:\" & imageName & num.ToString & ".png")
        '        hasNoMatch = True
        '    End If
        'Loop Until hasNoMatch = True

        Dim config As New cConfig
        Dim httpRequest As New cHttpRequest(config.SERVER & "/thesis/imageUpload.php")
        Dim requestText As New Hashtable
        requestText.Add("firstname", "Jairi Jaymark")
        Dim serverResponse As String = Nothing
        httpRequest._ImagePostRequest(requestText, pcb.Image, serverResponse)
        MsgBox(serverResponse)
    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer.Tick
        pcb.Image = cap.QueryFrame.Bitmap
    End Sub
End Class