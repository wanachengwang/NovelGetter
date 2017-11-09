using System;
using System.Data;
using System.Data.Common;

namespace MySql.Data.MySqlClient
{
	public sealed class MySqlRowUpdatingEventArgs : RowUpdatingEventArgs
	{
		public MySqlCommand Command
		{
			get
			{
				return (MySqlCommand)base.get_Command();
			}
			set
			{
				base.set_Command(value);
			}
		}

		public MySqlRowUpdatingEventArgs(DataRow row, IDbCommand command, StatementType statementType, DataTableMapping tableMapping) : base(row, command, statementType, tableMapping)
		{
		}
	}
}
