using MySql.Data.MySqlClient;
using System;
using System.Globalization;

namespace MySql.Data.Common
{
	internal struct DBVersion
	{
		private int major;

		private int minor;

		private int build;

		private string srcString;

		public DBVersion(string s, int major, int minor, int build)
		{
			this.major = major;
			this.minor = minor;
			this.build = build;
			this.srcString = s;
		}

		public static DBVersion Parse(string versionString)
		{
			int num = 0;
			int num2 = versionString.IndexOf('.', 0);
			if (num2 == -1)
			{
				throw new MySqlException(Resources.BadVersionFormat);
			}
			string text = versionString.Substring(num, num2 - num).Trim();
			int num3 = Convert.ToInt32(text, NumberFormatInfo.InvariantInfo);
			num = num2 + 1;
			num2 = versionString.IndexOf('.', num);
			if (num2 == -1)
			{
				throw new MySqlException(Resources.BadVersionFormat);
			}
			text = versionString.Substring(num, num2 - num).Trim();
			int num4 = Convert.ToInt32(text, NumberFormatInfo.InvariantInfo);
			num = num2 + 1;
			int num5 = num;
			while (num5 < versionString.Length && char.IsDigit(versionString, num5))
			{
				num5++;
			}
			text = versionString.Substring(num, num5 - num).Trim();
			int num6 = Convert.ToInt32(text, NumberFormatInfo.InvariantInfo);
			return new DBVersion(versionString, num3, num4, num6);
		}

		public bool isAtLeast(int major, int minor, int build)
		{
			return this.major > major || (this.major == major && this.minor > minor) || (this.major == major && this.minor == minor && this.build >= build);
		}

		public override string ToString()
		{
			return this.srcString;
		}
	}
}
