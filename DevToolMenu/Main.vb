Public Class Main

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Command() <> Nothing Then
            ReadParameter(Command())
        End If
        Notifyer.BalloonTipTitle = "Has started!"
        Notifyer.BalloonTipText = "Welcome, " & Environment.UserName
        Notifyer.Text = My.Application.Info.AssemblyName
        LoadDB()
    End Sub

    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        SaveDB()
    End Sub

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
        If cb_InsideAFolder_Dir_GetLocation.CheckState = CheckState.Checked Then
            InsideFolder_DirCreate_GetLocation()
        Else
            InsideFolder_DirCreate_GetLocation(True)
        End If
        If cb_SelectAFolder_Dir_GetLocation.CheckState = CheckState.Checked Then
            SelectFolder_DirCreate_GetLocation()
        Else
            SelectFolder_DirCreate_GetLocation(True)
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
    End Sub

    Private Sub CheckBox5_CheckedChanged(sender As Object, e As EventArgs) Handles cbFile_OpenWith.CheckedChanged
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
End Class