Imports System.Runtime.InteropServices
Imports System.Text
Imports Microsoft.Win32
Module Complementos
    Public DIRCommons As String = "C:\Users\" & Environment.UserName & "\AppData\Local\CRZ_Labs\DevToolMenu"

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
            Dim Ruta3 As String = Ruta2 & "\\In Command prompt"
            Dim Ruta4 As String = Ruta3 & "\\command"
            Dim Ruta5 As String = Ruta2 & "\\In a new windows"
            Dim Ruta6 As String = Ruta5 & "\\command"
            Dim Ruta7 As String = Ruta2 & "\\In PowerShell"
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
            Dim Ruta3 As String = Ruta2 & "\\In Command prompt"
            Dim Ruta4 As String = Ruta3 & "\\command"
            Dim Ruta5 As String = Ruta2 & "\\In a new windows"
            Dim Ruta6 As String = Ruta5 & "\\command"
            Dim Ruta7 As String = Ruta2 & "\\In PowerShell"
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
            Dim Ruta2 As String = Ruta1 & "\\Get Location"
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
                RegeditWriter1.DeleteSubKeyTree("Get Location")
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
            Dim Ruta2 As String = Ruta1 & "\\Get Location"
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
                RegeditWriter1.DeleteSubKeyTree("Get Location")
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
                    RegeditWriter1.DeleteSubKeyTree("in Command prompt")
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
                    RegeditWriter3.DeleteSubKeyTree("In a new windows")
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
                    RegeditWriter5.DeleteSubKeyTree("In PowerShell")
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
                    RegeditWriter1.DeleteSubKeyTree("in Command prompt")
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
                    RegeditWriter3.DeleteSubKeyTree("In a new windows")
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
                    RegeditWriter5.DeleteSubKeyTree("In PowerShell")
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
            Dim Ruta2 As String = Ruta1 & "\\Get Location"
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
                RegeditWriter1.DeleteSubKeyTree("Get Location")
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

