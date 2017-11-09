using MySql.Data.MySqlClient;
using System;
using System.IO;
using System.Text;

namespace MySql.Data.Types
{
	internal class MySqlString : MySqlValue
	{
		public string Value
		{
			get
			{
				return this.objectValue as string;
			}
			set
			{
				this.objectValue = value;
			}
		}

		internal override Type SystemType
		{
			get
			{
				return typeof(string);
			}
		}

		public MySqlString(string val, MySqlDbType type)
		{
			this.Value = val;
			this.mySqlDbType = type;
		}

		private string EscapeString(string s)
		{
			s = s.Replace("\\", "\\\\");
			s = s.Replace("'", "\\'");
			s = s.Replace("\"", "\\\"");
			s = s.Replace("`", "\\`");
			return s;
		}

		internal override void Serialize(PacketWriter writer, bool binary, object value, int length)
		{
			string text = value.ToString();
			if (length > 0)
			{
				text = text.Substring(0, length);
			}
			if (binary)
			{
				writer.WriteLenString(text);
				return;
			}
			writer.WriteStringNoNull("'" + this.EscapeString(text) + "'");
		}

		public byte[] ToBytes(Encoding encoding)
		{
			PacketWriter packetWriter = new PacketWriter();
			packetWriter.Encoding = encoding;
			packetWriter.WriteLenString(this.Value);
			MemoryStream memoryStream = packetWriter.Stream as MemoryStream;
			byte[] array = new byte[memoryStream.Length];
			Array.Copy(memoryStream.GetBuffer(), 0, array, 0, (int)memoryStream.Length);
			return array;
		}

		internal override string GetMySqlTypeName()
		{
			switch (this.mySqlDbType)
			{
			case MySqlDbType.Enum:
				return "ENUM";
			case MySqlDbType.Set:
				return "SET";
			default:
				return "VARCHAR";
			}
		}

		internal override MySqlValue ReadValue(PacketReader reader, long length)
		{
			string val = string.Empty;
			if (length == -1L)
			{
				val = reader.ReadLenString();
			}
			else
			{
				val = reader.ReadString(length);
			}
			return new MySqlString(val, this.mySqlDbType);
		}

		internal override void Skip(PacketReader reader)
		{
			long fieldLength = reader.GetFieldLength();
			reader.Skip(fieldLength);
		}
	}
}
