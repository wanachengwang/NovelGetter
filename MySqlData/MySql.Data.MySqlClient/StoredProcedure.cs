using MySql.Data.Common;
using System;
using System.Collections;
using System.Data.SqlTypes;
using System.Globalization;

namespace MySql.Data.MySqlClient
{
	internal class StoredProcedure
	{
		private string hash;

		private MySqlConnection connection;

		private string outSelect;

		public StoredProcedure(MySqlConnection conn)
		{
			this.hash = ((uint)DateTime.get_Now().GetHashCode()).ToString();
			this.connection = conn;
		}

		private MySqlParameter GetReturnParameter(IEnumerable parms)
		{
			using (IEnumerator enumerator = parms.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					MySqlParameter mySqlParameter = (MySqlParameter)enumerator.get_Current();
					if (mySqlParameter.Direction == 6)
					{
						return mySqlParameter;
					}
				}
			}
			return null;
		}

		private string CleanSymbol(string name)
		{
			if (!name.StartsWith("`"))
			{
				return name;
			}
			name = name.Remove(0, 1);
			name = name.Remove(name.Length - 1, 1);
			return name;
		}

		private string GetRoutineType(ref string spName)
		{
			int num = spName.IndexOf('.');
			string text = null;
			if (num != -1)
			{
				text = this.CleanSymbol(spName.Substring(0, num));
			}
			if (text != null && !(text == string.Empty))
			{
				text = string.Format("'{0}'", text);
			}
			else
			{
				text = "database()";
			}
			string text2 = this.CleanSymbol(spName.Substring(num + 1));
			MySqlCommand mySqlCommand = new MySqlCommand(string.Format("SELECT ROUTINE_SCHEMA, ROUTINE_TYPE FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_SCHEMA={0} AND ROUTINE_NAME='{1}'", text, text2), this.connection);
			MySqlDataReader mySqlDataReader = null;
			string @string;
			try
			{
				mySqlDataReader = mySqlCommand.ExecuteReader();
				mySqlDataReader.Read();
				object value = mySqlDataReader.GetValue(0);
				if (text == "database()")
				{
					spName = string.Format("`{0}`.`{1}`", value.ToString(), text2);
				}
				@string = mySqlDataReader.GetString(1);
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
			return @string;
		}

		private string GetProcedureBody(string spName, out string sql_mode, out bool isFunc)
		{
			sql_mode = string.Empty;
			string routineType = this.GetRoutineType(ref spName);
			if (routineType == null)
			{
				throw new MySqlException("Procedure or function '" + spName + "' does not exist.");
			}
			MySqlDataReader mySqlDataReader = null;
			string @string;
			try
			{
				MySqlCommand mySqlCommand = new MySqlCommand(string.Format("SHOW CREATE {0} {1}", routineType, spName), this.connection);
				isFunc = (routineType.ToLower(CultureInfo.InvariantCulture) == "function");
				mySqlCommand.CommandText = string.Format("SHOW CREATE {0} {1}", routineType, spName);
				mySqlDataReader = mySqlCommand.ExecuteReader();
				mySqlDataReader.Read();
				sql_mode = mySqlDataReader.GetString(1);
				@string = mySqlDataReader.GetString(2);
			}
			catch (SqlNullValueException ex)
			{
				throw new InvalidOperationException(Resources.UnableToRetrieveSProcData, ex);
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
			return @string;
		}

		private string CleanParameterName(string parameter, bool stripMarker)
		{
			char c = parameter[0];
			if (c == '`' || c == '\'' || c == '"')
			{
				parameter = parameter.Substring(1, parameter.Length - 2);
			}
			if (stripMarker && parameter[0] == this.connection.ParameterMarker)
			{
				parameter = parameter.Substring(1);
			}
			return parameter;
		}

		private int FindRightParen(string body, string quotePattern)
		{
			int num = 0;
			bool flag = false;
			char c = '\0';
			for (int i = 0; i < body.Length; i++)
			{
				char c2 = body[i];
				if (c2 == ')')
				{
					if (flag)
					{
						flag = false;
					}
					else if (c == '\0')
					{
						break;
					}
				}
				else if (c2 == '(' && c == '\0')
				{
					flag = true;
				}
				else
				{
					int num2 = quotePattern.IndexOf(c2);
					if (num2 > -1)
					{
						if (c == '\0')
						{
							c = c2;
						}
						else if (c == c2)
						{
							c = '\0';
						}
					}
				}
				num++;
			}
			return num;
		}

		private ArrayList ParseBody(string body, string sqlMode)
		{
			bool flag = sqlMode.IndexOf("ANSI_QUOTES") != -1;
			bool flag2 = sqlMode.IndexOf("NO_BACKSLASH_ESCAPES") != -1;
			string text = flag ? "``\"\"" : "``";
			ContextString contextString = new ContextString(text, !flag2);
			int num = contextString.IndexOf(body, '(');
			body = body.Substring(num + 1);
			int num2 = this.FindRightParen(body, text);
			string src = body.Substring(0, num2).Trim();
			ContextString expr_71 = contextString;
			expr_71.ContextMarkers += "()";
			ArrayList arrayList = new ArrayList();
			string[] array = contextString.Split(src, ",");
			if (array.Length > 0)
			{
				string[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					string parmDef = array2[i];
					arrayList.Add(this.ParseParameter(parmDef, contextString, sqlMode));
				}
			}
			body = body.Substring(num2 + 1).Trim().ToLower(CultureInfo.InvariantCulture);
			if (body.StartsWith("returns"))
			{
				arrayList.Add(this.ParseParameter(body, contextString, sqlMode));
			}
			return arrayList;
		}

		private MySqlParameter ParseParameter(string parmDef, ContextString cs, string sqlMode)
		{
			MySqlParameter mySqlParameter = new MySqlParameter();
			parmDef = parmDef.Trim();
			string text = parmDef.ToLower(CultureInfo.InvariantCulture);
			if (text.StartsWith("inout "))
			{
				mySqlParameter.Direction = 3;
				parmDef = parmDef.Substring(6);
			}
			else if (text.StartsWith("in "))
			{
				parmDef = parmDef.Substring(3);
			}
			else if (text.StartsWith("out "))
			{
				mySqlParameter.Direction = 2;
				parmDef = parmDef.Substring(4);
			}
			else if (text.StartsWith("returns "))
			{
				mySqlParameter.Direction = 6;
				parmDef = parmDef.Substring(8);
			}
			parmDef = parmDef.Trim();
			string[] array = cs.Split(parmDef, " \t\r\n");
			if (mySqlParameter.Direction != 6)
			{
				mySqlParameter.ParameterName = string.Format("{0}{1}", this.connection.ParameterMarker, this.CleanParameterName(array[0], false));
				parmDef = parmDef.Substring(array[0].Length);
			}
			else
			{
				text = parmDef.ToLower(CultureInfo.InvariantCulture);
				parmDef = parmDef.Substring(0, text.IndexOf("begin"));
				mySqlParameter.ParameterName = string.Format("{0}RETURN_VALUE", this.connection.ParameterMarker);
			}
			this.ParseType(parmDef, sqlMode, mySqlParameter);
			return mySqlParameter;
		}

		public ArrayList DiscoverParameters(string spName)
		{
			string sqlMode;
			bool flag;
			string procedureBody = this.GetProcedureBody(spName, out sqlMode, out flag);
			return this.ParseBody(procedureBody, sqlMode);
		}

		private string StripParameterName(string name)
		{
			if (name[0] == this.connection.ParameterMarker)
			{
				return name.Remove(0, 1);
			}
			return name;
		}

		private IEnumerable GetParameters(MySqlConnection connection, MySqlCommand cmd)
		{
			if (connection.Settings.UseProcedureBodies)
			{
				return connection.ProcedureCache.GetProcedure(connection, cmd.CommandText);
			}
			using (IEnumerator enumerator = cmd.Parameters.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					MySqlParameter mySqlParameter = (MySqlParameter)enumerator.get_Current();
					if (!mySqlParameter.TypeHasBeenSet)
					{
						throw new InvalidOperationException(Resources.NoBodiesAndTypeNotSet);
					}
				}
			}
			return cmd.Parameters;
		}

		public string Prepare(MySqlCommand cmd)
		{
			MySqlParameter returnParameter = this.GetReturnParameter(cmd.Parameters);
			string result;
			try
			{
				IEnumerable parameters = this.GetParameters(this.connection, cmd);
				bool flag = this.GetReturnParameter(parameters) != null;
				string text = string.Empty;
				string text2 = string.Empty;
				this.outSelect = string.Empty;
				using (IEnumerator enumerator = parameters.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						MySqlParameter mySqlParameter = (MySqlParameter)enumerator.get_Current();
						if (mySqlParameter.Direction != 6)
						{
							int num = cmd.Parameters.IndexOf(mySqlParameter.ParameterName);
							if (num == -1)
							{
								throw new MySqlException("Parameter '" + mySqlParameter.ParameterName + "' is not defined");
							}
							MySqlParameter mySqlParameter2 = cmd.Parameters[num];
							if (!mySqlParameter2.TypeHasBeenSet)
							{
								mySqlParameter2.MySqlDbType = mySqlParameter.MySqlDbType;
							}
							string text3 = this.StripParameterName(mySqlParameter2.ParameterName);
							string text4 = this.connection.ParameterMarker + text3;
							string text5 = "@" + this.hash + text3;
							if (mySqlParameter2.Direction == 1)
							{
								text = text + text4 + ", ";
							}
							else
							{
								if (mySqlParameter2.Direction == 3)
								{
									string text6 = text2;
									text2 = string.Concat(new string[]
									{
										text6,
										"set ",
										text5,
										"=",
										text4,
										";"
									});
								}
								text = text + text5 + ", ";
								this.outSelect = this.outSelect + text5 + ", ";
							}
						}
					}
				}
				if (!flag)
				{
					text = "call " + cmd.CommandText + "(" + text;
				}
				else
				{
					string text7 = "@" + this.hash + "dummy";
					if (returnParameter != null)
					{
						string text8 = this.CleanParameterName(returnParameter.ParameterName, true);
						text7 = "@" + this.hash + text8;
						this.outSelect = text7 + this.outSelect;
					}
					text = string.Concat(new string[]
					{
						"set ",
						text7,
						"=",
						cmd.CommandText,
						"(",
						text
					});
				}
				text = text.TrimEnd(new char[]
				{
					' ',
					','
				});
				this.outSelect = this.outSelect.TrimEnd(new char[]
				{
					' ',
					','
				});
				text += ")";
				if (text2.Length > 0)
				{
					text = text2 + text;
				}
				result = text;
			}
			catch (InvalidOperationException)
			{
				throw;
			}
			catch (Exception ex)
			{
				throw new MySqlException("Exception during execution of '" + cmd.CommandText + "': " + ex.get_Message(), ex);
			}
			return result;
		}

