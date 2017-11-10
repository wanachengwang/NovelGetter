using MySql.Data.Common;
using System;
using System.IO;
using System.Text;

namespace MySql.Data.MySqlClient
{
	internal class PacketWriter
	{
		private Stream stream;

		private MemoryStream buffStream;

		private Stream nativeStream;

		private Encoding encoding;

		private NativeDriver driver;

		private long leftThisPacket = 0L;

		private long leftToWrite = 0L;

		private DBVersion version;

		public DBVersion Version
		{
			get
			{
				return this.version;
			}
			set
			{
				this.version = value;
			}
		}

		public NativeDriver Driver
		{
			get
			{
				return this.driver;
			}
			set
			{
				this.driver = value;
			}
		}

		public bool Buffering
		{
			get
			{
				return this.stream is MemoryStream;
			}
			set
			{
				this.stream = (value ? this.buffStream : this.nativeStream);
			}
		}

		public Stream Stream
		{
			get
			{
				return this.stream;
			}
		}

		public Encoding Encoding
		{
			get
			{
				return this.encoding;
			}
			set
			{
				this.encoding = value;
			}
		}

		public PacketWriter()
		{
			this.buffStream = new MemoryStream();
			this.Buffering = true;
		}

		public PacketWriter(Stream stream, NativeDriver driver) : this()
		{
			this.driver = driver;
			this.nativeStream = stream;
		}

		private void WriteStartBlock(long len)
		{
			long num = (long)this.driver.MaxSinglePacket;
			if (this.stream is CompressedStream)
			{
				num -= 4L;
			}
			this.leftThisPacket = Math.Min(num, len);
			this.stream.WriteByte((byte)(this.leftThisPacket & 255L));
			this.stream.WriteByte((byte)(this.leftThisPacket >> 8 & 255L));
			this.stream.WriteByte((byte)(this.leftThisPacket >> 16 & 255L));
			Stream arg_A9_0 = this.stream;
			NativeDriver expr_98 = this.driver;
			byte sequenceByte;
			expr_98.SequenceByte = (byte)((sequenceByte = expr_98.SequenceByte) + 1);
			arg_A9_0.WriteByte(sequenceByte);
		}

		public void StartPacket(long len)
		{
			this.Buffering = (len == 0L);
			if (this.Buffering)
			{
				this.buffStream.SetLength(0L);
				return;
			}
			if (len > this.driver.MaxPacketSize)
			{
				throw new MySqlException(Resources.QueryTooLarge, 1153);
			}
			this.WriteStartBlock(len);
			this.leftToWrite = len;
		}

		private void FlushBuffer()
		{
			long num = this.buffStream.Length;
			byte[] buffer = this.buffStream.GetBuffer();
			long num2 = 0L;
			if (num > this.driver.MaxPacketSize)
			{
				throw new MySqlException(Resources.QueryTooLarge, 1153);
			}
			while (num > 0L)
			{
				int num3 = Math.Min(this.driver.MaxSinglePacket, (int)num);
				this.nativeStream.WriteByte((byte)(num3 & 255));
				this.nativeStream.WriteByte((byte)(num3 >> 8 & 255));
				this.nativeStream.WriteByte((byte)(num3 >> 16 & 255));
				Stream arg_B3_0 = this.nativeStream;
				NativeDriver expr_A0 = this.driver;
				byte sequenceByte;
				expr_A0.SequenceByte = (byte)((sequenceByte = expr_A0.SequenceByte) + 1);
				arg_B3_0.WriteByte(sequenceByte);
				this.nativeStream.Write(buffer, (int)num2, num3);
				this.nativeStream.Flush();
				num -= (long)num3;
				num2 += (long)num3;
			}
			this.Buffering = true;
		}

		public void Flush()
		{
			if (this.Buffering)
			{
				if (this.buffStream.Length > this.driver.MaxPacketSize)
				{
					throw new MySqlException("Packet size too large.  This MySQL server cannot accept rows larger than " + this.driver.MaxPacketSize + " bytes.");
				}
				this.FlushBuffer();
			}
			this.nativeStream.Flush();
		}

		public void WriteByte(byte b)
		{
			this.stream.WriteByte(b);
			this.leftToWrite -= 1L;
			this.leftThisPacket -= 1L;
		}

		public void Write(byte[] buffer)
		{
			this.Write(buffer, 0, buffer.Length);
		}

		public void WriteChunk(byte[] buf, int offset, int length)
		{
			while (length > 0)
			{
				long num = Math.Min(this.leftThisPacket, Math.Min((long)length, this.leftToWrite));
				this.stream.Write(buf, offset, (int)num);
				this.stream.Flush();
				this.leftThisPacket -= num;
				offset += (int)num;
				this.leftToWrite -= num;
				if (this.leftThisPacket == 0L && this.leftToWrite > 0L)
				{
					this.WriteStartBlock(this.leftToWrite);
				}
				length -= (int)num;
			}
		}

		public void Write(byte[] buffer, int offset, int count)
		{
			try
			{
				if (!this.Buffering)
				{
					this.WriteChunk(buffer, offset, count);
				}
				else
				{
					this.stream.Write(buffer, offset, count);
				}
			}
			catch (Exception ex)
			{
				Logger.LogException(ex);
				throw new MySqlException("Unable to write to stream", true, ex);
			}
		}

		public void WriteLength(long length)
		{
			if (length < 251L)
			{
				this.WriteByte((byte)length);
				return;
			}
			if (length < 65536L)
			{
				this.WriteByte(252);
				this.WriteInteger(length, 2);
				return;
			}
			if (length < 16777216L)
			{
				this.WriteByte(253);
				this.WriteInteger(length, 3);
				return;
			}
			this.WriteByte(254);
			this.WriteInteger(length, 4);
		}

		public void WriteInteger(long v, int numbytes)
		{
			long num = v;
			if (numbytes >= 1 && numbytes <= 4)
			{
				for (int i = 0; i < numbytes; i++)
				{
					this.stream.WriteByte((byte)(num & 255L));
					num >>= 8;
				}
				this.leftToWrite -= (long)numbytes;
				return;
			}
			throw new ArgumentOutOfRangeException("Wrong byte count for WriteInteger");
		}

		public void WriteLenString(string s)
		{
			byte[] bytes = this.encoding.GetBytes(s);
			this.WriteLength((long)bytes.Length);
			this.stream.Write(bytes, 0, bytes.Length);
		}

		public void WriteString(string v)
		{
			this.WriteStringNoNull(v);
			this.stream.WriteByte(0);
		}

		public void WriteStringNoNull(string v)
		{
			byte[] bytes = this.encoding.GetBytes(v);
			this.stream.Write(bytes, 0, bytes.Length);
		}
	}
}
