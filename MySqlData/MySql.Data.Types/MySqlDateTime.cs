using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Globalization;

namespace MySql.Data.Types
{
	public class MySqlDateTime : MySqlValue, IConvertible, IComparable
	{
		private int year;

		private int month;

		private int day;

		private int hour;

		private int minute;

		private int second;

		private int milli;

		private static string fullPattern;

		private static string shortPattern;

		public bool IsValidDateTime
		{
			get
			{
				return this.year != 0 && this.month != 0 && this.day != 0;
			}
		}

		public int Year
		{
			get
			{
				return this.year;
			}
			set
			{
				this.year = value;
			}
		}

		public int Month
		{
			get
			{
				return this.month;
			}
			set
			{
				this.month = value;
			}
		}

		public int Day
		{
			get
			{
				return this.day;
			}
			set
			{
				this.day = value;
			}
		}

		public int Hour
		{
			get
			{
				return this.hour;
			}
			set
			{
				this.hour = value;
			}
		}

		public int Minute
		{
			get
			{
				return this.minute;
			}
			set
			{
				this.minute = value;
			}
		}

		public int Second
		{
			get
			{
				return this.second;
			}
			set
			{
				this.second = value;
			}
		}

		public int Millisecond
		{
			get
			{
				return this.milli;
			}
			set
			{
				this.milli = value;
			}
		}

		internal override DbType DbType
		{
			get
			{
				MySqlDbType mySqlDbType = this.mySqlDbType;
				if (mySqlDbType != MySqlDbType.Date)
				{
					if (mySqlDbType != MySqlDbType.Newdate)
					{
						return 6;
					}
				}
				return 5;
			}
		}

		internal override Type SystemType
		{
			get
			{
				return typeof(MySqlDateTime);
			}
		}

		public MySqlDateTime(int year, int month, int day, int hour, int minute, int second) : this(year, month, day, hour, minute, second, MySqlDbType.Datetime)
		{
		}

		public MySqlDateTime(DateTime dt) : this(dt, MySqlDbType.Datetime)
		{
		}

		public MySqlDateTime(MySqlDateTime mdt)
		{
			this.year = mdt.Year;
			this.month = mdt.Month;
			this.day = mdt.Day;
			this.hour = mdt.Hour;
			this.minute = mdt.Minute;
			this.second = mdt.Second;
			this.mySqlDbType = MySqlDbType.Datetime;
			this.isNull = false;
		}

		public MySqlDateTime(string s) : this(MySqlDateTime.Parse(s))
		{
		}

		internal MySqlDateTime(int year, int month, int day, int hour, int minute, int second, MySqlDbType type) : this(type)
		{
			this.year = year;
			this.month = month;
			this.day = day;
			this.hour = hour;
			this.minute = minute;
			this.second = second;
			if (MySqlDateTime.fullPattern == null)
			{
				this.ComposePatterns();
			}
		}

		internal MySqlDateTime(MySqlDbType type)
		{
			this.mySqlDbType = type;
			this.objectValue = this;
		}

		internal MySqlDateTime(DateTime val, MySqlDbType type) : this(type)
		{
			this.year = val.get_Year();
			this.month = val.get_Month();
			this.day = val.get_Day();
			this.hour = val.get_Hour();
			this.minute = val.get_Minute();
			this.second = val.get_Second();
			this.milli = val.get_Millisecond();
		}

		private void SerializeText(PacketWriter writer, MySqlDateTime value)
		{
			string text = string.Empty;
			if (this.mySqlDbType == MySqlDbType.Timestamp && !writer.Version.isAtLeast(4, 1, 0))
			{
				text = string.Format("{0:0000}{1:00}{2:00}{3:00}{4:00}{5:00}", new object[]
				{
					value.Year,
					value.Month,
					value.Day,
					value.Hour,
					value.Minute,
					value.Second
				});
			}
			else
			{
				text = string.Format("{0:0000}-{1:00}-{2:00}", value.Year, value.Month, value.Day);
				if (this.mySqlDbType != MySqlDbType.Date)
				{
					text = string.Format("{0} {1:00}:{2:00}:{3:00}", new object[]
					{
						text,
						value.Hour,
						value.Minute,
						value.Second
					});
				}
			}
			writer.WriteStringNoNull("'" + text + "'");
		}

