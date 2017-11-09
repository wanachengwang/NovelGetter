using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Text;

namespace MySql.Data.MySqlClient
{
	[DesignerCategory("Code")]
	public sealed class MySqlCommand : Component, IDbCommand, IDisposable, ICloneable
	{
		private MySqlConnection connection;

		private MySqlTransaction curTransaction;

		private string cmdText;

		private CommandType cmdType;

		private long updateCount;

		private UpdateRowSource updatedRowSource;

		private MySqlParameterCollection parameters;

		private ArrayList sqlBuffers;

		private PreparedStatement preparedStatement;

		private ArrayList parameterMap;

		private StoredProcedure storedProcedure;

		private CommandResult lastResult;

		[Category("Data"), Description("Command text to execute")]
		public string CommandText
		{
			get
			{
				return this.cmdText;
			}
			set
			{
				this.cmdText = value;
				this.preparedStatement = null;
			}
		}

		internal int UpdateCount
		{
			get
			{
				return (int)this.updateCount;
			}
		}

		[Category("Misc"), Description("Time to wait for command to execute")]
		public int CommandTimeout
		{
			get
			{
				return 0;
			}
			set
			{
				if (value != 0)
				{
					throw new NotSupportedException();
				}
			}
		}

		[Category("Data")]
		public CommandType CommandType
		{
			get
			{
				return this.cmdType;
			}
			set
			{
				this.cmdType = value;
			}
		}

		[Browsable(false)]
		public bool IsPrepared
		{
			get
			{
				return this.preparedStatement != null;
			}
		}

		IDbConnection IDbCommand.Connection
		{
			get
			{
				return this.connection;
			}
			set
			{
				this.Connection = (MySqlConnection)value;
			}
		}

		[Category("Behavior"), Description("Connection used by the command")]
		public MySqlConnection Connection
		{
			get
			{
				return this.connection;
			}
			set
			{
				if (this.connection != value)
				{
					this.Transaction = null;
				}
				this.connection = value;
				if (this.connection != null)
				{
					this.parameters.ParameterMarker = this.connection.ParameterMarker;
				}
			}
		}

		[Category("Data"), Description("The parameters collection"), DesignerSerializationVisibility]
		public MySqlParameterCollection Parameters
		{
			get
			{
				return this.parameters;
			}
		}

		IDataParameterCollection IDbCommand.Parameters
		{
			get
			{
				return this.parameters;
			}
		}

		IDbTransaction IDbCommand.Transaction
		{
			get
			{
				return this.Transaction;
			}
			set
			{
				this.Transaction = (MySqlTransaction)value;
			}
		}

		[Browsable(false)]
		public MySqlTransaction Transaction
		{
			get
			{
				return this.curTransaction;
			}
			set
			{
				this.curTransaction = value;
			}
		}

		[Category("Behavior")]
		public UpdateRowSource UpdatedRowSource
		{
			get
			{
				return this.updatedRowSource;
			}
			set
			{
				this.updatedRowSource = value;
			}
		}

		public MySqlCommand()
		{
			this.cmdType = 1;
			this.parameterMap = new ArrayList();
			this.parameters = new MySqlParameterCollection();
			this.updatedRowSource = 3;
		}

		public MySqlCommand(string cmdText) : this()
		{
			this.CommandText = cmdText;
		}

		public MySqlCommand(string cmdText, MySqlConnection connection) : this(cmdText)
		{
			this.Connection = connection;
			if (connection != null)
			{
				this.parameters.ParameterMarker = connection.ParameterMarker;
			}
		}

		public MySqlCommand(string cmdText, MySqlConnection connection, MySqlTransaction transaction) : this(cmdText, connection)
		{
			this.curTransaction = transaction;
		}

		public void Cancel()
		{
			throw new NotSupportedException();
		}

		public MySqlParameter CreateParameter()
		{
			return new MySqlParameter();
		}

		IDbDataParameter IDbCommand.CreateParameter()
		{
			return this.CreateParameter();
		}

		internal void Consume()
		{
			for (CommandResult nextResultSet = this.GetNextResultSet(null); nextResultSet != null; nextResultSet = this.GetNextResultSet(null))
			{
				nextResultSet.Consume();
			}
			if (this.storedProcedure != null)
			{
				this.storedProcedure.UpdateParameters(this.Parameters);
			}
		}