		public void UpdateParameters(MySqlParameterCollection parameters)
		{
			if (this.outSelect.Length == 0)
			{
				return;
			}
			char parameterMarker = this.connection.ParameterMarker;
			MySqlCommand mySqlCommand = new MySqlCommand("SELECT " + this.outSelect, this.connection);
			MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
			for (int i = 0; i < mySqlDataReader.FieldCount; i++)
			{
				string text = mySqlDataReader.GetName(i);
				text = parameterMarker + text.Remove(0, this.hash.Length + 1);
				mySqlDataReader.CurrentResult[i] = parameters[text].GetValueObject();
			}
			mySqlDataReader.Read();
			for (int j = 0; j < mySqlDataReader.FieldCount; j++)
			{
				string text2 = mySqlDataReader.GetName(j);
				text2 = parameterMarker + text2.Remove(0, this.hash.Length + 1);
				parameters[text2].Value = mySqlDataReader.GetValue(j);
			}
			mySqlDataReader.Close();
		}

		private void ParseType(string type, string sql_mode, MySqlParameter p)
		{
			string text = string.Empty;
			type = type.ToLower(CultureInfo.InvariantCulture).Trim();
			int num = type.IndexOf("(");
			int num2;
			if (num != -1)
			{
				num2 = type.IndexOf(')', num + 1);
			}
			else
			{
				num = (num2 = type.IndexOf(' '));
			}
			if (num == -1)
			{
				num = type.Length;
			}
			string typeName = type.Substring(0, num);
			if (num2 != -1)
			{
				text = type.Substring(num2 + 1);
			}
			bool unsigned = text.IndexOf("unsigned") != -1;
			bool realAsFloat = sql_mode.IndexOf("REAL_AS_FLOAT") != -1;
			p.MySqlDbType = this.GetTypeFromName(typeName, unsigned, realAsFloat);
			if (num2 > num && p.MySqlDbType != MySqlDbType.Set && p.MySqlDbType != MySqlDbType.Enum)
			{
				string text2 = type.Substring(num + 1, num2 - (num + 1));
				string[] array = text2.Split(new char[]
				{
					','
				});
				p.Size = int.Parse(array[0]);
				if (p.MySqlDbType == MySqlDbType.Decimal)
				{
					p.Precision = (byte)p.Size;
					p.Size = 0;
					if (array.Length > 1)
					{
						p.Scale = byte.Parse(array[1]);
					}
				}
			}
		}

