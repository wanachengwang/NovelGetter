using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection;

namespace MySql.Data.Common
{
	internal class StreamCreator
	{
		private string hostList;

		private int port;

		private string pipeName;

		private int timeOut;

		public StreamCreator(string hosts, int port, string pipeName)
		{
			this.hostList = hosts;
			if (this.hostList == null || this.hostList.Length == 0)
			{
				this.hostList = "localhost";
			}
			this.port = port;
			this.pipeName = pipeName;
		}

		public Stream GetStream(uint timeOut)
		{
			this.timeOut = (int)timeOut;
			if (this.hostList.StartsWith("/"))
			{
				return this.CreateSocketStream(null, 0, true);
			}
			string[] array = this.hostList.Split(new char[]
			{
				'&'
			});
			Random random = new Random((int)DateTime.get_Now().get_Ticks());
			int num = random.Next(array.Length);
			int i = 0;
			bool flag = this.pipeName != null && this.pipeName.Length != 0;
			Stream stream = null;
			while (i < array.Length)
			{
				if (flag)
				{
					stream = this.CreateNamedPipeStream(array[num]);
				}
				else
				{
					IPHostEntry hostByName = Dns.GetHostByName(array[num]);
					IPAddress[] addressList = hostByName.get_AddressList();
					for (int j = 0; j < addressList.Length; j++)
					{
						IPAddress iPAddress = addressList[j];
						if (iPAddress.get_AddressFamily() != 23)
						{
							stream = this.CreateSocketStream(iPAddress, this.port, false);
							if (stream != null)
							{
								break;
							}
						}
					}
				}
				if (stream != null)
				{
					break;
				}
				num++;
				if (num == array.Length)
				{
					num = 0;
				}
				i++;
			}
			return stream;
		}

		private Stream CreateNamedPipeStream(string hostname)
		{
			string host;
			if (string.Compare(hostname, "localhost", true) == 0)
			{
				host = "\\\\.\\pipe\\" + this.pipeName;
			}
			else
			{
				host = string.Format("\\\\{0}\\pipe\\{1}", hostname.ToString(), this.pipeName);
			}
			return new NamedPipeStream(host, 3);
		}

		private EndPoint CreateUnixEndPoint(string host)
		{
			Assembly assembly = Assembly.LoadWithPartialName("Mono.Posix");
			return (EndPoint)assembly.CreateInstance("Mono.Posix.UnixEndPoint", false, 512, null, new object[]
			{
				host
			}, null, null);
		}

		private Stream CreateSocketStream(IPAddress ip, int port, bool unix)
		{
			EndPoint endPoint;
			if (!Platform.IsWindows() && unix)
			{
				endPoint = this.CreateUnixEndPoint(this.hostList);
			}
			else
			{
				endPoint = new IPEndPoint(ip, port);
			}
			Socket socket = unix ? new Socket(1, 1, 0) : new Socket(2, 1, 6);
			IAsyncResult asyncResult = socket.BeginConnect(endPoint, null, null);
			if (!asyncResult.get_AsyncWaitHandle().WaitOne(this.timeOut * 1000, true))
			{
				socket.Close();
				return null;
			}
			Stream result;
			try
			{
				socket.EndConnect(asyncResult);
				goto IL_7B;
			}
			catch (Exception)
			{
				socket.Close();
				result = null;
			}
			return result;
			IL_7B:
			NetworkStream networkStream = new NetworkStream(socket, true);
			GC.SuppressFinalize(socket);
			GC.SuppressFinalize(networkStream);
			return networkStream;
		}
	}
}
