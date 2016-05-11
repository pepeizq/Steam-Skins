Module Versiones

    Public Function Generar(titulo As String) As String

        Dim version As String = Nothing

        If titulo = "Air" Then
            version = GitHub("https://github.com/Outsetini/Air-for-Steam")
        ElseIf titulo = "Air Classic" Then
            version = GitHub("https://github.com/Outsetini/Air-Classic")
        ElseIf titulo = "Black Rock Shooter" Then
            version = GameBanana("http://steam.gamebanana.com/guis/download/30778")
        ElseIf titulo = "Blue Pulse" Then
            version = GameBanana("http://steam.gamebanana.com/guis/download/31078")
        ElseIf titulo = "Compact" Then
            version = GitHub("https://github.com/badanka/Compact")
        ElseIf titulo = "Invert" Then
            version = GameBanana("http://steam.gamebanana.com/guis/download/28814")
        ElseIf titulo = "Metro" Then
            version = Metro()
        ElseIf titulo = "Minimal" Then
            version = GameBanana("http://steam.gamebanana.com/guis/download/27756")
        ElseIf titulo = "PixelVision²" Then
            version = GitHub("https://github.com/somini/Pixelvision2")
        ElseIf titulo = "Plexed" Then
            version = GameBanana("http://steam.gamebanana.com/guis/download/30097")
        ElseIf titulo = "Pressure²" Then
            version = GitHub("https://github.com/DirtDiglett/Pressure2/")
        ElseIf titulo = "Threshold" Then
            version = GitHub("https://github.com/Edgarware/Threshold-Skin")
        End If

        Return version
    End Function

    Private Function GitHub(url As String) As String

        Dim html As String = Nothing

        Dim i As Integer = 0
        While i < 10
            If html = Nothing Then
                html = Decompiladores.Decompression(url + "/commits/master.atom")
            Else
                Exit While
            End If
            i += 1
        End While

        Dim temp, temp2 As String
        Dim int, int2 As Integer

        If Not html = Nothing Then
            int = html.IndexOf("Commit/")
            temp = html.Remove(0, int + 7)

            int2 = temp.IndexOf("</id>")
            temp2 = temp.Remove(int2, temp.Length - int2)

            Return temp2
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

        Dim temp, temp2, temp3, temp4, temp5, temp6 As String
        Dim int, int2, int3, int4, int5, int6 As Integer

        If Not html = Nothing Then
            int = html.IndexOf("<dt>Filename</dt>")
            temp = html.Remove(0, int)

            int2 = temp.IndexOf("<dd>")
            temp2 = temp.Remove(0, int2 + 4)

            int3 = temp2.IndexOf("</dd>")
            temp3 = temp2.Remove(int3, temp2.Length - int3)

            int4 = html.IndexOf("<dt>FileID</dt>")
            temp4 = html.Remove(0, int4)

            int5 = temp4.IndexOf("<dd>")
            temp5 = temp4.Remove(0, int5 + 4)

            int6 = temp5.IndexOf("</dd>")
            temp6 = temp5.Remove(int6, temp5.Length - int6)

            Return temp3 + temp6
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

        Dim temp, temp2, temp3 As String
        Dim int, int2, int3 As Integer

        If Not html = Nothing Then
            int = html.IndexOf("<h1 id=" + Chr(34) + "date")
            temp = html.Remove(0, int)

            int2 = temp.IndexOf(">")
            temp2 = temp.Remove(0, int2 + 1)

            int3 = temp2.IndexOf("</h1>")
            temp3 = temp2.Remove(int3, temp2.Length - int3)

            Return temp3
        Else
            Return Nothing
        End If
    End Function

End Module
