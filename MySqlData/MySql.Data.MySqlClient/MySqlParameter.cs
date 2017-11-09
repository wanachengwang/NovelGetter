using MySql.Data.Types;
using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Globalization;
using System.Reflection;

namespace MySql.Data.MySqlClient
{
	[TypeConverter(typeof(MySqlParameter.MySqlParameterConverter))]
	public sealed class MySqlParameter : MarshalByRefObject, ICloneable, IDbDataParameter, IDataParameter
	{
		internal class MySqlParameterConverter : TypeConverter
		{
			public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
			{
				return destinationType == typeof(InstanceDescriptor) || base.CanConvertTo(context, destinationType);
			}

			public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
			{
				if (destinationType == typeof(InstanceDescriptor))
				{
					ConstructorInfo constructor = typeof(MySqlParameter).GetConstructor(new Type[]
					{
						typeof(string),
						typeof(MySqlDbType),
						typeof(int),
						typeof(ParameterDirection),
						typeof(bool),
						typeof(byte),
						typeof(byte),
						typeof(string),
						typeof(DataRowVersion),
						typeof(object)
					});
					MySqlParameter mySqlParameter = (MySqlParameter)value;
					return new InstanceDescriptor(constructor, new object[]
					{
						mySqlParameter.ParameterName,
						mySqlParameter.DbType,
						mySqlParameter.Size,
						mySqlParameter.Direction,
						mySqlParameter.IsNullable,
						mySqlParameter.Precision,
						mySqlParameter.Scale,
						mySqlParameter.SourceColumn,
						mySqlParameter.SourceVersion,
						mySqlParameter.Value
					});
				}
				return base.ConvertTo(context, culture, value, destinationType);
			}
		}

		private const int UNSIGNED_MASK = 32768;

		private object paramValue;

		private MySqlValue valueObject;

		private ParameterDirection direction = 1;

		private bool isNullable = false;

		private string paramName;

		private string sourceColumn;

		private DataRowVersion sourceVersion = 512;

		private int size;

		private byte precision;

		private byte scale;

		private MySqlDbType mySqlDbType;

		private DbType dbType;

		private bool inferType;

		private MySqlParameterCollection collection;

		internal MySqlParameterCollection Collection
		{
			get
			{
				return this.collection;
			}
			set
			{
				this.collection = value;
			}
		}

		internal bool TypeHasBeenSet
		{
			get
			{
				return !this.inferType;
			}
		}

		public DbType DbType
		{
			get
			{
				return this.dbType;
			}
			set
			{
				this.SetDbType(value);
				this.inferType = false;
			}
		}

		[Category("Data")]
		public ParameterDirection Direction
		{
			get
			{
				return this.direction;
			}
			set
			{
				this.direction = value;
			}
		}

		[Browsable(false)]
		public bool IsNullable
		{
			get
			{
				return this.isNullable;
			}
			set
			{
				this.isNullable = value;
			}
		}

		[Category("Data")]
		public MySqlDbType MySqlDbType
		{
			get
			{
				return this.mySqlDbType;
			}
			set
			{
				this.SetMySqlDbType(value);
				this.inferType = false;
			}
		}

		[Category("Misc")]
		public string ParameterName
		{
			get
			{
				return this.paramName;
			}
			set
			{
				if (this.collection != null)
				{
					this.collection.ParameterNameChanged(this, this.paramName, value);
				}
				this.paramName = value;
			}
		}

		[Category("Data")]
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

		[Category("Data")]
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

		[Category("Data")]
		public int Size
		{
			get
			{
				return this.size;
			}
			set
			{
				this.size = value;
			}
		}

		[Category("Data")]
		public string SourceColumn
		{
			get
			{
				return this.sourceColumn;
			}
			set
			{
				this.sourceColumn = value;
			}
		}

		[Category("Data")]
		public DataRowVersion SourceVersion
		{
			get
			{
				return this.sourceVersion;
			}
			set
			{
				this.sourceVersion = value;
			}
		}

		[Category("Data"), TypeConverter(typeof(StringConverter))]
		public object Value
		{
			get
			{
				return this.paramValue;
			}
			set
			{
				this.paramValue = value;
				if (value is byte[])
				{
					this.size = (value as byte[]).Length;
				}
				else if (value is string)
				{
					this.size = (value as string).Length;
				}
				if (this.inferType)
				{
					this.SetTypeFromValue();
				}
			}
		}