		internal CommandResult GetNextResultSet(MySqlDataReader reader)
		{
			if (reader != null && (reader.Behavior & 1) != null && this.lastResult != null)
			{
				return null;
			}
			if (this.lastResult != null && this.lastResult.ReadNextResult(false))
			{
				return this.lastResult;
			}
			this.lastResult = null;
			CommandResult commandResult = null;
			if (this.preparedStatement == null)
			{
				if (this.sqlBuffers == null || this.sqlBuffers.get_Count() == 0)
				{
					return null;
				}
			}
			else if (this.preparedStatement.ExecutionCount > 0)
			{
				return null;
			}
			if (this.preparedStatement != null)
			{
				commandResult = this.preparedStatement.Execute(this.parameters);
				if (!commandResult.IsResultSet)
				{
					if (this.updateCount == -1L)
					{
						this.updateCount = 0L;
					}
					this.updateCount += commandResult.AffectedRows;
				}
			}
			else
			{
				while (this.sqlBuffers.get_Count() > 0)
				{
					MemoryStream memoryStream = (MemoryStream)this.sqlBuffers[0];
					using (memoryStream)
					{
						commandResult = this.connection.driver.SendQuery(memoryStream.GetBuffer(), (int)memoryStream.Length, false);
						this.sqlBuffers.RemoveAt(0);
					}
					if (commandResult.AffectedRows != -1L)
					{
						if (this.updateCount == -1L)
						{
							this.updateCount = 0L;
						}
						this.updateCount += commandResult.AffectedRows;
					}
					if (commandResult.IsResultSet)
					{
						break;
					}
				}
			}
			if (commandResult.IsResultSet)
			{
				this.lastResult = commandResult;
				return commandResult;
			}
			return null;
		}

		private void CheckState()
		{
			if (this.connection != null)
			{
				if (this.connection.State == 1)
				{
					if (this.connection.Reader != null)
					{
						throw new MySqlException(Resources.DataReaderOpen);
					}
					if (this.CommandType == 4 && !this.connection.driver.Version.isAtLeast(5, 0, 0))
					{
						throw new MySqlException(Resources.SPNotSupported);
					}
					return;
				}
			}
			throw new InvalidOperationException(Resources.ConnectionMustBeOpen);
		}

		public int ExecuteNonQuery()
		{
			this.lastResult = null;
			this.CheckState();
			if (this.cmdText != null && this.cmdText.Trim().Length != 0)
			{
				this.updateCount = 0L;
				if (this.preparedStatement == null)
				{
					this.sqlBuffers = this.PrepareSqlBuffers(this.CommandText);
				}
				else
				{
					this.preparedStatement.ExecutionCount = 0;
				}
				try
				{
					this.Consume();
					goto IL_95;
				}
				catch (MySqlException ex)
				{
					if (ex.IsFatal)
					{
						this.connection.Terminate();
					}
					throw;
				}
				catch (Exception)
				{
					this.connection.Terminate();
					throw;
				}
				goto IL_8A;
				IL_95:
				return (int)this.updateCount;
			}
			IL_8A:
			throw new InvalidOperationException(Resources.CommandTextNotInitialized);
		}

		IDataReader IDbCommand.ExecuteReader()
		{
			return this.ExecuteReader();
		}

		IDataReader IDbCommand.ExecuteReader(CommandBehavior behavior)
		{
			return this.ExecuteReader(behavior);
		}

		public MySqlDataReader ExecuteReader()
		{
			return this.ExecuteReader(0);
		}

		public MySqlDataReader ExecuteReader(CommandBehavior behavior)
		{
			this.lastResult = null;
			this.CheckState();
			if (this.cmdText != null && this.cmdText.Trim().Length != 0)
			{
				string sql = this.TrimSemicolons(this.cmdText);
				this.updateCount = -1L;
				MySqlDataReader mySqlDataReader = new MySqlDataReader(this, behavior);
				if (this.preparedStatement == null)
				{
					this.sqlBuffers = this.PrepareSqlBuffers(sql);
				}
				else
				{
					this.preparedStatement.ExecutionCount = 0;
				}
				this.HandleCommandBehaviors(behavior);
				mySqlDataReader.NextResult();
				this.connection.Reader = mySqlDataReader;
				return mySqlDataReader;
			}
			throw new InvalidOperationException(Resources.CommandTextNotInitialized);
		}

