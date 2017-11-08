using NovelSpider.Common;
using NovelSpider.Config;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Resources;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace NovelSpider
{
	public class MdiForm : Form
	{
		private ConfigForm configForm_0;

		private DockPanel dockPanel;

		private IContainer icontainer_0;

		public string KeyPassWd;

		private MenuStrip MainMenu;

		private System.Windows.Forms.Timer timer_0;

		private ToolStripMenuItem toolStripMenuItem_0;

		private ToolStripMenuItem toolStripMenuItem_1;

		private ToolStripMenuItem toolStripMenuItem_10;

		private ToolStripMenuItem toolStripMenuItem_11;

		private ToolStripMenuItem toolStripMenuItem_12;

		private ToolStripMenuItem toolStripMenuItem_13;

		private ToolStripMenuItem toolStripMenuItem_14;

		private ToolStripMenuItem toolStripMenuItem_15;

		private ToolStripMenuItem toolStripMenuItem_16;

		private ToolStripMenuItem toolStripMenuItem_18;

		private ToolStripMenuItem toolStripMenuItem_19;

		private ToolStripMenuItem toolStripMenuItem_2;

		private ToolStripMenuItem toolStripMenuItem_20;

		private ToolStripMenuItem toolStripMenuItem_21;

		private ToolStripMenuItem toolStripMenuItem_23;

		private ToolStripMenuItem toolStripMenuItem_24;

		private ToolStripMenuItem toolStripMenuItem_25;

		private ToolStripMenuItem toolStripMenuItem_26;

		private ToolStripMenuItem toolStripMenuItem_27;

		private ToolStripMenuItem toolStripMenuItem_28;

		private ToolStripMenuItem toolStripMenuItem_3;

		private ToolStripMenuItem toolStripMenuItem_4;

		private ToolStripMenuItem toolStripMenuItem_5;

		private ToolStripMenuItem toolStripMenuItem_6;

		private ToolStripMenuItem toolStripMenuItem_7;

		private ToolStripMenuItem toolStripMenuItem_8;

		private ToolStripMenuItem toolStripMenuItem_9;

		private ToolStripMenuItem toolStripMenuItem1;

		private IContainer components;

		private ToolStripMenuItem 高级设置ToolStripMenuItem;

		private static Thread thr;

		private ToolStripMenuItem 图转文设置ToolStripMenuItem;

		private static DateTime time;

		static MdiForm()
		{
			Class19.Q77LubhzKM3NS();
		}

		public MdiForm()
		{
			Class19.Q77LubhzKM3NS();
			this.KeyPassWd = "";
			this.InitializeComponent();
		}

		protected override void Dispose(bool disposing)
		{
			if ((!disposing ? false : this.icontainer_0 != null))
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		public static string GetMail()
		{
			string bookMsg = NovelSpider.NativeMethods.BookMsg;
			if (Configs.BaseConfig.LogType != 0)
			{
				DateTime now = DateTime.Now;
				FileInfo fileInfo = new FileInfo(string.Concat("Log\\", now.ToString("yyyyMMdd"), ".db3"));
				if (fileInfo.Exists)
				{
					string str = string.Concat("Data Source=", fileInfo.FullName);
					object[] count = new object[] { "Select * From [TaskLog] Where LASTNUM >", SecurityUtil.ConvertDateTimeInt(MdiForm.time.AddMinutes((double)(-Configs.BaseConfig.MailTimeNum))), " AND LASTNUM<=", SecurityUtil.ConvertDateTimeInt(MdiForm.time), " And NOVELNAME<>''" };
					DataSet dataSet = SQLiteHelper.ExecuteDataset(str, string.Concat(count));
					if ((dataSet == null ? true : dataSet.Tables[0].Rows.Count < 1))
					{
						bookMsg = string.Concat(bookMsg, Localization.Get("没有发现错误。<br />"));
					}
					else
					{
						object obj = bookMsg;
						count = new object[] { obj, Localization.Get("<br /><br />错误共计<font style=color:red>"), dataSet.Tables[0].Rows.Count, Localization.Get("</font>条。") };
						bookMsg = string.Concat(count);
						for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
						{
							string str1 = bookMsg;
							string[] strArrays = new string[] { str1, "<br /><br />", dataSet.Tables[0].Rows[i]["LASTTIME"].ToString(), Localization.Get(" 规则"), dataSet.Tables[0].Rows[i]["RULEFILE"].ToString(), Localization.Get("操作书籍[<font style=color:green>"), dataSet.Tables[0].Rows[i]["NOVELNAME"].ToString(), Localization.Get("</font>]时候发生("), dataSet.Tables[0].Rows[i]["EXID"].ToString(), Localization.Get(")错误。<br />错误详情："), dataSet.Tables[0].Rows[i]["EXMSG"].ToString(), Localization.Get("<br />相关网址："), dataSet.Tables[0].Rows[i]["INDEXURL"].ToString() };
							bookMsg = string.Concat(strArrays);
						}
					}
				}
			}
			else
			{
				bookMsg = string.Concat(bookMsg, Localization.Get("<br /><br />由于你使用的是文本log模式，无法给你提供错误详单，如果需要，请设置为SQLite模式。"));
			}
			bookMsg = string.Concat(bookMsg, Localization.Get("<br /><br />开发任何网站系统，任何软件，请联系biqu01.com"));
			return bookMsg;
		}

		public static void GoMail()
		{
			EmailSendServer emailSendServer = new EmailSendServer()
			{
				SenderEmail = Configs.BaseConfig.MailUser,
				SmtpServer = Configs.BaseConfig.MailSmtp,
				SmtpServerAccount = Configs.BaseConfig.MailUser,
				SmtpServerPassword = Configs.BaseConfig.MailPass
			};
			EmailSendServer emailSendServer1 = emailSendServer;
			int num = (new Random()).Next(0, 99999);
			string str = SecurityUtil.MD5(num.ToString()).Substring(8, 5);
			EmailBase emailBase = new EmailBase();
			string[] webSiteName = new string[] { Localization.Get("【"), Configs.BaseConfig.WebSiteName, Localization.Get("】即时采集报告("), str, ")" };
			emailBase.Subject = string.Concat(webSiteName);
			emailBase.Content = MdiForm.GetMail();
			string[] strArrays = Configs.BaseConfig.MailTitle.Trim().Split(new char[] { ',' });
			int num1 = 0;
			while (true)
			{
				if (num1 < (int)strArrays.Length)
				{
					string str1 = strArrays[num1];
					if (str1 == string.Empty)
					{
						break;
					}
					else
					{
						emailBase.ToEmail = str1;
						emailSendServer1.SendMail(emailBase);
						num1++;
					}
				}
				else
				{
					break;
				}
			}
		}

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MdiForm));
			DockPanelSkin dockPanelSkin = new DockPanelSkin();
			AutoHideStripSkin autoHideStripSkin = new AutoHideStripSkin();
			DockPanelGradient dockPanelGradient = new DockPanelGradient();
			TabGradient tabGradient = new TabGradient();
			DockPaneStripSkin dockPaneStripSkin = new DockPaneStripSkin();
			DockPaneStripGradient dockPaneStripGradient = new DockPaneStripGradient();
			TabGradient controlLightLight = new TabGradient();
			DockPanelGradient control = new DockPanelGradient();
			TabGradient controlLight = new TabGradient();
			DockPaneStripToolWindowGradient dockPaneStripToolWindowGradient = new DockPaneStripToolWindowGradient();
			TabGradient activeCaption = new TabGradient();
			TabGradient controlText = new TabGradient();
			DockPanelGradient dockPanelGradient1 = new DockPanelGradient();
			TabGradient gradientInactiveCaption = new TabGradient();
			TabGradient transparent = new TabGradient();
			this.MainMenu = new MenuStrip();
			this.toolStripMenuItem_0 = new ToolStripMenuItem();
			this.toolStripMenuItem_1 = new ToolStripMenuItem();
			this.toolStripMenuItem_2 = new ToolStripMenuItem();
			this.toolStripMenuItem_3 = new ToolStripMenuItem();
			this.toolStripMenuItem_4 = new ToolStripMenuItem();
			this.toolStripMenuItem_23 = new ToolStripMenuItem();
			this.toolStripMenuItem_8 = new ToolStripMenuItem();
			this.toolStripMenuItem1 = new ToolStripMenuItem();
			this.toolStripMenuItem_7 = new ToolStripMenuItem();
			this.toolStripMenuItem_9 = new ToolStripMenuItem();
			this.toolStripMenuItem_25 = new ToolStripMenuItem();
			this.toolStripMenuItem_26 = new ToolStripMenuItem();
			this.toolStripMenuItem_27 = new ToolStripMenuItem();
			this.toolStripMenuItem_5 = new ToolStripMenuItem();
			this.toolStripMenuItem_13 = new ToolStripMenuItem();
			this.toolStripMenuItem_12 = new ToolStripMenuItem();
			this.高级设置ToolStripMenuItem = new ToolStripMenuItem();
			this.图转文设置ToolStripMenuItem = new ToolStripMenuItem();
			this.toolStripMenuItem_14 = new ToolStripMenuItem();
			this.toolStripMenuItem_15 = new ToolStripMenuItem();
			this.toolStripMenuItem_16 = new ToolStripMenuItem();
			this.toolStripMenuItem_10 = new ToolStripMenuItem();
			this.toolStripMenuItem_11 = new ToolStripMenuItem();
			this.toolStripMenuItem_6 = new ToolStripMenuItem();
			this.toolStripMenuItem_18 = new ToolStripMenuItem();
			this.toolStripMenuItem_19 = new ToolStripMenuItem();
			this.toolStripMenuItem_24 = new ToolStripMenuItem();
			this.toolStripMenuItem_20 = new ToolStripMenuItem();
			this.toolStripMenuItem_21 = new ToolStripMenuItem();
			this.toolStripMenuItem_28 = new ToolStripMenuItem();
			this.dockPanel = new DockPanel();
			this.timer_0 = new System.Windows.Forms.Timer(this.components);
			this.MainMenu.SuspendLayout();
			base.SuspendLayout();
			ToolStripItemCollection items = this.MainMenu.Items;
			ToolStripItem[] toolStripMenuItem0 = new ToolStripItem[] { this.toolStripMenuItem_0, this.toolStripMenuItem_4, this.toolStripMenuItem_5, this.toolStripMenuItem_10, this.toolStripMenuItem_6, this.toolStripMenuItem_18 };
			items.AddRange(toolStripMenuItem0);
			this.MainMenu.Location = new Point(0, 0);
			this.MainMenu.MdiWindowListItem = this.toolStripMenuItem_6;
			this.MainMenu.Name = "MainMenu";
			this.MainMenu.RenderMode = ToolStripRenderMode.System;
			this.MainMenu.Size = new System.Drawing.Size(834, 25);
			this.MainMenu.TabIndex = 0;
			this.MainMenu.Text = Localization.Get("主菜单");
			ToolStripItemCollection dropDownItems = this.toolStripMenuItem_0.DropDownItems;
			toolStripMenuItem0 = new ToolStripItem[] { this.toolStripMenuItem_1, this.toolStripMenuItem_2, this.toolStripMenuItem_3 };
			dropDownItems.AddRange(toolStripMenuItem0);
			this.toolStripMenuItem_0.Name = "toolStripMenuItem_0";
			this.toolStripMenuItem_0.Size = new System.Drawing.Size(60, 21);
			this.toolStripMenuItem_0.Text = Localization.Get("采集(&C)");
			this.toolStripMenuItem_1.Image = (Image)componentResourceManager.GetObject("toolStripMenuItem_1.Image");
			this.toolStripMenuItem_1.Name = "toolStripMenuItem_1";
			this.toolStripMenuItem_1.Size = new System.Drawing.Size(152, 22);
			this.toolStripMenuItem_1.Text = Localization.Get("标准采集模式");
			this.toolStripMenuItem_1.Click += new EventHandler(this.toolStripMenuItem_1_Click);
			this.toolStripMenuItem_2.ForeColor = Color.Maroon;
			this.toolStripMenuItem_2.Image = (Image)componentResourceManager.GetObject("toolStripMenuItem_2.Image");
			this.toolStripMenuItem_2.Name = "toolStripMenuItem_2";
			this.toolStripMenuItem_2.Size = new System.Drawing.Size(152, 22);
			this.toolStripMenuItem_2.Text = Localization.Get("超级修复模式");
			this.toolStripMenuItem_2.Click += new EventHandler(this.toolStripMenuItem_2_Click);
			this.toolStripMenuItem_3.Image = (Image)componentResourceManager.GetObject("toolStripMenuItem_3.Image");
			this.toolStripMenuItem_3.Name = "toolStripMenuItem_3";
			this.toolStripMenuItem_3.Size = new System.Drawing.Size(152, 22);
			this.toolStripMenuItem_3.Text = Localization.Get("手动控制模式");
			this.toolStripMenuItem_3.Click += new EventHandler(this.toolStripMenuItem_3_Click);
			ToolStripItemCollection toolStripItemCollections = this.toolStripMenuItem_4.DropDownItems;
			toolStripMenuItem0 = new ToolStripItem[] { this.toolStripMenuItem_23, this.toolStripMenuItem_8, this.toolStripMenuItem1, this.toolStripMenuItem_7, this.toolStripMenuItem_9, this.toolStripMenuItem_25, this.toolStripMenuItem_26, this.toolStripMenuItem_27 };
			toolStripItemCollections.AddRange(toolStripMenuItem0);
			this.toolStripMenuItem_4.Name = "toolStripMenuItem_4";
			this.toolStripMenuItem_4.Size = new System.Drawing.Size(60, 21);
			this.toolStripMenuItem_4.Text = Localization.Get("辅助(&A)");
			this.toolStripMenuItem_23.Name = "toolStripMenuItem_23";
			this.toolStripMenuItem_23.Size = new System.Drawing.Size(166, 22);
			this.toolStripMenuItem_23.Text = Localization.Get("子窗口冲突监控");
			this.toolStripMenuItem_23.Click += new EventHandler(this.toolStripMenuItem_23_Click);
			this.toolStripMenuItem_8.Name = "toolStripMenuItem_8";
			this.toolStripMenuItem_8.Size = new System.Drawing.Size(166, 22);
			this.toolStripMenuItem_8.Text = Localization.Get("错误生成器");
			this.toolStripMenuItem_8.Click += new EventHandler(this.toolStripMenuItem_8_Click);
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(166, 22);
			this.toolStripMenuItem1.Text = ("数据库维护");
			this.toolStripMenuItem1.Visible = false;
			this.toolStripMenuItem1.Click += new EventHandler(this.toolStripMenuItem1_Click);
			this.toolStripMenuItem_7.Name = "toolStripMenuItem_7";
			this.toolStripMenuItem_7.Size = new System.Drawing.Size(166, 22);
			this.toolStripMenuItem_7.Text = Localization.Get("批量生成");
			this.toolStripMenuItem_7.Click += new EventHandler(this.toolStripMenuItem_7_Click);
			this.toolStripMenuItem_9.Name = "toolStripMenuItem_9";
			this.toolStripMenuItem_9.Size = new System.Drawing.Size(166, 22);
			this.toolStripMenuItem_9.Text = Localization.Get("批量删除小说");
			this.toolStripMenuItem_9.Click += new EventHandler(this.toolStripMenuItem_9_Click);
			this.toolStripMenuItem_25.Enabled = false;
			this.toolStripMenuItem_25.Name = "toolStripMenuItem_25";
			this.toolStripMenuItem_25.Size = new System.Drawing.Size(166, 22);
			this.toolStripMenuItem_25.Text = Localization.Get("批量删除章节");
			this.toolStripMenuItem_25.Visible = false;
			this.toolStripMenuItem_26.Name = "toolStripMenuItem_26";
			this.toolStripMenuItem_26.Size = new System.Drawing.Size(166, 22);
			this.toolStripMenuItem_26.Text = Localization.Get("更新小说信息");
			this.toolStripMenuItem_26.Click += new EventHandler(this.toolStripMenuItem_26_Click);
			this.toolStripMenuItem_27.Name = "toolStripMenuItem_27";
			this.toolStripMenuItem_27.Size = new System.Drawing.Size(166, 22);
			this.toolStripMenuItem_27.Text = Localization.Get("MYSQL时间换算");
			this.toolStripMenuItem_27.Click += new EventHandler(this.toolStripMenuItem_27_Click);
			ToolStripItemCollection dropDownItems1 = this.toolStripMenuItem_5.DropDownItems;
			toolStripMenuItem0 = new ToolStripItem[] { this.toolStripMenuItem_13, this.toolStripMenuItem_12, this.高级设置ToolStripMenuItem, this.toolStripMenuItem_14, this.图转文设置ToolStripMenuItem, this.toolStripMenuItem_15, this.toolStripMenuItem_16 };
			dropDownItems1.AddRange(toolStripMenuItem0);
			this.toolStripMenuItem_5.Name = "toolStripMenuItem_5";
			this.toolStripMenuItem_5.Size = new System.Drawing.Size(59, 21);
			this.toolStripMenuItem_5.Text = Localization.Get("设置(&S)");
			this.toolStripMenuItem_13.Name = "toolStripMenuItem_13";
			this.toolStripMenuItem_13.Size = new System.Drawing.Size(136, 22);
			this.toolStripMenuItem_13.Text = Localization.Get("系统设置");
			this.toolStripMenuItem_13.Click += new EventHandler(this.toolStripMenuItem_13_Click);
			this.toolStripMenuItem_12.Name = "toolStripMenuItem_12";
			this.toolStripMenuItem_12.Size = new System.Drawing.Size(136, 22);
			this.toolStripMenuItem_12.Text = Localization.Get("分类对应");
			this.toolStripMenuItem_12.Click += new EventHandler(this.toolStripMenuItem_12_Click);
			this.高级设置ToolStripMenuItem.Name = Localization.Get("高级设置ToolStripMenuItem");
			this.高级设置ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
			this.高级设置ToolStripMenuItem.Text = Localization.Get("高级设置");
			this.高级设置ToolStripMenuItem.Click += new EventHandler(this.高级设置ToolStripMenuItem_Click);
			this.图转文设置ToolStripMenuItem.Name = Localization.Get("图转文设置ToolStripMenuItem");
			this.图转文设置ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.图转文设置ToolStripMenuItem.Text = Localization.Get("附加设置");
			this.图转文设置ToolStripMenuItem.Click += new EventHandler(this.图转文设置ToolStripMenuItem_Click);
			this.toolStripMenuItem_14.Name = Localization.Get("toolStripMenuItem_14");
			this.toolStripMenuItem_14.Size = new System.Drawing.Size(136, 22);
			this.toolStripMenuItem_14.Text = Localization.Get("生成设置");
			this.toolStripMenuItem_14.Click += new EventHandler(this.toolStripMenuItem_14_Click);
			this.toolStripMenuItem_15.Name = "toolStripMenuItem_15";
			this.toolStripMenuItem_15.Size = new System.Drawing.Size(136, 22);
			this.toolStripMenuItem_15.Text = Localization.Get("文字广告");
			this.toolStripMenuItem_15.Click += new EventHandler(this.toolStripMenuItem_15_Click);
			this.toolStripMenuItem_16.Name = "toolStripMenuItem_16";
			this.toolStripMenuItem_16.Size = new System.Drawing.Size(136, 22);
			this.toolStripMenuItem_16.Text = Localization.Get("过滤替换");
			this.toolStripMenuItem_16.Click += new EventHandler(this.toolStripMenuItem_16_Click);
			ToolStripItemCollection toolStripItemCollections1 = this.toolStripMenuItem_10.DropDownItems;
			toolStripMenuItem0 = new ToolStripItem[] { this.toolStripMenuItem_11 };
			toolStripItemCollections1.AddRange(toolStripMenuItem0);
			this.toolStripMenuItem_10.Name = "toolStripMenuItem_10";
			this.toolStripMenuItem_10.Size = new System.Drawing.Size(60, 21);
			this.toolStripMenuItem_10.Text = Localization.Get("规则(&R)");
			this.toolStripMenuItem_11.Name = "toolStripMenuItem_11";
			this.toolStripMenuItem_11.Size = new System.Drawing.Size(148, 22);
			this.toolStripMenuItem_11.Text = Localization.Get("采集规则管理");
			this.toolStripMenuItem_11.Click += new EventHandler(this.toolStripMenuItem_11_Click);
			this.toolStripMenuItem_6.Name = "toolStripMenuItem_6";
			this.toolStripMenuItem_6.Size = new System.Drawing.Size(64, 21);
			this.toolStripMenuItem_6.Text = Localization.Get("窗口(&W)");
			ToolStripItemCollection dropDownItems2 = this.toolStripMenuItem_18.DropDownItems;
			toolStripMenuItem0 = new ToolStripItem[] { this.toolStripMenuItem_19, this.toolStripMenuItem_24, this.toolStripMenuItem_20, this.toolStripMenuItem_21, this.toolStripMenuItem_28 };
			dropDownItems2.AddRange(toolStripMenuItem0);
			this.toolStripMenuItem_18.Name = "toolStripMenuItem_18";
			this.toolStripMenuItem_18.Size = new System.Drawing.Size(61, 21);
			this.toolStripMenuItem_18.Text = Localization.Get("帮助(&H)");
			this.toolStripMenuItem_19.Name = "toolStripMenuItem_19";
			this.toolStripMenuItem_19.Size = new System.Drawing.Size(124, 22);
			this.toolStripMenuItem_19.Text = Localization.Get("帮助内容");
			this.toolStripMenuItem_19.Click += new EventHandler(this.toolStripMenuItem_19_Click);
			this.toolStripMenuItem_24.Name = "toolStripMenuItem_24";
			this.toolStripMenuItem_24.Size = new System.Drawing.Size(124, 22);
			this.toolStripMenuItem_24.Text = Localization.Get("查看日志");
			this.toolStripMenuItem_24.Click += new EventHandler(this.toolStripMenuItem_24_Click);
			this.toolStripMenuItem_20.Name = "toolStripMenuItem_20";
			this.toolStripMenuItem_20.Size = new System.Drawing.Size(124, 22);
			this.toolStripMenuItem_20.Text = Localization.Get("检查更新");
			this.toolStripMenuItem_20.Visible = false;
			this.toolStripMenuItem_20.Click += new EventHandler(this.toolStripMenuItem_20_Click);
			this.toolStripMenuItem_21.Name = "toolStripMenuItem_21";
			this.toolStripMenuItem_21.Size = new System.Drawing.Size(124, 22);
			this.toolStripMenuItem_21.Text = Localization.Get("最新消息");
			this.toolStripMenuItem_21.Click += new EventHandler(this.toolStripMenuItem_21_Click);
			this.toolStripMenuItem_28.Name = "toolStripMenuItem_28";
			this.toolStripMenuItem_28.Size = new System.Drawing.Size(124, 22);
			this.toolStripMenuItem_28.Text = Localization.Get("高级功能");
			this.toolStripMenuItem_28.Click += new EventHandler(this.toolStripMenuItem_28_Click);
			this.dockPanel.ActiveAutoHideContent = null;
			this.dockPanel.Dock = DockStyle.Fill;
			this.dockPanel.DockBackColor = SystemColors.AppWorkspace;
			this.dockPanel.Location = new Point(0, 0);
			this.dockPanel.Name = "dockPanel";
			this.dockPanel.Size = new System.Drawing.Size(834, 452);
			dockPanelGradient.EndColor = SystemColors.ControlLight;
			dockPanelGradient.StartColor = SystemColors.ControlLight;
			autoHideStripSkin.DockStripGradient = dockPanelGradient;
			tabGradient.EndColor = SystemColors.Control;
			tabGradient.StartColor = SystemColors.Control;
			tabGradient.TextColor = SystemColors.ControlDarkDark;
			autoHideStripSkin.TabGradient = tabGradient;
			dockPanelSkin.AutoHideStripSkin = autoHideStripSkin;
			controlLightLight.EndColor = SystemColors.ControlLightLight;
			controlLightLight.StartColor = SystemColors.ControlLightLight;
			controlLightLight.TextColor = SystemColors.ControlText;
			dockPaneStripGradient.ActiveTabGradient = controlLightLight;
			control.EndColor = SystemColors.Control;
			control.StartColor = SystemColors.Control;
			dockPaneStripGradient.DockStripGradient = control;
			controlLight.EndColor = SystemColors.ControlLight;
			controlLight.StartColor = SystemColors.ControlLight;
			controlLight.TextColor = SystemColors.ControlText;
			dockPaneStripGradient.InactiveTabGradient = controlLight;
			dockPaneStripSkin.DocumentGradient = dockPaneStripGradient;
			activeCaption.EndColor = SystemColors.ActiveCaption;
			activeCaption.LinearGradientMode = LinearGradientMode.Vertical;
			activeCaption.StartColor = SystemColors.GradientActiveCaption;
			activeCaption.TextColor = SystemColors.ActiveCaptionText;
			dockPaneStripToolWindowGradient.ActiveCaptionGradient = activeCaption;
			controlText.EndColor = SystemColors.Control;
			controlText.StartColor = SystemColors.Control;
			controlText.TextColor = SystemColors.ControlText;
			dockPaneStripToolWindowGradient.ActiveTabGradient = controlText;
			dockPanelGradient1.EndColor = SystemColors.ControlLight;
			dockPanelGradient1.StartColor = SystemColors.ControlLight;
			dockPaneStripToolWindowGradient.DockStripGradient = dockPanelGradient1;
			gradientInactiveCaption.EndColor = SystemColors.GradientInactiveCaption;
			gradientInactiveCaption.LinearGradientMode = LinearGradientMode.Vertical;
			gradientInactiveCaption.StartColor = SystemColors.GradientInactiveCaption;
			gradientInactiveCaption.TextColor = SystemColors.ControlText;
			dockPaneStripToolWindowGradient.InactiveCaptionGradient = gradientInactiveCaption;
			transparent.EndColor = Color.Transparent;
			transparent.StartColor = Color.Transparent;
			transparent.TextColor = SystemColors.ControlDarkDark;
			dockPaneStripToolWindowGradient.InactiveTabGradient = transparent;
			dockPaneStripSkin.ToolWindowGradient = dockPaneStripToolWindowGradient;
			dockPanelSkin.DockPaneStripSkin = dockPaneStripSkin;
			this.dockPanel.Skin = dockPanelSkin;
			this.dockPanel.TabIndex = 2;
			this.timer_0.Interval = 1000;
			this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
			this.BackColor = SystemColors.Control;
			base.ClientSize = new System.Drawing.Size(834, 452);
			base.Controls.Add(this.MainMenu);
			base.Controls.Add(this.dockPanel);
			base.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.IsMdiContainer = true;
			base.MainMenuStrip = this.MainMenu;
			base.Name = "MdiForm";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = Localization.Get("超级小说采集器 V8.0");
			base.Load += new EventHandler(this.MdiForm_Load);
			base.Shown += new EventHandler(this.MdiForm_Shown);
			this.MainMenu.ResumeLayout(false);
			this.MainMenu.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private void MdiForm_Load(object sender, EventArgs e)
		{
			this.configForm_0 = new ConfigForm()
			{
				MdiParent = this
			};
			NovelSpider.Common.Keys.LoadText();
			if ((Configs.BaseConfig.WebSiteName == null ? false : Configs.BaseConfig.WebSiteName != ""))
			{
				object[] str = new object[] { Localization.Get("超级小说采集器"), Configs.BaseConfig.WebSiteName.ToString(), Localization.Get("专用版 V"), Configs.AssemblyVersion };
				this.Text = string.Concat(str);
			}
			if (Configs.BaseConfig.LicenseOk)
			{
				MdiForm.time = DateTime.Now;
				System.Timers.Timer timer = new System.Timers.Timer(60000);
				timer.Elapsed += new ElapsedEventHandler(MdiForm.myTimer_Elapsed);
				timer.Enabled = true;
				timer.AutoReset = true;
			}
		}

		private void MdiForm_Shown(object sender, EventArgs e)
		{
			if (!Configs.BaseConfig.LicenseVip)
			{
				(new WelcomeForm()
				{
					MdiParent = this
				}).Show(this.dockPanel);
			}
		}

		private static void myTimer_Elapsed(object source, object e)
		{
			try
			{
				MdiForm.YourTask();
			}
			catch
			{
			}
		}

		private void timer_0_Tick(object sender, EventArgs e)
		{
			if ((DateTime.Now.Hour != 3 ? false : this.Text.IndexOf("V8.0") < 0))
			{
				Application.Exit();
			}
		}

		private void toolStripMenuItem_1_Click(object sender, EventArgs e)
		{
			(new CollectAuto()
			{
				MdiParent = this
			}).Show(this.dockPanel);
		}

		private void toolStripMenuItem_11_Click(object sender, EventArgs e)
		{
			(new RuleForm()
			{
				MdiParent = this
			}).Show(this.dockPanel);
		}

		private void toolStripMenuItem_12_Click(object sender, EventArgs e)
		{
			this.configForm_0.tabControl1.SelectedIndex = 1;
			this.configForm_0.Show(this.dockPanel);
		}

		private void toolStripMenuItem_13_Click(object sender, EventArgs e)
		{
			this.configForm_0.tabControl1.SelectedIndex = 0;
			this.configForm_0.Show(this.dockPanel);
		}

		private void toolStripMenuItem_14_Click(object sender, EventArgs e)
		{
			this.configForm_0.tabControl1.SelectedIndex = 3;
			this.configForm_0.Show(this.dockPanel);
		}

		private void toolStripMenuItem_15_Click(object sender, EventArgs e)
		{
			this.configForm_0.tabControl1.SelectedIndex = 5;
			this.configForm_0.Show(this.dockPanel);
		}

		private void toolStripMenuItem_16_Click(object sender, EventArgs e)
		{
			this.configForm_0.tabControl1.SelectedIndex = 6;
			this.configForm_0.Show(this.dockPanel);
		}

		private void toolStripMenuItem_17_Click(object sender, EventArgs e)
		{
			this.configForm_0.tabControl1.SelectedIndex = 7;
			this.configForm_0.Show(this.dockPanel);
		}

		private void toolStripMenuItem_19_Click(object sender, EventArgs e)
		{
			Help.ShowHelp(this, "http://biqu01.com/");
		}

		private void toolStripMenuItem_2_Click(object sender, EventArgs e)
		{
			(new CollectReplace()
			{
				MdiParent = this
			}).Show(this.dockPanel);
		}

		private void toolStripMenuItem_20_Click(object sender, EventArgs e)
		{
			(new NovelSpiderUpdate()
			{
				MdiParent = this
			}).Show(this.dockPanel);
		}

		private void toolStripMenuItem_21_Click(object sender, EventArgs e)
		{
			(new WelcomeForm()
			{
				MdiParent = this
			}).Show(this.dockPanel);
		}

		private void toolStripMenuItem_23_Click(object sender, EventArgs e)
		{
			(new HelpTaskNovelInfo()
			{
				MdiParent = this
			}).Show(this.dockPanel);
		}

		private void toolStripMenuItem_24_Click(object sender, EventArgs e)
		{
			if (Configs.BaseConfig.LogType != 0)
			{
				(new HelpLog()
				{
					MdiParent = this
				}).Show(this.dockPanel);
			}
			else
			{
				string startupPath = Application.StartupPath;
				DateTime today = DateTime.Today;
				string str = string.Concat(startupPath, "\\Log\\", today.ToString("yyyyMMdd"), ".Log");
				if (!File.Exists(str))
				{
					File.Create(str);
				}
				Process.Start(str);
			}
		}

		private void toolStripMenuItem_26_Click(object sender, EventArgs e)
		{
			(new HelpUpdateNovel()
			{
				MdiParent = this
			}).Show(this.dockPanel);
		}

		private void toolStripMenuItem_27_Click(object sender, EventArgs e)
		{
			(new HelpConversion()
			{
				MdiParent = this
			}).Show(this.dockPanel);
		}

		private void toolStripMenuItem_28_Click(object sender, EventArgs e)
		{
			if (!Configs.BaseConfig.LicenseVip)
			{
				MessageBox.Show(Localization.Get("请给根目录下 xxxxxxxxxx.key 输入授权码，方可开启高级功能。"));
			}
			else
			{
				MessageBox.Show(Localization.Get("高级功能已经开启。"));
			}
		}

		private void toolStripMenuItem_29_Click(object sender, EventArgs e)
		{
			(new HelpUpdateNovelBySelf()
			{
				MdiParent = this
			}).Show(this.dockPanel);
		}

		private void toolStripMenuItem_3_Click(object sender, EventArgs e)
		{
			(new CollectManual()
			{
				MdiParent = this
			}).Show(this.dockPanel);
		}

		private void toolStripMenuItem_7_Click(object sender, EventArgs e)
		{
			(new HelpBatchCreate()
			{
				MdiParent = this
			}).Show(this.dockPanel);
		}

		private void toolStripMenuItem_8_Click(object sender, EventArgs e)
		{
			(new TaskForm()
			{
				MdiParent = this
			}).Show(this.dockPanel);
		}

		private void toolStripMenuItem_9_Click(object sender, EventArgs e)
		{
			(new HelpDeleteNovel()
			{
				MdiParent = this
			}).Show(this.dockPanel);
		}

		private void toolStripMenuItem1_Click(object sender, EventArgs e)
		{
			(new MysqlForm()
			{
				MdiParent = this
			}).Show(this.dockPanel);
		}

		private static void YourTask()
		{
			if (MdiForm.time.AddMinutes((double)Configs.BaseConfig.MailTimeNum) <= DateTime.Now)
			{
				MdiForm.time = DateTime.Now;
				object[] str = new object[10];
				DateTime dateTime = MdiForm.time.AddMinutes((double)(-Configs.BaseConfig.MailTimeNum));
				str[0] = dateTime.ToString("s");
				str[1] = Localization.Get(" 至 ");
				str[2] = MdiForm.time.ToString("s");
				str[3] = Localization.Get(" 采集【");
				str[4] = Configs.BaseConfig.WebSiteName;
				str[5] = Localization.Get("】所有规则，共执行书籍<font style=color:red>");
				str[6] = NovelSpider.NativeMethods.BookCount;
				str[7] = Localization.Get("</font>本/次，成功入库<font style=color:red>");
				str[8] = NovelSpider.NativeMethods.ChapterCount;
				str[9] = Localization.Get("</font>章节。");
				NovelSpider.NativeMethods.BookMsg = string.Concat(str);
				NovelSpider.NativeMethods.ChapterCount = 0;
				NovelSpider.NativeMethods.BookCount = 0;
				if (Configs.BaseConfig.MailPass != string.Empty)
				{
					MdiForm.thr = new Thread(new ThreadStart(MdiForm.GoMail));
					MdiForm.thr.Start();
				}
			}
		}

		private void 高级设置ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.configForm_0.tabControl1.SelectedIndex = 2;
			this.configForm_0.Show(this.dockPanel);
		}

		private void 图转文设置ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.configForm_0.tabControl1.SelectedIndex = 4;
			this.configForm_0.Show(this.dockPanel);
		}
	}
}