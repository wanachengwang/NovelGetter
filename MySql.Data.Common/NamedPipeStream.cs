using MySql.Data.MySqlClient;
using System;
using System.IO;

namespace MySql.Data.Common
{
	internal class NamedPipeStream : Stream
	{
		private int pipeHandle;

		private FileAccess _mode;

		public override bool CanRead
		{
			get
			{
				return ((int)this._mode & 1) > 0;
			}
		}

		public override bool CanWrite
		{
			get
			{
				return ((int)this._mode & 2) > 0;
			}
		}

		public override bool CanSeek
		{
			get
			{
				throw new NotSupportedException(Resources.NamedPipeNoSeek);
			}
		}

		public override long Length
		{
			get
			{
				throw new NotSupportedException(Resources.NamedPipeNoSeek);
			}
		}

		public override long Position
		{
			get
			{
				throw new NotSupportedException(Resources.NamedPipeNoSeek);
			}
			set
			{
			}
		}

		public NamedPipeStream(string host, FileAccess mode)
		{
			this.Open(host, mode);
		}

		public void Open(string host, FileAccess mode)
		{
			this._mode = mode;
			uint num = 0u;
			if (((int)mode & 1) > 0)
			{
				num |= 2147483648u;
			}
			if (((int)mode & 2) > 0)
			{
				num |= 1073741824u;
			}
			this.pipeHandle = NativeMethods.CreateFile(host, num, 0u, null, 3u, 0u, 0u);
		}

		public override void Flush()
		{
			if (this.pipeHandle != 0)
			{
				NativeMethods.FlushFileBuffers((IntPtr)this.pipeHandle);
			}
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer", Resources.BufferCannotBeNull);
			}
			if (buffer.Length < offset + count)
			{
				throw new ArgumentException(Resources.BufferNotLargeEnough);
			}
			if (offset < 0)
			{
				throw new ArgumentOutOfRangeException("offset", offset, Resources.OffsetCannotBeNegative);
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count", count, Resources.CountCannotBeNegative);
			}
			if (!this.CanRead)
			{
				throw new NotSupportedException(Resources.StreamNoRead);
			}
			if (this.pipeHandle == 0)
			{
				throw new ObjectDisposedException("NamedPipeStream", Resources.StreamAlreadyClosed);
			}
			uint num = 0u;
			byte[] array = new byte[count];
			if (!NativeMethods.ReadFile((IntPtr)this.pipeHandle, array, (uint)count, out num, IntPtr.Zero))
			{
				this.Close();
				throw new MySqlException(Resources.ReadFromStreamFailed, true, null);
			}
			Array.Copy(array, 0, buffer, offset, (int)num);
			return (int)num;
		}

		public override void Close()
		{
			if (this.pipeHandle != 0)
			{
				NativeMethods.CloseHandle((IntPtr)this.pipeHandle);
				this.pipeHandle = 0;
			}
		}

		public override void SetLength(long length)
		{
			throw new NotSupportedException(Resources.NamedPipeNoSetLength);
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer", Resources.BufferCannotBeNull);
			}
			if (buffer.Length < offset + count)
			{
				throw new ArgumentException(Resources.BufferNotLargeEnough, "buffer");
			}
			if (offset < 0)
			{
				throw new ArgumentOutOfRangeException("offset", offset, Resources.OffsetCannotBeNegative);
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count", count, Resources.CountCannotBeNegative);
			}
			if (!this.CanWrite)
			{
				throw new NotSupportedException(Resources.StreamNoWrite);
			}
			if (this.pipeHandle == 0)
			{
				throw new ObjectDisposedException("NamedPipeStream", Resources.StreamAlreadyClosed);
			}
			uint num = 0u;
			bool flag;
			if (offset == 0 && count <= 65535)
			{
				flag = NativeMethods.WriteFile((IntPtr)this.pipeHandle, buffer, (uint)count, out num, IntPtr.Zero);
			}
			else
			{
				byte[] array = new byte[65535];
				flag = true;
				while (count != 0 && flag)
				{
					int num2 = Math.Min(count, 65535);
					Array.Copy(buffer, offset, array, 0, num2);
					uint num3;
					flag = NativeMethods.WriteFile((IntPtr)this.pipeHandle, array, (uint)num2, out num3, IntPtr.Zero);
					num += num3;
					count -= num2;
					offset += num2;
				}
			}
			if (!flag)
			{
				this.Close();
				throw new MySqlException(Resources.WriteToStreamFailed, true, null);
			}
			if ((ulong)num < (ulong)((long)count))
			{
				throw new IOException("Unable to write entire buffer to stream");
			}
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException(Resources.NamedPipeNoSeek);
		}
	}
}
