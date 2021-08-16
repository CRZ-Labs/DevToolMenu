Imports Microsoft.Win32
Module Complementos

#Region "Directorios"
    Sub Create_OpenWithCommandPrompt()
        Try
            'Idea principal. Crear un menu que diga "Open in CMD" OICMD = OICMD
            '   1) Crear la llave SOFTWARE\\Classes\\Directory\\Background\\shell\\OICMD
            '       1.0) Escribir en el valor defecto "Open in CMD"
            '       1.1) Escribir en el valor "Icon" "cmd.exe"
            '   2) Crear la llave SOFTWARE\\Classes\\Directory\\Background\\shell\\OICMD\\command
            '       2.0) Escribir en el valor defecto "cmd.exe"

            Dim Ruta1 As String = "SOFTWARE\\Classes\\Directory\\Background\\shell\\OICMD"
            Dim Ruta2 As String = Ruta1 & "\\command"

            Dim RegeditWriter1 As RegistryKey
            RegeditWriter1 = Registry.CurrentUser.OpenSubKey(Ruta1, True)
            If RegeditWriter1 Is Nothing Then
                Registry.CurrentUser.CreateSubKey(Ruta1)
                RegeditWriter1 = Registry.CurrentUser.OpenSubKey(Ruta1, True)
            End If
            RegeditWriter1.SetValue("", "Open in CMD", RegistryValueKind.String)
            RegeditWriter1.SetValue("Icon", "‪cmd.exe", RegistryValueKind.String)

            Dim RegeditWriter2 As RegistryKey
            RegeditWriter2 = Registry.CurrentUser.OpenSubKey(Ruta2, True)
            If RegeditWriter2 Is Nothing Then
                Registry.CurrentUser.CreateSubKey(Ruta2)
                RegeditWriter2 = Registry.CurrentUser.OpenSubKey(Ruta2, True)
            End If
            'RegeditWriter2.SetValue("", """" & "cmd.exe" & """" & " cd " & "%V", RegistryValueKind.String)
            RegeditWriter2.SetValue("", """" & "cmd.exe" & """", RegistryValueKind.String)

        Catch ex As Exception
            'MsgBox("Error al crear la llave." & vbCrLf & ex.Message)
            AddToLog("Create_OpenWithCommandPrompt", "Error: " & ex.Message, True)
        End Try
    End Sub 'Pass 15/08/2021 04:09 PM. Rev 05:09 PM

    Sub Create_OpenIn(Optional ByVal opt As SByte = 0)
        Try
            'Idea principal. Crear un menu de cascada "Open in". OI = OpenIn
            '   1) Crear la llave SOFTWARE\\Classes\\Directory\\Background\\shell\\OI
            '       1.0) Escribir el valor MUIVerb y poner el valor "Open in"
            '       1.1) Escribir el valor subcommands vacio
            '   2) Crear la llave SOFTWARE\\Classes\\Directory\\Background\\shell\\OI\\shell
            '   3) Crear la llave SOFTWARE\\Classes\\Directory\\Background\\shell\\OI\\shell\\NewWindows
            '       3.0) Escribir el valor defecto el valor "In a new windows"
            '       3.1) Escribir el valor "Icon" con el valor "explorer.exe"
            '   4) Crear la llave SOFTWARE\\Classes\\Directory\\Background\\shell\\OI\\shell\\NewWindows\\command
            '       4.0) Escribir el valor "explorer.exe %V" en el valor defecto



            Dim Ruta1 As String = "SOFTWARE\\Classes\\Directory\\Background\\shell\\OI"
            Dim Ruta2 As String = Ruta1 & "\\shell"
            Dim Ruta3 As String = Ruta2 & "\\InCMD"
            Dim Ruta4 As String = Ruta3 & "\\command"
            Dim Ruta5 As String = Ruta2 & "\\NewWindows"
            Dim Ruta6 As String = Ruta5 & "\\command"
            Dim Ruta7 As String = Ruta2 & "\\PowerShell"
            Dim Ruta8 As String = Ruta7 & "\\command"

            If opt = 0 Then
                Dim RegeditWriter1 As RegistryKey
                RegeditWriter1 = Registry.CurrentUser.OpenSubKey(Ruta1, True)
                If RegeditWriter1 Is Nothing Then
                    Registry.CurrentUser.CreateSubKey(Ruta1)
                    RegeditWriter1 = Registry.CurrentUser.OpenSubKey(Ruta1, True)
                End If
                RegeditWriter1.SetValue("MUIVerb", "Open in", RegistryValueKind.String)
                RegeditWriter1.SetValue("subcommands", "", RegistryValueKind.String)

                Dim RegeditWriter2 As RegistryKey
                RegeditWriter2 = Registry.CurrentUser.OpenSubKey(Ruta2, True)
                If RegeditWriter2 Is Nothing Then
                    Registry.CurrentUser.CreateSubKey(Ruta2)
                    RegeditWriter2 = Registry.CurrentUser.OpenSubKey(Ruta2, True)
                End If
            End If

            If opt = 1 Then
                Dim RegeditWriter1 As RegistryKey
                RegeditWriter1 = Registry.CurrentUser.OpenSubKey(Ruta3, True)
                If RegeditWriter1 Is Nothing Then
                    Registry.CurrentUser.CreateSubKey(Ruta3)
                    RegeditWriter1 = Registry.CurrentUser.OpenSubKey(Ruta3, True)
                End If
                RegeditWriter1.SetValue("", "in Command prompt", RegistryValueKind.String)
                RegeditWriter1.SetValue("Icon", "‪cmd.exe", RegistryValueKind.String)

                Dim RegeditWriter2 As RegistryKey
                RegeditWriter2 = Registry.CurrentUser.OpenSubKey(Ruta4, True)
                If RegeditWriter2 Is Nothing Then
                    Registry.CurrentUser.CreateSubKey(Ruta4)
                    RegeditWriter2 = Registry.CurrentUser.OpenSubKey(Ruta4, True)
                End If
                RegeditWriter2.SetValue("", """" & "cmd.exe" & """", RegistryValueKind.String)
            End If

            If opt = 2 Then
                Dim RegeditWriter3 As RegistryKey
                RegeditWriter3 = Registry.CurrentUser.OpenSubKey(Ruta5, True)
                If RegeditWriter3 Is Nothing Then
                    Registry.CurrentUser.CreateSubKey(Ruta5)
                    RegeditWriter3 = Registry.CurrentUser.OpenSubKey(Ruta5, True)
                End If
                RegeditWriter3.SetValue("", "In a new windows", RegistryValueKind.String)
                RegeditWriter3.SetValue("Icon", "explorer.exe", RegistryValueKind.String)

                Dim RegeditWriter4 As RegistryKey
                RegeditWriter4 = Registry.CurrentUser.OpenSubKey(Ruta6, True)
                If RegeditWriter4 Is Nothing Then
                    Registry.CurrentUser.CreateSubKey(Ruta6)
                    RegeditWriter4 = Registry.CurrentUser.OpenSubKey(Ruta6, True)
                End If
                RegeditWriter4.SetValue("", """" & "explorer.exe" & """" & "%V", RegistryValueKind.String)
            End If

            If opt = 3 Then
                Dim RegeditWriter5 As RegistryKey
                RegeditWriter5 = Registry.CurrentUser.OpenSubKey(Ruta7, True)
                If RegeditWriter5 Is Nothing Then
                    Registry.CurrentUser.CreateSubKey(Ruta7)
                    RegeditWriter5 = Registry.CurrentUser.OpenSubKey(Ruta7, True)
                End If
                RegeditWriter5.SetValue("", "In PowerShell", RegistryValueKind.String)
                RegeditWriter5.SetValue("Icon", "powershell.exe", RegistryValueKind.String)

                Dim RegeditWriter6 As RegistryKey
                RegeditWriter6 = Registry.CurrentUser.OpenSubKey(Ruta8, True)
                If RegeditWriter6 Is Nothing Then
                    Registry.CurrentUser.CreateSubKey(Ruta8)
                    RegeditWriter6 = Registry.CurrentUser.OpenSubKey(Ruta8, True)
                End If
                RegeditWriter6.SetValue("", """" & "powershell.exe" & """", RegistryValueKind.String)
            End If
        Catch ex As Exception
            'MsgBox("Error al crear la llave." & vbCrLf & ex.Message)
            AddToLog("Create_OpenInNewWindows", "Error: " & ex.Message, True)
        End Try
    End Sub
#End Region

#Region "Archivos"
    Sub Create_GetLocation()
        Try

            'Idea principal. Crear un menu  "GetLocation". GL = GetLocation
            '   1) Crear la llave SOFTWARE\\Classes\\*\\shell\\GL
            '       1.0) Escribir en el valor default el valor "Get Location"
            '       1.1) Escribir en el valor "Icon" el valor "ruta_a_un_icono_aqui"
            '   2) Crear la llave SOFTWARE\\Classes\\*\\shell\\GL\\command
            '       2.0) Escribir el valor "Application.Exectuable & "/WindowsCall>GetLocation>%L"" en el valor defecto



            Dim Ruta1 As String = "SOFTWARE\\Classes\\*\\shell\\GL"
            Dim Ruta2 As String = Ruta1 & "\\command"

            Dim RegeditWriter1 As RegistryKey
            RegeditWriter1 = Registry.CurrentUser.OpenSubKey(Ruta1, True)
            If RegeditWriter1 Is Nothing Then
                Registry.CurrentUser.CreateSubKey(Ruta1)
                RegeditWriter1 = Registry.CurrentUser.OpenSubKey(Ruta1, True)
            End If
            RegeditWriter1.SetValue("", "Get Location", RegistryValueKind.String)
            'RegeditWriter1.SetValue("Icon", "ruta_a_un_icono_aqui", RegistryValueKind.String)

            Dim RegeditWriter2 As RegistryKey
            RegeditWriter2 = Registry.CurrentUser.OpenSubKey(Ruta2, True)
            If RegeditWriter2 Is Nothing Then
                Registry.CurrentUser.CreateSubKey(Ruta2)
                RegeditWriter2 = Registry.CurrentUser.OpenSubKey(Ruta2, True)
            End If
            RegeditWriter2.SetValue("", """" & Application.ExecutablePath & "" & """" & "/WindowsCall>GetLocation>%V", RegistryValueKind.String)

        Catch ex As Exception
            'MsgBox("Error al crear la llave." & vbCrLf & ex.Message)
            AddToLog("Create_GetLocation", "Error: " & ex.Message, True)
        End Try
    End Sub 'Pass 15/08/2021 06:43 PM

    Sub Create_OpenWith(Optional ByVal opt As SByte = 0)
        Try
            'Idea principal. Crear un menu en cascada con opciones "Abrir con". OW = OpenWith
            '   1) Crear la llave SOFTWARE\\Classes\\*\\shell\\OW
            '       1.0) Escribir el valor MUIVerb y poner el valor "Open with"
            '       1.1) Escribir el valor subcommands vacio
            '   2) Crear la llave SOFTWARE\\Classes\\*\\shell\\OW\\shell
            '   3) Crear la llave SOFTWARE\\Classes\\*\\shell\\OW\\shell\\Notepad
            '       3.0) Escribir el valor defecto el valor "Notepad"
            '       3.1) Escribir el valor "Icon" con el valor "notepad.exe"
            '   4) Crear la llave SOFTWARE\\Classes\\*\\shell\\OW\\shell\\Notepad\\command
            '       4.0) Escribir el valor "notepad.exe %L" en el valor defecto

            Dim Ruta1 As String = "SOFTWARE\\Classes\\*\\shell\\OW"
            Dim Ruta2 As String = Ruta1 & "\\shell"
            Dim Ruta3 As String = Ruta2 & "\\Notepad"
            Dim Ruta4 As String = Ruta3 & "\\command"



            If opt = 0 Then 'Crear la OpenWith main cascade menu
                Dim RegeditWriter1 As RegistryKey
                RegeditWriter1 = Registry.CurrentUser.OpenSubKey(Ruta1, True)
                If RegeditWriter1 Is Nothing Then
                    Registry.CurrentUser.CreateSubKey(Ruta1)
                    RegeditWriter1 = Registry.CurrentUser.OpenSubKey(Ruta1, True)
                End If
                RegeditWriter1.SetValue("MUIVerb", "Open with", RegistryValueKind.String)
                RegeditWriter1.SetValue("subcommands", "", RegistryValueKind.String)

                Dim RegeditWriter2 As RegistryKey
                RegeditWriter2 = Registry.CurrentUser.OpenSubKey(Ruta2, True)
                If RegeditWriter2 Is Nothing Then
                    Registry.CurrentUser.CreateSubKey(Ruta2)
                    RegeditWriter2 = Registry.CurrentUser.OpenSubKey(Ruta2, True)
                End If
            End If

            If opt = 1 Then 'Si se selecciona la opcion 1 (OpenWith>Notepad)
                Dim RegeditWriter3 As RegistryKey
                RegeditWriter3 = Registry.CurrentUser.OpenSubKey(Ruta3, True)
                If RegeditWriter3 Is Nothing Then
                    Registry.CurrentUser.CreateSubKey(Ruta3)
                    RegeditWriter3 = Registry.CurrentUser.OpenSubKey(Ruta3, True)
                End If
                RegeditWriter3.SetValue("", "Notepad", RegistryValueKind.String)
                RegeditWriter3.SetValue("Icon", "notepad.exe", RegistryValueKind.String)

                Dim RegeditWriter4 As RegistryKey
                RegeditWriter4 = Registry.CurrentUser.OpenSubKey(Ruta4, True)
                If RegeditWriter4 Is Nothing Then
                    Registry.CurrentUser.CreateSubKey(Ruta4)
                    RegeditWriter4 = Registry.CurrentUser.OpenSubKey(Ruta4, True)
                End If
                RegeditWriter4.SetValue("", """" & "notepad.exe" & """" & "%L", RegistryValueKind.String)
            End If

        Catch ex As Exception
            'MsgBox("Error al crear la llave." & vbCrLf & ex.Message)
            AddToLog("Create_OpenWith", "Error: " & ex.Message, True)
        End Try
    End Sub 'Pass 15/08/2021 04:34 PM
#End Region

    Sub AddToLog(ByVal from As String, ByVal content As String, Optional ByVal flag As Boolean = False)
        Try

            Dim finalContent As String
            If flag = True Then
                finalContent = "[!!!]" & content
            Else
                finalContent = content
            End If

            Console.WriteLine(DateTime.Now.ToString("hh:mm:ss tt dd/MM/yyyy ") & from & " " & finalContent)

        Catch ex As Exception
            Console.WriteLine("[AddToLog@Complementos]Error: " & ex.Message)
        End Try
    End Sub

End Module
Module WindowsCalls
    Public StartParameter As String

    Sub ReadParameter(ByVal arg As String)
        Main.FormBorderStyle = FormBorderStyle.FixedToolWindow
        Main.WindowState = FormWindowState.Minimized
        Main.ShowInTaskbar = False
        Main.Hide()
        Try

            StartParameter = Command()
            Dim argumentos As String() = Command().Split(" ")
            Dim newArg As String() = Command().Split(">")

            For Each args As String In argumentos
                If args.StartsWith("/WindowsCall") Then
                    'Formato: "/WindosCall>GetLocation>C:\...\...\..."
                    If newArg(1) = "GetLocation" Then
                        GetLocation(newArg(2)) 'Pass 15/08/2021 06:58 PM
                    End If
                End If
            Next

        Catch ex As Exception
            AddToLog("ReadParameter", "Error: " & ex.Message, True)
        End Try
    End Sub

    Sub GetLocation(ByVal file As String)
        Try
            My.Computer.Clipboard.SetText(file)
            Main.Notifyer.ShowBalloonTip(500, "Get location", "Copied path " & file, ToolTipIcon.Info)
            Threading.Thread.Sleep(150)
            End 'Finaliza la aplicacion una vez mostrado el mensaje
        Catch ex As Exception
            AddToLog("GetLocation", "Error: " & ex.Message, True)
        End Try
    End Sub 'Pass 15/08/2021 06:53 PM

End Module 'En desarrollo
Module InstalledApplications

    Sub CheckForApps()
        Try

        Catch ex As Exception
            AddToLog("CheckForApps", "Error: " & ex.Message, True)
        End Try
    End Sub

End Module 'En desarrollo