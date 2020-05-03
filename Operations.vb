Public Class Operations
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
End Class
