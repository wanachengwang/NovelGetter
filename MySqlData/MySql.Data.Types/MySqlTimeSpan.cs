using MySql.Data.MySqlClient;
using System;

namespace MySql.Data.Types
{
	internal class MySqlTimeSpan : MySqlValue
	{
		private TimeSpan mValue;

		public TimeSpan Value
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
				return typeof(TimeSpan);
			}
		}

		public MySqlTimeSpan()
		{
			this.dbType = 17;
			this.mySqlDbType = MySqlDbType.Time;
		}

		public MySqlTimeSpan(TimeSpan val) : this()
		{
			this.mValue = val;
		}

		internal override void Serialize(PacketWriter writer, bool binary, object value, int length)
		{
			if (!(value is TimeSpan))
			{
				throw new MySqlException("Only TimeSpan objects can be serialized by MySqlTimeSpan");
			}
			TimeSpan timeSpan = (TimeSpan)value;
			if (binary)
			{
				writer.WriteByte(8);
				writer.WriteByte((timeSpan.get_TotalSeconds() < 0.0) ? 1 : 0);
				writer.WriteInteger((long)timeSpan.get_Days(), 4);
				writer.WriteByte((byte)timeSpan.get_Hours());
				writer.WriteByte((byte)timeSpan.get_Minutes());
				writer.WriteByte((byte)timeSpan.get_Seconds());
				return;
			}
			writer.WriteStringNoNull(string.Format("'{0} {1:00}:{2:00}:{3:00}.{4}'", new object[]
			{
				timeSpan.get_Days(),
				timeSpan.get_Hours(),
				timeSpan.get_Minutes(),
				timeSpan.get_Seconds(),
				timeSpan.get_Milliseconds()
			}));
		}

		public override string ToString()
		{
			return string.Format("{0} {1:00}:{2:00}:{3:00}.{4}", new object[]
			{
				this.mValue.get_Days(),
				this.mValue.get_Hours(),
				this.mValue.get_Minutes(),
				this.mValue.get_Seconds(),
				this.mValue.get_Milliseconds()
			});
		}

		internal override string GetMySqlTypeName()
		{
			return "TIME";
		}

		private void ParseMySql(string s, bool is41)
		{
			string[] array = s.Split(new char[]
			{
				':'
			});
			int num = int.Parse(array[0]);
			int num2 = int.Parse(array[1]);
			int num3 = int.Parse(array[2]);
			if (num < 0)
			{
				num2 *= -1;
				num3 *= -1;
			}
			int num4 = num / 24;
			num -= num4 * 24;
			this.Value = new TimeSpan(num4, num, num2, num3, 0);
		}

		internal override MySqlValue ReadValue(PacketReader reader, long length)
		{
			if (length >= 0L)
			{
				string s = reader.ReadString(length);
				this.ParseMySql(s, reader.Version.isAtLeast(4, 1, 0));
				return this;
			}
			long num = (long)reader.ReadByte();
			int num2 = 0;
			if (num > 0L)
			{
				num2 = reader.ReadByte();
			}
			if (num == 0L)
			{
				base.IsNull = true;
			}
			else if (num == 5L)
			{
				this.Value = new TimeSpan(reader.ReadInteger(4), 0, 0, 0);
			}
			else if (num == 8L)
			{
				this.Value = new TimeSpan(reader.ReadInteger(4), reader.ReadByte(), reader.ReadByte(), reader.ReadByte());
			}
			else
			{
				this.Value = new TimeSpan(reader.ReadInteger(4), reader.ReadByte(), reader.ReadByte(), reader.ReadByte(), reader.ReadInteger(4) / 1000000);
			}
			if (num2 == 1)
			{
				this.Value = this.mValue.Negate();
			}
			return this;
		}

		public string ToMySqlString(bool is41)
		{
			return this.mValue.ToString();
		}

		internal override void Skip(PacketReader reader)
		{
			long count = (long)reader.ReadByte();
			reader.Skip(count);
		}
	}
}
