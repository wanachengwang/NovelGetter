using MySql.Data.MySqlClient;
using System;

namespace MySql.Data.Types
{
	internal class MySqlDecimal : MySqlValue
	{
		private byte precision;

		private byte scale;

		private decimal mValue;

		public byte Precision
		{
			get
			{
				return this.precision;
			}
			set
			{
				this.precision = value;
			}
		}

		public byte Scale
		{
			get
			{
				return this.scale;
			}
			set
			{
				this.scale = value;
			}
		}

		public decimal Value
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
				return typeof(decimal);
			}
		}

		public MySqlDecimal()
		{
			this.dbType = 7;
			this.mySqlDbType = MySqlDbType.Decimal;
		}

		internal override void Serialize(PacketWriter writer, bool binary, object value, int length)
		{
			decimal num = Convert.ToDecimal(value);
			if (binary)
			{
				writer.WriteLenString(num.ToString(MySqlValue.numberFormat));
				return;
			}
			writer.WriteStringNoNull(num.ToString(MySqlValue.numberFormat));
		}

		internal override string GetMySqlTypeName()
		{
			return "DECIMAL";
		}

		internal override MySqlValue ReadValue(PacketReader reader, long length)
		{
			if (length == -1L)
			{
				string text = reader.ReadLenString();
				this.Value = decimal.Parse(text, MySqlValue.numberFormat);
			}
			else
			{
				string text2 = reader.ReadString(length);
				this.Value = decimal.Parse(text2, MySqlValue.numberFormat);
			}
			return this;
		}

		internal override void Skip(PacketReader reader)
		{
			long fieldLength = reader.GetFieldLength();
			reader.Skip(fieldLength);
		}
	}
}
