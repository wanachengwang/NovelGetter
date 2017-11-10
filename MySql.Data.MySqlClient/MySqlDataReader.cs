using MySql.Data.Types;
using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Data.SqlTypes;
using System.Globalization;

namespace MySql.Data.MySqlClient
{
	public sealed class MySqlDataReader : MarshalByRefObject, IDisposable, IEnumerable, IDataReader, IDataRecord
	{
		private bool isOpen = true;

		private MySqlField[] fields;

		private CommandBehavior commandBehavior;

		private MySqlCommand command;

		private bool canRead;

		private bool hasRows;

		private CommandResult currentResult;

		private int readCount;

		private DataTable schemaTable;

		private MySqlConnection connection;

		public int Depth
		{
			get
			{
				return 0;
			}
		}

		internal CommandBehavior Behavior
		{
			get
			{
				return this.commandBehavior;
			}
		}

		internal CommandResult CurrentResult
		{
			get
			{
				return this.currentResult;
			}
		}

		public bool IsClosed
		{
			get
			{
				return !this.isOpen;
			}
		}

		public int RecordsAffected
		{
			get
			{
				return this.command.UpdateCount;
			}
		}

		public bool HasRows
		{
			get
			{
				return this.hasRows;
			}
		}

		public int FieldCount
		{
			get
			{
				if (this.fields != null)
				{
					return this.fields.Length;
				}
				return 0;
			}
		}

		public object this[int i]
		{
			get
			{
				return this.GetValue(i);
			}
		}

		public object this[string name]
		{
			get
			{
				return this[this.GetOrdinal(name)];
			}
		}

		internal MySqlDataReader(MySqlCommand cmd, CommandBehavior behavior)
		{
			this.command = cmd;
			this.connection = this.command.Connection;
			this.commandBehavior = behavior;
		}

		void IDisposable.Dispose()
		{
			if (this.isOpen)
			{
				this.Close();
			}
		}

		public void Close()
		{
			if (!this.isOpen)
			{
				return;
			}
			try
			{
				if (this.currentResult != null)
				{
					this.currentResult.Consume();
				}
				this.connection.Reader = null;
				this.command.Consume();
				if (this.connection.driver.HasWarnings)
				{
					this.connection.driver.ReportWarnings();
				}
				if (((int)this.commandBehavior & 32) != 0)
				{
					this.connection.Close();
				}
			}
			catch (MySqlException ex)
			{
				if (ex.IsFatal)
				{
					this.connection.Reader = null;
					this.connection.Terminate();
				}
				throw;
			}
			finally
			{
				this.isOpen = false;
			}
		}

		public bool GetBoolean(int i)
		{
			return Convert.ToBoolean(this.GetValue(i));
		}

		public byte GetByte(int i)
		{
			MySqlValue fieldValue = this.GetFieldValue(i, false);
			if (fieldValue is MySqlUByte)
			{
				return ((MySqlUByte)fieldValue).Value;
			}
			return (byte)((MySqlByte)fieldValue).Value;
		}

		public long GetBytes(int i, long dataIndex, byte[] buffer, int bufferIndex, int length)
		{
			if (i >= this.fields.Length)
			{
				throw new IndexOutOfRangeException();
			}
			MySqlValue fieldValue = this.GetFieldValue(i, false);
			if (!(fieldValue is MySqlBinary))
			{
				throw new MySqlException("GetBytes can only be called on binary columns");
			}
			MySqlBinary mySqlBinary = (MySqlBinary)fieldValue;
			if (buffer == null)
			{
				return (long)mySqlBinary.Value.Length;
			}
			if (bufferIndex >= buffer.Length || bufferIndex < 0)
			{
				throw new IndexOutOfRangeException("Buffer index must be a valid index in buffer");
			}
			if (buffer.Length < bufferIndex + length)
			{
				throw new ArgumentException("Buffer is not large enough to hold the requested data");
			}
			if (dataIndex >= 0L && (dataIndex < (long)mySqlBinary.Value.Length || (long)mySqlBinary.Value.Length == 0L))
			{
				byte[] value = mySqlBinary.Value;
				if ((long)mySqlBinary.Value.Length < dataIndex + (long)length)
				{
					length = (int)((long)mySqlBinary.Value.Length - dataIndex);
				}
				Array.Copy(value, (int)dataIndex, buffer, bufferIndex, length);
				return (long)length;
			}
			throw new IndexOutOfRangeException("Data index must be a valid index in the field");
		}

		public char GetChar(int i)
		{
			string @string = this.GetString(i);
			return @string[0];
		}

