using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;

namespace MySql.Data.MySqlClient
{
	[DesignerCategory("Code"), ToolboxItem(true), ToolboxBitmap(typeof(MySqlConnection), "MySqlClient.resources.connection.bmp")]
	public sealed class MySqlConnection : Component, IDisposable, ICloneable, IDbConnection
	{
		internal ConnectionState state;

		internal Driver driver;

		private MySqlDataReader dataReader;

		private MySqlConnectionString settings;

		private bool hasBeenOpen;

		private ProcedureCache procedureCache;

        public event StateChangeEventHandler StateChange;

        public event MySqlInfoMessageEventHandler InfoMessage;

		internal ProcedureCache ProcedureCache
		{
			get
			{
				return this.procedureCache;
			}
		}

		internal MySqlConnectionString Settings
		{
			get
			{
				return this.settings;
			}
		}

		internal MySqlDataReader Reader
		{
			get
			{
				return this.dataReader;
			}
			set
			{
				this.dataReader = value;
			}
		}

		internal char ParameterMarker
		{
			get
			{
				if (this.settings.UseOldSyntax)
				{
					return '@';
				}
				return '?';
			}
		}

		[Browsable(false)]
		public int ServerThread
		{
			get
			{
				return this.driver.ThreadID;
			}
		}

		[Browsable(true)]
		public string DataSource
		{
			get
			{
				return this.settings.Server;
			}
		}

		[Browsable(true)]
		public int ConnectionTimeout
		{
			get
			{
				return this.settings.ConnectionTimeout;
			}
		}

		[Browsable(true)]
		public string Database
		{
			get
			{
				return this.settings.Database;
			}
		}

		[Browsable(false)]
		public bool UseCompression
		{
			get
			{
				return this.settings.UseCompression;
			}
		}

		[Browsable(false)]
		public ConnectionState State
		{
			get
			{
				return this.state;
			}
		}

		[Browsable(false)]
		public string ServerVersion
		{
			get
			{
				return this.driver.Version.ToString();
			}
		}

		internal Encoding Encoding
		{
			get
			{
				if (this.driver == null)
				{
					return Encoding.Default;
				}
				return this.driver.Encoding;
			}
		}

		[Browsable(true), Category("Data"), Description("Information used to connect to a DataSource, such as 'Server=xxx;UserId=yyy;Password=zzz;Database=dbdb'.")]
		public string ConnectionString
		{
			get
			{
				return this.settings.GetConnectionString(!this.hasBeenOpen);
			}
			set
			{
				if ((int)this.State != 0)
				{
					throw new MySqlException("Not allowed to change the 'ConnectionString' property while the connection (state=" + this.State + ").");
				}
				this.settings.SetConnectionString(value);
				if (this.driver != null)
				{
					this.driver.Settings = this.settings;
				}
			}
		}

		public MySqlConnection()
		{
			this.settings = new MySqlConnectionString();
			this.settings.LoadDefaultValues();
		}

		public MySqlConnection(string connectionString) : this()
		{
			this.ConnectionString = connectionString;
		}

		internal void OnInfoMessage(MySqlInfoMessageEventArgs args)
		{
			if (this.InfoMessage != null)
			{
				this.InfoMessage(this, args);
			}
		}

		public MySqlTransaction BeginTransaction()
		{
			return this.BeginTransaction((IsolationLevel)65536);
		}

		IDbTransaction IDbConnection.BeginTransaction()
		{
			return this.BeginTransaction();
		}

