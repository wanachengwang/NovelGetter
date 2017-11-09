using MySql.Data.Common;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing.Design;

namespace MySql.Data.MySqlClient
{
	internal sealed class MySqlConnectionString : DBConnectionString
	{
		private Hashtable defaults;

		[Category("Connection"), Description("The name or IP address of the server to use")]
		public string Server
		{
			get
			{
				return base.GetString("host");
			}
		}

		[Category("Connection"), DefaultValue(3306), Description("Port to use when connecting with sockets")]
		public int Port
		{
			get
			{
				return base.GetInt("port");
			}
		}

		[Category("Connection"), DefaultValue(ConnectionProtocol.Sockets), Description("Protocol to use for connection to MySQL")]
		public ConnectionProtocol Protocol
		{
			get
			{
				return (ConnectionProtocol)this.keyValues["protocol"];
			}
		}

		[Category("Connection"), Description("Name of pipe to use when connecting with named pipes (Win32 only)")]
		public string PipeName
		{
			get
			{
				return base.GetString("pipeName");
			}
		}

		[Category("Connection"), DefaultValue(false), Description("Should the connection ues compression")]
		public bool UseCompression
		{
			get
			{
				return base.GetBool("compress");
			}
		}

		[Category("Connection"), Description("Database to use initially"), Editor("MySql.Data.MySqlClient.Design.DatabaseTypeEditor,MySqlClient.Design", typeof(UITypeEditor))]
		public string Database
		{
			get
			{
				return base.GetString("database");
			}
			set
			{
				this.keyValues["database"] = value;
			}
		}

		[Category("Connection"), DefaultValue(15), Description("Number of seconds to wait for the connection to succeed")]
		public int ConnectionTimeout
		{
			get
			{
				return base.GetInt("connect timeout");
			}
		}

		[Category("Connection"), DefaultValue(true), Description("Allows execution of multiple SQL commands in a single statement")]
		public bool AllowBatch
		{
			get
			{
				return base.GetBool("allow batch");
			}
		}

		[Category("Connection"), DefaultValue(false), Description("Enables output of diagnostic messages")]
		public bool Logging
		{
			get
			{
				return base.GetBool("logging");
			}
		}

		[Category("Connection"), DefaultValue("MYSQL"), Description("Name of the shared memory object to use")]
		public string SharedMemoryName
		{
			get
			{
				return base.GetString("memname");
			}
		}

		[Category("Connection"), DefaultValue(false), Description("Allows the use of old style @ syntax for parameters")]
		public bool UseOldSyntax
		{
			get
			{
				return base.GetBool("oldsyntax");
			}
		}

		[Category("Authentication"), Description("The username to connect as")]
		public string UserId
		{
			get
			{
				return base.GetString("user id");
			}
		}

		[Category("Authentication"), Description("The password to use for authentication")]
		public string Password
		{
			get
			{
				return base.GetString("password");
			}
		}

		[Category("Authentication"), DefaultValue(false), Description("Show user password in connection string")]
		public bool PersistSecurityInfo
		{
			get
			{
				return base.GetBool("persist security info");
			}
		}

		[Category("Pooling"), DefaultValue(true), Description("Should the connection support pooling")]
		public bool Pooling
		{
			get
			{
				return base.GetBool("pooling");
			}
		}

		[Category("Pooling"), DefaultValue(0), Description("Minimum number of connections to have in this pool")]
		public int MinPoolSize
		{
			get
			{
				return base.GetInt("min pool size");
			}
		}

		[Category("Pooling"), DefaultValue(100), Description("Maximum number of connections to have in this pool")]
		public int MaxPoolSize
		{
			get
			{
				return base.GetInt("max pool size");
			}
		}

		[Category("Pooling"), DefaultValue(0), Description("Maximum number of seconds a connection should live.  This is checked when a connection is returned to the pool.")]
		public int ConnectionLifetime
		{
			get
			{
				return base.GetInt("connect lifetime");
			}
		}

