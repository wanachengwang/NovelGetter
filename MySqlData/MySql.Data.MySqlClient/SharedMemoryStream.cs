using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace MySql.Data.MySqlClient
{
	internal class SharedMemoryStream : Stream
	{
		private const uint SYNCHRONIZE = 1048576u;

		private const uint READ_CONTROL = 131072u;

		private const uint EVENT_MODIFY_STATE = 2u;

		private const uint EVENT_ALL_ACCESS = 2031619u;

		private const uint FILE_MAP_WRITE = 2u;

		private const int BUFFERLENGTH = 16004;

		private string memoryName;

		private AutoResetEvent serverRead;

		private AutoResetEvent serverWrote;

		private AutoResetEvent clientRead;

		private AutoResetEvent clientWrote;

		private IntPtr dataMap;

		private IntPtr dataView;

		private int bytesLeft;

		private int position;

		private int connectNumber;

		public override bool CanRead
		{
			get
			{
				return true;
			}
		}

		public override bool CanSeek
		{
			get
			{
				return false;
			}
		}

		public override bool CanWrite
		{
			get
			{
				return true;
			}
		}

		public override long Length
		{
			get
			{
				throw new NotSupportedException("SharedMemoryStream does not support seeking - length");
			}
		}

		public override long Position
		{
			get
			{
				throw new NotSupportedException("SharedMemoryStream does not support seeking - postition");
			}
			set
			{
			}
		}

		public SharedMemoryStream(string memName)
		{
			this.memoryName = memName;
		}

		public void Open(int timeOut)
		{
			this.GetConnectNumber(timeOut);
			this.SetupEvents();
		}

		public override void Close()
		{
			SharedMemoryStream.UnmapViewOfFile(this.dataView);
			SharedMemoryStream.CloseHandle(this.dataMap);
		}

		private void GetConnectNumber(int timeOut)
		{
			AutoResetEvent autoResetEvent = new AutoResetEvent(false);
			IntPtr handle = SharedMemoryStream.OpenEvent(1048578u, false, this.memoryName + "_CONNECT_REQUEST");
			autoResetEvent.set_Handle(handle);
			AutoResetEvent autoResetEvent2 = new AutoResetEvent(false);
			handle = SharedMemoryStream.OpenEvent(1048578u, false, this.memoryName + "_CONNECT_ANSWER");
			autoResetEvent2.set_Handle(handle);
			IntPtr hFileMappingObject = SharedMemoryStream.OpenFileMapping(2u, false, this.memoryName + "_CONNECT_DATA");
			IntPtr intPtr = SharedMemoryStream.MapViewOfFile(hFileMappingObject, 2u, 0u, 0u, (IntPtr)4);
			if (!autoResetEvent.Set())
			{
				throw new MySqlException("Failed to open shared memory connection ");
			}
			autoResetEvent2.WaitOne(timeOut * 1000, false);
			this.connectNumber = Marshal.ReadInt32(intPtr);
		}

		private void SetupEvents()
		{
			string text = this.memoryName + "_" + this.connectNumber;
			this.dataMap = SharedMemoryStream.OpenFileMapping(2u, false, text + "_DATA");
			this.dataView = SharedMemoryStream.MapViewOfFile(this.dataMap, 2u, 0u, 0u, (IntPtr)16004);
			this.serverWrote = new AutoResetEvent(false);
			IntPtr handle = SharedMemoryStream.OpenEvent(1048578u, false, text + "_SERVER_WROTE");
			this.serverWrote.set_Handle(handle);
			this.serverRead = new AutoResetEvent(false);
			handle = SharedMemoryStream.OpenEvent(1048578u, false, text + "_SERVER_READ");
			this.serverRead.set_Handle(handle);
			this.clientWrote = new AutoResetEvent(false);
			handle = SharedMemoryStream.OpenEvent(1048578u, false, text + "_CLIENT_WROTE");
			this.clientWrote.set_Handle(handle);
			this.clientRead = new AutoResetEvent(false);
			handle = SharedMemoryStream.OpenEvent(1048578u, false, text + "_CLIENT_READ");
			this.clientRead.set_Handle(handle);
			this.serverRead.Set();
		}

		public override void Flush()
		{
			SharedMemoryStream.FlushViewOfFile(this.dataView, 0u);
		}

		public bool IsClosed()
		{
			bool result;
			try
			{
				this.dataView = SharedMemoryStream.MapViewOfFile(this.dataMap, 2u, 0u, 0u, (IntPtr)16004);
				if (this.dataView == IntPtr.Zero)
				{
					result = true;
				}
				else
				{
					result = false;
				}
			}
			catch (Exception)
			{
				result = true;
			}
			return result;
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			while (this.bytesLeft == 0)
			{
				while (!this.serverWrote.WaitOne(500, false))
				{
					if (this.IsClosed())
					{
						return 0;
					}
				}
				this.bytesLeft = Marshal.ReadInt32(this.dataView);
				this.position = 4;
			}
			int num = Math.Min(count, this.bytesLeft);
			long num2 = this.dataView.ToInt64() + (long)this.position;
			int i = 0;
			while (i < num)
			{
				buffer[offset + i] = Marshal.ReadByte((IntPtr)(num2 + (long)i));
				i++;
				this.position++;
			}
			this.bytesLeft -= num;
			if (this.bytesLeft == 0)
			{
				this.clientRead.Set();
			}
			return num;
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException("SharedMemoryStream does not support seeking");
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			int i = count;
			int num = offset;
			while (i > 0)
			{
				if (!this.serverRead.WaitOne())
				{
					throw new MySqlException("Writing to shared memory failed");
				}
				int num2 = Math.Min(i, 16004);
				long num3 = this.dataView.ToInt64() + 4L;
				Marshal.WriteInt32(this.dataView, num2);
				int j = 0;
				while (j < num2)
				{
					Marshal.WriteByte((IntPtr)(num3 + (long)j), buffer[num]);
					j++;
					num++;
				}
				i -= num2;
				if (!this.clientWrote.Set())
				{
					throw new MySqlException("Writing to shared memory failed");
				}
			}
		}

		public override void SetLength(long value)
		{
			throw new NotSupportedException("SharedMemoryStream does not support seeking");
		}

		[DllImport("kernel32.dll")]
		private static extern IntPtr OpenEvent(uint dwDesiredAccess, bool bInheritHandle, string lpName);

		[DllImport("kernel32.dll")]
		private static extern IntPtr OpenFileMapping(uint dwDesiredAccess, bool bInheritHandle, string lpName);

		[DllImport("kernel32.dll")]
		private static extern IntPtr MapViewOfFile(IntPtr hFileMappingObject, uint dwDesiredAccess, uint dwFileOffsetHigh, uint dwFileOffsetLow, IntPtr dwNumberOfBytesToMap);

		[DllImport("kernel32.dll")]
		private static extern bool UnmapViewOfFile(IntPtr lpBaseAddress);

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern int CloseHandle(IntPtr hObject);

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern int FlushViewOfFile(IntPtr address, uint numBytes);
	}
}
