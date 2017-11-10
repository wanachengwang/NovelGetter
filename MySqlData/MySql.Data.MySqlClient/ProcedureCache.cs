using System;
using System.Collections;

namespace MySql.Data.MySqlClient
{
	internal class ProcedureCache
	{
		private Hashtable procHash;

		private Queue hashQueue;

		private int maxSize;

		public ProcedureCache(int size)
		{
			this.maxSize = size;
			this.hashQueue = new Queue(this.maxSize);
			this.procHash = new Hashtable(this.maxSize);
		}

		public ArrayList GetProcedure(MySqlConnection conn, string spName)
		{
			int num = spName.IndexOf('.');
			if (num == -1)
			{
				spName = string.Format("`{0}`.`{1}`", conn.Database, spName);
			}
			int hashCode = spName.GetHashCode();
			ArrayList arrayList = (ArrayList)this.procHash[hashCode];
			if (arrayList == null)
			{
				if (conn.Settings.Logging)
				{
					Logger.LogInformation(string.Format("Retrieving procedure metadata for {0} from server.", spName));
				}
				arrayList = this.AddNew(conn, spName);
			}
			else if (conn.Settings.Logging)
			{
				Logger.LogInformation(string.Format("Retrieving procedure metadata for {0} from procedure cache.", spName));
			}
			return arrayList;
		}

		private ArrayList AddNew(MySqlConnection connection, string spName)
		{
			ArrayList procData = this.GetProcData(connection, spName);
			if (this.maxSize > 0)
			{
				if (this.procHash.get_Keys().Count == this.maxSize)
				{
					this.TrimHash();
				}
				int hashCode = spName.GetHashCode();
				lock (this.procHash.get_SyncRoot())
				{
					if (!this.procHash.ContainsKey(hashCode))
					{
						this.procHash[hashCode] = procData;
						this.hashQueue.Enqueue(hashCode);
					}
				}
			}
			return procData;
		}

		private void TrimHash()
		{
			int num = (int)this.hashQueue.Dequeue();
			this.procHash.Remove(num);
		}

		private ArrayList GetProcData(MySqlConnection connection, string spName)
		{
			MySqlCommand mySqlCommand = new MySqlCommand(spName, connection);
			mySqlCommand.CommandType = 4;
			StoredProcedure storedProcedure = new StoredProcedure(connection);
			return storedProcedure.DiscoverParameters(spName);
		}
	}
}
