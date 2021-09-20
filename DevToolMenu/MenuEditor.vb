Imports Microsoft.Win32
Public Class MenuEditor
    Dim MenusArray As New ArrayList

    Dim keyType As String

    Private Sub MenuEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        IndexTheMenus()
    End Sub

    Sub IndexTheMenus()
        Try
            MenusArray.Clear()
            lb_Menus.Items.Clear()
            'Indexa los archivos .ini que se encuentren en el directorio \Menus
            For Each Item As String In My.Computer.FileSystem.GetFiles(DIRCommons & "\Menus")
                Dim fileName As String = Item.Remove(0, Item.LastIndexOf("\") + 1)
                fileName = fileName.Replace(".ini", Nothing)
                If Item.Contains(".ini") Then
                    MenusArray.Add(Item)
                    lb_Menus.Items.Add(fileName)
                End If
            Next
        Catch ex As Exception
            AddToLog("IndexTheMenus", "Error: " & ex.Message, True)
        End Try
    End Sub

    Sub CreateNewMenu()
        Try
            Dim MenuName = InputBox("Ingrese el nombre para el nuevo menu", "Ingresar nombre")
            If MenuName <> Nothing Then
                Dim filePath As String = DIRCommons & "\Menus\" & MenuName & ".ini"
                If My.Computer.FileSystem.FileExists(filePath) Then
                    My.Computer.FileSystem.DeleteFile(filePath)
                End If
                Dim Formato As String = "# DevToolMenu Config File"
                If MessageBox.Show("¿Quiere crear un menú cascada?", "Creación de menú", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                    Formato = "# DevToolMenu Config File" &
                    vbCrLf & "[BASICS]" &
                    vbCrLf & "KEY=" &
                    vbCrLf & "NAME=" &
                    vbCrLf & "ICON=" &
                    vbCrLf & "VALUE=" &
                    vbCrLf & "TYPE=Normal"
                Else
                    Formato = "# DevToolMenu Config File" &
                    vbCrLf & "[BASICS]" &
                    vbCrLf & "KEY=" &
                    vbCrLf & "NAME=" &
                    vbCrLf & "ICON=" &
                    vbCrLf & "TYPE=Cascade" &
                    vbCrLf & "COUNT=3" &
                    vbCrLf & "[CASCADE.1]" &
                    vbCrLf & "NAME=" &
                    vbCrLf & "ICON=" &
                    vbCrLf & "VALUE=" &
                    vbCrLf & "[CASCADE.2]" &
                    vbCrLf & "NAME=" &
                    vbCrLf & "ICON=" &
                    vbCrLf & "VALUE=" &
                    vbCrLf & "[CASCADE.3]" &
                    vbCrLf & "NAME=" &
                    vbCrLf & "ICON=" &
                    vbCrLf & "VALUE="
                End If
                My.Computer.FileSystem.WriteAllText(filePath, Formato, False)
                IndexTheMenus()
            End If
        Catch ex As Exception
            AddToLog("CreateNewMenu", "Error: " & ex.Message, True)
        End Try
    End Sub

    Sub ReadIniFile(ByVal name As String)
        Try
            Dim filePath As String = DIRCommons & "\Menus\" & name & ".ini"

            keyType = GetIniValue("BASICS", "TYPE", filePath)

            TabControl1.Visible = True
            TabControl1.Enabled = True

            If keyType = "Normal" Then
                TabPage1.Enabled = True
                TabPage2.Enabled = False
                TabControl1.SelectTab(0)
                TextBox1.Text = GetIniValue("BASICS", "KEY", filePath)
                TextBox2.Text = GetIniValue("BASICS", "NAME", filePath)
                TextBox3.Text = GetIniValue("BASICS", "ICON", filePath)
                TextBox4.Text = GetIniValue("BASICS", "VALUE", filePath)
            ElseIf keyType = "Cascade" Then
                TabPage1.Enabled = False
                TabPage2.Enabled = True
                TabControl1.SelectTab(1)
                TextBox5.Text = GetIniValue("BASICS", "KEY", filePath)
                TextBox6.Text = GetIniValue("BASICS", "NAME", filePath)
                TextBox7.Text = GetIniValue("BASICS", "ICON", filePath)
                TextBox8.Text = GetIniValue("CASCADE.1", "NAME", filePath)
                TextBox9.Text = GetIniValue("CASCADE.1", "ICON", filePath)
                TextBox10.Text = GetIniValue("CASCADE.1", "VALUE", filePath)
                TextBox11.Text = GetIniValue("CASCADE.2", "NAME", filePath)
                TextBox12.Text = GetIniValue("CASCADE.2", "ICON", filePath)
                TextBox13.Text = GetIniValue("CASCADE.2", "VALUE", filePath)
                TextBox14.Text = GetIniValue("CASCADE.3", "NAME", filePath)
                TextBox15.Text = GetIniValue("CASCADE.3", "ICON", filePath)
                TextBox16.Text = GetIniValue("CASCADE.3", "VALUE", filePath)
            End If

        Catch ex As Exception
            AddToLog("ReadIniFile", "Error: " & ex.Message, True)
        End Try
    End Sub

    Sub SaveIniMenuNormal(ByVal name As String, Optional ByVal apply As Boolean = True)
        Try
            Dim filePath As String = DIRCommons & "\Menus\" & name & ".ini"

            Dim Contenido As String = Nothing

            Contenido = "# DevToolMenu Config File" &
                    vbCrLf & "[BASICS]" &
                    vbCrLf & "KEY=" & TextBox1.Text &
                    vbCrLf & "NAME=" & TextBox2.Text &
                    vbCrLf & "ICON=" & TextBox3.Text &
                    vbCrLf & "VALUE=" & TextBox4.Text &
                    vbCrLf & "TYPE=Normal"

            If My.Computer.FileSystem.FileExists(filePath) = True Then
                My.Computer.FileSystem.DeleteFile(filePath)
            End If

            My.Computer.FileSystem.WriteAllText(filePath, Contenido, False)

            If apply = True Then
                MenuEditorRegeditNormal(filePath)
            End If

        Catch ex As Exception
            AddToLog("SaveIniFile", "Error: " & ex.Message, True)
        End Try
    End Sub
    Sub SaveIniMenuCascade(ByVal name As String, Optional ByVal apply As Boolean = True)
        Try
            Dim filePath As String = DIRCommons & "\Menus\" & name & ".ini"

            Dim Contenido As String = "# DevToolMenu Config File" &
                    vbCrLf & "[BASICS]" &
                    vbCrLf & "KEY=" & TextBox5.Text &
                    vbCrLf & "NAME=" & TextBox6.Text &
                    vbCrLf & "ICON=" & TextBox7.Text &
                    vbCrLf & "TYPE=Cascade" &
                    vbCrLf & "COUNT=3" &
                    vbCrLf & "[CASCADE.1]" &
                    vbCrLf & "NAME=" & TextBox8.Text &
                    vbCrLf & "ICON=" & TextBox9.Text &
                    vbCrLf & "VALUE=" & TextBox10.Text &
                    vbCrLf & "[CASCADE.2]" &
                    vbCrLf & "NAME=" & TextBox11.Text &
                    vbCrLf & "ICON=" & TextBox12.Text &
                    vbCrLf & "VALUE=" & TextBox13.Text &
                    vbCrLf & "[CASCADE.3]" &
                    vbCrLf & "NAME=" & TextBox14.Text &
                    vbCrLf & "ICON=" & TextBox15.Text &
                    vbCrLf & "VALUE=" & TextBox16.Text

            If My.Computer.FileSystem.FileExists(filePath) = True Then
                My.Computer.FileSystem.DeleteFile(filePath)
            End If

            My.Computer.FileSystem.WriteAllText(filePath, Contenido, False)

            If apply = True Then
                MenuEditorRegeditNormal(filePath)
            End If

        Catch ex As Exception
            AddToLog("SaveDefaultMenuCascade", "Error: " & ex.Message, True)
        End Try
    End Sub

    Sub MenuEditorRegeditNormal(ByVal filePath As String)
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
    Sub MenuEditorRegeditCascade(ByVal filePath As String)
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
            RegeditWriter.SetValue("Icon", GetIniValue("BASICS", "ICON", filePath), RegistryValueKind.String)
            RegeditWriter.SetValue("MUIVerb", GetIniValue("BASICS", "NAME", filePath), RegistryValueKind.String)
            RegeditWriter.SetValue("subcommands", "", RegistryValueKind.String)

            'CASCADE 1
            Dim RegeditWriter1 As RegistryKey
            RegeditWriter1 = Registry.CurrentUser.OpenSubKey(ruta & "\\" & GetIniValue("CASCADE.1", "NAME", filePath), True)
            If RegeditWriter1 Is Nothing Then
                Registry.CurrentUser.CreateSubKey(ruta & "\\" & GetIniValue("CASCADE.1", "NAME", filePath))
                RegeditWriter1 = Registry.CurrentUser.OpenSubKey(ruta & "\\" & GetIniValue("CASCADE.1", "NAME", filePath), True)
            End If
            RegeditWriter1.SetValue("", GetIniValue("CASCADE.1", "NAME", filePath), RegistryValueKind.String)
            RegeditWriter1.SetValue("Icon", GetIniValue("CASCADE.1", "ICON", filePath), RegistryValueKind.String)

            Dim RegeditWriter3 As RegistryKey
            RegeditWriter3 = Registry.CurrentUser.OpenSubKey(ruta & "\\" & GetIniValue("CASCADE.1", "NAME", filePath) & "\\command", True)
            If RegeditWriter3 Is Nothing Then
                Registry.CurrentUser.CreateSubKey(ruta & "\\" & GetIniValue("CASCADE.1", "NAME", filePath) & "\\command")
                RegeditWriter3 = Registry.CurrentUser.OpenSubKey(ruta & "\\" & GetIniValue("CASCADE.1", "NAME", filePath) & "\\command", True)
            End If
            RegeditWriter3.SetValue("", GetIniValue("CASCADE.1", "VALUE", filePath), RegistryValueKind.String)

            'CASCADE 2
            Dim RegeditWriter4 As RegistryKey
            RegeditWriter4 = Registry.CurrentUser.OpenSubKey(ruta & "\\" & GetIniValue("CASCADE.2", "NAME", filePath), True)
            If RegeditWriter4 Is Nothing Then
                Registry.CurrentUser.CreateSubKey(ruta & "\\" & GetIniValue("CASCADE.2", "NAME", filePath))
                RegeditWriter4 = Registry.CurrentUser.OpenSubKey(ruta & "\\" & GetIniValue("CASCADE.2", "NAME", filePath), True)
            End If
            RegeditWriter4.SetValue("", GetIniValue("CASCADE.2", "NAME", filePath), RegistryValueKind.String)
            RegeditWriter4.SetValue("Icon", GetIniValue("CASCADE.2", "ICON", filePath), RegistryValueKind.String)

            Dim RegeditWriter5 As RegistryKey
            RegeditWriter5 = Registry.CurrentUser.OpenSubKey(ruta & "\\" & GetIniValue("CASCADE.2", "NAME", filePath) & "\\command", True)
            If RegeditWriter5 Is Nothing Then
                Registry.CurrentUser.CreateSubKey(ruta & "\\" & GetIniValue("CASCADE.2", "NAME", filePath) & "\\command")
                RegeditWriter5 = Registry.CurrentUser.OpenSubKey(ruta & "\\" & GetIniValue("CASCADE.2", "NAME", filePath) & "\\command", True)
            End If
            RegeditWriter5.SetValue("", GetIniValue("CASCADE.2", "VALUE", filePath), RegistryValueKind.String)

            'CASCADE 3
            Dim RegeditWriter6 As RegistryKey
            RegeditWriter6 = Registry.CurrentUser.OpenSubKey(ruta & "\\" & GetIniValue("CASCADE.3", "NAME", filePath), True)
            If RegeditWriter6 Is Nothing Then
                Registry.CurrentUser.CreateSubKey(ruta & "\\" & GetIniValue("CASCADE.3", "NAME", filePath))
                RegeditWriter6 = Registry.CurrentUser.OpenSubKey(ruta & "\\" & GetIniValue("CASCADE.3", "NAME", filePath), True)
            End If
            RegeditWriter6.SetValue("", GetIniValue("CASCADE.3", "NAME", filePath), RegistryValueKind.String)
            RegeditWriter6.SetValue("Icon", GetIniValue("CASCADE.3", "ICON", filePath), RegistryValueKind.String)

            Dim RegeditWriter7 As RegistryKey
            RegeditWriter7 = Registry.CurrentUser.OpenSubKey(ruta & "\\" & GetIniValue("CASCADE.3", "NAME", filePath) & "\\command", True)
            If RegeditWriter7 Is Nothing Then
                Registry.CurrentUser.CreateSubKey(ruta & "\\" & GetIniValue("CASCADE.3", "NAME", filePath) & "\\command")
                RegeditWriter7 = Registry.CurrentUser.OpenSubKey(ruta & "\\" & GetIniValue("CASCADE.3", "NAME", filePath) & "\\command", True)
            End If
            RegeditWriter7.SetValue("", GetIniValue("CASCADE.3", "VALUE", filePath), RegistryValueKind.String)

        Catch ex As Exception
            AddToLog("MenuEditorRegeditCascade", "Error: " & ex.Message, True)
        End Try
    End Sub

    Sub MenuEditorRegeditRemover(ByVal filePath As String)
        Try
            Dim ruta As String = GetIniValue("BASICS", "KEY", filePath)
            Dim keyName As String = ruta
            keyName = keyName.Remove(0, keyName.LastIndexOf("\") + 1)

            ruta = ruta.Replace("\\" & keyName, Nothing)
            ruta = ruta.Replace("\" & keyName, Nothing)

            Dim RegeditWriter1 As RegistryKey
            RegeditWriter1 = Registry.CurrentUser.OpenSubKey(ruta, True)
            If RegeditWriter1 Is Nothing Then
                Exit Sub
            End If
            RegeditWriter1.DeleteSubKeyTree(keyName)
        Catch ex As Exception
            'MsgBox("Error al crear la llave." & vbCrLf & ex.Message)
            AddToLog("MenuEditorRegeditNormalRemover", "Error: " & ex.Message, True)
        End Try
    End Sub

#Region "Controles"
    Private Sub btn_Edit_Click(sender As Object, e As EventArgs) Handles btn_Edit.Click
        ReadIniFile(lb_Menus.SelectedItem)
    End Sub
    Private Sub btn_Save_Click(sender As Object, e As EventArgs) Handles btn_Save.Click
        If keyType = "Normal" Then
            SaveIniMenuNormal(DIRCommons & "\Menus\" & lb_Menus.SelectedItem & ".ini")
        ElseIf keyType = "Cascade" Then
            SaveIniMenuCascade(DIRCommons & "\Menus\" & lb_Menus.SelectedItem & ".ini")
        End If
        'cerrar el archivo
    End Sub
    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If MessageBox.Show("¿Seguro quieres eliminar la llave '" & lb_Menus.SelectedItem & "'", "Eliminar registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            MenuEditorRegeditRemover(DIRCommons & "\Menus\" & lb_Menus.SelectedItem & ".ini")
        End If
    End Sub

    Private Sub btn_Create_Click(sender As Object, e As EventArgs) Handles btn_Create.Click
        CreateNewMenu()
    End Sub
    Private Sub btn_Delete_Click(sender As Object, e As EventArgs) Handles btn_Delete.Click
        If MessageBox.Show("¿Seguro de que quiere eliminar '" & lb_Menus.SelectedItem & "'?", "Eliminar menu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            My.Computer.FileSystem.DeleteFile(DIRCommons & "\Menus\" & lb_Menus.SelectedItem & ".ini")
            MenusArray.RemoveAt(lb_Menus.SelectedIndex)
            lb_Menus.Items.Remove(lb_Menus.SelectedItem)
            IndexTheMenus()
        End If
    End Sub

    Private Sub btn_SaveAndApplyNormal_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SaveIniMenuNormal(lb_Menus.SelectedItem)
        MenuEditorRegeditNormal(DIRCommons & "\Menus\" & lb_Menus.SelectedItem & ".ini")
    End Sub
    Private Sub btn_SaveAndApplyCascade_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SaveIniMenuCascade(lb_Menus.SelectedItem)
        MenuEditorRegeditCascade(DIRCommons & "\Menus\" & lb_Menus.SelectedItem & ".ini")
    End Sub
#End Region
End Class
'Se supone que este coso es para editar los que fueron creados desde Directorios y Archivos, y tambien para crear nuevos