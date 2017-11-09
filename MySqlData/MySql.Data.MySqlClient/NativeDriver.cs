using MySql.Data.Common;
using MySql.Data.Types;
using System;
using System.Collections;
using System.IO;

namespace MySql.Data.MySqlClient
{
	internal class NativeDriver : Driver
	{
		public int MaxSinglePacket = 16581375;

		protected byte packetSeq;

		protected int protocol;

		protected string encryptionSeed;

		protected ClientFlags connectionFlags;

		protected PacketReader reader;

		protected PacketWriter writer;

		private BitArray nullMap;

		public ClientFlags Flags
		{
			get
			{
				return this.connectionFlags;
			}
		}

		public byte SequenceByte
		{
			get
			{
				return this.packetSeq;
			}
			set
			{
				this.packetSeq = value;
			}
		}

		public override bool SupportsBatch
		{
			get
			{
				if ((this.Flags & ClientFlags.MULTI_STATEMENTS) != (ClientFlags)0)
				{
					if (this.version.isAtLeast(4, 1, 0) && !this.version.isAtLeast(4, 1, 10))
					{
						object obj = this.serverProps["query_cache_type"];
						object obj2 = this.serverProps["query_cache_size"];
						if (obj != null && obj.Equals("ON") && obj2 != null && !obj2.Equals("0"))
						{
							return false;
						}
					}
					return true;
				}
				return false;
			}
		}

		public NativeDriver(MySqlConnectionString settings) : base(settings)
		{
			this.packetSeq = 0;
			this.isOpen = false;
			this.maxPacketSize = 1047552L;
		}

		~NativeDriver()
		{
			this.Close();
		}

		private void ExecuteCommand(DBCmd cmd, byte[] bytes, int length)
		{
			try
			{
				this.SequenceByte = 0;
				int num = 1;
				if (bytes != null)
				{
					num += length;
				}
				this.writer.StartPacket((long)num);
				this.writer.WriteByte((byte)cmd);
				if (bytes != null)
				{
					this.writer.Write(bytes, 0, length);
				}
				this.writer.Flush();
			}
			catch (MySqlException ex)
			{
				if (ex.IsFatal)
				{
					this.isOpen = false;
					this.Close();
				}
				throw;
			}
		}

		public override void SetDatabase(string dbName)
		{
			byte[] bytes = base.Encoding.GetBytes(dbName);
			this.ExecuteCommand(DBCmd.INIT_DB, bytes, bytes.Length);
			if (!this.reader.ReadOk())
			{
				throw new MySqlException("Failure setting database <" + dbName + ">");
			}
		}

		public string GetString(byte[] stringBuffer)
		{
			if (stringBuffer == null)
			{
				return string.Empty;
			}
			return this.encoding.GetString(stringBuffer);
		}

		public byte[] GetBytes(string s)
		{
			return this.encoding.GetBytes(s);
		}

