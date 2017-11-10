using System;

namespace MySql.Data.MySqlClient
{
	internal class Logger
	{
		private Logger()
		{
		}

		public static void LogCommand(DBCmd cmd, string text)
		{
			if (text.Length > 300)
			{
				text = text.Substring(0, 300);
			}
			string.Format("Executing command {0} with text ='{1}'", Enum.GetName(typeof(DBCmd), cmd), text);
		}

		public static void LogInformation(string msg)
		{
		}

		public static void LogException(Exception ex)
		{
			string.Format("EXCEPTION: " + ex.Message, new object[0]);
		}

		public static void LogWarning(string s)
		{
		}
	}
}
