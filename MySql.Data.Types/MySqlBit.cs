using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace MySql.Data.Types
{
	internal class MySqlBit : MySqlValue
	{
		private ulong mValue;

		private byte[] buffer;

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

		public MySqlBit()
		{
			this.buffer = new byte[8];
			this.dbType = (DbType)20;
			this.mySqlDbType = MySqlDbType.Bit;
		}

		internal override void Serialize(PacketWriter writer, bool binary, object value, int length)
		{
			ulong num = Convert.ToUInt64(value);
			if (binary)
			{
				byte[] bytes = BitConverter.GetBytes(num);
				writer.Write(bytes);
				return;
			}
			writer.WriteStringNoNull(num.ToString());
		}

		internal override string GetMySqlTypeName()
		{
			return "BIT";
		}

		internal override MySqlValue ReadValue(PacketReader reader, long length)
		{
			if (length == -1L)
			{
				length = reader.GetFieldLength();
			}
			Array.Clear(this.buffer, 0, this.buffer.Length);
			for (long num = length - 1L; num >= 0L; num -= 1L)
			{
				this.buffer[(int)(checked((IntPtr)num))] = (byte)reader.ReadByte();
			}
			this.Value = BitConverter.ToUInt64(this.buffer, 0);
			return this;
		}

		internal override void Skip(PacketReader reader)
		{
			long fieldLength = reader.GetFieldLength();
			reader.Skip(fieldLength);
		}
	}
}
