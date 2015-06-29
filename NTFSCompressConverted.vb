''' <summary>
''' Code from http://www.thescarms.com/dotnet/NTFSCompress.aspx, converted to VB.Net
''' </summary>
Imports System
Imports System.IO
Imports System.Runtime.InteropServices
Namespace NTFSCompress
    Class Program
        <DllImport("Kernel32.dll")> _
        Public Shared Function DeviceIoControl(hDevice As IntPtr, dwIoControlCode As Integer, _
          lpInBuffer As Short, nInBufferSize As Integer, lpOutBuffer As IntPtr, nOutBufferSize As Integer, _
          ByRef lpBytesReturned As Integer, lpOverlapped As IntPtr) As Integer
        End Function
        Public Shared Sub Main(args As String())
            Dim fileName As String = "C:\Temp\test.mdb"
            Dim lpBytesReturned As Integer = 0
            Dim FSCTL_SET_COMPRESSION As Integer = &H9c040
            Dim COMPRESSION_FORMAT_DEFAULT As Short = 1

            Dim f As FileStream = File.Open(fileName, System.IO.FileMode.Open, _
              System.IO.FileAccess.ReadWrite, System.IO.FileShare.None)

            Dim result As Integer = DeviceIoControl(f.Handle, FSCTL_SET_COMPRESSION, _
              COMPRESSION_FORMAT_DEFAULT, 2, IntPtr.Zero, 0, lpBytesReturned, IntPtr.Zero)
        End Sub
    End Class
End Namespace
