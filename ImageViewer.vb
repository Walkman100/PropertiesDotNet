<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class ImageViewer
    Inherits System.Windows.Forms.Form
    Private components As System.ComponentModel.IContainer
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If components IsNot Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
    Private Sub InitializeComponent()
        Me.fileImage = New System.Windows.Forms.PictureBox()
        Me.btnSave = New System.Windows.Forms.Button()
        CType(Me.fileImage,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        'fileImage
        Me.fileImage.Dock = System.Windows.Forms.DockStyle.Top
        Me.fileImage.Name = "fileImage"
        Me.fileImage.Size = New System.Drawing.Size(284, 240)
        Me.fileImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        'btnSave
        Me.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnSave.Location = New System.Drawing.Point(110, 240)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.Text = "Save..."
        Me.btnSave.UseVisualStyleBackColor = true
        AddHandler Me.btnSave.Click, AddressOf Me.btnSave_Click
        'ImageViewer
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.fileImage)
        Me.Name = "ImageViewer"
        Me.ShowIcon = false
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.fileImage,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
    End Sub
    Private btnSave As System.Windows.Forms.Button
    Friend fileImage As System.Windows.Forms.PictureBox
    
    Sub ImageViewer_Resize() Handles Me.Resize
        fileImage.Size = New System.Drawing.Size(fileImage.Width, (Me.Height - 60))
    End Sub
    
    Sub btnSave_Click()
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.Title = "Save image"
        SaveFileDialog.FileName = PropertiesDotNet.imgFile.ImageLocation & ".png"
        If SaveFileDialog.ShowDialog = DialogResult.OK Then
            fileImage.Image.Save(SaveFileDialog.FileName)
        End If
    End Sub
End Class