		public object ExecuteScalar()
		{
			this.lastResult = null;
			if (this.cmdText != null && this.cmdText.Trim().Length != 0)
			{
				this.updateCount = -1L;
				object result = null;
				MySqlDataReader mySqlDataReader = null;
				try
				{
					try
					{
						mySqlDataReader = this.ExecuteReader();
						if (mySqlDataReader.Read())
						{
							result = mySqlDataReader.GetValue(0);
						}
					}
					catch (Exception)
					{
						throw;
					}
					return result;
				}
				finally
				{
					if (mySqlDataReader != null)
					{
						mySqlDataReader.Close();
					}
				}
			}
			throw new InvalidOperationException(Resources.CommandTextNotInitialized);
		}

		public void Prepare()
		{
			if (this.connection == null)
			{
				throw new InvalidOperationException(Resources.ConnectionNotSet);
			}
			if (this.connection.State != 1)
			{
				throw new InvalidOperationException(Resources.ConnectionNotOpen);
			}
			if (!this.connection.driver.Version.isAtLeast(4, 1, 0) || this.connection.Settings.IgnorePrepare)
			{
				return;
			}
			string text = this.CommandText;
			if (text != null && text.Trim().Length != 0)
			{
				if (this.CommandType == 4)
				{
					if (this.storedProcedure == null)
					{
						this.storedProcedure = new StoredProcedure(this.connection);
					}
					text = this.storedProcedure.Prepare(this);
				}
				text = this.PrepareCommandText(text);
				this.preparedStatement = this.connection.driver.Prepare(text, (string[])this.parameterMap.ToArray(typeof(string)));
				return;
			}
		}

		private void HandleCommandBehaviors(CommandBehavior behavior)
		{
			MySqlCommand mySqlCommand = new MySqlCommand("", this.connection);
			int num;
			if ((behavior & 2) != null)
			{
				num = 0;
			}
			else if ((behavior & 8) != null)
			{
				num = 1;
			}
			else
			{
				if (this.connection.driver.selectLimit == -1)
				{
					return;
				}
				num = -1;
			}
			try
			{
				mySqlCommand.CommandText = string.Format("SET SQL_SELECT_LIMIT={0}", num);
				mySqlCommand.ExecuteNonQuery();
				this.connection.driver.selectLimit = num;
			}
			catch (Exception)
			{
				throw;
			}
		}

		private string TrimSemicolons(string sql)
		{
			StringBuilder stringBuilder = new StringBuilder(sql);
			int num = 0;
			while (stringBuilder[num] == ';')
			{
				num++;
			}
			int num2 = stringBuilder.Length - 1;
			while (stringBuilder[num2] == ';')
			{
				num2--;
			}
			return stringBuilder.ToString(num, num2 - num + 1);
		}

		private MySqlParameter GetParameter(MySqlParameterCollection parameters, string name)
		{
			int num = parameters.IndexOf(name);
			if (num == -1)
			{
				name = name.Substring(1);
				num = this.Parameters.IndexOf(name);
				if (num == -1)
				{
					return null;
				}
			}
			return parameters[num];
		}

		private bool SerializeParameter(PacketWriter writer, string parmName)
		{
			MySqlParameter parameter = this.GetParameter(this.parameters, parmName);
			if (parameter != null)
			{
				parameter.Serialize(writer, false);
				return true;
			}
			if (this.Connection.Settings.UseOldSyntax)
			{
				return false;
			}
			throw new MySqlException(string.Format(Resources.ParameterMustBeDefined, new object[0]));
		}

