Imports PropertiesDotNet.Trinet.Core.IO.Ntfs

Public Partial Class AlternateDataStreamManager
    Public Sub New()
        Me.InitializeComponent()
    End Sub
    
    Sub LoadStreams() Handles Me.Shown
        lstStreams.Items.Clear()
        
        Dim file As FileInfo = New FileInfo(PropertiesDotNet.lblLocation.Text)
        
        For Each s As AlternateDataStreamInfo In file.ListAlternateDataStreams
            Dim tmpListViewItem As New ListViewItem(New String() {s.Name, s.Size.ToString(), s.StreamType.ToString, s.Attributes.ToString})
            lstStreams.SelectedItems.Clear() ' deselect existing items
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
            btnRename.Enabled = False
            btnDelete.Enabled = False
        Else
            btnOpen.Enabled = True
            btnView.Enabled = True
            btnType.Enabled = True
            btnAttributes.Enabled = True
            btnRename.Enabled = True
            btnDelete.Enabled = True
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
        frmShowStream.ShowInTaskbar = True
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
    
    Sub btnRename_Click(sender As Object, e As EventArgs) Handles btnRename.Click
        
    End Sub
    
    Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        For Each item As ListViewItem In lstStreams.SelectedItems
            DeleteAlternateDataStream(PropertiesDotNet.lblLocation.Text, item.Text)
        Next
        
        LoadStreams()
    End Sub
    
    Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        
    End Sub
End Class
