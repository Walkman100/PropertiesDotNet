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
        Me.components = New System.ComponentModel.Container()
        Me.lblLocation = New System.Windows.Forms.Label()
        Me.chkHidden = New System.Windows.Forms.CheckBox()
        Me.chkSystem = New System.Windows.Forms.CheckBox()
        Me.grpReadOnly = New System.Windows.Forms.GroupBox()
        Me.btnHashes = New System.Windows.Forms.Button()
        Me.btnCopyFullPath = New System.Windows.Forms.Button()
        Me.btnCopyDirectory = New System.Windows.Forms.Button()
        Me.btnCopyName = New System.Windows.Forms.Button()
        Me.btnCopyExtension = New System.Windows.Forms.Button()
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
        Me.lnkAttributes = New System.Windows.Forms.LinkLabel()
        Me.chkSparse = New System.Windows.Forms.CheckBox()
        Me.chkReparse = New System.Windows.Forms.CheckBox()
        Me.chkOffline = New System.Windows.Forms.CheckBox()
        Me.chkNotIndexed = New System.Windows.Forms.CheckBox()
        Me.chkNoScrub = New System.Windows.Forms.CheckBox()
        Me.chkIntegrity = New System.Windows.Forms.CheckBox()
        Me.chkTemporary = New System.Windows.Forms.CheckBox()
        Me.chkArchive = New System.Windows.Forms.CheckBox()
        Me.chkEncrypted = New System.Windows.Forms.CheckBox()
        Me.chkCompressed = New System.Windows.Forms.CheckBox()
        Me.chkReadOnly = New System.Windows.Forms.CheckBox()
        Me.grpEditID = New System.Windows.Forms.GroupBox()
        Me.btnMove = New System.Windows.Forms.Button()
        Me.btnCopy = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnRename = New System.Windows.Forms.Button()
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.timerCloseCompressForm = New System.Windows.Forms.Timer(Me.components)
        Me.btnClose = New System.Windows.Forms.Button()
        Me.grpReadOnly.SuspendLayout
        Me.grpChangeable.SuspendLayout
        Me.grpEditID.SuspendLayout
        Me.SuspendLayout
        '
        'lblLocation
        '
        Me.lblLocation.AutoSize = true
        Me.lblLocation.Location = New System.Drawing.Point(101, 16)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(61, 13)
        Me.lblLocation.TabIndex = 0
        Me.lblLocation.Text = "Checking..."
        '
        'chkHidden
        '
        Me.chkHidden.AutoSize = true
        Me.chkHidden.Location = New System.Drawing.Point(6, 34)
        Me.chkHidden.Name = "chkHidden"
        Me.chkHidden.Size = New System.Drawing.Size(60, 17)
        Me.chkHidden.TabIndex = 1
        Me.chkHidden.Text = "Hidden"
        Me.chkHidden.UseVisualStyleBackColor = true
        '
        'chkSystem
        '
        Me.chkSystem.AutoSize = true
        Me.chkSystem.Location = New System.Drawing.Point(6, 79)
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
        Me.grpReadOnly.Controls.Add(Me.btnHashes)
        Me.grpReadOnly.Controls.Add(Me.btnCopyFullPath)
        Me.grpReadOnly.Controls.Add(Me.btnCopyDirectory)
        Me.grpReadOnly.Controls.Add(Me.btnCopyName)
        Me.grpReadOnly.Controls.Add(Me.btnCopyExtension)
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
        Me.grpReadOnly.Size = New System.Drawing.Size(411, 199)
        Me.grpReadOnly.TabIndex = 3
        Me.grpReadOnly.TabStop = false
        Me.grpReadOnly.Text = "Read-only Attributes:"
        '
        'btnHashes
        '
        Me.btnHashes.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnHashes.Location = New System.Drawing.Point(307, 170)
        Me.btnHashes.Name = "btnHashes"
        Me.btnHashes.Size = New System.Drawing.Size(98, 23)
        Me.btnHashes.TabIndex = 23
        Me.btnHashes.Text = "Compute Hashes"
        Me.btnHashes.UseVisualStyleBackColor = true
        '
        'btnCopyFullPath
        '
        Me.btnCopyFullPath.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnCopyFullPath.Location = New System.Drawing.Point(361, 24)
        Me.btnCopyFullPath.Name = "btnCopyFullPath"
        Me.btnCopyFullPath.Size = New System.Drawing.Size(44, 23)
        Me.btnCopyFullPath.TabIndex = 22
        Me.btnCopyFullPath.Text = "Copy"
        Me.btnCopyFullPath.UseVisualStyleBackColor = true
        '
        'btnCopyDirectory
        '
        Me.btnCopyDirectory.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnCopyDirectory.Location = New System.Drawing.Point(361, 48)
        Me.btnCopyDirectory.Name = "btnCopyDirectory"
        Me.btnCopyDirectory.Size = New System.Drawing.Size(44, 23)
        Me.btnCopyDirectory.TabIndex = 21
        Me.btnCopyDirectory.Text = "Copy"
        Me.btnCopyDirectory.UseVisualStyleBackColor = true
        '
        'btnCopyName
        '
        Me.btnCopyName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnCopyName.Location = New System.Drawing.Point(361, 72)
        Me.btnCopyName.Name = "btnCopyName"
        Me.btnCopyName.Size = New System.Drawing.Size(44, 23)
        Me.btnCopyName.TabIndex = 20
        Me.btnCopyName.Text = "Copy"
        Me.btnCopyName.UseVisualStyleBackColor = true
        '
        'btnCopyExtension
        '
        Me.btnCopyExtension.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnCopyExtension.Location = New System.Drawing.Point(361, 96)
        Me.btnCopyExtension.Name = "btnCopyExtension"
        Me.btnCopyExtension.Size = New System.Drawing.Size(44, 23)
        Me.btnCopyExtension.TabIndex = 19
        Me.btnCopyExtension.Text = "Copy"
        Me.btnCopyExtension.UseVisualStyleBackColor = true
        '
        'lblSize
        '
        Me.lblSize.AutoSize = true
        Me.lblSize.Location = New System.Drawing.Point(101, 114)
        Me.lblSize.Name = "lblSize"
        Me.lblSize.Size = New System.Drawing.Size(61, 13)
        Me.lblSize.TabIndex = 18
        Me.lblSize.Text = "Checking..."
        '
        'lblSizeLbl
        '
        Me.lblSizeLbl.AutoSize = true
        Me.lblSizeLbl.Location = New System.Drawing.Point(6, 114)
        Me.lblSizeLbl.Name = "lblSizeLbl"
        Me.lblSizeLbl.Size = New System.Drawing.Size(64, 13)
        Me.lblSizeLbl.TabIndex = 17
        Me.lblSizeLbl.Text = "Size (bytes):"
        '
        'chkUTC
        '
        Me.chkUTC.AutoSize = true
        Me.chkUTC.Location = New System.Drawing.Point(10, 130)
        Me.chkUTC.Name = "chkUTC"
        Me.chkUTC.Size = New System.Drawing.Size(120, 17)
        Me.chkUTC.TabIndex = 16
        Me.chkUTC.Text = "Show Times in UTC"
        Me.chkUTC.UseVisualStyleBackColor = true
        '
        'lblLastWriteTime
        '
        Me.lblLastWriteTime.AutoSize = true
        Me.lblLastWriteTime.Location = New System.Drawing.Point(101, 176)
        Me.lblLastWriteTime.Name = "lblLastWriteTime"
        Me.lblLastWriteTime.Size = New System.Drawing.Size(61, 13)
        Me.lblLastWriteTime.TabIndex = 15
        Me.lblLastWriteTime.Text = "Checking..."
        '
        'lblLastWriteTimeLbl
        '
        Me.lblLastWriteTimeLbl.AutoSize = true
        Me.lblLastWriteTimeLbl.Location = New System.Drawing.Point(6, 176)
        Me.lblLastWriteTimeLbl.Name = "lblLastWriteTimeLbl"
        Me.lblLastWriteTimeLbl.Size = New System.Drawing.Size(77, 13)
        Me.lblLastWriteTimeLbl.TabIndex = 14
        Me.lblLastWriteTimeLbl.Text = "Last write time:"
        '
        'lblLastAccessTime
        '
        Me.lblLastAccessTime.AutoSize = true
        Me.lblLastAccessTime.Location = New System.Drawing.Point(101, 163)
        Me.lblLastAccessTime.Name = "lblLastAccessTime"
        Me.lblLastAccessTime.Size = New System.Drawing.Size(61, 13)
        Me.lblLastAccessTime.TabIndex = 13
        Me.lblLastAccessTime.Text = "Checking..."
        '
        'lblLastAccessTimeLbl
        '
        Me.lblLastAccessTimeLbl.AutoSize = true
        Me.lblLastAccessTimeLbl.Location = New System.Drawing.Point(6, 163)
        Me.lblLastAccessTimeLbl.Name = "lblLastAccessTimeLbl"
        Me.lblLastAccessTimeLbl.Size = New System.Drawing.Size(89, 13)
        Me.lblLastAccessTimeLbl.TabIndex = 12
        Me.lblLastAccessTimeLbl.Text = "Last access time:"
        '
        'lblCreationTime
        '
        Me.lblCreationTime.AutoSize = true
        Me.lblCreationTime.Location = New System.Drawing.Point(101, 150)
        Me.lblCreationTime.Name = "lblCreationTime"
        Me.lblCreationTime.Size = New System.Drawing.Size(61, 13)
        Me.lblCreationTime.TabIndex = 11
        Me.lblCreationTime.Text = "Checking..."
        '
        'lblCreationTimeLbl
        '
        Me.lblCreationTimeLbl.AutoSize = true
        Me.lblCreationTimeLbl.Location = New System.Drawing.Point(6, 150)
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
        Me.lblDirectory.Location = New System.Drawing.Point(101, 53)
        Me.lblDirectory.Name = "lblDirectory"
        Me.lblDirectory.Size = New System.Drawing.Size(61, 13)
        Me.lblDirectory.TabIndex = 8
        Me.lblDirectory.Text = "Checking..."
        '
        'lblExtension
        '
        Me.lblExtension.AutoSize = true
        Me.lblExtension.Location = New System.Drawing.Point(101, 101)
        Me.lblExtension.Name = "lblExtension"
        Me.lblExtension.Size = New System.Drawing.Size(61, 13)
        Me.lblExtension.TabIndex = 7
        Me.lblExtension.Text = "Checking..."
        '
        'lblName
        '
        Me.lblName.AutoSize = true
        Me.lblName.Location = New System.Drawing.Point(101, 77)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(61, 13)
        Me.lblName.TabIndex = 6
        Me.lblName.Text = "Checking..."
        '
        'lblDirectoryLbl
        '
        Me.lblDirectoryLbl.AutoSize = true
        Me.lblDirectoryLbl.Location = New System.Drawing.Point(6, 53)
        Me.lblDirectoryLbl.Name = "lblDirectoryLbl"
        Me.lblDirectoryLbl.Size = New System.Drawing.Size(77, 13)
        Me.lblDirectoryLbl.TabIndex = 5
        Me.lblDirectoryLbl.Text = "Directory Path:"
        '
        'lblExtensionLbl
        '
        Me.lblExtensionLbl.AutoSize = true
        Me.lblExtensionLbl.Location = New System.Drawing.Point(6, 101)
        Me.lblExtensionLbl.Name = "lblExtensionLbl"
        Me.lblExtensionLbl.Size = New System.Drawing.Size(56, 13)
        Me.lblExtensionLbl.TabIndex = 4
        Me.lblExtensionLbl.Text = "Extension:"
        '
        'lblNameLbl
        '
        Me.lblNameLbl.AutoSize = true
        Me.lblNameLbl.Location = New System.Drawing.Point(6, 77)
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
        Me.grpChangeable.Controls.Add(Me.lnkAttributes)
        Me.grpChangeable.Controls.Add(Me.chkSparse)
        Me.grpChangeable.Controls.Add(Me.chkReparse)
        Me.grpChangeable.Controls.Add(Me.chkOffline)
        Me.grpChangeable.Controls.Add(Me.chkNotIndexed)
        Me.grpChangeable.Controls.Add(Me.chkNoScrub)
        Me.grpChangeable.Controls.Add(Me.chkIntegrity)
        Me.grpChangeable.Controls.Add(Me.chkTemporary)
        Me.grpChangeable.Controls.Add(Me.chkArchive)
        Me.grpChangeable.Controls.Add(Me.chkSystem)
        Me.grpChangeable.Controls.Add(Me.chkEncrypted)
        Me.grpChangeable.Controls.Add(Me.chkCompressed)
        Me.grpChangeable.Controls.Add(Me.chkHidden)
        Me.grpChangeable.Controls.Add(Me.chkReadOnly)
        Me.grpChangeable.Location = New System.Drawing.Point(2, 209)
        Me.grpChangeable.Name = "grpChangeable"
        Me.grpChangeable.Size = New System.Drawing.Size(411, 221)
        Me.grpChangeable.TabIndex = 4
        Me.grpChangeable.TabStop = false
        Me.grpChangeable.Text = "Changeable attributes:"
        '
        'lnkAttributes
        '
        Me.lnkAttributes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.lnkAttributes.AutoSize = true
        Me.lnkAttributes.LinkArea = New System.Windows.Forms.LinkArea(21, 4)
        Me.lnkAttributes.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkAttributes.Location = New System.Drawing.Point(279, 16)
        Me.lnkAttributes.Name = "lnkAttributes"
        Me.lnkAttributes.Size = New System.Drawing.Size(126, 17)
        Me.lnkAttributes.TabIndex = 14
        Me.lnkAttributes.TabStop = true
        Me.lnkAttributes.Text = "See full description here"
        Me.lnkAttributes.UseCompatibleTextRendering = true
        '
        'chkSparse
        '
        Me.chkSparse.AutoSize = true
        Me.chkSparse.Location = New System.Drawing.Point(6, 199)
        Me.chkSparse.Name = "chkSparse"
        Me.chkSparse.Size = New System.Drawing.Size(234, 17)
        Me.chkSparse.TabIndex = 13
        Me.chkSparse.Text = "Sparse - large files consisting of mostly zeros"
        Me.chkSparse.UseVisualStyleBackColor = true
        '
        'chkReparse
        '
        Me.chkReparse.AutoSize = true
        Me.chkReparse.Location = New System.Drawing.Point(6, 184)
        Me.chkReparse.Name = "chkReparse"
        Me.chkReparse.Size = New System.Drawing.Size(279, 17)
        Me.chkReparse.TabIndex = 12
        Me.chkReparse.Text = "Contains Reparse Point - A block of user-defined data"
        Me.chkReparse.UseVisualStyleBackColor = true
        '
        'chkOffline
        '
        Me.chkOffline.AutoSize = true
        Me.chkOffline.Location = New System.Drawing.Point(6, 169)
        Me.chkOffline.Name = "chkOffline"
        Me.chkOffline.Size = New System.Drawing.Size(211, 17)
        Me.chkOffline.TabIndex = 11
        Me.chkOffline.Text = "Offline - File is not immediately available"
        Me.chkOffline.UseVisualStyleBackColor = true
        '
        'chkNotIndexed
        '
        Me.chkNotIndexed.AutoSize = true
        Me.chkNotIndexed.Location = New System.Drawing.Point(6, 154)
        Me.chkNotIndexed.Name = "chkNotIndexed"
        Me.chkNotIndexed.Size = New System.Drawing.Size(292, 17)
        Me.chkNotIndexed.TabIndex = 10
        Me.chkNotIndexed.Text = "Not Indexed - File will not be indexed by indexing service"
        Me.chkNotIndexed.UseVisualStyleBackColor = true
        '
        'chkNoScrub
        '
        Me.chkNoScrub.AutoSize = true
        Me.chkNoScrub.Location = New System.Drawing.Point(6, 139)
        Me.chkNoScrub.Name = "chkNoScrub"
        Me.chkNoScrub.Size = New System.Drawing.Size(314, 17)
        Me.chkNoScrub.TabIndex = 9
        Me.chkNoScrub.Text = "No Scrub Data - Path is excluded from the data integrity scan"
        Me.chkNoScrub.UseVisualStyleBackColor = true
        '
        'chkIntegrity
        '
        Me.chkIntegrity.AutoSize = true
        Me.chkIntegrity.Location = New System.Drawing.Point(6, 124)
        Me.chkIntegrity.Name = "chkIntegrity"
        Me.chkIntegrity.Size = New System.Drawing.Size(331, 17)
        Me.chkIntegrity.TabIndex = 8
        Me.chkIntegrity.Text = "Data Integrity - The file or directory includes data integrity support"
        Me.chkIntegrity.UseVisualStyleBackColor = true
        '
        'chkTemporary
        '
        Me.chkTemporary.AutoSize = true
        Me.chkTemporary.Location = New System.Drawing.Point(6, 109)
        Me.chkTemporary.Name = "chkTemporary"
        Me.chkTemporary.Size = New System.Drawing.Size(76, 17)
        Me.chkTemporary.TabIndex = 7
        Me.chkTemporary.Text = "Temporary"
        Me.chkTemporary.UseVisualStyleBackColor = true
        '
        'chkArchive
        '
        Me.chkArchive.AutoSize = true
        Me.chkArchive.Location = New System.Drawing.Point(6, 94)
        Me.chkArchive.Name = "chkArchive"
        Me.chkArchive.Size = New System.Drawing.Size(259, 17)
        Me.chkArchive.TabIndex = 6
        Me.chkArchive.Text = "Archive - file is a candidate for backup or removal"
        Me.chkArchive.UseVisualStyleBackColor = true
        '
        'chkEncrypted
        '
        Me.chkEncrypted.AutoSize = true
        Me.chkEncrypted.Location = New System.Drawing.Point(6, 64)
        Me.chkEncrypted.Name = "chkEncrypted"
        Me.chkEncrypted.Size = New System.Drawing.Size(74, 17)
        Me.chkEncrypted.TabIndex = 5
        Me.chkEncrypted.Text = "Encrypted"
        Me.chkEncrypted.UseVisualStyleBackColor = true
        '
        'chkCompressed
        '
        Me.chkCompressed.AutoSize = true
        Me.chkCompressed.Location = New System.Drawing.Point(6, 49)
        Me.chkCompressed.Name = "chkCompressed"
        Me.chkCompressed.Size = New System.Drawing.Size(84, 17)
        Me.chkCompressed.TabIndex = 4
        Me.chkCompressed.Text = "Compressed"
        Me.chkCompressed.UseVisualStyleBackColor = true
        '
        'chkReadOnly
        '
        Me.chkReadOnly.AutoSize = true
        Me.chkReadOnly.Location = New System.Drawing.Point(6, 19)
        Me.chkReadOnly.Name = "chkReadOnly"
        Me.chkReadOnly.Size = New System.Drawing.Size(76, 17)
        Me.chkReadOnly.TabIndex = 3
        Me.chkReadOnly.Text = "Read-Only"
        Me.chkReadOnly.UseVisualStyleBackColor = true
        '
        'grpEditID
        '
        Me.grpEditID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
                        Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.grpEditID.Controls.Add(Me.btnClose)
        Me.grpEditID.Controls.Add(Me.btnMove)
        Me.grpEditID.Controls.Add(Me.btnCopy)
        Me.grpEditID.Controls.Add(Me.btnDelete)
        Me.grpEditID.Controls.Add(Me.btnRename)
        Me.grpEditID.Location = New System.Drawing.Point(2, 436)
        Me.grpEditID.Name = "grpEditID"
        Me.grpEditID.Size = New System.Drawing.Size(411, 50)
        Me.grpEditID.TabIndex = 5
        Me.grpEditID.TabStop = false
        Me.grpEditID.Text = "File location:"
        '
        'btnMove
        '
        Me.btnMove.Location = New System.Drawing.Point(249, 19)
        Me.btnMove.Name = "btnMove"
        Me.btnMove.Size = New System.Drawing.Size(75, 23)
        Me.btnMove.TabIndex = 3
        Me.btnMove.Text = "Move To..."
        Me.btnMove.UseVisualStyleBackColor = true
        '
        'btnCopy
        '
        Me.btnCopy.Location = New System.Drawing.Point(168, 19)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(75, 23)
        Me.btnCopy.TabIndex = 2
        Me.btnCopy.Text = "Copy To..."
        Me.btnCopy.UseVisualStyleBackColor = true
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(87, 19)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 1
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = true
        '
        'btnRename
        '
        Me.btnRename.Location = New System.Drawing.Point(6, 19)
        Me.btnRename.Name = "btnRename"
        Me.btnRename.Size = New System.Drawing.Size(75, 23)
        Me.btnRename.TabIndex = 0
        Me.btnRename.Text = "Rename..."
        Me.btnRename.UseVisualStyleBackColor = true
        '
        'SaveFileDialog
        '
        Me.SaveFileDialog.AddExtension = false
        '
        'timerCloseCompressForm
        '
        Me.timerCloseCompressForm.Interval = 500
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(330, 19)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = true
        '
        'PropertiesDotNet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(416, 488)
        Me.Controls.Add(Me.grpEditID)
        Me.Controls.Add(Me.grpChangeable)
        Me.Controls.Add(Me.grpReadOnly)
        Me.MaximizeBox = false
        Me.Name = "PropertiesDotNet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Properties: "
        Me.grpReadOnly.ResumeLayout(false)
        Me.grpReadOnly.PerformLayout
        Me.grpChangeable.ResumeLayout(false)
        Me.grpChangeable.PerformLayout
        Me.grpEditID.ResumeLayout(false)
        Me.ResumeLayout(false)
    End Sub
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents btnHashes As System.Windows.Forms.Button
    Private WithEvents btnCopyExtension As System.Windows.Forms.Button
    Private WithEvents btnCopyName As System.Windows.Forms.Button
    Private WithEvents btnCopyDirectory As System.Windows.Forms.Button
    Private WithEvents btnCopyFullPath As System.Windows.Forms.Button
    Private WithEvents timerCloseCompressForm As System.Windows.Forms.Timer
    Private SaveFileDialog As System.Windows.Forms.SaveFileDialog
    Private WithEvents btnRename As System.Windows.Forms.Button
    Private WithEvents btnDelete As System.Windows.Forms.Button
    Private WithEvents btnCopy As System.Windows.Forms.Button
    Private WithEvents btnMove As System.Windows.Forms.Button
    Private WithEvents lnkAttributes As System.Windows.Forms.LinkLabel
    Private WithEvents chkReadOnly As System.Windows.Forms.CheckBox
    Private WithEvents chkCompressed As System.Windows.Forms.CheckBox
    Private WithEvents chkEncrypted As System.Windows.Forms.CheckBox
    Private WithEvents chkArchive As System.Windows.Forms.CheckBox
    Private WithEvents chkTemporary As System.Windows.Forms.CheckBox
    Private WithEvents chkIntegrity As System.Windows.Forms.CheckBox
    Private WithEvents chkNoScrub As System.Windows.Forms.CheckBox
    Private WithEvents chkNotIndexed As System.Windows.Forms.CheckBox
    Private WithEvents chkOffline As System.Windows.Forms.CheckBox
    Private WithEvents chkReparse As System.Windows.Forms.CheckBox
    Private WithEvents chkSparse As System.Windows.Forms.CheckBox
    Private lblSizeLbl As System.Windows.Forms.Label
    Private lblSize As System.Windows.Forms.Label
    Private grpEditID As System.Windows.Forms.GroupBox
    Private lblLastWriteTime As System.Windows.Forms.Label
    Private WithEvents chkUTC As System.Windows.Forms.CheckBox
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
    Private WithEvents chkSystem As System.Windows.Forms.CheckBox
    Private WithEvents chkHidden As System.Windows.Forms.CheckBox
    Private lblLocation As System.Windows.Forms.Label
End Class