		public long GetChars(int i, long fieldOffset, char[] buffer, int bufferoffset, int length)
		{
			if (i >= this.fields.Length)
			{
				throw new IndexOutOfRangeException();
			}
			string @string = this.GetString(i);
			if (buffer == null)
			{
				return (long)@string.Length;
			}
			if (bufferoffset >= buffer.Length || bufferoffset < 0)
			{
				throw new IndexOutOfRangeException("Buffer index must be a valid index in buffer");
			}
			if (buffer.Length < bufferoffset + length)
			{
				throw new ArgumentException("Buffer is not large enough to hold the requested data");
			}
			if (fieldOffset >= 0L && fieldOffset < (long)@string.Length)
			{
				if (@string.Length < length)
				{
					length = @string.Length;
				}
				@string.CopyTo((int)fieldOffset, buffer, bufferoffset, length);
				return (long)length;
			}
			throw new IndexOutOfRangeException("Field offset must be a valid index in the field");
		}

		public string GetDataTypeName(int i)
		{
			if (!this.isOpen)
			{
				throw new Exception("No current query in data reader");
			}
			if (i >= this.fields.Length)
			{
				throw new IndexOutOfRangeException();
			}
			return this.currentResult[i].GetMySqlTypeName();
		}

		public MySqlDateTime GetMySqlDateTime(int index)
		{
			return (MySqlDateTime)this.GetFieldValue(index, true);
		}

		public DateTime GetDateTime(int index)
		{
			MySqlValue fieldValue = this.GetFieldValue(index, true);
			if (fieldValue is MySqlDateTime)
			{
				MySqlDateTime mySqlDateTime = (MySqlDateTime)fieldValue;
				if (this.connection.Settings.ConvertZeroDateTime && !mySqlDateTime.IsValidDateTime)
				{
					return DateTime.MinValue;
				}
				return mySqlDateTime.GetDateTime();
			}
			else
			{
				if (!(fieldValue is MySqlString))
				{
					throw new NotSupportedException("Unable to convert from type " + fieldValue.GetType().ToString() + " to DateTime");
				}
				MySqlDateTime mySqlDateTime2 = new MySqlDateTime(MySqlDbType.Datetime);
				mySqlDateTime2 = mySqlDateTime2.ParseMySql(this.GetString(index), true);
				return mySqlDateTime2.GetDateTime();
			}
		}

		public decimal GetDecimal(int index)
		{
			MySqlValue fieldValue = this.GetFieldValue(index, true);
			if (fieldValue is MySqlDecimal)
			{
				return ((MySqlDecimal)fieldValue).Value;
			}
			return Convert.ToDecimal(fieldValue.ValueAsObject);
		}

		public double GetDouble(int index)
		{
			MySqlValue fieldValue = this.GetFieldValue(index, true);
			if (fieldValue is MySqlDouble)
			{
				return ((MySqlDouble)fieldValue).Value;
			}
			return Convert.ToDouble(fieldValue.ValueAsObject);
		}

		public Type GetFieldType(int i)
		{
			if (!this.isOpen)
			{
				throw new Exception("No current query in data reader");
			}
			if (i >= this.fields.Length)
			{
				throw new IndexOutOfRangeException();
			}
			if (!(this.currentResult[i] is MySqlDateTime))
			{
				return this.currentResult[i].SystemType;
			}
			if (!this.connection.Settings.AllowZeroDateTime)
			{
				return typeof(DateTime);
			}
			return typeof(MySqlDateTime);
		}

		public float GetFloat(int index)
		{
			MySqlValue fieldValue = this.GetFieldValue(index, true);
			if (fieldValue is MySqlFloat)
			{
				return ((MySqlFloat)fieldValue).Value;
			}
			return Convert.ToSingle(fieldValue.ValueAsObject);
		}

		public Guid GetGuid(int index)
		{
			return new Guid(this.GetString(index));
		}

		public short GetInt16(int index)
		{
			MySqlValue fieldValue = this.GetFieldValue(index, true);
			if (fieldValue is MySqlInt16)
			{
				return ((MySqlInt16)fieldValue).Value;
			}
			return Convert.ToInt16(fieldValue.ValueAsObject);
		}

		public int GetInt32(int index)
		{
			MySqlValue fieldValue = this.GetFieldValue(index, true);
			if (fieldValue is MySqlInt32)
			{
				return ((MySqlInt32)fieldValue).Value;
			}
			return Convert.ToInt32(fieldValue.ValueAsObject);
		}

		public long GetInt64(int index)
		{
			MySqlValue fieldValue = this.GetFieldValue(index, true);
			if (fieldValue is MySqlInt64)
			{
				return ((MySqlInt64)fieldValue).Value;
			}
			return Convert.ToInt64(fieldValue.ValueAsObject);
		}

		public string GetName(int i)
		{
			return this.fields[i].ColumnName;
		}

