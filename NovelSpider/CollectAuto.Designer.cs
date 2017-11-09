using NovelSpider.Common;
using NovelSpider.Config;
using NovelSpider.Entity;
using NovelSpider.Local;
using NovelSpider.Target;
using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace NovelSpider
{
	public class CollectAuto : DockContent
	{
		public BackgroundWorker AutoWorker;

		private bool bool_0;

		private Button button_0;

		private Button button_1;

		private Button button_2;

		private DateTime dateTime_0;

		private FontDialog fontDialog_0;

		private IContainer icontainer_0;

		private Label label_16;

		private OpenFileDialog openFileDialog_0;

		public RuleConfigInfo rInfo;

		private SaveFileDialog saveFileDialog_0;

		private System.Windows.Forms.ContextMenuStrip SaveMenuStrip;

		private string string_0;

		private string string_1;

		private string string_2;

		private System.Windows.Forms.Timer timer_0;

		public TaskConfigInfo tInfo;

		private ToolStripMenuItem toolStripMenuItem_0;

		private ToolStripMenuItem toolStripMenuItem_1;

		private ToolStripMenuItem toolStripMenuItem_2;

		private ToolStripMenuItem toolStripMenuItem_3;

		private ToolStripSeparator toolStripSeparator_0;

		private IContainer components;

		private Button button_3;

		public BackgroundWorker LoginWorker;

		public BackgroundWorker TestWorker;

		private System.Windows.Forms.ContextMenuStrip TargetMenuStrip;

		private ToolStripMenuItem toolStripMenuItem_6;

		private ToolStripMenuItem toolStripMenuItem_25;

		private ToolStripSeparator toolStripSeparator_2;

		private ToolStripMenuItem toolStripMenuItem_8;

		private ToolStripMenuItem toolStripMenuItem_22;

		private ToolStripSeparator toolStripSeparator_3;

		private ToolStripMenuItem toolStripMenuItem_11;

		private ToolStripMenuItem toolStripMenuItem_23;

		private ToolStripMenuItem toolStripMenuItem_9;

		public BackgroundWorker HttpWorker;

		private TabPage tabPage2;

		private GroupBox groupBox8;

		private ListView listView1;

		private ColumnHeader columnHeader_12;

		private ColumnHeader columnHeader_13;

		private ColumnHeader columnHeader1;

		private ColumnHeader columnHeader2;

		private ColumnHeader columnHeader3;

		private ColumnHeader columnHeader4;

		private GroupBox groupBox_7;

		private Button button1;

		private CheckBox checkBox_19;

		private Label label_19;

		private TextBox textBox_14;

		private Label label_17;

		private Label label_18;

		private TextBox textBox_9;

		private TextBox textBox_10;

		private TextBox textBox_11;

		private TextBox textBox_12;

		private TabPage tabPage_4;

		private GroupBox groupBox_4;

		private Label label16;

		private Label label17;

		private Label label6;

		private Label label7;

		private Label label11;

		private Label label12;

		private Label label13;

		private Label label14;

		private Label label_13;

		private Label label_14;

		private Label label_15;

		private Label label_8;

		private Label label_9;

		private Label label_10;

		private GroupBox groupBox7;

		private CheckBox checkBox_20;

		private ProgressBar progressBar_1;

		private ProgressBar progressBar_0;

		private Label label_11;

		private Label label_12;

		private GroupBox groupBox_9;

		private Label label_21;

		private Label label_22;

		private Label label_23;

		private Label label_24;

		private NumericUpDown numericUpDown_3;

		private Label label_25;

		private NumericUpDown numericUpDown_4;

		private Label label_26;

		private NumericUpDown numericUpDown_5;

		private TabPage tabPage1;

		private GroupBox groupBox6;

		private Label label15;

		private CheckBox DelChapter;

		private Label label10;

		private Label label9;

		private NumericUpDown ReplaceChapterNun;

		private CheckBox ReplaceChapter;

		private GroupBox groupBox5;

		private CheckBox StrongReplaceIntro;

		private CheckBox StrongReplaceFullflag;

		private CheckBox StrongReplaceImgflag;

		private Label label8;

		private NumericUpDown ReplaceSortId;

		private CheckBox OnlyReplaceSort;

		private CheckBox ReplaceSort;

		private CheckBox ReplaceIntro;

		private CheckBox ReplaceFullflag;

		private CheckBox ReplaceImgflag;

		private GroupBox groupBox4;

		private Label label4;

		private TabPage tabPage_2;

		private GroupBox groupBox3;

		private TextBox FilterVolumeTextBox1;

		private GroupBox groupBox2;

		private TextBox FilterChapterNameBox1;

		private GroupBox groupBox1;

		private TextBox FilterChapterNameBox;

		private GroupBox groupBox_2;

		private TextBox FilterNovelTextBox;

		private ComboBox FilterNovelType;

		private GroupBox groupBox_3;

		private TextBox FilterVolumeTextBox;

		private TabPage tabPage_1;

		private GroupBox groupBox_5;

		private Label label3;

		private ComboBox comboBox1;

		private Label label_32;

		private ComboBox comboBox_7;

		private ComboBox comboBox_6;

		private Label label_31;

		private Label label_27;

		private ComboBox comboBox_5;

		private Label label_6;

		private ComboBox comboBox_1;

		private Label label_7;

		private ComboBox comboBox_2;

		private GroupBox groupBox_6;

		private Label label1;

		private Label label2;

		private NumericUpDown DonnotCollectLastChapterNum;

		private Label label_29;

		private NumericUpDown numericUpDown_6;

		private Label label_30;

		private Label label_2;

		private NumericUpDown numericUpDown_1;

		private Label label_3;

		private Label label_4;

		private Label label_5;

		private NumericUpDown numericUpDown_2;

		private CheckBox checkBox_15;

		private CheckBox HideBook;

		private CheckBox checkBox_22;

		private CheckBox checkBox_21;

		private CheckBox checkBox_18;

		private CheckBox checkBox_17;

		private CheckBox checkBox_0;

		private CheckBox checkBox_16;

		private CheckBox checkBox_1;

		private CheckBox checkBox_10;

		private CheckBox checkBox_8;

		private CheckBox checkBox_9;

		private CheckBox checkBox_6;

		private CheckBox checkBox_4;

		private TabPage tabPage_0;

		private TextBox textBox_18;

		private TextBox textBox_16;

		private TextBox textBox_17;

		private TextBox textBox_0;

		private TextBox textBox_1;

		private TextBox textBox_2;

		private TextBox textBox_3;

		private TextBox textBox_4;

		private TextBox textBox_5;

		private TextBox textBox_6;

		private RadioButton radioButton_5;

		private ComboBox comboBox_4;

		private Label label_20;

		private Label label_1;

		private ComboBox comboBox_0;

		private RadioButton radioButton_3;

		private RadioButton radioButton_4;

		private RadioButton radioButton_0;

		private RadioButton radioButton_1;

		private RadioButton radioButton_2;

		private Label label_0;

		private NumericUpDown numericUpDown_0;

		private CheckBox checkBox_2;

		private CheckBox checkBox_3;

		private TabControl tabControl_0;

		private CheckBox ReplaceChapterNameOn;

		private ToolTip toolTip_0;

		public CollectAuto()
		{
			Class19.Q77LubhzKM3NS();
			this.rInfo = new RuleConfigInfo();
			this.tInfo = new TaskConfigInfo();
			this.dateTime_0 = DateTime.Now;
			this.string_0 = "";
			Guid guid = Guid.NewGuid();
			this.string_1 = guid.ToString().ToUpper();
			this.string_2 = "";
			this.InitializeComponent();
		}

		public CollectAuto(bool bool_1)
		{
			Class19.Q77LubhzKM3NS();
			this.rInfo = new RuleConfigInfo();
			this.tInfo = new TaskConfigInfo();
			this.dateTime_0 = DateTime.Now;
			this.string_0 = "";
			this.string_1 = "";
			this.string_2 = "";
			this.InitializeComponent();
			this.bool_0 = bool_1;
		}

		private void AutoWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			this.AutoWorker.ReportProgress(2, Localization.Get("获得小说列表"));
			string radioBy = this.tInfo.RadioBy;
			if (radioBy != null)
			{
				if (radioBy == "GetListUrl")
				{
					string[] ids = (new Page(this.rInfo, this.tInfo)).GetIds(this.tInfo.GetListUrl);
					this.AutoWorker.ReportProgress(5, (int)ids.Length);
					this.method_1(ids, true);
				}
				else if (radioBy == "GetOrderId")
				{
					this.AutoWorker.ReportProgress(5, this.tInfo.GetOrderMaxId - this.tInfo.GetOrderMinId);
					this.method_2(this.tInfo.GetOrderMinId, this.tInfo.GetOrderMaxId, true);
				}
				else if (radioBy == "GetSinceId")
				{
					this.AutoWorker.ReportProgress(5, (int)this.tInfo.GetSinceId.Length);
					this.method_1(this.tInfo.GetSinceId, true);
				}
				else if (radioBy == "PutOrderId")
				{
					this.AutoWorker.ReportProgress(5, this.tInfo.PutOrderMaxId - this.tInfo.PutOrderMinId);
					this.method_2(this.tInfo.PutOrderMinId, this.tInfo.PutOrderMaxId, false);
				}
				else if (radioBy == "PutSinceId")
				{
					this.AutoWorker.ReportProgress(5, (int)this.tInfo.PutSinceId.Length);
					this.method_1(this.tInfo.PutSinceId, false);
				}
				else if (radioBy == "OtherListUrl")
				{
					string[] novelList = Page.GetNovelList(this.tInfo.OtherListUrl, this.tInfo.OtherRegex, this.tInfo.OtherEncoding);
					this.AutoWorker.ReportProgress(5, (int)this.tInfo.PutSinceId.Length);
					this.method_0(novelList);
				}
			}
			if (this.AutoWorker.CancellationPending)
			{
				e.Cancel = true;
			}
			else if (this.tInfo.UpdateDefault)
			{
				string[] updateDefaultUrls = Configs.BaseConfig.UpdateDefaultUrls;
				for (int i = 0; i < (int)updateDefaultUrls.Length; i++)
				{
					string str = updateDefaultUrls[i];
					if (string.IsNullOrEmpty(str))
					{
						break;
					}
					HttpClient httpClient = new HttpClient()
					{
						UriString = str
					};
					this.AutoWorker.ReportProgress(2, string.Concat(Localization.Get("执行"), str));
					httpClient.GetStringWork();
				}
			}
		}

		private void AutoWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			if (Configs.CmdModel)
			{
				switch (e.ProgressPercentage)
				{
					case 0:
					{
						Console.WriteLine(string.Concat(Localization.Get("当前小说："), e.UserState.ToString()));
						break;
					}
					case 1:
					{
						Console.WriteLine(string.Concat(Localization.Get("当前章节："), e.UserState.ToString()));
						break;
					}
					case 2:
					{
						Console.WriteLine(string.Concat(Localization.Get("当前动作："), e.UserState.ToString()));
						break;
					}
				}
			}
			switch (e.ProgressPercentage)
			{
				case 0:
				{
					this.label_15.Text = e.UserState.ToString();
					break;
				}
				case 1:
				{
					this.label_14.Text = e.UserState.ToString();
					break;
				}
				case 2:
				{
					this.label_13.Text = e.UserState.ToString();
					break;
				}
				case 3:
				{
					if (this.tInfo.NoPBar)
					{
						break;
					}
					int num = Convert.ToInt32(e.UserState);
					if (num > this.progressBar_1.Maximum || num < this.progressBar_1.Minimum)
					{
						break;
					}
					this.progressBar_1.Value = Convert.ToInt32(e.UserState);
					break;
				}
				case 4:
				{
					if (this.tInfo.NoPBar)
					{
						break;
					}
					int num1 = Convert.ToInt32(e.UserState);
					if (num1 > this.progressBar_0.Maximum || num1 < this.progressBar_0.Minimum)
					{
						break;
					}
					this.progressBar_0.Value = Convert.ToInt32(e.UserState);
					break;
				}
				case 5:
				{
					if (this.tInfo.NoPBar)
					{
						break;
					}
					this.progressBar_1.Maximum = Convert.ToInt32(e.UserState);
					break;
				}
				case 6:
				{
					if (this.tInfo.NoPBar)
					{
						break;
					}
					this.progressBar_0.Maximum = Convert.ToInt32(e.UserState);
					break;
				}
			}
		}

		private void AutoWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			DateTime now;
			if (e.Error != null)
			{
				SpiderException.Debug(this.tInfo.ID, string.Concat(Localization.Get("严重错误："), e.Error.Message));
				if (Configs.CmdModel)
				{
					Console.WriteLine(string.Concat(Localization.Get("严重错误："), e.Error.Message));
				}
				if (!this.tInfo.Timing)
				{
					MessageForm messageForm = new MessageForm()
					{
						Text = Localization.Get("错误提示")
					};
					messageForm.MessageText.Text = e.Error.Message;
					messageForm.ShowDialog();
					this.button_2.Enabled = true;
					this.button_0.Enabled = false;
				}
				else if (!this.tInfo.Log)
				{
					MessageForm message = new MessageForm()
					{
						Text = Localization.Get("错误提示")
					};
					message.MessageText.Text = e.Error.Message;
					message.ShowDialog();
					this.button_2.Enabled = true;
					this.button_0.Enabled = false;
				}
				else
				{
					this.label_13.Text = string.Concat(Localization.Get("错误提示："), e.Error.Message);
					SpiderException.Show(0, e.Error.Message, null, this.tInfo.Log, this.string_0, this.tInfo.RuleFile);
					this.timer_0.Start();
					now = DateTime.Now;
					this.dateTime_0 = now.AddMinutes((double)this.tInfo.Interval);
				}
			}
			else if (e.Cancelled)
			{
				this.label_13.Text = Localization.Get("操作取消");
				this.button_2.Enabled = true;
				this.button_0.Enabled = false;
			}
			else if (!this.tInfo.Timing)
			{
				this.label_13.Text = Localization.Get("操作完成");
				this.button_2.Enabled = true;
				this.button_0.Enabled = false;
			}
			else
			{
				this.timer_0.Start();
				now = DateTime.Now;
				this.dateTime_0 = now.AddMinutes((double)this.tInfo.Interval);
			}
			this.label7.Text = "-";
			Configs.TaskNovelInfo[this.string_2.ToString()] = null;
		}

		private void button_0_Click(object sender, EventArgs e)
		{
			this.button_0.Enabled = false;
			if (!this.AutoWorker.IsBusy)
			{
				if (this.timer_0.Enabled)
				{
					this.timer_0.Stop();
					this.label_13.Text = Localization.Get("操作取消");
				}
				this.button_2.Enabled = true;
				this.button_3.Enabled = true;
			}
			else
			{
				this.AutoWorker.CancelAsync();
			}
		}

		private void button_1_Click(object sender, EventArgs e)
		{
			if (!this.bool_0)
			{
				this.SaveMenuStrip.Show(this.button_1, 0, 23);
			}
			else
			{
				this.method_5();
				ConfigFileManager.SaveConfig("TaskConfig.xml", this.tInfo);
				base.DialogResult = System.Windows.Forms.DialogResult.OK;
			}
		}

		private void button_2_Click(object sender, EventArgs e)
		{
			if (Configs.BaseConfig.LicenseOk)
			{
				this.label6.Text = DateTime.Now.ToString();
				this.rInfo = (RuleConfigInfo)ConfigFileManager.LoadConfig(this.comboBox_0.Text, this.rInfo);
				this.method_5();
				if ((!this.tInfo.Proxy ? false : this.tInfo.ProxyHost.Trim() != string.Empty))
				{
					Label label = this.label7;
					string str = this.tInfo.ProxyHost.Trim();
					int proxyPort = this.tInfo.ProxyPort;
					label.Text = string.Concat(str, ":", proxyPort.ToString());
				}
				this.tInfo.ID = this.string_2;
				this.button_2.Enabled = false;
				this.button_0.Enabled = true;
				this.button_3.Enabled = false;
				this.tabControl_0.SelectedIndex = this.tabControl_0.TabCount - 2;
				DateTime now = DateTime.Now;
				this.dateTime_0 = now.AddMinutes((double)this.tInfo.Interval);
				if (!this.AutoWorker.IsBusy)
				{
					this.AutoWorker.RunWorkerAsync();
				}
			}
			else
			{
				MessageBox.Show(Localization.Get("授权码无效，请删除或清空根目录下xxxxxxx.ini文件"));
			}
		}

		private void button_3_Click(object sender, EventArgs e)
		{
			this.label_13.Text = Localization.Get("正在网络测速...");
			this.rInfo = (RuleConfigInfo)ConfigFileManager.LoadConfig(this.comboBox_0.Text, this.rInfo);
			this.method_5();
			this.tInfo.ID = this.string_2;
			this.button_2.Enabled = false;
			this.button_3.Enabled = false;
			this.button_0.Enabled = false;
			this.tabControl_0.SelectedIndex = this.tabControl_0.TabCount - 2;
			if (!this.HttpWorker.IsBusy)
			{
				this.HttpWorker.RunWorkerAsync();
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog()
			{
				Filter = "txt files|*.txt"
			};
			if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				string[] strArrays = File.ReadAllLines(openFileDialog.FileName);
				if ((int)strArrays.Length > 0)
				{
					ListViewItem[] listViewItem = new ListViewItem[(int)strArrays.Length];
					int num = 0;
					string[] strArrays1 = strArrays;
					for (int i = 0; i < (int)strArrays1.Length; i++)
					{
						string str = strArrays1[i].Trim();
						if (!string.IsNullOrEmpty(str))
						{
							string[] strArrays2 = str.Split(new char[] { ':' });
							if ((int)strArrays2.Length == 1)
							{
								if (SecurityUtil.IsIP(str))
								{
									listViewItem[num] = new ListViewItem(str);
									listViewItem[num].SubItems.Add("80");
									listViewItem[num].SubItems.Add("Unknown");
									listViewItem[num].SubItems.Add("-");
									listViewItem[num].SubItems.Add("-");
								}
							}
							else if ((!SecurityUtil.IsIP(strArrays2[0].Trim()) ? false : SecurityUtil.IsNum(strArrays2[1].Trim())))
							{
								listViewItem[num] = new ListViewItem(strArrays2[0].Trim());
								listViewItem[num].SubItems.Add(strArrays2[1].Trim());
								listViewItem[num].SubItems.Add("Unknown");
								listViewItem[num].SubItems.Add("-");
								listViewItem[num].SubItems.Add("-");
							}
							num++;
						}
					}
					this.listView1.Items.Clear();
					this.listView1.Items.AddRange(listViewItem);
				}
			}
		}

		public static bool CheckHost()
		{
			bool flag;
			string str = string.Concat(Environment.GetFolderPath(Environment.SpecialFolder.System), "\\drivers\\etc\\hosts");
			if (File.Exists(str))
			{
				string[] strArrays = File.ReadAllLines(str);
				int num = 0;
				while (num < (int)strArrays.Length)
				{
					string str1 = strArrays[num];
					if ((str1.Trim().StartsWith("#") ? false : str1.IndexOf("gg.soshuwang.com") >= 0))
					{
						flag = false;
						return flag;
					}
					else
					{
						num++;
					}
				}
			}
			flag = true;
			return flag;
		}

		private void CollectAuto_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!this.AutoWorker.IsBusy)
			{
				Configs.TaskNovelInfo.Remove(this.string_2);
			}
			else
			{
				this.AutoWorker.CancelAsync();
				e.Cancel = true;
				MessageBox.Show(Localization.Get("检查到采集进程正在运行，现在正在自动停止采集进程\n\n请在采集进程停止后关闭窗口！"), Localization.Get("信息提示"));
			}
		}

		private void CollectAuto_Load(object sender, EventArgs e)
		{
			this.label_16.Text = string.Concat(Localization.Get("通知："), Configs.BaseConfig.LicenseAd);
			Guid guid = Guid.NewGuid();
			this.string_2 = guid.ToString().ToUpper();
			this.label11.Text = this.string_2;
			if (!this.LoginWorker.IsBusy)
			{
				this.LoginWorker.RunWorkerAsync();
			}
			Configs.TaskNovelInfo.Add(this.string_2, null);
			CollectAuto collectAuto = this;
			string str = string.Concat(collectAuto.Text, " ", this.string_2);
			collectAuto.Text = str;
			this.tInfo = (TaskConfigInfo)ConfigFileManager.LoadConfig("TaskConfig.xml", this.tInfo);
			this.comboBox_0.BeginUpdate();
			string[] strArrays = IO.LoadRules();
			if ((int)strArrays.Length > 0)
			{
				for (int i = 0; i < (int)strArrays.Length; i++)
				{
					this.comboBox_0.Items.Add(strArrays[i]);
					if (strArrays[i] == this.tInfo.RuleFile)
					{
						this.comboBox_0.Text = this.tInfo.RuleFile;
						this.rInfo = (RuleConfigInfo)ConfigFileManager.LoadConfig(this.tInfo.RuleFile, this.rInfo);
						this.textBox_3.Text = this.rInfo.NovelListUrl.Pattern;
						if (!this.bool_0)
						{
							this.Text = string.Concat(this.rInfo.GetSiteName.Pattern, Localization.Get(" 标准采集模式"));
						}
					}
				}
			}
			this.comboBox_0.EndUpdate();
			this.comboBox_4.BeginUpdate();
			this.comboBox_4.Items.Add("TaskConfig.xml");
			this.comboBox_4.Text = "TaskConfig.xml";
			string[] strArrays1 = IO.LoadTasks();
			if ((int)strArrays1.Length > 0)
			{
				for (int j = 0; j < (int)strArrays1.Length; j++)
				{
					this.comboBox_4.Items.Add(strArrays1[j]);
				}
			}
			this.comboBox_4.EndUpdate();
			this.method_4();
			if (this.bool_0)
			{
				this.comboBox_4.Enabled = false;
				this.label_16.Visible = false;
				this.button_2.Visible = false;
				this.button_0.Visible = false;
				this.Text = Localization.Get("设置手动方案");
				this.button_1.Text = Localization.Get("保存");
			}
		}

		private void comboBox_0_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.comboBox_0.Items.Count != -1)
			{
				this.rInfo = (RuleConfigInfo)ConfigFileManager.LoadConfig(this.comboBox_0.Text, this.rInfo);
			}
			else
			{
				MessageBox.Show(Localization.Get("你没有选择任何项目"));
			}
			this.textBox_3.Text = this.rInfo.NovelListUrl.Pattern;
			if (!this.bool_0)
			{
				this.Text = string.Concat(this.rInfo.GetSiteName.Pattern, Localization.Get(" 标准采集模式"));
			}
		}

		private void comboBox_4_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.string_0 = this.comboBox_4.Text;
			FileInfo fileInfo = new FileInfo(this.string_0);
			this.tInfo = (TaskConfigInfo)ConfigFileManager.LoadConfig(this.string_0, this.tInfo);
			this.method_4();
			this.rInfo = (RuleConfigInfo)ConfigFileManager.LoadConfig(this.comboBox_0.Text, this.rInfo);
			if (!this.bool_0)
			{
				this.Text = string.Concat(this.rInfo.GetSiteName.Pattern, Localization.Get(" 标准采集模式"));
			}
		}

		protected override void Dispose(bool disposing)
		{
			if ((!disposing ? false : this.icontainer_0 != null))
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		private void HttpWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			HttpClient httpClient = new HttpClient()
			{
				UriString = this.rInfo.NovelListUrl.Pattern,
				Encoding = Encoding.GetEncoding(this.rInfo.GetSiteCharset.Pattern),
				Proxy = this.tInfo.Proxy,
				ProxyHost = this.tInfo.ProxyHost,
				ProxyPort = this.tInfo.ProxyPort,
				ProxyDomain = this.tInfo.ProxyDomain,
				ProxyUser = this.tInfo.ProxyUser,
				ProxyPassword = this.tInfo.ProxyPassword
			};
			HttpClient httpClient1 = httpClient;
			string str = "";
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			string stringWork = httpClient1.GetStringWork();
			if (stringWork != string.Empty)
			{
				double totalSeconds = stopwatch.Elapsed.TotalSeconds;
				str = string.Concat(totalSeconds.ToString("0.000"), "sec");
			}
			string str1 = Localization.Get("测试完成，");
			str1 = (!this.tInfo.Proxy ? string.Concat(str1, Localization.Get("本机访问")) : string.Concat(str1, Localization.Get("代理IP("), this.tInfo.ProxyHost, Localization.Get(")访问")));
			if (str != string.Empty)
			{
				double length = (double)stringWork.Length / 1024;
				string str2 = str1;
				string[] strArrays = new string[] { str2, Localization.Get("抓取"), length.ToString("0.000"), Localization.Get("k字节耗时"), str };
				str1 = string.Concat(strArrays);
			}
			else
			{
				str1 = string.Concat(str1, Localization.Get("不可用"));
			}
			base.Invoke(new EventHandler((object argument0, EventArgs argument1) => this.label_13.Text = str1));
		}

		private void HttpWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
		}

		private void HttpWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.button_2.Enabled = true;
			this.button_3.Enabled = true;
			this.button_0.Enabled = false;
			this.label6.Text = "--";
			this.label7.Text = "--";
		}

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(CollectAuto));
			this.button_2 = new Button();
			this.button_0 = new Button();
			this.TargetMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.toolStripMenuItem_6 = new ToolStripMenuItem();
			this.toolStripMenuItem_25 = new ToolStripMenuItem();
			this.toolStripSeparator_2 = new ToolStripSeparator();
			this.toolStripMenuItem_8 = new ToolStripMenuItem();
			this.toolStripMenuItem_22 = new ToolStripMenuItem();
			this.toolStripSeparator_3 = new ToolStripSeparator();
			this.toolStripMenuItem_9 = new ToolStripMenuItem();
			this.toolStripMenuItem_11 = new ToolStripMenuItem();
			this.toolStripMenuItem_23 = new ToolStripMenuItem();
			this.toolTip_0 = new ToolTip(this.components);
			this.groupBox_3 = new GroupBox();
			this.FilterVolumeTextBox = new TextBox();
			this.FilterNovelTextBox = new TextBox();
			this.groupBox1 = new GroupBox();
			this.FilterChapterNameBox = new TextBox();
			this.groupBox2 = new GroupBox();
			this.FilterChapterNameBox1 = new TextBox();
			this.groupBox3 = new GroupBox();
			this.FilterVolumeTextBox1 = new TextBox();
			this.checkBox_4 = new CheckBox();
			this.checkBox_6 = new CheckBox();
			this.checkBox_8 = new CheckBox();
			this.checkBox_1 = new CheckBox();
			this.checkBox_16 = new CheckBox();
			this.checkBox_0 = new CheckBox();
			this.checkBox_18 = new CheckBox();
			this.checkBox_22 = new CheckBox();
			this.checkBox_3 = new CheckBox();
			this.checkBox_2 = new CheckBox();
			this.numericUpDown_0 = new NumericUpDown();
			this.textBox_6 = new TextBox();
			this.textBox_5 = new TextBox();
			this.textBox_4 = new TextBox();
			this.textBox_3 = new TextBox();
			this.textBox_2 = new TextBox();
			this.textBox_1 = new TextBox();
			this.textBox_0 = new TextBox();
			this.textBox_17 = new TextBox();
			this.textBox_16 = new TextBox();
			this.textBox_18 = new TextBox();
			this.AutoWorker = new BackgroundWorker();
			this.label_16 = new Label();
			this.button_1 = new Button();
			this.timer_0 = new System.Windows.Forms.Timer(this.components);
			this.SaveMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.toolStripMenuItem_3 = new ToolStripMenuItem();
			this.toolStripMenuItem_0 = new ToolStripMenuItem();
			this.toolStripSeparator_0 = new ToolStripSeparator();
			this.toolStripMenuItem_1 = new ToolStripMenuItem();
			this.toolStripMenuItem_2 = new ToolStripMenuItem();
			this.fontDialog_0 = new FontDialog();
			this.openFileDialog_0 = new OpenFileDialog();
			this.saveFileDialog_0 = new SaveFileDialog();
			this.button_3 = new Button();
			this.LoginWorker = new BackgroundWorker();
			this.TestWorker = new BackgroundWorker();
			this.HttpWorker = new BackgroundWorker();
			this.tabPage2 = new TabPage();
			this.groupBox8 = new GroupBox();
			this.listView1 = new ListView();
			this.columnHeader_12 = new ColumnHeader();
			this.columnHeader_13 = new ColumnHeader();
			this.columnHeader1 = new ColumnHeader();
			this.columnHeader2 = new ColumnHeader();
			this.columnHeader3 = new ColumnHeader();
			this.columnHeader4 = new ColumnHeader();
			this.groupBox_7 = new GroupBox();
			this.button1 = new Button();
			this.checkBox_19 = new CheckBox();
			this.label_19 = new Label();
			this.textBox_14 = new TextBox();
			this.label_17 = new Label();
			this.label_18 = new Label();
			this.textBox_9 = new TextBox();
			this.textBox_10 = new TextBox();
			this.textBox_11 = new TextBox();
			this.textBox_12 = new TextBox();
			this.tabPage_4 = new TabPage();
			this.groupBox_4 = new GroupBox();
			this.label16 = new Label();
			this.label17 = new Label();
			this.label6 = new Label();
			this.label7 = new Label();
			this.label11 = new Label();
			this.label12 = new Label();
			this.label13 = new Label();
			this.label14 = new Label();
			this.label_13 = new Label();
			this.label_14 = new Label();
			this.label_15 = new Label();
			this.label_8 = new Label();
			this.label_9 = new Label();
			this.label_10 = new Label();
			this.groupBox7 = new GroupBox();
			this.checkBox_20 = new CheckBox();
			this.progressBar_1 = new ProgressBar();
			this.progressBar_0 = new ProgressBar();
			this.label_11 = new Label();
			this.label_12 = new Label();
			this.groupBox_9 = new GroupBox();
			this.label_21 = new Label();
			this.label_22 = new Label();
			this.label_23 = new Label();
			this.label_24 = new Label();
			this.numericUpDown_3 = new NumericUpDown();
			this.label_25 = new Label();
			this.numericUpDown_4 = new NumericUpDown();
			this.label_26 = new Label();
			this.numericUpDown_5 = new NumericUpDown();
			this.tabPage1 = new TabPage();
			this.groupBox6 = new GroupBox();
			this.label15 = new Label();
			this.DelChapter = new CheckBox();
			this.label10 = new Label();
			this.label9 = new Label();
			this.ReplaceChapterNun = new NumericUpDown();
			this.ReplaceChapter = new CheckBox();
			this.groupBox5 = new GroupBox();
			this.StrongReplaceIntro = new CheckBox();
			this.StrongReplaceFullflag = new CheckBox();
			this.StrongReplaceImgflag = new CheckBox();
			this.label8 = new Label();
			this.ReplaceSortId = new NumericUpDown();
			this.OnlyReplaceSort = new CheckBox();
			this.ReplaceSort = new CheckBox();
			this.ReplaceIntro = new CheckBox();
			this.ReplaceFullflag = new CheckBox();
			this.ReplaceImgflag = new CheckBox();
			this.groupBox4 = new GroupBox();
			this.label4 = new Label();
			this.tabPage_2 = new TabPage();
			this.groupBox_2 = new GroupBox();
			this.FilterNovelType = new ComboBox();
			this.tabPage_1 = new TabPage();
			this.groupBox_5 = new GroupBox();
			this.label3 = new Label();
			this.comboBox1 = new ComboBox();
			this.label_32 = new Label();
			this.comboBox_7 = new ComboBox();
			this.comboBox_6 = new ComboBox();
			this.label_31 = new Label();
			this.label_27 = new Label();
			this.comboBox_5 = new ComboBox();
			this.label_6 = new Label();
			this.comboBox_1 = new ComboBox();
			this.label_7 = new Label();
			this.comboBox_2 = new ComboBox();
			this.groupBox_6 = new GroupBox();
			this.label1 = new Label();
			this.label2 = new Label();
			this.DonnotCollectLastChapterNum = new NumericUpDown();
			this.label_29 = new Label();
			this.numericUpDown_6 = new NumericUpDown();
			this.label_30 = new Label();
			this.label_2 = new Label();
			this.numericUpDown_1 = new NumericUpDown();
			this.label_3 = new Label();
			this.label_4 = new Label();
			this.label_5 = new Label();
			this.numericUpDown_2 = new NumericUpDown();
			this.checkBox_15 = new CheckBox();
			this.HideBook = new CheckBox();
			this.checkBox_21 = new CheckBox();
			this.checkBox_17 = new CheckBox();
			this.checkBox_10 = new CheckBox();
			this.checkBox_9 = new CheckBox();
			this.tabPage_0 = new TabPage();
			this.radioButton_5 = new RadioButton();
			this.comboBox_4 = new ComboBox();
			this.label_20 = new Label();
			this.label_1 = new Label();
			this.comboBox_0 = new ComboBox();
			this.radioButton_3 = new RadioButton();
			this.radioButton_4 = new RadioButton();
			this.radioButton_0 = new RadioButton();
			this.radioButton_1 = new RadioButton();
			this.radioButton_2 = new RadioButton();
			this.label_0 = new Label();
			this.tabControl_0 = new TabControl();
			this.ReplaceChapterNameOn = new CheckBox();
			this.TargetMenuStrip.SuspendLayout();
			this.groupBox_3.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((ISupportInitialize)this.numericUpDown_0).BeginInit();
			this.SaveMenuStrip.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.groupBox8.SuspendLayout();
			this.groupBox_7.SuspendLayout();
			this.tabPage_4.SuspendLayout();
			this.groupBox_4.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.groupBox_9.SuspendLayout();
			((ISupportInitialize)this.numericUpDown_3).BeginInit();
			((ISupportInitialize)this.numericUpDown_4).BeginInit();
			((ISupportInitialize)this.numericUpDown_5).BeginInit();
			this.tabPage1.SuspendLayout();
			this.groupBox6.SuspendLayout();
			((ISupportInitialize)this.ReplaceChapterNun).BeginInit();
			this.groupBox5.SuspendLayout();
			((ISupportInitialize)this.ReplaceSortId).BeginInit();
			this.groupBox4.SuspendLayout();
			this.tabPage_2.SuspendLayout();
			this.groupBox_2.SuspendLayout();
			this.tabPage_1.SuspendLayout();
			this.groupBox_5.SuspendLayout();
			this.groupBox_6.SuspendLayout();
			((ISupportInitialize)this.DonnotCollectLastChapterNum).BeginInit();
			((ISupportInitialize)this.numericUpDown_6).BeginInit();
			((ISupportInitialize)this.numericUpDown_1).BeginInit();
			((ISupportInitialize)this.numericUpDown_2).BeginInit();
			this.tabPage_0.SuspendLayout();
			this.tabControl_0.SuspendLayout();
			base.SuspendLayout();
			this.button_2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			this.button_2.Location = new Point(497, 358);
			this.button_2.Name = "button_2";
			this.button_2.Size = new System.Drawing.Size(75, 23);
			this.button_2.TabIndex = 14;
			this.button_2.Text = Localization.Get("开始");
			this.button_2.UseVisualStyleBackColor = true;
			this.button_2.Click += new EventHandler(this.button_2_Click);
			this.button_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			this.button_0.Enabled = false;
			this.button_0.Location = new Point(578, 358);
			this.button_0.Name = "button_0";
			this.button_0.Size = new System.Drawing.Size(75, 23);
			this.button_0.TabIndex = 15;
			this.button_0.Text = Localization.Get("停止");
			this.button_0.UseVisualStyleBackColor = true;
			this.button_0.Click += new EventHandler(this.button_0_Click);
			ToolStripItemCollection items = this.TargetMenuStrip.Items;
			ToolStripItem[] toolStripMenuItem6 = new ToolStripItem[] { this.toolStripMenuItem_6, this.toolStripMenuItem_25, this.toolStripSeparator_2, this.toolStripMenuItem_8, this.toolStripMenuItem_22, this.toolStripSeparator_3, this.toolStripMenuItem_9, this.toolStripMenuItem_11, this.toolStripMenuItem_23 };
			items.AddRange(toolStripMenuItem6);
			this.TargetMenuStrip.Name = "TargetMenuStrip";
			this.TargetMenuStrip.Size = new System.Drawing.Size(149, 170);
			this.toolStripMenuItem_6.Name = "toolStripMenuItem_6";
			this.toolStripMenuItem_6.Size = new System.Drawing.Size(148, 22);
			this.toolStripMenuItem_6.Text = Localization.Get("设为代理");
			this.toolStripMenuItem_6.Click += new EventHandler(this.toolStripMenuItem_6_Click);
			this.toolStripMenuItem_25.Name = "toolStripMenuItem_25";
			this.toolStripMenuItem_25.Size = new System.Drawing.Size(148, 22);
			this.toolStripMenuItem_25.Text = Localization.Get("验证可用性");
			this.toolStripMenuItem_25.Click += new EventHandler(this.toolStripMenuItem_25_Click);
			this.toolStripSeparator_2.Name = "toolStripSeparator_2";
			this.toolStripSeparator_2.Size = new System.Drawing.Size(145, 6);
			this.toolStripMenuItem_8.Name = "toolStripMenuItem_8";
			this.toolStripMenuItem_8.Size = new System.Drawing.Size(148, 22);
			this.toolStripMenuItem_8.Text = Localization.Get("全部选中");
			this.toolStripMenuItem_8.Click += new EventHandler(this.toolStripMenuItem_8_Click);
			this.toolStripMenuItem_22.Name = "toolStripMenuItem_22";
			this.toolStripMenuItem_22.Size = new System.Drawing.Size(148, 22);
			this.toolStripMenuItem_22.Text = Localization.Get("全部不选中");
			this.toolStripMenuItem_22.Click += new EventHandler(this.toolStripMenuItem_22_Click);
			this.toolStripSeparator_3.Name = "toolStripSeparator_3";
			this.toolStripSeparator_3.Size = new System.Drawing.Size(145, 6);
			this.toolStripMenuItem_9.Name = "toolStripMenuItem_9";
			this.toolStripMenuItem_9.Size = new System.Drawing.Size(148, 22);
			this.toolStripMenuItem_9.Text = Localization.Get("删除选中");
			this.toolStripMenuItem_9.Click += new EventHandler(this.toolStripMenuItem_9_Click);
			this.toolStripMenuItem_11.Name = "toolStripMenuItem_11";
			this.toolStripMenuItem_11.Size = new System.Drawing.Size(148, 22);
			this.toolStripMenuItem_11.Text = Localization.Get("清空列表");
			this.toolStripMenuItem_11.Click += new EventHandler(this.toolStripMenuItem_11_Click);
			this.toolStripMenuItem_23.Name = "toolStripMenuItem_23";
			this.toolStripMenuItem_23.Size = new System.Drawing.Size(148, 22);
			this.toolStripMenuItem_23.Text = Localization.Get("重新加载列表");
			this.toolStripMenuItem_23.Click += new EventHandler(this.toolStripMenuItem_23_Click);
			this.toolTip_0.AutomaticDelay = 100;
			this.toolTip_0.AutoPopDelay = 50000;
			this.toolTip_0.InitialDelay = 100;
			this.toolTip_0.ReshowDelay = 20;
			this.toolTip_0.ShowAlways = true;
			this.toolTip_0.ToolTipIcon = ToolTipIcon.Info;
			this.toolTip_0.ToolTipTitle = Localization.Get("提示");
			this.groupBox_3.Controls.Add(this.FilterVolumeTextBox);
			this.groupBox_3.Location = new Point(218, 13);
			this.groupBox_3.Name = "groupBox_3";
			this.groupBox_3.Size = new System.Drawing.Size(188, 145);
			this.groupBox_3.TabIndex = 1;
			this.groupBox_3.TabStop = false;
			this.groupBox_3.Text = Localization.Get("过滤分卷（跳过本分卷）");
			this.toolTip_0.SetToolTip(this.groupBox_3, Localization.Get("过滤格式：\n分卷名\u3000\u3000\u3000\u3000这种过滤所有书的这个分卷\n书名♂分卷\u3000\u3000只过滤某本书的某个分卷"));
			this.FilterVolumeTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.FilterVolumeTextBox.Location = new Point(3, 20);
			this.FilterVolumeTextBox.Multiline = true;
			this.FilterVolumeTextBox.Name = "FilterVolumeTextBox";
			this.FilterVolumeTextBox.ScrollBars = ScrollBars.Vertical;
			this.FilterVolumeTextBox.Size = new System.Drawing.Size(179, 119);
			this.FilterVolumeTextBox.TabIndex = 0;
			this.toolTip_0.SetToolTip(this.FilterVolumeTextBox, Localization.Get("请输入分卷名称，一行一个。"));
			this.FilterNovelTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.FilterNovelTextBox.Location = new Point(8, 46);
			this.FilterNovelTextBox.Multiline = true;
			this.FilterNovelTextBox.Name = "FilterNovelTextBox";
			this.FilterNovelTextBox.ScrollBars = ScrollBars.Vertical;
			this.FilterNovelTextBox.Size = new System.Drawing.Size(192, 242);
			this.FilterNovelTextBox.TabIndex = 8;
			this.toolTip_0.SetToolTip(this.FilterNovelTextBox, Localization.Get("请输入小说名称，一行一个。"));
			this.groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.groupBox1.Controls.Add(this.FilterChapterNameBox);
			this.groupBox1.Location = new Point(412, 13);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(387, 145);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = Localization.Get("过滤章节名（跳过本书）");
			this.toolTip_0.SetToolTip(this.groupBox1, Localization.Get("过滤格式：\r\n章节名\u3000\u3000\u3000\u3000这种过滤所有书的这个章节\r\n书名♂章节名\u3000\u3000只过滤某本书的某个章节"));
			this.FilterChapterNameBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.FilterChapterNameBox.Location = new Point(3, 20);
			this.FilterChapterNameBox.Multiline = true;
			this.FilterChapterNameBox.Name = "FilterChapterNameBox";
			this.FilterChapterNameBox.ScrollBars = ScrollBars.Vertical;
			this.FilterChapterNameBox.Size = new System.Drawing.Size(378, 119);
			this.FilterChapterNameBox.TabIndex = 0;
			this.toolTip_0.SetToolTip(this.FilterChapterNameBox, Localization.Get("请输入章节名称，一行一个。"));
			this.groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.groupBox2.Controls.Add(this.FilterChapterNameBox1);
			this.groupBox2.Location = new Point(412, 164);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(384, 143);
			this.groupBox2.TabIndex = 4;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = Localization.Get("过滤章节名（继续采集）");
			this.toolTip_0.SetToolTip(this.groupBox2, Localization.Get("过滤格式：\r\n章节名\u3000\u3000\u3000\u3000这种过滤所有书的这个章节\r\n书名♂章节名\u3000\u3000只过滤某本书的某个章节"));
			this.FilterChapterNameBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.FilterChapterNameBox1.Location = new Point(3, 20);
			this.FilterChapterNameBox1.Multiline = true;
			this.FilterChapterNameBox1.Name = "FilterChapterNameBox1";
			this.FilterChapterNameBox1.ScrollBars = ScrollBars.Vertical;
			this.FilterChapterNameBox1.Size = new System.Drawing.Size(375, 117);
			this.FilterChapterNameBox1.TabIndex = 0;
			this.toolTip_0.SetToolTip(this.FilterChapterNameBox1, Localization.Get("请输入章节名称，一行一个。"));
			this.groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
			this.groupBox3.Controls.Add(this.FilterVolumeTextBox1);
			this.groupBox3.Location = new Point(218, 164);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(188, 143);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = Localization.Get("过滤分卷（继续采集）");
			this.toolTip_0.SetToolTip(this.groupBox3, Localization.Get("过滤格式：\n分卷名\u3000\u3000\u3000\u3000这种过滤所有书的这个分卷\n书名♂分卷\u3000\u3000只过滤某本书的某个分卷"));
			this.FilterVolumeTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.FilterVolumeTextBox1.Location = new Point(3, 20);
			this.FilterVolumeTextBox1.Multiline = true;
			this.FilterVolumeTextBox1.Name = "FilterVolumeTextBox1";
			this.FilterVolumeTextBox1.ScrollBars = ScrollBars.Vertical;
			this.FilterVolumeTextBox1.Size = new System.Drawing.Size(179, 117);
			this.FilterVolumeTextBox1.TabIndex = 0;
			this.toolTip_0.SetToolTip(this.FilterVolumeTextBox1, Localization.Get("请输入分卷名称，一行一个。"));
			this.checkBox_4.AutoSize = true;
			this.checkBox_4.Location = new Point(6, 64);
			this.checkBox_4.Name = "checkBox_4";
			this.checkBox_4.Size = new System.Drawing.Size(96, 16);
			this.checkBox_4.TabIndex = 7;
			this.checkBox_4.Text = Localization.Get("禁止添加分卷");
			this.toolTip_0.SetToolTip(this.checkBox_4, Localization.Get("入库章节的时候不考虑分卷问题，直接追加在最后一个分卷后面。"));
			this.checkBox_4.UseVisualStyleBackColor = true;
			this.checkBox_6.AutoSize = true;
			this.checkBox_6.ForeColor = Color.Gray;
			this.checkBox_6.Location = new Point(6, 86);
			this.checkBox_6.Name = "checkBox_6";
			this.checkBox_6.Size = new System.Drawing.Size(168, 16);
			this.checkBox_6.TabIndex = 5;
			this.checkBox_6.Text = Localization.Get("对比章节失败自动清空重采");
			this.toolTip_0.SetToolTip(this.checkBox_6, Localization.Get("对比最新章节失败的时候自动清空所有旧的章节重新采集，不建议使用，不利于SEO"));
			this.checkBox_6.UseVisualStyleBackColor = true;
			this.checkBox_8.AutoSize = true;
			this.checkBox_8.Location = new Point(426, 20);
			this.checkBox_8.Name = "checkBox_8";
			this.checkBox_8.Size = new System.Drawing.Size(120, 16);
			this.checkBox_8.TabIndex = 2;
			this.checkBox_8.Text = Localization.Get("不处理已完成小说");
			this.toolTip_0.SetToolTip(this.checkBox_8, Localization.Get("本站标记已完成的小说不进行任何操作。"));
			this.checkBox_8.UseVisualStyleBackColor = true;
			this.checkBox_1.AutoSize = true;
			this.checkBox_1.Location = new Point(200, 20);
			this.checkBox_1.Name = "checkBox_1";
			this.checkBox_1.Size = new System.Drawing.Size(96, 16);
			this.checkBox_1.TabIndex = 1;
			this.checkBox_1.Text = Localization.Get("更新连载章节");
			this.toolTip_0.SetToolTip(this.checkBox_1, Localization.Get("采集过程中需要更新旧书章节吗？"));
			this.checkBox_1.UseVisualStyleBackColor = true;
			this.checkBox_16.AutoSize = true;
			this.checkBox_16.Location = new Point(200, 42);
			this.checkBox_16.Name = "checkBox_16";
			this.checkBox_16.Size = new System.Drawing.Size(120, 16);
			this.checkBox_16.TabIndex = 4;
			this.checkBox_16.Text = Localization.Get("自动排版章节内容");
			this.toolTip_0.SetToolTip(this.checkBox_16, Localization.Get("章节内容自动重新排版。"));
			this.checkBox_16.UseVisualStyleBackColor = true;
			this.checkBox_0.AutoSize = true;
			this.checkBox_0.Location = new Point(6, 20);
			this.checkBox_0.Name = "checkBox_0";
			this.checkBox_0.Size = new System.Drawing.Size(72, 16);
			this.checkBox_0.TabIndex = 0;
			this.checkBox_0.Text = Localization.Get("添加新书");
			this.toolTip_0.SetToolTip(this.checkBox_0, Localization.Get("采集过程中遇到新书是否添加？"));
			this.checkBox_0.UseVisualStyleBackColor = true;
			this.checkBox_18.AutoSize = true;
			this.checkBox_18.ForeColor = Color.Gray;
			this.checkBox_18.Location = new Point(200, 86);
			this.checkBox_18.Name = "checkBox_18";
			this.checkBox_18.Size = new System.Drawing.Size(132, 16);
			this.checkBox_18.TabIndex = 11;
			this.checkBox_18.Text = Localization.Get("强制清空重采(慎用)");
			this.toolTip_0.SetToolTip(this.checkBox_18, Localization.Get("对比最新章节失败的时候自动清空所有旧的章节重新采集，不建议使用，不利于SEO"));
			this.checkBox_18.UseVisualStyleBackColor = true;
			this.checkBox_22.AutoSize = true;
			this.checkBox_22.Location = new Point(426, 86);
			this.checkBox_22.Name = "checkBox_22";
			this.checkBox_22.Size = new System.Drawing.Size(132, 16);
			this.checkBox_22.TabIndex = 13;
			this.checkBox_22.Text = Localization.Get("检测目标站重复章节");
			this.toolTip_0.SetToolTip(this.checkBox_22, Localization.Get("只检查需要入库的第一个章节\n判断方式调用下面设置的对比方式。"));
			this.checkBox_22.UseVisualStyleBackColor = true;
			this.checkBox_3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			this.checkBox_3.AutoSize = true;
			this.checkBox_3.Location = new Point(459, 287);
			this.checkBox_3.Name = "checkBox_3";
			this.checkBox_3.Size = new System.Drawing.Size(72, 16);
			this.checkBox_3.TabIndex = 15;
			this.checkBox_3.Text = Localization.Get("日志记录");
			this.toolTip_0.SetToolTip(this.checkBox_3, Localization.Get("当发生错误是，以日志形式记录，不弹出错误提示框。"));
			this.checkBox_3.UseVisualStyleBackColor = true;
			this.checkBox_2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			this.checkBox_2.AutoSize = true;
			this.checkBox_2.Location = new Point(537, 287);
			this.checkBox_2.Name = "checkBox_2";
			this.checkBox_2.Size = new System.Drawing.Size(72, 16);
			this.checkBox_2.TabIndex = 16;
			this.checkBox_2.Text = Localization.Get("循环采集");
			this.toolTip_0.SetToolTip(this.checkBox_2, Localization.Get("当一次采集完成后，等待N分钟间隔时间，开始下次循环。"));
			this.checkBox_2.UseVisualStyleBackColor = true;
			this.numericUpDown_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			this.numericUpDown_0.Location = new Point(746, 286);
			NumericUpDown numericUpDown0 = this.numericUpDown_0;
			int[] numArray = new int[] { 10000, 0, 0, 0 };
			numericUpDown0.Maximum = new decimal(numArray);
			this.numericUpDown_0.Name = "numericUpDown_0";
			this.numericUpDown_0.Size = new System.Drawing.Size(50, 21);
			this.numericUpDown_0.TabIndex = 19;
			this.toolTip_0.SetToolTip(this.numericUpDown_0, Localization.Get("2次采集中间的间隔时间。"));
			this.textBox_6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			this.textBox_6.Location = new Point(144, 152);
			this.textBox_6.Name = "textBox_6";
			this.textBox_6.Size = new System.Drawing.Size(100, 21);
			this.textBox_6.TabIndex = 4;
			this.toolTip_0.SetToolTip(this.textBox_6, Localization.Get("开始编号"));
			this.textBox_5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.textBox_5.Location = new Point(250, 152);
			this.textBox_5.Name = "textBox_5";
			this.textBox_5.Size = new System.Drawing.Size(546, 21);
			this.textBox_5.TabIndex = 5;
			this.toolTip_0.SetToolTip(this.textBox_5, Localization.Get("结束编号"));
			this.textBox_4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.textBox_4.Location = new Point(144, 179);
			this.textBox_4.Name = "textBox_4";
			this.textBox_4.Size = new System.Drawing.Size(652, 21);
			this.textBox_4.TabIndex = 7;
			this.toolTip_0.SetToolTip(this.textBox_4, Localization.Get("自定义编号，用\",\"分割(英文半角)"));
			this.textBox_3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.textBox_3.Location = new Point(6, 54);
			this.textBox_3.Multiline = true;
			this.textBox_3.Name = "textBox_3";
			this.textBox_3.ScrollBars = ScrollBars.Vertical;
			this.textBox_3.Size = new System.Drawing.Size(790, 92);
			this.textBox_3.TabIndex = 2;
			this.toolTip_0.SetToolTip(this.textBox_3, Localization.Get("一行一个地址。"));
			this.textBox_2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			this.textBox_2.Location = new Point(144, 206);
			this.textBox_2.Name = "textBox_2";
			this.textBox_2.Size = new System.Drawing.Size(100, 21);
			this.textBox_2.TabIndex = 10;
			this.toolTip_0.SetToolTip(this.textBox_2, Localization.Get("开始编号"));
			this.textBox_1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.textBox_1.Location = new Point(250, 206);
			this.textBox_1.Name = "textBox_1";
			this.textBox_1.Size = new System.Drawing.Size(546, 21);
			this.textBox_1.TabIndex = 11;
			this.toolTip_0.SetToolTip(this.textBox_1, Localization.Get("结束编号"));
			this.textBox_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.textBox_0.Location = new Point(144, 233);
			this.textBox_0.Name = "textBox_0";
			this.textBox_0.Size = new System.Drawing.Size(652, 21);
			this.textBox_0.TabIndex = 13;
			this.toolTip_0.SetToolTip(this.textBox_0, Localization.Get("自定义编号，用\",\"分割(英文半角)"));
			this.textBox_17.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			this.textBox_17.Location = new Point(144, 259);
			this.textBox_17.Name = "textBox_17";
			this.textBox_17.Size = new System.Drawing.Size(100, 21);
			this.textBox_17.TabIndex = 34;
			this.toolTip_0.SetToolTip(this.textBox_17, Localization.Get("其他站URL地址"));
			this.textBox_16.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.textBox_16.Location = new Point(311, 259);
			this.textBox_16.Name = "textBox_16";
			this.textBox_16.Size = new System.Drawing.Size(485, 21);
			this.textBox_16.TabIndex = 35;
			this.toolTip_0.SetToolTip(this.textBox_16, Localization.Get("提取小说名规则"));
			this.textBox_18.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			this.textBox_18.Location = new Point(250, 259);
			this.textBox_18.Name = "textBox_18";
			this.textBox_18.Size = new System.Drawing.Size(55, 21);
			this.textBox_18.TabIndex = 36;
			this.toolTip_0.SetToolTip(this.textBox_18, Localization.Get("其他站URL地址"));
			this.AutoWorker.WorkerReportsProgress = true;
			this.AutoWorker.WorkerSupportsCancellation = true;
			this.AutoWorker.DoWork += new DoWorkEventHandler(this.AutoWorker_DoWork);
			this.AutoWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.AutoWorker_RunWorkerCompleted);
			this.AutoWorker.ProgressChanged += new ProgressChangedEventHandler(this.AutoWorker_ProgressChanged);
			this.label_16.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			this.label_16.AutoSize = true;
			this.label_16.Location = new Point(10, 363);
			this.label_16.Name = "label_16";
			this.label_16.Size = new System.Drawing.Size(197, 12);
			this.label_16.TabIndex = 19;
			this.label_16.Text = Localization.Get("注意：采集过程中，改动设置无效。");
			this.button_1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			this.button_1.Location = new Point(743, 358);
			this.button_1.Name = "button_1";
			this.button_1.Size = new System.Drawing.Size(75, 23);
			this.button_1.TabIndex = 20;
			this.button_1.Text = Localization.Get("采集方案");
			this.button_1.UseVisualStyleBackColor = true;
			this.button_1.Click += new EventHandler(this.button_1_Click);
			this.timer_0.Interval = 1000;
			this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
			ToolStripItemCollection toolStripItemCollections = this.SaveMenuStrip.Items;
			toolStripMenuItem6 = new ToolStripItem[] { this.toolStripMenuItem_3, this.toolStripMenuItem_0, this.toolStripSeparator_0, this.toolStripMenuItem_1, this.toolStripMenuItem_2 };
			toolStripItemCollections.AddRange(toolStripMenuItem6);
			this.SaveMenuStrip.Name = "SaveMenuStrip";
			this.SaveMenuStrip.ShowImageMargin = false;
			this.SaveMenuStrip.Size = new System.Drawing.Size(136, 98);
			this.toolStripMenuItem_3.Name = "toolStripMenuItem_3";
			this.toolStripMenuItem_3.Size = new System.Drawing.Size(135, 22);
			this.toolStripMenuItem_3.Text = Localization.Get("打开方案");
			this.toolStripMenuItem_3.Click += new EventHandler(this.toolStripMenuItem_3_Click);
			this.toolStripMenuItem_0.Name = "toolStripMenuItem_0";
			this.toolStripMenuItem_0.Size = new System.Drawing.Size(135, 22);
			this.toolStripMenuItem_0.Text = Localization.Get("保存方案");
			this.toolStripMenuItem_0.Click += new EventHandler(this.toolStripMenuItem_0_Click);
			this.toolStripSeparator_0.Name = "toolStripSeparator_0";
			this.toolStripSeparator_0.Size = new System.Drawing.Size(132, 6);
			this.toolStripMenuItem_1.Name = "toolStripMenuItem_1";
			this.toolStripMenuItem_1.Size = new System.Drawing.Size(135, 22);
			this.toolStripMenuItem_1.Text = Localization.Get("另存方案");
			this.toolStripMenuItem_1.Click += new EventHandler(this.toolStripMenuItem_1_Click);
			this.toolStripMenuItem_2.Name = "toolStripMenuItem_2";
			this.toolStripMenuItem_2.Size = new System.Drawing.Size(135, 22);
			this.toolStripMenuItem_2.Text = Localization.Get("保存为手动方案");
			this.toolStripMenuItem_2.Click += new EventHandler(this.toolStripMenuItem_2_Click);
			this.openFileDialog_0.DefaultExt = "xml";
			this.openFileDialog_0.Filter = "Rules(*.xml)|*.xml|All Files(*.*)|*.*";
			this.openFileDialog_0.InitialDirectory = "Tasks";
			this.openFileDialog_0.RestoreDirectory = true;
			this.saveFileDialog_0.DefaultExt = "xml";
			this.saveFileDialog_0.Filter = "Rules(*.xml)|*.xml|All Files(*.*)|*.*";
			this.saveFileDialog_0.InitialDirectory = "Tasks";
			this.saveFileDialog_0.RestoreDirectory = true;
			this.button_3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			this.button_3.Location = new Point(662, 358);
			this.button_3.Name = "button_3";
			this.button_3.Size = new System.Drawing.Size(75, 23);
			this.button_3.TabIndex = 21;
			this.button_3.Text = Localization.Get("测试网速");
			this.button_3.UseVisualStyleBackColor = true;
			this.button_3.Click += new EventHandler(this.button_3_Click);
			this.LoginWorker.WorkerReportsProgress = true;
			this.LoginWorker.WorkerSupportsCancellation = true;
			this.LoginWorker.DoWork += new DoWorkEventHandler(this.LoginWorker_DoWork);
			this.LoginWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.LoginWorker_RunWorkerCompleted);
			this.LoginWorker.ProgressChanged += new ProgressChangedEventHandler(this.LoginWorker_ProgressChanged);
			this.TestWorker.WorkerReportsProgress = true;
			this.TestWorker.WorkerSupportsCancellation = true;
			this.TestWorker.DoWork += new DoWorkEventHandler(this.TestWorker_DoWork);
			this.TestWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.TestWorker_RunWorkerCompleted);
			this.HttpWorker.WorkerReportsProgress = true;
			this.HttpWorker.WorkerSupportsCancellation = true;
			this.HttpWorker.DoWork += new DoWorkEventHandler(this.HttpWorker_DoWork);
			this.HttpWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.HttpWorker_RunWorkerCompleted);
			this.HttpWorker.ProgressChanged += new ProgressChangedEventHandler(this.HttpWorker_ProgressChanged);
			this.tabPage2.Controls.Add(this.groupBox8);
			this.tabPage2.Controls.Add(this.groupBox_7);
			this.tabPage2.Location = new Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(802, 314);
			this.tabPage2.TabIndex = 6;
			this.tabPage2.Text = Localization.Get("代理设定");
			this.tabPage2.UseVisualStyleBackColor = true;
			this.groupBox8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.groupBox8.Controls.Add(this.listView1);
			this.groupBox8.Location = new Point(9, 116);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new System.Drawing.Size(787, 192);
			this.groupBox8.TabIndex = 5;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = Localization.Get("获取代理列表");
			this.listView1.CheckBoxes = true;
			ListView.ColumnHeaderCollection columns = this.listView1.Columns;
			ColumnHeader[] columnHeader12 = new ColumnHeader[] { this.columnHeader_12, this.columnHeader_13, this.columnHeader1, this.columnHeader2, this.columnHeader3, this.columnHeader4 };
			columns.AddRange(columnHeader12);
			this.listView1.ContextMenuStrip = this.TargetMenuStrip;
			this.listView1.Dock = DockStyle.Fill;
			this.listView1.FullRowSelect = true;
			this.listView1.GridLines = true;
			this.listView1.Location = new Point(3, 17);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(781, 172);
			this.listView1.TabIndex = 4;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = View.Details;
			this.listView1.MouseDoubleClick += new MouseEventHandler(this.listView1_MouseDoubleClick);
			this.columnHeader_12.Text = Localization.Get("IP地址");
			this.columnHeader_12.Width = 150;
			this.columnHeader_13.Text = Localization.Get("端口");
			this.columnHeader_13.Width = 80;
			this.columnHeader1.Text = Localization.Get("位置");
			this.columnHeader1.Width = 200;
			this.columnHeader2.Text = Localization.Get("连接速度");
			this.columnHeader2.Width = 90;
			this.columnHeader3.Text = Localization.Get("抓取速度");
			this.columnHeader3.Width = 90;
			this.columnHeader4.Text = Localization.Get("验证时间");
			this.columnHeader4.Width = 130;
			this.groupBox_7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.groupBox_7.Controls.Add(this.button1);
			this.groupBox_7.Controls.Add(this.checkBox_19);
			this.groupBox_7.Controls.Add(this.label_19);
			this.groupBox_7.Controls.Add(this.textBox_14);
			this.groupBox_7.Controls.Add(this.label_17);
			this.groupBox_7.Controls.Add(this.label_18);
			this.groupBox_7.Controls.Add(this.textBox_9);
			this.groupBox_7.Controls.Add(this.textBox_10);
			this.groupBox_7.Controls.Add(this.textBox_11);
			this.groupBox_7.Controls.Add(this.textBox_12);
			this.groupBox_7.Location = new Point(9, 6);
			this.groupBox_7.Name = "groupBox_7";
			this.groupBox_7.Size = new System.Drawing.Size(787, 104);
			this.groupBox_7.TabIndex = 4;
			this.groupBox_7.TabStop = false;
			this.groupBox_7.Text = Localization.Get("代理IP");
			this.button1.Location = new Point(663, 72);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(118, 23);
			this.button1.TabIndex = 21;
			this.button1.Text = Localization.Get("手动导入代理");
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new EventHandler(this.button1_Click);
			this.checkBox_19.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.checkBox_19.AutoSize = true;
			this.checkBox_19.Location = new Point(663, 50);
			this.checkBox_19.Name = "checkBox_19";
			this.checkBox_19.Size = new System.Drawing.Size(96, 16);
			this.checkBox_19.TabIndex = 20;
			this.checkBox_19.Text = Localization.Get("启用代理功能");
			this.checkBox_19.UseVisualStyleBackColor = true;
			this.label_19.AutoSize = true;
			this.label_19.Location = new Point(30, 50);
			this.label_19.Name = "label_19";
			this.label_19.Size = new System.Drawing.Size(53, 12);
			this.label_19.TabIndex = 19;
			this.label_19.Text = Localization.Get("代理域：");
			this.textBox_14.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.textBox_14.Location = new Point(89, 47);
			this.textBox_14.Name = "textBox_14";
			this.textBox_14.Size = new System.Drawing.Size(568, 21);
			this.textBox_14.TabIndex = 17;
			this.label_17.AutoSize = true;
			this.label_17.Location = new Point(18, 77);
			this.label_17.Name = "label_17";
			this.label_17.Size = new System.Drawing.Size(65, 12);
			this.label_17.TabIndex = 16;
			this.label_17.Text = Localization.Get("帐户密码：");
			this.label_18.AutoSize = true;
			this.label_18.Location = new Point(18, 23);
			this.label_18.Name = "label_18";
			this.label_18.Size = new System.Drawing.Size(65, 12);
			this.label_18.TabIndex = 15;
			this.label_18.Text = Localization.Get("IP端口：");
			this.textBox_9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.textBox_9.Location = new Point(313, 74);
			this.textBox_9.Name = "textBox_9";
			this.textBox_9.Size = new System.Drawing.Size(344, 21);
			this.textBox_9.TabIndex = 12;
			this.textBox_10.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.textBox_10.Location = new Point(89, 74);
			this.textBox_10.Name = "textBox_10";
			this.textBox_10.Size = new System.Drawing.Size(218, 21);
			this.textBox_10.TabIndex = 11;
			this.textBox_11.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.textBox_11.Location = new Point(663, 20);
			this.textBox_11.Name = "textBox_11";
			this.textBox_11.Size = new System.Drawing.Size(118, 21);
			this.textBox_11.TabIndex = 10;
			this.textBox_11.Text = "80";
			this.textBox_12.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.textBox_12.Location = new Point(89, 20);
			this.textBox_12.Name = "textBox_12";
			this.textBox_12.Size = new System.Drawing.Size(568, 21);
			this.textBox_12.TabIndex = 9;
			this.tabPage_4.Controls.Add(this.groupBox_4);
			this.tabPage_4.Controls.Add(this.groupBox7);
			this.tabPage_4.Controls.Add(this.groupBox_9);
			this.tabPage_4.Location = new Point(4, 22);
			this.tabPage_4.Name = "tabPage_4";
			this.tabPage_4.Size = new System.Drawing.Size(802, 314);
			this.tabPage_4.TabIndex = 4;
			this.tabPage_4.Text = Localization.Get("采集进度");
			this.tabPage_4.UseVisualStyleBackColor = true;
			this.groupBox_4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.groupBox_4.Controls.Add(this.label16);
			this.groupBox_4.Controls.Add(this.label17);
			this.groupBox_4.Controls.Add(this.label6);
			this.groupBox_4.Controls.Add(this.label7);
			this.groupBox_4.Controls.Add(this.label11);
			this.groupBox_4.Controls.Add(this.label12);
			this.groupBox_4.Controls.Add(this.label13);
			this.groupBox_4.Controls.Add(this.label14);
			this.groupBox_4.Controls.Add(this.label_13);
			this.groupBox_4.Controls.Add(this.label_14);
			this.groupBox_4.Controls.Add(this.label_15);
			this.groupBox_4.Controls.Add(this.label_8);
			this.groupBox_4.Controls.Add(this.label_9);
			this.groupBox_4.Controls.Add(this.label_10);
			this.groupBox_4.Location = new Point(6, 116);
			this.groupBox_4.Name = "groupBox_4";
			this.groupBox_4.Size = new System.Drawing.Size(790, 191);
			this.groupBox_4.TabIndex = 3;
			this.groupBox_4.TabStop = false;
			this.groupBox_4.Text = Localization.Get("操作详情");
			this.label16.AutoSize = true;
			this.label16.Location = new Point(78, 22);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(89, 12);
			this.label16.TabIndex = 24;
			this.label16.Text = Localization.Get("普通版本无期限");
			this.label17.AutoSize = true;
			this.label17.Location = new Point(18, 22);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(65, 12);
			this.label17.TabIndex = 23;
			this.label17.Text = Localization.Get("版本授权：");
			this.label6.AutoSize = true;
			this.label6.Location = new Point(78, 96);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(17, 12);
			this.label6.TabIndex = 22;
			this.label6.Text = "--";
			this.label7.AutoSize = true;
			this.label7.Location = new Point(78, 71);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(17, 12);
			this.label7.TabIndex = 21;
			this.label7.Text = "--";
			this.label11.AutoSize = true;
			this.label11.Location = new Point(78, 46);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(17, 12);
			this.label11.TabIndex = 20;
			this.label11.Text = "--";
			this.label12.AutoSize = true;
			this.label12.Location = new Point(18, 96);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(65, 12);
			this.label12.TabIndex = 19;
			this.label12.Text = Localization.Get("开始时间：");
			this.label13.AutoSize = true;
			this.label13.Location = new Point(6, 71);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(77, 12);
			this.label13.TabIndex = 18;
			this.label13.Text = Localization.Get("代理IP地址：");
			this.label14.AutoSize = true;
			this.label14.Location = new Point(6, 46);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(77, 12);
			this.label14.TabIndex = 17;
			this.label14.Text = Localization.Get("子窗口标识：");
			this.label_13.AutoSize = true;
			this.label_13.Location = new Point(78, 169);
			this.label_13.Name = "label_13";
			this.label_13.Size = new System.Drawing.Size(17, 12);
			this.label_13.TabIndex = 16;
			this.label_13.Text = "--";
			this.label_14.AutoSize = true;
			this.label_14.Location = new Point(78, 144);
			this.label_14.Name = "label_14";
			this.label_14.Size = new System.Drawing.Size(17, 12);
			this.label_14.TabIndex = 15;
			this.label_14.Text = "--";
			this.label_15.AutoSize = true;
			this.label_15.Location = new Point(78, 119);
			this.label_15.Name = "label_15";
			this.label_15.Size = new System.Drawing.Size(17, 12);
			this.label_15.TabIndex = 14;
			this.label_15.Text = "--";
			this.label_8.AutoSize = true;
			this.label_8.Location = new Point(18, 169);
			this.label_8.Name = "label_8";
			this.label_8.Size = new System.Drawing.Size(65, 12);
			this.label_8.TabIndex = 13;
			this.label_8.Text = Localization.Get("当前状态：");
			this.label_9.AutoSize = true;
			this.label_9.Location = new Point(18, 144);
			this.label_9.Name = "label_9";
			this.label_9.Size = new System.Drawing.Size(65, 12);
			this.label_9.TabIndex = 12;
			this.label_9.Text = Localization.Get("当前章节：");
			this.label_10.AutoSize = true;
			this.label_10.Location = new Point(18, 119);
			this.label_10.Name = "label_10";
			this.label_10.Size = new System.Drawing.Size(65, 12);
			this.label_10.TabIndex = 11;
			this.label_10.Text = Localization.Get("当前小说：");
			this.groupBox7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.groupBox7.Controls.Add(this.checkBox_20);
			this.groupBox7.Controls.Add(this.progressBar_1);
			this.groupBox7.Controls.Add(this.progressBar_0);
			this.groupBox7.Controls.Add(this.label_11);
			this.groupBox7.Controls.Add(this.label_12);
			this.groupBox7.Location = new Point(6, 6);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(622, 104);
			this.groupBox7.TabIndex = 6;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = Localization.Get("采集进度");
			this.checkBox_20.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.checkBox_20.AutoSize = true;
			this.checkBox_20.Location = new Point(80, 75);
			this.checkBox_20.Name = "checkBox_20";
			this.checkBox_20.Size = new System.Drawing.Size(96, 16);
			this.checkBox_20.TabIndex = 17;
			this.checkBox_20.Text = Localization.Get("不绘图进度条");
			this.checkBox_20.UseVisualStyleBackColor = true;
			this.progressBar_1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.progressBar_1.Location = new Point(80, 23);
			this.progressBar_1.Name = "progressBar_1";
			this.progressBar_1.Size = new System.Drawing.Size(536, 18);
			this.progressBar_1.TabIndex = 7;
			this.progressBar_0.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.progressBar_0.Location = new Point(80, 47);
			this.progressBar_0.Name = "progressBar_0";
			this.progressBar_0.Size = new System.Drawing.Size(536, 18);
			this.progressBar_0.TabIndex = 10;
			this.label_11.AutoSize = true;
			this.label_11.Location = new Point(6, 50);
			this.label_11.Name = "label_11";
			this.label_11.Size = new System.Drawing.Size(77, 12);
			this.label_11.TabIndex = 9;
			this.label_11.Text = Localization.Get("采集分进度：");
			this.label_12.AutoSize = true;
			this.label_12.Location = new Point(6, 28);
			this.label_12.Name = "label_12";
			this.label_12.Size = new System.Drawing.Size(77, 12);
			this.label_12.TabIndex = 8;
			this.label_12.Text = Localization.Get("采集总进度：");
			this.groupBox_9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.groupBox_9.Controls.Add(this.label_21);
			this.groupBox_9.Controls.Add(this.label_22);
			this.groupBox_9.Controls.Add(this.label_23);
			this.groupBox_9.Controls.Add(this.label_24);
			this.groupBox_9.Controls.Add(this.numericUpDown_3);
			this.groupBox_9.Controls.Add(this.label_25);
			this.groupBox_9.Controls.Add(this.numericUpDown_4);
			this.groupBox_9.Controls.Add(this.label_26);
			this.groupBox_9.Controls.Add(this.numericUpDown_5);
			this.groupBox_9.Location = new Point(634, 6);
			this.groupBox_9.Name = "groupBox_9";
			this.groupBox_9.Size = new System.Drawing.Size(162, 104);
			this.groupBox_9.TabIndex = 5;
			this.groupBox_9.TabStop = false;
			this.groupBox_9.Text = Localization.Get("延时等待");
			this.label_21.AutoSize = true;
			this.label_21.Location = new Point(121, 77);
			this.label_21.Name = "label_21";
			this.label_21.Size = new System.Drawing.Size(29, 12);
			this.label_21.TabIndex = 28;
			this.label_21.Text = "ms";
			this.label_22.AutoSize = true;
			this.label_22.Location = new Point(121, 50);
			this.label_22.Name = "label_22";
			this.label_22.Size = new System.Drawing.Size(29, 12);
			this.label_22.TabIndex = 27;
			this.label_22.Text = "ms";
			this.label_23.AutoSize = true;
			this.label_23.Location = new Point(121, 23);
			this.label_23.Name = "label_23";
			this.label_23.Size = new System.Drawing.Size(29, 12);
			this.label_23.TabIndex = 26;
			this.label_23.Text = "ms";
			this.label_24.AutoSize = true;
			this.label_24.Location = new Point(12, 77);
			this.label_24.Name = "label_24";
			this.label_24.Size = new System.Drawing.Size(53, 12);
			this.label_24.TabIndex = 25;
			this.label_24.Text = Localization.Get("章节页：");
			this.numericUpDown_3.Location = new Point(71, 74);
			NumericUpDown numericUpDown3 = this.numericUpDown_3;
			numArray = new int[] { 9999, 0, 0, 0 };
			numericUpDown3.Maximum = new decimal(numArray);
			this.numericUpDown_3.Name = "numericUpDown_3";
			this.numericUpDown_3.Size = new System.Drawing.Size(44, 21);
			this.numericUpDown_3.TabIndex = 24;
			this.label_25.AutoSize = true;
			this.label_25.Location = new Point(12, 50);
			this.label_25.Name = "label_25";
			this.label_25.Size = new System.Drawing.Size(53, 12);
			this.label_25.TabIndex = 23;
			this.label_25.Text = Localization.Get("目录页：");
			this.numericUpDown_4.Location = new Point(71, 47);
			NumericUpDown numericUpDown4 = this.numericUpDown_4;
			numArray = new int[] { 9999, 0, 0, 0 };
			numericUpDown4.Maximum = new decimal(numArray);
			this.numericUpDown_4.Name = "numericUpDown_4";
			this.numericUpDown_4.Size = new System.Drawing.Size(44, 21);
			this.numericUpDown_4.TabIndex = 22;
			this.label_26.AutoSize = true;
			this.label_26.Location = new Point(12, 23);
			this.label_26.Name = "label_26";
			this.label_26.Size = new System.Drawing.Size(53, 12);
			this.label_26.TabIndex = 21;
			this.label_26.Text = "信息页：";
			this.numericUpDown_5.Location = new Point(71, 20);
			NumericUpDown numericUpDown5 = this.numericUpDown_5;
			numArray = new int[] { 9999, 0, 0, 0 };
			numericUpDown5.Maximum = new decimal(numArray);
			this.numericUpDown_5.Name = "numericUpDown_5";
			this.numericUpDown_5.Size = new System.Drawing.Size(44, 21);
			this.numericUpDown_5.TabIndex = 0;
			this.tabPage1.Controls.Add(this.groupBox6);
			this.tabPage1.Controls.Add(this.groupBox5);
			this.tabPage1.Controls.Add(this.groupBox4);
			this.tabPage1.Location = new Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(802, 314);
			this.tabPage1.TabIndex = 5;
			this.tabPage1.Text = Localization.Get("高级设置");
			this.tabPage1.UseVisualStyleBackColor = true;
			this.groupBox6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.groupBox6.Controls.Add(this.label15);
			this.groupBox6.Controls.Add(this.DelChapter);
			this.groupBox6.Controls.Add(this.label10);
			this.groupBox6.Controls.Add(this.label9);
			this.groupBox6.Controls.Add(this.ReplaceChapterNun);
			this.groupBox6.Controls.Add(this.ReplaceChapter);
			this.groupBox6.Location = new Point(3, 119);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(796, 95);
			this.groupBox6.TabIndex = 3;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = Localization.Get("章节自动修复(高级授权服务)");
			this.label15.AutoSize = true;
			this.label15.Location = new Point(25, 43);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(353, 12);
			this.label15.TabIndex = 26;
			this.label15.Text = Localization.Get("(说明：自动修复错误，即覆盖章节名和内容，无视一切防盗章节)");
			this.DelChapter.AutoSize = true;
			this.DelChapter.Location = new Point(6, 63);
			this.DelChapter.Name = "DelChapter";
			this.DelChapter.Size = new System.Drawing.Size(282, 16);
			this.DelChapter.TabIndex = 25;
			this.DelChapter.Text = Localization.Get("自动对比章节MD5（如果章节内容相同则不替换）");
			this.DelChapter.UseVisualStyleBackColor = true;
			this.label10.AutoSize = true;
			this.label10.Location = new Point(302, 20);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(29, 12);
			this.label10.TabIndex = 24;
			this.label10.Text = Localization.Get("章节");
			this.label9.AutoSize = true;
			this.label9.Location = new Point(148, 21);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(77, 12);
			this.label9.TabIndex = 23;
			this.label9.Text = Localization.Get("覆盖修复最后");
			this.ReplaceChapterNun.Location = new Point(231, 17);
			NumericUpDown replaceChapterNun = this.ReplaceChapterNun;
			numArray = new int[] { 9999, 0, 0, 0 };
			replaceChapterNun.Maximum = new decimal(numArray);
			this.ReplaceChapterNun.Name = "ReplaceChapterNun";
			this.ReplaceChapterNun.Size = new System.Drawing.Size(63, 21);
			this.ReplaceChapterNun.TabIndex = 1;
			this.ReplaceChapter.AutoSize = true;
			this.ReplaceChapter.Location = new Point(6, 20);
			this.ReplaceChapter.Name = "ReplaceChapter";
			this.ReplaceChapter.Size = new System.Drawing.Size(120, 16);
			this.ReplaceChapter.TabIndex = 0;
			this.ReplaceChapter.Text = Localization.Get("启用自动修复错误");
			this.ReplaceChapter.UseVisualStyleBackColor = true;
			this.groupBox5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.groupBox5.Controls.Add(this.StrongReplaceIntro);
			this.groupBox5.Controls.Add(this.StrongReplaceFullflag);
			this.groupBox5.Controls.Add(this.StrongReplaceImgflag);
			this.groupBox5.Controls.Add(this.label8);
			this.groupBox5.Controls.Add(this.ReplaceSortId);
			this.groupBox5.Controls.Add(this.OnlyReplaceSort);
			this.groupBox5.Controls.Add(this.ReplaceSort);
			this.groupBox5.Controls.Add(this.ReplaceIntro);
			this.groupBox5.Controls.Add(this.ReplaceFullflag);
			this.groupBox5.Controls.Add(this.ReplaceImgflag);
			this.groupBox5.Location = new Point(3, 3);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(796, 110);
			this.groupBox5.TabIndex = 2;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = Localization.Get("信息自动更新");
			this.StrongReplaceIntro.AutoSize = true;
			this.StrongReplaceIntro.Location = new Point(396, 63);
			this.StrongReplaceIntro.Name = "StrongReplaceIntro";
			this.StrongReplaceIntro.Size = new System.Drawing.Size(288, 16);
			this.StrongReplaceIntro.TabIndex = 25;
			this.StrongReplaceIntro.Text = Localization.Get("强制更新小说简介(目标站无简介时不更新，慎用)");
			this.StrongReplaceIntro.UseVisualStyleBackColor = true;
			this.StrongReplaceIntro.CheckedChanged += new EventHandler(this.StrongReplaceIntro_CheckedChanged);
			this.StrongReplaceFullflag.AutoSize = true;
			this.StrongReplaceFullflag.Location = new Point(396, 41);
			this.StrongReplaceFullflag.Name = "StrongReplaceFullflag";
			this.StrongReplaceFullflag.Size = new System.Drawing.Size(120, 16);
			this.StrongReplaceFullflag.TabIndex = 24;
			this.StrongReplaceFullflag.Text = Localization.Get("强制更新连载状态");
			this.StrongReplaceFullflag.UseVisualStyleBackColor = true;
			this.StrongReplaceFullflag.CheckedChanged += new EventHandler(this.StrongReplaceFullflag_CheckedChanged);
			this.StrongReplaceImgflag.AutoSize = true;
			this.StrongReplaceImgflag.Location = new Point(396, 20);
			this.StrongReplaceImgflag.Name = "StrongReplaceImgflag";
			this.StrongReplaceImgflag.Size = new System.Drawing.Size(288, 16);
			this.StrongReplaceImgflag.TabIndex = 23;
			this.StrongReplaceImgflag.Text = Localization.Get("强制更新小说封面（目标站无封面不更新，慎用）");
			this.StrongReplaceImgflag.UseVisualStyleBackColor = true;
			this.StrongReplaceImgflag.CheckedChanged += new EventHandler(this.StrongReplaceImgflag_CheckedChanged);
			this.label8.AutoSize = true;
			this.label8.Location = new Point(518, 87);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(239, 12);
			this.label8.TabIndex = 22;
			this.label8.Text = Localization.Get("的小说(如只更新本站无分类小说请设置为0)");
			this.ReplaceSortId.Location = new Point(466, 83);
			this.ReplaceSortId.Name = "ReplaceSortId";
			this.ReplaceSortId.Size = new System.Drawing.Size(46, 21);
			this.ReplaceSortId.TabIndex = 21;
			this.OnlyReplaceSort.AutoSize = true;
			this.OnlyReplaceSort.Location = new Point(300, 86);
			this.OnlyReplaceSort.Name = "OnlyReplaceSort";
			this.OnlyReplaceSort.Size = new System.Drawing.Size(168, 16);
			this.OnlyReplaceSort.TabIndex = 4;
			this.OnlyReplaceSort.Text = Localization.Get("无分类小说和本站分类ID为");
			this.OnlyReplaceSort.UseVisualStyleBackColor = true;
			this.OnlyReplaceSort.CheckedChanged += new EventHandler(this.OnlyReplaceSort_CheckedChanged);
			this.ReplaceSort.AutoSize = true;
			this.ReplaceSort.Location = new Point(6, 86);
			this.ReplaceSort.Name = "ReplaceSort";
			this.ReplaceSort.Size = new System.Drawing.Size(288, 16);
			this.ReplaceSort.TabIndex = 3;
			this.ReplaceSort.Text = Localization.Get("自动更新分类（后面未选择时强制更新所有小说）");
			this.ReplaceSort.UseVisualStyleBackColor = true;
			this.ReplaceSort.CheckedChanged += new EventHandler(this.ReplaceSort_CheckedChanged);
			this.ReplaceIntro.AutoSize = true;
			this.ReplaceIntro.Location = new Point(6, 64);
			this.ReplaceIntro.Name = "ReplaceIntro";
			this.ReplaceIntro.Size = new System.Drawing.Size(396, 16);
			this.ReplaceIntro.TabIndex = 2;
			this.ReplaceIntro.Text = Localization.Get("自动更新小说简介（只更新本站无简介的小说目标站无简介时不更新）");
			this.ReplaceIntro.UseVisualStyleBackColor = true;
			this.ReplaceIntro.CheckedChanged += new EventHandler(this.ReplaceIntro_CheckedChanged);
			this.ReplaceFullflag.AutoSize = true;
			this.ReplaceFullflag.Location = new Point(6, 42);
			this.ReplaceFullflag.Name = "ReplaceFullflag";
			this.ReplaceFullflag.Size = new System.Drawing.Size(372, 16);
			this.ReplaceFullflag.TabIndex = 1;
			this.ReplaceFullflag.Text = Localization.Get("自动更新连载状态（只更新本站状态为连载的小说，连载到完结）");
			this.ReplaceFullflag.UseVisualStyleBackColor = true;
			this.ReplaceFullflag.CheckedChanged += new EventHandler(this.ReplaceFullflag_CheckedChanged);
			this.ReplaceImgflag.AutoSize = true;
			this.ReplaceImgflag.Location = new Point(6, 20);
			this.ReplaceImgflag.Name = "ReplaceImgflag";
			this.ReplaceImgflag.Size = new System.Drawing.Size(384, 16);
			this.ReplaceImgflag.TabIndex = 0;
			this.ReplaceImgflag.Text = Localization.Get("自动更新封面（只更新本站无封面的小说，目标站无封面时不更新）");
			this.ReplaceImgflag.UseVisualStyleBackColor = true;
			this.ReplaceImgflag.CheckedChanged += new EventHandler(this.ReplaceImgflag_CheckedChanged);
			this.groupBox4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.groupBox4.Controls.Add(this.ReplaceChapterNameOn);
			this.groupBox4.Controls.Add(this.label4);
			this.groupBox4.Location = new Point(3, 220);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(796, 91);
			this.groupBox4.TabIndex = 1;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = Localization.Get("突破列表防采集(高级授权服务)");
			this.label4.AutoSize = true;
			this.label4.Location = new Point(9, 46);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(665, 12);
			this.label4.TabIndex = 27;
			this.label4.Text = Localization.Get("(说明：针对部分网站给列表中添加字符导致无法对比的情况使用此功能，在规则编辑器编辑规则时使用最后红色部分来实现)");
			this.tabPage_2.Controls.Add(this.groupBox3);
			this.tabPage_2.Controls.Add(this.groupBox2);
			this.tabPage_2.Controls.Add(this.groupBox1);
			this.tabPage_2.Controls.Add(this.groupBox_2);
			this.tabPage_2.Controls.Add(this.groupBox_3);
			this.tabPage_2.Location = new Point(4, 22);
			this.tabPage_2.Name = "tabPage_2";
			this.tabPage_2.Size = new System.Drawing.Size(802, 314);
			this.tabPage_2.TabIndex = 2;
			this.tabPage_2.Text = Localization.Get("过滤设置");
			this.tabPage_2.UseVisualStyleBackColor = true;
			this.groupBox_2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
			this.groupBox_2.Controls.Add(this.FilterNovelTextBox);
			this.groupBox_2.Controls.Add(this.FilterNovelType);
			this.groupBox_2.Location = new Point(6, 13);
			this.groupBox_2.Name = "groupBox_2";
			this.groupBox_2.Size = new System.Drawing.Size(206, 294);
			this.groupBox_2.TabIndex = 2;
			this.groupBox_2.TabStop = false;
			this.groupBox_2.Text = Localization.Get("限制小说");
			this.FilterNovelType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.FilterNovelType.DropDownStyle = ComboBoxStyle.DropDownList;
			this.FilterNovelType.FormattingEnabled = true;
			ComboBox.ObjectCollection objectCollections = this.FilterNovelType.Items;
			object[] objArray = new object[] { Localization.Get("不限制"), Localization.Get("不采集限制小说"), Localization.Get("只采集限制小说") };
			objectCollections.AddRange(objArray);
			this.FilterNovelType.Location = new Point(8, 20);
			this.FilterNovelType.Name = "FilterNovelType";
			this.FilterNovelType.Size = new System.Drawing.Size(192, 20);
			this.FilterNovelType.TabIndex = 7;
			this.tabPage_1.Controls.Add(this.groupBox_5);
			this.tabPage_1.Controls.Add(this.groupBox_6);
			this.tabPage_1.Location = new Point(4, 22);
			this.tabPage_1.Name = "tabPage_1";
			this.tabPage_1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage_1.Size = new System.Drawing.Size(802, 314);
			this.tabPage_1.TabIndex = 1;
			this.tabPage_1.Text = Localization.Get("采集动作");
			this.tabPage_1.UseVisualStyleBackColor = true;
			this.groupBox_5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.groupBox_5.Controls.Add(this.label3);
			this.groupBox_5.Controls.Add(this.comboBox1);
			this.groupBox_5.Controls.Add(this.label_32);
			this.groupBox_5.Controls.Add(this.comboBox_7);
			this.groupBox_5.Controls.Add(this.comboBox_6);
			this.groupBox_5.Controls.Add(this.label_31);
			this.groupBox_5.Controls.Add(this.label_27);
			this.groupBox_5.Controls.Add(this.comboBox_5);
			this.groupBox_5.Controls.Add(this.label_6);
			this.groupBox_5.Controls.Add(this.comboBox_1);
			this.groupBox_5.Controls.Add(this.label_7);
			this.groupBox_5.Controls.Add(this.comboBox_2);
			this.groupBox_5.Location = new Point(6, 190);
			this.groupBox_5.Name = "groupBox_5";
			this.groupBox_5.Size = new System.Drawing.Size(790, 117);
			this.groupBox_5.TabIndex = 13;
			this.groupBox_5.TabStop = false;
			this.groupBox_5.Text = Localization.Get("设置2");
			this.label3.AutoSize = true;
			this.label3.Location = new Point(198, 55);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(149, 12);
			this.label3.TabIndex = 21;
			this.label3.Text = Localization.Get("目标站重复章节判断方式：");
			this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox1.FormattingEnabled = true;
			ComboBox.ObjectCollection items1 = this.comboBox1.Items;
			objArray = new object[] { Localization.Get("停止本书，跳入下一本"), Localization.Get("跳过本章，继续采集下一个章") };
			items1.AddRange(objArray);
			this.comboBox1.Location = new Point(413, 70);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(207, 20);
			this.comboBox1.TabIndex = 20;
			this.label_32.AutoSize = true;
			this.label_32.Location = new Point(411, 17);
			this.label_32.Name = "label_32";
			this.label_32.Size = new System.Drawing.Size(89, 12);
			this.label_32.TabIndex = 19;
			this.label_32.Text = Localization.Get("章节排序方式：");
			this.comboBox_7.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_7.FormattingEnabled = true;
			ComboBox.ObjectCollection objectCollections1 = this.comboBox_7.Items;
			objArray = new object[] { Localization.Get("目标站顺序"), Localization.Get("目标站倒序"), Localization.Get("按章节ID顺序"), Localization.Get("按章节ID倒序"), Localization.Get("按章节名顺序"), Localization.Get("按章节名倒序") };
			objectCollections1.AddRange(objArray);
			this.comboBox_7.Location = new Point(413, 32);
			this.comboBox_7.Name = "comboBox_7";
			this.comboBox_7.Size = new System.Drawing.Size(207, 20);
			this.comboBox_7.TabIndex = 18;
			this.comboBox_6.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_6.FormattingEnabled = true;
			ComboBox.ObjectCollection items2 = this.comboBox_6.Items;
			objArray = new object[] { Localization.Get("只对比章节名"), Localization.Get("对比分卷名+章节名"), Localization.Get("智能对比 V1.2 Beta"), Localization.Get("智能对比 V2.6 Beta"), Localization.Get("智能对比 V3.2 Beta") };
			items2.AddRange(objArray);
			this.comboBox_6.Location = new Point(6, 70);
			this.comboBox_6.Name = "comboBox_6";
			this.comboBox_6.Size = new System.Drawing.Size(188, 20);
			this.comboBox_6.TabIndex = 17;
			this.label_31.AutoSize = true;
			this.label_31.Location = new Point(4, 55);
			this.label_31.Name = "label_31";
			this.label_31.Size = new System.Drawing.Size(113, 12);
			this.label_31.TabIndex = 16;
			this.label_31.Text = Localization.Get("重复章节判断方式：");
			this.label_27.AutoSize = true;
			this.label_27.Location = new Point(411, 55);
			this.label_27.Name = "label_27";
			this.label_27.Size = new System.Drawing.Size(113, 12);
			this.label_27.TabIndex = 12;
			this.label_27.Text = Localization.Get("重复章节处理方式：");
			this.comboBox_5.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_5.FormattingEnabled = true;
			ComboBox.ObjectCollection objectCollections2 = this.comboBox_5.Items;
			objArray = new object[] { Localization.Get("只对比章节名"), Localization.Get("对比分卷名+章节名") };
			objectCollections2.AddRange(objArray);
			this.comboBox_5.Location = new Point(200, 70);
			this.comboBox_5.Name = "comboBox_5";
			this.comboBox_5.Size = new System.Drawing.Size(207, 20);
			this.comboBox_5.TabIndex = 11;
			this.label_6.AutoSize = true;
			this.label_6.Location = new Point(198, 17);
			this.label_6.Name = "label_6";
			this.label_6.Size = new System.Drawing.Size(101, 12);
			this.label_6.TabIndex = 10;
			this.label_6.Text = Localization.Get("空章节处理方式：");
			this.comboBox_1.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_1.FormattingEnabled = true;
			ComboBox.ObjectCollection items3 = this.comboBox_1.Items;
			objArray = new object[] { Localization.Get("停止本书，跳入下一本"), Localization.Get("跳过本章，继续采集下一个章"), Localization.Get("入库一个章节名，继续采集下一个章") };
			items3.AddRange(objArray);
			this.comboBox_1.Location = new Point(200, 32);
			this.comboBox_1.Name = "comboBox_1";
			this.comboBox_1.Size = new System.Drawing.Size(207, 20);
			this.comboBox_1.TabIndex = 1;
			this.label_7.AutoSize = true;
			this.label_7.Location = new Point(4, 17);
			this.label_7.Name = "label_7";
			this.label_7.Size = new System.Drawing.Size(113, 12);
			this.label_7.TabIndex = 9;
			this.label_7.Text = Localization.Get("最新章节对比方式：");
			this.comboBox_2.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_2.FormattingEnabled = true;
			ComboBox.ObjectCollection objectCollections3 = this.comboBox_2.Items;
			objArray = new object[] { Localization.Get("只对比章节名"), Localization.Get("对比分卷名+章节名"), Localization.Get("智能对比 V1.2 Beta"), Localization.Get("得分对比 V2.6 Beta"), Localization.Get("得分对比 V3.2 Beta"), Localization.Get("智能对比 V3.2 Beta+索引对比") };
			objectCollections3.AddRange(objArray);
			this.comboBox_2.Location = new Point(6, 32);
			this.comboBox_2.Name = "comboBox_2";
			this.comboBox_2.Size = new System.Drawing.Size(188, 20);
			this.comboBox_2.TabIndex = 0;
			this.groupBox_6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.groupBox_6.Controls.Add(this.label1);
			this.groupBox_6.Controls.Add(this.label2);
			this.groupBox_6.Controls.Add(this.DonnotCollectLastChapterNum);
			this.groupBox_6.Controls.Add(this.label_29);
			this.groupBox_6.Controls.Add(this.numericUpDown_6);
			this.groupBox_6.Controls.Add(this.label_30);
			this.groupBox_6.Controls.Add(this.label_2);
			this.groupBox_6.Controls.Add(this.numericUpDown_1);
			this.groupBox_6.Controls.Add(this.label_3);
			this.groupBox_6.Controls.Add(this.label_4);
			this.groupBox_6.Controls.Add(this.label_5);
			this.groupBox_6.Controls.Add(this.numericUpDown_2);
			this.groupBox_6.Controls.Add(this.checkBox_15);
			this.groupBox_6.Controls.Add(this.HideBook);
			this.groupBox_6.Controls.Add(this.checkBox_22);
			this.groupBox_6.Controls.Add(this.checkBox_21);
			this.groupBox_6.Controls.Add(this.checkBox_18);
			this.groupBox_6.Controls.Add(this.checkBox_17);
			this.groupBox_6.Controls.Add(this.checkBox_0);
			this.groupBox_6.Controls.Add(this.checkBox_16);
			this.groupBox_6.Controls.Add(this.checkBox_1);
			this.groupBox_6.Controls.Add(this.checkBox_10);
			this.groupBox_6.Controls.Add(this.checkBox_8);
			this.groupBox_6.Controls.Add(this.checkBox_9);
			this.groupBox_6.Controls.Add(this.checkBox_6);
			this.groupBox_6.Controls.Add(this.checkBox_4);
			this.groupBox_6.Location = new Point(6, 6);
			this.groupBox_6.Name = "groupBox_6";
			this.groupBox_6.Size = new System.Drawing.Size(790, 178);
			this.groupBox_6.TabIndex = 12;
			this.groupBox_6.TabStop = false;
			this.groupBox_6.Text = Localization.Get("设置");
			this.label1.AutoSize = true;
			this.label1.Location = new Point(467, 154);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(29, 12);
			this.label1.TabIndex = 27;
			this.label1.Text = Localization.Get("章节");
			this.label2.AutoSize = true;
			this.label2.Location = new Point(333, 154);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(65, 12);
			this.label2.TabIndex = 26;
			this.label2.Text = Localization.Get("不采集倒数");
			this.DonnotCollectLastChapterNum.Location = new Point(404, 151);
			NumericUpDown donnotCollectLastChapterNum = this.DonnotCollectLastChapterNum;
			numArray = new int[] { 10000, 0, 0, 0 };
			donnotCollectLastChapterNum.Maximum = new decimal(numArray);
			this.DonnotCollectLastChapterNum.Name = "DonnotCollectLastChapterNum";
			this.DonnotCollectLastChapterNum.Size = new System.Drawing.Size(57, 21);
			this.DonnotCollectLastChapterNum.TabIndex = 25;
			this.label_29.AutoSize = true;
			this.label_29.Location = new Point(467, 132);
			this.label_29.Name = "label_29";
			this.label_29.Size = new System.Drawing.Size(77, 12);
			this.label_29.TabIndex = 24;
			this.label_29.Text = Localization.Get("个字符的章节");
			this.numericUpDown_6.Location = new Point(404, 127);
			NumericUpDown numericUpDown6 = this.numericUpDown_6;
			numArray = new int[] { 10000, 0, 0, 0 };
			numericUpDown6.Maximum = new decimal(numArray);
			this.numericUpDown_6.Name = "numericUpDown_6";
			this.numericUpDown_6.Size = new System.Drawing.Size(57, 21);
			this.numericUpDown_6.TabIndex = 22;
			this.label_30.AutoSize = true;
			this.label_30.Location = new Point(333, 132);
			this.label_30.Name = "label_30";
			this.label_30.Size = new System.Drawing.Size(65, 12);
			this.label_30.TabIndex = 23;
			this.label_30.Text = Localization.Get("不采集小于");
			this.label_2.AutoSize = true;
			this.label_2.Location = new Point(176, 154);
			this.label_2.Name = "label_2";
			this.label_2.Size = new System.Drawing.Size(137, 12);
			this.label_2.TabIndex = 21;
			this.label_2.Text = Localization.Get("的小说(需要更新的小说)");
			this.numericUpDown_1.Location = new Point(113, 151);
			NumericUpDown numericUpDown1 = this.numericUpDown_1;
			numArray = new int[] { 10000, 0, 0, 0 };
			numericUpDown1.Maximum = new decimal(numArray);
			this.numericUpDown_1.Name = "numericUpDown_1";
			this.numericUpDown_1.Size = new System.Drawing.Size(57, 21);
			this.numericUpDown_1.TabIndex = 16;
			this.label_3.AutoSize = true;
			this.label_3.Location = new Point(6, 154);
			this.label_3.Name = "label_3";
			this.label_3.Size = new System.Drawing.Size(101, 12);
			this.label_3.TabIndex = 20;
			this.label_3.Text = Localization.Get("不更新章节数超过");
			this.label_4.AutoSize = true;
			this.label_4.Location = new Point(176, 132);
			this.label_4.Name = "label_4";
			this.label_4.Size = new System.Drawing.Size(125, 12);
			this.label_4.TabIndex = 19;
			this.label_4.Text = Localization.Get("的小说(只对新书而言)");
			this.label_5.AutoSize = true;
			this.label_5.Location = new Point(6, 132);
			this.label_5.Name = "label_5";
			this.label_5.Size = new System.Drawing.Size(101, 12);
			this.label_5.TabIndex = 18;
			this.label_5.Text = Localization.Get("不采集章节数小于");
			this.numericUpDown_2.Location = new Point(113, 127);
			NumericUpDown numericUpDown2 = this.numericUpDown_2;
			numArray = new int[] { 10000, 0, 0, 0 };
			numericUpDown2.Maximum = new decimal(numArray);
			this.numericUpDown_2.Name = "numericUpDown_2";
			this.numericUpDown_2.Size = new System.Drawing.Size(57, 21);
			this.numericUpDown_2.TabIndex = 15;
			this.checkBox_15.AutoSize = true;
			this.checkBox_15.ForeColor = Color.Red;
			this.checkBox_15.Location = new Point(6, 108);
			this.checkBox_15.Name = "checkBox_15";
			this.checkBox_15.Size = new System.Drawing.Size(168, 16);
			this.checkBox_15.TabIndex = 17;
			this.checkBox_15.Text = Localization.Get("全本必采(不考虑以下情况)");
			this.checkBox_15.UseVisualStyleBackColor = true;
			this.HideBook.AutoSize = true;
			this.HideBook.Location = new Point(426, 64);
			this.HideBook.Name = "HideBook";
			this.HideBook.Size = new System.Drawing.Size(96, 16);
			this.HideBook.TabIndex = 14;
			this.HideBook.Text = Localization.Get("隐藏更新小说");
			this.HideBook.UseVisualStyleBackColor = true;
			this.checkBox_21.AutoSize = true;
			this.checkBox_21.Location = new Point(200, 64);
			this.checkBox_21.Name = "checkBox_21";
			this.checkBox_21.Size = new System.Drawing.Size(198, 16);
			this.checkBox_21.TabIndex = 12;
			this.checkBox_21.Text = Localization.Get("遇到“１一1壹”才判断添加分卷");
			this.checkBox_21.UseVisualStyleBackColor = true;
			this.checkBox_17.AutoSize = true;
			this.checkBox_17.Location = new Point(426, 42);
			this.checkBox_17.Name = "checkBox_17";
			this.checkBox_17.Size = new System.Drawing.Size(150, 16);
			this.checkBox_17.TabIndex = 10;
			this.checkBox_17.Text = Localization.Get("以\"书名+作者\"识别书籍");
			this.checkBox_17.UseVisualStyleBackColor = true;
			this.checkBox_10.AutoSize = true;
			this.checkBox_10.Location = new Point(200, 108);
			this.checkBox_10.Name = "checkBox_10";
			this.checkBox_10.Size = new System.Drawing.Size(132, 16);
			this.checkBox_10.TabIndex = 8;
			this.checkBox_10.Text = Localization.Get("单次循环后调用页面");
			this.checkBox_10.UseVisualStyleBackColor = true;
			this.checkBox_9.AutoSize = true;
			this.checkBox_9.Location = new Point(6, 42);
			this.checkBox_9.Name = "checkBox_9";
			this.checkBox_9.Size = new System.Drawing.Size(108, 16);
			this.checkBox_9.TabIndex = 9;
			this.checkBox_9.Text = Localization.Get("只采集文字章节");
			this.checkBox_9.UseVisualStyleBackColor = true;
			this.tabPage_0.AllowDrop = true;
			this.tabPage_0.Controls.Add(this.textBox_18);
			this.tabPage_0.Controls.Add(this.textBox_16);
			this.tabPage_0.Controls.Add(this.textBox_17);
			this.tabPage_0.Controls.Add(this.textBox_0);
			this.tabPage_0.Controls.Add(this.textBox_1);
			this.tabPage_0.Controls.Add(this.textBox_2);
			this.tabPage_0.Controls.Add(this.textBox_3);
			this.tabPage_0.Controls.Add(this.textBox_4);
			this.tabPage_0.Controls.Add(this.textBox_5);
			this.tabPage_0.Controls.Add(this.textBox_6);
			this.tabPage_0.Controls.Add(this.radioButton_5);
			this.tabPage_0.Controls.Add(this.comboBox_4);
			this.tabPage_0.Controls.Add(this.label_20);
			this.tabPage_0.Controls.Add(this.label_1);
			this.tabPage_0.Controls.Add(this.comboBox_0);
			this.tabPage_0.Controls.Add(this.radioButton_3);
			this.tabPage_0.Controls.Add(this.radioButton_4);
			this.tabPage_0.Controls.Add(this.radioButton_0);
			this.tabPage_0.Controls.Add(this.radioButton_1);
			this.tabPage_0.Controls.Add(this.radioButton_2);
			this.tabPage_0.Controls.Add(this.label_0);
			this.tabPage_0.Controls.Add(this.numericUpDown_0);
			this.tabPage_0.Controls.Add(this.checkBox_2);
			this.tabPage_0.Controls.Add(this.checkBox_3);
			this.tabPage_0.Location = new Point(4, 22);
			this.tabPage_0.Name = "tabPage_0";
			this.tabPage_0.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage_0.Size = new System.Drawing.Size(802, 314);
			this.tabPage_0.TabIndex = 0;
			this.tabPage_0.Text = Localization.Get("采集模式");
			this.tabPage_0.UseVisualStyleBackColor = true;
			this.radioButton_5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.radioButton_5.AutoSize = true;
			this.radioButton_5.Location = new Point(8, 260);
			this.radioButton_5.Name = "radioButton_5";
			this.radioButton_5.Size = new System.Drawing.Size(119, 16);
			this.radioButton_5.TabIndex = 33;
			this.radioButton_5.TabStop = true;
			this.radioButton_5.Text = Localization.Get("按其他站列表搜索");
			this.radioButton_5.UseVisualStyleBackColor = true;
			this.comboBox_4.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_4.FormattingEnabled = true;
			ComboBox.ObjectCollection items4 = this.comboBox_4.Items;
			objArray = new object[] { "TaskConfig.xml" };
			items4.AddRange(objArray);
			this.comboBox_4.Location = new Point(77, 6);
			this.comboBox_4.Name = "comboBox_4";
			this.comboBox_4.Size = new System.Drawing.Size(180, 20);
			this.comboBox_4.TabIndex = 32;
			this.comboBox_4.SelectedIndexChanged += new EventHandler(this.comboBox_4_SelectedIndexChanged);
			this.label_20.AutoSize = true;
			this.label_20.Font = new System.Drawing.Font(Localization.Font, 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
			this.label_20.Location = new Point(6, 9);
			this.label_20.Name = "label_20";
			this.label_20.Size = new System.Drawing.Size(65, 12);
			this.label_20.TabIndex = 31;
			this.label_20.Text = Localization.Get("采集方案：");
			this.label_1.AutoSize = true;
			this.label_1.Font = new System.Drawing.Font(Localization.Font, 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
			this.label_1.Location = new Point(263, 9);
			this.label_1.Name = "label_1";
			this.label_1.Size = new System.Drawing.Size(65, 12);
			this.label_1.TabIndex = 30;
			this.label_1.Text = Localization.Get("采集规则：");
			this.comboBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.comboBox_0.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_0.FormattingEnabled = true;
			this.comboBox_0.Location = new Point(334, 6);
			this.comboBox_0.Name = "comboBox_0";
			this.comboBox_0.Size = new System.Drawing.Size(462, 20);
			this.comboBox_0.TabIndex = 0;
			this.comboBox_0.SelectedIndexChanged += new EventHandler(this.comboBox_0_SelectedIndexChanged);
			this.radioButton_3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.radioButton_3.AutoSize = true;
			this.radioButton_3.Location = new Point(6, 234);
			this.radioButton_3.Name = "radioButton_3";
			this.radioButton_3.Size = new System.Drawing.Size(131, 16);
			this.radioButton_3.TabIndex = 12;
			this.radioButton_3.TabStop = true;
			this.radioButton_3.Text = Localization.Get("按自己站自定义编号");
			this.radioButton_3.UseVisualStyleBackColor = true;
			this.radioButton_4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.radioButton_4.AutoSize = true;
			this.radioButton_4.Location = new Point(6, 207);
			this.radioButton_4.Name = "radioButton_4";
			this.radioButton_4.Size = new System.Drawing.Size(119, 16);
			this.radioButton_4.TabIndex = 9;
			this.radioButton_4.TabStop = true;
			this.radioButton_4.Text = Localization.Get("按自己站编号顺序");
			this.radioButton_4.UseVisualStyleBackColor = true;
			this.radioButton_0.AutoSize = true;
			this.radioButton_0.Location = new Point(6, 32);
			this.radioButton_0.Name = "radioButton_0";
			this.radioButton_0.Size = new System.Drawing.Size(335, 16);
			this.radioButton_0.TabIndex = 1;
			this.radioButton_0.TabStop = true;
			this.radioButton_0.Text = Localization.Get("按目标站页面获得编号，一般监控最新列表，一个地址一行");
			this.radioButton_0.UseVisualStyleBackColor = true;
			this.radioButton_1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.radioButton_1.AutoSize = true;
			this.radioButton_1.Location = new Point(6, 180);
			this.radioButton_1.Name = "radioButton_1";
			this.radioButton_1.Size = new System.Drawing.Size(131, 16);
			this.radioButton_1.TabIndex = 6;
			this.radioButton_1.TabStop = true;
			this.radioButton_1.Text = Localization.Get("按目标站自定义编号");
			this.radioButton_1.UseVisualStyleBackColor = true;
			this.radioButton_2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.radioButton_2.AutoSize = true;
			this.radioButton_2.Location = new Point(6, 153);
			this.radioButton_2.Name = "radioButton_2";
			this.radioButton_2.Size = new System.Drawing.Size(119, 16);
			this.radioButton_2.TabIndex = 3;
			this.radioButton_2.TabStop = true;
			this.radioButton_2.Text = Localization.Get("按目标站编号顺序");
			this.radioButton_2.UseVisualStyleBackColor = true;
			this.label_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			this.label_0.AutoSize = true;
			this.label_0.Location = new Point(615, 288);
			this.label_0.Name = "label_0";
			this.label_0.Size = new System.Drawing.Size(125, 12);
			this.label_0.TabIndex = 18;
			this.label_0.Text = Localization.Get("循环间隔时间(分钟)：");
			this.tabControl_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.tabControl_0.Controls.Add(this.tabPage_0);
			this.tabControl_0.Controls.Add(this.tabPage_1);
			this.tabControl_0.Controls.Add(this.tabPage_2);
			this.tabControl_0.Controls.Add(this.tabPage1);
			this.tabControl_0.Controls.Add(this.tabPage_4);
			this.tabControl_0.Controls.Add(this.tabPage2);
			this.tabControl_0.Location = new Point(12, 12);
			this.tabControl_0.Name = "tabControl_0";
			this.tabControl_0.SelectedIndex = 0;
			this.tabControl_0.Size = new System.Drawing.Size(810, 340);
			this.tabControl_0.TabIndex = 17;
			this.ReplaceChapterNameOn.AutoSize = true;
			this.ReplaceChapterNameOn.ForeColor = SystemColors.HotTrack;
			this.ReplaceChapterNameOn.Location = new Point(6, 20);
			this.ReplaceChapterNameOn.Name = "ReplaceChapterNameOn";
			this.ReplaceChapterNameOn.Size = new System.Drawing.Size(300, 16);
			this.ReplaceChapterNameOn.TabIndex = 30;
			this.ReplaceChapterNameOn.Text = Localization.Get("获取列表时，使用修正列表规则（突破列表防采集）");
			this.ReplaceChapterNameOn.UseVisualStyleBackColor = true;
			base.ClientSize = new System.Drawing.Size(834, 393);
			base.Controls.Add(this.button_3);
			base.Controls.Add(this.label_16);
			base.Controls.Add(this.button_1);
			base.Controls.Add(this.tabControl_0);
			base.Controls.Add(this.button_2);
			base.Controls.Add(this.button_0);
			this.Font = new System.Drawing.Font(Localization.Font, 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
			base.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "CollectAuto";
			base.ShowInTaskbar = false;
			base.StartPosition = FormStartPosition.CenterParent;
			this.Text = Localization.Get("标准采集模式");
			base.Load += new EventHandler(this.CollectAuto_Load);
			base.FormClosing += new FormClosingEventHandler(this.CollectAuto_FormClosing);
			this.TargetMenuStrip.ResumeLayout(false);
			this.groupBox_3.ResumeLayout(false);
			this.groupBox_3.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((ISupportInitialize)this.numericUpDown_0).EndInit();
			this.SaveMenuStrip.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.groupBox8.ResumeLayout(false);
			this.groupBox_7.ResumeLayout(false);
			this.groupBox_7.PerformLayout();
			this.tabPage_4.ResumeLayout(false);
			this.groupBox_4.ResumeLayout(false);
			this.groupBox_4.PerformLayout();
			this.groupBox7.ResumeLayout(false);
			this.groupBox7.PerformLayout();
			this.groupBox_9.ResumeLayout(false);
			this.groupBox_9.PerformLayout();
			((ISupportInitialize)this.numericUpDown_3).EndInit();
			((ISupportInitialize)this.numericUpDown_4).EndInit();
			((ISupportInitialize)this.numericUpDown_5).EndInit();
			this.tabPage1.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			((ISupportInitialize)this.ReplaceChapterNun).EndInit();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			((ISupportInitialize)this.ReplaceSortId).EndInit();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.tabPage_2.ResumeLayout(false);
			this.groupBox_2.ResumeLayout(false);
			this.groupBox_2.PerformLayout();
			this.tabPage_1.ResumeLayout(false);
			this.groupBox_5.ResumeLayout(false);
			this.groupBox_5.PerformLayout();
			this.groupBox_6.ResumeLayout(false);
			this.groupBox_6.PerformLayout();
			((ISupportInitialize)this.DonnotCollectLastChapterNum).EndInit();
			((ISupportInitialize)this.numericUpDown_6).EndInit();
			((ISupportInitialize)this.numericUpDown_1).EndInit();
			((ISupportInitialize)this.numericUpDown_2).EndInit();
			this.tabPage_0.ResumeLayout(false);
			this.tabPage_0.PerformLayout();
			this.tabControl_0.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			string str = "";
			int num = 80;
			if (this.listView1.SelectedItems.Count > 0)
			{
				str = this.listView1.SelectedItems[0].SubItems[0].Text.Trim();
				num = int.Parse(this.listView1.SelectedItems[0].SubItems[1].Text.Trim());
				this.checkBox_19.Checked = true;
				this.textBox_11.Text = num.ToString();
				this.textBox_12.Text = str;
				this.tInfo.Proxy = true;
				this.tInfo.ProxyHost = str;
				this.tInfo.ProxyPort = num;
			}
		}

		private void LoginWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			int num = (new Random()).Next(10000000, 99999999);
			string str = num.ToString();
			HttpClient httpClient = new HttpClient()
			{
				UriString = string.Concat("http://www.xici.net.co/wn?", str),
				Encoding = Encoding.UTF8
			};
			HttpClient httpClient1 = httpClient;
			string stringWork = httpClient1.GetStringWork();
			string str1 = string.Format("{0}(?<getcontent>[\\s|\\S]+?){1}", "<table id=\"ip_list\">", "</table>");
			Match match = SecurityUtil.RegexsMatch(stringWork, str1);
			if (match.Success)
			{
				stringWork = match.Groups["getcontent"].Value;
				httpClient1.UriString = string.Concat("http://www.xici.net.co/nn?", str);
				string value = httpClient1.GetStringWork();
				str1 = string.Format("{0}(?<getcontent>[\\s|\\S]+?){1}", "<table id=\"ip_list\">", "</table>");
				match = SecurityUtil.RegexsMatch(value, str1);
				if (!match.Success)
				{
					MessageBox.Show(Localization.Get("获取代理ip错误,请联系管理员"));
				}
				else
				{
					value = match.Groups["getcontent"].Value;
					stringWork = string.Concat(stringWork, value);
					MatchCollection matchCollections = null;
					if (stringWork != string.Empty)
					{
						str1 = string.Format("{0}(?<getcontent>[\\s|\\S]+?){1}", "<tr class=\"\\w+\">", "</tr>");
						matchCollections = SecurityUtil.RegexsMatches(stringWork, str1);
					}
					if (matchCollections.Count > 0)
					{
						ListViewItem[] listViewItem = new ListViewItem[matchCollections.Count];
						int num1 = 0;
						foreach (Match match1 in matchCollections)
						{
							stringWork = match1.Value.Replace("\r", "").Replace("\n", "");
							str1 = string.Format("{0}(?<getcontent>[\\s|\\S]+?){1}", "<td>", "</td>");
							matchCollections = SecurityUtil.RegexsMatches(stringWork, str1);
							if (matchCollections.Count == 9 && SecurityUtil.IsIP(SecurityUtil.NoHtml(matchCollections[1].Groups["getcontent"].Value.Trim())))
							{
								listViewItem[num1] = new ListViewItem(SecurityUtil.NoHtml(matchCollections[1].Groups["getcontent"].Value.Trim()));
								listViewItem[num1].SubItems.Add(SecurityUtil.NoHtml(matchCollections[2].Groups["getcontent"].Value.Trim()));
								listViewItem[num1].SubItems.Add(SecurityUtil.NoHtml(matchCollections[3].Groups["getcontent"].Value.Trim()));
								str1 = string.Format("{0}(?<getcontent>[\\s|\\S]+?){1}", "<div title=\"", "\"");
								match = SecurityUtil.RegexsMatch(matchCollections[6].Groups["getcontent"].Value.Trim(), str1);
								if (!match.Success)
								{
									listViewItem[num1].SubItems.Add("Unknown");
								}
								else
								{
									listViewItem[num1].SubItems.Add(SecurityUtil.NoHtml(match.Groups["getcontent"].Value.Trim()));
								}
								listViewItem[num1].SubItems.Add("-");
								listViewItem[num1].SubItems.Add("-");
							} else {
                                listViewItem[num1] = new ListViewItem("Unknown");
                            }
                            num1++;
						}
                        base.Invoke(new EventHandler((object argument0, EventArgs argument1) => {
							this.listView1.Items.Clear();
							this.listView1.Items.AddRange(listViewItem);
						}));
					}
				}
			}
		}

		private void LoginWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
		}

		private void LoginWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
		}

		private void method_0(string[] string_3)
		{
			for (int i = 0; i < (int)string_3.Length && !this.AutoWorker.CancellationPending; i++)
			{
				this.AutoWorker.ReportProgress(3, i + 1);
				NovelInfo novelInfo = new NovelInfo()
				{
					Name = string_3[i]
				};
				this.method_3(novelInfo);
			}
		}

		private void method_1(string[] string_3, bool bool_1)
		{
			for (int i = 0; i < (int)string_3.Length && !this.AutoWorker.CancellationPending; i++)
			{
				this.AutoWorker.ReportProgress(3, i + 1);
				NovelInfo novelInfo = new NovelInfo();
				if (!bool_1)
				{
					novelInfo.PutID = Convert.ToInt32(string_3[i]);
				}
				else
				{
					novelInfo.GetID = string_3[i];
				}
				this.method_3(novelInfo);
			}
		}

		private void method_2(int int_0, int int_1, bool bool_1)
		{
			for (int i = int_0; i <= int_1 && !this.AutoWorker.CancellationPending; i++)
			{
				this.AutoWorker.ReportProgress(3, i - int_0 + 1);
				NovelInfo novelInfo = new NovelInfo();
				if (!bool_1)
				{
					novelInfo.PutID = i;
				}
				else
				{
					novelInfo.GetID = i.ToString();
				}
				this.method_3(novelInfo);
			}
		}

		private void method_3(NovelInfo novelInfo_0)
		{
			string[] filterNovel;
			int i;
			ChapterInfo[] chapterList;
			bool flag;
			bool flag1;
			bool flag2;
			bool flag3;
			bool flag4;
			try
			{
				NovelSpider.NativeMethods.BookCount = NovelSpider.NativeMethods.BookCount + 1;
				if (novelInfo_0.GetID == null)
				{
					novelInfo_0.GetID = "0";
				}
				if (novelInfo_0.Name == null)
				{
					novelInfo_0.Name = "";
				}
				BackgroundWorker autoWorker = this.AutoWorker;
				string[] getID = new string[] { novelInfo_0.GetID, " | ", novelInfo_0.Name, " | ", novelInfo_0.PutID.ToString() };
				autoWorker.ReportProgress(0, string.Concat(getID));
				this.AutoWorker.ReportProgress(1, "--");
				this.AutoWorker.ReportProgress(2, Localization.Get("获得小说信息"));
				this.AutoWorker.ReportProgress(4, 0);
				SpiderException.Debug(this.tInfo.ID, Localization.Get("CollectAuto.Collect 获得小说信息"));
				Page page = new Page(this.rInfo, this.tInfo);
				try
				{
					if (novelInfo_0.PutID == 0)
					{
						if (novelInfo_0.NovelUrl == null)
						{
							novelInfo_0 = page.GetNovelInfo(novelInfo_0);
						}
						novelInfo_0 = LocalProvider.GetInstance().GetNovelInfo(novelInfo_0, this.tInfo.NameAndAuthor);
					}
					else if ((novelInfo_0.GetID == "" ? true : novelInfo_0.GetID == "0"))
					{
						novelInfo_0 = LocalProvider.GetInstance().GetNovelInfo(novelInfo_0, this.tInfo.NameAndAuthor);
						BackgroundWorker backgroundWorker = this.AutoWorker;
						getID = new string[] { novelInfo_0.GetID, " | ", novelInfo_0.Name, " | ", novelInfo_0.PutID.ToString() };
						backgroundWorker.ReportProgress(0, string.Concat(getID));
						novelInfo_0 = page.GetNovelInfo(novelInfo_0);
					}
				}
				catch (Exception exception1)
				{
					Exception exception = exception1;
					SpiderException.Show(200, exception.Message, novelInfo_0, this.tInfo.Log, this.string_0, this.tInfo.RuleFile);
					return;
				}
				if (!this.AutoWorker.CancellationPending)
				{
					Thread.Sleep(this.tInfo.NovelUrlWait);
					try
					{
						ICollection keys = Configs.TaskNovelInfo.Keys;
						if (Configs.TaskNovelInfo.Count != 0)
						{
							IEnumerator enumerator = keys.GetEnumerator();
							while (enumerator.MoveNext())
							{
								string current = (string)enumerator.Current;
								if ((!(current != this.string_2) || Configs.TaskNovelInfo[current] == null ? true : !(((NovelInfo)Configs.TaskNovelInfo[current]).Name == novelInfo_0.Name)))
								{
									continue;
								}
								SpiderException.Show(101, Localization.Get("子窗口冲突"), novelInfo_0, this.tInfo.Log, this.string_0, this.tInfo.RuleFile);
								return;
							}
						}
					}
					catch
					{
						SpiderException.Show(102, Localization.Get("检查子窗口冲突失败"), novelInfo_0, this.tInfo.Log, this.string_0, this.tInfo.RuleFile);
						return;
					}
					Configs.TaskNovelInfo[this.string_2.ToString()] = novelInfo_0;
					BackgroundWorker autoWorker1 = this.AutoWorker;
					getID = new string[] { novelInfo_0.GetID, " | ", novelInfo_0.Name, " | ", novelInfo_0.PutID.ToString() };
					autoWorker1.ReportProgress(0, string.Concat(getID));
					SpiderException.Debug(this.tInfo.ID, Localization.Get("CollectAuto.Collect 过滤小说"));
					if (this.tInfo.FilterNovelType != 1)
					{
						if (this.tInfo.FilterNovelType == 2)
						{
							bool flag5 = false;
							if (this.tInfo.FilterNovel != null)
							{
								filterNovel = this.tInfo.FilterNovel;
								i = 0;
								while (i < (int)filterNovel.Length)
								{
									string str = filterNovel[i];
									if (novelInfo_0.Name.Trim() == str.Trim())
									{
										flag5 = true;
										goto Label1;
									}
									else
									{
										i++;
									}
								}
							}
						Label1:
							if (!flag5)
							{
								SpiderException.Show(135, Localization.Get("限制小说_不在白名单"), novelInfo_0, this.tInfo.Log, this.string_0, this.tInfo.RuleFile);
								return;
							}
						}
					}
					else if (this.tInfo.FilterNovel != null)
					{
						filterNovel = this.tInfo.FilterNovel;
						i = 0;
						while (i < (int)filterNovel.Length)
						{
							string str1 = filterNovel[i];
							if (novelInfo_0.Name.Trim() == str1.Trim())
							{
								SpiderException.Show(134, Localization.Get("限制小说_黑名单"), novelInfo_0, this.tInfo.Log, this.string_0, this.tInfo.RuleFile);
								return;
							}
							else
							{
								i++;
							}
						}
					}
					SpiderException.Debug(this.tInfo.ID, Localization.Get("CollectAuto.Collect 获得小说的章节目录"));
					int num = -1;
					bool flag6 = false;
					try
					{
						this.AutoWorker.ReportProgress(2, Localization.Get("获得小说的章节目录"));
						chapterList = page.GetChapterList(novelInfo_0);
					}
					catch (Exception exception3)
					{
						Exception exception2 = exception3;
						SpiderException.Show(210, exception2.Message, novelInfo_0, this.tInfo.Log, this.string_0, this.tInfo.RuleFile);
						return;
					}
					if ((chapterList == null ? false : (int)chapterList.Length != 0))
					{
						this.AutoWorker.ReportProgress(6, (int)chapterList.Length);
						if (!this.AutoWorker.CancellationPending)
						{
							if ((novelInfo_0.PutID != 0 ? false : novelInfo_0.IsNew))
							{
								this.AutoWorker.ReportProgress(2, Localization.Get("处理新书"));
								if ((!this.tInfo.Finish || novelInfo_0.Degree != 1 ? true : !this.tInfo.NewBook))
								{
									SpiderException.Debug(this.tInfo.ID, Localization.Get("CollectAuto.Collect 是否添加新书判断"));
									if (this.tInfo.NewBook)
									{
										SpiderException.Debug(this.tInfo.ID, Localization.Get("CollectAuto.Collect 章节数量限制判断"));
										if (((int)chapterList.Length >= this.tInfo.MinChapterNum ? false : this.tInfo.MinChapterNum != 0))
										{
											SpiderException.Show(131, Localization.Get("章节数量小于限制"), novelInfo_0, this.tInfo.Log, this.string_0, this.tInfo.RuleFile);
											return;
										}
									}
									else
									{
										SpiderException.Show(125, Localization.Get("设置不添加新书"), novelInfo_0, this.tInfo.Log, this.string_0, this.tInfo.RuleFile);
										return;
									}
								}
								SpiderException.Debug(this.tInfo.ID, Localization.Get("CollectAuto.Collect 正式入库小说信息"));
								novelInfo_0 = LocalProvider.GetInstance().InsertNovel(novelInfo_0);
								flag6 = true;
								BackgroundWorker backgroundWorker1 = this.AutoWorker;
								getID = new string[] { novelInfo_0.GetID, " | ", novelInfo_0.Name, " | ", novelInfo_0.PutID.ToString() };
								backgroundWorker1.ReportProgress(0, string.Concat(getID));
							}
							if (!this.AutoWorker.CancellationPending)
							{
								if (novelInfo_0.LastChapter.PutID == 0)
								{
									flag6 = true;
								}
								if (this.tInfo.ReplaceFullflag || this.tInfo.ReplaceImgflag)
								{
									flag = false;
								}
								else
								{
									flag = (this.tInfo.ReplaceIntro ? false : !this.tInfo.ReplaceSort);
								}
								if (!flag)
								{
									if (this.tInfo.ReplaceImgflag)
									{
										if ((this.tInfo.StrongReplaceImgflag ? true : novelInfo_0.ImgFlag != 1))
										{
											try
											{
												if (novelInfo_0.Cover.Height <= 5)
												{
													this.tInfo.ReplaceImgflag = false;
												}
												else
												{
													this.tInfo.ReplaceImgflag = true;
												}
											}
											catch (Exception exception4)
											{
												this.tInfo.ReplaceImgflag = false;
											}
										}
										else
										{
											this.tInfo.ReplaceImgflag = false;
										}
									}
									if (this.tInfo.ReplaceFullflag)
									{
										if ((novelInfo_0.MDegree != 0 ? true : this.tInfo.StrongReplaceIntro))
										{
											this.tInfo.ReplaceIntro = true;
										}
										else
										{
											this.tInfo.ReplaceIntro = false;
										}
									}
									if (this.tInfo.ReplaceIntro)
									{
										if ((!(novelInfo_0.Intro == "") || !(novelInfo_0.MIntro != "") ? true : this.tInfo.StrongReplaceFullflag))
										{
											this.tInfo.ReplaceFullflag = true;
										}
										else
										{
											this.tInfo.ReplaceFullflag = false;
										}
									}
									if ((novelInfo_0.MLagerSortID == novelInfo_0.LagerSortID || !this.tInfo.ReplaceSort ? true : novelInfo_0.MLagerSortID == 0))
									{
										this.tInfo.ReplaceSort = false;
									}
									else if (this.tInfo.OnlyReplaceSort)
									{
										if ((novelInfo_0.LagerSortID == this.tInfo.ReplaceSortId ? true : novelInfo_0.LagerSortID == 0))
										{
											this.tInfo.ReplaceSort = true;
										}
										else
										{
											this.tInfo.ReplaceSort = false;
										}
									}
									if (this.tInfo.ReplaceImgflag || this.tInfo.ReplaceFullflag)
									{
										flag4 = false;
									}
									else
									{
										flag4 = (this.tInfo.ReplaceIntro ? false : !this.tInfo.ReplaceSort);
									}
									if (!flag4)
									{
										LocalProvider.GetInstance().UpdateNovel(novelInfo_0, false, this.tInfo.ReplaceIntro, this.tInfo.ReplaceFullflag, this.tInfo.ReplaceSort, this.tInfo.ReplaceSort, this.tInfo.ReplaceImgflag, false);
									}
								}
								this.AutoWorker.ReportProgress(2, Localization.Get("判断是否开启超级模式"));
								ChapterInfo[] chapterInfoArray = LocalProvider.GetInstance().GetChapterList(novelInfo_0.PutID);
								novelInfo_0.LastChapter = new ChapterInfo();
								int length = 0;
								if ((int)chapterInfoArray.Length > 0)
								{
									length = (int)chapterInfoArray.Length - 1;
									if ((!Configs.BaseConfig.LicenseVip ? false : this.tInfo.ReplaceChapter))
									{
										length = (int)chapterInfoArray.Length - 1 - this.tInfo.ReplaceChapterNun;
										if (length < 0)
										{
											length = 0;
										}
									}
									novelInfo_0.LastChapter = chapterInfoArray[length];
								}
								this.AutoWorker.ReportProgress(2, Localization.Get("对比最新章节开始"));
								SpiderException.Debug(this.tInfo.ID, Localization.Get("CollectAuto.Collect 对比最新章节开始"));
								if (!flag6)
								{
									this.AutoWorker.ReportProgress(2, Localization.Get("正在对比最新章节"));
									this.AutoWorker.ReportProgress(1, "-");
									int num1 = 0;
									int num2 = 0;
									while (!this.AutoWorker.CancellationPending)
									{
										if (num2 >= (int)chapterList.Length - this.tInfo.DonnotCollectLastChapterNo)
										{
											goto Label2;
										}
										if (!this.tInfo.NoPBar)
										{
											this.AutoWorker.ReportProgress(4, num2 + 1);
										}
										switch (this.tInfo.EqualsChapter)
										{
											case 0:
											{
												if (chapterList[num2].ChapterName != novelInfo_0.LastChapter.ChapterName)
												{
													break;
												}
												num = num2;
												flag6 = true;
												break;
											}
											case 1:
											{
												if ((chapterList[num2].ChapterName != novelInfo_0.LastChapter.ChapterName ? true : !(chapterList[num2].VolumeName == novelInfo_0.LastChapter.VolumeName)))
												{
													break;
												}
												num = num2;
												flag6 = true;
												break;
											}
											case 2:
											{
												if (!FormatText.CompareToChapter(chapterList[num2].ChapterName, novelInfo_0.LastChapter.ChapterName))
												{
													break;
												}
												num = num2;
												flag6 = true;
												break;
											}
											case 3:
											{
												int chapter2 = FormatText.CompareToChapter2(chapterList[num2].ChapterName, novelInfo_0.LastChapter.ChapterName, chapterList[num2].VolumeName, novelInfo_0.LastChapter.VolumeName);
												if ((chapter2 <= 3 ? true : chapter2 < num1))
												{
													break;
												}
												num1 = chapter2;
												num = num2;
												flag6 = true;
												break;
											}
											case 4:
											{
												int chapter3 = FormatText.CompareToChapter3(chapterList[num2].ChapterName, novelInfo_0.LastChapter.ChapterName, chapterList[num2].VolumeName, novelInfo_0.LastChapter.VolumeName);
												if ((chapter3 <= 0 ? true : chapter3 < num1))
												{
													break;
												}
												num1 = chapter3;
												num = num2;
												flag6 = true;
												break;
											}
											case 5:
											{
												int chapter4 = FormatText.CompareToChapter4(chapterList[num2].ChapterName, num2, novelInfo_0.LastChapter.ChapterName, novelInfo_0.Chapters, chapterList[num2].VolumeName, novelInfo_0.LastChapter.VolumeName);
												if ((chapter4 <= 0 ? true : chapter4 < num1))
												{
													break;
												}
												num1 = chapter4;
												num = num2;
												flag6 = true;
												break;
											}
										}
										num2++;
									}
									return;
								}
							Label2:
								if (!this.AutoWorker.CancellationPending)
								{
									if (!flag6)
									{
										if (this.tInfo.DeleteChapter)
										{
											this.AutoWorker.ReportProgress(2, Localization.Get("正在清空章节"));
											LocalProvider.GetInstance().ClearNovel(novelInfo_0);
											flag6 = true;
										}
										else
										{
											SpiderException.Show(120, string.Concat(novelInfo_0.LastChapter.VolumeName, " | ", novelInfo_0.LastChapter.ChapterName), novelInfo_0, this.tInfo.Log, this.string_0, this.tInfo.RuleFile);
											return;
										}
									}
									else if (this.tInfo.CompulsoryDeleteChapter)
									{
										this.AutoWorker.ReportProgress(2, Localization.Get("正在强制清空章节"));
										LocalProvider.GetInstance().ClearNovel(novelInfo_0);
										flag6 = true;
										num = -1;
									}
									if ((int)chapterList.Length - num > this.tInfo.FindMaxChapterNum)
									{
										SpiderException.Show(132, Localization.Get("对比最新章节成功！但需要采集到章节数超限。"), novelInfo_0, this.tInfo.Log, this.string_0, this.tInfo.RuleFile);
									}
									else if ((this.AutoWorker.CancellationPending || !this.tInfo.OldBook ? false : flag6))
									{
										Thread.Sleep(this.tInfo.IndexUrlWait);
										bool flag7 = false;
										int num3 = num + 1;
										int num4 = 0;
										int num5 = 0;
										while (true)
										{
											if ((num3 >= (int)chapterList.Length - this.tInfo.DonnotCollectLastChapterNo ? true : this.AutoWorker.CancellationPending))
											{
												break;
											}
											num4++;
											num5 = length + num4;
											if (num5 < (int)chapterInfoArray.Length)
											{
												chapterList[num3].PutID = chapterInfoArray[num5].PutID;
											}
											if ((this.tInfo.FilterVolume == null ? true : !(this.tInfo.FilterVolume[0].Replace(" ", "") != "")))
											{
												if ((this.tInfo.FilterContinueChapterName == null ? false : this.tInfo.FilterContinueChapterName[0].Replace(" ", "") != ""))
												{
													if (!this.tInfo.NoPBar)
													{
														this.AutoWorker.ReportProgress(2, Localization.Get("过滤章节名"));
														this.AutoWorker.ReportProgress(1, chapterList[num3].ChapterName);
														this.AutoWorker.ReportProgress(4, num3 + 1);
													}
													string str2 = "";
													filterNovel = this.tInfo.FilterContinueChapterName;
													for (i = 0; i < (int)filterNovel.Length; i++)
													{
														string str3 = filterNovel[i];
														if (str3.Replace(" ", "") != "")
														{
															str2 = str3.Replace(Localization.Get("{$书卷名称$}"), chapterList[num3].VolumeName).Replace(Localization.Get("{$小说作者$}"), novelInfo_0.Author).Replace(Localization.Get("{$小说名称$}"), novelInfo_0.Name).Replace(Localization.Get("{$分类名称$}"), novelInfo_0.LagerSort);
														}
													}
													if (!Regex.Match(chapterList[num3].ChapterName, str2, RegexOptions.IgnoreCase).Success)
													{
														goto Label4;
													}
													SpiderException.Show(137, string.Concat(Localization.Get("限制章节("), chapterList[num3].ChapterName, Localization.Get(")_跳出本章节")), novelInfo_0, this.tInfo.Log, this.string_0, this.tInfo.RuleFile);
													LocalProvider.GetInstance().CreateIndex(novelInfo_0, Configs.BaseConfig.IndexHtml, Configs.BaseConfig.FullHtml, Configs.BaseConfig.bool_10, Configs.BaseConfig.CreateTxt, false, false, 0);
													goto Label3;
												}
											Label4:
												flag2 = (this.tInfo.FilterChapterName == null ? true : !(this.tInfo.FilterChapterName[0].Replace(" ", "") != ""));
												if (!flag2)
												{
													if (!this.tInfo.NoPBar)
													{
														this.AutoWorker.ReportProgress(2, Localization.Get("过滤章节名"));
														this.AutoWorker.ReportProgress(1, chapterList[num3].ChapterName);
														this.AutoWorker.ReportProgress(4, num3 + 1);
													}
													string str4 = "";
													filterNovel = this.tInfo.FilterChapterName;
													for (i = 0; i < (int)filterNovel.Length; i++)
													{
														string str5 = filterNovel[i];
														if (str5.Replace(" ", "") != "")
														{
															str4 = str5.Replace(Localization.Get("{$书卷名称$}"), chapterList[num3].VolumeName).Replace(Localization.Get("{$小说作者$}"), novelInfo_0.Author).Replace(Localization.Get("{$小说名称$}"), novelInfo_0.Name).Replace(Localization.Get("{$分类名称$}"), novelInfo_0.LagerSort);
														}
													}
													if (Regex.Match(chapterList[num3].ChapterName, str4, RegexOptions.IgnoreCase).Success)
													{
														SpiderException.Show(137, string.Concat(Localization.Get("限制章节("), chapterList[num3].ChapterName, Localization.Get(")_跳出本书")), novelInfo_0, this.tInfo.Log, this.string_0, this.tInfo.RuleFile);
														LocalProvider.GetInstance().CreateIndex(novelInfo_0, Configs.BaseConfig.IndexHtml, Configs.BaseConfig.FullHtml, Configs.BaseConfig.bool_10, Configs.BaseConfig.CreateTxt, false, false, 0);
														return;
													}
												}
												if ((this.tInfo.FilterContinueVolume == null ? false : this.tInfo.FilterContinueVolume[0].Replace(" ", "") != ""))
												{
													if (!this.tInfo.NoPBar)
													{
														this.AutoWorker.ReportProgress(2, string.Concat(Localization.Get("限制章节《"), chapterList[num3].VolumeName, Localization.Get("》不入库分卷名")));
														this.AutoWorker.ReportProgress(1, chapterList[num3].ChapterName);
														this.AutoWorker.ReportProgress(4, num3 + 1);
													}
													string str6 = "";
													filterNovel = this.tInfo.FilterContinueVolume;
													for (i = 0; i < (int)filterNovel.Length; i++)
													{
														string str7 = filterNovel[i];
														if (str7.Replace(" ", "") != "")
														{
															str6 = str7.Replace(Localization.Get("{$书卷名称$}"), chapterList[num3].VolumeName).Replace(Localization.Get("{$小说作者$}"), novelInfo_0.Author).Replace(Localization.Get("{$小说名称$}"), novelInfo_0.Name).Replace(Localization.Get("{$分类名称$}"), novelInfo_0.LagerSort);
														}
													}
													if (!Regex.Match(chapterList[num3].VolumeName, str6, RegexOptions.IgnoreCase).Success)
													{
														flag3 = true;
													}
													else
													{
														flag3 = (num3 != 0 ? false : !(chapterList[0].VolumeName != Configs.BaseConfig.DefaultVolumeName));
													}
													if (!flag3)
													{
														chapterList[num3].VolumeName = "";
													}
												}
												if (this.tInfo.CheckRepeat)
												{
													if (!this.tInfo.NoPBar)
													{
														this.AutoWorker.ReportProgress(2, Localization.Get("重复章节检查"));
														this.AutoWorker.ReportProgress(1, chapterList[num3].ChapterName);
														this.AutoWorker.ReportProgress(4, num3 + 1);
													}
													int num6 = 0;
													bool flag8 = false;
													int num7 = 0;
													while (true)
													{
														if (num7 <= (int)chapterInfoArray.Length - 1)
														{
															switch (this.tInfo.RepeatChapter)
															{
																case 0:
																{
																	if ((!Configs.BaseConfig.LicenseVip || !this.tInfo.ReplaceChapter ? false : num7 > length) || !(chapterList[num3].ChapterName == chapterInfoArray[num7].ChapterName))
																	{
																		break;
																	}
																	flag8 = true;
																	break;
																}
																case 1:
																{
																	if ((!Configs.BaseConfig.LicenseVip || !this.tInfo.ReplaceChapter ? false : num7 > length))
																	{
																		break;
																	}
																	if ((chapterList[num3].ChapterName != chapterInfoArray[num7].ChapterName ? true : !(chapterList[num3].VolumeName == chapterInfoArray[num7].VolumeName)))
																	{
																		break;
																	}
																	flag8 = true;
																	break;
																}
																case 2:
																{
																	if ((!Configs.BaseConfig.LicenseVip || !this.tInfo.ReplaceChapter ? true : num7 <= length))
																	{
																		if (!FormatText.CompareToChapter(chapterList[num3].ChapterName, chapterInfoArray[num7].ChapterName))
																		{
																			break;
																		}
																		flag8 = true;
																		break;
																	}
																	else
																	{
																		chapterList[num3].PutID = chapterInfoArray[num7].PutID;
																		break;
																	}
																}
																case 3:
																{
																	if ((!Configs.BaseConfig.LicenseVip || !this.tInfo.ReplaceChapter ? false : num7 > length))
																	{
																		break;
																	}
																	int chapter21 = FormatText.CompareToChapter2(chapterList[num3].ChapterName, chapterInfoArray[num7].ChapterName, chapterList[num3].VolumeName, chapterInfoArray[num7].VolumeName);
																	if ((chapter21 <= 8 ? true : chapter21 < num6))
																	{
																		break;
																	}
																	num6 = chapter21;
																	flag8 = true;
																	break;
																}
																case 4:
																{
																	if ((!Configs.BaseConfig.LicenseVip || !this.tInfo.ReplaceChapter ? false : num7 > length))
																	{
																		break;
																	}
																	int chapter31 = FormatText.CompareToChapter3(chapterList[num3].ChapterName, chapterInfoArray[num7].ChapterName, chapterList[num3].VolumeName, chapterInfoArray[num7].VolumeName);
																	if ((chapter31 <= 0 ? true : chapter31 < num6))
																	{
																		break;
																	}
																	num6 = chapter31;
																	flag8 = true;
																	break;
																}
																case 5:
																{
																	if ((!Configs.BaseConfig.LicenseVip || !this.tInfo.ReplaceChapter ? false : num7 > length))
																	{
																		break;
																	}
																	int chapter41 = FormatText.CompareToChapter4(chapterList[num3].ChapterName, num3, chapterInfoArray[num7].ChapterName, num7, chapterList[num3].VolumeName, novelInfo_0.LastChapter.VolumeName);
																	if ((chapter41 <= 0 ? true : chapter41 < num6))
																	{
																		break;
																	}
																	num6 = chapter41;
																	flag8 = true;
																	break;
																}
															}
															if (flag8)
															{
																getID = new string[] { chapterList[num3].VolumeName, "|", chapterList[num3].ChapterName, "@", chapterInfoArray[num7].VolumeName, "|", chapterInfoArray[num7].ChapterName };
																SpiderException.Show(122, string.Concat(getID), novelInfo_0, this.tInfo.Log, this.string_0, this.tInfo.RuleFile);
																break;
															}
															else
															{
																num7++;
															}
														}
														else
														{
															break;
														}
													}
													if ((!flag8 ? false : this.tInfo.RepeatChapterHandle == 0))
													{
														break;
													}
													if ((!flag8 ? false : this.tInfo.RepeatChapterHandle != 0))
													{
														goto Label3;
													}
												}
												this.AutoWorker.ReportProgress(1, chapterList[num3].ChapterName);
												this.AutoWorker.ReportProgress(4, num3 + 1);
												novelInfo_0.LastChapter = chapterList[num3];
												if (novelInfo_0.LastChapter.PutID <= 0)
												{
													int replaceChapterNun = num4;
													if (this.tInfo.ReplaceChapter)
													{
														replaceChapterNun = num4 - this.tInfo.ReplaceChapterNun;
														if ((int)chapterInfoArray.Length < this.tInfo.ReplaceChapterNun)
														{
															replaceChapterNun = replaceChapterNun + (this.tInfo.ReplaceChapterNun - (int)chapterInfoArray.Length);
														}
													}
													this.AutoWorker.ReportProgress(2, string.Concat(Localization.Get("开始采集新章节第"), replaceChapterNun, Localization.Get("个")));
												}
												else
												{
													this.AutoWorker.ReportProgress(2, string.Concat(Localization.Get("开始采集替换章节第"), num4, Localization.Get("个")));
												}
												try
												{
													novelInfo_0 = page.GetChapterInfo(novelInfo_0, false);
												}
												catch (Exception exception6)
												{
													Exception exception5 = exception6;
													SpiderException.Show(220, exception5.Message, novelInfo_0, this.tInfo.Log, this.string_0, this.tInfo.RuleFile);
													break;
												}
												bool flag9 = true;
												if ((novelInfo_0.LastChapter.ChapterText == null ? true : novelInfo_0.LastChapter.ChapterText.Trim() == ""))
												{
													SpiderException.Show(121, string.Concat(novelInfo_0.LastChapter.ChapterName, "|", novelInfo_0.LastChapter.ChapterUrl), novelInfo_0, this.tInfo.Log, this.string_0, this.tInfo.RuleFile);
													switch (this.tInfo.EmptyChapter)
													{
														case 0:
														{
															return;
														}
														case 1:
														{
															flag9 = false;
															break;
														}
														case 2:
														{
															flag9 = true;
															break;
														}
													}
												}
												if ((!Regex.Match(chapterList[num3].ChapterText, "<img", RegexOptions.IgnoreCase).Success ? false : this.tInfo.OnlyText))
												{
													SpiderException.Show(124, string.Concat(novelInfo_0.LastChapter.ChapterName, "|", novelInfo_0.LastChapter.ChapterUrl), novelInfo_0, this.tInfo.Log, this.string_0, this.tInfo.RuleFile);
													return;
												}
												else
												{
													if (flag9)
													{
														this.AutoWorker.ReportProgress(2, Localization.Get("正在入库章节"));
														if (novelInfo_0.LastChapter.ChapterText.Length <= this.tInfo.MinChapterTextLength)
														{
															object[] objArray = new object[] { Localization.Get("空章节或当前章节字数"), novelInfo_0.LastChapter.ChapterText.Length, Localization.Get("少于设置的"), this.tInfo.MinChapterTextLength, Localization.Get("字") };
															SpiderException.Show(130, string.Concat(objArray), novelInfo_0, this.tInfo.Log, this.string_0, this.tInfo.RuleFile);
															break;
														}
														else
														{
															try
															{
																novelInfo_0.LastChapter.ChapterName = chapterList[num3].ChapterName;
																novelInfo_0.LastChapter.ItemIndex = num3;
																if (novelInfo_0.LastChapter.PutID <= 0)
																{
																	LocalProvider.GetInstance().InsertChapter(novelInfo_0, this.tInfo);
																}
																else
																{
																	bool flag10 = true;
																	if (this.tInfo.DelChapter)
																	{
																		string chapterText = LocalProvider.GetInstance().GetChapterText(novelInfo_0, false);
																		string chapterText1 = LocalProvider.GetInstance().GetChapterText(novelInfo_0, true);
																		if (SecurityUtil.MD5(chapterText) == SecurityUtil.MD5(chapterText1.Substring(0, chapterText1.Length - 4)))
																		{
																			flag10 = false;
																		}
																	}
																	if (!flag10)
																	{
																		num3++;
																		NovelSpider.NativeMethods.ChapterCount = NovelSpider.NativeMethods.ChapterCount + 1;
																		continue;
																	}
																	else
																	{
																		ReplaceConfigInfo replaceConfigInfo = new ReplaceConfigInfo()
																		{
																			UpdateChapterName = true
																		};
																		novelInfo_0.LastChapter.LastTime = DateTime.Now;
																		LocalProvider.GetInstance().UpdateChapter(novelInfo_0, replaceConfigInfo);
																	}
																}
																NovelSpider.NativeMethods.ChapterCount = NovelSpider.NativeMethods.ChapterCount + 1;
															}
															catch (Exception exception8)
															{
																Exception exception7 = exception8;
																SpiderException.Show(441, exception7.Message, novelInfo_0, this.tInfo.Log, this.string_0, this.tInfo.RuleFile);
															}
															if (Configs.BaseConfig.ChapterHtml)
															{
																this.AutoWorker.ReportProgress(2, Localization.Get("正在生成章节Html"));
																LocalProvider.GetInstance().CreateChapter(novelInfo_0);
															}
															flag7 = true;
														}
													}
													if ((DateTime.Now.Second % 12 != 10 ? false : !FormatDateTime.CheckHost()))
													{
														Thread.Sleep(5000);
													}
													Thread.Sleep(this.tInfo.ChapterUrlWait);
												}
											}
											else
											{
												if (!this.tInfo.NoPBar)
												{
													this.AutoWorker.ReportProgress(2, Localization.Get("过滤章节名"));
													this.AutoWorker.ReportProgress(1, chapterList[num3].ChapterName);
													this.AutoWorker.ReportProgress(4, num3 + 1);
												}
												string str8 = "";
												filterNovel = this.tInfo.FilterVolume;
												for (i = 0; i < (int)filterNovel.Length; i++)
												{
													string str9 = filterNovel[i];
													if (str9.Replace(" ", "") != "")
													{
														str8 = str9.Replace(Localization.Get("{$书卷名称$}"), chapterList[num3].VolumeName).Replace(Localization.Get("{$小说作者$}"), novelInfo_0.Author).Replace(Localization.Get("{$小说名称$}"), novelInfo_0.Name).Replace(Localization.Get("{$分类名称$}"), novelInfo_0.LagerSort);
													}
												}
												if (Regex.Match(chapterList[num3].VolumeName, str8, RegexOptions.IgnoreCase).Success)
												{
													SpiderException.Show(137, string.Concat(Localization.Get("限制分卷("), chapterList[num3].VolumeName, Localization.Get(")_跳出本分卷章节")), novelInfo_0, this.tInfo.Log, this.string_0, this.tInfo.RuleFile);
												}
											}
										Label3:
											num3++;
										}
										if (!flag7)
										{
											flag1 = true;
										}
										else
										{
											flag1 = (Configs.BaseConfig.IndexHtml || Configs.BaseConfig.FullHtml ? false : !Configs.BaseConfig.bool_10);
										}
										if (!flag1)
										{
											this.AutoWorker.ReportProgress(2, Localization.Get("清理正在生成目录Html (此过程将同时生成OPF和其他格式)"));
											LocalProvider.GetInstance().CreateIndex(novelInfo_0, Configs.BaseConfig.IndexHtml, Configs.BaseConfig.FullHtml, Configs.BaseConfig.bool_10, Configs.BaseConfig.CreateTxt, false, false, 0);
										}
									}
								}
							}
						}
					}
					else
					{
						SpiderException.Show(214, Localization.Get("章节组为空"), novelInfo_0, this.tInfo.Log, this.string_0, this.tInfo.RuleFile);
					}
				}
			}
			catch (Exception exception10)
			{
				Exception exception9 = exception10;
				SpiderException.Show(0, string.Concat(novelInfo_0.LastChapter.ChapterName, "|", novelInfo_0.LastChapter.ChapterUrl), novelInfo_0, this.tInfo.Log, exception9.Message, this.tInfo.RuleFile);
			}
		}

		private void method_4()
		{
			try
			{
				this.comboBox_0.Text = this.tInfo.RuleFile;
				string radioBy = this.tInfo.RadioBy;
				if (radioBy != null)
				{
					if (radioBy == "GetListUrl")
					{
						this.radioButton_0.Checked = true;
					}
					else if (radioBy == "GetOrderId")
					{
						this.radioButton_2.Checked = true;
					}
					else if (radioBy == "GetSinceId")
					{
						this.radioButton_1.Checked = true;
					}
					else if (radioBy == "PutOrderId")
					{
						this.radioButton_4.Checked = true;
					}
					else if (radioBy == "PutSinceId")
					{
						this.radioButton_3.Checked = true;
					}
					else if (radioBy == "OtherListUrl")
					{
						this.radioButton_5.Checked = true;
					}
				}
				if (this.tInfo.GetListUrl != null)
				{
					this.textBox_3.Text = string.Join("\r\n", this.tInfo.GetListUrl);
				}
				TextBox textBox6 = this.textBox_6;
				int getOrderMinId = this.tInfo.GetOrderMinId;
				textBox6.Text = getOrderMinId.ToString();
				TextBox textBox5 = this.textBox_5;
				getOrderMinId = this.tInfo.GetOrderMaxId;
				textBox5.Text = getOrderMinId.ToString();
				if (this.tInfo.GetSinceId != null)
				{
					this.textBox_4.Text = string.Join(",", this.tInfo.GetSinceId);
				}
				TextBox textBox2 = this.textBox_2;
				getOrderMinId = this.tInfo.PutOrderMinId;
				textBox2.Text = getOrderMinId.ToString();
				TextBox textBox1 = this.textBox_1;
				getOrderMinId = this.tInfo.PutOrderMaxId;
				textBox1.Text = getOrderMinId.ToString();
				if (this.tInfo.PutSinceId != null)
				{
					this.textBox_0.Text = string.Join(",", this.tInfo.PutSinceId);
				}
				this.textBox_17.Text = this.tInfo.OtherListUrl;
				this.textBox_16.Text = this.tInfo.OtherRegex;
				this.textBox_18.Text = this.tInfo.OtherEncoding;
				this.checkBox_3.Checked = this.tInfo.Log;
				this.checkBox_2.Checked = this.tInfo.Timing;
				this.numericUpDown_0.Value = this.tInfo.Interval;
				this.checkBox_0.Checked = this.tInfo.NewBook;
				this.checkBox_1.Checked = this.tInfo.OldBook;
				this.checkBox_8.Checked = this.tInfo.FilterFinish;
				this.checkBox_16.Checked = this.tInfo.Typesetting;
				this.checkBox_18.Checked = this.tInfo.CompulsoryDeleteChapter;
				this.checkBox_6.Checked = this.tInfo.DeleteChapter;
				this.checkBox_4.Checked = this.tInfo.ProhibitionVolume;
				this.checkBox_17.Checked = this.tInfo.NameAndAuthor;
				this.checkBox_21.Checked = this.tInfo.CheckVolume;
				this.checkBox_10.Checked = this.tInfo.UpdateDefault;
				this.checkBox_9.Checked = this.tInfo.OnlyText;
				this.checkBox_22.Checked = this.tInfo.CheckRepeat;
				this.comboBox_2.SelectedIndex = this.tInfo.EqualsChapter;
				this.comboBox_6.SelectedIndex = this.tInfo.RepeatChapter;
				this.comboBox1.SelectedIndex = this.tInfo.RepeatChapterHandle;
				this.comboBox_1.SelectedIndex = this.tInfo.EmptyChapter;
				this.comboBox_5.SelectedIndex = this.tInfo.GoRepeatChapter;
				this.comboBox_7.SelectedIndex = this.tInfo.OrderChapter;
				this.numericUpDown_6.Value = this.tInfo.MinChapterTextLength;
				this.numericUpDown_2.Value = this.tInfo.MinChapterNum;
				this.numericUpDown_1.Value = this.tInfo.FindMaxChapterNum;
				this.checkBox_15.Checked = this.tInfo.Finish;
				this.HideBook.Checked = this.tInfo.Hidebook;
				this.DonnotCollectLastChapterNum.Value = this.tInfo.DonnotCollectLastChapterNo;
				this.FilterNovelType.SelectedIndex = this.tInfo.FilterNovelType;
				if (this.tInfo.FilterVolume != null)
				{
					this.FilterVolumeTextBox.Text = string.Join("\r\n", this.tInfo.FilterVolume);
				}
				if (this.tInfo.FilterContinueVolume != null)
				{
					this.FilterVolumeTextBox1.Text = string.Join("\r\n", this.tInfo.FilterContinueVolume);
				}
				if (this.tInfo.FilterChapterName != null)
				{
					this.FilterChapterNameBox.Text = string.Join("\r\n", this.tInfo.FilterChapterName);
				}
				if (this.tInfo.FilterContinueChapterName != null)
				{
					this.FilterChapterNameBox1.Text = string.Join("\r\n", this.tInfo.FilterContinueChapterName);
				}
				if (this.tInfo.FilterNovel != null)
				{
					this.FilterNovelTextBox.Text = string.Join("\r\n", this.tInfo.FilterNovel);
				}
				this.ReplaceImgflag.Checked = this.tInfo.ReplaceImgflag;
				this.ReplaceFullflag.Checked = this.tInfo.ReplaceFullflag;
				this.ReplaceIntro.Checked = this.tInfo.ReplaceIntro;
				this.ReplaceSort.Checked = this.tInfo.ReplaceSort;
				this.OnlyReplaceSort.Checked = this.tInfo.OnlyReplaceSort;
				this.ReplaceChapter.Checked = this.tInfo.ReplaceChapter;
				this.DelChapter.Checked = this.tInfo.DelChapter;
				this.ReplaceSortId.Value = this.tInfo.ReplaceSortId;
				this.ReplaceChapterNun.Value = this.tInfo.ReplaceChapterNun;
				this.ReplaceChapterNameOn.Checked = this.tInfo.ReplaceChapterNameOn;
				this.StrongReplaceImgflag.Checked = this.tInfo.StrongReplaceImgflag;
				this.StrongReplaceFullflag.Checked = this.tInfo.StrongReplaceFullflag;
				this.StrongReplaceIntro.Checked = this.tInfo.StrongReplaceIntro;
				if (!Configs.BaseConfig.LicenseVip)
				{
					this.ReplaceChapterNun.Value = new decimal(0);
					this.ReplaceChapterNameOn.Checked = false;
					this.ReplaceChapter.Checked = false;
					this.DelChapter.Checked = false;
					this.groupBox6.Enabled = false;
					this.groupBox4.Enabled = false;
					this.label16.Text = Localization.Get("普通版本无期限");
				}
				else if (Configs.BaseConfig.LicenseTime <= DateTime.Now.AddMonths(3))
				{
					this.label16.Text = string.Concat(Localization.Get("高级版本，到期时间("), Configs.BaseConfig.LicenseTime.ToLongDateString(), ")");
				}
				else
				{
					this.label16.Text = Localization.Get("高级版本无期限，永久无需验证");
				}
				this.textBox_12.Text = this.tInfo.ProxyHost;
				TextBox textBox11 = this.textBox_11;
				getOrderMinId = this.tInfo.ProxyPort;
				textBox11.Text = getOrderMinId.ToString();
				this.textBox_14.Text = this.tInfo.ProxyDomain;
				this.textBox_10.Text = this.tInfo.ProxyUser;
				this.textBox_9.Text = this.tInfo.ProxyPassword;
				this.checkBox_19.Checked = this.tInfo.Proxy;
				this.numericUpDown_5.Value = this.tInfo.NovelUrlWait;
				this.numericUpDown_4.Value = this.tInfo.IndexUrlWait;
				this.numericUpDown_3.Value = this.tInfo.ChapterUrlWait;
				this.checkBox_20.Checked = this.tInfo.NoPBar;
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageForm messageForm = new MessageForm()
				{
					Text = Localization.Get("错误提示")
				};
				messageForm.MessageText.Text = exception.Message;
				messageForm.ShowDialog();
			}
		}

		private void method_5()
		{
			try
			{
				this.tInfo.RuleFile = this.comboBox_0.Text;
				if (this.radioButton_0.Checked)
				{
					this.tInfo.RadioBy = "GetListUrl";
				}
				if (this.radioButton_2.Checked)
				{
					this.tInfo.RadioBy = "GetOrderId";
				}
				if (this.radioButton_1.Checked)
				{
					this.tInfo.RadioBy = "GetSinceId";
				}
				if (this.radioButton_4.Checked)
				{
					this.tInfo.RadioBy = "PutOrderId";
				}
				if (this.radioButton_3.Checked)
				{
					this.tInfo.RadioBy = "PutSinceId";
				}
				if (this.radioButton_5.Checked)
				{
					this.tInfo.RadioBy = "OtherListUrl";
				}
				TaskConfigInfo taskConfigInfo = this.tInfo;
				string str = this.textBox_3.Text.Trim().Replace("\r\n", "♂");
				char[] chrArray = new char[] { '\u2642' };
				taskConfigInfo.GetListUrl = str.Split(chrArray);
				this.tInfo.GetOrderMinId = Convert.ToInt32(this.textBox_6.Text);
				this.tInfo.GetOrderMaxId = Convert.ToInt32(this.textBox_5.Text);
				TaskConfigInfo taskConfigInfo1 = this.tInfo;
				string text = this.textBox_4.Text;
				chrArray = new char[] { ',' };
				taskConfigInfo1.GetSinceId = text.Split(chrArray);
				this.tInfo.OtherListUrl = this.textBox_17.Text;
				this.tInfo.OtherRegex = this.textBox_16.Text;
				this.tInfo.OtherEncoding = this.textBox_18.Text;
				this.tInfo.PutOrderMinId = Convert.ToInt32(this.textBox_2.Text);
				this.tInfo.PutOrderMaxId = Convert.ToInt32(this.textBox_1.Text);
				TaskConfigInfo taskConfigInfo2 = this.tInfo;
				string text1 = this.textBox_0.Text;
				chrArray = new char[] { ',' };
				taskConfigInfo2.PutSinceId = text1.Split(chrArray);
				this.tInfo.Log = this.checkBox_3.Checked;
				this.tInfo.Timing = this.checkBox_2.Checked;
				this.tInfo.Interval = Convert.ToInt32(this.numericUpDown_0.Value);
				this.tInfo.NewBook = this.checkBox_0.Checked;
				this.tInfo.OldBook = this.checkBox_1.Checked;
				this.tInfo.FilterFinish = this.checkBox_8.Checked;
				this.tInfo.Typesetting = this.checkBox_16.Checked;
				this.tInfo.CompulsoryDeleteChapter = this.checkBox_18.Checked;
				this.tInfo.DeleteChapter = this.checkBox_6.Checked;
				this.tInfo.ProhibitionVolume = this.checkBox_4.Checked;
				this.tInfo.CheckVolume = this.checkBox_21.Checked;
				this.tInfo.UpdateDefault = this.checkBox_10.Checked;
				this.tInfo.OnlyText = this.checkBox_9.Checked;
				this.tInfo.CheckRepeat = this.checkBox_22.Checked;
				this.tInfo.EqualsChapter = this.comboBox_2.SelectedIndex;
				this.tInfo.RepeatChapter = this.comboBox_6.SelectedIndex;
				this.tInfo.RepeatChapterHandle = this.comboBox1.SelectedIndex;
				this.tInfo.EmptyChapter = this.comboBox_1.SelectedIndex;
				this.tInfo.GoRepeatChapter = this.comboBox_5.SelectedIndex;
				this.tInfo.OrderChapter = this.comboBox_7.SelectedIndex;
				this.tInfo.NameAndAuthor = this.checkBox_17.Checked;
				this.tInfo.MinChapterTextLength = Convert.ToInt32(this.numericUpDown_6.Value);
				this.tInfo.MinChapterNum = Convert.ToInt32(this.numericUpDown_2.Value);
				this.tInfo.FindMaxChapterNum = Convert.ToInt32(this.numericUpDown_1.Value);
				this.tInfo.Finish = this.checkBox_15.Checked;
				this.tInfo.Hidebook = this.HideBook.Checked;
				this.tInfo.DonnotCollectLastChapterNo = Convert.ToInt32(this.DonnotCollectLastChapterNum.Value);
				this.tInfo.FilterNovelType = this.FilterNovelType.SelectedIndex;
				TaskConfigInfo taskConfigInfo3 = this.tInfo;
				string str1 = this.FilterVolumeTextBox.Text.Replace("\r\n", "♂");
				chrArray = new char[] { '\u2642' };
				taskConfigInfo3.FilterVolume = str1.Split(chrArray);
				TaskConfigInfo taskConfigInfo4 = this.tInfo;
				string str2 = this.FilterVolumeTextBox1.Text.Replace("\r\n", "♂");
				chrArray = new char[] { '\u2642' };
				taskConfigInfo4.FilterContinueVolume = str2.Split(chrArray);
				TaskConfigInfo taskConfigInfo5 = this.tInfo;
				string str3 = this.FilterNovelTextBox.Text.Replace("\r\n", "♂");
				chrArray = new char[] { '\u2642' };
				taskConfigInfo5.FilterNovel = str3.Split(chrArray);
				TaskConfigInfo taskConfigInfo6 = this.tInfo;
				string str4 = this.FilterChapterNameBox.Text.Replace("\r\n", "♂");
				chrArray = new char[] { '\u2642' };
				taskConfigInfo6.FilterChapterName = str4.Split(chrArray);
				TaskConfigInfo taskConfigInfo7 = this.tInfo;
				string str5 = this.FilterChapterNameBox1.Text.Replace("\r\n", "♂");
				chrArray = new char[] { '\u2642' };
				taskConfigInfo7.FilterContinueChapterName = str5.Split(chrArray);
				this.tInfo.ReplaceImgflag = this.ReplaceImgflag.Checked;
				this.tInfo.ReplaceFullflag = this.ReplaceFullflag.Checked;
				this.tInfo.ReplaceIntro = this.ReplaceIntro.Checked;
				this.tInfo.ReplaceSort = this.ReplaceSort.Checked;
				this.tInfo.OnlyReplaceSort = this.OnlyReplaceSort.Checked;
				this.tInfo.ReplaceChapter = this.ReplaceChapter.Checked;
				this.tInfo.DelChapter = this.DelChapter.Checked;
				this.tInfo.ReplaceSortId = Convert.ToInt32(this.ReplaceSortId.Value);
				this.tInfo.ReplaceChapterNun = Convert.ToInt32(this.ReplaceChapterNun.Value);
				this.tInfo.ReplaceChapterNameOn = this.ReplaceChapterNameOn.Checked;
				this.tInfo.StrongReplaceImgflag = this.StrongReplaceImgflag.Checked;
				this.tInfo.StrongReplaceFullflag = this.StrongReplaceFullflag.Checked;
				this.tInfo.StrongReplaceIntro = this.StrongReplaceIntro.Checked;
				this.tInfo.ProxyHost = this.textBox_12.Text;
				this.tInfo.ProxyPort = Convert.ToInt32(this.textBox_11.Text);
				this.tInfo.ProxyDomain = this.textBox_14.Text;
				this.tInfo.ProxyUser = this.textBox_10.Text;
				this.tInfo.ProxyPassword = this.textBox_9.Text;
				this.tInfo.Proxy = this.checkBox_19.Checked;
				this.tInfo.NoPBar = this.checkBox_20.Checked;
				this.tInfo.NovelUrlWait = Convert.ToInt32(this.numericUpDown_5.Value);
				this.tInfo.IndexUrlWait = Convert.ToInt32(this.numericUpDown_4.Value);
				this.tInfo.ChapterUrlWait = Convert.ToInt32(this.numericUpDown_3.Value);
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				MessageForm messageForm = new MessageForm()
				{
					Text = "错误提示"
				};
				messageForm.MessageText.Text = exception.Message;
				messageForm.ShowDialog();
			}
		}

		private void OnlyReplaceSort_CheckedChanged(object sender, EventArgs e)
		{
			if (this.OnlyReplaceSort.Checked)
			{
				this.ReplaceSort.Checked = true;
			}
		}

		private void ReplaceFullflag_CheckedChanged(object sender, EventArgs e)
		{
			if (!this.ReplaceFullflag.Checked)
			{
				this.StrongReplaceFullflag.Checked = false;
			}
		}

		private void ReplaceImgflag_CheckedChanged(object sender, EventArgs e)
		{
			if (!this.ReplaceImgflag.Checked)
			{
				this.StrongReplaceImgflag.Checked = false;
			}
		}

		private void ReplaceIntro_CheckedChanged(object sender, EventArgs e)
		{
			if (!this.ReplaceIntro.Checked)
			{
				this.StrongReplaceIntro.Checked = false;
			}
		}

		private void ReplaceSort_CheckedChanged(object sender, EventArgs e)
		{
			if (!this.ReplaceSort.Checked)
			{
				this.OnlyReplaceSort.Checked = false;
			}
		}

		public void Run()
		{
			Console.WriteLine(Localization.Get("开始执行"));
			if (this.tInfo.Timing)
			{
				while (true)
				{
					if (!this.AutoWorker.IsBusy)
					{
						this.AutoWorker.RunWorkerAsync();
						while (this.AutoWorker.IsBusy)
						{
							Application.DoEvents();
							Thread.Sleep(1);
						}
					}
					for (int i = this.tInfo.Interval * 60; i > 0; i--)
					{
						Console.WriteLine(string.Concat(Localization.Get("距离下次启动还有 "), i.ToString(), " sec"));
						Thread.Sleep(1000);
					}
				}
			}
			if (!this.AutoWorker.IsBusy)
			{
				this.AutoWorker.RunWorkerAsync();
				while (this.AutoWorker.IsBusy)
				{
					Application.DoEvents();
					Thread.Sleep(1);
				}
			}
		}

		private void StrongReplaceFullflag_CheckedChanged(object sender, EventArgs e)
		{
			if (this.StrongReplaceFullflag.Checked)
			{
				this.ReplaceFullflag.Checked = true;
			}
		}

		private void StrongReplaceImgflag_CheckedChanged(object sender, EventArgs e)
		{
			if (this.StrongReplaceImgflag.Checked)
			{
				this.ReplaceImgflag.Checked = true;
			}
		}

		private void StrongReplaceIntro_CheckedChanged(object sender, EventArgs e)
		{
			if (this.StrongReplaceIntro.Checked)
			{
				this.ReplaceIntro.Checked = true;
			}
		}

		private void TestWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			ListViewItem[] argument = (ListViewItem[])e.Argument;
			for (int i = 0; i < (int)argument.Length; i++)
			{
				ListViewItem green = argument[i];
				string str = green.Text.ToString();
				int num = int.Parse(green.SubItems[1].Text.ToString());
				HttpClient httpClient = new HttpClient()
				{
					UriString = "http://www.baidu.com/",
					Encoding = Encoding.UTF8,
					Proxy = true,
					ProxyHost = str,
					ProxyPort = num
				};
				HttpClient httpClient1 = httpClient;
				string str1 = "不可用";
				Stopwatch stopwatch = new Stopwatch();
				stopwatch.Start();
				if (httpClient1.GetStringWork() != string.Empty)
				{
					double totalSeconds = stopwatch.Elapsed.TotalSeconds;
					str1 = string.Concat(totalSeconds.ToString("0.000"), "sec");
				}
				base.Invoke(new EventHandler((object argument0, EventArgs argument1) => {
					if (str1 != "不可用")
					{
						this.listView1.Items[green.Index].ForeColor = Color.Green;
					}
					else
					{
						this.listView1.Items[green.Index].ForeColor = Color.Red;
					}
					this.listView1.Items[green.Index].SubItems[4].Text = str1;
					this.listView1.Items[green.Index].SubItems[5].Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
				}));
			}
		}

		private void TestWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
		}

		private void timer_0_Tick(object sender, EventArgs e)
		{
			DateTime now;
			if (!this.AutoWorker.IsBusy)
			{
				if (this.dateTime_0 >= DateTime.Now)
				{
					TimeSpan timeSpan = new TimeSpan(this.dateTime_0.Ticks);
					now = DateTime.Now;
					TimeSpan timeSpan1 = timeSpan.Subtract(new TimeSpan(now.Ticks));
					TimeSpan timeSpan2 = timeSpan1.Duration();
					Label label13 = this.label_13;
					string[] str = new string[] { Localization.Get("距离下次循环开始还有 "), null, null, null, null, null, null, null, null };
					int days = timeSpan2.Days;
					str[1] = days.ToString();
					str[2] = Localization.Get("天");
					days = timeSpan2.Hours;
					str[3] = days.ToString();
					str[4] = Localization.Get("小时");
					days = timeSpan2.Minutes;
					str[5] = days.ToString();
					str[6] = Localization.Get("分钟");
					days = timeSpan2.Seconds;
					str[7] = days.ToString();
					str[8] = Localization.Get("秒");
					label13.Text = string.Concat(str);
				}
				else
				{
					now = DateTime.Now;
					this.dateTime_0 = now.AddMinutes((double)this.tInfo.Interval);
					this.AutoWorker.RunWorkerAsync();
					this.timer_0.Stop();
				}
			}
		}

		private void toolStripMenuItem_0_Click(object sender, EventArgs e)
		{
			if (this.string_0 == "")
			{
				this.toolStripMenuItem_1_Click(sender, e);
			}
			else
			{
				this.method_5();
				ConfigFileManager.SaveConfig(this.string_0, this.tInfo);
			}
		}

		private void toolStripMenuItem_1_Click(object sender, EventArgs e)
		{
			if (this.saveFileDialog_0.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				this.string_0 = this.saveFileDialog_0.FileName;
				FileInfo fileInfo = new FileInfo(this.string_0);
				this.method_5();
				ConfigFileManager.SaveConfig(this.string_0, this.tInfo);
			}
			this.comboBox_4.BeginUpdate();
			string[] strArrays = IO.LoadTasks();
			if ((int)strArrays.Length > 0)
			{
				for (int i = 0; i < (int)strArrays.Length; i++)
				{
					if (!this.comboBox_4.Items.Contains(strArrays[i]))
					{
						this.comboBox_4.Items.Add(strArrays[i]);
						this.comboBox_4.Text = strArrays[i];
					}
				}
			}
			this.comboBox_4.EndUpdate();
		}

		private void toolStripMenuItem_11_Click(object sender, EventArgs e)
		{
			this.listView1.Items.Clear();
		}

		private void toolStripMenuItem_2_Click(object sender, EventArgs e)
		{
			this.method_5();
			ConfigFileManager.SaveConfig("TaskConfig.xml", this.tInfo);
		}

		private void toolStripMenuItem_22_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.listView1.Items.Count; i++)
			{
				this.listView1.Items[i].Checked = false;
			}
		}

		private void toolStripMenuItem_23_Click(object sender, EventArgs e)
		{
			if (!this.LoginWorker.IsBusy)
			{
				this.LoginWorker.RunWorkerAsync();
			}
		}

		private void toolStripMenuItem_25_Click(object sender, EventArgs e)
		{
			if ((this.listView1.CheckedItems.Count == 0 ? false : !this.TestWorker.IsBusy))
			{
				ListViewItem[] listViewItemArray = new ListViewItem[this.listView1.CheckedItems.Count];
				int num = 0;
				foreach (ListViewItem checkedItem in this.listView1.CheckedItems)
				{
					listViewItemArray[num] = checkedItem;
					num++;
				}
				this.TestWorker.RunWorkerAsync(listViewItemArray);
			}
		}

		private void toolStripMenuItem_3_Click(object sender, EventArgs e)
		{
			if (this.openFileDialog_0.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				this.string_0 = this.openFileDialog_0.FileName;
				FileInfo fileInfo = new FileInfo(this.string_0);
				this.tInfo = (TaskConfigInfo)ConfigFileManager.LoadConfig(this.string_0, this.tInfo);
				this.method_4();
				this.rInfo = (RuleConfigInfo)ConfigFileManager.LoadConfig(this.comboBox_0.Text, this.rInfo);
				if (!this.bool_0)
				{
					this.Text = string.Concat(this.rInfo.GetSiteName.Pattern, Localization.Get(" 标准采集模式"));
				}
			}
		}

		private void toolStripMenuItem_6_Click(object sender, EventArgs e)
		{
			string str = "";
			int num = 80;
			if (this.listView1.SelectedItems.Count > 0)
			{
				str = this.listView1.SelectedItems[0].SubItems[0].Text.Trim();
				num = int.Parse(this.listView1.SelectedItems[0].SubItems[1].Text.Trim());
				this.checkBox_19.Checked = true;
				this.textBox_11.Text = num.ToString();
				this.textBox_12.Text = str;
				this.tInfo.Proxy = true;
				this.tInfo.ProxyHost = str;
				this.tInfo.ProxyPort = num;
			}
		}

		private void toolStripMenuItem_8_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.listView1.Items.Count; i++)
			{
				this.listView1.Items[i].Checked = true;
			}
		}

		private void toolStripMenuItem_9_Click(object sender, EventArgs e)
		{
			if ((this.listView1.CheckedItems.Count == 0 ? false : !this.LoginWorker.IsBusy))
			{
				foreach (ListViewItem checkedItem in this.listView1.CheckedItems)
				{
					this.listView1.Items.Remove(checkedItem);
				}
			}
		}
	}
}