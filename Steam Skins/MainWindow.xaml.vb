Imports System.IO
Imports System.IO.Compression
Imports System.ComponentModel
Imports System.Net
Imports System.Environment
Imports System.Globalization
Imports System.Resources
Imports System.Reflection
Imports Hardcodet.Wpf.TaskbarNotification

Class MainWindow

    Dim rutaSteam As String
    Dim skinInstalada, versionSkinInstalada, versionSkinActualizada As String

    Dim skinTitulo As String
    Dim skinCarpeta As String
    Dim skinZip As String
    Dim skinUrlDescarga As String
    Dim skinSeleccionPosicion As String

    Dim skinOpcion1, skinOpcion2, skinOpcion3, skinOpcion4, skinOpcion5, skinOpcion6, skinOpcion7, skinOpcion8, skinOpcion9 As String
    Dim skinOpcionSeleccion1, skinOpcionSeleccion2, skinOpcionSeleccion3, skinOpcionSeleccion4, skinOpcionSeleccion5, skinOpcionSeleccion6, skinOpcionSeleccion7, skinOpcionSeleccion8, skinOpcionSeleccion9 As String

    Dim opcionIdioma As String
    Dim assem As Assembly = Assembly.Load("Steam Skins")
    Dim recursos As ResourceManager = New ResourceManager("Steam_Skins.Idioma", assem)

    Private Sub Main_Loaded(sender As Object, e As RoutedEventArgs) Handles Main.Loaded

        Dim version As String = Me.GetType.Assembly.GetName.Version.Major.ToString + "." + Me.GetType.Assembly.GetName.Version.Minor.ToString

        Main.Title = "Steam Skins (" + version + ")"

        Dim intFramework As Integer = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full", "Release", Nothing)

        If intFramework < 378759 Then
            MsgBox("You need to have installed at least .NET Framework 4.5.2 before starting the application")
            Me.Close()
        End If

        If Not File.Exists(My.Application.Info.DirectoryPath + "\Config.ini") Then
            Modulos.CrearFicheroConfig()
        End If

        Try
            If FicherosINI.Leer(My.Application.Info.DirectoryPath + "\Config.ini", "Options", "Language") = Nothing Then
                Dim tempIdioma As String = CultureInfo.CurrentCulture.Name

                If Not tempIdioma = "es-ES" Then
                    tempIdioma = "en-US"
                End If

                FicherosINI.Escribir(My.Application.Info.DirectoryPath + "\Config.ini", "Options", "Language", tempIdioma)
            End If
        Catch ex As Exception
            FicherosINI.Escribir(My.Application.Info.DirectoryPath + "\Config.ini", "Options", "Language", "en-US")
        End Try

        CargarIdioma()

        rutaSteam = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Valve\Steam", "SteamPath", Nothing)
        rutaSteam = rutaSteam.Replace("/", "\")
        labelRutaSteam.Content = rutaSteam.Trim
        ControlesEstadoSkins()

        Dim azar As Random = New Random()
        comboBoxSkins.SelectedIndex = azar.Next(2, comboBoxSkins.Items.Count)

        If opcionIdioma = "es-ES" Then
            comboBoxOpcionesIdioma.SelectedIndex = 1
        Else
            comboBoxOpcionesIdioma.SelectedIndex = 0
        End If

        Modulos.ImagenExpandir(columnImage1, imagePreview1)

        If Not skinInstalada = "Default" Then
            If Directory.Exists(rutaSteam + "\skins\" + skinInstalada) Then
                If File.Exists(rutaSteam + "\skins\" + skinInstalada + "\SteamSkins.ini") Then
                    comboBoxSkins.SelectedIndex = FicherosINI.Leer(rutaSteam + "\skins\" + skinInstalada + "\SteamSkins.ini", "Data", "Code")
                End If
            End If
        End If

    End Sub

    Private Sub CargarIdioma()

        opcionIdioma = FicherosINI.Leer(My.Application.Info.DirectoryPath + "\Config.ini", "Options", "Language")

        labelTopBarComboBox.Content = recursos.GetString("labelTopBarComboBox", New CultureInfo(opcionIdioma))
        labelTopBarSteamFolder.Content = recursos.GetString("labelTopBarSteamFolder", New CultureInfo(opcionIdioma))
        labelTopBarSkinUse.Content = recursos.GetString("labelTopBarSkinUse", New CultureInfo(opcionIdioma))

        menuOptions.Header = recursos.GetString("menuOptions", New CultureInfo(opcionIdioma))
        menuContact.Header = recursos.GetString("menuContact", New CultureInfo(opcionIdioma))

        skinInstallButton.Content = recursos.GetString("skinInstallButton", New CultureInfo(opcionIdioma))

        tabControlAutorLabel.Content = recursos.GetString("tabControlAutorLabel", New CultureInfo(opcionIdioma))
        tabControlAutorCreado.Content = recursos.GetString("tabControlAutorCreado", New CultureInfo(opcionIdioma))
        tabControlAutorDonar.Content = recursos.GetString("tabControlAutorDonar", New CultureInfo(opcionIdioma))

        tabControlScreenshotsLabel.Content = recursos.GetString("tabControlScreenshotsLabel", New CultureInfo(opcionIdioma))
        tabControlScreenshotsTooltip.Content = recursos.GetString("tabControlScreenshotsTooltip", New CultureInfo(opcionIdioma))

        tabControlCustomizationLabel.Content = recursos.GetString("tabControlCustomizationLabel", New CultureInfo(opcionIdioma))

        buttonBarraSuperiorVolver.Content = recursos.GetString("buttonBarraSuperiorVolver", New CultureInfo(opcionIdioma))
        buttonBarraSuperiorVolverOpciones.Content = recursos.GetString("buttonBarraSuperiorVolver", New CultureInfo(opcionIdioma))

        gridOptionsLanguageLabel.Content = recursos.GetString("gridOptionsLanguageLabel", New CultureInfo(opcionIdioma))
        gridOptionsLanguageLabelAviso.Content = recursos.GetString("gridOptionsLanguageLabelWarning", New CultureInfo(opcionIdioma))
        buttonCleanAllSkins.Content = recursos.GetString("buttonCleanAllSkins", New CultureInfo(opcionIdioma))

    End Sub

    Private Sub ControlesEstado(estado As Boolean)

        menuOptions.IsEnabled = estado
        buttonCleanAllSkins.IsEnabled = estado

        comboBoxSkins.IsEnabled = estado
        skinInstallButton.IsEnabled = estado

        gridSkinOpcion1.IsEnabled = estado
        gridSkinOpcion2.IsEnabled = estado
        gridSkinOpcion3.IsEnabled = estado

        buttonBarraSuperiorVolverOpciones.IsEnabled = estado
        comboBoxOpcionesIdioma.IsEnabled = estado

    End Sub

    Private Sub ControlesEstadoSkins()

        skinInstalada = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Valve\Steam", "SkinV4", Nothing)

        If Not skinInstalada = Nothing Then
            skinInstalada = skinInstalada.Replace("/", "\")
            skinInstalada = skinInstalada.Trim
            labelSkinInstalada.Content = skinInstalada
        End If

        If skinInstalada = Nothing Then
            labelSkinInstalada.Content = "Default"
        Else
            labelSkinInstalada.Content = skinInstalada
        End If

    End Sub

    'SKINS----------------------------------------------------------------------

    Private Sub comboBoxSkins_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles comboBoxSkins.SelectionChanged

        skinTitulo = Nothing
        skinCarpeta = Nothing
        skinZip = Nothing
        skinUrlDescarga = Nothing
        skinSeleccionPosicion = Nothing

        skinOpcion1 = Nothing
        skinOpcion2 = Nothing
        skinOpcion3 = Nothing
        skinOpcion4 = Nothing
        skinOpcion5 = Nothing
        skinOpcion6 = Nothing
        skinOpcion7 = Nothing
        skinOpcion8 = Nothing
        skinOpcion9 = Nothing

        skinOpcionSeleccion1 = Nothing
        skinOpcionSeleccion2 = Nothing
        skinOpcionSeleccion3 = Nothing
        skinOpcionSeleccion4 = Nothing
        skinOpcionSeleccion5 = Nothing
        skinOpcionSeleccion6 = Nothing
        skinOpcionSeleccion7 = Nothing
        skinOpcionSeleccion8 = Nothing
        skinOpcionSeleccion9 = Nothing

        labelSkinOpcion1.Content = Nothing
        labelSkinOpcion2.Content = Nothing
        labelSkinOpcion3.Content = Nothing
        labelSkinOpcion4.Content = Nothing
        labelSkinOpcion5.Content = Nothing
        labelSkinOpcion6.Content = Nothing
        labelSkinOpcion7.Content = Nothing
        labelSkinOpcion8.Content = Nothing
        labelSkinOpcion9.Content = Nothing

        gridSkinOpcion1.Visibility = Visibility.Collapsed
        gridSkinOpcion2.Visibility = Visibility.Collapsed
        gridSkinOpcion3.Visibility = Visibility.Collapsed
        gridSkinOpcion4.Visibility = Visibility.Collapsed
        gridSkinOpcion5.Visibility = Visibility.Collapsed
        gridSkinOpcion6.Visibility = Visibility.Collapsed
        gridSkinOpcion7.Visibility = Visibility.Collapsed
        gridSkinOpcion8.Visibility = Visibility.Collapsed
        gridSkinOpcion9.Visibility = Visibility.Collapsed

        Modulos.ImagenExpandir(columnImage1, imagePreview1)
        Modulos.ImagenReducir(columnImage2, imagePreview2)
        Modulos.ImagenReducir(columnImage3, imagePreview3)
        Modulos.ImagenReducir(columnImage4, imagePreview4)

        Dim seleccion As String = comboBoxSkins.SelectedItem.ToString

        seleccion = seleccion.Replace("System.Windows.Controls.ComboBoxItem:", Nothing)
        seleccion = seleccion.Trim

        If seleccion = "Default" Then

            labelAutor.Content = "Valve"

            Dim listaImagenes As List(Of String) = New List(Of String)

            listaImagenes.Add("Imagenes/Default/default1.png")
            listaImagenes.Add("Imagenes/Default/default2.png")
            listaImagenes.Add("Imagenes/Default/default3.png")
            listaImagenes.Add("Imagenes/Default/default4.png")

            gridSkinOpciones.Visibility = Visibility.Collapsed

            PreCargaInstallButton(Nothing, Nothing, "Default", listaImagenes, Nothing, Nothing, Nothing)

        ElseIf seleccion = "Air" Then

            labelAutor.Content = "Inhibitor"

            Dim listaImagenes As List(Of String) = New List(Of String)

            listaImagenes.Add("Imagenes/Air/air1.png")
            listaImagenes.Add("Imagenes/Air/air2.png")
            listaImagenes.Add("Imagenes/Air/air3.png")
            listaImagenes.Add("Imagenes/Air/air4.png")

            gridSkinOpciones.Visibility = Visibility.Visible

            Dim listaThemes As List(Of String) = New List(Of String)

            listaThemes.Add(recursos.GetString("themeLight", New CultureInfo(opcionIdioma)))
            listaThemes.Add(recursos.GetString("themeDark", New CultureInfo(opcionIdioma)))

            labelSkinOpcion1.Content = recursos.GetString("customTheme", New CultureInfo(opcionIdioma))
            Modulos.VisibilidadOpcion(listaThemes, gridSkinOpcion1, comboBoxSkinOpcion1)

            Dim listaColores As List(Of String) = New List(Of String)

            listaColores.Add(recursos.GetString("colorSky", New CultureInfo(opcionIdioma)))
            listaColores.Add(recursos.GetString("colorSea", New CultureInfo(opcionIdioma)))
            listaColores.Add(recursos.GetString("colorBreeze", New CultureInfo(opcionIdioma)))
            listaColores.Add(recursos.GetString("colorSlate", New CultureInfo(opcionIdioma)))
            listaColores.Add(recursos.GetString("colorTruffle", New CultureInfo(opcionIdioma)))
            listaColores.Add(recursos.GetString("colorGunmetal", New CultureInfo(opcionIdioma)))
            listaColores.Add(recursos.GetString("colorSilver", New CultureInfo(opcionIdioma)))
            listaColores.Add(recursos.GetString("colorGrass", New CultureInfo(opcionIdioma)))
            listaColores.Add(recursos.GetString("colorRose", New CultureInfo(opcionIdioma)))
            listaColores.Add(recursos.GetString("colorCinnabar", New CultureInfo(opcionIdioma)))
            listaColores.Add(recursos.GetString("colorLavender", New CultureInfo(opcionIdioma)))
            listaColores.Add(recursos.GetString("colorLilac", New CultureInfo(opcionIdioma)))
            listaColores.Add(recursos.GetString("colorDeeppurple", New CultureInfo(opcionIdioma)))
            listaColores.Add(recursos.GetString("colorSteamblue", New CultureInfo(opcionIdioma)))
            listaColores.Add(recursos.GetString("colorYoutubered", New CultureInfo(opcionIdioma)))
            listaColores.Sort()

            labelSkinOpcion2.Content = recursos.GetString("customColor", New CultureInfo(opcionIdioma))
            Modulos.VisibilidadOpcion(listaColores, gridSkinOpcion2, comboBoxSkinOpcion2)

            PreCargaInstallButton("Air-for-Steam-master", "air", "Air", listaImagenes, "http://airforsteam.com", Nothing, "http://www.patreon.com/inhibitor")

        ElseIf seleccion = "Air Classic" Then

            labelAutor.Content = "Inhibitor"

            Dim listaImagenes As List(Of String) = New List(Of String)

            listaImagenes.Add("Imagenes/Air Classic/airclassic1.png")
            listaImagenes.Add("Imagenes/Air Classic/airclassic2.png")
            listaImagenes.Add("Imagenes/Air Classic/airclassic3.png")
            listaImagenes.Add("Imagenes/Air Classic/airclassic4.png")

            gridSkinOpciones.Visibility = Visibility.Visible

            Dim listaColores As List(Of String) = New List(Of String)

            listaColores.Add(recursos.GetString("colorBlue", New CultureInfo(opcionIdioma)))
            listaColores.Add(recursos.GetString("colorBubblegum", New CultureInfo(opcionIdioma)))
            listaColores.Add(recursos.GetString("colorCinnamon", New CultureInfo(opcionIdioma)))
            listaColores.Add(recursos.GetString("colorGreen", New CultureInfo(opcionIdioma)))
            listaColores.Add(recursos.GetString("colorHappyOrange", New CultureInfo(opcionIdioma)))
            listaColores.Add(recursos.GetString("colorNavy", New CultureInfo(opcionIdioma)))
            listaColores.Add(recursos.GetString("colorNight", New CultureInfo(opcionIdioma)))
            listaColores.Add(recursos.GetString("colorOrange", New CultureInfo(opcionIdioma)))
            listaColores.Add(recursos.GetString("colorPadawan", New CultureInfo(opcionIdioma)))
            listaColores.Add(recursos.GetString("colorRoyal", New CultureInfo(opcionIdioma)))
            listaColores.Add(recursos.GetString("colorSilver", New CultureInfo(opcionIdioma)))
            listaColores.Add(recursos.GetString("colorTeal", New CultureInfo(opcionIdioma)))
            listaColores.Add(recursos.GetString("colorWatermelon", New CultureInfo(opcionIdioma)))
            listaColores.Sort()

            labelSkinOpcion1.Content = recursos.GetString("customColor", New CultureInfo(opcionIdioma))
            Modulos.VisibilidadOpcion(listaColores, gridSkinOpcion1, comboBoxSkinOpcion1)

            Dim listaBackgrounds As List(Of String) = New List(Of String)

            listaBackgrounds.Add(recursos.GetString("backgroundNone", New CultureInfo(opcionIdioma)))
            listaBackgrounds.Add(recursos.GetString("backgroundNoise", New CultureInfo(opcionIdioma)))
            listaBackgrounds.Add(recursos.GetString("backgroundDots", New CultureInfo(opcionIdioma)))
            listaBackgrounds.Add(recursos.GetString("backgroundRibbon", New CultureInfo(opcionIdioma)))

            labelSkinOpcion2.Content = recursos.GetString("customBackground", New CultureInfo(opcionIdioma))
            Modulos.VisibilidadOpcion(listaBackgrounds, gridSkinOpcion2, comboBoxSkinOpcion2)

            PreCargaInstallButton("Air-Classic-master", "airclassic", "Air Classic", listaImagenes, "http://airforsteam.com", Nothing, "http://www.patreon.com/inhibitor")

        ElseIf seleccion = "Black Rock Shooter" Then

            labelAutor.Content = "uGuardian"

            Dim listaImagenes As List(Of String) = New List(Of String)

            listaImagenes.Add("Imagenes/Black Rock Shooter/blackrock1.png")
            listaImagenes.Add("Imagenes/Black Rock Shooter/blackrock2.png")
            listaImagenes.Add("Imagenes/Black Rock Shooter/blackrock3.png")
            listaImagenes.Add("Imagenes/Black Rock Shooter/blackrock4.png")

            gridSkinOpciones.Visibility = Visibility.Collapsed

            PreCargaInstallButton("Black Rock Shooter theme", "blackrock", "Black Rock Shooter", listaImagenes, "http://steam.gamebanana.com/guis/30778", Nothing, Nothing)

        ElseIf seleccion = "Blue Pulse" Then

            labelAutor.Content = "Asp"

            Dim listaImagenes As List(Of String) = New List(Of String)

            listaImagenes.Add("Imagenes/Blue Pulse/bluepulse1.png")
            listaImagenes.Add("Imagenes/Blue Pulse/bluepulse2.png")
            listaImagenes.Add("Imagenes/Blue Pulse/bluepulse3.png")
            listaImagenes.Add("Imagenes/Blue Pulse/bluepulse4.png")

            gridSkinOpciones.Visibility = Visibility.Collapsed

            PreCargaInstallButton("Blue Pulse", "blue pulse", "Blue Pulse", listaImagenes, "http://steamcommunity.com/groups/DigitallyUnmastered", Nothing, Nothing)

        ElseIf seleccion = "Compact" Then

            labelAutor.Content = "sequestrum"

            Dim listaImagenes As List(Of String) = New List(Of String)

            listaImagenes.Add("Imagenes/Compact/compact1.png")
            listaImagenes.Add("Imagenes/Compact/compact2.png")
            listaImagenes.Add("Imagenes/Compact/compact3.png")
            listaImagenes.Add("Imagenes/Compact/compact4.png")

            gridSkinOpciones.Visibility = Visibility.Collapsed

            PreCargaInstallButton("Compact-master\Steam\skins\Compact", "compact", "Compact", listaImagenes, "http://steamcommunity.com/groups/SteamCompact", Nothing, Nothing)

        ElseIf seleccion = "Invert" Then

            labelAutor.Content = "Ultimate Luki"

            Dim listaImagenes As List(Of String) = New List(Of String)

            listaImagenes.Add("Imagenes/Invert/invert1.png")
            listaImagenes.Add("Imagenes/Invert/invert2.png")
            listaImagenes.Add("Imagenes/Invert/invert3.png")
            listaImagenes.Add("Imagenes/Invert/invert4.png")

            gridSkinOpciones.Visibility = Visibility.Collapsed

            PreCargaInstallButton("Invert", "invert", "Invert", listaImagenes, "http://steam.gamebanana.com/guis/28814", "https://www.paypal.com/sk/cgi-bin/webscr?cmd=_flow&SESSION=MPUQPttbWm_uZiZcBQNxLAl29APMCE23ftbSIYZ05i2lgDG0q8s9iyITuxW&dispatch=5885d80a13c0db1f8e263663d3faee8d6625bf1e8bd269586d425cc639e26c6a", Nothing)

        ElseIf seleccion = "Metro" Then

            labelAutor.Content = "Dominic Minischetti III"

            Dim listaImagenes As List(Of String) = New List(Of String)

            listaImagenes.Add("Imagenes/Metro/metro1.png")
            listaImagenes.Add("Imagenes/Metro/metro2.png")
            listaImagenes.Add("Imagenes/Metro/metro3.png")
            listaImagenes.Add("Imagenes/Metro/metro4.png")

            gridSkinOpciones.Visibility = Visibility.Visible

            Dim listaColores As List(Of String) = New List(Of String)

            listaColores.Add(recursos.GetString("colorGrey", New CultureInfo(opcionIdioma)))
            listaColores.Add(recursos.GetString("colorRose", New CultureInfo(opcionIdioma)))
            listaColores.Add(recursos.GetString("colorViolet", New CultureInfo(opcionIdioma)))
            listaColores.Add(recursos.GetString("colorRed", New CultureInfo(opcionIdioma)))
            listaColores.Add(recursos.GetString("colorOrange", New CultureInfo(opcionIdioma)))
            listaColores.Add(recursos.GetString("colorGreen", New CultureInfo(opcionIdioma)))
            listaColores.Add(recursos.GetString("colorDarkGreen", New CultureInfo(opcionIdioma)))
            listaColores.Add(recursos.GetString("colorViridian", New CultureInfo(opcionIdioma)))
            listaColores.Add(recursos.GetString("colorLightBlue", New CultureInfo(opcionIdioma)))
            listaColores.Add(recursos.GetString("colorRoyalBlue", New CultureInfo(opcionIdioma)))
            listaColores.Add(recursos.GetString("colorDarkBlue", New CultureInfo(opcionIdioma)))
            listaColores.Sort()

            labelSkinOpcion1.Content = recursos.GetString("customColor", New CultureInfo(opcionIdioma))
            Modulos.VisibilidadOpcion(listaColores, gridSkinOpcion1, comboBoxSkinOpcion1)

            PreCargaInstallButton("Metro for Steam", "metro", "Metro", listaImagenes, "http://www.metroforsteam.com", "https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=BDL2J3MEETZ3J&lc=US&item_name=Metro%20for%20Steam&item_number=metroforsteam&currency_code=USD&bn=PP%2dDonationsBF%3abtn_donate_LG%2egif%3aNonHosted", "http://www.patreon.com/dommini")

        ElseIf seleccion = "Minimal" Then

            labelAutor.Content = "Lusito"

            Dim listaImagenes As List(Of String) = New List(Of String)

            listaImagenes.Add("Imagenes/Minimal/mini1.png")
            listaImagenes.Add("Imagenes/Minimal/mini2.png")
            listaImagenes.Add("Imagenes/Minimal/mini3.png")
            listaImagenes.Add("Imagenes/Minimal/mini4.png")

            gridSkinOpciones.Visibility = Visibility.Visible

            Dim listaColores As List(Of String) = New List(Of String)

            listaColores.Add(recursos.GetString("colorBlack", New CultureInfo(opcionIdioma)))
            listaColores.Add(recursos.GetString("colorRed", New CultureInfo(opcionIdioma)))
            listaColores.Add(recursos.GetString("colorGreen", New CultureInfo(opcionIdioma)))
            listaColores.Add(recursos.GetString("colorBlue", New CultureInfo(opcionIdioma)))
            listaColores.Sort()

            labelSkinOpcion1.Content = recursos.GetString("customColor", New CultureInfo(opcionIdioma))
            Modulos.VisibilidadOpcion(listaColores, gridSkinOpcion1, comboBoxSkinOpcion1)

            PreCargaInstallButton("Minimal Steam UI V3", "minimal", "Minimal", listaImagenes, "http://steamcommunity.com/groups/MinimalSteamUI", Nothing, Nothing)

        ElseIf seleccion = "PixelVision²" Then

            labelAutor.Content = "somini"

            Dim listaImagenes As List(Of String) = New List(Of String)

            listaImagenes.Add("Imagenes/PixelVision2/pixel1.png")
            listaImagenes.Add("Imagenes/PixelVision2/pixel2.png")
            listaImagenes.Add("Imagenes/PixelVision2/pixel3.png")
            listaImagenes.Add("Imagenes/PixelVision2/pixel4.png")

            gridSkinOpciones.Visibility = Visibility.Collapsed

            PreCargaInstallButton("Pixelvision2-master", "pixel2", "PixelVision²", listaImagenes, "http://steamcommunity.com/groups/pixelvision2", Nothing, Nothing)

        ElseIf seleccion = "Plexed" Then

            labelAutor.Content = "Fusionfan45"

            Dim listaImagenes As List(Of String) = New List(Of String)

            listaImagenes.Add("Imagenes/Plexed/plexed1.png")
            listaImagenes.Add("Imagenes/Plexed/plexed2.png")
            listaImagenes.Add("Imagenes/Plexed/plexed3.png")
            listaImagenes.Add("Imagenes/Plexed/plexed4.png")

            gridSkinOpciones.Visibility = Visibility.Collapsed

            PreCargaInstallButton("Plexed", "plexed", "Plexed", listaImagenes, "http://steam.gamebanana.com/guis/30097", Nothing, Nothing)

        ElseIf seleccion = "Pressure²" Then

            labelAutor.Content = "Dirt Diglett"

            Dim listaImagenes As List(Of String) = New List(Of String)

            listaImagenes.Add("Imagenes/Pressure2/pre1.png")
            listaImagenes.Add("Imagenes/Pressure2/pre2.png")
            listaImagenes.Add("Imagenes/Pressure2/pre3.png")
            listaImagenes.Add("Imagenes/Pressure2/pre4.png")

            gridSkinOpciones.Visibility = Visibility.Collapsed

            PreCargaInstallButton("Pressure2-master", "pre2", "Pressure²", listaImagenes, "http://www.pressureforsteam.com", Nothing, "https://www.patreon.com/dirtdiglett")

        ElseIf seleccion = "Threshold" Then

            labelAutor.Content = "Edgarware"

            Dim listaImagenes As List(Of String) = New List(Of String)

            listaImagenes.Add("Imagenes/Threshold/thr1.png")
            listaImagenes.Add("Imagenes/Threshold/thr2.png")
            listaImagenes.Add("Imagenes/Threshold/thr3.png")
            listaImagenes.Add("Imagenes/Threshold/thr4.png")

            gridSkinOpciones.Visibility = Visibility.Visible

            Dim listaColores As List(Of String) = New List(Of String)

            listaColores.Add(recursos.GetString("colorCobalt", New CultureInfo(opcionIdioma)))
            listaColores.Add(recursos.GetString("colorRed", New CultureInfo(opcionIdioma)))
            listaColores.Add(recursos.GetString("colorGreen", New CultureInfo(opcionIdioma)))
            listaColores.Add(recursos.GetString("colorCyan", New CultureInfo(opcionIdioma)))
            listaColores.Add(recursos.GetString("colorOrange", New CultureInfo(opcionIdioma)))
            listaColores.Add(recursos.GetString("colorPurple", New CultureInfo(opcionIdioma)))
            listaColores.Sort()

            labelSkinOpcion1.Content = recursos.GetString("customColor", New CultureInfo(opcionIdioma))
            Modulos.VisibilidadOpcion(listaColores, gridSkinOpcion1, comboBoxSkinOpcion1)

            Dim listaTitleBar As List(Of String) = New List(Of String)

            listaTitleBar.Add(recursos.GetString("yes", New CultureInfo(opcionIdioma)))
            listaTitleBar.Add(recursos.GetString("no", New CultureInfo(opcionIdioma)))

            labelSkinOpcion2.Content = recursos.GetString("customTitleBar", New CultureInfo(opcionIdioma))
            Modulos.VisibilidadOpcion(listaTitleBar, gridSkinOpcion2, comboBoxSkinOpcion2)

            PreCargaInstallButton("Threshold-Skin-master", "threshold", "Threshold", listaImagenes, "http://steamcommunity.com/groups/thresholdskin", Nothing, Nothing)

        End If

    End Sub

    Private Sub PreCargaInstallButton(carpeta As String, zip As String, titulo As String, listaImagenes As List(Of String), web As String, paypal As String, patreon As String)

        skinCarpeta = carpeta
        skinZip = zip
        skinTitulo = titulo
        skinSeleccionPosicion = comboBoxSkins.SelectedIndex.ToString

        textBoxSkinSeleccionada.Text = skinTitulo
        labelProgreso.Content = Nothing

        skinWebButton.ToolTip = web

        If Not paypal = Nothing Then
            skinDonarPaypalButton.ToolTip = paypal
            skinDonarPaypalButton.Visibility = Visibility.Visible
        Else
            skinDonarPaypalButton.Visibility = Visibility.Collapsed
        End If

        If Not patreon = Nothing Then
            skinDonarPatreonButton.ToolTip = patreon
            skinDonarPatreonButton.Visibility = Visibility.Visible
        Else
            skinDonarPatreonButton.Visibility = Visibility.Collapsed
        End If

        If skinDonarPaypalButton.Visibility = Visibility.Collapsed And skinDonarPatreonButton.Visibility = Visibility.Collapsed Then
            gridDonar.Visibility = Visibility.Collapsed
        Else
            gridDonar.Visibility = Visibility.Visible
        End If

        Dim i As Integer = 0
        While i < 4
            If Not listaImagenes(0) = Nothing Then
                Modulos.VisibilidadImagen(buttonImagePreview1, imagePreview1, listaImagenes(0))
            End If

            If i < listaImagenes.Count Then
                If i = 1 Then
                    Modulos.VisibilidadImagen(buttonImagePreview2, imagePreview2, listaImagenes(i))
                ElseIf i = 2 Then
                    Modulos.VisibilidadImagen(buttonImagePreview3, imagePreview3, listaImagenes(i))
                ElseIf i = 3 Then
                    Modulos.VisibilidadImagen(buttonImagePreview4, imagePreview4, listaImagenes(i))
                End If
            Else
                If i = 1 Then
                    Modulos.VisibilidadImagen(buttonImagePreview2, imagePreview2, Nothing)
                ElseIf i = 2 Then
                    Modulos.VisibilidadImagen(buttonImagePreview3, imagePreview3, Nothing)
                ElseIf i = 3 Then
                    Modulos.VisibilidadImagen(buttonImagePreview4, imagePreview4, Nothing)
                End If
            End If

            i += 1
        End While

        If Not skinTitulo = "Default" Then
            Dim tempTitulo As String = skinTitulo

            tempTitulo = tempTitulo.Replace("²", "2")

            If Directory.Exists(rutaSteam + "\skins\" + tempTitulo) Then
                skinInstallButton.Content = recursos.GetString("skinInstallButtonAgain", New CultureInfo(opcionIdioma))
            Else
                skinInstallButton.Content = recursos.GetString("skinInstallButton", New CultureInfo(opcionIdioma))
            End If
        Else
            skinInstallButton.Content = recursos.GetString("skinInstallButton", New CultureInfo(opcionIdioma))
        End If

        If Not skinTitulo = "Default" Then
            If Directory.Exists(rutaSteam + "\skins\" + skinTitulo) Then
                If File.Exists(rutaSteam + "\skins\" + skinTitulo + "\SteamSkins.ini") Then
                    versionSkinInstalada = FicherosINI.Leer(rutaSteam + "\skins\" + skinTitulo + "\SteamSkins.ini", "Data", "Version")

                    comboBoxSkinOpcion1.SelectedItem = FicherosINI.Leer(rutaSteam + "\skins\" + skinTitulo + "\SteamSkins.ini", "Options", "Option1_Selection")
                    comboBoxSkinOpcion2.SelectedItem = FicherosINI.Leer(rutaSteam + "\skins\" + skinTitulo + "\SteamSkins.ini", "Options", "Option2_Selection")
                    comboBoxSkinOpcion3.SelectedItem = FicherosINI.Leer(rutaSteam + "\skins\" + skinTitulo + "\SteamSkins.ini", "Options", "Option3_Selection")
                    comboBoxSkinOpcion4.SelectedItem = FicherosINI.Leer(rutaSteam + "\skins\" + skinTitulo + "\SteamSkins.ini", "Options", "Option4_Selection")
                    comboBoxSkinOpcion5.SelectedItem = FicherosINI.Leer(rutaSteam + "\skins\" + skinTitulo + "\SteamSkins.ini", "Options", "Option5_Selection")
                    comboBoxSkinOpcion6.SelectedItem = FicherosINI.Leer(rutaSteam + "\skins\" + skinTitulo + "\SteamSkins.ini", "Options", "Option6_Selection")
                    comboBoxSkinOpcion7.SelectedItem = FicherosINI.Leer(rutaSteam + "\skins\" + skinTitulo + "\SteamSkins.ini", "Options", "Option7_Selection")
                    comboBoxSkinOpcion8.SelectedItem = FicherosINI.Leer(rutaSteam + "\skins\" + skinTitulo + "\SteamSkins.ini", "Options", "Option8_Selection")
                    comboBoxSkinOpcion9.SelectedItem = FicherosINI.Leer(rutaSteam + "\skins\" + skinTitulo + "\SteamSkins.ini", "Options", "Option9_Selection")

                    labelProgreso.Content = recursos.GetString("checkingLastVersion", New CultureInfo(opcionIdioma))
                    ControlesEstado(False)

                    workerVersiones.RunWorkerAsync()
                End If
            End If
        End If

    End Sub

    Private Sub skinInstallButton_Click(sender As Object, e As RoutedEventArgs) Handles skinInstallButton.Click

        skinOpcion1 = labelSkinOpcion1.Content
        skinOpcion2 = labelSkinOpcion2.Content
        skinOpcion3 = labelSkinOpcion3.Content
        skinOpcion4 = labelSkinOpcion4.Content
        skinOpcion5 = labelSkinOpcion5.Content
        skinOpcion6 = labelSkinOpcion6.Content
        skinOpcion7 = labelSkinOpcion7.Content
        skinOpcion8 = labelSkinOpcion8.Content
        skinOpcion9 = labelSkinOpcion9.Content

        skinOpcionSeleccion1 = Modulos.CogerSeleccion(gridSkinOpcion1, comboBoxSkinOpcion1)
        skinOpcionSeleccion2 = Modulos.CogerSeleccion(gridSkinOpcion2, comboBoxSkinOpcion2)
        skinOpcionSeleccion3 = Modulos.CogerSeleccion(gridSkinOpcion3, comboBoxSkinOpcion3)
        skinOpcionSeleccion4 = Modulos.CogerSeleccion(gridSkinOpcion4, comboBoxSkinOpcion4)
        skinOpcionSeleccion5 = Modulos.CogerSeleccion(gridSkinOpcion5, comboBoxSkinOpcion5)
        skinOpcionSeleccion6 = Modulos.CogerSeleccion(gridSkinOpcion6, comboBoxSkinOpcion6)
        skinOpcionSeleccion7 = Modulos.CogerSeleccion(gridSkinOpcion7, comboBoxSkinOpcion7)
        skinOpcionSeleccion8 = Modulos.CogerSeleccion(gridSkinOpcion8, comboBoxSkinOpcion8)
        skinOpcionSeleccion9 = Modulos.CogerSeleccion(gridSkinOpcion9, comboBoxSkinOpcion9)

        ControlesEstado(False)

        If skinTitulo = "Default" Then
            workerDefault.WorkerReportsProgress = True
            workerDefault.RunWorkerAsync()
        Else
            workerDescarga.WorkerReportsProgress = True
            workerDescarga.RunWorkerAsync()
        End If

    End Sub

    'DESCARGA SKINS-------------------------------------------------------------------------

    Dim WithEvents workerDescarga As New BackgroundWorker

    Private Sub workerDescarga_DoWork(sender As Object, e As DoWorkEventArgs) Handles workerDescarga.DoWork

        workerDescarga.ReportProgress(0, recursos.GetString("searchingDownload", New CultureInfo(opcionIdioma)))

        skinUrlDescarga = UrlDescargas.Generar(skinTitulo)

        Try
            If Directory.Exists(rutaSteam + "\skins\" + skinZip) Then
                Directory.Delete(rutaSteam + "\skins\" + skinZip, True)
            End If

            If Directory.Exists(My.Application.Info.DirectoryPath + "\Temp") Then
                Directory.Delete(My.Application.Info.DirectoryPath + "\Temp", True)
            End If

            Directory.CreateDirectory(My.Application.Info.DirectoryPath + "\Temp")
        Catch ex As Exception

        End Try

        Dim theResponse As HttpWebResponse = Nothing
        Dim theRequest As HttpWebRequest = Nothing
        Dim length As Long = -1

        Try
            If Not skinUrlDescarga = Nothing Then
                Dim i As Integer = 0
                While i < 10
                    theRequest = WebRequest.Create(skinUrlDescarga)
                    theResponse = theRequest.GetResponse
                    length = theResponse.ContentLength

                    If Not length = -1 Then
                        i = 10
                    End If
                    i += 1
                End While
            Else
                workerDescarga.ReportProgress(0, recursos.GetString("errorConnecting", New CultureInfo(opcionIdioma)))
            End If
        Catch ex As Exception
            workerDescarga.ReportProgress(0, recursos.GetString("errorConnecting", New CultureInfo(opcionIdioma)))
        End Try

        If Not length = -1 Then
            Dim writeStream As New FileStream(My.Application.Info.DirectoryPath + "\Temp\" + skinZip + ".zip", FileMode.Create)
            Dim nRead As Integer

            Dim speedtimer As New Stopwatch
            Dim currentspeed As Double = -1
            Dim readings As Integer = 0

            Try
                Do
                    speedtimer.Start()

                    Dim readBytes(4095) As Byte
                    Dim bytesread As Integer = theResponse.GetResponseStream.Read(readBytes, 0, 4096)
                    nRead += bytesread
                    Dim percent As Short = (nRead * 100) / length

                    workerDescarga.ReportProgress(percent, recursos.GetString("progressDownload", New CultureInfo(opcionIdioma)) + " " + percent.ToString + "%")

                    If bytesread = 0 Then
                        Exit Do
                    End If

                    writeStream.Write(readBytes, 0, bytesread)

                    speedtimer.Stop()

                    readings += 1
                    If readings >= 5 Then
                        currentspeed = 20480 / (speedtimer.ElapsedMilliseconds / 1000)

                        speedtimer.Reset()
                        readings = 0
                    End If
                Loop
            Catch ex As Exception
                workerDescarga.ReportProgress(0, recursos.GetString("errorDownloadingFile", New CultureInfo(opcionIdioma)))
            End Try

            theResponse.GetResponseStream.Close()
            writeStream.Close()
        Else
            workerDescarga.ReportProgress(0, recursos.GetString("errorStartingDownload", New CultureInfo(opcionIdioma)))
        End If

        If File.Exists(My.Application.Info.DirectoryPath + "\Temp\" + skinZip + ".zip") Then

            workerDescarga.ReportProgress(0, recursos.GetString("extractingFiles", New CultureInfo(opcionIdioma)))

            ZipFile.ExtractToDirectory(My.Application.Info.DirectoryPath + "\Temp\" + skinZip + ".zip", My.Application.Info.DirectoryPath + "\Temp\" + skinZip)

            If skinZip = "plexed" Or skinZip = "blue pulse" Then
                For Each carpeta As String In Directory.GetDirectories(My.Application.Info.DirectoryPath + "\Temp\" + skinZip)
                    Directory.Move(carpeta, My.Application.Info.DirectoryPath + "\Temp\" + skinZip + "\" + skinZip)
                Next
            End If

            Try
                workerDescarga.ReportProgress(0, recursos.GetString("movingFiles", New CultureInfo(opcionIdioma)))

                Dim arrancarSteam As Boolean = True

                'FUENTES---------------------------------------------------

                If skinZip = "metro" Then
                    If Not File.Exists(GetFolderPath(SpecialFolder.Fonts) + "\segoeuisl.ttf") Then
                        Directory.CreateDirectory(My.Application.Info.DirectoryPath + "\Temp\" + recursos.GetString("fontsFolder", New CultureInfo(opcionIdioma)) + "\")
                        Modulos.CrearFicheroInstrucciones(opcionIdioma, recursos)

                        File.Copy(My.Application.Info.DirectoryPath + "\Temp\" + skinZip + "\INSTALL THIS FONT (WINDOWS 7 AND OLDER)\segoeuisl.ttf", My.Application.Info.DirectoryPath + "\Temp\" + recursos.GetString("fontsFolder", New CultureInfo(opcionIdioma)) + "\segoeuisl.ttf")

                        Process.Start(My.Application.Info.DirectoryPath + "\Temp\" + recursos.GetString("fontsFolder", New CultureInfo(opcionIdioma)) + "\")
                        arrancarSteam = False
                    End If
                End If

                If skinZip = "pre2" Then
                    If Not File.Exists(GetFolderPath(SpecialFolder.Fonts) + "\Roboto.TTF") Then
                        Directory.CreateDirectory(My.Application.Info.DirectoryPath + "\Temp\" + recursos.GetString("fontsFolder", New CultureInfo(opcionIdioma)) + "\")
                        Modulos.CrearFicheroInstrucciones(opcionIdioma, recursos)

                        File.Copy(My.Application.Info.DirectoryPath + "\Temp\" + skinZip + "\" + skinCarpeta + "\fonts\Roboto Bold Italic.TTF", My.Application.Info.DirectoryPath + "\Temp\" + recursos.GetString("fontsFolder", New CultureInfo(opcionIdioma)) + "\Roboto Bold Italic.TTF")
                        File.Copy(My.Application.Info.DirectoryPath + "\Temp\" + skinZip + "\" + skinCarpeta + "\fonts\Roboto Bold.TTF", My.Application.Info.DirectoryPath + "\Temp\" + recursos.GetString("fontsFolder", New CultureInfo(opcionIdioma)) + "\Roboto Bold.TTF")
                        File.Copy(My.Application.Info.DirectoryPath + "\Temp\" + skinZip + "\" + skinCarpeta + "\fonts\Roboto Italic.TTF", My.Application.Info.DirectoryPath + "\Temp\" + recursos.GetString("fontsFolder", New CultureInfo(opcionIdioma)) + "\Roboto Italic.TTF")
                        File.Copy(My.Application.Info.DirectoryPath + "\Temp\" + skinZip + "\" + skinCarpeta + "\fonts\Roboto Medium Italic.TTF", My.Application.Info.DirectoryPath + "\Temp\" + recursos.GetString("fontsFolder", New CultureInfo(opcionIdioma)) + "\Roboto Medium Italic.TTF")
                        File.Copy(My.Application.Info.DirectoryPath + "\Temp\" + skinZip + "\" + skinCarpeta + "\fonts\Roboto Medium.TTF", My.Application.Info.DirectoryPath + "\Temp\" + recursos.GetString("fontsFolder", New CultureInfo(opcionIdioma)) + "\Roboto Medium.TTF")
                        File.Copy(My.Application.Info.DirectoryPath + "\Temp\" + skinZip + "\" + skinCarpeta + "\fonts\Roboto.TTF", My.Application.Info.DirectoryPath + "\Temp\" + recursos.GetString("fontsFolder", New CultureInfo(opcionIdioma)) + "\Roboto.TTF")

                        Process.Start(My.Application.Info.DirectoryPath + "\Temp\" + recursos.GetString("fontsFolder", New CultureInfo(opcionIdioma)) + "\")
                        arrancarSteam = False
                    End If
                End If

                'MOVER---------------------------------------------------

                skinTitulo = skinTitulo.Replace("²", "2")

                If Directory.Exists(rutaSteam + "\skins\" + skinTitulo) Then
                    Directory.Delete(rutaSteam + "\skins\" + skinTitulo, True)
                End If

                My.Computer.FileSystem.MoveDirectory(My.Application.Info.DirectoryPath + "\Temp\" + skinZip + "\" + skinCarpeta, rutaSteam + "\skins\" + skinTitulo)

                Modulos.CrearFicheroSkin(rutaSteam + "\skins\" + skinTitulo)

                Dim version As String = Versiones.Generar(skinTitulo)

                If Not version = Nothing Then
                    FicherosINI.Escribir(rutaSteam + "\skins\" + skinTitulo + "\SteamSkins.ini", "Data", "Version", version)
                End If

                FicherosINI.Escribir(rutaSteam + "\skins\" + skinTitulo + "\SteamSkins.ini", "Data", "Zip", skinZip)
                FicherosINI.Escribir(rutaSteam + "\skins\" + skinTitulo + "\SteamSkins.ini", "Data", "Folder", skinCarpeta)
                FicherosINI.Escribir(rutaSteam + "\skins\" + skinTitulo + "\SteamSkins.ini", "Data", "Title", skinTitulo)
                FicherosINI.Escribir(rutaSteam + "\skins\" + skinTitulo + "\SteamSkins.ini", "Data", "Code", skinSeleccionPosicion)

                If Not skinOpcionSeleccion1 = Nothing Then
                    Opciones.Filtrar(skinOpcion1, rutaSteam, skinZip, skinTitulo, skinOpcionSeleccion1, opcionIdioma, recursos)
                    FicherosINI.Escribir(rutaSteam + "\skins\" + skinTitulo + "\SteamSkins.ini", "Options", "Option1_Label", skinOpcion1)
                    FicherosINI.Escribir(rutaSteam + "\skins\" + skinTitulo + "\SteamSkins.ini", "Options", "Option1_Selection", skinOpcionSeleccion1)
                End If

                If Not skinOpcionSeleccion2 = Nothing Then
                    Opciones.Filtrar(skinOpcion2, rutaSteam, skinZip, skinTitulo, skinOpcionSeleccion2, opcionIdioma, recursos)
                    FicherosINI.Escribir(rutaSteam + "\skins\" + skinTitulo + "\SteamSkins.ini", "Options", "Option2_Label", skinOpcion2)
                    FicherosINI.Escribir(rutaSteam + "\skins\" + skinTitulo + "\SteamSkins.ini", "Options", "Option2_Selection", skinOpcionSeleccion2)
                End If

                If Not skinOpcionSeleccion3 = Nothing Then
                    Opciones.Filtrar(skinOpcion3, rutaSteam, skinZip, skinTitulo, skinOpcionSeleccion3, opcionIdioma, recursos)
                    FicherosINI.Escribir(rutaSteam + "\skins\" + skinTitulo + "\SteamSkins.ini", "Options", "Option3_Label", skinOpcion3)
                    FicherosINI.Escribir(rutaSteam + "\skins\" + skinTitulo + "\SteamSkins.ini", "Options", "Option3_Selection", skinOpcionSeleccion3)
                End If

                If Not skinOpcionSeleccion4 = Nothing Then
                    Opciones.Filtrar(skinOpcion4, rutaSteam, skinZip, skinTitulo, skinOpcionSeleccion4, opcionIdioma, recursos)
                    FicherosINI.Escribir(rutaSteam + "\skins\" + skinTitulo + "\SteamSkins.ini", "Options", "Option4_Label", skinOpcion4)
                    FicherosINI.Escribir(rutaSteam + "\skins\" + skinTitulo + "\SteamSkins.ini", "Options", "Option4_Selection", skinOpcionSeleccion4)
                End If

                If Not skinOpcionSeleccion5 = Nothing Then
                    Opciones.Filtrar(skinOpcion5, rutaSteam, skinZip, skinTitulo, skinOpcionSeleccion5, opcionIdioma, recursos)
                    FicherosINI.Escribir(rutaSteam + "\skins\" + skinTitulo + "\SteamSkins.ini", "Options", "Option5_Label", skinOpcion5)
                    FicherosINI.Escribir(rutaSteam + "\skins\" + skinTitulo + "\SteamSkins.ini", "Options", "Option5_Selection", skinOpcionSeleccion5)
                End If

                If Not skinOpcionSeleccion6 = Nothing Then
                    Opciones.Filtrar(skinOpcion6, rutaSteam, skinZip, skinTitulo, skinOpcionSeleccion6, opcionIdioma, recursos)
                    FicherosINI.Escribir(rutaSteam + "\skins\" + skinTitulo + "\SteamSkins.ini", "Options", "Option6_Label", skinOpcion6)
                    FicherosINI.Escribir(rutaSteam + "\skins\" + skinTitulo + "\SteamSkins.ini", "Options", "Option6_Selection", skinOpcionSeleccion6)
                End If

                If Not skinOpcionSeleccion7 = Nothing Then
                    Opciones.Filtrar(skinOpcion7, rutaSteam, skinZip, skinTitulo, skinOpcionSeleccion7, opcionIdioma, recursos)
                    FicherosINI.Escribir(rutaSteam + "\skins\" + skinTitulo + "\SteamSkins.ini", "Options", "Option7_Label", skinOpcion7)
                    FicherosINI.Escribir(rutaSteam + "\skins\" + skinTitulo + "\SteamSkins.ini", "Options", "Option7_Selection", skinOpcionSeleccion7)
                End If

                If Not skinOpcionSeleccion8 = Nothing Then
                    Opciones.Filtrar(skinOpcion8, rutaSteam, skinZip, skinTitulo, skinOpcionSeleccion8, opcionIdioma, recursos)
                    FicherosINI.Escribir(rutaSteam + "\skins\" + skinTitulo + "\SteamSkins.ini", "Options", "Option8_Label", skinOpcion8)
                    FicherosINI.Escribir(rutaSteam + "\skins\" + skinTitulo + "\SteamSkins.ini", "Options", "Option8_Selection", skinOpcionSeleccion8)
                End If

                If Not skinOpcionSeleccion9 = Nothing Then
                    Opciones.Filtrar(skinOpcion9, rutaSteam, skinZip, skinTitulo, skinOpcionSeleccion9, opcionIdioma, recursos)
                    FicherosINI.Escribir(rutaSteam + "\skins\" + skinTitulo + "\SteamSkins.ini", "Options", "Option9_Label", skinOpcion6)
                    FicherosINI.Escribir(rutaSteam + "\skins\" + skinTitulo + "\SteamSkins.ini", "Options", "Option9_Selection", skinOpcionSeleccion6)
                End If

                'REGISTRO---------------------------------------------------

                Try
                    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Valve\Steam", "SkinV4", skinTitulo)
                Catch ex3 As Exception
                    workerDescarga.ReportProgress(0, recursos.GetString("errorRegistryWindows", New CultureInfo(opcionIdioma)))
                End Try

                'PROCESO---------------------------------------------------

                If arrancarSteam = True Then
                    Dim i As Integer = 0

                    While i < 100
                        Dim tempProc() As Process = Process.GetProcessesByName("Steam")

                        If tempProc.Count = 0 Then
                            workerDescarga.ReportProgress(0, recursos.GetString("startingSteam", New CultureInfo(opcionIdioma)))
                            Process.Start(rutaSteam + "\steam.exe")
                            Exit While
                        Else
                            Try
                                Process.GetProcessesByName("Steam")(0).Kill()
                            Catch ex As Exception

                            End Try
                        End If
                        i += 1
                    End While
                Else
                    Try
                        Process.GetProcessesByName("Steam")(0).Kill()
                    Catch ex As Exception

                    End Try
                End If

                workerDescarga.ReportProgress(0, recursos.GetString("skinInstalled", New CultureInfo(opcionIdioma)))
            Catch ex2 As Exception
                workerDescarga.ReportProgress(0, recursos.GetString("errorMovingFiles", New CultureInfo(opcionIdioma)))
            End Try
        Else
            workerDescarga.ReportProgress(0, recursos.GetString("errorExtractingFiles", New CultureInfo(opcionIdioma)))
        End If

        Try
            If Directory.Exists(My.Application.Info.DirectoryPath + "\Temp") Then
                Directory.Delete(My.Application.Info.DirectoryPath + "\Temp", True)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub workerDescarga_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles workerDescarga.RunWorkerCompleted

        ControlesEstado(True)
        ControlesEstadoSkins()
        skinInstallButton.Content = recursos.GetString("skinInstallButtonAgain", New CultureInfo(opcionIdioma))

    End Sub

    Private Sub workerDescarga_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles workerDescarga.ProgressChanged

        If Not e.ProgressPercentage = 0 Then
            progressBarProgreso.Visibility = Visibility.Visible
            progressBarProgreso.Value = e.ProgressPercentage
        Else
            progressBarProgreso.Visibility = Visibility.Collapsed
        End If

        labelProgreso.Content = e.UserState.ToString

        If e.UserState.ToString = recursos.GetString("skinInstalled", New CultureInfo(opcionIdioma)) Then
            Dim notifyIcon As New TaskbarIcon
            notifyIcon.ShowBalloonTip(recursos.GetString("skinInstalled", New CultureInfo(opcionIdioma)), "Steam Skins", BalloonIcon.Info)
            notifyIcon.Dispose()
        End If

    End Sub

    'IMAGENES-------------------------------------------------------------------------

    Private Sub buttonImagePreview1_Click(sender As Object, e As RoutedEventArgs) Handles buttonImagePreview1.Click

        Modulos.ImagenExpandir(columnImage1, imagePreview1)
        Modulos.ImagenReducir(columnImage2, imagePreview2)
        Modulos.ImagenReducir(columnImage3, imagePreview3)
        Modulos.ImagenReducir(columnImage4, imagePreview4)

    End Sub

    Private Sub buttonImagePreview2_Click(sender As Object, e As RoutedEventArgs) Handles buttonImagePreview2.Click

        Modulos.ImagenReducir(columnImage1, imagePreview1)
        Modulos.ImagenExpandir(columnImage2, imagePreview2)
        Modulos.ImagenReducir(columnImage3, imagePreview3)
        Modulos.ImagenReducir(columnImage4, imagePreview4)

    End Sub

    Private Sub buttonImagePreview3_Click(sender As Object, e As RoutedEventArgs) Handles buttonImagePreview3.Click

        Modulos.ImagenReducir(columnImage1, imagePreview1)
        Modulos.ImagenReducir(columnImage2, imagePreview2)
        Modulos.ImagenExpandir(columnImage3, imagePreview3)
        Modulos.ImagenReducir(columnImage4, imagePreview4)

    End Sub

    Private Sub buttonImagePreview4_Click(sender As Object, e As RoutedEventArgs) Handles buttonImagePreview4.Click

        Modulos.ImagenReducir(columnImage1, imagePreview1)
        Modulos.ImagenReducir(columnImage2, imagePreview2)
        Modulos.ImagenReducir(columnImage3, imagePreview3)
        Modulos.ImagenExpandir(columnImage4, imagePreview4)

    End Sub

    Private Sub buttonBarraSuperiorVolver_Click(sender As Object, e As RoutedEventArgs) Handles buttonBarraSuperiorVolver.Click

        gridBarraSuperior.Visibility = Visibility.Visible
        gridPrincipal.Visibility = Visibility.Visible
        menuOptions.Visibility = Visibility.Visible

        gridPrincipalScreenshot.Visibility = Visibility.Collapsed

    End Sub

    Private Sub buttonImagePreview1_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs) Handles buttonImagePreview1.MouseDoubleClick

        OcultarMenusScreenshot()
        Dim brush As ImageBrush = buttonImagePreview1.Background
        imageScreenshotAmpliada.Source = brush.ImageSource

    End Sub

    Private Sub buttonImagePreview2_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs) Handles buttonImagePreview2.MouseDoubleClick

        OcultarMenusScreenshot()
        Dim brush As ImageBrush = buttonImagePreview2.Background
        imageScreenshotAmpliada.Source = brush.ImageSource

    End Sub

    Private Sub buttonImagePreview3_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs) Handles buttonImagePreview3.MouseDoubleClick

        OcultarMenusScreenshot()
        Dim brush As ImageBrush = buttonImagePreview3.Background
        imageScreenshotAmpliada.Source = brush.ImageSource

    End Sub

    Private Sub buttonImagePreview4_MouseDoubleClick(sender As Object, e As MouseButtonEventArgs) Handles buttonImagePreview4.MouseDoubleClick

        OcultarMenusScreenshot()
        Dim brush As ImageBrush = buttonImagePreview4.Background
        imageScreenshotAmpliada.Source = brush.ImageSource

    End Sub

    Private Sub OcultarMenusScreenshot()

        gridBarraSuperior.Visibility = Visibility.Collapsed
        gridPrincipal.Visibility = Visibility.Collapsed
        menuOptions.Visibility = Visibility.Collapsed

        gridPrincipalScreenshot.Visibility = Visibility.Visible

    End Sub

    'SKIN AUTOR-------------------------------------------------------------------------

    Private Sub skinWebButton_Click(sender As Object, e As RoutedEventArgs) Handles skinWebButton.Click
        Try
            Process.Start(skinWebButton.ToolTip)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub skinDonarPaypalButton_Click(sender As Object, e As RoutedEventArgs) Handles skinDonarPaypalButton.Click
        Try
            Process.Start(skinDonarPaypalButton.ToolTip)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub skinDonarPatreonButton_Click(sender As Object, e As RoutedEventArgs) Handles skinDonarPatreonButton.Click
        Try
            Process.Start(skinDonarPatreonButton.ToolTip)
        Catch ex As Exception

        End Try
    End Sub

    'MENU-------------------------------------------------------------------------

    Private Sub menuOptions_Click(sender As Object, e As RoutedEventArgs) Handles menuOptions.Click

        gridBarraSuperior.Visibility = Visibility.Collapsed
        gridPrincipal.Visibility = Visibility.Collapsed
        menuOptions.Visibility = Visibility.Collapsed

        gridPrincipalOpciones.Visibility = Visibility.Visible

    End Sub

    Private Sub menuContact_Click(sender As Object, e As RoutedEventArgs) Handles menuContact.Click
        Try
            Process.Start("https://steamskinsapp.wordpress.com/contact/")
        Catch ex As Exception

        End Try
    End Sub

    'OPCIONES-------------------------------------------------------------------------

    Private Sub buttonBarraSuperiorVolverOpciones_Click(sender As Object, e As RoutedEventArgs) Handles buttonBarraSuperiorVolverOpciones.Click

        gridBarraSuperior.Visibility = Visibility.Visible
        gridPrincipal.Visibility = Visibility.Visible
        menuOptions.Visibility = Visibility.Visible

        gridPrincipalOpciones.Visibility = Visibility.Collapsed

    End Sub

    Private Sub comboBoxOpcionesIdioma_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles comboBoxOpcionesIdioma.SelectionChanged

        Dim idiomaPrevio As String = FicherosINI.Leer(My.Application.Info.DirectoryPath + "\Config.ini", "Options", "Language")

        If comboBoxOpcionesIdioma.SelectedIndex = 0 Then
            FicherosINI.Escribir(My.Application.Info.DirectoryPath + "\Config.ini", "Options", "Language", "en-US")
            opcionIdioma = "en-US"
        ElseIf comboBoxOpcionesIdioma.SelectedIndex = 1 Then
            FicherosINI.Escribir(My.Application.Info.DirectoryPath + "\Config.ini", "Options", "Language", "es-ES")
            opcionIdioma = "es-ES"
        End If

        If Not idiomaPrevio = opcionIdioma Then
            CargarIdioma()
            ControlesEstado(False)
            workerLimpieza.RunWorkerAsync()
        End If

    End Sub

    Private Sub buttonCleanAllSkins_Click(sender As Object, e As RoutedEventArgs) Handles buttonCleanAllSkins.Click

        ControlesEstado(False)
        workerLimpieza.RunWorkerAsync()

    End Sub

    'SKIN POR DEFECTO-------------------------------------------------------------------------

    Dim WithEvents workerDefault As New BackgroundWorker

    Private Sub workerDefault_DoWork(sender As Object, e As DoWorkEventArgs) Handles workerDefault.DoWork

        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Valve\Steam", "SkinV4", " ")

        Dim i As Integer = 0

        While i < 100
            Dim tempProc() As Process = Process.GetProcessesByName("Steam")

            If tempProc.Count = 0 Then
                workerDefault.ReportProgress(0, recursos.GetString("startingSteam", New CultureInfo(opcionIdioma)))
                Process.Start(rutaSteam + "\steam.exe")
                Exit While
            Else
                Try
                    Process.GetProcessesByName("Steam")(0).Kill()
                Catch ex As Exception

                End Try
            End If
            i += 1
        End While

        workerDefault.ReportProgress(0, recursos.GetString("skinInstalled", New CultureInfo(opcionIdioma)))

    End Sub

    Private Sub workerDefault_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles workerDefault.RunWorkerCompleted

        ControlesEstadoSkins()
        ControlesEstado(True)

    End Sub

    Private Sub workerDefault_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles workerDefault.ProgressChanged

        labelProgreso.Content = e.UserState.ToString

    End Sub

    'LIMPIEZA TOTAL-------------------------------------------------------------------------

    Dim WithEvents workerLimpieza As New BackgroundWorker

    Private Sub workerLimpieza_DoWork(sender As Object, e As DoWorkEventArgs) Handles workerLimpieza.DoWork

        Try
            If Directory.Exists(rutaSteam + "\skins") Then
                For Each carpeta As String In Directory.GetDirectories(rutaSteam + "\skins")
                    Directory.Delete(carpeta, True)
                Next
            End If

            skinTitulo = "Default"
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Valve\Steam", "SkinV4", " ")
        Catch ex As Exception

        End Try

    End Sub

    Private Sub workerLimpieza_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles workerLimpieza.RunWorkerCompleted

        ControlesEstadoSkins()
        ControlesEstado(True)
        labelProgreso.Content = Nothing
        skinInstallButton.Content = recursos.GetString("skinInstallButton", New CultureInfo(opcionIdioma))

        Dim azar As Random = New Random()
        comboBoxSkins.SelectedIndex = azar.Next(2, comboBoxSkins.Items.Count)

    End Sub

    'VERSIONES-------------------------------------------------------------------------

    Dim WithEvents workerVersiones As New BackgroundWorker

    Private Sub workerVersiones_DoWork(sender As Object, e As DoWorkEventArgs) Handles workerVersiones.DoWork

        versionSkinActualizada = Versiones.Generar(skinTitulo)

    End Sub

    Private Sub workerVersiones_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles workerVersiones.RunWorkerCompleted

        If Not versionSkinActualizada = Nothing Then
            If Not versionSkinInstalada = versionSkinActualizada Then
                Dim notifyIcon As New TaskbarIcon
                notifyIcon.ShowBalloonTip(recursos.GetString("updatingNewVersion", New CultureInfo(opcionIdioma)) + " " + skinTitulo, "Steam Skins", BalloonIcon.Info)
                notifyIcon.Dispose()

                skinCarpeta = FicherosINI.Leer(rutaSteam + "\skins\" + skinTitulo + "\SteamSkins.ini", "Data", "Folder")
                skinZip = FicherosINI.Leer(rutaSteam + "\skins\" + skinTitulo + "\SteamSkins.ini", "Data", "Zip")

                skinOpcion1 = FicherosINI.Leer(rutaSteam + "\skins\" + skinTitulo + "\SteamSkins.ini", "Options", "Option1_Label")
                skinOpcion2 = FicherosINI.Leer(rutaSteam + "\skins\" + skinTitulo + "\SteamSkins.ini", "Options", "Option2_Label")
                skinOpcion3 = FicherosINI.Leer(rutaSteam + "\skins\" + skinTitulo + "\SteamSkins.ini", "Options", "Option3_Label")
                skinOpcion4 = FicherosINI.Leer(rutaSteam + "\skins\" + skinTitulo + "\SteamSkins.ini", "Options", "Option4_Label")
                skinOpcion5 = FicherosINI.Leer(rutaSteam + "\skins\" + skinTitulo + "\SteamSkins.ini", "Options", "Option5_Label")
                skinOpcion6 = FicherosINI.Leer(rutaSteam + "\skins\" + skinTitulo + "\SteamSkins.ini", "Options", "Option6_Label")
                skinOpcion7 = FicherosINI.Leer(rutaSteam + "\skins\" + skinTitulo + "\SteamSkins.ini", "Options", "Option7_Label")
                skinOpcion8 = FicherosINI.Leer(rutaSteam + "\skins\" + skinTitulo + "\SteamSkins.ini", "Options", "Option8_Label")
                skinOpcion9 = FicherosINI.Leer(rutaSteam + "\skins\" + skinTitulo + "\SteamSkins.ini", "Options", "Option9_Label")

                skinOpcionSeleccion1 = FicherosINI.Leer(rutaSteam + "\skins\" + skinTitulo + "\SteamSkins.ini", "Options", "Option1_Selection")
                skinOpcionSeleccion2 = FicherosINI.Leer(rutaSteam + "\skins\" + skinTitulo + "\SteamSkins.ini", "Options", "Option2_Selection")
                skinOpcionSeleccion3 = FicherosINI.Leer(rutaSteam + "\skins\" + skinTitulo + "\SteamSkins.ini", "Options", "Option3_Selection")
                skinOpcionSeleccion4 = FicherosINI.Leer(rutaSteam + "\skins\" + skinTitulo + "\SteamSkins.ini", "Options", "Option4_Selection")
                skinOpcionSeleccion5 = FicherosINI.Leer(rutaSteam + "\skins\" + skinTitulo + "\SteamSkins.ini", "Options", "Option5_Selection")
                skinOpcionSeleccion6 = FicherosINI.Leer(rutaSteam + "\skins\" + skinTitulo + "\SteamSkins.ini", "Options", "Option6_Selection")
                skinOpcionSeleccion7 = FicherosINI.Leer(rutaSteam + "\skins\" + skinTitulo + "\SteamSkins.ini", "Options", "Option7_Selection")
                skinOpcionSeleccion8 = FicherosINI.Leer(rutaSteam + "\skins\" + skinTitulo + "\SteamSkins.ini", "Options", "Option8_Selection")
                skinOpcionSeleccion9 = FicherosINI.Leer(rutaSteam + "\skins\" + skinTitulo + "\SteamSkins.ini", "Options", "Option9_Selection")

                workerDescarga.WorkerReportsProgress = True
                workerDescarga.RunWorkerAsync()
            Else
                ControlesEstado(True)
                labelProgreso.Content = recursos.GetString("succesfulLastVersion", New CultureInfo(opcionIdioma))
            End If
        Else
            ControlesEstado(True)
            labelProgreso.Content = recursos.GetString("succesfulLastVersion", New CultureInfo(opcionIdioma))
        End If

    End Sub

    'CERRAR-------------------------------------------------------------------------

    Private Sub Main_Closed(sender As Object, e As EventArgs) Handles Main.Closed

        Cerrar()

    End Sub

    Private Sub Main_Closing(sender As Object, e As CancelEventArgs) Handles Main.Closing

        Cerrar()

    End Sub

    Private Sub Cerrar()

        Try
            workerDefault.CancelAsync()
        Catch ex As Exception

        End Try

        Try
            workerLimpieza.CancelAsync()
        Catch ex As Exception

        End Try

        Try
            workerDescarga.CancelAsync()
        Catch ex As Exception

        End Try

        Try
            workerVersiones.CancelAsync()
        Catch ex As Exception

        End Try

    End Sub

End Class
