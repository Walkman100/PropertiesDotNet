Imports System
Imports System.Diagnostics
Imports System.IO
Imports System.Windows.Forms

Public Class Operations
    Enum TimeChangeEnum
        Creation = 1   ' have to give them values,
        LastAccess = 2 '  so the "Case ... And ..."
        LastWrite = 3  '  below works.
    End Enum

    Shared Sub SetSelectDateDialogValue(path As String, useUTC As Boolean, type As TimeChangeEnum)
        Try
            Select Case DirectCast(type, Integer)
                Case TimeChangeEnum.Creation And CType(useUTC, Integer)
                    SelectDateDialog.dateTimePicker.Value = File.GetCreationTimeUtc(path)
                Case TimeChangeEnum.Creation
                    SelectDateDialog.dateTimePicker.Value = File.GetCreationTime(path)
                Case TimeChangeEnum.LastAccess And CType(useUTC, Integer)
                    SelectDateDialog.dateTimePicker.Value = File.GetLastAccessTimeUtc(path)
                Case TimeChangeEnum.LastAccess
                    SelectDateDialog.dateTimePicker.Value = File.GetLastAccessTime(path)
                Case TimeChangeEnum.LastWrite And CType(useUTC, Integer)
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
            Select Case DirectCast(type, Integer)
                Case TimeChangeEnum.Creation And CType(useUTC, Integer)
                    File.SetCreationTimeUtc  (path, time)
                Case TimeChangeEnum.Creation
                    File.SetCreationTime     (path, time)
                Case TimeChangeEnum.LastAccess And CType(useUTC, Integer)
                    File.SetLastAccessTimeUtc(path, time)
                Case TimeChangeEnum.LastAccess
                    File.SetLastAccessTime   (path, time)
                Case TimeChangeEnum.LastWrite And CType(useUTC, Integer)
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

            PropertiesDotNet.LoadNew(fileProperties.FullName)
        Catch ex As UnauthorizedAccessException When Not WalkmanLib.IsAdmin()
            Select Case WalkmanLib.CustomMsgBox(ex.Message, Settings.GetTheme(), cMBTitle, cMBbRelaunch, cMBbRunSysTool, cMBbCancel, MessageBoxIcon.Exclamation, ownerForm:=PropertiesDotNet)
                Case cMBbRelaunch
                    PropertiesDotNet.RestartAsAdmin()
                Case cMBbRunSysTool
                    If WalkmanLib.RunAsAdmin("cmd", "/c ren """ & sourcePath & """ """ & targetName & """ && pause") AndAlso
                            MessageBox("Read new location?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        PropertiesDotNet.LoadNew(fullTargetName)
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
                    My.Computer.FileSystem.MoveFile(sourcePath, targetPath, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs)
                ElseIf pathInfo.HasFlag(PathEnum.IsDirectory) Then
                    My.Computer.FileSystem.MoveDirectory(sourcePath, targetPath, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs)
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

            PropertiesDotNet.LoadNew(targetPath)
        Catch ex As OperationCanceledException ' ignore user cancellation
        Catch ex As UnauthorizedAccessException When Not WalkmanLib.IsAdmin()
            Select Case WalkmanLib.CustomMsgBox(ex.Message, Settings.GetTheme(), cMBTitle, cMBbRelaunch, cMBbRunSysTool, cMBbCancel, MessageBoxIcon.Exclamation, ownerForm:=PropertiesDotNet)
                Case cMBbRelaunch
                    PropertiesDotNet.RestartAsAdmin()
                Case cMBbRunSysTool
                    If WalkmanLib.RunAsAdmin("cmd", "/c move """ & sourcePath & """ """ & targetPath & """ & pause") AndAlso
                            MessageBox("Read new location?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        PropertiesDotNet.LoadNew(targetPath)
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
                    My.Computer.FileSystem.CopyFile(sourcePath, targetPath, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs)
                ElseIf pathInfo.HasFlag(PathEnum.IsDirectory) Then
                    My.Computer.FileSystem.CopyDirectory(sourcePath, targetPath, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs)
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
                        targetStream = File.Open(targetPath, FileMode.Create, FileAccess.Write)

                        WalkmanLib.StreamCopy(sourceStream, targetStream, "Copying """ & sourcePath & """ to """ & targetPath & """...",
                                              "File Copy", Sub(s, e)
                                                               If e.Error IsNot Nothing Then
                                                                   PropertiesDotNet.ErrorParser(e.Error)
                                                               ElseIf MessageBox("Read new location?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                                                   PropertiesDotNet.LoadNew(targetPath)
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
                PropertiesDotNet.LoadNew(targetPath)
            End If
        Catch ex As OperationCanceledException ' ignore user cancellation
        Catch ex As UnauthorizedAccessException When Not WalkmanLib.IsAdmin()
            Select Case WalkmanLib.CustomMsgBox(ex.Message, Settings.GetTheme(), cMBTitle, cMBbRelaunch, cMBbRunSysTool, cMBbCancel, MessageBoxIcon.Exclamation, ownerForm:=PropertiesDotNet)
                Case cMBbRelaunch
                    PropertiesDotNet.RestartAsAdmin()
                Case cMBbRunSysTool
                    If WalkmanLib.RunAsAdmin("xcopy", "/F /H /K """ & sourcePath & """ """ & targetPath & "*""") AndAlso
                            MessageBox("Read new location?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        PropertiesDotNet.LoadNew(targetPath)
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

    Shared Sub Delete(path As String, Optional useShell As Boolean = False, Optional recycleOption As Microsoft.VisualBasic.FileIO.RecycleOption =
                                                                                                      Microsoft.VisualBasic.FileIO.RecycleOption.DeletePermanently)
        Try
            Dim pathInfo = WalkmanLib.IsFileOrDirectory(path)
            If useShell Then
                If pathInfo.HasFlag(PathEnum.IsFile) Then
                    My.Computer.FileSystem.DeleteFile(path, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, recycleOption)
                ElseIf pathInfo.HasFlag(PathEnum.IsDirectory) Then
                    My.Computer.FileSystem.DeleteDirectory(path, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, recycleOption)
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
            Select Case WalkmanLib.CustomMsgBox(ex.Message, Settings.GetTheme(), cMBTitle, cMBbRelaunch, cMBbRunSysTool, cMBbCancel, MessageBoxIcon.Exclamation, ownerForm:=PropertiesDotNet)
                Case cMBbRelaunch
                    PropertiesDotNet.RestartAsAdmin()
                Case cMBbRunSysTool
                    If WalkmanLib.RunAsAdmin("cmd", "/c del """ & path & """ & pause") Then
                        Threading.Thread.Sleep(500)
                    End If
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
                PropertiesDotNet.LoadNew(newShortcutPath)
            End If
        Catch ex As UnauthorizedAccessException When Not WalkmanLib.IsAdmin()
            Select Case WalkmanLib.CustomMsgBox(ex.Message, Settings.GetTheme(), cMBTitle, cMBbRelaunch, cMBbRunSysTool, cMBbCancel, MessageBoxIcon.Exclamation, ownerForm:=PropertiesDotNet)
                Case cMBbRelaunch
                    PropertiesDotNet.RestartAsAdmin()
                Case cMBbRunSysTool
                    Dim scriptPath As String = Environment.GetEnvironmentVariable("temp") & Path.DirectorySeparatorChar & "createShortcut.vbs"
                    Using writer As New StreamWriter(File.Open(scriptPath, FileMode.Create))
                        writer.WriteLine("Set lnk = WScript.CreateObject(""WScript.Shell"").CreateShortcut(""" & targetPath & """)")
                        writer.WriteLine("lnk.TargetPath = """ & sourcePath & """")
                        writer.WriteLine("lnk.Save")
                    End Using

                    If WalkmanLib.RunAsAdmin("wscript", scriptPath) AndAlso
                            MessageBox("Show properties for created Shortcut?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        PropertiesDotNet.LoadNew(targetPath)
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
                PropertiesDotNet.LoadNew(targetPath)
            End If
        Catch ex As UnauthorizedAccessException When Not WalkmanLib.IsAdmin()
            Select Case WalkmanLib.CustomMsgBox(ex.Message, Settings.GetTheme(), cMBTitle, cMBbRelaunch, cMBbRunSysTool, cMBbCancel, MessageBoxIcon.Exclamation, ownerForm:=PropertiesDotNet)
                Case cMBbRelaunch
                    PropertiesDotNet.RestartAsAdmin()
                Case cMBbRunSysTool
                    Dim pathInfo = WalkmanLib.IsFileOrDirectory(sourcePath)
                    Dim arguments As String = "/c mklink " & If(pathInfo.HasFlag(PathEnum.IsFile), """", "/d """) & targetPath & """ """ & sourcePath & """ & pause"

                    If WalkmanLib.RunAsAdmin("cmd", arguments) AndAlso
                            MessageBox("Show properties for created Symlink?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        PropertiesDotNet.LoadNew(targetPath)
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
                PropertiesDotNet.LoadNew(targetPath)
            End If
        Catch ex As UnauthorizedAccessException When Not WalkmanLib.IsAdmin()
            Select Case WalkmanLib.CustomMsgBox(ex.Message, Settings.GetTheme(), cMBTitle, cMBbRelaunch, cMBbRunSysTool, cMBbCancel, MessageBoxIcon.Exclamation, ownerForm:=PropertiesDotNet)
                Case cMBbRelaunch
                    PropertiesDotNet.RestartAsAdmin()
                Case cMBbRunSysTool
                    If WalkmanLib.RunAsAdmin("cmd", "/c mklink /h """ & targetPath & """ """ & sourcePath & """ & pause") AndAlso
                            MessageBox("Show properties for created Hardlink?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        PropertiesDotNet.LoadNew(targetPath)
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
                PropertiesDotNet.LoadNew(targetPath)
            End If
        Catch ex As UnauthorizedAccessException When Not WalkmanLib.IsAdmin()
            Select Case WalkmanLib.CustomMsgBox(ex.Message, Settings.GetTheme(), cMBTitle, cMBbRelaunch, cMBbRunSysTool, cMBbCancel, MessageBoxIcon.Exclamation, ownerForm:=PropertiesDotNet)
                Case cMBbRelaunch
                    PropertiesDotNet.RestartAsAdmin()
                Case cMBbRunSysTool
                    If WalkmanLib.RunAsAdmin("cmd", "/c mklink /j """ & targetPath & """ """ & sourcePath & """ & pause") AndAlso
                            MessageBox("Show properties for created Junction?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        PropertiesDotNet.LoadNew(targetPath)
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
            Select Case WalkmanLib.CustomMsgBox(ex.Message, Settings.GetTheme(), cMBTitle, cMBbRelaunch, cMBbRunSysTool, cMBbCancel, MessageBoxIcon.Exclamation, ownerForm:=PropertiesDotNet)
                Case cMBbRelaunch
                    PropertiesDotNet.RestartAsAdmin()
                Case cMBbRunSysTool
                    If SetAttributeAsAdmin(path, attribute, addOrRemove) Then
                        Threading.Thread.Sleep(100)
                    End If
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

    Private Shared Function SetAttributeAsAdmin(path As String, attribute As FileAttributes, addOrRemove As Boolean) As Boolean
        Select Case attribute
            Case FileAttributes.ReadOnly
                Return WalkmanLib.RunAsAdmin("attrib", If(addOrRemove, "+", "-") & "r """ & path & """ /l")
            Case FileAttributes.Hidden
                Return WalkmanLib.RunAsAdmin("attrib", If(addOrRemove, "+", "-") & "h """ & path & """ /l")
            Case FileAttributes.System
                Return WalkmanLib.RunAsAdmin("attrib", If(addOrRemove, "+", "-") & "s """ & path & """ /l")
            Case FileAttributes.Archive
                Return WalkmanLib.RunAsAdmin("attrib", If(addOrRemove, "+", "-") & "a """ & path & """ /l")
            Case FileAttributes.NotContentIndexed
                Return WalkmanLib.RunAsAdmin("attrib", If(addOrRemove, "+", "-") & "i """ & path & """ /l")
            Case FileAttributes.Offline
                Return WalkmanLib.RunAsAdmin("attrib", If(addOrRemove, "+", "-") & "o """ & path & """ /l")
            Case FileAttributes.NoScrubData
                Return WalkmanLib.RunAsAdmin("attrib", If(addOrRemove, "+", "-") & "x """ & path & """ /l")
            Case FileAttributes.IntegrityStream
                Return WalkmanLib.RunAsAdmin("attrib", If(addOrRemove, "+", "-") & "v """ & path & """ /l")
            Case Else
                Throw New InvalidOperationException("Invalid Attribute specified: " & attribute.ToString())
        End Select
    End Function

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
                               Optional icon As MessageBoxIcon = 0, Optional title As String = Nothing) As DialogResult
        If title Is Nothing Then
            title = Application.ProductName
        End If

        ' if running on a separate thread then settings isn't loaded. doesn't matter, we can just load, as all settings are immediately saved
        If Not Settings.Loaded Then Settings.Init()

        Return WalkmanLib.CustomMsgBox(text, Settings.GetTheme(), title, buttons, icon, WinVersionStyle.Win10, PropertiesDotNet)
    End Function

    Shared Function GetInput(ByRef input As String, Optional windowTitle As String = Nothing, Optional header As String = Nothing, Optional content As String = Nothing) As DialogResult
        If Not Settings.Loaded Then Settings.Init()
        Return WalkmanLib.InputDialog(input, Settings.GetTheme(), header, windowTitle, content, ownerForm:=PropertiesDotNet)
    End Function
End Class
