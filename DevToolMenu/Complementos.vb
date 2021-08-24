Imports Microsoft.Win32
Module Complementos

#Region "Directorios"
    Sub InsideFolder_DirCreate_OpenIn(Optional ByVal opt As SByte = 0)
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
                RegeditWriter1.SetValue("Icon", Application.ExecutablePath, RegistryValueKind.String)
                RegeditWriter1.SetValue("MUIVerb", "Open in", RegistryValueKind.String)
                RegeditWriter1.SetValue("subcommands", "", RegistryValueKind.String)

                Dim RegeditWriter2 As RegistryKey
                RegeditWriter2 = Registry.CurrentUser.OpenSubKey(Ruta2, True)
                If RegeditWriter2 Is Nothing Then
                    Registry.CurrentUser.CreateSubKey(Ruta2)
                    RegeditWriter2 = Registry.CurrentUser.OpenSubKey(Ruta2, True)
                End If
                InsideFolder_Dir_OpenIn = True
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
                InsideFolder_Dir_OpenIn_InCommandPrompt = True
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
                InsideFolder_Dir_OpenIn_InANewFolder = True
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
                InsideFolder_Dir_OpenIn_InPowerShell = True
            End If
        Catch ex As Exception
            'MsgBox("Error al crear la llave." & vbCrLf & ex.Message)
            AddToLog("InsideFolder_DirCreate_OpenIn", "Error: " & ex.Message, True)
        End Try
    End Sub
    Sub SelectFolder_DirCreate_OpenIn(Optional ByVal opt As SByte = 0)
        Try
            'Idea principal. Crear un menu de cascada "Open in". OI = OpenIn
            '   1) Crear la llave SOFTWARE\\Classes\\Directory\\shell
            '       1.0) Escribir el valor MUIVerb y poner el valor "Open in"
            '       1.1) Escribir el valor subcommands vacio
            '   2) Crear la llave SOFTWARE\\Classes\\Directory\\shell\\OI\\shell
            '   3) Crear la llave SOFTWARE\\Classes\\Directory\\shell\\OI\\shell\\NewWindows
            '       3.0) Escribir el valor defecto el valor "In a new windows"
            '       3.1) Escribir el valor "Icon" con el valor "explorer.exe"
            '   4) Crear la llave SOFTWARE\\Classes\\Directory\\shell\\OI\\shell\\NewWindows\\command
            '       4.0) Escribir el valor "explorer.exe %V" en el valor defecto

            Dim Ruta1 As String = "SOFTWARE\\Classes\\Directory\\shell\\OI"
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
                RegeditWriter1.SetValue("Icon", Application.ExecutablePath, RegistryValueKind.String)
                RegeditWriter1.SetValue("MUIVerb", "Open in", RegistryValueKind.String)
                RegeditWriter1.SetValue("subcommands", "", RegistryValueKind.String)

                Dim RegeditWriter2 As RegistryKey
                RegeditWriter2 = Registry.CurrentUser.OpenSubKey(Ruta2, True)
                If RegeditWriter2 Is Nothing Then
                    Registry.CurrentUser.CreateSubKey(Ruta2)
                    RegeditWriter2 = Registry.CurrentUser.OpenSubKey(Ruta2, True)
                End If
                SelectFolder_Dir_OpenIn = True
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
                RegeditWriter2.SetValue("", """" & "cmd.exe" & """" & " /K " & """" & "cd %V" & """", RegistryValueKind.String)
                SelectFolder_Dir_OpenIn_InCommandPrompt = True
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
                SelectFolder_Dir_OpenIn_InANewFolder = True
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
                RegeditWriter6.SetValue("", """" & "powershell.exe" & """" & " -noexit -command " & """" & "cd %V" & """", RegistryValueKind.String)
                SelectFolder_Dir_OpenIn_InPowerShell = True
            End If
        Catch ex As Exception
            'MsgBox("Error al crear la llave." & vbCrLf & ex.Message)
            AddToLog("SelectFolder_DirCreate_OpenIn", "Error: " & ex.Message, True)
        End Try
    End Sub
    Sub InsideFolder_DirCreate_GetLocation(Optional ByVal delete As Boolean = False)
        Try

            'Idea principal. Crear un menu  "GetLocation". GL = GetLocation
            '   1) Crear la llave SOFTWARE\\Classes\\Directory\\Background\\shell\\GL
            '       1.0) Escribir en el valor default el valor "Get Location"
            '       1.1) Escribir en el valor "Icon" el valor "ruta_a_un_icono_aqui"
            '   2) Crear la llave SOFTWARE\\Classes\\Directory\\Background\\shell\\GL\\command
            '       2.0) Escribir el valor "Application.Exectuable & "/WindowsCall>GetLocation>%L"" en el valor defecto



            Dim Ruta1 As String = "SOFTWARE\\Classes\\Directory\\Background\\shell"
            Dim Ruta2 As String = Ruta1 & "\\GL"
            Dim Ruta3 As String = Ruta2 & "\\command"
            If delete = False Then
                Dim RegeditWriter1 As RegistryKey
                RegeditWriter1 = Registry.CurrentUser.OpenSubKey(Ruta2, True)
                If RegeditWriter1 Is Nothing Then
                    Registry.CurrentUser.CreateSubKey(Ruta2)
                    RegeditWriter1 = Registry.CurrentUser.OpenSubKey(Ruta2, True)
                End If
                RegeditWriter1.SetValue("", "Get Location", RegistryValueKind.String)
                RegeditWriter1.SetValue("Icon", Application.ExecutablePath, RegistryValueKind.String)

                Dim RegeditWriter2 As RegistryKey
                RegeditWriter2 = Registry.CurrentUser.OpenSubKey(Ruta3, True)
                If RegeditWriter2 Is Nothing Then
                    Registry.CurrentUser.CreateSubKey(Ruta3)
                    RegeditWriter2 = Registry.CurrentUser.OpenSubKey(Ruta3, True)
                End If
                RegeditWriter2.SetValue("", """" & Application.ExecutablePath & "" & """" & "/WindowsCall>GetLocation>%V", RegistryValueKind.String)
                InsideFolder_Dir_GetLocation = True
            Else
                'eliminar
                Dim RegeditWriter1 As RegistryKey
                RegeditWriter1 = Registry.CurrentUser.OpenSubKey(Ruta1, True)
                If RegeditWriter1 Is Nothing Then
                    Exit Sub
                End If
                RegeditWriter1.DeleteSubKeyTree("GL")
                InsideFolder_Dir_GetLocation = False
            End If
        Catch ex As Exception
            'MsgBox("Error al crear la llave." & vbCrLf & ex.Message)
            AddToLog("InsideFolder_DirCreate_GetLocation", "Error: " & ex.Message, True)
        End Try
    End Sub
    Sub SelectFolder_DirCreate_GetLocation(Optional ByVal delete As Boolean = False)
        Try

            'Idea principal. Crear un menu  "GetLocation". GL = GetLocation
            '   1) Crear la llave SOFTWARE\\Classes\\Directory\\shell\\GL
            '       1.0) Escribir en el valor default el valor "Get Location"
            '       1.1) Escribir en el valor "Icon" el valor "ruta_a_un_icono_aqui"
            '   2) Crear la llave SOFTWARE\\Classes\\Directory\\shell\\GL\\command
            '       2.0) Escribir el valor "Application.Exectuable & "/WindowsCall>GetLocation>%L"" en el valor defecto



            Dim Ruta1 As String = "SOFTWARE\\Classes\\Directory\\shell"
            Dim Ruta2 As String = Ruta1 & "\\GL"
            Dim Ruta3 As String = Ruta2 & "\\command"
            If delete = False Then
                Dim RegeditWriter1 As RegistryKey
                RegeditWriter1 = Registry.CurrentUser.OpenSubKey(Ruta2, True)
                If RegeditWriter1 Is Nothing Then
                    Registry.CurrentUser.CreateSubKey(Ruta2)
                    RegeditWriter1 = Registry.CurrentUser.OpenSubKey(Ruta2, True)
                End If
                RegeditWriter1.SetValue("", "Get Location", RegistryValueKind.String)
                RegeditWriter1.SetValue("Icon", Application.ExecutablePath, RegistryValueKind.String)

                Dim RegeditWriter2 As RegistryKey
                RegeditWriter2 = Registry.CurrentUser.OpenSubKey(Ruta3, True)
                If RegeditWriter2 Is Nothing Then
                    Registry.CurrentUser.CreateSubKey(Ruta3)
                    RegeditWriter2 = Registry.CurrentUser.OpenSubKey(Ruta3, True)
                End If
                RegeditWriter2.SetValue("", """" & Application.ExecutablePath & "" & """" & "/WindowsCall>GetLocation>%V", RegistryValueKind.String)
                SelectFolder_Dir_GetLocation = True
            Else
                'eliminar
                Dim RegeditWriter1 As RegistryKey
                RegeditWriter1 = Registry.CurrentUser.OpenSubKey(Ruta1, True)
                If RegeditWriter1 Is Nothing Then
                    Exit Sub
                End If
                RegeditWriter1.DeleteSubKeyTree("GL")
                SelectFolder_Dir_GetLocation = False
            End If
        Catch ex As Exception
            'MsgBox("Error al crear la llave." & vbCrLf & ex.Message)
            AddToLog("SelectFolder_DirCreate_GetLocation", "Error: " & ex.Message, True)
        End Try
    End Sub

    Sub InsideFolder_DirRemover_OpenIn(Optional ByVal opt As SByte = 0)
        Try
            'SOFTWARE\Classes\Directory\Background\shell
            Dim Ruta1 As String = "SOFTWARE\\Classes\\Directory\\Background\\shell"
            Dim Ruta2 As String = Ruta1 & "\\OI\\shell"

            If opt = 0 Then
                If InsideFolder_Dir_OpenIn = True Then
                    Dim RegeditWriter1 As RegistryKey
                    RegeditWriter1 = Registry.CurrentUser.OpenSubKey(Ruta1, True)
                    If RegeditWriter1 Is Nothing Then
                        Exit Sub
                    End If
                    RegeditWriter1.DeleteSubKeyTree("OI")
                    InsideFolder_Dir_OpenIn = False
                End If
            End If

            If opt = 1 Then
                If InsideFolder_Dir_OpenIn_InCommandPrompt = True Then
                    Dim RegeditWriter1 As RegistryKey
                    RegeditWriter1 = Registry.CurrentUser.OpenSubKey(Ruta2, True)
                    If RegeditWriter1 Is Nothing Then
                        Exit Sub
                    End If
                    RegeditWriter1.DeleteSubKeyTree("InCMD")
                    InsideFolder_Dir_OpenIn_InCommandPrompt = False
                End If
            End If

            If opt = 2 Then
                If InsideFolder_Dir_OpenIn_InANewFolder = True Then
                    Dim RegeditWriter3 As RegistryKey
                    RegeditWriter3 = Registry.CurrentUser.OpenSubKey(Ruta2, True)
                    If RegeditWriter3 Is Nothing Then
                        Exit Sub
                    End If
                    RegeditWriter3.DeleteSubKeyTree("NewWindows")
                    InsideFolder_Dir_OpenIn_InANewFolder = False
                End If
            End If

            If opt = 3 Then
                If InsideFolder_Dir_OpenIn_InPowerShell = True Then
                    Dim RegeditWriter5 As RegistryKey
                    RegeditWriter5 = Registry.CurrentUser.OpenSubKey(Ruta2, True)
                    If RegeditWriter5 Is Nothing Then
                        Exit Sub
                    End If
                    RegeditWriter5.DeleteSubKeyTree("PowerShell")
                    InsideFolder_Dir_OpenIn_InPowerShell = False
                End If
            End If
        Catch ex As Exception
            'MsgBox("Error al crear la llave." & vbCrLf & ex.Message)
            AddToLog("InsideFolder_DirRemover_OpenIn", "Error: " & ex.Message, True)
        End Try
    End Sub
    Sub SelectFolder_DirRemover_OpenIn(Optional ByVal opt As SByte = 0)
        Try
            'SOFTWARE\Classes\Directory\shell
            Dim Ruta1 As String = "SOFTWARE\\Classes\\Directory\\shell"
            Dim Ruta2 As String = Ruta1 & "\\OI\\shell"

            If opt = 0 Then
                If SelectFolder_Dir_OpenIn = True Then
                    Dim RegeditWriter1 As RegistryKey
                    RegeditWriter1 = Registry.CurrentUser.OpenSubKey(Ruta1, True)
                    If RegeditWriter1 Is Nothing Then
                        Exit Sub
                    End If
                    RegeditWriter1.DeleteSubKeyTree("OI")
                    SelectFolder_Dir_OpenIn = False
                End If
            End If

            If opt = 1 Then
                If SelectFolder_Dir_OpenIn_InCommandPrompt = True Then
                    Dim RegeditWriter1 As RegistryKey
                    RegeditWriter1 = Registry.CurrentUser.OpenSubKey(Ruta2, True)
                    If RegeditWriter1 Is Nothing Then
                        Exit Sub
                    End If
                    RegeditWriter1.DeleteSubKeyTree("InCMD")
                    SelectFolder_Dir_OpenIn_InCommandPrompt = False
                End If
            End If

            If opt = 2 Then
                If SelectFolder_Dir_OpenIn_InANewFolder = True Then
                    Dim RegeditWriter3 As RegistryKey
                    RegeditWriter3 = Registry.CurrentUser.OpenSubKey(Ruta2, True)
                    If RegeditWriter3 Is Nothing Then
                        Exit Sub
                    End If
                    RegeditWriter3.DeleteSubKeyTree("NewWindows")
                    SelectFolder_Dir_OpenIn_InANewFolder = False
                End If
            End If

            If opt = 3 Then
                If SelectFolder_Dir_OpenIn_InPowerShell = True Then
                    Dim RegeditWriter5 As RegistryKey
                    RegeditWriter5 = Registry.CurrentUser.OpenSubKey(Ruta2, True)
                    If RegeditWriter5 Is Nothing Then
                        Exit Sub
                    End If
                    RegeditWriter5.DeleteSubKeyTree("PowerShell")
                    SelectFolder_Dir_OpenIn_InPowerShell = False
                End If
            End If
        Catch ex As Exception
            'MsgBox("Error al crear la llave." & vbCrLf & ex.Message)
            AddToLog("SelectFolder_DirRemover_OpenIn", "Error: " & ex.Message, True)
        End Try
    End Sub
#End Region

#Region "Archivos"
    Sub Create_GetLocation(Optional ByVal delete As Boolean = False)
        Try

            'Idea principal. Crear un menu  "GetLocation". GL = GetLocation
            '   1) Crear la llave SOFTWARE\\Classes\\*\\shell\\GL
            '       1.0) Escribir en el valor default el valor "Get Location"
            '       1.1) Escribir en el valor "Icon" el valor "ruta_a_un_icono_aqui"
            '   2) Crear la llave SOFTWARE\\Classes\\*\\shell\\GL\\command
            '       2.0) Escribir el valor "Application.Exectuable & "/WindowsCall>GetLocation>%L"" en el valor defecto



            Dim Ruta1 As String = "SOFTWARE\\Classes\\*\\shell"
            Dim Ruta2 As String = Ruta1 & "\\GL"
            Dim Ruta3 As String = Ruta2 & "\\command"
            If delete = False Then
                Dim RegeditWriter1 As RegistryKey
                RegeditWriter1 = Registry.CurrentUser.OpenSubKey(Ruta2, True)
                If RegeditWriter1 Is Nothing Then
                    Registry.CurrentUser.CreateSubKey(Ruta2)
                    RegeditWriter1 = Registry.CurrentUser.OpenSubKey(Ruta2, True)
                End If
                RegeditWriter1.SetValue("", "Get Location", RegistryValueKind.String)
                RegeditWriter1.SetValue("Icon", Application.ExecutablePath, RegistryValueKind.String)

                Dim RegeditWriter2 As RegistryKey
                RegeditWriter2 = Registry.CurrentUser.OpenSubKey(Ruta3, True)
                If RegeditWriter2 Is Nothing Then
                    Registry.CurrentUser.CreateSubKey(Ruta3)
                    RegeditWriter2 = Registry.CurrentUser.OpenSubKey(Ruta3, True)
                End If
                RegeditWriter2.SetValue("", """" & Application.ExecutablePath & "" & """" & "/WindowsCall>GetLocation>%V", RegistryValueKind.String)
                File_GetLocation = True
            Else
                'eliminar
                Dim RegeditWriter1 As RegistryKey
                RegeditWriter1 = Registry.CurrentUser.OpenSubKey(Ruta1, True)
                If RegeditWriter1 Is Nothing Then
                    Exit Sub
                End If
                RegeditWriter1.DeleteSubKeyTree("GL")
                File_GetLocation = False
            End If
        Catch ex As Exception
            'MsgBox("Error al crear la llave." & vbCrLf & ex.Message)
            AddToLog("Create_GetLocation", "Error: " & ex.Message, True)
        End Try
    End Sub

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
                RegeditWriter1.SetValue("Icon", Application.ExecutablePath, RegistryValueKind.String)
                RegeditWriter1.SetValue("MUIVerb", "Open with", RegistryValueKind.String)
                RegeditWriter1.SetValue("subcommands", "", RegistryValueKind.String)

                Dim RegeditWriter2 As RegistryKey
                RegeditWriter2 = Registry.CurrentUser.OpenSubKey(Ruta2, True)
                If RegeditWriter2 Is Nothing Then
                    Registry.CurrentUser.CreateSubKey(Ruta2)
                    RegeditWriter2 = Registry.CurrentUser.OpenSubKey(Ruta2, True)
                End If
                File_OpenWith = True
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
                File_OpenWith_Notepad = True
            End If

        Catch ex As Exception
            'MsgBox("Error al crear la llave." & vbCrLf & ex.Message)
            AddToLog("Create_OpenWith", "Error: " & ex.Message, True)
        End Try
    End Sub
    Sub Remover_OpenWith(Optional ByVal opt As SByte = 0)
        Try

            Dim Ruta1 As String = "SOFTWARE\\Classes\\*\\shell"
            Dim Ruta2 As String = Ruta1 & "\\OW\\shell"



            If opt = 0 Then
                If File_OpenWith = True Then
                    Dim RegeditWriter1 As RegistryKey
                    RegeditWriter1 = Registry.CurrentUser.OpenSubKey(Ruta1, True)
                    If RegeditWriter1 Is Nothing Then
                        Registry.CurrentUser.CreateSubKey(Ruta1)
                        RegeditWriter1 = Registry.CurrentUser.OpenSubKey(Ruta1, True)
                    End If
                    RegeditWriter1.DeleteSubKeyTree("OW")
                    File_OpenWith = False
                End If
            End If

            If opt = 1 Then
                If File_OpenWith_Notepad = True Then
                    Dim RegeditWriter2 As RegistryKey
                    RegeditWriter2 = Registry.CurrentUser.OpenSubKey(Ruta2, True)
                    If RegeditWriter2 Is Nothing Then
                        Registry.CurrentUser.CreateSubKey(Ruta2)
                        RegeditWriter2 = Registry.CurrentUser.OpenSubKey(Ruta2, True)
                    End If
                    RegeditWriter2.DeleteSubKeyTree("Notepad")
                    File_OpenWith_Notepad = False
                End If
            End If

        Catch ex As Exception
            'MsgBox("Error al crear la llave." & vbCrLf & ex.Message)
            AddToLog("Remover_OpenWith", "Error: " & ex.Message, True)
        End Try
    End Sub
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


    Public InsideFolder_Dir_OpenIn As Boolean = False
    Public InsideFolder_Dir_OpenIn_InCommandPrompt As Boolean = False
    Public InsideFolder_Dir_OpenIn_InANewFolder As Boolean = False
    Public InsideFolder_Dir_OpenIn_InPowerShell As Boolean = False
    Public InsideFolder_Dir_GetLocation As Boolean = False
    Public SelectFolder_Dir_OpenIn As Boolean = False
    Public SelectFolder_Dir_OpenIn_InCommandPrompt As Boolean = False
    Public SelectFolder_Dir_OpenIn_InANewFolder As Boolean = False
    Public SelectFolder_Dir_OpenIn_InPowerShell As Boolean = False
    Public SelectFolder_Dir_GetLocation As Boolean = False

    Public File_GetLocation As Boolean = False
    Public File_OpenWith As Boolean = False
    Public File_OpenWith_Notepad As Boolean = False

    Sub SaveDB()
        Try
            Dim RutaBaseDatos As String = "SOFTWARE\\CRZ Labs\\DevToolMenu"
            Dim BaseDataRegeditWriter As RegistryKey
            BaseDataRegeditWriter = Registry.CurrentUser.OpenSubKey(RutaBaseDatos, True)
            If BaseDataRegeditWriter Is Nothing Then
                Registry.CurrentUser.CreateSubKey(RutaBaseDatos)
                BaseDataRegeditWriter = Registry.CurrentUser.OpenSubKey(RutaBaseDatos, True)
            End If
            BaseDataRegeditWriter.SetValue("Assembly", My.Application.Info.AssemblyName, RegistryValueKind.String)
            BaseDataRegeditWriter.SetValue("Version", My.Application.Info.Version.ToString, RegistryValueKind.String)
            BaseDataRegeditWriter.SetValue("Compilated", Application.ProductVersion, RegistryValueKind.String)
            BaseDataRegeditWriter.SetValue("Assembly Path", Application.ExecutablePath, RegistryValueKind.String)
            BaseDataRegeditWriter.SetValue("Path", Application.StartupPath, RegistryValueKind.String)

            Dim RutaConfig As String = "SOFTWARE\\CRZ Labs\\DevToolMenu\\Config"
            Dim ConfigDataRegeditWriter As RegistryKey
            ConfigDataRegeditWriter = Registry.CurrentUser.OpenSubKey(RutaConfig, True)
            If ConfigDataRegeditWriter Is Nothing Then
                Registry.CurrentUser.CreateSubKey(RutaConfig)
                ConfigDataRegeditWriter = Registry.CurrentUser.OpenSubKey(RutaConfig, True)
            End If

            'Directorios
            '   Inside a Folder
            ConfigDataRegeditWriter.SetValue("InsideFolder_Dir_OpenIn", InsideFolder_Dir_OpenIn, RegistryValueKind.String)
            ConfigDataRegeditWriter.SetValue("InsideFolder_Dir_OpenIn_InCommandPrompt", InsideFolder_Dir_OpenIn_InCommandPrompt, RegistryValueKind.String)
            ConfigDataRegeditWriter.SetValue("InsideFolder_Dir_OpenIn_InANewFolder", InsideFolder_Dir_OpenIn_InANewFolder, RegistryValueKind.String)
            ConfigDataRegeditWriter.SetValue("InsideFolder_Dir_OpenIn_InPowerShell", InsideFolder_Dir_OpenIn_InPowerShell, RegistryValueKind.String)
            ConfigDataRegeditWriter.SetValue("InsideFolder_Dir_GetLocation", InsideFolder_Dir_GetLocation, RegistryValueKind.String)
            '   Select a Folder
            ConfigDataRegeditWriter.SetValue("SelectFolder_Dir_OpenIn", SelectFolder_Dir_OpenIn, RegistryValueKind.String)
            ConfigDataRegeditWriter.SetValue("SelectFolder_Dir_OpenIn_InCommandPrompt", SelectFolder_Dir_OpenIn_InCommandPrompt, RegistryValueKind.String)
            ConfigDataRegeditWriter.SetValue("SelectFolder_Dir_OpenIn_InANewFolder", SelectFolder_Dir_OpenIn_InANewFolder, RegistryValueKind.String)
            ConfigDataRegeditWriter.SetValue("SelectFolder_Dir_OpenIn_InPowerShell", SelectFolder_Dir_OpenIn_InPowerShell, RegistryValueKind.String)
            ConfigDataRegeditWriter.SetValue("SelectFolder_Dir_GetLocation", SelectFolder_Dir_GetLocation, RegistryValueKind.String)

            'Archivos
            ConfigDataRegeditWriter.SetValue("File_GetLocation", File_GetLocation, RegistryValueKind.String)
            ConfigDataRegeditWriter.SetValue("File_OpenWith", File_OpenWith, RegistryValueKind.String)
            ConfigDataRegeditWriter.SetValue("File_OpenWith_Notepad", File_OpenWith_Notepad, RegistryValueKind.String)

            LoadDB()
        Catch ex As Exception
            'MsgBox("Error al guardar el estado." & vbCrLf & ex.Message)
            AddToLog("SaveDB", "Error: " & ex.Message, True)
        End Try
    End Sub

    Sub LoadDB()
        Try

            Dim RutaConfig As String = "SOFTWARE\\CRZ Labs\\DevToolMenu\\Config"
            Dim ConfigDataRegeditWriter As RegistryKey
            ConfigDataRegeditWriter = Registry.CurrentUser.OpenSubKey(RutaConfig, True)
            If ConfigDataRegeditWriter Is Nothing Then
                Registry.CurrentUser.CreateSubKey(RutaConfig)
                ConfigDataRegeditWriter = Registry.CurrentUser.OpenSubKey(RutaConfig, True)
            End If
            'Directorios
            '   Inside a Folder
            InsideFolder_Dir_OpenIn = Boolean.Parse(ConfigDataRegeditWriter.GetValue("InsideFolder_Dir_OpenIn"))
            InsideFolder_Dir_OpenIn_InCommandPrompt = Boolean.Parse(ConfigDataRegeditWriter.GetValue("InsideFolder_Dir_OpenIn_InCommandPrompt"))
            InsideFolder_Dir_OpenIn_InANewFolder = Boolean.Parse(ConfigDataRegeditWriter.GetValue("InsideFolder_Dir_OpenIn_InANewFolder"))
            InsideFolder_Dir_OpenIn_InPowerShell = Boolean.Parse(ConfigDataRegeditWriter.GetValue("InsideFolder_Dir_OpenIn_InPowerShell"))
            InsideFolder_Dir_GetLocation = Boolean.Parse(ConfigDataRegeditWriter.GetValue("InsideFolder_Dir_GetLocation"))
            '   Select a Folder
            SelectFolder_Dir_OpenIn = Boolean.Parse(ConfigDataRegeditWriter.GetValue("SelectFolder_Dir_OpenIn"))
            SelectFolder_Dir_OpenIn_InCommandPrompt = Boolean.Parse(ConfigDataRegeditWriter.GetValue("SelectFolder_Dir_OpenIn_InCommandPrompt"))
            SelectFolder_Dir_OpenIn_InANewFolder = Boolean.Parse(ConfigDataRegeditWriter.GetValue("SelectFolder_Dir_OpenIn_InANewFolder"))
            SelectFolder_Dir_OpenIn_InPowerShell = Boolean.Parse(ConfigDataRegeditWriter.GetValue("SelectFolder_Dir_OpenIn_InPowerShell"))
            SelectFolder_Dir_GetLocation = Boolean.Parse(ConfigDataRegeditWriter.GetValue("SelectFolder_Dir_GetLocation"))

            File_GetLocation = Boolean.Parse(ConfigDataRegeditWriter.GetValue("File_GetLocation"))
            File_OpenWith = Boolean.Parse(ConfigDataRegeditWriter.GetValue("File_OpenWith"))
            File_OpenWith_Notepad = Boolean.Parse(ConfigDataRegeditWriter.GetValue("File_OpenWith_Notepad"))

            'Directorios
            '   Inside a Folder
            If InsideFolder_Dir_OpenIn = True Then
                Main.cb_InsideAFolder_Dir_OpenIn.CheckState = CheckState.Checked
            End If
            If InsideFolder_Dir_OpenIn_InCommandPrompt = True Then
                Main.cb_InsideAFolder_Dir_OpenIn_InCommandPrompt.CheckState = CheckState.Checked
            End If
            If InsideFolder_Dir_OpenIn_InANewFolder = True Then
                Main.cb_InsideAFolder_Dir_OpenIn_InANewFolder.CheckState = CheckState.Checked
            End If
            If InsideFolder_Dir_OpenIn_InPowerShell = True Then
                Main.cb_InsideAFolder_Dir_OpenIn_InPowerShell.CheckState = CheckState.Checked
            End If
            If InsideFolder_Dir_GetLocation = True Then
                Main.cb_InsideAFolder_Dir_GetLocation.CheckState = CheckState.Checked
            End If

            '   Select a Folder
            If SelectFolder_Dir_OpenIn = True Then
                Main.cb_SelectAFolder_Dir_OpenIn.CheckState = CheckState.Checked
            End If
            If SelectFolder_Dir_OpenIn_InCommandPrompt = True Then
                Main.cb_SelectAFolder_Dir_OpenIn_InCommandPrompt.CheckState = CheckState.Checked
            End If
            If SelectFolder_Dir_OpenIn_InANewFolder = True Then
                Main.cb_SelectAFolder_Dir_OpenIn_InANewFolder.CheckState = CheckState.Checked
            End If
            If SelectFolder_Dir_OpenIn_InPowerShell = True Then
                Main.cb_SelectAFolder_Dir_OpenIn_InPowerShell.CheckState = CheckState.Checked
            End If
            If SelectFolder_Dir_GetLocation = True Then
                Main.cb_SelectAFolder_Dir_GetLocation.CheckState = CheckState.Checked
            End If


            If File_GetLocation = True Then
                Main.cbFile_GetLocation.CheckState = CheckState.Checked
            End If
            If File_OpenWith = True Then
                Main.cbFile_OpenWith.CheckState = CheckState.Checked
            End If
            If File_OpenWith_Notepad = True Then
                Main.cbFile_OpenWith_Notepad.CheckState = CheckState.Checked
            End If
        Catch ex As Exception
            'MsgBox("Error al cargar el estado." & vbCrLf & ex.Message)
            AddToLog("LoadDB", "Error: " & ex.Message, True)
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