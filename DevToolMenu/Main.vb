Public Class Main
    Dim MenusArray As New ArrayList

    Dim keyType As String

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CommonStart()
        If Command() <> Nothing Then
            ReadParameter(Command())
        End If
        Notifyer.BalloonTipTitle = "Has started!"
        Notifyer.BalloonTipText = "Welcome, " & Environment.UserName
        Notifyer.Text = My.Application.Info.AssemblyName
        LoadDB()
        LoadRegistry()
    End Sub

    Sub CommonStart()
        Try
            If My.Computer.FileSystem.DirectoryExists(DIRCommons) = False Then
                My.Computer.FileSystem.CreateDirectory(DIRCommons)
            End If
            If My.Computer.FileSystem.DirectoryExists(DIRCommons & "\Menus") = False Then
                My.Computer.FileSystem.CreateDirectory(DIRCommons & "\Menus")
            End If
            If My.Computer.FileSystem.DirectoryExists(DIRCommons & "\Default") = False Then
                My.Computer.FileSystem.CreateDirectory(DIRCommons & "\Default")
            End If
            TabPage4.Enabled = False
            TabPage5.Enabled = False
        Catch ex As Exception
            AddToLog("CommonStart", "Error: " & ex.Message, True)
        End Try
    End Sub

    Sub IndexTheMenus()
        Try
            MenusArray.Clear()
            'Indexa los archivos .ini que se encuentren en el directorio \Menus
            For Each Item As String In My.Computer.FileSystem.GetFiles(DIRCommons & "\Default")
                Dim fileName As String = Item.Remove(0, Item.LastIndexOf("\") + 1)
                fileName = fileName.Replace(".ini", Nothing)
                If Item.Contains(".ini") Then
                    MenusArray.Add(Item)
                End If
            Next
        Catch ex As Exception
            AddToLog("CommonStart", "Error: " & ex.Message, True)
        End Try
    End Sub

    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        SaveDB()
        SaveRegistry()
    End Sub

    Private Sub btnMenuEditor_Click(sender As Object, e As EventArgs) Handles tb_btn_MenuEditor.Click
        MenuEditor.Show()
        MenuEditor.Focus()
    End Sub

#Region "Comunes"
    Private Sub tc_btn_Directory_Apply_Click(sender As Object, e As EventArgs) Handles tc_btn_Directory_Apply.Click
        If cb_InsideAFolder_Dir_OpenIn.CheckState = CheckState.Checked Then
            InsideFolder_DirCreate_OpenIn()
            If cb_InsideAFolder_Dir_OpenIn_InCommandPrompt.CheckState = CheckState.Checked Then
                InsideFolder_DirCreate_OpenIn(1)
            Else
                InsideFolder_DirRemover_OpenIn(1)
            End If
            If cb_InsideAFolder_Dir_OpenIn_InANewFolder.CheckState = CheckState.Checked Then
                InsideFolder_DirCreate_OpenIn(2)
            Else
                InsideFolder_DirRemover_OpenIn(2)
            End If
            If cb_InsideAFolder_Dir_OpenIn_InPowerShell.CheckState = CheckState.Checked Then
                InsideFolder_DirCreate_OpenIn(3)
            Else
                InsideFolder_DirRemover_OpenIn(3)
            End If
        Else
            InsideFolder_DirRemover_OpenIn()
        End If
        If cb_InsideAFolder_Dir_GetLocation.CheckState = CheckState.Checked Then
            InsideFolder_DirCreate_GetLocation()
        Else
            InsideFolder_DirCreate_GetLocation(True)
        End If
        If cb_InsideAFolder_Dir_OpenIn_InOther.CheckState = CheckState.Checked Then
            InsideFolder_DirCreate_OpenInOther()
            If cb_InsideAFolder_gbDir_1.Checked Then
                InsideFolder_DirCreate_OpenInOther(1)
            Else
                InsideFolder_DirRemover_OpenInOther(1)
            End If
            If cb_InsideAFolder_gbDir_2.Checked Then
                InsideFolder_DirCreate_OpenInOther(2)
            Else
                InsideFolder_DirRemover_OpenInOther(2)
            End If
            If cb_InsideAFolder_gbDir_3.Checked Then
                InsideFolder_DirCreate_OpenInOther(3)
            Else
                InsideFolder_DirRemover_OpenInOther(3)
            End If
        Else
            InsideFolder_DirRemover_OpenInOther()
        End If

        If cb_SelectAFolder_Dir_OpenIn.CheckState = CheckState.Checked Then
            SelectFolder_DirCreate_OpenIn()
            If cb_SelectAFolder_Dir_OpenIn_InCommandPrompt.CheckState = CheckState.Checked Then
                SelectFolder_DirCreate_OpenIn(1)
            Else
                SelectFolder_DirRemover_OpenIn(1)
            End If
            If cb_SelectAFolder_Dir_OpenIn_InANewFolder.CheckState = CheckState.Checked Then
                SelectFolder_DirCreate_OpenIn(2)
            Else
                SelectFolder_DirRemover_OpenIn(2)
            End If
            If cb_SelectAFolder_Dir_OpenIn_InPowerShell.CheckState = CheckState.Checked Then
                SelectFolder_DirCreate_OpenIn(3)
            Else
                SelectFolder_DirRemover_OpenIn(3)
            End If
        Else
            SelectFolder_DirRemover_OpenIn()
        End If
        If cb_SelectAFolder_Dir_GetLocation.CheckState = CheckState.Checked Then
            SelectFolder_DirCreate_GetLocation()
        Else
            SelectFolder_DirCreate_GetLocation(True)
        End If
        If cb_SelectAFolder_Dir_OpenIn_InOther.CheckState = CheckState.Checked Then
            SelectFolder_DirCreate_OpenInOther()
            If cb_SelectAFolder_gbDir_1.Checked Then
                SelectFolder_DirCreate_OpenInOther(1)
            Else
                SelectFolder_DirRemover_OpenInOther(1)
            End If
            If cb_SelectAFolder_gbDir_2.Checked Then
                SelectFolder_DirCreate_OpenInOther(2)
            Else
                SelectFolder_DirRemover_OpenInOther(2)
            End If
            If cb_SelectAFolder_gbDir_3.Checked Then
                SelectFolder_DirCreate_OpenInOther(3)
            Else
                SelectFolder_DirRemover_OpenInOther(3)
            End If
        Else
            SelectFolder_DirRemover_OpenInOther()
        End If
    End Sub
    Private Sub tc_btn_File_Apply_Click(sender As Object, e As EventArgs) Handles tc_btn_File_Apply.Click
        If cbFile_GetLocation.CheckState = CheckState.Checked Then
            Create_GetLocation()
        Else
            Create_GetLocation(True)
        End If
        If cbFile_OpenWith.CheckState = CheckState.Checked Then
            Create_OpenWith()
            If cbFile_OpenWith_Notepad.CheckState = CheckState.Checked Then
                Create_OpenWith(1)
            Else
                Remover_OpenWith(1)
            End If
        Else
            Remover_OpenWith()
        End If

        If cbFile_OpenWith_Other.Checked Then
            Create_OpenWithOther()
            If cbFile_gbFile_1.Checked Then
                Create_OpenWithOther(1)
            Else
                Remover_OpenWithOther(1)
            End If
            If cbFile_gbFile_2.Checked Then
                Create_OpenWithOther(2)
            Else
                Remover_OpenWithOther(2)
            End If
            If cbFile_gbFile_3.Checked Then
                Create_OpenWithOther(3)
            Else
                Remover_OpenWithOther(3)
            End If
        Else
            Remover_OpenWithOther()
        End If
    End Sub

    Private Sub cbFile_OpenWith_CheckedChanged(sender As Object, e As EventArgs) Handles cbFile_OpenWith.CheckedChanged
        If cbFile_OpenWith.CheckState = CheckState.Checked Then
            cbFile_OpenWith_Notepad.Enabled = True
            cbFile_OpenWith_Other.Enabled = True
        Else
            cbFile_OpenWith_Notepad.Enabled = False
            cbFile_OpenWith_Other.Enabled = False
        End If
    End Sub

    Private Sub cb_InsideAFolder_Dir_OpenIn_CheckedChanged(sender As Object, e As EventArgs) Handles cb_InsideAFolder_Dir_OpenIn.CheckedChanged
        If cb_InsideAFolder_Dir_OpenIn.CheckState = CheckState.Checked Then
            cb_InsideAFolder_Dir_OpenIn_InCommandPrompt.Enabled = True
            cb_InsideAFolder_Dir_OpenIn_InANewFolder.Enabled = True
            cb_InsideAFolder_Dir_OpenIn_InPowerShell.Enabled = True
            cb_InsideAFolder_Dir_OpenIn_InOther.Enabled = True
        Else
            cb_InsideAFolder_Dir_OpenIn_InCommandPrompt.Enabled = False
            cb_InsideAFolder_Dir_OpenIn_InANewFolder.Enabled = False
            cb_InsideAFolder_Dir_OpenIn_InPowerShell.Enabled = False
            cb_InsideAFolder_Dir_OpenIn_InOther.Enabled = False
        End If
    End Sub

    Private Sub cb_SelectAFolder_Dir_OpenIn_CheckedChanged(sender As Object, e As EventArgs) Handles cb_SelectAFolder_Dir_OpenIn.CheckedChanged
        If cb_SelectAFolder_Dir_OpenIn.CheckState = CheckState.Checked Then
            cb_SelectAFolder_Dir_OpenIn_InCommandPrompt.Enabled = True
            cb_SelectAFolder_Dir_OpenIn_InANewFolder.Enabled = True
            cb_SelectAFolder_Dir_OpenIn_InPowerShell.Enabled = True
            cb_SelectAFolder_Dir_OpenIn_InOther.Enabled = True
        Else
            cb_SelectAFolder_Dir_OpenIn_InCommandPrompt.Enabled = False
            cb_SelectAFolder_Dir_OpenIn_InANewFolder.Enabled = False
            cb_SelectAFolder_Dir_OpenIn_InPowerShell.Enabled = False
            cb_SelectAFolder_Dir_OpenIn_InOther.Enabled = False
        End If
    End Sub
#End Region

    Private Sub cb_InsideAFolder_Dir_OpenIn_InOther_CheckedChanged(sender As Object, e As EventArgs) Handles cb_InsideAFolder_Dir_OpenIn_InOther.CheckedChanged
        If cb_InsideAFolder_Dir_OpenIn_InOther.Checked Then
            gbDir_InsideAFolder.Width = 740
            gbDir_InsideAFolder.Location = New System.Drawing.Point(6, 6)
            gbDir_InsideAFolder_gbOthers.Enabled = True
            InsideFolder_Dir_OpenInOther = True
        Else
            gbDir_InsideAFolder.Width = 174
            gbDir_InsideAFolder.Location = New System.Drawing.Point(289, 6)
            gbDir_InsideAFolder_gbOthers.Enabled = False
            InsideFolder_Dir_OpenInOther = False
        End If
    End Sub
    Private Sub cb_SelectAFolder_Dir_OpenIn_InOther_CheckedChanged(sender As Object, e As EventArgs) Handles cb_SelectAFolder_Dir_OpenIn_InOther.CheckedChanged
        If cb_SelectAFolder_Dir_OpenIn_InOther.Checked Then
            gbDir_SelectingAFolder.Width = 740
            gbDir_SelectingAFolder.Location = New System.Drawing.Point(6, 171)
            gbDir_SelectingAFolder_gbOthers.Enabled = True
            SelectFolder_Dir_OpenInOther = True
        Else
            gbDir_SelectingAFolder.Width = 174
            gbDir_SelectingAFolder.Location = New System.Drawing.Point(289, 171)
            gbDir_SelectingAFolder_gbOthers.Enabled = False
            SelectFolder_Dir_OpenInOther = False
        End If
    End Sub
    Private Sub cbFile_OpenWith_Other_CheckedChanged(sender As Object, e As EventArgs) Handles cbFile_OpenWith_Other.CheckedChanged
        If cbFile_OpenWith_Other.Checked Then
            gbFiles_FileSelect.Width = 740
            gbFiles_FileSelect.Location = New System.Drawing.Point(6, 6)
            gbFiles_FileSelect_gbOthers.Enabled = True
            File_OpenWithOther = True
        Else
            gbFiles_FileSelect.Width = 174
            gbFiles_FileSelect.Location = New System.Drawing.Point(289, 6)
            gbFiles_FileSelect_gbOthers.Enabled = False
            File_OpenWithOther = False
        End If
    End Sub

    Private Sub cb_InsideAFolder_gbDir_1_CheckedChanged(sender As Object, e As EventArgs) Handles cb_InsideAFolder_gbDir_1.CheckedChanged
        If cb_InsideAFolder_gbDir_1.Checked Then
            lbl_InsideAFolder_gbDir_1.Enabled = True
            tb_InsideAFolder_gbDir_1.Enabled = True
            tb_InsideAFolder_gbDir_11.Enabled = True
        Else
            lbl_InsideAFolder_gbDir_1.Enabled = False
            tb_InsideAFolder_gbDir_1.Enabled = False
            tb_InsideAFolder_gbDir_11.Enabled = False
        End If
    End Sub
    Private Sub cb_InsideAFolder_gbDir_2_CheckedChanged(sender As Object, e As EventArgs) Handles cb_InsideAFolder_gbDir_2.CheckedChanged
        If cb_InsideAFolder_gbDir_2.Checked Then
            lbl_InsideAFolder_gbDir_2.Enabled = True
            tb_InsideAFolder_gbDir_2.Enabled = True
            tb_InsideAFolder_gbDir_22.Enabled = True
        Else
            lbl_InsideAFolder_gbDir_2.Enabled = False
            tb_InsideAFolder_gbDir_2.Enabled = False
            tb_InsideAFolder_gbDir_22.Enabled = False
        End If
    End Sub
    Private Sub cb_InsideAFolder_gbDir_3_CheckedChanged(sender As Object, e As EventArgs) Handles cb_InsideAFolder_gbDir_3.CheckedChanged
        If cb_InsideAFolder_gbDir_3.Checked Then
            lbl_InsideAFolder_gbDir_3.Enabled = True
            tb_InsideAFolder_gbDir_3.Enabled = True
            tb_InsideAFolder_gbDir_33.Enabled = True
        Else
            lbl_InsideAFolder_gbDir_3.Enabled = False
            tb_InsideAFolder_gbDir_3.Enabled = False
            tb_InsideAFolder_gbDir_33.Enabled = False
        End If
    End Sub

    Private Sub cbFile_gbFile_1_CheckedChanged(sender As Object, e As EventArgs) Handles cbFile_gbFile_1.CheckedChanged
        If cbFile_gbFile_1.Checked Then
            lblFile_gbFile_1.Enabled = True
            tbFile_gbFile_1.Enabled = True
            tbFile_gbFile_11.Enabled = True
        Else
            lblFile_gbFile_1.Enabled = False
            tbFile_gbFile_1.Enabled = False
            tbFile_gbFile_11.Enabled = False
        End If
    End Sub
    Private Sub cbFile_gbFile_2_CheckedChanged(sender As Object, e As EventArgs) Handles cbFile_gbFile_2.CheckedChanged
        If cbFile_gbFile_2.Checked Then
            lblFile_gbFile_2.Enabled = True
            tbFile_gbFile_2.Enabled = True
            tbFile_gbFile_22.Enabled = True
        Else
            lblFile_gbFile_2.Enabled = False
            tbFile_gbFile_2.Enabled = False
            tbFile_gbFile_22.Enabled = False
        End If
    End Sub
    Private Sub cbFile_gbFile_3_CheckedChanged(sender As Object, e As EventArgs) Handles cbFile_gbFile_3.CheckedChanged
        If cbFile_gbFile_3.Checked Then
            lblFile_gbFile_3.Enabled = True
            tbFile_gbFile_3.Enabled = True
            tbFile_gbFile_33.Enabled = True
        Else
            lblFile_gbFile_3.Enabled = False
            tbFile_gbFile_3.Enabled = False
            tbFile_gbFile_33.Enabled = False
        End If
    End Sub

    Private Sub cb_SelectAFolder_gbDir_1_CheckedChanged(sender As Object, e As EventArgs) Handles cb_SelectAFolder_gbDir_1.CheckedChanged
        If cb_SelectAFolder_gbDir_1.Checked Then
            lbl_SelectAFolder_gbDir_1.Enabled = True
            tb_SelectAFolder_gbDir_1.Enabled = True
            tb_SelectAFolder_gbDir_11.Enabled = True
        Else
            lbl_SelectAFolder_gbDir_1.Enabled = False
            tb_SelectAFolder_gbDir_1.Enabled = False
            tb_SelectAFolder_gbDir_11.Enabled = False
        End If
    End Sub
    Private Sub cb_SelectAFolder_gbDir_2_CheckedChanged(sender As Object, e As EventArgs) Handles cb_SelectAFolder_gbDir_2.CheckedChanged
        If cb_SelectAFolder_gbDir_2.Checked Then
            lbl_SelectAFolder_gbDir_2.Enabled = True
            tb_SelectAFolder_gbDir_2.Enabled = True
            tb_SelectAFolder_gbDir_22.Enabled = True
        Else
            lbl_SelectAFolder_gbDir_2.Enabled = False
            tb_SelectAFolder_gbDir_2.Enabled = False
            tb_SelectAFolder_gbDir_22.Enabled = False
        End If
    End Sub
    Private Sub cb_SelectAFolder_gbDir_3_CheckedChanged(sender As Object, e As EventArgs) Handles cb_SelectAFolder_gbDir_3.CheckedChanged
        If cb_SelectAFolder_gbDir_3.Checked Then
            lbl_SelectAFolder_gbDir_3.Enabled = True
            tb_SelectAFolder_gbDir_3.Enabled = True
            tb_SelectAFolder_gbDir_33.Enabled = True
        Else
            lbl_SelectAFolder_gbDir_3.Enabled = False
            tb_SelectAFolder_gbDir_3.Enabled = False
            tb_SelectAFolder_gbDir_33.Enabled = False
        End If
    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        ReadDefaultMenu(TreeView1.SelectedNode.FullPath.Replace("\", ","))
    End Sub

    Private Sub btn_SaveAndApplyNormal_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SaveDefaultMenuNormal(DIRCommons & "\Default\" & TreeView1.SelectedNode.FullPath.Replace("\", ",") & ".ini")
        MainEditorRegeditNormal(DIRCommons & "\Default\" & TreeView1.SelectedNode.FullPath.Replace("\", ",") & ".ini")
    End Sub
    Private Sub btn_SaveAndApplyCascade_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SaveDefaulMenuCascade(DIRCommons & "\Default\" & TreeView1.SelectedNode.FullPath.Replace("\", ",") & ".ini")
        MainEditorRegeditCascade(DIRCommons & "\Default\" & TreeView1.SelectedNode.FullPath.Replace("\", ",") & ".ini")
    End Sub
End Class