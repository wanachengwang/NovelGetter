using System;
using System.Data;

namespace MySql.Data.MySqlClient
{
	public sealed class MySqlHelper
	{
		private MySqlHelper()
		{
		}

		public static int ExecuteNonQuery(MySqlConnection connection, string commandText, params MySqlParameter[] commandParameters)
		{
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.Connection = connection;
			mySqlCommand.CommandText = commandText;
			mySqlCommand.CommandType = 1;
			if (commandParameters != null)
			{
				for (int i = 0; i < commandParameters.Length; i++)
				{
					MySqlParameter value = commandParameters[i];
					mySqlCommand.Parameters.Add(value);
				}
			}
			int result = mySqlCommand.ExecuteNonQuery();
			mySqlCommand.Parameters.Clear();
			return result;
		}

		public static int ExecuteNonQuery(string connectionString, string commandText, params MySqlParameter[] parms)
		{
			int result;
			using (MySqlConnection mySqlConnection = new MySqlConnection(connectionString))
			{
				mySqlConnection.Open();
				result = MySqlHelper.ExecuteNonQuery(mySqlConnection, commandText, parms);
			}
			return result;
		}

		public static DataRow ExecuteDataRow(string connectionString, string commandText, params MySqlParameter[] parms)
		{
			DataSet dataSet = MySqlHelper.ExecuteDataset(connectionString, commandText, parms);
			if (dataSet == null)
			{
				return null;
			}
			if (dataSet.get_Tables().get_Count() == 0)
			{
				return null;
			}
			if (dataSet.get_Tables()[0].get_Rows().get_Count() == 0)
			{
				return null;
			}
			return dataSet.get_Tables()[0].get_Rows()[0];
		}

		public static DataSet ExecuteDataset(string connectionString, string commandText)
		{
			return MySqlHelper.ExecuteDataset(connectionString, commandText, null);
		}

		public static DataSet ExecuteDataset(string connectionString, string commandText, params MySqlParameter[] commandParameters)
		{
			DataSet result;
			using (MySqlConnection mySqlConnection = new MySqlConnection(connectionString))
			{
				mySqlConnection.Open();
				result = MySqlHelper.ExecuteDataset(mySqlConnection, commandText, commandParameters);
			}
			return result;
		}

		public static DataSet ExecuteDataset(MySqlConnection connection, string commandText)
		{
			return MySqlHelper.ExecuteDataset(connection, commandText, null);
		}

		public static DataSet ExecuteDataset(MySqlConnection connection, string commandText, params MySqlParameter[] commandParameters)
		{
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.Connection = connection;
			mySqlCommand.CommandText = commandText;
			mySqlCommand.CommandType = 1;
			if (commandParameters != null)
			{
				for (int i = 0; i < commandParameters.Length; i++)
				{
					MySqlParameter value = commandParameters[i];
					mySqlCommand.Parameters.Add(value);
				}
			}
			MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
			DataSet dataSet = new DataSet();
			mySqlDataAdapter.Fill(dataSet);
			mySqlCommand.Parameters.Clear();
			return dataSet;
		}

		public static void UpdateDataSet(string connectionString, string commandText, DataSet ds, string tablename)
		{
			MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
			mySqlConnection.Open();
			MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(commandText, mySqlConnection);
			MySqlCommandBuilder mySqlCommandBuilder = new MySqlCommandBuilder(mySqlDataAdapter);
			mySqlCommandBuilder.ToString();
			mySqlDataAdapter.Update(ds, tablename);
			mySqlConnection.Close();
		}

		private static MySqlDataReader ExecuteReader(MySqlConnection connection, MySqlTransaction transaction, string commandText, MySqlParameter[] commandParameters, bool ExternalConn)
		{
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.Connection = connection;
			mySqlCommand.Transaction = transaction;
			mySqlCommand.CommandText = commandText;
			mySqlCommand.CommandType = 1;
			if (commandParameters != null)
			{
				for (int i = 0; i < commandParameters.Length; i++)
				{
					MySqlParameter value = commandParameters[i];
					mySqlCommand.Parameters.Add(value);
				}
			}
			MySqlDataReader result;
			if (ExternalConn)
			{
				result = mySqlCommand.ExecuteReader();
			}
			else
			{
				result = mySqlCommand.ExecuteReader(32);
			}
			mySqlCommand.Parameters.Clear();
			return result;
		}

		public static MySqlDataReader ExecuteReader(string connectionString, string commandText)
		{
			return MySqlHelper.ExecuteReader(connectionString, commandText, null);
		}

		public static MySqlDataReader ExecuteReader(string connectionString, string commandText, params MySqlParameter[] commandParameters)
		{
			MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
			mySqlConnection.Open();
			MySqlDataReader result;
			try
			{
				result = MySqlHelper.ExecuteReader(mySqlConnection, null, commandText, commandParameters, false);
			}
			catch
			{
				mySqlConnection.Close();
				throw;
			}
			return result;
		}

		public static object ExecuteScalar(string connectionString, string commandText)
		{
			return MySqlHelper.ExecuteScalar(connectionString, commandText, null);
		}

		public static object ExecuteScalar(string connectionString, string commandText, params MySqlParameter[] commandParameters)
		{
			object result;
			using (MySqlConnection mySqlConnection = new MySqlConnection(connectionString))
			{
				mySqlConnection.Open();
				result = MySqlHelper.ExecuteScalar(mySqlConnection, commandText, commandParameters);
			}
			return result;
		}

		public static object ExecuteScalar(MySqlConnection connection, string commandText)
		{
			return MySqlHelper.ExecuteScalar(connection, commandText, null);
		}

		public static object ExecuteScalar(MySqlConnection connection, string commandText, params MySqlParameter[] commandParameters)
		{
			MySqlCommand mySqlCommand = new MySqlCommand();
			mySqlCommand.Connection = connection;
			mySqlCommand.CommandText = commandText;
			mySqlCommand.CommandType = 1;
			if (commandParameters != null)
			{
				for (int i = 0; i < commandParameters.Length; i++)
				{
					MySqlParameter value = commandParameters[i];
					mySqlCommand.Parameters.Add(value);
				}
			}
			object result = mySqlCommand.ExecuteScalar();
			mySqlCommand.Parameters.Clear();
			return result;
		}
	}
}