		[Category("Pooling"), DefaultValue(true), Description("Should connections pulled from connection pools be reset")]
		public bool ResetPooledConnections
		{
			get
			{
				return base.GetBool("reset_pooled_conn");
			}
		}

		[Category("Other"), DefaultValue(false), Description("Should zero datetimes be supported")]
		public bool AllowZeroDateTime
		{
			get
			{
				return base.GetBool("allowzerodatetime");
			}
		}

		[Category("Other"), DefaultValue(false), Description("Should illegal datetime values be converted to DateTime.MinValue")]
		public bool ConvertZeroDateTime
		{
			get
			{
				return base.GetBool("convertzerodatetime");
			}
		}

		[Category("Other"), DefaultValue(null), Description("Character set this connection should use")]
		public string CharacterSet
		{
			get
			{
				return base.GetString("charset");
			}
		}

		[Category("Other"), DefaultValue(true), Description("Instructs the provider to ignore any attempts to prepare a command.")]
		public bool IgnorePrepare
		{
			get
			{
				return base.GetBool("ignore prepare");
			}
		}

		[Category("Advanced"), DefaultValue(25), Description("Indicates how many stored procedures can be cached at one time. A value of 0 effectively disables the procedure cache.")]
		public int ProcedureCacheSize
		{
			get
			{
				return base.GetInt("procedure cache size");
			}
		}

		[Category("Advanced"), DefaultValue(true), Description("Indicates if stored procedure bodies will be available for parameter detection.")]
		public bool UseProcedureBodies
		{
			get
			{
				return base.GetBool("procedure bodies");
			}
		}

		public MySqlConnectionString()
		{
		}

		public MySqlConnectionString(string connectString) : this()
		{
			base.SetConnectionString(connectString);
		}

		public string GetConnectionString(bool includePass)
		{
			if (this.connectString == null)
			{
				return string.Empty;
			}
			string text = this.connectString;
			if (!this.PersistSecurityInfo && !includePass)
			{
				text = this.RemovePassword(text);
			}
			return text;
		}

		private string RemovePassword(string connStr)
		{
			return base.RemoveKeys(connStr, new string[]
			{
				"password",
				"pwd"
			});
		}

		public string CreateConnectionString()
		{
			string text = string.Empty;
			Hashtable hashtable = (Hashtable)this.keyValues.Clone();
			Hashtable defaultValues = this.GetDefaultValues();
			if (!this.PersistSecurityInfo && hashtable.Contains("password"))
			{
				hashtable.Remove("password");
			}
			text = "server=" + hashtable["host"] + ";";
			hashtable.Remove("server");
			using (IEnumerator enumerator = hashtable.get_Keys().GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					string text2 = (string)enumerator.get_Current();
					if (hashtable[text2] != null && defaultValues[text2] != null && !hashtable[text2].Equals(defaultValues[text2]))
					{
						object obj = text;
						text = string.Concat(new object[]
						{
							obj,
							text2,
							"=",
							hashtable[text2],
							";"
						});
					}
				}
			}
			return text;
		}

		protected override Hashtable GetDefaultValues()
		{
			this.defaults = base.GetDefaultValues();
			if (this.defaults == null)
			{
				this.defaults = new Hashtable(new CaseInsensitiveHashCodeProvider(), new CaseInsensitiveComparer());
				this.defaults["host"] = string.Empty;
				this.defaults["connect lifetime"] = 0;
				this.defaults["user id"] = string.Empty;
				this.defaults["password"] = string.Empty;
				this.defaults["database"] = null;
				this.defaults["charset"] = null;
				this.defaults["pooling"] = true;
				this.defaults["min pool size"] = 0;
				this.defaults["protocol"] = ConnectionProtocol.Sockets;
				this.defaults["max pool size"] = 100;
				this.defaults["connect timeout"] = 15;
				this.defaults["port"] = 3306;
				this.defaults["useSSL"] = false;
				this.defaults["compress"] = false;
				this.defaults["persist security info"] = false;
				this.defaults["allow batch"] = true;
				this.defaults["logging"] = false;
				this.defaults["oldsyntax"] = false;
				this.defaults["pipeName"] = "MySQL";
				this.defaults["memname"] = "MYSQL";
				this.defaults["allowzerodatetime"] = false;
				this.defaults["convertzerodatetime"] = false;
				this.defaults["reset_pooled_conn"] = true;
				this.defaults["procedure cache size"] = 25;
				this.defaults["ignore prepare"] = true;
				this.defaults["procedure bodies"] = true;
			}
			return (Hashtable)this.defaults.Clone();
		}

