Public Class ShortcutPropertiesDialog
    Inherits System.Windows.Forms.Form
    Private components As System.ComponentModel.IContainer
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If components IsNot Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
    Private Sub InitializeComponent()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnTarget = New System.Windows.Forms.Button()
        Me.txtTarget = New System.Windows.Forms.TextBox()
        Me.txtArguments = New System.Windows.Forms.TextBox()
        Me.txtStartIn = New System.Windows.Forms.TextBox()
        Me.btnStartIn = New System.Windows.Forms.Button()
        Me.txtIconPath = New System.Windows.Forms.TextBox()
        Me.btnIconBrowse = New System.Windows.Forms.Button()
        Me.txtShortcutKey = New System.Windows.Forms.TextBox()
        Me.txtComment = New System.Windows.Forms.TextBox()
        Me.cbxWindow = New System.Windows.Forms.ComboBox()
        Me.lblTarget = New System.Windows.Forms.Label()
        Me.lblArguments = New System.Windows.Forms.Label()
        Me.lblStartIn = New System.Windows.Forms.Label()
        Me.lblIconPath = New System.Windows.Forms.Label()
        Me.lblShortcutKey = New System.Windows.Forms.Label()
        Me.lblComment = New System.Windows.Forms.Label()
        Me.lblWindow = New System.Windows.Forms.Label()
        Me.chkRunAs = New System.Windows.Forms.CheckBox()
        Me.btnIconPick = New System.Windows.Forms.Button()
        Me.ofdTarget = New System.Windows.Forms.OpenFileDialog()
        Me.ofdIcon = New System.Windows.Forms.OpenFileDialog()
        Me.fbdStartIn = New Ookii.Dialogs.VistaFolderBrowserDialog()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.pbxStatus = New System.Windows.Forms.PictureBox()
        Me.pbxIcon = New System.Windows.Forms.PictureBox()
        Me.lblTargetSize = New System.Windows.Forms.Label()
        Me.lblStartInSize = New System.Windows.Forms.Label()
        CType(Me.pbxStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        'btnCancel
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(169, 260)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 20
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        'btnSave
        Me.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnSave.Location = New System.Drawing.Point(88, 260)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 19
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        'btnTarget
        Me.btnTarget.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTarget.Location = New System.Drawing.Point(245, 10)
        Me.btnTarget.Name = "btnTarget"
        Me.btnTarget.Size = New System.Drawing.Size(75, 23)
        Me.btnTarget.TabIndex = 2
        Me.btnTarget.Text = "Browse..."
        Me.btnTarget.UseVisualStyleBackColor = True
        'txtTarget
        Me.txtTarget.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTarget.Location = New System.Drawing.Point(81, 12)
        Me.txtTarget.Name = "txtTarget"
        Me.txtTarget.Size = New System.Drawing.Size(158, 20)
        Me.txtTarget.TabIndex = 1
        'txtArguments
        Me.txtArguments.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtArguments.Location = New System.Drawing.Point(81, 38)
        Me.txtArguments.Name = "txtArguments"
        Me.txtArguments.Size = New System.Drawing.Size(239, 20)
        Me.txtArguments.TabIndex = 4
        'txtStartIn
        Me.txtStartIn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtStartIn.Location = New System.Drawing.Point(81, 64)
        Me.txtStartIn.Name = "txtStartIn"
        Me.txtStartIn.Size = New System.Drawing.Size(158, 20)
        Me.txtStartIn.TabIndex = 6
        'btnStartIn
        Me.btnStartIn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStartIn.Location = New System.Drawing.Point(245, 62)
        Me.btnStartIn.Name = "btnStartIn"
        Me.btnStartIn.Size = New System.Drawing.Size(75, 23)
        Me.btnStartIn.TabIndex = 7
        Me.btnStartIn.Text = "Browse..."
        Me.btnStartIn.UseVisualStyleBackColor = True
        'txtIconPath
        Me.txtIconPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtIconPath.Location = New System.Drawing.Point(81, 90)
        Me.txtIconPath.Name = "txtIconPath"
        Me.txtIconPath.Size = New System.Drawing.Size(239, 20)
        Me.txtIconPath.TabIndex = 9
        'btnIconBrowse
        Me.btnIconBrowse.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnIconBrowse.Location = New System.Drawing.Point(123, 116)
        Me.btnIconBrowse.Name = "btnIconBrowse"
        Me.btnIconBrowse.Size = New System.Drawing.Size(75, 23)
        Me.btnIconBrowse.TabIndex = 10
        Me.btnIconBrowse.Text = "Browse..."
        Me.btnIconBrowse.UseVisualStyleBackColor = True
        'txtShortcutKey
        Me.txtShortcutKey.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtShortcutKey.Location = New System.Drawing.Point(81, 145)
        Me.txtShortcutKey.Name = "txtShortcutKey"
        Me.txtShortcutKey.Size = New System.Drawing.Size(239, 20)
        Me.txtShortcutKey.TabIndex = 13
        'txtComment
        Me.txtComment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtComment.Location = New System.Drawing.Point(81, 184)
        Me.txtComment.Name = "txtComment"
        Me.txtComment.Size = New System.Drawing.Size(239, 20)
        Me.txtComment.TabIndex = 15
        'cbxWindow
        Me.cbxWindow.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbxWindow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxWindow.FormattingEnabled = True
        Me.cbxWindow.Items.AddRange(New Object() {"Normal Window", "Minimised", "Maximised"})
        Me.cbxWindow.Location = New System.Drawing.Point(81, 210)
        Me.cbxWindow.Name = "cbxWindow"
        Me.cbxWindow.Size = New System.Drawing.Size(239, 21)
        Me.cbxWindow.TabIndex = 17
        'lblTarget
        Me.lblTarget.AutoSize = True
        Me.lblTarget.Location = New System.Drawing.Point(6, 15)
        Me.lblTarget.Name = "lblTarget"
        Me.lblTarget.Size = New System.Drawing.Size(41, 13)
        Me.lblTarget.TabIndex = 0
        Me.lblTarget.Text = "Target:"
        'lblArguments
        Me.lblArguments.AutoSize = True
        Me.lblArguments.Location = New System.Drawing.Point(6, 41)
        Me.lblArguments.Name = "lblArguments"
        Me.lblArguments.Size = New System.Drawing.Size(60, 13)
        Me.lblArguments.TabIndex = 3
        Me.lblArguments.Text = "Arguments:"
        'lblStartIn
        Me.lblStartIn.AutoSize = True
        Me.lblStartIn.Location = New System.Drawing.Point(6, 67)
        Me.lblStartIn.Name = "lblStartIn"
        Me.lblStartIn.Size = New System.Drawing.Size(44, 13)
        Me.lblStartIn.TabIndex = 5
        Me.lblStartIn.Text = "Start In:"
        'lblIconPath
        Me.lblIconPath.AutoSize = True
        Me.lblIconPath.Location = New System.Drawing.Point(6, 93)
        Me.lblIconPath.Name = "lblIconPath"
        Me.lblIconPath.Size = New System.Drawing.Size(56, 13)
        Me.lblIconPath.TabIndex = 8
        Me.lblIconPath.Text = "Icon Path:"
        'lblShortcutKey
        Me.lblShortcutKey.AutoSize = True
        Me.lblShortcutKey.Location = New System.Drawing.Point(6, 148)
        Me.lblShortcutKey.Name = "lblShortcutKey"
        Me.lblShortcutKey.Size = New System.Drawing.Size(71, 13)
        Me.lblShortcutKey.TabIndex = 12
        Me.lblShortcutKey.Text = "Shortcut Key:"
        'lblComment
        Me.lblComment.AutoSize = True
        Me.lblComment.Location = New System.Drawing.Point(6, 187)
        Me.lblComment.Name = "lblComment"
        Me.lblComment.Size = New System.Drawing.Size(54, 13)
        Me.lblComment.TabIndex = 14
        Me.lblComment.Text = "Comment:"
        'lblWindow
        Me.lblWindow.AutoSize = True
        Me.lblWindow.Location = New System.Drawing.Point(6, 213)
        Me.lblWindow.Name = "lblWindow"
        Me.lblWindow.Size = New System.Drawing.Size(75, 13)
        Me.lblWindow.TabIndex = 16
        Me.lblWindow.Text = "Window Style:"
        'chkRunAs
        Me.chkRunAs.AutoSize = True
        Me.chkRunAs.Location = New System.Drawing.Point(81, 237)
        Me.chkRunAs.Name = "chkRunAs"
        Me.chkRunAs.Size = New System.Drawing.Size(123, 17)
        Me.chkRunAs.TabIndex = 18
        Me.chkRunAs.Text = "Run as Administrator"
        Me.chkRunAs.UseVisualStyleBackColor = True
        'btnIconPick
        Me.btnIconPick.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnIconPick.Location = New System.Drawing.Point(204, 116)
        Me.btnIconPick.Name = "btnIconPick"
        Me.btnIconPick.Size = New System.Drawing.Size(75, 23)
        Me.btnIconPick.TabIndex = 11
        Me.btnIconPick.Text = "Pick Icon..."
        Me.btnIconPick.UseVisualStyleBackColor = True
        'ofdTarget
        Me.ofdTarget.Filter = "All Files|*.*"
        Me.ofdTarget.Title = "Select Shortcut Target"
        'ofdIcon
        Me.ofdIcon.DefaultExt = "ico"
        Me.ofdIcon.Filter = "Icon Files|*.ico;*.icl;*.exe;*.dll|All Files|*.*"
        Me.ofdIcon.Title = "Select Shortcut Icon File"
        'fbdStartIn
        Me.fbdStartIn.Description = "Select Start In folder for Shortcut:"
        Me.fbdStartIn.UseDescriptionForTitle = True
        'lblStatus
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(97, 168)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(114, 13)
        Me.lblStatus.TabIndex = 21
        Me.lblStatus.Text = "Enter a Shortcut Key..."
        'pbxStatus
        Me.pbxStatus.Location = New System.Drawing.Point(81, 166)
        Me.pbxStatus.Name = "pbxStatus"
        Me.pbxStatus.Size = New System.Drawing.Size(16, 16)
        Me.pbxStatus.TabIndex = 22
        Me.pbxStatus.TabStop = False
        'pbxIcon
        Me.pbxIcon.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.pbxIcon.Location = New System.Drawing.Point(285, 112)
        Me.pbxIcon.Name = "pbxIcon"
        Me.pbxIcon.Size = New System.Drawing.Size(32, 32)
        Me.pbxIcon.TabIndex = 23
        Me.pbxIcon.TabStop = False
        'lblTargetSize
        Me.lblTargetSize.AutoSize = True
        Me.lblTargetSize.Location = New System.Drawing.Point(8, -20)
        Me.lblTargetSize.Name = "lblTargetSize"
        Me.lblTargetSize.Size = New System.Drawing.Size(16, 13)
        Me.lblTargetSize.TabIndex = 24
        Me.lblTargetSize.Text = "..."
        'lblStartInSize
        Me.lblStartInSize.AutoSize = True
        Me.lblStartInSize.Location = New System.Drawing.Point(8, -20)
        Me.lblStartInSize.Name = "lblStartInSize"
        Me.lblStartInSize.Size = New System.Drawing.Size(16, 13)
        Me.lblStartInSize.TabIndex = 25
        Me.lblStartInSize.Text = "..."
        'ShortcutPropertiesDialog
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(332, 295)
        Me.Controls.Add(Me.lblStartInSize)
        Me.Controls.Add(Me.lblTargetSize)
        Me.Controls.Add(Me.pbxIcon)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.pbxStatus)
        Me.Controls.Add(Me.btnIconPick)
        Me.Controls.Add(Me.chkRunAs)
        Me.Controls.Add(Me.lblWindow)
        Me.Controls.Add(Me.lblComment)
        Me.Controls.Add(Me.lblShortcutKey)
        Me.Controls.Add(Me.lblIconPath)
        Me.Controls.Add(Me.lblStartIn)
        Me.Controls.Add(Me.lblArguments)
        Me.Controls.Add(Me.lblTarget)
        Me.Controls.Add(Me.cbxWindow)
        Me.Controls.Add(Me.txtComment)
        Me.Controls.Add(Me.txtShortcutKey)
        Me.Controls.Add(Me.txtIconPath)
        Me.Controls.Add(Me.btnIconBrowse)
        Me.Controls.Add(Me.txtStartIn)
        Me.Controls.Add(Me.btnStartIn)
        Me.Controls.Add(Me.txtArguments)
        Me.Controls.Add(Me.txtTarget)
        Me.Controls.Add(Me.btnTarget)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnCancel)
        Me.Icon = Global.PropertiesDotNet.Resources.document_properties_shortcut
        Me.Name = "ShortcutPropertiesDialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Shortcut Properties"
        CType(Me.pbxStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
    Friend lblStartInSize As System.Windows.Forms.Label
    Friend lblTargetSize As System.Windows.Forms.Label
    Private pbxIcon As System.Windows.Forms.PictureBox
    Private pbxStatus As System.Windows.Forms.PictureBox
    Private lblStatus As System.Windows.Forms.Label
    Private fbdStartIn As Ookii.Dialogs.VistaFolderBrowserDialog
    Private ofdIcon As System.Windows.Forms.OpenFileDialog
    Private ofdTarget As System.Windows.Forms.OpenFileDialog
    Private WithEvents btnIconPick As System.Windows.Forms.Button
    Friend chkRunAs As System.Windows.Forms.CheckBox
    Private lblWindow As System.Windows.Forms.Label
    Private lblComment As System.Windows.Forms.Label
    Private lblShortcutKey As System.Windows.Forms.Label
    Private lblIconPath As System.Windows.Forms.Label
    Private lblStartIn As System.Windows.Forms.Label
    Private lblArguments As System.Windows.Forms.Label
    Private lblTarget As System.Windows.Forms.Label
    Friend cbxWindow As System.Windows.Forms.ComboBox
    Friend txtComment As System.Windows.Forms.TextBox
    Friend WithEvents txtShortcutKey As System.Windows.Forms.TextBox
    Private WithEvents btnIconBrowse As System.Windows.Forms.Button
    Friend WithEvents txtIconPath As System.Windows.Forms.TextBox
    Private WithEvents btnStartIn As System.Windows.Forms.Button
    Friend txtStartIn As System.Windows.Forms.TextBox
    Friend txtArguments As System.Windows.Forms.TextBox
    Friend txtTarget As System.Windows.Forms.TextBox
    Private WithEvents btnTarget As System.Windows.Forms.Button
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents btnCancel As System.Windows.Forms.Button

    Public Sub New()
        Me.InitializeComponent()
        cbxWindow.SelectedIndex = 0
    End Sub

    Sub ShortcutPropertiesDialog_VisibleChanged() Handles Me.VisibleChanged
        If Me.Visible Then
            Me.CenterToParent()
        End If
    End Sub

    Sub PerformResize()
        Me.Width = Math.Max(Math.Max(lblTargetSize.Width, lblStartInSize.Width) + 190, 348)
    End Sub

    Sub btnTarget_Click() Handles btnTarget.Click
        ofdTarget.FileName = txtTarget.Text

        If ofdTarget.ShowDialog() = DialogResult.OK Then
            txtTarget.Text = ofdTarget.FileName
        End If
    End Sub

    Sub btnStartIn_Click() Handles btnStartIn.Click
        fbdStartIn.SelectedPath = txtStartIn.Text

        If fbdStartIn.ShowDialog() = DialogResult.OK Then
            txtStartIn.Text = fbdStartIn.SelectedPath
        End If
    End Sub

    Function TransformResourcePath(iconResource As String, Optional ByRef iconIndex As Integer = 0) As String
        If iconResource.Contains(",") Then
            If IsNumeric(iconResource.Substring(iconResource.LastIndexOf(",") + 1)) Then
                iconIndex = iconResource.Substring(iconResource.LastIndexOf(",") + 1)

                iconResource = iconResource.Remove(iconResource.LastIndexOf(","))
            End If
        End If

        If iconResource = "" Then
            iconResource = txtTarget.Text
        End If
        Return iconResource
    End Function

    Sub btnIconBrowse_Click() Handles btnIconBrowse.Click
        ofdIcon.FileName = TransformResourcePath(txtIconPath.Text)

        If ofdIcon.ShowDialog() = DialogResult.OK Then
            txtIconPath.Text = ofdIcon.FileName
        End If
    End Sub

    Sub btnIconPick_Click() Handles btnIconPick.Click
        Dim selectedIconIndex As Integer
        Dim selectedFilePath As String = TransformResourcePath(txtIconPath.Text, selectedIconIndex)

        If WalkmanLib.PickIconDialogShow(selectedFilePath, selectedIconIndex, Me.Handle) Then
            txtIconPath.Text = selectedFilePath & "," & selectedIconIndex
        End If
    End Sub

    Sub txtIconPath_TextChanged() Handles txtIconPath.TextChanged
        Dim selectedIconIndex As Integer
        Dim selectedFilePath As String = TransformResourcePath(txtIconPath.Text, selectedIconIndex)
        selectedFilePath = Environment.ExpandEnvironmentVariables(selectedFilePath)

        Try
            Dim tmpIcon = WalkmanLib.ExtractIconByIndex(selectedFilePath, selectedIconIndex, pbxIcon.Width)
            pbxIcon.Image = tmpIcon.ToBitmap
        Catch
            pbxIcon.Image = Nothing
        End Try
    End Sub

    Sub txtShortcutKey_TextChanged() Handles txtShortcutKey.TextChanged
        Dim tmpShortcut = WalkmanLib.GetShortcutInfo("C:\tmp.lnk")
        Dim isValidHotkey As Boolean = True

        Try
            tmpShortcut.Hotkey = txtShortcutKey.Text
        Catch e As ArgumentException
            isValidHotkey = False
        End Try

        If isValidHotkey Then
            lblStatus.Text = "Valid Shortcut Key"
            pbxStatus.Image = Resources.accept
        Else
            lblStatus.Text = "Invalid Shortcut Key"
            pbxStatus.Image = Resources.warning
        End If
    End Sub

    Sub btnSave_Click() Handles btnSave.Click
        Dim windowStyle As FormWindowState

        Select Case cbxWindow.SelectedIndex
            Case 0 'Normal Window
                windowStyle = FormWindowState.Normal
            Case 1 'Minimised
                windowStyle = FormWindowState.Minimized
            Case 2 'Maximised
                windowStyle = FormWindowState.Maximized
        End Select

        Try
            WalkmanLib.CreateShortcut(PropertiesDotNet.lblLocation.Text, txtTarget.Text, txtArguments.Text,
                    txtStartIn.Text, txtIconPath.Text, txtComment.Text, txtShortcutKey.Text, windowStyle)
        Catch ex As ArgumentException When ex.Message = "Value does not fall within the expected range."
            ' https://ss64.com/vb/shortcut.html
            MsgBox("Incorrect Shortcut Key!" & vbNewLine & vbNewLine &
                "HotKey mappings are only usable if the shortcut is on the Desktop or in the Start Menu." & vbNewLine & vbNewLine &
                "Valid hot key-options:" & vbNewLine & vbNewLine & """ALT+"", ""CTRL+"", ""SHIFT+"", and ""EXT+""." & vbNewLine & vbNewLine &
                """A"" .. ""Z"", ""0"" .. ""9"", ""NUMPAD0"" .. ""NUMPAD9"", ""Back"", ""Tab"", ""Clear"", ""Return"", ""Escape"", ""Space"", and ""Prior"".",
                MsgBoxStyle.Critical, "Error saving Shortcut properties")
            Exit Sub
        Catch ex As UnauthorizedAccessException When Not WalkmanLib.IsAdmin()
            Select Case WalkmanLib.CustomMsgBox(ex.Message, Operations.cMBTitle, Operations.cMBbRelaunch, Operations.cMBbRunSysTool, Operations.cMBbCancel, MessageBoxIcon.Exclamation, ownerForm:=PropertiesDotNet)
                Case Operations.cMBbRelaunch
                    PropertiesDotNet.RestartAsAdmin()
                Case Operations.cMBbRunSysTool
                    Dim scriptPath As String = Environment.GetEnvironmentVariable("temp") & Path.DirectorySeparatorChar & "createShortcut.vbs"
                    Using writer As StreamWriter = New StreamWriter(File.Open(scriptPath, FileMode.Create))
                        writer.WriteLine("Set lnk = WScript.CreateObject(""WScript.Shell"").CreateShortcut(""" & PropertiesDotNet.lblLocation.Text & """)")
                        writer.WriteLine("lnk.TargetPath = """ & txtTarget.Text & """")
                        writer.WriteLine("lnk.Arguments = """ & txtArguments.Text & """")
                        writer.WriteLine("lnk.WorkingDirectory = """ & txtStartIn.Text & """")
                        writer.WriteLine("lnk.IconLocation = """ & txtIconPath.Text & """")
                        writer.WriteLine("lnk.Description = """ & txtComment.Text & """")
                        writer.WriteLine("lnk.HotKey = """ & txtShortcutKey.Text & """")
                        If windowStyle = Windows.Forms.FormWindowState.Normal Then
                            writer.WriteLine("lnk.WindowStyle = 1")
                        ElseIf windowStyle = Windows.Forms.FormWindowState.Minimized Then
                            writer.WriteLine("lnk.WindowStyle = 7")
                        ElseIf windowStyle = Windows.Forms.FormWindowState.Maximized Then
                            writer.WriteLine("lnk.WindowStyle = 3")
                        End If
                        writer.WriteLine("lnk.Save")
                    End Using

                    WalkmanLib.RunAsAdmin("wscript", scriptPath)
                    Threading.Thread.Sleep(500)
            End Select
        Catch ex As Exception
            PropertiesDotNet.ErrorParser(ex)
            Exit Sub
        End Try

        WalkmanLib.SetShortcutRunAsAdmin(PropertiesDotNet.lblLocation.Text, chkRunAs.Checked)

        Me.Hide()
    End Sub

    Sub btnCancel_Click() Handles btnCancel.Click
        Me.Hide()
    End Sub
End Class
