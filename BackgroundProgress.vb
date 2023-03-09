Imports System
Imports System.IO
Imports System.Linq

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        Me.pbTaskProgress = New wyDay.Controls.Windows7ProgressBar()
        Me.bwFolderOperations = New System.ComponentModel.BackgroundWorker()
        CType(Me.imgLoading, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        'lblStatus
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(34, 14)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(0, 13)
        'imgLoading
        Me.imgLoading.Image = My.Resources.loading4
        Me.imgLoading.Location = New System.Drawing.Point(12, 12)
        Me.imgLoading.Name = "imgLoading"
        Me.imgLoading.Size = New System.Drawing.Size(16, 16)
        Me.imgLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.imgLoading.TabStop = False
        'pbTaskProgress
        Me.pbTaskProgress.ContainerControl = Me
        Me.pbTaskProgress.Location = New System.Drawing.Point(12, 34)
        Me.pbTaskProgress.Name = "pbTaskProgress"
        Me.pbTaskProgress.ShowInTaskbar = True
        Me.pbTaskProgress.Size = New System.Drawing.Size(310, 23)
        'bwFolderOperations
        Me.bwFolderOperations.WorkerReportsProgress = True
        Me.bwFolderOperations.WorkerSupportsCancellation = True
        'BackgroundProgress
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(334, 71)
        Me.Controls.Add(Me.pbTaskProgress)
        Me.Controls.Add(Me.imgLoading)
        Me.Controls.Add(Me.lblStatus)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = My.Resources.document_properties
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "BackgroundProgress"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        'Me.Location = New System.Drawing.Size((My.Computer.Screen.WorkingArea.Width/2) - 167, (My.Computer.Screen.WorkingArea.Height/2) - 35.5)
        CType(Me.imgLoading, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
    Friend WithEvents bwFolderOperations As System.ComponentModel.BackgroundWorker
    Private pbTaskProgress As wyDay.Controls.Windows7ProgressBar
    Private lblStatus As System.Windows.Forms.Label
    Private imgLoading As System.Windows.Forms.PictureBox

    Sub New()
        InitializeComponent()

        Dim theme As WalkmanLib.Theme = Settings.GetTheme()
        WalkmanLib.ApplyTheme(theme, Me, True)
        If components IsNot Nothing Then WalkmanLib.ApplyTheme(theme, components.Components, True)
    End Sub

    Dim i As Integer
    Dim WasError As Boolean = False
    ''' delete, deletePath
    ''' copy, copyFromPath, copyToPath
    Sub bwFolderOperations_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwFolderOperations.DoWork
        Dim command As String = DirectCast(e.Argument, String())(0)
        Dim sourcePath As String = DirectCast(e.Argument, String())(1)

        Dim DirectoryProperties As New DirectoryInfo(sourcePath)
        Try
            If command = "delete" Then
                'Get file list (2%)
                'Delete files (95% total)
                'Get folder list (1%)
                'Delete folders (1%)
                'Delete final folder (1%)

                Me.Text = "Deleting """ & DirectoryProperties.Name & """..."
                SetStatus("Getting file list... (May take a while)", 0)
                Dim SubFiles = DirectoryProperties.GetFiles("*", SearchOption.AllDirectories)

                i = 0
                For Each SubFile As FileInfo In SubFiles
                    SetStatus("Deleting file """ & SubFile.Name & """...", CType(((i / SubFiles.Length) * 95) + 2, Integer))
                    Try
                        SubFile.Delete()
                    Catch ex As Exception
                        Select Case Operations.MessageBox("There was an error deleting """ & SubFile.FullName & """!" & Environment.NewLine & Environment.NewLine & ex.Message,
                                                          Windows.Forms.MessageBoxButtons.AbortRetryIgnore, Windows.Forms.MessageBoxIcon.Exclamation, "Error!")
                            Case Windows.Forms.DialogResult.Abort
                                Exit For
                            Case Windows.Forms.DialogResult.Retry
                                Try
                                    SubFile.Delete()
                                Catch ex2 As Exception
                                    Select Case Operations.MessageBox("Error retrying delete for """ & SubFile.FullName & """:" & ex.Message,
                                                                      Windows.Forms.MessageBoxButtons.AbortRetryIgnore, Windows.Forms.MessageBoxIcon.Exclamation, "Error!")
                                        Case Windows.Forms.DialogResult.Abort
                                            Exit For
                                        Case Windows.Forms.DialogResult.Retry
                                            Operations.MessageBox("Already retried!", icon:=Windows.Forms.MessageBoxIcon.Exclamation)
                                        Case Else
                                    End Select
                                End Try
                        End Select
                    End Try
                    i += 1
                Next

                SetStatus("Getting folder list...", 97)
                Dim SubFolders = DirectoryProperties.GetDirectories("*", SearchOption.AllDirectories)

                i = 0
                For Each SubFolder As DirectoryInfo In SubFolders.Reverse() ' Reverse to delete deepest directories first
                    SetStatus("Deleting folder """ & SubFolder.Name & """...", CType(((i / SubFolders.Length) * 1) + 98, Integer))
                    Try
                        SubFolder.Delete()
                    Catch
                        WasError = True
                    End Try
                    i += 1
                Next

                If WasError Then
                    For Each SubFolder As DirectoryInfo In SubFolders.Reverse()
                        Try
                            SubFolder.Delete()
                        Catch
                        End Try
                    Next
                End If

                SetStatus("Deleting folder """ & DirectoryProperties.Name & """...", 99)
                Threading.Thread.Sleep(100)
                DirectoryProperties.Delete()
                Me.Close()
                Me.Dispose()
            ElseIf command = "copy" Then
                'Create root dir (1%)
                'Get folder list (1%)
                'Create folders (1%)
                'Get file list (2%)
                'Copy files (95%)

                Dim targetPath As String = DirectCast(e.Argument, String())(2)

                Me.Text = "Copying """ & DirectoryProperties.Name & """ to """ & targetPath & """..."
                Directory.CreateDirectory(targetPath)

                SetStatus("Getting folder list...", 1)
                Dim SubFolders = DirectoryProperties.GetDirectories("*", SearchOption.AllDirectories)

                i = 0
                For Each SubFolder As DirectoryInfo In SubFolders
                    SetStatus("Creating folder """ & SubFolder.Name & """...", CType(((i / SubFolders.Length) * 1) + 1, Integer))
                    Try
                        Directory.CreateDirectory(targetPath & SubFolder.FullName.Substring(DirectoryProperties.FullName.Length))
                    Catch
                        WasError = True
                    End Try
                    i += 1
                Next

                If WasError Then
                    For Each SubFolder As DirectoryInfo In SubFolders
                        Try
                            Directory.CreateDirectory(targetPath & SubFolder.FullName.Substring(DirectoryProperties.FullName.Length))
                        Catch
                        End Try
                    Next
                End If

                SetStatus("Getting file list... (May take a while)", 3)
                Dim SubFiles = DirectoryProperties.GetFiles("*", SearchOption.AllDirectories)

                i = 0
                For Each SubFile As FileInfo In SubFiles
                    SetStatus("Copying file """ & SubFile.Name & """...", CType(((i / SubFiles.Length) * 95) + 5, Integer))
                    Try
                        SubFile.CopyTo(targetPath & SubFile.FullName.Substring(DirectoryProperties.FullName.Length))
                    Catch ex As Exception
                        Select Case Operations.MessageBox("There was an error copying """ & SubFile.FullName & """ to """ & targetPath &
                                                          SubFile.FullName.Substring(DirectoryProperties.FullName.Length) & """!" &
                                                          Environment.NewLine & Environment.NewLine & ex.Message,
                                                          Windows.Forms.MessageBoxButtons.AbortRetryIgnore, Windows.Forms.MessageBoxIcon.Exclamation, "Error!")
                            Case Windows.Forms.DialogResult.Abort
                                Exit For
                            Case Windows.Forms.DialogResult.Retry
                                Try
                                    SubFile.CopyTo(targetPath & SubFile.FullName.Substring(DirectoryProperties.FullName.Length))
                                Catch ex2 As Exception
                                    Select Case Operations.MessageBox("Error retrying copy for """ & SubFile.FullName & """:" & ex.Message,
                                                                      Windows.Forms.MessageBoxButtons.AbortRetryIgnore, Windows.Forms.MessageBoxIcon.Exclamation, "Error!")
                                        Case Windows.Forms.DialogResult.Abort
                                            Exit For
                                        Case Windows.Forms.DialogResult.Retry
                                            Operations.MessageBox("Already retried!", icon:=Windows.Forms.MessageBoxIcon.Exclamation)
                                    End Select
                                End Try
                        End Select
                    End Try
                    i += 1
                Next

                Threading.Thread.Sleep(100)
                Me.Close()
                Me.Dispose()
            End If
        Catch ex As Exception
            If Not Settings.Loaded Then Settings.Init()
            WalkmanLib.ErrorDialog(ex, Settings.GetTheme())

            Me.Close()
        End Try
    End Sub

    ''' <summary>Sets the status label text to statusText, and the progress bar percent to statusPercent.</summary>
    ''' <param name="statusText">The text to display on the status label</param>
    ''' <param name="statusPercent">The percent to set the progress bar value to. 0-100</param>
    Sub SetStatus(statusText As String, statusPercent As Integer)
        lblStatus.Text = statusText
        pbTaskProgress.Value = statusPercent
    End Sub
End Class
