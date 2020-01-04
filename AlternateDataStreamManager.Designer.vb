﻿
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
        Me.btnRename = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnType = New System.Windows.Forms.Button()
        Me.btnAttributes = New System.Windows.Forms.Button()
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
        Me.lstStreams.Size = New System.Drawing.Size(419, 226)
        Me.lstStreams.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lstStreams.TabIndex = 1
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
        Me.btnOpen.TabIndex = 2
        Me.btnOpen.Text = "Open"
        Me.btnOpen.UseVisualStyleBackColor = true
        '
        'btnView
        '
        Me.btnView.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnView.Location = New System.Drawing.Point(437, 41)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(100, 23)
        Me.btnView.TabIndex = 3
        Me.btnView.Text = "View Contents"
        Me.btnView.UseVisualStyleBackColor = true
        '
        'btnRename
        '
        Me.btnRename.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnRename.Location = New System.Drawing.Point(437, 128)
        Me.btnRename.Name = "btnRename"
        Me.btnRename.Size = New System.Drawing.Size(100, 23)
        Me.btnRename.TabIndex = 4
        Me.btnRename.Text = "Rename"
        Me.btnRename.UseVisualStyleBackColor = true
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnDelete.Location = New System.Drawing.Point(437, 157)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(100, 23)
        Me.btnDelete.TabIndex = 5
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = true
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnAdd.Location = New System.Drawing.Point(437, 186)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(100, 23)
        Me.btnAdd.TabIndex = 6
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = true
        '
        'btnClose
        '
        Me.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(437, 215)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(100, 23)
        Me.btnClose.TabIndex = 7
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = true
        '
        'btnType
        '
        Me.btnType.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnType.Location = New System.Drawing.Point(437, 70)
        Me.btnType.Name = "btnType"
        Me.btnType.Size = New System.Drawing.Size(100, 23)
        Me.btnType.TabIndex = 8
        Me.btnType.Text = "Change Type"
        Me.btnType.UseVisualStyleBackColor = true
        '
        'btnAttributes
        '
        Me.btnAttributes.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnAttributes.Location = New System.Drawing.Point(437, 99)
        Me.btnAttributes.Name = "btnAttributes"
        Me.btnAttributes.Size = New System.Drawing.Size(100, 23)
        Me.btnAttributes.TabIndex = 9
        Me.btnAttributes.Text = "Change Attributes"
        Me.btnAttributes.UseVisualStyleBackColor = true
        '
        'AlternateDataStreamManager
        '
        Me.AcceptButton = Me.btnOpen
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(549, 250)
        Me.Controls.Add(Me.btnAttributes)
        Me.Controls.Add(Me.btnType)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnRename)
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
    Private WithEvents btnAttributes As System.Windows.Forms.Button
    Private WithEvents btnType As System.Windows.Forms.Button
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents btnAdd As System.Windows.Forms.Button
    Private WithEvents btnDelete As System.Windows.Forms.Button
    Private WithEvents btnRename As System.Windows.Forms.Button
    Private WithEvents btnView As System.Windows.Forms.Button
    Private WithEvents btnOpen As System.Windows.Forms.Button
    Private colStreamsAttributes As System.Windows.Forms.ColumnHeader
    Private colStreamsType As System.Windows.Forms.ColumnHeader
    Private colStreamsSize As System.Windows.Forms.ColumnHeader
    Private colStreamsName As System.Windows.Forms.ColumnHeader
    Private WithEvents lstStreams As System.Windows.Forms.ListView
End Class