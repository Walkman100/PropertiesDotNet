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
        chkReadOnly.Checked = GetAttributes(lblLocation.Text).HasFlag(FileAttributes.ReadOnly)
        chkHidden.Checked = GetAttributes(lblLocation.Text).HasFlag(FileAttributes.Hidden)
        chkCompressed.Checked = GetAttributes(lblLocation.Text).HasFlag(FileAttributes.Compressed)
        chkEncrypted.Checked = GetAttributes(lblLocation.Text).HasFlag(FileAttributes.Encrypted)'FileProperties.Decrypt
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
    
    Sub chkHidden_Click() Handles chkHidden.Click
        If chkHidden.Checked Then SetAttributes(lblLocation.Text, GetAttributes(lblLocation.Text) + FileAttributes.Hidden) _
          Else SetAttributes(lblLocation.Text, GetAttributes(lblLocation.Text) - FileAttributes.Hidden)
        CheckData()
    End Sub
    
    Sub chkSystem_Click() Handles chkSystem.Click
        If chkSystem.Checked Then SetAttributes(lblLocation.Text, GetAttributes(lblLocation.Text) + FileAttributes.System) _
          Else SetAttributes(lblLocation.Text, GetAttributes(lblLocation.Text) - FileAttributes.System)
        CheckData()
    End Sub
End Class
