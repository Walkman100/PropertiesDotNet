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
        Me.btnClose = New System.Windows.Forms.Button()
        CType(Me.fileImage,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        'fileImage
        Me.fileImage.Dock = System.Windows.Forms.DockStyle.Top
        Me.fileImage.Name = "fileImage"
        Me.fileImage.Size = New System.Drawing.Size(284, 240)
        Me.fileImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        'btnSave
        Me.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnSave.Location = New System.Drawing.Point(110, 240)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.Text = "&Save..."
        Me.btnSave.UseVisualStyleBackColor = true
        AddHandler Me.btnSave.Click, AddressOf Me.btnSave_Click
        'btnClose
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(-87, -35)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabStop = false
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        AddHandler Me.btnClose.Click, AddressOf Me.btnClose_Click
        'ImageViewer
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(284, 263)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.fileImage)
        Me.Name = "ImageViewer"
        Me.ShowIcon = false
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.fileImage,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
    End Sub
    Private btnClose As System.Windows.Forms.Button
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
    
    Sub btnClose_Click()
        Me.Close()
    End Sub
End Class
