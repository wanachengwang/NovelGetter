using MySql.Data.Common;
using System;
using System.Collections;

namespace MySql.Data.MySqlClient
{
	internal sealed class MySqlPool
	{
		private ArrayList inUsePool;

		private Queue idlePool;

		private MySqlConnectionString settings;

		private int minSize;

		private int maxSize;

		private ProcedureCache procedureCache;

		private Semaphore poolGate;

		private object lockObject;

		public MySqlConnectionString Settings
		{
			get
			{
				return this.settings;
			}
			set
			{
				this.settings = value;
			}
		}

		private bool NeedConnections
		{
			get
			{
				int num = this.idlePool.get_Count() + this.inUsePool.get_Count();
				return this.idlePool.get_Count() == 0 || num < this.minSize;
			}
		}

		public ProcedureCache ProcedureCache
		{
			get
			{
				return this.procedureCache;
			}
		}

		private bool HasIdleConnections
		{
			get
			{
				return this.idlePool.get_Count() > 0;
			}
		}

		private bool HasRoomForConnections
		{
			get
			{
				return this.inUsePool.get_Count() + this.idlePool.get_Count() != this.maxSize;
			}
		}

		public MySqlPool(MySqlConnectionString settings)
		{
			this.minSize = settings.MinPoolSize;
			this.maxSize = settings.MaxPoolSize;
			this.settings = settings;
			this.inUsePool = new ArrayList(this.maxSize);
			this.idlePool = new Queue(this.maxSize);
			for (int i = 0; i < this.minSize; i++)
			{
				this.CreateNewPooledConnection();
			}
			this.procedureCache = new ProcedureCache(settings.ProcedureCacheSize);
			this.poolGate = new Semaphore(this.maxSize, this.maxSize);
			this.lockObject = new object();
		}

		private Driver CheckoutConnection()
		{
			Driver driver = (Driver)this.idlePool.Dequeue();
			if (!driver.Ping())
			{
				driver.Close();
				return null;
			}
			if (this.settings.ResetPooledConnections)
			{
				driver.Reset();
			}
			this.inUsePool.Add(driver);
			return driver;
		}

		private Driver GetPooledConnection()
		{
			Driver driver;
			do
			{
				if (!this.HasIdleConnections)
				{
					this.CreateNewPooledConnection();
				}
				driver = this.CheckoutConnection();
			}
			while (driver == null);
			return driver;
		}

		private void CreateNewPooledConnection()
		{
			Driver driver = Driver.Create(this.settings);
			this.idlePool.Enqueue(driver);
		}

		public void ReleaseConnection(Driver driver)
		{
			lock (this.lockObject)
			{
				if (this.inUsePool.Contains(driver))
				{
					this.inUsePool.Remove(driver);
				}
				if (driver.IsTooOld)
				{
					driver.Close();
				}
				else
				{
					this.idlePool.Enqueue(driver);
				}
				this.poolGate.Release();
			}
		}

		public void RemoveConnection(Driver driver)
		{
			lock (this.lockObject)
			{
				if (this.inUsePool.Contains(driver))
				{
					this.inUsePool.Remove(driver);
					this.poolGate.Release();
				}
			}
		}

		public Driver GetConnection()
		{
			int num = this.settings.ConnectionTimeout * 1000;
			if (!this.poolGate.WaitOne(num, false))
			{
				throw new MySqlException(Resources.TimeoutGettingConnection);
			}
			Driver result;
			lock (this.lockObject)
			{
				try
				{
					Driver pooledConnection = this.GetPooledConnection();
					result = pooledConnection;
				}
				catch (Exception ex)
				{
					if (this.settings.Logging)
					{
						Logger.LogException(ex);
					}
					this.poolGate.Release();
					throw;
				}
			}
			return result;
		}
	}
}