		public override void Open()
		{
			base.Open();
			Stream stream;
			try
			{
				if (base.Settings.Protocol == ConnectionProtocol.SharedMemory)
				{
					SharedMemoryStream sharedMemoryStream = new SharedMemoryStream(base.Settings.SharedMemoryName);
					sharedMemoryStream.Open(base.Settings.ConnectionTimeout);
					stream = sharedMemoryStream;
				}
				else
				{
					string pipeName = base.Settings.PipeName;
					if (base.Settings.Protocol != ConnectionProtocol.NamedPipe)
					{
						pipeName = null;
					}
					StreamCreator streamCreator = new StreamCreator(base.Settings.Server, base.Settings.Port, pipeName);
					stream = streamCreator.GetStream((uint)base.Settings.ConnectionTimeout);
				}
				if (stream == null)
				{
					throw new Exception();
				}
			}
			catch (Exception inner)
			{
				throw new MySqlException(Resources.UnableToConnectToHost, 1042, inner);
			}
			if (stream == null)
			{
				throw new MySqlException("Unable to connect to any of the specified MySQL hosts");
			}
			this.reader = new PacketReader(new BufferedStream(stream), this);
			this.writer = new PacketWriter(new BufferedStream(stream), this);
			this.writer.Encoding = this.encoding;
			this.reader.OpenPacket();
			this.protocol = this.reader.ReadByte();
			string versionString = this.reader.ReadString();
			this.version = DBVersion.Parse(versionString);
			this.threadId = this.reader.ReadInteger(4);
			this.encryptionSeed = this.reader.ReadString();
			if (this.version.isAtLeast(4, 0, 8))
			{
				this.MaxSinglePacket = 16777215;
			}
			this.serverCaps = (ClientFlags)0;
			if (this.reader.HasMoreData)
			{
				this.serverCaps = (ClientFlags)this.reader.ReadInteger(2);
			}
			this.SetConnectionFlags();
			this.writer.StartPacket(0L);
			this.writer.WriteInteger((long)this.connectionFlags, this.version.isAtLeast(4, 1, 0) ? 4 : 2);
			this.writer.WriteInteger((long)this.MaxSinglePacket, this.version.isAtLeast(4, 1, 0) ? 4 : 3);
			if (this.version.isAtLeast(4, 1, 1))
			{
				this.serverLanguage = this.reader.ReadInteger(1);
				this.serverStatus = (ServerStatusFlags)this.reader.ReadInteger(2);
				this.reader.Skip(13L);
				string text = this.reader.ReadString();
				this.encryptionSeed += text;
				this.writer.WriteByte(8);
				this.writer.Write(new byte[23], 0, 23);
			}
			this.Authenticate();
			if ((this.connectionFlags & ClientFlags.COMPRESS) != (ClientFlags)0)
			{
				this.writer = new PacketWriter(new BufferedStream(new CompressedStream(stream)), this);
				this.writer.Encoding = this.encoding;
				this.reader = new PacketReader(new BufferedStream(new CompressedStream(stream)), this);
			}
			this.isOpen = true;
		}

		private void SetConnectionFlags()
		{
			ClientFlags clientFlags = ClientFlags.FOUND_ROWS;
			if (this.version.isAtLeast(4, 1, 1))
			{
				clientFlags |= ClientFlags.PROTOCOL_41;
				clientFlags |= ClientFlags.TRANSACTIONS;
				if (this.connectionString.AllowBatch)
				{
					clientFlags |= ClientFlags.MULTI_STATEMENTS;
				}
				clientFlags |= ClientFlags.MULTI_RESULTS;
			}
			else if (this.version.isAtLeast(4, 1, 0))
			{
				clientFlags |= ClientFlags.RESERVED;
			}
			if ((this.serverCaps & ClientFlags.LONG_FLAG) != (ClientFlags)0)
			{
				clientFlags |= ClientFlags.LONG_FLAG;
			}
			if ((this.serverCaps & ClientFlags.COMPRESS) != (ClientFlags)0 && this.connectionString.UseCompression)
			{
				clientFlags |= ClientFlags.COMPRESS;
			}
			if (this.protocol > 9)
			{
				clientFlags |= ClientFlags.LONG_PASSWORD;
			}
			else
			{
				clientFlags &= ~ClientFlags.LONG_PASSWORD;
			}
			clientFlags |= ClientFlags.LOCAL_FILES;
			if ((this.serverCaps & ClientFlags.CONNECT_WITH_DB) != (ClientFlags)0 && this.connectionString.Database != null && this.connectionString.Database.Length > 0)
			{
				clientFlags |= ClientFlags.CONNECT_WITH_DB;
			}
			if ((this.serverCaps & ClientFlags.SECURE_CONNECTION) != (ClientFlags)0)
			{
				clientFlags |= ClientFlags.SECURE_CONNECTION;
			}
			this.connectionFlags = clientFlags;
		}

