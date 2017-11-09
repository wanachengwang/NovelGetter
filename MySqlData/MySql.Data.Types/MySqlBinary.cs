using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Text;

namespace MySql.Data.Types
{
	internal class MySqlBinary : MySqlValue
	{
		private byte[] mValue;

		private bool isBinary;

		public bool IsBinary
		{
			get
			{
				return this.isBinary;
			}
			set
			{
				this.isBinary = value;
			}
		}

		public byte[] Value
		{
			get
			{
				return this.mValue;
			}
			set
			{
				this.mValue = value;
				this.objectValue = value;
			}
		}

		internal override DbType DbType
		{
			get
			{
				if (this.isBinary)
				{
					return 1;
				}
				return 16;
			}
		}

		internal override Type SystemType
		{
			get
			{
				return typeof(byte[]);
			}
		}

		public MySqlBinary(byte[] val, MySqlDbType type)
		{
			this.Value = val;
			this.mySqlDbType = type;
		}

		internal string ToString(Encoding encoding)
		{
			return encoding.GetString(this.mValue);
		}

		internal override void Serialize(PacketWriter writer, bool binary, object ourValue, int length)
		{
			byte[] array;
			if (ourValue is byte[])
			{
				array = (byte[])ourValue;
			}
			else if (ourValue is char[])
			{
				array = writer.Encoding.GetBytes(ourValue as char[]);
				length = array.Length;
			}
			else
			{
				string text = ourValue.ToString().Substring(0, length);
				array = writer.Encoding.GetBytes(text);
				length = array.Length;
			}
			if (array == null)
			{
				throw new MySqlException("Only byte arrays and strings can be serialized by MySqlBinary");
			}
			if (binary)
			{
				writer.WriteLength((long)length);
				writer.Write(array, 0, length);
				return;
			}
			if (writer.Version.isAtLeast(4, 1, 0))
			{
				writer.WriteStringNoNull("_binary ");
			}
			writer.WriteByte(39);
			this.EscapeByteArray(array, length, writer);
			writer.WriteByte(39);
		}

		private void EscapeByteArray(byte[] bytes, int length, PacketWriter writer)
		{
			MemoryStream memoryStream = (MemoryStream)writer.Stream;
			MemoryStream expr_0D = memoryStream;
			expr_0D.set_Capacity(expr_0D.get_Capacity() + length * 2);
			for (int i = 0; i < length; i++)
			{
				byte b = bytes[i];
				if (b == 0)
				{
					writer.WriteByte(92);
					writer.WriteByte(48);
				}
				else
				{
					if (b != 92 && b != 39)
					{
						if (b != 34)
						{
							writer.WriteByte(b);
							goto IL_62;
						}
					}
					writer.WriteByte(92);
					writer.WriteByte(b);
				}
				IL_62:;
			}
		}

		internal override string GetMySqlTypeName()
		{
			switch (this.mySqlDbType)
			{
			case MySqlDbType.TinyBlob:
				return "TINY_BLOB";
			case MySqlDbType.MediumBlob:
				return "MEDIUM_BLOB";
			case MySqlDbType.LongBlob:
				return "LONG_BLOB";
			}
			return "BLOB";
		}

		internal override MySqlValue ReadValue(PacketReader reader, long length)
		{
			if (length == -1L)
			{
				length = reader.GetFieldLength();
			}
			byte[] val = new byte[length];
			reader.Read(ref val, 0L, length);
			return new MySqlBinary(val, this.mySqlDbType);
		}

		internal override void Skip(PacketReader reader)
		{
			long fieldLength = reader.GetFieldLength();
			reader.Skip(fieldLength);
		}
	}
}
