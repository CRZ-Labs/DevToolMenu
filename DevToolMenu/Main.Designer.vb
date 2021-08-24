<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.gbDir_SelectingAFolder = New System.Windows.Forms.GroupBox()
        Me.cb_SelectAFolder_Dir_OpenIn = New System.Windows.Forms.CheckBox()
        Me.cb_SelectAFolder_Dir_OpenIn_InCommandPrompt = New System.Windows.Forms.CheckBox()
        Me.cb_SelectAFolder_Dir_OpenIn_InOther = New System.Windows.Forms.CheckBox()
        Me.cb_SelectAFolder_Dir_OpenIn_InANewFolder = New System.Windows.Forms.CheckBox()
        Me.cb_SelectAFolder_Dir_OpenIn_InPowerShell = New System.Windows.Forms.CheckBox()
        Me.gbDir_InsideAFolder = New System.Windows.Forms.GroupBox()
        Me.cb_InsideAFolder_Dir_OpenIn = New System.Windows.Forms.CheckBox()
        Me.cb_InsideAFolder_Dir_OpenIn_InCommandPrompt = New System.Windows.Forms.CheckBox()
        Me.cb_InsideAFolder_Dir_OpenIn_InOther = New System.Windows.Forms.CheckBox()
        Me.cb_InsideAFolder_Dir_OpenIn_InANewFolder = New System.Windows.Forms.CheckBox()
        Me.cb_InsideAFolder_Dir_OpenIn_InPowerShell = New System.Windows.Forms.CheckBox()
        Me.tc_btn_Directory_Apply = New System.Windows.Forms.Button()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.tc_btn_File_Apply = New System.Windows.Forms.Button()
        Me.cbFile_OpenWith_Other = New System.Windows.Forms.CheckBox()
        Me.cbFile_OpenWith_Notepad = New System.Windows.Forms.CheckBox()
        Me.cbFile_OpenWith = New System.Windows.Forms.CheckBox()
        Me.cbFile_GetLocation = New System.Windows.Forms.CheckBox()
        Me.Notifyer = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.cb_InsideAFolder_Dir_GetLocation = New System.Windows.Forms.CheckBox()
        Me.cb_SelectAFolder_Dir_GetLocation = New System.Windows.Forms.CheckBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.gbDir_SelectingAFolder.SuspendLayout()
        Me.gbDir_InsideAFolder.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(760, 437)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(752, 411)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "General"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.gbDir_SelectingAFolder)
        Me.TabPage2.Controls.Add(Me.gbDir_InsideAFolder)
        Me.TabPage2.Controls.Add(Me.tc_btn_Directory_Apply)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(752, 411)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Directorios"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'gbDir_SelectingAFolder
        '
        Me.gbDir_SelectingAFolder.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.gbDir_SelectingAFolder.Controls.Add(Me.cb_SelectAFolder_Dir_GetLocation)
        Me.gbDir_SelectingAFolder.Controls.Add(Me.cb_SelectAFolder_Dir_OpenIn)
        Me.gbDir_SelectingAFolder.Controls.Add(Me.cb_SelectAFolder_Dir_OpenIn_InCommandPrompt)
        Me.gbDir_SelectingAFolder.Controls.Add(Me.cb_SelectAFolder_Dir_OpenIn_InOther)
        Me.gbDir_SelectingAFolder.Controls.Add(Me.cb_SelectAFolder_Dir_OpenIn_InANewFolder)
        Me.gbDir_SelectingAFolder.Controls.Add(Me.cb_SelectAFolder_Dir_OpenIn_InPowerShell)
        Me.gbDir_SelectingAFolder.Location = New System.Drawing.Point(379, 48)
        Me.gbDir_SelectingAFolder.Name = "gbDir_SelectingAFolder"
        Me.gbDir_SelectingAFolder.Size = New System.Drawing.Size(174, 159)
        Me.gbDir_SelectingAFolder.TabIndex = 7
        Me.gbDir_SelectingAFolder.TabStop = False
        Me.gbDir_SelectingAFolder.Text = "Selecting a Folder"
        '
        'cb_SelectAFolder_Dir_OpenIn
        '
        Me.cb_SelectAFolder_Dir_OpenIn.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cb_SelectAFolder_Dir_OpenIn.AutoSize = True
        Me.cb_SelectAFolder_Dir_OpenIn.Location = New System.Drawing.Point(20, 46)
        Me.cb_SelectAFolder_Dir_OpenIn.Name = "cb_SelectAFolder_Dir_OpenIn"
        Me.cb_SelectAFolder_Dir_OpenIn.Size = New System.Drawing.Size(63, 17)
        Me.cb_SelectAFolder_Dir_OpenIn.TabIndex = 5
        Me.cb_SelectAFolder_Dir_OpenIn.Text = "Open in"
        Me.cb_SelectAFolder_Dir_OpenIn.UseVisualStyleBackColor = True
        '
        'cb_SelectAFolder_Dir_OpenIn_InCommandPrompt
        '
        Me.cb_SelectAFolder_Dir_OpenIn_InCommandPrompt.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cb_SelectAFolder_Dir_OpenIn_InCommandPrompt.AutoSize = True
        Me.cb_SelectAFolder_Dir_OpenIn_InCommandPrompt.Enabled = False
        Me.cb_SelectAFolder_Dir_OpenIn_InCommandPrompt.Location = New System.Drawing.Point(35, 69)
        Me.cb_SelectAFolder_Dir_OpenIn_InCommandPrompt.Name = "cb_SelectAFolder_Dir_OpenIn_InCommandPrompt"
        Me.cb_SelectAFolder_Dir_OpenIn_InCommandPrompt.Size = New System.Drawing.Size(120, 17)
        Me.cb_SelectAFolder_Dir_OpenIn_InCommandPrompt.TabIndex = 0
        Me.cb_SelectAFolder_Dir_OpenIn_InCommandPrompt.Text = "in Command Prompt"
        Me.cb_SelectAFolder_Dir_OpenIn_InCommandPrompt.UseVisualStyleBackColor = True
        '
        'cb_SelectAFolder_Dir_OpenIn_InOther
        '
        Me.cb_SelectAFolder_Dir_OpenIn_InOther.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cb_SelectAFolder_Dir_OpenIn_InOther.AutoSize = True
        Me.cb_SelectAFolder_Dir_OpenIn_InOther.Enabled = False
        Me.cb_SelectAFolder_Dir_OpenIn_InOther.Location = New System.Drawing.Point(35, 138)
        Me.cb_SelectAFolder_Dir_OpenIn_InOther.Name = "cb_SelectAFolder_Dir_OpenIn_InOther"
        Me.cb_SelectAFolder_Dir_OpenIn_InOther.Size = New System.Drawing.Size(50, 17)
        Me.cb_SelectAFolder_Dir_OpenIn_InOther.TabIndex = 4
        Me.cb_SelectAFolder_Dir_OpenIn_InOther.Text = "other"
        Me.cb_SelectAFolder_Dir_OpenIn_InOther.UseVisualStyleBackColor = True
        '
        'cb_SelectAFolder_Dir_OpenIn_InANewFolder
        '
        Me.cb_SelectAFolder_Dir_OpenIn_InANewFolder.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cb_SelectAFolder_Dir_OpenIn_InANewFolder.AutoSize = True
        Me.cb_SelectAFolder_Dir_OpenIn_InANewFolder.Checked = True
        Me.cb_SelectAFolder_Dir_OpenIn_InANewFolder.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cb_SelectAFolder_Dir_OpenIn_InANewFolder.Enabled = False
        Me.cb_SelectAFolder_Dir_OpenIn_InANewFolder.Location = New System.Drawing.Point(35, 92)
        Me.cb_SelectAFolder_Dir_OpenIn_InANewFolder.Name = "cb_SelectAFolder_Dir_OpenIn_InANewFolder"
        Me.cb_SelectAFolder_Dir_OpenIn_InANewFolder.Size = New System.Drawing.Size(95, 17)
        Me.cb_SelectAFolder_Dir_OpenIn_InANewFolder.TabIndex = 2
        Me.cb_SelectAFolder_Dir_OpenIn_InANewFolder.Text = "in a new folder"
        Me.cb_SelectAFolder_Dir_OpenIn_InANewFolder.UseVisualStyleBackColor = True
        '
        'cb_SelectAFolder_Dir_OpenIn_InPowerShell
        '
        Me.cb_SelectAFolder_Dir_OpenIn_InPowerShell.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cb_SelectAFolder_Dir_OpenIn_InPowerShell.AutoSize = True
        Me.cb_SelectAFolder_Dir_OpenIn_InPowerShell.Enabled = False
        Me.cb_SelectAFolder_Dir_OpenIn_InPowerShell.Location = New System.Drawing.Point(35, 115)
        Me.cb_SelectAFolder_Dir_OpenIn_InPowerShell.Name = "cb_SelectAFolder_Dir_OpenIn_InPowerShell"
        Me.cb_SelectAFolder_Dir_OpenIn_InPowerShell.Size = New System.Drawing.Size(90, 17)
        Me.cb_SelectAFolder_Dir_OpenIn_InPowerShell.TabIndex = 3
        Me.cb_SelectAFolder_Dir_OpenIn_InPowerShell.Text = "in PowerShell"
        Me.cb_SelectAFolder_Dir_OpenIn_InPowerShell.UseVisualStyleBackColor = True
        '
        'gbDir_InsideAFolder
        '
        Me.gbDir_InsideAFolder.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.gbDir_InsideAFolder.Controls.Add(Me.cb_InsideAFolder_Dir_GetLocation)
        Me.gbDir_InsideAFolder.Controls.Add(Me.cb_InsideAFolder_Dir_OpenIn)
        Me.gbDir_InsideAFolder.Controls.Add(Me.cb_InsideAFolder_Dir_OpenIn_InCommandPrompt)
        Me.gbDir_InsideAFolder.Controls.Add(Me.cb_InsideAFolder_Dir_OpenIn_InOther)
        Me.gbDir_InsideAFolder.Controls.Add(Me.cb_InsideAFolder_Dir_OpenIn_InANewFolder)
        Me.gbDir_InsideAFolder.Controls.Add(Me.cb_InsideAFolder_Dir_OpenIn_InPowerShell)
        Me.gbDir_InsideAFolder.Location = New System.Drawing.Point(199, 48)
        Me.gbDir_InsideAFolder.Name = "gbDir_InsideAFolder"
        Me.gbDir_InsideAFolder.Size = New System.Drawing.Size(174, 159)
        Me.gbDir_InsideAFolder.TabIndex = 6
        Me.gbDir_InsideAFolder.TabStop = False
        Me.gbDir_InsideAFolder.Text = "Inside a Folder"
        '
        'cb_InsideAFolder_Dir_OpenIn
        '
        Me.cb_InsideAFolder_Dir_OpenIn.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cb_InsideAFolder_Dir_OpenIn.AutoSize = True
        Me.cb_InsideAFolder_Dir_OpenIn.Location = New System.Drawing.Point(20, 46)
        Me.cb_InsideAFolder_Dir_OpenIn.Name = "cb_InsideAFolder_Dir_OpenIn"
        Me.cb_InsideAFolder_Dir_OpenIn.Size = New System.Drawing.Size(63, 17)
        Me.cb_InsideAFolder_Dir_OpenIn.TabIndex = 5
        Me.cb_InsideAFolder_Dir_OpenIn.Text = "Open in"
        Me.cb_InsideAFolder_Dir_OpenIn.UseVisualStyleBackColor = True
        '
        'cb_InsideAFolder_Dir_OpenIn_InCommandPrompt
        '
        Me.cb_InsideAFolder_Dir_OpenIn_InCommandPrompt.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cb_InsideAFolder_Dir_OpenIn_InCommandPrompt.AutoSize = True
        Me.cb_InsideAFolder_Dir_OpenIn_InCommandPrompt.Enabled = False
        Me.cb_InsideAFolder_Dir_OpenIn_InCommandPrompt.Location = New System.Drawing.Point(35, 69)
        Me.cb_InsideAFolder_Dir_OpenIn_InCommandPrompt.Name = "cb_InsideAFolder_Dir_OpenIn_InCommandPrompt"
        Me.cb_InsideAFolder_Dir_OpenIn_InCommandPrompt.Size = New System.Drawing.Size(120, 17)
        Me.cb_InsideAFolder_Dir_OpenIn_InCommandPrompt.TabIndex = 0
        Me.cb_InsideAFolder_Dir_OpenIn_InCommandPrompt.Text = "in Command Prompt"
        Me.cb_InsideAFolder_Dir_OpenIn_InCommandPrompt.UseVisualStyleBackColor = True
        '
        'cb_InsideAFolder_Dir_OpenIn_InOther
        '
        Me.cb_InsideAFolder_Dir_OpenIn_InOther.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cb_InsideAFolder_Dir_OpenIn_InOther.AutoSize = True
        Me.cb_InsideAFolder_Dir_OpenIn_InOther.Enabled = False
        Me.cb_InsideAFolder_Dir_OpenIn_InOther.Location = New System.Drawing.Point(35, 138)
        Me.cb_InsideAFolder_Dir_OpenIn_InOther.Name = "cb_InsideAFolder_Dir_OpenIn_InOther"
        Me.cb_InsideAFolder_Dir_OpenIn_InOther.Size = New System.Drawing.Size(50, 17)
        Me.cb_InsideAFolder_Dir_OpenIn_InOther.TabIndex = 4
        Me.cb_InsideAFolder_Dir_OpenIn_InOther.Text = "other"
        Me.cb_InsideAFolder_Dir_OpenIn_InOther.UseVisualStyleBackColor = True
        '
        'cb_InsideAFolder_Dir_OpenIn_InANewFolder
        '
        Me.cb_InsideAFolder_Dir_OpenIn_InANewFolder.AutoSize = True
        Me.cb_InsideAFolder_Dir_OpenIn_InANewFolder.Checked = True
        Me.cb_InsideAFolder_Dir_OpenIn_InANewFolder.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cb_InsideAFolder_Dir_OpenIn_InANewFolder.Enabled = False
        Me.cb_InsideAFolder_Dir_OpenIn_InANewFolder.Location = New System.Drawing.Point(35, 92)
        Me.cb_InsideAFolder_Dir_OpenIn_InANewFolder.Name = "cb_InsideAFolder_Dir_OpenIn_InANewFolder"
        Me.cb_InsideAFolder_Dir_OpenIn_InANewFolder.Size = New System.Drawing.Size(95, 17)
        Me.cb_InsideAFolder_Dir_OpenIn_InANewFolder.TabIndex = 2
        Me.cb_InsideAFolder_Dir_OpenIn_InANewFolder.Text = "in a new folder"
        Me.cb_InsideAFolder_Dir_OpenIn_InANewFolder.UseVisualStyleBackColor = True
        '
        'cb_InsideAFolder_Dir_OpenIn_InPowerShell
        '
        Me.cb_InsideAFolder_Dir_OpenIn_InPowerShell.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cb_InsideAFolder_Dir_OpenIn_InPowerShell.AutoSize = True
        Me.cb_InsideAFolder_Dir_OpenIn_InPowerShell.Enabled = False
        Me.cb_InsideAFolder_Dir_OpenIn_InPowerShell.Location = New System.Drawing.Point(35, 115)
        Me.cb_InsideAFolder_Dir_OpenIn_InPowerShell.Name = "cb_InsideAFolder_Dir_OpenIn_InPowerShell"
        Me.cb_InsideAFolder_Dir_OpenIn_InPowerShell.Size = New System.Drawing.Size(90, 17)
        Me.cb_InsideAFolder_Dir_OpenIn_InPowerShell.TabIndex = 3
        Me.cb_InsideAFolder_Dir_OpenIn_InPowerShell.Text = "in PowerShell"
        Me.cb_InsideAFolder_Dir_OpenIn_InPowerShell.UseVisualStyleBackColor = True
        '
        'tc_btn_Directory_Apply
        '
        Me.tc_btn_Directory_Apply.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.tc_btn_Directory_Apply.Location = New System.Drawing.Point(297, 369)
        Me.tc_btn_Directory_Apply.Name = "tc_btn_Directory_Apply"
        Me.tc_btn_Directory_Apply.Size = New System.Drawing.Size(158, 39)
        Me.tc_btn_Directory_Apply.TabIndex = 1
        Me.tc_btn_Directory_Apply.Text = "Apply"
        Me.tc_btn_Directory_Apply.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.tc_btn_File_Apply)
        Me.TabPage3.Controls.Add(Me.cbFile_OpenWith_Other)
        Me.TabPage3.Controls.Add(Me.cbFile_OpenWith_Notepad)
        Me.TabPage3.Controls.Add(Me.cbFile_OpenWith)
        Me.TabPage3.Controls.Add(Me.cbFile_GetLocation)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(752, 411)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Archivos"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'tc_btn_File_Apply
        '
        Me.tc_btn_File_Apply.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.tc_btn_File_Apply.Location = New System.Drawing.Point(297, 369)
        Me.tc_btn_File_Apply.Name = "tc_btn_File_Apply"
        Me.tc_btn_File_Apply.Size = New System.Drawing.Size(158, 39)
        Me.tc_btn_File_Apply.TabIndex = 4
        Me.tc_btn_File_Apply.Text = "Apply"
        Me.tc_btn_File_Apply.UseVisualStyleBackColor = True
        '
        'cbFile_OpenWith_Other
        '
        Me.cbFile_OpenWith_Other.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cbFile_OpenWith_Other.AutoSize = True
        Me.cbFile_OpenWith_Other.Enabled = False
        Me.cbFile_OpenWith_Other.Location = New System.Drawing.Point(344, 231)
        Me.cbFile_OpenWith_Other.Name = "cbFile_OpenWith_Other"
        Me.cbFile_OpenWith_Other.Size = New System.Drawing.Size(50, 17)
        Me.cbFile_OpenWith_Other.TabIndex = 3
        Me.cbFile_OpenWith_Other.Text = "other"
        Me.cbFile_OpenWith_Other.UseVisualStyleBackColor = True
        '
        'cbFile_OpenWith_Notepad
        '
        Me.cbFile_OpenWith_Notepad.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cbFile_OpenWith_Notepad.AutoSize = True
        Me.cbFile_OpenWith_Notepad.Checked = True
        Me.cbFile_OpenWith_Notepad.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbFile_OpenWith_Notepad.Location = New System.Drawing.Point(344, 208)
        Me.cbFile_OpenWith_Notepad.Name = "cbFile_OpenWith_Notepad"
        Me.cbFile_OpenWith_Notepad.Size = New System.Drawing.Size(67, 17)
        Me.cbFile_OpenWith_Notepad.TabIndex = 2
        Me.cbFile_OpenWith_Notepad.Text = "Notepad"
        Me.cbFile_OpenWith_Notepad.UseVisualStyleBackColor = True
        '
        'cbFile_OpenWith
        '
        Me.cbFile_OpenWith.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cbFile_OpenWith.AutoSize = True
        Me.cbFile_OpenWith.Location = New System.Drawing.Point(335, 185)
        Me.cbFile_OpenWith.Name = "cbFile_OpenWith"
        Me.cbFile_OpenWith.Size = New System.Drawing.Size(74, 17)
        Me.cbFile_OpenWith.TabIndex = 1
        Me.cbFile_OpenWith.Text = "Open with"
        Me.cbFile_OpenWith.UseVisualStyleBackColor = True
        '
        'cbFile_GetLocation
        '
        Me.cbFile_GetLocation.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cbFile_GetLocation.AutoSize = True
        Me.cbFile_GetLocation.Location = New System.Drawing.Point(335, 162)
        Me.cbFile_GetLocation.Name = "cbFile_GetLocation"
        Me.cbFile_GetLocation.Size = New System.Drawing.Size(83, 17)
        Me.cbFile_GetLocation.TabIndex = 0
        Me.cbFile_GetLocation.Text = "Get location"
        Me.cbFile_GetLocation.UseVisualStyleBackColor = True
        '
        'Notifyer
        '
        Me.Notifyer.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.Notifyer.Icon = CType(resources.GetObject("Notifyer.Icon"), System.Drawing.Icon)
        Me.Notifyer.Visible = True
        '
        'cb_InsideAFolder_Dir_GetLocation
        '
        Me.cb_InsideAFolder_Dir_GetLocation.AutoSize = True
        Me.cb_InsideAFolder_Dir_GetLocation.Location = New System.Drawing.Point(20, 23)
        Me.cb_InsideAFolder_Dir_GetLocation.Name = "cb_InsideAFolder_Dir_GetLocation"
        Me.cb_InsideAFolder_Dir_GetLocation.Size = New System.Drawing.Size(87, 17)
        Me.cb_InsideAFolder_Dir_GetLocation.TabIndex = 6
        Me.cb_InsideAFolder_Dir_GetLocation.Text = "Get Location"
        Me.cb_InsideAFolder_Dir_GetLocation.UseVisualStyleBackColor = True
        '
        'cb_SelectAFolder_Dir_GetLocation
        '
        Me.cb_SelectAFolder_Dir_GetLocation.AutoSize = True
        Me.cb_SelectAFolder_Dir_GetLocation.Location = New System.Drawing.Point(20, 23)
        Me.cb_SelectAFolder_Dir_GetLocation.Name = "cb_SelectAFolder_Dir_GetLocation"
        Me.cb_SelectAFolder_Dir_GetLocation.Size = New System.Drawing.Size(87, 17)
        Me.cb_SelectAFolder_Dir_GetLocation.TabIndex = 7
        Me.cb_SelectAFolder_Dir_GetLocation.Text = "Get Location"
        Me.cb_SelectAFolder_Dir_GetLocation.UseVisualStyleBackColor = True
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 461)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Main"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.gbDir_SelectingAFolder.ResumeLayout(False)
        Me.gbDir_SelectingAFolder.PerformLayout()
        Me.gbDir_InsideAFolder.ResumeLayout(False)
        Me.gbDir_InsideAFolder.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents cb_InsideAFolder_Dir_OpenIn_InCommandPrompt As CheckBox
    Friend WithEvents tc_btn_Directory_Apply As Button
    Friend WithEvents cb_InsideAFolder_Dir_OpenIn_InPowerShell As CheckBox
    Friend WithEvents cb_InsideAFolder_Dir_OpenIn_InANewFolder As CheckBox
    Friend WithEvents cbFile_OpenWith_Other As CheckBox
    Friend WithEvents cbFile_OpenWith_Notepad As CheckBox
    Friend WithEvents cbFile_OpenWith As CheckBox
    Friend WithEvents cbFile_GetLocation As CheckBox
    Friend WithEvents tc_btn_File_Apply As Button
    Friend WithEvents Notifyer As NotifyIcon
    Friend WithEvents cb_InsideAFolder_Dir_OpenIn As CheckBox
    Friend WithEvents cb_InsideAFolder_Dir_OpenIn_InOther As CheckBox
    Friend WithEvents gbDir_InsideAFolder As GroupBox
    Friend WithEvents gbDir_SelectingAFolder As GroupBox
    Friend WithEvents cb_SelectAFolder_Dir_OpenIn As CheckBox
    Friend WithEvents cb_SelectAFolder_Dir_OpenIn_InCommandPrompt As CheckBox
    Friend WithEvents cb_SelectAFolder_Dir_OpenIn_InOther As CheckBox
    Friend WithEvents cb_SelectAFolder_Dir_OpenIn_InANewFolder As CheckBox
    Friend WithEvents cb_SelectAFolder_Dir_OpenIn_InPowerShell As CheckBox
    Friend WithEvents cb_SelectAFolder_Dir_GetLocation As CheckBox
    Friend WithEvents cb_InsideAFolder_Dir_GetLocation As CheckBox
End Class
