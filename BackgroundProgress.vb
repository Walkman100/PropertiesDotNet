<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class BackgroundProgress
    Inherits System.Windows.Forms.Form
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If components IsNot Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
    Private components As System.ComponentModel.IContainer
    Private Sub InitializeComponent()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.imgLoading = New System.Windows.Forms.PictureBox()
        Me.pbTaskProgress = New System.Windows.Forms.ProgressBar()
        Me.bwFolderOperations = New System.ComponentModel.BackgroundWorker()
        CType(Me.imgLoading,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        'lblStatus
        Me.lblStatus.AutoSize = true
        Me.lblStatus.Location = New System.Drawing.Point(34, 14)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(0, 13)
        'imgLoading
'To get code autocomplete, comment out the following line:
        Me.imgLoading.Image = Global.PropertiesDotNet.My.Resources.Resources.loading4
        Me.imgLoading.Location = New System.Drawing.Point(12, 12)
        Me.imgLoading.Name = "imgLoading"
        Me.imgLoading.Size = New System.Drawing.Size(16, 16)
        Me.imgLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.imgLoading.TabStop = false
        'pbTaskProgress
        '''
        ' Taskbar Progress code: uncomment the next line and the #End If below to use the normal ProgressBar
        '#If IsReference = True
            Me.pbTaskProgress = New wyDay.Controls.Windows7ProgressBar()
            Me.pbTaskProgress.ContainerControl = Me
            Me.pbTaskProgress.ShowInTaskbar = True
        '#End If
        '''
        Me.pbTaskProgress.Location = New System.Drawing.Point(12, 34)
        Me.pbTaskProgress.Name = "pbTaskProgress"
        Me.pbTaskProgress.Size = New System.Drawing.Size(310, 23)
        'bwFolderOperations
        Me.bwFolderOperations.WorkerReportsProgress = true
        Me.bwFolderOperations.WorkerSupportsCancellation = true
        'BackgroundProgress
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(334, 71)
        Me.Controls.Add(Me.pbTaskProgress)
        Me.Controls.Add(Me.imgLoading)
        Me.Controls.Add(Me.lblStatus)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
'To get code autocomplete, comment out the following line:
        Me.Icon = Global.PropertiesDotNet.My.Resources.Resources.document_properties
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "BackgroundProgress"
        Me.ShowInTaskbar = false
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Location = New System.Drawing.Size((My.Computer.Screen.WorkingArea.Width/2) - 167, (My.Computer.Screen.WorkingArea.Height/2) - 35.5)
        CType(Me.imgLoading,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout
    End Sub
    Friend WithEvents bwFolderOperations As System.ComponentModel.BackgroundWorker
    Private pbTaskProgress As Object 'wyDay.Controls.Windows7ProgressBar
    Private lblStatus As System.Windows.Forms.Label
    Private imgLoading As System.Windows.Forms.PictureBox
    
    Dim i As Integer
    ''' delete, deletePath
    ''' copy, copyFromPath, copyToPath
    Sub bwFolderOperations_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwFolderOperations.DoWork
        Dim DirectoryProperties As New DirectoryInfo(e.Argument(1))
        Try
            If e.Argument(0) = "delete" Then
                'Get file list (2%)
                'Delete files (95% total)
                'Get folder list (1%)
                'Delete folders (1%)
                'Delete final folder (1%)
                
                Me.Text = "Deleting """ & DirectoryProperties.Name & """..."
                SetStatus("Getting file list... (May take a while)", 0.01)
                Dim SubFiles = DirectoryProperties.GetFiles("*", SearchOption.AllDirectories)
                
                i = 0
                For Each SubFile As FileInfo In SubFiles
                    SetStatus("Deleting file """ & SubFile.Name & """...", (( i/SubFiles.Length ) *95 ) +2 )
                    SubFile.Delete
                    i += 1
                Next
                
                SetStatus("Getting folder list...", 97)
                Dim SubFolders = DirectoryProperties.GetDirectories("*", SearchOption.AllDirectories)
                
                i = 0
                For Each SubFolder As DirectoryInfo In SubFolders
                    SetStatus("Deleting folder """ & SubFolder.Name & """...", (( i/SubFolders.Length ) *1 ) +98 )
                    SubFolder.Delete
                    i += 1
                Next
                
                SetStatus("Deleting folder """ & DirectoryProperties.Name & """...", 99)
                Sleep(100)
                DirectoryProperties.Delete
                Me.Close
                Me.Dispose
            ElseIf e.Argument(0) = "copy" Then
                'Create root dir (1%)
                'Get folder list (1%)
                'Create folders (1%)
                'Get file list (2%)
                'Copy files (95%)
                
                Me.Text = "Copying """ & DirectoryProperties.Name & """ to """ & e.Argument(2) & """..."
                Directory.CreateDirectory(e.Argument(2))
                
                SetStatus("Getting folder list...", 1)
                Dim SubFolders = DirectoryProperties.GetDirectories("*", SearchOption.AllDirectories)
                
                i = 0
                For Each SubFolder As DirectoryInfo In SubFolders
                    SetStatus("Creating folder """ & SubFolder.Name & """...", (( i/SubFolders.Length ) *1 ) +1 )
                    Directory.CreateDirectory(e.Argument(2) & SubFolder.FullName.Substring(DirectoryProperties.FullName.Length))
                    i += 1
                Next
                
                SetStatus("Getting file list... (May take a while)", 3)
                Dim SubFiles = DirectoryProperties.GetFiles("*", SearchOption.AllDirectories)
                
                i = 0
                For Each SubFile As FileInfo In SubFiles
                    SetStatus("Copying file """ & SubFile.Name & """...", (( i/SubFiles.Length ) *95 ) +5)
                    SubFile.CopyTo(e.Argument(2) & SubFile.FullName.Substring(DirectoryProperties.FullName.Length))
                Next
                
                Sleep(100)
                Me.Close
                Me.Dispose
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation)
            Me.Close
        End Try
    End Sub
    
    ''' <summary>Sets the status label text to statusText.</summary>
    ''' TEMPORARY SUB
    ''' <param name="statusText">The text to display on the status label</param>
    Sub SetStatus(statusText As String)
        lblStatus.Text = statusText
    End Sub
    
    ''' <summary>Sets the status label text to statusText, and the progress bar percent to statusPercent.</summary>
    ''' <param name="statusText">The text to display on the status label</param>
    ''' <param name="statusPercent">The percent to set the progress bar value to. 0-100</param>
    Sub SetStatus(statusText As String, statusPercent As Integer)
        lblStatus.Text = statusText
        pbTaskProgress.Value = statusPercent
    End Sub
End Class