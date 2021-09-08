Public Class MenuEditor
    Dim MenusArray As New ArrayList

    Private Sub MenuEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        IndexTheMenus()
    End Sub

    Sub IndexTheMenus()
        Try
            MenusArray.Clear()
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

    Sub CreateNewMenu(ByVal name As String)
        Dim filePath As String = DIRCommons & "\Menus\" & name & ".ini"
        Try
            If My.Computer.FileSystem.FileExists(filePath) Then
                My.Computer.FileSystem.DeleteFile(filePath)
            End If

            Dim Formato As String = "# DevToolMenu Menu Config File"

        Catch ex As Exception
            AddToLog("IndexTheMenus", "Error: " & ex.Message, True)
        End Try
    End Sub

#Region "Controles"
    Private Sub btn_Edit_Click(sender As Object, e As EventArgs) Handles btn_Edit.Click

    End Sub
    Private Sub btn_Save_Click(sender As Object, e As EventArgs) Handles btn_Save.Click

    End Sub

    Private Sub btn_Create_Click(sender As Object, e As EventArgs) Handles btn_Create.Click
        Dim MenuName = InputBox("Ingrese el nombre para el nuevo menu", "Ingresar nombre")
        If MenuName <> Nothing Then
            CreateNewMenu(MenuName)
        End If
    End Sub
    Private Sub btn_Delete_Click(sender As Object, e As EventArgs) Handles btn_Delete.Click
        If MessageBox.Show("¿Seguro de que quiere eliminar '" & lb_Menus.SelectedItem & "'?", "Eliminar menu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            My.Computer.FileSystem.DeleteFile(DIRCommons & "\Menus\" & lb_Menus.SelectedItem & ".ini")
            MenusArray.RemoveAt(lb_Menus.SelectedIndex)
            lb_Menus.Items.Remove(lb_Menus.SelectedItem)
            IndexTheMenus()
        End If
    End Sub
#End Region
End Class
'Se supone que este coso es para editar los que fueron creados desde Directorios y Archivos, y tambien para crear nuevos