		protected override bool ConnectionParameterParsed(Hashtable hash, string key, string value)
		{
			if (PrivateImplementationDetails.method0x600027e_1 == null)
			{
				Hashtable expr_18 = new Hashtable(44, 0.5f);
				expr_18.Add("procedure cache size", 0);
				expr_18.Add("connection reset", 1);
				expr_18.Add("character set", 2);
				expr_18.Add("charset", 3);
				expr_18.Add("use compression", 4);
				expr_18.Add("compress", 5);
				expr_18.Add("protocol", 6);
				expr_18.Add("pipe name", 7);
				expr_18.Add("pipe", 8);
				expr_18.Add("allow batch", 9);
				expr_18.Add("logging", 10);
				expr_18.Add("shared memory name", 11);
				expr_18.Add("old syntax", 12);
				expr_18.Add("oldsyntax", 13);
				expr_18.Add("convert zero datetime", 14);
				expr_18.Add("convertzerodatetime", 15);
				expr_18.Add("allow zero datetime", 16);
				expr_18.Add("allowzerodatetime", 17);
				expr_18.Add("ignore prepare", 18);
				expr_18.Add("procedure bodies", 19);
				expr_18.Add("use procedure bodies", 20);
				PrivateImplementationDetails.method0x600027e_1 = expr_18;
			}
			string text = key.ToLower();
			string text2 = value.Trim().ToLower();
			bool flag = text2 == "yes" || text2 == "true";
			object obj;
			if ((obj = text) != null && (obj = PrivateImplementationDetails.method0x600027e_1[obj]) != null)
			{
				switch ((int)obj)
				{
				case 0:
					hash["procedure cache size"] = int.Parse(text2);
					return true;
				case 1:
					hash["reset_pooled_conn"] = flag;
					return true;
				case 2:
				case 3:
					hash["charset"] = value;
					return true;
				case 4:
				case 5:
					hash["compress"] = flag;
					return true;
				case 6:
					if (value == "socket" || value == "tcp")
					{
						hash["protocol"] = ConnectionProtocol.Sockets;
						return true;
					}
					if (value == "pipe")
					{
						hash["protocol"] = ConnectionProtocol.NamedPipe;
						return true;
					}
					if (value == "unix")
					{
						hash["protocol"] = ConnectionProtocol.UnixSocket;
						return true;
					}
					if (value == "memory")
					{
						hash["protocol"] = ConnectionProtocol.SharedMemory;
						return true;
					}
					return true;
				case 7:
				case 8:
					hash["pipeName"] = value;
					return true;
				case 9:
					hash["allow batch"] = flag;
					return true;
				case 10:
					hash["logging"] = flag;
					return true;
				case 11:
					hash["memname"] = value;
					return true;
				case 12:
				case 13:
					hash["oldsyntax"] = flag;
					return true;
				case 14:
				case 15:
					hash["convertzerodatetime"] = flag;
					return true;
				case 16:
				case 17:
					hash["allowzerodatetime"] = flag;
					return true;
				case 18:
					hash["ignore prepare"] = flag;
					return true;
				case 19:
				case 20:
					hash["procedure bodies"] = flag;
					return true;
				}
			}
			if (!base.ConnectionParameterParsed(hash, key, value))
			{
				throw new ArgumentException(Resources.KeywordNotSupported, key);
			}
			return true;
		}
	}
}
