Public Class PropertiesDotNet
    Dim byteSize As ULong = 0
    Dim compressedSizeOrError As String = " "
    Dim driveSizes(3) As ULong
    
    Sub PropertiesDotNet_Load() Handles Me.Load
        For Each s As String In My.Application.CommandLineArgs
            If lblLocation.Text = "Checking..." Then
                lblLocation.Text = s
            Else
                Process.Start(Application.StartupPath & "\" & Process.GetCurrentProcess.ProcessName & ".exe", """" & s & """")
            End If
        Next
        If lblLocation.Text.EndsWith("""") Then
            lblLocation.Text = lblLocation.Text.Remove(lblLocation.Text.Length - 1) & "\"
        End If
        timerDelayedBrowse.Start
    End Sub
    
    Sub timerDelayedBrowse_Tick() Handles timerDelayedBrowse.Tick
        timerDelayedBrowse.Stop
        If lblLocation.Text = "Checking..." Then
            Dim OpenFileDialog As New OpenFileDialog()
            OpenFileDialog.Filter = "All Files|*.*"
            OpenFileDialog.Title = "Select a file to view properties for:"
            OpenFileDialog.DereferenceLinks = False
            If OpenFileDialog.ShowDialog() = DialogResult.OK Then
                lblLocation.Text = OpenFileDialog.FileName
            Else
                Dim SelectFolderDialog As New FolderBrowserDialog
                SelectFolderDialog.Description = "Select a folder to view properties for:"
                If SelectFolderDialog.ShowDialog = DialogResult.OK Then
                    lblLocation.Text = SelectFolderDialog.SelectedPath
                Else
                    Application.Exit
                End If
            End If
        End If
        If lblLocation.Text.StartsWith("\\?\") Then
            lblLocation.Text = lblLocation.Text.Substring(4)
        End If
        If Exists(lblLocation.Text) Or Directory.Exists(lblLocation.Text) Then
            CheckData(True)
        Else
            Try
                If New DriveInfo(lblLocation.Text).Name = New FileInfo(lblLocation.Text).FullName Then
                    CheckData(True)
                Else
                    Throw New Exception
                End If
            Catch
                MsgBox("File or directory """ & lblLocation.Text & """ not found!", MsgBoxStyle.Critical)
                Application.Exit
            End Try
        End If
    End Sub
    
    Sub PropertiesDotNet_DragEnter(sender As Object, e As DragEventArgs) Handles Me.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.All
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub
    Sub PropertiesDotNet_DragDrop(sender As Object, e As DragEventArgs) Handles Me.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            If Not Exists(e.Data.GetData(DataFormats.FileDrop)(0)) And Not Directory.Exists(e.Data.GetData(DataFormats.FileDrop)(0))
                MsgBox("File or directory """ & e.Data.GetData(DataFormats.FileDrop)(0) & """ not found!", MsgBoxStyle.Critical)
                Exit Sub
            End If
            
            lblLocation.Text = e.Data.GetData(DataFormats.FileDrop)(0)
            imgFile.Image = My.Resources.Resources.loading4
            ShowImageBox
            CheckData(True)
        End If
    End Sub
    
    Sub chkUTC_CheckedChanged() Handles chkUTC.CheckedChanged
        CheckData
    End Sub
    Sub CheckData(Optional recalculateFolderSize As Boolean = False) 
        'Properties:
        Dim FileProperties As New FileInfo(lblLocation.Text)
        ' Thanks to https://stackoverflow.com/a/22691609/2999220
        If WalkmanLib.IsAdmin() Then _
          Me.Text = "[Admin] Properties: " & FileProperties.Name Else _
          Me.Text = "Properties: " & FileProperties.Name
        lblFullPath.Text = FileProperties.FullName
        If lblFullPath.Width>256 Then Me.Width = lblFullPath.Width+176 Else Me.Width = 432
        lblDirectory.Text = FileProperties.DirectoryName
        lblName.Text = FileProperties.Name
        lblExtension.Text = FileProperties.Extension
        If lblExtension.Text = "" Then lblExtension.Text = "No extension!"
        
        Try
            compressedSizeOrError = WalkmanLib.GetCompressedSize(lblFullPath.Text)
        Catch ex As Exception
            compressedSizeOrError = ex.Message
        End Try
        chkCompressed.Text = "Compressed"
        
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
                lblDriveTotalSize.Text = DriveProperties.TotalSize
                driveSizes(0) = DriveProperties.TotalSize
                lblDriveTotalFreeSpace.Text = DriveProperties.TotalFreeSpace
                driveSizes(1) = DriveProperties.TotalFreeSpace
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
                Me.Height = 674
            Else
                Me.Height = 559
            End If
        Catch
            Me.Height = 559
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
            
            lblOpenWithLbl.Text = "Opens with:"
            btnHashes.Image = My.Resources.Resources.hashx16
            btnHashes.Text = "Compute Hashes"
        ElseIf Directory.Exists(lblFullPath.Text)
            If bwCalcSize.IsBusy = False Then
                If recalculateFolderSize = True Then
                    bwCalcSize.RunWorkerAsync()
                Else
                    ApplySizeFormatting
                End If
            End If
            imgFile.ImageLocation = GetFolderIconPath(lblFullPath.Text)
            
            btnLaunchAdmin.Enabled = False
            lblExtensionLbl.Enabled = False
            lblExtension.Enabled = False
            btnStartAssocProg.Visible = False
            btnStartAssocProgAdmin.Visible = False
            chkTemporary.Enabled = False
            
            lblOpenWithLbl.Text = "Number of files:"
            btnHashes.Image = My.Resources.Resources.Shell32__326_
            btnHashes.Text = "DirectoryImage..."
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
        
        'Attributes:
        Try
            chkReadOnly.Checked = GetAttributes(lblFullPath.Text).HasFlag(FileAttributes.ReadOnly)
            chkHidden.Checked = GetAttributes(lblFullPath.Text).HasFlag(FileAttributes.Hidden)
            chkCompressed.Checked = GetAttributes(lblFullPath.Text).HasFlag(FileAttributes.Compressed)
            chkEncrypted.Checked = GetAttributes(lblFullPath.Text).HasFlag(FileAttributes.Encrypted)
            chkSystem.Checked = GetAttributes(lblFullPath.Text).HasFlag(FileAttributes.System)
            chkArchive.Checked = GetAttributes(lblFullPath.Text).HasFlag(FileAttributes.Archive)
            chkTemporary.Checked = GetAttributes(lblFullPath.Text).HasFlag(FileAttributes.Temporary)
            chkIntegrity.Checked = GetAttributes(lblFullPath.Text).HasFlag(FileAttributes.IntegrityStream)
            chkNoScrub.Checked = GetAttributes(lblFullPath.Text).HasFlag(FileAttributes.NoScrubData)
            chkNotIndexed.Checked = GetAttributes(lblFullPath.Text).HasFlag(FileAttributes.NotContentIndexed)
            chkOffline.Checked = GetAttributes(lblFullPath.Text).HasFlag(FileAttributes.Offline)
            chkReparse.Checked = GetAttributes(lblFullPath.Text).HasFlag(FileAttributes.ReparsePoint)
            chkSparse.Checked = GetAttributes(lblFullPath.Text).HasFlag(FileAttributes.SparseFile)
        Catch
        End Try
    End Sub
    
    ''' <summary>Gets the path to the folder icon</summary>
    ''' <param name="folder">the folder path to get the icon path for</param>
    ''' <returns>the icon path</returns>
    Function GetFolderIconPath(folder As String) As String
        Dim gotIconOrIsAbsolute As Boolean = False
        Dim parsedIconPath As String = folder
        If folder.endswith(":\") Then
            If Exists(folder & "\Autorun.inf") Then
                For Each line In ReadLines(folder & "\Autorun.inf")
                    If line.StartsWith("Icon=", True, Nothing) Then
                        parsedIconPath = line.Substring(5)
                        gotIconOrIsAbsolute = True
                    End If
                Next
            End If
        Else
            If Exists(folder & "\desktop.ini") Then
                For Each line In ReadLines(folder & "\desktop.ini")
                    If line.StartsWith("IconResource=", True, Nothing) Then
                        parsedIconPath = line.Substring(13)
                        gotIconOrIsAbsolute = True
                    ElseIf line.StartsWith("IconFile=", True, Nothing) And gotIconOrIsAbsolute = False Then
                        parsedIconPath = line.Substring(9)
                        gotIconOrIsAbsolute = True
                    End If
                Next
            End If
        End If
        If gotIconOrIsAbsolute Then
            gotIconOrIsAbsolute = False
            If parsedIconPath.StartsWith("%") Then
                gotIconOrIsAbsolute = True
            Else
                For i = 1 To 26 ' The Chr() below will give all letters from A to Z
                    If parsedIconPath.StartsWith(Chr(i+64) & ":\") Then
                        gotIconOrIsAbsolute = True
                        Exit For
                    End If
                Next
                If gotIconOrIsAbsolute = False Then
                    For i = 1 To 26 ' The Chr() below will give all letters from a to z
                        If parsedIconPath.StartsWith(Chr(i+96) & ":\") Then
                            gotIconOrIsAbsolute = True
                            Exit For
                        End If
                    Next
                End If
            End If
            If parsedIconPath.EndsWith(",0") Then
                parsedIconPath = parsedIconPath.Remove(parsedIconPath.Length-2)
            End If
            If gotIconOrIsAbsolute Then
                Return parsedIconPath
            Else
                Return folder & "\" & parsedIconPath
            End If
        Else
            Return "no icon found"
        End If
    End Function
    Sub imgFile_LoadCompleted(sender As Object, e As System.ComponentModel.AsyncCompletedEventArgs) Handles imgFile.LoadCompleted
        If IsNothing(e.Error) Then
            ShowImageBox
        Else
            If Exists(lblFullPath.Text) Then
                Try
                    imgFile.Image = Icon.ExtractAssociatedIcon(lblFullPath.Text).ToBitmap
                    ShowImageBox
                Catch
                    HideImageBox
                End Try
            ElseIf Directory.Exists(lblFullPath.Text)
                Try
                    imgFile.Image = Icon.ExtractAssociatedIcon(GetFolderIconPath(lblFullPath.Text)).ToBitmap
                    ShowImageBox
                Catch
                    HideImageBox
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
        ImageViewer.Close
        ImageViewer.fileImage.Image = Nothing
        ImageViewer.Text = lblName.Text
        ImageViewer.Show
        ImageViewer.fileImage.Image = imgFile.Image
    End Sub
    
    Sub btnCopyFullPath_Click() Handles btnCopyFullPath.Click
        Try
            Clipboard.SetText(lblFullPath.Text, TextDataFormat.UnicodeText)
            MsgBox(lblFullPath.Text & vbNewLine & "Succesfully copied!", MsgBoxStyle.Information, "Succesfully copied!")
        Catch ex As Exception
            MsgBox("Copy failed!" & vbNewLine & "Error: """ & ex.ToString & """", MsgBoxStyle.Critical, "Copy failed!")
        End Try
    End Sub
    Sub btnCopyDirectory_Click() Handles btnCopyDirectory.Click
        Try
            Clipboard.SetText(lblDirectory.Text, TextDataFormat.UnicodeText)
            MsgBox(lblDirectory.Text & vbNewLine & "Succesfully copied!", MsgBoxStyle.Information, "Succesfully copied!")
        Catch ex As Exception
            MsgBox("Copy failed!" & vbNewLine & "Error: """ & ex.ToString & """", MsgBoxStyle.Critical, "Copy failed!")
        End Try
    End Sub
    Sub btnCopyName_Click() Handles btnCopyName.Click
        Try
            Clipboard.SetText(lblName.Text, TextDataFormat.UnicodeText)
            MsgBox(lblName.Text & vbNewLine & "Succesfully copied!", MsgBoxStyle.Information, "Succesfully copied!")
        Catch ex As Exception
            MsgBox("Copy failed!" & vbNewLine & "Error: """ & ex.ToString & """", MsgBoxStyle.Critical, "Copy failed!")
        End Try
    End Sub
    Sub btnCopyExtension_Click() Handles btnCopyExtension.Click
        Try
            Clipboard.SetText(lblExtension.Text, TextDataFormat.UnicodeText)
            MsgBox(lblExtension.Text & vbNewLine & "Succesfully copied!", MsgBoxStyle.Information, "Succesfully copied!")
        Catch ex As Exception
            MsgBox("Copy failed!" & vbNewLine & "Error: """ & ex.ToString & """", MsgBoxStyle.Critical, "Copy failed!")
        End Try
    End Sub
    Sub btnCopyOpenWith_Click() Handles btnCopyOpenWith.Click
        Try
            Clipboard.SetText(lblOpenWith.Text, TextDataFormat.UnicodeText)
            MsgBox(lblOpenWith.Text & vbNewLine & "Succesfully copied!", MsgBoxStyle.Information, "Succesfully copied!")
        Catch ex As Exception
            MsgBox("Copy failed!" & vbNewLine & "Error: """ & ex.ToString & """", MsgBoxStyle.Critical, "Copy failed!")
        End Try
    End Sub
    
    Sub btnOpenDir_Click() Handles btnOpenDir.Click
        Process.Start("explorer.exe", "/select, " & lblFullPath.Text)
    End Sub
    Sub btnLaunch_Click() Handles btnLaunch.Click
        Process.Start(lblFullPath.Text)
    End Sub
    Sub btnLaunchAdmin_Click() Handles btnLaunchAdmin.Click
        If lblOpenWith.Text = Environment.GetEnvironmentVariable("ProgramFiles") & "\Windows Photo Viewer\PhotoViewer.dll" Then
            ' rundll32 "%ProgramFiles%\Windows Photo Viewer\PhotoViewer.dll", ImageView_Fullscreen FilePath
            WalkmanLib.RunAsAdmin("rundll32", Environment.GetEnvironmentVariable("ProgramFiles") & "\Windows Photo Viewer\PhotoViewer.dll, " & _
              "ImageView_Fullscreen " & lblFullPath.Text)
            
        ElseIf lblOpenWith.Text = Environment.GetEnvironmentVariable("ProgramFiles(x86)") & "\Windows Photo Viewer\PhotoViewer.dll" Then
            WalkmanLib.RunAsAdmin("rundll32", Environment.GetEnvironmentVariable("ProgramFiles(x86)") & "\Windows Photo Viewer\PhotoViewer.dll, " & _
              "ImageView_Fullscreen " & lblFullPath.Text)
              
        ElseIf lblOpenWith.Text = Environment.GetEnvironmentVariable("ProgramW6432") & "\Windows Photo Viewer\PhotoViewer.dll" Then
            WalkmanLib.RunAsAdmin("rundll32", Environment.GetEnvironmentVariable("ProgramW6432") & "\Windows Photo Viewer\PhotoViewer.dll, " & _
              "ImageView_Fullscreen " & lblFullPath.Text)
              
        Else
            If lblOpenWith.Text = "Filetype not associated!" Then
                WalkmanLib.RunAsAdmin(lblFullPath.Text)
            Else
                WalkmanLib.RunAsAdmin(lblOpenWith.Text, lblFullPath.Text)
            End If
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
                Shell("rundll32 shell32.dll,OpenAs_RunDLL " & lblFullPath.Text, AppWinStyle.NormalFocus, True, 500)
        Else
            Shell("rundll32 shell32.dll,OpenAs_RunDLL " & lblFullPath.Text, AppWinStyle.NormalFocus, True, 500)
            'Process.Start("rundll32", "shell32.dll,OpenAs_RunDLL " & lblFullPath.Text)
        End If
    End Sub
    Sub btnOpenWith_MouseUp(sender As Object, e As MouseEventArgs) Handles btnOpenWith.MouseUp
        If e.Button = MouseButtons.Right Then
            Try
                Process.Start(Application.StartupPath & "\ProgramLauncher", """" & lblFullPath.Text & """")
            Catch ex As Exception
                MsgBox("""" & Application.StartupPath & "\ProgramLauncher"" executable not found!", MsgBoxStyle.Exclamation)
            End Try
        End If
    End Sub
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
                chkCompressed.Text = "Compressed"
            ElseIf compressedSizeOrError = byteSize Then
                chkCompressed.Text = "Compressed (Size on disk is either 0 or bigger than size)"
            Else
                chkCompressed.Text = "Compressed (Size on disk: "
                chkCompressed.Text &= FormatNumber(compressedSizeOrError) & ")"
            End If
        Else
            chkCompressed.Text = "Compressed (GetSizeError: " & compressedSizeOrError & ")"
        End If
        
        lblDriveTotalSize.Text = FormatNumber(driveSizes(0))
        lblDriveTotalFreeSpace.Text = FormatNumber(driveSizes(1))
        lblDriveAvailableFreeSpace.Text = FormatNumber(driveSizes(2))
    End Sub
    Function FormatNumber(number As Decimal) As String
        Dim postString As String = ""
        Select Case cbxSize.SelectedIndex
            Case 0 'bytes (8 bits)
                number = number
                postString = " bytes"
            Case 1 'kB  (Decimal - 1000)
                number = number / 1000
                postString = " kB"
            Case 2 'KiB (Binary - 1024)
                number = number / 1024
                postString = " KiB"
            Case 3 'MB (Decimal - 1000)
                number = number / 1000^2
                postString = " MB"
            Case 4 'MiB (Binary - 1024)
                number = number / 1024^2
                postString = " MiB"
            Case 5 'GB  (Decimal - 1000)
                number = number / 1000^3
                postString = " GB"
            Case 6 'GiB (Binary - 1024)
                number = number / 1024^3
                postString = " GiB"
            Case 7 'TB  (Decimal - 1000)
                number = number / 1000^4
                postString = " TB"
            Case 8 'TiB (Binary - 1024)
                number = number / 1024^4
                postString = " TiB"
            Case 9 'PB  (Decimal - 1000)
                number = number / 1000^5
                postString = " PB"
            Case 10 'PiB (Binary - 1024)
                number = number / 1024^5
                postString = " PiB"
            Case 11 '(Click to read more)
                postString = " bytes"
                Try
                    Process.Start("https://en.wikipedia.org/wiki/Byte#Unit_symbol")
                Catch ex As Exception
                    If MsgBox("Unable to launch URL, copy to clipboard instead?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then _
                      Clipboard.SetText("https://en.wikipedia.org/wiki/Byte#Unit_symbol")
                End Try
        End Select
        Return number.ToString("#,##0.### ### ### ### ### ### ###").Trim & postString
    End Function
    
    Sub btnStartAssocProg_Click() Handles btnStartAssocProg.Click
        Process.Start(lblOpenWith.Text)
    End Sub
    Sub btnStartAssocProgAdmin_Click() Handles btnStartAssocProgAdmin.Click
        WalkmanLib.RunAsAdmin(lblOpenWith.Text)
    End Sub
    
    Sub lblCreationTime_DoubleClick(sender As Object, e As EventArgs) Handles lblCreationTime.DoubleClick
        If chkUTC.Checked Then
            SelectDateDialog.dateTimePicker.Value = GetCreationTimeUtc(lblFullPath.Text)
            If SelectDateDialog.ShowDialog() = DialogResult.OK Then
                SetCreationTimeUtc(lblFullPath.Text, SelectDateDialog.dateTimePicker.Value)
            End If
        Else
            SelectDateDialog.dateTimePicker.Value = GetCreationTime(lblFullPath.Text)
            If SelectDateDialog.ShowDialog() = DialogResult.OK Then
                SetCreationTime(lblFullPath.Text, SelectDateDialog.dateTimePicker.Value)
            End If
        End If
        CheckData
    End Sub
    Sub lblLastAccessTime_DoubleClick(sender As Object, e As EventArgs) Handles lblLastAccessTime.DoubleClick
        If chkUTC.Checked Then
            SelectDateDialog.dateTimePicker.Value = GetLastAccessTimeUtc(lblFullPath.Text)
            If SelectDateDialog.ShowDialog() = DialogResult.OK Then
                SetLastAccessTimeUtc(lblFullPath.Text, SelectDateDialog.dateTimePicker.Value)
            End If
        Else
            SelectDateDialog.dateTimePicker.Value = GetLastAccessTime(lblFullPath.Text)
            If SelectDateDialog.ShowDialog() = DialogResult.OK Then
                SetLastAccessTime(lblFullPath.Text, SelectDateDialog.dateTimePicker.Value)
            End If
        End If
        CheckData
    End Sub
    Sub lblLastWriteTime_DoubleClick(sender As Object, e As EventArgs) Handles lblLastWriteTime.DoubleClick
        If chkUTC.Checked Then
            SelectDateDialog.dateTimePicker.Value = GetLastWriteTimeUtc(lblFullPath.Text)
            If SelectDateDialog.ShowDialog() = DialogResult.OK Then
                SetLastWriteTimeUtc(lblFullPath.Text, SelectDateDialog.dateTimePicker.Value)
            End If
        Else
            SelectDateDialog.dateTimePicker.Value = GetLastWriteTime(lblFullPath.Text)
            If SelectDateDialog.ShowDialog() = DialogResult.OK Then
                SetLastWriteTime(lblFullPath.Text, SelectDateDialog.dateTimePicker.Value)
            End If
        End If
        CheckData
    End Sub
    
    Sub btnWindowsProperties_Click() Handles btnWindowsProperties.Click
        If WalkmanLib.ShowProperties(lblFullPath.Text) = False Then
            MsgBox("Could not open properties window!", MsgBoxStyle.Exclamation)
        End If
    End Sub
    Sub btnHashes_Click() Handles btnHashes.Click
        If btnHashes.Text = "Compute Hashes" Then
            Hashes.Show
            Hashes.Text = "Generate Hashes: " & lblName.Text
            Hashes.Activate
        ElseIf btnHashes.Text = "DirectoryImage..."
            Try
                Process.Start(Application.StartupPath & "\DirectoryImage", """" & lblFullPath.Text & """")
            Catch ex As Exception
                MsgBox("""" & Application.StartupPath & "\DirectoryImage"" executable not found!", MsgBoxStyle.Exclamation)
            End Try
        End If
    End Sub
    Sub btnDriveVolumeLabel_Click() Handles btnDriveVolumeLabel.Click
        Dim DriveProperties As New DriveInfo(lblLocation.Text)
        Dim newName = InputBox("Rename to:", "New volume name", DriveProperties.VolumeLabel)
        If newName <> "" Then
            Try
                DriveProperties.VolumeLabel = newName
            Catch ex As exception
                ErrorParser(ex)
            End Try
        End If
        CheckData
    End Sub
    Sub btnTakeOwn_Click() Handles btnTakeOwn.Click
        If Exists(lblFullPath.Text) Then
            WalkmanLib.RunAsAdmin("cmd.exe", "/c takeown /f " & lblFullPath.Text & " && icacls " & lblFullPath.Text & " /grant administrators:F && pause")
        ElseIf Directory.Exists(lblFullPath.Text)
            WalkmanLib.RunAsAdmin("cmd.exe", "/c takeown /f " & lblFullPath.Text & " /r /d y && icacls " & lblFullPath.Text & " /grant administrators:F /t && pause")
        End If
    End Sub
    
    Sub chkReadOnly_Click() Handles chkReadOnly.Click
        If chkReadOnly.Checked Then WalkmanLib.SetAttribute(lblFullPath.Text, GetAttributes(lblFullPath.Text) + FileAttributes.ReadOnly) _
          Else WalkmanLib.SetAttribute(lblFullPath.Text, GetAttributes(lblFullPath.Text) - FileAttributes.ReadOnly)
        CheckData
    End Sub
    Sub chkHidden_Click() Handles chkHidden.Click
        If chkHidden.Checked Then WalkmanLib.SetAttribute(lblFullPath.Text, GetAttributes(lblFullPath.Text) + FileAttributes.Hidden) _
          Else WalkmanLib.SetAttribute(lblFullPath.Text, GetAttributes(lblFullPath.Text) - FileAttributes.Hidden)
        CheckData
    End Sub
    Sub chkCompressed_Click() Handles chkCompressed.Click
        If chkCompressed.Checked Then
            If WalkmanLib.SetAttribute(lblFullPath.Text, GetAttributes(lblFullPath.Text) + FileAttributes.Compressed) Then
                If Not GetAttributes(lblFullPath.Text).HasFlag(FileAttributes.Compressed) Then
                    Dim oneGB = 1000000000 '1 GB
                    If byteSize < oneGB Or (byteSize >= oneGB AndAlso MsgBox("Are you sure you want to compress this large file (>1GB)? This will take a while and can't be interrupted", _
                            MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Compressing Large File") = MsgBoxResult.Yes) Then
                        CompressReport.bwCompress.RunWorkerAsync({True, lblFullPath.Text})
                        CompressReport.ShowDialog
                    End If
                End If
            End If
        Else
            If WalkmanLib.SetAttribute(lblFullPath.Text, GetAttributes(lblFullPath.Text) - FileAttributes.Compressed) Then
                If GetAttributes(lblFullPath.Text).HasFlag(FileAttributes.Compressed) Then
                    Dim oneGB = 1000000000
                    If byteSize < oneGB Or (byteSize >= oneGB AndAlso MsgBox("Are you sure you want to decompress this large file (>1GB)? This will take a while and can't be interrupted", _
                            MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Decompressing Large File") = MsgBoxResult.Yes) Then
                        CompressReport.bwCompress.RunWorkerAsync({False, lblFullPath.Text})
                        CompressReport.ShowDialog
                    End If
                End If
            End If
        End If
        CheckData
    End Sub
    Sub chkEncrypted_Click() Handles chkEncrypted.Click
        If chkEncrypted.Checked Then
            If WalkmanLib.SetAttribute(lblFullPath.Text, GetAttributes(lblFullPath.Text) + FileAttributes.Encrypted) Then
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
            End If
        Else
            If WalkmanLib.SetAttribute(lblFullPath.Text, GetAttributes(lblFullPath.Text) - FileAttributes.Encrypted) Then
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
    Sub chkSystem_Click() Handles chkSystem.Click
        If chkSystem.Checked Then WalkmanLib.SetAttribute(lblFullPath.Text, GetAttributes(lblFullPath.Text) + FileAttributes.System) _
          Else WalkmanLib.SetAttribute(lblFullPath.Text, GetAttributes(lblFullPath.Text) - FileAttributes.System)
        CheckData
    End Sub
    Sub chkArchive_Click() Handles chkArchive.Click
        If chkArchive.Checked Then WalkmanLib.SetAttribute(lblFullPath.Text, GetAttributes(lblFullPath.Text) + FileAttributes.Archive) _
          Else WalkmanLib.SetAttribute(lblFullPath.Text, GetAttributes(lblFullPath.Text) - FileAttributes.Archive)
        CheckData
    End Sub
    Sub chkTemporary_Click() Handles chkTemporary.Click
        If chkTemporary.Checked Then WalkmanLib.SetAttribute(lblFullPath.Text, GetAttributes(lblFullPath.Text) + FileAttributes.Temporary) _
          Else WalkmanLib.SetAttribute(lblFullPath.Text, GetAttributes(lblFullPath.Text) - FileAttributes.Temporary)
        CheckData
    End Sub
    Sub chkIntegrity_Click() Handles chkIntegrity.Click
        If chkIntegrity.Checked Then WalkmanLib.SetAttribute(lblFullPath.Text, GetAttributes(lblFullPath.Text) + FileAttributes.IntegrityStream) _
          Else WalkmanLib.SetAttribute(lblFullPath.Text, GetAttributes(lblFullPath.Text) - FileAttributes.IntegrityStream)
        CheckData
    End Sub
    Sub chkNoScrub_Click() Handles chkNoScrub.Click
        If chkNoScrub.Checked Then WalkmanLib.SetAttribute(lblFullPath.Text, GetAttributes(lblFullPath.Text) + FileAttributes.NoScrubData) _
          Else WalkmanLib.SetAttribute(lblFullPath.Text, GetAttributes(lblFullPath.Text) - FileAttributes.NoScrubData)
        CheckData
    End Sub
    Sub chkNotIndexed_Click() Handles chkNotIndexed.Click
        If chkNotIndexed.Checked Then WalkmanLib.SetAttribute(lblFullPath.Text, GetAttributes(lblFullPath.Text) + FileAttributes.NotContentIndexed) _
          Else WalkmanLib.SetAttribute(lblFullPath.Text, GetAttributes(lblFullPath.Text) - FileAttributes.NotContentIndexed)
        CheckData
    End Sub
    Sub chkOffline_Click() Handles chkOffline.Click
        If chkOffline.Checked Then WalkmanLib.SetAttribute(lblFullPath.Text, GetAttributes(lblFullPath.Text) + FileAttributes.Offline) _
          Else WalkmanLib.SetAttribute(lblFullPath.Text, GetAttributes(lblFullPath.Text) - FileAttributes.Offline)
        CheckData
    End Sub
    Sub chkReparse_Click() Handles chkReparse.Click
        If chkReparse.Checked Then WalkmanLib.SetAttribute(lblFullPath.Text, GetAttributes(lblFullPath.Text) + FileAttributes.ReparsePoint) _
          Else WalkmanLib.SetAttribute(lblFullPath.Text, GetAttributes(lblFullPath.Text) - FileAttributes.ReparsePoint)
        CheckData
    End Sub
    Sub chkSparse_Click() Handles chkSparse.Click
        If chkSparse.Checked Then WalkmanLib.SetAttribute(lblFullPath.Text, GetAttributes(lblFullPath.Text) + FileAttributes.SparseFile) _
          Else WalkmanLib.SetAttribute(lblFullPath.Text, GetAttributes(lblFullPath.Text) - FileAttributes.SparseFile)
        CheckData
    End Sub
    
    Sub lnkAttributes_LinkClicked() Handles lnkAttributes.LinkClicked
        Try
            Process.Start("https://msdn.microsoft.com/en-us/library/system.io.fileattributes%28v=vs.110%29.aspx#Anchor_1")
        Catch ex As Exception
            If MsgBox("Unable to launch URL, copy to clipboard instead?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then _
              Clipboard.SetText("https://msdn.microsoft.com/en-us/library/system.io.fileattributes%28v=vs.110%29.aspx#Anchor_1")
        End Try
    End Sub
    
    Sub btnRename_Click() Handles btnRename.Click
        Dim FileProperties As New FileInfo(lblFullPath.Text)
        Dim newName = InputBox("Rename to:", "New name", FileProperties.Name)
        If newName <> "" Then
            Try
                FileProperties.MoveTo(FileProperties.DirectoryName & "\" & newName)
                lblLocation.Text = FileProperties.FullName
            Catch ex As UnauthorizedAccessException
                If MsgBox(ex.message & vbnewline & vbnewline & "Try launching a system tool as admin?", _
                  MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Access denied!") = MsgBoxResult.Yes Then
                    WalkmanLib.RunAsAdmin("cmd", "/k ren """ & lblFullPath.Text & """ """ & newName & """")
                    If MsgBox("Read new location?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then _
                      lblLocation.Text = FileProperties.DirectoryName & "\" & newName
                Else
                    ErrorParser(ex)
                End If
            Catch ex As exception
                ErrorParser(ex)
            End Try
        End If
        CheckData
    End Sub
    Sub btnDelete_Click() Handles btnDelete.Click
        Dim FileProperties As New FileInfo(lblFullPath.Text)
        If MsgBox("Are you sure you want to delete """ & FileProperties.Name & """?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Try
                If chkUseSystem.Checked Then
                    If Exists(lblFullPath.Text) Then
                        My.Computer.FileSystem.DeleteFile(lblFullPath.Text, FileIO.UIOption.AllDialogs, FileIO.RecycleOption.DeletePermanently)
                    Else
                        My.Computer.FileSystem.DeleteDirectory(lblFullPath.Text, FileIO.UIOption.AllDialogs, FileIO.RecycleOption.DeletePermanently)
                    End If
                Else
                    If Exists(lblFullPath.Text) Then
                        FileProperties.Delete
                    ElseIf Directory.Exists(lblFullPath.Text)
                        BackgroundProgress.bwFolderOperations.RunWorkerAsync({"delete", lblFullPath.Text})
                        BackgroundProgress.ShowDialog
                    End If
                End If
                Application.Exit
            Catch ex As UnauthorizedAccessException
                If MsgBox(ex.message & vbnewline & vbnewline & "Try launching a system tool as admin?", _
                  MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Access denied!") = MsgBoxResult.Yes Then
                    WalkmanLib.RunAsAdmin("cmd", "/k del """ & lblFullPath.Text & """")
                Else
                    ErrorParser(ex)
                End If
            Catch ex As exception
                ErrorParser(ex)
            End Try
        End If
        CheckData
    End Sub
    Sub btnCopy_Click() Handles btnCopy.Click
        Dim FileProperties As New FileInfo(lblFullPath.Text)
        SaveFileDialog.InitialDirectory = FileProperties.DirectoryName
        SaveFileDialog.FileName = FileProperties.Name
        SaveFileDialog.Title = "Choose where to copy """ & FileProperties.Name & """ to:"
        If SaveFileDialog.ShowDialog() = DialogResult.OK Then
            ' No point in adding an access denied check here, since the SaveFileDialog doesn't allow you to select a location that needs admin access
            If chkUseSystem.Checked Then
                If Exists(lblFullPath.Text) Then
                    My.Computer.FileSystem.CopyFile(lblFullPath.Text, SaveFileDialog.FileName, FileIO.UIOption.AllDialogs)
                Else
                    My.Computer.FileSystem.CopyDirectory(lblFullPath.Text, SaveFileDialog.FileName, FileIO.UIOption.AllDialogs)
                End If
            Else
                If Exists(lblFullPath.Text) Then
                    FileProperties.CopyTo(SaveFileDialog.FileName)
                ElseIf Directory.Exists(lblFullPath.Text)
                    BackgroundProgress.bwFolderOperations.RunWorkerAsync({"copy", lblFullPath.Text, SaveFileDialog.FileName})
                    BackgroundProgress.ShowDialog
                End If
            End If
            
            If MsgBox("Read new location?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then _
              lblLocation.Text = SaveFileDialog.FileName
        End If
        CheckData
    End Sub
    Sub btnCopy_MouseUp(sender As Object, e As MouseEventArgs) Handles btnCopy.MouseUp
        If e.Button = MouseButtons.Right Then
            Dim FileProperties As New FileInfo(lblFullPath.Text)
            Dim newName = InputBox("Copy to:", "Copy file", FileProperties.FullName)
            If newName <> "" Then
                Try
                    If chkUseSystem.Checked Then
                        If Exists(lblFullPath.Text) Then
                            My.Computer.FileSystem.CopyFile(lblFullPath.Text, newName, FileIO.UIOption.AllDialogs)
                        Else
                            My.Computer.FileSystem.CopyDirectory(lblFullPath.Text, newName, FileIO.UIOption.AllDialogs)
                        End If
                    Else
                        If Exists(lblFullPath.Text)
                            FileProperties.CopyTo(newName)
                        ElseIf Directory.Exists(lblFullPath.Text)
                            BackgroundProgress.bwFolderOperations.RunWorkerAsync({"copy", lblFullPath.Text, newName})
                            BackgroundProgress.ShowDialog
                        End If
                    End If
                    If MsgBox("Read new location?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then _
                      lblLocation.Text = newName
                Catch ex As UnauthorizedAccessException
                    If MsgBox(ex.message & vbnewline & vbnewline & "Try launching a system tool as admin?", _
                          MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Access denied!") = MsgBoxResult.Yes Then
                            WalkmanLib.RunAsAdmin("xcopy", """" & lblFullPath.Text & """ """ & newName & """")
                            If MsgBox("Read new location?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then _
                              lblLocation.Text = newName
                        Else
                            ErrorParser(ex)
                        End If
                Catch ex As exception
                    ErrorParser(ex)
                End Try
            End If
            CheckData
        End If
    End Sub
    Sub btnMove_Click() Handles btnMove.Click
        Dim FileProperties As New FileInfo(lblFullPath.Text)
        SaveFileDialog.InitialDirectory = FileProperties.DirectoryName
        SaveFileDialog.FileName = FileProperties.Name
        SaveFileDialog.Title = "Choose where to move """ & FileProperties.Name & """ to:"
        If SaveFileDialog.ShowDialog() = DialogResult.OK Then
            Try
                If chkUseSystem.Checked Then
                    If Exists(lblFullPath.Text) Then
                        My.Computer.FileSystem.MoveFile(lblFullPath.Text, SaveFileDialog.FileName, FileIO.UIOption.AllDialogs)
                    ElseIf Directory.Exists(lblFullPath.Text)
                        My.Computer.FileSystem.MoveDirectory(lblFullPath.Text, SaveFileDialog.FileName, FileIO.UIOption.AllDialogs)
                    End If
                Else
                    FileProperties.MoveTo(SaveFileDialog.FileName)
                End If
                lblLocation.Text = SaveFileDialog.FileName
            Catch ex As UnauthorizedAccessException
                If MsgBox(ex.message & vbnewline & vbnewline & "Try launching a system tool as admin?", _
                  MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Access denied!") = MsgBoxResult.Yes Then
                    WalkmanLib.RunAsAdmin("cmd", "/k move """ & lblFullPath.Text & """ """ & SaveFileDialog.FileName & """")
                    If MsgBox("Read new location?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then _
                      lblLocation.Text = SaveFileDialog.FileName
                Else
                    ErrorParser(ex)
                End If
            Catch ex As exception
                ErrorParser(ex)
            End Try
        End If
        CheckData
    End Sub
    Sub btnClose_Click() Handles btnClose.Click
        Application.Exit
    End Sub
    
    Sub bwCalcSize_DoWork() Handles bwCalcSize.DoWork
        Try
            Dim DirectoryProperties As New DirectoryInfo(lblFullPath.Text)
            
            lblOpenWith.Text = "Checking..."
            lblSize.Text = "Getting file list... (May take a while)"
            Dim SubFiles = DirectoryProperties.GetFiles("*", SearchOption.AllDirectories)
            
            lblOpenWith.Text = SubFiles.Count.ToString("N0")
            byteSize = 0
            For Each SubFile As FileInfo In SubFiles
                byteSize += SubFile.Length
                lblSize.Text = byteSize
            Next
            
            lblOpenWith.Text = SubFiles.Count.ToString("N0")
            AutoDetectSize
        Catch ex As Exception
            lblSize.Text = "Error: " & ex.Message
            lblOpenWith.Text = "?"
            ErrorParser(ex)
        End Try
        ApplySizeFormatting
    End Sub
    
    Sub ErrorParser(ex As Exception)
        ''' <summary>
        ''' Copied from DirectoryImage (see the end of the file)
        ''' </summary>
        If ex.GetType.ToString = "System.UnauthorizedAccessException" AndAlso Not WalkmanLib.IsAdmin() Then
            If MsgBox(ex.message & vbnewline & vbnewline & "Try launching PropertiesDotNet As Administrator?", _
              MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Access denied!") = MsgBoxResult.Yes Then
                WalkmanLib.RunAsAdmin(Application.StartupPath & "\" & Process.GetCurrentProcess.ProcessName & ".exe", lblFullPath.Text)
                Application.Exit
            End If
        Else
            WalkmanLib.ErrorDialog(ex)
        End If
    End Sub
End Class
