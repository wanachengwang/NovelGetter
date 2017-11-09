using MySql.Data.MySqlClient;
using System;

namespace MySql.Data.Types
{
	internal class MySqlInt64 : MySqlValue
	{
		private long mValue;

		public long Value
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
				return typeof(long);
			}
		}

		public MySqlInt64()
		{
			this.dbType = 12;
			this.mySqlDbType = MySqlDbType.Int64;
		}

		internal override void Serialize(PacketWriter writer, bool binary, object value, int length)
		{
			long num = Convert.ToInt64(value);
			if (binary)
			{
				writer.Write(BitConverter.GetBytes(num));
				return;
			}
			writer.WriteStringNoNull(num.ToString(MySqlValue.numberFormat));
		}

		internal override string GetMySqlTypeName()
		{
			return "BIGINT";
		}

		internal override MySqlValue ReadValue(PacketReader reader, long length)
		{
			if (length == -1L)
			{
				this.Value = (long)reader.ReadLong(8);
			}
			else
			{
				string text = reader.ReadString(length);
				this.Value = long.Parse(text, MySqlValue.numberFormat);
			}
			return this;
		}

		internal override void Skip(PacketReader reader)
		{
			reader.Skip(8L);
		}
	}
}
