Imports System
Imports System.IO
Imports System.Security
Imports System.Security.Cryptography
Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Public Class Hashes
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
        Me.grpMD5 = New System.Windows.Forms.GroupBox()
        Me.btnMD5Copy = New System.Windows.Forms.Button()
        Me.lblMD5 = New System.Windows.Forms.TextBox()
        Me.btnMD5 = New System.Windows.Forms.Button()
        Me.grpSHA1 = New System.Windows.Forms.GroupBox()
        Me.btnSHA1Copy = New System.Windows.Forms.Button()
        Me.lblSHA1 = New System.Windows.Forms.TextBox()
        Me.btnSHA1 = New System.Windows.Forms.Button()
        Me.grpSHA256 = New System.Windows.Forms.GroupBox()
        Me.btnSHA256Copy = New System.Windows.Forms.Button()
        Me.lblSHA256 = New System.Windows.Forms.TextBox()
        Me.btnSHA256 = New System.Windows.Forms.Button()
        Me.btnAllCopy = New System.Windows.Forms.Button()
        Me.btnAllCalculate = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.pbCalculateProgress = New wyDay.Controls.Windows7ProgressBar()
        Me.bwCalcHashes = New System.ComponentModel.BackgroundWorker()
        Me.grpSHA512 = New System.Windows.Forms.GroupBox()
        Me.btnSHA512Copy = New System.Windows.Forms.Button()
        Me.lblSHA512 = New System.Windows.Forms.TextBox()
        Me.btnSHA512 = New System.Windows.Forms.Button()
        Me.btnAllCancel = New System.Windows.Forms.Button()
        Me.grpMD5.SuspendLayout()
        Me.grpSHA1.SuspendLayout()
        Me.grpSHA256.SuspendLayout()
        Me.grpSHA512.SuspendLayout()
        Me.SuspendLayout()
        'grpMD5
        Me.grpMD5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpMD5.Controls.Add(Me.btnMD5Copy)
        Me.grpMD5.Controls.Add(Me.lblMD5)
        Me.grpMD5.Controls.Add(Me.btnMD5)
        Me.grpMD5.Location = New System.Drawing.Point(3, 4)
        Me.grpMD5.Name = "grpMD5"
        Me.grpMD5.Size = New System.Drawing.Size(510, 50)
        Me.grpMD5.TabIndex = 0
        Me.grpMD5.TabStop = False
        Me.grpMD5.Text = "MD5"
        'btnMD5Copy
        Me.btnMD5Copy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMD5Copy.Location = New System.Drawing.Point(460, 19)
        Me.btnMD5Copy.Name = "btnMD5Copy"
        Me.btnMD5Copy.Size = New System.Drawing.Size(44, 23)
        Me.btnMD5Copy.TabIndex = 2
        Me.btnMD5Copy.Text = "Copy"
        Me.btnMD5Copy.UseVisualStyleBackColor = True
        'lblMD5
        Me.lblMD5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMD5.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblMD5.Location = New System.Drawing.Point(87, 24)
        Me.lblMD5.Name = "lblMD5"
        Me.lblMD5.ReadOnly = True
        Me.lblMD5.Size = New System.Drawing.Size(367, 13)
        Me.lblMD5.TabIndex = 1
        Me.lblMD5.Text = "Click ""Calculate"""
        'btnMD5
        Me.btnMD5.Location = New System.Drawing.Point(6, 19)
        Me.btnMD5.Name = "btnMD5"
        Me.btnMD5.Size = New System.Drawing.Size(75, 23)
        Me.btnMD5.TabIndex = 0
        Me.btnMD5.Text = "Calculate..."
        Me.btnMD5.UseVisualStyleBackColor = True
        'grpSHA1
        Me.grpSHA1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpSHA1.Controls.Add(Me.btnSHA1Copy)
        Me.grpSHA1.Controls.Add(Me.lblSHA1)
        Me.grpSHA1.Controls.Add(Me.btnSHA1)
        Me.grpSHA1.Location = New System.Drawing.Point(3, 60)
        Me.grpSHA1.Name = "grpSHA1"
        Me.grpSHA1.Size = New System.Drawing.Size(510, 50)
        Me.grpSHA1.TabIndex = 1
        Me.grpSHA1.TabStop = False
        Me.grpSHA1.Text = "SHA-1"
        'btnSHA1Copy
        Me.btnSHA1Copy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSHA1Copy.Location = New System.Drawing.Point(460, 19)
        Me.btnSHA1Copy.Name = "btnSHA1Copy"
        Me.btnSHA1Copy.Size = New System.Drawing.Size(44, 23)
        Me.btnSHA1Copy.TabIndex = 2
        Me.btnSHA1Copy.Text = "Copy"
        Me.btnSHA1Copy.UseVisualStyleBackColor = True
        'lblSHA1
        Me.lblSHA1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSHA1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblSHA1.Location = New System.Drawing.Point(87, 24)
        Me.lblSHA1.Name = "lblSHA1"
        Me.lblSHA1.ReadOnly = True
        Me.lblSHA1.Size = New System.Drawing.Size(367, 13)
        Me.lblSHA1.TabIndex = 1
        Me.lblSHA1.Text = "Click ""Calculate"""
        'btnSHA1
        Me.btnSHA1.Location = New System.Drawing.Point(6, 19)
        Me.btnSHA1.Name = "btnSHA1"
        Me.btnSHA1.Size = New System.Drawing.Size(75, 23)
        Me.btnSHA1.TabIndex = 0
        Me.btnSHA1.Text = "Calculate..."
        Me.btnSHA1.UseVisualStyleBackColor = True
        'grpSHA256
        Me.grpSHA256.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpSHA256.Controls.Add(Me.btnSHA256Copy)
        Me.grpSHA256.Controls.Add(Me.lblSHA256)
        Me.grpSHA256.Controls.Add(Me.btnSHA256)
        Me.grpSHA256.Location = New System.Drawing.Point(3, 116)
        Me.grpSHA256.Name = "grpSHA256"
        Me.grpSHA256.Size = New System.Drawing.Size(510, 50)
        Me.grpSHA256.TabIndex = 2
        Me.grpSHA256.TabStop = False
        Me.grpSHA256.Text = "SHA-256"
        'btnSHA256Copy
        Me.btnSHA256Copy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSHA256Copy.Location = New System.Drawing.Point(460, 19)
        Me.btnSHA256Copy.Name = "btnSHA256Copy"
        Me.btnSHA256Copy.Size = New System.Drawing.Size(44, 23)
        Me.btnSHA256Copy.TabIndex = 2
        Me.btnSHA256Copy.Text = "Copy"
        Me.btnSHA256Copy.UseVisualStyleBackColor = True
        'lblSHA256
        Me.lblSHA256.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSHA256.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblSHA256.Location = New System.Drawing.Point(87, 24)
        Me.lblSHA256.Name = "lblSHA256"
        Me.lblSHA256.ReadOnly = True
        Me.lblSHA256.Size = New System.Drawing.Size(367, 13)
        Me.lblSHA256.TabIndex = 1
        Me.lblSHA256.Text = "Click ""Calculate"""
        'btnSHA256
        Me.btnSHA256.Location = New System.Drawing.Point(6, 19)
        Me.btnSHA256.Name = "btnSHA256"
        Me.btnSHA256.Size = New System.Drawing.Size(75, 23)
        Me.btnSHA256.TabIndex = 0
        Me.btnSHA256.Text = "Calculate..."
        Me.btnSHA256.UseVisualStyleBackColor = True
        'btnAllCopy
        Me.btnAllCopy.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAllCopy.Location = New System.Drawing.Point(265, 257)
        Me.btnAllCopy.Name = "btnAllCopy"
        Me.btnAllCopy.Size = New System.Drawing.Size(116, 23)
        Me.btnAllCopy.TabIndex = 7
        Me.btnAllCopy.Text = "Copy All"
        Me.btnAllCopy.UseVisualStyleBackColor = True
        'btnAllCalculate
        Me.btnAllCalculate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAllCalculate.Location = New System.Drawing.Point(12, 257)
        Me.btnAllCalculate.Name = "btnAllCalculate"
        Me.btnAllCalculate.Size = New System.Drawing.Size(116, 23)
        Me.btnAllCalculate.TabIndex = 5
        Me.btnAllCalculate.Text = "Calculate All..."
        Me.btnAllCalculate.UseVisualStyleBackColor = True
        'btnClose
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnClose.Location = New System.Drawing.Point(387, 257)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(116, 23)
        Me.btnClose.TabIndex = 8
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        'pbCalculateProgress
        Me.pbCalculateProgress.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbCalculateProgress.ContainerControl = Me
        Me.pbCalculateProgress.Location = New System.Drawing.Point(9, 228)
        Me.pbCalculateProgress.Name = "pbCalculateProgress"
        Me.pbCalculateProgress.ShowInTaskbar = True
        Me.pbCalculateProgress.Size = New System.Drawing.Size(498, 23)
        Me.pbCalculateProgress.TabIndex = 4
        'bwCalcHashes
        Me.bwCalcHashes.WorkerReportsProgress = True
        Me.bwCalcHashes.WorkerSupportsCancellation = True
        'grpSHA512
        Me.grpSHA512.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpSHA512.Controls.Add(Me.btnSHA512Copy)
        Me.grpSHA512.Controls.Add(Me.lblSHA512)
        Me.grpSHA512.Controls.Add(Me.btnSHA512)
        Me.grpSHA512.Location = New System.Drawing.Point(3, 172)
        Me.grpSHA512.Name = "grpSHA512"
        Me.grpSHA512.Size = New System.Drawing.Size(510, 50)
        Me.grpSHA512.TabIndex = 3
        Me.grpSHA512.TabStop = False
        Me.grpSHA512.Text = "SHA-512"
        'btnSHA512Copy
        Me.btnSHA512Copy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSHA512Copy.Location = New System.Drawing.Point(460, 19)
        Me.btnSHA512Copy.Name = "btnSHA512Copy"
        Me.btnSHA512Copy.Size = New System.Drawing.Size(44, 23)
        Me.btnSHA512Copy.TabIndex = 2
        Me.btnSHA512Copy.Text = "Copy"
        Me.btnSHA512Copy.UseVisualStyleBackColor = True
        'lblSHA512
        Me.lblSHA512.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSHA512.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblSHA512.Location = New System.Drawing.Point(87, 24)
        Me.lblSHA512.Name = "lblSHA512"
        Me.lblSHA512.ReadOnly = True
        Me.lblSHA512.Size = New System.Drawing.Size(367, 13)
        Me.lblSHA512.TabIndex = 1
        Me.lblSHA512.Text = "Click ""Calculate"""
        'btnSHA512
        Me.btnSHA512.Location = New System.Drawing.Point(6, 19)
        Me.btnSHA512.Name = "btnSHA512"
        Me.btnSHA512.Size = New System.Drawing.Size(75, 23)
        Me.btnSHA512.TabIndex = 0
        Me.btnSHA512.Text = "Calculate..."
        Me.btnSHA512.UseVisualStyleBackColor = True
        'btnAllCancel
        Me.btnAllCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAllCancel.Enabled = False
        Me.btnAllCancel.Location = New System.Drawing.Point(134, 257)
        Me.btnAllCancel.Name = "btnAllCancel"
        Me.btnAllCancel.Size = New System.Drawing.Size(125, 23)
        Me.btnAllCancel.TabIndex = 6
        Me.btnAllCancel.Text = "Cancel All"
        Me.btnAllCancel.UseVisualStyleBackColor = True
        'Hashes
        Me.AcceptButton = Me.btnAllCalculate
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(515, 293)
        Me.Controls.Add(Me.btnAllCancel)
        Me.Controls.Add(Me.grpSHA512)
        Me.Controls.Add(Me.pbCalculateProgress)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnAllCopy)
        Me.Controls.Add(Me.grpSHA256)
        Me.Controls.Add(Me.btnAllCalculate)
        Me.Controls.Add(Me.grpSHA1)
        Me.Controls.Add(Me.grpMD5)
        Me.Icon = My.Resources.hashx64
        Me.Name = "Hashes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        'Me.Location = New System.Drawing.Size((My.Computer.Screen.WorkingArea.Width/2) - 257.5, (My.Computer.Screen.WorkingArea.Height/2) - 146.5)
        Me.Text = "Generate Hashes: <filename>"
        Me.grpMD5.ResumeLayout(False)
        Me.grpMD5.PerformLayout()
        Me.grpSHA1.ResumeLayout(False)
        Me.grpSHA1.PerformLayout()
        Me.grpSHA256.ResumeLayout(False)
        Me.grpSHA256.PerformLayout()
        Me.grpSHA512.ResumeLayout(False)
        Me.grpSHA512.PerformLayout()
        Me.ResumeLayout(False)
    End Sub
    Private WithEvents btnAllCancel As System.Windows.Forms.Button
    Private WithEvents btnSHA512 As System.Windows.Forms.Button
    Private lblSHA512 As System.Windows.Forms.TextBox
    Private WithEvents btnSHA512Copy As System.Windows.Forms.Button
    Private grpSHA512 As System.Windows.Forms.GroupBox
    Private WithEvents bwCalcHashes As System.ComponentModel.BackgroundWorker
    Private pbCalculateProgress As wyDay.Controls.Windows7ProgressBar
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents btnAllCalculate As System.Windows.Forms.Button
    Private WithEvents btnAllCopy As System.Windows.Forms.Button
    Private WithEvents btnSHA256 As System.Windows.Forms.Button
    Private lblSHA256 As System.Windows.Forms.TextBox
    Private WithEvents btnSHA256Copy As System.Windows.Forms.Button
    Private grpSHA256 As System.Windows.Forms.GroupBox
    Private WithEvents btnSHA1 As System.Windows.Forms.Button
    Private lblSHA1 As System.Windows.Forms.TextBox
    Private WithEvents btnSHA1Copy As System.Windows.Forms.Button
    Private grpSHA1 As System.Windows.Forms.GroupBox
    Private WithEvents btnMD5 As System.Windows.Forms.Button
    Private lblMD5 As System.Windows.Forms.TextBox
    Private WithEvents btnMD5Copy As System.Windows.Forms.Button
    Private grpMD5 As System.Windows.Forms.GroupBox

    ''' End Designer code

    Dim hashQueue As String

    ''' <summary>Removes a hash type string from the queue. WARNING: cannot remove the first hash in queue - but that is currently being hashed anyway.</summary>
    ''' <param name="type">The hash type to remove</param>
    Sub ClearHashFromQueue(type As String) ' given queue of `MD5 SHA1` and argument of `SHA1` will result in `MD5` - this is _
        If hashQueue.Contains(type) Then   ' to remove the space \/
            hashQueue = hashQueue.Remove(hashQueue.IndexOf(type) - 1) & hashQueue.Substring(hashQueue.IndexOf(type) + type.Length)
        End If
    End Sub

    Sub SetAllToQueue()
        btnMD5.Text = "Queue"
        btnSHA1.Text = "Queue"
        btnSHA256.Text = "Queue"
        btnSHA512.Text = "Queue"
    End Sub

    Sub Hashes_VisibleChanged() Handles Me.VisibleChanged
        If Me.Visible Then
            Me.CenterToParent()
        End If
    End Sub

    ' Starting & stopping

    Sub btnMD5_Click() Handles btnMD5.Click
        Select Case btnMD5.Text
            Case "Calculate..."
                hashQueue = "MD5"
                SetAllToQueue()
                bwCalcHashes.RunWorkerAsync(PropertiesDotNet.lblLocation.Text)
            Case "Cancel"
                bwCalcHashes.CancelAsync()
            Case "Queue"
                hashQueue &= " MD5"
                btnMD5.Text = "Unqueue"
            Case "Unqueue"
                ClearHashFromQueue("MD5")
                btnMD5.Text = "Queue"
        End Select
    End Sub

    Sub btnSHA1_Click() Handles btnSHA1.Click
        Select Case btnSHA1.Text
            Case "Calculate..."
                hashQueue = "SHA1"
                SetAllToQueue()
                bwCalcHashes.RunWorkerAsync(PropertiesDotNet.lblLocation.Text)
            Case "Cancel"
                bwCalcHashes.CancelAsync()
            Case "Queue"
                hashQueue &= " SHA1"
                btnSHA1.Text = "Unqueue"
            Case "Unqueue"
                ClearHashFromQueue("SHA1")
                btnSHA1.Text = "Queue"
        End Select
    End Sub

    Sub btnSHA256_Click() Handles btnSHA256.Click
        Select Case btnSHA256.Text
            Case "Calculate..."
                hashQueue = "SHA256"
                SetAllToQueue()
                bwCalcHashes.RunWorkerAsync(PropertiesDotNet.lblLocation.Text)
            Case "Cancel"
                bwCalcHashes.CancelAsync()
            Case "Queue"
                hashQueue &= " SHA256"
                btnSHA256.Text = "Unqueue"
            Case "Unqueue"
                ClearHashFromQueue("SHA256")
                btnSHA256.Text = "Queue"
        End Select
    End Sub

    Sub btnSHA512_Click() Handles btnSHA512.Click
        Select Case btnSHA512.Text
            Case "Calculate..."
                hashQueue = "SHA512"
                SetAllToQueue()
                bwCalcHashes.RunWorkerAsync(PropertiesDotNet.lblLocation.Text)
            Case "Cancel"
                bwCalcHashes.CancelAsync()
            Case "Queue"
                hashQueue &= " SHA512"
                btnSHA512.Text = "Unqueue"
            Case "Unqueue"
                ClearHashFromQueue("SHA512")
                btnSHA512.Text = "Queue"
        End Select
    End Sub

    Sub btnAllCalculate_Click() Handles btnAllCalculate.Click
        hashQueue = "MD5 SHA1 SHA256 SHA512"
        bwCalcHashes.RunWorkerAsync(PropertiesDotNet.lblLocation.Text)
        btnSHA1.Text = "Unqueue"
        btnSHA256.Text = "Unqueue"
        btnSHA512.Text = "Unqueue"
    End Sub

    Sub btnAllCancel_Click() Handles btnAllCancel.Click
        If hashQueue.StartsWith("MD5") Then
            hashQueue = "MD5"
        ElseIf hashQueue.StartsWith("SHA1") Then
            hashQueue = "SHA1"
        ElseIf hashQueue.StartsWith("SHA256") Then
            hashQueue = "SHA256"
        ElseIf hashQueue.StartsWith("SHA512") Then
            hashQueue = "SHA512"
        Else
            Exit Sub
        End If
        bwCalcHashes.CancelAsync()

        Do Until bwCalcHashes.CancellationPending
            bwCalcHashes.CancelAsync()
        Loop
        btnAllCancel.Enabled = False
    End Sub

    Sub btnClose_Click() Handles btnClose.Click
        Me.Hide()
    End Sub

    ' Copying output

    Sub btnMD5Copy_Click() Handles btnMD5Copy.Click
        WalkmanLib.SafeSetText(lblMD5.Text, "default")
    End Sub

    Sub btnSHA1Copy_Click() Handles btnSHA1Copy.Click
        WalkmanLib.SafeSetText(lblSHA1.Text, "default")
    End Sub

    Sub btnSHA256Copy_Click() Handles btnSHA256Copy.Click
        WalkmanLib.SafeSetText(lblSHA256.Text, "default")
    End Sub

    Sub btnSHA512Copy_Click() Handles btnSHA512Copy.Click
        WalkmanLib.SafeSetText(lblSHA512.Text, "default")
    End Sub

    Sub btnAllCopy_Click() Handles btnAllCopy.Click
        Dim ToCopy As String
        ToCopy = "MD5: " & CheckGenerated(lblMD5.Text) & Environment.NewLine
        ToCopy &= "SHA1: " & CheckGenerated(lblSHA1.Text) & Environment.NewLine
        ToCopy &= "SHA256: " & CheckGenerated(lblSHA256.Text) & Environment.NewLine
        ToCopy &= "SHA512: " & CheckGenerated(lblSHA512.Text)

        WalkmanLib.SafeSetText(ToCopy)
    End Sub
    Function CheckGenerated(status As String) As String
        If status = "Click ""Calculate""" Then
            Return "Not generated"
        ElseIf status = "Operation was cancelled" Then
            Return "Not generated"
        Else
            Return status
        End If
    End Function

    ' Original code, thanks to http://us.informatiweb.net/programmation/36--generate-hashes-md5-sha-1-and-sha-256-of-a-file.html
    ' Code that reports progress, thanks to http://www.infinitec.de/post/2007/06/09/Displaying-progress-updates-when-hashing-large-files.aspx

    Dim hashHex As String
    Dim hashObject As HashAlgorithm
    Dim buffer As Byte()
    Dim bytesRead As Integer
    Dim totalBytesRead As Long = 0

    Sub bwCalcHashes_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwCalcHashes.DoWork
        Dim FilePropertiesStream As FileStream = Nothing
        Try
            ' Set up GUI
            btnAllCalculate.Enabled = False
            btnAllCancel.Enabled = True
            bwCalcHashes.ReportProgress(0)

            HashGeneratorOutput("Creating hash object...")
            If hashQueue.StartsWith("MD5") Then
                hashObject = MD5.Create
                btnMD5.Text = "Cancel"
            ElseIf hashQueue.StartsWith("SHA1") Then
                hashObject = SHA1.Create
                btnSHA1.Text = "Cancel"
            ElseIf hashQueue.StartsWith("SHA256") Then
                hashObject = SHA256.Create
                btnSHA256.Text = "Cancel"
            ElseIf hashQueue.StartsWith("SHA384") Then
                hashObject = SHA384.Create
            ElseIf hashQueue.StartsWith("SHA512") Then
                hashObject = SHA512.Create
                btnSHA512.Text = "Cancel"
            End If

            HashGeneratorOutput("Opening file...")
            FilePropertiesStream = File.OpenRead(e.Argument.ToString)

            HashGeneratorOutput("Setting file position...")
            FilePropertiesStream.Position = 0

            HashGeneratorOutput("Setting up variables...")
            buffer = New Byte(4095) {}
            bytesRead = FilePropertiesStream.Read(buffer, 0, buffer.Length)
            totalBytesRead = bytesRead

            HashGeneratorOutput("Generating hash byte array...")
            Dim lastProgressPercent As Integer = 0
            Dim currentProgressPercent As Integer
            Do While bytesRead <> 0
                hashObject.TransformBlock(buffer, 0, bytesRead, buffer, 0)
                buffer = New Byte(4095) {}
                bytesRead = FilePropertiesStream.Read(buffer, 0, buffer.Length)
                totalBytesRead += bytesRead

                If bwCalcHashes.CancellationPending Then Throw New OperationCanceledException("Operation was cancelled")
                currentProgressPercent = CInt(Math.Truncate(CDbl(totalBytesRead) * 100 / FilePropertiesStream.Length))
                If currentProgressPercent > lastProgressPercent Then
                    bwCalcHashes.ReportProgress(currentProgressPercent)
                    lastProgressPercent = currentProgressPercent
                End If
            Loop
            hashObject.TransformFinalBlock(buffer, 0, bytesRead)

            HashGeneratorOutput("Converting hash byte array to hexadecimal...")
            buffer = hashObject.Hash
            hashHex = ""
            For i = 0 To buffer.Length - 1
                hashHex += buffer(i).ToString("X2")
            Next i

            HashGeneratorOutput("Closing streams...")
            FilePropertiesStream.Close()
            hashObject.Clear()

            HashGeneratorOutput(hashHex.ToLower)
            bwCalcHashes.ReportProgress(100)
        Catch ex As OperationCanceledException
            HashGeneratorOutput("Closing streams...")
            If Not FilePropertiesStream Is Nothing Then
                FilePropertiesStream.Close()
            End If
            hashObject.Clear()

            HashGeneratorOutput(ex.Message)
            bwCalcHashes.ReportProgress(0)
        Catch ex As Exception
            Operations.MessageBox(ex.ToString, icon:=MessageBoxIcon.Exclamation)
            HashGeneratorOutput("Click ""Calculate""")
            bwCalcHashes.ReportProgress(0)
        End Try
    End Sub

    Sub bwCalcHashes_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles bwCalcHashes.ProgressChanged
        pbCalculateProgress.Value = e.ProgressPercentage
    End Sub

    Sub bwCalcHashes_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwCalcHashes.RunWorkerCompleted
        If hashQueue.Contains(" ") Then
            If hashQueue.StartsWith("MD5") Then
                btnMD5.Text = "Queue"
            ElseIf hashQueue.StartsWith("SHA1") Then
                btnSHA1.Text = "Queue"
            ElseIf hashQueue.StartsWith("SHA256") Then
                btnSHA256.Text = "Queue"
            ElseIf hashQueue.StartsWith("SHA512") Then
                btnSHA512.Text = "Queue"
            End If
            hashQueue = hashQueue.Substring(hashQueue.IndexOf(" ") + 1)
            bwCalcHashes.RunWorkerAsync(PropertiesDotNet.lblLocation.Text)
        Else
            btnAllCalculate.Enabled = True
            btnAllCancel.Enabled = False
            btnMD5.Text = "Calculate..."
            btnSHA1.Text = "Calculate..."
            btnSHA256.Text = "Calculate..."
            btnSHA512.Text = "Calculate..."
        End If
    End Sub

    ''' <summary>Set the correct labels text to the status, depending on the hashQueue</summary>
    ''' <param name="status">The text to set the label to.</param>
    Sub HashGeneratorOutput(status As String)
        If hashQueue.StartsWith("MD5") Then
            lblMD5.Text = status
        ElseIf hashQueue.StartsWith("SHA1") Then
            lblSHA1.Text = status
        ElseIf hashQueue.StartsWith("SHA256") Then
            lblSHA256.Text = status
        ElseIf hashQueue.StartsWith("SHA512") Then
            lblSHA512.Text = status
        End If
    End Sub
End Class
