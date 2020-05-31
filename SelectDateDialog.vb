Public Class SelectDateDialog
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
        Me.dateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.monthCalendar = New System.Windows.Forms.MonthCalendar()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.SuspendLayout
        'dateTimePicker
        Me.dateTimePicker.CustomFormat = "dddd, dd MMMM yyyy, HH:mm:ss"
        Me.dateTimePicker.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dateTimePicker.Location = New System.Drawing.Point(0, 0)
        Me.dateTimePicker.Name = "dateTimePicker"
        Me.dateTimePicker.Size = New System.Drawing.Size(263, 20)
        Me.dateTimePicker.TabIndex = 0
        'monthCalendar
        Me.monthCalendar.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.monthCalendar.Location = New System.Drawing.Point(18, 32)
        Me.monthCalendar.MaxSelectionCount = 1
        Me.monthCalendar.Name = "monthCalendar"
        Me.monthCalendar.TabIndex = 1
        'btnCancel
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(134, 206)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = true
        'btnSave
        Me.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnSave.Location = New System.Drawing.Point(53, 206)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = true
        'SelectDateDialog
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(263, 241)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.monthCalendar)
        Me.Controls.Add(Me.dateTimePicker)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "SelectDateDialog"
        Me.ShowIcon = false
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Choose a date:"
        Me.ResumeLayout(false)
    End Sub
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents btnCancel As System.Windows.Forms.Button
    Private WithEvents monthCalendar As System.Windows.Forms.MonthCalendar
    Public WithEvents dateTimePicker As System.Windows.Forms.DateTimePicker
    
    Public Sub New()
        Me.InitializeComponent()
    End Sub
    
    Sub SelectDateDialog_VisibleChanged() Handles Me.VisibleChanged
        If Me.Visible Then
            Me.CenterToParent()
        End If
    End Sub
    
    Sub dateTimePicker_ValueChanged() Handles dateTimePicker.ValueChanged
        monthCalendar.SelectionStart = dateTimePicker.Value
        monthCalendar.SelectionEnd = dateTimePicker.Value
    End Sub
    
    Sub monthCalendar_DateSelected() Handles monthCalendar.DateSelected
        dateTimePicker.Value = monthCalendar.SelectionStart
    End Sub
    
    Sub CloseSelectDateDialog() Handles btnCancel.Click
        Me.Close
        Me.DestroyHandle()
        Me.Dispose()
    End Sub
    
    Sub btnSave_Click() Handles btnSave.Click
        If Not IsNothing(_saveAction) Then
            _saveAction.Invoke()
        End If
        CloseSelectDateDialog()
    End Sub
    
    Private _saveAction As Action
    Public WriteOnly Property SaveAction As Action
        Set(value As Action)
            _saveAction = value
        End Set
    End Property
End Class
