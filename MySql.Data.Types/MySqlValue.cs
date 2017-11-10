using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Globalization;

namespace MySql.Data.Types
{
	public abstract class MySqlValue
	{
		protected static NumberFormatInfo numberFormat = null;

		protected object objectValue;

		protected DbType dbType;

		protected MySqlDbType mySqlDbType;

		protected string mySqlTypeName;

		protected Type classType;

		protected bool isNull;

		public object ValueAsObject
		{
			get
			{
				return this.objectValue;
			}
		}

		internal abstract Type SystemType
		{
			get;
		}

		public bool IsNull
		{
			get
			{
				return this.isNull;
			}
			set
			{
				this.isNull = value;
				if (this.isNull)
				{
					this.objectValue = null;
				}
			}
		}

		internal virtual DbType DbType
		{
			get
			{
				return this.dbType;
			}
		}

		internal MySqlDbType MySqlDbType
		{
			get
			{
				return this.mySqlDbType;
			}
		}

		public MySqlValue()
		{
			this.isNull = false;
			if (MySqlValue.numberFormat == null)
			{
				MySqlValue.numberFormat = (NumberFormatInfo)NumberFormatInfo.InvariantInfo.Clone();
				MySqlValue.numberFormat.NumberDecimalSeparator = (".");
			}
		}

		internal abstract void Serialize(PacketWriter writer, bool binary, object value, int length);

		internal abstract string GetMySqlTypeName();

		internal abstract MySqlValue ReadValue(PacketReader reader, long length);

		internal abstract void Skip(PacketReader reader);

		public override string ToString()
		{
			return this.ValueAsObject.ToString();
		}

		internal static MySqlValue GetMySqlValue(MySqlDbType type)
		{
			if (type <= MySqlDbType.Char)
			{
				switch (type)
				{
				case MySqlDbType.Decimal:
					break;
				case MySqlDbType.Byte:
					return new MySqlByte();
				case MySqlDbType.Int16:
					return new MySqlInt16();
				case MySqlDbType.Int32:
				case MySqlDbType.Int24:
				case MySqlDbType.Year:
					return new MySqlInt32(type);
				case MySqlDbType.Float:
					return new MySqlFloat();
				case MySqlDbType.Double:
					return new MySqlDouble();
				case (MySqlDbType)6:
				case MySqlDbType.VarString:
					goto IL_12C;
				case MySqlDbType.Timestamp:
				case MySqlDbType.Date:
				case MySqlDbType.Datetime:
				case MySqlDbType.Newdate:
					return new MySqlDateTime(type);
				case MySqlDbType.Int64:
					return new MySqlInt64();
				case MySqlDbType.Time:
					return new MySqlTimeSpan();
				case MySqlDbType.Bit:
					return new MySqlBit();
				default:
					switch (type)
					{
					case MySqlDbType.NewDecimal:
						break;
					case MySqlDbType.Enum:
					case MySqlDbType.Set:
					case MySqlDbType.VarChar:
					case MySqlDbType.Char:
						goto IL_12C;
					case MySqlDbType.TinyBlob:
					case MySqlDbType.MediumBlob:
					case MySqlDbType.LongBlob:
					case MySqlDbType.Blob:
						goto IL_134;
					default:
						goto IL_148;
					}
					break;
				}
				return new MySqlDecimal();
			}
			switch (type)
			{
			case MySqlDbType.UByte:
				return new MySqlUByte();
			case MySqlDbType.UInt16:
				return new MySqlUInt16();
			case MySqlDbType.UInt32:
			case MySqlDbType.UInt24:
				return new MySqlUInt32(type);
			case (MySqlDbType)504:
			case (MySqlDbType)505:
			case (MySqlDbType)506:
			case (MySqlDbType)507:
				goto IL_148;
			case MySqlDbType.UInt64:
				return new MySqlUInt64();
			default:
				switch (type)
				{
				case MySqlDbType.Binary:
				case MySqlDbType.VarBinary:
					goto IL_134;
				default:
					switch (type)
					{
					case MySqlDbType.TinyText:
					case MySqlDbType.MediumText:
					case MySqlDbType.LongText:
					case MySqlDbType.Text:
						break;
					default:
						goto IL_148;
					}
					break;
				}
				break;
			}
			IL_12C:
			return new MySqlString(null, type);
			IL_134:
			return new MySqlBinary(null, type);
			IL_148:
			throw new MySqlException("Unknown data type");
		}
	}
}