		public int GetOrdinal(string name)
		{
			if (!this.isOpen)
			{
				throw new Exception("No current query in data reader");
			}
			name = name.ToLower(CultureInfo.InvariantCulture);
			for (int i = 0; i < this.fields.Length; i++)
			{
				if (this.fields[i].ColumnName.ToLower(CultureInfo.InvariantCulture) == name)
				{
					return i;
				}
			}
			throw new IndexOutOfRangeException("Could not find specified column in results");
		}

		public DataTable GetSchemaTable()
		{
			if (this.schemaTable != null)
			{
				return this.schemaTable;
			}
			if (this.fields != null && this.fields.Length != 0)
			{
				DataTable dataTable = new DataTable("SchemaTable");
				dataTable.Columns.Add("ColumnName", typeof(string));
				dataTable.Columns.Add("ColumnOrdinal", typeof(int));
				dataTable.Columns.Add("ColumnSize", typeof(int));
				dataTable.Columns.Add("NumericPrecision", typeof(int));
				dataTable.Columns.Add("NumericScale", typeof(int));
				dataTable.Columns.Add("IsUnique", typeof(bool));
				dataTable.Columns.Add("IsKey", typeof(bool));
				DataColumn dataColumn = dataTable.Columns["IsKey"];
				dataColumn.AllowDBNull = (true);
				dataTable.Columns.Add("BaseCatalogName", typeof(string));
				dataTable.Columns.Add("BaseColumnName", typeof(string));
				dataTable.Columns.Add("BaseSchemaName", typeof(string));
				dataTable.Columns.Add("BaseTableName", typeof(string));
				dataTable.Columns.Add("DataType", typeof(Type));
				dataTable.Columns.Add("AllowDBNull", typeof(bool));
				dataTable.Columns.Add("ProviderType", typeof(int));
				dataTable.Columns.Add("IsAliased", typeof(bool));
				dataTable.Columns.Add("IsExpression", typeof(bool));
				dataTable.Columns.Add("IsIdentity", typeof(bool));
				dataTable.Columns.Add("IsAutoIncrement", typeof(bool));
				dataTable.Columns.Add("IsRowVersion", typeof(bool));
				dataTable.Columns.Add("IsHidden", typeof(bool));
				dataTable.Columns.Add("IsLong", typeof(bool));
				dataTable.Columns.Add("IsReadOnly", typeof(bool));
				int num = 1;
				for (int i = 0; i < this.fields.Length; i++)
				{
					MySqlField mySqlField = this.fields[i];
					DataRow dataRow = dataTable.NewRow();
					dataRow["ColumnName"] = mySqlField.ColumnName;
					dataRow["ColumnOrdinal"] = num++;
					dataRow["ColumnSize"] = mySqlField.IsTextField ? (mySqlField.ColumnLength / mySqlField.MaxLength) : mySqlField.ColumnLength;
					int precision = (int)mySqlField.Precision;
					int scale = (int)mySqlField.Scale;
					dataRow["NumericPrecision"] = (short)precision;
					dataRow["NumericScale"] = (short)scale;
					dataRow["DataType"] = this.GetFieldType(i);
					dataRow["ProviderType"] = (int)mySqlField.ProviderType();
					dataRow["IsLong"] = mySqlField.IsBlob && mySqlField.ColumnLength > 255;
					dataRow["AllowDBNull"] = mySqlField.AllowsNull;
					dataRow["IsReadOnly"] = false;
					dataRow["IsRowVersion"] = false;
					dataRow["IsUnique"] = mySqlField.IsUnique;
					dataRow["IsKey"] = mySqlField.IsPrimaryKey;
					dataRow["IsAutoIncrement"] = mySqlField.IsAutoIncrement;
					dataRow["BaseSchemaName"] = mySqlField.DatabaseName;
					dataRow["BaseCatalogName"] = mySqlField.DatabaseName;
					dataRow["BaseTableName"] = mySqlField.RealTableName;
					dataRow["BaseColumnName"] = mySqlField.OriginalColumnName;
					dataTable.Rows.Add(dataRow);
				}
				this.schemaTable = dataTable;
				return dataTable;
			}
			return null;
		}

		public string GetString(int index)
		{
			MySqlValue fieldValue = this.GetFieldValue(index, true);
			if (fieldValue is MySqlBinary)
			{
				return (this.currentResult[index] as MySqlBinary).ToString(this.fields[index].Encoding);
			}
			return fieldValue.ToString();
		}

		public TimeSpan GetTimeSpan(int index)
		{
			MySqlTimeSpan mySqlTimeSpan = (MySqlTimeSpan)this.GetFieldValue(index, true);
			return mySqlTimeSpan.Value;
		}

