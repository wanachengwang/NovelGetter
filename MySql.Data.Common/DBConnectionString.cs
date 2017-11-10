using System;
using System.Collections;
using System.Globalization;
using System.Text;

namespace MySql.Data.Common
{
	internal abstract class DBConnectionString
	{
		protected Hashtable keyValues;

		protected string connectionName = string.Empty;

		protected string connectString;

		public DBConnectionString()
		{
			this.keyValues = new Hashtable(new CaseInsensitiveHashCodeProvider(), new CaseInsensitiveComparer());
		}

		public void LoadDefaultValues()
		{
			this.keyValues = this.GetDefaultValues();
		}

		public void SetConnectionString(string value)
		{
			Hashtable hashtable = this.Parse(value);
			this.connectString = value;
			this.keyValues = hashtable;
		}

		protected string GetString(string name)
		{
			if (!this.keyValues.ContainsKey(name))
			{
				return string.Empty;
			}
			if (this.keyValues[name] == null)
			{
				return string.Empty;
			}
			return this.keyValues[name] as string;
		}

		protected int GetInt(string name)
		{
			return Convert.ToInt32(this.keyValues[name], NumberFormatInfo.InvariantInfo);
		}

		protected bool GetBool(string name)
		{
			object obj = this.keyValues[name];
			return obj.Equals(true) || obj.Equals("true") || obj.Equals("yes") || obj.Equals(1);
		}

		protected string RemoveKeys(string value, string[] keys)
		{
			StringBuilder stringBuilder = new StringBuilder();
			ContextString contextString = new ContextString("\"'", false);
			string[] array = contextString.Split(value, ";");
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				string text = array2[i];
				string text2 = text.Trim().ToLower();
				if (!text2.StartsWith("pwd") && !text2.StartsWith("password"))
				{
					stringBuilder.Append(text);
					stringBuilder.Append(";");
				}
			}
			stringBuilder.Remove(stringBuilder.Length - 1, 1);
			return stringBuilder.ToString();
		}

		protected virtual bool ConnectionParameterParsed(Hashtable hash, string key, string value)
		{
			if (PrivateImplementationDetails.method0x600000d_1 == null)
			{
				Hashtable expr_18 = new Hashtable(48, 0.5f);
				expr_18.Add("persist security info", 0);
				expr_18.Add("uid", 1);
				expr_18.Add("username", 2);
				expr_18.Add("user id", 3);
				expr_18.Add("user name", 4);
				expr_18.Add("userid", 5);
				expr_18.Add("password", 6);
				expr_18.Add("pwd", 7);
				expr_18.Add("host", 8);
				expr_18.Add("server", 9);
				expr_18.Add("data source", 10);
				expr_18.Add("datasource", 11);
				expr_18.Add("address", 12);
				expr_18.Add("addr", 13);
				expr_18.Add("network address", 14);
				expr_18.Add("initial catalog", 15);
				expr_18.Add("database", 16);
				expr_18.Add("connection timeout", 17);
				expr_18.Add("connect timeout", 18);
				expr_18.Add("port", 19);
				expr_18.Add("pooling", 20);
				expr_18.Add("min pool size", 21);
				expr_18.Add("max pool size", 22);
				expr_18.Add("connection lifetime", 23);
				PrivateImplementationDetails.method0x600000d_1 = expr_18;
			}
			string text = key.ToLower(CultureInfo.InvariantCulture);
			object obj;
			if ((obj = text) != null && (obj = PrivateImplementationDetails.method0x600000d_1[obj]) != null)
			{
				switch ((int)obj)
				{
				case 0:
					hash["persist security info"] = value;
					return true;
				case 1:
				case 2:
				case 3:
				case 4:
				case 5:
					hash["user id"] = value;
					return true;
				case 6:
				case 7:
					hash["password"] = value;
					return true;
				case 8:
				case 9:
				case 10:
				case 11:
				case 12:
				case 13:
				case 14:
					hash["host"] = value;
					return true;
				case 15:
				case 16:
					hash["database"] = value;
					return true;
				case 17:
				case 18:
					hash["connect timeout"] = int.Parse(value, NumberFormatInfo.InvariantInfo);
					return true;
				case 19:
					hash["port"] = int.Parse(value, NumberFormatInfo.InvariantInfo);
					return true;
				case 20:
					hash["pooling"] = value.ToLower() == "yes" || value.ToLower() == "true";
					return true;
				case 21:
					hash["min pool size"] = int.Parse(value, NumberFormatInfo.InvariantInfo);
					return true;
				case 22:
					hash["max pool size"] = int.Parse(value, NumberFormatInfo.InvariantInfo);
					return true;
				case 23:
					hash["connect lifetime"] = int.Parse(value, NumberFormatInfo.InvariantInfo);
					return true;
				}
			}
			return false;
		}

		protected virtual Hashtable GetDefaultValues()
		{
			return null;
		}

		protected static Hashtable ParseKeyValuePairs(string src)
		{
			string[] array = src.Split(new char[]
			{
				';'
			});
			string[] array2 = new string[array.Length];
			int num = 0;
			string[] array3 = array;
			for (int i = 0; i < array3.Length; i++)
			{
				string text = array3[i];
				if (text.Length != 0)
				{
					if (text.IndexOf('=') >= 0)
					{
						array2[num++] = text;
					}
					else
					{
						string[] array4;
						IntPtr intPtr;
						(array4 = array2)[(int)(intPtr = (IntPtr)(num - 1))] = array4[(int)intPtr] + ";";
						(array4 = array2)[(int)(intPtr = (IntPtr)(num - 1))] = array4[(int)intPtr] + text;
					}
				}
			}
			Hashtable hashtable = new Hashtable();
			for (int j = 0; j < num; j++)
			{
				string[] array5 = array2[j].Split(new char[]
				{
					'='
				});
				array5[0] = array5[0].Trim().ToLower();
				array5[1] = array5[1].Trim();
				if (array5[1].Length >= 2)
				{
					if ((array5[1][0] == '"' && array5[1][array5[1].Length - 1] == '"') || (array5[1][0] == '\'' && array5[1][array5[1].Length - 1] == '\''))
					{
						array5[1] = array5[1].Substring(1, array5[1].Length - 2);
					}
				}
				else
				{
					array5[1] = array5[1];
				}
				array5[0] = array5[0].Trim(new char[]
				{
					'\'',
					'"'
				});
				hashtable[array5[0]] = array5[1];
			}
			return hashtable;
		}

		protected virtual Hashtable Parse(string newConnectString)
		{
			Hashtable hashtable = DBConnectionString.ParseKeyValuePairs(newConnectString);
			Hashtable defaultValues = this.GetDefaultValues();
            foreach(Object o in hashtable.Keys) {
                this.ConnectionParameterParsed(defaultValues, (string)o, (string)hashtable[o]);
            }
			return defaultValues;
		}
	}
}
