using System;
using System.Collections;
using System.IO;

namespace MySql.Data.MySqlClient
{
	internal class PreparedStatement
	{
		private Driver driver;

		private int statementId;

		private MySqlField[] paramList;

		private int executionCount;

		public int StatementId
		{
			get
			{
				return this.statementId;
			}
		}

		public int NumParameters
		{
			get
			{
				return this.paramList.Length;
			}
		}

		public int ExecutionCount
		{
			get
			{
				return this.executionCount;
			}
			set
			{
				this.executionCount = value;
			}
		}

		public PreparedStatement(Driver driver, int statementId, MySqlField[] paramList)
		{
			this.paramList = new MySqlField[0];
			this.driver = driver;
			this.statementId = statementId;
			this.paramList = paramList;
			this.executionCount = 0;
		}

		public CommandResult Execute(MySqlParameterCollection parameters)
		{
			PacketWriter packetWriter = new PacketWriter();
			packetWriter.Driver = (NativeDriver)this.driver;
			BitArray bitArray = new BitArray(parameters.Count);
			for (int i = 0; i < this.paramList.Length; i++)
			{
				MySqlParameter mySqlParameter = parameters[this.paramList[i].ColumnName];
				if (mySqlParameter.Value == DBNull.Value || mySqlParameter.Value == null)
				{
					bitArray[i] = true;
				}
			}
			byte[] array = new byte[(parameters.Count + 7) / 8];
			if (array.Length > 0)
			{
				bitArray.CopyTo(array, 0);
			}
			packetWriter.WriteInteger((long)this.StatementId, 4);
			packetWriter.WriteByte(0);
			packetWriter.WriteInteger(1L, 4);
			packetWriter.Write(array);
			packetWriter.WriteByte(1);
			MySqlField[] array2 = this.paramList;
			for (int j = 0; j < array2.Length; j++)
			{
				MySqlField mySqlField = array2[j];
				MySqlParameter mySqlParameter2 = parameters[mySqlField.ColumnName];
				packetWriter.WriteInteger((long)mySqlParameter2.GetPSType(), 2);
			}
			array2 = this.paramList;
			for (int j = 0; j < array2.Length; j++)
			{
				MySqlField mySqlField2 = array2[j];
				int num = parameters.IndexOf(mySqlField2.ColumnName);
				if (num == -1)
				{
					throw new MySqlException("Parameter '" + mySqlField2.ColumnName + "' is not defined.");
				}
				MySqlParameter mySqlParameter3 = parameters[num];
				if (mySqlParameter3.Value != DBNull.Value && mySqlParameter3.Value != null)
				{
					packetWriter.Encoding = mySqlField2.Encoding;
					mySqlParameter3.Serialize(packetWriter, true);
				}
			}
			this.executionCount++;
			return this.driver.ExecuteStatement(((MemoryStream)packetWriter.Stream).ToArray());
		}
	}
}
