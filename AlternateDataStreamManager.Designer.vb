
Partial Class AlternateDataStreamManager
    Inherits System.Windows.Forms.Form
    
    ''' <summary>
    ''' Designer variable used to keep track of non-visual components.
    ''' </summary>
    Private components As System.ComponentModel.IContainer
    
    ''' <summary>
    ''' Disposes resources used by the form.
    ''' </summary>
    ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If components IsNot Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
    
    ''' <summary>
    ''' This method is required for Windows Forms designer support.
    ''' Do not change the method contents inside the source code editor. The Forms designer might
    ''' not be able to load this method if it was changed manually.
    ''' </summary>
    Private Sub InitializeComponent()
        Me.lstStreams = New System.Windows.Forms.ListView()
        Me.colStreamsName = New System.Windows.Forms.ColumnHeader()
        Me.colStreamsSize = New System.Windows.Forms.ColumnHeader()
        Me.colStreamsType = New System.Windows.Forms.ColumnHeader()
        Me.colStreamsAttributes = New System.Windows.Forms.ColumnHeader()
        Me.btnOpen = New System.Windows.Forms.Button()
        Me.btnView = New System.Windows.Forms.Button()
        Me.btnCopy = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.sfdSelectCopyTarget = New System.Windows.Forms.SaveFileDialog()
        Me.SuspendLayout
        '
        'lstStreams
        '
        Me.lstStreams.AllowColumnReorder = true
        Me.lstStreams.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
                        Or System.Windows.Forms.AnchorStyles.Left)  _
                        Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.lstStreams.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colStreamsName, Me.colStreamsSize, Me.colStreamsType, Me.colStreamsAttributes})
        Me.lstStreams.FullRowSelect = true
        Me.lstStreams.GridLines = true
        Me.lstStreams.HideSelection = false
        Me.lstStreams.LabelWrap = false
        Me.lstStreams.Location = New System.Drawing.Point(12, 12)
        Me.lstStreams.Name = "lstStreams"
        Me.lstStreams.Size = New System.Drawing.Size(419, 168)
        Me.lstStreams.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lstStreams.TabIndex = 0
        Me.lstStreams.UseCompatibleStateImageBehavior = false
        Me.lstStreams.View = System.Windows.Forms.View.Details
        '
        'colStreamsName
        '
        Me.colStreamsName.Text = "Name"
        '
        'colStreamsSize
        '
        Me.colStreamsSize.Text = "Size"
        '
        'colStreamsType
        '
        Me.colStreamsType.Text = "Type"
        '
        'colStreamsAttributes
        '
        Me.colStreamsAttributes.Text = "Attributes"
        '
        'btnOpen
        '
        Me.btnOpen.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnOpen.Image = Global.PropertiesDotNet.Resources.mouse_right_click_8x
        Me.btnOpen.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.btnOpen.Location = New System.Drawing.Point(437, 12)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(100, 23)
        Me.btnOpen.TabIndex = 1
        Me.btnOpen.Text = "Open in Notepad"
        Me.btnOpen.UseVisualStyleBackColor = true
        '
        'btnView
        '
        Me.btnView.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnView.Location = New System.Drawing.Point(437, 41)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(100, 23)
        Me.btnView.TabIndex = 2
        Me.btnView.Text = "View Contents"
        Me.btnView.UseVisualStyleBackColor = true
        '
        'btnCopy
        '
        Me.btnCopy.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnCopy.Location = New System.Drawing.Point(437, 99)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(100, 23)
        Me.btnCopy.TabIndex = 6
        Me.btnCopy.Text = "Copy Stream"
        Me.btnCopy.UseVisualStyleBackColor = true
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnDelete.Location = New System.Drawing.Point(437, 70)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(100, 23)
        Me.btnDelete.TabIndex = 5
        Me.btnDelete.Text = "Delete Stream"
        Me.btnDelete.UseVisualStyleBackColor = true
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnAdd.Location = New System.Drawing.Point(437, 128)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(100, 23)
        Me.btnAdd.TabIndex = 7
        Me.btnAdd.Text = "Add New"
        Me.btnAdd.UseVisualStyleBackColor = true
        '
        'btnClose
        '
        Me.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(437, 157)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(100, 23)
        Me.btnClose.TabIndex = 8
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = true
        '
        'sfdSelectCopyTarget
        '
        Me.sfdSelectCopyTarget.AddExtension = false
        Me.sfdSelectCopyTarget.DereferenceLinks = false
        Me.sfdSelectCopyTarget.Filter = "All Files|*.*"
        Me.sfdSelectCopyTarget.OverwritePrompt = false
        '
        'AlternateDataStreamManager
        '
        Me.AcceptButton = Me.btnOpen
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(549, 192)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnCopy)
        Me.Controls.Add(Me.btnView)
        Me.Controls.Add(Me.btnOpen)
        Me.Controls.Add(Me.lstStreams)
        Me.Name = "AlternateDataStreamManager"
        Me.ShowIcon = false
        Me.ShowInTaskbar = false
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Data Stream Manager"
        Me.ResumeLayout(false)
    End Sub
    Private sfdSelectCopyTarget As System.Windows.Forms.SaveFileDialog
    Private WithEvents btnCopy As System.Windows.Forms.Button
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents btnAdd As System.Windows.Forms.Button
    Private WithEvents btnDelete As System.Windows.Forms.Button
    Private WithEvents btnView As System.Windows.Forms.Button
    Private WithEvents btnOpen As System.Windows.Forms.Button
    Private colStreamsAttributes As System.Windows.Forms.ColumnHeader
    Private colStreamsType As System.Windows.Forms.ColumnHeader
    Private colStreamsSize As System.Windows.Forms.ColumnHeader
    Private colStreamsName As System.Windows.Forms.ColumnHeader
    Private WithEvents lstStreams As System.Windows.Forms.ListView
End Class
