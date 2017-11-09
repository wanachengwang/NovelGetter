using MySql.Data.Common;
using MySql.Data.Types;
using System;
using System.Text;

namespace MySql.Data.MySqlClient
{
	internal class MySqlField
	{
		public string CatalogName;

		public int ColumnLength;

		public string ColumnName;

		public string OriginalColumnName;

		public string TableName;

		public string RealTableName;

		public string DatabaseName;

		public Encoding Encoding;

		public int maxLength;

		protected ColumnFlags colFlags;

		protected int charSetIndex;

		protected byte precision;

		protected byte scale;

		protected MySqlDbType mySqlDbType;

		protected DBVersion connVersion;

		public int CharacterSetIndex
		{
			get
			{
				return this.charSetIndex;
			}
			set
			{
				this.charSetIndex = value;
			}
		}

		public MySqlDbType Type
		{
			get
			{
				return this.mySqlDbType;
			}
			set
			{
				this.mySqlDbType = value;
			}
		}

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

		public int MaxLength
		{
			get
			{
				return this.maxLength;
			}
			set
			{
				this.maxLength = value;
			}
		}

		public ColumnFlags Flags
		{
			get
			{
				return this.colFlags;
			}
			set
			{
				this.colFlags = value;
			}
		}

		public bool IsAutoIncrement
		{
			get
			{
				return (this.colFlags & ColumnFlags.AUTO_INCREMENT) > (ColumnFlags)0;
			}
		}

		public bool IsNumeric
		{
			get
			{
				return (this.colFlags & ColumnFlags.NUMBER) > (ColumnFlags)0;
			}
		}

		public bool AllowsNull
		{
			get
			{
				return (this.colFlags & ColumnFlags.NOT_NULL) == (ColumnFlags)0;
			}
		}

		public bool IsUnique
		{
			get
			{
				return (this.colFlags & ColumnFlags.UNIQUE_KEY) > (ColumnFlags)0;
			}
		}

		public bool IsPrimaryKey
		{
			get
			{
				return (this.colFlags & ColumnFlags.PRIMARY_KEY) > (ColumnFlags)0;
			}
		}

		public bool IsBlob
		{
			get
			{
				return (this.colFlags & ColumnFlags.BLOB) > (ColumnFlags)0;
			}
		}

		public bool IsBinary
		{
			get
			{
				if (this.connVersion.isAtLeast(4, 1, 0))
				{
					return this.CharacterSetIndex == 63;
				}
				return (this.colFlags & ColumnFlags.BINARY) > (ColumnFlags)0;
			}
		}

		public bool IsUnsigned
		{
			get
			{
				return (this.colFlags & ColumnFlags.UNSIGNED) > (ColumnFlags)0;
			}
		}

		public bool IsTextField
		{
			get
			{
				if (this.Type != MySqlDbType.VarString && this.Type != MySqlDbType.VarChar)
				{
					if (this.Type != MySqlDbType.TinyBlob && this.Type != MySqlDbType.MediumBlob && this.Type != MySqlDbType.Blob)
					{
						if (this.Type != MySqlDbType.LongBlob)
						{
							return false;
						}
					}
					return !this.IsBinary;
				}
				return true;
			}
		}

		public MySqlField(DBVersion connVersion)
		{
			this.connVersion = connVersion;
			this.maxLength = 1;
		}

		public void SetTypeAndFlags(MySqlDbType type, ColumnFlags flags)
		{
			this.colFlags = flags;
			this.mySqlDbType = type;
			if (this.IsUnsigned)
			{
				switch (type)
				{
				case MySqlDbType.Byte:
					this.mySqlDbType = MySqlDbType.UByte;
					break;
				case MySqlDbType.Int16:
					this.mySqlDbType = MySqlDbType.UInt16;
					break;
				case MySqlDbType.Int32:
					this.mySqlDbType = MySqlDbType.UInt32;
					break;
				case MySqlDbType.Int64:
					this.mySqlDbType = MySqlDbType.UInt64;
					break;
				case MySqlDbType.Int24:
					this.mySqlDbType = MySqlDbType.UInt24;
					break;
				}
			}
			if (this.IsBlob && !this.IsBinary)
			{
				if (type == MySqlDbType.TinyBlob)
				{
					this.mySqlDbType = MySqlDbType.TinyText;
					return;
				}
				if (type == MySqlDbType.MediumBlob)
				{
					this.mySqlDbType = MySqlDbType.MediumText;
					return;
				}
				if (type == MySqlDbType.Blob)
				{
					this.mySqlDbType = MySqlDbType.Text;
					return;
				}
				if (type == MySqlDbType.LongBlob)
				{
					this.mySqlDbType = MySqlDbType.LongText;
				}
			}
		}

		public MySqlDbType ProviderType()
		{
			if (this.IsUnsigned)
			{
				switch (this.Type)
				{
				case MySqlDbType.Byte:
					return MySqlDbType.UByte;
				case MySqlDbType.Int16:
					return MySqlDbType.UInt16;
				case MySqlDbType.Int32:
					return MySqlDbType.UInt32;
				case MySqlDbType.Int64:
					return MySqlDbType.UInt64;
				case MySqlDbType.Int24:
					return MySqlDbType.UInt24;
				}
			}
			return this.Type;
		}

		public MySqlValue GetValueObject()
		{
			return MySqlValue.GetMySqlValue(this.ProviderType());
		}
	}
}
