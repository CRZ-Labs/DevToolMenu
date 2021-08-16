Public Class Main

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Command() <> Nothing Then
            ReadParameter(Command())
        End If
        Notifyer.BalloonTipTitle = "Has started!"
        Notifyer.BalloonTipText = "Welcome, " & Environment.UserName
        Notifyer.Text = My.Application.Info.AssemblyName
    End Sub

    Private Sub tc_btn_Directory_Apply_Click(sender As Object, e As EventArgs) Handles tc_btn_Directory_Apply.Click
        If CheckBox9.CheckState = CheckState.Checked Then
            Create_OpenIn()
            If CheckBox1.CheckState = CheckState.Checked Then
                Create_OpenIn(1)
            End If
            If CheckBox2.CheckState = CheckState.Checked Then
                Create_OpenIn(2)
            End If
            If CheckBox3.CheckState = CheckState.Checked Then
                Create_OpenIn(3)
            End If
        End If
    End Sub

    Private Sub CheckBox5_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox5.CheckedChanged
        If CheckBox5.CheckState = CheckState.Checked Then
            CheckBox6.Enabled = True
            CheckBox7.Enabled = True
        Else
            CheckBox6.Enabled = False
            CheckBox7.Enabled = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If CheckBox4.CheckState = CheckState.Checked Then
            Create_GetLocation()
        End If

        If CheckBox5.CheckState = CheckState.Checked Then
            Create_OpenWith() 'Crear menu principal
            If CheckBox6.CheckState = CheckState.Checked Then
                Create_OpenWith(1) 'Crear menu en la cascada principal
            End If
        End If
    End Sub

    Private Sub CheckBox9_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox9.CheckedChanged
        If CheckBox9.CheckState = CheckState.Checked Then
            CheckBox1.Enabled = True
            CheckBox2.Enabled = True
            CheckBox3.Enabled = True
            CheckBox8.Enabled = True
        Else
            CheckBox1.Enabled = False
            CheckBox2.Enabled = False
            CheckBox3.Enabled = False
            CheckBox8.Enabled = False
        End If
    End Sub
End Class
'Based on
'   https://medium.com/analytics-vidhya/creating-cascading-context-menus-with-the-windows-10-registry-f1cf3cd8398f