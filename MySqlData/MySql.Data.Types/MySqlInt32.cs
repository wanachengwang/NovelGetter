using MySql.Data.MySqlClient;
using System;

namespace MySql.Data.Types
{
	internal class MySqlInt32 : MySqlValue
	{
		private int mValue;

		public int Value
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
				return typeof(int);
			}
		}

		public MySqlInt32(MySqlDbType type)
		{
			this.dbType = 11;
			this.mySqlDbType = type;
		}

		internal override void Serialize(PacketWriter writer, bool binary, object value, int length)
		{
			int num = Convert.ToInt32(value);
			if (binary)
			{
				writer.Write(BitConverter.GetBytes(num));
				return;
			}
			writer.WriteStringNoNull(num.ToString(MySqlValue.numberFormat));
		}

		internal override string GetMySqlTypeName()
		{
			if (this.mySqlDbType == MySqlDbType.Int24)
			{
				return "MEDIUMINT";
			}
			return "INT";
		}

		internal override MySqlValue ReadValue(PacketReader reader, long length)
		{
			if (length == -1L)
			{
				if (this.mySqlDbType == MySqlDbType.Int24)
				{
					this.Value = reader.ReadInteger(3);
				}
				else
				{
					this.Value = (int)reader.ReadLong(4);
				}
			}
			else
			{
				string text = reader.ReadString(length);
				this.Value = int.Parse(text, MySqlValue.numberFormat);
			}
			return this;
		}

		internal override void Skip(PacketReader reader)
		{
			reader.Skip(4L);
		}
	}
}