		private void Authenticate411()
		{
			if ((this.connectionFlags & ClientFlags.SECURE_CONNECTION) == (ClientFlags)0)
			{
				this.AuthenticateOld();
			}
			this.writer.Write(Crypt.Get411Password(this.connectionString.Password, this.encryptionSeed));
			if ((this.connectionFlags & ClientFlags.CONNECT_WITH_DB) != (ClientFlags)0 && this.connectionString.Database != null)
			{
				this.writer.WriteString(this.connectionString.Database);
			}
			this.writer.Flush();
			this.reader.OpenPacket();
			if (this.reader.IsLastPacket)
			{
				this.writer.StartPacket(0L);
				this.writer.WriteString(Crypt.EncryptPassword(this.connectionString.Password, this.encryptionSeed.Substring(0, 8), true));
				this.writer.Flush();
				this.reader.ReadOk();
			}
		}

		private void AuthenticateOld()
		{
			this.writer.WriteString(Crypt.EncryptPassword(this.connectionString.Password, this.encryptionSeed, this.protocol > 9));
			if ((this.connectionFlags & ClientFlags.CONNECT_WITH_DB) != (ClientFlags)0 && this.connectionString.Database != null)
			{
				this.writer.WriteString(this.connectionString.Database);
			}
			this.writer.Flush();
			this.reader.ReadOk();
		}

		public void Authenticate()
		{
			this.writer.WriteString(this.connectionString.UserId);
			if (this.version.isAtLeast(4, 1, 1))
			{
				this.Authenticate411();
				return;
			}
			this.AuthenticateOld();
		}

		public override void Reset()
		{
			this.SequenceByte = 0;
			this.writer.StartPacket(0L);
			this.writer.WriteByte(17);
			this.Authenticate();
		}

		public override CommandResult SendQuery(byte[] bytes, int length, bool consume)
		{
			if (base.Settings.Logging)
			{
				Logger.LogCommand(DBCmd.QUERY, this.encoding.GetString(bytes, 0, length));
			}
			this.ExecuteCommand(DBCmd.QUERY, bytes, length);
			return new CommandResult(this, false);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				try
				{
					if (this.isOpen)
					{
						this.ExecuteCommand(DBCmd.QUIT, null, 0);
						this.writer.Stream.Close();
						this.reader.Stream.Close();
					}
				}
				catch (Exception)
				{
				}
			}
			base.Dispose(disposing);
		}

		public override bool Ping()
		{
			bool result;
			try
			{
				this.ExecuteCommand(DBCmd.PING, null, 0);
				result = this.reader.ReadOk();
			}
			catch (Exception)
			{
				this.isOpen = false;
				result = false;
			}
			return result;
		}

		public override long ReadResult(ref long affectedRows, ref long lastInsertId)
		{
			this.reader.OpenPacket();
			long fieldLength = this.reader.GetFieldLength();
			if (fieldLength > 0L)
			{
				affectedRows = -1L;
				return fieldLength;
			}
			if (-1L == fieldLength)
			{
				string filename = this.reader.ReadString();
				this.SendFileToServer(filename);
				this.reader.OpenPacket();
				fieldLength = this.reader.GetFieldLength();
			}
			affectedRows = this.reader.GetFieldLength();
			lastInsertId = this.reader.GetFieldLength();
			if (this.version.isAtLeast(4, 1, 0))
			{
				this.serverStatus = (ServerStatusFlags)this.reader.ReadInteger(2);
				this.hasWarnings = (this.reader.ReadInteger(2) != 0);
				if (this.reader.HasMoreData)
				{
					this.reader.ReadLenString();
				}
			}
			return 0L;
		}