#Region "Others"
#Region "Dir"
    Sub InsideFolder_DirCreate_OpenInOther(Optional ByVal opt As SByte = 0)
        Try

            Dim Ruta1 As String = "SOFTWARE\\Classes\\Directory\\Background\\shell\\OI"
            Dim Ruta2 As String = Ruta1 & "\\shell"

            If opt = 0 Then
                InsideFolder_Dir_OpenInOther = True
            End If

            If opt = 1 Then
                Dim RegeditWriter1 As RegistryKey
                RegeditWriter1 = Registry.CurrentUser.OpenSubKey(Ruta2 & "\\OI_1", True)
                If RegeditWriter1 Is Nothing Then
                    Registry.CurrentUser.CreateSubKey(Ruta2 & "\\OI_1")
                    RegeditWriter1 = Registry.CurrentUser.OpenSubKey(Ruta2 & "\\OI_1", True)
                End If
                RegeditWriter1.SetValue("", Main.tb_InsideAFolder_gbDir_1.Text, RegistryValueKind.String)
                RegeditWriter1.SetValue("Icon", Application.ExecutablePath, RegistryValueKind.String) 'Temporalmente hasta encontrar una forma de poner un icono

                Dim RegeditWriter11 As RegistryKey
                RegeditWriter11 = Registry.CurrentUser.OpenSubKey(Ruta2 & "\\OI_1\\command", True)
                If RegeditWriter11 Is Nothing Then
                    Registry.CurrentUser.CreateSubKey(Ruta2 & "\\OI_1\\command")
                    RegeditWriter11 = Registry.CurrentUser.OpenSubKey(Ruta2 & "\\OI_1\\command", True)
                End If
                RegeditWriter11.SetValue("", Main.tbFile_gbFile_11.Text, RegistryValueKind.String)
                InsideFolder_Dir_OpenIn1 = True
            End If

            If opt = 2 Then
                Dim RegeditWriter2 As RegistryKey
                RegeditWriter2 = Registry.CurrentUser.OpenSubKey(Ruta2 & "\\OI_2", True)
                If RegeditWriter2 Is Nothing Then
                    Registry.CurrentUser.CreateSubKey(Ruta2 & "\\OI_2")
                    RegeditWriter2 = Registry.CurrentUser.OpenSubKey(Ruta2 & "\\OI_2", True)
                End If
                RegeditWriter2.SetValue("", Main.tb_InsideAFolder_gbDir_2.Text, RegistryValueKind.String)
                RegeditWriter2.SetValue("Icon", Application.ExecutablePath, RegistryValueKind.String) 'Temporalmente hasta encontrar una forma de poner un icono

                Dim RegeditWriter22 As RegistryKey
                RegeditWriter22 = Registry.CurrentUser.OpenSubKey(Ruta2 & "\\OI_2\\command", True)
                If RegeditWriter22 Is Nothing Then
                    Registry.CurrentUser.CreateSubKey(Ruta2 & "\\OI_2\\command")
                    RegeditWriter22 = Registry.CurrentUser.OpenSubKey(Ruta2 & "\\OI_2\\command", True)
                End If
                RegeditWriter22.SetValue("", Main.tbFile_gbFile_22.Text, RegistryValueKind.String)
                InsideFolder_Dir_OpenIn2 = True
            End If

            If opt = 3 Then
                Dim RegeditWriter3 As RegistryKey
                RegeditWriter3 = Registry.CurrentUser.OpenSubKey(Ruta2 & "\\OI_2", True)
                If RegeditWriter3 Is Nothing Then
                    Registry.CurrentUser.CreateSubKey(Ruta2 & "\\OI_2")
                    RegeditWriter3 = Registry.CurrentUser.OpenSubKey(Ruta2 & "\\OI_2", True)
                End If
                RegeditWriter3.SetValue("", Main.tb_InsideAFolder_gbDir_3.Text, RegistryValueKind.String)
                RegeditWriter3.SetValue("Icon", Application.ExecutablePath, RegistryValueKind.String) 'Temporalmente hasta encontrar una forma de poner un icono

                Dim RegeditWriter33 As RegistryKey
                RegeditWriter33 = Registry.CurrentUser.OpenSubKey(Ruta2 & "\\OI_2\\command", True)
                If RegeditWriter33 Is Nothing Then
                    Registry.CurrentUser.CreateSubKey(Ruta2 & "\\OI_2\\command")
                    RegeditWriter33 = Registry.CurrentUser.OpenSubKey(Ruta2 & "\\OI_2\\command", True)
                End If
                RegeditWriter33.SetValue("", Main.tbFile_gbFile_33.Text, RegistryValueKind.String)
                InsideFolder_Dir_OpenIn3 = True
            End If

        Catch ex As Exception
            'MsgBox("Error al crear la llave." & vbCrLf & ex.Message)
            AddToLog("InsideFolder_DirCreate_OpenIn", "Error: " & ex.Message, True)
        End Try
    End Sub
    Sub InsideFolder_DirRemover_OpenInOther(Optional ByVal opt As SByte = 0)
        Try
            'SOFTWARE\Classes\Directory\Background\shell
            Dim Ruta1 As String = "SOFTWARE\\Classes\\Directory\\Background\\shell"
            Dim Ruta2 As String = Ruta1 & "\\OI\\shell"

            If opt = 0 Then
                InsideFolder_Dir_OpenInOther = False
            End If

            If opt = 1 Then
                If InsideFolder_Dir_OpenIn1 = True Then
                    Dim RegeditWriter1 As RegistryKey
                    RegeditWriter1 = Registry.CurrentUser.OpenSubKey(Ruta2, True)
                    If RegeditWriter1 Is Nothing Then
                        Exit Sub
                    End If
                    RegeditWriter1.DeleteSubKeyTree("OI_1")
                    InsideFolder_Dir_OpenIn1 = False
                End If
            End If

            If opt = 2 Then
                If InsideFolder_Dir_OpenIn2 = True Then
                    Dim RegeditWriter3 As RegistryKey
                    RegeditWriter3 = Registry.CurrentUser.OpenSubKey(Ruta2, True)
                    If RegeditWriter3 Is Nothing Then
                        Exit Sub
                    End If
                    RegeditWriter3.DeleteSubKeyTree("OI_2")
                    InsideFolder_Dir_OpenIn2 = False
                End If
            End If

            If opt = 3 Then
                If InsideFolder_Dir_OpenIn3 = True Then
                    Dim RegeditWriter5 As RegistryKey
                    RegeditWriter5 = Registry.CurrentUser.OpenSubKey(Ruta2, True)
                    If RegeditWriter5 Is Nothing Then
                        Exit Sub
                    End If
                    RegeditWriter5.DeleteSubKeyTree("OI_3")
                    InsideFolder_Dir_OpenIn3 = False
                End If
            End If
        Catch ex As Exception
            'MsgBox("Error al crear la llave." & vbCrLf & ex.Message)
            AddToLog("InsideFolder_DirRemover_OpenIn", "Error: " & ex.Message, True)
        End Try
    End Sub

    Sub SelectFolder_DirCreate_OpenInOther(Optional ByVal opt As SByte = 0)
        Try

            Dim Ruta1 As String = "SOFTWARE\\Classes\\Directory\\shell\\OI"
            Dim Ruta2 As String = Ruta1 & "\\shell"

            If opt = 0 Then
                SelectFolder_Dir_OpenInOther = True
            End If

            If opt = 1 Then
                Dim RegeditWriter1 As RegistryKey
                RegeditWriter1 = Registry.CurrentUser.OpenSubKey(Ruta2 & "\\OI_1", True)
                If RegeditWriter1 Is Nothing Then
                    Registry.CurrentUser.CreateSubKey(Ruta2 & "\\OI_1")
                    RegeditWriter1 = Registry.CurrentUser.OpenSubKey(Ruta2 & "\\OI_1", True)
                End If
                RegeditWriter1.SetValue("", Main.tb_SelectAFolder_gbDir_1.Text, RegistryValueKind.String)
                RegeditWriter1.SetValue("Icon", Application.ExecutablePath, RegistryValueKind.String) 'Temporalmente hasta encontrar una forma de poner un icono

                Dim RegeditWriter11 As RegistryKey
                RegeditWriter11 = Registry.CurrentUser.OpenSubKey(Ruta2 & "\\OI_1\\command", True)
                If RegeditWriter11 Is Nothing Then
                    Registry.CurrentUser.CreateSubKey(Ruta2 & "\\OI_1\\command")
                    RegeditWriter11 = Registry.CurrentUser.OpenSubKey(Ruta2 & "\\OI_1\\command", True)
                End If
                RegeditWriter11.SetValue("", Main.tb_SelectAFolder_gbDir_11.Text, RegistryValueKind.String)
                SelectFolder_Dir_OpenIn1 = True
            End If

            If opt = 2 Then
                Dim RegeditWriter2 As RegistryKey
                RegeditWriter2 = Registry.CurrentUser.OpenSubKey(Ruta2 & "\\OI_2", True)
                If RegeditWriter2 Is Nothing Then
                    Registry.CurrentUser.CreateSubKey(Ruta2 & "\\OI_2")
                    RegeditWriter2 = Registry.CurrentUser.OpenSubKey(Ruta2 & "\\OI_2", True)
                End If
                RegeditWriter2.SetValue("", Main.tb_SelectAFolder_gbDir_2.Text, RegistryValueKind.String)
                RegeditWriter2.SetValue("Icon", Application.ExecutablePath, RegistryValueKind.String) 'Temporalmente hasta encontrar una forma de poner un icono

                Dim RegeditWriter22 As RegistryKey
                RegeditWriter22 = Registry.CurrentUser.OpenSubKey(Ruta2 & "\\OI_2\\command", True)
                If RegeditWriter22 Is Nothing Then
                    Registry.CurrentUser.CreateSubKey(Ruta2 & "\\OI_2\\command")
                    RegeditWriter22 = Registry.CurrentUser.OpenSubKey(Ruta2 & "\\OI_2\\command", True)
                End If
                RegeditWriter22.SetValue("", Main.tb_SelectAFolder_gbDir_22.Text, RegistryValueKind.String)
                SelectFolder_Dir_OpenIn2 = True
            End If

            If opt = 3 Then
                Dim RegeditWriter3 As RegistryKey
                RegeditWriter3 = Registry.CurrentUser.OpenSubKey(Ruta2 & "\\OI_3", True)
                If RegeditWriter3 Is Nothing Then
                    Registry.CurrentUser.CreateSubKey(Ruta2 & "\\OI_3")
                    RegeditWriter3 = Registry.CurrentUser.OpenSubKey(Ruta2 & "\\OI_3", True)
                End If
                RegeditWriter3.SetValue("", Main.tb_SelectAFolder_gbDir_3.Text, RegistryValueKind.String)
                RegeditWriter3.SetValue("Icon", Application.ExecutablePath, RegistryValueKind.String) 'Temporalmente hasta encontrar una forma de poner un icono

                Dim RegeditWriter33 As RegistryKey
                RegeditWriter33 = Registry.CurrentUser.OpenSubKey(Ruta2 & "\\OI_3\\command", True)
                If RegeditWriter33 Is Nothing Then
                    Registry.CurrentUser.CreateSubKey(Ruta2 & "\\OI_3\\command")
                    RegeditWriter33 = Registry.CurrentUser.OpenSubKey(Ruta2 & "\\OI_3\\command", True)
                End If
                RegeditWriter33.SetValue("", Main.tb_SelectAFolder_gbDir_33.Text, RegistryValueKind.String)
                SelectFolder_Dir_OpenIn3 = True
            End If
        Catch ex As Exception
            'MsgBox("Error al crear la llave." & vbCrLf & ex.Message)
            AddToLog("SelectFolder_DirCreate_OpenIn", "Error: " & ex.Message, True)
        End Try
    End Sub
    Sub SelectFolder_DirRemover_OpenInOther(Optional ByVal opt As SByte = 0)
        Try
            'SOFTWARE\Classes\Directory\shell
            Dim Ruta1 As String = "SOFTWARE\\Classes\\Directory\\shell"
            Dim Ruta2 As String = Ruta1 & "\\OI\\shell"

            If opt = 0 Then
                SelectFolder_Dir_OpenInOther = False
            End If

            If opt = 1 Then
                If SelectFolder_Dir_OpenIn1 = True Then
                    Dim RegeditWriter1 As RegistryKey
                    RegeditWriter1 = Registry.CurrentUser.OpenSubKey(Ruta2, True)
                    If RegeditWriter1 Is Nothing Then
                        Exit Sub
                    End If
                    RegeditWriter1.DeleteSubKeyTree("OI_1")
                    SelectFolder_Dir_OpenIn1 = False
                End If
            End If

            If opt = 2 Then
                If SelectFolder_Dir_OpenIn2 = True Then
                    Dim RegeditWriter2 As RegistryKey
                    RegeditWriter2 = Registry.CurrentUser.OpenSubKey(Ruta2, True)
                    If RegeditWriter2 Is Nothing Then
                        Exit Sub
                    End If
                    RegeditWriter2.DeleteSubKeyTree("OI_2")
                    SelectFolder_Dir_OpenIn2 = False
                End If
            End If

            If opt = 3 Then
                If SelectFolder_Dir_OpenIn3 = True Then
                    Dim RegeditWriter3 As RegistryKey
                    RegeditWriter3 = Registry.CurrentUser.OpenSubKey(Ruta2, True)
                    If RegeditWriter3 Is Nothing Then
                        Exit Sub
                    End If
                    RegeditWriter3.DeleteSubKeyTree("OI_3")
                    SelectFolder_Dir_OpenIn3 = False
                End If
            End If
        Catch ex As Exception
            'MsgBox("Error al crear la llave." & vbCrLf & ex.Message)
            AddToLog("SelectFolder_DirRemover_OpenIn", "Error: " & ex.Message, True)
        End Try
    End Sub
