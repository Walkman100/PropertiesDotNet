<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        CType(Me.imgLoading,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        'lblStatus
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.AutoSize = true
        Me.lblStatus.Location = New System.Drawing.Point(34, 14)
        Me.lblStatus.Text = "Starting compression..."
        'imgLoading
        Me.imgLoading.Name = "imgLoading"
        Me.imgLoading.Image = Global.PropertiesDotNet.My.Resources.Resources.loading4
        Me.imgLoading.Location = New System.Drawing.Point(12, 12)
        Me.imgLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.imgLoading.TabStop = false
        'CompressReport
        Me.Name = "CompressReport"
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(334, 40)
        Me.Controls.Add(Me.imgLoading)
        Me.Controls.Add(Me.lblStatus)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = Global.PropertiesDotNet.My.Resources.Resources.compress
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Compressing..."
        CType(Me.imgLoading,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout
    End Sub
    Friend lblStatus As System.Windows.Forms.Label
    Private imgLoading As System.Windows.Forms.PictureBox
End Class