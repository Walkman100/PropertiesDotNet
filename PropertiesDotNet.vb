Imports System.IO
Imports System.IO.File

Public Class PropertiesDotNet
    'File Name, rename button, copy file name
    'file path, copy file path, copy full file path
    'icon: picturebox
    'date whatevered
    'sizes
    'attributes
    'default open with?
    'set default open with
    'launch
    'launch with [..]
    'ok, cancel, apply
    
    Sub PropertiesDotNet_Load(sender As Object, e As EventArgs) Handles Me.Load
        For Each s As String In My.Application.CommandLineArgs
            lblLocation.Text &= s
        Next
        CheckData()
    End Sub
    
    Sub CheckData
        chkHidden.Checked = GetAttributes(lblLocation.Text).HasFlag(FileAttributes.Hidden)
        chkSystem.Checked = GetAttributes(lblLocation.Text).HasFlag(FileAttributes.System)
    End Sub
    
    Sub chkHidden_CheckedChanged() Handles chkHidden.Click
        If chkHidden.Checked Then
            SetAttributes(lblLocation.Text, FileAttribute.Hidden)
        Else
            SetAttributes(lblLocation.Text, FileAttributes.Normal)
        End If
        CheckData()
    End Sub
    
    Sub chkSystem_CheckedChanged() Handles chkSystem.Click
        If chkSystem.Checked Then
            SetAttributes(lblLocation.Text, FileAttribute.System)
        Else
            SetAttributes(lblLocation.Text, FileAttribute.Normal)
        End If
        CheckData()
    End Sub
End Class
