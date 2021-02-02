Imports PropertiesDotNet.Trinet.Core.IO.Ntfs

Public Partial Class AlternateDataStreamManager
    Public Sub New()
        Me.InitializeComponent()
    End Sub
    
    Sub LoadStreams() Handles Me.Shown
        lstStreams.Items.Clear()
        
        Dim file As FileInfo = New FileInfo(PropertiesDotNet.lblLocation.Text)
        
        If file.Exists Then
            Dim tmpListViewItem As New ListViewItem(New String() {":$DATA", file.Length, "Main Stream", "(see base file attributes)"})
            lstStreams.Items.Add(tmpListViewItem)
        End If
        
        Try
            For Each s As AlternateDataStreamInfo In ListAlternateDataStreams(file.FullName)
                Dim tmpListViewItem As New ListViewItem(New String() {s.Name, s.Size.ToString(), s.StreamType.ToString, s.Attributes.ToString})
                lstStreams.Items.Add(tmpListViewItem)
            Next
        Catch ex As Exception
            PropertiesDotNet.ErrorParser(ex)
        End Try
        
        lstStreams.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
        lstStreams_SelectedIndexChanged()
    End Sub
    
    Sub ADS_VisibleChanged() Handles Me.VisibleChanged
        If Me.Visible Then
            Me.CenterToParent()
        End If
    End Sub
    
    Sub ADSFormClosed() Handles Me.FormClosed
        PropertiesDotNet.CheckData()
    End Sub
    
    Sub lstStreams_SelectedIndexChanged() Handles lstStreams.SelectedIndexChanged
        If lstStreams.SelectedItems.Count = 0 Then
            btnOpen.Enabled = False
            btnView.Enabled = False
            btnExecute.Enabled = False
            btnDelete.Enabled = False
            btnCopy.Enabled = False
        Else
            btnOpen.Enabled = True
            btnView.Enabled = True
            btnExecute.Enabled = True
            btnDelete.Enabled = True
            btnCopy.Enabled = True
            
            ' stream :$DATA is the base file, we don't want to open that within the program and the file is deletable in the main window
            For Each item As ListViewItem In lstStreams.SelectedItems
                If item.Text = ":$DATA" Then
                    btnView.Enabled = False
                    btnDelete.Enabled = False
                    Exit For
                End If
            Next
        End If
    End Sub
    
    Sub lstStreams_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lstStreams.ColumnClick
        If e.Column = 0 Then
            lstStreams.Sorting = IIf(lstStreams.Sorting = SortOrder.Ascending, SortOrder.Descending, SortOrder.Ascending)
        Else
            'lstStreams.Sort(e.Column)
        End If
    End Sub
    
    Sub btnOpen_Click() Handles btnOpen.Click, lstStreams.ItemActivate
        For Each item As ListViewItem In lstStreams.SelectedItems
            Process.Start("notepad.exe", PropertiesDotNet.lblLocation.Text & ":" & item.Text)
        Next
    End Sub
    
    Sub btnOpen_MouseClick(sender As Object, e As MouseEventArgs) Handles btnOpen.MouseUp
        If e.Button = MouseButtons.Right Then
            Try
                For Each item As ListViewItem In lstStreams.SelectedItems
                    Process.Start(Application.StartupPath & "\ProgramLauncher", PropertiesDotNet.lblLocation.Text & ":" & item.Text)
                Next
            Catch ex As Exception
                MsgBox("""" & Application.StartupPath & "\ProgramLauncher"" executable not found!", MsgBoxStyle.Exclamation)
            End Try
        End If
    End Sub
        
    Sub btnView_Click() Handles btnView.Click
        Dim frmShowStream As New Form With {
            .Width = 600,
            .Height = 525,
            .StartPosition = FormStartPosition.CenterParent,
            .WindowState = FormWindowState.Normal,
            .ShowIcon = False,
            .ShowInTaskbar = False
        }
        Dim txtShowStream As New TextBox With {
            .Multiline = True,
            .ReadOnly = True,
            .ScrollBars = ScrollBars.Vertical,
            .Dock = DockStyle.Fill
        }
        frmShowStream.Controls.Add(txtShowStream)
        
        For Each item As ListViewItem In lstStreams.SelectedItems
            frmShowStream.Text = PropertiesDotNet.lblLocation.Text & ":" & item.Text
            Using stream As StreamReader = GetAlternateDataStream(PropertiesDotNet.lblLocation.Text, item.Text).OpenText
                txtShowStream.Text = stream.ReadToEnd().Replace(vbNullChar, "")
            End Using
            txtShowStream.SelectionStart = txtShowStream.Text.Length
            frmShowStream.ShowDialog()
        Next
    End Sub
    
    Sub btnExecute_Click() Handles btnExecute.Click
        For Each item As ListViewItem In lstStreams.SelectedItems
            Try
                Dim info As New ProcessStartInfo
                If item.Text = ":$DATA" Then
                    info.FileName = PropertiesDotNet.lblLocation.Text
                Else
                    info.FileName = PropertiesDotNet.lblLocation.Text & ":" & item.Text
                End If
                info.UseShellExecute = False
                Process.Start(info)
            Catch ex As System.ComponentModel.Win32Exception When ex.NativeErrorCode = 740
                'ERROR_ELEVATION_REQUIRED: The requested operation requires elevation.
                PropertiesDotNet.ErrorParser(New UnauthorizedAccessException(ex.Message, ex))
            Catch ex As Exception
                PropertiesDotNet.ErrorParser(ex)
            End Try
        Next
    End Sub
    
    Sub btnDelete_Click() Handles btnDelete.Click
        For Each item As ListViewItem In lstStreams.SelectedItems
            Try
                DeleteAlternateDataStream(PropertiesDotNet.lblLocation.Text, item.Text)
            Catch ex As UnauthorizedAccessException When MsgBox(ex.Message & vbNewLine & vbNewLine &
              "Try launching a system tool as admin?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Access denied!") = MsgBoxResult.Yes
                WalkmanLib.RunAsAdmin("powershell", "-Command Remove-Item -Path '" & PropertiesDotNet.lblLocation.Text & "' -Stream '" & item.Text & "'; pause")
                Threading.Thread.Sleep(500)
            Catch ex As Exception
                PropertiesDotNet.ErrorParser(ex)
            End Try
        Next
        
        LoadStreams()
    End Sub
    
    Sub btnCopy_Click() Handles btnCopy.Click
        Dim result As MsgBoxResult
        Dim targetFile As String
        Dim targetStreamName As String
        Dim adsSource As AlternateDataStreamInfo
        Dim adsTarget As AlternateDataStreamInfo
        
        For Each item As ListViewItem In lstStreams.SelectedItems
            
            ' get target file from user input
            targetFile = PropertiesDotNet.lblLocation.Text
            result = MsgBox("Copy stream """ & item.Text & """ to same file?", MsgBoxStyle.YesNoCancel, "Copy Stream Target")
            If result = MsgBoxResult.Cancel Then
                Continue For
            ElseIf result = MsgBoxResult.No
                sfdSelectCopyTarget.InitialDirectory = PropertiesDotNet.lblDirectory.Text
                sfdSelectCopyTarget.FileName = "Don't select a file to select folder"
                sfdSelectCopyTarget.Title = "Select file to copy stream """ & item.Text & """ to:"
                If sfdSelectCopyTarget.ShowDialog() = DialogResult.OK Then
                    If sfdSelectCopyTarget.FileName.EndsWith("Don't select a file to select folder") Then
                        targetFile = sfdSelectCopyTarget.FileName.Remove(sfdSelectCopyTarget.FileName.LastIndexOf(Path.DirectorySeparatorChar))
                    Else
                        targetFile = sfdSelectCopyTarget.FileName
                    End If
                Else
                    Continue For
                End If
            End If
            
            adsSource = New AlternateDataStreamInfo(PropertiesDotNet.lblLocation.Text, item.Text, Nothing, True)
            
            ' get target stream from user input
            If adsSource.Name = ":$DATA" Then
                targetStreamName = ""
            Else
                targetStreamName = adsSource.Name
            End If
            
            If Operations.GetInput(targetStreamName, "Copy Stream", "Enter name to copy stream """ & adsSource.Name & """ to:") <> DialogResult.OK Then
                Continue For
            End If
            
            Dim sourceStream As FileStream = Nothing
            Dim targetStream As FileStream = Nothing
            
            Try
                If Not File.Exists(targetFile) And Not Directory.Exists(targetFile) Then
                    File.Create(targetFile).Close()
                End If
                
                ' Copying FROM AlternateDataStream TO file
                If targetStreamName = ":$DATA" Then
                    sourceStream = adsSource.OpenRead()
                    targetStream = Open(targetFile, FileMode.Truncate)
                Else
                    Try
                        adsTarget = GetAlternateDataStream(targetFile, targetStreamName, FileMode.CreateNew)
                    Catch ex2 As IOException
                        MsgBox("Stream """ & targetStreamName & """ already exists on file """ & targetFile & """!", MsgBoxStyle.Critical, "Error Creating Stream")
                        Continue For
                    Catch ex2 As ArgumentException
                        MsgBox("Stream name """ & targetStreamName & """ contains invalid characters!", MsgBoxStyle.Critical, "Error Creating Stream")
                        Continue For
                    End Try
                    
                    ' Copying FROM file TO AlternateDataStream
                    If adsSource.Name = ":$DATA" Then
                        sourceStream = OpenRead(adsSource.FilePath)
                        targetStream = adsTarget.OpenWrite()
                    Else ' Copying FROM AlternateDataStream TO AlternateDataStream
                        sourceStream = adsSource.OpenRead()
                        targetStream = adsTarget.OpenWrite()
                    End If
                End If
                
                WalkmanLib.StreamCopy(sourceStream, targetStream, "Copying """ & adsSource.FullPath & """ to """ & targetFile & ":" & targetStreamName & """...",
                                      onComplete:=Sub(s, e)
                                                      If e.Error IsNot Nothing Then
                                                          PropertiesDotNet.ErrorParser(e.Error)
                                                      End If
                                                      LoadStreams()
                                                  End Sub)
            Catch ex As Exception
                If sourceStream IsNot Nothing Then sourceStream.Dispose()
                If targetStream IsNot Nothing Then targetStream.Dispose()
                sourceStream = Nothing
                targetStream = Nothing
                PropertiesDotNet.ErrorParser(ex)
            End Try
        Next
        
        LoadStreams()
    End Sub
    
    Sub btnAdd_Click() Handles btnAdd.Click
        Dim streamInfo As String = ""
        
        If Operations.GetInput(streamInfo, "Create Stream", "Type a name for the stream:") <> DialogResult.OK Then
            Exit Sub
        End If
        
        Dim ads As AlternateDataStreamInfo
        Try
            ads = GetAlternateDataStream(PropertiesDotNet.lblLocation.Text, streamInfo, FileMode.CreateNew)
        Catch ex As IOException
            MsgBox("Stream """ & streamInfo & """ already exists on file """ & PropertiesDotNet.lblLocation.Text & """!", MsgBoxStyle.Critical, "Error Creating Stream")
            Exit Sub
        Catch ex As ArgumentException
            MsgBox("Stream name """ & streamInfo & """ contains invalid characters!", MsgBoxStyle.Critical, "Error Creating Stream")
            Exit Sub
        End Try
        
        streamInfo = ""
        If Operations.GetInput(streamInfo, "Create Stream", "Enter stream contents:") <> DialogResult.OK Then
            Exit Sub
        End If
        
        Try
            Using stream As StreamWriter = New StreamWriter(ads.OpenWrite())
                stream.Write(streamInfo)
            End Using
        Catch ex As UnauthorizedAccessException When MsgBox(ex.Message & vbNewLine & vbNewLine &
          "Try launching a system tool as admin?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Access denied!") = MsgBoxResult.Yes
            WalkmanLib.RunAsAdmin("powershell", "-Command Set-Content -Path '" & ads.FilePath & "' -Stream '" & ads.Name & "' -Value '" & streamInfo & "'; pause")
            Threading.Thread.Sleep(500)
        Catch ex As Exception
            PropertiesDotNet.ErrorParser(ex)
        End Try
        
        LoadStreams()
    End Sub
    
    Sub btnClose_Click() Handles btnClose.Click
        Me.Close
    End Sub
End Class
