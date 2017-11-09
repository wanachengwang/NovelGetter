using System;
using System.Runtime.Serialization;

namespace MySql.Data.MySqlClient
{
	[Serializable]
	public sealed class MySqlException : SystemException
	{
		private int errorCode;

		private bool isFatal;

		public int Number
		{
			get
			{
				return this.errorCode;
			}
		}

		internal bool IsFatal
		{
			get
			{
				return this.isFatal;
			}
		}

		internal MySqlException()
		{
		}

		internal MySqlException(string msg) : base(msg)
		{
		}

		internal MySqlException(string msg, Exception ex) : base(msg, ex)
		{
		}

		internal MySqlException(string msg, bool isFatal, Exception inner) : base(msg, inner)
		{
			this.isFatal = isFatal;
		}

		internal MySqlException(string msg, int errno, Exception inner) : this(msg, inner)
		{
			this.errorCode = errno;
		}

		internal MySqlException(string msg, int errno) : this(msg)
		{
			this.errorCode = errno;
		}

		private MySqlException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
