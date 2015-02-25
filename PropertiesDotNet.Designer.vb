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
        Me.txtInOne = New System.Windows.Forms.TextBox()
        Me.lblIn1 = New System.Windows.Forms.Label()
        Me.txtInTwo = New System.Windows.Forms.TextBox()
        Me.lblOp = New System.Windows.Forms.Label()
        Me.lblIn2 = New System.Windows.Forms.Label()
        Me.lblEquals = New System.Windows.Forms.Label()
        Me.txtOutput = New System.Windows.Forms.TextBox()
        Me.lblOut = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnSub = New System.Windows.Forms.Button()
        Me.btnDivide = New System.Windows.Forms.Button()
        Me.btnMulti = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.SuspendLayout
        '
        'txtInOne
        '
        Me.txtInOne.Location = New System.Drawing.Point(12, 25)
        Me.txtInOne.Name = "txtInOne"
        Me.txtInOne.Size = New System.Drawing.Size(100, 20)
        Me.txtInOne.TabIndex = 0
        '
        'lblIn1
        '
        Me.lblIn1.AutoSize = true
        Me.lblIn1.Location = New System.Drawing.Point(46, 9)
        Me.lblIn1.Name = "lblIn1"
        Me.lblIn1.Size = New System.Drawing.Size(54, 13)
        Me.lblIn1.TabIndex = 1
        Me.lblIn1.Text = "Input One"
        '
        'txtInTwo
        '
        Me.txtInTwo.Location = New System.Drawing.Point(130, 25)
        Me.txtInTwo.Name = "txtInTwo"
        Me.txtInTwo.Size = New System.Drawing.Size(100, 20)
        Me.txtInTwo.TabIndex = 2
        '
        'lblOp
        '
        Me.lblOp.AutoSize = true
        Me.lblOp.Location = New System.Drawing.Point(118, 28)
        Me.lblOp.Name = "lblOp"
        Me.lblOp.Size = New System.Drawing.Size(0, 13)
        Me.lblOp.TabIndex = 3
        '
        'lblIn2
        '
        Me.lblIn2.AutoSize = true
        Me.lblIn2.Location = New System.Drawing.Point(166, 9)
        Me.lblIn2.Name = "lblIn2"
        Me.lblIn2.Size = New System.Drawing.Size(55, 13)
        Me.lblIn2.TabIndex = 4
        Me.lblIn2.Text = "Input Two"
        '
        'lblEquals
        '
        Me.lblEquals.AutoSize = true
        Me.lblEquals.Location = New System.Drawing.Point(236, 28)
        Me.lblEquals.Name = "lblEquals"
        Me.lblEquals.Size = New System.Drawing.Size(13, 13)
        Me.lblEquals.TabIndex = 5
        Me.lblEquals.Text = "="
        '
        'txtOutput
        '
        Me.txtOutput.Location = New System.Drawing.Point(255, 25)
        Me.txtOutput.Name = "txtOutput"
        Me.txtOutput.Size = New System.Drawing.Size(100, 20)
        Me.txtOutput.TabIndex = 6
        '
        'lblOut
        '
        Me.lblOut.AutoSize = true
        Me.lblOut.Location = New System.Drawing.Point(292, 9)
        Me.lblOut.Name = "lblOut"
        Me.lblOut.Size = New System.Drawing.Size(39, 13)
        Me.lblOut.TabIndex = 7
        Me.lblOut.Text = "Output"
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(12, 108)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 8
        Me.btnAdd.Text = "+"
        Me.btnAdd.UseVisualStyleBackColor = true
        '
        'btnSub
        '
        Me.btnSub.Location = New System.Drawing.Point(93, 108)
        Me.btnSub.Name = "btnSub"
        Me.btnSub.Size = New System.Drawing.Size(75, 23)
        Me.btnSub.TabIndex = 9
        Me.btnSub.Text = "-"
        Me.btnSub.UseVisualStyleBackColor = true
        '
        'btnDivide
        '
        Me.btnDivide.Location = New System.Drawing.Point(12, 137)
        Me.btnDivide.Name = "btnDivide"
        Me.btnDivide.Size = New System.Drawing.Size(75, 23)
        Me.btnDivide.TabIndex = 10
        Me.btnDivide.Text = "/"
        Me.btnDivide.UseVisualStyleBackColor = true
        '
        'btnMulti
        '
        Me.btnMulti.Location = New System.Drawing.Point(93, 137)
        Me.btnMulti.Name = "btnMulti"
        Me.btnMulti.Size = New System.Drawing.Size(75, 23)
        Me.btnMulti.TabIndex = 11
        Me.btnMulti.Text = "*"
        Me.btnMulti.UseVisualStyleBackColor = true
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(280, 137)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 12
        Me.btnExit.Text = "Close"
        Me.btnExit.UseVisualStyleBackColor = true
        '
        'PropertiesDotNet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(368, 174)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnMulti)
        Me.Controls.Add(Me.btnDivide)
        Me.Controls.Add(Me.btnSub)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.lblOut)
        Me.Controls.Add(Me.txtOutput)
        Me.Controls.Add(Me.lblEquals)
        Me.Controls.Add(Me.lblIn2)
        Me.Controls.Add(Me.lblOp)
        Me.Controls.Add(Me.txtInTwo)
        Me.Controls.Add(Me.lblIn1)
        Me.Controls.Add(Me.txtInOne)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "PropertiesDotNet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PropertiesDotNet"
        Me.ResumeLayout(false)
        Me.PerformLayout
    End Sub
    Private btnExit As System.Windows.Forms.Button
    Private btnMulti As System.Windows.Forms.Button
    Private btnDivide As System.Windows.Forms.Button
    Private btnSub As System.Windows.Forms.Button
    Private btnAdd As System.Windows.Forms.Button
    Private lblOut As System.Windows.Forms.Label
    Private txtOutput As System.Windows.Forms.TextBox
    Private lblEquals As System.Windows.Forms.Label
    Private lblIn2 As System.Windows.Forms.Label
    Private lblOp As System.Windows.Forms.Label
    Private txtInTwo As System.Windows.Forms.TextBox
    Private lblIn1 As System.Windows.Forms.Label
    Private txtInOne As System.Windows.Forms.TextBox

End Class
