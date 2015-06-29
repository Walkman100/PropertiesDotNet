Imports System.IO
Imports System.IO.File
Imports System.Runtime.InteropServices 'For NTFS compression

Public Class PropertiesDotNet
    ' TODO:
    'icon: picturebox
    'copy file name, copy file dir, copy full file path
    'sizes (only have bytes)
    'compute hashes
    
    'default open with?
    'set default open with
    'launch
    'launch with [..]
    'ok, cancel, apply - no, stuff applies immediatly
    
    Sub PropertiesDotNet_Load(sender As Object, e As EventArgs) Handles Me.Load
        For Each s As String In My.Application.CommandLineArgs
            If lblLocation.Text = "Checking..." Then
                lblLocation.Text = s
            Else
                lblLocation.Text = lblLocation.Text & " " & s 
            End If
        Next
        CheckData
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
    
    <DllImport("Kernel32.dll")> _
    Public Shared Function DeviceIoControl(hDevice As IntPtr,dwIoControlCode As Integer,ByRef lpInBuffer As Short, _
    nInBufferSize As Integer,lpOutBuffer As IntPtr,nOutBufferSize As Integer,ByRef lpBytesReturned As Integer,lpOverlapped As IntPtr)As Integer
    End Function
    Sub Compress(Optional CompressB As Boolean = True)
        ''' <summary>
        ''' Credits to http://www.thescarms.com/dotnet/NTFSCompress.aspx
        ''' Converted to VB.Net with SharpDevelop (which I believe uses MSBuild anyway to convert)
        ''' </summary>
        Dim FilePropertiesInfo As New FileInfo(lblLocation.Text)
        Dim FilePropertiesStream As FileStream = File.Open(FilePropertiesInfo.FullName, FileMode.Open, FileAccess.ReadWrite, FileShare.None)
        If CompressB Then
            DeviceIoControl(FilePropertiesStream.Handle, &H9c040, 1, 2, 0, 0, 0, 0)
        Else
            ' https://msdn.microsoft.com/en-us/library/windows/desktop/aa364592(v=vs.85).aspx
            ' COMPRESSION_FORMAT_NONE is equal to 0 (i assume)
            DeviceIoControl(FilePropertiesStream.Handle, &H9c040, 0, 2, 0, 0, 0, 0)
        End If
        FilePropertiesStream.Flush(True)
        FilePropertiesStream.Close
        FilePropertiesStream.Dispose
    End Sub
    
    Sub chkReadOnly_Click() Handles chkReadOnly.Click
        If chkReadOnly.Checked Then SetAttributes(lblLocation.Text, GetAttributes(lblLocation.Text) + FileAttributes.ReadOnly) _
          Else SetAttributes(lblLocation.Text, GetAttributes(lblLocation.Text) - FileAttributes.ReadOnly)
        CheckData
    End Sub
    Sub chkHidden_Click() Handles chkHidden.Click
        If chkHidden.Checked Then SetAttributes(lblLocation.Text, GetAttributes(lblLocation.Text) + FileAttributes.Hidden) _
          Else SetAttributes(lblLocation.Text, GetAttributes(lblLocation.Text) - FileAttributes.Hidden)
        CheckData
    End Sub
    Sub chkCompressed_Click() Handles chkCompressed.Click
        If chkCompressed.Checked Then
            SetAttributes(lblLocation.Text, GetAttributes(lblLocation.Text) + FileAttributes.Compressed)
            If Not GetAttributes(lblLocation.Text).HasFlag(FileAttributes.Compressed) Then
                Compress()
            End If
        Else
            SetAttributes(lblLocation.Text, GetAttributes(lblLocation.Text) - FileAttributes.Compressed)
            If GetAttributes(lblLocation.Text).HasFlag(FileAttributes.Compressed) Then
                Compress(False)
            End If
        End If
        CheckData
    End Sub
    Sub chkEncrypted_Click() Handles chkEncrypted.Click
        If chkEncrypted.Checked Then
            SetAttributes(lblLocation.Text, GetAttributes(lblLocation.Text) + FileAttributes.Encrypted)
            If Not GetAttributes(lblLocation.Text).HasFlag(FileAttributes.Encrypted) Then
                Dim FileProperties As New FileInfo(lblLocation.Text)
                Try
                    FileProperties.Encrypt
                Catch ex As IOException
                    MsgBox("Could not encrypt!" & vbNewLine & vbNewLine & ex.Message, MsgBoxStyle.Exclamation)
                End Try
            End If
        Else
            SetAttributes(lblLocation.Text, GetAttributes(lblLocation.Text) - FileAttributes.Encrypted)
            If GetAttributes(lblLocation.Text).HasFlag(FileAttributes.Encrypted) Then
                Dim FileProperties As New FileInfo(lblLocation.Text)
                Try
                    FileProperties.Decrypt
                Catch ex As IOException
                    MsgBox("Could not decrypt!" & vbNewLine & vbNewLine & ex.Message, MsgBoxStyle.Exclamation)
                End Try
            End If
        End If 
        CheckData
    End Sub
    Sub chkSystem_Click() Handles chkSystem.Click
        If chkSystem.Checked Then SetAttributes(lblLocation.Text, GetAttributes(lblLocation.Text) + FileAttributes.System) _
          Else SetAttributes(lblLocation.Text, GetAttributes(lblLocation.Text) - FileAttributes.System)
        CheckData
    End Sub
    Sub chkArchive_Click() Handles chkArchive.Click
        If chkArchive.Checked Then SetAttributes(lblLocation.Text, GetAttributes(lblLocation.Text) + FileAttributes.Archive) _
          Else SetAttributes(lblLocation.Text, GetAttributes(lblLocation.Text) - FileAttributes.Archive)
        CheckData
    End Sub
    Sub chkTemporary_Click() Handles chkTemporary.Click
        If chkTemporary.Checked Then SetAttributes(lblLocation.Text, GetAttributes(lblLocation.Text) + FileAttributes.Temporary) _
          Else SetAttributes(lblLocation.Text, GetAttributes(lblLocation.Text) - FileAttributes.Temporary)
        CheckData
    End Sub
    Sub chkIntegrity_Click() Handles chkIntegrity.Click
        If chkIntegrity.Checked Then SetAttributes(lblLocation.Text, GetAttributes(lblLocation.Text) + FileAttributes.IntegrityStream) _
          Else SetAttributes(lblLocation.Text, GetAttributes(lblLocation.Text) - FileAttributes.IntegrityStream)
        CheckData
    End Sub
    Sub chkNoScrub_Click() Handles chkNoScrub.Click
        If chkNoScrub.Checked Then SetAttributes(lblLocation.Text, GetAttributes(lblLocation.Text) + FileAttributes.NoScrubData) _
          Else SetAttributes(lblLocation.Text, GetAttributes(lblLocation.Text) - FileAttributes.NoScrubData)
        CheckData
    End Sub
    Sub chkNotIndexed_Click() Handles chkNotIndexed.Click
        If chkNotIndexed.Checked Then SetAttributes(lblLocation.Text, GetAttributes(lblLocation.Text) + FileAttributes.NotContentIndexed) _
          Else SetAttributes(lblLocation.Text, GetAttributes(lblLocation.Text) - FileAttributes.NotContentIndexed)
        CheckData
    End Sub
    Sub chkOffline_Click() Handles chkOffline.Click
        If chkOffline.Checked Then SetAttributes(lblLocation.Text, GetAttributes(lblLocation.Text) + FileAttributes.Offline) _
          Else SetAttributes(lblLocation.Text, GetAttributes(lblLocation.Text) - FileAttributes.Offline)
        CheckData
    End Sub
    Sub chkReparse_Click() Handles chkReparse.Click
        If chkReparse.Checked Then SetAttributes(lblLocation.Text, GetAttributes(lblLocation.Text) + FileAttributes.ReparsePoint) _
          Else SetAttributes(lblLocation.Text, GetAttributes(lblLocation.Text) - FileAttributes.ReparsePoint)
        CheckData
    End Sub
    Sub chkSparse_Click() Handles chkSparse.Click
        If chkSparse.Checked Then SetAttributes(lblLocation.Text, GetAttributes(lblLocation.Text) + FileAttributes.SparseFile) _
          Else SetAttributes(lblLocation.Text, GetAttributes(lblLocation.Text) - FileAttributes.SparseFile)
        CheckData
    End Sub
    
    Sub lnkAttributes_LinkClicked() Handles lnkAttributes.LinkClicked
        Try
            Process.Start("https://msdn.microsoft.com/en-us/library/system.io.fileattributes(v=vs.110).aspx#memberList")
        Catch ex As Exception
            If MsgBox("Unable to launch URL, copy to clipboard instead?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then Clipboard.SetText("https://msdn.microsoft.com/en-us/library/system.io.fileattributes(v=vs.110).aspx#memberList")
        End Try
    End Sub
    
    Sub btnRename_Click() Handles btnRename.Click
        Dim FileProperties As New FileInfo(lblLocation.Text)
        Dim newName = InputBox("Rename to:", "New name", FileProperties.Name)
        If newName <> "" Then
            FileProperties.MoveTo(FileProperties.DirectoryName & "\" & newName)
            lblLocation.Text = FileProperties.DirectoryName & "\" & newName
        End If
        CheckData
    End Sub
    Sub btnDelete_Click() Handles btnDelete.Click
        Dim FileProperties As New FileInfo(lblLocation.Text)
        If MsgBox("Are you sure you want to delete """ & FileProperties.Name & """?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            FileProperties.Delete
            Application.Exit
        End If
        CheckData
    End Sub
    Sub btnCopy_Click() Handles btnCopy.Click
        Dim FileProperties As New FileInfo(lblLocation.Text)
        SaveFileDialog.InitialDirectory = FileProperties.DirectoryName
        SaveFileDialog.FileName = FileProperties.Name
        SaveFileDialog.Title = "Choose where to copy """ & FileProperties.Name & """ to:"
        If (SaveFileDialog.ShowDialog() = DialogResult.OK) Then
            FileProperties.CopyTo(SaveFileDialog.FileName)
            If MsgBox("Read new file?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then lblLocation.Text = SaveFileDialog.FileName
        End If
        CheckData
    End Sub
    Sub btnMove_Click() Handles btnMove.Click
        Dim FileProperties As New FileInfo(lblLocation.Text)
        SaveFileDialog.InitialDirectory = FileProperties.DirectoryName
        SaveFileDialog.FileName = FileProperties.Name
        SaveFileDialog.Title = "Choose where to move """ & FileProperties.Name & """ to:"
        If (SaveFileDialog.ShowDialog() = DialogResult.OK) Then
            FileProperties.MoveTo(SaveFileDialog.FileName)
            lblLocation.Text = SaveFileDialog.FileName
        End If
        CheckData
    End Sub
End Class
