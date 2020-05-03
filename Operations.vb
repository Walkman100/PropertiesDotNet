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
End Class
