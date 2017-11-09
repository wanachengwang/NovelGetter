using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace MySql.Data.Common
{
	internal class Semaphore : WaitHandle
	{
		public Semaphore(int initialCount, int maximumCount)
		{
			SECURITY_ATTRIBUTES sECURITY_ATTRIBUTES = default(SECURITY_ATTRIBUTES);
			IntPtr handle = Semaphore.CreateSemaphore(ref sECURITY_ATTRIBUTES, initialCount, maximumCount, null);
			if (handle.Equals(IntPtr.Zero))
			{
				throw new Exception("Unable to create semaphore");
			}
			base.set_Handle(handle);
		}

		public int Release()
		{
			IntPtr zero = IntPtr.Zero;
			if (!Semaphore.ReleaseSemaphore(base.get_Handle(), 1, zero))
			{
				throw new Exception("Unable to release semaphore");
			}
			return zero.ToInt32();
		}

		public override bool WaitOne(int millisecondsTimeout, bool exitContext)
		{
			if (millisecondsTimeout < 0 && millisecondsTimeout != -1)
			{
				throw new ArgumentOutOfRangeException("millisecondsTimeout");
			}
			if (exitContext)
			{
				throw new ArgumentException(null, "exitContext");
			}
			return Semaphore.WaitForSingleObject(this.get_Handle(), millisecondsTimeout) == 0;
		}

		[DllImport("kernel32.dll")]
		private static extern bool ReleaseSemaphore(IntPtr hSemaphore, int lReleaseCount, IntPtr lpPreviousCount);

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern IntPtr CreateSemaphore(ref SECURITY_ATTRIBUTES securityAttributes, int initialCount, int maximumCount, string name);

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern int WaitForSingleObject(IntPtr handle, int millis);
	}
}
