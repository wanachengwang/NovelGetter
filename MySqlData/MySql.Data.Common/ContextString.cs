using System;
using System.Collections;
using System.Text;

namespace MySql.Data.Common
{
	internal class ContextString
	{
		private string contextMarkers;

		private bool escapeBackslash;

		public string ContextMarkers
		{
			get
			{
				return this.contextMarkers;
			}
			set
			{
				this.contextMarkers = value;
			}
		}

		public ContextString(string contextMarkers, bool escapeBackslash)
		{
			this.contextMarkers = contextMarkers;
			this.escapeBackslash = escapeBackslash;
		}

		public int IndexOf(string src, char target)
		{
			char c = '\0';
			bool flag = false;
			int num = 0;
			for (int i = 0; i < src.Length; i++)
			{
				char c2 = src[i];
				int num2 = this.contextMarkers.IndexOf(c2);
				if (num2 > -1 && c == this.contextMarkers[num2] && !flag)
				{
					c = '\0';
				}
				else if (c == '\0' && num2 > -1 && !flag)
				{
					c = c2;
				}
				else
				{
					if (c == '\0' && c2 == target)
					{
						return num;
					}
					if (c2 == '\\' && this.escapeBackslash)
					{
						flag = !flag;
					}
				}
				num++;
			}
			return -1;
		}

		public string[] Split(string src, string delimiters)
		{
			ArrayList arrayList = new ArrayList();
			StringBuilder stringBuilder = new StringBuilder();
			bool flag = false;
			char c = '\0';
			for (int i = 0; i < src.Length; i++)
			{
				char c2 = src[i];
				if (delimiters.IndexOf(c2) != -1 && !flag)
				{
					if (c != '\0')
					{
						stringBuilder.Append(c2);
					}
					else if (stringBuilder.Length > 0)
					{
						arrayList.Add(stringBuilder.ToString());
						stringBuilder.Remove(0, stringBuilder.Length);
					}
				}
				else if (c2 == '\\' && this.escapeBackslash)
				{
					flag = !flag;
				}
				else
				{
					int num = this.contextMarkers.IndexOf(c2);
					if (num % 2 == 0 && c != '\0')
					{
						num++;
					}
					if (num % 2 == 1 && c == this.contextMarkers[num - 1] && !flag)
					{
						c = '\0';
					}
					else if (c == '\0' && this.contextMarkers.IndexOf(c2) % 2 == 0 && !flag)
					{
						c = c2;
					}
					stringBuilder.Append(c2);
				}
			}
			if (stringBuilder.Length > 0)
			{
				arrayList.Add(stringBuilder.ToString());
			}
			return (string[])arrayList.ToArray(typeof(string));
		}
	}
}
