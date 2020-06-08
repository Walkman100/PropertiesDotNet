Public Class Operations
    <Flags>
    Enum PathEnum
        NotFound = 0
        Exists = 1
        IsDirectory = 2
        IsFile = 4
        IsDrive = 8
    End Enum
    Shared Function IsFileOrDirectory(path As String) As PathEnum
        Dim rtn As PathEnum
        If File.Exists(path) Then
            rtn = PathEnum.Exists Or PathEnum.IsFile
        ElseIf Directory.Exists(path)
            rtn = PathEnum.Exists Or PathEnum.IsDirectory
        End If
        
        ' path can be a Directory and a Drive, or just a Drive...
        ' will have IsDirectory if the drive can be accessed
        If New DriveInfo(path).Name = New FileInfo(path).FullName Then
            rtn = rtn Or PathEnum.Exists Or PathEnum.IsDrive
        End If
        
        Return rtn
    End Function
    
    Enum TimeChangeEnum
        Creation = 1   ' have to give them values,
        LastAccess = 2 '  so the "Case ... And ..."
        LastWrite = 3  '  below works.
    End Enum
    
    Shared Sub SetSelectDateDialogValue(path As String, useUTC As Boolean, type As TimeChangeEnum)
        Try
            Select type
                Case TimeChangeEnum.Creation And useUTC
                    SelectDateDialog.dateTimePicker.Value = GetCreationTimeUtc(path)
                Case TimeChangeEnum.Creation
                    SelectDateDialog.dateTimePicker.Value = GetCreationTime(path)
                Case TimeChangeEnum.LastAccess And useUTC
                    SelectDateDialog.dateTimePicker.Value = GetLastAccessTimeUtc(path)
                Case TimeChangeEnum.LastAccess
                    SelectDateDialog.dateTimePicker.Value = GetLastAccessTime(path)
                Case TimeChangeEnum.LastWrite And useUTC
                    SelectDateDialog.dateTimePicker.Value = GetLastWriteTimeUtc(path)
                Case TimeChangeEnum.LastWrite
                    SelectDateDialog.dateTimePicker.Value = GetLastWriteTime(path)
            End Select
        Catch ex As Exception
            PropertiesDotNet.ErrorParser(ex)
        End Try
    End Sub
    
    Shared Sub SetTime(path As String, useUTC As Boolean, type As TimeChangeEnum, time As Date)
        Try
            Select Case type
                Case TimeChangeEnum.Creation And useUTC
                    SetCreationTimeUtc  (path, time)
                Case TimeChangeEnum.Creation
                    SetCreationTime     (path, time)
                Case TimeChangeEnum.LastAccess And useUTC
                    SetLastAccessTimeUtc(path, time)
                Case TimeChangeEnum.LastAccess
                    SetLastAccessTime   (path, time)
                Case TimeChangeEnum.LastWrite And useUTC
                    SetLastWriteTimeUtc (path, time)
                Case TimeChangeEnum.LastWrite
                    SetLastWriteTime    (path, time)
            End Select
        Catch ex As Exception
            PropertiesDotNet.ErrorParser(ex)
        End Try
    End Sub
    
    ' cMBb = CustomMsgBoxBtn
    Public Const cMBbRelaunch As String = "Relaunch as Admin"
    Public Const cMBbRunSysTool As String = "Run System Tool as Admin"
    Public Const cMBbCancel As String = "Cancel"
    Public Const cMBTitle As String = "Access denied!"
    
    Private Shared Function Win32FromHResult(HResult As Integer) As Integer
        'getting Win32 error from HResult:
        ' https://docs.microsoft.com/en-us/dotnet/standard/io/handling-io-errors#handling-ioexception
        ' https://devblogs.microsoft.com/oldnewthing/20061103-07/?p=29133
        ' https://stackoverflow.com/a/426467/2999220
        Return (HResult And &H0000FFFF)
    End Function
    
    '32 (0x20) = ERROR_SHARING_VIOLATION: The process cannot access the file because it is being used by another process.
    Private Const shareViolation As Integer = &H20
    
    Shared Sub Rename(sourcePath As String, targetName As String)
        Dim fileProperties As New FileInfo(sourcePath)
        Dim fullTargetName = fileProperties.DirectoryName & Path.DirectorySeparatorChar & targetName
        
        Try
            If IsFileOrDirectory(fullTargetName).HasFlag(PathEnum.Exists) AndAlso sourcePath <> fullTargetName Then
                Select Case MsgBox("Target """ & fullTargetName & """ already exists! Remove first?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNoCancel)
                    Case MsgBoxResult.Yes
                        Delete(fullTargetName, False, Nothing)
                    Case MsgBoxResult.Cancel
                        Exit Sub
                End Select
            End If
            
            fileProperties.MoveTo(fullTargetName)
            
            PropertiesDotNet.lblLocation.Text = fileProperties.FullName
        Catch ex As UnauthorizedAccessException When Not WalkmanLib.IsAdmin()
            Select Case WalkmanLib.CustomMsgBox(ex.Message, cMBbRelaunch, cMBbRunSysTool, cMBbCancel, MsgBoxStyle.Exclamation, cMBTitle, ownerForm:=PropertiesDotNet)
                Case cMBbRelaunch
                    PropertiesDotNet.RestartAsAdmin()
                Case cMBbRunSysTool
                    WalkmanLib.RunAsAdmin("cmd", "/c ren """ & sourcePath & """ """ & targetName & """ && pause")
                    If MsgBox("Read new location?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                        PropertiesDotNet.lblLocation.Text = fullTargetName
                    End If
            End Select
        Catch ex As IOException When Win32FromHResult(ex.HResult) = shareViolation
            If MsgBox("File """ & sourcePath & """ is in use! Open Handle Manager?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                HandleManager.Show(PropertiesDotNet)
                HandleManager.Activate()
            End If
        Catch ex As Exception
            PropertiesDotNet.ErrorParser(ex)
        End Try
    End Sub
    
    Shared Sub Move(sourcePath As String, targetPath As String, useShell As Boolean)
        Try
            If useShell Then
                Dim pathInfo = IsFileOrDirectory(sourcePath)
                If pathInfo.HasFlag(PathEnum.IsFile) Then
                    My.Computer.FileSystem.MoveFile(sourcePath, targetPath, FileIO.UIOption.AllDialogs)
                ElseIf pathInfo.HasFlag(PathEnum.IsDirectory) Then
                    My.Computer.FileSystem.MoveDirectory(sourcePath, targetPath, FileIO.UIOption.AllDialogs)
                End If
            Else
                If IsFileOrDirectory(targetPath).HasFlag(PathEnum.Exists) AndAlso sourcePath <> targetPath Then
                    Select Case MsgBox("Target """ & targetPath & """ already exists! Remove first?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNoCancel)
                        Case MsgBoxResult.Yes
                            Delete(targetPath, useShell, FileIO.RecycleOption.DeletePermanently)
                        Case MsgBoxResult.Cancel
                            Exit Sub
                    End Select
                End If
                
                File.Move(sourcePath, targetPath)
            End If
            
            PropertiesDotNet.lblLocation.Text = targetPath
        Catch ex As OperationCanceledException ' ignore user cancellation
        Catch ex As UnauthorizedAccessException When Not WalkmanLib.IsAdmin()
            Select Case WalkmanLib.CustomMsgBox(ex.Message, cMBbRelaunch, cMBbRunSysTool, cMBbCancel, MsgBoxStyle.Exclamation, cMBTitle, ownerForm:=PropertiesDotNet)
                Case cMBbRelaunch
                    PropertiesDotNet.RestartAsAdmin()
                Case cMBbRunSysTool
                    WalkmanLib.RunAsAdmin("cmd", "/c move """ & sourcePath & """ """ & targetPath & """ & pause")
                    If MsgBox("Read new location?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                        PropertiesDotNet.lblLocation.Text = targetPath
                    End If
            End Select
        Catch ex As IOException When Win32FromHResult(ex.HResult) = shareViolation
            If MsgBox("File """ & sourcePath & """ is in use! Open Handle Manager?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                HandleManager.Show(PropertiesDotNet)
                HandleManager.Activate()
            End If
        Catch ex As Exception
            PropertiesDotNet.ErrorParser(ex)
        End Try
    End Sub
    
    Shared Sub Copy(sourcePath As String, targetPath As String, useShell As Boolean)
        Try
            Dim pathInfo = IsFileOrDirectory(sourcePath)
            If useShell Then
                If pathInfo.HasFlag(PathEnum.IsFile) Then
                    My.Computer.FileSystem.CopyFile(sourcePath, targetPath, FileIO.UIOption.AllDialogs)
                ElseIf pathInfo.HasFlag(PathEnum.IsDirectory) Then
                    My.Computer.FileSystem.CopyDirectory(sourcePath, targetPath, FileIO.UIOption.AllDialogs)
                End If
            Else
                If pathInfo.HasFlag(PathEnum.IsFile) Then
                    If IsFileOrDirectory(targetPath).HasFlag(PathEnum.Exists) AndAlso sourcePath <> targetPath AndAlso _
                            MsgBox("Target """ & targetPath & """ already exists! Are you sure you want to overwrite it?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        Exit Sub
                    End If
                    
                    File.Copy(sourcePath, targetPath, overwrite:=True)
                ElseIf pathInfo.HasFlag(PathEnum.IsDirectory) Then
                    BackgroundProgress.bwFolderOperations.RunWorkerAsync({"copy", sourcePath, targetPath})
                    BackgroundProgress.ShowDialog()
                End If
            End If
            
            If MsgBox("Read new location?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                PropertiesDotNet.lblLocation.Text = targetPath
            End If
        Catch ex As OperationCanceledException ' ignore user cancellation
        Catch ex As UnauthorizedAccessException When Not WalkmanLib.IsAdmin()
            Select Case WalkmanLib.CustomMsgBox(ex.Message, cMBbRelaunch, cMBbRunSysTool, cMBbCancel, MsgBoxStyle.Exclamation, cMBTitle, ownerForm:=PropertiesDotNet)
                Case cMBbRelaunch
                    PropertiesDotNet.RestartAsAdmin()
                Case cMBbRunSysTool
                    WalkmanLib.RunAsAdmin("xcopy", "/F /H /K """ & sourcePath & """ """ & targetPath & "*""")
                    If MsgBox("Read new location?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                        PropertiesDotNet.lblLocation.Text = targetPath
                    End If
            End Select
        Catch ex As IOException When Win32FromHResult(ex.HResult) = shareViolation
            If MsgBox("A file is in use! Open Handle Manager on """ & sourcePath & """?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                HandleManager.Show(PropertiesDotNet)
                HandleManager.Activate()
            Else
                PropertiesDotNet.ErrorParser(ex)
            End If
        Catch ex As Exception
            PropertiesDotNet.ErrorParser(ex)
        End Try
    End Sub
    
    Shared Sub Delete(path As String, useShell As String, Optional recycleOption As FileIO.RecycleOption = Nothing)
        Try
            Dim pathInfo = IsFileOrDirectory(path)
            If useShell Then
                If pathInfo.HasFlag(PathEnum.IsFile) Then
                    My.Computer.FileSystem.DeleteFile(path, FileIO.UIOption.AllDialogs, recycleOption)
                ElseIf pathInfo.HasFlag(PathEnum.IsDirectory) Then
                    My.Computer.FileSystem.DeleteDirectory(path, FileIO.UIOption.AllDialogs, recycleOption)
                End If
            Else
                If pathInfo.HasFlag(PathEnum.IsFile) Then
                    File.Delete(path)
                ElseIf pathInfo.HasFlag(PathEnum.IsDirectory) Then
                    BackgroundProgress.bwFolderOperations.RunWorkerAsync({"delete", path})
                    BackgroundProgress.ShowDialog()
                End If
            End If
        Catch ex As OperationCanceledException ' ignore user cancellation
        Catch ex As UnauthorizedAccessException When Not WalkmanLib.IsAdmin()
            Select Case WalkmanLib.CustomMsgBox(ex.Message, cMBbRelaunch, cMBbRunSysTool, cMBbCancel, MsgBoxStyle.Exclamation, cMBTitle, ownerForm:=PropertiesDotNet)
                Case cMBbRelaunch
                    PropertiesDotNet.RestartAsAdmin()
                Case cMBbRunSysTool
                    WalkmanLib.RunAsAdmin("cmd", "/c del """ & path & """ & pause")
                    Threading.Thread.Sleep(500)
            End Select
        Catch ex As IOException When Win32FromHResult(ex.HResult) = shareViolation
            If MsgBox("File """ & path & """ is in use! Open Handle Manager?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                HandleManager.Show(PropertiesDotNet)
                HandleManager.Activate()
            End If
        Catch ex As Exception
            PropertiesDotNet.ErrorParser(ex)
        End Try
    End Sub
    
    Shared Sub CreateShortcut(sourcePath As String, targetPath As String)
        Try
            If IsFileOrDirectory(targetPath).HasFlag(PathEnum.Exists) AndAlso sourcePath <> targetPath AndAlso _
                    MsgBox("Target """ & targetPath & """ already exists! Are you sure you want to overwrite the shortcut's Target Path?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
            
            Dim newShortcutPath As String = WalkmanLib.CreateShortcut(targetPath, sourcePath)
            
            If MsgBox("Show properties for created Shortcut?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                PropertiesDotNet.lblLocation.Text = newShortcutPath
            End If
        Catch ex As UnauthorizedAccessException When Not WalkmanLib.IsAdmin()
            Select Case WalkmanLib.CustomMsgBox(ex.Message, cMBbRelaunch, cMBbRunSysTool, cMBbCancel, MsgBoxStyle.Exclamation, cMBTitle, ownerForm:=PropertiesDotNet)
                Case cMBbRelaunch
                    PropertiesDotNet.RestartAsAdmin()
                Case cMBbRunSysTool
                    Dim scriptPath As String = Environment.GetEnvironmentVariable("temp") & Path.DirectorySeparatorChar & "createShortcut.vbs"
                    Using writer As StreamWriter = New StreamWriter(File.Open(scriptPath, FileMode.Create))
                        writer.WriteLine("Set lnk = WScript.CreateObject(""WScript.Shell"").CreateShortcut(""" & targetPath & """)")
                        writer.WriteLine("lnk.TargetPath = """ & sourcePath & """")
                        writer.WriteLine("lnk.Save")
                    End Using
                    
                    WalkmanLib.RunAsAdmin("wscript", scriptPath)
                    If MsgBox("Show properties for created Shortcut?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                        PropertiesDotNet.lblLocation.Text = targetPath
                    End If
            End Select
        Catch ex As Exception
            PropertiesDotNet.ErrorParser(ex)
        End Try
    End Sub
    
    Shared Sub CreateSymlink(sourcePath As String, targetPath As String)
        Try
            If IsFileOrDirectory(targetPath).HasFlag(PathEnum.Exists) AndAlso sourcePath <> targetPath Then
                Select Case MsgBox("Target """ & targetPath & """ already exists! Remove first?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNoCancel)
                    Case MsgBoxResult.Yes
                        Delete(targetPath, False, Nothing)
                    Case MsgBoxResult.Cancel
                        Exit Sub
                End Select
            End If
            
            Dim pathInfo = IsFileOrDirectory(sourcePath)
            If pathInfo.HasFlag(PathEnum.IsFile) Then
                WalkmanLib.CreateSymLink(targetPath, sourcePath, SymbolicLinkType.File)
            ElseIf pathInfo.HasFlag(PathEnum.IsDirectory) Then
                WalkmanLib.CreateSymLink(targetPath, sourcePath, SymbolicLinkType.Directory)
            End If
            
            If MsgBox("Show properties for created Symlink?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                PropertiesDotNet.lblLocation.Text = targetPath
            End If
        Catch ex As UnauthorizedAccessException When Not WalkmanLib.IsAdmin()
            Select Case WalkmanLib.CustomMsgBox(ex.Message, cMBbRelaunch, cMBbRunSysTool, cMBbCancel, MsgBoxStyle.Exclamation, cMBTitle, ownerForm:=PropertiesDotNet)
                Case cMBbRelaunch
                    PropertiesDotNet.RestartAsAdmin()
                Case cMBbRunSysTool
                    Dim pathInfo = IsFileOrDirectory(sourcePath)
                    If pathInfo.HasFlag(PathEnum.IsFile) Then
                        WalkmanLib.RunAsAdmin("cmd", "/c mklink """ & targetPath & """ """ & sourcePath & """ & pause")
                    ElseIf pathInfo.HasFlag(PathEnum.IsDirectory)
                        WalkmanLib.RunAsAdmin("cmd", "/c mklink /d """ & targetPath & """ """ & sourcePath & """ & pause")
                    End If
                    
                    If MsgBox("Show properties for created Symlink?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                        PropertiesDotNet.lblLocation.Text = targetPath
                    End If
            End Select
        Catch ex As Exception
            PropertiesDotNet.ErrorParser(ex)
        End Try
    End Sub
    
    Shared Sub CreateHardlink(sourcePath As String, targetPath As String)
        Try
            If IsFileOrDirectory(targetPath).HasFlag(PathEnum.Exists) AndAlso sourcePath <> targetPath Then
                Select Case MsgBox("Target """ & targetPath & """ already exists! Remove first?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNoCancel)
                    Case MsgBoxResult.Yes
                        Delete(targetPath, False, Nothing)
                    Case MsgBoxResult.Cancel
                        Exit Sub
                End Select
            End If
            
            WalkmanLib.CreateHardLink(targetPath, sourcePath)
            
            If MsgBox("Show properties for created Hardlink?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                PropertiesDotNet.lblLocation.Text = targetPath
            End If
        Catch ex As UnauthorizedAccessException When Not WalkmanLib.IsAdmin()
            Select Case WalkmanLib.CustomMsgBox(ex.Message, cMBbRelaunch, cMBbRunSysTool, cMBbCancel, MsgBoxStyle.Exclamation, cMBTitle, ownerForm:=PropertiesDotNet)
                Case cMBbRelaunch
                    PropertiesDotNet.RestartAsAdmin()
                Case cMBbRunSysTool
                    WalkmanLib.RunAsAdmin("cmd", "/c mklink /h """ & targetPath & """ """ & sourcePath & """ & pause")
                    
                    If MsgBox("Show properties for created Hardlink?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                        PropertiesDotNet.lblLocation.Text = targetPath
                    End If
            End Select
        Catch ex As Exception
            PropertiesDotNet.ErrorParser(ex)
        End Try
    End Sub
    
    Shared Function SetAttribute(path As String, attribute As FileAttributes, addOrRemove As Boolean) As Boolean
        Try
            Dim fileAttributes As FileAttributes
            fileAttributes = GetAttributes(path)
            If addOrRemove Then
                fileAttributes = fileAttributes Or attribute
            Else ' Or (C# |) adds an attribute, And Not (C# & ~) removes an attribute
                fileAttributes = fileAttributes And Not attribute
            End If
            
            SetAttributes(path, fileAttributes)
            Return True
        Catch ex As UnauthorizedAccessException When _
                Not WalkmanLib.IsAdmin() AndAlso
                Not attribute.HasFlag(FileAttributes.Compressed) AndAlso
                Not attribute.HasFlag(FileAttributes.Encrypted) AndAlso
                Not attribute.HasFlag(FileAttributes.Temporary) AndAlso
                Not attribute.HasFlag(FileAttributes.ReparsePoint) AndAlso
                Not attribute.HasFlag(FileAttributes.SparseFile)
            Select Case WalkmanLib.CustomMsgBox(ex.Message, cMBbRelaunch, cMBbRunSysTool, cMBbCancel, MsgBoxStyle.Exclamation, cMBTitle, ownerForm:=PropertiesDotNet)
                Case cMBbRelaunch
                    PropertiesDotNet.RestartAsAdmin()
                Case cMBbRunSysTool
                    SetAttributeAsAdmin(path, attribute, addOrRemove)
                    Threading.Thread.Sleep(100)
            End Select
        Catch ex As IOException When Win32FromHResult(ex.HResult) = shareViolation
            If MsgBox("File """ & path & """ is in use! Open Handle Manager?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                HandleManager.Show(PropertiesDotNet)
                HandleManager.Activate()
            End If
        Catch ex As Exception
            PropertiesDotNet.ErrorParser(ex)
        End Try
        Return False
    End Function
    
    Private Shared Sub SetAttributeAsAdmin(path As String, attribute As FileAttributes, addOrRemove As Boolean)
        Select Case attribute
            Case FileAttributes.ReadOnly
                WalkmanLib.RunAsAdmin("attrib", IIf(addOrRemove, "+", "-") & "r """ & path & """")
            Case FileAttributes.Hidden
                WalkmanLib.RunAsAdmin("attrib", IIf(addOrRemove, "+", "-") & "h """ & path & """")
            Case FileAttributes.System
                WalkmanLib.RunAsAdmin("attrib", IIf(addOrRemove, "+", "-") & "s """ & path & """")
            Case FileAttributes.Archive
                WalkmanLib.RunAsAdmin("attrib", IIf(addOrRemove, "+", "-") & "a """ & path & """")
            Case FileAttributes.NotContentIndexed
                WalkmanLib.RunAsAdmin("attrib", IIf(addOrRemove, "+", "-") & "i """ & path & """")
            Case FileAttributes.Offline
                WalkmanLib.RunAsAdmin("attrib", IIf(addOrRemove, "+", "-") & "o """ & path & """")
            Case FileAttributes.NoScrubData
                WalkmanLib.RunAsAdmin("attrib", IIf(addOrRemove, "+", "-") & "x """ & path & """")
            Case FileAttributes.IntegrityStream
                WalkmanLib.RunAsAdmin("attrib", IIf(addOrRemove, "+", "-") & "v """ & path & """")
            Case Else
                Throw New InvalidOperationException("Invalid Attribute specified: " & attribute.ToString())
        End Select
    End Sub
    
    Shared Function GetInput(ByRef input As String, Optional windowTitle As String = Nothing, Optional header As String = Nothing, Optional content As String = Nothing) As DialogResult
        If OokiiDialogsLoaded() Then
            Dim ooInput = New Ookii.Dialogs.InputDialog With {
                .Input = input,
                .WindowTitle = windowTitle,
                .MainInstruction = header,
                .Content = content
            }
            
            Dim returnResult = ooInput.ShowDialog(PropertiesDotNet)
            input = ooInput.Input
            Return returnResult
        Else
            Dim inputBoxPrompt As String = header
            If content IsNot Nothing Then
                inputBoxPrompt &= vbNewLine & content
            End If
            
            input = InputBox(inputBoxPrompt, windowTitle, input)
            If String.IsNullOrEmpty(input) Then
                Return DialogResult.Cancel
            Else
                Return DialogResult.OK
            End If
        End If
    End Function
    
    Private Shared Function OokiiDialogsLoaded() As Boolean
        Try
            OokiiDialogsLoadedDelegate()
            Return True
        Catch ex As FileNotFoundException When ex.FileName.StartsWith("PropertiesDotNet-Ookii.Dialogs")
            Return False
        Catch ex As Exception
            MsgBox("Unexpected error loading PropertiesDotNet-Ookii.Dialogs.dll!" & vbNewLine & vbNewLine & ex.Message, MsgBoxStyle.Exclamation)
            Return False
        End Try
    End Function
    Private Shared Sub OokiiDialogsLoadedDelegate() ' because calling a not found class will fail the caller of the method not directly in the method
        Dim test = Ookii.Dialogs.TaskDialogIcon.Information
    End Sub
End Class