		public MySqlTransaction BeginTransaction(IsolationLevel iso)
		{
			if (this.state != (ConnectionState)1)
			{
				throw new InvalidOperationException(Resources.ConnectionNotOpen);
			}
			if ((this.driver.ServerStatus & ServerStatusFlags.InTransaction) != (ServerStatusFlags)0)
			{
				throw new InvalidOperationException(Resources.NoNestedTransactions);
			}
			MySqlTransaction result = new MySqlTransaction(this, iso);
			MySqlCommand mySqlCommand = new MySqlCommand("", this);
			mySqlCommand.CommandText = "SET SESSION TRANSACTION ISOLATION LEVEL ";
			if ((int)iso <= 256)
			{
				if ((int)iso == 16)
				{
					throw new NotSupportedException(Resources.ChaosNotSupported);
				}
				if ((int)iso == 256)
				{
					MySqlCommand expr_6A = mySqlCommand;
					expr_6A.CommandText += "READ UNCOMMITTED";
				}
			}
			else if ((int)iso != 4096)
			{
				if ((int)iso != 65536)
				{
					if ((int)iso == 1048576)
					{
						MySqlCommand expr_A7 = mySqlCommand;
						expr_A7.CommandText += "SERIALIZABLE";
					}
				}
				else
				{
					MySqlCommand expr_BF = mySqlCommand;
					expr_BF.CommandText += "REPEATABLE READ";
				}
			}
			else
			{
				MySqlCommand expr_D7 = mySqlCommand;
				expr_D7.CommandText += "READ COMMITTED";
			}
			mySqlCommand.ExecuteNonQuery();
			mySqlCommand.CommandText = "BEGIN";
			mySqlCommand.ExecuteNonQuery();
			return result;
		}

		IDbTransaction IDbConnection.BeginTransaction(IsolationLevel il)
		{
			return this.BeginTransaction(il);
		}

		public void ChangeDatabase(string databaseName)
		{
			if (databaseName == null || databaseName.Trim().Length == 0)
			{
				throw new ArgumentException(Resources.ParameterIsInvalid, "database");
			}
			if (this.state != (ConnectionState)1)
			{
				throw new InvalidOperationException(Resources.ConnectionNotOpen);
			}
			MySqlCommand mySqlCommand = new MySqlCommand(string.Format("USE `{0}`", databaseName), this);
			mySqlCommand.ExecuteNonQuery();
			this.settings.Database = databaseName;
		}

		internal void SetState(ConnectionState newState)
		{
			ConnectionState connectionState = this.state;
			this.state = newState;
			if (this.StateChange != null)
			{
				this.StateChange.Invoke(this, new StateChangeEventArgs(connectionState, newState));
			}
		}

		public bool Ping()
		{
			bool result;
			if (!(result = this.driver.Ping()))
			{
				this.Terminate();
			}
			return result;
		}

		public void Open()
		{
			if (this.state == (ConnectionState)1)
			{
				throw new InvalidOperationException(Resources.ConnectionAlreadyOpen);
			}
			this.SetState((ConnectionState)2);
			try
			{
				if (this.settings.Pooling)
				{
					MySqlPool pool = MySqlPoolManager.GetPool(this.settings);
					this.driver = pool.GetConnection();
					this.procedureCache = pool.ProcedureCache;
				}
				else
				{
					this.driver = Driver.Create(this.settings);
					this.procedureCache = new ProcedureCache(this.settings.ProcedureCacheSize);
				}
			}
			catch (Exception)
			{
				this.SetState(0);
				throw;
			}
			if (this.driver.Settings.UseOldSyntax)
			{
				Logger.LogWarning("You are using old syntax that will be removed in future versions");
			}
			this.SetState((ConnectionState)1);
			this.driver.Configure(this);
			if (this.settings.Database != null && this.settings.Database.Length != 0)
			{
				this.ChangeDatabase(this.settings.Database);
			}
			this.hasBeenOpen = true;
		}

		internal void Terminate()
		{
			try
			{
				if (this.settings.Pooling)
				{
					MySqlPoolManager.ReleaseConnection(this.driver);
				}
				else
				{
					this.driver.Close();
				}
			}
			catch (Exception)
			{
			}
			this.SetState(0);
		}

		public void Close()
		{
			if ((int)this.state == 0)
			{
				return;
			}
			if (this.dataReader != null)
			{
				this.dataReader.Close();
			}
			this.Terminate();
		}

		IDbCommand IDbConnection.CreateCommand()
		{
			return this.CreateCommand();
		}

		public MySqlCommand CreateCommand()
		{
			return new MySqlCommand
			{
				Connection = this
			};
		}

		object ICloneable.Clone()
		{
			return new MySqlConnection
			{
				ConnectionString = this.ConnectionString
			};
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && (int)this.State == 1)
			{
				this.Close();
			}
			base.Dispose(disposing);
		}
	}
}
