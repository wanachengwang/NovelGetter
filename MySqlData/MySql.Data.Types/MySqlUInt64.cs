using MySql.Data.MySqlClient;
using System;

namespace MySql.Data.Types
{
	internal class MySqlUInt64 : MySqlValue
	{
		private ulong mValue;

		public ulong Value
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
				return typeof(ulong);
			}
		}

		public MySqlUInt64()
		{
			this.dbType = 20;
			this.mySqlDbType = MySqlDbType.Int64;
		}

		internal override void Serialize(PacketWriter writer, bool binary, object value, int length)
		{
			ulong num = Convert.ToUInt64(value);
			if (binary)
			{
				writer.Write(BitConverter.GetBytes(num));
				return;
			}
			writer.WriteStringNoNull(num.ToString());
		}

		internal override string GetMySqlTypeName()
		{
			return "BIGINT";
		}

		internal override MySqlValue ReadValue(PacketReader reader, long length)
		{
			if (length == -1L)
			{
				this.Value = reader.ReadLong(8);
			}
			else
			{
				string text = reader.ReadString(length);
				this.Value = ulong.Parse(text);
			}
			return this;
		}

		internal override void Skip(PacketReader reader)
		{
			reader.Skip(8L);
		}
	}
}
