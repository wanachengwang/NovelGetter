using System;
using System.Runtime.InteropServices;

namespace NovelSpider
{
	public class NativeMethods
	{
		public static int BookCount;

		public static int ChapterCount;

		public static string BookMsg;

		static NativeMethods()
		{
			Class19.Q77LubhzKM3NS();
			NativeMethods.BookCount = 0;
			NativeMethods.ChapterCount = 0;
			NativeMethods.BookMsg = "";
		}

		public NativeMethods()
		{
			Class19.Q77LubhzKM3NS();
		}

		[DllImport("kernel32.dll", CharSet=CharSet.None, ExactSpelling=false)]
		public static extern bool AllocConsole();

		[DllImport("kernel32.dll", CharSet=CharSet.None, ExactSpelling=false)]
		public static extern bool FreeConsole();
	}
}