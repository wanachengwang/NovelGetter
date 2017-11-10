using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Globalization;

namespace MySql.Data.Types
{
	internal class MySqlDouble : MySqlValue
	{
		private double mValue;

		public static double MaxValue
		{
			get
			{
				return double.Parse(1.7976931348623157E+308.ToString("R"));
			}
		}

		public static double MinValue
		{
			get
			{
				return double.Parse((-1.7976931348623157E+308).ToString("R"));
			}
		}

		public double Value
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
				return typeof(double);
			}
		}

		public MySqlDouble()
		{
			this.dbType = (DbType)8;
			this.mySqlDbType = MySqlDbType.Double;
		}

		internal override void Serialize(PacketWriter writer, bool binary, object value, int length)
		{
			double num = Convert.ToDouble(value);
			if (binary)
			{
				writer.Write(BitConverter.GetBytes(num));
				return;
			}
			writer.WriteStringNoNull(num.ToString("R", MySqlValue.numberFormat));
		}

		internal override string GetMySqlTypeName()
		{
			return "DOUBLE";
		}

		internal override MySqlValue ReadValue(PacketReader reader, long length)
		{
			if (length == -1L)
			{
				byte[] array = new byte[8];
				reader.Read(ref array, 0L, 8L);
				this.Value = BitConverter.ToDouble(array, 0);
			}
			else
			{
				string s = reader.ReadString(length);
				this.Value = this.Parse(s);
			}
			return this;
		}

		private double Parse(string s)
		{
			double result = 0.0;
            if (double.TryParse(s, (NumberStyles)231, MySqlValue.numberFormat, out result))
			{
				return result;
			}
			s = s.ToLower();
			bool flag = s.StartsWith(MySqlValue.numberFormat.NegativeSign);
			if (s.IndexOf("e+") == -1)
			{
				return 0.0;
			}
			if (!flag)
			{
				return MySqlDouble.MaxValue;
			}
			return MySqlDouble.MinValue;
		}

		internal override void Skip(PacketReader reader)
		{
			reader.Skip(8L);
		}
	}
}
