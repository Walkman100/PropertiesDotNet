﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PropertiesDotNet
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblLocation = New System.Windows.Forms.Label()
        Me.chkHidden = New System.Windows.Forms.CheckBox()
        Me.chkSystem = New System.Windows.Forms.CheckBox()
        Me.grpReadOnly = New System.Windows.Forms.GroupBox()
        Me.lblSize = New System.Windows.Forms.Label()
        Me.lblSizeLbl = New System.Windows.Forms.Label()
        Me.chkUTC = New System.Windows.Forms.CheckBox()
        Me.lblLastWriteTime = New System.Windows.Forms.Label()
        Me.lblLastWriteTimeLbl = New System.Windows.Forms.Label()
        Me.lblLastAccessTime = New System.Windows.Forms.Label()
        Me.lblLastAccessTimeLbl = New System.Windows.Forms.Label()
        Me.lblCreationTime = New System.Windows.Forms.Label()
        Me.lblCreationTimeLbl = New System.Windows.Forms.Label()
        Me.lblFullPath = New System.Windows.Forms.Label()
        Me.lblDirectory = New System.Windows.Forms.Label()
        Me.lblExtension = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblDirectoryLbl = New System.Windows.Forms.Label()
        Me.lblExtensionLbl = New System.Windows.Forms.Label()
        Me.lblNameLbl = New System.Windows.Forms.Label()
        Me.lblFullPathLbl = New System.Windows.Forms.Label()
        Me.lblPathLbl = New System.Windows.Forms.Label()
        Me.grpChangeable = New System.Windows.Forms.GroupBox()
        Me.grpEditID = New System.Windows.Forms.GroupBox()
        Me.grpReadOnly.SuspendLayout
        Me.grpChangeable.SuspendLayout
        Me.SuspendLayout
        '
        'lblLocation
        '
        Me.lblLocation.AutoSize = true
        Me.lblLocation.Location = New System.Drawing.Point(101, 16)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(0, 13)
        Me.lblLocation.TabIndex = 0
        '
        'chkHidden
        '
        Me.chkHidden.AutoSize = true
        Me.chkHidden.Location = New System.Drawing.Point(28, 19)
        Me.chkHidden.Name = "chkHidden"
        Me.chkHidden.Size = New System.Drawing.Size(60, 17)
        Me.chkHidden.TabIndex = 1
        Me.chkHidden.Text = "Hidden"
        Me.chkHidden.UseVisualStyleBackColor = true
        '
        'chkSystem
        '
        Me.chkSystem.AutoSize = true
        Me.chkSystem.Location = New System.Drawing.Point(55, 57)
        Me.chkSystem.Name = "chkSystem"
        Me.chkSystem.Size = New System.Drawing.Size(60, 17)
        Me.chkSystem.TabIndex = 2
        Me.chkSystem.Text = "System"
        Me.chkSystem.UseVisualStyleBackColor = true
        '
        'grpReadOnly
        '
        Me.grpReadOnly.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
                        Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.grpReadOnly.Controls.Add(Me.lblSize)
        Me.grpReadOnly.Controls.Add(Me.lblSizeLbl)
        Me.grpReadOnly.Controls.Add(Me.chkUTC)
        Me.grpReadOnly.Controls.Add(Me.lblLastWriteTime)
        Me.grpReadOnly.Controls.Add(Me.lblLastWriteTimeLbl)
        Me.grpReadOnly.Controls.Add(Me.lblLastAccessTime)
        Me.grpReadOnly.Controls.Add(Me.lblLastAccessTimeLbl)
        Me.grpReadOnly.Controls.Add(Me.lblCreationTime)
        Me.grpReadOnly.Controls.Add(Me.lblCreationTimeLbl)
        Me.grpReadOnly.Controls.Add(Me.lblFullPath)
        Me.grpReadOnly.Controls.Add(Me.lblDirectory)
        Me.grpReadOnly.Controls.Add(Me.lblExtension)
        Me.grpReadOnly.Controls.Add(Me.lblName)
        Me.grpReadOnly.Controls.Add(Me.lblDirectoryLbl)
        Me.grpReadOnly.Controls.Add(Me.lblExtensionLbl)
        Me.grpReadOnly.Controls.Add(Me.lblNameLbl)
        Me.grpReadOnly.Controls.Add(Me.lblFullPathLbl)
        Me.grpReadOnly.Controls.Add(Me.lblPathLbl)
        Me.grpReadOnly.Controls.Add(Me.lblLocation)
        Me.grpReadOnly.Location = New System.Drawing.Point(2, 4)
        Me.grpReadOnly.Name = "grpReadOnly"
        Me.grpReadOnly.Size = New System.Drawing.Size(363, 142)
        Me.grpReadOnly.TabIndex = 3
        Me.grpReadOnly.TabStop = false
        Me.grpReadOnly.Text = "Read-only Attributes:"
        '
        'lblSize
        '
        Me.lblSize.AutoSize = true
        Me.lblSize.Location = New System.Drawing.Point(101, 81)
        Me.lblSize.Name = "lblSize"
        Me.lblSize.Size = New System.Drawing.Size(61, 13)
        Me.lblSize.TabIndex = 18
        Me.lblSize.Text = "Checking..."
        '
        'lblSizeLbl
        '
        Me.lblSizeLbl.AutoSize = true
        Me.lblSizeLbl.Location = New System.Drawing.Point(6, 81)
        Me.lblSizeLbl.Name = "lblSizeLbl"
        Me.lblSizeLbl.Size = New System.Drawing.Size(64, 13)
        Me.lblSizeLbl.TabIndex = 17
        Me.lblSizeLbl.Text = "Size (bytes):"
        '
        'chkUTC
        '
        Me.chkUTC.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.chkUTC.AutoSize = true
        Me.chkUTC.Location = New System.Drawing.Point(234, 67)
        Me.chkUTC.Name = "chkUTC"
        Me.chkUTC.Size = New System.Drawing.Size(120, 17)
        Me.chkUTC.TabIndex = 16
        Me.chkUTC.Text = "Show Times in UTC"
        Me.chkUTC.UseVisualStyleBackColor = true
        '
        'lblLastWriteTime
        '
        Me.lblLastWriteTime.AutoSize = true
        Me.lblLastWriteTime.Location = New System.Drawing.Point(101, 120)
        Me.lblLastWriteTime.Name = "lblLastWriteTime"
        Me.lblLastWriteTime.Size = New System.Drawing.Size(61, 13)
        Me.lblLastWriteTime.TabIndex = 15
        Me.lblLastWriteTime.Text = "Checking..."
        '
        'lblLastWriteTimeLbl
        '
        Me.lblLastWriteTimeLbl.AutoSize = true
        Me.lblLastWriteTimeLbl.Location = New System.Drawing.Point(6, 120)
        Me.lblLastWriteTimeLbl.Name = "lblLastWriteTimeLbl"
        Me.lblLastWriteTimeLbl.Size = New System.Drawing.Size(77, 13)
        Me.lblLastWriteTimeLbl.TabIndex = 14
        Me.lblLastWriteTimeLbl.Text = "Last write time:"
        '
        'lblLastAccessTime
        '
        Me.lblLastAccessTime.AutoSize = true
        Me.lblLastAccessTime.Location = New System.Drawing.Point(101, 107)
        Me.lblLastAccessTime.Name = "lblLastAccessTime"
        Me.lblLastAccessTime.Size = New System.Drawing.Size(61, 13)
        Me.lblLastAccessTime.TabIndex = 13
        Me.lblLastAccessTime.Text = "Checking..."
        '
        'lblLastAccessTimeLbl
        '
        Me.lblLastAccessTimeLbl.AutoSize = true
        Me.lblLastAccessTimeLbl.Location = New System.Drawing.Point(6, 107)
        Me.lblLastAccessTimeLbl.Name = "lblLastAccessTimeLbl"
        Me.lblLastAccessTimeLbl.Size = New System.Drawing.Size(89, 13)
        Me.lblLastAccessTimeLbl.TabIndex = 12
        Me.lblLastAccessTimeLbl.Text = "Last access time:"
        '
        'lblCreationTime
        '
        Me.lblCreationTime.AutoSize = true
        Me.lblCreationTime.Location = New System.Drawing.Point(101, 94)
        Me.lblCreationTime.Name = "lblCreationTime"
        Me.lblCreationTime.Size = New System.Drawing.Size(61, 13)
        Me.lblCreationTime.TabIndex = 11
        Me.lblCreationTime.Text = "Checking..."
        '
        'lblCreationTimeLbl
        '
        Me.lblCreationTimeLbl.AutoSize = true
        Me.lblCreationTimeLbl.Location = New System.Drawing.Point(6, 94)
        Me.lblCreationTimeLbl.Name = "lblCreationTimeLbl"
        Me.lblCreationTimeLbl.Size = New System.Drawing.Size(71, 13)
        Me.lblCreationTimeLbl.TabIndex = 10
        Me.lblCreationTimeLbl.Text = "Creation time:"
        '
        'lblFullPath
        '
        Me.lblFullPath.AutoSize = true
        Me.lblFullPath.Location = New System.Drawing.Point(101, 29)
        Me.lblFullPath.Name = "lblFullPath"
        Me.lblFullPath.Size = New System.Drawing.Size(61, 13)
        Me.lblFullPath.TabIndex = 9
        Me.lblFullPath.Text = "Checking..."
        '
        'lblDirectory
        '
        Me.lblDirectory.AutoSize = true
        Me.lblDirectory.Location = New System.Drawing.Point(101, 42)
        Me.lblDirectory.Name = "lblDirectory"
        Me.lblDirectory.Size = New System.Drawing.Size(61, 13)
        Me.lblDirectory.TabIndex = 8
        Me.lblDirectory.Text = "Checking..."
        '
        'lblExtension
        '
        Me.lblExtension.AutoSize = true
        Me.lblExtension.Location = New System.Drawing.Point(101, 68)
        Me.lblExtension.Name = "lblExtension"
        Me.lblExtension.Size = New System.Drawing.Size(61, 13)
        Me.lblExtension.TabIndex = 7
        Me.lblExtension.Text = "Checking..."
        '
        'lblName
        '
        Me.lblName.AutoSize = true
        Me.lblName.Location = New System.Drawing.Point(101, 55)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(61, 13)
        Me.lblName.TabIndex = 6
        Me.lblName.Text = "Checking..."
        '
        'lblDirectoryLbl
        '
        Me.lblDirectoryLbl.AutoSize = true
        Me.lblDirectoryLbl.Location = New System.Drawing.Point(6, 42)
        Me.lblDirectoryLbl.Name = "lblDirectoryLbl"
        Me.lblDirectoryLbl.Size = New System.Drawing.Size(77, 13)
        Me.lblDirectoryLbl.TabIndex = 5
        Me.lblDirectoryLbl.Text = "Directory Path:"
        '
        'lblExtensionLbl
        '
        Me.lblExtensionLbl.AutoSize = true
        Me.lblExtensionLbl.Location = New System.Drawing.Point(6, 68)
        Me.lblExtensionLbl.Name = "lblExtensionLbl"
        Me.lblExtensionLbl.Size = New System.Drawing.Size(56, 13)
        Me.lblExtensionLbl.TabIndex = 4
        Me.lblExtensionLbl.Text = "Extension:"
        '
        'lblNameLbl
        '
        Me.lblNameLbl.AutoSize = true
        Me.lblNameLbl.Location = New System.Drawing.Point(6, 55)
        Me.lblNameLbl.Name = "lblNameLbl"
        Me.lblNameLbl.Size = New System.Drawing.Size(38, 13)
        Me.lblNameLbl.TabIndex = 3
        Me.lblNameLbl.Text = "Name:"
        '
        'lblFullPathLbl
        '
        Me.lblFullPathLbl.AutoSize = true
        Me.lblFullPathLbl.Location = New System.Drawing.Point(6, 29)
        Me.lblFullPathLbl.Name = "lblFullPathLbl"
        Me.lblFullPathLbl.Size = New System.Drawing.Size(51, 13)
        Me.lblFullPathLbl.TabIndex = 2
        Me.lblFullPathLbl.Text = "Full Path:"
        '
        'lblPathLbl
        '
        Me.lblPathLbl.AutoSize = true
        Me.lblPathLbl.Location = New System.Drawing.Point(6, 16)
        Me.lblPathLbl.Name = "lblPathLbl"
        Me.lblPathLbl.Size = New System.Drawing.Size(83, 13)
        Me.lblPathLbl.TabIndex = 1
        Me.lblPathLbl.Text = "Read from path:"
        '
        'grpChangeable
        '
        Me.grpChangeable.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
                        Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.grpChangeable.Controls.Add(Me.chkHidden)
        Me.grpChangeable.Controls.Add(Me.chkSystem)
        Me.grpChangeable.Location = New System.Drawing.Point(2, 152)
        Me.grpChangeable.Name = "grpChangeable"
        Me.grpChangeable.Size = New System.Drawing.Size(363, 92)
        Me.grpChangeable.TabIndex = 4
        Me.grpChangeable.TabStop = false
        Me.grpChangeable.Text = "Changeable attributes:"
        '
        'grpEditID
        '
        Me.grpEditID.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
                        Or System.Windows.Forms.AnchorStyles.Left)  _
                        Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.grpEditID.Location = New System.Drawing.Point(2, 250)
        Me.grpEditID.Name = "grpEditID"
        Me.grpEditID.Size = New System.Drawing.Size(363, 220)
        Me.grpEditID.TabIndex = 5
        Me.grpEditID.TabStop = false
        Me.grpEditID.Text = "File location:"
        '
        'PropertiesDotNet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(368, 472)
        Me.Controls.Add(Me.grpEditID)
        Me.Controls.Add(Me.grpChangeable)
        Me.Controls.Add(Me.grpReadOnly)
        Me.HelpButton = true
        Me.MaximizeBox = false
        Me.Name = "PropertiesDotNet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PropertiesDotNet"
        Me.grpReadOnly.ResumeLayout(false)
        Me.grpReadOnly.PerformLayout
        Me.grpChangeable.ResumeLayout(false)
        Me.grpChangeable.PerformLayout
        Me.ResumeLayout(false)
    End Sub
    Private lblSizeLbl As System.Windows.Forms.Label
    Private lblSize As System.Windows.Forms.Label
    Private grpEditID As System.Windows.Forms.GroupBox
    Private lblLastWriteTime As System.Windows.Forms.Label
    Private withevents chkUTC As System.Windows.Forms.CheckBox
    Private lblName As System.Windows.Forms.Label
    Private lblExtension As System.Windows.Forms.Label
    Private lblDirectory As System.Windows.Forms.Label
    Private lblFullPath As System.Windows.Forms.Label
    Private lblCreationTimeLbl As System.Windows.Forms.Label
    Private lblCreationTime As System.Windows.Forms.Label
    Private lblLastAccessTimeLbl As System.Windows.Forms.Label
    Private lblLastAccessTime As System.Windows.Forms.Label
    Private lblLastWriteTimeLbl As System.Windows.Forms.Label
    Private lblExtensionLbl As System.Windows.Forms.Label
    Private lblDirectoryLbl As System.Windows.Forms.Label
    Private lblFullPathLbl As System.Windows.Forms.Label
    Private lblNameLbl As System.Windows.Forms.Label
    Private grpChangeable As System.Windows.Forms.GroupBox
    Private lblPathLbl As System.Windows.Forms.Label
    Private grpReadOnly As System.Windows.Forms.GroupBox
    Private withevents chkSystem As System.Windows.Forms.CheckBox
    Private withevents chkHidden As System.Windows.Forms.CheckBox
    Private lblLocation As System.Windows.Forms.Label

End Class
