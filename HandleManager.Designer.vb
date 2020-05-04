Partial Class HandleManager
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
        Me.btnScan = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnKillProcess = New System.Windows.Forms.Button()
        Me.btnCloseHandle = New System.Windows.Forms.Button()
        Me.lstHandles = New System.Windows.Forms.ListView()
        Me.colHeadProcessID = New System.Windows.Forms.ColumnHeader()
        Me.colHeadProcessPath = New System.Windows.Forms.ColumnHeader()
        Me.colHeadHandleID = New System.Windows.Forms.ColumnHeader()
        Me.colHeadHandleName = New System.Windows.Forms.ColumnHeader()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.bwHandleScan = New System.ComponentModel.BackgroundWorker()
        Me.SuspendLayout
        '
        'btnScan
        '
        Me.btnScan.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnScan.Location = New System.Drawing.Point(822, 75)
        Me.btnScan.Name = "btnScan"
        Me.btnScan.Size = New System.Drawing.Size(100, 23)
        Me.btnScan.TabIndex = 11
        Me.btnScan.Text = "Start Scanning"
        Me.btnScan.UseVisualStyleBackColor = true
        '
        'btnClose
        '
        Me.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(822, 162)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(100, 23)
        Me.btnClose.TabIndex = 15
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = true
        '
        'btnKillProcess
        '
        Me.btnKillProcess.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnKillProcess.Enabled = false
        Me.btnKillProcess.Location = New System.Drawing.Point(822, 104)
        Me.btnKillProcess.Name = "btnKillProcess"
        Me.btnKillProcess.Size = New System.Drawing.Size(100, 23)
        Me.btnKillProcess.TabIndex = 12
        Me.btnKillProcess.Text = "Kill Process"
        Me.btnKillProcess.UseVisualStyleBackColor = true
        '
        'btnCloseHandle
        '
        Me.btnCloseHandle.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnCloseHandle.Enabled = false
        Me.btnCloseHandle.Location = New System.Drawing.Point(822, 133)
        Me.btnCloseHandle.Name = "btnCloseHandle"
        Me.btnCloseHandle.Size = New System.Drawing.Size(100, 23)
        Me.btnCloseHandle.TabIndex = 13
        Me.btnCloseHandle.Text = "Close Handle"
        Me.btnCloseHandle.UseVisualStyleBackColor = true
        '
        'lstHandles
        '
        Me.lstHandles.AllowColumnReorder = true
        Me.lstHandles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
                        Or System.Windows.Forms.AnchorStyles.Left)  _
                        Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.lstHandles.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colHeadProcessID, Me.colHeadProcessPath, Me.colHeadHandleID, Me.colHeadHandleName})
        Me.lstHandles.FullRowSelect = true
        Me.lstHandles.GridLines = true
        Me.lstHandles.HideSelection = false
        Me.lstHandles.LabelWrap = false
        Me.lstHandles.Location = New System.Drawing.Point(12, 12)
        Me.lstHandles.Name = "lstHandles"
        Me.lstHandles.Size = New System.Drawing.Size(804, 223)
        Me.lstHandles.TabIndex = 8
        Me.lstHandles.UseCompatibleStateImageBehavior = false
        Me.lstHandles.View = System.Windows.Forms.View.Details
        '
        'colHeadProcessID
        '
        Me.colHeadProcessID.Text = "Process ID"
        Me.colHeadProcessID.Width = 200
        '
        'colHeadProcessPath
        '
        Me.colHeadProcessPath.Text = "Process Path"
        Me.colHeadProcessPath.Width = 200
        '
        'colHeadHandleID
        '
        Me.colHeadHandleID.Text = "Handle ID"
        Me.colHeadHandleID.Width = 200
        '
        'colHeadHandleName
        '
        Me.colHeadHandleName.Text = "Handle Name"
        Me.colHeadHandleName.Width = 200
        '
        'lblStatus
        '
        Me.lblStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.lblStatus.AutoSize = true
        Me.lblStatus.Location = New System.Drawing.Point(12, 238)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(88, 13)
        Me.lblStatus.TabIndex = 16
        Me.lblStatus.Text = "Status: Starting..."
        '
        'bwHandleScan
        '
        Me.bwHandleScan.WorkerReportsProgress = true
        Me.bwHandleScan.WorkerSupportsCancellation = true
        '
        'HandleManager
        '
        Me.AcceptButton = Me.btnScan
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(934, 260)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.btnScan)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnKillProcess)
        Me.Controls.Add(Me.btnCloseHandle)
        Me.Controls.Add(Me.lstHandles)
        Me.Name = "HandleManager"
        Me.ShowIcon = false
        Me.ShowInTaskbar = false
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Processes using file: Checking..."
        Me.ResumeLayout(false)
        Me.PerformLayout
    End Sub
    Private WithEvents bwHandleScan As System.ComponentModel.BackgroundWorker
    Private lblStatus As System.Windows.Forms.Label
    Private colHeadHandleName As System.Windows.Forms.ColumnHeader
    Private colHeadHandleID As System.Windows.Forms.ColumnHeader
    Private colHeadProcessPath As System.Windows.Forms.ColumnHeader
    Private colHeadProcessID As System.Windows.Forms.ColumnHeader
    Private WithEvents lstHandles As System.Windows.Forms.ListView
    Private WithEvents btnCloseHandle As System.Windows.Forms.Button
    Private WithEvents btnKillProcess As System.Windows.Forms.Button
    Private btnClose As System.Windows.Forms.Button
    Private WithEvents btnScan As System.Windows.Forms.Button
End Class
