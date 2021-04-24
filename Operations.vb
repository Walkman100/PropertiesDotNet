Imports System
Imports System.Diagnostics
Imports System.IO
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

Public Class Operations
    Enum TimeChangeEnum
        Creation = 1   ' have to give them values,
        LastAccess = 2 '  so the "Case ... And ..."
        LastWrite = 3  '  below works.
    End Enum

    Shared Sub SetSelectDateDialogValue(path As String, useUTC As Boolean, type As TimeChangeEnum)
        Try
            Select Case type
                Case TimeChangeEnum.Creation And useUTC
                    SelectDateDialog.dateTimePicker.Value = File.GetCreationTimeUtc(path)
                Case TimeChangeEnum.Creation
                    SelectDateDialog.dateTimePicker.Value = File.GetCreationTime(path)
                Case TimeChangeEnum.LastAccess And useUTC
                    SelectDateDialog.dateTimePicker.Value = File.GetLastAccessTimeUtc(path)
                Case TimeChangeEnum.LastAccess
                    SelectDateDialog.dateTimePicker.Value = File.GetLastAccessTime(path)
                Case TimeChangeEnum.LastWrite And useUTC
                    SelectDateDialog.dateTimePicker.Value = File.GetLastWriteTimeUtc(path)
                Case TimeChangeEnum.LastWrite
                    SelectDateDialog.dateTimePicker.Value = File.GetLastWriteTime(path)
            End Select
        Catch ex As Exception
            PropertiesDotNet.ErrorParser(ex)
        End Try
    End Sub

    Shared Sub SetTime(path As String, useUTC As Boolean, type As TimeChangeEnum, time As Date)
        Try
            Select Case type
                Case TimeChangeEnum.Creation And useUTC
                    File.SetCreationTimeUtc  (path, time)
                Case TimeChangeEnum.Creation
                    File.SetCreationTime     (path, time)
                Case TimeChangeEnum.LastAccess And useUTC
                    File.SetLastAccessTimeUtc(path, time)
                Case TimeChangeEnum.LastAccess
                    File.SetLastAccessTime   (path, time)
                Case TimeChangeEnum.LastWrite And useUTC
                    File.SetLastWriteTimeUtc (path, time)
                Case TimeChangeEnum.LastWrite
                    File.SetLastWriteTime    (path, time)
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
            If WalkmanLib.IsFileOrDirectory(fullTargetName).HasFlag(PathEnum.Exists) AndAlso sourcePath <> fullTargetName Then
                Select Case MessageBox("Target """ & fullTargetName & """ already exists! Remove first?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation)
                    Case DialogResult.Yes
                        Delete(fullTargetName)
                    Case DialogResult.Cancel
                        Exit Sub
                End Select
            End If

            fileProperties.MoveTo(fullTargetName)

            PropertiesDotNet.lblLocation.Text = fileProperties.FullName
        Catch ex As UnauthorizedAccessException When Not WalkmanLib.IsAdmin()
            Select Case WalkmanLib.CustomMsgBox(ex.Message, cMBTitle, cMBbRelaunch, cMBbRunSysTool, cMBbCancel, MessageBoxIcon.Exclamation, ownerForm:=PropertiesDotNet)
                Case cMBbRelaunch
                    PropertiesDotNet.RestartAsAdmin()
                Case cMBbRunSysTool
                    WalkmanLib.RunAsAdmin("cmd", "/c ren """ & sourcePath & """ """ & targetName & """ && pause")
                    If MessageBox("Read new location?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        PropertiesDotNet.lblLocation.Text = fullTargetName
                    End If
            End Select
        Catch ex As IOException When Win32FromHResult(ex.HResult) = shareViolation
            If MessageBox("File """ & sourcePath & """ is in use! Open Handle Manager?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes Then
                HandleManager(sourcePath)
            End If
        Catch ex As Exception
            PropertiesDotNet.ErrorParser(ex)
        End Try
    End Sub

    Shared Sub Move(sourcePath As String, targetPath As String, useShell As Boolean)
        Try
            If useShell Then
                Dim pathInfo = WalkmanLib.IsFileOrDirectory(sourcePath)
                If pathInfo.HasFlag(PathEnum.IsFile) Then
                    My.Computer.FileSystem.MoveFile(sourcePath, targetPath, FileIO.UIOption.AllDialogs)
                ElseIf pathInfo.HasFlag(PathEnum.IsDirectory) Then
                    My.Computer.FileSystem.MoveDirectory(sourcePath, targetPath, FileIO.UIOption.AllDialogs)
                End If
            Else
                If WalkmanLib.IsFileOrDirectory(targetPath).HasFlag(PathEnum.Exists) AndAlso sourcePath <> targetPath Then
                    Select Case MessageBox("Target """ & targetPath & """ already exists! Remove first?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation)
                        Case DialogResult.Yes
                            Delete(targetPath)
                        Case DialogResult.Cancel
                            Exit Sub
                    End Select
                End If

                File.Move(sourcePath, targetPath)
            End If

            PropertiesDotNet.lblLocation.Text = targetPath
        Catch ex As OperationCanceledException ' ignore user cancellation
        Catch ex As UnauthorizedAccessException When Not WalkmanLib.IsAdmin()
            Select Case WalkmanLib.CustomMsgBox(ex.Message, cMBTitle, cMBbRelaunch, cMBbRunSysTool, cMBbCancel, MessageBoxIcon.Exclamation, ownerForm:=PropertiesDotNet)
                Case cMBbRelaunch
                    PropertiesDotNet.RestartAsAdmin()
                Case cMBbRunSysTool
                    WalkmanLib.RunAsAdmin("cmd", "/c move """ & sourcePath & """ """ & targetPath & """ & pause")
                    If MessageBox("Read new location?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        PropertiesDotNet.lblLocation.Text = targetPath
                    End If
            End Select
        Catch ex As IOException When Win32FromHResult(ex.HResult) = shareViolation
            If MessageBox("File """ & sourcePath & """ is in use! Open Handle Manager?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes Then
                HandleManager(sourcePath)
            End If
        Catch ex As Exception
            PropertiesDotNet.ErrorParser(ex)
        End Try
    End Sub

    Shared Sub Copy(sourcePath As String, targetPath As String, useShell As Boolean)
        Try
            Dim pathInfo = WalkmanLib.IsFileOrDirectory(sourcePath)
            If useShell Then
                If pathInfo.HasFlag(PathEnum.IsFile) Then
                    My.Computer.FileSystem.CopyFile(sourcePath, targetPath, FileIO.UIOption.AllDialogs)
                ElseIf pathInfo.HasFlag(PathEnum.IsDirectory) Then
                    My.Computer.FileSystem.CopyDirectory(sourcePath, targetPath, FileIO.UIOption.AllDialogs)
                End If
            Else
                If pathInfo.HasFlag(PathEnum.IsFile) Then
                    If WalkmanLib.IsFileOrDirectory(targetPath).HasFlag(PathEnum.Exists) AndAlso sourcePath <> targetPath AndAlso
                            MessageBox("Target """ & targetPath & """ already exists! Are you sure you want to overwrite it?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.No Then
                        Exit Sub
                    End If

                    Dim sourceStream As FileStream = Nothing
                    Dim targetStream As FileStream = Nothing
                    Try
                        sourceStream = File.OpenRead(sourcePath)
                        targetStream = File.OpenWrite(targetPath)

                        WalkmanLib.StreamCopy(sourceStream, targetStream, "Copying """ & sourcePath & """ to """ & targetPath & """...",
                                              "File Copy", Sub(s, e)
                                                               If e.Error IsNot Nothing Then
                                                                   PropertiesDotNet.ErrorParser(e.Error)
                                                               ElseIf MessageBox("Read new location?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                                                   PropertiesDotNet.lblLocation.Text = targetPath
                                                                   PropertiesDotNet.CheckData(True)
                                                               End If
                                                           End Sub)
                    Catch
                        If sourceStream IsNot Nothing Then sourceStream.Dispose()
                        If targetStream IsNot Nothing Then targetStream.Dispose()
                        Throw
                    End Try
                ElseIf pathInfo.HasFlag(PathEnum.IsDirectory) Then
                    BackgroundProgress.bwFolderOperations.RunWorkerAsync({"copy", sourcePath, targetPath})
                    BackgroundProgress.ShowDialog()
                End If
            End If

            '       if we do file StreamCopy then don't show message
            If Not (useShell = False AndAlso pathInfo.HasFlag(PathEnum.IsFile)) AndAlso
                    MessageBox("Read new location?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                PropertiesDotNet.lblLocation.Text = targetPath
            End If
        Catch ex As OperationCanceledException ' ignore user cancellation
        Catch ex As UnauthorizedAccessException When Not WalkmanLib.IsAdmin()
            Select Case WalkmanLib.CustomMsgBox(ex.Message, cMBTitle, cMBbRelaunch, cMBbRunSysTool, cMBbCancel, MessageBoxIcon.Exclamation, ownerForm:=PropertiesDotNet)
                Case cMBbRelaunch
                    PropertiesDotNet.RestartAsAdmin()
                Case cMBbRunSysTool
                    WalkmanLib.RunAsAdmin("xcopy", "/F /H /K """ & sourcePath & """ """ & targetPath & "*""")
                    If MessageBox("Read new location?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        PropertiesDotNet.lblLocation.Text = targetPath
                    End If
            End Select
        Catch ex As IOException When Win32FromHResult(ex.HResult) = shareViolation
            If MessageBox("A file is in use! Open Handle Manager on """ & targetPath & """?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes Then
                HandleManager(targetPath)
            Else
                PropertiesDotNet.ErrorParser(ex)
            End If
        Catch ex As Exception
            PropertiesDotNet.ErrorParser(ex)
        End Try
    End Sub

    Shared Sub Delete(path As String, Optional useShell As Boolean = False, Optional recycleOption As FileIO.RecycleOption = FileIO.RecycleOption.DeletePermanently)
        Try
            Dim pathInfo = WalkmanLib.IsFileOrDirectory(path)
            If useShell Then
                If pathInfo.HasFlag(PathEnum.IsFile) Then
                    My.Computer.FileSystem.DeleteFile(path, FileIO.UIOption.AllDialogs, recycleOption)
                ElseIf pathInfo.HasFlag(PathEnum.IsDirectory) Then
                    My.Computer.FileSystem.DeleteDirectory(path, FileIO.UIOption.AllDialogs, recycleOption)
                End If
            Else
                Dim pathAttrs As FileAttributes = File.GetAttributes(path)
                If pathInfo.HasFlag(PathEnum.IsFile) Then
                    File.Delete(path)
                ElseIf pathAttrs.HasFlag(FileAttributes.ReparsePoint) Then
                    Directory.Delete(path)
                ElseIf pathInfo.HasFlag(PathEnum.IsDirectory) Then
                    BackgroundProgress.bwFolderOperations.RunWorkerAsync({"delete", path})
                    BackgroundProgress.ShowDialog()
                End If
            End If
        Catch ex As OperationCanceledException ' ignore user cancellation
        Catch ex As UnauthorizedAccessException When Not WalkmanLib.IsAdmin()
            Select Case WalkmanLib.CustomMsgBox(ex.Message, cMBTitle, cMBbRelaunch, cMBbRunSysTool, cMBbCancel, MessageBoxIcon.Exclamation, ownerForm:=PropertiesDotNet)
                Case cMBbRelaunch
                    PropertiesDotNet.RestartAsAdmin()
                Case cMBbRunSysTool
                    WalkmanLib.RunAsAdmin("cmd", "/c del """ & path & """ & pause")
                    Threading.Thread.Sleep(500)
            End Select
        Catch ex As IOException When Win32FromHResult(ex.HResult) = shareViolation
            If MessageBox("File """ & path & """ is in use! Open Handle Manager?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes Then
                HandleManager(path)
            End If
        Catch ex As Exception
            PropertiesDotNet.ErrorParser(ex)
        End Try
    End Sub

    Shared Sub CreateShortcut(sourcePath As String, targetPath As String)
        Try
            If WalkmanLib.IsFileOrDirectory(targetPath).HasFlag(PathEnum.Exists) AndAlso sourcePath <> targetPath AndAlso
                    MessageBox("Target """ & targetPath & """ already exists! Are you sure you want to overwrite the shortcut's Target Path?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.No Then
                Exit Sub
            End If

            Dim newShortcutPath As String = WalkmanLib.CreateShortcut(targetPath, sourcePath)

            If MessageBox("Show properties for created Shortcut?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                PropertiesDotNet.lblLocation.Text = newShortcutPath
            End If
        Catch ex As UnauthorizedAccessException When Not WalkmanLib.IsAdmin()
            Select Case WalkmanLib.CustomMsgBox(ex.Message, cMBTitle, cMBbRelaunch, cMBbRunSysTool, cMBbCancel, MessageBoxIcon.Exclamation, ownerForm:=PropertiesDotNet)
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
                    If MessageBox("Show properties for created Shortcut?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        PropertiesDotNet.lblLocation.Text = targetPath
                    End If
            End Select
        Catch ex As Exception
            PropertiesDotNet.ErrorParser(ex)
        End Try
    End Sub

    Shared Sub CreateSymlink(sourcePath As String, targetPath As String)
        Try
            If WalkmanLib.IsFileOrDirectory(targetPath).HasFlag(PathEnum.Exists) AndAlso sourcePath <> targetPath Then
                Select Case MessageBox("Target """ & targetPath & """ already exists! Remove first?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation)
                    Case DialogResult.Yes
                        Delete(targetPath)
                    Case DialogResult.Cancel
                        Exit Sub
                End Select
            End If

            Dim pathInfo = WalkmanLib.IsFileOrDirectory(sourcePath)
            WalkmanLib.CreateSymLink(targetPath, sourcePath, pathInfo.HasFlag(PathEnum.IsDirectory))

            If MessageBox("Show properties for created Symlink?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                PropertiesDotNet.lblLocation.Text = targetPath
            End If
        Catch ex As UnauthorizedAccessException When Not WalkmanLib.IsAdmin()
            Select Case WalkmanLib.CustomMsgBox(ex.Message, cMBTitle, cMBbRelaunch, cMBbRunSysTool, cMBbCancel, MessageBoxIcon.Exclamation, ownerForm:=PropertiesDotNet)
                Case cMBbRelaunch
                    PropertiesDotNet.RestartAsAdmin()
                Case cMBbRunSysTool
                    Dim pathInfo = WalkmanLib.IsFileOrDirectory(sourcePath)
                    If pathInfo.HasFlag(PathEnum.IsFile) Then
                        WalkmanLib.RunAsAdmin("cmd", "/c mklink """ & targetPath & """ """ & sourcePath & """ & pause")
                    ElseIf pathInfo.HasFlag(PathEnum.IsDirectory) Then
                        WalkmanLib.RunAsAdmin("cmd", "/c mklink /d """ & targetPath & """ """ & sourcePath & """ & pause")
                    End If

                    If MessageBox("Show properties for created Symlink?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        PropertiesDotNet.lblLocation.Text = targetPath
                    End If
            End Select
        Catch ex As Exception
            PropertiesDotNet.ErrorParser(ex)
        End Try
    End Sub

    Shared Sub CreateHardlink(sourcePath As String, targetPath As String)
        Try
            If WalkmanLib.IsFileOrDirectory(targetPath).HasFlag(PathEnum.Exists) AndAlso sourcePath <> targetPath Then
                Select Case MessageBox("Target """ & targetPath & """ already exists! Remove first?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation)
                    Case DialogResult.Yes
                        Delete(targetPath)
                    Case DialogResult.Cancel
                        Exit Sub
                End Select
            End If

            WalkmanLib.CreateHardLink(targetPath, sourcePath)

            If MessageBox("Show properties for created Hardlink?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                PropertiesDotNet.lblLocation.Text = targetPath
            End If
        Catch ex As UnauthorizedAccessException When Not WalkmanLib.IsAdmin()
            Select Case WalkmanLib.CustomMsgBox(ex.Message, cMBTitle, cMBbRelaunch, cMBbRunSysTool, cMBbCancel, MessageBoxIcon.Exclamation, ownerForm:=PropertiesDotNet)
                Case cMBbRelaunch
                    PropertiesDotNet.RestartAsAdmin()
                Case cMBbRunSysTool
                    WalkmanLib.RunAsAdmin("cmd", "/c mklink /h """ & targetPath & """ """ & sourcePath & """ & pause")

                    If MessageBox("Show properties for created Hardlink?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        PropertiesDotNet.lblLocation.Text = targetPath
                    End If
            End Select
        Catch ex As Exception
            PropertiesDotNet.ErrorParser(ex)
        End Try
    End Sub

    Shared Sub CreateJunction(sourcePath As String, targetPath As String)
        Try
            If WalkmanLib.IsFileOrDirectory(targetPath).HasFlag(PathEnum.Exists) AndAlso sourcePath <> targetPath Then
                Select Case MessageBox("Target """ & targetPath & """ already exists! Remove first?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation)
                    Case DialogResult.Yes
                        Delete(targetPath)
                    Case DialogResult.Cancel
                        Exit Sub
                End Select
            End If

            WalkmanLib.CreateJunction(targetPath, sourcePath, True)

            If MessageBox("Show properties for created Junction?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                PropertiesDotNet.lblLocation.Text = targetPath
            End If
        Catch ex As UnauthorizedAccessException When Not WalkmanLib.IsAdmin()
            Select Case WalkmanLib.CustomMsgBox(ex.Message, cMBTitle, cMBbRelaunch, cMBbRunSysTool, cMBbCancel, MessageBoxIcon.Exclamation, ownerForm:=PropertiesDotNet)
                Case cMBbRelaunch
                    PropertiesDotNet.RestartAsAdmin()
                Case cMBbRunSysTool
                    WalkmanLib.RunAsAdmin("cmd", "/c mklink /j """ & targetPath & """ """ & sourcePath & """ & pause")

                    If MessageBox("Show properties for created Junction?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
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
            fileAttributes = File.GetAttributes(path)
            If addOrRemove Then
                fileAttributes = fileAttributes Or attribute
            Else ' Or (C# |) adds an attribute, And Not (C# & ~) removes an attribute
                fileAttributes = fileAttributes And Not attribute
            End If

            File.SetAttributes(path, fileAttributes)
            Return True
        Catch ex As UnauthorizedAccessException When _
                Not WalkmanLib.IsAdmin() AndAlso
                Not attribute.HasFlag(FileAttributes.Compressed) AndAlso
                Not attribute.HasFlag(FileAttributes.Encrypted) AndAlso
                Not attribute.HasFlag(FileAttributes.Temporary) AndAlso
                Not attribute.HasFlag(FileAttributes.ReparsePoint) AndAlso
                Not attribute.HasFlag(FileAttributes.SparseFile)
            Select Case WalkmanLib.CustomMsgBox(ex.Message, cMBTitle, cMBbRelaunch, cMBbRunSysTool, cMBbCancel, MessageBoxIcon.Exclamation, ownerForm:=PropertiesDotNet)
                Case cMBbRelaunch
                    PropertiesDotNet.RestartAsAdmin()
                Case cMBbRunSysTool
                    SetAttributeAsAdmin(path, attribute, addOrRemove)
                    Threading.Thread.Sleep(100)
            End Select
        Catch ex As IOException When Win32FromHResult(ex.HResult) = shareViolation
            If MessageBox("File """ & path & """ is in use! Open Handle Manager?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes Then
                HandleManager(path)
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

    Public Shared Sub HandleManager(filePath As String)
        Dim walkmanUtilsPath As String = WalkmanLib.GetWalkmanUtilsPath()
        Dim handleManagerPath As String = Path.Combine(walkmanUtilsPath, "HandleManager.exe")

        If Not File.Exists(handleManagerPath) Then
            MessageBox("Could not find HandleManager in WalkmanUtils install!" & Environment.NewLine & Environment.NewLine &
                       "Looking for: " & handleManagerPath, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, "Launching HandleManager")
            Exit Sub
        End If

        Process.Start(handleManagerPath, """" & filePath & """")
    End Sub

    Shared Function MessageBox(text As String, Optional buttons As MessageBoxButtons = 0,
                               Optional icon As MessageBoxIcon = 0, Optional title As String = Nothing,
                               Optional defaultButton As MessageBoxDefaultButton = 0,
                               Optional options As MessageBoxOptions = 0) As DialogResult
        If title Is Nothing Then
            title = Application.ProductName
        End If

        Return Windows.Forms.MessageBox.Show(text, title, buttons, icon, defaultButton, options)
    End Function

    Shared Function GetInput(ByRef input As String, Optional windowTitle As String = Nothing, Optional header As String = Nothing, Optional content As String = Nothing) As DialogResult
        If OokiiDialogsLoaded() Then
            Return OokiiInputBox(input, windowTitle, header, content)
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

    Private Shared Function OokiiInputBox(ByRef input As String, Optional windowTitle As String = Nothing, Optional header As String = Nothing, Optional content As String = Nothing) As DialogResult
        Dim ooInput = New Ookii.Dialogs.InputDialog With {
            .Input = input,
            .WindowTitle = windowTitle,
            .MainInstruction = header,
            .Content = content
        }

        Dim returnResult = ooInput.ShowDialog(PropertiesDotNet)
        input = ooInput.Input
        Return returnResult
    End Function

    Private Shared Function OokiiDialogsLoaded() As Boolean
        Try
            OokiiDialogsLoadedDelegate()
            Return True
        Catch ex As FileNotFoundException When ex.FileName.StartsWith("PropertiesDotNet-Ookii.Dialogs")
            Return False
        Catch ex As Exception
            MessageBox("Unexpected error loading PropertiesDotNet-Ookii.Dialogs.dll!" & Environment.NewLine & Environment.NewLine & ex.Message, 0, MessageBoxIcon.Exclamation)
            Return False
        End Try
    End Function
    Private Shared Sub OokiiDialogsLoadedDelegate() ' because calling a not found class will fail the caller of the method not directly in the method
        Dim test = Ookii.Dialogs.TaskDialogIcon.Information
    End Sub
End Class