		private ArrayList PrepareSqlBuffers(string sql)
		{
			ArrayList arrayList = new ArrayList();
			PacketWriter packetWriter = new PacketWriter();
			packetWriter.Encoding = this.connection.Encoding;
			packetWriter.Version = this.connection.driver.Version;
			if (this.CommandType == 4)
			{
				if (this.storedProcedure == null)
				{
					this.storedProcedure = new StoredProcedure(this.connection);
				}
				sql = this.storedProcedure.Prepare(this);
			}
			sql = sql.TrimStart(new char[]
			{
				';'
			}).TrimEnd(new char[]
			{
				';'
			});
			ArrayList arrayList2 = this.TokenizeSql(sql);
			using (IEnumerator enumerator = arrayList2.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					string text = (string)enumerator.get_Current();
					if (text.Trim().Length != 0)
					{
						if (text == ";" && !this.connection.driver.SupportsBatch)
						{
							MemoryStream memoryStream = (MemoryStream)packetWriter.Stream;
							if (memoryStream.Length > 0L)
							{
								arrayList.Add(memoryStream);
							}
							packetWriter = new PacketWriter();
							packetWriter.Encoding = this.connection.Encoding;
							packetWriter.Version = this.connection.driver.Version;
						}
						else if (text[0] != this.parameters.ParameterMarker || !this.SerializeParameter(packetWriter, text))
						{
							packetWriter.WriteStringNoNull(text);
						}
					}
				}
			}
			MemoryStream memoryStream2 = (MemoryStream)packetWriter.Stream;
			if (memoryStream2.Length > 0L)
			{
				arrayList.Add(memoryStream2);
			}
			return arrayList;
		}

		private string PrepareCommandText(string text)
		{
			StringBuilder stringBuilder = new StringBuilder();
			ArrayList arrayList = this.TokenizeSql(text);
			this.parameterMap.Clear();
			using (IEnumerator enumerator = arrayList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					string text2 = (string)enumerator.get_Current();
					if (text2[0] != this.parameters.ParameterMarker)
					{
						stringBuilder.Append(text2);
					}
					else
					{
						this.parameterMap.Add(text2);
						stringBuilder.Append(this.parameters.ParameterMarker);
					}
				}
			}
			return stringBuilder.ToString();
		}

		private ArrayList TokenizeSql(string sql)
		{
			char c = '\0';
			StringBuilder stringBuilder = new StringBuilder();
			bool flag = false;
			ArrayList arrayList = new ArrayList();
			int i = 0;
			while (i < sql.Length)
			{
				char c2 = sql[i];
				if (flag)
				{
					flag = !flag;
					goto IL_149;
				}
				if (c2 == c)
				{
					c = '\0';
					goto IL_149;
				}
				if (c2 == ';' && !flag && c == '\0' && !this.connection.driver.SupportsBatch)
				{
					arrayList.Add(stringBuilder.ToString());
					arrayList.Add(";");
					stringBuilder.Remove(0, stringBuilder.Length);
				}
				else
				{
					if ((c2 == '\'' || c2 == '"' || c2 == '`') & !flag & c == '\0')
					{
						c = c2;
						goto IL_149;
					}
					if (c2 == '\\')
					{
						flag = !flag;
						goto IL_149;
					}
					if (c2 == this.parameters.ParameterMarker && c == '\0' && !flag)
					{
						arrayList.Add(stringBuilder.ToString());
						stringBuilder.Remove(0, stringBuilder.Length);
						goto IL_149;
					}
					if (stringBuilder.Length > 0 && stringBuilder[0] == this.parameters.ParameterMarker && !char.IsLetterOrDigit(c2) && c2 != '_' && c2 != '.' && c2 != '$' && c2 != '@')
					{
						arrayList.Add(stringBuilder.ToString());
						stringBuilder.Remove(0, stringBuilder.Length);
						goto IL_149;
					}
					goto IL_149;
				}
				IL_152:
				i++;
				continue;
				IL_149:
				stringBuilder.Append(c2);
				goto IL_152;
			}
			arrayList.Add(stringBuilder.ToString());
			return arrayList;
		}

		object ICloneable.Clone()
		{
			MySqlCommand mySqlCommand = new MySqlCommand(this.cmdText, this.connection, this.curTransaction);
			using (IEnumerator enumerator = this.parameters.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					MySqlParameter mySqlParameter = (MySqlParameter)enumerator.get_Current();
					mySqlCommand.Parameters.Add(mySqlParameter.Clone());
				}
			}
			return mySqlCommand;
		}
	}
}
