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
        Creation = 1   ' have to give them values
        LastAccess = 2 ' so the Case ... And ...
        LastWrite = 3  ' below works.
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
                Case TimeChangeEnum.Creation
                    SetLastAccessTime   (path, time)
                Case TimeChangeEnum.LastWrite And useUTC
                    SetLastWriteTimeUtc (path, time)
                Case TimeChangeEnum.Creation
                    SetLastWriteTime    (path, time)
            End Select
        Catch ex As Exception
            PropertiesDotNet.ErrorParser(ex)
        End Try
    End Sub
    
    Shared Sub Rename(sourcePath As String, targetName As String)
        Dim fileProperties As New FileInfo(sourcePath)
        Try
            fileProperties.MoveTo(targetName)
            
            PropertiesDotNet.lblLocation.Text = fileProperties.FullName
        Catch ex As UnauthorizedAccessException When MsgBox(ex.Message & vbNewLine & vbNewLine &
          "Try launching a system tool as admin?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Access denied!") = MsgBoxResult.Yes
            WalkmanLib.RunAsAdmin("cmd", "/c ren """ & sourcePath & """ """ & targetName & """ && pause")
            If MsgBox("Read new location?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                PropertiesDotNet.lblLocation.Text = fileProperties.DirectoryName & "\" & targetName
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
                Dim fileProperties As New FileInfo(sourcePath)
                fileProperties.MoveTo(targetPath)
            End If
            
            PropertiesDotNet.lblLocation.Text = targetPath
        Catch ex As UnauthorizedAccessException When MsgBox(ex.Message & vbNewLine & vbNewLine &
          "Try launching a system tool as admin?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Access denied!") = MsgBoxResult.Yes
            WalkmanLib.RunAsAdmin("cmd", "/c move """ & sourcePath & """ """ & targetPath & """ & pause")
            If MsgBox("Read new location?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                PropertiesDotNet.lblLocation.Text = targetPath
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
                    Dim fileProperties As New FileInfo(sourcePath)
                    fileProperties.CopyTo(targetPath)
                ElseIf pathInfo.HasFlag(PathEnum.IsDirectory) Then
                    BackgroundProgress.bwFolderOperations.RunWorkerAsync({"copy", sourcePath, targetPath})
                    BackgroundProgress.ShowDialog()
                End If
            End If
            
            If MsgBox("Read new location?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                PropertiesDotNet.lblLocation.Text = targetPath
            End If
        Catch ex As UnauthorizedAccessException When MsgBox(ex.Message & vbNewLine & vbNewLine &
          "Try launching a system tool as admin?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Access denied!") = MsgBoxResult.Yes
            WalkmanLib.RunAsAdmin("xcopy", "/F /H /K """ & sourcePath & """ """ & targetPath & "*""")
            If MsgBox("Read new location?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                PropertiesDotNet.lblLocation.Text = targetPath
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
                    Dim fileProperties As New FileInfo(path)
                    fileProperties.Delete()
                ElseIf pathInfo.HasFlag(PathEnum.IsDirectory) Then
                    BackgroundProgress.bwFolderOperations.RunWorkerAsync({"delete", path})
                    BackgroundProgress.ShowDialog()
                End If
            End If
            Application.Exit()
        Catch ex As UnauthorizedAccessException When MsgBox(ex.Message & vbNewLine & vbNewLine &
          "Try launching a system tool as admin?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Access denied!") = MsgBoxResult.Yes
            WalkmanLib.RunAsAdmin("cmd", "/c del """ & path & """ & pause")
        Catch ex As Exception
            PropertiesDotNet.ErrorParser(ex)
        End Try
    End Sub
    
    Shared Sub CreateShortcut(sourcePath As String, targetPath As String)
        Try
            Dim newShortcutPath As String = WalkmanLib.CreateShortcut(targetPath, sourcePath)
            
            If MsgBox("Show properties for created Shortcut?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                PropertiesDotNet.lblLocation.Text = newShortcutPath
            End If
        Catch ex As UnauthorizedAccessException When MsgBox(ex.Message & vbNewLine & vbNewLine &
          "Try launching a system tool as admin?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Access denied!") = MsgBoxResult.Yes
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
        Catch ex As Exception
            PropertiesDotNet.ErrorParser(ex)
        End Try
    End Sub
    
    Shared Sub CreateSymlink(sourcePath As String, targetPath As String)
        Try
            Dim pathInfo = IsFileOrDirectory(sourcePath)
            If pathInfo.HasFlag(PathEnum.IsFile) Then
                WalkmanLib.CreateSymLink(targetPath, sourcePath, SymbolicLinkType.File)
            ElseIf pathInfo.HasFlag(PathEnum.IsDirectory) Then
                WalkmanLib.CreateSymLink(targetPath, sourcePath, SymbolicLinkType.Directory)
            End If
            
            If MsgBox("Show properties for created Symlink?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                PropertiesDotNet.lblLocation.Text = targetPath
            End If
        Catch ex As UnauthorizedAccessException When MsgBox(ex.Message & vbNewLine & vbNewLine &
          "Try launching a system tool as admin?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Access denied!") = MsgBoxResult.Yes
            Dim pathInfo = IsFileOrDirectory(sourcePath)
            If pathInfo.HasFlag(PathEnum.IsFile) Then
                WalkmanLib.RunAsAdmin("cmd", "/c mklink """ & targetPath & """ """ & sourcePath & """ & pause")
            ElseIf pathInfo.HasFlag(PathEnum.IsDirectory)
                WalkmanLib.RunAsAdmin("cmd", "/c mklink /d """ & targetPath & """ """ & sourcePath & """ & pause")
            End If
            
            If MsgBox("Show properties for created Symlink?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                PropertiesDotNet.lblLocation.Text = targetPath
            End If
        Catch ex As Exception
            PropertiesDotNet.ErrorParser(ex)
        End Try
    End Sub
End Class