		private void SendFileToServer(string filename)
		{
			byte[] array = new byte[4092];
			FileStream fileStream = null;
			try
			{
				fileStream = new FileStream(filename, 3);
				this.writer.StartPacket(fileStream.Length);
				int num2;
				for (long num = fileStream.Length; num > 0L; num -= (long)num2)
				{
					num2 = fileStream.Read(array, 0, 4092);
					this.writer.Write(array, 0, num2);
				}
				this.writer.Flush();
				this.writer.Buffering = false;
				this.writer.WriteInteger(0L, 3);
				PacketWriter arg_A2_0 = this.writer;
				byte sequenceByte;
				this.SequenceByte = (sequenceByte = this.SequenceByte) + 1;
				arg_A2_0.WriteByte(sequenceByte);
				this.writer.Flush();
			}
			catch (Exception ex)
			{
				throw new MySqlException("Error during LOAD DATA LOCAL INFILE", ex);
			}
			finally
			{
				fileStream.Close();
			}
		}

		public override bool OpenDataRow(int fieldCount, bool isBinary)
		{
			this.reader.OpenPacket();
			if (this.reader.IsLastPacket)
			{
				this.ReadEOF(false);
				return false;
			}
			this.nullMap = null;
			if (isBinary)
			{
				this.ReadNullMap(fieldCount);
			}
			return true;
		}

		private void ReadNullMap(int fieldCount)
		{
			this.nullMap = null;
			byte[] array = new byte[(fieldCount + 9) / 8];
			this.reader.ReadByte();
			this.reader.Read(ref array, 0L, (long)array.Length);
			this.nullMap = new BitArray(array);
		}

		public override MySqlValue ReadFieldValue(int index, MySqlField field, MySqlValue valObject)
		{
			long num = -1L;
			if (this.nullMap != null)
			{
				valObject.IsNull = this.nullMap.get_Item(index + 2);
			}
			else
			{
				num = this.reader.GetFieldLength();
				valObject.IsNull = (num == -1L);
			}
			if (valObject.IsNull)
			{
				return valObject;
			}
			this.reader.Encoding = field.Encoding;
			return valObject.ReadValue(this.reader, num);
		}

		public override void SkipField(MySqlValue valObject)
		{
			long num = -1L;
			if (this.nullMap == null)
			{
				num = this.reader.GetFieldLength();
				if (num == -1L)
				{
					return;
				}
			}
			if (num > -1L)
			{
				this.reader.Skip((long)((int)num));
				return;
			}
			valObject.Skip(this.reader);
		}

		public override void ReadFieldMetadata(int count, ref MySqlField[] fields)
		{
			fields = new MySqlField[count];
			for (int i = 0; i < count; i++)
			{
				fields[i] = this.GetFieldMetaData();
			}
			this.ReadEOF(true);
		}

		private MySqlField GetFieldMetaData()
		{
			MySqlField mySqlField;
			if (this.version.isAtLeast(4, 1, 0))
			{
				mySqlField = this.GetFieldMetaData41();
			}
			else
			{
				this.reader.OpenPacket();
				mySqlField = new MySqlField(base.Version);
				mySqlField.Encoding = this.encoding;
				mySqlField.TableName = (mySqlField.RealTableName = this.reader.ReadLenString());
				mySqlField.ColumnName = this.reader.ReadLenString();
				mySqlField.ColumnLength = this.reader.ReadNBytes();
				MySqlDbType type = (MySqlDbType)this.reader.ReadNBytes();
				this.reader.ReadByte();
				ColumnFlags flags;
				if ((this.Flags & ClientFlags.LONG_FLAG) != (ClientFlags)0)
				{
					flags = (ColumnFlags)this.reader.ReadInteger(2);
				}
				else
				{
					flags = (ColumnFlags)this.reader.ReadByte();
				}
				mySqlField.SetTypeAndFlags(type, flags);
				mySqlField.Scale = (byte)this.reader.ReadByte();
				if (!this.version.isAtLeast(3, 23, 15) && this.version.isAtLeast(3, 23, 0))
				{
					MySqlField expr_F8 = mySqlField;
					expr_F8.Scale += 1;
				}
			}
			return mySqlField;
		}

