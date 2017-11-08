using NovelSpider.Common;
using NovelSpider.Config;
using NovelSpider.Entity;
using NovelSpider.Local;
using NovelSpider.Target;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace NovelSpider
{
	public class CollectReplace : DockContent
	{
		private BackgroundWorker backgroundWorker_0;

		private bool bool_0;

		private Button button_0;

		private Button button_1;

		private Button button_2;

		private ComboBox comboBox_0;

		private DateTime dateTime_0;

		private IContainer icontainer_0;

		public RuleConfigInfo rInfo;

		private string string_0;

		private string string_1;

		private string string_2;

		private System.Windows.Forms.Timer timer_0;

		private IContainer components;

		private TabPage tabPage1;

		private GroupBox groupBox1;

		private RichTextBox richTextBox_0;

		private GroupBox groupBox_7;

		private CheckBox checkBox_12;

		private Label label_6;

		private TextBox textBox_12;

		private Label label_7;

		private Label label_8;

		private TextBox textBox_13;

		private TextBox textBox_14;

		private TextBox textBox_15;

		private TextBox textBox_16;

		private TabPage tabPage_4;

		private GroupBox groupBox2;

		private CheckBox checkBox_13;

		private Label label_22;

		private ProgressBar progressBar_1;

		private Label label_21;

		private ProgressBar progressBar_0;

		private GroupBox groupBox_9;

		private Label label9;

		private Label label10;

		private Label label7;

		private Label label8;

		private Label label5;

		private Label label6;

		private Label label_15;

		private Label label_16;

		private Label label_17;

		private Label label_18;

		private Label label_19;

		private Label label_20;

		private GroupBox groupBox_8;

		private Label label_9;

		private Label label_10;

		private Label label_11;

		private Label label_12;

		private NumericUpDown numericUpDown_3;

		private Label label_13;

		private NumericUpDown numericUpDown_4;

		private Label label_14;

		private NumericUpDown numericUpDown_5;

		private TabPage tabPage_2;

		private GroupBox groupBox_4;

		private TextBox FilterVolume;

		private GroupBox groupBox_3;

		private TextBox FilterNovel;

		private ComboBox comboBox_2;

		private GroupBox groupBox_2;

		private Label label3;

		private NumericUpDown DonotCollectChapterNum;

		private Label label4;

		private Label label_2;

		private NumericUpDown numericUpDown_1;

		private Label label_3;

		private Label label_4;

		private Label label_5;

		private NumericUpDown numericUpDown_2;

		private TabPage tabPage_1;

		private GroupBox groupBox_1;

		private CheckBox checkBox_6;

		private NumericUpDown numericUpDown_0;

		private CheckBox checkBox_5;

		private Label label_1;

		private GroupBox groupBox_0;

		private DateTimePicker dateTimePicker_1;

		private Label label_25;

		private CheckBox checkBox_14;

		private DateTimePicker dateTimePicker_0;

		private TabControl tabControl_0;

		private CheckBox checkBox_22;

		private CheckBox checkBox_21;

		private CheckBox checkBox_17;

		private CheckBox checkBox_16;

		private CheckBox DelForTxt;

		private CheckBox checkBox_8;

		private CheckBox checkBox_9;

		private CheckBox checkBox_4;

		private Label label1;

		private ComboBox comboBox1;

		private Label label_32;

		private ComboBox comboBox_7;

		private Label label_27;

		private ComboBox comboBox_5;

		private Label label2;

		private ComboBox comboBox_1;

		public ReplaceConfigInfo tInfo;

		private GroupBox groupBox3;

		private Label label11;

		private Label label12;

		private NumericUpDown numericUpDown1;

		private CheckBox ReplaceChapterNameOn;

		private CheckBox checkBox_0;

		private CheckBox DelForTxtHtml;

		public TaskConfigInfo uInfo;

		public CollectReplace()
		{
			Class19.Q77LubhzKM3NS();
			this.dateTime_0 = DateTime.Now;
			this.rInfo = new RuleConfigInfo();
			this.string_0 = "";
			this.string_1 = "";
			this.string_2 = "";
			this.tInfo = new ReplaceConfigInfo();
			this.uInfo = new TaskConfigInfo();
			this.InitializeComponent();
		}

		private void backgroundWorker_0_DoWork(object sender, DoWorkEventArgs e)
		{
			this.backgroundWorker_0.ReportProgress(2, Localization.Get("获得错误日志小说列表"));
			int selectedIndex = 0;
			string str = "";
			base.Invoke(new EventHandler((object argument0, EventArgs argument1) => {
				str = this.comboBox_0.SelectedItem.ToString();
				selectedIndex = this.comboBox_0.SelectedIndex;
			}));
			if (selectedIndex != 0)
			{
				this.method_2(str, false);
			}
			else
			{
				string[] strArrays = IO.LoadLogs();
				if ((int)strArrays.Length > 0)
				{
					for (int i = 0; i < (int)strArrays.Length; i++)
					{
						if (this.backgroundWorker_0.CancellationPending)
						{
							if (this.backgroundWorker_0.CancellationPending)
							{
								e.Cancel = true;
							}
							return;
						}
						if (strArrays[i].EndsWith("db3"))
						{
							this.method_2(strArrays[i], false);
						}
					}
				}
			}
			if (this.backgroundWorker_0.CancellationPending)
			{
				e.Cancel = true;
			}
		}

		private void backgroundWorker_0_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			int progressPercentage;
			string str;
			string[] strArrays;
			string str1;
			char[] chrArray;
			if (Configs.CmdModel)
			{
				progressPercentage = e.ProgressPercentage;
				switch (progressPercentage)
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
			progressPercentage = e.ProgressPercentage;
			switch (progressPercentage)
			{
				case 0:
				{
					this.label_17.Text = e.UserState.ToString();
					return;
				}
				case 1:
				{
					this.label_16.Text = e.UserState.ToString();
					return;
				}
				case 2:
				{
					this.label_15.Text = e.UserState.ToString();
					return;
				}
				case 3:
				{
					if (this.tInfo.NoPBar)
					{
						return;
					}
					int num = Convert.ToInt32(e.UserState);
					if (num > this.progressBar_1.Maximum || num < this.progressBar_1.Minimum)
					{
						return;
					}
					this.progressBar_1.Value = Convert.ToInt32(e.UserState);
					return;
				}
				case 4:
				{
					if (this.tInfo.NoPBar)
					{
						return;
					}
					int num1 = Convert.ToInt32(e.UserState);
					if (num1 > this.progressBar_0.Maximum || num1 < this.progressBar_0.Minimum)
					{
						return;
					}
					this.progressBar_0.Value = Convert.ToInt32(e.UserState);
					return;
				}
				case 5:
				{
					if (this.tInfo.NoPBar)
					{
						return;
					}
					this.progressBar_1.Maximum = Convert.ToInt32(e.UserState);
					return;
				}
				case 6:
				{
					if (this.tInfo.NoPBar)
					{
						return;
					}
					this.progressBar_0.Maximum = Convert.ToInt32(e.UserState);
					return;
				}
				case 7:
				{
					return;
				}
				case 8:
				{
					if (this.tInfo.Log)
					{
						this.richTextBox_0.AppendText(string.Concat(e.UserState.ToString(), "\n"));
						this.richTextBox_0.Focus();
						this.richTextBox_0.Select(this.richTextBox_0.TextLength, 0);
						this.richTextBox_0.ScrollToCaret();
					}
					string str2 = e.UserState.ToString();
					chrArray = new char[] { '|' };
					string[] strArrays1 = str2.Split(chrArray);
					if ((int)strArrays1.Length != 5)
					{
						return;
					}
					str = string.Concat("Data Source=", strArrays1[1].Trim());
					strArrays = new string[] { "update [TaskLog] set ERROROK=1,ERRORTEXT='已修复' Where GETID='", strArrays1[3].Trim(), "' And RULEFILE='", strArrays1[2].Trim(), "'" };
					str1 = string.Concat(strArrays);
					SQLiteHelper.ExecuteNonQuery(str, str1, new IDataParameter[0]);
					return;
				}
				case 9:
				{
					if (this.tInfo.Log)
					{
						this.richTextBox_0.AppendText(string.Concat(e.UserState.ToString(), "\n"));
						this.richTextBox_0.Focus();
						this.richTextBox_0.Select(this.richTextBox_0.TextLength, 0);
						this.richTextBox_0.ScrollToCaret();
					}
					string str3 = e.UserState.ToString();
					chrArray = new char[] { '|' };
					string[] strArrays2 = str3.Split(chrArray);
					if ((int)strArrays2.Length != 5)
					{
						return;
					}
					str = string.Concat("Data Source=", strArrays2[1].Trim());
					strArrays = new string[] { "update [TaskLog] set ERRORNUM=ERRORNUM+1,ERRORTEXT='未修复' Where GETID='", strArrays2[3].Trim(), "' And RULEFILE='", strArrays2[2].Trim(), "'" };
					str1 = string.Concat(strArrays);
					SQLiteHelper.ExecuteNonQuery(str, str1, new IDataParameter[0]);
					return;
				}
				default:
				{
					switch (progressPercentage)
					{
						case 101:
						{
							this.label7.Text = e.UserState.ToString();
							return;
						}
						case 102:
						{
							this.label5.Text = e.UserState.ToString();
							return;
						}
						case 103:
						{
							this.label9.Text = e.UserState.ToString();
							return;
						}
						default:
						{
							return;
						}
					}
					break;
				}
			}
		}

		private void backgroundWorker_0_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
					this.button_1.Enabled = true;
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
					this.button_1.Enabled = true;
					this.button_0.Enabled = false;
				}
				else
				{
					this.label_15.Text = string.Concat(Localization.Get("错误提示："), e.Error.Message);
					this.timer_0.Start();
					now = DateTime.Now;
					this.dateTime_0 = now.AddMinutes((double)this.tInfo.Interval);
				}
			}
			else if (e.Cancelled)
			{
				this.label_15.Text = Localization.Get("操作取消");
				this.button_1.Enabled = true;
				this.button_0.Enabled = false;
			}
			else if (!this.tInfo.Timing)
			{
				this.label_15.Text = Localization.Get("操作完成");
				this.button_1.Enabled = true;
				this.button_0.Enabled = false;
			}
			else
			{
				this.timer_0.Start();
				now = DateTime.Now;
				this.dateTime_0 = now.AddMinutes((double)this.tInfo.Interval);
			}
			Configs.TaskNovelInfo[this.string_2.ToString()] = null;
		}

		private void button_0_Click(object sender, EventArgs e)
		{
			this.button_0.Enabled = false;
			if (!this.backgroundWorker_0.IsBusy)
			{
				if (this.timer_0.Enabled)
				{
					this.timer_0.Stop();
					this.label_15.Text = Localization.Get("操作取消");
				}
				this.button_1.Enabled = true;
			}
			else
			{
				this.backgroundWorker_0.CancelAsync();
			}
		}

		private void button_1_Click(object sender, EventArgs e)
		{
			if (Configs.BaseConfig.LicenseOk)
			{
				this.uInfo.CheckVolume = this.tInfo.CheckVolume;
				this.uInfo.ProhibitionVolume = this.tInfo.ProhibitionVolume;
				this.uInfo.Hidebook = this.tInfo.Hidebook;
				this.method_1();
				this.tInfo.ID = this.string_2;
				this.button_1.Enabled = false;
				this.button_0.Enabled = true;
				this.tabControl_0.SelectedIndex = this.tabControl_0.TabCount - 2;
				DateTime now = DateTime.Now;
				this.dateTime_0 = now.AddMinutes((double)this.tInfo.Interval);
				if (!this.backgroundWorker_0.IsBusy)
				{
					this.backgroundWorker_0.RunWorkerAsync();
				}
			}
			else
			{
				MessageBox.Show(Localization.Get("授权码无效，请删除或清空根目录下xxxxxxx.ini文件"));
			}
		}

		private void button_2_Click(object sender, EventArgs e)
		{
			this.method_1();
			ConfigFileManager.SaveConfig("ReplaceConfig.xml", this.tInfo);
		}

		private void CollectReplace_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!this.backgroundWorker_0.IsBusy)
			{
				Configs.TaskNovelInfo.Remove(this.string_2);
			}
			else
			{
				this.backgroundWorker_0.CancelAsync();
				e.Cancel = true;
				MessageBox.Show(Localization.Get("检查到采集进程正在运行，现在正在自动停止采集进程\n\n请在采集进程停止后关闭窗口！"), Localization.Get("信息提示"));
			}
		}

		private void CollectReplace_Load(object sender, EventArgs e)
		{
			Guid guid = Guid.NewGuid();
			this.string_2 = guid.ToString().ToUpper();
			Configs.TaskNovelInfo.Add(this.string_2, null);
			CollectReplace collectReplace = this;
			string str = string.Concat(collectReplace.Text, " ", this.string_2);
			collectReplace.Text = str;
			this.tInfo = (ReplaceConfigInfo)ConfigFileManager.LoadConfig("ReplaceConfig.xml", this.tInfo);
			this.comboBox_0.BeginUpdate();
			this.comboBox_0.Items.Add(Localization.Get("循环执行所有采集错误日志"));
			string[] strArrays = IO.LoadLogs();
			if ((int)strArrays.Length > 0)
			{
				for (int i = 0; i < (int)strArrays.Length; i++)
				{
					if (strArrays[i].EndsWith("db3"))
					{
						this.comboBox_0.Items.Add(strArrays[i]);
					}
				}
			}
			this.comboBox_0.EndUpdate();
			this.comboBox_0.SelectedIndex = 0;
			this.method_0();
		}

		private void comboBox_0_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!this.bool_0)
			{
				if (this.comboBox_0.SelectedIndex != 0)
				{
					this.Text = string.Concat(this.comboBox_0.SelectedItem.ToString(), Localization.Get(" 超级修复模式"));
				}
				else
				{
					this.Text = Localization.Get("多日志 超级修复模式");
				}
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

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(CollectReplace));
			this.comboBox_0 = new ComboBox();
			this.button_0 = new Button();
			this.button_1 = new Button();
			this.button_2 = new Button();
			this.backgroundWorker_0 = new BackgroundWorker();
			this.timer_0 = new System.Windows.Forms.Timer(this.components);
			this.tabPage1 = new TabPage();
			this.groupBox1 = new GroupBox();
			this.richTextBox_0 = new RichTextBox();
			this.groupBox_7 = new GroupBox();
			this.checkBox_12 = new CheckBox();
			this.label_6 = new Label();
			this.textBox_12 = new TextBox();
			this.label_7 = new Label();
			this.label_8 = new Label();
			this.textBox_13 = new TextBox();
			this.textBox_14 = new TextBox();
			this.textBox_15 = new TextBox();
			this.textBox_16 = new TextBox();
			this.tabPage_4 = new TabPage();
			this.groupBox2 = new GroupBox();
			this.checkBox_13 = new CheckBox();
			this.label_22 = new Label();
			this.progressBar_1 = new ProgressBar();
			this.label_21 = new Label();
			this.progressBar_0 = new ProgressBar();
			this.groupBox_9 = new GroupBox();
			this.label9 = new Label();
			this.label10 = new Label();
			this.label7 = new Label();
			this.label8 = new Label();
			this.label5 = new Label();
			this.label6 = new Label();
			this.label_15 = new Label();
			this.label_16 = new Label();
			this.label_17 = new Label();
			this.label_18 = new Label();
			this.label_19 = new Label();
			this.label_20 = new Label();
			this.groupBox_8 = new GroupBox();
			this.label_9 = new Label();
			this.label_10 = new Label();
			this.label_11 = new Label();
			this.label_12 = new Label();
			this.numericUpDown_3 = new NumericUpDown();
			this.label_13 = new Label();
			this.numericUpDown_4 = new NumericUpDown();
			this.label_14 = new Label();
			this.numericUpDown_5 = new NumericUpDown();
			this.tabPage_2 = new TabPage();
			this.groupBox_4 = new GroupBox();
			this.FilterVolume = new TextBox();
			this.groupBox_3 = new GroupBox();
			this.FilterNovel = new TextBox();
			this.comboBox_2 = new ComboBox();
			this.groupBox_2 = new GroupBox();
			this.label3 = new Label();
			this.DonotCollectChapterNum = new NumericUpDown();
			this.label4 = new Label();
			this.label_2 = new Label();
			this.numericUpDown_1 = new NumericUpDown();
			this.label_3 = new Label();
			this.label_4 = new Label();
			this.label_5 = new Label();
			this.numericUpDown_2 = new NumericUpDown();
			this.tabPage_1 = new TabPage();
			this.groupBox3 = new GroupBox();
			this.checkBox_0 = new CheckBox();
			this.ReplaceChapterNameOn = new CheckBox();
			this.label11 = new Label();
			this.label12 = new Label();
			this.numericUpDown1 = new NumericUpDown();
			this.groupBox_1 = new GroupBox();
			this.label1 = new Label();
			this.comboBox1 = new ComboBox();
			this.label_32 = new Label();
			this.comboBox_7 = new ComboBox();
			this.label_27 = new Label();
			this.comboBox_5 = new ComboBox();
			this.label2 = new Label();
			this.comboBox_1 = new ComboBox();
			this.groupBox_0 = new GroupBox();
			this.checkBox_22 = new CheckBox();
			this.checkBox_21 = new CheckBox();
			this.checkBox_17 = new CheckBox();
			this.checkBox_16 = new CheckBox();
			this.DelForTxt = new CheckBox();
			this.checkBox_8 = new CheckBox();
			this.checkBox_9 = new CheckBox();
			this.checkBox_4 = new CheckBox();
			this.dateTimePicker_1 = new DateTimePicker();
			this.label_25 = new Label();
			this.checkBox_14 = new CheckBox();
			this.dateTimePicker_0 = new DateTimePicker();
			this.checkBox_5 = new CheckBox();
			this.label_1 = new Label();
			this.checkBox_6 = new CheckBox();
			this.numericUpDown_0 = new NumericUpDown();
			this.tabControl_0 = new TabControl();
			this.DelForTxtHtml = new CheckBox();
			this.tabPage1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox_7.SuspendLayout();
			this.tabPage_4.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox_9.SuspendLayout();
			this.groupBox_8.SuspendLayout();
			((ISupportInitialize)this.numericUpDown_3).BeginInit();
			((ISupportInitialize)this.numericUpDown_4).BeginInit();
			((ISupportInitialize)this.numericUpDown_5).BeginInit();
			this.tabPage_2.SuspendLayout();
			this.groupBox_4.SuspendLayout();
			this.groupBox_3.SuspendLayout();
			this.groupBox_2.SuspendLayout();
			((ISupportInitialize)this.DonotCollectChapterNum).BeginInit();
			((ISupportInitialize)this.numericUpDown_1).BeginInit();
			((ISupportInitialize)this.numericUpDown_2).BeginInit();
			this.tabPage_1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((ISupportInitialize)this.numericUpDown1).BeginInit();
			this.groupBox_1.SuspendLayout();
			this.groupBox_0.SuspendLayout();
			((ISupportInitialize)this.numericUpDown_0).BeginInit();
			this.tabControl_0.SuspendLayout();
			base.SuspendLayout();
			this.comboBox_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			this.comboBox_0.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_0.FormattingEnabled = true;
			this.comboBox_0.Location = new Point(12, 376);
			this.comboBox_0.Name = "comboBox_0";
			this.comboBox_0.Size = new System.Drawing.Size(261, 20);
			this.comboBox_0.TabIndex = 31;
			this.comboBox_0.SelectedIndexChanged += new EventHandler(this.comboBox_0_SelectedIndexChanged);
			this.button_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			this.button_0.Enabled = false;
			this.button_0.Location = new Point(666, 374);
			this.button_0.Name = "button_0";
			this.button_0.Size = new System.Drawing.Size(75, 23);
			this.button_0.TabIndex = 47;
			this.button_0.Text = Localization.Get("停止");
			this.button_0.UseVisualStyleBackColor = true;
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.button_1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			this.button_1.Location = new Point(585, 374);
			this.button_1.Name = "button_1";
			this.button_1.Size = new System.Drawing.Size(75, 23);
			this.button_1.TabIndex = 46;
			this.button_1.Text = Localization.Get("开始");
			this.button_1.UseVisualStyleBackColor = true;
			this.button_1.Click += new EventHandler(this.button_1_Click);
			this.button_2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			this.button_2.Location = new Point(747, 374);
			this.button_2.Name = "button_2";
			this.button_2.Size = new System.Drawing.Size(75, 23);
			this.button_2.TabIndex = 49;
			this.button_2.Text = Localization.Get("保存设置");
			this.button_2.UseVisualStyleBackColor = true;
			this.button_2.Click += new EventHandler(this.button_2_Click);
			this.backgroundWorker_0.WorkerReportsProgress = true;
			this.backgroundWorker_0.WorkerSupportsCancellation = true;
			this.backgroundWorker_0.DoWork += new DoWorkEventHandler(this.backgroundWorker_0_DoWork);
			this.backgroundWorker_0.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker_0_RunWorkerCompleted);
			this.backgroundWorker_0.ProgressChanged += new ProgressChangedEventHandler(this.backgroundWorker_0_ProgressChanged);
			this.timer_0.Interval = 1000;
			this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
			this.tabPage1.Controls.Add(this.groupBox1);
			this.tabPage1.Controls.Add(this.groupBox_7);
			this.tabPage1.Location = new Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(802, 330);
			this.tabPage1.TabIndex = 5;
			this.tabPage1.Text = Localization.Get("代理/记录");
			this.tabPage1.UseVisualStyleBackColor = true;
			this.groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.groupBox1.Controls.Add(this.richTextBox_0);
			this.groupBox1.Location = new Point(6, 116);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(790, 204);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = Localization.Get("修复记录");
			this.richTextBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.richTextBox_0.BackColor = SystemColors.Window;
			this.richTextBox_0.BorderStyle = BorderStyle.None;
			this.richTextBox_0.Location = new Point(6, 20);
			this.richTextBox_0.Name = "richTextBox_0";
			this.richTextBox_0.ScrollBars = RichTextBoxScrollBars.ForcedVertical;
			this.richTextBox_0.Size = new System.Drawing.Size(778, 176);
			this.richTextBox_0.TabIndex = 18;
			this.richTextBox_0.Text = "";
			this.groupBox_7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.groupBox_7.Controls.Add(this.checkBox_12);
			this.groupBox_7.Controls.Add(this.label_6);
			this.groupBox_7.Controls.Add(this.textBox_12);
			this.groupBox_7.Controls.Add(this.label_7);
			this.groupBox_7.Controls.Add(this.label_8);
			this.groupBox_7.Controls.Add(this.textBox_13);
			this.groupBox_7.Controls.Add(this.textBox_14);
			this.groupBox_7.Controls.Add(this.textBox_15);
			this.groupBox_7.Controls.Add(this.textBox_16);
			this.groupBox_7.Location = new Point(6, 6);
			this.groupBox_7.Name = "groupBox_7";
			this.groupBox_7.Size = new System.Drawing.Size(790, 104);
			this.groupBox_7.TabIndex = 5;
			this.groupBox_7.TabStop = false;
			this.groupBox_7.Text = Localization.Get("代理IP");
			this.checkBox_12.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.checkBox_12.AutoSize = true;
			this.checkBox_12.Location = new Point(666, 50);
			this.checkBox_12.Name = "checkBox_12";
			this.checkBox_12.Size = new System.Drawing.Size(96, 16);
			this.checkBox_12.TabIndex = 20;
			this.checkBox_12.Text = Localization.Get("启用代理功能");
			this.checkBox_12.UseVisualStyleBackColor = true;
			this.label_6.AutoSize = true;
			this.label_6.Location = new Point(30, 50);
			this.label_6.Name = "label_6";
			this.label_6.Size = new System.Drawing.Size(53, 12);
			this.label_6.TabIndex = 19;
			this.label_6.Text = Localization.Get("代理域：");
			this.textBox_12.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.textBox_12.Location = new Point(89, 47);
			this.textBox_12.Name = "textBox_12";
			this.textBox_12.Size = new System.Drawing.Size(571, 21);
			this.textBox_12.TabIndex = 17;
			this.label_7.AutoSize = true;
			this.label_7.Location = new Point(18, 77);
			this.label_7.Name = "label_7";
			this.label_7.Size = new System.Drawing.Size(65, 12);
			this.label_7.TabIndex = 16;
			this.label_7.Text = Localization.Get("帐户密码：");
			this.label_8.AutoSize = true;
			this.label_8.Location = new Point(18, 23);
			this.label_8.Name = "label_8";
			this.label_8.Size = new System.Drawing.Size(65, 12);
			this.label_8.TabIndex = 15;
			this.label_8.Text = Localization.Get("ＩＰ端口：");
			this.textBox_13.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.textBox_13.Location = new Point(666, 74);
			this.textBox_13.Name = "textBox_13";
			this.textBox_13.Size = new System.Drawing.Size(118, 21);
			this.textBox_13.TabIndex = 12;
			this.textBox_14.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.textBox_14.Location = new Point(89, 74);
			this.textBox_14.Name = "textBox_14";
			this.textBox_14.Size = new System.Drawing.Size(571, 21);
			this.textBox_14.TabIndex = 11;
			this.textBox_15.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.textBox_15.Location = new Point(666, 20);
			this.textBox_15.Name = "textBox_15";
			this.textBox_15.Size = new System.Drawing.Size(118, 21);
			this.textBox_15.TabIndex = 10;
			this.textBox_15.Text = "80";
			this.textBox_16.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.textBox_16.Location = new Point(89, 20);
			this.textBox_16.Name = "textBox_16";
			this.textBox_16.Size = new System.Drawing.Size(571, 21);
			this.textBox_16.TabIndex = 9;
			this.tabPage_4.Controls.Add(this.groupBox2);
			this.tabPage_4.Controls.Add(this.groupBox_9);
			this.tabPage_4.Controls.Add(this.groupBox_8);
			this.tabPage_4.Location = new Point(4, 22);
			this.tabPage_4.Name = "tabPage_4";
			this.tabPage_4.Size = new System.Drawing.Size(802, 330);
			this.tabPage_4.TabIndex = 4;
			this.tabPage_4.Text = Localization.Get("修复进度");
			this.tabPage_4.UseVisualStyleBackColor = true;
			this.groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.groupBox2.Controls.Add(this.checkBox_13);
			this.groupBox2.Controls.Add(this.label_22);
			this.groupBox2.Controls.Add(this.progressBar_1);
			this.groupBox2.Controls.Add(this.label_21);
			this.groupBox2.Controls.Add(this.progressBar_0);
			this.groupBox2.Location = new Point(6, 8);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(625, 100);
			this.groupBox2.TabIndex = 53;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = Localization.Get("修复进度");
			this.checkBox_13.AutoSize = true;
			this.checkBox_13.Location = new Point(83, 72);
			this.checkBox_13.Name = "checkBox_13";
			this.checkBox_13.Size = new System.Drawing.Size(96, 16);
			this.checkBox_13.TabIndex = 17;
			this.checkBox_13.Text = Localization.Get("不绘图进度条");
			this.checkBox_13.UseVisualStyleBackColor = true;
			this.label_22.AutoSize = true;
			this.label_22.Location = new Point(6, 23);
			this.label_22.Name = "label_22";
			this.label_22.Size = new System.Drawing.Size(77, 12);
			this.label_22.TabIndex = 8;
			this.label_22.Text = Localization.Get("修复总进度：");
			this.progressBar_1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.progressBar_1.Location = new Point(83, 19);
			this.progressBar_1.Name = "progressBar_1";
			this.progressBar_1.Size = new System.Drawing.Size(536, 18);
			this.progressBar_1.TabIndex = 7;
			this.label_21.AutoSize = true;
			this.label_21.Location = new Point(6, 48);
			this.label_21.Name = "label_21";
			this.label_21.Size = new System.Drawing.Size(77, 12);
			this.label_21.TabIndex = 9;
			this.label_21.Text = Localization.Get("修复分进度：");
			this.progressBar_0.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.progressBar_0.Location = new Point(83, 45);
			this.progressBar_0.Name = "progressBar_0";
			this.progressBar_0.Size = new System.Drawing.Size(536, 18);
			this.progressBar_0.TabIndex = 10;
			this.groupBox_9.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.groupBox_9.Controls.Add(this.label9);
			this.groupBox_9.Controls.Add(this.label10);
			this.groupBox_9.Controls.Add(this.label7);
			this.groupBox_9.Controls.Add(this.label8);
			this.groupBox_9.Controls.Add(this.label5);
			this.groupBox_9.Controls.Add(this.label6);
			this.groupBox_9.Controls.Add(this.label_15);
			this.groupBox_9.Controls.Add(this.label_16);
			this.groupBox_9.Controls.Add(this.label_17);
			this.groupBox_9.Controls.Add(this.label_18);
			this.groupBox_9.Controls.Add(this.label_19);
			this.groupBox_9.Controls.Add(this.label_20);
			this.groupBox_9.Location = new Point(6, 116);
			this.groupBox_9.Name = "groupBox_9";
			this.groupBox_9.Size = new System.Drawing.Size(793, 207);
			this.groupBox_9.TabIndex = 52;
			this.groupBox_9.TabStop = false;
			this.groupBox_9.Text = Localization.Get("操作详情");
			this.label9.AutoSize = true;
			this.label9.Location = new Point(81, 78);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(17, 12);
			this.label9.TabIndex = 22;
			this.label9.Text = "--";
			this.label10.AutoSize = true;
			this.label10.Location = new Point(18, 78);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(65, 12);
			this.label10.TabIndex = 21;
			this.label10.Text = Localization.Get("使用规则：");
			this.label7.AutoSize = true;
			this.label7.Location = new Point(81, 28);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(17, 12);
			this.label7.TabIndex = 20;
			this.label7.Text = "--";
			this.label8.AutoSize = true;
			this.label8.Location = new Point(18, 28);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(65, 12);
			this.label8.TabIndex = 19;
			this.label8.Text = Localization.Get("当前日志：");
			this.label5.AutoSize = true;
			this.label5.Location = new Point(81, 52);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(17, 12);
			this.label5.TabIndex = 18;
			this.label5.Text = "--";
			this.label6.AutoSize = true;
			this.label6.Location = new Point(6, 52);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(77, 12);
			this.label6.TabIndex = 17;
			this.label6.Text = Localization.Get("错误总数量：");
			this.label_15.AutoSize = true;
			this.label_15.Location = new Point(81, 156);
			this.label_15.Name = "label_15";
			this.label_15.Size = new System.Drawing.Size(17, 12);
			this.label_15.TabIndex = 16;
			this.label_15.Text = "--";
			this.label_16.AutoSize = true;
			this.label_16.Location = new Point(81, 130);
			this.label_16.Name = "label_16";
			this.label_16.Size = new System.Drawing.Size(17, 12);
			this.label_16.TabIndex = 15;
			this.label_16.Text = "--";
			this.label_17.AutoSize = true;
			this.label_17.Location = new Point(81, 105);
			this.label_17.Name = "label_17";
			this.label_17.Size = new System.Drawing.Size(17, 12);
			this.label_17.TabIndex = 14;
			this.label_17.Text = "--";
			this.label_18.AutoSize = true;
			this.label_18.Location = new Point(18, 156);
			this.label_18.Name = "label_18";
			this.label_18.Size = new System.Drawing.Size(65, 12);
			this.label_18.TabIndex = 13;
			this.label_18.Text = Localization.Get("当前动作：");
			this.label_19.AutoSize = true;
			this.label_19.Location = new Point(18, 130);
			this.label_19.Name = "label_19";
			this.label_19.Size = new System.Drawing.Size(65, 12);
			this.label_19.TabIndex = 12;
			this.label_19.Text = Localization.Get("当前章节：");
			this.label_20.AutoSize = true;
			this.label_20.Location = new Point(18, 105);
			this.label_20.Name = "label_20";
			this.label_20.Size = new System.Drawing.Size(65, 12);
			this.label_20.TabIndex = 11;
			this.label_20.Text = Localization.Get("当前小说：");
			this.groupBox_8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.groupBox_8.Controls.Add(this.label_9);
			this.groupBox_8.Controls.Add(this.label_10);
			this.groupBox_8.Controls.Add(this.label_11);
			this.groupBox_8.Controls.Add(this.label_12);
			this.groupBox_8.Controls.Add(this.numericUpDown_3);
			this.groupBox_8.Controls.Add(this.label_13);
			this.groupBox_8.Controls.Add(this.numericUpDown_4);
			this.groupBox_8.Controls.Add(this.label_14);
			this.groupBox_8.Controls.Add(this.numericUpDown_5);
			this.groupBox_8.Location = new Point(637, 6);
			this.groupBox_8.Name = "groupBox_8";
			this.groupBox_8.Size = new System.Drawing.Size(162, 104);
			this.groupBox_8.TabIndex = 6;
			this.groupBox_8.TabStop = false;
			this.groupBox_8.Text = Localization.Get("延时等待");
			this.label_9.AutoSize = true;
			this.label_9.Location = new Point(124, 77);
			this.label_9.Name = "label_9";
			this.label_9.Size = new System.Drawing.Size(29, 12);
			this.label_9.TabIndex = 28;
			this.label_9.Text = "ms";
			this.label_10.AutoSize = true;
			this.label_10.Location = new Point(124, 50);
			this.label_10.Name = "label_10";
			this.label_10.Size = new System.Drawing.Size(29, 12);
			this.label_10.TabIndex = 27;
			this.label_10.Text = "ms";
			this.label_11.AutoSize = true;
			this.label_11.Location = new Point(124, 23);
			this.label_11.Name = "label_11";
			this.label_11.Size = new System.Drawing.Size(29, 12);
			this.label_11.TabIndex = 26;
			this.label_11.Text = "ms";
			this.label_12.AutoSize = true;
			this.label_12.Location = new Point(12, 77);
			this.label_12.Name = "label_12";
			this.label_12.Size = new System.Drawing.Size(53, 12);
			this.label_12.TabIndex = 25;
			this.label_12.Text = Localization.Get("章节页：");
			this.numericUpDown_3.Location = new Point(71, 74);
			NumericUpDown numericUpDown3 = this.numericUpDown_3;
			int[] numArray = new int[] { 9999, 0, 0, 0 };
			numericUpDown3.Maximum = new decimal(numArray);
			this.numericUpDown_3.Name = "numericUpDown_3";
			this.numericUpDown_3.Size = new System.Drawing.Size(46, 21);
			this.numericUpDown_3.TabIndex = 24;
			this.label_13.AutoSize = true;
			this.label_13.Location = new Point(12, 50);
			this.label_13.Name = "label_13";
			this.label_13.Size = new System.Drawing.Size(53, 12);
			this.label_13.TabIndex = 23;
			this.label_13.Text = "目录页：";
			this.numericUpDown_4.Location = new Point(71, 47);
			NumericUpDown numericUpDown4 = this.numericUpDown_4;
			numArray = new int[] { 9999, 0, 0, 0 };
			numericUpDown4.Maximum = new decimal(numArray);
			this.numericUpDown_4.Name = "numericUpDown_4";
			this.numericUpDown_4.Size = new System.Drawing.Size(46, 21);
			this.numericUpDown_4.TabIndex = 22;
			this.label_14.AutoSize = true;
			this.label_14.Location = new Point(12, 23);
			this.label_14.Name = "label_14";
			this.label_14.Size = new System.Drawing.Size(53, 12);
			this.label_14.TabIndex = 21;
			this.label_14.Text = Localization.Get("信息页：");
			this.numericUpDown_5.Location = new Point(71, 20);
			NumericUpDown numericUpDown5 = this.numericUpDown_5;
			numArray = new int[] { 9999, 0, 0, 0 };
			numericUpDown5.Maximum = new decimal(numArray);
			this.numericUpDown_5.Name = "numericUpDown_5";
			this.numericUpDown_5.Size = new System.Drawing.Size(46, 21);
			this.numericUpDown_5.TabIndex = 0;
			this.tabPage_2.Controls.Add(this.groupBox_4);
			this.tabPage_2.Controls.Add(this.groupBox_3);
			this.tabPage_2.Controls.Add(this.groupBox_2);
			this.tabPage_2.Location = new Point(4, 22);
			this.tabPage_2.Name = "tabPage_2";
			this.tabPage_2.Size = new System.Drawing.Size(802, 330);
			this.tabPage_2.TabIndex = 2;
			this.tabPage_2.Text = Localization.Get("过滤设置");
			this.tabPage_2.UseVisualStyleBackColor = true;
			this.groupBox_4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.groupBox_4.Controls.Add(this.FilterVolume);
			this.groupBox_4.Location = new Point(199, 111);
			this.groupBox_4.Name = "groupBox_4";
			this.groupBox_4.Size = new System.Drawing.Size(597, 212);
			this.groupBox_4.TabIndex = 4;
			this.groupBox_4.TabStop = false;
			this.groupBox_4.Text = Localization.Get("过滤分卷");
			this.FilterVolume.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.FilterVolume.Location = new Point(3, 20);
			this.FilterVolume.Multiline = true;
			this.FilterVolume.Name = "FilterVolume";
			this.FilterVolume.ScrollBars = ScrollBars.Vertical;
			this.FilterVolume.Size = new System.Drawing.Size(588, 186);
			this.FilterVolume.TabIndex = 0;
			this.groupBox_3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
			this.groupBox_3.Controls.Add(this.FilterNovel);
			this.groupBox_3.Controls.Add(this.comboBox_2);
			this.groupBox_3.Location = new Point(6, 111);
			this.groupBox_3.Name = "groupBox_3";
			this.groupBox_3.Size = new System.Drawing.Size(190, 212);
			this.groupBox_3.TabIndex = 3;
			this.groupBox_3.TabStop = false;
			this.groupBox_3.Text = Localization.Get("限制小说");
			this.FilterNovel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.FilterNovel.Location = new Point(8, 46);
			this.FilterNovel.Multiline = true;
			this.FilterNovel.Name = "FilterNovel";
			this.FilterNovel.ScrollBars = ScrollBars.Vertical;
			this.FilterNovel.Size = new System.Drawing.Size(176, 160);
			this.FilterNovel.TabIndex = 8;
			this.comboBox_2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.comboBox_2.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_2.FormattingEnabled = true;
			ComboBox.ObjectCollection items = this.comboBox_2.Items;
			object[] objArray = new object[] { Localization.Get("不限制"), Localization.Get("不采集限制小说"), Localization.Get("只采集限制小说") };
			items.AddRange(objArray);
			this.comboBox_2.Location = new Point(8, 20);
			this.comboBox_2.Name = "comboBox_2";
			this.comboBox_2.Size = new System.Drawing.Size(176, 20);
			this.comboBox_2.TabIndex = 7;
			this.groupBox_2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.groupBox_2.Controls.Add(this.label3);
			this.groupBox_2.Controls.Add(this.DonotCollectChapterNum);
			this.groupBox_2.Controls.Add(this.label4);
			this.groupBox_2.Controls.Add(this.label_2);
			this.groupBox_2.Controls.Add(this.numericUpDown_1);
			this.groupBox_2.Controls.Add(this.label_3);
			this.groupBox_2.Controls.Add(this.label_4);
			this.groupBox_2.Controls.Add(this.label_5);
			this.groupBox_2.Controls.Add(this.numericUpDown_2);
			this.groupBox_2.Location = new Point(6, 6);
			this.groupBox_2.Name = "groupBox_2";
			this.groupBox_2.Size = new System.Drawing.Size(790, 99);
			this.groupBox_2.TabIndex = 1;
			this.groupBox_2.TabStop = false;
			this.groupBox_2.Text = Localization.Get("章节限制");
			this.label3.AutoSize = true;
			this.label3.Location = new Point(188, 73);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(197, 12);
			this.label3.TabIndex = 9;
			this.label3.Text = Localization.Get("字的章节(根据目标站章节字节总数)");
			this.DonotCollectChapterNum.Location = new Point(125, 71);
			NumericUpDown donotCollectChapterNum = this.DonotCollectChapterNum;
			numArray = new int[] { 10000, 0, 0, 0 };
			donotCollectChapterNum.Maximum = new decimal(numArray);
			this.DonotCollectChapterNum.Name = "DonotCollectChapterNum";
			this.DonotCollectChapterNum.Size = new System.Drawing.Size(57, 21);
			this.DonotCollectChapterNum.TabIndex = 7;
			this.label4.AutoSize = true;
			this.label4.Location = new Point(6, 73);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(113, 12);
			this.label4.TabIndex = 8;
			this.label4.Text = Localization.Get("不替换章节字数小于");
			this.label_2.AutoSize = true;
			this.label_2.Location = new Point(212, 49);
			this.label_2.Name = "label_2";
			this.label_2.Size = new System.Drawing.Size(161, 12);
			this.label_2.TabIndex = 6;
			this.label_2.Text = Localization.Get("的小说(根据目标站章节总数)");
			this.numericUpDown_1.Location = new Point(149, 47);
			NumericUpDown numericUpDown1 = this.numericUpDown_1;
			numArray = new int[] { 10000, 0, 0, 0 };
			numericUpDown1.Maximum = new decimal(numArray);
			this.numericUpDown_1.Name = "numericUpDown_1";
			this.numericUpDown_1.Size = new System.Drawing.Size(57, 21);
			this.numericUpDown_1.TabIndex = 1;
			this.label_3.AutoSize = true;
			this.label_3.Location = new Point(6, 49);
			this.label_3.Name = "label_3";
			this.label_3.Size = new System.Drawing.Size(137, 12);
			this.label_3.TabIndex = 4;
			this.label_3.Text = Localization.Get("不修复需要更新章节超过");
			this.label_4.AutoSize = true;
			this.label_4.Location = new Point(176, 25);
			this.label_4.Name = "label_4";
			this.label_4.Size = new System.Drawing.Size(161, 12);
			this.label_4.TabIndex = 3;
			this.label_4.Text = Localization.Get("的小说(根据目标站章节总数)");
			this.label_5.AutoSize = true;
			this.label_5.Location = new Point(6, 25);
			this.label_5.Name = "label_5";
			this.label_5.Size = new System.Drawing.Size(101, 12);
			this.label_5.TabIndex = 2;
			this.label_5.Text = Localization.Get("不修复章节数小于");
			this.numericUpDown_2.Location = new Point(113, 20);
			NumericUpDown numericUpDown2 = this.numericUpDown_2;
			numArray = new int[] { 10000, 0, 0, 0 };
			numericUpDown2.Maximum = new decimal(numArray);
			this.numericUpDown_2.Name = "numericUpDown_2";
			this.numericUpDown_2.Size = new System.Drawing.Size(57, 21);
			this.numericUpDown_2.TabIndex = 0;
			this.tabPage_1.Controls.Add(this.groupBox3);
			this.tabPage_1.Controls.Add(this.groupBox_1);
			this.tabPage_1.Controls.Add(this.groupBox_0);
			this.tabPage_1.Controls.Add(this.checkBox_5);
			this.tabPage_1.Controls.Add(this.label_1);
			this.tabPage_1.Controls.Add(this.checkBox_6);
			this.tabPage_1.Controls.Add(this.numericUpDown_0);
			this.tabPage_1.Location = new Point(4, 22);
			this.tabPage_1.Name = "tabPage_1";
			this.tabPage_1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage_1.Size = new System.Drawing.Size(802, 330);
			this.tabPage_1.TabIndex = 1;
			this.tabPage_1.Text = Localization.Get("修复设置");
			this.tabPage_1.UseVisualStyleBackColor = true;
			this.groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.groupBox3.Controls.Add(this.checkBox_0);
			this.groupBox3.Controls.Add(this.ReplaceChapterNameOn);
			this.groupBox3.Controls.Add(this.label11);
			this.groupBox3.Controls.Add(this.label12);
			this.groupBox3.Controls.Add(this.numericUpDown1);
			this.groupBox3.Location = new Point(6, 232);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(790, 63);
			this.groupBox3.TabIndex = 51;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = Localization.Get("高级设置(高级授权服务)");
			this.checkBox_0.AutoSize = true;
			this.checkBox_0.Location = new Point(231, 24);
			this.checkBox_0.Name = "Md5Chapter";
			this.checkBox_0.Size = new System.Drawing.Size(282, 16);
			this.checkBox_0.TabIndex = 32;
			this.checkBox_0.Text = Localization.Get("自动对比章节MD5（如果章节内容相同则不修复）");
			this.checkBox_0.UseVisualStyleBackColor = true;
			this.ReplaceChapterNameOn.AutoSize = true;
			this.ReplaceChapterNameOn.ForeColor = SystemColors.HotTrack;
			this.ReplaceChapterNameOn.Location = new Point(521, 24);
			this.ReplaceChapterNameOn.Name = "ReplaceChapterNameOn";
			this.ReplaceChapterNameOn.Size = new System.Drawing.Size(228, 16);
			this.ReplaceChapterNameOn.TabIndex = 31;
			this.ReplaceChapterNameOn.Text = Localization.Get("使用修正列表规则（突破列表防采集）");
			this.ReplaceChapterNameOn.UseVisualStyleBackColor = true;
			this.label11.AutoSize = true;
			this.label11.Location = new Point(176, 25);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(41, 12);
			this.label11.TabIndex = 6;
			this.label11.Text = Localization.Get("的小说");
			this.label12.AutoSize = true;
			this.label12.Location = new Point(6, 25);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(113, 12);
			this.label12.TabIndex = 5;
			this.label12.Text = Localization.Get("只修复错误次数小于");
			this.numericUpDown1.Location = new Point(125, 23);
			NumericUpDown num = this.numericUpDown1;
			numArray = new int[] { 10000, 0, 0, 0 };
			num.Maximum = new decimal(numArray);
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(45, 21);
			this.numericUpDown1.TabIndex = 4;
			this.groupBox_1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.groupBox_1.Controls.Add(this.label1);
			this.groupBox_1.Controls.Add(this.comboBox1);
			this.groupBox_1.Controls.Add(this.label_32);
			this.groupBox_1.Controls.Add(this.comboBox_7);
			this.groupBox_1.Controls.Add(this.label_27);
			this.groupBox_1.Controls.Add(this.comboBox_5);
			this.groupBox_1.Controls.Add(this.label2);
			this.groupBox_1.Controls.Add(this.comboBox_1);
			this.groupBox_1.Location = new Point(6, 128);
			this.groupBox_1.Name = "groupBox_1";
			this.groupBox_1.Size = new System.Drawing.Size(790, 98);
			this.groupBox_1.TabIndex = 50;
			this.groupBox_1.TabStop = false;
			this.groupBox_1.Text = Localization.Get("其他设置");
			this.label1.AutoSize = true;
			this.label1.Location = new Point(6, 55);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(149, 12);
			this.label1.TabIndex = 31;
			this.label1.Text = Localization.Get("目标站重复章节判断方式：");
			this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox1.FormattingEnabled = true;
			ComboBox.ObjectCollection objectCollections = this.comboBox1.Items;
			objArray = new object[] { Localization.Get("停止本书，跳入下一本"), Localization.Get("跳过本章，继续采集下一个章") };
			objectCollections.AddRange(objArray);
			this.comboBox1.Location = new Point(221, 70);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(207, 20);
			this.comboBox1.TabIndex = 30;
			this.label_32.AutoSize = true;
			this.label_32.Location = new Point(219, 17);
			this.label_32.Name = "label_32";
			this.label_32.Size = new System.Drawing.Size(89, 12);
			this.label_32.TabIndex = 29;
			this.label_32.Text = Localization.Get("章节排序方式：");
			this.comboBox_7.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_7.FormattingEnabled = true;
			ComboBox.ObjectCollection items1 = this.comboBox_7.Items;
			objArray = new object[] { Localization.Get("目标站顺序"), Localization.Get("目标站倒序"), Localization.Get("按章节ID顺序"), Localization.Get("按章节ID倒序"), Localization.Get("按章节名顺序"), Localization.Get("按章节名倒序") };
			items1.AddRange(objArray);
			this.comboBox_7.Location = new Point(221, 32);
			this.comboBox_7.Name = "comboBox_7";
			this.comboBox_7.Size = new System.Drawing.Size(207, 20);
			this.comboBox_7.TabIndex = 28;
			this.label_27.AutoSize = true;
			this.label_27.Location = new Point(219, 55);
			this.label_27.Name = "label_27";
			this.label_27.Size = new System.Drawing.Size(113, 12);
			this.label_27.TabIndex = 25;
			this.label_27.Text = Localization.Get("重复章节处理方式：");
			this.comboBox_5.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_5.FormattingEnabled = true;
			ComboBox.ObjectCollection objectCollections1 = this.comboBox_5.Items;
			objArray = new object[] { Localization.Get("只对比章节名"), Localization.Get("对比分卷名+章节名") };
			objectCollections1.AddRange(objArray);
			this.comboBox_5.Location = new Point(8, 70);
			this.comboBox_5.Name = "comboBox_5";
			this.comboBox_5.Size = new System.Drawing.Size(207, 20);
			this.comboBox_5.TabIndex = 24;
			this.label2.AutoSize = true;
			this.label2.Location = new Point(6, 17);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(101, 12);
			this.label2.TabIndex = 23;
			this.label2.Text = Localization.Get("空章节处理方式：");
			this.comboBox_1.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_1.FormattingEnabled = true;
			ComboBox.ObjectCollection items2 = this.comboBox_1.Items;
			objArray = new object[] { Localization.Get("停止本书，跳入下一本"), Localization.Get("跳过本章，继续采集下一个章"), Localization.Get("入库一个章节名，继续采集下一个章") };
			items2.AddRange(objArray);
			this.comboBox_1.Location = new Point(8, 32);
			this.comboBox_1.Name = "comboBox_1";
			this.comboBox_1.Size = new System.Drawing.Size(207, 20);
			this.comboBox_1.TabIndex = 22;
			this.groupBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.groupBox_0.Controls.Add(this.DelForTxtHtml);
			this.groupBox_0.Controls.Add(this.checkBox_22);
			this.groupBox_0.Controls.Add(this.checkBox_21);
			this.groupBox_0.Controls.Add(this.checkBox_17);
			this.groupBox_0.Controls.Add(this.checkBox_16);
			this.groupBox_0.Controls.Add(this.DelForTxt);
			this.groupBox_0.Controls.Add(this.checkBox_8);
			this.groupBox_0.Controls.Add(this.checkBox_9);
			this.groupBox_0.Controls.Add(this.checkBox_4);
			this.groupBox_0.Controls.Add(this.dateTimePicker_1);
			this.groupBox_0.Controls.Add(this.label_25);
			this.groupBox_0.Controls.Add(this.checkBox_14);
			this.groupBox_0.Controls.Add(this.dateTimePicker_0);
			this.groupBox_0.Location = new Point(6, 6);
			this.groupBox_0.Name = "groupBox_0";
			this.groupBox_0.Size = new System.Drawing.Size(790, 116);
			this.groupBox_0.TabIndex = 49;
			this.groupBox_0.TabStop = false;
			this.groupBox_0.Text = Localization.Get("替换设置");
			this.checkBox_22.AutoSize = true;
			this.checkBox_22.Location = new Point(428, 20);
			this.checkBox_22.Name = "checkBox_22";
			this.checkBox_22.Size = new System.Drawing.Size(132, 16);
			this.checkBox_22.TabIndex = 71;
			this.checkBox_22.Text = Localization.Get("检测目标站重复章节");
			this.checkBox_22.UseVisualStyleBackColor = true;
			this.checkBox_21.AutoSize = true;
			this.checkBox_21.Location = new Point(202, 42);
			this.checkBox_21.Name = "checkBox_21";
			this.checkBox_21.Size = new System.Drawing.Size(198, 16);
			this.checkBox_21.TabIndex = 70;
			this.checkBox_21.Text = Localization.Get("遇到“１一1壹”才判断添加分卷");
			this.checkBox_21.UseVisualStyleBackColor = true;
			this.checkBox_17.AutoSize = true;
			this.checkBox_17.Location = new Point(428, 42);
			this.checkBox_17.Name = "checkBox_17";
			this.checkBox_17.Size = new System.Drawing.Size(150, 16);
			this.checkBox_17.TabIndex = 68;
			this.checkBox_17.Text = Localization.Get("以\"书名+作者\"识别书籍");
			this.checkBox_17.UseVisualStyleBackColor = true;
			this.checkBox_16.AutoSize = true;
			this.checkBox_16.Location = new Point(8, 64);
			this.checkBox_16.Name = "checkBox_16";
			this.checkBox_16.Size = new System.Drawing.Size(96, 16);
			this.checkBox_16.TabIndex = 62;
			this.checkBox_16.Text = Localization.Get("隐藏更新小说");
			this.checkBox_16.UseVisualStyleBackColor = true;
			this.DelForTxt.AutoSize = true;
			this.DelForTxt.Location = new Point(428, 64);
			this.DelForTxt.Name = "DelForTxt";
			this.DelForTxt.Size = new System.Drawing.Size(150, 16);
			this.DelForTxt.TabIndex = 60;
			this.DelForTxt.Text = Localization.Get("清理无用的TXT文本文件");
			this.DelForTxt.UseVisualStyleBackColor = true;
			this.checkBox_8.AutoSize = true;
			this.checkBox_8.Location = new Point(202, 20);
			this.checkBox_8.Name = "checkBox_8";
			this.checkBox_8.Size = new System.Drawing.Size(120, 16);
			this.checkBox_8.TabIndex = 61;
			this.checkBox_8.Text = Localization.Get("不处理已完成小说");
			this.checkBox_8.UseVisualStyleBackColor = true;
			this.checkBox_9.AutoSize = true;
			this.checkBox_9.Location = new Point(8, 20);
			this.checkBox_9.Name = "checkBox_9";
			this.checkBox_9.Size = new System.Drawing.Size(96, 16);
			this.checkBox_9.TabIndex = 67;
			this.checkBox_9.Text = Localization.Get("是否加添新书");
			this.checkBox_9.UseVisualStyleBackColor = true;
			this.checkBox_4.AutoSize = true;
			this.checkBox_4.Location = new Point(8, 42);
			this.checkBox_4.Name = "checkBox_4";
			this.checkBox_4.Size = new System.Drawing.Size(96, 16);
			this.checkBox_4.TabIndex = 65;
			this.checkBox_4.Text = Localization.Get("禁止添加分卷");
			this.checkBox_4.UseVisualStyleBackColor = true;
			this.dateTimePicker_1.CustomFormat = "yyyy/MM/dd HH:mm:ss";
			this.dateTimePicker_1.Format = DateTimePickerFormat.Custom;
			this.dateTimePicker_1.Location = new Point(318, 85);
			this.dateTimePicker_1.Name = "dateTimePicker_1";
			this.dateTimePicker_1.Size = new System.Drawing.Size(153, 21);
			this.dateTimePicker_1.TabIndex = 55;
			this.label_25.AutoSize = true;
			this.label_25.Location = new Point(295, 88);
			this.label_25.Name = "label_25";
			this.label_25.Size = new System.Drawing.Size(17, 12);
			this.label_25.TabIndex = 54;
			this.label_25.Text = Localization.Get("至");
			this.checkBox_14.AutoSize = true;
			this.checkBox_14.Location = new Point(8, 86);
			this.checkBox_14.Name = "checkBox_14";
			this.checkBox_14.Size = new System.Drawing.Size(120, 16);
			this.checkBox_14.TabIndex = 49;
			this.checkBox_14.Text = Localization.Get("章节入库时间限制");
			this.checkBox_14.UseVisualStyleBackColor = true;
			this.dateTimePicker_0.CustomFormat = "yyyy/MM/dd HH:mm:ss";
			this.dateTimePicker_0.Format = DateTimePickerFormat.Custom;
			this.dateTimePicker_0.Location = new Point(136, 85);
			this.dateTimePicker_0.Name = "dateTimePicker_0";
			this.dateTimePicker_0.Size = new System.Drawing.Size(153, 21);
			this.dateTimePicker_0.TabIndex = 52;
			this.checkBox_5.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			this.checkBox_5.AutoSize = true;
			this.checkBox_5.Location = new Point(459, 304);
			this.checkBox_5.Name = "checkBox_5";
			this.checkBox_5.Size = new System.Drawing.Size(72, 16);
			this.checkBox_5.TabIndex = 45;
			this.checkBox_5.Text = Localization.Get("修复记录");
			this.checkBox_5.UseVisualStyleBackColor = true;
			this.label_1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			this.label_1.AutoSize = true;
			this.label_1.Location = new Point(615, 304);
			this.label_1.Name = "label_1";
			this.label_1.Size = new System.Drawing.Size(125, 12);
			this.label_1.TabIndex = 47;
			this.label_1.Text = Localization.Get("循环间隔时间(分钟)：");
			this.checkBox_6.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			this.checkBox_6.AutoSize = true;
			this.checkBox_6.Location = new Point(537, 304);
			this.checkBox_6.Name = "checkBox_6";
			this.checkBox_6.Size = new System.Drawing.Size(72, 16);
			this.checkBox_6.TabIndex = 46;
			this.checkBox_6.Text = Localization.Get("循环修复");
			this.checkBox_6.UseVisualStyleBackColor = true;
			this.numericUpDown_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			this.numericUpDown_0.Location = new Point(746, 301);
			this.numericUpDown_0.Name = "numericUpDown_0";
			this.numericUpDown_0.Size = new System.Drawing.Size(50, 21);
			this.numericUpDown_0.TabIndex = 48;
			this.tabControl_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.tabControl_0.Controls.Add(this.tabPage_1);
			this.tabControl_0.Controls.Add(this.tabPage_2);
			this.tabControl_0.Controls.Add(this.tabPage_4);
			this.tabControl_0.Controls.Add(this.tabPage1);
			this.tabControl_0.Location = new Point(12, 12);
			this.tabControl_0.Name = "tabControl_0";
			this.tabControl_0.SelectedIndex = 0;
			this.tabControl_0.Size = new System.Drawing.Size(810, 356);
			this.tabControl_0.TabIndex = 48;
			this.DelForTxtHtml.AutoSize = true;
			this.DelForTxtHtml.Location = new Point(202, 64);
			this.DelForTxtHtml.Name = "DelForTxtHtml";
			this.DelForTxtHtml.Size = new System.Drawing.Size(144, 16);
			this.DelForTxtHtml.TabIndex = 72;
			this.DelForTxtHtml.Text = Localization.Get("清理无用HTML页面文件");
			this.DelForTxtHtml.UseVisualStyleBackColor = true;
			base.ClientSize = new System.Drawing.Size(834, 409);
			base.Controls.Add(this.button_2);
			base.Controls.Add(this.tabControl_0);
			base.Controls.Add(this.comboBox_0);
			base.Controls.Add(this.button_0);
			base.Controls.Add(this.button_1);
			this.Font = new System.Drawing.Font(Localization.Get("宋体"), 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
			base.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "CollectReplace";
			this.Text = Localization.Get("超级修复模式");
			base.Load += new EventHandler(this.CollectReplace_Load);
			base.FormClosing += new FormClosingEventHandler(this.CollectReplace_FormClosing);
			this.tabPage1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox_7.ResumeLayout(false);
			this.groupBox_7.PerformLayout();
			this.tabPage_4.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox_9.ResumeLayout(false);
			this.groupBox_9.PerformLayout();
			this.groupBox_8.ResumeLayout(false);
			this.groupBox_8.PerformLayout();
			((ISupportInitialize)this.numericUpDown_3).EndInit();
			((ISupportInitialize)this.numericUpDown_4).EndInit();
			((ISupportInitialize)this.numericUpDown_5).EndInit();
			this.tabPage_2.ResumeLayout(false);
			this.groupBox_4.ResumeLayout(false);
			this.groupBox_4.PerformLayout();
			this.groupBox_3.ResumeLayout(false);
			this.groupBox_3.PerformLayout();
			this.groupBox_2.ResumeLayout(false);
			this.groupBox_2.PerformLayout();
			((ISupportInitialize)this.DonotCollectChapterNum).EndInit();
			((ISupportInitialize)this.numericUpDown_1).EndInit();
			((ISupportInitialize)this.numericUpDown_2).EndInit();
			this.tabPage_1.ResumeLayout(false);
			this.tabPage_1.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((ISupportInitialize)this.numericUpDown1).EndInit();
			this.groupBox_1.ResumeLayout(false);
			this.groupBox_1.PerformLayout();
			this.groupBox_0.ResumeLayout(false);
			this.groupBox_0.PerformLayout();
			((ISupportInitialize)this.numericUpDown_0).EndInit();
			this.tabControl_0.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		private void method_0()
		{
			try
			{
				this.checkBox_5.Checked = this.tInfo.Log;
				this.checkBox_6.Checked = this.tInfo.Timing;
				this.numericUpDown_0.Value = this.tInfo.Interval;
				this.checkBox_14.Checked = this.tInfo.AddTime;
				this.dateTimePicker_0.Value = this.tInfo.MinAddTime;
				this.dateTimePicker_1.Value = this.tInfo.MaxAddTime;
				this.checkBox_4.Checked = this.tInfo.ProhibitionVolume;
				this.numericUpDown_2.Value = this.tInfo.MinChapterNum;
				this.numericUpDown_1.Value = this.tInfo.FindMaxChapterNum;
				this.DonotCollectChapterNum.Value = this.tInfo.ReMoteChapterNum;
				this.comboBox_2.SelectedIndex = this.tInfo.FilterNovelType;
				if (this.tInfo.FilterVolume != null)
				{
					this.FilterVolume.Text = string.Join("\r\n", this.tInfo.FilterVolume);
				}
				if (this.tInfo.FilterNovel != null)
				{
					this.FilterNovel.Text = string.Join("\r\n", this.tInfo.FilterNovel);
				}
				this.textBox_16.Text = this.tInfo.ProxyHost;
				this.textBox_15.Text = this.tInfo.ProxyPort.ToString();
				this.textBox_12.Text = this.tInfo.ProxyDomain;
				this.textBox_14.Text = this.tInfo.ProxyUser;
				this.textBox_13.Text = this.tInfo.ProxyPassword;
				this.checkBox_12.Checked = this.tInfo.Proxy;
				this.numericUpDown_5.Value = this.tInfo.NovelUrlWait;
				this.numericUpDown_4.Value = this.tInfo.IndexUrlWait;
				this.numericUpDown_3.Value = this.tInfo.ChapterUrlWait;
				this.checkBox_13.Checked = this.tInfo.NoPBar;
				this.checkBox_22.Checked = this.tInfo.CheckRepeat;
				this.DelForTxt.Checked = this.tInfo.DelForTxt;
				this.checkBox_8.Checked = this.tInfo.FilterFinish;
				this.checkBox_9.Checked = this.tInfo.NewBook;
				this.checkBox_16.Checked = this.tInfo.Hidebook;
				this.checkBox_17.Checked = this.tInfo.NameAndAuthor;
				this.checkBox_21.Checked = this.tInfo.CheckVolume;
				this.checkBox_4.Checked = this.tInfo.ProhibitionVolume;
				this.comboBox_1.SelectedIndex = this.tInfo.EmptyChapter;
				this.comboBox_7.SelectedIndex = this.tInfo.OrderChapter;
				this.comboBox1.SelectedIndex = this.tInfo.RepeatChapterHandle;
				this.comboBox_5.SelectedIndex = this.tInfo.GoRepeatChapter;
				this.DelForTxtHtml.Checked = this.tInfo.DelForTxtHtml;
				this.numericUpDown1.Value = this.tInfo.ErrorNum;
				this.ReplaceChapterNameOn.Checked = this.tInfo.ReplaceChapterNameOn;
				this.checkBox_0.Checked = this.tInfo.Boolean_0;
				if (!Configs.BaseConfig.LicenseVip)
				{
					this.numericUpDown1.Value = new decimal(0);
					this.checkBox_0.Checked = false;
					this.ReplaceChapterNameOn.Checked = false;
					this.groupBox3.Enabled = false;
				}
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

		private void method_1()
		{
			try
			{
				this.tInfo.Log = this.checkBox_5.Checked;
				this.tInfo.Timing = this.checkBox_6.Checked;
				this.tInfo.Interval = Convert.ToInt32(this.numericUpDown_0.Value);
				this.tInfo.ProhibitionVolume = this.checkBox_4.Checked;
				this.tInfo.AddTime = this.checkBox_14.Checked;
				this.tInfo.MinAddTime = this.dateTimePicker_0.Value;
				this.tInfo.MaxAddTime = this.dateTimePicker_1.Value;
				this.tInfo.MinChapterNum = Convert.ToInt32(this.numericUpDown_2.Value);
				this.tInfo.FindMaxChapterNum = Convert.ToInt32(this.numericUpDown_1.Value);
				this.tInfo.ReMoteChapterNum = Convert.ToInt32(this.DonotCollectChapterNum.Value);
				this.tInfo.FilterNovelType = this.comboBox_2.SelectedIndex;
				ReplaceConfigInfo replaceConfigInfo = this.tInfo;
				string str = this.FilterVolume.Text.Replace("\r\n", "♂");
				char[] chrArray = new char[] { '\u2642' };
				replaceConfigInfo.FilterVolume = str.Split(chrArray);
				ReplaceConfigInfo replaceConfigInfo1 = this.tInfo;
				string str1 = this.FilterNovel.Text.Replace("\r\n", "♂");
				chrArray = new char[] { '\u2642' };
				replaceConfigInfo1.FilterNovel = str1.Split(chrArray);
				this.tInfo.ProxyHost = this.textBox_16.Text;
				this.tInfo.ProxyPort = Convert.ToInt32(this.textBox_15.Text);
				this.tInfo.ProxyDomain = this.textBox_12.Text;
				this.tInfo.ProxyUser = this.textBox_14.Text;
				this.tInfo.ProxyPassword = this.textBox_13.Text;
				this.tInfo.Proxy = this.checkBox_12.Checked;
				this.tInfo.NoPBar = this.checkBox_13.Checked;
				this.tInfo.NovelUrlWait = Convert.ToInt32(this.numericUpDown_5.Value);
				this.tInfo.IndexUrlWait = Convert.ToInt32(this.numericUpDown_4.Value);
				this.tInfo.ChapterUrlWait = Convert.ToInt32(this.numericUpDown_3.Value);
				this.tInfo.CheckRepeat = this.checkBox_22.Checked;
				this.tInfo.DelForTxt = this.DelForTxt.Checked;
				this.tInfo.FilterFinish = this.checkBox_8.Checked;
				this.tInfo.NewBook = this.checkBox_9.Checked;
				this.tInfo.Hidebook = this.checkBox_16.Checked;
				this.tInfo.NameAndAuthor = this.checkBox_17.Checked;
				this.tInfo.CheckVolume = this.checkBox_21.Checked;
				this.tInfo.ProhibitionVolume = this.checkBox_4.Checked;
				this.tInfo.EmptyChapter = this.comboBox_1.SelectedIndex;
				this.tInfo.OrderChapter = this.comboBox_7.SelectedIndex;
				this.tInfo.RepeatChapterHandle = this.comboBox1.SelectedIndex;
				this.tInfo.GoRepeatChapter = this.comboBox_5.SelectedIndex;
				this.tInfo.DelForTxtHtml = this.DelForTxtHtml.Checked;
				this.tInfo.ErrorNum = Convert.ToInt32(this.numericUpDown1.Value);
				this.tInfo.ReplaceChapterNameOn = this.ReplaceChapterNameOn.Checked;
				this.tInfo.Boolean_0 = this.checkBox_0.Checked;
				if (!Configs.BaseConfig.LicenseVip)
				{
					this.tInfo.Boolean_0 = false;
					this.tInfo.ReplaceChapterNameOn = false;
					this.tInfo.ErrorNum = 0;
				}
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

		private void method_2(string string_3, bool bool_1)
		{
			this.backgroundWorker_0.ReportProgress(101, string_3);
			FileInfo fileInfo = new FileInfo(string_3 ?? "");
			if (fileInfo.Exists)
			{
				string str = string.Concat("Data Source=", fileInfo.FullName);
				string str1 = string.Concat("Select * From [TaskLog] Where GETID<>'0' And GETID<>'' And RULEFILE<>'' And ERROROK=0 And ERRORNUM<=", this.tInfo.ErrorNum);
				DataSet dataSet = SQLiteHelper.ExecuteDataset(str, str1);
				if ((dataSet == null ? false : dataSet.Tables[0].Rows.Count >= 1))
				{
					this.backgroundWorker_0.ReportProgress(5, dataSet.Tables[0].Rows.Count);
					for (int i = 0; i < dataSet.Tables[0].Rows.Count && !this.backgroundWorker_0.CancellationPending; i++)
					{
						this.backgroundWorker_0.ReportProgress(3, i + 1);
						int num = i + 1;
						this.backgroundWorker_0.ReportProgress(102, string.Concat(num.ToString(), " / ", dataSet.Tables[0].Rows.Count));
						NovelInfo novelInfo = new NovelInfo()
						{
							GetID = dataSet.Tables[0].Rows[i]["GETID"].ToString(),
							RuleName = dataSet.Tables[0].Rows[i]["RULEFILE"].ToString()
						};
						NovelInfo novelInfo1 = novelInfo;
						this.backgroundWorker_0.ReportProgress(103, novelInfo1.RuleName);
						try
						{
							this.rInfo = (RuleConfigInfo)ConfigFileManager.LoadConfig(novelInfo1.RuleName, this.rInfo);
						}
						catch
						{
							BackgroundWorker backgroundWorker0 = this.backgroundWorker_0;
							string[] string3 = new string[] { Localization.Get("失败 | "), string_3, " | ", novelInfo1.RuleName, " | ", novelInfo1.GetID, Localization.Get(" | 无法载入。") };
							backgroundWorker0.ReportProgress(9, string.Concat(string3));
						}
						this.method_4(novelInfo1, string_3, novelInfo1.RuleName);
					}
				}
			}
		}

		private void method_4(NovelInfo novelInfo_0, string string_3, string string_2)
		{
			ChapterInfo[] chapterList;
			int i;
			int num;
			string[] filterNovel;
			if (novelInfo_0.GetID == null)
			{
				novelInfo_0.GetID = "0";
			}
			if (novelInfo_0.Name == null)
			{
				novelInfo_0.Name = "";
			}
			BackgroundWorker backgroundWorker0 = this.backgroundWorker_0;
			string[] getID = new string[] { novelInfo_0.GetID, " | ", novelInfo_0.Name, " | ", novelInfo_0.PutID.ToString() };
			backgroundWorker0.ReportProgress(0, string.Concat(getID));
			this.backgroundWorker_0.ReportProgress(1, "--");
			this.backgroundWorker_0.ReportProgress(2, Localization.Get("获得小说信息"));
			this.backgroundWorker_0.ReportProgress(4, 0);
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
					novelInfo_0 = page.GetNovelInfo(novelInfo_0);
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				BackgroundWorker backgroundWorker = this.backgroundWorker_0;
				getID = new string[] { Localization.Get("失败 | "), string_3, " | ", string_2, " | ", novelInfo_0.GetID, " | ", exception.Message };
				backgroundWorker.ReportProgress(9, string.Concat(getID));
				return;
			}
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
						BackgroundWorker backgroundWorker01 = this.backgroundWorker_0;
						getID = new string[] { Localization.Get("失败 | "), string_3, " | ", string_2, " | ", novelInfo_0.GetID, Localization.Get(" | 子窗口冲突") };
						backgroundWorker01.ReportProgress(9, string.Concat(getID));
						return;
					}
				}
			}
			catch
			{
				BackgroundWorker backgroundWorker1 = this.backgroundWorker_0;
				getID = new string[] { Localization.Get("失败 | "), string_3, " | ", string_2, " | ", novelInfo_0.GetID, Localization.Get(" | 检查子窗口冲突失败") };
				backgroundWorker1.ReportProgress(9, string.Concat(getID));
				return;
			}
			Configs.TaskNovelInfo[this.string_2.ToString()] = novelInfo_0;
			BackgroundWorker backgroundWorker02 = this.backgroundWorker_0;
			getID = new string[] { novelInfo_0.GetID, " | ", novelInfo_0.Name, " | ", novelInfo_0.PutID.ToString() };
			backgroundWorker02.ReportProgress(0, string.Concat(getID));
			SpiderException.Debug(this.tInfo.ID, Localization.Get("CollectAuto.Collect 过滤小说"));
			if (this.tInfo.FilterNovelType != 1)
			{
				if (this.tInfo.FilterNovelType == 2)
				{
					bool flag = false;
					if (this.tInfo.FilterNovel != null)
					{
						filterNovel = this.tInfo.FilterNovel;
						i = 0;
						while (i < (int)filterNovel.Length)
						{
							string str = filterNovel[i];
							if (novelInfo_0.Name.Trim() == str.Trim())
							{
								flag = true;
								goto Label1;
							}
							else
							{
								i++;
							}
						}
					}
				Label1:
					if (flag)
					{
						goto Label2;
					}
					BackgroundWorker backgroundWorker2 = this.backgroundWorker_0;
					getID = new string[] { Localization.Get("失败 | "), string_3, " | ", string_2, " | ", novelInfo_0.GetID, " | ", novelInfo_0.Name, Localization.Get(" 限制小说(不在白名单)") };
					backgroundWorker2.ReportProgress(9, string.Concat(getID));
					return;
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
						BackgroundWorker backgroundWorker03 = this.backgroundWorker_0;
						getID = new string[] { Localization.Get("失败 | "), string_3, " | ", string_2, " | ", novelInfo_0.GetID, " | ", novelInfo_0.Name, Localization.Get(" 限制小说(黑名单)") };
						backgroundWorker03.ReportProgress(9, string.Concat(getID));
						return;
					}
					else
					{
						i++;
					}
				}
			}
		Label2:
			if (!this.backgroundWorker_0.CancellationPending)
			{
				SpiderException.Debug(this.tInfo.ID, Localization.Get("CollectAuto.Collect 获得小说的章节目录"));
				try
				{
					this.backgroundWorker_0.ReportProgress(2, Localization.Get("获得小说的章节目录"));
					chapterList = page.GetChapterList(novelInfo_0);
				}
				catch (Exception exception3)
				{
					Exception exception2 = exception3;
					BackgroundWorker backgroundWorker3 = this.backgroundWorker_0;
					getID = new string[] { Localization.Get("失败 | "), string_3, " | ", string_2, " | ", novelInfo_0.GetID, " | ", novelInfo_0.Name, " ", exception2.Message };
					backgroundWorker3.ReportProgress(9, string.Concat(getID));
					return;
				}
				if ((chapterList == null ? false : (int)chapterList.Length != 0))
				{
					this.backgroundWorker_0.ReportProgress(6, (int)chapterList.Length);
					if (!this.backgroundWorker_0.CancellationPending)
					{
						bool flag1 = false;
						if ((novelInfo_0.PutID != 0 ? false : novelInfo_0.IsNew))
						{
							this.backgroundWorker_0.ReportProgress(2, Localization.Get("处理新书"));
							if ((!this.tInfo.Finish || novelInfo_0.Degree != 1 ? true : !this.tInfo.NewBook))
							{
								SpiderException.Debug(this.tInfo.ID, Localization.Get("CollectAuto.Collect 是否添加新书判断"));
								if (this.tInfo.NewBook)
								{
									SpiderException.Debug(this.tInfo.ID, Localization.Get("CollectAuto.Collect 章节数量限制判断"));
									if (((int)chapterList.Length <= this.tInfo.FindMaxChapterNum ? true : this.tInfo.FindMaxChapterNum == 0))
									{
										if (((int)chapterList.Length >= this.tInfo.MinChapterNum ? true : this.tInfo.MinChapterNum == 0))
										{
											goto Label3;
										}
										BackgroundWorker backgroundWorker04 = this.backgroundWorker_0;
										getID = new string[] { Localization.Get("失败 | "), string_3, " | ", string_2, " | ", novelInfo_0.GetID, " | ", novelInfo_0.Name, Localization.Get(" 章节数量小于限制") };
										backgroundWorker04.ReportProgress(9, string.Concat(getID));
										return;
									}
									else
									{
										BackgroundWorker backgroundWorker4 = this.backgroundWorker_0;
										getID = new string[] { Localization.Get("失败 | "), string_3, " | ", string_2, " | ", novelInfo_0.GetID, " | ", novelInfo_0.Name, Localization.Get(" 章节数量大于限制") };
										backgroundWorker4.ReportProgress(9, string.Concat(getID));
										return;
									}
								}
								else
								{
									BackgroundWorker backgroundWorker05 = this.backgroundWorker_0;
									getID = new string[] { Localization.Get("失败 | "), string_3, " | ", string_2, " | ", novelInfo_0.GetID, " | ", novelInfo_0.Name, Localization.Get(" 设置不添加新书") };
									backgroundWorker05.ReportProgress(9, string.Concat(getID));
									return;
								}
							}
						Label3:
							SpiderException.Debug(this.tInfo.ID, Localization.Get("CollectAuto.Collect 正式入库小说信息"));
							novelInfo_0 = LocalProvider.GetInstance().InsertNovel(novelInfo_0);
							flag1 = true;
							BackgroundWorker backgroundWorker5 = this.backgroundWorker_0;
							getID = new string[] { novelInfo_0.GetID, " | ", novelInfo_0.Name, " | ", novelInfo_0.PutID.ToString() };
							backgroundWorker5.ReportProgress(0, string.Concat(getID));
						}
						ChapterInfo[] chapterInfo = LocalProvider.GetInstance().GetChapterList(novelInfo_0.PutID);
						int length = 0;
						length = (int)chapterInfo.Length - (int)chapterList.Length;
						if (length < 0)
						{
							length = 0;
						}
						int num1 = 0;
						int num2 = 0;
						num = 0;
						Thread.Sleep(this.tInfo.IndexUrlWait);
						int num3 = 0;
						while (true)
						{
							if ((num3 < (int)chapterList.Length ? this.backgroundWorker_0.CancellationPending : true))
							{
								this.backgroundWorker_0.ReportProgress(2, Localization.Get("章节循环完毕"));
								break;
							}
							else
							{
								novelInfo_0.LastChapter = chapterList[num3];
								if ((this.tInfo.FilterVolume == null ? false : this.tInfo.FilterVolume[0].Replace(" ", "") != ""))
								{
									string str2 = "";
									filterNovel = this.tInfo.FilterVolume;
									for (i = 0; i < (int)filterNovel.Length; i++)
									{
										string str3 = filterNovel[i];
										if (str3.Replace(" ", "") != "")
										{
											str2 = str3.Replace(Localization.Get("{$书卷名称$}"), chapterList[num3].VolumeName).Replace(Localization.Get("{$小说作者$}"), novelInfo_0.Author).Replace(Localization.Get("{$小说名称$}"), novelInfo_0.Name).Replace(Localization.Get("{$分类名称$}"), novelInfo_0.LagerSort);
										}
									}
									if (!Regex.Match(chapterList[num3].VolumeName, str2, RegexOptions.IgnoreCase).Success)
									{
										goto Label5;
									}
									num++;
									this.backgroundWorker_0.ReportProgress(2, string.Concat(Localization.Get("限制分卷 "), novelInfo_0.LastChapter.ChapterName));
                                    num3++;
                                    continue;
								}
							Label5:
								this.backgroundWorker_0.ReportProgress(1, string.Concat(novelInfo_0.LastChapter.ChapterName, " | ", novelInfo_0.LastChapter.GetID));
								this.backgroundWorker_0.ReportProgress(4, num3 + 1);
								if (this.tInfo.CheckRepeat)
								{
									int num4 = 0;
									ChapterInfo[] chapterInfoArray = chapterList;
									i = 0;
									while (i < (int)chapterInfoArray.Length)
									{
										ChapterInfo chapterInfo1 = chapterInfoArray[i];
										bool flag2 = false;
										if (this.tInfo.GoRepeatChapter == 1)
										{
											if ((!(chapterInfo1.VolumeName == novelInfo_0.LastChapter.VolumeName) || !(chapterInfo1.ChapterName == novelInfo_0.LastChapter.Name) || chapterInfo1.PutID == novelInfo_0.LastChapter.PutID ? false : num4 > num3))
											{
												flag2 = true;
											}
										}
										else if ((!(chapterInfo1.ChapterName == novelInfo_0.LastChapter.Name) || chapterInfo1.PutID == novelInfo_0.LastChapter.PutID ? false : num4 > num3))
										{
											flag2 = true;
										}
										if (!flag2)
										{
											num4++;
											i++;
										}
										else if (this.tInfo.RepeatChapterHandle == 0)
										{
											this.backgroundWorker_0.ReportProgress(2, string.Concat(Localization.Get("跳过本书，发现重复章节 "), novelInfo_0.LastChapter.ChapterName));
											goto Label6;
										}
										else
										{
											num++;
											this.backgroundWorker_0.ReportProgress(2, string.Concat(Localization.Get("重复章节 "), novelInfo_0.LastChapter.ChapterName));
                                            num3++;
                                            continue;
										}
									}
								}
								if ((!this.tInfo.AddTime ? false : num3 < (int)chapterInfo.Length))
								{
									chapterInfo[num3] = LocalProvider.GetInstance().GetChapterInfo(novelInfo_0.PutID, chapterInfo[num3].PutID);
									if ((chapterInfo[num3].LastTime >= this.tInfo.MinAddTime ? true : !(chapterInfo[num3].LastTime > this.tInfo.MaxAddTime)))
									{
										goto Label7;
									}
									num++;
									this.backgroundWorker_0.ReportProgress(2, string.Concat(Localization.Get("限制章节 "), novelInfo_0.LastChapter.ChapterName));
                                    num3++;
                                    continue;
								}
							Label7:
								if (this.backgroundWorker_0.CancellationPending)
								{
									break;
								}
								try
								{
									novelInfo_0 = page.GetChapterInfo(novelInfo_0, false);
								}
								catch (Exception exception5)
								{
									Exception exception4 = exception5;
									BackgroundWorker backgroundWorker06 = this.backgroundWorker_0;
									getID = new string[] { Localization.Get("失败 | "), string_3, " | ", string_2, " | ", novelInfo_0.GetID, " | ", novelInfo_0.Name, " ", exception4.Message };
									backgroundWorker06.ReportProgress(9, string.Concat(getID));
									break;
								}
								flag1 = true;
								this.backgroundWorker_0.ReportProgress(2, Localization.Get("正在入库章节"));
								if (novelInfo_0.LastChapter.ChapterText.Length <= this.tInfo.ReMoteChapterNum)
								{
									if (this.tInfo.EmptyChapter == 0)
									{
										this.backgroundWorker_0.ReportProgress(2, string.Concat(Localization.Get("跳过本书，发现空白章节"), novelInfo_0.LastChapter.ChapterName));
										break;
									}
									else if (this.tInfo.EmptyChapter == 1)
									{
                                        num++;
                                        this.backgroundWorker_0.ReportProgress(2, string.Concat(Localization.Get("空白章节 "), novelInfo_0.LastChapter.ChapterName));
                                        num3++;
                                        continue;
                                    }
                                }
								try
								{
									if (num3 >= (int)chapterInfo.Length)
									{
										novelInfo_0.LastChapter.LastTime = DateTime.Now;
									}
									else
									{
										novelInfo_0.LastChapter.PutID = chapterInfo[num3].PutID;
										novelInfo_0.LastChapter.LastTime = chapterInfo[num3].LastTime;
									}
									if ((!this.tInfo.Boolean_0 ? false : novelInfo_0.LastChapter.PutID > 0))
									{
										string chapterText = LocalProvider.GetInstance().GetChapterText(novelInfo_0, false);
										string chapterText1 = LocalProvider.GetInstance().GetChapterText(novelInfo_0, true);
										if (SecurityUtil.MD5(chapterText) == SecurityUtil.MD5(chapterText1.Substring(0, chapterText1.Length - 4)))
										{
											num++;
											this.backgroundWorker_0.ReportProgress(2, string.Concat(Localization.Get("跳过章节 "), novelInfo_0.LastChapter.ChapterName));
                                            num3++;
                                            continue;
										}
									}
									if (novelInfo_0.LastChapter.PutID <= 0)
									{
										num2++;
										this.backgroundWorker_0.ReportProgress(2, string.Concat(Localization.Get("新增章节 "), novelInfo_0.LastChapter.ChapterName));
										LocalProvider.GetInstance().InsertChapter(novelInfo_0, this.uInfo);
									}
									else
									{
										num1++;
										this.backgroundWorker_0.ReportProgress(2, string.Concat(Localization.Get("执行替换 "), novelInfo_0.LastChapter.ChapterName));
										LocalProvider.GetInstance().UpdateChapter(novelInfo_0, this.tInfo);
									}
								}
								catch (Exception exception7)
								{
									Exception exception6 = exception7;
									BackgroundWorker backgroundWorker6 = this.backgroundWorker_0;
									getID = new string[] { Localization.Get("失败 | "), string_3, " | ", string_2, " | ", novelInfo_0.GetID, " | ", novelInfo_0.Name, " ", exception6.Message };
									backgroundWorker6.ReportProgress(9, string.Concat(getID));
								}
								if (Configs.BaseConfig.ChapterHtml)
								{
									if (Configs.BaseConfig.ChapterHtml)
									{
										LocalProvider.GetInstance().CreateChapter(novelInfo_0);
									}
									Thread.Sleep(this.tInfo.ChapterUrlWait);
								}
                                num3++;
                                continue;
							}
						}
					Label6:
						if (flag1)
						{
							LocalProvider.GetInstance().UpdateLastChapter(novelInfo_0);
							LocalProvider.GetInstance().CreateIndex(novelInfo_0, Configs.BaseConfig.IndexHtml, Configs.BaseConfig.FullHtml, Configs.BaseConfig.bool_10, Configs.BaseConfig.CreateTxt, this.tInfo.DelForTxt, this.tInfo.DelForTxtHtml, length);
							BackgroundWorker backgroundWorker07 = this.backgroundWorker_0;
							object[] string3 = new object[] { Localization.Get("成功 | "), string_3, " | ", string_2, " | ", novelInfo_0.GetID, " | ", novelInfo_0.Name, Localization.Get(" 替换"), num1, Localization.Get("章节，新增"), num2, Localization.Get("章节，跳过"), num, Localization.Get("章节") };
							backgroundWorker07.ReportProgress(8, string.Concat(string3));
						}
					}
				}
				else
				{
					BackgroundWorker backgroundWorker7 = this.backgroundWorker_0;
					getID = new string[] { Localization.Get("失败 | "), string_3, " | ", string_2, " | ", novelInfo_0.GetID, " | ", novelInfo_0.Name, Localization.Get(" 章节组为空") };
					backgroundWorker7.ReportProgress(9, string.Concat(getID));
				}
			}
			return;
		}

		private void timer_0_Tick(object sender, EventArgs e)
		{
			DateTime now;
			if (!this.backgroundWorker_0.IsBusy)
			{
				if (this.dateTime_0 >= DateTime.Now)
				{
					TimeSpan timeSpan = new TimeSpan(this.dateTime_0.Ticks);
					now = DateTime.Now;
					TimeSpan timeSpan1 = timeSpan.Subtract(new TimeSpan(now.Ticks));
					TimeSpan timeSpan2 = timeSpan1.Duration();
					Label label15 = this.label_15;
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
					label15.Text = string.Concat(str);
				}
				else
				{
					now = DateTime.Now;
					this.dateTime_0 = now.AddMinutes((double)this.tInfo.Interval);
					this.backgroundWorker_0.RunWorkerAsync();
					this.timer_0.Stop();
				}
			}
		}
	}
}