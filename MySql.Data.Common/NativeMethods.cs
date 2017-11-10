using System;
using System.Runtime.InteropServices;

namespace MySql.Data.Common
{
	internal class NativeMethods
	{
		[StructLayout(LayoutKind.Sequential)]
		public class SecurityAttributes
		{
			public int Length;

			public IntPtr securityDescriptor = IntPtr.Zero;

			public bool inheritHandle = false;

			public SecurityAttributes()
			{
				this.Length = Marshal.SizeOf(typeof(NativeMethods.SecurityAttributes));
			}
		}

		public const uint GENERIC_READ = 2147483648u;

		public const uint GENERIC_WRITE = 1073741824u;

		public const int INVALIDpipeHandle_VALUE = -1;

		public const uint FILE_FLAG_OVERLAPPED = 1073741824u;

		public const uint FILE_FLAG_NO_BUFFERING = 536870912u;

		public const uint OPEN_EXISTING = 3u;

		private NativeMethods()
		{
		}

		[DllImport("Kernel32")]
		public static extern int CreateFile(string fileName, uint desiredAccess, uint shareMode, NativeMethods.SecurityAttributes securityAttributes, uint creationDisposition, uint flagsAndAttributes, uint templateFile);

		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(2)]
		public static extern bool PeekNamedPipe(IntPtr handle, byte[] buffer, uint nBufferSize, ref uint bytesRead, ref uint bytesAvail, ref uint BytesLeftThisMessage);

		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(2)]
		internal static extern bool ReadFile(IntPtr hFile, [Out] byte[] lpBuffer, uint nNumberOfBytesToRead, out uint lpNumberOfBytesRead, IntPtr lpOverlapped);

		[DllImport("Kernel32")]
		[return: MarshalAs(2)]
		internal static extern bool WriteFile(IntPtr hFile, [In] byte[] buffer, uint numberOfBytesToWrite, out uint numberOfBytesWritten, IntPtr lpOverlapped);

		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(2)]
		public static extern bool CloseHandle(IntPtr handle);

		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(2)]
		public static extern bool FlushFileBuffers(IntPtr handle);

		[DllImport("ws2_32.dll", SetLastError = true)]
		public static extern IntPtr socket(int af, int type, int protocol);

		[DllImport("ws2_32.dll", SetLastError = true)]
		public static extern int ioctlsocket(IntPtr socket, uint cmd, ref uint arg);

		[DllImport("ws2_32.dll", SetLastError = true)]
		public static extern int WSAIoctl(IntPtr s, uint dwIoControlCode, byte[] inBuffer, uint cbInBuffer, byte[] outBuffer, uint cbOutBuffer, IntPtr lpcbBytesReturned, IntPtr lpOverlapped, IntPtr lpCompletionRoutine);

		[DllImport("ws2_32.dll", SetLastError = true)]
		public static extern int WSAGetLastError();

		[DllImport("ws2_32.dll", SetLastError = true)]
		public static extern int connect(IntPtr socket, byte[] addr, int addrlen);

		[DllImport("ws2_32.dll", SetLastError = true)]
		public static extern int recv(IntPtr socket, byte[] buff, int len, int flags);

		[DllImport("ws2_32.Dll", SetLastError = true)]
		public static extern int send(IntPtr socket, byte[] buff, int len, int flags);
	}
}
