using MySql.Data.MySqlClient;
using System;

namespace MySql.Data.Types
{
	internal class MySqlUByte : MySqlValue
	{
		private byte mValue;

		public byte Value
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

		internal override Type SystemType
		{
			get
			{
				return typeof(byte);
			}
		}

		public MySqlUByte()
		{
			this.dbType = 2;
			this.mySqlDbType = MySqlDbType.Byte;
		}

		internal override void Serialize(PacketWriter writer, bool binary, object value, int length)
		{
			byte b = Convert.ToByte(value);
			if (binary)
			{
				writer.WriteByte(b);
				return;
			}
			writer.WriteStringNoNull(b.ToString());
		}

		internal override string GetMySqlTypeName()
		{
			if (this.mySqlDbType == MySqlDbType.Year)
			{
				return "YEAR";
			}
			return "TINYINT";
		}

		internal override MySqlValue ReadValue(PacketReader reader, long length)
		{
			if (length == -1L)
			{
				this.Value = (byte)reader.ReadByte();
			}
			else
			{
				this.Value = byte.Parse(reader.ReadString(length));
			}
			return this;
		}

		internal override void Skip(PacketReader reader)
		{
			reader.ReadByte();
		}
	}
}
