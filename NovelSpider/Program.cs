using NovelSpider.Common;
using NovelSpider.Config;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace NovelSpider
{
	internal static class Program
	{
		[STAThread]
		private static void Main(string[] args)
		{
			string str = "";
			DateTime dateTime = DateTime.Parse("2000-01-01");
			DateTime now = DateTime.Now;
			bool flag = false;
			try
			{
				Comm.Key = FormatDateTime.GetDiskInfo();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message, Localization.Get("系统错误"));
				return;
			}
			if ((Comm.Key == null ? false : Comm.Key.Length == 16))
			{
				try
				{
					Comm.Text = File.ReadAllText(string.Concat(Comm.Key, ".ini"), Encoding.UTF8);
					if (!string.IsNullOrEmpty(Comm.Text))
					{
						string[] strArrays = SecurityUtil.DesDecode(Comm.Text, Comm.Key).Split(new char[] { '|' });
						if ((int)strArrays.Length == 5)
						{
							DateTime.Parse(strArrays[0]);
							str = strArrays[2];
							flag = bool.Parse(strArrays[1]);
							dateTime = DateTime.Parse(strArrays[4]);
						}
					}
					else
					{
						DateTime now1 = DateTime.Now;
					}
				}
				catch
				{
					File.WriteAllText(string.Concat(Comm.Key, ".ini"), "", Encoding.UTF8);
					DateTime dateTime1 = DateTime.Now;
				}
				try
				{
					if (!Directory.Exists("Log"))
					{
						Directory.CreateDirectory("Log");
					}
					Configs.LoadConfigs();
					Configs.BaseConfig.LicenseAd = Localization.Get("站群系统，防封IP采集，各类软件定制 http://biqu01.com/");
					Configs.BaseConfig.LicenseOk = (str == Comm.Key ? true : Comm.Text == "");
					Configs.BaseConfig.LicenseVip = flag;
					Configs.BaseConfig.LicenseTime = dateTime;
					if (DateTime.Now > Configs.BaseConfig.LicenseTime)
					{
						Configs.BaseConfig.LicenseVip = false;
					}
				}
				catch (Exception exception1)
				{
					MessageBox.Show(exception1.Message, Localization.Get("错误提示"));
					return;
				}
				try
				{
                    NovelSpider.NativeMethods.FreeConsole();
					Application.EnableVisualStyles();
					Application.SetCompatibleTextRenderingDefault(true);
					Class19.Q77LubhzKM3NS();
					Application.Run(new MdiForm());
				}
				finally
				{
                    Localization.Refresh();
                    NovelSpider.NativeMethods.FreeConsole();
				}
			}
			else
			{
				MessageBox.Show(Localization.Get("系统编码失败，请联系管理员。"), Localization.Get("系统错误"));
			}
		}
	}
}