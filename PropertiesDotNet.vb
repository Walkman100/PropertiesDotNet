Public Class PropertiesDotNet
    Dim byteSize As ULong = 0
    Dim compressedSizeOrError As String = " "
    Dim driveSizes(3) As ULong
    
    Sub PropertiesDotNet_Load() Handles Me.Load
        For Each s As String In My.Application.CommandLineArgs
            If lblLocation.Text = "Checking..." Then
                lblLocation.Text = s
            Else
                Process.Start(Path.Combine(Application.StartupPath, Process.GetCurrentProcess.ProcessName & ".exe"), """" & s & """")
            End If
        Next
        If lblLocation.Text.EndsWith("""") Then
            lblLocation.Text = lblLocation.Text.Remove(lblLocation.Text.Length - 1) & "\"
        End If
        If WalkmanLib.IsAdmin() Then btnRelaunchAsAdmin.Visible = False
        timerDelayedBrowse.Start
    End Sub
    
    Sub timerDelayedBrowse_Tick() Handles timerDelayedBrowse.Tick
        timerDelayedBrowse.Stop
        lblVersion.Text = My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build
        If lblLocation.Text = "Checking..." Then
            If ofdBrowse.ShowDialog() = DialogResult.OK Then
                If ofdBrowse.FileName.EndsWith("Don't select a file to select folder") Then
                    lblLocation.Text = Path.GetDirectoryName(ofdBrowse.FileName)
                Else
                    lblLocation.Text = ofdBrowse.FileName
                End If
            Else
                Application.Exit
                End ' make sure nothing else can be processed
            End If
        End If
        If Not Exists(lblLocation.Text) And Not Directory.Exists(lblLocation.Text) Then
            Try
                If Not New DriveInfo(lblLocation.Text).Name = New FileInfo(lblLocation.Text).FullName Then
                    Throw New Exception
                End If
            Catch
                MsgBox("File, directory or drive """ & lblLocation.Text & """ not found!", MsgBoxStyle.Critical)
                Application.Exit
                End
            End Try
        End If
        CheckData(True, True)
    End Sub
    
    ' ======================= Dragging-and-dropping =======================
    
    Sub PropertiesDotNet_DragEnter(sender As Object, e As DragEventArgs) Handles Me.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.All
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub
    
    Sub PropertiesDotNet_DragDrop(sender As Object, e As DragEventArgs) Handles Me.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim newFilePath As String = e.Data.GetData(DataFormats.FileDrop)(0)
            
            If Not Exists(newFilePath) And Not Directory.Exists(newFilePath) Then
                Try
                    If Not New DriveInfo(newFilePath).Name = New FileInfo(newFilePath).FullName Then
                        Throw New Exception
                    End If
                Catch
                    MsgBox("File, directory or drive """ & newFilePath & """ not found!", MsgBoxStyle.Critical)
                    Exit Sub
                End Try
            End If
            
            lblLocation.Text = newFilePath
            imgFile.Image = Resources.loading4
            ShowImageBox
            CheckData(True)
        End If
    End Sub
    
    ' ======================= Loading data =======================
    
    Sub chkUTC_CheckedChanged() Handles chkUTC.CheckedChanged
        CheckData
    End Sub
    Sub CheckData(Optional recalculateFolderSize As Boolean = False, Optional firstStart As Boolean = False)
        ' init
        Dim FileProperties As FileInfo
        If lblLocation.Text.StartsWith("\\?\") AndAlso Not lblLocation.Text.StartsWith("\\?\Volume{") Then
            FileProperties = New FileInfo(lblLocation.Text.Substring(4))
        Else
            FileProperties = New FileInfo(lblLocation.Text)
        End If
        If WalkmanLib.IsAdmin() Then
            Me.Text = "[Admin] Properties: " & FileProperties.Name
        Else
            Me.Text = "Properties: " & FileProperties.Name
        End If
        
        ' ======================= Properties section =======================
        
        lblFullPath.Text = FileProperties.FullName
        If lblFullPath.Width>256 Then Me.Width = lblFullPath.Width+176 Else Me.Width = 432
        If firstStart Then Me.CenterToScreen()
        lblDirectory.Text = FileProperties.DirectoryName
        lblName.Text = FileProperties.Name
        lblExtension.Text = FileProperties.Extension
        If lblExtension.Text = "" Then lblExtension.Text = "No extension!"
        
        ' get compressed size (or error) so it can be applied later
        Try
            compressedSizeOrError = WalkmanLib.GetCompressedSize(lblFullPath.Text)
        Catch ex As Exception
            compressedSizeOrError = ex.Message
        End Try
        chkCompressed.Text = "Compr&essed"
        
        ' check drive properties and if on a drive show them
        Try
            Dim DriveProperties As New DriveInfo(lblLocation.Text)
            lblDriveIsReady.Text = DriveProperties.IsReady
            Select Case DriveProperties.DriveType
                Case DriveType.Unknown
                    lblDriveType.Text = "Unknown"
                Case DriveType.NoRootDirectory
                    lblDriveType.Text = "No Root Directory"
                Case DriveType.Removable
                    lblDriveType.Text = "Removable"
                Case DriveType.Fixed
                    lblDriveType.Text = "Fixed"
                Case DriveType.Network
                    lblDriveType.Text = "Network"
                Case DriveType.CDRom
                    lblDriveType.Text = "CD Rom"
                Case DriveType.Ram
                    lblDriveType.Text = "RAM"
                Case Else
                    lblDriveType.Text = DriveProperties.DriveType
            End Select
            If DriveProperties.IsReady Then
                lblDriveVolumeLabel.Text = DriveProperties.VolumeLabel
                lblDriveFormat.Text = DriveProperties.DriveFormat
                
                ' driveSizes(*) is used to store values so size formatting can be applied
                lblDriveTotalSize.Text = DriveProperties.TotalSize
                driveSizes(0) = DriveProperties.TotalSize
                
                lblDriveTotalFreeSpace.Text = DriveProperties.TotalFreeSpace
                driveSizes(1) = DriveProperties.TotalFreeSpace
                
                lblDriveTotalUsedSpace.Text = driveSizes(0) - driveSizes(1)
                
                lblDriveAvailableFreeSpace.Text = DriveProperties.AvailableFreeSpace
                driveSizes(2) = DriveProperties.AvailableFreeSpace
            Else
                lblDriveVolumeLabel.Text = "Not Ready"
                lblDriveFormat.Text = "Not Ready"
                lblDriveTotalSize.Text = "Not Ready"
                lblDriveTotalFreeSpace.Text = "Not Ready"
                lblDriveAvailableFreeSpace.Text = "Not Ready"
            End If
            If DriveProperties.Name = FileProperties.FullName Then
                Me.Height = 714
            Else
                Me.Height = 586
            End If
        Catch
            Me.Height = 586
        End Try
        
        If Exists(lblFullPath.Text) Then
            byteSize = FileProperties.Length
            lblSize.Text = byteSize ' clear any folder errors
            AutoDetectSize
            ApplySizeFormatting
            
            Dim fileSizeMax = 200000000 '200 MB
            If byteSize < fileSizeMax Then
                imgFile.ImageLocation = FileProperties.FullName
            Else
                imgFile_LoadCompleted(Nothing, New System.ComponentModel.AsyncCompletedEventArgs(New FileLoadException("File too big", lblFullPath.Text), True, Nothing))
            End If
            
            lblOpenWith.Text = WalkmanLib.GetOpenWith(lblFullPath.Text)
            If lblOpenWith.Text = "Filetype not associated!" Then
                btnStartAssocProg.Enabled = False
                btnStartAssocProgAdmin.Enabled = False
            Else
                btnStartAssocProg.Enabled = True
                btnStartAssocProgAdmin.Enabled = True
            End If
            
            btnLaunchAdmin.Enabled = True
            lblExtensionLbl.Enabled = True
            lblExtension.Enabled = True
            btnStartAssocProg.Visible = True
            btnStartAssocProgAdmin.Visible = True
            
            chkTemporary.Enabled = True
            chkTemporary.Text = "&Temporary"
            chkTemporary.Checked = GetAttributes(lblFullPath.Text).HasFlag(FileAttributes.Temporary)
            
            lblOpenWithLbl.Text = "Opens with:"
            btnHashes.Image = Resources.hashx16
            btnHashes.Text = "Compute &Hashes"
            
            If lblExtension.Text.ToLower() = ".lnk" Then
                btnShortcut.Text = "&Shortcut Properties"
                btnShortcut.Image = Nothing
            Else
                btnShortcut.Text = "Create &Shortcut..."
                btnShortcut.Image = Resources.mouse_right_click_8x
            End If
        ElseIf Directory.Exists(lblFullPath.Text)
            If bwCalcSize.IsBusy = False Then
                If recalculateFolderSize = True Then
                    bwCalcSize.RunWorkerAsync()
                Else
                    ApplySizeFormatting
                End If
            End If
            imgFile.ImageLocation = WalkmanLib.GetFolderIconPath(lblFullPath.Text)
            
            btnLaunchAdmin.Enabled = False
            lblExtensionLbl.Enabled = False
            lblExtension.Enabled = False
            btnStartAssocProg.Visible = False
            btnStartAssocProgAdmin.Visible = False
            
            If My.Computer.Info.OSFullName.Contains("Windows 10") Then
                chkTemporary.Enabled = True
                chkTemporary.Text = "Case Sensi&tive Contents"
                Try
                    chkTemporary.Checked = QueryCaseSensitiveFlag(lblFullPath.Text)
                Catch ex As Exception
                    chkTemporary.Enabled = False
                    chkTemporary.Text = "Case Sensi&tive Contents (" & ex.Message & ")"
                End Try
            Else
                chkTemporary.Enabled = False
                chkTemporary.Text = "&Temporary"
            End If
            
            lblOpenWithLbl.Text = "Number of files:"
            btnHashes.Image = Resources.Shell32__326_
            btnHashes.Text = "DirectoryIma&ge..."
            btnShortcut.Text = "Create &Shortcut..."
            btnShortcut.Image = Resources.mouse_right_click_8x
        End If
        
        If chkUTC.Checked Then
            lblCreationTime.Text = GetCreationTimeUtc(lblFullPath.Text)
            lblLastAccessTime.Text = GetLastAccessTimeUtc(lblFullPath.Text)
            lblLastWriteTime.Text = GetLastWriteTimeUtc(lblFullPath.Text)
        Else
            lblCreationTime.Text = GetCreationTime(lblFullPath.Text)
            lblLastAccessTime.Text = GetLastAccessTime(lblFullPath.Text)
            lblLastWriteTime.Text = GetLastWriteTime(lblFullPath.Text)
        End If
        
        ' ======================= Attributes section =======================
        '  (except some checkbox properties are set above depending if on folder or file)
        
        chkReadOnly.Checked = GetAttributes(lblFullPath.Text).HasFlag(FileAttributes.ReadOnly)
        chkHidden.Checked = GetAttributes(lblFullPath.Text).HasFlag(FileAttributes.Hidden)
        chkSystem.Checked = GetAttributes(lblFullPath.Text).HasFlag(FileAttributes.System)
        chkArchive.Checked = GetAttributes(lblFullPath.Text).HasFlag(FileAttributes.Archive)
        chkNotIndexed.Checked = GetAttributes(lblFullPath.Text).HasFlag(FileAttributes.NotContentIndexed)
        chkCompressed.Checked = GetAttributes(lblFullPath.Text).HasFlag(FileAttributes.Compressed)
        chkEncrypted.Checked = GetAttributes(lblFullPath.Text).HasFlag(FileAttributes.Encrypted)
        chkOffline.Checked = GetAttributes(lblFullPath.Text).HasFlag(FileAttributes.Offline)
        ' chkTemporary moved to If Exists section above as it is the case sensitive checkbox for directories
        chkNoScrub.Checked = GetAttributes(lblFullPath.Text).HasFlag(FileAttributes.NoScrubData)
        chkIntegrity.Checked = GetAttributes(lblFullPath.Text).HasFlag(FileAttributes.IntegrityStream)
        chkReparse.Checked = GetAttributes(lblFullPath.Text).HasFlag(FileAttributes.ReparsePoint)
        chkSparse.Checked = GetAttributes(lblFullPath.Text).HasFlag(FileAttributes.SparseFile)
        
        If chkReparse.Checked Then
            Try
                chkReparse.Text = "Is Reparse Point (Target: " & WalkmanLib.GetSymlinkTarget(lblFullPath.Text) & ")"
            Catch ex As Exception
                chkReparse.Text = "Is Reparse Point (GetTargetError: " & ex.Message & ")"
            End Try
        Else
            chkReparse.Text = "Is Reparse Point"
        End If
        
        Try
            Dim tmpADSCount As Integer = Trinet.Core.IO.Ntfs.ListAlternateDataStreams(lblFullPath.Text).Count
            If File.Exists(lblFullPath.Text) Then tmpADSCount += 1
            btnADS.Text = "Data Streams: " & tmpADSCount.ToString()
        Catch
            btnADS.Text = "Data Streams: " & "Error"
        End Try
    End Sub
    
    ' ======================= imgFile management =======================
    
    Sub imgFile_LoadCompleted(sender As Object, e As System.ComponentModel.AsyncCompletedEventArgs) Handles imgFile.LoadCompleted
        If IsNothing(e.Error) Then
            ShowImageBox()
        Else
            If Exists(lblFullPath.Text) Then
                Try
                    imgFile.Image = Icon.ExtractAssociatedIcon(lblFullPath.Text).ToBitmap
                    ShowImageBox()
                Catch
                    HideImageBox()
                End Try
            ElseIf Directory.Exists(lblFullPath.Text) Then
                Try
                    Dim resourceFile = WalkmanLib.GetFolderIconPath(lblFullPath.Text)
                    resourceFile = Environment.ExpandEnvironmentVariables(resourceFile)
                    If resourceFile.Contains(",") Then
                        Dim resourceIndex = resourceFile.Substring(resourceFile.LastIndexOf(",") + 1)
                        resourceFile = resourceFile.Remove(resourceFile.LastIndexOf(","))
                        imgFile.Image = WalkmanLib.ExtractIconByIndex(resourceFile, resourceIndex, imgFile.Width).ToBitmap()
                    Else
                        imgFile.Image = Icon.ExtractAssociatedIcon(resourceFile).ToBitmap()
                    End If
                    ShowImageBox()
                Catch ex As Exception
                    HideImageBox()
                End Try
            End If
        End If
    End Sub
    
    Sub ShowImageBox
        imgFile.Visible = True
        lblOpenWithLbl.Location = New Point(48, lblOpenWithLbl.Location.Y)
        lblOpenWith.Location = New Point(lblOpenWithLbl.Width +54, lblOpenWith.Location.Y)
        chkUTC.Location = New Point(48, chkUTC.Location.Y)
    End Sub
    
    Sub HideImageBox
        imgFile.Visible = False
        lblOpenWithLbl.Location = New Point(6, lblOpenWithLbl.Location.Y)
        lblOpenWith.Location = New Point(101, lblOpenWith.Location.Y)
        chkUTC.Location = New Point(10, chkUTC.Location.Y)
    End Sub
    
    Sub imgFile_Click() Handles imgFile.Click
        ImageViewer.Close()
        ImageViewer.fileImage.Image = Nothing
        ImageViewer.Text = lblName.Text
        ImageViewer.Show(Me)
        ImageViewer.fileImage.Image = imgFile.Image
    End Sub
    
    ' ======================= Copying =======================
    
    Sub btnCopyFullPath_Click() Handles btnCopyFullPath.Click
        WalkmanLib.SafeSetText(lblFullPath.Text)
    End Sub
    
    Sub btnCopyDirectory_Click() Handles btnCopyDirectory.Click
        WalkmanLib.SafeSetText(lblDirectory.Text)
    End Sub
    
    Sub btnCopyName_Click() Handles btnCopyName.Click
        WalkmanLib.SafeSetText(lblName.Text)
    End Sub
    
    Sub btnCopyExtension_Click() Handles btnCopyExtension.Click
        WalkmanLib.SafeSetText(lblExtension.Text)
    End Sub
    
    Sub btnCopyOpenWith_Click() Handles btnCopyOpenWith.Click
        WalkmanLib.SafeSetText(lblOpenWith.Text)
    End Sub
    
    ' ======================= Properties section buttons =======================
    
    Sub btnRelaunchAsAdmin_Click() Handles btnRelaunchAsAdmin.Click
        RestartAsAdmin()
    End Sub
    
    Sub btnOpenDir_Click() Handles btnOpenDir.Click
        Process.Start("explorer.exe", "/select, " & lblFullPath.Text)
    End Sub
    
    Sub btnLaunch_Click() Handles btnLaunch.Click
        Process.Start(lblFullPath.Text)
    End Sub
    
    Sub btnLaunchAdmin_Click() Handles btnLaunchAdmin.Click
        For Each envVar As String In {"ProgramFiles", "ProgramFiles(x86)", "ProgramW6432"}
            Dim PhotoViewerPath As String = path.Combine(Environment.GetEnvironmentVariable(envVar), "Windows Photo Viewer", "PhotoViewer.dll")
            If lblOpenWith.Text = PhotoViewerPath Then
                ' rundll32 "%ProgramFiles%\Windows Photo Viewer\PhotoViewer.dll", ImageView_Fullscreen FilePath
                WalkmanLib.RunAsAdmin("rundll32", """" & PhotoViewerPath & """, ImageView_Fullscreen " & lblFullPath.Text)
                Exit Sub
            End If
        Next
        
        If lblOpenWith.Text = "Filetype not associated!" Then
            WalkmanLib.RunAsAdmin(lblFullPath.Text)
        Else
            WalkmanLib.RunAsAdmin(lblOpenWith.Text, """" & lblFullPath.Text & """")
        End If
    End Sub
    
    Sub btnOpenWith_Click() Handles btnOpenWith.Click
        Dim isDangerousExtension As New Boolean
        Dim dangerousExtensions() As String = {".exe", ".bat", ".cmd", ".lnk", ".com", ".scr"}
        For i = 1 To dangerousExtensions.Length
            If lblExtension.Text = dangerousExtensions(i-1) Then
                isDangerousExtension = True
                Exit For
            End If
        Next
        If isDangerousExtension Then
            Dim MsgBoxText As String = "Are you sure you want to open the ""Open With"" dialog for """ & lblExtension.Text & """ files?"
            
            If Environment.OSVersion.Version.Major > 6 OrElse (Environment.OSVersion.Version.Major = 6 AndAlso Environment.OSVersion.Version.Minor >= 2) Then
                ' We're on Win8+
                MsgBoxText &= " This could potentially make your PC unusable if you click ""Ok"" while the ""Use this application for all " & lblExtension.Text & " files"" checkbox is checked!"
            Else
                ' We're on Win7 and below
                MsgBoxText &= " This could potentially make your PC unusable if you click ""Ok"" while the ""Always use the selected program"" checkbox is checked!"
            End If
            
            If MsgBox(MsgBoxText, MsgBoxStyle.Critical + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then _
              If MsgBox("You have been warned!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then _
                WalkmanLib.OpenWith(lblFullPath.Text)
        Else
            WalkmanLib.OpenWith(lblFullPath.Text)
        End If
    End Sub
    
    Sub btnOpenWith_MouseUp(sender As Object, e As MouseEventArgs) Handles btnOpenWith.MouseUp
        If e.Button = MouseButtons.Right Then
            Try
                Process.Start(Path.Combine(Application.StartupPath, "ProgramLauncher"), """" & lblFullPath.Text & """")
            Catch ex As Exception
                MsgBox("""" & Path.Combine(Application.StartupPath, "ProgramLauncher") &""" executable not found!", MsgBoxStyle.Exclamation)
            End Try
        End If
    End Sub
    
    ' cbxSize handling
    Sub AutoDetectSize()
        If byteSize > 1000^5 Then
            cbxSize.SelectedIndex = 9
        ElseIf byteSize > 1000^4 Then
            cbxSize.SelectedIndex = 7
        ElseIf byteSize > 1000^3 Then
            cbxSize.SelectedIndex = 5
        ElseIf byteSize > 1000^2 Then
            cbxSize.SelectedIndex = 3
        ElseIf byteSize > 1000 Then
            cbxSize.SelectedIndex = 1
        Else
            cbxSize.SelectedIndex = 0
        End If
    End Sub
    Sub ApplySizeFormatting() Handles cbxSize.SelectedIndexChanged
        If Not lblSize.Text.Contains("Error:") And lblSize.Text <> "Getting file list... (May take a while)" Then
            lblSize.Text = FormatNumber(byteSize)
        End If
        
        If IsNumeric(compressedSizeOrError) Then
            If compressedSizeOrError = 0 Then
                chkCompressed.Text = "Compr&essed"
            ElseIf compressedSizeOrError = byteSize Then
                chkCompressed.Text = "Compr&essed (Size on disk is either 0 or bigger than size)"
            Else
                chkCompressed.Text = "Compr&essed (Size on disk: "
                chkCompressed.Text &= FormatNumber(compressedSizeOrError) & ")"
            End If
        Else
            chkCompressed.Text = "Compr&essed (GetSizeError: " & compressedSizeOrError & ")"
        End If
        
        lblDriveTotalSize.Text = FormatNumber(driveSizes(0))
        lblDriveTotalUsedSpace.Text = FormatNumber(driveSizes(0) - driveSizes(1))
        lblDriveTotalFreeSpace.Text = FormatNumber(driveSizes(1))
        lblDriveAvailableFreeSpace.Text = FormatNumber(driveSizes(2))
    End Sub
    Function FormatNumber(number As Decimal) As String
        Dim postString As String = ""
        ' These Decimal.Truncate(...) ... below are horrible
        Select Case cbxSize.SelectedIndex
            Case 0 'bytes (8 bits)
                number = number
                postString = " bytes"
            Case 1 'kB  (Decimal - 1000)
                number = number / 1000
                postString = " kB"
            Case 2 'KiB (Binary - 1024)
                number = number / 1024
                number = Decimal.Truncate(number * 1000) / 1000
                postString = " KiB"
            Case 3 'MB (Decimal - 1000)
                number = number / 1000^2
                postString = " MB"
            Case 4 'MiB (Binary - 1024)
                number = number / 1024^2
                number = Decimal.Truncate(number * 1000^2) / 1000^2
                postString = " MiB"
            Case 5 'GB  (Decimal - 1000)
                number = number / 1000^3
                postString = " GB"
            Case 6 'GiB (Binary - 1024)
                number = number / 1024^3
                number = Decimal.Truncate(number * 1000^3) / 1000^3
                postString = " GiB"
            Case 7 'TB  (Decimal - 1000)
                number = number / 1000^4
                postString = " TB"
            Case 8 'TiB (Binary - 1024)
                number = number / 1024^4
                number = Decimal.Truncate(number * 1000^4) / 1000^4
                postString = " TiB"
            Case 9 'PB  (Decimal - 1000)
                number = number / 1000^5
                postString = " PB"
            Case 10 'PiB (Binary - 1024)
                number = number / 1024^5
                number = Decimal.Truncate(number * 1000^5) / 1000^5
                postString = " PiB"
            Case 11 '(Click to read more)
                postString = " bytes"
                Try
                    Process.Start("https://en.wikipedia.org/wiki/Byte#Unit_symbol")
                Catch ex As Exception
                    If MsgBox("Unable to launch URL, copy to clipboard instead?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then _
                      WalkmanLib.SafeSetText("https://en.wikipedia.org/wiki/Byte#Unit_symbol")
                End Try
                ' otherwise every call to FormatNumber opens the URL...
                cbxSize.SelectedIndex = 0
        End Select
        Return number.ToString("#,##0.### ### ### ### ### ### ###").Trim & postString
    End Function
    
    Sub btnStartAssocProg_Click() Handles btnStartAssocProg.Click
        Process.Start(lblOpenWith.Text)
    End Sub
    
    Sub btnStartAssocProgAdmin_Click() Handles btnStartAssocProgAdmin.Click
        WalkmanLib.RunAsAdmin(lblOpenWith.Text)
    End Sub
    
    ' ----------------------- date/time manipulation -----------------------
    Sub lblCreationTime_Click() Handles lblCreationTime.Click
        Operations.SetSelectDateDialogValue(lblFullPath.Text, chkUTC.Checked, Operations.TimeChangeEnum.Creation)
        Dim tmpSelectDateDialog As New SelectDateDialog With {
            .Text = "Choose a date to set Creation time to:"
        }
        tmpSelectDateDialog.dateTimePicker.Value = SelectDateDialog.dateTimePicker.Value
        tmpSelectDateDialog.SaveAction = Sub()
                                             Operations.SetTime(lblFullPath.Text, chkUTC.Checked, Operations.TimeChangeEnum.Creation, tmpSelectDateDialog.dateTimePicker.Value)
                                             CheckData
                                         End Sub
        tmpSelectDateDialog.Show(Me)
        tmpSelectDateDialog.Activate()
    End Sub
    Sub lblLastAccessTime_Click() Handles lblLastAccessTime.Click
        Operations.SetSelectDateDialogValue(lblFullPath.Text, chkUTC.Checked, Operations.TimeChangeEnum.LastAccess)
        Dim tmpSelectDateDialog As New SelectDateDialog With {
            .Text = "Choose a date to set Last access time to:"
        }
        tmpSelectDateDialog.dateTimePicker.Value = SelectDateDialog.dateTimePicker.Value
        tmpSelectDateDialog.SaveAction = Sub()
                                             Operations.SetTime(lblFullPath.Text, chkUTC.Checked, Operations.TimeChangeEnum.LastAccess, tmpSelectDateDialog.dateTimePicker.Value)
                                             CheckData()
                                         End Sub
        tmpSelectDateDialog.Show(Me)
        tmpSelectDateDialog.Activate()
    End Sub
    Sub lblLastWriteTime_Click() Handles lblLastWriteTime.Click
        Operations.SetSelectDateDialogValue(lblFullPath.Text, chkUTC.Checked, Operations.TimeChangeEnum.LastWrite)
        Dim tmpSelectDateDialog As New SelectDateDialog With {
            .Text = "Choose a date to set Last write time to:"
        }
        tmpSelectDateDialog.dateTimePicker.Value = SelectDateDialog.dateTimePicker.Value
        tmpSelectDateDialog.SaveAction = Sub()
                                             Operations.SetTime(lblFullPath.Text, chkUTC.Checked, Operations.TimeChangeEnum.LastWrite, tmpSelectDateDialog.dateTimePicker.Value)
                                             CheckData()
                                         End Sub
        tmpSelectDateDialog.Show(Me)
        tmpSelectDateDialog.Activate()
    End Sub
    
    Sub btnWindowsProperties_Click() Handles btnWindowsProperties.Click
        If Not WalkmanLib.ShowProperties(lblFullPath.Text) Then
            MsgBox("Could not open properties window!", MsgBoxStyle.Exclamation)
        End If
    End Sub
    
    Sub btnHashes_Click() Handles btnHashes.Click
        If btnHashes.Text = "Compute &Hashes" Then
            Hashes.Show(Me)
            Hashes.Text = "Generate Hashes: " & lblName.Text
            Hashes.Activate()
        ElseIf btnHashes.Text = "DirectoryIma&ge..."
            Try
                Process.Start(Path.Combine(Application.StartupPath, "DirectoryImage"), """" & lblFullPath.Text & """")
            Catch ex As Exception
                MsgBox("""" & Path.Combine(Application.StartupPath, "DirectoryImage") & """ executable not found!", MsgBoxStyle.Exclamation)
            End Try
        End If
    End Sub
    
    Sub btnDriveVolumeLabel_Click() Handles btnDriveVolumeLabel.Click
        Dim driveProperties As New DriveInfo(lblLocation.Text)
        Dim newName As String = driveProperties.VolumeLabel
        
        If Operations.GetInput(newName, "New volume name (Max 32 chars)", "Rename to:") <> DialogResult.OK Then
            Exit Sub
        End If
        
        Try
            driveProperties.VolumeLabel = newName
        Catch ex As UnauthorizedAccessException When Not WalkmanLib.IsAdmin()
            Select Case WalkmanLib.CustomMsgBox(ex.Message, Operations.cMBTitle, Operations.cMBbRelaunch, Operations.cMBbRunSysTool, Operations.cMBbCancel, MessageBoxIcon.Exclamation, ownerForm:=Me)
                Case Operations.cMBbRelaunch
                    RestartAsAdmin()
                Case Operations.cMBbRunSysTool
                    WalkmanLib.RunAsAdmin("label.exe", driveProperties.Name.Remove(2) & " " & newName)
                    Threading.Thread.Sleep(500)
            End Select
        Catch ex As Exception
            ErrorParser(ex)
        End Try
        CheckData
    End Sub
    
    ' ======================= Attributes =======================
    
    Sub lnkAttributes_LinkClicked() Handles lnkAttributes.LinkClicked
        Try
            Process.Start("https://docs.microsoft.com/en-us/dotnet/api/system.io.fileattributes?view=netframework-4.5#fields")
        Catch ex As Exception
            If MsgBox("Unable to launch URL, copy to clipboard instead?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then _
              WalkmanLib.SafeSetText("https://docs.microsoft.com/en-us/dotnet/api/system.io.fileattributes?view=netframework-4.5#fields")
        End Try
    End Sub
    
    Sub btnTakeOwn_Click() Handles btnTakeOwn.Click
        WalkmanLib.TakeOwnership(lblFullPath.Text)
    End Sub
    
    Sub btnADS_Click() Handles btnADS.Click
        AlternateDataStreamManager.Show(Me)
        AlternateDataStreamManager.Activate()
    End Sub
    
    Sub btnHandles_Click() Handles btnHandles.Click
        HandleManager.Show(Me)
        HandleManager.Activate()
    End Sub
    
    Sub chkReadOnly_Click() Handles chkReadOnly.Click
        ' checkbox.Checked value will be the value after changing, so it is exactly whether the attribute should be added
        Operations.SetAttribute(lblFullPath.Text, FileAttributes.ReadOnly, chkReadOnly.Checked)
        CheckData
    End Sub
    
    Sub chkHidden_Click() Handles chkHidden.Click
        Operations.SetAttribute(lblFullPath.Text, FileAttributes.Hidden, chkHidden.Checked)
        CheckData
    End Sub
    
    Sub chkSystem_Click() Handles chkSystem.Click
        Operations.SetAttribute(lblFullPath.Text, FileAttributes.System, chkSystem.Checked)
        CheckData
    End Sub
    
    Sub chkArchive_Click() Handles chkArchive.Click
        Operations.SetAttribute(lblFullPath.Text, FileAttributes.Archive, chkArchive.Checked)
        CheckData
    End Sub
    
    Sub chkNotIndexed_Click() Handles chkNotIndexed.Click
        Operations.SetAttribute(lblFullPath.Text, FileAttributes.NotContentIndexed, chkNotIndexed.Checked)
        CheckData
    End Sub
    
    Sub chkCompressed_Click() Handles chkCompressed.Click
        If Operations.SetAttribute(lblFullPath.Text, FileAttributes.Compressed, chkCompressed.Checked) Then
            Dim oneGB = 1000000000 '1 GB
            If chkCompressed.Checked Then
                If Not GetAttributes(lblFullPath.Text).HasFlag(FileAttributes.Compressed) Then
                    If byteSize < oneGB Or (byteSize >= oneGB AndAlso MsgBox("Are you sure you want to compress this large file (>1GB)? This will take a while and can't be interrupted",
                            MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Compressing Large File") = MsgBoxResult.Yes) Then
                        CompressReport.bwCompress.RunWorkerAsync({True, lblFullPath.Text})
                        CompressReport.ShowDialog()
                    End If
                End If
            Else
                If GetAttributes(lblFullPath.Text).HasFlag(FileAttributes.Compressed) Then
                    If byteSize < oneGB Or (byteSize >= oneGB AndAlso MsgBox("Are you sure you want to decompress this large file (>1GB)? This will take a while and can't be interrupted",
                            MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Decompressing Large File") = MsgBoxResult.Yes) Then
                        CompressReport.bwCompress.RunWorkerAsync({False, lblFullPath.Text})
                        CompressReport.ShowDialog()
                    End If
                End If
            End If
        End If
        CheckData
    End Sub
    
    Sub chkEncrypted_Click() Handles chkEncrypted.Click
        If Operations.SetAttribute(lblFullPath.Text, FileAttributes.Encrypted, chkEncrypted.Checked) Then
            If chkEncrypted.Checked Then
                If Not GetAttributes(lblFullPath.Text).HasFlag(FileAttributes.Encrypted) Then
                    Dim FileProperties As New FileInfo(lblFullPath.Text)
                    Try
                        FileProperties.Encrypt
                    Catch ex As IOException
                        MsgBox("Could not encrypt!" & vbNewLine & vbNewLine & ex.Message, MsgBoxStyle.Exclamation)
                    Catch ex As Exception
                        ErrorParser(ex)
                    End Try
                End If
            Else
                If GetAttributes(lblFullPath.Text).HasFlag(FileAttributes.Encrypted) Then
                    Dim FileProperties As New FileInfo(lblFullPath.Text)
                    Try
                        FileProperties.Decrypt
                    Catch ex As IOException
                        MsgBox("Could not decrypt!" & vbNewLine & vbNewLine & ex.Message, MsgBoxStyle.Exclamation)
                    Catch ex As Exception
                        ErrorParser(ex)
                    End Try
                End If
            End If
        End If
        CheckData
    End Sub
    
    Sub chkOffline_Click() Handles chkOffline.Click
        Operations.SetAttribute(lblFullPath.Text, FileAttributes.Offline, chkOffline.Checked)
        CheckData
    End Sub
    
    Sub chkTemporary_Click() Handles chkTemporary.Click
        Dim pathInfo = WalkmanLib.IsFileOrDirectory(lblFullPath.Text)
        If pathInfo.HasFlag(PathEnum.IsFile) Then
            Operations.SetAttribute(lblFullPath.Text, FileAttributes.Temporary, chkTemporary.Checked)
            
        ElseIf pathInfo.HasFlag(PathEnum.IsDirectory)
            ' working on a directory and setting case sensitive
            Dim output As String = SetCaseSensitiveFlag(lblFullPath.Text, chkTemporary.Checked)
            
            If output = "Error:  Access is denied." AndAlso Not WalkmanLib.IsAdmin() Then
                Select Case WalkmanLib.CustomMsgBox(output, Operations.cMBTitle, Operations.cMBbRelaunch, Operations.cMBbRunSysTool, Operations.cMBbCancel, MessageBoxIcon.Exclamation, ownerForm:=Me)
                    Case Operations.cMBbRelaunch
                        RestartAsAdmin()
                    Case Operations.cMBbRunSysTool
                        SetCaseSensitiveFlag(lblFullPath.Text, chkTemporary.Checked, True)
                End Select
            ElseIf output = "Error:  The directory is not empty." And chkTemporary.Checked = False Then
                MsgBox("Error! The directory contains items that cannot be kept in a case-insensitive directory. Either move or rename these items first.", MsgBoxStyle.Exclamation)
            Else
                MsgBox(output, MsgBoxStyle.Information)
            End If
        End If
        
        CheckData
    End Sub
    
    Sub chkNoScrub_Click() Handles chkNoScrub.Click
        Operations.SetAttribute(lblFullPath.Text, FileAttributes.NoScrubData, chkNoScrub.Checked)
        CheckData
    End Sub
    
    Sub chkIntegrity_Click() Handles chkIntegrity.Click
        Operations.SetAttribute(lblFullPath.Text, FileAttributes.IntegrityStream, chkIntegrity.Checked)
        CheckData
    End Sub
    
    Sub chkReparse_Click() Handles chkReparse.Click
        Operations.SetAttribute(lblFullPath.Text, FileAttributes.ReparsePoint, chkReparse.Checked)
        CheckData
    End Sub
    
    Sub chkSparse_Click() Handles chkSparse.Click
        Operations.SetAttribute(lblFullPath.Text, FileAttributes.SparseFile, chkSparse.Checked)
        CheckData
    End Sub
    
    ' ======================= File Location =======================
    
    ' SaveFileDialog buttons (as opposed to InputDialogs)
    Sub btnMove_Click() Handles btnMove.Click
        sfdSave.InitialDirectory = lblDirectory.Text
        sfdSave.FileName = lblName.Text
        sfdSave.Title = "Choose where to move """ & lblName.Text & """ to:"
        
        If sfdSave.ShowDialog() = DialogResult.OK Then
            Operations.Move(lblFullPath.Text, sfdSave.FileName, chkUseSystem.Checked)
            CheckData(True)
        End If
    End Sub
    Sub btnCopy_Click() Handles btnCopy.Click
        sfdSave.InitialDirectory = lblDirectory.Text
        sfdSave.FileName = lblName.Text
        sfdSave.Title = "Choose where to copy """ & lblName.Text & """ to:"
        
        If sfdSave.ShowDialog() = DialogResult.OK Then
            Operations.Copy(lblFullPath.Text, sfdSave.FileName, chkUseSystem.Checked)
            CheckData(True)
        End If
    End Sub
    Sub btnShortcut_Click() Handles btnShortcut.Click
        If lblExtension.Text.ToLower() = ".lnk" Then
            Dim shortcutInfo = WalkmanLib.GetShortcutInfo(lblFullPath.Text)
            
            Try: ShortcutPropertiesDialog.lblTargetSize.Text = shortcutInfo.TargetPath
            Catch: MsgBox("Error getting shortcut target!", MsgBoxStyle.Exclamation)
                ShortcutPropertiesDialog.lblTargetSize.Text = ""
            End Try
            
            Try: ShortcutPropertiesDialog.lblStartInSize.Text = shortcutInfo.WorkingDirectory
            Catch: MsgBox("Error getting shortcut working directory!", MsgBoxStyle.Exclamation)
                ShortcutPropertiesDialog.lblStartInSize.Text = ""
            End Try
            
            ShortcutPropertiesDialog.PerformResize()
            ShortcutPropertiesDialog.txtTarget.Text = ShortcutPropertiesDialog.lblTargetSize.Text
            ShortcutPropertiesDialog.txtStartIn.Text = ShortcutPropertiesDialog.lblStartInSize.Text
            
            Try: ShortcutPropertiesDialog.txtArguments.Text = shortcutInfo.Arguments
            Catch: MsgBox("Error getting shortcut arguments!", MsgBoxStyle.Exclamation)
                ShortcutPropertiesDialog.txtArguments.Text = ""
            End Try
            
            Try: ShortcutPropertiesDialog.txtIconPath.Text = shortcutInfo.IconLocation
            Catch: MsgBox("Error getting shortcut icon path!", MsgBoxStyle.Exclamation)
                ShortcutPropertiesDialog.txtIconPath.Text = ""
            End Try
            
            Try: ShortcutPropertiesDialog.txtShortcutKey.Text = shortcutInfo.Hotkey
            Catch: MsgBox("Error getting shortcut hotkey!", MsgBoxStyle.Exclamation)
                ShortcutPropertiesDialog.txtShortcutKey.Text = ""
            End Try
            
            Try: ShortcutPropertiesDialog.txtComment.Text = shortcutInfo.Description
            Catch: MsgBox("Error getting shortcut comment!", MsgBoxStyle.Exclamation)
                ShortcutPropertiesDialog.txtComment.Text = ""
            End Try
            
            Select Case shortcutInfo.WindowStyle
                Case 1 'Normal
                    ShortcutPropertiesDialog.cbxWindow.SelectedIndex = 0 'Normal Window
                Case 7 'Minimised
                    ShortcutPropertiesDialog.cbxWindow.SelectedIndex = 1 'Minimised
                Case 3 'Maximised
                    ShortcutPropertiesDialog.cbxWindow.SelectedIndex = 2 'Maximised
                Case Else
                    ShortcutPropertiesDialog.cbxWindow.SelectedIndex = 0 ' set it to default
            End Select
            
            Try
                ShortcutPropertiesDialog.chkRunAs.Checked = WalkmanLib.GetShortcutRunAsAdmin(lblFullPath.Text)
                ShortcutPropertiesDialog.chkRunAs.Enabled = True
            Catch
                ShortcutPropertiesDialog.chkRunAs.Enabled = False
            End Try
            
            ShortcutPropertiesDialog.Show(Me)
            ShortcutPropertiesDialog.Activate()
        Else
            sfdSave.InitialDirectory = lblDirectory.Text
            sfdSave.FileName = "Shortcut to " & lblName.Text & ".lnk"
            sfdSave.Title = "Choose where to create a Shortcut to """ & lblName.Text & """:"
            
            If sfdSave.ShowDialog() = DialogResult.OK Then
                Operations.CreateShortcut(lblFullPath.Text, sfdSave.FileName)
                CheckData(True)
            End If
        End If
    End Sub
    Sub btnSymlink_Click() Handles btnSymlink.Click
        sfdSave.InitialDirectory = lblDirectory.Text
        sfdSave.FileName = lblName.Text
        sfdSave.Title = "Choose where to create a Symlink to """ & lblName.Text & """:"
        
        If sfdSave.ShowDialog() = DialogResult.OK Then
            Operations.CreateSymlink(lblFullPath.Text, sfdSave.FileName)
            CheckData(True)
        End If
    End Sub
    Sub btnHardlink_Click() Handles btnHardlink.Click
        sfdSave.InitialDirectory = lblDirectory.Text
        sfdSave.FileName = lblName.Text
        sfdSave.Title = "Choose where to create a Hardlink to """ & lblName.Text & """:"
        
        If sfdSave.ShowDialog() = DialogResult.OK Then
            Operations.CreateHardlink(lblFullPath.Text, sfdSave.FileName)
            CheckData(True)
        End If
    End Sub
    
    ' InputDialog buttons (as opposed to SaveFileDialogs)
    Sub btnRename_Click() Handles btnRename.Click
        Dim newName As String = lblName.Text
        
        If Operations.GetInput(newName, "New name", "Rename """ & lblName.Text & """ to:") = DialogResult.OK Then
                             ' newName is ByRef
            Operations.Rename(lblFullPath.Text, newName)
            CheckData(True)
        End If
    End Sub
    Sub btnMove_MouseUp(sender As Object, e As MouseEventArgs) Handles btnMove.MouseUp
        If e.Button = MouseButtons.Right Then
            Dim newName As String = lblFullPath.Text
            
            If Operations.GetInput(newName, "Move file/folder", "Move """ & lblName.Text & """ to:") = DialogResult.OK Then
                Operations.Move(lblFullPath.Text, newName, chkUseSystem.Checked)
                CheckData(True)
            End If
        End If
    End Sub
    Sub btnCopy_MouseUp(sender As Object, e As MouseEventArgs) Handles btnCopy.MouseUp
        If e.Button = MouseButtons.Right Then
            Dim newName As String = lblFullPath.Text
            
            If Operations.GetInput(newName, "Copy file/folder", "Copy """ & lblName.Text & """ to:") = DialogResult.OK Then
                Operations.Copy(lblFullPath.Text, newName, chkUseSystem.Checked)
                CheckData(True)
            End If
        End If
    End Sub
    Sub btnShortcut_MouseUp(sender As Object, e As MouseEventArgs) Handles btnShortcut.MouseUp
        If e.Button = MouseButtons.Right AndAlso lblExtension.Text.ToLower() <> ".lnk" Then
            Dim newName As String = Path.Combine(lblDirectory.Text, "Shortcut to " & lblName.Text & ".lnk")
            
            If Operations.GetInput(newName, "Create Shortcut", "Create shortcut to """ & lblName.Text & """:") = DialogResult.OK Then
                Operations.CreateShortcut(lblFullPath.Text, newName)
                CheckData(True)
            End If
        End If
    End Sub
    Sub btnSymlink_MouseUp(sender As Object, e As MouseEventArgs) Handles btnSymlink.MouseUp
        If e.Button = MouseButtons.Right Then
            Dim newName As String = lblFullPath.Text
            
            If Operations.GetInput(newName, "Create Symlink", "Create symlink to """ & lblName.Text & """:") = DialogResult.OK Then
                Operations.CreateSymlink(lblFullPath.Text, newName)
                CheckData(True)
            End If
        End If
    End Sub
    Sub btnHardlink_MouseUp(sender As Object, e As MouseEventArgs) Handles btnHardlink.MouseUp
        If e.Button = MouseButtons.Right Then
            Dim newName As String = lblFullPath.Text
            
            If Operations.GetInput(newName, "Create Hardlink", "Create hardlink to """ & lblName.Text & """:") = DialogResult.OK Then
                Operations.CreateHardlink(lblFullPath.Text, newName)
                CheckData(True)
            End If
        End If
    End Sub
    
    Sub btnDelete_Click() Handles btnDelete.Click
        Dim recycleOption As FileIO.RecycleOption
        If chkUseSystem.Checked Then
            Select Case MsgBox("Send """ & lblName.Text & """ to Recycle Bin? (No to delete permanently)", MsgBoxStyle.Question + MsgBoxStyle.YesNoCancel)
                Case MsgBoxResult.Yes
                    recycleOption = FileIO.RecycleOption.SendToRecycleBin
                Case MsgBoxResult.No
                    recycleOption = FileIO.RecycleOption.DeletePermanently
                Case MsgBoxResult.Cancel
                    Exit Sub
            End Select
        ElseIf MsgBox("Are you sure you want to delete """ & lblName.Text & """?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then
            Exit Sub
        End If
        
        Operations.Delete(lblFullPath.Text, chkUseSystem.Checked, recycleOption)
        If WalkmanLib.IsFileOrDirectory(lblFullPath.Text) = PathEnum.NotFound Then
            Application.Exit()
            End
        End If
        CheckData(True)
    End Sub
    
    Sub btnClose_Click() Handles btnClose.Click
        Application.Exit
    End Sub
    
    ' ======================= Non-UI methods =======================
    
    Sub bwCalcSize_DoWork() Handles bwCalcSize.DoWork
        Try
            Dim DirectoryProperties As New DirectoryInfo(lblFullPath.Text)
            
            lblOpenWith.Text = "Checking..."
            lblSize.Text = "Getting file list... (May take a while)"
            Dim SubFiles = DirectoryProperties.GetFiles("*", SearchOption.AllDirectories)
            
            lblOpenWith.Text = SubFiles.Count.ToString("N0")
            byteSize = 0
            Dim countInterval As ULong = 0
            For Each SubFile As FileInfo In SubFiles
                byteSize += SubFile.Length
                countInterval += 1
                If countInterval Mod 100 = 0 Then
                    lblSize.Text = byteSize
                End If
            Next
            
            lblSize.Text = byteSize
            lblOpenWith.Text = SubFiles.Count.ToString("N0")
            AutoDetectSize
        Catch ex As Exception
            lblSize.Text = "Error: " & ex.Message
            lblOpenWith.Text = "?"
            ErrorParser(ex)
        End Try
        ApplySizeFormatting
    End Sub
    
    Sub RestartAsAdmin()
        WalkmanLib.RunAsAdmin(Path.Combine(Application.StartupPath, Process.GetCurrentProcess.ProcessName & ".exe"), """" & lblFullPath.Text & """")
        Application.Exit()
    End Sub
    
    Sub ErrorParser(ex As Exception)
        If TypeOf ex Is UnauthorizedAccessException AndAlso Not WalkmanLib.IsAdmin() Then
            If MsgBox(ex.Message & vbNewLine & vbNewLine & "Try launching PropertiesDotNet As Administrator?",
              MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Access denied!") = MsgBoxResult.Yes Then
                RestartAsAdmin()
            End If
        Else
            WalkmanLib.ErrorDialog(ex, messagePumpForm:=Me)
        End If
    End Sub
    
    Function QueryCaseSensitiveFlag(path As String) As Boolean
        ' check if the path ends with \, if it does it needs to be escaped so it doesn't escape the double-quotes
        If path.EndsWith(IO.Path.DirectorySeparatorChar) Then
            path &= IO.Path.DirectorySeparatorChar
        End If
        Dim fsUtilOutput As String = WalkmanLib.RunAndGetOutput("fsutil.exe", "file queryCaseSensitiveInfo """ & path & """")
        
        Select Case True
            Case fsUtilOutput.EndsWith("enabled.")
                Return True
            Case fsUtilOutput.EndsWith("disabled.")
                Return False
            Case Else
                Throw New Exception(fsUtilOutput)
        End Select
    End Function
    
    Function SetCaseSensitiveFlag(path As String, caseSensitive As Boolean, Optional runAsAdmin As Boolean = False) As String
        Dim caseSensitiveFlag As String = IIf(caseSensitive, "enable", "disable")
        If path.EndsWith(IO.Path.DirectorySeparatorChar) Then
            path &= IO.Path.DirectorySeparatorChar
        End If
        
        If runAsAdmin Then
            WalkmanLib.RunAsAdmin("fsutil.exe", "file setCaseSensitiveInfo """ & path & """ " & caseSensitiveFlag)
            Threading.Thread.Sleep(500)
            Return "See Admin output"
        Else
            Return WalkmanLib.RunAndGetOutput("fsutil.exe", "file setCaseSensitiveInfo """ & path & """ " & caseSensitiveFlag)
        End If
    End Function
End Class
