using System;
using System.Collections;

namespace MySql.Data.MySqlClient
{
	internal class MySqlPoolManager
	{
		private static Hashtable pools;

		static MySqlPoolManager()
		{
			MySqlPoolManager.pools = new Hashtable();
		}

		public static MySqlPool GetPool(MySqlConnectionString settings)
		{
			string connectionString = settings.GetConnectionString(true);
			MySqlPool result;
			lock (MySqlPoolManager.pools.SyncRoot)
			{
				MySqlPool mySqlPool;
				if (!MySqlPoolManager.pools.Contains(connectionString))
				{
					mySqlPool = new MySqlPool(settings);
					MySqlPoolManager.pools.Add(connectionString, mySqlPool);
				}
				else
				{
					mySqlPool = (MySqlPoolManager.pools[connectionString] as MySqlPool);
					mySqlPool.Settings = settings;
				}
				result = mySqlPool;
			}
			return result;
		}

		public static void RemoveConnection(Driver driver)
		{
			lock (MySqlPoolManager.pools.SyncRoot)
			{
				string connectionString = driver.Settings.GetConnectionString(true);
				MySqlPool mySqlPool = (MySqlPool)MySqlPoolManager.pools[connectionString];
				if (mySqlPool == null)
				{
					throw new MySqlException("Pooling exception: Unable to find original pool for connection");
				}
				mySqlPool.RemoveConnection(driver);
			}
		}

		public static void ReleaseConnection(Driver driver)
		{
			lock (MySqlPoolManager.pools.SyncRoot)
			{
				string connectionString = driver.Settings.GetConnectionString(true);
				MySqlPool mySqlPool = (MySqlPool)MySqlPoolManager.pools[connectionString];
				if (mySqlPool == null)
				{
					throw new MySqlException("Pooling exception: Unable to find original pool for connection");
				}
				mySqlPool.ReleaseConnection(driver);
			}
		}
	}
}
