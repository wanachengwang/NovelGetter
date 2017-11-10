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
			OperatingSystem oSVersion = Environment.OSVersion;
			switch (oSVersion.Platform)
			{
			case (PlatformID)0:
			case (PlatformID)1:
			case (PlatformID)2:
				return true;
			default:
				return false;
			}
		}
	}
}
