<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Settings
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnReload = New System.Windows.Forms.Button()
        Me.btnShowSettingsFile = New System.Windows.Forms.Button()
        Me.chkUseSystemDefault = New System.Windows.Forms.CheckBox()
        Me.chkShowOpenWithWarning = New System.Windows.Forms.CheckBox()
        Me.chkEnableAutoResize = New System.Windows.Forms.CheckBox()
        Me.cbxDriveInfo = New System.Windows.Forms.ComboBox()
        Me.grpDriveInfo = New System.Windows.Forms.GroupBox()
        Me.grpDefaultSize = New System.Windows.Forms.GroupBox()
        Me.cbxDefaultSize = New System.Windows.Forms.ComboBox()
        Me.chkEnableUpdateCheck = New System.Windows.Forms.CheckBox()
        Me.grpDriveInfo.SuspendLayout()
        Me.grpDefaultSize.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(12, 216)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 6
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnSave.Location = New System.Drawing.Point(93, 216)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 7
        Me.btnSave.Text = "Force-Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnReload
        '
        Me.btnReload.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnReload.Location = New System.Drawing.Point(174, 216)
        Me.btnReload.Name = "btnReload"
        Me.btnReload.Size = New System.Drawing.Size(92, 23)
        Me.btnReload.TabIndex = 8
        Me.btnReload.Text = "Reload Settings"
        Me.btnReload.UseVisualStyleBackColor = True
        '
        'btnShowSettingsFile
        '
        Me.btnShowSettingsFile.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnShowSettingsFile.Location = New System.Drawing.Point(272, 216)
        Me.btnShowSettingsFile.Name = "btnShowSettingsFile"
        Me.btnShowSettingsFile.Size = New System.Drawing.Size(104, 23)
        Me.btnShowSettingsFile.TabIndex = 9
        Me.btnShowSettingsFile.Text = "Show Settings File"
        Me.btnShowSettingsFile.UseVisualStyleBackColor = True
        '
        'chkUseSystemDefault
        '
        Me.chkUseSystemDefault.AutoSize = True
        Me.chkUseSystemDefault.Location = New System.Drawing.Point(18, 12)
        Me.chkUseSystemDefault.Name = "chkUseSystemDefault"
        Me.chkUseSystemDefault.Size = New System.Drawing.Size(208, 17)
        Me.chkUseSystemDefault.TabIndex = 0
        Me.chkUseSystemDefault.Text = "Default ""Use Windows Explorer"" State"
        Me.chkUseSystemDefault.UseVisualStyleBackColor = True
        '
        'chkShowOpenWithWarning
        '
        Me.chkShowOpenWithWarning.AutoSize = True
        Me.chkShowOpenWithWarning.Location = New System.Drawing.Point(18, 35)
        Me.chkShowOpenWithWarning.Name = "chkShowOpenWithWarning"
        Me.chkShowOpenWithWarning.Size = New System.Drawing.Size(147, 17)
        Me.chkShowOpenWithWarning.TabIndex = 1
        Me.chkShowOpenWithWarning.Text = "Show OpenWith Warning"
        Me.chkShowOpenWithWarning.UseVisualStyleBackColor = True
        '
        'chkEnableAutoResize
        '
        Me.chkEnableAutoResize.AutoSize = True
        Me.chkEnableAutoResize.Location = New System.Drawing.Point(18, 58)
        Me.chkEnableAutoResize.Name = "chkEnableAutoResize"
        Me.chkEnableAutoResize.Size = New System.Drawing.Size(161, 17)
        Me.chkEnableAutoResize.TabIndex = 2
        Me.chkEnableAutoResize.Text = "Enable Auto Window Resize"
        Me.chkEnableAutoResize.UseVisualStyleBackColor = True
        '
        'cbxDriveInfo
        '
        Me.cbxDriveInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbxDriveInfo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxDriveInfo.FormattingEnabled = True
        Me.cbxDriveInfo.Items.AddRange(New Object() {"Always Show", "Always Hide", "Show on Drives"})
        Me.cbxDriveInfo.Location = New System.Drawing.Point(6, 19)
        Me.cbxDriveInfo.Name = "cbxDriveInfo"
        Me.cbxDriveInfo.Size = New System.Drawing.Size(352, 21)
        Me.cbxDriveInfo.TabIndex = 0
        '
        'grpDriveInfo
        '
        Me.grpDriveInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpDriveInfo.Controls.Add(Me.cbxDriveInfo)
        Me.grpDriveInfo.Location = New System.Drawing.Point(12, 104)
        Me.grpDriveInfo.Name = "grpDriveInfo"
        Me.grpDriveInfo.Size = New System.Drawing.Size(364, 46)
        Me.grpDriveInfo.TabIndex = 4
        Me.grpDriveInfo.TabStop = False
        Me.grpDriveInfo.Text = "Drive Info Visibility"
        '
        'grpDefaultSize
        '
        Me.grpDefaultSize.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpDefaultSize.Controls.Add(Me.cbxDefaultSize)
        Me.grpDefaultSize.Location = New System.Drawing.Point(12, 156)
        Me.grpDefaultSize.Name = "grpDefaultSize"
        Me.grpDefaultSize.Size = New System.Drawing.Size(364, 46)
        Me.grpDefaultSize.TabIndex = 5
        Me.grpDefaultSize.TabStop = False
        Me.grpDefaultSize.Text = "Default Size Selection"
        '
        'cbxDefaultSize
        '
        Me.cbxDefaultSize.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbxDefaultSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxDefaultSize.FormattingEnabled = True
        Me.cbxDefaultSize.Items.AddRange(New Object() {"bytes (8 bits)", "kB  (Decimal - 1000)", "KiB (Binary    - 1024)", "MB (Decimal - 1000)", "MiB (Binary    - 1024)", "GB  (Decimal - 1000)", "GiB (Binary    - 1024)", "TB  (Decimal - 1000)", "TiB (Binary    - 1024)", "PB  (Decimal - 1000)", "PiB (Binary    - 1024)", "Auto (Decimal - 1000)", "Auto (Binary    - 1024)"})
        Me.cbxDefaultSize.Location = New System.Drawing.Point(6, 19)
        Me.cbxDefaultSize.Name = "cbxDefaultSize"
        Me.cbxDefaultSize.Size = New System.Drawing.Size(352, 21)
        Me.cbxDefaultSize.TabIndex = 0
        '
        'chkEnableUpdateCheck
        '
        Me.chkEnableUpdateCheck.AutoSize = True
        Me.chkEnableUpdateCheck.Location = New System.Drawing.Point(18, 81)
        Me.chkEnableUpdateCheck.Name = "chkEnableUpdateCheck"
        Me.chkEnableUpdateCheck.Size = New System.Drawing.Size(131, 17)
        Me.chkEnableUpdateCheck.TabIndex = 3
        Me.chkEnableUpdateCheck.Text = "Enable Update Check"
        Me.chkEnableUpdateCheck.UseVisualStyleBackColor = True
        '
        'Settings
        '
        Me.AcceptButton = Me.btnClose
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(388, 251)
        Me.Controls.Add(Me.chkEnableUpdateCheck)
        Me.Controls.Add(Me.grpDefaultSize)
        Me.Controls.Add(Me.grpDriveInfo)
        Me.Controls.Add(Me.chkEnableAutoResize)
        Me.Controls.Add(Me.chkShowOpenWithWarning)
        Me.Controls.Add(Me.chkUseSystemDefault)
        Me.Controls.Add(Me.btnShowSettingsFile)
        Me.Controls.Add(Me.btnReload)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnClose)
        Me.Icon = Global.My.Resources.Resources.settingsx64
        Me.Name = "Settings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Settings"
        Me.grpDriveInfo.ResumeLayout(False)
        Me.grpDefaultSize.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnReload As System.Windows.Forms.Button
    Friend WithEvents btnShowSettingsFile As System.Windows.Forms.Button
    Friend WithEvents chkUseSystemDefault As System.Windows.Forms.CheckBox
    Friend WithEvents chkShowOpenWithWarning As System.Windows.Forms.CheckBox
    Friend WithEvents chkEnableAutoResize As System.Windows.Forms.CheckBox
    Friend WithEvents cbxDriveInfo As System.Windows.Forms.ComboBox
    Friend WithEvents grpDriveInfo As System.Windows.Forms.GroupBox
    Friend WithEvents grpDefaultSize As System.Windows.Forms.GroupBox
    Friend WithEvents cbxDefaultSize As System.Windows.Forms.ComboBox
    Friend WithEvents chkEnableUpdateCheck As System.Windows.Forms.CheckBox
End Class