#End Region
#Region "File"
    Sub Create_OpenWithOther(Optional ByVal opt As SByte = 0)
        Try
            Dim Ruta1 As String = "SOFTWARE\\Classes\\*\\shell\\OW"
            Dim Ruta2 As String = Ruta1 & "\\shell"
            If opt = 0 Then
                File_OpenWithOther = True
            End If
            If opt = 1 Then
                Dim RegeditWriter1 As RegistryKey
                RegeditWriter1 = Registry.CurrentUser.OpenSubKey(Ruta2 & "\\OW_1", True)
                If RegeditWriter1 Is Nothing Then
                    Registry.CurrentUser.CreateSubKey(Ruta2 & "\\OW_1")
                    RegeditWriter1 = Registry.CurrentUser.OpenSubKey(Ruta2 & "\\OW_1", True)
                End If
                RegeditWriter1.SetValue("", Main.tbFile_gbFile_1.Text, RegistryValueKind.String)
                RegeditWriter1.SetValue("Icon", Application.ExecutablePath, RegistryValueKind.String) 'Temporalmente hasta encontrar una forma de poner un icono

                Dim RegeditWriter11 As RegistryKey
                RegeditWriter11 = Registry.CurrentUser.OpenSubKey(Ruta2 & "\\OW_1\\command", True)
                If RegeditWriter11 Is Nothing Then
                    Registry.CurrentUser.CreateSubKey(Ruta2 & "\\OW_1\\command")
                    RegeditWriter11 = Registry.CurrentUser.OpenSubKey(Ruta2 & "\\OW_1\\command", True)
                End If
                RegeditWriter11.SetValue("", Main.tbFile_gbFile_11.Text, RegistryValueKind.String)
                File_OpenWith_In1 = True
            End If

            If opt = 2 Then
                Dim RegeditWriter2 As RegistryKey
                RegeditWriter2 = Registry.CurrentUser.OpenSubKey(Ruta2 & "\\OW_2", True)
                If RegeditWriter2 Is Nothing Then
                    Registry.CurrentUser.CreateSubKey(Ruta2 & "\\OW_2")
                    RegeditWriter2 = Registry.CurrentUser.OpenSubKey(Ruta2 & "\\OW_2", True)
                End If
                RegeditWriter2.SetValue("", Main.tbFile_gbFile_2.Text, RegistryValueKind.String)
                RegeditWriter2.SetValue("Icon", Application.ExecutablePath, RegistryValueKind.String) 'Temporalmente hasta encontrar una forma de poner un icono

                Dim RegeditWriter22 As RegistryKey
                RegeditWriter22 = Registry.CurrentUser.OpenSubKey(Ruta2 & "\\OW_2\\command", True)
                If RegeditWriter22 Is Nothing Then
                    Registry.CurrentUser.CreateSubKey(Ruta2 & "\\OW_2\\command")
                    RegeditWriter22 = Registry.CurrentUser.OpenSubKey(Ruta2 & "\\OW_2\\command", True)
                End If
                RegeditWriter22.SetValue("", Main.tbFile_gbFile_22.Text, RegistryValueKind.String)
                File_OpenWith_In2 = True
            End If

            If opt = 3 Then
                Dim RegeditWriter3 As RegistryKey
                RegeditWriter3 = Registry.CurrentUser.OpenSubKey(Ruta2 & "\\OW_3", True)
                If RegeditWriter3 Is Nothing Then
                    Registry.CurrentUser.CreateSubKey(Ruta2 & "\\OW_3")
                    RegeditWriter3 = Registry.CurrentUser.OpenSubKey(Ruta2 & "\\OW_3", True)
                End If
                RegeditWriter3.SetValue("", Main.tbFile_gbFile_3.Text, RegistryValueKind.String)
                RegeditWriter3.SetValue("Icon", Application.ExecutablePath, RegistryValueKind.String) 'Temporalmente hasta encontrar una forma de poner un icono

                Dim RegeditWriter33 As RegistryKey
                RegeditWriter33 = Registry.CurrentUser.OpenSubKey(Ruta2 & "\\OW_3\\command", True)
                If RegeditWriter33 Is Nothing Then
                    Registry.CurrentUser.CreateSubKey(Ruta2 & "\\OW_3\\command")
                    RegeditWriter33 = Registry.CurrentUser.OpenSubKey(Ruta2 & "\\OW_3\\command", True)
                End If
                RegeditWriter33.SetValue("", Main.tbFile_gbFile_33.Text, RegistryValueKind.String)
                File_OpenWith_In3 = True
            End If

        Catch ex As Exception
            'MsgBox("Error al crear la llave." & vbCrLf & ex.Message)
            AddToLog("Create_OpenWithOther", "Error: " & ex.Message, True)
        End Try
    End Sub
    Sub Remover_OpenWithOther(Optional ByVal opt As SByte = 0)
        Try

            Dim Ruta1 As String = "SOFTWARE\\Classes\\*\\shell"
            Dim Ruta2 As String = Ruta1 & "\\OW\\shell"
            If opt = 0 Then
                File_OpenWithOther = False
            End If
            If opt = 1 Then
                If File_OpenWith_In1 = True Then
                    Dim RegeditWriter1 As RegistryKey
                    RegeditWriter1 = Registry.CurrentUser.OpenSubKey(Ruta2, True)
                    If RegeditWriter1 Is Nothing Then
                        Registry.CurrentUser.CreateSubKey(Ruta2)
                        RegeditWriter1 = Registry.CurrentUser.OpenSubKey(Ruta2, True)
                    End If
                    RegeditWriter1.DeleteSubKeyTree("OW_1")
                    File_OpenWith_In1 = False
                End If
            End If

            If opt = 2 Then
                If File_OpenWith_In2 = True Then
                    Dim RegeditWriter1 As RegistryKey
                    RegeditWriter1 = Registry.CurrentUser.OpenSubKey(Ruta2, True)
                    If RegeditWriter1 Is Nothing Then
                        Registry.CurrentUser.CreateSubKey(Ruta2)
                        RegeditWriter1 = Registry.CurrentUser.OpenSubKey(Ruta2, True)
                    End If
                    RegeditWriter1.DeleteSubKeyTree("OW_2")
                    File_OpenWith_In2 = False
                End If
            End If

            If opt = 3 Then
                If File_OpenWith_In3 = True Then
                    Dim RegeditWriter1 As RegistryKey
                    RegeditWriter1 = Registry.CurrentUser.OpenSubKey(Ruta2, True)
                    If RegeditWriter1 Is Nothing Then
                        Registry.CurrentUser.CreateSubKey(Ruta2)
                        RegeditWriter1 = Registry.CurrentUser.OpenSubKey(Ruta2, True)
                    End If
                    RegeditWriter1.DeleteSubKeyTree("OW_3")
                    File_OpenWith_In3 = False
                End If
            End If
        Catch ex As Exception
            'MsgBox("Error al crear la llave." & vbCrLf & ex.Message)
            AddToLog("Remover_OpenWith", "Error: " & ex.Message, True)
        End Try
    End Sub
#End Region
#End Region

