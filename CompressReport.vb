Imports System
Imports System.IO
Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Public Class CompressReport
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
        Me.bwCompress = New System.ComponentModel.BackgroundWorker()
        CType(Me.imgLoading, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        'lblStatus
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(34, 14)
        Me.lblStatus.Text = "Starting compression..."
        'imgLoading
        Me.imgLoading.Name = "imgLoading"
        Me.imgLoading.Image = Resources.loading4
        Me.imgLoading.Location = New System.Drawing.Point(12, 12)
        Me.imgLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.imgLoading.TabStop = False
        'bwCompress
        AddHandler Me.bwCompress.DoWork, AddressOf Me.bwCompress_DoWork
        'CompressReport
        Me.Name = "CompressReport"
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(334, 40)
        Me.Controls.Add(Me.imgLoading)
        Me.Controls.Add(Me.lblStatus)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = Resources.compress
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Compressing..."
        CType(Me.imgLoading, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
    Friend bwCompress As System.ComponentModel.BackgroundWorker
    Friend lblStatus As System.Windows.Forms.Label
    Private imgLoading As System.Windows.Forms.PictureBox

    ' Imported Functions: DeviceIoControl:
    '  Used for (De)Compressing files
    '   http://www.thescarms.com/dotnet/NTFSCompress.aspx
    <DllImport("Kernel32.dll")>
    Public Shared Function DeviceIoControl(hDevice As IntPtr, dwIoControlCode As Integer, ByRef lpInBuffer As Short,
    nInBufferSize As Integer, lpOutBuffer As IntPtr, nOutBufferSize As Integer, ByRef lpBytesReturned As Integer, lpOverlapped As IntPtr) As Integer
    End Function

    Sub bwCompress_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)
        Try
            ' Credits to http://www.thescarms.com/dotnet/NTFSCompress.aspx
            ' Converted to VB.Net with SharpDevelop (which I believe uses MSBuild anyway to convert)
            If e.Argument(0) Then Me.Text = "Compressing..." Else Me.Text = "Decompressing..."

            If WalkmanLib.IsFileOrDirectory(e.Argument(1)).HasFlag(PathEnum.IsDirectory) Then
                lblStatus.Text = "Running function..."
                WalkmanLib.SetCompression(e.Argument(1), e.Argument(0))

                lblStatus.Text = "Done!"
                Threading.Thread.Sleep(100)
                Me.Close()
                Return
            End If

            lblStatus.Text = "[1/5] Opening File stream..."
            Dim FilePropertiesStream As FileStream = File.Open(e.Argument(1), FileMode.Open, FileAccess.ReadWrite, FileShare.None)

            If e.Argument(0) Then
                lblStatus.Text = "[2/5] Running compress function..."
                DeviceIoControl(FilePropertiesStream.SafeFileHandle.DangerousGetHandle, &H9C040, 1, 2, 0, 0, 0, 0)
            Else
                ' https://msdn.microsoft.com/en-us/library/windows/desktop/aa364592(v=vs.85).aspx
                ' COMPRESSION_FORMAT_NONE is equal to 0 (i assume)
                lblStatus.Text = "[2/5] Running decompress function..."
                DeviceIoControl(FilePropertiesStream.SafeFileHandle.DangerousGetHandle, &H9C040, 0, 2, 0, 0, 0, 0)
            End If

            lblStatus.Text = "[3/5] Flushing buffer to disc..."
            FilePropertiesStream.Flush(True)

            lblStatus.Text = "[4/5] Closing File stream..."
            FilePropertiesStream.SafeFileHandle.Dispose()
            FilePropertiesStream.Dispose()
            FilePropertiesStream.Close()

            If e.Argument(0) Then lblStatus.Text = "[5/5] Compression Done!" Else lblStatus.Text = "[5/5] Decompression Done!"
            Threading.Thread.Sleep(100)
            Me.Close()

        Catch ex As UnauthorizedAccessException
            lblStatus.Text = "Failed! Access denied!"
            Threading.Thread.Sleep(4000)
            Me.Close()
        Catch ex As IOException
            lblStatus.Text = "Failed! File in use!"
            Threading.Thread.Sleep(2000)
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation)
            Me.Close()
        End Try
    End Sub
End Class
