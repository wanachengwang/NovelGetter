using System;

namespace MySql.Data.MySqlClient
{
	[Flags]
	internal enum ClientFlags
	{
		LONG_PASSWORD = 1,
		FOUND_ROWS = 2,
		LONG_FLAG = 4,
		CONNECT_WITH_DB = 8,
		NO_SCHEMA = 16,
		COMPRESS = 32,
		ODBC = 64,
		LOCAL_FILES = 128,
		IGNORE_SPACE = 256,
		PROTOCOL_41 = 512,
		INTERACTIVE = 1024,
		SSL = 2048,
		IGNORE_SIGPIPE = 4096,
		TRANSACTIONS = 8192,
		RESERVED = 16384,
		SECURE_CONNECTION = 32768,
		MULTI_STATEMENTS = 65536,
		MULTI_RESULTS = 131072
	}
}
