using System;
using System.Data;

namespace MySql.Data.MySqlClient
{
	public sealed class MySqlTransaction : IDisposable, IDbTransaction
	{
		private IsolationLevel level;

		private MySqlConnection conn;

		private bool open;

		IDbConnection IDbTransaction.Connection
		{
			get
			{
				return this.Connection;
			}
		}

		public MySqlConnection Connection
		{
			get
			{
				return this.conn;
			}
		}

		public IsolationLevel IsolationLevel
		{
			get
			{
				return this.level;
			}
		}

		internal MySqlTransaction(MySqlConnection c, IsolationLevel il)
		{
			this.conn = c;
			this.level = il;
			this.open = true;
		}

		void IDisposable.Dispose()
		{
		}

		public void Commit()
		{
			if (this.conn != null)
			{
				if (this.conn.State == (ConnectionState)1)
				{
					if (!this.open)
					{
						throw new InvalidOperationException("Transaction has already been committed or is not pending");
					}
					try
					{
						MySqlCommand mySqlCommand = new MySqlCommand("COMMIT", this.conn);
						mySqlCommand.ExecuteNonQuery();
						this.open = false;
						return;
					}
					catch (MySqlException)
					{
						throw;
					}
				}
			}
			throw new InvalidOperationException("Connection must be valid and open to commit transaction");
		}

		public void Rollback()
		{
			if (this.conn != null)
			{
				if (this.conn.State == (ConnectionState)1)
				{
					if (!this.open)
					{
						throw new InvalidOperationException("Transaction has already been rolled back or is not pending");
					}
					try
					{
						MySqlCommand mySqlCommand = new MySqlCommand("ROLLBACK", this.conn);
						mySqlCommand.ExecuteNonQuery();
						this.open = false;
						return;
					}
					catch (MySqlException)
					{
						throw;
					}
				}
			}
			throw new InvalidOperationException("Connection must be valid and open to commit transaction");
		}
	}
}
