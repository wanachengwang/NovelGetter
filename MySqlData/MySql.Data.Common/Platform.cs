using System;

namespace MySql.Data.Common
{
	internal class Platform
	{
		private Platform()
		{
		}

		public static bool IsWindows()
		{
			OperatingSystem oSVersion = Environment.get_OSVersion();
			switch (oSVersion.get_Platform())
			{
			case 0:
			case 1:
			case 2:
				return true;
			default:
				return false;
			}
		}
	}
}
