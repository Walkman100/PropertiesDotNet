<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.sfdSave = New System.Windows.Forms.SaveFileDialog()
        Me.lblLocation = New System.Windows.Forms.Label()
        Me.chkHidden = New System.Windows.Forms.CheckBox()
        Me.chkSystem = New System.Windows.Forms.CheckBox()
        Me.grpProperties = New System.Windows.Forms.GroupBox()
        Me.lblDriveTotalUsedSpace = New System.Windows.Forms.Label()
        Me.lblDriveTotalUsedSpaceLbl = New System.Windows.Forms.Label()
        Me.lblDriveAvailableFreeSpaceInfo = New System.Windows.Forms.Label()
        Me.btnDriveVolumeLabel = New System.Windows.Forms.Button()
        Me.lblDriveAvailableFreeSpace = New System.Windows.Forms.Label()
        Me.lblDriveTotalFreeSpace = New System.Windows.Forms.Label()
        Me.lblDriveTotalSize = New System.Windows.Forms.Label()
        Me.lblDriveFormat = New System.Windows.Forms.Label()
        Me.lblDriveVolumeLabel = New System.Windows.Forms.Label()
        Me.lblDriveType = New System.Windows.Forms.Label()
        Me.lblDriveIsReady = New System.Windows.Forms.Label()
        Me.lblDriveAvailableFreeSpaceLbl = New System.Windows.Forms.Label()
        Me.lblDriveTotalFreeSpaceLbl = New System.Windows.Forms.Label()
        Me.lblDriveTotalSizeLbl = New System.Windows.Forms.Label()
        Me.lblDriveFormatLbl = New System.Windows.Forms.Label()
        Me.lblDriveVolumeLabelLbl = New System.Windows.Forms.Label()
        Me.lblDriveTypeLbl = New System.Windows.Forms.Label()
        Me.lblDriveIsReadyLbl = New System.Windows.Forms.Label()
        Me.btnWindowsProperties = New System.Windows.Forms.Button()
        Me.cbxSize = New System.Windows.Forms.ComboBox()
        Me.btnLaunchAdmin = New System.Windows.Forms.Button()
        Me.btnStartAssocProgAdmin = New System.Windows.Forms.Button()
        Me.btnStartAssocProg = New System.Windows.Forms.Button()
        Me.btnCopyOpenWith = New System.Windows.Forms.Button()
        Me.btnOpenWith = New System.Windows.Forms.Button()
        Me.lblOpenWithLbl = New System.Windows.Forms.Label()
        Me.imgFile = New System.Windows.Forms.PictureBox()
        Me.btnOpenDir = New System.Windows.Forms.Button()
        Me.btnLaunch = New System.Windows.Forms.Button()
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
        Me.lblOpenWith = New System.Windows.Forms.Label()
        Me.btnRelaunchAsAdmin = New System.Windows.Forms.Button()
        Me.grpAttributes = New System.Windows.Forms.GroupBox()
        Me.btnHandles = New System.Windows.Forms.Button()
        Me.btnADS = New System.Windows.Forms.Button()
        Me.chkSparse = New System.Windows.Forms.CheckBox()
        Me.chkReparse = New System.Windows.Forms.CheckBox()
        Me.chkIntegrity = New System.Windows.Forms.CheckBox()
        Me.chkNoScrub = New System.Windows.Forms.CheckBox()
        Me.chkTemporary = New System.Windows.Forms.CheckBox()
        Me.chkOffline = New System.Windows.Forms.CheckBox()
        Me.chkEncrypted = New System.Windows.Forms.CheckBox()
        Me.chkCompressed = New System.Windows.Forms.CheckBox()
        Me.chkNotIndexed = New System.Windows.Forms.CheckBox()
        Me.chkArchive = New System.Windows.Forms.CheckBox()
        Me.chkReadOnly = New System.Windows.Forms.CheckBox()
        Me.btnTakeOwn = New System.Windows.Forms.Button()
        Me.lnkAttributes = New System.Windows.Forms.LinkLabel()
        Me.grpFileLocation = New System.Windows.Forms.GroupBox()
        Me.btnHardlink = New System.Windows.Forms.Button()
        Me.btnSymlink = New System.Windows.Forms.Button()
        Me.btnShortcut = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnMove = New System.Windows.Forms.Button()
        Me.btnCopy = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnRename = New System.Windows.Forms.Button()
        Me.chkUseSystem = New System.Windows.Forms.CheckBox()
        Me.bwCalcSize = New System.ComponentModel.BackgroundWorker()
        Me.timerDelayedBrowse = New System.Windows.Forms.Timer(Me.components)
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.ofdBrowse = New System.Windows.Forms.OpenFileDialog()
        Me.myToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnSettings = New System.Windows.Forms.Button()
        Me.grpProperties.SuspendLayout()
        CType(Me.imgFile, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpAttributes.SuspendLayout()
        Me.grpFileLocation.SuspendLayout()
        Me.SuspendLayout()
        '
        'sfdSave
        '
        Me.sfdSave.AddExtension = False
        Me.sfdSave.Filter = "All Files|*.*"
        '
        'lblLocation
        '
        Me.lblLocation.AutoSize = True
        Me.lblLocation.Location = New System.Drawing.Point(101, 16)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(61, 13)
        Me.lblLocation.TabIndex = 1
        Me.lblLocation.Text = "Checking..."
        Me.lblLocation.UseMnemonic = False
        '
        'chkHidden
        '
        Me.chkHidden.AutoSize = True
        Me.chkHidden.Location = New System.Drawing.Point(6, 34)
        Me.chkHidden.Name = "chkHidden"
        Me.chkHidden.Size = New System.Drawing.Size(60, 17)
        Me.chkHidden.TabIndex = 1
        Me.chkHidden.Text = "H&idden"
        Me.chkHidden.UseVisualStyleBackColor = True
        '
        'chkSystem
        '
        Me.chkSystem.AutoSize = True
        Me.chkSystem.Location = New System.Drawing.Point(6, 49)
        Me.chkSystem.Name = "chkSystem"
        Me.chkSystem.Size = New System.Drawing.Size(60, 17)
        Me.chkSystem.TabIndex = 2
        Me.chkSystem.Text = "S&ystem"
        Me.chkSystem.UseVisualStyleBackColor = True
        '
        'grpProperties
        '
        Me.grpProperties.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpProperties.Controls.Add(Me.lblDriveTotalUsedSpace)
        Me.grpProperties.Controls.Add(Me.lblDriveTotalUsedSpaceLbl)
        Me.grpProperties.Controls.Add(Me.lblDriveAvailableFreeSpaceInfo)
        Me.grpProperties.Controls.Add(Me.btnDriveVolumeLabel)
        Me.grpProperties.Controls.Add(Me.lblDriveAvailableFreeSpace)
        Me.grpProperties.Controls.Add(Me.lblDriveTotalFreeSpace)
        Me.grpProperties.Controls.Add(Me.lblDriveTotalSize)
        Me.grpProperties.Controls.Add(Me.lblDriveFormat)
        Me.grpProperties.Controls.Add(Me.lblDriveVolumeLabel)
        Me.grpProperties.Controls.Add(Me.lblDriveType)
        Me.grpProperties.Controls.Add(Me.lblDriveIsReady)
        Me.grpProperties.Controls.Add(Me.lblDriveAvailableFreeSpaceLbl)
        Me.grpProperties.Controls.Add(Me.lblDriveTotalFreeSpaceLbl)
        Me.grpProperties.Controls.Add(Me.lblDriveTotalSizeLbl)
        Me.grpProperties.Controls.Add(Me.lblDriveFormatLbl)
        Me.grpProperties.Controls.Add(Me.lblDriveVolumeLabelLbl)
        Me.grpProperties.Controls.Add(Me.lblDriveTypeLbl)
        Me.grpProperties.Controls.Add(Me.lblDriveIsReadyLbl)
        Me.grpProperties.Controls.Add(Me.btnWindowsProperties)
        Me.grpProperties.Controls.Add(Me.cbxSize)
        Me.grpProperties.Controls.Add(Me.btnLaunchAdmin)
        Me.grpProperties.Controls.Add(Me.btnStartAssocProgAdmin)
        Me.grpProperties.Controls.Add(Me.btnStartAssocProg)
        Me.grpProperties.Controls.Add(Me.btnCopyOpenWith)
        Me.grpProperties.Controls.Add(Me.btnOpenWith)
        Me.grpProperties.Controls.Add(Me.lblOpenWithLbl)
        Me.grpProperties.Controls.Add(Me.imgFile)
        Me.grpProperties.Controls.Add(Me.btnOpenDir)
        Me.grpProperties.Controls.Add(Me.btnLaunch)
        Me.grpProperties.Controls.Add(Me.btnHashes)
        Me.grpProperties.Controls.Add(Me.btnCopyFullPath)
        Me.grpProperties.Controls.Add(Me.btnCopyDirectory)
        Me.grpProperties.Controls.Add(Me.btnCopyName)
        Me.grpProperties.Controls.Add(Me.btnCopyExtension)
        Me.grpProperties.Controls.Add(Me.lblSize)
        Me.grpProperties.Controls.Add(Me.lblSizeLbl)
        Me.grpProperties.Controls.Add(Me.chkUTC)
        Me.grpProperties.Controls.Add(Me.lblLastWriteTime)
        Me.grpProperties.Controls.Add(Me.lblLastWriteTimeLbl)
        Me.grpProperties.Controls.Add(Me.lblLastAccessTime)
        Me.grpProperties.Controls.Add(Me.lblLastAccessTimeLbl)
        Me.grpProperties.Controls.Add(Me.lblCreationTime)
        Me.grpProperties.Controls.Add(Me.lblCreationTimeLbl)
        Me.grpProperties.Controls.Add(Me.lblFullPath)
        Me.grpProperties.Controls.Add(Me.lblDirectory)
        Me.grpProperties.Controls.Add(Me.lblExtension)
        Me.grpProperties.Controls.Add(Me.lblName)
        Me.grpProperties.Controls.Add(Me.lblDirectoryLbl)
        Me.grpProperties.Controls.Add(Me.lblExtensionLbl)
        Me.grpProperties.Controls.Add(Me.lblNameLbl)
        Me.grpProperties.Controls.Add(Me.lblFullPathLbl)
        Me.grpProperties.Controls.Add(Me.lblPathLbl)
        Me.grpProperties.Controls.Add(Me.lblLocation)
        Me.grpProperties.Controls.Add(Me.lblOpenWith)
        Me.grpProperties.Location = New System.Drawing.Point(2, 4)
        Me.grpProperties.Name = "grpProperties"
        Me.grpProperties.Size = New System.Drawing.Size(411, 233)
        Me.grpProperties.TabIndex = 2
        Me.grpProperties.TabStop = False
        Me.grpProperties.Text = "Properties:"
        '
        'lblDriveTotalUsedSpace
        '
        Me.lblDriveTotalUsedSpace.AutoSize = True
        Me.lblDriveTotalUsedSpace.Location = New System.Drawing.Point(101, 298)
        Me.lblDriveTotalUsedSpace.Name = "lblDriveTotalUsedSpace"
        Me.lblDriveTotalUsedSpace.Size = New System.Drawing.Size(61, 13)
        Me.lblDriveTotalUsedSpace.TabIndex = 48
        Me.lblDriveTotalUsedSpace.Text = "Checking..."
        Me.lblDriveTotalUsedSpace.UseMnemonic = False
        '
        'lblDriveTotalUsedSpaceLbl
        '
        Me.lblDriveTotalUsedSpaceLbl.AutoSize = True
        Me.lblDriveTotalUsedSpaceLbl.Location = New System.Drawing.Point(6, 298)
        Me.lblDriveTotalUsedSpaceLbl.Name = "lblDriveTotalUsedSpaceLbl"
        Me.lblDriveTotalUsedSpaceLbl.Size = New System.Drawing.Size(69, 13)
        Me.lblDriveTotalUsedSpaceLbl.TabIndex = 40
        Me.lblDriveTotalUsedSpaceLbl.Text = "Used Space:"
        '
        'lblDriveAvailableFreeSpaceInfo
        '
        Me.lblDriveAvailableFreeSpaceInfo.AutoSize = True
        Me.lblDriveAvailableFreeSpaceInfo.Location = New System.Drawing.Point(22, 337)
        Me.lblDriveAvailableFreeSpaceInfo.Name = "lblDriveAvailableFreeSpaceInfo"
        Me.lblDriveAvailableFreeSpaceInfo.Size = New System.Drawing.Size(268, 13)
        Me.lblDriveAvailableFreeSpaceInfo.TabIndex = 52
        Me.lblDriveAvailableFreeSpaceInfo.Text = "(Available space takes into account user quotas, if any)"
        '
        'btnDriveVolumeLabel
        '
        Me.btnDriveVolumeLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDriveVolumeLabel.Location = New System.Drawing.Point(330, 254)
        Me.btnDriveVolumeLabel.Name = "btnDriveVolumeLabel"
        Me.btnDriveVolumeLabel.Size = New System.Drawing.Size(75, 23)
        Me.btnDriveVolumeLabel.TabIndex = 51
        Me.btnDriveVolumeLabel.Text = "Rename..."
        Me.myToolTip.SetToolTip(Me.btnDriveVolumeLabel, "Allows renaming the drive containing the current item")
        Me.btnDriveVolumeLabel.UseVisualStyleBackColor = True
        '
        'lblDriveAvailableFreeSpace
        '
        Me.lblDriveAvailableFreeSpace.AutoSize = True
        Me.lblDriveAvailableFreeSpace.Location = New System.Drawing.Point(101, 324)
        Me.lblDriveAvailableFreeSpace.Name = "lblDriveAvailableFreeSpace"
        Me.lblDriveAvailableFreeSpace.Size = New System.Drawing.Size(61, 13)
        Me.lblDriveAvailableFreeSpace.TabIndex = 50
        Me.lblDriveAvailableFreeSpace.Text = "Checking..."
        Me.lblDriveAvailableFreeSpace.UseMnemonic = False
        '
        'lblDriveTotalFreeSpace
        '
        Me.lblDriveTotalFreeSpace.AutoSize = True
        Me.lblDriveTotalFreeSpace.Location = New System.Drawing.Point(101, 311)
        Me.lblDriveTotalFreeSpace.Name = "lblDriveTotalFreeSpace"
        Me.lblDriveTotalFreeSpace.Size = New System.Drawing.Size(61, 13)
        Me.lblDriveTotalFreeSpace.TabIndex = 49
        Me.lblDriveTotalFreeSpace.Text = "Checking..."
        Me.lblDriveTotalFreeSpace.UseMnemonic = False
        '
        'lblDriveTotalSize
        '
        Me.lblDriveTotalSize.AutoSize = True
        Me.lblDriveTotalSize.Location = New System.Drawing.Point(101, 285)
        Me.lblDriveTotalSize.Name = "lblDriveTotalSize"
        Me.lblDriveTotalSize.Size = New System.Drawing.Size(61, 13)
        Me.lblDriveTotalSize.TabIndex = 47
        Me.lblDriveTotalSize.Text = "Checking..."
        Me.lblDriveTotalSize.UseMnemonic = False
        '
        'lblDriveFormat
        '
        Me.lblDriveFormat.AutoSize = True
        Me.lblDriveFormat.Location = New System.Drawing.Point(101, 272)
        Me.lblDriveFormat.Name = "lblDriveFormat"
        Me.lblDriveFormat.Size = New System.Drawing.Size(61, 13)
        Me.lblDriveFormat.TabIndex = 46
        Me.lblDriveFormat.Text = "Checking..."
        Me.lblDriveFormat.UseMnemonic = False
        '
        'lblDriveVolumeLabel
        '
        Me.lblDriveVolumeLabel.AutoSize = True
        Me.lblDriveVolumeLabel.Location = New System.Drawing.Point(101, 259)
        Me.lblDriveVolumeLabel.Name = "lblDriveVolumeLabel"
        Me.lblDriveVolumeLabel.Size = New System.Drawing.Size(61, 13)
        Me.lblDriveVolumeLabel.TabIndex = 45
        Me.lblDriveVolumeLabel.Text = "Checking..."
        Me.lblDriveVolumeLabel.UseMnemonic = False
        '
        'lblDriveType
        '
        Me.lblDriveType.AutoSize = True
        Me.lblDriveType.Location = New System.Drawing.Point(101, 246)
        Me.lblDriveType.Name = "lblDriveType"
        Me.lblDriveType.Size = New System.Drawing.Size(61, 13)
        Me.lblDriveType.TabIndex = 44
        Me.lblDriveType.Text = "Checking..."
        Me.lblDriveType.UseMnemonic = False
        '
        'lblDriveIsReady
        '
        Me.lblDriveIsReady.AutoSize = True
        Me.lblDriveIsReady.Location = New System.Drawing.Point(101, 233)
        Me.lblDriveIsReady.Name = "lblDriveIsReady"
        Me.lblDriveIsReady.Size = New System.Drawing.Size(61, 13)
        Me.lblDriveIsReady.TabIndex = 43
        Me.lblDriveIsReady.Text = "Checking..."
        Me.lblDriveIsReady.UseMnemonic = False
        '
        'lblDriveAvailableFreeSpaceLbl
        '
        Me.lblDriveAvailableFreeSpaceLbl.AutoSize = True
        Me.lblDriveAvailableFreeSpaceLbl.Location = New System.Drawing.Point(6, 324)
        Me.lblDriveAvailableFreeSpaceLbl.Name = "lblDriveAvailableFreeSpaceLbl"
        Me.lblDriveAvailableFreeSpaceLbl.Size = New System.Drawing.Size(87, 13)
        Me.lblDriveAvailableFreeSpaceLbl.TabIndex = 42
        Me.lblDriveAvailableFreeSpaceLbl.Text = "Available Space:"
        '
        'lblDriveTotalFreeSpaceLbl
        '
        Me.lblDriveTotalFreeSpaceLbl.AutoSize = True
        Me.lblDriveTotalFreeSpaceLbl.Location = New System.Drawing.Point(6, 311)
        Me.lblDriveTotalFreeSpaceLbl.Name = "lblDriveTotalFreeSpaceLbl"
        Me.lblDriveTotalFreeSpaceLbl.Size = New System.Drawing.Size(65, 13)
        Me.lblDriveTotalFreeSpaceLbl.TabIndex = 41
        Me.lblDriveTotalFreeSpaceLbl.Text = "Free Space:"
        '
        'lblDriveTotalSizeLbl
        '
        Me.lblDriveTotalSizeLbl.AutoSize = True
        Me.lblDriveTotalSizeLbl.Location = New System.Drawing.Point(6, 285)
        Me.lblDriveTotalSizeLbl.Name = "lblDriveTotalSizeLbl"
        Me.lblDriveTotalSizeLbl.Size = New System.Drawing.Size(97, 13)
        Me.lblDriveTotalSizeLbl.TabIndex = 39
        Me.lblDriveTotalSizeLbl.Text = "Total Size of Drive:"
        '
        'lblDriveFormatLbl
        '
        Me.lblDriveFormatLbl.AutoSize = True
        Me.lblDriveFormatLbl.Location = New System.Drawing.Point(6, 272)
        Me.lblDriveFormatLbl.Name = "lblDriveFormatLbl"
        Me.lblDriveFormatLbl.Size = New System.Drawing.Size(80, 13)
        Me.lblDriveFormatLbl.TabIndex = 38
        Me.lblDriveFormatLbl.Text = "Volume Format:"
        '
        'lblDriveVolumeLabelLbl
        '
        Me.lblDriveVolumeLabelLbl.AutoSize = True
        Me.lblDriveVolumeLabelLbl.Location = New System.Drawing.Point(6, 259)
        Me.lblDriveVolumeLabelLbl.Name = "lblDriveVolumeLabelLbl"
        Me.lblDriveVolumeLabelLbl.Size = New System.Drawing.Size(74, 13)
        Me.lblDriveVolumeLabelLbl.TabIndex = 37
        Me.lblDriveVolumeLabelLbl.Text = "Volume Label:"
        '
        'lblDriveTypeLbl
        '
        Me.lblDriveTypeLbl.AutoSize = True
        Me.lblDriveTypeLbl.Location = New System.Drawing.Point(6, 246)
        Me.lblDriveTypeLbl.Name = "lblDriveTypeLbl"
        Me.lblDriveTypeLbl.Size = New System.Drawing.Size(62, 13)
        Me.lblDriveTypeLbl.TabIndex = 36
        Me.lblDriveTypeLbl.Text = "Drive Type:"
        '
        'lblDriveIsReadyLbl
        '
        Me.lblDriveIsReadyLbl.AutoSize = True
        Me.lblDriveIsReadyLbl.Location = New System.Drawing.Point(6, 233)
        Me.lblDriveIsReadyLbl.Name = "lblDriveIsReadyLbl"
        Me.lblDriveIsReadyLbl.Size = New System.Drawing.Size(79, 13)
        Me.lblDriveIsReadyLbl.TabIndex = 35
        Me.lblDriveIsReadyLbl.Text = "Drive is Ready:"
        '
        'btnWindowsProperties
        '
        Me.btnWindowsProperties.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnWindowsProperties.Location = New System.Drawing.Point(291, 178)
        Me.btnWindowsProperties.Name = "btnWindowsProperties"
        Me.btnWindowsProperties.Size = New System.Drawing.Size(114, 23)
        Me.btnWindowsProperties.TabIndex = 33
        Me.btnWindowsProperties.Text = "Windows &Properties"
        Me.myToolTip.SetToolTip(Me.btnWindowsProperties, "Opens the Windows Properties pane for the current item")
        Me.btnWindowsProperties.UseVisualStyleBackColor = True
        '
        'cbxSize
        '
        Me.cbxSize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbxSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxSize.FormattingEnabled = True
        Me.cbxSize.Items.AddRange(New Object() {"bytes (8 bits)", "kB  (Decimal - 1000)", "KiB (Binary    - 1024)", "MB (Decimal - 1000)", "MiB (Binary    - 1024)", "GB  (Decimal - 1000)", "GiB (Binary    - 1024)", "TB  (Decimal - 1000)", "TiB (Binary    - 1024)", "PB  (Decimal - 1000)", "PiB (Binary    - 1024)", "(Click to read more)"})
        Me.cbxSize.Location = New System.Drawing.Point(282, 120)
        Me.cbxSize.Name = "cbxSize"
        Me.cbxSize.Size = New System.Drawing.Size(122, 21)
        Me.cbxSize.TabIndex = 20
        Me.myToolTip.SetToolTip(Me.cbxSize, "Changes the display factor for sizes. Also affects Drive sizes")
        '
        'btnLaunchAdmin
        '
        Me.btnLaunchAdmin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLaunchAdmin.Image = Global.My.Resources.Resources.admin
        Me.btnLaunchAdmin.Location = New System.Drawing.Point(337, 71)
        Me.btnLaunchAdmin.Name = "btnLaunchAdmin"
        Me.btnLaunchAdmin.Size = New System.Drawing.Size(23, 25)
        Me.btnLaunchAdmin.TabIndex = 12
        Me.myToolTip.SetToolTip(Me.btnLaunchAdmin, "Launches the associated program as administrator, with the current item as argume" &
        "nt")
        Me.btnLaunchAdmin.UseVisualStyleBackColor = True
        '
        'btnStartAssocProgAdmin
        '
        Me.btnStartAssocProgAdmin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStartAssocProgAdmin.Image = Global.My.Resources.Resources.admin
        Me.btnStartAssocProgAdmin.Location = New System.Drawing.Point(337, 141)
        Me.btnStartAssocProgAdmin.Name = "btnStartAssocProgAdmin"
        Me.btnStartAssocProgAdmin.Size = New System.Drawing.Size(23, 25)
        Me.btnStartAssocProgAdmin.TabIndex = 24
        Me.myToolTip.SetToolTip(Me.btnStartAssocProgAdmin, "Runs the program associated with the current item as Administrator")
        Me.btnStartAssocProgAdmin.UseVisualStyleBackColor = True
        '
        'btnStartAssocProg
        '
        Me.btnStartAssocProg.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStartAssocProg.Location = New System.Drawing.Point(276, 142)
        Me.btnStartAssocProg.Name = "btnStartAssocProg"
        Me.btnStartAssocProg.Size = New System.Drawing.Size(62, 23)
        Me.btnStartAssocProg.TabIndex = 23
        Me.btnStartAssocProg.Text = "L&aunch..."
        Me.myToolTip.SetToolTip(Me.btnStartAssocProg, "Launches the program associated with the current item")
        Me.btnStartAssocProg.UseVisualStyleBackColor = True
        '
        'btnCopyOpenWith
        '
        Me.btnCopyOpenWith.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCopyOpenWith.Location = New System.Drawing.Point(361, 142)
        Me.btnCopyOpenWith.Name = "btnCopyOpenWith"
        Me.btnCopyOpenWith.Size = New System.Drawing.Size(44, 23)
        Me.btnCopyOpenWith.TabIndex = 25
        Me.btnCopyOpenWith.Text = "Copy"
        Me.myToolTip.SetToolTip(Me.btnCopyOpenWith, "Copies the path to the program associated with the file type to the clipboard")
        Me.btnCopyOpenWith.UseVisualStyleBackColor = True
        '
        'btnOpenWith
        '
        Me.btnOpenWith.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOpenWith.Image = Global.My.Resources.Resources.mouse_right_click_8x
        Me.btnOpenWith.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.btnOpenWith.Location = New System.Drawing.Point(285, 96)
        Me.btnOpenWith.Name = "btnOpenWith"
        Me.btnOpenWith.Size = New System.Drawing.Size(75, 23)
        Me.btnOpenWith.TabIndex = 16
        Me.btnOpenWith.Text = "Open &with..."
        Me.myToolTip.SetToolTip(Me.btnOpenWith, "Launches Windows' ""Open With"" dialog. Right-Click to launch ProgramLauncher.")
        Me.btnOpenWith.UseVisualStyleBackColor = True
        '
        'lblOpenWithLbl
        '
        Me.lblOpenWithLbl.AutoSize = True
        Me.lblOpenWithLbl.Location = New System.Drawing.Point(48, 147)
        Me.lblOpenWithLbl.Name = "lblOpenWithLbl"
        Me.lblOpenWithLbl.Size = New System.Drawing.Size(63, 13)
        Me.lblOpenWithLbl.TabIndex = 21
        Me.lblOpenWithLbl.Text = "Opens with:"
        '
        'imgFile
        '
        Me.imgFile.Cursor = System.Windows.Forms.Cursors.Hand
        Me.imgFile.Image = Global.My.Resources.Resources.loading4
        Me.imgFile.Location = New System.Drawing.Point(10, 147)
        Me.imgFile.Name = "imgFile"
        Me.imgFile.Size = New System.Drawing.Size(32, 32)
        Me.imgFile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.imgFile.TabIndex = 26
        Me.imgFile.TabStop = False
        Me.myToolTip.SetToolTip(Me.imgFile, "Image contents, or File Icon. Click to enlarge")
        '
        'btnOpenDir
        '
        Me.btnOpenDir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOpenDir.Location = New System.Drawing.Point(298, 48)
        Me.btnOpenDir.Name = "btnOpenDir"
        Me.btnOpenDir.Size = New System.Drawing.Size(62, 23)
        Me.btnOpenDir.TabIndex = 7
        Me.btnOpenDir.Text = "Open..."
        Me.myToolTip.SetToolTip(Me.btnOpenDir, "Opens the containing directory and selects the current item in Windows Explorer")
        Me.btnOpenDir.UseVisualStyleBackColor = True
        '
        'btnLaunch
        '
        Me.btnLaunch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLaunch.Location = New System.Drawing.Point(276, 72)
        Me.btnLaunch.Name = "btnLaunch"
        Me.btnLaunch.Size = New System.Drawing.Size(62, 23)
        Me.btnLaunch.TabIndex = 11
        Me.btnLaunch.Text = "&Launch..."
        Me.myToolTip.SetToolTip(Me.btnLaunch, "Launches the current item. This will either run the program, or open it with it's" &
        " associated program")
        Me.btnLaunch.UseVisualStyleBackColor = True
        '
        'btnHashes
        '
        Me.btnHashes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnHashes.Image = Global.My.Resources.Resources.hashx16
        Me.btnHashes.Location = New System.Drawing.Point(291, 204)
        Me.btnHashes.Name = "btnHashes"
        Me.btnHashes.Size = New System.Drawing.Size(114, 23)
        Me.btnHashes.TabIndex = 34
        Me.btnHashes.Text = "Compute &Hashes"
        Me.btnHashes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.myToolTip.SetToolTip(Me.btnHashes, "Opens the Hashing window if the current item is a file, or opens DirectoryImage i" &
        "f the current item is a folder")
        Me.btnHashes.UseVisualStyleBackColor = True
        '
        'btnCopyFullPath
        '
        Me.btnCopyFullPath.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCopyFullPath.Location = New System.Drawing.Point(361, 24)
        Me.btnCopyFullPath.Name = "btnCopyFullPath"
        Me.btnCopyFullPath.Size = New System.Drawing.Size(44, 23)
        Me.btnCopyFullPath.TabIndex = 4
        Me.btnCopyFullPath.Text = "Copy"
        Me.myToolTip.SetToolTip(Me.btnCopyFullPath, "Copies the full path to the clipboard")
        Me.btnCopyFullPath.UseVisualStyleBackColor = True
        '
        'btnCopyDirectory
        '
        Me.btnCopyDirectory.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCopyDirectory.Location = New System.Drawing.Point(361, 48)
        Me.btnCopyDirectory.Name = "btnCopyDirectory"
        Me.btnCopyDirectory.Size = New System.Drawing.Size(44, 23)
        Me.btnCopyDirectory.TabIndex = 8
        Me.btnCopyDirectory.Text = "Copy"
        Me.myToolTip.SetToolTip(Me.btnCopyDirectory, "Copies the containing directory path to the clipboard")
        Me.btnCopyDirectory.UseVisualStyleBackColor = True
        '
        'btnCopyName
        '
        Me.btnCopyName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCopyName.Location = New System.Drawing.Point(361, 72)
        Me.btnCopyName.Name = "btnCopyName"
        Me.btnCopyName.Size = New System.Drawing.Size(44, 23)
        Me.btnCopyName.TabIndex = 13
        Me.btnCopyName.Text = "Copy"
        Me.myToolTip.SetToolTip(Me.btnCopyName, "Copies the current item name to the clipboard")
        Me.btnCopyName.UseVisualStyleBackColor = True
        '
        'btnCopyExtension
        '
        Me.btnCopyExtension.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCopyExtension.Location = New System.Drawing.Point(361, 96)
        Me.btnCopyExtension.Name = "btnCopyExtension"
        Me.btnCopyExtension.Size = New System.Drawing.Size(44, 23)
        Me.btnCopyExtension.TabIndex = 17
        Me.btnCopyExtension.Text = "Copy"
        Me.myToolTip.SetToolTip(Me.btnCopyExtension, "Copies the current item extension to the clipboard")
        Me.btnCopyExtension.UseVisualStyleBackColor = True
        '
        'lblSize
        '
        Me.lblSize.AutoSize = True
        Me.lblSize.Location = New System.Drawing.Point(101, 123)
        Me.lblSize.Name = "lblSize"
        Me.lblSize.Size = New System.Drawing.Size(61, 13)
        Me.lblSize.TabIndex = 19
        Me.lblSize.Text = "Checking..."
        Me.lblSize.UseMnemonic = False
        '
        'lblSizeLbl
        '
        Me.lblSizeLbl.AutoSize = True
        Me.lblSizeLbl.Location = New System.Drawing.Point(6, 123)
        Me.lblSizeLbl.Name = "lblSizeLbl"
        Me.lblSizeLbl.Size = New System.Drawing.Size(97, 13)
        Me.lblSizeLbl.TabIndex = 18
        Me.lblSizeLbl.Text = "Size (not disk size):"
        '
        'chkUTC
        '
        Me.chkUTC.AutoSize = True
        Me.chkUTC.Location = New System.Drawing.Point(48, 163)
        Me.chkUTC.Name = "chkUTC"
        Me.chkUTC.Size = New System.Drawing.Size(120, 17)
        Me.chkUTC.TabIndex = 26
        Me.chkUTC.Text = "Show Times in &UTC"
        Me.myToolTip.SetToolTip(Me.chkUTC, "Toggles times between UTC and local time. Also refreshes most info")
        Me.chkUTC.UseVisualStyleBackColor = True
        '
        'lblLastWriteTime
        '
        Me.lblLastWriteTime.AutoSize = True
        Me.lblLastWriteTime.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblLastWriteTime.Location = New System.Drawing.Point(101, 209)
        Me.lblLastWriteTime.Name = "lblLastWriteTime"
        Me.lblLastWriteTime.Size = New System.Drawing.Size(61, 13)
        Me.lblLastWriteTime.TabIndex = 32
        Me.lblLastWriteTime.Text = "Checking..."
        Me.myToolTip.SetToolTip(Me.lblLastWriteTime, "Date and Time file was last written to. Click to choose time to set to")
        Me.lblLastWriteTime.UseMnemonic = False
        '
        'lblLastWriteTimeLbl
        '
        Me.lblLastWriteTimeLbl.AutoSize = True
        Me.lblLastWriteTimeLbl.Location = New System.Drawing.Point(6, 209)
        Me.lblLastWriteTimeLbl.Name = "lblLastWriteTimeLbl"
        Me.lblLastWriteTimeLbl.Size = New System.Drawing.Size(77, 13)
        Me.lblLastWriteTimeLbl.TabIndex = 31
        Me.lblLastWriteTimeLbl.Text = "Last write time:"
        '
        'lblLastAccessTime
        '
        Me.lblLastAccessTime.AutoSize = True
        Me.lblLastAccessTime.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblLastAccessTime.Location = New System.Drawing.Point(101, 196)
        Me.lblLastAccessTime.Name = "lblLastAccessTime"
        Me.lblLastAccessTime.Size = New System.Drawing.Size(61, 13)
        Me.lblLastAccessTime.TabIndex = 30
        Me.lblLastAccessTime.Text = "Checking..."
        Me.myToolTip.SetToolTip(Me.lblLastAccessTime, "Date and Time file was last accessed. Click to choose time to set to")
        Me.lblLastAccessTime.UseMnemonic = False
        '
        'lblLastAccessTimeLbl
        '
        Me.lblLastAccessTimeLbl.AutoSize = True
        Me.lblLastAccessTimeLbl.Location = New System.Drawing.Point(6, 196)
        Me.lblLastAccessTimeLbl.Name = "lblLastAccessTimeLbl"
        Me.lblLastAccessTimeLbl.Size = New System.Drawing.Size(89, 13)
        Me.lblLastAccessTimeLbl.TabIndex = 29
        Me.lblLastAccessTimeLbl.Text = "Last access time:"
        '
        'lblCreationTime
        '
        Me.lblCreationTime.AutoSize = True
        Me.lblCreationTime.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblCreationTime.Location = New System.Drawing.Point(101, 183)
        Me.lblCreationTime.Name = "lblCreationTime"
        Me.lblCreationTime.Size = New System.Drawing.Size(61, 13)
        Me.lblCreationTime.TabIndex = 28
        Me.lblCreationTime.Text = "Checking..."
        Me.myToolTip.SetToolTip(Me.lblCreationTime, "Date and Time of file creation. Click to choose time to set to")
        Me.lblCreationTime.UseMnemonic = False
        '
        'lblCreationTimeLbl
        '
        Me.lblCreationTimeLbl.AutoSize = True
        Me.lblCreationTimeLbl.Location = New System.Drawing.Point(6, 183)
        Me.lblCreationTimeLbl.Name = "lblCreationTimeLbl"
        Me.lblCreationTimeLbl.Size = New System.Drawing.Size(71, 13)
        Me.lblCreationTimeLbl.TabIndex = 27
        Me.lblCreationTimeLbl.Text = "Creation time:"
        '
        'lblFullPath
        '
        Me.lblFullPath.AutoSize = True
        Me.lblFullPath.Location = New System.Drawing.Point(101, 29)
        Me.lblFullPath.Name = "lblFullPath"
        Me.lblFullPath.Size = New System.Drawing.Size(61, 13)
        Me.lblFullPath.TabIndex = 3
        Me.lblFullPath.Text = "Checking..."
        Me.lblFullPath.UseMnemonic = False
        '
        'lblDirectory
        '
        Me.lblDirectory.AutoSize = True
        Me.lblDirectory.Location = New System.Drawing.Point(101, 53)
        Me.lblDirectory.Name = "lblDirectory"
        Me.lblDirectory.Size = New System.Drawing.Size(61, 13)
        Me.lblDirectory.TabIndex = 6
        Me.lblDirectory.Text = "Checking..."
        Me.lblDirectory.UseMnemonic = False
        '
        'lblExtension
        '
        Me.lblExtension.AutoSize = True
        Me.lblExtension.Location = New System.Drawing.Point(101, 101)
        Me.lblExtension.Name = "lblExtension"
        Me.lblExtension.Size = New System.Drawing.Size(61, 13)
        Me.lblExtension.TabIndex = 15
        Me.lblExtension.Text = "Checking..."
        Me.lblExtension.UseMnemonic = False
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(101, 77)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(61, 13)
        Me.lblName.TabIndex = 10
        Me.lblName.Text = "Checking..."
        Me.lblName.UseMnemonic = False
        '
        'lblDirectoryLbl
        '
        Me.lblDirectoryLbl.AutoSize = True
        Me.lblDirectoryLbl.Location = New System.Drawing.Point(6, 53)
        Me.lblDirectoryLbl.Name = "lblDirectoryLbl"
        Me.lblDirectoryLbl.Size = New System.Drawing.Size(77, 13)
        Me.lblDirectoryLbl.TabIndex = 5
        Me.lblDirectoryLbl.Text = "Directory Path:"
        '
        'lblExtensionLbl
        '
        Me.lblExtensionLbl.AutoSize = True
        Me.lblExtensionLbl.Location = New System.Drawing.Point(6, 101)
        Me.lblExtensionLbl.Name = "lblExtensionLbl"
        Me.lblExtensionLbl.Size = New System.Drawing.Size(56, 13)
        Me.lblExtensionLbl.TabIndex = 14
        Me.lblExtensionLbl.Text = "Extension:"
        '
        'lblNameLbl
        '
        Me.lblNameLbl.AutoSize = True
        Me.lblNameLbl.Location = New System.Drawing.Point(6, 77)
        Me.lblNameLbl.Name = "lblNameLbl"
        Me.lblNameLbl.Size = New System.Drawing.Size(38, 13)
        Me.lblNameLbl.TabIndex = 9
        Me.lblNameLbl.Text = "Name:"
        '
        'lblFullPathLbl
        '
        Me.lblFullPathLbl.AutoSize = True
        Me.lblFullPathLbl.Location = New System.Drawing.Point(6, 29)
        Me.lblFullPathLbl.Name = "lblFullPathLbl"
        Me.lblFullPathLbl.Size = New System.Drawing.Size(51, 13)
        Me.lblFullPathLbl.TabIndex = 2
        Me.lblFullPathLbl.Text = "Full Path:"
        '
        'lblPathLbl
        '
        Me.lblPathLbl.AutoSize = True
        Me.lblPathLbl.Location = New System.Drawing.Point(6, 16)
        Me.lblPathLbl.Name = "lblPathLbl"
        Me.lblPathLbl.Size = New System.Drawing.Size(83, 13)
        Me.lblPathLbl.TabIndex = 0
        Me.lblPathLbl.Text = "Read from path:"
        '
        'lblOpenWith
        '
        Me.lblOpenWith.AutoSize = True
        Me.lblOpenWith.Location = New System.Drawing.Point(117, 147)
        Me.lblOpenWith.Name = "lblOpenWith"
        Me.lblOpenWith.Size = New System.Drawing.Size(61, 13)
        Me.lblOpenWith.TabIndex = 22
        Me.lblOpenWith.Text = "Checking..."
        Me.lblOpenWith.UseMnemonic = False
        '
        'btnRelaunchAsAdmin
        '
        Me.btnRelaunchAsAdmin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRelaunchAsAdmin.Image = Global.My.Resources.Resources.admin
        Me.btnRelaunchAsAdmin.Location = New System.Drawing.Point(360, 2)
        Me.btnRelaunchAsAdmin.Name = "btnRelaunchAsAdmin"
        Me.btnRelaunchAsAdmin.Size = New System.Drawing.Size(23, 25)
        Me.btnRelaunchAsAdmin.TabIndex = 0
        Me.myToolTip.SetToolTip(Me.btnRelaunchAsAdmin, "Relaunch PropertiesDotNet as Administrator")
        Me.btnRelaunchAsAdmin.UseVisualStyleBackColor = True
        '
        'grpAttributes
        '
        Me.grpAttributes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpAttributes.Controls.Add(Me.btnHandles)
        Me.grpAttributes.Controls.Add(Me.btnADS)
        Me.grpAttributes.Controls.Add(Me.chkSparse)
        Me.grpAttributes.Controls.Add(Me.chkReparse)
        Me.grpAttributes.Controls.Add(Me.chkIntegrity)
        Me.grpAttributes.Controls.Add(Me.chkNoScrub)
        Me.grpAttributes.Controls.Add(Me.chkTemporary)
        Me.grpAttributes.Controls.Add(Me.chkOffline)
        Me.grpAttributes.Controls.Add(Me.chkEncrypted)
        Me.grpAttributes.Controls.Add(Me.chkCompressed)
        Me.grpAttributes.Controls.Add(Me.chkNotIndexed)
        Me.grpAttributes.Controls.Add(Me.chkArchive)
        Me.grpAttributes.Controls.Add(Me.chkSystem)
        Me.grpAttributes.Controls.Add(Me.chkHidden)
        Me.grpAttributes.Controls.Add(Me.chkReadOnly)
        Me.grpAttributes.Controls.Add(Me.btnTakeOwn)
        Me.grpAttributes.Controls.Add(Me.lnkAttributes)
        Me.grpAttributes.Location = New System.Drawing.Point(2, 243)
        Me.grpAttributes.Name = "grpAttributes"
        Me.grpAttributes.Size = New System.Drawing.Size(411, 221)
        Me.grpAttributes.TabIndex = 3
        Me.grpAttributes.TabStop = False
        Me.grpAttributes.Text = "Attributes:"
        '
        'btnHandles
        '
        Me.btnHandles.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnHandles.Location = New System.Drawing.Point(287, 89)
        Me.btnHandles.Name = "btnHandles"
        Me.btnHandles.Size = New System.Drawing.Size(118, 23)
        Me.btnHandles.TabIndex = 16
        Me.btnHandles.Text = "In Use By..."
        Me.myToolTip.SetToolTip(Me.btnHandles, "Opens a window that allows to get processes with an open handle (lock) on the cur" &
        "rent item")
        Me.btnHandles.UseVisualStyleBackColor = True
        '
        'btnADS
        '
        Me.btnADS.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnADS.Location = New System.Drawing.Point(287, 63)
        Me.btnADS.Name = "btnADS"
        Me.btnADS.Size = New System.Drawing.Size(118, 23)
        Me.btnADS.TabIndex = 15
        Me.btnADS.Text = "Streams: Checking..."
        Me.myToolTip.SetToolTip(Me.btnADS, "Opens the Alternate Data Streams (ADS) Manager")
        Me.btnADS.UseVisualStyleBackColor = True
        '
        'chkSparse
        '
        Me.chkSparse.AutoSize = True
        Me.chkSparse.Location = New System.Drawing.Point(6, 199)
        Me.chkSparse.Name = "chkSparse"
        Me.chkSparse.Size = New System.Drawing.Size(89, 17)
        Me.chkSparse.TabIndex = 12
        Me.chkSparse.Text = "Is Sparse File"
        Me.chkSparse.UseVisualStyleBackColor = True
        '
        'chkReparse
        '
        Me.chkReparse.AutoSize = True
        Me.chkReparse.Location = New System.Drawing.Point(6, 184)
        Me.chkReparse.Name = "chkReparse"
        Me.chkReparse.Size = New System.Drawing.Size(104, 17)
        Me.chkReparse.TabIndex = 11
        Me.chkReparse.Text = "Is Reparse Point"
        Me.chkReparse.UseVisualStyleBackColor = True
        '
        'chkIntegrity
        '
        Me.chkIntegrity.AutoSize = True
        Me.chkIntegrity.Location = New System.Drawing.Point(6, 169)
        Me.chkIntegrity.Name = "chkIntegrity"
        Me.chkIntegrity.Size = New System.Drawing.Size(129, 17)
        Me.chkIntegrity.TabIndex = 10
        Me.chkIntegrity.Text = "Data Integrity Support"
        Me.chkIntegrity.UseVisualStyleBackColor = True
        '
        'chkNoScrub
        '
        Me.chkNoScrub.AutoSize = True
        Me.chkNoScrub.Location = New System.Drawing.Point(6, 154)
        Me.chkNoScrub.Name = "chkNoScrub"
        Me.chkNoScrub.Size = New System.Drawing.Size(97, 17)
        Me.chkNoScrub.TabIndex = 9
        Me.chkNoScrub.Text = "No Scrub Data"
        Me.chkNoScrub.UseVisualStyleBackColor = True
        '
        'chkTemporary
        '
        Me.chkTemporary.AutoSize = True
        Me.chkTemporary.Location = New System.Drawing.Point(6, 139)
        Me.chkTemporary.Name = "chkTemporary"
        Me.chkTemporary.Size = New System.Drawing.Size(76, 17)
        Me.chkTemporary.TabIndex = 8
        Me.chkTemporary.Text = "&Temporary"
        Me.myToolTip.SetToolTip(Me.chkTemporary, "If on a file, toggles the Temporary attribute. If on a folder, allows toggling " &
        "the Case Sensitive flag, which is meant for WSL but works with Win32 programs. Uses the ""fsutil"" command to c" &
        "hange Case Sensitivity")
        Me.chkTemporary.UseVisualStyleBackColor = True
        '
        'chkOffline
        '
        Me.chkOffline.AutoSize = True
        Me.chkOffline.Location = New System.Drawing.Point(6, 124)
        Me.chkOffline.Name = "chkOffline"
        Me.chkOffline.Size = New System.Drawing.Size(56, 17)
        Me.chkOffline.TabIndex = 7
        Me.chkOffline.Text = "Offline"
        Me.chkOffline.UseVisualStyleBackColor = True
        '
        'chkEncrypted
        '
        Me.chkEncrypted.AutoSize = True
        Me.chkEncrypted.Location = New System.Drawing.Point(6, 109)
        Me.chkEncrypted.Name = "chkEncrypted"
        Me.chkEncrypted.Size = New System.Drawing.Size(74, 17)
        Me.chkEncrypted.TabIndex = 6
        Me.chkEncrypted.Text = "E&ncrypted"
        Me.chkEncrypted.UseVisualStyleBackColor = True
        '
        'chkCompressed
        '
        Me.chkCompressed.AutoSize = True
        Me.chkCompressed.Location = New System.Drawing.Point(6, 94)
        Me.chkCompressed.Name = "chkCompressed"
        Me.chkCompressed.Size = New System.Drawing.Size(84, 17)
        Me.chkCompressed.TabIndex = 5
        Me.chkCompressed.Text = "Compr&essed"
        Me.chkCompressed.UseVisualStyleBackColor = True
        '
        'chkNotIndexed
        '
        Me.chkNotIndexed.AutoSize = True
        Me.chkNotIndexed.Location = New System.Drawing.Point(6, 79)
        Me.chkNotIndexed.Name = "chkNotIndexed"
        Me.chkNotIndexed.Size = New System.Drawing.Size(84, 17)
        Me.chkNotIndexed.TabIndex = 4
        Me.chkNotIndexed.Text = "Not Indexed"
        Me.chkNotIndexed.UseVisualStyleBackColor = True
        '
        'chkArchive
        '
        Me.chkArchive.AutoSize = True
        Me.chkArchive.Location = New System.Drawing.Point(6, 64)
        Me.chkArchive.Name = "chkArchive"
        Me.chkArchive.Size = New System.Drawing.Size(62, 17)
        Me.chkArchive.TabIndex = 3
        Me.chkArchive.Text = "Archive"
        Me.chkArchive.UseVisualStyleBackColor = True
        '
        'chkReadOnly
        '
        Me.chkReadOnly.AutoSize = True
        Me.chkReadOnly.Location = New System.Drawing.Point(6, 19)
        Me.chkReadOnly.Name = "chkReadOnly"
        Me.chkReadOnly.Size = New System.Drawing.Size(76, 17)
        Me.chkReadOnly.TabIndex = 0
        Me.chkReadOnly.Text = "Read-Only"
        Me.chkReadOnly.UseVisualStyleBackColor = True
        '
        'btnTakeOwn
        '
        Me.btnTakeOwn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTakeOwn.Image = Global.My.Resources.Resources.admin
        Me.btnTakeOwn.Location = New System.Drawing.Point(287, 36)
        Me.btnTakeOwn.Name = "btnTakeOwn"
        Me.btnTakeOwn.Size = New System.Drawing.Size(118, 24)
        Me.btnTakeOwn.TabIndex = 14
        Me.btnTakeOwn.Text = "Take &Ownership..."
        Me.btnTakeOwn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.myToolTip.SetToolTip(Me.btnTakeOwn, "Launches system tools to change the Owner of the current item to the current user" &
        ", and grant administators permissions. Runs recursively on a folder")
        Me.btnTakeOwn.UseVisualStyleBackColor = True
        '
        'lnkAttributes
        '
        Me.lnkAttributes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkAttributes.AutoSize = True
        Me.lnkAttributes.LinkArea = New System.Windows.Forms.LinkArea(21, 4)
        Me.lnkAttributes.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkAttributes.Location = New System.Drawing.Point(279, 16)
        Me.lnkAttributes.Name = "lnkAttributes"
        Me.lnkAttributes.Size = New System.Drawing.Size(126, 17)
        Me.lnkAttributes.TabIndex = 13
        Me.lnkAttributes.TabStop = True
        Me.lnkAttributes.Text = "See full description here"
        Me.lnkAttributes.UseCompatibleTextRendering = True
        '
        'grpFileLocation
        '
        Me.grpFileLocation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpFileLocation.Controls.Add(Me.btnHardlink)
        Me.grpFileLocation.Controls.Add(Me.btnSymlink)
        Me.grpFileLocation.Controls.Add(Me.btnShortcut)
        Me.grpFileLocation.Controls.Add(Me.btnClose)
        Me.grpFileLocation.Controls.Add(Me.btnMove)
        Me.grpFileLocation.Controls.Add(Me.btnCopy)
        Me.grpFileLocation.Controls.Add(Me.btnDelete)
        Me.grpFileLocation.Controls.Add(Me.btnRename)
        Me.grpFileLocation.Controls.Add(Me.chkUseSystem)
        Me.grpFileLocation.Location = New System.Drawing.Point(2, 470)
        Me.grpFileLocation.Name = "grpFileLocation"
        Me.grpFileLocation.Size = New System.Drawing.Size(411, 77)
        Me.grpFileLocation.TabIndex = 4
        Me.grpFileLocation.TabStop = False
        Me.grpFileLocation.Text = "File location:"
        '
        'btnHardlink
        '
        Me.btnHardlink.Image = Global.My.Resources.Resources.mouse_right_click_8x
        Me.btnHardlink.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.btnHardlink.Location = New System.Drawing.Point(225, 48)
        Me.btnHardlink.Name = "btnHardlink"
        Me.btnHardlink.Size = New System.Drawing.Size(99, 23)
        Me.btnHardlink.TabIndex = 7
        Me.btnHardlink.Text = "Create Hardlin&k..."
        Me.myToolTip.SetToolTip(Me.btnHardlink, "Allows creating a Hardlink to the current item. Right-Click to use a plain text i" &
        "nput instead of Windows Explorer's window")
        Me.btnHardlink.UseVisualStyleBackColor = True
        '
        'btnSymlink
        '
        Me.btnSymlink.Image = Global.My.Resources.Resources.mouse_right_click_8x
        Me.btnSymlink.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.btnSymlink.Location = New System.Drawing.Point(120, 48)
        Me.btnSymlink.Name = "btnSymlink"
        Me.btnSymlink.Size = New System.Drawing.Size(99, 23)
        Me.btnSymlink.TabIndex = 6
        Me.btnSymlink.Text = "Create Sym&link..."
        Me.myToolTip.SetToolTip(Me.btnSymlink, "Allows creating a symbolic link to the current item. Right-Click to use a plain t" &
        "ext input instead of Windows Explorer's window")
        Me.btnSymlink.UseVisualStyleBackColor = True
        '
        'btnShortcut
        '
        Me.btnShortcut.Image = Global.My.Resources.Resources.mouse_right_click_8x
        Me.btnShortcut.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.btnShortcut.Location = New System.Drawing.Point(6, 48)
        Me.btnShortcut.Name = "btnShortcut"
        Me.btnShortcut.Size = New System.Drawing.Size(108, 23)
        Me.btnShortcut.TabIndex = 5
        Me.btnShortcut.Text = "Create &Shortcut..."
        Me.myToolTip.SetToolTip(Me.btnShortcut, "Allows creating a shortcut to the current item. Right-Click to use a plain text i" &
        "nput instead of Windows Explorer's window")
        Me.btnShortcut.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.btnClose.Location = New System.Drawing.Point(330, 48)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 8
        Me.btnClose.Text = "Close"
        Me.myToolTip.SetToolTip(Me.btnClose, "Exits PropertiesDotNet")
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnMove
        '
        Me.btnMove.Image = Global.My.Resources.Resources.mouse_right_click_8x
        Me.btnMove.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.btnMove.Location = New System.Drawing.Point(87, 19)
        Me.btnMove.Name = "btnMove"
        Me.btnMove.Size = New System.Drawing.Size(75, 23)
        Me.btnMove.TabIndex = 1
        Me.btnMove.Text = "&Move To..."
        Me.myToolTip.SetToolTip(Me.btnMove, "Allows moving the current item to an absolute path. Right-Click to use a plain te" &
        "xt input instead of Windows Explorer's window")
        Me.btnMove.UseVisualStyleBackColor = True
        '
        'btnCopy
        '
        Me.btnCopy.Image = Global.My.Resources.Resources.mouse_right_click_8x
        Me.btnCopy.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.btnCopy.Location = New System.Drawing.Point(168, 19)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(75, 23)
        Me.btnCopy.TabIndex = 2
        Me.btnCopy.Text = "&Copy To..."
        Me.myToolTip.SetToolTip(Me.btnCopy, "Allows copying the currrent item. Right-Click to use a plain text input instead o" &
        "f Windows Explorer's window")
        Me.btnCopy.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.btnDelete.Location = New System.Drawing.Point(249, 19)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "&Delete"
        Me.myToolTip.SetToolTip(Me.btnDelete, "Allows deleting the current item. If Use Windows Explorer is checked, can send to" &
        " recycle bin")
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnRename
        '
        Me.btnRename.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.btnRename.Location = New System.Drawing.Point(6, 19)
        Me.btnRename.Name = "btnRename"
        Me.btnRename.Size = New System.Drawing.Size(75, 23)
        Me.btnRename.TabIndex = 0
        Me.btnRename.Text = "&Rename..."
        Me.myToolTip.SetToolTip(Me.btnRename, "Allows renaming the current item. Works relative to containing folder, can use <R" &
        "elativeFolderPath>\<FileName>")
        Me.btnRename.UseVisualStyleBackColor = True
        '
        'chkUseSystem
        '
        Me.chkUseSystem.AutoSize = True
        Me.chkUseSystem.Checked = True
        Me.chkUseSystem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkUseSystem.Location = New System.Drawing.Point(330, 23)
        Me.chkUseSystem.Name = "chkUseSystem"
        Me.chkUseSystem.Size = New System.Drawing.Size(133, 17)
        Me.chkUseSystem.TabIndex = 4
        Me.chkUseSystem.Text = "Use Windows E&xplorer"
        Me.myToolTip.SetToolTip(Me.chkUseSystem, "If checked, uses the Windows Shell methods to Move/Copy/Delete files. If unchecke" &
        "d, uses .Net's file management methods instead. Copying and Deleting folders & f" &
        "iles using .Net uses a custom process.")
        Me.chkUseSystem.UseVisualStyleBackColor = True
        '
        'bwCalcSize
        '
        Me.bwCalcSize.WorkerReportsProgress = True
        Me.bwCalcSize.WorkerSupportsCancellation = True
        '
        'timerDelayedBrowse
        '
        Me.timerDelayedBrowse.Interval = 1
        '
        'lblVersion
        '
        Me.lblVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblVersion.AutoSize = True
        Me.lblVersion.BackColor = System.Drawing.Color.Transparent
        Me.lblVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.Location = New System.Drawing.Point(382, 540)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(21, 9)
        Me.lblVersion.TabIndex = 5
        Me.lblVersion.Text = "1.0.0"
        '
        'ofdBrowse
        '
        Me.ofdBrowse.AddExtension = False
        Me.ofdBrowse.CheckFileExists = False
        Me.ofdBrowse.DereferenceLinks = False
        Me.ofdBrowse.FileName = "Don't select a file to select folder"
        Me.ofdBrowse.Filter = "All Files|*.*"
        Me.ofdBrowse.Title = "Select a file or folder to view properties for:"
        '
        'btnSettings
        '
        Me.btnSettings.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSettings.Image = Global.My.Resources.Resources.settingsx16
        Me.btnSettings.Location = New System.Drawing.Point(384, 2)
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Size = New System.Drawing.Size(23, 25)
        Me.btnSettings.TabIndex = 1
        Me.myToolTip.SetToolTip(Me.btnSettings, "Open Settings Window")
        Me.btnSettings.UseVisualStyleBackColor = True
        '
        'PropertiesDotNet
        '
        Me.AcceptButton = Me.btnWindowsProperties
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(416, 549)
        Me.Controls.Add(Me.btnSettings)
        Me.Controls.Add(Me.btnRelaunchAsAdmin)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.grpFileLocation)
        Me.Controls.Add(Me.grpAttributes)
        Me.Controls.Add(Me.grpProperties)
        Me.Icon = Global.My.Resources.Resources.document_properties
        Me.Name = "PropertiesDotNet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Properties: "
        Me.grpProperties.ResumeLayout(False)
        Me.grpProperties.PerformLayout()
        CType(Me.imgFile, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpAttributes.ResumeLayout(False)
        Me.grpAttributes.PerformLayout()
        Me.grpFileLocation.ResumeLayout(False)
        Me.grpFileLocation.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents btnHandles As System.Windows.Forms.Button
    Private WithEvents btnRelaunchAsAdmin As System.Windows.Forms.Button
    Private myToolTip As System.Windows.Forms.ToolTip
    Private WithEvents btnADS As System.Windows.Forms.Button
    Private lblDriveTotalUsedSpaceLbl As System.Windows.Forms.Label
    Private lblDriveTotalUsedSpace As System.Windows.Forms.Label
    Private sfdSave As System.Windows.Forms.SaveFileDialog
    Private ofdBrowse As System.Windows.Forms.OpenFileDialog
    Private lblVersion As System.Windows.Forms.Label
    Private WithEvents btnShortcut As System.Windows.Forms.Button
    Private WithEvents btnSymlink As System.Windows.Forms.Button
    Private WithEvents btnHardlink As System.Windows.Forms.Button
    Private lblDriveTotalFreeSpace As System.Windows.Forms.Label
    Private lblDriveIsReadyLbl As System.Windows.Forms.Label
    Private lblDriveTypeLbl As System.Windows.Forms.Label
    Private lblDriveVolumeLabelLbl As System.Windows.Forms.Label
    Private lblDriveFormatLbl As System.Windows.Forms.Label
    Private lblDriveTotalSizeLbl As System.Windows.Forms.Label
    Private lblDriveTotalFreeSpaceLbl As System.Windows.Forms.Label
    Private lblDriveAvailableFreeSpaceLbl As System.Windows.Forms.Label
    Private lblDriveIsReady As System.Windows.Forms.Label
    Private lblDriveType As System.Windows.Forms.Label
    Private lblDriveVolumeLabel As System.Windows.Forms.Label
    Private lblDriveFormat As System.Windows.Forms.Label
    Private lblDriveTotalSize As System.Windows.Forms.Label
    Private lblDriveAvailableFreeSpace As System.Windows.Forms.Label
    Private WithEvents btnDriveVolumeLabel As System.Windows.Forms.Button
    Private lblDriveAvailableFreeSpaceInfo As System.Windows.Forms.Label
    Private WithEvents btnTakeOwn As System.Windows.Forms.Button
    Private WithEvents timerDelayedBrowse As System.Windows.Forms.Timer
    Private chkUseSystem As System.Windows.Forms.CheckBox
    Private WithEvents btnWindowsProperties As System.Windows.Forms.Button
    Private grpProperties As System.Windows.Forms.GroupBox
    Private grpAttributes As System.Windows.Forms.GroupBox
    Private grpFileLocation As System.Windows.Forms.GroupBox
    Private WithEvents cbxSize As System.Windows.Forms.ComboBox
    Private WithEvents bwCalcSize As System.ComponentModel.BackgroundWorker
    Private WithEvents btnLaunchAdmin As System.Windows.Forms.Button
    Private WithEvents btnStartAssocProgAdmin As System.Windows.Forms.Button
    Private WithEvents btnStartAssocProg As System.Windows.Forms.Button
    Private WithEvents btnCopyOpenWith As System.Windows.Forms.Button
    Private WithEvents btnLaunch As System.Windows.Forms.Button
    Private WithEvents btnOpenDir As System.Windows.Forms.Button
    Friend WithEvents imgFile As System.Windows.Forms.PictureBox
    Private lblOpenWithLbl As System.Windows.Forms.Label
    Private WithEvents btnOpenWith As System.Windows.Forms.Button
    Private lblOpenWith As System.Windows.Forms.Label
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents btnHashes As System.Windows.Forms.Button
    Private WithEvents btnCopyExtension As System.Windows.Forms.Button
    Private WithEvents btnCopyName As System.Windows.Forms.Button
    Private WithEvents btnCopyDirectory As System.Windows.Forms.Button
    Private WithEvents btnCopyFullPath As System.Windows.Forms.Button
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
    Private WithEvents lblLastWriteTime As System.Windows.Forms.Label
    Private WithEvents chkUTC As System.Windows.Forms.CheckBox
    Private lblName As System.Windows.Forms.Label
    Private lblExtension As System.Windows.Forms.Label
    Friend lblDirectory As System.Windows.Forms.Label
    Friend lblFullPath As System.Windows.Forms.Label
    Private lblCreationTimeLbl As System.Windows.Forms.Label
    Private WithEvents lblCreationTime As System.Windows.Forms.Label
    Private lblLastAccessTimeLbl As System.Windows.Forms.Label
    Private WithEvents lblLastAccessTime As System.Windows.Forms.Label
    Private lblLastWriteTimeLbl As System.Windows.Forms.Label
    Private lblExtensionLbl As System.Windows.Forms.Label
    Private lblDirectoryLbl As System.Windows.Forms.Label
    Private lblFullPathLbl As System.Windows.Forms.Label
    Private lblNameLbl As System.Windows.Forms.Label
    Private lblPathLbl As System.Windows.Forms.Label
    Private WithEvents chkSystem As System.Windows.Forms.CheckBox
    Private WithEvents chkHidden As System.Windows.Forms.CheckBox
    Private lblLocation As System.Windows.Forms.Label
    Friend WithEvents btnSettings As System.Windows.Forms.Button
End Class
