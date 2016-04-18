Imports System.Net
Imports System.IO

Public Module Decompiladores

    Public Function WebClient(url As String, tipo As String, user As String) As String

        Dim i As Integer = 0

        Try
            Dim objWebClient As WebClient = New WebClient

            If user = "Google" Then
                objWebClient.Headers.Add("User-Agent", "Googlebot/2.1 ( http://www.googlebot.com/bot.html)")
            ElseIf user = "Mozilla" Then
                objWebClient.Headers.Add("User-Agent", "Mozilla/5.0")
            ElseIf user = "Opera" Then
                objWebClient.Headers.Add("User-Agent", "Opera/9.60 (Windows NT 5.1; U; de) Presto/2.1.1 ")
            ElseIf user = "ProxyOS" Then
                objWebClient.Headers.Add("User-Agent", "Anonymized by ProxyOS: http://www.megaproxy.com ")
            ElseIf user = "Windows Live" Then
                objWebClient.Headers.Add("User-Agent", "msnbot-Products/1.0 (+http://search.msn.com/msnbot.htm) ")
            ElseIf user = "Mozilla2" Then
                objWebClient.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.3; rv:36.0) Gecko/20100101 Firefox/36.0")
            ElseIf user = "Opera2" Then
                objWebClient.Headers.Add("User-Agent", "Opera/9.80 (X11; Linux i686; Ubuntu/14.10) Presto/2.12.388 Version/12.16")
            End If

            Dim HTML() As Byte = objWebClient.DownloadData(url)
            Dim HTMLContent As String = New Text.UTF8Encoding().GetString(HTML)

            If tipo = "html" Then
                Return HTMLContent
            Else
                Return Nothing
            End If

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function WebRequest2(url As String) As String

        Try
            Dim req As WebRequest = Net.WebRequest.Create(url)
            Dim response As WebResponse = req.GetResponse()

            Dim dataStream As Stream = response.GetResponseStream()
            Dim reader As New StreamReader(dataStream)
            Dim responseFromServer As String = reader.ReadToEnd()

            reader.Close()
            response.Close()

            Return responseFromServer
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Decompression(url As String) As String

        Try
            Dim request As HttpWebRequest = CType(Net.WebRequest.Create(url), HttpWebRequest)

            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; .NET CLR 1.0.3705;)"
            request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate")
            request.AutomaticDecompression = DecompressionMethods.GZip Or DecompressionMethods.Deflate

            Using response As WebResponse = request.GetResponse()
                Using responseStream As Stream = response.GetResponseStream()
                    Using sr As StreamReader = New StreamReader(responseStream)
                        Return sr.ReadToEnd().ToString
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Download(url As String) As String

        Try
            Dim sourceString As String = New WebClient().DownloadString(url)

            Return sourceString
        Catch ex As Exception
            Return Nothing
        End Try
    End Function



End Module


