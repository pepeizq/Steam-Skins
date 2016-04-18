Module Metro

    Public Function UrlDescarga()

        Dim html As String = Decompiladores.WebRequest2("http://www.metroforsteam.com")

        Dim temp, temp2 As String
        Dim int, int2 As Integer

        int = html.IndexOf(".zip")
        temp = html.Remove(int + 4, html.Length - (int + 4))

        int2 = temp.LastIndexOf("http")
        temp2 = temp.Remove(0, int2)

        Return temp2
    End Function

End Module
