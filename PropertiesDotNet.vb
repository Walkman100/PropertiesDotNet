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
    
    Sub CheckData Handles chkUTC.CheckedChanged
        'Read-Only attributes:
        Dim FileProperties As New FileInfo(lblLocation.Text)
        lblName.Text = FileProperties.Name
        lblExtension.Text = FileProperties.Extension
        lblDirectory.Text = FileProperties.DirectoryName
        lblFullPath.Text = FileProperties.FullName
        lblSize.Text = FileProperties.Length
        If chkUTC.Checked Then
            lblCreationTime.Text = GetCreationTime(lblLocation.Text)
            lblLastAccessTime.Text = GetLastAccessTime(lblLocation.Text)
            lblLastWriteTime.Text = GetLastWriteTime(lblLocation.Text)
        Else
            lblCreationTime.Text = GetCreationTimeUtc(lblLocation.Text)
            lblLastAccessTime.Text = GetLastAccessTimeUtc(lblLocation.Text)
            lblLastWriteTime.Text = GetLastWriteTimeUtc(lblLocation.Text)
        End If
        
        'Changeable attributes:
        chkHidden.Checked = GetAttributes(lblLocation.Text).HasFlag(FileAttributes.Hidden)
        chkSystem.Checked = GetAttributes(lblLocation.Text).HasFlag(FileAttributes.System)
'        GetAttributes(lblLocation.Text).HasFlag(FileAttributes.Archive)
'        GetAttributes(lblLocation.Text).HasFlag(FileAttributes.Compressed)
'        GetAttributes(lblLocation.Text).HasFlag(FileAttributes.Encrypted)
'        GetAttributes(lblLocation.Text).HasFlag(FileAttributes.Hidden)
'        GetAttributes(lblLocation.Text).HasFlag(FileAttributes.IntegrityStream)
'        GetAttributes(lblLocation.Text).HasFlag(FileAttributes.NoScrubData)
'        GetAttributes(lblLocation.Text).HasFlag(FileAttributes.NotContentIndexed)
'        GetAttributes(lblLocation.Text).HasFlag(FileAttributes.Offline)
'        GetAttributes(lblLocation.Text).HasFlag(FileAttributes.ReadOnly)
'        GetAttributes(lblLocation.Text).HasFlag(FileAttributes.ReparsePoint)
'        GetAttributes(lblLocation.Text).HasFlag(FileAttributes.SparseFile)
'        GetAttributes(lblLocation.Text).HasFlag(FileAttributes.Temporary)
        'FileProperties.Decrypt
    End Sub
    
    Sub chkHidden_Click() Handles chkHidden.Click
        If chkHidden.Checked Then
            SetAttributes(lblLocation.Text, FileAttribute.Hidden)
        Else
            SetAttributes(lblLocation.Text, FileAttributes.Normal)
        End If
        CheckData()
    End Sub
    
    Sub chkSystem_Click() Handles chkSystem.Click
        If chkSystem.Checked Then
            SetAttributes(lblLocation.Text, FileAttribute.System)
        Else
            SetAttributes(lblLocation.Text, FileAttribute.Normal)
        End If
        CheckData()
    End Sub
End Class
