using MySql.Data.MySqlClient;
using System;

namespace MySql.Data.Types
{
	internal class MySqlFloat : MySqlValue
	{
		private float mValue;

		public float Value
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

		public static float MaxValue
		{
			get
			{
				return float.Parse(3.40282347E+38f.ToString("R"));
			}
		}

		public static float MinValue
		{
			get
			{
				return float.Parse(-3.40282347E+38f.ToString("R"));
			}
		}

		internal override Type SystemType
		{
			get
			{
				return typeof(float);
			}
		}

		public MySqlFloat()
		{
			this.dbType = 15;
			this.mySqlDbType = MySqlDbType.Float;
		}

		internal override void Serialize(PacketWriter writer, bool binary, object value, int length)
		{
			float num = Convert.ToSingle(value);
			if (binary)
			{
				writer.Write(BitConverter.GetBytes(num));
				return;
			}
			writer.WriteStringNoNull(num.ToString(MySqlValue.numberFormat));
		}

		internal override string GetMySqlTypeName()
		{
			return "FLOAT";
		}

		internal override MySqlValue ReadValue(PacketReader reader, long length)
		{
			if (length == -1L)
			{
				byte[] array = new byte[4];
				reader.Read(ref array, 0L, 4L);
				this.Value = BitConverter.ToSingle(array, 0);
			}
			else
			{
				string s = reader.ReadString(length);
				this.Value = this.Parse(s);
			}
			return this;
		}

		internal override void Skip(PacketReader reader)
		{
			reader.Skip(4L);
		}

		private float Parse(string s)
		{
			float result = 0f;
			float result2;
			try
			{
				result = float.Parse(s, MySqlValue.numberFormat);
				return result;
			}
			catch (Exception)
			{
				s = s.ToLower();
				bool flag = s.StartsWith(MySqlValue.numberFormat.get_NegativeSign());
				if (s.IndexOf("e+") != -1)
				{
					result2 = (flag ? MySqlFloat.MinValue : MySqlFloat.MaxValue);
				}
				else
				{
					result2 = 0f;
				}
			}
			return result2;
		}
	}
}