		public MySqlParameter()
		{
			this.inferType = true;
		}

		public MySqlParameter(string parameterName, object value) : this()
		{
			this.ParameterName = parameterName;
			this.Value = value;
		}

		public MySqlParameter(string parameterName, MySqlDbType dbType) : this(parameterName, null)
		{
			this.MySqlDbType = dbType;
		}

		public MySqlParameter(string parameterName, MySqlDbType dbType, int size) : this(parameterName, dbType)
		{
			this.size = size;
		}

		public MySqlParameter(string parameterName, MySqlDbType dbType, int size, string sourceColumn) : this(parameterName, dbType)
		{
			this.size = size;
			this.direction = 1;
			this.sourceColumn = sourceColumn;
			this.sourceVersion = 512;
		}

		internal MySqlParameter(string name, MySqlDbType type, ParameterDirection dir, string col, DataRowVersion ver, object val) : this(name, type)
		{
			if (this.direction != 1)
			{
				throw new ArgumentException("Only input parameters are supported by MySql");
			}
			this.direction = dir;
			this.sourceColumn = col;
			this.sourceVersion = ver;
			this.Value = val;
		}

		public MySqlParameter(string parameterName, MySqlDbType dbType, int size, ParameterDirection direction, bool isNullable, byte precision, byte scale, string sourceColumn, DataRowVersion sourceVersion, object value) : this(parameterName, dbType, size, sourceColumn)
		{
			if (direction != 1)
			{
				throw new ArgumentException("Only input parameters are supported by MySql");
			}
			this.direction = direction;
			this.sourceVersion = sourceVersion;
			this.Value = value;
		}

		public override string ToString()
		{
			return this.paramName;
		}

		internal MySqlValue GetValueObject()
		{
			if (this.valueObject == null)
			{
				this.valueObject = MySqlValue.GetMySqlValue(this.mySqlDbType);
				MySqlDecimal mySqlDecimal = this.valueObject as MySqlDecimal;
				if (mySqlDecimal != null)
				{
					mySqlDecimal.Precision = this.precision;
					mySqlDecimal.Scale = this.scale;
				}
			}
			return this.valueObject;
		}

		internal int GetPSType()
		{
			MySqlDbType mySqlDbType = this.mySqlDbType;
			if (mySqlDbType != MySqlDbType.Bit)
			{
				switch (mySqlDbType)
				{
				case MySqlDbType.UByte:
					return 32769;
				case MySqlDbType.UInt16:
					return 32770;
				case MySqlDbType.UInt32:
					return 32771;
				case MySqlDbType.UInt64:
					return 32776;
				case MySqlDbType.UInt24:
					return 32771;
				}
				return (int)this.mySqlDbType;
			}
			return 32776;
		}

		internal void Serialize(PacketWriter writer, bool binary)
		{
			this.GetValueObject();
			if (!binary && (this.paramValue == null || this.paramValue == DBNull.Value))
			{
				writer.WriteStringNoNull("NULL");
				return;
			}
			this.valueObject.Serialize(writer, binary, this.paramValue, this.size);
		}

		private void SetMySqlDbType(MySqlDbType mySqlDbType)
		{
			if (this.mySqlDbType != mySqlDbType)
			{
				this.valueObject = null;
			}
			this.mySqlDbType = mySqlDbType;
			switch (mySqlDbType)
			{
			case MySqlDbType.Decimal:
				this.dbType = 7;
				return;
			case MySqlDbType.Byte:
				this.dbType = 14;
				return;
			case MySqlDbType.Int16:
				this.dbType = 10;
				return;
			case MySqlDbType.Int32:
			case MySqlDbType.Int24:
				this.dbType = 11;
				return;
			case MySqlDbType.Float:
				this.dbType = 15;
				return;
			case MySqlDbType.Double:
				this.dbType = 8;
				return;
			case (MySqlDbType)6:
			case MySqlDbType.VarString:
				break;
			case MySqlDbType.Timestamp:
			case MySqlDbType.Datetime:
				this.dbType = 6;
				return;
			case MySqlDbType.Int64:
				this.dbType = 12;
				return;
			case MySqlDbType.Date:
			case MySqlDbType.Year:
			case MySqlDbType.Newdate:
				this.dbType = 5;
				return;
			case MySqlDbType.Time:
				this.dbType = 17;
				return;
			case MySqlDbType.Bit:
				this.dbType = 20;
				return;
			default:
				switch (mySqlDbType)
				{
				case MySqlDbType.Enum:
				case MySqlDbType.Set:
				case MySqlDbType.VarChar:
					this.dbType = 16;
					return;
				case MySqlDbType.TinyBlob:
				case MySqlDbType.MediumBlob:
				case MySqlDbType.LongBlob:
				case MySqlDbType.Blob:
					this.dbType = 13;
					return;
				case MySqlDbType.Char:
					this.dbType = 23;
					break;
				default:
					switch (mySqlDbType)
					{
					case MySqlDbType.UByte:
						this.dbType = 2;
						return;
					case MySqlDbType.UInt16:
						this.dbType = 18;
						return;
					case MySqlDbType.UInt32:
					case MySqlDbType.UInt24:
						this.dbType = 19;
						return;
					case (MySqlDbType)504:
					case (MySqlDbType)505:
					case (MySqlDbType)506:
					case (MySqlDbType)507:
						break;
					case MySqlDbType.UInt64:
						this.dbType = 20;
						return;
					default:
						return;
					}
					break;
				}
				break;
			}
		}

