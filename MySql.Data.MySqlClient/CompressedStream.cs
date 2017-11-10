using System;
using System.IO;
using zlib;

namespace MySql.Data.MySqlClient
{
	internal class CompressedStream : Stream
	{
		private Stream baseStream;

		private MemoryStream cache;

		private byte[] localByte;

		private byte[] inBuffer;

		private WeakReference inBufferRef;

		private int inPos;

		private int maxInPos;

		private ZInputStream zInStream;

		public override bool CanRead
		{
			get
			{
				return this.baseStream.CanRead;
			}
		}

		public override bool CanWrite
		{
			get
			{
				return this.baseStream.CanWrite;
			}
		}

		public override bool CanSeek
		{
			get
			{
				return this.baseStream.CanSeek;
			}
		}

		public override long Length
		{
			get
			{
				return this.baseStream.Length;
			}
		}

		public override long Position
		{
			get
			{
				return this.baseStream.Position;
			}
			set
			{
				this.baseStream.Position = (value);
			}
		}

		public CompressedStream(Stream baseStream)
		{
			this.baseStream = baseStream;
			this.localByte = new byte[1];
			this.cache = new MemoryStream();
			this.inBufferRef = new WeakReference(this.inBuffer, false);
		}

		public override void Close()
		{
			this.baseStream.Close();
			base.Close();
		}

		public override void SetLength(long value)
		{
			throw new NotSupportedException(Resources.CSNoSetLength);
		}

		public override int ReadByte()
		{
			this.Read(this.localByte, 0, 1);
			return (int)this.localByte[0];
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer", Resources.BufferCannotBeNull);
			}
			if (offset < 0 || offset >= buffer.Length)
			{
				throw new ArgumentOutOfRangeException("offset", Resources.OffsetMustBeValid);
			}
			if (offset + count > buffer.Length)
			{
				throw new ArgumentException(Resources.BufferNotLargeEnough, "buffer");
			}
			if (this.inPos == this.maxInPos)
			{
				this.PrepareNextPacket();
			}
			int num = Math.Min(count, this.maxInPos - this.inPos);
			int num2;
			if (this.zInStream != null)
			{
				num2 = this.zInStream.read(buffer, offset, num);
			}
			else
			{
				num2 = this.baseStream.Read(buffer, offset, num);
			}
			this.inPos += num2;
			if (this.inPos == this.maxInPos)
			{
				this.zInStream = null;
				this.inBufferRef.Target = (this.inBuffer);
				this.inBuffer = null;
			}
			return num2;
		}

		private void PrepareNextPacket()
		{
			byte b = (byte)this.baseStream.ReadByte();
			byte b2 = (byte)this.baseStream.ReadByte();
			byte b3 = (byte)this.baseStream.ReadByte();
			int num = (int)b + ((int)b2 << 8) + ((int)b3 << 16);
			this.baseStream.ReadByte();
			int num2 = this.baseStream.ReadByte() + (this.baseStream.ReadByte() << 8) + (this.baseStream.ReadByte() << 16);
			if (num2 == 0)
			{
				num2 = num;
				this.zInStream = null;
			}
			else
			{
				this.ReadNextPacket(num);
				MemoryStream in_Renamed = new MemoryStream(this.inBuffer);
				this.zInStream = new ZInputStream(in_Renamed);
				this.zInStream.maxInput = (long)num;
			}
			this.inPos = 0;
			this.maxInPos = num2;
		}

		private void ReadNextPacket(int len)
		{
			this.inBuffer = (byte[])this.inBufferRef.Target;
			if (this.inBuffer == null || this.inBuffer.Length < len)
			{
				this.inBuffer = new byte[len];
			}
			int num = 0;
			int num2;
			for (int i = len; i > 0; i -= num2)
			{
				num2 = this.baseStream.Read(this.inBuffer, num, i);
				num += num2;
			}
		}

		private MemoryStream CompressCache()
		{
			if (this.cache.Length < 50L)
			{
				return null;
			}
			byte[] buffer = this.cache.GetBuffer();
			MemoryStream memoryStream = new MemoryStream();
			ZOutputStream zOutputStream = new ZOutputStream(memoryStream, -1);
			zOutputStream.Write(buffer, 0, (int)this.cache.Length);
			zOutputStream.finish();
			if (memoryStream.Length >= this.cache.Length)
			{
				return null;
			}
			return memoryStream;
		}

		private void CompressAndSendCache()
		{
			long num = 0L;
			byte[] buffer = this.cache.GetBuffer();
			byte b = buffer[3];
			buffer[3] = 0;
			MemoryStream memoryStream = this.CompressCache();
			long length;
			if (memoryStream == null)
			{
				length = this.cache.Length;
			}
			else
			{
				length = memoryStream.Length;
				num = this.cache.Length;
			}
			this.baseStream.WriteByte((byte)(length & 255L));
			this.baseStream.WriteByte((byte)(length >> 8 & 255L));
			this.baseStream.WriteByte((byte)(length >> 16 & 255L));
			this.baseStream.WriteByte(b);
			this.baseStream.WriteByte((byte)(num & 255L));
			this.baseStream.WriteByte((byte)(num >> 8 & 255L));
			this.baseStream.WriteByte((byte)(num >> 16 & 255L));
			if (memoryStream == null)
			{
				this.baseStream.Write(buffer, 0, (int)this.cache.Length);
			}
			else
			{
				byte[] buffer2 = memoryStream.GetBuffer();
				this.baseStream.Write(buffer2, 0, (int)memoryStream.Length);
			}
			this.baseStream.Flush();
			this.cache.SetLength(0L);
		}

		public override void Flush()
		{
			if (!this.InputDone())
			{
				return;
			}
			this.CompressAndSendCache();
		}

		private bool InputDone()
		{
			if (this.cache.Length < 4L)
			{
				return false;
			}
			byte[] buffer = this.cache.GetBuffer();
			int num = (int)buffer[0] + ((int)buffer[1] << 8) + ((int)buffer[2] << 16);
			return this.cache.Length >= (long)(num + 4);
		}

		public override void WriteByte(byte value)
		{
			this.cache.WriteByte(value);
			this.Flush();
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			this.cache.Write(buffer, offset, count);
			this.Flush();
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			return this.baseStream.Seek(offset, origin);
		}
	}
}
