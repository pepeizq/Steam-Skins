Imports System.IO
Imports System.Text
Imports ColorPickerLib.Controls
Imports Pfim

Module Editor

    Public Sub CrearFicheroEditor(path As String)

        Using fs As FileStream = File.Create(path + "\Config.ini")
            Dim info As Byte() = New UTF8Encoding(True).GetBytes("[")
            fs.Write(info, 0, info.Length)
        End Using

        Dim lineas() As String = {"Data]", " ", "[Colors]", " ", "[Textures]"}

        File.AppendAllLines(path + "\Config.ini", lineas)

    End Sub

    Public Sub GenerarListadoSkins(comboBox As ComboBox, grid As Grid)

        comboBox.Items.Clear()

        For Each carpeta As String In Directory.GetDirectories(My.Application.Info.DirectoryPath + "\Editor")
            Dim item As New ComboBoxItem
            item.Content = carpeta.Replace(My.Application.Info.DirectoryPath + "\Editor\", Nothing)
            item.FontSize = 15
            item.Margin = New Thickness(5, 0, 5, 0)

            comboBox.Items.Add(item)
        Next

        If comboBox.Items.Count > 0 Then
            Dim azar As Random = New Random()
            comboBox.SelectedIndex = azar.Next(0, comboBox.Items.Count)
            grid.Visibility = Visibility.Visible
        Else
            grid.Visibility = Visibility.Collapsed
        End If

    End Sub

    Public Sub GenerarListadoTexturas(tabControl As TabControl, path As String)

        For Each fichero As String In Directory.GetFiles(path)
            If fichero.Contains(".png") Or fichero.Contains(".tga") Then
                Dim tab As New TabItem
                Dim titulo As String = Editor.LimpiarTitulo(fichero)

                If fichero.Contains(".png") Then
                    tab.ToolTip = titulo + ".png"
                End If

                If fichero.Contains(".tga") Then
                    tab.ToolTip = titulo + ".tga"
                End If

                tab.Header = titulo
                tabControl.Items.Add(tab)
            End If
        Next

    End Sub

    Public Function LimpiarTitulo(titulo As String) As String

        Dim temp, temp2 As String
        Dim int, int2 As Integer

        int = titulo.LastIndexOf("\")
        temp = titulo.Remove(0, int + 1)

        int2 = temp.IndexOf(".")
        temp2 = temp.Remove(int2, temp.Length - int2)

        Return temp2
    End Function

    Public Sub CargaTexturaPng(imagenWpf As Image, path As String, labelWpf As Label)

        Dim bit As New BitmapImage
        bit.BeginInit()
        bit.UriSource = New Uri(path)
        bit.EndInit()

        imagenWpf.Source = bit
        labelWpf.Content = "PNG - " + Math.Round(bit.Width).ToString + "x" + Math.Round(bit.Height).ToString

    End Sub

    Public Sub CargaTexturaTga(imagenWpf As Image, path As String, labelWpf As Label)

        Try
            Dim imagen As IImage = Pfim.Pfim.FromFile(path)
            Dim formato As PixelFormat

            Select Case imagen.Format()
                Case ImageFormat.Rgb24
                    formato = PixelFormats.Bgr24
                Case ImageFormat.Rgba32
                    formato = PixelFormats.Bgr32
            End Select

            imagenWpf.Source = BitmapSource.Create(imagen.Width, imagen.Height, 96.0, 96.0, formato, Nothing, imagen.Data, imagen.Stride)
            labelWpf.Content = "TGA - " + imagen.Width.ToString + "x" + imagen.Height.ToString
        Catch ex As Exception
            imagenWpf.Source = Nothing
            labelWpf.Content = "Error to load"
        End Try

    End Sub

    Public Function TraducirColor(color As ColorCanvas) As String

        Dim colorFinal As String

        colorFinal = color.SelectedColor.Value.R.ToString + " " + color.SelectedColor.Value.G.ToString + " " + color.SelectedColor.Value.B.ToString + " " + color.SelectedColor.Value.A.ToString

        Return colorFinal

    End Function

    Public Sub TraducirRGBA(color As ColorCanvas, traducir As String)

        Dim temp, temp2 As String
        Dim int, int2, int3 As Integer

        int = traducir.IndexOf(" ")
        temp = traducir.Remove(0, int + 1)

        color.R = traducir.Remove(int, traducir.Length - int)

        int2 = temp.IndexOf(" ")
        temp2 = temp.Remove(0, int2 + 1)

        color.G = temp.Remove(int2, temp.Length - int2)

        int3 = temp2.IndexOf(" ")

        color.B = temp2.Remove(int3, temp2.Length - int3)
        color.A = temp2.Remove(0, int3 + 1)

    End Sub

End Module