#Region "Main Editor"

    Sub ReadDefaultMenu(ByVal name As String)
        Try
            Dim filePath As String = DIRCommons & "\Default\" & name & ".ini"
            If My.Computer.FileSystem.FileExists(filePath) = True Then
                If GetIniValue("BASICS", "TYPE", filePath) = "Normal" Then
                    ReadDefaultMenuNormal(name)
                    Main.TabPage4.Enabled = True
                    Main.TabPage5.Enabled = False
                    Main.TabControl2.SelectTab(0)
                ElseIf GetIniValue("BASICS", "TYPE", filePath) = "Cascade" Then
                    ReadDefaultMenuCascade(name)
                    Main.TabPage4.Enabled = False
                    Main.TabPage5.Enabled = True
                    Main.TabControl2.SelectTab(1)
                End If
            Else
                CreateDefaultMenuFiles(name)
            End If
        Catch ex As Exception
            AddToLog("ReadDefaultMenu", "Error: " & ex.Message, True)
        End Try
    End Sub

    Sub ReadDefaultMenuNormal(ByVal name As String)
        Try
            Dim filePath As String = DIRCommons & "\Default\" & name & ".ini"
            Dim formato As String = Nothing
            Main.TextBox1.Text = GetIniValue("BASICS", "KEY", filePath)
            Main.TextBox2.Text = GetIniValue("BASICS", "NAME", filePath)
            Main.TextBox3.Text = GetIniValue("BASICS", "ICON", filePath)
            Main.TextBox4.Text = GetIniValue("BASICS", "VALUE", filePath)
        Catch ex As Exception
            AddToLog("ReadDefaultMenu", "Error: " & ex.Message, True)
        End Try
    End Sub
    Sub ReadDefaultMenuCascade(ByVal name As String)
        Try
            Dim filePath As String = DIRCommons & "\Default\" & name & ".ini"
            Main.TextBox5.Text = GetIniValue("BASICS", "KEY", filePath)
            Main.TextBox6.Text = GetIniValue("BASICS", "NAME", filePath)
            Main.TextBox7.Text = GetIniValue("BASICS", "ICON", filePath)
            Main.TextBox8.Text = GetIniValue("CASCADE.1", "NAME", filePath)
            Main.TextBox9.Text = GetIniValue("CASCADE.1", "ICON", filePath)
            Main.TextBox10.Text = GetIniValue("CASCADE.1", "VALUE", filePath)
            Main.TextBox11.Text = GetIniValue("CASCADE.2", "NAME", filePath)
            Main.TextBox12.Text = GetIniValue("CASCADE.2", "ICON", filePath)
            Main.TextBox13.Text = GetIniValue("CASCADE.2", "VALUE", filePath)
            Main.TextBox14.Text = GetIniValue("CASCADE.3", "NAME", filePath)
            Main.TextBox15.Text = GetIniValue("CASCADE.3", "ICON", filePath)
            Main.TextBox16.Text = GetIniValue("CASCADE.3", "VALUE", filePath)
        Catch ex As Exception
            AddToLog("CreateDefaultMenuFiles", "Error: " & ex.Message, True)
        End Try
    End Sub

    Sub SaveDefaultMenuNormal(ByVal filePath As String)
        Try
            If My.Computer.FileSystem.FileExists(filePath) = True Then
                My.Computer.FileSystem.DeleteFile(filePath)
            End If
            Dim formato As String = "# DevToolMenu Config File" &
                    vbCrLf & "[BASICS]" &
                    vbCrLf & "KEY=" & Main.TextBox1.Text &
                    vbCrLf & "NAME=" & Main.TextBox2.Text &
                    vbCrLf & "ICON=" & Main.TextBox3.Text &
                    vbCrLf & "VALUE=" & Main.TextBox4.Text &
                    vbCrLf & "TYPE=Normal"
            My.Computer.FileSystem.WriteAllText(filePath, formato, False)
        Catch ex As Exception
            AddToLog("SaveDefaultMenuNormal", "Error: " & ex.Message, True)
        End Try
    End Sub
    Sub SaveDefaulMenuCascade(ByVal filePath As String)
        Try
            If My.Computer.FileSystem.FileExists(filePath) = True Then
                My.Computer.FileSystem.DeleteFile(filePath)
            End If
            Dim formato As String = "# DevToolMenu Config File" &
                    vbCrLf & "[BASICS]" &
                    vbCrLf & "KEY=" & Main.TextBox5.Text &
                    vbCrLf & "NAME=" & Main.TextBox6.Text &
                    vbCrLf & "ICON=" & Main.TextBox7.Text &
                    vbCrLf & "TYPE=Cascade" &
                    vbCrLf & "COUNT=3" &
                    vbCrLf & "[CASCADE.1]" &
                    vbCrLf & "NAME=" & Main.TextBox8.Text &
                    vbCrLf & "ICON=" & Main.TextBox9.Text &
                    vbCrLf & "VALUE=" & Main.TextBox10.Text &
                    vbCrLf & "[CASCADE.2]" &
                    vbCrLf & "NAME=" & Main.TextBox11.Text &
                    vbCrLf & "ICON=" & Main.TextBox12.Text &
                    vbCrLf & "VALUE=" & Main.TextBox13.Text &
                    vbCrLf & "[CASCADE.3]" &
                    vbCrLf & "NAME=" & Main.TextBox14.Text &
                    vbCrLf & "ICON=" & Main.TextBox15.Text &
                    vbCrLf & "VALUE=" & Main.TextBox16.Text
            My.Computer.FileSystem.WriteAllText(filePath, formato, False)
        Catch ex As Exception
            AddToLog("SaveDefaultMenuCascade", "Error: " & ex.Message, True)
        End Try
    End Sub

    Sub CreateDefaultMenuFiles(ByVal name As String)
        Try
            Dim filePath As String = DIRCommons & "\Default\" & name & ".ini"
            If My.Computer.FileSystem.FileExists(filePath) = True Then
                My.Computer.FileSystem.DeleteFile(filePath)
            End If

            'Get Location
            If name = "Directorios,Dentro de carpeta,Get Location" Then
                My.Computer.FileSystem.WriteAllText(filePath, "# DevToolMenu Config File" &
                    vbCrLf & "[BASICS]" &
                    vbCrLf & "KEY=" & "SOFTWARE\\Classes\\Directory\\Background\\shell\\GL" &
                    vbCrLf & "NAME=" & "Get Location" &
                    vbCrLf & "ICON=" & Application.ExecutablePath &
                    vbCrLf & "VALUE=" & """" & Application.ExecutablePath & "" & """" & "/WindowsCall>GetLocation>%V" &
                    vbCrLf & "TYPE=Normal", False)
                ReadDefaultMenuNormal(name)
            End If

            If name = "Directorios,Seleccionando carpeta,Get Location" Then
                My.Computer.FileSystem.WriteAllText(filePath, "# DevToolMenu Config File" &
                    vbCrLf & "[BASICS]" &
                    vbCrLf & "KEY=" & "SOFTWARE\\Classes\\Directory\\shell\\GL" &
                    vbCrLf & "NAME=" & "Get Location" &
                    vbCrLf & "ICON=" & Application.ExecutablePath &
                    vbCrLf & "VALUE=" & """" & Application.ExecutablePath & "" & """" & "/WindowsCall>GetLocation>%V" &
                    vbCrLf & "TYPE=Normal", False)
                ReadDefaultMenuNormal(name)
            End If

            If name = "Archivos,Get Location" Then
                My.Computer.FileSystem.WriteAllText(filePath, "# DevToolMenu Config File" &
                    vbCrLf & "[BASICS]" &
                    vbCrLf & "KEY=" & "SOFTWARE\\Classes\\*\\shell\\GL" &
                    vbCrLf & "NAME=" & "Get Location" &
                    vbCrLf & "ICON=" & Application.ExecutablePath &
                    vbCrLf & "VALUE=" & """" & Application.ExecutablePath & "" & """" & "/WindowsCall>GetLocation>%V" &
                    vbCrLf & "TYPE=Normal", False)
                ReadDefaultMenuNormal(name)
            End If

            'Open in
            If name = "Directorios,Dentro de carpeta,Open in" Then
                My.Computer.FileSystem.WriteAllText(filePath, "# DevToolMenu Config File" &
                    vbCrLf & "[BASICS]" &
                    vbCrLf & "KEY=" & "SOFTWARE\\Classes\\Directory\\Background\\shell\\OI" &
                    vbCrLf & "NAME=" & "Open in" &
                    vbCrLf & "ICON=" & Application.ExecutablePath &
                    vbCrLf & "TYPE=Cascade" &
                    vbCrLf & "COUNT=3" &
                    vbCrLf & "[CASCADE.1]" &
                    vbCrLf & "NAME=" & "In Command prompt" &
                    vbCrLf & "ICON=" & "cmd.exe" &
                    vbCrLf & "VALUE=" & """" & "cmd.exe" & """" &
                    vbCrLf & "[CASCADE.2]" &
                    vbCrLf & "NAME=" & "In a new windows" &
                    vbCrLf & "ICON=" & "explorer.exe" &
                    vbCrLf & "VALUE=" & """" & "explorer.exe" & """" & "%V" &
                    vbCrLf & "[CASCADE.3]" &
                    vbCrLf & "NAME=" & "In PowerShell" &
                    vbCrLf & "ICON=" & "powershell.exe" &
                    vbCrLf & "VALUE=" & """" & "powershell.exe" & """", False)
                ReadDefaultMenuCascade(name)
            End If

            If name = "Directorios,Seleccionando carpeta,Open in" Then
                My.Computer.FileSystem.WriteAllText(filePath, "# DevToolMenu Config File" &
                    vbCrLf & "[BASICS]" &
                    vbCrLf & "KEY=" & "SOFTWARE\\Classes\\Directory\\shell\\OI" &
                    vbCrLf & "NAME=" & "Open in" &
                    vbCrLf & "ICON=" & Application.ExecutablePath &
                    vbCrLf & "TYPE=Cascade" &
                    vbCrLf & "COUNT=3" &
                    vbCrLf & "[CASCADE.1]" &
                    vbCrLf & "NAME=" & "In Command prompt" &
                    vbCrLf & "ICON=" & "cmd.exe" &
                    vbCrLf & "VALUE=" & """" & "cmd.exe" & """" & " /K " & """" & "cd %V" & """" &
                    vbCrLf & "[CASCADE.2]" &
                    vbCrLf & "NAME=" & "In a new windows" &
                    vbCrLf & "ICON=" & "explorer.exe" &
                    vbCrLf & "VALUE=" & """" & "explorer.exe" & """" & "%V" &
                    vbCrLf & "[CASCADE.3]" &
                    vbCrLf & "NAME=" & "In PowerShell" &
                    vbCrLf & "ICON=" & "powershell.exe" &
                    vbCrLf & "VALUE=" & """" & "powershell.exe" & """" & " -noexit -command " & """" & "cd %V" & """", False)
                ReadDefaultMenuCascade(name)
            End If

            If name = "Archivos,Open in" Then
                My.Computer.FileSystem.WriteAllText(filePath, "# DevToolMenu Config File" &
                    vbCrLf & "[BASICS]" &
                    vbCrLf & "KEY=" & "SOFTWARE\\Classes\\*\\shell\\OW" &
                    vbCrLf & "NAME=" & "Open with" &
                    vbCrLf & "ICON=" & Application.ExecutablePath &
                    vbCrLf & "TYPE=Cascade" &
                    vbCrLf & "COUNT=3" &
                    vbCrLf & "[CASCADE.1]" &
                    vbCrLf & "NAME=" & "Notepad" &
                    vbCrLf & "ICON=" & "notepad.exe" &
                    vbCrLf & "VALUE=" & """" & "notepad.exe" & """" & "%L" &
                    vbCrLf & "[CASCADE.2]" &
                    vbCrLf & "NAME=" &
                    vbCrLf & "ICON=" &
                    vbCrLf & "VALUE=" &
                    vbCrLf & "[CASCADE.3]" &
                    vbCrLf & "NAME=" &
                    vbCrLf & "ICON=" &
                    vbCrLf & "VALUE=", False)
                ReadDefaultMenuCascade(name)
            End If
        Catch ex As Exception
            AddToLog("CreateDefaultMenuFiles", "Error: " & ex.Message, True)
        End Try
    End Sub

    Sub MainEditorRegeditNormal(ByVal filePath As String)
        Try
            Dim ruta As String = GetIniValue("BASICS", "KEY", filePath)
            Dim keyName As String = GetIniValue("BASICS", "NAME", filePath)
            Dim keyIcon As String = GetIniValue("BASICS", "ICON", filePath)
            Dim keyValue As String = GetIniValue("BASICS", "VALUE", filePath)
            Dim RegeditWriter As RegistryKey
            RegeditWriter = Registry.CurrentUser.OpenSubKey(ruta, True)
            If RegeditWriter Is Nothing Then
                Registry.CurrentUser.CreateSubKey(ruta)
                RegeditWriter = Registry.CurrentUser.OpenSubKey(ruta, True)
            End If
            RegeditWriter.SetValue("", keyName, RegistryValueKind.String)
            RegeditWriter.SetValue("Icon", keyIcon, RegistryValueKind.String)
            Dim RegeditWriter1 As RegistryKey
            RegeditWriter1 = Registry.CurrentUser.OpenSubKey(ruta & "\\command", True)
            If RegeditWriter1 Is Nothing Then
                Registry.CurrentUser.CreateSubKey(ruta & "\\command")
                RegeditWriter1 = Registry.CurrentUser.OpenSubKey(ruta & "\\command", True)
            End If
            RegeditWriter1.SetValue("", keyValue, RegistryValueKind.String)
        Catch ex As Exception
            AddToLog("MenuEditorRegeditNormal", "Error: " & ex.Message, True)
        End Try
    End Sub
    Sub MainEditorRegeditCascade(ByVal filePath As String)
        'falta la prueba. eso deberia crear ls registro indicados en los textboxes. se debe observar como se van
        ' habitando las variables en busqueda de llaves que no se parescan al original (Main y Complementos. Sub registros pre-configurados)
        'es
        Try
            Dim ruta As String = GetIniValue("BASICS", "KEY", filePath)
            Dim keyName As String = GetIniValue("BASICS", "NAME", filePath)
            Dim keyIcon As String = GetIniValue("BASICS", "ICON", filePath)
            Dim keyValue As String = GetIniValue("BASICS", "VALUE", filePath)
            Dim rutaFinal As String = ruta.Remove(0, ruta.LastIndexOf("\") + 1)
            Dim RegeditWriter As RegistryKey
            RegeditWriter = Registry.CurrentUser.OpenSubKey(ruta, True)
            If RegeditWriter Is Nothing Then
                Registry.CurrentUser.CreateSubKey(ruta)
                RegeditWriter = Registry.CurrentUser.OpenSubKey(ruta, True)
            End If
            RegeditWriter.SetValue("Icon", keyIcon, RegistryValueKind.String)
            RegeditWriter.SetValue("MUIVerb", keyName, RegistryValueKind.String)
            RegeditWriter.SetValue("subcommands", "", RegistryValueKind.String)

            'esto no esta funcionando, se deben crear en shell y no en la raiz de OI.
            '   se debe revisar para que las cascade se creen bajo shell}
            '   los nombres NO coinciden con los ya creados.
            'ahora si, pero
            'los valores con " no se crean correctamente

            'CASCADE 1
            Dim RegeditWriter1 As RegistryKey
            RegeditWriter1 = Registry.CurrentUser.OpenSubKey(ruta & "\\shell\\" & GetIniValue("CASCADE.1", "NAME", filePath), True)
            If RegeditWriter1 Is Nothing Then
                Registry.CurrentUser.CreateSubKey(ruta & "\\shell\\" & GetIniValue("CASCADE.1", "NAME", filePath))
                RegeditWriter1 = Registry.CurrentUser.OpenSubKey(ruta & "\\shell\\" & GetIniValue("CASCADE.1", "NAME", filePath), True)
            End If
            RegeditWriter1.SetValue("", GetIniValue("CASCADE.1", "NAME", filePath), RegistryValueKind.String)
            RegeditWriter1.SetValue("Icon", GetIniValue("CASCADE.1", "ICON", filePath), RegistryValueKind.String)

            Dim RegeditWriter3 As RegistryKey
            RegeditWriter3 = Registry.CurrentUser.OpenSubKey(ruta & "\\shell\\" & GetIniValue("CASCADE.1", "NAME", filePath) & "\\command", True)
            If RegeditWriter3 Is Nothing Then
                Registry.CurrentUser.CreateSubKey(ruta & "\\shell\\" & GetIniValue("CASCADE.1", "NAME", filePath) & "\\command")
                RegeditWriter3 = Registry.CurrentUser.OpenSubKey(ruta & "\\shell\\" & GetIniValue("CASCADE.1", "NAME", filePath) & "\\command", True)
            End If
            RegeditWriter3.SetValue("", GetIniValue("CASCADE.1", "VALUE", filePath), RegistryValueKind.String)

            'CASCADE 2
            Dim RegeditWriter4 As RegistryKey
            RegeditWriter4 = Registry.CurrentUser.OpenSubKey(ruta & "\\shell\\" & GetIniValue("CASCADE.2", "NAME", filePath), True)
            If RegeditWriter4 Is Nothing Then
                Registry.CurrentUser.CreateSubKey(ruta & "\\shell\\" & GetIniValue("CASCADE.2", "NAME", filePath))
                RegeditWriter4 = Registry.CurrentUser.OpenSubKey(ruta & "\\shell\\" & GetIniValue("CASCADE.2", "NAME", filePath), True)
            End If
            RegeditWriter4.SetValue("", GetIniValue("CASCADE.2", "NAME", filePath), RegistryValueKind.String)
            RegeditWriter4.SetValue("Icon", GetIniValue("CASCADE.2", "ICON", filePath), RegistryValueKind.String)

            Dim RegeditWriter5 As RegistryKey
            RegeditWriter5 = Registry.CurrentUser.OpenSubKey(ruta & "\\shell\\" & GetIniValue("CASCADE.2", "NAME", filePath) & "\\command", True)
            If RegeditWriter5 Is Nothing Then
                Registry.CurrentUser.CreateSubKey(ruta & "\\shell\\" & GetIniValue("CASCADE.2", "NAME", filePath) & "\\command")
                RegeditWriter5 = Registry.CurrentUser.OpenSubKey(ruta & "\\shell\\" & GetIniValue("CASCADE.2", "NAME", filePath) & "\\command", True)
            End If
            RegeditWriter5.SetValue("", GetIniValue("CASCADE.2", "VALUE", filePath), RegistryValueKind.String)

            'CASCADE 3
            Dim RegeditWriter6 As RegistryKey
            RegeditWriter6 = Registry.CurrentUser.OpenSubKey(ruta & "\\shell\\" & GetIniValue("CASCADE.3", "NAME", filePath), True)
            If RegeditWriter6 Is Nothing Then
                Registry.CurrentUser.CreateSubKey(ruta & "\\shell\\" & GetIniValue("CASCADE.3", "NAME", filePath))
                RegeditWriter6 = Registry.CurrentUser.OpenSubKey(ruta & "\\shell\\" & GetIniValue("CASCADE.3", "NAME", filePath), True)
            End If
            RegeditWriter6.SetValue("", GetIniValue("CASCADE.3", "NAME", filePath), RegistryValueKind.String)
            RegeditWriter6.SetValue("Icon", GetIniValue("CASCADE.3", "ICON", filePath), RegistryValueKind.String)

            Dim RegeditWriter7 As RegistryKey
            RegeditWriter7 = Registry.CurrentUser.OpenSubKey(ruta & "\\shell\\" & GetIniValue("CASCADE.3", "NAME", filePath) & "\\command", True)
            If RegeditWriter7 Is Nothing Then
                Registry.CurrentUser.CreateSubKey(ruta & "\\shell\\" & GetIniValue("CASCADE.3", "NAME", filePath) & "\\command")
                RegeditWriter7 = Registry.CurrentUser.OpenSubKey(ruta & "\\shell\\" & GetIniValue("CASCADE.3", "NAME", filePath) & "\\command", True)
            End If
            RegeditWriter7.SetValue("", GetIniValue("CASCADE.3", "VALUE", filePath), RegistryValueKind.String)

        Catch ex As Exception
            AddToLog("MenuEditorRegeditCascade", "Error: " & ex.Message, True)
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

    'Variables
    Public InsideFolder_Dir_OpenIn As Boolean = False
    Public InsideFolder_Dir_OpenInOther As Boolean = False
    Public InsideFolder_Dir_OpenIn1 As Boolean = False
    Public InsideFolder_Dir_OpenIn2 As Boolean = False
    Public InsideFolder_Dir_OpenIn3 As Boolean = False
    Public InsideFolder_Dir_OpenIn1Name As String
    Public InsideFolder_Dir_OpenIn2Name As String
    Public InsideFolder_Dir_OpenIn3Name As String
    Public InsideFolder_Dir_OpenIn1Value As String
    Public InsideFolder_Dir_OpenIn2Value As String
    Public InsideFolder_Dir_OpenIn3Value As String
    Public InsideFolder_Dir_OpenIn_InCommandPrompt As Boolean = False
    Public InsideFolder_Dir_OpenIn_InANewFolder As Boolean = False
    Public InsideFolder_Dir_OpenIn_InPowerShell As Boolean = False
    Public InsideFolder_Dir_GetLocation As Boolean = False
    Public SelectFolder_Dir_OpenIn As Boolean = False
    Public SelectFolder_Dir_OpenInOther As Boolean = False
    Public SelectFolder_Dir_OpenIn1 As Boolean = False
    Public SelectFolder_Dir_OpenIn2 As Boolean = False
    Public SelectFolder_Dir_OpenIn3 As Boolean = False
    Public SelectFolder_Dir_OpenIn1Name As String
    Public SelectFolder_Dir_OpenIn2Name As String
    Public SelectFolder_Dir_OpenIn3Name As String
    Public SelectFolder_Dir_OpenIn1Value As String
    Public SelectFolder_Dir_OpenIn2Value As String
    Public SelectFolder_Dir_OpenIn3Value As String
    Public SelectFolder_Dir_OpenIn_InCommandPrompt As Boolean = False
    Public SelectFolder_Dir_OpenIn_InANewFolder As Boolean = False
    Public SelectFolder_Dir_OpenIn_InPowerShell As Boolean = False
    Public SelectFolder_Dir_GetLocation As Boolean = False
    Public File_GetLocation As Boolean = False
    Public File_OpenWith As Boolean = False
    Public File_OpenWithOther As Boolean = False
    Public File_OpenWith_Notepad As Boolean = False
    Public File_OpenWith_In1 As Boolean = False
    Public File_OpenWith_In2 As Boolean = False
    Public File_OpenWith_In3 As Boolean = False
    Public File_OpenWith_In1Name As String
    Public File_OpenWith_In2Name As String
    Public File_OpenWith_In3Name As String
    Public File_OpenWith_In1Value As String
    Public File_OpenWith_In2Value As String
    Public File_OpenWith_In3Value As String

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
            ConfigDataRegeditWriter.SetValue("InsideFolder_Dir_OpenInOther", InsideFolder_Dir_OpenInOther, RegistryValueKind.String)
            ConfigDataRegeditWriter.SetValue("InsideFolder_Dir_OpenIn1", InsideFolder_Dir_OpenIn1, RegistryValueKind.String)
            ConfigDataRegeditWriter.SetValue("InsideFolder_Dir_OpenIn2", InsideFolder_Dir_OpenIn2, RegistryValueKind.String)
            ConfigDataRegeditWriter.SetValue("InsideFolder_Dir_OpenIn3", InsideFolder_Dir_OpenIn3, RegistryValueKind.String)
            ConfigDataRegeditWriter.SetValue("InsideFolder_Dir_OpenIn1Name", Main.tb_InsideAFolder_gbDir_1.Text, RegistryValueKind.String)
            ConfigDataRegeditWriter.SetValue("InsideFolder_Dir_OpenIn2Name", Main.tb_InsideAFolder_gbDir_2.Text, RegistryValueKind.String)
            ConfigDataRegeditWriter.SetValue("InsideFolder_Dir_OpenIn3Name", Main.tb_InsideAFolder_gbDir_3.Text, RegistryValueKind.String)
            ConfigDataRegeditWriter.SetValue("InsideFolder_Dir_OpenIn1Value", Main.tb_InsideAFolder_gbDir_11.Text, RegistryValueKind.String)
            ConfigDataRegeditWriter.SetValue("InsideFolder_Dir_OpenIn2Value", Main.tb_InsideAFolder_gbDir_22.Text, RegistryValueKind.String)
            ConfigDataRegeditWriter.SetValue("InsideFolder_Dir_OpenIn3Value", Main.tb_InsideAFolder_gbDir_33.Text, RegistryValueKind.String)
            ConfigDataRegeditWriter.SetValue("InsideFolder_Dir_OpenIn_InCommandPrompt", InsideFolder_Dir_OpenIn_InCommandPrompt, RegistryValueKind.String)
            ConfigDataRegeditWriter.SetValue("InsideFolder_Dir_OpenIn_InANewFolder", InsideFolder_Dir_OpenIn_InANewFolder, RegistryValueKind.String)
            ConfigDataRegeditWriter.SetValue("InsideFolder_Dir_OpenIn_InPowerShell", InsideFolder_Dir_OpenIn_InPowerShell, RegistryValueKind.String)
            ConfigDataRegeditWriter.SetValue("InsideFolder_Dir_GetLocation", InsideFolder_Dir_GetLocation, RegistryValueKind.String)
            '   Select a Folder
            ConfigDataRegeditWriter.SetValue("SelectFolder_Dir_OpenIn", SelectFolder_Dir_OpenIn, RegistryValueKind.String)
            ConfigDataRegeditWriter.SetValue("SelectFolder_Dir_OpenInOther", SelectFolder_Dir_OpenInOther, RegistryValueKind.String)
            ConfigDataRegeditWriter.SetValue("SelectFolder_Dir_OpenIn1", SelectFolder_Dir_OpenIn1, RegistryValueKind.String)
            ConfigDataRegeditWriter.SetValue("SelectFolder_Dir_OpenIn2", SelectFolder_Dir_OpenIn2, RegistryValueKind.String)
            ConfigDataRegeditWriter.SetValue("SelectFolder_Dir_OpenIn3", SelectFolder_Dir_OpenIn3, RegistryValueKind.String)
            ConfigDataRegeditWriter.SetValue("SelectFolder_Dir_OpenIn1Name", Main.tb_SelectAFolder_gbDir_1.Text, RegistryValueKind.String)
            ConfigDataRegeditWriter.SetValue("SelectFolder_Dir_OpenIn2Name", Main.tb_SelectAFolder_gbDir_2.Text, RegistryValueKind.String)
            ConfigDataRegeditWriter.SetValue("SelectFolder_Dir_OpenIn3Name", Main.tb_SelectAFolder_gbDir_3.Text, RegistryValueKind.String)
            ConfigDataRegeditWriter.SetValue("SelectFolder_Dir_OpenIn1Value", Main.tb_SelectAFolder_gbDir_11.Text, RegistryValueKind.String)
            ConfigDataRegeditWriter.SetValue("SelectFolder_Dir_OpenIn2Value", Main.tb_SelectAFolder_gbDir_22.Text, RegistryValueKind.String)
            ConfigDataRegeditWriter.SetValue("SelectFolder_Dir_OpenIn3Value", Main.tb_SelectAFolder_gbDir_33.Text, RegistryValueKind.String)
            ConfigDataRegeditWriter.SetValue("SelectFolder_Dir_OpenIn_InCommandPrompt", SelectFolder_Dir_OpenIn_InCommandPrompt, RegistryValueKind.String)
            ConfigDataRegeditWriter.SetValue("SelectFolder_Dir_OpenIn_InANewFolder", SelectFolder_Dir_OpenIn_InANewFolder, RegistryValueKind.String)
            ConfigDataRegeditWriter.SetValue("SelectFolder_Dir_OpenIn_InPowerShell", SelectFolder_Dir_OpenIn_InPowerShell, RegistryValueKind.String)
            ConfigDataRegeditWriter.SetValue("SelectFolder_Dir_GetLocation", SelectFolder_Dir_GetLocation, RegistryValueKind.String)

            'Archivos
            ConfigDataRegeditWriter.SetValue("File_GetLocation", File_GetLocation, RegistryValueKind.String)
            ConfigDataRegeditWriter.SetValue("File_OpenWith", File_OpenWith, RegistryValueKind.String)
            ConfigDataRegeditWriter.SetValue("File_OpenWithOther", File_OpenWithOther, RegistryValueKind.String)
            ConfigDataRegeditWriter.SetValue("File_OpenWith_Notepad", File_OpenWith_Notepad, RegistryValueKind.String)
            ConfigDataRegeditWriter.SetValue("File_OpenWith_In1", File_OpenWith_In1, RegistryValueKind.String)
            ConfigDataRegeditWriter.SetValue("File_OpenWith_In2", File_OpenWith_In2, RegistryValueKind.String)
            ConfigDataRegeditWriter.SetValue("File_OpenWith_In3", File_OpenWith_In3, RegistryValueKind.String)
            ConfigDataRegeditWriter.SetValue("File_OpenWith_In1Name", Main.tbFile_gbFile_1.Text, RegistryValueKind.String)
            ConfigDataRegeditWriter.SetValue("File_OpenWith_In2Name", Main.tbFile_gbFile_2.Text, RegistryValueKind.String)
            ConfigDataRegeditWriter.SetValue("File_OpenWith_In3Name", Main.tbFile_gbFile_3.Text, RegistryValueKind.String)
            ConfigDataRegeditWriter.SetValue("File_OpenWith_In1Value", Main.tbFile_gbFile_11.Text, RegistryValueKind.String)
            ConfigDataRegeditWriter.SetValue("File_OpenWith_In2Value", Main.tbFile_gbFile_22.Text, RegistryValueKind.String)
            ConfigDataRegeditWriter.SetValue("File_OpenWith_In3Value", Main.tbFile_gbFile_33.Text, RegistryValueKind.String)

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
            InsideFolder_Dir_OpenInOther = Boolean.Parse(ConfigDataRegeditWriter.GetValue("InsideFolder_Dir_OpenInOther"))
            InsideFolder_Dir_OpenIn1 = Boolean.Parse(ConfigDataRegeditWriter.GetValue("InsideFolder_Dir_OpenIn1"))
            InsideFolder_Dir_OpenIn2 = Boolean.Parse(ConfigDataRegeditWriter.GetValue("InsideFolder_Dir_OpenIn2"))
            InsideFolder_Dir_OpenIn3 = Boolean.Parse(ConfigDataRegeditWriter.GetValue("InsideFolder_Dir_OpenIn3"))
            InsideFolder_Dir_OpenIn1Name = ConfigDataRegeditWriter.GetValue("InsideFolder_Dir_OpenIn1Name")
            InsideFolder_Dir_OpenIn2Name = ConfigDataRegeditWriter.GetValue("InsideFolder_Dir_OpenIn2Name")
            InsideFolder_Dir_OpenIn3Name = ConfigDataRegeditWriter.GetValue("InsideFolder_Dir_OpenIn3Name")
            InsideFolder_Dir_OpenIn1Value = ConfigDataRegeditWriter.GetValue("InsideFolder_Dir_OpenIn1Value")
            InsideFolder_Dir_OpenIn2Value = ConfigDataRegeditWriter.GetValue("InsideFolder_Dir_OpenIn2Value")
            InsideFolder_Dir_OpenIn3Value = ConfigDataRegeditWriter.GetValue("InsideFolder_Dir_OpenIn3Value")
            InsideFolder_Dir_OpenIn_InCommandPrompt = Boolean.Parse(ConfigDataRegeditWriter.GetValue("InsideFolder_Dir_OpenIn_InCommandPrompt"))
            InsideFolder_Dir_OpenIn_InANewFolder = Boolean.Parse(ConfigDataRegeditWriter.GetValue("InsideFolder_Dir_OpenIn_InANewFolder"))
            InsideFolder_Dir_OpenIn_InPowerShell = Boolean.Parse(ConfigDataRegeditWriter.GetValue("InsideFolder_Dir_OpenIn_InPowerShell"))
            InsideFolder_Dir_GetLocation = Boolean.Parse(ConfigDataRegeditWriter.GetValue("InsideFolder_Dir_GetLocation"))
            '   Select a Folder
            SelectFolder_Dir_OpenIn = Boolean.Parse(ConfigDataRegeditWriter.GetValue("SelectFolder_Dir_OpenIn"))
            SelectFolder_Dir_OpenInOther = Boolean.Parse(ConfigDataRegeditWriter.GetValue("SelectFolder_Dir_OpenInOther"))
            SelectFolder_Dir_OpenIn1 = Boolean.Parse(ConfigDataRegeditWriter.GetValue("SelectFolder_Dir_OpenIn1"))
            SelectFolder_Dir_OpenIn2 = Boolean.Parse(ConfigDataRegeditWriter.GetValue("SelectFolder_Dir_OpenIn2"))
            SelectFolder_Dir_OpenIn3 = Boolean.Parse(ConfigDataRegeditWriter.GetValue("SelectFolder_Dir_OpenIn3"))
            SelectFolder_Dir_OpenIn1Name = ConfigDataRegeditWriter.GetValue("SelectFolder_Dir_OpenIn1Name")
            SelectFolder_Dir_OpenIn2Name = ConfigDataRegeditWriter.GetValue("SelectFolder_Dir_OpenIn2Name")
            SelectFolder_Dir_OpenIn3Name = ConfigDataRegeditWriter.GetValue("SelectFolder_Dir_OpenIn3Name")
            SelectFolder_Dir_OpenIn1Value = ConfigDataRegeditWriter.GetValue("SelectFolder_Dir_OpenIn1Value")
            SelectFolder_Dir_OpenIn2Value = ConfigDataRegeditWriter.GetValue("SelectFolder_Dir_OpenIn2Value")
            SelectFolder_Dir_OpenIn3Value = ConfigDataRegeditWriter.GetValue("SelectFolder_Dir_OpenIn3Value")
            SelectFolder_Dir_OpenIn_InCommandPrompt = Boolean.Parse(ConfigDataRegeditWriter.GetValue("SelectFolder_Dir_OpenIn_InCommandPrompt"))
            SelectFolder_Dir_OpenIn_InANewFolder = Boolean.Parse(ConfigDataRegeditWriter.GetValue("SelectFolder_Dir_OpenIn_InANewFolder"))
            SelectFolder_Dir_OpenIn_InPowerShell = Boolean.Parse(ConfigDataRegeditWriter.GetValue("SelectFolder_Dir_OpenIn_InPowerShell"))
            SelectFolder_Dir_GetLocation = Boolean.Parse(ConfigDataRegeditWriter.GetValue("SelectFolder_Dir_GetLocation"))


            File_GetLocation = Boolean.Parse(ConfigDataRegeditWriter.GetValue("File_GetLocation"))
            File_OpenWith = Boolean.Parse(ConfigDataRegeditWriter.GetValue("File_OpenWith"))
            File_OpenWithOther = Boolean.Parse(ConfigDataRegeditWriter.GetValue("File_OpenWithOther"))
            File_OpenWith_Notepad = Boolean.Parse(ConfigDataRegeditWriter.GetValue("File_OpenWith_Notepad"))
            File_OpenWith_In1 = Boolean.Parse(ConfigDataRegeditWriter.GetValue("File_OpenWith_In1"))
            File_OpenWith_In2 = Boolean.Parse(ConfigDataRegeditWriter.GetValue("File_OpenWith_In2"))
            File_OpenWith_In3 = Boolean.Parse(ConfigDataRegeditWriter.GetValue("File_OpenWith_In3"))
            File_OpenWith_In1Name = ConfigDataRegeditWriter.GetValue("File_OpenWith_In1Name")
            File_OpenWith_In2Name = ConfigDataRegeditWriter.GetValue("File_OpenWith_In2Name")
            File_OpenWith_In3Name = ConfigDataRegeditWriter.GetValue("File_OpenWith_In3Name")
            File_OpenWith_In1Value = ConfigDataRegeditWriter.GetValue("File_OpenWith_In1Value")
            File_OpenWith_In2Value = ConfigDataRegeditWriter.GetValue("File_OpenWith_In2Value")
            File_OpenWith_In3Value = ConfigDataRegeditWriter.GetValue("File_OpenWith_In3Value")

            'Directorios
            '   Inside a Folder
            If InsideFolder_Dir_OpenIn = True Then
                Main.cb_InsideAFolder_Dir_OpenIn.CheckState = CheckState.Checked
            End If
            If InsideFolder_Dir_OpenInOther = True Then
                Main.cb_InsideAFolder_Dir_OpenIn_InOther.CheckState = CheckState.Checked
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
            If InsideFolder_Dir_OpenIn1 = True Then
                Main.cb_InsideAFolder_gbDir_1.CheckState = CheckState.Checked
                Main.tb_InsideAFolder_gbDir_1.Text = InsideFolder_Dir_OpenIn1Name
                Main.tb_InsideAFolder_gbDir_11.Text = InsideFolder_Dir_OpenIn1Value
            End If
            If InsideFolder_Dir_OpenIn2 = True Then
                Main.cb_InsideAFolder_gbDir_3.CheckState = CheckState.Checked
                Main.tb_InsideAFolder_gbDir_2.Text = InsideFolder_Dir_OpenIn2Name
                Main.tb_InsideAFolder_gbDir_22.Text = InsideFolder_Dir_OpenIn2Value
            End If
            If InsideFolder_Dir_OpenIn3 = True Then
                Main.cb_InsideAFolder_gbDir_3.CheckState = CheckState.Checked
                Main.tb_InsideAFolder_gbDir_3.Text = InsideFolder_Dir_OpenIn3Name
                Main.tb_InsideAFolder_gbDir_33.Text = InsideFolder_Dir_OpenIn3Value
            End If

            '   Select a Folder
            If SelectFolder_Dir_OpenIn = True Then
                Main.cb_SelectAFolder_Dir_OpenIn.CheckState = CheckState.Checked
            End If
            If SelectFolder_Dir_OpenInOther = True Then
                Main.cb_SelectAFolder_Dir_OpenIn_InOther.CheckState = CheckState.Checked
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
            If SelectFolder_Dir_OpenIn1 = True Then
                Main.cb_SelectAFolder_gbDir_1.CheckState = CheckState.Checked
                Main.tb_SelectAFolder_gbDir_1.Text = SelectFolder_Dir_OpenIn1Name
                Main.tb_SelectAFolder_gbDir_11.Text = SelectFolder_Dir_OpenIn1Value
            End If
            If SelectFolder_Dir_OpenIn2 = True Then
                Main.cb_SelectAFolder_gbDir_2.CheckState = CheckState.Checked
                Main.tb_SelectAFolder_gbDir_2.Text = SelectFolder_Dir_OpenIn2Name
                Main.tb_SelectAFolder_gbDir_22.Text = SelectFolder_Dir_OpenIn2Value
            End If
            If SelectFolder_Dir_OpenIn3 = True Then
                Main.cb_SelectAFolder_gbDir_3.CheckState = CheckState.Checked
                Main.tb_SelectAFolder_gbDir_3.Text = SelectFolder_Dir_OpenIn3Name
                Main.tb_SelectAFolder_gbDir_33.Text = SelectFolder_Dir_OpenIn3Value
            End If

            'Archivos
            If File_GetLocation = True Then
                Main.cbFile_GetLocation.CheckState = CheckState.Checked
            End If
            If File_OpenWith = True Then
                Main.cbFile_OpenWith.CheckState = CheckState.Checked
            End If
            If File_OpenWithOther = True Then
                Main.cbFile_OpenWith_Other.CheckState = CheckState.Checked
            End If
            If File_OpenWith_Notepad = True Then
                Main.cbFile_OpenWith_Notepad.CheckState = CheckState.Checked
            End If
            If File_OpenWith_In1 = True Then
                Main.cbFile_gbFile_1.CheckState = CheckState.Checked
                Main.tbFile_gbFile_1.Text = File_OpenWith_In1Name
                Main.tbFile_gbFile_11.Text = File_OpenWith_In1Value
            End If
            If File_OpenWith_In2 = True Then
                Main.cbFile_gbFile_2.CheckState = CheckState.Checked
                Main.tbFile_gbFile_2.Text = File_OpenWith_In2Name
                Main.tbFile_gbFile_22.Text = File_OpenWith_In2Value
            End If
            If File_OpenWith_In3 = True Then
                Main.cbFile_gbFile_3.CheckState = CheckState.Checked
                Main.tbFile_gbFile_3.Text = File_OpenWith_In3Name
                Main.tbFile_gbFile_33.Text = File_OpenWith_In3Value
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
                    'Formato: "/WindowsCall>GetLocation>C:\...\...\..."
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

    <DllImport("kernel32")>
    Private Function GetPrivateProfileString(ByVal section As String, ByVal key As String, ByVal def As String, ByVal retVal As StringBuilder, ByVal size As Integer, ByVal filePath As String) As Integer
        'Use GetIniValue("KEY_HERE", "SubKEY_HERE", "filepath")
    End Function
    Public Function GetIniValue(ByVal section As String, ByVal key As String, ByVal filename As String, Optional ByVal defaultValue As String = Nothing) As String
        Dim sb As New StringBuilder(500)
        If GetPrivateProfileString(section, key, defaultValue, sb, sb.Capacity, filename) > 0 Then
            Return sb.ToString
        Else
            Return defaultValue
        End If
    End Function
End Module
Module InstalledApplications

    Sub CheckForApps()
        Try

        Catch ex As Exception
            AddToLog("CheckForApps", "Error: " & ex.Message, True)
        End Try
    End Sub

End Module 'En desarrollo