		private MySqlDbType GetTypeFromName(string typeName, bool unsigned, bool realAsFloat)
		{
			if (PrivateImplementationDetails.method0x600043e_1 == null)
			{
				Hashtable expr_18 = new Hashtable(68, 0.5f);
				expr_18.Add("char", 0);
				expr_18.Add("varchar", 1);
				expr_18.Add("date", 2);
				expr_18.Add("datetime", 3);
				expr_18.Add("numeric", 4);
				expr_18.Add("decimal", 5);
				expr_18.Add("dec", 6);
				expr_18.Add("fixed", 7);
				expr_18.Add("year", 8);
				expr_18.Add("time", 9);
				expr_18.Add("timestamp", 10);
				expr_18.Add("set", 11);
				expr_18.Add("enum", 12);
				expr_18.Add("bit", 13);
				expr_18.Add("tinyint", 14);
				expr_18.Add("bool", 15);
				expr_18.Add("boolean", 16);
				expr_18.Add("smallint", 17);
				expr_18.Add("mediumint", 18);
				expr_18.Add("int", 19);
				expr_18.Add("integer", 20);
				expr_18.Add("serial", 21);
				expr_18.Add("bigint", 22);
				expr_18.Add("float", 23);
				expr_18.Add("double", 24);
				expr_18.Add("real", 25);
				expr_18.Add("blob", 26);
				expr_18.Add("text", 27);
				expr_18.Add("longblob", 28);
				expr_18.Add("longtext", 29);
				expr_18.Add("mediumblob", 30);
				expr_18.Add("mediumtext", 31);
				expr_18.Add("tinyblob", 32);
				expr_18.Add("tinytext", 33);
				PrivateImplementationDetails.method0x600043e_1 = expr_18;
			}
			object obj;
			if (typeName != null && (obj = PrivateImplementationDetails.method0x600043e_1[typeName]) != null)
			{
				switch ((int)obj)
				{
				case 0:
					return MySqlDbType.Char;
				case 1:
					return MySqlDbType.VarChar;
				case 2:
					return MySqlDbType.Date;
				case 3:
					return MySqlDbType.Datetime;
				case 4:
				case 5:
				case 6:
				case 7:
					if (this.connection.driver.Version.isAtLeast(5, 0, 3))
					{
						return MySqlDbType.NewDecimal;
					}
					return MySqlDbType.Decimal;
				case 8:
					return MySqlDbType.Year;
				case 9:
					return MySqlDbType.Time;
				case 10:
					return MySqlDbType.Timestamp;
				case 11:
					return MySqlDbType.Set;
				case 12:
					return MySqlDbType.Enum;
				case 13:
					return MySqlDbType.Bit;
				case 14:
				case 15:
				case 16:
					return MySqlDbType.Byte;
				case 17:
					if (!unsigned)
					{
						return MySqlDbType.Int16;
					}
					return MySqlDbType.UInt16;
				case 18:
					if (!unsigned)
					{
						return MySqlDbType.Int24;
					}
					return MySqlDbType.UInt24;
				case 19:
				case 20:
					if (!unsigned)
					{
						return MySqlDbType.Int32;
					}
					return MySqlDbType.UInt32;
				case 21:
					return MySqlDbType.UInt64;
				case 22:
					if (!unsigned)
					{
						return MySqlDbType.Int64;
					}
					return MySqlDbType.UInt64;
				case 23:
					return MySqlDbType.Float;
				case 24:
					return MySqlDbType.Double;
				case 25:
					if (!realAsFloat)
					{
						return MySqlDbType.Double;
					}
					return MySqlDbType.Float;
				case 26:
				case 27:
					return MySqlDbType.Blob;
				case 28:
				case 29:
					return MySqlDbType.LongBlob;
				case 30:
				case 31:
					return MySqlDbType.MediumBlob;
				case 32:
				case 33:
					return MySqlDbType.TinyBlob;
				}
			}
			throw new MySqlException("Unhandled type encountered");
		}
	}
}
