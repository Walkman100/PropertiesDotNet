Imports System.IO
Imports System.Security
Imports System.Security.Cryptography

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.lblMD5 = New System.Windows.Forms.Label()
        Me.btnMD5Calculate = New System.Windows.Forms.Button()
        Me.grpSHA1 = New System.Windows.Forms.GroupBox()
        Me.btnSHA1Copy = New System.Windows.Forms.Button()
        Me.lblSHA1 = New System.Windows.Forms.Label()
        Me.btnSHA1Calculate = New System.Windows.Forms.Button()
        Me.grpSHA256 = New System.Windows.Forms.GroupBox()
        Me.btnSHA256Copy = New System.Windows.Forms.Button()
        Me.lblSHA256 = New System.Windows.Forms.Label()
        Me.btnSHA256Calculate = New System.Windows.Forms.Button()
        Me.btnAllCopy = New System.Windows.Forms.Button()
        Me.btnAllCalculate = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.pbCalculateProgress = New System.Windows.Forms.ProgressBar()
        Me.bwCalcHashes = New System.ComponentModel.BackgroundWorker()
        Me.grpMD5.SuspendLayout
        Me.grpSHA1.SuspendLayout
        Me.grpSHA256.SuspendLayout
        Me.SuspendLayout
        'grpMD5
        Me.grpMD5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.grpMD5.Controls.Add(Me.btnMD5Copy)
        Me.grpMD5.Controls.Add(Me.lblMD5)
        Me.grpMD5.Controls.Add(Me.btnMD5Calculate)
        Me.grpMD5.Location = New System.Drawing.Point(3, 4)
        Me.grpMD5.Name = "grpMD5"
        Me.grpMD5.Size = New System.Drawing.Size(510, 50)
        Me.grpMD5.TabIndex = 0
        Me.grpMD5.TabStop = false
        Me.grpMD5.Text = "MD5"
        'btnMD5Copy
        Me.btnMD5Copy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnMD5Copy.Location = New System.Drawing.Point(460, 19)
        Me.btnMD5Copy.Name = "btnMD5Copy"
        Me.btnMD5Copy.Size = New System.Drawing.Size(44, 23)
        Me.btnMD5Copy.TabIndex = 2
        Me.btnMD5Copy.Text = "Copy"
        Me.btnMD5Copy.UseVisualStyleBackColor = true
        AddHandler Me.btnMD5Copy.Click, AddressOf Me.btnMD5Copy_Click
        'lblMD5
        Me.lblMD5.AutoSize = true
        Me.lblMD5.Location = New System.Drawing.Point(90, 24)
        Me.lblMD5.Name = "lblMD5"
        Me.lblMD5.Size = New System.Drawing.Size(87, 13)
        Me.lblMD5.TabIndex = 1
        Me.lblMD5.Text = "Click ""Calculate"""
        'btnMD5Calculate
        Me.btnMD5Calculate.Location = New System.Drawing.Point(9, 19)
        Me.btnMD5Calculate.Name = "btnMD5Calculate"
        Me.btnMD5Calculate.Size = New System.Drawing.Size(75, 23)
        Me.btnMD5Calculate.TabIndex = 0
        Me.btnMD5Calculate.Text = "Calculate..."
        Me.btnMD5Calculate.UseVisualStyleBackColor = true
        AddHandler Me.btnMD5Calculate.Click, AddressOf Me.btnMD5Calculate_Click
        'grpSHA1
        Me.grpSHA1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.grpSHA1.Controls.Add(Me.btnSHA1Copy)
        Me.grpSHA1.Controls.Add(Me.lblSHA1)
        Me.grpSHA1.Controls.Add(Me.btnSHA1Calculate)
        Me.grpSHA1.Location = New System.Drawing.Point(3, 60)
        Me.grpSHA1.Name = "grpSHA1"
        Me.grpSHA1.Size = New System.Drawing.Size(510, 50)
        Me.grpSHA1.TabIndex = 1
        Me.grpSHA1.TabStop = false
        Me.grpSHA1.Text = "SHA-1"
        'btnSHA1Copy
        Me.btnSHA1Copy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnSHA1Copy.Location = New System.Drawing.Point(460, 19)
        Me.btnSHA1Copy.Name = "btnSHA1Copy"
        Me.btnSHA1Copy.Size = New System.Drawing.Size(44, 23)
        Me.btnSHA1Copy.TabIndex = 2
        Me.btnSHA1Copy.Text = "Copy"
        Me.btnSHA1Copy.UseVisualStyleBackColor = true
        AddHandler Me.btnSHA1Copy.Click, AddressOf Me.btnSHA1Copy_Click
        'lblSHA1
        Me.lblSHA1.AutoSize = true
        Me.lblSHA1.Location = New System.Drawing.Point(90, 24)
        Me.lblSHA1.Name = "lblSHA1"
        Me.lblSHA1.Size = New System.Drawing.Size(87, 13)
        Me.lblSHA1.TabIndex = 1
        Me.lblSHA1.Text = "Click ""Calculate"""
        'btnSHA1Calculate
        Me.btnSHA1Calculate.Location = New System.Drawing.Point(9, 19)
        Me.btnSHA1Calculate.Name = "btnSHA1Calculate"
        Me.btnSHA1Calculate.Size = New System.Drawing.Size(75, 23)
        Me.btnSHA1Calculate.TabIndex = 0
        Me.btnSHA1Calculate.Text = "Calculate..."
        Me.btnSHA1Calculate.UseVisualStyleBackColor = true
        AddHandler Me.btnSHA1Calculate.Click, AddressOf Me.btnSHA1Calculate_Click
        'grpSHA256
        Me.grpSHA256.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.grpSHA256.Controls.Add(Me.btnSHA256Copy)
        Me.grpSHA256.Controls.Add(Me.lblSHA256)
        Me.grpSHA256.Controls.Add(Me.btnSHA256Calculate)
        Me.grpSHA256.Location = New System.Drawing.Point(3, 116)
        Me.grpSHA256.Name = "grpSHA256"
        Me.grpSHA256.Size = New System.Drawing.Size(510, 50)
        Me.grpSHA256.TabIndex = 2
        Me.grpSHA256.TabStop = false
        Me.grpSHA256.Text = "SHA-256"
        'btnSHA256Copy
        Me.btnSHA256Copy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnSHA256Copy.Location = New System.Drawing.Point(460, 19)
        Me.btnSHA256Copy.Name = "btnSHA256Copy"
        Me.btnSHA256Copy.Size = New System.Drawing.Size(44, 23)
        Me.btnSHA256Copy.TabIndex = 2
        Me.btnSHA256Copy.Text = "Copy"
        Me.btnSHA256Copy.UseVisualStyleBackColor = true
        AddHandler Me.btnSHA256Copy.Click, AddressOf Me.btnSHA256Copy_Click
        'lblSHA256
        Me.lblSHA256.AutoSize = true
        Me.lblSHA256.Location = New System.Drawing.Point(90, 24)
        Me.lblSHA256.Name = "lblSHA256"
        Me.lblSHA256.Size = New System.Drawing.Size(87, 13)
        Me.lblSHA256.TabIndex = 1
        Me.lblSHA256.Text = "Click ""Calculate"""
        'btnSHA256Calculate
        Me.btnSHA256Calculate.Location = New System.Drawing.Point(9, 19)
        Me.btnSHA256Calculate.Name = "btnSHA256Calculate"
        Me.btnSHA256Calculate.Size = New System.Drawing.Size(75, 23)
        Me.btnSHA256Calculate.TabIndex = 0
        Me.btnSHA256Calculate.Text = "Calculate..."
        Me.btnSHA256Calculate.UseVisualStyleBackColor = true
        AddHandler Me.btnSHA256Calculate.Click, AddressOf Me.btnSHA256Calculate_Click
        'btnAllCopy
        Me.btnAllCopy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnAllCopy.Location = New System.Drawing.Point(365, 172)
        Me.btnAllCopy.Name = "btnAllCopy"
        Me.btnAllCopy.Size = New System.Drawing.Size(57, 23)
        Me.btnAllCopy.TabIndex = 2
        Me.btnAllCopy.Text = "Copy All"
        Me.btnAllCopy.UseVisualStyleBackColor = true
        AddHandler Me.btnAllCopy.Click, AddressOf Me.btnAllCopy_Click
        'btnAllCalculate
        Me.btnAllCalculate.Location = New System.Drawing.Point(12, 172)
        Me.btnAllCalculate.Name = "btnAllCalculate"
        Me.btnAllCalculate.Size = New System.Drawing.Size(84, 23)
        Me.btnAllCalculate.TabIndex = 0
        Me.btnAllCalculate.Text = "Calculate All..."
        Me.btnAllCalculate.UseVisualStyleBackColor = true
        AddHandler Me.btnAllCalculate.Click, AddressOf Me.btnAllCalculate_Click
        'btnClose
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(428, 172)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = true
        AddHandler Me.btnClose.Click, AddressOf Me.btnClose_Click
        'pbCalculateProgress
        Me.pbCalculateProgress.Location = New System.Drawing.Point(102, 172)
        Me.pbCalculateProgress.Name = "pbCalculateProgress"
        Me.pbCalculateProgress.Size = New System.Drawing.Size(257, 23)
        Me.pbCalculateProgress.TabIndex = 5
        'bwCalcHashes
        Me.bwCalcHashes.WorkerReportsProgress = true
        Me.bwCalcHashes.WorkerSupportsCancellation = true
        AddHandler Me.bwCalcHashes.DoWork, AddressOf Me.bwCalcHashes_DoWork
        AddHandler Me.bwCalcHashes.ProgressChanged, AddressOf Me.bwCalcHashes_ProgressChanged
        'Hashes
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(515, 208)
        Me.Controls.Add(Me.pbCalculateProgress)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnAllCopy)
        Me.Controls.Add(Me.grpSHA256)
        Me.Controls.Add(Me.btnAllCalculate)
        Me.Controls.Add(Me.grpSHA1)
        Me.Controls.Add(Me.grpMD5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = false
        Me.Name = "Hashes"
        Me.ShowInTaskbar = false
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Generate Hashes"
        Me.grpMD5.ResumeLayout(false)
        Me.grpMD5.PerformLayout
        Me.grpSHA1.ResumeLayout(false)
        Me.grpSHA1.PerformLayout
        Me.grpSHA256.ResumeLayout(false)
        Me.grpSHA256.PerformLayout
        Me.ResumeLayout(false)
    End Sub
    Private bwCalcHashes As System.ComponentModel.BackgroundWorker
    Private pbCalculateProgress As System.Windows.Forms.ProgressBar
    Private btnClose As System.Windows.Forms.Button
    Private btnAllCalculate As System.Windows.Forms.Button
    Private btnAllCopy As System.Windows.Forms.Button
    Private btnSHA256Calculate As System.Windows.Forms.Button
    Private lblSHA256 As System.Windows.Forms.Label
    Private btnSHA256Copy As System.Windows.Forms.Button
    Private grpSHA256 As System.Windows.Forms.GroupBox
    Private btnSHA1Calculate As System.Windows.Forms.Button
    Private lblSHA1 As System.Windows.Forms.Label
    Private btnSHA1Copy As System.Windows.Forms.Button
    Private grpSHA1 As System.Windows.Forms.GroupBox
    Private btnMD5Calculate As System.Windows.Forms.Button
    Private lblMD5 As System.Windows.Forms.Label
    Private btnMD5Copy As System.Windows.Forms.Button
    Private grpMD5 As System.Windows.Forms.GroupBox
    
    Sub btnMD5Calculate_Click()
        hashType = "MD5"
        hashHex = PropertiesDotNet.lblLocation.Text
        bwCalcHashes.RunWorkerAsync
    End Sub
    
    Sub btnSHA1Calculate_Click()
        hashType = "SHA1"
        bwCalcHashes.RunWorkerAsync
        hashHex = PropertiesDotNet.lblLocation.Text
    End Sub
    
    Sub btnSHA256Calculate_Click()
        hashType = "SHA256"
        bwCalcHashes.RunWorkerAsync
        hashHex = PropertiesDotNet.lblLocation.Text
    End Sub
    
    Sub btnAllCalculate_Click()
        hashType = "All"
        bwCalcHashes.RunWorkerAsync
        hashHex = PropertiesDotNet.lblLocation.Text
    End Sub
    
    Sub btnMD5Copy_Click()
        Try
            Clipboard.SetText(lblMD5.Text, TextDataFormat.UnicodeText)
            MsgBox(lblMD5.Text & vbNewLine & "Succesfully copied!", MsgBoxStyle.Information, "Succesfully copied!")
        Catch ex As Exception
            MsgBox("Copy failed!" & vbNewLine & "Error: """ & ex.ToString & """", MsgBoxStyle.Critical, "Copy failed!")
        End Try
    End Sub
    
    Sub btnSHA1Copy_Click()
        Try
            Clipboard.SetText(lblSHA1.Text, TextDataFormat.UnicodeText)
            MsgBox(lblSHA1.Text & vbNewLine & "Succesfully copied!", MsgBoxStyle.Information, "Succesfully copied!")
        Catch ex As Exception
            MsgBox("Copy failed!" & vbNewLine & "Error: """ & ex.ToString & """", MsgBoxStyle.Critical, "Copy failed!")
        End Try
    End Sub
    
    Sub btnSHA256Copy_Click()
        Try
            Clipboard.SetText(lblSHA256.Text, TextDataFormat.UnicodeText)
            MsgBox(lblSHA256.Text & vbNewLine & "Succesfully copied!", MsgBoxStyle.Information, "Succesfully copied!")
        Catch ex As Exception
            MsgBox("Copy failed!" & vbNewLine & "Error: """ & ex.ToString & """", MsgBoxStyle.Critical, "Copy failed!")
        End Try
    End Sub
    
    Sub btnAllCopy_Click()
        Try
            Clipboard.SetText(lblMD5.Text & vbNewLine & lblSHA1.Text & vbNewLine & lblSHA256.Text, TextDataFormat.UnicodeText)
            MsgBox(lblMD5.Text & vbNewLine & lblSHA1.Text & vbNewLine & lblSHA256.Text & vbNewLine & "Succesfully copied!", MsgBoxStyle.Information, "Succesfully copied!")
        Catch ex As Exception
            MsgBox("Copy failed!" & vbNewLine & "Error: """ & ex.ToString & """", MsgBoxStyle.Critical, "Copy failed!")
        End Try
    End Sub
    
    Sub btnClose_Click()
        Me.Close
    End Sub
    
    ''' <summary>
    ''' Original code, thanks to http://us.informatiweb.net/programmation/36--generate-hashes-md5-sha-1-and-sha-256-of-a-file.html
    ''' Code that reports progress, thanks to http://www.infinitec.de/post/2007/06/09/Displaying-progress-updates-when-hashing-large-files.aspx
    ''' </summary>

    Dim hashType As String
    Dim hashHex As String
    Dim hashObject
    
    Dim buffer As Byte()
    Dim oldBuffer As Byte()
    Dim bytesRead As Integer
    Dim oldBytesRead As Integer
    Dim size As Long
    Dim totalBytesRead As Long = 0
    
    Sub bwCalcHashes_DoWork()
        Try
            ' Set up GUI
            btnMD5Calculate.Enabled = False
            btnSHA1Calculate.Enabled = False
            btnSHA256Calculate.Enabled = False
            btnAllCalculate.Enabled = False
            bwCalcHashes.ReportProgress(0)
            
            HashGeneratorOutput("Creating hash object...")
            Select Case hashType
                Case "MD5"
                    hashObject = MD5.Create
                Case "SHA1"
                    hashObject = SHA1.Create
                Case "SHA256"
                    hashObject = SHA256.Create
                'Case "SHA512"
                '    hashObject = SHA512.Create
                Case "All"
                    
            End Select
            
            HashGeneratorOutput("Opening file...")
            Dim FilePropertiesStream As FileStream = File.OpenRead(hashHex)
            
            HashGeneratorOutput("Setting file position...")
            FilePropertiesStream.Position = 0
            
            HashGeneratorOutput("Setting up variables...")
            size = FilePropertiesStream.Length
            
            buffer = New Byte(4095) {}
            
            bytesRead = FilePropertiesStream.Read(buffer, 0, buffer.Length)
            totalBytesRead = bytesRead
            
            HashGeneratorOutput("Generating hash byte array...")
            Do
                oldBytesRead = bytesRead
                oldBuffer = buffer
                
                buffer = New Byte(4095) {}
                bytesRead = FilePropertiesStream.Read(buffer, 0, buffer.Length)
                
                totalBytesRead += bytesRead
                
                If bytesRead = 0 Then
                    hashObject.TransformFinalBlock(oldBuffer, 0, oldBytesRead)
                Else
                    hashObject.TransformBlock(oldBuffer, 0, oldBytesRead, oldBuffer, 0)
                End If
                
                bwCalcHashes.ReportProgress(CInt(Math.Truncate(CDbl(totalBytesRead) * 100 / size)))
            Loop While bytesRead <> 0
            
            HashGeneratorOutput("Converting hash byte array to hexadecimal...")
            buffer = hashObject.Hash
            hashHex = ""
            For i = 0 To buffer.Length - 1
                hashHex += buffer(i).ToString("X2")
            Next i
            
            HashGeneratorOutput("Closing streams...")
            FilePropertiesStream.Close()
            hashObject.Clear
            
            HashGeneratorOutput(hashHex.ToLower)
            btnMD5Calculate.Enabled = True
            btnSHA1Calculate.Enabled = True
            btnSHA256Calculate.Enabled = True
            btnAllCalculate.Enabled = True
            bwCalcHashes.ReportProgress(100)
        Catch ex As Exception
            PropertiesDotNet.ErrorParser(ex)
            HashGeneratorOutput("Click ""Calculate""")
            btnMD5Calculate.Enabled = True
            btnSHA1Calculate.Enabled = True
            btnSHA256Calculate.Enabled = True
            btnAllCalculate.Enabled = True
            bwCalcHashes.ReportProgress(0)
        End Try
    End Sub
    
    Sub bwCalcHashes_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs)
        pbCalculateProgress.Value = e.ProgressPercentage
        
    End Sub
    
    Sub HashGeneratorOutput(status As String)
        Select Case hashType
            Case "MD5"
                lblMD5.Text = status
            Case "SHA1"
                lblSHA1.Text = status
            Case "SHA256"
                lblSHA256.Text = status
            Case "SHA512"
                'lblSHA512.Text = status
            End Select
    End Sub
End Class
