using MySql.Data.Common;
using MySql.Data.Types;
using System;
using System.Collections;
using System.Globalization;
using System.Text;

namespace MySql.Data.MySqlClient
{
	internal abstract class Driver : IDisposable
	{
		protected int threadId;

		protected DBVersion version;

		protected Encoding encoding;

		protected ServerStatusFlags serverStatus;

		protected MySqlConnectionString connectionString;

		protected ClientFlags serverCaps;

		protected bool isOpen;

		protected DateTime creationTime;

		protected int serverLanguage;

		protected Hashtable serverProps;

		protected MySqlConnection connection;

		protected Hashtable charSets;

		protected bool hasWarnings;

		protected long maxPacketSize;

		internal int selectLimit;

		internal bool IsOpen
		{
			get
			{
				return this.isOpen;
			}
		}

		internal long MaxPacketSize
		{
			get
			{
				return this.maxPacketSize;
			}
		}

		public int ThreadID
		{
			get
			{
				return this.threadId;
			}
		}

		public DBVersion Version
		{
			get
			{
				return this.version;
			}
		}

		public MySqlConnectionString Settings
		{
			get
			{
				return this.connectionString;
			}
			set
			{
				this.connectionString = value;
			}
		}

		public Encoding Encoding
		{
			get
			{
				return this.encoding;
			}
			set
			{
				this.encoding = value;
			}
		}

		public ServerStatusFlags ServerStatus
		{
			get
			{
				return this.serverStatus;
			}
		}

		public bool HasWarnings
		{
			get
			{
				return this.hasWarnings;
			}
		}

		public bool IsTooOld
		{
			get
			{
				TimeSpan timeSpan = DateTime.Now.Subtract(this.creationTime);
				return this.Settings.ConnectionLifetime != 0 && timeSpan.TotalSeconds > (double)this.Settings.ConnectionLifetime;
			}
		}

		public abstract bool SupportsBatch
		{
			get;
		}

		public Driver(MySqlConnectionString settings)
		{
			this.encoding = Encoding.GetEncoding("latin1");
			this.connectionString = settings;
			this.threadId = -1;
			this.selectLimit = -1;
		}

		public string Property(string key)
		{
			return (string)this.serverProps[key];
		}

		public static Driver Create(MySqlConnectionString settings)
		{
			Driver driver = new NativeDriver(settings);
			driver.Open();
			return driver;
		}

		public virtual void Open()
		{
			this.creationTime = DateTime.Now;
		}

		public virtual void SafeClose()
		{
			try
			{
				this.Close();
			}
			catch (Exception)
			{
			}
		}

		public virtual void Close()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		public virtual void Configure(MySqlConnection connection)
		{
			this.connection = connection;
			if (this.serverProps == null)
			{
				this.serverProps = new Hashtable();
				MySqlCommand mySqlCommand = new MySqlCommand("SHOW VARIABLES", connection);
				try
				{
					MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
					while (mySqlDataReader.Read())
					{
						this.serverProps[mySqlDataReader.GetValue(0)] = mySqlDataReader.GetString(1);
					}
					mySqlDataReader.Close();
				}
				catch (Exception ex)
				{
					Logger.LogException(ex);
					throw;
				}
				if (this.serverProps.Contains("max_allowed_packet"))
				{
					this.maxPacketSize = Convert.ToInt64(this.serverProps["max_allowed_packet"]);
				}
				this.LoadCharacterSets();
			}
			if (!this.Settings.ResetPooledConnections)
			{
				return;
			}
			string text = this.connectionString.CharacterSet;
			if (text == null || text.Length == 0)
			{
				if (!this.version.isAtLeast(4, 1, 0))
				{
					if (this.serverProps.Contains("character_set"))
					{
						text = this.serverProps["character_set"].ToString();
					}
				}
				else
				{
					text = (string)this.charSets[this.serverLanguage];
				}
			}
			if (this.version.isAtLeast(4, 1, 0))
			{
				MySqlCommand mySqlCommand2 = new MySqlCommand("SET character_set_results=NULL", connection);
				object obj = this.serverProps["character_set_client"];
				object obj2 = this.serverProps["character_set_connection"];
				if ((obj != null && obj.ToString() != text) || (obj2 != null && obj2.ToString() != text))
				{
					mySqlCommand2.CommandText = "SET NAMES " + text + ";" + mySqlCommand2.CommandText;
				}
				mySqlCommand2.ExecuteNonQuery();
			}
			if (text != null)
			{
				this.Encoding = CharSetMap.GetEncoding(this.version, text);
				return;
			}
			this.Encoding = CharSetMap.GetEncoding(this.version, "latin1");
		}

		private void LoadCharacterSets()
		{
			if (!this.version.isAtLeast(4, 1, 0))
			{
				return;
			}
			MySqlCommand mySqlCommand = new MySqlCommand("SHOW COLLATION", this.connection);
			MySqlDataReader mySqlDataReader = null;
			try
			{
				mySqlDataReader = mySqlCommand.ExecuteReader();
				this.charSets = new Hashtable();
				while (mySqlDataReader.Read())
				{
					this.charSets[Convert.ToInt32(mySqlDataReader["id"], NumberFormatInfo.InvariantInfo)] = mySqlDataReader.GetString(mySqlDataReader.GetOrdinal("charset"));
				}
			}
			catch (Exception ex)
			{
				Logger.LogException(ex);
				throw;
			}
			finally
			{
				if (mySqlDataReader != null)
				{
					mySqlDataReader.Close();
				}
			}
		}

		public void ReportWarnings()
		{
			ArrayList arrayList = new ArrayList();
			MySqlCommand mySqlCommand = new MySqlCommand("SHOW WARNINGS", this.connection);
			MySqlDataReader mySqlDataReader = null;
			try
			{
				mySqlDataReader = mySqlCommand.ExecuteReader();
				while (mySqlDataReader.Read())
				{
					arrayList.Add(new MySqlError(mySqlDataReader.GetString(0), mySqlDataReader.GetInt32(1), mySqlDataReader.GetString(2)));
				}
				mySqlDataReader.Close();
				this.hasWarnings = false;
				if (arrayList.Count != 0)
				{
					MySqlInfoMessageEventArgs mySqlInfoMessageEventArgs = new MySqlInfoMessageEventArgs();
					mySqlInfoMessageEventArgs.errors = (MySqlError[])arrayList.ToArray(typeof(MySqlError));
					if (this.connection != null)
					{
						this.connection.OnInfoMessage(mySqlInfoMessageEventArgs);
					}
				}
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				if (mySqlDataReader != null)
				{
					mySqlDataReader.Close();
				}
			}
		}

		public abstract void SetDatabase(string dbName);

		public abstract PreparedStatement Prepare(string sql, string[] names);

		public abstract void Reset();

		public abstract CommandResult SendQuery(byte[] bytes, int length, bool consume);

		public abstract long ReadResult(ref long affectedRows, ref long lastInsertId);

		public abstract bool OpenDataRow(int fieldCount, bool isBinary);

		public abstract MySqlValue ReadFieldValue(int index, MySqlField field, MySqlValue value);

		public abstract CommandResult ExecuteStatement(byte[] bytes);

		public abstract void SkipField(MySqlValue valObject);

		public abstract void ReadFieldMetadata(int count, ref MySqlField[] fields);

		public abstract bool Ping();

		protected virtual void Dispose(bool disposing)
		{
			if (this.connectionString.Pooling)
			{
				MySqlPoolManager.RemoveConnection(this);
			}
			this.isOpen = false;
		}

		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
