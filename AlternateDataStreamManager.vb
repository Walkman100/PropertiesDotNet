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
        
        For Each s As AlternateDataStreamInfo In file.ListAlternateDataStreams
            Dim tmpListViewItem As New ListViewItem(New String() {s.Name, s.Size.ToString(), s.StreamType.ToString, s.Attributes.ToString})
            lstStreams.Items.Add(tmpListViewItem)
        Next
        
        lstStreams.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
        lstStreams_SelectedIndexChanged()
    End Sub
    
    Sub lstStreams_SelectedIndexChanged() Handles lstStreams.SelectedIndexChanged
        If lstStreams.SelectedItems.Count = 0 Then
            btnOpen.Enabled = False
            btnView.Enabled = False
            btnType.Enabled = False
            btnAttributes.Enabled = False
            btnDelete.Enabled = False
            btnCopy.Enabled = False
        Else
            btnOpen.Enabled = True
            btnView.Enabled = True
            btnType.Enabled = True
            btnAttributes.Enabled = True
            btnDelete.Enabled = True
            btnCopy.Enabled = True
            
            ' stream :$DATA is the base file, we don't want to open that within the program,
            '   it's type can't be changed, attributes are changeable and the file is deletable in the main window
            For Each item As ListViewItem In lstStreams.SelectedItems
                If item.Text = ":$DATA" Then
                    btnView.Enabled = False
                    btnType.Enabled = False
                    btnAttributes.Enabled = False
                    btnDelete.Enabled = False
                End If
            Next
        End If
    End Sub
    
    Sub lstStreams_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lstStreams.ColumnClick
        If e.Column = 0 Then
            lstStreams.Sorting = IIf(lstStreams.Sorting = SortOrder.Ascending, SortOrder.Descending, SortOrder.Ascending)
        Else
            'lstPrograms.Sort(e.Column)
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
        
    Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Dim frmShowStream As New Form()
        frmShowStream.Width = 600
        frmShowStream.Height = 525
        frmShowStream.StartPosition = FormStartPosition.CenterParent
        frmShowStream.WindowState = FormWindowState.Normal
        frmShowStream.ShowIcon = False
        frmShowStream.ShowInTaskbar = False
        Dim txtShowStream As New TextBox()
        txtShowStream.Multiline = True
        txtShowStream.ReadOnly = True
        txtShowStream.ScrollBars = ScrollBars.Vertical
        frmShowStream.Controls.Add(txtShowStream)
        txtShowStream.Dock = DockStyle.Fill
        
        For Each item As ListViewItem In lstStreams.SelectedItems
            frmShowStream.Text = PropertiesDotNet.lblLocation.Text & ":" & item.Text
            txtShowStream.Text = GetAlternateDataStream(PropertiesDotNet.lblLocation.Text, item.Text).OpenText.ReadToEnd
            txtShowStream.SelectionStart = txtShowStream.Text.Length
            frmShowStream.ShowDialog()
        Next
    End Sub
    
    Sub btnType_Click(sender As Object, e As EventArgs) Handles btnType.Click
        
    End Sub
    
    Sub btnAttributes_Click(sender As Object, e As EventArgs) Handles btnAttributes.Click
        
    End Sub
    
    Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        For Each item As ListViewItem In lstStreams.SelectedItems
            DeleteAlternateDataStream(PropertiesDotNet.lblLocation.Text, item.Text)
        Next
        
        LoadStreams()
    End Sub
    
    Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click
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
                sfdSelectCopyTarget.FileName = targetFile
                sfdSelectCopyTarget.Title = "Select file to copy stream """ & item.Text & """ to:"
                If sfdSelectCopyTarget.ShowDialog() = DialogResult.OK Then
                    targetFile = sfdSelectCopyTarget.FileName
                Else
                    Continue For
                End If
            End If
            
            adsSource = New AlternateDataStreamInfo(PropertiesDotNet.lblLocation.Text, item.Text, Nothing, True)
            
            ' get target stream from user input
            targetStreamName = adsSource.Name
            If PropertiesDotNet.OokiiDialogsLoaded() Then
                If PropertiesDotNet.OokiiInputBox(targetStreamName, "Copy Stream", "Enter name to copy stream """ & targetStreamName & """ to:") <> DialogResult.OK Then
                    Continue For                  ' newName above is ByRef, so OokiiInputBox() updates it
                End If
            Else
                targetStreamName = InputBox("Enter name to copy stream """ & targetStreamName & """ to:", "Copy Stream", targetStreamName)
                If targetStreamName = "" Then
                    Continue For
                End If
            End If
            
            ' Copying FROM AlternateDataStream TO file
            If targetStreamName = ":$DATA" Then
                Using sourceStream As FileStream = adsSource.OpenRead()
                    Using targetStream As FileStream = Open(targetFile, FileMode.Truncate)
                        sourceStream.CopyTo(targetStream)
                    End Using
                End Using
                
            Else
                Try
                    adsTarget  = GetAlternateDataStream(targetFile, targetStreamName, FileMode.CreateNew)
                Catch ex As IOException
                    MsgBox("Stream """ & targetStreamName & """ already exists on file """ & targetFile & """!", MsgBoxStyle.Critical, "Error Creating Stream")
                    Continue For
                Catch ex As ArgumentException
                    MsgBox("Stream name """ & targetStreamName & """ contains invalid characters!", MsgBoxStyle.Critical, "Error Creating Stream")
                    Continue For
                End Try
                
                ' Copying FROM file TO AlternateDataStream
                If adsSource.Name = ":$DATA" Then
                    Using sourceStream As FileStream = OpenRead(adsSource.FilePath)
                        Using targetStream As FileStream = adsTarget.OpenWrite()
                            sourceStream.CopyTo(targetStream)
                        End Using
                    End Using
                    
                Else ' Copying FROM AlternateDataStream TO AlternateDataStream
                    Using sourceStream As FileStream = adsSource.OpenRead()
                        Using targetStream As FileStream = adsTarget.OpenWrite()
                            sourceStream.CopyTo(targetStream)
                        End Using
                    End Using
                End If
            End If
        Next
        
        LoadStreams()
    End Sub
    
    Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim streamInfo As String = ""
        
        If PropertiesDotNet.OokiiDialogsLoaded() Then
            If PropertiesDotNet.OokiiInputBox(streamInfo, "Create Stream", "Type a name for the stream:") <> DialogResult.OK Then
                Exit Sub                      ' streamInfo above is ByRef, so OokiiInputBox() updates it
            End If
        Else
            streamInfo = InputBox("Type a name for the stream:", "Create Stream")
            If streamInfo = "" Then
                Exit Sub
            End If
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
        
        If PropertiesDotNet.OokiiDialogsLoaded() Then
            streamInfo = ""
            If PropertiesDotNet.OokiiInputBox(streamInfo, "Create Stream", "Enter stream contents:") <> DialogResult.OK Then
                Exit Sub                      ' streamInfo above is ByRef, so OokiiInputBox() updates it
            End If
        Else
            streamInfo = InputBox("Enter stream contents:", "Create Stream")
            If streamInfo = "" Then
                Exit Sub
            End If
        End If
        
        Using stream As StreamWriter = New StreamWriter(ads.OpenWrite())
            stream.Write(streamInfo)
        End Using
        
        LoadStreams()
    End Sub
End Class
