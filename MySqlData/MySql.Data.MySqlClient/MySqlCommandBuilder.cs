using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Text;

namespace MySql.Data.MySqlClient
{
	[DesignerCategory("Code"), ToolboxItem(false)]
	public sealed class MySqlCommandBuilder : Component
	{
		private MySqlDataAdapter _adapter;

		private string _QuotePrefix;

		private string _QuoteSuffix;

		private DataTable _schema;

		private string tableName;

		private string schemaName;

		private MySqlCommand _updateCmd;

		private MySqlCommand _insertCmd;

		private MySqlCommand _deleteCmd;

		private char marker = '?';

		private bool lastOneWins;

		public MySqlDataAdapter DataAdapter
		{
			get
			{
				return this._adapter;
			}
			set
			{
				if (this._adapter != null)
				{
					this._adapter.RowUpdating -= new MySqlRowUpdatingEventHandler(this.OnRowUpdating);
				}
				if (value == null)
				{
					throw new ArgumentException(Resources.ParameterCannotBeNull, "value");
				}
				this._adapter = value;
				this._adapter.RowUpdating += new MySqlRowUpdatingEventHandler(this.OnRowUpdating);
			}
		}

		public string QuotePrefix
		{
			get
			{
				return this._QuotePrefix;
			}
			set
			{
				this._QuotePrefix = value;
			}
		}

		public string QuoteSuffix
		{
			get
			{
				return this._QuoteSuffix;
			}
			set
			{
				this._QuoteSuffix = value;
			}
		}

		private string TableName
		{
			get
			{
				if (this.schemaName != null && this.schemaName.Length > 0)
				{
					return this.Quote(this.schemaName) + "." + this.Quote(this.tableName);
				}
				return this.Quote(this.tableName);
			}
		}

		public MySqlCommandBuilder()
		{
			this._QuotePrefix = (this._QuoteSuffix = "`");
		}

		public MySqlCommandBuilder(bool lastOneWins) : this()
		{
			this.lastOneWins = lastOneWins;
		}

		public MySqlCommandBuilder(MySqlDataAdapter adapter) : this()
		{
			this.DataAdapter = adapter;
		}

		public MySqlCommandBuilder(MySqlDataAdapter adapter, bool lastOneWins) : this(lastOneWins)
		{
			this.DataAdapter = adapter;
		}

		public static void DeriveParameters(MySqlCommand command)
		{
			if (!command.Connection.driver.Version.isAtLeast(5, 0, 0))
			{
				throw new MySqlException("DeriveParameters is not supported on MySQL versions prior to 5.0");
			}
			string text = command.CommandText;
			if (text.IndexOf(".") == -1)
			{
				text = string.Format("`{0}`.`{1}`", command.Connection.Database, text);
			}
			ArrayList procedure = command.Connection.ProcedureCache.GetProcedure(command.Connection, text);
			command.Parameters.Clear();
			using (IEnumerator enumerator = procedure.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					MySqlParameter value = (MySqlParameter)enumerator.get_Current();
					command.Parameters.Add(value);
				}
			}
		}

		public MySqlCommand GetDeleteCommand()
		{
			if (this._schema == null)
			{
				this.GenerateSchema();
			}
			return this.CreateDeleteCommand();
		}

		public MySqlCommand GetInsertCommand()
		{
			if (this._schema == null)
			{
				this.GenerateSchema();
			}
			return this.CreateInsertCommand();
		}

		public MySqlCommand GetUpdateCommand()
		{
			if (this._schema == null)
			{
				this.GenerateSchema();
			}
			return this.CreateUpdateCommand();
		}

		public void RefreshSchema()
		{
			this._schema = null;
			this._insertCmd = null;
			this._deleteCmd = null;
			this._updateCmd = null;
			this.tableName = null;
			this.schemaName = null;
		}

