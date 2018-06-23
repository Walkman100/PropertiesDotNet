# PropertiesDotNet [![Build status](https://ci.appveyor.com/api/projects/status/7iooy0iqejw297i0)](https://ci.appveyor.com/project/Walkman100/propertiesdotnet)
An advanced properties window made in VB.Net

[![Gitter](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/Walkman100/Walkman?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

## Screenshots
[![PropertiesDotNet main window][MainWindow]][MainWindow]
[![Hash generator window][Hashes]][Hashes]
[![Folder deleting window][Deletion]][Deletion]
[![Folder copying window][Copying]][Copying]
[![File compress dialog][Compress]][Compress]

  [MainWindow]: https://walkman100.github.io/images/Screenshots/My_Projects/PropertiesDotNet/MainWindow.png
  [Hashes]: https://walkman100.github.io/images/Screenshots/My_Projects/PropertiesDotNet/Hashes.png
  [Deletion]: https://walkman100.github.io/images/Screenshots/My_Projects/PropertiesDotNet/Deletion.png
  [Copying]: https://walkman100.github.io/images/Screenshots/My_Projects/PropertiesDotNet/Copying.png
  [Compress]: https://walkman100.github.io/images/Screenshots/My_Projects/PropertiesDotNet/Compress.png

## Download
Get the latest version [here](https://github.com/Walkman100/PropertiesDotNet/releases), and the latest build from commit
[here](https://ci.appveyor.com/project/Walkman100/PropertiesDotNet/build/artifacts)
(note that these builds are built for the Debug config and so are not optimised)

## Credits/Acknowledgements
### Icons
- Program Icon:
  - https://www.iconfinder.com/icons/28343/document_properties_icon
  - License: [GPL](http://www.gnu.org/copyleft/gpl.html)
- Compress form icon:
  - https://www.iconfinder.com/icons/35891/compress_icon
  - License: [Creative Commons (Attribution 3.0 United States)](http://creativecommons.org/licenses/by/3.0/us)
- Hashing form icon:
  - https://www.iconfinder.com/icons/118664/hash_icon
  - License: [Attribution-Non-Commercial 3.0 Netherlands](http://creativecommons.org/licenses/by-nc/3.0/nl/deed.en_GB)

### Getting open with program
- Find at: [PropertiesDotNet.vb#L6](PropertiesDotNet.vb#L6)
- And: [PropertiesDotNet.vb#L147](PropertiesDotNet.vb#L147)
- http://www.vb-helper.com/howto_get_associated_program.html
- The page above is in VB6 however, so I needed to convert it (manually) to VB.Net. Also, the most important line, the `Function FindExecutable Lib "shell32.dll"`, is chopped off the sample you see on the page, so you have to download the `zip` to get that.

### NTFS Compression
- Find at: [CompressReport.vb#L59](CompressReport.vb#L59)
- And: [CompressReport.vb#L68](CompressReport.vb#L68)
- http://www.thescarms.com/dotnet/NTFSCompress.aspx
- Original code from above link has been copied, un-modified, to [NTFSCompressOriginalCode.cs](NTFSCompressOriginalCode.cs)
- I have edited it so it can be compiled: [NTFSCompressConvertable.cs](NTFSCompressConvertable.cs)
- Then I converted it to VB.Net: [NTFSCompressConverted.vb](NTFSCompressConverted.vb)
- MSDN Info (for decompression value): https://msdn.microsoft.com/en-us/library/windows/desktop/aa364592(v=vs.85).aspx

### Hash Generating
- Find at: [Hashes.vb#L405](Hashes.vb#L405)
- Basic Hashing: http://us.informatiweb.net/programmation/36--generate-hashes-md5-sha-1-and-sha-256-of-a-file.html
- Hashing with progress reporting: http://www.infinitec.de/post/2007/06/09/Displaying-progress-updates-when-hashing-large-files.aspx
- Since the code on the page above is in C#, I converted it to VB.Net:
```vb
Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.ComponentModel
Imports System.Security
Imports System.Security.Cryptography

Namespace NTFSCompress
    Public Partial Class MainForm
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub
        Private Sub BackgroundWorker_DoWork(sender As Object, e As DoWorkEventArgs)
            Dim buffer As Byte()
            Dim oldBuffer As Byte()
            Dim bytesRead As Integer
            Dim oldBytesRead As Integer
            Dim size As Long
            Dim totalBytesRead As Long = 0
            Using stream As Stream = File.OpenRead(DirectCast(e.Argument, String))
                Using hashAlgorithm As HashAlgorithm = MD5.Create()
                    size = stream.Length
                    buffer = New Byte(4095) {}
                    bytesRead = stream.Read(buffer, 0, buffer.Length)
                    totalBytesRead += bytesRead
                    Do
                        oldBytesRead = bytesRead
                        oldBuffer = buffer
                        buffer = New Byte(4095) {}
                        bytesRead = stream.Read(buffer, 0, buffer.Length)
                        totalBytesRead += bytesRead
                        If bytesRead = 0 Then
                            hashAlgorithm.TransformFinalBlock(oldBuffer, 0, oldBytesRead)
                        Else
                            hashAlgorithm.TransformBlock(oldBuffer, 0, oldBytesRead, oldBuffer, 0)
                        End If
                        BackgroundWorker.ReportProgress(CInt(Math.Truncate(CDbl(totalBytesRead) * 100 / size)))
                    Loop While bytesRead <> 0
                    e.Result = hashAlgorithm.Hash
                End Using
            End Using
        End Sub
    End Class
End Namespace
```

## Compile requirements
See [CompileInstructions.md](https://github.com/Walkman100/gists/blob/master/CompileInstructions.md)
