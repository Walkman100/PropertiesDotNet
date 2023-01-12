Imports System
Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        CType(Me.fileImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        'fileImage
        Me.fileImage.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fileImage.Location = New System.Drawing.Point(0, 0)
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
        Me.btnSave.UseVisualStyleBackColor = True
        'btnClose
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(-87, -35)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabStop = False
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        'ImageViewer
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(284, 263)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.fileImage)
        Me.Name = "ImageViewer"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        CType(Me.fileImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    End Sub
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents btnSave As System.Windows.Forms.Button
    Friend fileImage As System.Windows.Forms.PictureBox

    Sub New()
        InitializeComponent()

        Dim theme As WalkmanLib.Theme = Settings.GetTheme()
        WalkmanLib.ApplyTheme(theme, Me, True)
        If components IsNot Nothing Then WalkmanLib.ApplyTheme(theme, components.Components, True)
    End Sub

    Sub ImageViewer_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        If Me.Visible Then
            Me.CenterToParent()
        End If
    End Sub

    Sub btnSave_Click() Handles btnSave.Click
        Dim sfd As New SaveFileDialog With {
            .Title = "Save image",
            .FileName = PropertiesDotNet.imgFile.ImageLocation & ".png"
        }
        If sfd.ShowDialog = DialogResult.OK Then
            fileImage.Image.Save(sfd.FileName)
        End If
    End Sub

    Sub btnClose_Click() Handles btnClose.Click
        Me.Close()
    End Sub
End Class
