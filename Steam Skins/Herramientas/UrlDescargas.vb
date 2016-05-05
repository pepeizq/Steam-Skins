Module UrlDescargas

    Public Function Generar(titulo As String) As String

        Dim url As String = Nothing

        If titulo = "Air" Then
            url = GitHub("https://github.com/Outsetini/Air-for-Steam")
        ElseIf titulo = "Air Classic" Then
            url = GitHub("https://github.com/Outsetini/Air-Classic")
        ElseIf titulo = "Black Rock Shooter" Then
            url = GameBanana("http://steam.gamebanana.com/guis/download/30778")
        ElseIf titulo = "Blue Pulse" Then
            url = GameBanana("http://steam.gamebanana.com/guis/download/31078")
        ElseIf titulo = "Compact" Then
            url = GitHub("https://github.com/badanka/Compact")
        ElseIf titulo = "Invert" Then
            url = GameBanana("http://steam.gamebanana.com/guis/download/28814")
        ElseIf titulo = "Metro" Then
            url = Metro()
        ElseIf titulo = "Minimal" Then
            url = GameBanana("http://steam.gamebanana.com/guis/download/27756")
        ElseIf titulo = "PixelVision²" Then
            url = GitHub("https://github.com/somini/Pixelvision2")
        ElseIf titulo = "Plexed" Then
            url = GameBanana("http://steam.gamebanana.com/guis/download/30097")
        ElseIf titulo = "Pressure²" Then
            url = GitHub("https://github.com/DirtDiglett/Pressure2/")
        ElseIf titulo = "Threshold" Then
            url = GitHub("https://github.com/Edgarware/Threshold-Skin")
        End If

        Return url
    End Function

    Private Function GitHub(url As String) As String

        Dim html As String = Nothing

        Dim i As Integer = 0
        While i < 10
            If html = Nothing Then
                html = Decompiladores.Decompression(url)
            Else
                Exit While
            End If
            i += 1
        End While

        Dim temp, temp2 As String
        Dim int, int2 As Integer

        If Not html = Nothing Then
            int = html.IndexOf(".zip")
            temp = html.Remove(int + 4, html.Length - (int + 4))

            int2 = temp.LastIndexOf("<a href=")
            temp2 = temp.Remove(0, int2 + 9)

            Return "https://github.com" + temp2
        Else
            Return Nothing
        End If
    End Function

    Private Function GameBanana(url As String) As String

        Dim html As String = Nothing

        Dim i As Integer = 0
        While i < 10
            If html = Nothing Then
                html = Decompiladores.Decompression(url)
            Else
                Exit While
            End If
            i += 1
        End While

        Dim temp, temp2 As String
        Dim int, int2 As Integer

        If Not html = Nothing Then
            int = html.IndexOf(".zip")
            temp = html.Remove(int + 4, html.Length - (int + 4))

            int2 = temp.LastIndexOf("http://")
            temp2 = temp.Remove(0, int2)

            Return temp2
        Else
            Return Nothing
        End If

    End Function

    Private Function Metro()

        Dim html As String = Nothing

        Dim i As Integer = 0
        While i < 10
            If html = Nothing Then
                html = Decompiladores.WebRequest2("http://www.metroforsteam.com")
            Else
                Exit While
            End If
            i += 1
        End While

        Dim temp, temp2 As String
        Dim int, int2 As Integer

        If Not html = Nothing Then
            int = html.IndexOf(".zip")
            temp = html.Remove(int + 4, html.Length - (int + 4))

            int2 = temp.LastIndexOf("http")
            temp2 = temp.Remove(0, int2)

            Return temp2
        Else
            Return Nothing
        End If
    End Function

End Module
