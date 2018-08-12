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

    Sub _ImagePostRequest(requestText As Hashtable, requestImage As Image, ByRef serverResponse As String)
        Try
            Dim request As HttpWebRequest = CType(WebRequest.Create(_URI), HttpWebRequest)
            request.Method = "POST"
            Dim boundary As String = CreateFormDataBoundary()
            request.ContentType = "multipart/form-data; boundary=" & boundary
            Dim dataStream As Stream = request.GetRequestStream()

            ''Send Text
            For Each key As String In requestText.Keys
                Dim item As String = "--" + boundary + vbCrLf + "Content-Disposition: form-data; name=""" & key & """" + vbCrLf + vbCrLf + requestText.Item(key) + vbCrLf
                Dim itemBytes() As Byte = Encoding.UTF8.GetBytes(item)
                dataStream.Write(itemBytes, 0, itemBytes.Length)
            Next

            ''Send Image
            Dim file_header = "--" + boundary + vbCrLf + "Content-Disposition: form-data; name=""file"";filename=""file.png""" + vbCrLf + "Content-Type: image/png" + vbCrLf + vbCrLf
            Dim file_header_bytes() As Byte = Encoding.UTF8.GetBytes(file_header)
            dataStream.Write(file_header_bytes, 0, file_header_bytes.Length)
            Dim ms As MemoryStream = New MemoryStream()
            Dim image As Image = requestImage
            Dim format As Imaging.ImageFormat = Imaging.ImageFormat.Png
            image.Save(ms, format)
            Dim file_bytes() As Byte = ms.GetBuffer()
            ms.Close()
            dataStream.Write(file_bytes, 0, file_bytes.Length)
            Dim file_footer_bytes() As Byte = Encoding.UTF8.GetBytes(vbCrLf)
            dataStream.Write(file_footer_bytes, 0, file_footer_bytes.Length)

            ''Send
            Dim endBytes() As Byte = Encoding.UTF8.GetBytes("--" + boundary + "--")
            dataStream.Write(endBytes, 0, endBytes.Length)
            dataStream.Close()

            Dim Response As HttpWebResponse = request.GetResponse()
            dataStream = Response.GetResponseStream 'Downloading the response from your website
            Dim reader As New StreamReader(dataStream)
            serverResponse = reader.ReadToEnd()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Sub _GetRequest()
        Dim webClient As New System.Net.WebClient
        Dim result As String = webClient.DownloadString(_URI)
    End Sub

    Private Function CreateFormDataBoundary()
        Return "---------------------------" & DateTime.Now.Ticks.ToString("x")
    End Function
End Class
