Module Air

    Public Function UrlDescarga()

        Dim html As String = Decompiladores.Decompression("http://outsetinitiative.deviantart.com/art/Air-for-Steam-2016-0417-410288247")

        Dim temp, temp2, temp3, temp4 As String
        Dim int, int2, int3 As Integer

        int = html.IndexOf(".zip")
        temp = html.Remove(int + 4, html.Length - (int + 4))

        int2 = temp.LastIndexOf("http")
        temp2 = temp.Remove(0, int2)

        temp3 = html.Remove(0, int + 4)

        int3 = temp3.IndexOf(Chr(34))
        temp4 = temp3.Remove(int3, temp3.Length - int3)

        temp4 = temp4.Replace("&amp;", "&")

        Return temp2 + temp4
    End Function

End Module
