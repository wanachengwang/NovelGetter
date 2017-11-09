using System;

namespace MySql.Data.MySqlClient
{
	public enum MySqlDbType
	{
		Decimal,
		Byte,
		Int16,
		Int24 = 9,
		Int32 = 3,
		Int64 = 8,
		Float = 4,
		Double,
		Timestamp = 7,
		Date = 10,
		Time,
		Datetime,
		Year,
		Newdate,
		VarString,
		Bit,
		NewDecimal = 246,
		Enum,
		Set,
		TinyBlob,
		MediumBlob,
		LongBlob,
		Blob,
		VarChar,
		Char,
		String = 254,
		Geometry,
		UByte = 501,
		UInt16,
		UInt24 = 509,
		UInt32 = 503,
		UInt64 = 508,
		Binary = 600,
		VarBinary,
		TinyText = 749,
		MediumText,
		LongText,
		Text
	}
}
