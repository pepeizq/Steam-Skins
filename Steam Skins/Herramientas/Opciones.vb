Imports System.Globalization
Imports System.IO
Imports System.Resources

Module Opciones

    Public Sub Filtrar(skinOpcion As String, rutaSteam As String, skinZip As String, skinTitulo As String, skinSeleccion As String, opcionIdioma As String, recursos As ResourceManager)

        If skinOpcion = recursos.GetString("customTheme", New CultureInfo(opcionIdioma)) Then
            CambiarTheme(rutaSteam, skinTitulo, skinSeleccion, opcionIdioma, recursos)
        ElseIf skinOpcion = recursos.GetString("customColor", New CultureInfo(opcionIdioma)) Then
            CambiarColor(rutaSteam, skinZip, skinTitulo, skinSeleccion, opcionIdioma, recursos)
        ElseIf skinOpcion = recursos.GetString("customBackground", New CultureInfo(opcionIdioma)) Then
            CambiarBackground(rutaSteam, skinTitulo, skinSeleccion, opcionIdioma, recursos)
        ElseIf skinOpcion = recursos.GetString("customTitleBar", New CultureInfo(opcionIdioma)) Then
            CambiarTitleBar(rutaSteam, skinTitulo, skinSeleccion, opcionIdioma, recursos)
        ElseIf skinOpcion = recursos.GetString("customGameDetails", New CultureInfo(opcionIdioma)) Then
            CambiarGameDetails(rutaSteam, skinTitulo, skinSeleccion, opcionIdioma, recursos)
        ElseIf skinOpcion = recursos.GetString("customGridFade", New CultureInfo(opcionIdioma)) Then
            CambiarGridFade(rutaSteam, skinTitulo, skinSeleccion, opcionIdioma, recursos)
        ElseIf skinOpcion = recursos.GetString("customHoverFriends", New CultureInfo(opcionIdioma)) Then
            CambiarHoverFriends(rutaSteam, skinTitulo, skinSeleccion, opcionIdioma, recursos)
        ElseIf skinOpcion = recursos.GetString("customLibraryDividers", New CultureInfo(opcionIdioma)) Then
            CambiarLibraryDividers(rutaSteam, skinTitulo, skinSeleccion, opcionIdioma, recursos)
        ElseIf skinOpcion = recursos.GetString("customNotificationPosition", New CultureInfo(opcionIdioma)) Then
            CambiarNotificationPosition(rutaSteam, skinTitulo, skinSeleccion, opcionIdioma, recursos)
        ElseIf skinOpcion = recursos.GetString("customNotificationPosition", New CultureInfo(opcionIdioma)) Then
            CambiarNotificationPosition(rutaSteam, skinTitulo, skinSeleccion, opcionIdioma, recursos)
        ElseIf skinOpcion = recursos.GetString("customNotificationTimer", New CultureInfo(opcionIdioma)) Then
            CambiarNotificationTimer(rutaSteam, skinTitulo, skinSeleccion, opcionIdioma, recursos)
        ElseIf skinOpcion = recursos.GetString("customNotificationQuantity", New CultureInfo(opcionIdioma)) Then
            CambiarNotificationQuantity(rutaSteam, skinTitulo, skinSeleccion, opcionIdioma, recursos)
        ElseIf skinOpcion = recursos.GetString("customTransparentUninstalled", New CultureInfo(opcionIdioma)) Then
            CambiarTransparentUninstalled(rutaSteam, skinTitulo, skinSeleccion, opcionIdioma, recursos)
        ElseIf skinOpcion = recursos.GetString("customOverlayBackground", New CultureInfo(opcionIdioma)) Then
            CambiarOverlayBackground(rutaSteam, skinTitulo, skinSeleccion, opcionIdioma, recursos)
        End If

    End Sub

    Private Sub CambiarColor(rutaSteam As String, skinZip As String, skinTitulo As String, skinColor As String, opcionIdioma As String, recursos As ResourceManager)

        If skinColor = recursos.GetString("colorBlack", New CultureInfo(opcionIdioma)) Then
            skinColor = recursos.GetString("colorBlack", New CultureInfo("en-US"))
        ElseIf skinColor = recursos.GetString("colorBlue", New CultureInfo(opcionIdioma)) Then
            skinColor = recursos.GetString("colorBlue", New CultureInfo("en-US"))
        ElseIf skinColor = recursos.GetString("colorBreeze", New CultureInfo(opcionIdioma)) Then
            skinColor = recursos.GetString("colorBreeze", New CultureInfo("en-US"))
        ElseIf skinColor = recursos.GetString("colorBubblegum", New CultureInfo(opcionIdioma)) Then
            skinColor = recursos.GetString("colorBubblegum", New CultureInfo("en-US"))
        ElseIf skinColor = recursos.GetString("colorCinnabar", New CultureInfo(opcionIdioma)) Then
            skinColor = recursos.GetString("colorCinnabar", New CultureInfo("en-US"))
        ElseIf skinColor = recursos.GetString("colorCinnamon", New CultureInfo(opcionIdioma)) Then
            skinColor = recursos.GetString("colorCinnamon", New CultureInfo("en-US"))
        ElseIf skinColor = recursos.GetString("colorCobalt", New CultureInfo(opcionIdioma)) Then
            skinColor = recursos.GetString("colorCobalt", New CultureInfo("en-US"))
        ElseIf skinColor = recursos.GetString("colorCyan", New CultureInfo(opcionIdioma)) Then
            skinColor = recursos.GetString("colorCyan", New CultureInfo("en-US"))
        ElseIf skinColor = recursos.GetString("colorDarkBlue", New CultureInfo(opcionIdioma)) Then
            skinColor = recursos.GetString("colorDarkBlue", New CultureInfo("en-US"))
        ElseIf skinColor = recursos.GetString("colorDarkGreen", New CultureInfo(opcionIdioma)) Then
            skinColor = recursos.GetString("colorDarkGreen", New CultureInfo("en-US"))
        ElseIf skinColor = recursos.GetString("colorDeeppurple", New CultureInfo(opcionIdioma)) Then
            skinColor = recursos.GetString("colorDeeppurple", New CultureInfo("en-US"))
        ElseIf skinColor = recursos.GetString("colorGrass", New CultureInfo(opcionIdioma)) Then
            skinColor = recursos.GetString("colorGrass", New CultureInfo("en-US"))
        ElseIf skinColor = recursos.GetString("colorGreen", New CultureInfo(opcionIdioma)) Then
            skinColor = recursos.GetString("colorGreen", New CultureInfo("en-US"))
        ElseIf skinColor = recursos.GetString("colorGrey", New CultureInfo(opcionIdioma)) Then
            skinColor = recursos.GetString("colorGrey", New CultureInfo("en-US"))
        ElseIf skinColor = recursos.GetString("colorGunmetal", New CultureInfo(opcionIdioma)) Then
            skinColor = recursos.GetString("colorGunmetal", New CultureInfo("en-US"))
        ElseIf skinColor = recursos.GetString("colorHappyOrange", New CultureInfo(opcionIdioma)) Then
            skinColor = recursos.GetString("colorHappyOrange", New CultureInfo("en-US"))
        ElseIf skinColor = recursos.GetString("colorLavender", New CultureInfo(opcionIdioma)) Then
            skinColor = recursos.GetString("colorLavender", New CultureInfo("en-US"))
        ElseIf skinColor = recursos.GetString("colorLightBlue", New CultureInfo(opcionIdioma)) Then
            skinColor = recursos.GetString("colorLightBlue", New CultureInfo("en-US"))
        ElseIf skinColor = recursos.GetString("colorLilac", New CultureInfo(opcionIdioma)) Then
            skinColor = recursos.GetString("colorLilac", New CultureInfo("en-US"))
        ElseIf skinColor = recursos.GetString("colorNavy", New CultureInfo(opcionIdioma)) Then
            skinColor = recursos.GetString("colorNavy", New CultureInfo("en-US"))
        ElseIf skinColor = recursos.GetString("colorNight", New CultureInfo(opcionIdioma)) Then
            skinColor = recursos.GetString("colorNight", New CultureInfo("en-US"))
        ElseIf skinColor = recursos.GetString("colorOrange", New CultureInfo(opcionIdioma)) Then
            skinColor = recursos.GetString("colorOrange", New CultureInfo("en-US"))
        ElseIf skinColor = recursos.GetString("colorPadawan", New CultureInfo(opcionIdioma)) Then
            skinColor = recursos.GetString("colorPadawan", New CultureInfo("en-US"))
        ElseIf skinColor = recursos.GetString("colorPurple", New CultureInfo(opcionIdioma)) Then
            skinColor = recursos.GetString("colorPurple", New CultureInfo("en-US"))
        ElseIf skinColor = recursos.GetString("colorRed", New CultureInfo(opcionIdioma)) Then
            skinColor = recursos.GetString("colorRed", New CultureInfo("en-US"))
        ElseIf skinColor = recursos.GetString("colorRose", New CultureInfo(opcionIdioma)) Then
            skinColor = recursos.GetString("colorRose", New CultureInfo("en-US"))
        ElseIf skinColor = recursos.GetString("colorRoyal", New CultureInfo(opcionIdioma)) Then
            skinColor = recursos.GetString("colorRoyal", New CultureInfo("en-US"))
        ElseIf skinColor = recursos.GetString("colorRoyalBlue", New CultureInfo(opcionIdioma)) Then
            skinColor = recursos.GetString("colorRoyalBlue", New CultureInfo("en-US"))
        ElseIf skinColor = recursos.GetString("colorSea", New CultureInfo(opcionIdioma)) Then
            skinColor = recursos.GetString("colorSea", New CultureInfo("en-US"))
        ElseIf skinColor = recursos.GetString("colorSilver", New CultureInfo(opcionIdioma)) Then
            skinColor = recursos.GetString("colorSilver", New CultureInfo("en-US"))
        ElseIf skinColor = recursos.GetString("colorSky", New CultureInfo(opcionIdioma)) Then
            skinColor = recursos.GetString("colorSky", New CultureInfo("en-US"))
        ElseIf skinColor = recursos.GetString("colorSlate", New CultureInfo(opcionIdioma)) Then
            skinColor = recursos.GetString("colorSlate", New CultureInfo("en-US"))
        ElseIf skinColor = recursos.GetString("colorSteamblue", New CultureInfo(opcionIdioma)) Then
            skinColor = recursos.GetString("colorSteamblue", New CultureInfo("en-US"))
        ElseIf skinColor = recursos.GetString("colorTruffle", New CultureInfo(opcionIdioma)) Then
            skinColor = recursos.GetString("colorTruffle", New CultureInfo("en-US"))
        ElseIf skinColor = recursos.GetString("colorViolet", New CultureInfo(opcionIdioma)) Then
            skinColor = recursos.GetString("colorViolet", New CultureInfo("en-US"))
        ElseIf skinColor = recursos.GetString("colorViridian", New CultureInfo(opcionIdioma)) Then
            skinColor = recursos.GetString("colorViridian", New CultureInfo("en-US"))
        ElseIf skinColor = recursos.GetString("colorWatermelon", New CultureInfo(opcionIdioma)) Then
            skinColor = recursos.GetString("colorWatermelon", New CultureInfo("en-US"))
        ElseIf skinColor = recursos.GetString("colorYoutubered", New CultureInfo(opcionIdioma)) Then
            skinColor = recursos.GetString("colorYoutubered", New CultureInfo("en-US"))
        End If

        skinColor = skinColor.ToLower()
        skinColor = skinColor.Replace(" ", Nothing)

        Dim tempFichero As String = Nothing
        Dim tempDefault As String = Nothing
        Dim tempFolder As String = Nothing

        If skinZip = "air" Then
            tempFichero = "config.ini"
            tempDefault = "sky"
            tempFolder = "colors/"
        ElseIf skinZip = "airclassic" Then
            tempFichero = "config.ini"
            tempDefault = "blue"
            tempFolder = "tweaks/color_"
        ElseIf skinZip = "metro" Then
            tempFichero = "custom.styles"
            tempDefault = "0 120 215 255"

            If skinColor = "grey" Then
                skinColor = "0 120 215 255"
            ElseIf skinColor = "rose" Then
                skinColor = "220 79 173 255"
            ElseIf skinColor = "violet" Then
                skinColor = "172 25 61 255"
            ElseIf skinColor = "red" Then
                skinColor = "255 0 0 255"
            ElseIf skinColor = "orange" Then
                skinColor = "210 71 38 255"
            ElseIf skinColor = "green" Then
                skinColor = "130 186 0 255"
            ElseIf skinColor = "dark green" Then
                skinColor = "0 138 23 255"
            ElseIf skinColor = "viridian" Then
                skinColor = "3 179 178 255"
            ElseIf skinColor = "light blue" Then
                skinColor = "93 178 255 255"
            ElseIf skinColor = "royal blue" Then
                skinColor = "0 114 198 255"
            ElseIf skinColor = "dark blue" Then
                skinColor = "70 23 180 255"
            End If

        ElseIf skinZip = "minimal" Then
            tempFichero = "settings.ini"
            tempDefault = "black"
            tempFolder = "styles/colors/"
        ElseIf skinZip = "threshold" Then
            tempFichero = "config.ini"
            tempDefault = "cobalt"
            tempFolder = "styles/colors/"
        End If

        Dim ini As String
        Using sr As New StreamReader(rutaSteam + "\skins\" + skinTitulo + "\" + tempFichero)
            ini = sr.ReadToEnd()

            If skinZip = "metro" Then
                ini = ini.Replace("colors{Focus=" + Chr(34) + tempDefault, "colors{Focus=" + Chr(34) + skinColor)
            Else
                ini = ini.Replace("include " + Chr(34) + "resource/" + tempFolder + tempDefault + ".styles", "include " + Chr(34) + "resource/" + tempFolder + skinColor + ".styles")
            End If
        End Using

        File.WriteAllText(rutaSteam + "\skins\" + skinTitulo + "\" + tempFichero, ini)

    End Sub

    'AIR------------------------------------------

    Private Sub CambiarTheme(rutaSteam As String, skinTitulo As String, skinTheme As String, opcionIdioma As String, recursos As ResourceManager)

        If skinTheme = recursos.GetString("themeDark", New CultureInfo(opcionIdioma)) Then
            skinTheme = recursos.GetString("themeDark", New CultureInfo("en-US"))
        ElseIf skinTheme = recursos.GetString("themeLight", New CultureInfo(opcionIdioma)) Then
            skinTheme = recursos.GetString("themeLight", New CultureInfo("en-US"))
        End If

        skinTheme = skinTheme.ToLower()

        Dim ini As String
        Using sr As New StreamReader(rutaSteam + "\skins\" + skinTitulo + "\config.ini")
            ini = sr.ReadToEnd()

            ini = ini.Replace("include " + Chr(34) + "resource/themes/_light.styles", "//include " + Chr(34) + "resource/themes/_light.styles")
            ini = ini.Replace("//include " + Chr(34) + "resource/themes/_" + skinTheme + ".styles", "include " + Chr(34) + "resource/themes/_" + skinTheme + ".styles")
        End Using

        File.WriteAllText(rutaSteam + "\skins\" + skinTitulo + "\config.ini", ini)

    End Sub

    'THRESHOLD------------------------------------------

    Private Sub CambiarTitleBar(rutaSteam As String, skinTitulo As String, skinTitleBar As String, opcionIdioma As String, recursos As ResourceManager)

        Dim ini As String
        Using sr As New StreamReader(rutaSteam + "\skins\" + skinTitulo + "\config.ini")
            ini = sr.ReadToEnd()

            If skinTitleBar = recursos.GetString("yes", New CultureInfo(opcionIdioma)) Then
                ini = ini.Replace("//include " + Chr(34) + "resource/styles/colors/titlebar_black", "include " + Chr(34) + "resource/styles/colors/titlebar_black")
            End If

            If skinTitleBar = recursos.GetString("no", New CultureInfo(opcionIdioma)) Then
                ini = ini.Replace("include " + Chr(34) + "resource/styles/colors/titlebar_black", "//include " + Chr(34) + "resource/styles/colors/titlebar_black")
            End If
        End Using

        File.WriteAllText(rutaSteam + "\skins\" + skinTitulo + "\config.ini", ini)

    End Sub

    'AIR CLASSIC------------------------------------------

    Private Sub CambiarBackground(rutaSteam As String, skinTitulo As String, skinBackground As String, opcionIdioma As String, recursos As ResourceManager)

        If skinBackground = recursos.GetString("backgroundNone", New CultureInfo(opcionIdioma)) Then
            skinBackground = recursos.GetString("backgroundNone", New CultureInfo("en-US"))
        ElseIf skinBackground = recursos.GetString("backgroundNoise", New CultureInfo(opcionIdioma)) Then
            skinBackground = recursos.GetString("backgroundNoise", New CultureInfo("en-US"))
        ElseIf skinBackground = recursos.GetString("backgroundDots", New CultureInfo(opcionIdioma)) Then
            skinBackground = recursos.GetString("backgroundDots", New CultureInfo("en-US"))
        ElseIf skinBackground = recursos.GetString("backgroundRibbon", New CultureInfo(opcionIdioma)) Then
            skinBackground = recursos.GetString("backgroundRibbon", New CultureInfo("en-US"))
        End If

        skinBackground = skinBackground.ToLower()

        Dim ini As String
        Using sr As New StreamReader(rutaSteam + "\skins\" + skinTitulo + "\config.ini")
            ini = sr.ReadToEnd()

            ini = ini.Replace("include " + Chr(34) + "resource/tweaks/bg_none.styles", "//include " + Chr(34) + "resource/tweaks/bg_none.styles")
            ini = ini.Replace("//include " + Chr(34) + "resource/tweaks/bg_" + skinBackground + ".styles", "include " + Chr(34) + "resource/tweaks/bg_" + skinBackground + ".styles")
        End Using

        File.WriteAllText(rutaSteam + "\skins\" + skinTitulo + "\config.ini", ini)

    End Sub

    Private Sub CambiarGameDetails(rutaSteam As String, skinTitulo As String, skinGameDetails As String, opcionIdioma As String, recursos As ResourceManager)

        If skinGameDetails = recursos.GetString("colorSteamblue", New CultureInfo(opcionIdioma)) Then
            skinGameDetails = recursos.GetString("colorSteamblue", New CultureInfo("en-US"))
        ElseIf skinGameDetails = recursos.GetString("colorColorized", New CultureInfo(opcionIdioma)) Then
            skinGameDetails = recursos.GetString("colorColorized", New CultureInfo("en-US"))
        End If

        skinGameDetails = skinGameDetails.ToLower()
        skinGameDetails = skinGameDetails.Replace(" ", Nothing)

        Dim ini As String
        Using sr As New StreamReader(rutaSteam + "\skins\" + skinTitulo + "\config.ini")
            ini = sr.ReadToEnd()

            ini = ini.Replace("include " + Chr(34) + "resource/tweaks/details_steamblue.styles", "//include " + Chr(34) + "resource/tweaks/details_steamblue.styles")
            ini = ini.Replace("//include " + Chr(34) + "resource/tweaks/details_" + skinGameDetails + ".styles", "include " + Chr(34) + "resource/tweaks/details_" + skinGameDetails + ".styles")
        End Using

        File.WriteAllText(rutaSteam + "\skins\" + skinTitulo + "\config.ini", ini)

    End Sub

    Private Sub CambiarGridFade(rutaSteam As String, skinTitulo As String, skinGridFade As String, opcionIdioma As String, recursos As ResourceManager)

        Dim ini As String
        Using sr As New StreamReader(rutaSteam + "\skins\" + skinTitulo + "\config.ini")
            ini = sr.ReadToEnd()

            If skinGridFade = recursos.GetString("yes", New CultureInfo(opcionIdioma)) Then
                ini = ini.Replace("include " + Chr(34) + "resource/tweaks/grid_nofade.styles", "//include " + Chr(34) + "resource/tweaks/grid_nofade.styles")
                ini = ini.Replace("//include " + Chr(34) + "resource/tweaks/grid_fade.styles", "include " + Chr(34) + "resource/tweaks/grid_fade.styles")
            End If

            If skinGridFade = recursos.GetString("no", New CultureInfo(opcionIdioma)) Then
                ini = ini.Replace("//include " + Chr(34) + "resource/tweaks/grid_nofade.styles", "include " + Chr(34) + "resource/tweaks/grid_nofade.styles")
                ini = ini.Replace("include " + Chr(34) + "resource/tweaks/grid_fade.styles", "//include " + Chr(34) + "resource/tweaks/grid_fade.styles")
            End If
        End Using

        File.WriteAllText(rutaSteam + "\skins\" + skinTitulo + "\config.ini", ini)

    End Sub

    Private Sub CambiarHoverFriends(rutaSteam As String, skinTitulo As String, skinHoverFriends As String, opcionIdioma As String, recursos As ResourceManager)

        Dim ini As String
        Using sr As New StreamReader(rutaSteam + "\skins\" + skinTitulo + "\config.ini")
            ini = sr.ReadToEnd()

            If skinHoverFriends = recursos.GetString("yes", New CultureInfo(opcionIdioma)) Then
                ini = ini.Replace("include " + Chr(34) + "resource/tweaks/friends_nohover.styles", "//include " + Chr(34) + "resource/tweaks/friends_nohover.styles")
                ini = ini.Replace("//include " + Chr(34) + "resource/tweaks/friends_hover.styles", "include " + Chr(34) + "resource/tweaks/friends_hover.styles")
            End If

            If skinHoverFriends = recursos.GetString("no", New CultureInfo(opcionIdioma)) Then
                ini = ini.Replace("//include " + Chr(34) + "resource/tweaks/friends_nohover.styles", "include " + Chr(34) + "resource/tweaks/friends_nohover.styles")
                ini = ini.Replace("include " + Chr(34) + "resource/tweaks/friends_hover.styles", "//include " + Chr(34) + "resource/tweaks/friends_hover.styles")
            End If
        End Using

        File.WriteAllText(rutaSteam + "\skins\" + skinTitulo + "\config.ini", ini)

    End Sub

    Private Sub CambiarLibraryDividers(rutaSteam As String, skinTitulo As String, skinLibraryDividers As String, opcionIdioma As String, recursos As ResourceManager)

        Dim ini As String
        Using sr As New StreamReader(rutaSteam + "\skins\" + skinTitulo + "\config.ini")
            ini = sr.ReadToEnd()

            If skinLibraryDividers = recursos.GetString("yes", New CultureInfo(opcionIdioma)) Then
                ini = ini.Replace("include " + Chr(34) + "resource/tweaks/lib_nodividers.styles", "//include " + Chr(34) + "resource/tweaks/lib_nodividers.styles")
                ini = ini.Replace("//include " + Chr(34) + "resource/tweaks/lib_dividers.styles", "include " + Chr(34) + "resource/tweaks/lib_dividers.styles")
            End If

            If skinLibraryDividers = recursos.GetString("no", New CultureInfo(opcionIdioma)) Then
                ini = ini.Replace("//include " + Chr(34) + "resource/tweaks/lib_nodividers.styles", "include " + Chr(34) + "resource/tweaks/lib_nodividers.styles")
                ini = ini.Replace("include " + Chr(34) + "resource/tweaks/lib_dividers.styles", "//include " + Chr(34) + "resource/tweaks/lib_dividers.styles")
            End If
        End Using

        File.WriteAllText(rutaSteam + "\skins\" + skinTitulo + "\config.ini", ini)

    End Sub

    'PRESSURE2------------------------------------------

    Private Sub CambiarNotificationPosition(rutaSteam As String, skinTitulo As String, skinNotificationPosition As String, opcionIdioma As String, recursos As ResourceManager)

        If skinNotificationPosition = recursos.GetString("positionBottomRight", New CultureInfo(opcionIdioma)) Then
            skinNotificationPosition = recursos.GetString("positionBottomRight", New CultureInfo("en-US"))
        ElseIf skinNotificationPosition = recursos.GetString("positionBottomLeft", New CultureInfo(opcionIdioma)) Then
            skinNotificationPosition = recursos.GetString("positionBottomLeft", New CultureInfo("en-US"))
        ElseIf skinNotificationPosition = recursos.GetString("positionTopRight", New CultureInfo(opcionIdioma)) Then
            skinNotificationPosition = recursos.GetString("positionTopRight", New CultureInfo("en-US"))
        ElseIf skinNotificationPosition = recursos.GetString("positionTopLeft", New CultureInfo(opcionIdioma)) Then
            skinNotificationPosition = recursos.GetString("positionTopLeft", New CultureInfo("en-US"))
        End If

        Dim ini As String
        Using sr As New StreamReader(rutaSteam + "\skins\" + skinTitulo + "\config.ini")
            ini = sr.ReadToEnd()

            ini = ini.Replace("Notifications.PanelPosition = " + Chr(34) + "BottomRight", "Notifications.PanelPosition = " + Chr(34) + skinNotificationPosition)
        End Using

        File.WriteAllText(rutaSteam + "\skins\" + skinTitulo + "\config.ini", ini)

    End Sub

    Private Sub CambiarNotificationTimer(rutaSteam As String, skinTitulo As String, skinNotificationTimer As String, opcionIdioma As String, recursos As ResourceManager)

        skinNotificationTimer = skinNotificationTimer + ".0"

        Dim ini As String
        Using sr As New StreamReader(rutaSteam + "\skins\" + skinTitulo + "\config.ini")
            ini = sr.ReadToEnd()

            ini = ini.Replace("Notifications.DisplayTime = " + Chr(34) + "3.0", "Notifications.DisplayTime = " + Chr(34) + skinNotificationTimer)
        End Using

        File.WriteAllText(rutaSteam + "\skins\" + skinTitulo + "\config.ini", ini)

    End Sub

    Private Sub CambiarNotificationQuantity(rutaSteam As String, skinTitulo As String, skinNotificationQuantity As String, opcionIdioma As String, recursos As ResourceManager)

        Dim ini As String
        Using sr As New StreamReader(rutaSteam + "\skins\" + skinTitulo + "\config.ini")
            ini = sr.ReadToEnd()

            ini = ini.Replace("Notifications.StackSize = " + Chr(34) + "6", "Notifications.StackSize = " + Chr(34) + skinNotificationQuantity)
        End Using

        File.WriteAllText(rutaSteam + "\skins\" + skinTitulo + "\config.ini", ini)

    End Sub

    Private Sub CambiarTransparentUninstalled(rutaSteam As String, skinTitulo As String, skinTransparentUninstalled As String, opcionIdioma As String, recursos As ResourceManager)

        Dim ini As String
        Using sr As New StreamReader(rutaSteam + "\skins\" + skinTitulo + "\config.ini")
            ini = sr.ReadToEnd()

            If skinTransparentUninstalled = recursos.GetString("yes", New CultureInfo(opcionIdioma)) Then
                ini = ini.Replace("include " + Chr(34) + "includes/tweaks/grid/not-transparent.styles", "//include " + Chr(34) + "includes/tweaks/grid/not-transparent.styles")
                ini = ini.Replace("//include " + Chr(34) + "includes/tweaks/grid/transparent.styles", "include " + Chr(34) + "includes/tweaks/grid/transparent.styles")
            End If

            If skinTransparentUninstalled = recursos.GetString("no", New CultureInfo(opcionIdioma)) Then
                ini = ini.Replace("//include " + Chr(34) + "includes/tweaks/grid/not-transparent.styles", "include " + Chr(34) + "includes/tweaks/grid/not-transparent.styles")
                ini = ini.Replace("include " + Chr(34) + "includes/tweaks/grid/transparent.styles", "//include " + Chr(34) + "includes/tweaks/grid/transparent.styles")
            End If
        End Using

        File.WriteAllText(rutaSteam + "\skins\" + skinTitulo + "\config.ini", ini)

    End Sub

    Private Sub CambiarOverlayBackground(rutaSteam As String, skinTitulo As String, skinOverlayBackground As String, opcionIdioma As String, recursos As ResourceManager)

        Dim ini As String
        Using sr As New StreamReader(rutaSteam + "\skins\" + skinTitulo + "\config.ini")
            ini = sr.ReadToEnd()

            If skinOverlayBackground = recursos.GetString("yes", New CultureInfo(opcionIdioma)) Then
                ini = ini.Replace("include " + Chr(34) + "includes/tweaks/gamebackgroundoverlay/disable.styles", "//include " + Chr(34) + "includes/tweaks/gamebackgroundoverlay/disable.styles")
                ini = ini.Replace("//include " + Chr(34) + "includes/tweaks/gamebackgroundoverlay/enable.styles", "include " + Chr(34) + "includes/tweaks/gamebackgroundoverlay/enable.styles")
            End If

            If skinOverlayBackground = recursos.GetString("no", New CultureInfo(opcionIdioma)) Then
                ini = ini.Replace("//include " + Chr(34) + "includes/tweaks/gamebackgroundoverlay/disable.styles", "include " + Chr(34) + "includes/tweaks/gamebackgroundoverlay/disable.styles")
                ini = ini.Replace("include " + Chr(34) + "includes/tweaks/gamebackgroundoverlay/enable.styles", "//include " + Chr(34) + "includes/tweaks/gamebackgroundoverlay/enable.styles")
            End If
        End Using

        File.WriteAllText(rutaSteam + "\skins\" + skinTitulo + "\config.ini", ini)

    End Sub

End Module
