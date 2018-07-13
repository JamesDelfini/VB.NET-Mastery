Imports System.IO
Imports System.Net
Imports System.Text
Imports Newtonsoft.Json.Linq

Public Class cHttpRequest
    Private _URI As String = Nothing
    Private _Request As String = Nothing

    Sub New(URI As String)
        _URI = URI
    End Sub

    Sub _PostRequest(dataRequest As Dictionary(Of String, String), ByRef jsonObject As JObject)
        Dim data As String
        Dim hasMoreRequest As Boolean = False
        For Each item In dataRequest
            If Not hasMoreRequest Then
                data = item.Key & "=" & item.Value
            Else
                data += "&" & item.Key & "=" & item.Value
            End If
            hasMoreRequest = True
        Next

        Try
            Dim request As HttpWebRequest = CType(WebRequest.Create(_URI), HttpWebRequest)
            request.Method = "POST"
            request.ContentType = "application/x-www-form-urlencoded"
            Dim Post As String = (data)
            Dim byteArray() As Byte = Encoding.UTF8.GetBytes(Post)
            request.ContentLength = byteArray.Length
            Dim DataStream As Stream = request.GetRequestStream()
            DataStream.Write(byteArray, 0, byteArray.Length)
            DataStream.Close()
            Dim Response As HttpWebResponse = request.GetResponse()
            DataStream = Response.GetResponseStream 'Downloading the response from your website
            Dim reader As New StreamReader(DataStream)
            Dim ServerResponse As String = reader.ReadToEnd()
            jsonObject = JObject.Parse(ServerResponse)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Sub _GetRequest()
        Dim webClient As New System.Net.WebClient
        Dim result As String = webClient.DownloadString("http://api.hostip.info/?ip=68.180.206.184")
    End Sub
End Class