		internal override void Serialize(PacketWriter writer, bool binary, object value, int length)
		{
			MySqlDateTime mySqlDateTime;
			if (value is DateTime)
			{
				mySqlDateTime = new MySqlDateTime((DateTime)value, base.MySqlDbType);
			}
			else if (value is string)
			{
				mySqlDateTime = new MySqlDateTime(DateTime.Parse((string)value, CultureInfo.get_CurrentCulture()), base.MySqlDbType);
			}
			else
			{
				if (!(value is MySqlDateTime))
				{
					throw new MySqlException("Unable to serialize date/time value.");
				}
				mySqlDateTime = (MySqlDateTime)value;
			}
			if (!binary)
			{
				this.SerializeText(writer, mySqlDateTime);
				return;
			}
			if (this.mySqlDbType == MySqlDbType.Timestamp)
			{
				writer.WriteByte(11);
			}
			else
			{
				writer.WriteByte(7);
			}
			writer.WriteInteger((long)mySqlDateTime.Year, 2);
			writer.WriteByte((byte)mySqlDateTime.Month);
			writer.WriteByte((byte)mySqlDateTime.Day);
			if (this.mySqlDbType == MySqlDbType.Date)
			{
				writer.WriteByte(0);
				writer.WriteByte(0);
				writer.WriteByte(0);
			}
			else
			{
				writer.WriteByte((byte)mySqlDateTime.Hour);
				writer.WriteByte((byte)mySqlDateTime.Minute);
				writer.WriteByte((byte)mySqlDateTime.Second);
			}
			if (this.mySqlDbType == MySqlDbType.Timestamp)
			{
				writer.WriteInteger((long)mySqlDateTime.Millisecond, 4);
			}
		}

		internal override string GetMySqlTypeName()
		{
			MySqlDbType mySqlDbType = this.mySqlDbType;
			if (mySqlDbType == MySqlDbType.Timestamp)
			{
				return "TIMESTAMP";
			}
			if (mySqlDbType == MySqlDbType.Date)
			{
				return "DATE";
			}
			if (mySqlDbType != MySqlDbType.Newdate)
			{
				return "DATETIME";
			}
			return "NEWDATE";
		}

		public DateTime GetDateTime()
		{
			if (!this.IsValidDateTime)
			{
				throw new MySqlConversionException("Unable to convert MySQL date/time value to System.DateTime");
			}
			return new DateTime(this.year, this.month, this.day, this.hour, this.minute, this.second);
		}

		private MySqlDateTime Parse40Timestamp(string s)
		{
			int num = 0;
			this.day = 1;
			this.month = 1;
			this.year = 1;
			this.second = 0;
			this.minute = 0;
			this.hour = 0;
			if (s.Length != 14)
			{
				if (s.Length != 8)
				{
					this.year = int.Parse(s.Substring(num, 2));
					num += 2;
					if (this.year >= 70)
					{
						this.year += 1900;
						goto IL_A1;
					}
					this.year += 2000;
					goto IL_A1;
				}
			}
			this.year = int.Parse(s.Substring(num, 4));
			num += 4;
			IL_A1:
			if (s.Length > 2)
			{
				this.month = int.Parse(s.Substring(num, 2));
				num += 2;
			}
			if (s.Length > 4)
			{
				this.day = int.Parse(s.Substring(num, 2));
				num += 2;
			}
			if (s.Length > 8)
			{
				this.hour = int.Parse(s.Substring(num, 2));
				this.minute = int.Parse(s.Substring(num + 2, 2));
				num += 4;
			}
			if (s.Length > 10)
			{
				this.second = int.Parse(s.Substring(num, 2));
			}
			return new MySqlDateTime(this.year, this.month, this.day, this.hour, this.minute, this.second, this.mySqlDbType);
		}

		internal static MySqlDateTime Parse(string s)
		{
			MySqlDateTime mySqlDateTime = new MySqlDateTime(MySqlDbType.Datetime);
			return mySqlDateTime.ParseMySql(s, true);
		}

