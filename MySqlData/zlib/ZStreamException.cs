using System;
using System.IO;

namespace zlib
{
	[Serializable]
	internal class ZStreamException : IOException
	{
		public ZStreamException()
		{
		}

		public ZStreamException(string s) : base(s)
		{
		}
	}
}
