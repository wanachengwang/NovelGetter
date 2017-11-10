using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace MySql.Data.Types
{
	internal class MySqlUInt16 : MySqlValue
	{
		private ushort mValue;

		public ushort Value
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
				return typeof(ushort);
			}
		}

		public MySqlUInt16()
		{
			this.dbType = (DbType)18;
			this.mySqlDbType = MySqlDbType.Int16;
		}

		public MySqlUInt16(MySqlDbType type) : this()
		{
			this.mySqlDbType = type;
		}

		internal override void Serialize(PacketWriter writer, bool binary, object value, int length)
		{
			ushort num = Convert.ToUInt16(value);
			if (binary)
			{
				writer.Write(BitConverter.GetBytes(num));
				return;
			}
			writer.WriteStringNoNull(num.ToString());
		}

		internal override string GetMySqlTypeName()
		{
			return "SMALLINT";
		}

		internal override MySqlValue ReadValue(PacketReader reader, long length)
		{
			if (length == -1L)
			{
				this.Value = (ushort)reader.ReadInteger(2);
			}
			else
			{
				string text = reader.ReadString(length);
				this.Value = ushort.Parse(text);
			}
			return this;
		}

		internal override void Skip(PacketReader reader)
		{
			reader.Skip(2L);
		}
	}
}