		internal MySqlDateTime ParseMySql(string s, bool is41)
		{
			if (this.mySqlDbType == MySqlDbType.Timestamp && !is41)
			{
				return this.Parse40Timestamp(s);
			}
			string[] array = s.Split(new char[]
			{
				'-',
				' ',
				':',
				'/'
			});
			int num = int.Parse(array[0]);
			int num2 = int.Parse(array[1]);
			int num3 = int.Parse(array[2]);
			int num4 = 0;
			int num5 = 0;
			int num6 = 0;
			if (array.Length > 3)
			{
				num4 = int.Parse(array[3]);
				num5 = int.Parse(array[4]);
				num6 = int.Parse(array[5]);
			}
			return new MySqlDateTime(num, num2, num3, num4, num5, num6, this.mySqlDbType);
		}

		internal override MySqlValue ReadValue(PacketReader reader, long length)
		{
			if (length >= 0L)
			{
				string s = reader.ReadString(length);
				return this.ParseMySql(s, reader.Version.isAtLeast(4, 1, 0));
			}
			long num = (long)reader.ReadByte();
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			int num6 = 0;
			int num7 = 0;
			if (num >= 4L)
			{
				num2 = reader.ReadInteger(2);
				num3 = reader.ReadByte();
				num4 = reader.ReadByte();
			}
			if (num > 4L)
			{
				num5 = reader.ReadByte();
				num6 = reader.ReadByte();
				num7 = reader.ReadByte();
			}
			if (num > 7L)
			{
				reader.ReadInteger(4);
			}
			return new MySqlDateTime(num2, num3, num4, num5, num6, num7, this.mySqlDbType);
		}

		internal override void Skip(PacketReader reader)
		{
			long count = (long)reader.ReadByte();
			reader.Skip(count);
		}

		public override string ToString()
		{
			if (this.IsValidDateTime)
			{
				DateTime dateTime = new DateTime(this.year, this.month, this.day, this.hour, this.minute, this.second);
				if (this.mySqlDbType != MySqlDbType.Date)
				{
					return dateTime.ToString();
				}
				return dateTime.ToString("d");
			}
			else
			{
				if (this.mySqlDbType == MySqlDbType.Date)
				{
					return string.Format(MySqlDateTime.shortPattern, this.year, this.month, this.day);
				}
				if (this.hour >= 12)
				{
					MySqlDateTime.fullPattern = MySqlDateTime.fullPattern.Replace("A", "P");
				}
				return string.Format(MySqlDateTime.fullPattern, new object[]
				{
					this.year,
					this.month,
					this.day,
					this.hour,
					this.minute,
					this.second
				});
			}
		}

		private void ComposePatterns()
		{
			DateTime dateTime = new DateTime(1, 2, 3, 4, 5, 6);
			MySqlDateTime.fullPattern = dateTime.ToString();
			MySqlDateTime.fullPattern = MySqlDateTime.fullPattern.Replace("0001", "{0:0000}");
			if (MySqlDateTime.fullPattern.IndexOf("02") != -1)
			{
				MySqlDateTime.fullPattern = MySqlDateTime.fullPattern.Replace("02", "{1:00}");
			}
			else
			{
				MySqlDateTime.fullPattern = MySqlDateTime.fullPattern.Replace("2", "{1}");
			}
			if (MySqlDateTime.fullPattern.IndexOf("03") != -1)
			{
				MySqlDateTime.fullPattern = MySqlDateTime.fullPattern.Replace("03", "{2:00}");
			}
			else
			{
				MySqlDateTime.fullPattern = MySqlDateTime.fullPattern.Replace("3", "{2}");
			}
			if (MySqlDateTime.fullPattern.IndexOf("04") != -1)
			{
				MySqlDateTime.fullPattern = MySqlDateTime.fullPattern.Replace("04", "{3:00}");
			}
			else
			{
				MySqlDateTime.fullPattern = MySqlDateTime.fullPattern.Replace("4", "{3}");
			}
			if (MySqlDateTime.fullPattern.IndexOf("05") != -1)
			{
				MySqlDateTime.fullPattern = MySqlDateTime.fullPattern.Replace("05", "{4:00}");
			}
			else
			{
				MySqlDateTime.fullPattern = MySqlDateTime.fullPattern.Replace("5", "{4}");
			}
			if (MySqlDateTime.fullPattern.IndexOf("06") != -1)
			{
				MySqlDateTime.fullPattern = MySqlDateTime.fullPattern.Replace("06", "{5:00}");
			}
			else
			{
				MySqlDateTime.fullPattern = MySqlDateTime.fullPattern.Replace("6", "{5}");
			}
			MySqlDateTime.shortPattern = dateTime.ToString("d");
			MySqlDateTime.shortPattern = MySqlDateTime.shortPattern.Replace("0001", "{0:0000}");
			if (MySqlDateTime.shortPattern.IndexOf("02") != -1)
			{
				MySqlDateTime.shortPattern = MySqlDateTime.shortPattern.Replace("02", "{1:00}");
			}
			else
			{
				MySqlDateTime.shortPattern = MySqlDateTime.shortPattern.Replace("2", "{1}");
			}
			if (MySqlDateTime.shortPattern.IndexOf("03") != -1)
			{
				MySqlDateTime.shortPattern = MySqlDateTime.shortPattern.Replace("03", "{2:00}");
				return;
			}
			MySqlDateTime.shortPattern = MySqlDateTime.shortPattern.Replace("3", "{2}");
		}

