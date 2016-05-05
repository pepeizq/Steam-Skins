Imports System.Environment
Imports System.Globalization
Imports System.IO
Imports System.Resources
Imports System.Text
Imports System.Windows.Resources

Module Modulos

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

    Public Sub VisibilidadImagen(button As Button, imagen As ImageBrush, url As String)

        If Not url = Nothing Then
            Dim uri As Uri = New Uri(url, UriKind.RelativeOrAbsolute)
            Dim info As StreamResourceInfo = Application.GetResourceStream(uri)
            Dim bit As BitmapFrame = BitmapFrame.Create(info.Stream)

            imagen.ImageSource = bit
            button.Background = imagen
            button.Content = Nothing
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

End Module
