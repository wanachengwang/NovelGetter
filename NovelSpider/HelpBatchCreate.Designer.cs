using NovelSpider.Common;
using NovelSpider.Config;
using NovelSpider.Entity;
using NovelSpider.Local;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace NovelSpider
{
	public class HelpBatchCreate : DockContent
	{
		private BackgroundWorker backgroundWorker_0;

		private Button button_0;

		private Button button_1;

		private Button button_2;

		private Button button_3;

		private Button button_4;

		private Button button1;

		public bool ChapterHtml;

		private CheckBox checkBox_3;

		private CheckBox checkBox_5;

		private CheckBox checkBox_6;

		private CheckBox checkBox_7;

		private CheckBox checkBox_8;

		private CheckBox checkBox_9;

		public string CmdText;

		public bool bool_0;

		public bool bool_1;

		private DateTime dateTime_0;

		public bool FullHtml;

		private GroupBox groupBox_0;

		private GroupBox groupBox_1;

		private IContainer icontainer_0;

		public bool IndexHtml;

		private Label label_0;

		private Label label_1;

		private Label label_10;

		private Label label_11;

		private Label label_13;

		private Label label_2;

		private Label label_3;

		private Label label_4;

		private Label label_5;

		private Label label_6;

		private Label label_7;

		private Label label_8;

		private Label label_9;

		private Label label1;

		private Label label2;

		public bool Log;

		public int m_Interval;

		private NumericUpDown numericUpDown_0;

		private NumericUpDown numericUpDown_1;

		private NumericUpDown numericUpDown_2;

		private NumericUpDown numericUpDown_3;

		private ProgressBar progressBar_0;

		private ProgressBar progressBar_1;

		private TextBox textBox_0;

		private TextBox textBox1;

		private Timer timer_0;

		private IContainer components;

		public bool Timing;

		public HelpBatchCreate()
		{
			Class19.Q77LubhzKM3NS();
			this.dateTime_0 = DateTime.Now;
			this.m_Interval = 1;
			this.InitializeComponent();
		}

		private void backgroundWorker_0_DoWork(object sender, DoWorkEventArgs e)
		{
			NovelInfo[] novelList;
			this.backgroundWorker_0.ReportProgress(2, Localization.Get("正在获得小说列表"));
			try
			{
				novelList = LocalProvider.GetInstance().GetNovelList(this.CmdText);
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				if (this.Log)
				{
					SpiderException.Debug(Localization.Get("批量生成"), exception.Message);
				}
				else
				{
					MessageBox.Show(string.Concat(Localization.Get("无法载入小说列表，有可能是SQL语句错误。\n\n"), exception.Message));
				}
				return;
			}
			this.backgroundWorker_0.ReportProgress(5, (int)novelList.Length - 1);
			int num = 0;
			while (num < (int)novelList.Length)
			{
				if (this.backgroundWorker_0.CancellationPending)
				{
					e.Cancel = true;
					break;
				}
				else
				{
					this.backgroundWorker_0.ReportProgress(3, num);
					this.backgroundWorker_0.ReportProgress(0, string.Concat(novelList[num].PutID, " | ", novelList[num].Name));
					this.backgroundWorker_0.ReportProgress(2, Localization.Get("正在获得章节列表"));
					if (this.ChapterHtml)
					{
						try
						{
							ChapterInfo[] chapterList = LocalProvider.GetInstance().GetChapterList(novelList[num].PutID);
							this.backgroundWorker_0.ReportProgress(6, (int)chapterList.Length - 1);
							int num1 = 0;
							while (num1 < (int)chapterList.Length)
							{
								if (this.backgroundWorker_0.CancellationPending)
								{
									e.Cancel = true;
									goto Label1;
								}
								else
								{
									this.backgroundWorker_0.ReportProgress(4, num1);
									this.backgroundWorker_0.ReportProgress(1, string.Concat(chapterList[num1].VolumeName, " ", chapterList[num1].ChapterName));
									this.backgroundWorker_0.ReportProgress(2, Localization.Get("正在生成章节内容HTML"));
									int putID = 0;
									int putID1 = 0;
									string chapterName = "";
									string str = "";
									string volumeName = "";
									if (num1 != 0)
									{
										chapterName = chapterList[num1 - 1].ChapterName;
										putID = chapterList[num1 - 1].PutID;
									}
									if ((int)chapterList.Length > num1 + 1)
									{
										str = chapterList[num1 + 1].ChapterName;
										putID1 = chapterList[num1 + 1].PutID;
									}
									volumeName = chapterList[num1].VolumeName;
									LocalProvider.GetInstance().CreateSingleChapter(novelList[num], chapterList[num1], false, putID, putID1, chapterName, str, volumeName);
									num1++;
								}
							}
						}
						catch (Exception exception3)
						{
							Exception exception2 = exception3;
							if (this.Log)
							{
								SpiderException.Debug(Localization.Get("批量生成"), exception2.Message);
							}
							else
							{
								MessageBox.Show(exception2.Message);
							}
						}
					}
				Label1:
					this.backgroundWorker_0.ReportProgress(1, "--");
					this.backgroundWorker_0.ReportProgress(2, Localization.Get("正在生成目录页,全文页及电子书"));
					try
					{
						LocalProvider.GetInstance().CreateIndex(novelList[num], this.IndexHtml, this.FullHtml, this.bool_0, this.bool_1, false, false, 0);
					}
					catch (Exception exception5)
					{
						Exception exception4 = exception5;
						if (this.Log)
						{
							SpiderException.Debug(Localization.Get("批量生成"), exception4.Message);
						}
						else
						{
							MessageBox.Show(exception4.Message);
						}
					}
					num++;
				}
			}
		}

		private void backgroundWorker_0_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			switch (e.ProgressPercentage)
			{
				case 0:
				{
					this.label_5.Text = e.UserState.ToString();
					break;
				}
				case 1:
				{
					this.label_4.Text = e.UserState.ToString();
					break;
				}
				case 2:
				{
					this.label_3.Text = e.UserState.ToString();
					break;
				}
				case 3:
				{
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
					int num2 = Convert.ToInt32(e.UserState);
					if (num2 <= 0)
					{
						break;
					}
					this.progressBar_1.Maximum = num2;
					break;
				}
				case 6:
				{
					int num3 = Convert.ToInt32(e.UserState);
					if (num3 <= 0)
					{
						break;
					}
					this.progressBar_0.Maximum = num3;
					break;
				}
			}
		}

		private void backgroundWorker_0_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (e.Error != null)
			{
				this.label_3.Text = string.Concat(Localization.Get("错误提示："), e.Error.Message);
				this.button_1.Enabled = true;
				this.groupBox_0.Enabled = true;
				this.button_0.Enabled = false;
			}
			else if (!e.Cancelled)
			{
				this.label_3.Text = Localization.Get("操作完成");
				if (!this.Timing)
				{
					this.label_3.Text = Localization.Get("操作完成");
					this.groupBox_0.Enabled = true;
					this.button_1.Enabled = true;
					this.button_0.Enabled = false;
				}
				else
				{
					this.timer_0.Start();
					DateTime now = DateTime.Now;
					this.dateTime_0 = now.AddMinutes((double)this.m_Interval);
				}
			}
			else
			{
				this.label_3.Text = Localization.Get("操作取消");
				this.button_1.Enabled = true;
				this.groupBox_0.Enabled = true;
				this.button_0.Enabled = false;
			}
		}

		private void button_0_Click(object sender, EventArgs e)
		{
			if (this.backgroundWorker_0.IsBusy)
			{
				this.button_0.Enabled = false;
				this.backgroundWorker_0.CancelAsync();
				this.timer_0.Stop();
			}
		}

		private void button_1_Click(object sender, EventArgs e)
		{
			if (this.textBox_0.Text == "")
			{
				MessageBox.Show(Localization.Get("请输入自定义SQL，选择单本或批量方式的请先生成自定义SQL。"));
			}
			else if (!this.backgroundWorker_0.IsBusy)
			{
				this.button_1.Enabled = false;
				this.groupBox_0.Enabled = false;
				this.button_0.Enabled = true;
				this.IndexHtml = this.checkBox_7.Checked;
				this.ChapterHtml = this.checkBox_6.Checked;
				this.FullHtml = this.checkBox_5.Checked;
				this.bool_0 = true;
				this.bool_1 = this.checkBox_3.Checked;
				this.CmdText = this.textBox_0.Text;
				DateTime now = DateTime.Now;
				this.dateTime_0 = now.AddMinutes((double)this.m_Interval);
				this.backgroundWorker_0.RunWorkerAsync();
			}
		}

		private void button_2_Click(object sender, EventArgs e)
		{
			string[] shortDateString;
			DateTime today;
			if (Configs.CmsName == "Qiwen")
			{
				TextBox textBox0 = this.textBox_0;
				shortDateString = new string[] { "SELECT * FROM [Ws_BookList] WHERE bookupdatetime BETWEEN '", null, null, null, null };
				today = DateTime.Today;
				shortDateString[1] = today.ToShortDateString();
				shortDateString[2] = "' AND '";
				today = DateTime.Today.AddDays(1);
				shortDateString[3] = today.ToShortDateString();
				shortDateString[4] = "' ORDER BY bookupdatetime ASC";
				textBox0.Text = string.Concat(shortDateString);
			}
			else if (Configs.CmsName == "Jieqi")
			{
				TextBox textBox = this.textBox_0;
				shortDateString = new string[] { "SELECT * FROM `jieqi_article_article` WHERE `lastupdate` BETWEEN '", null, null, null, null };
				int time = FormatText.GetTime(DateTime.Today);
				shortDateString[1] = time.ToString();
				shortDateString[2] = "' AND '";
				today = DateTime.Today;
				time = FormatText.GetTime(today.AddDays(1));
				shortDateString[3] = time.ToString();
				shortDateString[4] = "' ORDER BY `lastupdate` ASC";
				textBox.Text = string.Concat(shortDateString);
			}
			else if (Configs.CmsName != "Cnend")
			{
				this.textBox_0.Text = Localization.Get("请输入SQL语句");
			}
			else
			{
				TextBox textBox01 = this.textBox_0;
				shortDateString = new string[] { "SELECT * FROM [list_book] WHERE list_gxdate BETWEEN ", null, null, null, null };
				decimal value = this.numericUpDown_1.Value;
				shortDateString[1] = value.ToString();
				shortDateString[2] = " AND ";
				value = this.numericUpDown_0.Value;
				shortDateString[3] = value.ToString();
				shortDateString[4] = " ORDER BY list_gxdate ASC";
				textBox01.Text = string.Concat(shortDateString);
			}
		}

		private void button_3_Click(object sender, EventArgs e)
		{
			string[] str;
			decimal value;
			if (Configs.CmsName == "Qiwen")
			{
				TextBox textBox0 = this.textBox_0;
				str = new string[] { "SELECT * FROM [Ws_BookList] WHERE id BETWEEN ", null, null, null, null };
				value = this.numericUpDown_1.Value;
				str[1] = value.ToString();
				str[2] = " AND ";
				value = this.numericUpDown_0.Value;
				str[3] = value.ToString();
				str[4] = " ORDER BY id ASC";
				textBox0.Text = string.Concat(str);
			}
			else if (Configs.CmsName == "Jieqi")
			{
				TextBox textBox = this.textBox_0;
				str = new string[] { "SELECT * FROM `jieqi_article_article` WHERE `articleid` BETWEEN '", null, null, null, null };
				value = this.numericUpDown_1.Value;
				str[1] = value.ToString();
				str[2] = "' AND '";
				value = this.numericUpDown_0.Value;
				str[3] = value.ToString();
				str[4] = "' ORDER BY `articleid` ASC";
				textBox.Text = string.Concat(str);
			}
			else if (Configs.CmsName != "Cnend")
			{
				this.textBox_0.Text = Localization.Get("请输入SQL语句");
			}
			else
			{
				TextBox textBox01 = this.textBox_0;
				str = new string[] { "SELECT * FROM [list_book] WHERE id BETWEEN ", null, null, null, null };
				value = this.numericUpDown_1.Value;
				str[1] = value.ToString();
				str[2] = " AND ";
				value = this.numericUpDown_0.Value;
				str[3] = value.ToString();
				str[4] = " ORDER BY id ASC";
				textBox01.Text = string.Concat(str);
			}
		}

		private void button_4_Click(object sender, EventArgs e)
		{
			decimal value;
			if (Configs.CmsName == "Qiwen")
			{
				TextBox textBox0 = this.textBox_0;
				value = this.numericUpDown_2.Value;
				textBox0.Text = string.Concat("SELECT TOP 1 * FROM [Ws_BookList] WHERE id = ", value.ToString());
			}
			else if (Configs.CmsName == "Jieqi")
			{
				TextBox textBox = this.textBox_0;
				value = this.numericUpDown_2.Value;
				textBox.Text = string.Concat("SELECT * FROM `jieqi_article_article` WHERE `articleid` = '", value.ToString(), "'");
			}
			else if (Configs.CmsName != "Cnend")
			{
				this.textBox_0.Text = Localization.Get("请输入SQL语句");
			}
			else
			{
				TextBox textBox01 = this.textBox_0;
				value = this.numericUpDown_2.Value;
				textBox01.Text = string.Concat("SELECT TOP 1 * FROM [list_book] WHERE id = ", value.ToString());
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (Configs.CmsName == "Qiwen")
			{
				this.textBox_0.Text = string.Concat("SELECT TOP 1 * FROM [Ws_BookList] WHERE id in (", this.textBox1.Text.ToString(), ")");
			}
			else if (Configs.CmsName != "Jieqi")
			{
				this.textBox_0.Text = Localization.Get("请输入SQL语句");
			}
			else
			{
				this.textBox_0.Text = string.Concat("SELECT * FROM `jieqi_article_article` WHERE `articleid` in (", this.textBox1.Text.ToString(), ")");
			}
		}

		private void checkBox_8_CheckedChanged(object sender, EventArgs e)
		{
			if (!this.checkBox_8.Checked)
			{
				this.Log = true;
			}
			else
			{
				this.Log = false;
			}
		}

		private void checkBox_9_CheckedChanged(object sender, EventArgs e)
		{
			if (!this.checkBox_9.Checked)
			{
				this.Timing = false;
			}
			else
			{
				this.Timing = true;
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

		private void HelpBatchCreate_Load(object sender, EventArgs e)
		{
		}

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(HelpBatchCreate));
			this.groupBox_0 = new GroupBox();
			this.label2 = new Label();
			this.button1 = new Button();
			this.textBox1 = new TextBox();
			this.label1 = new Label();
			this.label_11 = new Label();
			this.checkBox_6 = new CheckBox();
			this.checkBox_7 = new CheckBox();
			this.button_2 = new Button();
			this.checkBox_5 = new CheckBox();
			this.button_3 = new Button();
			this.button_4 = new Button();
			this.label_0 = new Label();
			this.label_1 = new Label();
			this.label_2 = new Label();
			this.checkBox_3 = new CheckBox();
			this.numericUpDown_0 = new NumericUpDown();
			this.numericUpDown_1 = new NumericUpDown();
			this.numericUpDown_2 = new NumericUpDown();
			this.textBox_0 = new TextBox();
			this.button_0 = new Button();
			this.button_1 = new Button();
			this.groupBox_1 = new GroupBox();
			this.label_13 = new Label();
			this.numericUpDown_3 = new NumericUpDown();
			this.checkBox_9 = new CheckBox();
			this.checkBox_8 = new CheckBox();
			this.label_3 = new Label();
			this.label_4 = new Label();
			this.label_5 = new Label();
			this.label_6 = new Label();
			this.label_7 = new Label();
			this.label_8 = new Label();
			this.progressBar_0 = new ProgressBar();
			this.label_9 = new Label();
			this.label_10 = new Label();
			this.progressBar_1 = new ProgressBar();
			this.backgroundWorker_0 = new BackgroundWorker();
			this.timer_0 = new Timer(this.components);
			this.groupBox_0.SuspendLayout();
			((ISupportInitialize)this.numericUpDown_0).BeginInit();
			((ISupportInitialize)this.numericUpDown_1).BeginInit();
			((ISupportInitialize)this.numericUpDown_2).BeginInit();
			this.groupBox_1.SuspendLayout();
			((ISupportInitialize)this.numericUpDown_3).BeginInit();
			base.SuspendLayout();
			this.groupBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.groupBox_0.Controls.Add(this.label2);
			this.groupBox_0.Controls.Add(this.button1);
			this.groupBox_0.Controls.Add(this.textBox1);
			this.groupBox_0.Controls.Add(this.label1);
			this.groupBox_0.Controls.Add(this.label_11);
			this.groupBox_0.Controls.Add(this.checkBox_6);
			this.groupBox_0.Controls.Add(this.checkBox_7);
			this.groupBox_0.Controls.Add(this.button_2);
			this.groupBox_0.Controls.Add(this.checkBox_5);
			this.groupBox_0.Controls.Add(this.button_3);
			this.groupBox_0.Controls.Add(this.button_4);
			this.groupBox_0.Controls.Add(this.label_0);
			this.groupBox_0.Controls.Add(this.label_1);
			this.groupBox_0.Controls.Add(this.label_2);
			this.groupBox_0.Controls.Add(this.checkBox_3);
			this.groupBox_0.Controls.Add(this.numericUpDown_0);
			this.groupBox_0.Controls.Add(this.numericUpDown_1);
			this.groupBox_0.Controls.Add(this.numericUpDown_2);
			this.groupBox_0.Controls.Add(this.textBox_0);
			this.groupBox_0.Location = new Point(12, 12);
			this.groupBox_0.Name = "groupBox_0";
			this.groupBox_0.Size = new System.Drawing.Size(555, 202);
			this.groupBox_0.TabIndex = 0;
			this.groupBox_0.TabStop = false;
			this.groupBox_0.Text = Localization.Get("生成设置");
			this.label2.AutoSize = true;
			this.label2.ForeColor = Color.Blue;
			this.label2.Location = new Point(6, 177);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(287, 12);
			this.label2.TabIndex = 22;
			this.label2.Text = Localization.Get("请先“生成自定义SQL”，再开始执行批量生成任务。");
			this.button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.button1.Location = new Point(424, 73);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(111, 21);
			this.button1.TabIndex = 21;
			this.button1.Text = Localization.Get("生成自定义SQL");
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new EventHandler(this.button1_Click);
			this.textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.textBox1.Location = new Point(111, 73);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(307, 21);
			this.textBox1.TabIndex = 20;
			this.label1.AutoSize = true;
			this.label1.Location = new Point(7, 76);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(107, 12);
			this.label1.TabIndex = 19;
			this.label1.Text = Localization.Get("自定义ID(,分割)：");
			this.label_11.AutoSize = true;
			this.label_11.Font = new System.Drawing.Font(Localization.Font, 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
			this.label_11.ForeColor = Color.Blue;
			this.label_11.Location = new Point(6, 155);
			this.label_11.Name = "label_11";
			this.label_11.Size = new System.Drawing.Size(419, 12);
			this.label_11.TabIndex = 18;
			this.label_11.Text = Localization.Get("批量生成最终是按“自定义SQL”执行，选择“单本ID”或“批量ID”方式的。");
			this.checkBox_6.AutoSize = true;
			this.checkBox_6.Checked = true;
			this.checkBox_6.CheckState = CheckState.Checked;
			this.checkBox_6.Location = new Point(111, 130);
			this.checkBox_6.Name = "checkBox_6";
			this.checkBox_6.Size = new System.Drawing.Size(96, 16);
			this.checkBox_6.TabIndex = 5;
			this.checkBox_6.Text = Localization.Get("章节内容HTML");
			this.checkBox_6.UseVisualStyleBackColor = true;
			this.checkBox_7.AutoSize = true;
			this.checkBox_7.Checked = true;
			this.checkBox_7.CheckState = CheckState.Checked;
			this.checkBox_7.Location = new Point(9, 130);
			this.checkBox_7.Name = "checkBox_7";
			this.checkBox_7.Size = new System.Drawing.Size(96, 16);
			this.checkBox_7.TabIndex = 4;
			this.checkBox_7.Text = Localization.Get("章节目录HTML");
			this.checkBox_7.UseVisualStyleBackColor = true;
			this.button_2.Location = new Point(341, 20);
			this.button_2.Name = "button_2";
			this.button_2.Size = new System.Drawing.Size(120, 21);
			this.button_2.TabIndex = 17;
			this.button_2.Text = Localization.Get("今日更新书籍SQL");
			this.button_2.UseVisualStyleBackColor = true;
			this.button_2.Click += new EventHandler(this.button_2_Click);
			this.checkBox_5.AutoSize = true;
			this.checkBox_5.Location = new Point(213, 130);
			this.checkBox_5.Name = "checkBox_5";
			this.checkBox_5.Size = new System.Drawing.Size(96, 16);
			this.checkBox_5.TabIndex = 6;
			this.checkBox_5.Text = Localization.Get("全文阅读HTML");
			this.checkBox_5.UseVisualStyleBackColor = true;
			this.button_3.Location = new Point(341, 47);
			this.button_3.Name = "button_3";
			this.button_3.Size = new System.Drawing.Size(120, 21);
			this.button_3.TabIndex = 16;
			this.button_3.Text = Localization.Get("生成自定义SQL");
			this.button_3.UseVisualStyleBackColor = true;
			this.button_3.Click += new EventHandler(this.button_3_Click);
			this.button_4.Location = new Point(215, 20);
			this.button_4.Name = "button_4";
			this.button_4.Size = new System.Drawing.Size(120, 21);
			this.button_4.TabIndex = 15;
			this.button_4.Text = Localization.Get("生成自定义SQL");
			this.button_4.UseVisualStyleBackColor = true;
			this.button_4.Click += new EventHandler(this.button_4_Click);
			this.label_0.AutoSize = true;
			this.label_0.Location = new Point(7, 103);
			this.label_0.Name = "label_0";
			this.label_0.Size = new System.Drawing.Size(77, 12);
			this.label_0.TabIndex = 14;
			this.label_0.Text = Localization.Get("自定义SQL ：");
			this.label_1.AutoSize = true;
			this.label_1.Location = new Point(7, 49);
			this.label_1.Name = "label_1";
			this.label_1.Size = new System.Drawing.Size(77, 12);
			this.label_1.TabIndex = 13;
			this.label_1.Text = Localization.Get("批量生成ID：");
			this.label_2.AutoSize = true;
			this.label_2.Location = new Point(6, 22);
			this.label_2.Name = "label_2";
			this.label_2.Size = new System.Drawing.Size(77, 12);
			this.label_2.TabIndex = 12;
			this.label_2.Text = Localization.Get("单本生成ID：");
			this.checkBox_3.AutoSize = true;
			this.checkBox_3.Location = new Point(315, 130);
			this.checkBox_3.Name = "checkBox_3";
			this.checkBox_3.Size = new System.Drawing.Size(114, 16);
			this.checkBox_3.TabIndex = 8;
			this.checkBox_3.Text = Localization.Get("TXT下载全文阅读");
			this.checkBox_3.UseVisualStyleBackColor = true;
			this.numericUpDown_0.Location = new Point(215, 47);
			NumericUpDown numericUpDown0 = this.numericUpDown_0;
			int[] numArray = new int[] { 1000000, 0, 0, 0 };
			numericUpDown0.Maximum = new decimal(numArray);
			this.numericUpDown_0.Name = "numericUpDown_0";
			this.numericUpDown_0.Size = new System.Drawing.Size(120, 21);
			this.numericUpDown_0.TabIndex = 3;
			this.numericUpDown_1.Location = new Point(89, 47);
			NumericUpDown numericUpDown1 = this.numericUpDown_1;
			numArray = new int[] { 1000000, 0, 0, 0 };
			numericUpDown1.Maximum = new decimal(numArray);
			this.numericUpDown_1.Name = "numericUpDown_1";
			this.numericUpDown_1.Size = new System.Drawing.Size(120, 21);
			this.numericUpDown_1.TabIndex = 2;
			this.numericUpDown_2.Location = new Point(89, 20);
			NumericUpDown numericUpDown2 = this.numericUpDown_2;
			numArray = new int[] { 1000000, 0, 0, 0 };
			numericUpDown2.Maximum = new decimal(numArray);
			this.numericUpDown_2.Name = "numericUpDown_2";
			this.numericUpDown_2.Size = new System.Drawing.Size(120, 21);
			this.numericUpDown_2.TabIndex = 1;
			this.textBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.textBox_0.Location = new Point(89, 100);
			this.textBox_0.Name = "textBox_0";
			this.textBox_0.Size = new System.Drawing.Size(455, 21);
			this.textBox_0.TabIndex = 0;
			this.button_0.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.button_0.Location = new Point(469, 98);
			this.button_0.Name = "button_0";
			this.button_0.Size = new System.Drawing.Size(75, 21);
			this.button_0.TabIndex = 19;
			this.button_0.Text = Localization.Get("停止");
			this.button_0.UseVisualStyleBackColor = true;
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.button_1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.button_1.Location = new Point(388, 99);
			this.button_1.Name = "button_1";
			this.button_1.Size = new System.Drawing.Size(75, 21);
			this.button_1.TabIndex = 18;
			this.button_1.Text = Localization.Get("开始");
			this.button_1.UseVisualStyleBackColor = true;
			this.button_1.Click += new EventHandler(this.button_1_Click);
			this.groupBox_1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.groupBox_1.Controls.Add(this.label_13);
			this.groupBox_1.Controls.Add(this.numericUpDown_3);
			this.groupBox_1.Controls.Add(this.checkBox_9);
			this.groupBox_1.Controls.Add(this.checkBox_8);
			this.groupBox_1.Controls.Add(this.button_0);
			this.groupBox_1.Controls.Add(this.label_3);
			this.groupBox_1.Controls.Add(this.label_4);
			this.groupBox_1.Controls.Add(this.button_1);
			this.groupBox_1.Controls.Add(this.label_5);
			this.groupBox_1.Controls.Add(this.label_6);
			this.groupBox_1.Controls.Add(this.label_7);
			this.groupBox_1.Controls.Add(this.label_8);
			this.groupBox_1.Controls.Add(this.progressBar_0);
			this.groupBox_1.Controls.Add(this.label_9);
			this.groupBox_1.Controls.Add(this.label_10);
			this.groupBox_1.Controls.Add(this.progressBar_1);
			this.groupBox_1.Location = new Point(12, 220);
			this.groupBox_1.Name = "groupBox_1";
			this.groupBox_1.Size = new System.Drawing.Size(555, 140);
			this.groupBox_1.TabIndex = 4;
			this.groupBox_1.TabStop = false;
			this.groupBox_1.Text = Localization.Get("生成进度");
			this.label_13.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.label_13.AutoSize = true;
			this.label_13.Location = new Point(515, 65);
			this.label_13.Name = "label_13";
			this.label_13.Size = new System.Drawing.Size(29, 12);
			this.label_13.TabIndex = 23;
			this.label_13.Text = Localization.Get("分钟");
			this.numericUpDown_3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.numericUpDown_3.Location = new Point(459, 63);
			NumericUpDown numericUpDown3 = this.numericUpDown_3;
			numArray = new int[] { 10000, 0, 0, 0 };
			numericUpDown3.Maximum = new decimal(numArray);
			this.numericUpDown_3.Name = "numericUpDown_3";
			this.numericUpDown_3.Size = new System.Drawing.Size(50, 21);
			this.numericUpDown_3.TabIndex = 22;
			this.numericUpDown_3.ValueChanged += new EventHandler(this.numericUpDown_3_ValueChanged);
			this.checkBox_9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.checkBox_9.AutoSize = true;
			this.checkBox_9.Location = new Point(351, 64);
			this.checkBox_9.Name = "checkBox_9";
			this.checkBox_9.Size = new System.Drawing.Size(102, 16);
			this.checkBox_9.TabIndex = 21;
			this.checkBox_9.Text = Localization.Get("定时采集 间隔");
			this.checkBox_9.UseVisualStyleBackColor = true;
			this.checkBox_9.CheckedChanged += new EventHandler(this.checkBox_9_CheckedChanged);
			this.checkBox_8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.checkBox_8.AutoSize = true;
			this.checkBox_8.Checked = true;
			this.checkBox_8.CheckState = CheckState.Checked;
			this.checkBox_8.Location = new Point(249, 64);
			this.checkBox_8.Name = "checkBox_8";
			this.checkBox_8.Size = new System.Drawing.Size(96, 16);
			this.checkBox_8.TabIndex = 20;
			this.checkBox_8.Text = Localization.Get("弹出异常提示");
			this.checkBox_8.UseVisualStyleBackColor = true;
			this.checkBox_8.CheckedChanged += new EventHandler(this.checkBox_8_CheckedChanged);
			this.label_3.AutoSize = true;
			this.label_3.Location = new Point(89, 108);
			this.label_3.Name = "label_3";
			this.label_3.Size = new System.Drawing.Size(17, 12);
			this.label_3.TabIndex = 16;
			this.label_3.Text = "--";
			this.label_4.AutoSize = true;
			this.label_4.Location = new Point(89, 86);
			this.label_4.Name = "label_4";
			this.label_4.Size = new System.Drawing.Size(17, 12);
			this.label_4.TabIndex = 15;
			this.label_4.Text = "--";
			this.label_5.AutoSize = true;
			this.label_5.Location = new Point(89, 64);
			this.label_5.Name = "label_5";
			this.label_5.Size = new System.Drawing.Size(17, 12);
			this.label_5.TabIndex = 14;
			this.label_5.Text = "--";
			this.label_6.AutoSize = true;
			this.label_6.Location = new Point(18, 107);
			this.label_6.Name = "label_6";
			this.label_6.Size = new System.Drawing.Size(65, 12);
			this.label_6.TabIndex = 13;
			this.label_6.Text = Localization.Get("当前动作：");
			this.label_7.AutoSize = true;
			this.label_7.Location = new Point(18, 86);
			this.label_7.Name = "label_7";
			this.label_7.Size = new System.Drawing.Size(65, 12);
			this.label_7.TabIndex = 12;
			this.label_7.Text = Localization.Get("当前章节：");
			this.label_8.AutoSize = true;
			this.label_8.Location = new Point(18, 64);
			this.label_8.Name = "label_8";
			this.label_8.Size = new System.Drawing.Size(65, 12);
			this.label_8.TabIndex = 11;
			this.label_8.Text = Localization.Get("当前小说：");
			this.progressBar_0.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.progressBar_0.Location = new Point(89, 43);
			this.progressBar_0.Name = "progressBar_0";
			this.progressBar_0.Size = new System.Drawing.Size(455, 12);
			this.progressBar_0.TabIndex = 10;
			this.label_9.AutoSize = true;
			this.label_9.Location = new Point(19, 43);
			this.label_9.Name = "label_9";
			this.label_9.Size = new System.Drawing.Size(65, 12);
			this.label_9.TabIndex = 9;
			this.label_9.Text = Localization.Get("章节进度：");
			this.label_10.AutoSize = true;
			this.label_10.Location = new Point(18, 20);
			this.label_10.Name = "label_10";
			this.label_10.Size = new System.Drawing.Size(65, 12);
			this.label_10.TabIndex = 8;
			this.label_10.Text = Localization.Get("小说进度：");
			this.progressBar_1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.progressBar_1.Location = new Point(89, 20);
			this.progressBar_1.Name = "progressBar_1";
			this.progressBar_1.Size = new System.Drawing.Size(455, 12);
			this.progressBar_1.TabIndex = 7;
			this.backgroundWorker_0.WorkerReportsProgress = true;
			this.backgroundWorker_0.WorkerSupportsCancellation = true;
			this.backgroundWorker_0.DoWork += new DoWorkEventHandler(this.backgroundWorker_0_DoWork);
			this.backgroundWorker_0.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker_0_RunWorkerCompleted);
			this.backgroundWorker_0.ProgressChanged += new ProgressChangedEventHandler(this.backgroundWorker_0_ProgressChanged);
			this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
			base.ClientSize = new System.Drawing.Size(579, 372);
			base.Controls.Add(this.groupBox_1);
			base.Controls.Add(this.groupBox_0);
			this.Font = new System.Drawing.Font(Localization.Font, 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
			base.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "HelpBatchCreate";
			this.Text = Localization.Get("批量生成");
			base.Load += new EventHandler(this.HelpBatchCreate_Load);
			this.groupBox_0.ResumeLayout(false);
			this.groupBox_0.PerformLayout();
			((ISupportInitialize)this.numericUpDown_0).EndInit();
			((ISupportInitialize)this.numericUpDown_1).EndInit();
			((ISupportInitialize)this.numericUpDown_2).EndInit();
			this.groupBox_1.ResumeLayout(false);
			this.groupBox_1.PerformLayout();
			((ISupportInitialize)this.numericUpDown_3).EndInit();
			base.ResumeLayout(false);
		}

		private void numericUpDown_3_ValueChanged(object sender, EventArgs e)
		{
			this.m_Interval = Convert.ToInt32(this.numericUpDown_3.Value);
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
					Label label3 = this.label_3;
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
					label3.Text = string.Concat(str);
				}
				else
				{
					now = DateTime.Now;
					this.dateTime_0 = now.AddMinutes((double)this.m_Interval);
					this.backgroundWorker_0.RunWorkerAsync();
					this.timer_0.Stop();
				}
			}
		}
	}
}