Imports System.IO
Imports System.IO.File
Imports System.Security.Principal

Public Class PropertiesDotNet
    ' Imported Functions: FindExecutable:
    '  Used for finding the program that a file opens with
    '   http://www.vb-helper.com/howto_get_associated_program.html
    Private Declare Function FindExecutable Lib "shell32.dll" Alias "FindExecutableA"(lpFile As String, lpDirectory As String, lpResult As String) As Long
    
    Sub PropertiesDotNet_Load(sender As Object, e As EventArgs) Handles Me.Load
        For Each s As String In My.Application.CommandLineArgs
            If lblLocation.Text = "Checking..." Then
                lblLocation.Text = s
            Else
                Process.Start(Application.StartupPath & "\" & Process.GetCurrentProcess.ProcessName & ".exe", """" & s & """")
            End If
        Next
        If lblLocation.Text = "Checking..." Then
            Dim OpenFileDialog As New OpenFileDialog()
            OpenFileDialog.Filter = "All Files|*.*"
            OpenFileDialog.Title = "Select a file to view properties for:"
            If OpenFileDialog.ShowDialog() = DialogResult.OK Then
                lblLocation.Text = OpenFileDialog.FileName
            Else
                Application.Exit
            End If
        End If
        CheckData
    End Sub
    
    Sub CheckData Handles chkUTC.CheckedChanged
        'Properties:
        Dim FileProperties As New FileInfo(lblLocation.Text)
        If IsRunningAsAdmin Then Me.Text = "[Admin] Properties: " & FileProperties.Name Else _
          Me.Text = "Properties: " & FileProperties.Name
        lblFullPath.Text = FileProperties.FullName
        lblDirectory.Text = FileProperties.DirectoryName
        lblName.Text = FileProperties.Name
        If lblFullPath.Width>256 Then Me.Width = lblFullPath.Width + 176
        lblExtension.Text = FileProperties.Extension
        lblSize.Text = FileProperties.Length
        imgFile.ImageLocation = FileProperties.FullName
        
        Dim result As String = Space$(1024)
        FindExecutable(lblName.Text, lblDirectory.Text & "\", result)
        lblOpenWith.Text = Strings.Left$(result, InStr(result, Chr(0)) - 1)
        If lblOpenWith.Text = "" Then lblOpenWith.Text = "Filetype not associated!"
        
        If chkUTC.Checked Then
            lblCreationTime.Text = GetCreationTime(lblLocation.Text)
            lblLastAccessTime.Text = GetLastAccessTime(lblLocation.Text)
            lblLastWriteTime.Text = GetLastWriteTime(lblLocation.Text)
        Else
            lblCreationTime.Text = GetCreationTimeUtc(lblLocation.Text)
            lblLastAccessTime.Text = GetLastAccessTimeUtc(lblLocation.Text)
            lblLastWriteTime.Text = GetLastWriteTimeUtc(lblLocation.Text)
        End If
        
        'Attributes:
        chkReadOnly.Checked = GetAttributes(lblLocation.Text).HasFlag(FileAttributes.ReadOnly)
        chkHidden.Checked = GetAttributes(lblLocation.Text).HasFlag(FileAttributes.Hidden)
        chkCompressed.Checked = GetAttributes(lblLocation.Text).HasFlag(FileAttributes.Compressed)
        chkEncrypted.Checked = GetAttributes(lblLocation.Text).HasFlag(FileAttributes.Encrypted)
        chkSystem.Checked = GetAttributes(lblLocation.Text).HasFlag(FileAttributes.System)
        chkArchive.Checked = GetAttributes(lblLocation.Text).HasFlag(FileAttributes.Archive)
        chkTemporary.Checked = GetAttributes(lblLocation.Text).HasFlag(FileAttributes.Temporary)
        chkIntegrity.Checked = GetAttributes(lblLocation.Text).HasFlag(FileAttributes.IntegrityStream)
        chkNoScrub.Checked = GetAttributes(lblLocation.Text).HasFlag(FileAttributes.NoScrubData)
        chkNotIndexed.Checked = GetAttributes(lblLocation.Text).HasFlag(FileAttributes.NotContentIndexed)
        chkOffline.Checked = GetAttributes(lblLocation.Text).HasFlag(FileAttributes.Offline)
        chkReparse.Checked = GetAttributes(lblLocation.Text).HasFlag(FileAttributes.ReparsePoint)
        chkSparse.Checked = GetAttributes(lblLocation.Text).HasFlag(FileAttributes.SparseFile)
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
            If MsgBox("Are you sure you want to open the ""Open With"" dialog for """ & lblExtension.Text & _
              """ files? this could potentially make your PC unusable if you click ""Ok"" in it while the ""Always use the selected program"" checkbox is checked!", _
              MsgBoxStyle.Critical + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then _
                If MsgBox("You have been warned!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then _
                  Shell("rundll32 shell32.dll,OpenAs_RunDLL " & lblFullPath.Text, AppWinStyle.NormalFocus, True, 500)
        Else
            Shell("rundll32 shell32.dll,OpenAs_RunDLL " & lblFullPath.Text, AppWinStyle.NormalFocus, True, 500)
            'Process.Start("rundll32", "shell32.dll,OpenAs_RunDLL " & lblFullPath.Text)
        End If
    End Sub
    Sub btnStartAssocProg_Click() Handles btnStartAssocProg.Click
        Process.Start(lblOpenWith.Text)
    End Sub
    Sub btnHashes_Click() Handles btnHashes.Click
        Hashes.Show
    End Sub
    
    Sub chkReadOnly_Click() Handles chkReadOnly.Click
        If chkReadOnly.Checked Then SetAttribWCheck(lblLocation.Text, GetAttributes(lblLocation.Text) + FileAttributes.ReadOnly) _
          Else SetAttribWCheck(lblLocation.Text, GetAttributes(lblLocation.Text) - FileAttributes.ReadOnly)
        CheckData
    End Sub
    Sub chkHidden_Click() Handles chkHidden.Click
        If chkHidden.Checked Then SetAttribWCheck(lblLocation.Text, GetAttributes(lblLocation.Text) + FileAttributes.Hidden) _
          Else SetAttribWCheck(lblLocation.Text, GetAttributes(lblLocation.Text) - FileAttributes.Hidden)
        CheckData
    End Sub
    Sub chkCompressed_Click() Handles chkCompressed.Click
        If chkCompressed.Checked Then
            If SetAttribWCheck(lblLocation.Text, GetAttributes(lblLocation.Text) + FileAttributes.Compressed) Then
                If Not GetAttributes(lblLocation.Text).HasFlag(FileAttributes.Compressed) Then
                    CompressReport.Compress(lblFullPath.Text)
                    CompressReport.ShowDialog
                End If
            End If
        Else
            If SetAttribWCheck(lblLocation.Text, GetAttributes(lblLocation.Text) - FileAttributes.Compressed) Then
                If GetAttributes(lblLocation.Text).HasFlag(FileAttributes.Compressed) Then
                    CompressReport.Compress(lblFullPath.Text, False)
                    CompressReport.ShowDialog
                End If
            End If
        End If
        CheckData
    End Sub
    Sub chkEncrypted_Click() Handles chkEncrypted.Click
        If chkEncrypted.Checked Then
            If SetAttribWCheck(lblLocation.Text, GetAttributes(lblLocation.Text) + FileAttributes.Encrypted) Then
                If Not GetAttributes(lblLocation.Text).HasFlag(FileAttributes.Encrypted) Then
                    Dim FileProperties As New FileInfo(lblLocation.Text)
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
            If SetAttribWCheck(lblLocation.Text, GetAttributes(lblLocation.Text) - FileAttributes.Encrypted) Then
                If GetAttributes(lblLocation.Text).HasFlag(FileAttributes.Encrypted) Then
                    Dim FileProperties As New FileInfo(lblLocation.Text)
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
        If chkSystem.Checked Then SetAttribWCheck(lblLocation.Text, GetAttributes(lblLocation.Text) + FileAttributes.System) _
          Else SetAttribWCheck(lblLocation.Text, GetAttributes(lblLocation.Text) - FileAttributes.System)
        CheckData
    End Sub
    Sub chkArchive_Click() Handles chkArchive.Click
        If chkArchive.Checked Then SetAttribWCheck(lblLocation.Text, GetAttributes(lblLocation.Text) + FileAttributes.Archive) _
          Else SetAttribWCheck(lblLocation.Text, GetAttributes(lblLocation.Text) - FileAttributes.Archive)
        CheckData
    End Sub
    Sub chkTemporary_Click() Handles chkTemporary.Click
        If chkTemporary.Checked Then SetAttribWCheck(lblLocation.Text, GetAttributes(lblLocation.Text) + FileAttributes.Temporary) _
          Else SetAttribWCheck(lblLocation.Text, GetAttributes(lblLocation.Text) - FileAttributes.Temporary)
        CheckData
    End Sub
    Sub chkIntegrity_Click() Handles chkIntegrity.Click
        If chkIntegrity.Checked Then SetAttribWCheck(lblLocation.Text, GetAttributes(lblLocation.Text) + FileAttributes.IntegrityStream) _
          Else SetAttribWCheck(lblLocation.Text, GetAttributes(lblLocation.Text) - FileAttributes.IntegrityStream)
        CheckData
    End Sub
    Sub chkNoScrub_Click() Handles chkNoScrub.Click
        If chkNoScrub.Checked Then SetAttribWCheck(lblLocation.Text, GetAttributes(lblLocation.Text) + FileAttributes.NoScrubData) _
          Else SetAttribWCheck(lblLocation.Text, GetAttributes(lblLocation.Text) - FileAttributes.NoScrubData)
        CheckData
    End Sub
    Sub chkNotIndexed_Click() Handles chkNotIndexed.Click
        If chkNotIndexed.Checked Then SetAttribWCheck(lblLocation.Text, GetAttributes(lblLocation.Text) + FileAttributes.NotContentIndexed) _
          Else SetAttribWCheck(lblLocation.Text, GetAttributes(lblLocation.Text) - FileAttributes.NotContentIndexed)
        CheckData
    End Sub
    Sub chkOffline_Click() Handles chkOffline.Click
        If chkOffline.Checked Then SetAttribWCheck(lblLocation.Text, GetAttributes(lblLocation.Text) + FileAttributes.Offline) _
          Else SetAttribWCheck(lblLocation.Text, GetAttributes(lblLocation.Text) - FileAttributes.Offline)
        CheckData
    End Sub
    Sub chkReparse_Click() Handles chkReparse.Click
        If chkReparse.Checked Then SetAttribWCheck(lblLocation.Text, GetAttributes(lblLocation.Text) + FileAttributes.ReparsePoint) _
          Else SetAttribWCheck(lblLocation.Text, GetAttributes(lblLocation.Text) - FileAttributes.ReparsePoint)
        CheckData
    End Sub
    Sub chkSparse_Click() Handles chkSparse.Click
        If chkSparse.Checked Then SetAttribWCheck(lblLocation.Text, GetAttributes(lblLocation.Text) + FileAttributes.SparseFile) _
          Else SetAttribWCheck(lblLocation.Text, GetAttributes(lblLocation.Text) - FileAttributes.SparseFile)
        CheckData
    End Sub
    
    Sub lnkAttributes_LinkClicked() Handles lnkAttributes.LinkClicked
        Try
            Process.Start("https://msdn.microsoft.com/en-us/library/system.io.fileattributes(v=vs.110).aspx#memberList")
        Catch ex As Exception
            If MsgBox("Unable to launch URL, copy to clipboard instead?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then _
              Clipboard.SetText("https://msdn.microsoft.com/en-us/library/system.io.fileattributes(v=vs.110).aspx#memberList")
        End Try
    End Sub
    
    Sub btnRename_Click() Handles btnRename.Click
        Dim FileProperties As New FileInfo(lblLocation.Text)
        Dim newName = InputBox("Rename to:", "New name", FileProperties.Name)
        If newName <> "" Then
            Try
                FileProperties.MoveTo(FileProperties.DirectoryName & "\" & newName)
                lblLocation.Text = FileProperties.FullName
            Catch ex As UnauthorizedAccessException
                If MsgBox(ex.message & vbnewline & vbnewline & "Try launching a system tool as admin?", _
                  MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Access denied!") = MsgBoxResult.Yes Then
                    CreateObject("Shell.Application").ShellExecute("cmd", "/k ren """ & lblFullPath.Text & _
                      """ """ & newName & """", "", "runas")
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
        Dim FileProperties As New FileInfo(lblLocation.Text)
        If MsgBox("Are you sure you want to delete """ & FileProperties.Name & """?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Try
                FileProperties.Delete
                Application.Exit
            Catch ex As UnauthorizedAccessException
                If MsgBox(ex.message & vbnewline & vbnewline & "Try launching a system tool as admin?", _
                  MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Access denied!") = MsgBoxResult.Yes Then
                    CreateObject("Shell.Application").ShellExecute("cmd", "/k del """ & lblFullPath.Text & """", "", "runas")
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
        Dim FileProperties As New FileInfo(lblLocation.Text)
        SaveFileDialog.InitialDirectory = FileProperties.DirectoryName
        SaveFileDialog.FileName = FileProperties.Name
        SaveFileDialog.Title = "Choose where to copy """ & FileProperties.Name & """ to:"
        If SaveFileDialog.ShowDialog() = DialogResult.OK Then
            ' No point in adding an access denied check here, since the SaveFileDialog doesn't allow you to select a location that needs admin access
            FileProperties.CopyTo(SaveFileDialog.FileName)
            If MsgBox("Read new file?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then _
              lblLocation.Text = SaveFileDialog.FileName
        End If
        CheckData
    End Sub
    Sub btnCopy_MouseUp(sender As Object, e As MouseEventArgs) Handles btnCopy.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim FileProperties As New FileInfo(lblLocation.Text)
            Dim newName = InputBox("Copy to:", "Copy file", FileProperties.FullName)
            If newName <> "" Then
                Try
                    FileProperties.CopyTo(newName)
                    If MsgBox("Read new file?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then _
                        lblLocation.Text = newName
                Catch ex As UnauthorizedAccessException
                    If MsgBox(ex.message & vbnewline & vbnewline & "Try launching a system tool as admin?", _
                          MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Access denied!") = MsgBoxResult.Yes Then
                            CreateObject("Shell.Application").ShellExecute("xcopy", """" & lblFullPath.Text & _
                              """ """ & newName & """", "", "runas")
                            If MsgBox("Read new file?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then _
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
        Dim FileProperties As New FileInfo(lblLocation.Text)
        SaveFileDialog.InitialDirectory = FileProperties.DirectoryName
        SaveFileDialog.FileName = FileProperties.Name
        SaveFileDialog.Title = "Choose where to move """ & FileProperties.Name & """ to:"
        If SaveFileDialog.ShowDialog() = DialogResult.OK Then
            Try
                FileProperties.MoveTo(SaveFileDialog.FileName)
                lblLocation.Text = SaveFileDialog.FileName
            Catch ex As UnauthorizedAccessException
                If MsgBox(ex.message & vbnewline & vbnewline & "Try launching a system tool as admin?", _
                  MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Access denied!") = MsgBoxResult.Yes Then
                    CreateObject("Shell.Application").ShellExecute("cmd", "/k move """ & lblFullPath.Text & _
                      """ """ & SaveFileDialog.FileName & """", "", "runas")
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
    
    ''' <summary>Sets the specified System.IO.FileAttributes of the file on the specified path, with a try..catch block.</summary>
    ''' <param name="path">The path to the file.</param>
    ''' <param name="fileAttributes">A bitwise combination of the enumeration values.</param>
    ''' <returns>True if setting the attribute was successful, False if not.</returns>
    Function SetAttribWCheck(path As String, fileAttributes As FileAttributes) As Boolean
        Try
            SetAttributes(path, fileAttributes)
            Return True
        Catch ex As exception
            ErrorParser(ex)
            Return False
        End Try
    End Function
    
    ''' <summary>
    ''' Checks if process is running with administrator priveledges.
    ''' </summary>
    ''' <returns>True if process is admin, False if not.</returns>
    Public Shared Function IsRunningAsAdmin() As Boolean
        ' Thanks to https://stackoverflow.com/a/22691609/2999220
        Dim principal As New WindowsPrincipal(WindowsIdentity.GetCurrent)
        Return principal.IsInRole(WindowsBuiltInRole.Administrator)
    End Function
    
    Sub ErrorParser(ex As Exception)
        ''' <summary>
        ''' Copied from DirectoryImage (see the end of the file)
        ''' </summary>
        If ex.GetType.ToString = "System.UnauthorizedAccessException" AndAlso Not IsRunningAsAdmin Then
            If MsgBox(ex.message & vbnewline & vbnewline & "Try launching PropertiesDotNet As Administrator?", _
              MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Access denied!") = MsgBoxResult.Yes Then
                CreateObject("Shell.Application").ShellExecute(Application.StartupPath & "\" & _
                  Process.GetCurrentProcess.ProcessName & ".exe", """" & lblFullPath.Text & """", "", "runas")
                Application.Exit
            End If
        Else
            If MsgBox("There was an error! Error message: " & ex.Message & vbNewLine & "Show full stacktrace? (For sending to developer/making bugreport)", _
              MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Error!") = MsgBoxresult.Yes Then
                Dim frmBugReport As New Form()
                frmBugReport.Width = 600
                frmBugReport.Height = 525
                frmBugReport.StartPosition = FormStartPosition.CenterParent
                frmBugReport.WindowState = Me.WindowState
                frmBugReport.ShowIcon = False
                frmBugReport.ShowInTaskbar = True
                frmBugReport.Text = "Full error trace"
                Dim txtBugReport As New TextBox()
                txtBugReport.Multiline = True
                txtBugReport.ScrollBars = ScrollBars.Vertical
                frmBugReport.Controls.Add(txtBugReport)
                txtBugReport.Dock = DockStyle.Fill
                txtBugReport.Text = "ToString:" & vbNewLine & ex.ToString & vbNewLine & vbNewLine & _
                                    "Data:" & vbNewLine & ex.Data.ToString & vbNewLine & vbNewLine & _
                                    "BaseException:" & vbNewLine & ex.GetBaseException.ToString & vbNewLine & vbNewLine & _
                                    "HashCode:" & vbNewLine & ex.GetHashCode.ToString & vbNewLine & vbNewLine & _
                                    "Type:" & vbNewLine & ex.GetType.ToString & vbNewLine & vbNewLine & _
                                    "HResult:" & vbNewLine & ex.HResult.ToString & vbNewLine & vbNewLine & _
                                    "Message:" & vbNewLine & ex.Message.ToString & vbNewLine & vbNewLine & _
                                    "Source:" & vbNewLine & ex.Source.ToString & vbNewLine & vbNewLine & _
                                    "StackTrace:" & vbNewLine & ex.StackTrace.ToString & vbNewLine & vbNewLine & _
                                    "TargetSite:" & vbNewLine & ex.TargetSite.ToString
                frmBugReport.Show()
            End If
        End If
    End Sub
End Class