		private void GenerateSchema()
		{
			MySqlConnection connection = this._adapter.SelectCommand.Connection;
			this.marker = connection.ParameterMarker;
			if (this._adapter == null)
			{
				throw new MySqlException(Resources.AdapterIsNull);
			}
			if (this._adapter.SelectCommand == null)
			{
				throw new MySqlException(Resources.AdapterSelectIsNull);
			}
			bool flag = false;
			if (connection.State == null)
			{
				connection.Open();
				flag = true;
			}
			try
			{
				MySqlDataReader mySqlDataReader = this._adapter.SelectCommand.ExecuteReader(6);
				this._schema = mySqlDataReader.GetSchemaTable();
				mySqlDataReader.Close();
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				if (flag && connection != null)
				{
					connection.Close();
				}
			}
			bool flag2 = false;
			using (IEnumerator enumerator = this._schema.get_Rows().GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					DataRow dataRow = (DataRow)enumerator.get_Current();
					string text = dataRow["BaseTableName"].ToString();
					string text2 = dataRow["BaseSchemaName"].ToString();
					if ((bool)dataRow["IsKey"] || (bool)dataRow["IsUnique"])
					{
						flag2 = true;
					}
					if (this.tableName == null)
					{
						this.schemaName = text2;
						this.tableName = text;
					}
					else
					{
						if (this.tableName != text && text.Length > 0)
						{
							throw new InvalidOperationException(Resources.CBMultiTableNotSupported);
						}
						if (this.schemaName != text2 && text2.Length > 0)
						{
							throw new InvalidOperationException(Resources.CBMultiTableNotSupported);
						}
					}
				}
			}
			if (!flag2)
			{
				throw new InvalidOperationException(Resources.CBNoKeyColumn);
			}
		}

		private string Quote(string table_or_column)
		{
			if (this._QuotePrefix != null && this._QuoteSuffix != null)
			{
				return this._QuotePrefix + table_or_column + this._QuoteSuffix;
			}
			return table_or_column;
		}

		private static string GetParameterName(string columnName)
		{
			StringBuilder stringBuilder = new StringBuilder(columnName);
			stringBuilder.Replace(" ", "");
			stringBuilder.Replace("/", "_per_");
			stringBuilder.Replace("-", "_");
			stringBuilder.Replace(")", "_cb_");
			stringBuilder.Replace("(", "_ob_");
			stringBuilder.Replace("%", "_pct_");
			stringBuilder.Replace("<", "_lt_");
			stringBuilder.Replace(">", "_gt_");
			stringBuilder.Replace(".", "_pt_");
			return stringBuilder.ToString();
		}

		private MySqlParameter CreateParameter(DataRow row, bool Original)
		{
			string parameterName = MySqlCommandBuilder.GetParameterName(row["ColumnName"].ToString());
			MySqlDbType type = (MySqlDbType)row["ProviderType"];
			MySqlParameter result;
			if (Original)
			{
				result = new MySqlParameter(string.Format("{0}Original_{1}", this.marker, parameterName), type, 1, (string)row["ColumnName"], 256, DBNull.Value);
			}
			else
			{
				result = new MySqlParameter(string.Format("{0}{1}", this.marker, parameterName), type, 1, (string)row["ColumnName"], 512, DBNull.Value);
			}
			return result;
		}

		private MySqlCommand CreateBaseCommand()
		{
			return new MySqlCommand
			{
				Connection = this._adapter.SelectCommand.Connection,
				CommandTimeout = this._adapter.SelectCommand.CommandTimeout,
				Transaction = this._adapter.SelectCommand.Transaction
			};
		}

		private MySqlCommand CreateDeleteCommand()
		{
			if (this._deleteCmd != null)
			{
				return this._deleteCmd;
			}
			MySqlCommand mySqlCommand = this.CreateBaseCommand();
			mySqlCommand.CommandText = "DELETE FROM " + this.TableName + " WHERE " + this.CreateOriginalWhere(mySqlCommand);
			this._deleteCmd = mySqlCommand;
			return mySqlCommand;
		}

		private string CreateFinalSelect(bool forinsert)
		{
			StringBuilder stringBuilder = new StringBuilder();
			StringBuilder stringBuilder2 = new StringBuilder();
			using (IEnumerator enumerator = this._schema.get_Rows().GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					DataRow dataRow = (DataRow)enumerator.get_Current();
					string text = (string)dataRow["BaseTableName"];
					if (text != null && text.Length != 0)
					{
						string text2 = this.Quote(dataRow["ColumnName"].ToString());
						string parameterName = MySqlCommandBuilder.GetParameterName(dataRow["ColumnName"].ToString());
						if (stringBuilder.Length > 0)
						{
							stringBuilder.Append(", ");
						}
						stringBuilder.Append(text2);
						if ((bool)dataRow["IsKey"])
						{
							if (stringBuilder2.Length > 0)
							{
								stringBuilder2.Append(" AND ");
							}
							stringBuilder2.Append("(" + text2 + "=");
							if (forinsert)
							{
								if ((bool)dataRow["IsAutoIncrement"])
								{
									stringBuilder2.Append("last_insert_id()");
								}
								else if ((bool)dataRow["IsKey"])
								{
									stringBuilder2.Append(this.marker + parameterName);
								}
							}
							else
							{
								stringBuilder2.Append(this.marker + "Original_" + parameterName);
							}
							stringBuilder2.Append(")");
						}
					}
				}
			}
			return string.Concat(new string[]
			{
				"SELECT ",
				stringBuilder.ToString(),
				" FROM ",
				this.TableName,
				" WHERE ",
				stringBuilder2.ToString()
			});
		}

		private string CreateOriginalWhere(MySqlCommand cmd)
		{
			StringBuilder stringBuilder = new StringBuilder();
			using (IEnumerator enumerator = this._schema.get_Rows().GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					DataRow dataRow = (DataRow)enumerator.get_Current();
					string text = (string)dataRow["BaseTableName"];
					if (text != null && text.Length != 0 && ((bool)dataRow["IsKey"] || (bool)dataRow["IsUnique"] || !this.lastOneWins) && MySqlCommandBuilder.IncludedInWhereClause(dataRow))
					{
						string text2 = this.Quote((string)dataRow["ColumnName"]);
						MySqlParameter mySqlParameter = this.CreateParameter(dataRow, true);
						cmd.Parameters.Add(mySqlParameter);
						stringBuilder.Append(text2 + " <=> " + mySqlParameter.ParameterName + " AND ");
					}
				}
			}
			stringBuilder.Remove(stringBuilder.Length - 5, 5);
			return stringBuilder.ToString();
		}

		private MySqlCommand CreateUpdateCommand()
		{
			if (this._updateCmd != null)
			{
				return this._updateCmd;
			}
			MySqlCommand mySqlCommand = this.CreateBaseCommand();
			StringBuilder stringBuilder = new StringBuilder();
			using (IEnumerator enumerator = this._schema.get_Rows().GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					DataRow dataRow = (DataRow)enumerator.get_Current();
					string text = (string)dataRow["BaseTableName"];
					if (text != null && text.Length != 0)
					{
						string text2 = this.Quote((string)dataRow["ColumnName"]);
						if (MySqlCommandBuilder.IncludedInUpdate(dataRow))
						{
							if (stringBuilder.Length > 0)
							{
								stringBuilder.Append(", ");
							}
							MySqlParameter mySqlParameter = this.CreateParameter(dataRow, false);
							mySqlCommand.Parameters.Add(mySqlParameter);
							stringBuilder.Append(text2 + "=" + mySqlParameter.ParameterName);
						}
					}
				}
			}
			mySqlCommand.CommandText = string.Concat(new string[]
			{
				"UPDATE ",
				this.TableName,
				" SET ",
				stringBuilder.ToString(),
				" WHERE ",
				this.CreateOriginalWhere(mySqlCommand)
			});
			MySqlCommand expr_137 = mySqlCommand;
			expr_137.CommandText = expr_137.CommandText + "; " + this.CreateFinalSelect(false);
			this._updateCmd = mySqlCommand;
			return mySqlCommand;
		}

		private MySqlCommand CreateInsertCommand()
		{
			if (this._insertCmd != null)
			{
				return this._insertCmd;
			}
			MySqlCommand mySqlCommand = this.CreateBaseCommand();
			StringBuilder stringBuilder = new StringBuilder();
			StringBuilder stringBuilder2 = new StringBuilder();
			using (IEnumerator enumerator = this._schema.get_Rows().GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					DataRow dataRow = (DataRow)enumerator.get_Current();
					string text = (string)dataRow["BaseTableName"];
					if (text != null && text.Length != 0)
					{
						string text2 = this.Quote((string)dataRow["ColumnName"]);
						if (MySqlCommandBuilder.IncludedInInsert(dataRow))
						{
							if (stringBuilder.Length > 0)
							{
								stringBuilder.Append(", ");
								stringBuilder2.Append(", ");
							}
							MySqlParameter mySqlParameter = this.CreateParameter(dataRow, false);
							mySqlCommand.Parameters.Add(mySqlParameter);
							stringBuilder.Append(text2);
							stringBuilder2.Append(mySqlParameter.ParameterName);
						}
					}
				}
			}
			mySqlCommand.CommandText = string.Concat(new string[]
			{
				"INSERT INTO ",
				this.TableName,
				" (",
				stringBuilder.ToString(),
				")  VALUES (",
				stringBuilder2.ToString(),
				")"
			});
			MySqlCommand expr_151 = mySqlCommand;
			expr_151.CommandText = expr_151.CommandText + "; " + this.CreateFinalSelect(true);
			this._insertCmd = mySqlCommand;
			return mySqlCommand;
		}

		private static bool IncludedInInsert(DataRow schemaRow)
		{
			return !(bool)schemaRow["IsAutoIncrement"] && !(bool)schemaRow["IsRowVersion"] && !(bool)schemaRow["IsReadOnly"];
		}

		private static bool IncludedInUpdate(DataRow schemaRow)
		{
			return !(bool)schemaRow["IsRowVersion"];
		}

		private static bool IncludedInWhereClause(DataRow schemaRow)
		{
			return true;
		}

		private static void SetParameterValues(MySqlCommand cmd, DataRow dataRow)
		{
			using (IEnumerator enumerator = cmd.Parameters.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					MySqlParameter mySqlParameter = (MySqlParameter)enumerator.get_Current();
					if (mySqlParameter.SourceVersion == 256)
					{
						mySqlParameter.Value = dataRow.get_Item(mySqlParameter.SourceColumn, 256);
					}
					else
					{
						mySqlParameter.Value = dataRow.get_Item(mySqlParameter.SourceColumn, 512);
					}
				}
			}
		}

		private void OnRowUpdating(object sender, MySqlRowUpdatingEventArgs e)
		{
			if (e.get_Status() != null)
			{
				return;
			}
			if (this._schema == null)
			{
				this.GenerateSchema();
			}
			if (3 == e.get_StatementType())
			{
				e.Command = this.CreateDeleteCommand();
			}
			else if (2 == e.get_StatementType())
			{
				e.Command = this.CreateUpdateCommand();
			}
			else if (1 == e.get_StatementType())
			{
				e.Command = this.CreateInsertCommand();
			}
			else if (e.get_StatementType() == null)
			{
				return;
			}
			MySqlCommandBuilder.SetParameterValues(e.Command, e.get_Row());
		}
	}
}