		public static explicit operator DateTime(MySqlDateTime val)
		{
			if (!val.IsValidDateTime)
			{
				return DateTime.MinValue;
			}
			return val.GetDateTime();
		}

		public static implicit operator MySqlDateTime(DateTime v)
		{
			return new MySqlDateTime(v, MySqlDbType.Datetime);
		}

		ulong IConvertible.ToUInt64(IFormatProvider provider)
		{
			return 0uL;
		}

		sbyte IConvertible.ToSByte(IFormatProvider provider)
		{
			return 0;
		}

		double IConvertible.ToDouble(IFormatProvider provider)
		{
			return 0.0;
		}

		DateTime IConvertible.ToDateTime(IFormatProvider provider)
		{
			return this.GetDateTime();
		}

		float IConvertible.ToSingle(IFormatProvider provider)
		{
			return 0f;
		}

		bool IConvertible.ToBoolean(IFormatProvider provider)
		{
			return false;
		}

		int IConvertible.ToInt32(IFormatProvider provider)
		{
			return 0;
		}

		ushort IConvertible.ToUInt16(IFormatProvider provider)
		{
			return 0;
		}

		short IConvertible.ToInt16(IFormatProvider provider)
		{
			return 0;
		}

		string IConvertible.ToString(IFormatProvider provider)
		{
			return null;
		}

		byte IConvertible.ToByte(IFormatProvider provider)
		{
			return 0;
		}

		char IConvertible.ToChar(IFormatProvider provider)
		{
			return '\0';
		}

		long IConvertible.ToInt64(IFormatProvider provider)
		{
			return 0L;
		}

		TypeCode IConvertible.GetTypeCode()
		{
			return 0;
		}

		decimal IConvertible.ToDecimal(IFormatProvider provider)
		{
			return 0m;
		}

		object IConvertible.ToType(Type conversionType, IFormatProvider provider)
		{
			return null;
		}

		uint IConvertible.ToUInt32(IFormatProvider provider)
		{
			return 0u;
		}

		int IComparable.CompareTo(object obj)
		{
			MySqlDateTime mySqlDateTime = (MySqlDateTime)obj;
			if (this.Year < mySqlDateTime.Year)
			{
				return -1;
			}
			if (this.Year > mySqlDateTime.Year)
			{
				return 1;
			}
			if (this.Month < mySqlDateTime.Month)
			{
				return -1;
			}
			if (this.Month > mySqlDateTime.Month)
			{
				return 1;
			}
			if (this.Day < mySqlDateTime.Day)
			{
				return -1;
			}
			if (this.Day > mySqlDateTime.Day)
			{
				return 1;
			}
			if (this.Hour < mySqlDateTime.Hour)
			{
				return -1;
			}
			if (this.Hour > mySqlDateTime.Hour)
			{
				return 1;
			}
			if (this.Minute < mySqlDateTime.Minute)
			{
				return -1;
			}
			if (this.Minute > mySqlDateTime.Minute)
			{
				return 1;
			}
			if (this.Second < mySqlDateTime.Second)
			{
				return -1;
			}
			if (this.Second > mySqlDateTime.Second)
			{
				return 1;
			}
			return 0;
		}
	}
}
