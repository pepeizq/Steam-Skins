Module Versiones

    Public Function Generar(titulo As String) As String

        Dim version As String = Nothing

        If titulo = "Air" Then
            version = GitHub("https://github.com/Outsetini/Air-for-Steam")
        ElseIf titulo = "Air Classic" Then
            version = GitHub("https://github.com/Outsetini/Air-Classic")
        ElseIf titulo = "Compact" Then
            version = GitHub("https://github.com/badanka/Compact")
        ElseIf titulo = "Metro" Then
            version = Metro()
        ElseIf titulo = "PixelVision²" Then
            version = GitHub("https://github.com/somini/Pixelvision2")
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
