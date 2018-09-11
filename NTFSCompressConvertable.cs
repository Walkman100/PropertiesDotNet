/// <summary>
/// Code from http://www.thescarms.com/dotnet/NTFSCompress.aspx,
/// but you can convert this to another language i.e. it compiles
/// </summary>
using System;
using System.IO;
using System.Runtime.InteropServices;
namespace NTFSCompress
{
    class Program
    {
        [DllImport("Kernel32.dll")]
        public static extern int DeviceIoControl(IntPtr hDevice, int
            dwIoControlCode, ref short lpInBuffer, int nInBufferSize, IntPtr
            lpOutBuffer, int nOutBufferSize, ref int lpBytesReturned, IntPtr
            lpOverlapped);
        
        public static void Main(string[] args)
        {
            string fileName = @"C:\Temp\test.mdb";
            int lpBytesReturned = 0;
            int FSCTL_SET_COMPRESSION = 0x9C040;
            short COMPRESSION_FORMAT_DEFAULT = 1;
            
            FileStream f = File.Open(fileName, System.IO.FileMode.Open,
                System.IO.FileAccess.ReadWrite, System.IO.FileShare.None);
            
            int result = DeviceIoControl(f.Handle, FSCTL_SET_COMPRESSION,
                ref COMPRESSION_FORMAT_DEFAULT, 2, IntPtr.Zero, 0,
                ref lpBytesReturned, IntPtr.Zero);
        }
    }
}
