Imports System.Text
Imports System.Globalization
Imports System.IO
Imports System.Resources
Imports System.Windows.Resources

Module Modulos

    Public Sub GenerarListadoSkins(comboBox As ComboBox)

        Dim i As Integer = 0
        Dim listaOrdenar As List(Of String) = New List(Of String)

        i = 0
        While i < comboBox.Items.Count
            If i > 1 Then
                Dim temp As String = comboBox.Items(i).ToString
                temp = temp.Replace("System.Windows.Controls.ComboBoxItem:", Nothing)
                listaOrdenar.Add(temp.Trim)
            End If
            i += 1
        End While

        comboBox.Items.Clear()

        For Each carpeta As String In Directory.GetDirectories(My.Application.Info.DirectoryPath + "\Editor")
            Dim item As String = carpeta.Replace(My.Application.Info.DirectoryPath + "\Editor\", Nothing)
            Dim tempItem As Boolean = False

            i = 0
            While i < listaOrdenar.Count
                If listaOrdenar(i) = item Then
                    tempItem = True
                End If
                i += 1
            End While

            If tempItem = False Then
                listaOrdenar.Add(item)
            End If
        Next

        listaOrdenar.Sort()

        Dim itemDefault As New ComboBoxItem
        itemDefault.Content = "Default"
        itemDefault.FontSize = 15
        itemDefault.Margin = New Thickness(5, 0, 5, 0)

        comboBox.Items.Add(itemDefault)
        comboBox.Items.Add(New Separator)

        For Each temp As String In listaOrdenar
            Dim item As New ComboBoxItem
            item.Content = temp.Trim
            item.FontSize = 15
            item.Margin = New Thickness(5, 0, 5, 0)

            comboBox.Items.Add(item)
        Next

        Dim azar As Random = New Random()
        comboBox.SelectedIndex = azar.Next(2, comboBox.Items.Count)

    End Sub

    Public Sub VisibilidadOpcion(lista As List(Of String), grid As Grid, comboBox As ComboBox)

        If Not lista Is Nothing Then
            comboBox.Items.Clear()

            Dim i As Integer = 0
            While i < lista.Count
                comboBox.Items.Add(lista(i))
                i += 1
            End While

            comboBox.SelectedIndex = 0
            grid.Visibility = Visibility.Visible
        Else
            grid.Visibility = Visibility.Collapsed
        End If

    End Sub

    Public Function CogerSeleccion(grid As Grid, comboBox As ComboBox) As String

        Dim seleccion As String

        If grid.Visibility = Visibility.Visible Then
            seleccion = comboBox.SelectedItem
            If Not seleccion = Nothing Then
                seleccion = seleccion.Replace("System.Windows.Controls.ComboBoxItem:", Nothing)
                seleccion = seleccion.Trim
            End If
        Else
            seleccion = Nothing
        End If

        Return seleccion

    End Function

    Public Sub CrearFicheroConfig()

        Using fs As FileStream = File.Create(My.Application.Info.DirectoryPath + "\Config.ini")
            Dim info As Byte() = New UTF8Encoding(True).GetBytes("[")
            fs.Write(info, 0, info.Length)
        End Using

        Dim lineas() As String = {"Options]", "Language="}

        File.AppendAllLines(My.Application.Info.DirectoryPath + "\Config.ini", lineas)

    End Sub

    Public Sub CrearFicheroInstrucciones(opcionIdioma As String, recursos As ResourceManager)

        Dim lineas() As String = {recursos.GetString("fontsInstructions1", New CultureInfo(opcionIdioma)), "2. " + recursos.GetString("fontsInstructions2", New CultureInfo(opcionIdioma))}

        Using fs As FileStream = File.Create(My.Application.Info.DirectoryPath + "\Temp\" + recursos.GetString("fontsFolder", New CultureInfo(opcionIdioma)) + "\" + recursos.GetString("fontsFile", New CultureInfo(opcionIdioma)))
            Dim info As Byte() = New UTF8Encoding(True).GetBytes("1. ")
            fs.Write(info, 0, info.Length)
        End Using

        File.AppendAllLines(My.Application.Info.DirectoryPath + "\Temp\" + recursos.GetString("fontsFolder", New CultureInfo(opcionIdioma)) + "\" + recursos.GetString("fontsFile", New CultureInfo(opcionIdioma)), lineas)

    End Sub

    Public Sub CrearFicheroSkin(path As String)

        Using fs As FileStream = File.Create(path + "\SteamSkins.ini")
            Dim info As Byte() = New UTF8Encoding(True).GetBytes("[")
            fs.Write(info, 0, info.Length)
        End Using

        Dim lineas() As String = {"Data]", "Version=", "Zip=", "Folder=", "Title=", "Code=", " ", "[Options]"}

        File.AppendAllLines(path + "\SteamSkins.ini", lineas)

    End Sub

    Public Sub VisibilidadImagen(button As Button, imagen As ImageBrush, url As String)

        If Not url = Nothing Then
            Dim imagenDatos As System.Drawing.Image

            Try
                Dim uri As Uri = New Uri(url, UriKind.RelativeOrAbsolute)
                Dim info As StreamResourceInfo = Application.GetResourceStream(uri)
                Dim bit As BitmapFrame = BitmapFrame.Create(info.Stream)

                imagen.ImageSource = bit
                imagenDatos = System.Drawing.Image.FromStream(info.Stream)
            Catch ex As Exception
                imagen.ImageSource = New BitmapImage(New Uri(url))
                imagenDatos = System.Drawing.Image.FromFile(url)
            End Try

            button.Background = imagen
            button.Content = Nothing

            Dim tip As New ToolTip
            tip.Visibility = Visibility.Collapsed
            tip.Content = imagenDatos.Width.ToString + "x" + imagenDatos.Height.ToString

            button.ToolTip = tip
            button.Visibility = Visibility.Visible
        Else
            button.Visibility = Visibility.Collapsed
        End If

    End Sub

    Public Sub ImagenExpandir(columna As ColumnDefinition, imagen As ImageBrush)

        columna.Width = New GridLength(200, GridUnitType.Star)
        imagen.Stretch = Stretch.Uniform

    End Sub

    Public Sub ImagenReducir(columna As ColumnDefinition, imagen As ImageBrush)

        columna.Width = New GridLength(1, GridUnitType.Star)
        imagen.Stretch = Stretch.UniformToFill

    End Sub

    Public Sub ImagenDimensionesExpandida(button As Button, imagen As Image)

        Dim dimensiones As String = button.ToolTip.ToString

        dimensiones = dimensiones.Replace("System.Windows.Controls.ToolTip:", Nothing)
        dimensiones = dimensiones.Trim

        Dim int As Integer = dimensiones.IndexOf("x")
        Dim width As String = dimensiones.Remove(int, dimensiones.Length - int)
        Dim height As String = dimensiones.Remove(0, int + 1)

        imagen.Width = width
        imagen.Height = height

    End Sub

End Module
