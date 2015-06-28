<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PropertiesDotNet
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblLocation = New System.Windows.Forms.Label()
        Me.chkHidden = New System.Windows.Forms.CheckBox()
        Me.chkSystem = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout
        '
        'lblLocation
        '
        Me.lblLocation.AutoSize = true
        Me.lblLocation.Location = New System.Drawing.Point(41, 21)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(0, 13)
        Me.lblLocation.TabIndex = 0
        '
        'chkHidden
        '
        Me.chkHidden.AutoSize = true
        Me.chkHidden.Location = New System.Drawing.Point(28, 64)
        Me.chkHidden.Name = "chkHidden"
        Me.chkHidden.Size = New System.Drawing.Size(60, 17)
        Me.chkHidden.TabIndex = 1
        Me.chkHidden.Text = "Hidden"
        Me.chkHidden.UseVisualStyleBackColor = true
        '
        'chkSystem
        '
        Me.chkSystem.AutoSize = true
        Me.chkSystem.Location = New System.Drawing.Point(55, 102)
        Me.chkSystem.Name = "chkSystem"
        Me.chkSystem.Size = New System.Drawing.Size(60, 17)
        Me.chkSystem.TabIndex = 2
        Me.chkSystem.Text = "System"
        Me.chkSystem.UseVisualStyleBackColor = true
        '
        'PropertiesDotNet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(368, 174)
        Me.Controls.Add(Me.chkSystem)
        Me.Controls.Add(Me.chkHidden)
        Me.Controls.Add(Me.lblLocation)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "PropertiesDotNet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PropertiesDotNet"
        Me.ResumeLayout(false)
        Me.PerformLayout
    End Sub
    Private withevents chkSystem As System.Windows.Forms.CheckBox
    Private withevents chkHidden As System.Windows.Forms.CheckBox
    Private lblLocation As System.Windows.Forms.Label

End Class