		private MySqlField GetFieldMetaData41()
		{
			MySqlField mySqlField = new MySqlField(base.Version);
			this.reader.OpenPacket();
			mySqlField.Encoding = this.encoding;
			mySqlField.CatalogName = this.reader.ReadLenString();
			mySqlField.DatabaseName = this.reader.ReadLenString();
			mySqlField.TableName = this.reader.ReadLenString();
			mySqlField.RealTableName = this.reader.ReadLenString();
			mySqlField.ColumnName = this.reader.ReadLenString();
			mySqlField.OriginalColumnName = this.reader.ReadLenString();
			this.reader.ReadByte();
			mySqlField.CharacterSetIndex = this.reader.ReadInteger(2);
			mySqlField.ColumnLength = this.reader.ReadInteger(4);
			MySqlDbType type = (MySqlDbType)this.reader.ReadByte();
			ColumnFlags flags;
			if ((this.Flags & ClientFlags.LONG_FLAG) != (ClientFlags)0)
			{
				flags = (ColumnFlags)this.reader.ReadInteger(2);
			}
			else
			{
				flags = (ColumnFlags)this.reader.ReadByte();
			}
			mySqlField.SetTypeAndFlags(type, flags);
			mySqlField.Scale = (byte)this.reader.ReadByte();
			if (this.charSets != null)
			{
				CharacterSet chararcterSet = CharSetMap.GetChararcterSet(base.Version, (string)this.charSets[mySqlField.CharacterSetIndex]);
				mySqlField.MaxLength = chararcterSet.byteCount;
				mySqlField.Encoding = CharSetMap.GetEncoding(this.version, (string)this.charSets[mySqlField.CharacterSetIndex]);
			}
			return mySqlField;
		}

		public override CommandResult ExecuteStatement(byte[] bytes)
		{
			this.ExecuteCommand(DBCmd.EXECUTE, bytes, bytes.Length);
			return new CommandResult(this, true);
		}

		private void ReadEOF(bool readPacket)
		{
			if (readPacket)
			{
				this.reader.OpenPacket();
			}
			if (!this.reader.IsLastPacket)
			{
				throw new MySqlException("Expected end of data packet");
			}
			this.reader.ReadByte();
			if (this.reader.HasMoreData && this.version.isAtLeast(4, 1, 0))
			{
				int num = this.reader.ReadInteger(2);
				this.hasWarnings = (num != 0);
				this.serverStatus = (ServerStatusFlags)this.reader.ReadInteger(2);
			}
		}

		public override PreparedStatement Prepare(string sql, string[] parmNames)
		{
			byte[] bytes = this.encoding.GetBytes(sql);
			this.ExecuteCommand(DBCmd.PREPARE, bytes, bytes.Length);
			this.reader.OpenPacket();
			int num = this.reader.ReadByte();
			if (num != 0)
			{
				throw new MySqlException("Expected prepared statement marker");
			}
			int statementId = this.reader.ReadInteger(4);
			int num2 = this.reader.ReadInteger(2);
			int num3 = this.reader.ReadInteger(2);
			MySqlField[] array = new MySqlField[num3];
			if (num3 > 0)
			{
				this.ReadFieldMetadata(num3, ref array);
				for (int i = 0; i < array.Length; i++)
				{
					array[i].Encoding = this.encoding;
				}
				if (parmNames.Length != array.Length)
				{
					throw new MySqlException("Incorrect number of parameters received for prepared statement");
				}
				for (int j = 0; j < parmNames.Length; j++)
				{
					array[j].ColumnName = parmNames[j];
				}
			}
			if (num2 > 0)
			{
				while (num2-- > 0)
				{
					this.reader.OpenPacket();
				}
				this.ReadEOF(true);
			}
			return new PreparedStatement(this, statementId, array);
		}
	}
}