		private void SetDbType(DbType dbType)
		{
			if (this.dbType != dbType)
			{
				this.valueObject = null;
			}
			this.dbType = dbType;
			switch (dbType)
			{
			case 0:
			case 9:
			case 16:
				this.mySqlDbType = MySqlDbType.VarChar;
				return;
			case 2:
			case 3:
			case 14:
				this.mySqlDbType = ((dbType == 2) ? MySqlDbType.UByte : MySqlDbType.Byte);
				return;
			case 4:
			case 7:
				this.mySqlDbType = MySqlDbType.Decimal;
				return;
			case 5:
				this.mySqlDbType = MySqlDbType.Date;
				return;
			case 6:
				this.mySqlDbType = MySqlDbType.Datetime;
				return;
			case 8:
				this.mySqlDbType = MySqlDbType.Double;
				return;
			case 10:
				this.mySqlDbType = MySqlDbType.Int16;
				return;
			case 11:
				this.mySqlDbType = MySqlDbType.Int32;
				return;
			case 12:
				this.mySqlDbType = MySqlDbType.Int64;
				return;
			case 15:
				this.mySqlDbType = MySqlDbType.Float;
				return;
			case 17:
				this.mySqlDbType = MySqlDbType.Time;
				return;
			case 18:
				this.mySqlDbType = MySqlDbType.UInt16;
				return;
			case 19:
				this.mySqlDbType = MySqlDbType.UInt32;
				return;
			case 20:
				this.mySqlDbType = MySqlDbType.UInt64;
				return;
			case 22:
			case 23:
				this.mySqlDbType = MySqlDbType.Char;
				return;
			}
			this.mySqlDbType = MySqlDbType.Blob;
		}

		private void SetTypeFromValue()
		{
			if (this.paramValue != null)
			{
				if (this.paramValue != DBNull.Value)
				{
					if (this.paramValue is Guid)
					{
						this.DbType = 16;
					}
					else if (this.paramValue is TimeSpan)
					{
						this.DbType = 17;
					}
					else if (this.paramValue is bool)
					{
						this.DbType = 2;
					}
					else
					{
						switch (Type.GetTypeCode(this.paramValue.GetType()))
						{
						case 5:
							this.DbType = 14;
							goto IL_155;
						case 6:
							this.DbType = 2;
							goto IL_155;
						case 7:
							this.DbType = 10;
							goto IL_155;
						case 8:
							this.DbType = 18;
							goto IL_155;
						case 9:
							this.DbType = 11;
							goto IL_155;
						case 10:
							this.DbType = 19;
							goto IL_155;
						case 11:
							this.DbType = 12;
							goto IL_155;
						case 12:
							this.DbType = 20;
							goto IL_155;
						case 13:
							this.DbType = 15;
							goto IL_155;
						case 14:
							this.DbType = 8;
							goto IL_155;
						case 15:
							this.DbType = 7;
							goto IL_155;
						case 16:
							this.DbType = 6;
							goto IL_155;
						case 18:
							this.DbType = 16;
							goto IL_155;
						}
						this.DbType = 13;
					}
					IL_155:
					this.valueObject = null;
					return;
				}
			}
		}

		object ICloneable.Clone()
		{
			return new MySqlParameter(this.paramName, this.mySqlDbType, this.direction, this.sourceColumn, this.sourceVersion, this.paramValue);
		}
	}
}
