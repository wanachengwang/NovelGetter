using System;
using System.ComponentModel;
using System.Globalization;
using System.Resources;

namespace MySql.Data.MySqlClient
{
	internal class Resources
	{
		private static ResourceManager resourceMan;

		private static CultureInfo resourceCulture;

		[EditorBrowsable]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (object.ReferenceEquals(Resources.resourceMan, null))
				{
					ResourceManager resourceManager = new ResourceManager("MySql.Data.MySqlClient.Resources", typeof(Resources).get_Assembly());
					Resources.resourceMan = resourceManager;
				}
				return Resources.resourceMan;
			}
		}

		[EditorBrowsable]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		internal static string AdapterIsNull
		{
			get
			{
				return Resources.ResourceManager.GetString("AdapterIsNull", Resources.resourceCulture);
			}
		}

		internal static string AdapterSelectIsNull
		{
			get
			{
				return Resources.ResourceManager.GetString("AdapterSelectIsNull", Resources.resourceCulture);
			}
		}

		internal static string BadVersionFormat
		{
			get
			{
				return Resources.ResourceManager.GetString("BadVersionFormat", Resources.resourceCulture);
			}
		}

		internal static string BufferCannotBeNull
		{
			get
			{
				return Resources.ResourceManager.GetString("BufferCannotBeNull", Resources.resourceCulture);
			}
		}

		internal static string BufferNotLargeEnough
		{
			get
			{
				return Resources.ResourceManager.GetString("BufferNotLargeEnough", Resources.resourceCulture);
			}
		}

		internal static string CBMultiTableNotSupported
		{
			get
			{
				return Resources.ResourceManager.GetString("CBMultiTableNotSupported", Resources.resourceCulture);
			}
		}

		internal static string CBNoKeyColumn
		{
			get
			{
				return Resources.ResourceManager.GetString("CBNoKeyColumn", Resources.resourceCulture);
			}
		}

		internal static string ChaosNotSupported
		{
			get
			{
				return Resources.ResourceManager.GetString("ChaosNotSupported", Resources.resourceCulture);
			}
		}

		internal static string CommandTextNotInitialized
		{
			get
			{
				return Resources.ResourceManager.GetString("CommandTextNotInitialized", Resources.resourceCulture);
			}
		}

		internal static string ConnectionAlreadyOpen
		{
			get
			{
				return Resources.ResourceManager.GetString("ConnectionAlreadyOpen", Resources.resourceCulture);
			}
		}

		internal static string ConnectionMustBeOpen
		{
			get
			{
				return Resources.ResourceManager.GetString("ConnectionMustBeOpen", Resources.resourceCulture);
			}
		}

		internal static string ConnectionNotOpen
		{
			get
			{
				return Resources.ResourceManager.GetString("ConnectionNotOpen", Resources.resourceCulture);
			}
		}

		internal static string ConnectionNotSet
		{
			get
			{
				return Resources.ResourceManager.GetString("ConnectionNotSet", Resources.resourceCulture);
			}
		}

		internal static string CountCannotBeNegative
		{
			get
			{
				return Resources.ResourceManager.GetString("CountCannotBeNegative", Resources.resourceCulture);
			}
		}

		internal static string CSNoSetLength
		{
			get
			{
				return Resources.ResourceManager.GetString("CSNoSetLength", Resources.resourceCulture);
			}
		}

		internal static string DataReaderOpen
		{
			get
			{
				return Resources.ResourceManager.GetString("DataReaderOpen", Resources.resourceCulture);
			}
		}

		internal static string ErrorCreatingSocket
		{
			get
			{
				return Resources.ResourceManager.GetString("ErrorCreatingSocket", Resources.resourceCulture);
			}
		}

		internal static string FromAndLengthTooBig
		{
			get
			{
				return Resources.ResourceManager.GetString("FromAndLengthTooBig", Resources.resourceCulture);
			}
		}

		internal static string FromIndexMustBeValid
		{
			get
			{
				return Resources.ResourceManager.GetString("FromIndexMustBeValid", Resources.resourceCulture);
			}
		}

		internal static string IndexAndLengthTooBig
		{
			get
			{
				return Resources.ResourceManager.GetString("IndexAndLengthTooBig", Resources.resourceCulture);
			}
		}

		internal static string IndexMustBeValid
		{
			get
			{
				return Resources.ResourceManager.GetString("IndexMustBeValid", Resources.resourceCulture);
			}
		}

		internal static string KeywordNotSupported
		{
			get
			{
				return Resources.ResourceManager.GetString("KeywordNotSupported", Resources.resourceCulture);
			}
		}

		internal static string NamedPipeNoSeek
		{
			get
			{
				return Resources.ResourceManager.GetString("NamedPipeNoSeek", Resources.resourceCulture);
			}
		}

		internal static string NamedPipeNoSetLength
		{
			get
			{
				return Resources.ResourceManager.GetString("NamedPipeNoSetLength", Resources.resourceCulture);
			}
		}

		internal static string NoBodiesAndTypeNotSet
		{
			get
			{
				return Resources.ResourceManager.GetString("NoBodiesAndTypeNotSet", Resources.resourceCulture);
			}
		}

		internal static string NoNestedTransactions
		{
			get
			{
				return Resources.ResourceManager.GetString("NoNestedTransactions", Resources.resourceCulture);
			}
		}

		internal static string OffsetCannotBeNegative
		{
			get
			{
				return Resources.ResourceManager.GetString("OffsetCannotBeNegative", Resources.resourceCulture);
			}
		}

		internal static string OffsetMustBeValid
		{
			get
			{
				return Resources.ResourceManager.GetString("OffsetMustBeValid", Resources.resourceCulture);
			}
		}

		internal static string ParameterAlreadyDefined
		{
			get
			{
				return Resources.ResourceManager.GetString("ParameterAlreadyDefined", Resources.resourceCulture);
			}
		}

		internal static string ParameterCannotBeNegative
		{
			get
			{
				return Resources.ResourceManager.GetString("ParameterCannotBeNegative", Resources.resourceCulture);
			}
		}

		internal static string ParameterCannotBeNull
		{
			get
			{
				return Resources.ResourceManager.GetString("ParameterCannotBeNull", Resources.resourceCulture);
			}
		}

		internal static string ParameterIsInvalid
		{
			get
			{
				return Resources.ResourceManager.GetString("ParameterIsInvalid", Resources.resourceCulture);
			}
		}

		internal static string ParameterMustBeDefined
		{
			get
			{
				return Resources.ResourceManager.GetString("ParameterMustBeDefined", Resources.resourceCulture);
			}
		}

		internal static string PasswordMustHaveLegalChars
		{
			get
			{
				return Resources.ResourceManager.GetString("PasswordMustHaveLegalChars", Resources.resourceCulture);
			}
		}

		internal static string QueryTooLarge
		{
			get
			{
				return Resources.ResourceManager.GetString("QueryTooLarge", Resources.resourceCulture);
			}
		}

		internal static string ReadFromStreamFailed
		{
			get
			{
				return Resources.ResourceManager.GetString("ReadFromStreamFailed", Resources.resourceCulture);
			}
		}

		internal static string ReturnParameterExists
		{
			get
			{
				return Resources.ResourceManager.GetString("ReturnParameterExists", Resources.resourceCulture);
			}
		}

		internal static string SocketNoSeek
		{
			get
			{
				return Resources.ResourceManager.GetString("SocketNoSeek", Resources.resourceCulture);
			}
		}

		internal static string SPNotSupported
		{
			get
			{
				return Resources.ResourceManager.GetString("SPNotSupported", Resources.resourceCulture);
			}
		}

		internal static string StreamAlreadyClosed
		{
			get
			{
				return Resources.ResourceManager.GetString("StreamAlreadyClosed", Resources.resourceCulture);
			}
		}

		internal static string StreamNoRead
		{
			get
			{
				return Resources.ResourceManager.GetString("StreamNoRead", Resources.resourceCulture);
			}
		}

		internal static string StreamNoWrite
		{
			get
			{
				return Resources.ResourceManager.GetString("StreamNoWrite", Resources.resourceCulture);
			}
		}

		internal static string TimeoutGettingConnection
		{
			get
			{
				return Resources.ResourceManager.GetString("TimeoutGettingConnection", Resources.resourceCulture);
			}
		}

		internal static string UnableToConnectToHost
		{
			get
			{
				return Resources.ResourceManager.GetString("UnableToConnectToHost", Resources.resourceCulture);
			}
		}

		internal static string UnableToExecuteSP
		{
			get
			{
				return Resources.ResourceManager.GetString("UnableToExecuteSP", Resources.resourceCulture);
			}
		}

		internal static string UnableToRetrieveSProcData
		{
			get
			{
				return Resources.ResourceManager.GetString("UnableToRetrieveSProcData", Resources.resourceCulture);
			}
		}

		internal static string UnixSocketsNotSupported
		{
			get
			{
				return Resources.ResourceManager.GetString("UnixSocketsNotSupported", Resources.resourceCulture);
			}
		}

		internal static string WriteToStreamFailed
		{
			get
			{
				return Resources.ResourceManager.GetString("WriteToStreamFailed", Resources.resourceCulture);
			}
		}

		internal static string WrongParameterName
		{
			get
			{
				return Resources.ResourceManager.GetString("WrongParameterName", Resources.resourceCulture);
			}
		}

		internal Resources()
		{
		}
	}
}
