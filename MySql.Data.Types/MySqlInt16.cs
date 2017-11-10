using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace MySql.Data.Types
{
	internal class MySqlInt16 : MySqlValue
	{
		private short mValue;

		public short Value
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
				return typeof(short);
			}
		}

		public MySqlInt16()
		{
			this.dbType = (DbType)10;
			this.mySqlDbType = MySqlDbType.Int16;
		}

		internal override void Serialize(PacketWriter writer, bool binary, object value, int length)
		{
			short num = Convert.ToInt16(value);
			if (binary)
			{
				writer.Write(BitConverter.GetBytes(num));
				return;
			}
			writer.WriteStringNoNull(num.ToString(MySqlValue.numberFormat));
		}

		internal override string GetMySqlTypeName()
		{
			return "SMALLINT";
		}

		internal override MySqlValue ReadValue(PacketReader reader, long length)
		{
			if (length == -1L)
			{
				this.Value = (short)reader.ReadInteger(2);
			}
			else
			{
				string text = reader.ReadString(length);
				this.Value = short.Parse(text, MySqlValue.numberFormat);
			}
			return this;
		}

		internal override void Skip(PacketReader reader)
		{
			reader.Skip(2L);
		}
	}
}
