using System;

namespace MySql.Data.MySqlClient
{
	public enum MySqlErrorCode
	{
		DuplicateKey = 1022,
		KeyNotFound = 1032,
		UnableToConnectToHost = 1042,
		DuplicateKeyName = 1061,
		DuplicateKeyEntry,
		HostNotPrivileged = 1130,
		AnonymousUser,
		PasswordNotAllowed,
		PasswordNoMatch,
		PacketTooLarge = 1153
	}
}
