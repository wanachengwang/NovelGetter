using MySql.Data.MySqlClient;
using System;

namespace MySql.Data.Types
{
	internal class MySqlUInt32 : MySqlValue
	{
		private uint mValue;

		public uint Value
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
				return typeof(uint);
			}
		}

		public MySqlUInt32(MySqlDbType type)
		{
			this.mySqlDbType = type;
		}

		internal override void Serialize(PacketWriter writer, bool binary, object value, int length)
		{
			uint num = Convert.ToUInt32(value);
			if (binary)
			{
				writer.Write(BitConverter.GetBytes(num));
				return;
			}
			writer.WriteStringNoNull(num.ToString());
		}

		internal override string GetMySqlTypeName()
		{
			return "INT";
		}

		internal override MySqlValue ReadValue(PacketReader reader, long length)
		{
			if (length == -1L)
			{
				if (this.mySqlDbType == MySqlDbType.Int24)
				{
					this.Value = (uint)reader.ReadInteger(3);
				}
				else
				{
					this.Value = (uint)reader.ReadLong(4);
				}
			}
			else
			{
				string text = reader.ReadString(length);
				this.Value = uint.Parse(text);
			}
			return this;
		}

		internal override void Skip(PacketReader reader)
		{
			reader.Skip(4L);
		}
	}
}
