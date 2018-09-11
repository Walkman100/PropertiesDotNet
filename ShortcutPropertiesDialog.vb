﻿Public Class ShortcutPropertiesDialog
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
        Me.fbdStartIn = New System.Windows.Forms.FolderBrowserDialog()
        Me.SuspendLayout
        'btnCancel
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(169, 247)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 20
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = true
        'btnSave
        Me.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnSave.Location = New System.Drawing.Point(88, 247)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 19
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = true
        'btnTarget
        Me.btnTarget.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnTarget.Location = New System.Drawing.Point(245, 10)
        Me.btnTarget.Name = "btnTarget"
        Me.btnTarget.Size = New System.Drawing.Size(75, 23)
        Me.btnTarget.TabIndex = 2
        Me.btnTarget.Text = "Browse..."
        Me.btnTarget.UseVisualStyleBackColor = true
        'txtTarget
        Me.txtTarget.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtTarget.Location = New System.Drawing.Point(81, 12)
        Me.txtTarget.Name = "txtTarget"
        Me.txtTarget.Size = New System.Drawing.Size(158, 20)
        Me.txtTarget.TabIndex = 1
        'txtArguments
        Me.txtArguments.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtArguments.Location = New System.Drawing.Point(81, 38)
        Me.txtArguments.Name = "txtArguments"
        Me.txtArguments.Size = New System.Drawing.Size(239, 20)
        Me.txtArguments.TabIndex = 4
        'txtStartIn
        Me.txtStartIn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtStartIn.Location = New System.Drawing.Point(81, 64)
        Me.txtStartIn.Name = "txtStartIn"
        Me.txtStartIn.Size = New System.Drawing.Size(158, 20)
        Me.txtStartIn.TabIndex = 6
        'btnStartIn
        Me.btnStartIn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnStartIn.Location = New System.Drawing.Point(245, 62)
        Me.btnStartIn.Name = "btnStartIn"
        Me.btnStartIn.Size = New System.Drawing.Size(75, 23)
        Me.btnStartIn.TabIndex = 7
        Me.btnStartIn.Text = "Browse..."
        Me.btnStartIn.UseVisualStyleBackColor = true
        'txtIconPath
        Me.txtIconPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
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
        Me.btnIconBrowse.UseVisualStyleBackColor = true
        'txtShortcutKey
        Me.txtShortcutKey.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtShortcutKey.Location = New System.Drawing.Point(81, 145)
        Me.txtShortcutKey.Name = "txtShortcutKey"
        Me.txtShortcutKey.Size = New System.Drawing.Size(239, 20)
        Me.txtShortcutKey.TabIndex = 13
        'txtComment
        Me.txtComment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtComment.Location = New System.Drawing.Point(81, 171)
        Me.txtComment.Name = "txtComment"
        Me.txtComment.Size = New System.Drawing.Size(239, 20)
        Me.txtComment.TabIndex = 15
        'cbxWindow
        Me.cbxWindow.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.cbxWindow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxWindow.FormattingEnabled = true
        Me.cbxWindow.Location = New System.Drawing.Point(81, 197)
        Me.cbxWindow.Name = "cbxWindow"
        Me.cbxWindow.Size = New System.Drawing.Size(239, 21)
        Me.cbxWindow.TabIndex = 17
        'lblTarget
        Me.lblTarget.AutoSize = true
        Me.lblTarget.Location = New System.Drawing.Point(6, 15)
        Me.lblTarget.Name = "lblTarget"
        Me.lblTarget.Size = New System.Drawing.Size(41, 13)
        Me.lblTarget.TabIndex = 0
        Me.lblTarget.Text = "Target:"
        'lblArguments
        Me.lblArguments.AutoSize = true
        Me.lblArguments.Location = New System.Drawing.Point(6, 41)
        Me.lblArguments.Name = "lblArguments"
        Me.lblArguments.Size = New System.Drawing.Size(60, 13)
        Me.lblArguments.TabIndex = 3
        Me.lblArguments.Text = "Arguments:"
        'lblStartIn
        Me.lblStartIn.AutoSize = true
        Me.lblStartIn.Location = New System.Drawing.Point(6, 67)
        Me.lblStartIn.Name = "lblStartIn"
        Me.lblStartIn.Size = New System.Drawing.Size(44, 13)
        Me.lblStartIn.TabIndex = 5
        Me.lblStartIn.Text = "Start In:"
        'lblIconPath
        Me.lblIconPath.AutoSize = true
        Me.lblIconPath.Location = New System.Drawing.Point(6, 93)
        Me.lblIconPath.Name = "lblIconPath"
        Me.lblIconPath.Size = New System.Drawing.Size(56, 13)
        Me.lblIconPath.TabIndex = 8
        Me.lblIconPath.Text = "Icon Path:"
        'lblShortcutKey
        Me.lblShortcutKey.AutoSize = true
        Me.lblShortcutKey.Location = New System.Drawing.Point(6, 148)
        Me.lblShortcutKey.Name = "lblShortcutKey"
        Me.lblShortcutKey.Size = New System.Drawing.Size(71, 13)
        Me.lblShortcutKey.TabIndex = 12
        Me.lblShortcutKey.Text = "Shortcut Key:"
        'lblComment
        Me.lblComment.AutoSize = true
        Me.lblComment.Location = New System.Drawing.Point(6, 174)
        Me.lblComment.Name = "lblComment"
        Me.lblComment.Size = New System.Drawing.Size(54, 13)
        Me.lblComment.TabIndex = 14
        Me.lblComment.Text = "Comment:"
        'lblWindow
        Me.lblWindow.AutoSize = true
        Me.lblWindow.Location = New System.Drawing.Point(6, 200)
        Me.lblWindow.Name = "lblWindow"
        Me.lblWindow.Size = New System.Drawing.Size(75, 13)
        Me.lblWindow.TabIndex = 16
        Me.lblWindow.Text = "Window Style:"
        'chkRunAs
        Me.chkRunAs.AutoSize = true
        Me.chkRunAs.Location = New System.Drawing.Point(81, 224)
        Me.chkRunAs.Name = "chkRunAs"
        Me.chkRunAs.Size = New System.Drawing.Size(123, 17)
        Me.chkRunAs.TabIndex = 18
        Me.chkRunAs.Text = "Run as Administrator"
        Me.chkRunAs.UseVisualStyleBackColor = true
        'btnIconPick
        Me.btnIconPick.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnIconPick.Location = New System.Drawing.Point(204, 116)
        Me.btnIconPick.Name = "btnIconPick"
        Me.btnIconPick.Size = New System.Drawing.Size(75, 23)
        Me.btnIconPick.TabIndex = 11
        Me.btnIconPick.Text = "Pick Icon..."
        Me.btnIconPick.UseVisualStyleBackColor = true
        'ofdTarget
        Me.ofdTarget.Filter = "All Files|*.*"
        Me.ofdTarget.Title = "Select Shortcut Target"
        'ofdIcon
        Me.ofdIcon.DefaultExt = "ico"
        Me.ofdIcon.Filter = "Icon Files|*.ico,*.icl,*.exe,*.dll|All Files|*.*"
        Me.ofdIcon.Title = "Select Shortcut Icon File"
        'fbdStartIn
        Me.fbdStartIn.Description = "Select Start In folder for Shortcut:"
        'ShortcutPropertiesDialog
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(332, 282)
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
        Me.Name = "ShortcutPropertiesDialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Shortcut Properties"
        Me.ResumeLayout(false)
        Me.PerformLayout
    End Sub
    Private fbdStartIn As System.Windows.Forms.FolderBrowserDialog
    Private ofdIcon As System.Windows.Forms.OpenFileDialog
    Private ofdTarget As System.Windows.Forms.OpenFileDialog
    Private WithEvents btnIconPick As System.Windows.Forms.Button
    Private chkRunAs As System.Windows.Forms.CheckBox
    Private lblWindow As System.Windows.Forms.Label
    Private lblComment As System.Windows.Forms.Label
    Private lblShortcutKey As System.Windows.Forms.Label
    Private lblIconPath As System.Windows.Forms.Label
    Private lblStartIn As System.Windows.Forms.Label
    Private lblArguments As System.Windows.Forms.Label
    Private lblTarget As System.Windows.Forms.Label
    Private cbxWindow As System.Windows.Forms.ComboBox
    Private txtComment As System.Windows.Forms.TextBox
    Private txtShortcutKey As System.Windows.Forms.TextBox
    Private WithEvents btnIconBrowse As System.Windows.Forms.Button
    Private txtIconPath As System.Windows.Forms.TextBox
    Private WithEvents btnStartIn As System.Windows.Forms.Button
    Private txtStartIn As System.Windows.Forms.TextBox
    Private txtArguments As System.Windows.Forms.TextBox
    Private txtTarget As System.Windows.Forms.TextBox
    Private WithEvents btnTarget As System.Windows.Forms.Button
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private btnCancel As System.Windows.Forms.Button
    
    Public Sub New()
        Me.InitializeComponent()
    End Sub
End Class