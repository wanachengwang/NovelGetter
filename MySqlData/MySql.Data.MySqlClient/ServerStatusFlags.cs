using System;

namespace MySql.Data.MySqlClient
{
	[Flags]
	internal enum ServerStatusFlags
	{
		InTransaction = 1,
		AutoCommitMode = 2,
		MoreResults = 4,
		AnotherQuery = 8,
		BadIndex = 16,
		NoIndex = 32
	}
}
