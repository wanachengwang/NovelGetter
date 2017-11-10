using MySql.Data.Common;
using System;
using System.IO;
using System.Text;

namespace MySql.Data.MySqlClient
{
	internal class PacketReader
	{
		public static int NULL_LEN = -1;

		private Stream stream;

		private long packetLength;

		private bool isLastPacket;

		private NativeDriver driver;

		private int firstByte;

		private byte[] buffer;

		private Encoding encoding;

		private long bytesLeft;

		public DBVersion Version
		{
			get
			{
				return this.driver.Version;
			}
		}

		public int Length
		{
			get
			{
				return (int)this.packetLength;
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

		public Stream Stream
		{
			get
			{
				return this.stream;
			}
			set
			{
				this.stream = value;
			}
		}

		public bool IsLastPacket
		{
			get
			{
				return this.isLastPacket;
			}
		}

		public bool HasMoreData
		{
			get
			{
				return this.bytesLeft > 0L;
			}
		}

		public PacketReader(Stream stream, NativeDriver driver)
		{
			this.packetLength = -1L;
			this.isLastPacket = false;
			this.driver = driver;
			this.stream = stream;
			this.firstByte = -1;
			this.buffer = new byte[1024];
			this.encoding = driver.Encoding;
		}

		private void ReadHeader()
		{
			int num = this.stream.ReadByte();
			int num2 = this.stream.ReadByte();
			int num3 = this.stream.ReadByte();
			int num4 = this.stream.ReadByte();
			if (num != -1 && num2 != -1 && num3 != -1)
			{
				if (num4 != -1)
				{
					this.packetLength = (long)(num + (num2 << 8) + (num3 << 16));
					this.bytesLeft = this.packetLength;
					this.driver.SequenceByte = (byte)(num4 + 1);
					if (this.packetLength > 0L)
					{
						this.firstByte = this.stream.ReadByte();
						if (this.firstByte == -1)
						{
							throw new MySqlException("Connection unexpectedly terminated", true, null);
						}
					}
					this.encoding = this.driver.Encoding;
					this.isLastPacket = (this.packetLength < 9L && this.firstByte == 254);
					if (!this.isLastPacket)
					{
						this.CheckForError();
					}
					return;
				}
			}
			throw new MySqlException("Connection unexpectedly terminated", true, null);
		}

		public void OpenPacket()
		{
			while (this.bytesLeft > 0L || this.packetLength == (long)this.driver.MaxSinglePacket)
			{
				if (this.bytesLeft == 0L && this.packetLength == (long)this.driver.MaxSinglePacket)
				{
					this.ReadHeader();
				}
				this.Skip(this.bytesLeft);
			}
			this.ReadHeader();
		}

		public bool ReadOk()
		{
			this.OpenPacket();
			bool result = this.firstByte == 0 && this.packetLength > 1L;
			this.Skip(this.packetLength);
			return result;
		}

		private void CheckForError()
		{
			if (this.firstByte == 255)
			{
				this.ReadByte();
				int errno = this.ReadInteger(2);
				string text = this.ReadString();
				if (text.StartsWith("#"))
				{
					text.Substring(1, 5);
					text = text.Substring(6);
				}
				throw new MySqlException(text, errno);
			}
		}

		public void Skip(long count)
		{
			while (count > 0L)
			{
				int num = this.Read(ref this.buffer, 0L, (count > (long)this.buffer.Length) ? ((long)this.buffer.Length) : count);
				count -= (long)num;
			}
		}

		public int ReadByte()
		{
			this.bytesLeft -= 1L;
			if (this.firstByte != -1)
			{
				int result = this.firstByte;
				this.firstByte = -1;
				return result;
			}
			int num = this.stream.ReadByte();
			if (num == -1)
			{
				throw new MySqlException("Connection unexpectedly terminated", true, null);
			}
			return num;
		}

		public long GetFieldLength()
		{
			byte b = (byte)this.ReadByte();
			switch (b)
			{
			case 251:
				return (long)PacketReader.NULL_LEN;
			case 252:
				return (long)this.ReadInteger(2);
			case 253:
				return (long)this.ReadInteger(3);
			case 254:
				return (long)this.ReadInteger(8);
			default:
				return (long)((ulong)b);
			}
		}

		public int ReadNBytes()
		{
			byte b = (byte)this.ReadByte();
			if (b < 1 || b > 4)
			{
				throw new MySqlException("Unexpected byte count received");
			}
			return this.ReadInteger((int)b);
		}

		public int Read(ref byte[] buffer, long pos, long len)
		{
			if (buffer == null || (long)buffer.Length < len)
			{
				buffer = new byte[pos + len];
			}
			int result;
			try
			{
				long num = len;
				while (len > 0L)
				{
					if (this.bytesLeft == 0L && this.packetLength == (long)this.driver.MaxSinglePacket)
					{
						this.ReadHeader();
					}
					if (this.firstByte != -1)
					{
						byte[] arg_6A_0 = buffer;
						long expr_55 = pos;
						pos = expr_55 + 1L;
						arg_6A_0[(int)(checked((IntPtr)expr_55))] = (byte)this.ReadByte();
						len -= 1L;
					}
					else
					{
						int num2 = (int)Math.Min(len, this.bytesLeft);
						int num3 = this.stream.Read(buffer, (int)pos, num2);
						if (num3 == 0)
						{
							throw new MySqlException("Connection unexpectedly terminated", true, null);
						}
						len -= (long)num3;
						pos += (long)num3;
						this.bytesLeft -= (long)num3;
					}
				}
				result = (int)num;
			}
			catch (Exception ex)
			{
				Logger.LogException(ex);
				throw new MySqlException("Connection unexpectedly terminated", true, ex);
			}
			return result;
		}

		public ulong ReadLong(int numbytes)
		{
			ulong num = 0uL;
			int num2 = 1;
			for (int i = 0; i < numbytes; i++)
			{
				int num3 = this.ReadByte();
				num += (ulong)((long)(num3 * num2));
				num2 *= 256;
			}
			return num;
		}

		public int ReadInteger(int numbytes)
		{
			return (int)this.ReadLong(numbytes);
		}

		public string ReadString()
		{
			MemoryStream memoryStream = new MemoryStream();
			while (this.HasMoreData)
			{
				int num = this.ReadByte();
				if (num == 0)
				{
					break;
				}
				memoryStream.WriteByte((byte)num);
			}
			return this.Encoding.GetString(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
		}

		public int ReadPackedInteger()
		{
			byte result = (byte)this.ReadByte();
			switch (result)
			{
			case 251:
				return PacketReader.NULL_LEN;
			case 252:
				return this.ReadInteger(2);
			case 253:
				return this.ReadInteger(3);
			case 254:
				return this.ReadInteger(4);
			default:
				return (int)result;
			}
		}

		public string ReadString(long length)
		{
			if (length == 0L)
			{
				return string.Empty;
			}
			byte[] array = this.buffer;
			if (length > (long)array.Length)
			{
				array = new byte[length];
			}
			this.Read(ref array, 0L, length);
			return this.Encoding.GetString(array, 0, (int)length);
		}

		public string ReadLenString()
		{
			long length = (long)this.ReadPackedInteger();
			return this.ReadString(length);
		}
	}
}
