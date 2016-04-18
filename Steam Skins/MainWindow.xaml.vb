Imports System.IO
Imports System.IO.Compression
Imports System.ComponentModel
Imports System.Net
Imports System.Threading

Class MainWindow

    Dim rutaSteam As String

    Dim skinCarpeta As String
    Dim skinZip As String
    Dim skinUrlDescarga As String

    Private Sub Main_Loaded(sender As Object, e As RoutedEventArgs) Handles Main.Loaded

        rutaSteam = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Valve\Steam", "SteamPath", Nothing)
        rutaSteam = rutaSteam.Replace("/", "\")

    End Sub

    Private Sub ControlesEstado(estado As Boolean)

        treeViewSkins.IsEnabled = estado

    End Sub

    'DEFAULT----------------------------------------------------------------------

    Private Sub skinDefaultButton_Click(sender As Object, e As RoutedEventArgs) Handles skinDefaultButton.Click

        workerDefault.WorkerReportsProgress = True
        workerDefault.RunWorkerAsync()

    End Sub

    Dim WithEvents workerDefault As New BackgroundWorker

    Private Sub workerDefault_DoWork(sender As Object, e As DoWorkEventArgs) Handles workerDefault.DoWork

    End Sub

    Private Sub workerDefault_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles workerDefault.RunWorkerCompleted

        ControlesEstado(False)

        If Directory.Exists(rutaSteam + "\skins") Then
            For Each carpeta As String In Directory.GetDirectories(rutaSteam + "\skins")
                Directory.Delete(carpeta, True)
            Next
        End If

        If Directory.Exists(My.Application.Info.DirectoryPath + "\Temp") Then
            Directory.Delete(My.Application.Info.DirectoryPath + "\Temp", True)
        End If

        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Valve\Steam", "SkinV4", " ")

        Try
            Process.GetProcessesByName("Steam")(0).Kill()
        Catch ex As Exception

        End Try

        Thread.Sleep(15000)
        Process.Start(rutaSteam + "\steam.exe")

        ControlesEstado(True)

    End Sub

    'SKINS----------------------------------------------------------------------

    Private Sub skinAirButton_Click(sender As Object, e As RoutedEventArgs) Handles skinAirButton.Click

        skinCarpeta = "Air-for-Steam-2016-0417"
        skinZip = "air"
        skinUrlDescarga = Air.UrlDescarga()

        ControlesEstado(False)
        workerDescarga.WorkerReportsProgress = True
        workerDescarga.RunWorkerAsync()

    End Sub

    Private Sub skinMetroButton_Click(sender As Object, e As RoutedEventArgs) Handles skinMetroButton.Click

        skinCarpeta = "Metro for Steam"
        skinZip = "metro"
        skinUrlDescarga = Metro.UrlDescarga()

        ControlesEstado(False)
        workerDescarga.WorkerReportsProgress = True
        workerDescarga.RunWorkerAsync()

    End Sub

    Dim WithEvents workerDescarga As New BackgroundWorker

    Private Sub workerDescarga_DoWork(sender As Object, e As DoWorkEventArgs) Handles workerDescarga.DoWork

        If Directory.Exists(rutaSteam + "\skins") Then
            For Each carpeta As String In Directory.GetDirectories(rutaSteam + "\skins")
                Directory.Delete(carpeta, True)
            Next
        End If

        If Directory.Exists(My.Application.Info.DirectoryPath + "\Temp") Then
            Directory.Delete(My.Application.Info.DirectoryPath + "\Temp", True)
        End If

        Directory.CreateDirectory(My.Application.Info.DirectoryPath + "\Temp")

        Dim theResponse As HttpWebResponse
        Dim theRequest As HttpWebRequest

        Try
            theRequest = WebRequest.Create(skinUrlDescarga)
            theResponse = theRequest.GetResponse

            Dim length As Long = theResponse.ContentLength
            Dim writeStream As New FileStream(My.Application.Info.DirectoryPath + "\Temp\" + skinZip + ".zip", FileMode.Create)
            Dim nRead As Integer

            Dim speedtimer As New Stopwatch
            Dim currentspeed As Double = -1
            Dim readings As Integer = 0

            Do
                speedtimer.Start()

                Dim readBytes(4095) As Byte
                Dim bytesread As Integer = theResponse.GetResponseStream.Read(readBytes, 0, 4096)
                nRead += bytesread
                Dim percent As Short = (nRead * 100) / length
                workerDescarga.ReportProgress(percent)

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

            theResponse.GetResponseStream.Close()
            writeStream.Close()
        Catch ex As Exception
            labelProgreso.Content = "Error downloading file"
        End Try

    End Sub

    Private Sub workerDescarga_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles workerDescarga.RunWorkerCompleted

        labelProgreso.Content = "Extracting files"
        ZipFile.ExtractToDirectory(My.Application.Info.DirectoryPath + "\Temp\" + skinZip + ".zip", My.Application.Info.DirectoryPath + "\Temp\" + skinZip)

        labelProgreso.Content = "Moving files"
        My.Computer.FileSystem.MoveDirectory(My.Application.Info.DirectoryPath + "\Temp\" + skinZip + "\" + skinCarpeta, rutaSteam + "\skins\" + skinCarpeta)

        If skinZip = "metro" Then
            If Not My.Computer.Info.OSFullName.Contains("Windows 10") Then
                If Not File.Exists("C:\Windows\Fonts\segoeuisl.ttf") Then
                    My.Computer.FileSystem.MoveFile(My.Application.Info.DirectoryPath + "\Temp\INSTALL THIS FONT (WINDOWS 7 AND OLDER)\segoeuisl.ttf", "C:\Windows\Fonts")
                End If
            End If
        End If

        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Valve\Steam", "SkinV4", skinCarpeta)

        Try
            Process.GetProcessesByName("Steam")(0).Kill()
        Catch ex As Exception

        End Try

        Thread.Sleep(15000)

        labelProgreso.Content = "Starting Steam"
        Process.Start(rutaSteam + "\steam.exe")

        ControlesEstado(True)

    End Sub

    Private Sub workerDescarga_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles workerDescarga.ProgressChanged

        labelProgreso.Content = "Progress download: " + e.ProgressPercentage.ToString + "%"

    End Sub

End Class
