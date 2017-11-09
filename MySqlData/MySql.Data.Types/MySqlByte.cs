using MySql.Data.MySqlClient;
using System;

namespace MySql.Data.Types
{
	internal class MySqlByte : MySqlValue
	{
		private sbyte mValue;

		public sbyte Value
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
				return typeof(sbyte);
			}
		}

		public MySqlByte()
		{
			this.dbType = 14;
			this.mySqlDbType = MySqlDbType.Byte;
		}

		internal override void Serialize(PacketWriter writer, bool binary, object value, int length)
		{
			sbyte b = Convert.ToSByte(value);
			if (binary)
			{
				writer.WriteByte((byte)b);
				return;
			}
			writer.WriteStringNoNull(b.ToString());
		}

		internal override string GetMySqlTypeName()
		{
			return "TINYINT";
		}

		internal override MySqlValue ReadValue(PacketReader reader, long length)
		{
			if (length == -1L)
			{
				this.Value = (sbyte)reader.ReadByte();
			}
			else
			{
				this.Value = sbyte.Parse(reader.ReadString(length));
			}
			return this;
		}

		internal override void Skip(PacketReader reader)
		{
			reader.ReadByte();
		}
	}
}
