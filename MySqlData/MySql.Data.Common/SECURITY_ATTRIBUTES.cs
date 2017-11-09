using System;

namespace MySql.Data.Common
{
	internal struct SECURITY_ATTRIBUTES
	{
		public int nLength;

		public IntPtr lpSecurityDescriptor;

		public int bInheritHandle;
	}
}