		public object GetValue(int i)
		{
			if (!this.isOpen)
			{
				throw new Exception("No current query in data reader");
			}
			if (i >= this.fields.Length)
			{
				throw new IndexOutOfRangeException();
			}
			MySqlValue fieldValue = this.GetFieldValue(i, false);
			if (fieldValue.IsNull)
			{
				return DBNull.Value;
			}
			if (!(fieldValue is MySqlDateTime))
			{
				return fieldValue.ValueAsObject;
			}
			MySqlDateTime mySqlDateTime = (MySqlDateTime)fieldValue;
			if (!mySqlDateTime.IsValidDateTime && this.connection.Settings.ConvertZeroDateTime)
			{
				return DateTime.MinValue;
			}
			if (this.connection.Settings.AllowZeroDateTime)
			{
				return fieldValue;
			}
			return mySqlDateTime.GetDateTime();
		}

		public int GetValues(object[] values)
		{
			if (values == null)
			{
				return 0;
			}
			int num = Math.Min(values.Length, this.fields.Length);
			for (int i = 0; i < num; i++)
			{
				values[i] = this.GetValue(i);
			}
			return num;
		}

		public ushort GetUInt16(int index)
		{
			MySqlValue fieldValue = this.GetFieldValue(index, true);
			if (fieldValue is MySqlUInt16)
			{
				return ((MySqlUInt16)fieldValue).Value;
			}
			return Convert.ToUInt16(fieldValue.ValueAsObject);
		}

		public uint GetUInt32(int index)
		{
			MySqlValue fieldValue = this.GetFieldValue(index, true);
			if (fieldValue is MySqlUInt32)
			{
				return ((MySqlUInt32)fieldValue).Value;
			}
			return Convert.ToUInt32(fieldValue.ValueAsObject);
		}

		public ulong GetUInt64(int index)
		{
			MySqlValue fieldValue = this.GetFieldValue(index, true);
			if (fieldValue is MySqlUInt64)
			{
				return ((MySqlUInt64)fieldValue).Value;
			}
			return Convert.ToUInt64(fieldValue.ValueAsObject);
		}

		IDataReader IDataRecord.GetData(int i)
		{
			throw new NotSupportedException("GetData not supported.");
		}

		public bool IsDBNull(int i)
		{
			return DBNull.Value == this.GetValue(i);
		}

		public bool NextResult()
		{
			if (!this.isOpen)
			{
				throw new MySqlException("Invalid attempt to NextResult when reader is closed.");
			}
			if (this.currentResult != null)
			{
				this.currentResult.Consume();
			}
			bool result;
			try
			{
				CommandResult nextResultSet = this.command.GetNextResultSet(this);
				if (nextResultSet != null)
				{
					this.currentResult = nextResultSet;
					this.readCount = 0;
					this.schemaTable = null;
					this.connection.SetState((ConnectionState)8);
					this.canRead = (this.hasRows = this.currentResult.Load());
					this.fields = this.currentResult.Fields;
					result = true;
				}
				else
				{
					this.canRead = false;
					result = false;
				}
			}
			catch (Exception ex)
			{
				if (ex is MySqlException && !(ex as MySqlException).IsFatal)
				{
					this.connection.SetState((ConnectionState)1);
				}
				else
				{
					this.connection.Terminate();
				}
				throw;
			}
			finally
			{
				if ((int)this.connection.State != 0 && (int)this.connection.State != 1)
				{
					this.connection.SetState((ConnectionState)1);
				}
			}
			return result;
		}

		public bool Read()
		{
			if (!this.isOpen)
			{
				throw new MySqlException("Invalid attempt to Read when reader is closed.");
			}
			if (!this.canRead)
			{
				return false;
			}
			this.readCount++;
			this.connection.SetState((ConnectionState)8);
			try
			{
				try
				{
					if (((int)this.Behavior & 16) != 0)
					{
						this.canRead = this.currentResult.ReadDataRow(false);
					}
					else
					{
						this.canRead = this.currentResult.ReadDataRow(true);
					}
					if (!this.canRead)
					{
						return false;
					}
				}
				catch (MySqlException ex)
				{
					if (ex.IsFatal)
					{
						this.connection.Terminate();
					}
					throw;
				}
				if ((int)this.Behavior == 8)
				{
					this.canRead = false;
				}
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				this.connection.SetState((ConnectionState)1);
			}
			return true;
		}

		private MySqlValue GetFieldValue(int index, bool checkNull)
		{
			if (index >= 0 && index < this.fields.Length)
			{
				try
				{
					MySqlValue mySqlValue = this.currentResult.ReadColumnValue(index);
					if (mySqlValue.IsNull && checkNull)
					{
						throw new SqlNullValueException();
					}
					if (this.readCount == 0)
					{
						throw new MySqlException("Invalid attempt to access a field before calling Read()");
					}
					return mySqlValue;
				}
				catch (MySqlException ex)
				{
					if (ex.IsFatal)
					{
						this.connection.Reader = null;
						this.connection.Terminate();
					}
					throw;
				}
			}
			throw new ArgumentException("You have specified an invalid column ordinal.");
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new DbEnumerator(this);
		}
	}
}
