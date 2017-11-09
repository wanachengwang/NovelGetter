using MySql.Data.Types;
using System;

namespace MySql.Data.MySqlClient
{
	internal class CommandResult
	{
		private Driver driver;

		private long affectedRows;

		private ulong fieldCount;

		private long lastInsertId;

		private bool readSchema;

		private bool readRows;

		private bool isBinary;

		private MySqlField[] fields;

		private MySqlValue[] values;

		private bool dataRowOpen;

		private bool usingSequentialAccess;

		private int seqColumn;

		public MySqlValue this[int index]
		{
			get
			{
				return this.values[index];
			}
			set
			{
				this.values[index] = value;
			}
		}

		public MySqlField[] Fields
		{
			get
			{
				return this.fields;
			}
		}

		public bool IsResultSet
		{
			get
			{
				return this.fieldCount > 0uL;
			}
		}

		public long AffectedRows
		{
			get
			{
				return this.affectedRows;
			}
		}

		public CommandResult(Driver d, bool isBinary)
		{
			this.driver = d;
			this.isBinary = isBinary;
			this.affectedRows = -1L;
			this.ReadNextResult(true);
		}

		public MySqlValue ReadColumnValue(int index)
		{
			if (this.usingSequentialAccess)
			{
				if (this.seqColumn != index)
				{
					if (index < this.seqColumn)
					{
						throw new MySqlException("Invalid attempt to read a prior column using SequentialAccess");
					}
					while (this.seqColumn + 1 < index)
					{
						this.driver.SkipField(this.values[this.seqColumn + 1]);
						this.seqColumn++;
					}
					this.values[index] = this.driver.ReadFieldValue(index, this.fields[index], this.values[index]);
					this.seqColumn = index;
					return this.values[index];
				}
			}
			return this[index];
		}

		public bool ReadNextResult(bool isFirst)
		{
			long num = 0L;
			while ((this.driver.ServerStatus & (ServerStatusFlags.MoreResults | ServerStatusFlags.AnotherQuery)) != (ServerStatusFlags)0 || isFirst)
			{
				this.fieldCount = (ulong)this.driver.ReadResult(ref num, ref this.lastInsertId);
				if (num != -1L)
				{
					if (this.affectedRows == -1L)
					{
						this.affectedRows = 0L;
					}
					this.affectedRows += num;
				}
				if (isFirst)
				{
					isFirst = false;
				}
				if (this.IsResultSet)
				{
					this.readSchema = false;
					this.readRows = false;
					return true;
				}
			}
			return false;
		}

		public bool Load()
		{
			bool result;
			try
			{
				this.driver.ReadFieldMetadata((int)this.fieldCount, ref this.fields);
				this.readSchema = true;
				this.values = new MySqlValue[this.fields.Length];
				for (int i = 0; i < this.fields.Length; i++)
				{
					this.values[i] = this.fields[i].GetValueObject();
				}
				if (!this.driver.OpenDataRow(this.fields.Length, this.isBinary))
				{
					this.readRows = true;
					result = false;
				}
				else
				{
					this.dataRowOpen = true;
					result = true;
				}
			}
			catch (Exception)
			{
				this.readSchema = true;
				this.readRows = true;
				throw;
			}
			return result;
		}

		public bool ReadDataRow(bool loadFields)
		{
			if (this.readRows)
			{
				return false;
			}
			this.seqColumn = -1;
			if (!this.dataRowOpen && !this.driver.OpenDataRow(this.fields.Length, this.isBinary))
			{
				this.readRows = true;
				return false;
			}
			this.dataRowOpen = false;
			this.usingSequentialAccess = !loadFields;
			if (!loadFields)
			{
				return true;
			}
			for (int i = 0; i < this.fields.Length; i++)
			{
				this.values[i] = this.driver.ReadFieldValue(i, this.fields[i], this.values[i]);
			}
			return true;
		}

		public void Consume()
		{
			if (!this.IsResultSet)
			{
				return;
			}
			if (!this.readSchema)
			{
				this.driver.ReadFieldMetadata((int)this.fieldCount, ref this.fields);
				this.readSchema = true;
			}
			if (!this.readRows)
			{
				while (this.driver.OpenDataRow(0, false))
				{
				}
				this.readRows = true;
			}
		}
	}
}
