/// <summary>
/// Original, non-convertable code from http://www.thescarms.com/dotnet/NTFSCompress.aspx
/// </summary>
using System.IO;
using System.Runtime.InteropServices;

[DllImport("kernel32.dll")]
public static extern int DeviceIoControl(IntPtr hDevice, int
    dwIoControlCode, ref short lpInBuffer, int nInBufferSize, IntPtr
    lpOutBuffer, int nOutBufferSize, ref int lpBytesReturned, IntPtr
    lpOverlapped);

string fileName = @"C:\Temp\test.mdb";
int lpBytesReturned = 0;
int FSCTL_SET_COMPRESSION = 0x9C040;
short COMPRESSION_FORMAT_DEFAULT = 1;

FileStream f = File.Open(fileName, System.IO.FileMode.Open,
    System.IO.FileAccess.ReadWrite, System.IO.FileShare.None);

int result = DeviceIoControl(f.Handle, FSCTL_SET_COMPRESSION,
    ref COMPRESSION_FORMAT_DEFAULT, 2 /*sizeof(short)*/, IntPtr.Zero, 0,
    ref lpBytesReturned, IntPtr.Zero);