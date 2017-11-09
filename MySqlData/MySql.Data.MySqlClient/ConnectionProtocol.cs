using System;

namespace MySql.Data.MySqlClient
{
	internal enum ConnectionProtocol
	{
		Sockets,
		NamedPipe,
		UnixSocket,
		SharedMemory
	}
}
