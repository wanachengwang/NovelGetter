using NovelSpider.Common;
using NovelSpider.Config;
using NovelSpider.Entity;
using NovelSpider.Local;
using NovelSpider.Target;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Threading;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace NovelSpider
{
	public class HelpUpdateNovel : DockContent
	{
		private BackgroundWorker backgroundWorker_0;

		public bool BAuthor;

		public bool BCover;

		public bool BDegree;

		public bool BIntro;

		public bool BKeyword;

		public bool bool_0;

		public bool bool_1;

		private Button button_0;

		private Button button_1;

		private RadioButton BymeRad;

		private CheckBox checkBox_0;

		private CheckBox checkBox_1;

		private CheckBox checkBox_2;

		private CheckBox checkBox_3;

		private CheckBox checkBox_4;

		private CheckBox checkBox_5;

		private CheckBox checkBox_6;

		private ComboBox comboBox_0;

		private GroupBox groupBox_0;

		private GroupBox groupBox_1;

		private IContainer icontainer_0;

		private Label label_0;

		private Label label_1;

		private Label label1;

		public int MaxID;

		private TextBox memaxid;

		public int memaxID;

		private TextBox meminid;

		public int meminID;

		public int MinID;

		private NumericUpDown numericUpDown1;

		private RadioButton radioButton_0;

		public RuleConfigInfo rInfo;

		private TextBox textBox_0;

		private TextBox textBox_1;

		public TaskConfigInfo tInfo;

		public HelpUpdateNovel()
		{
			Class19.Q77LubhzKM3NS();
			this.rInfo = new RuleConfigInfo();
			this.tInfo = new TaskConfigInfo();
			this.InitializeComponent();
		}

		private void backgroundWorker_0_DoWork(object sender, DoWorkEventArgs e)
		{
			bool flag = false;
			if (this.BymeRad.Checked)
			{
				this.MinID = this.meminID;
				this.MaxID = this.memaxID;
				flag = true;
			}
			int minID = this.MinID;
			while (minID <= this.MaxID)
			{
				if (this.backgroundWorker_0.CancellationPending)
				{
					e.Cancel = true;
					break;
				}
				else
				{
					NovelInfo novelInfo = new NovelInfo();
					if (!flag)
					{
						novelInfo.GetID = minID.ToString();
					}
					else
					{
						Thread.Sleep(Convert.ToInt32(this.numericUpDown1.Value) * 1000);
						NovelInfo novelInfo1 = new NovelInfo()
						{
							PutID = minID
						};
						try
						{
							SpiderException.Debug(Localization.Get("开始按本站ID获取信息并搜索目标站"));
							Page page = new Page(this.rInfo, this.tInfo);
							novelInfo1 = LocalProvider.GetInstance().GetNovelInfo(novelInfo1, this.tInfo.NameAndAuthor);
							novelInfo1 = page.GetNovelInfo(novelInfo1);
							novelInfo.GetID = novelInfo1.GetID;
						}
						catch (Exception exception1)
						{
							Exception exception = exception1;
							object[] putID = new object[] { Localization.Get("根据本站ID:"), novelInfo1.PutID, Localization.Get("获取目标站ID时错误,请确认规则支持搜索 | "), exception.Message };
							SpiderException.Show(string.Concat(putID), true);
							this.backgroundWorker_0.ReportProgress(0, string.Concat(novelInfo1.PutID, " | ", exception.Message));
						}
					}
					try
					{
						this.backgroundWorker_0.ReportProgress(0, novelInfo.GetID);
						Page page1 = new Page(this.rInfo, this.tInfo);
						SpiderException.Debug(Localization.Get("开始按目标站ID获取小说信息"));
						novelInfo = page1.GetNovelInfo(novelInfo);
						this.backgroundWorker_0.ReportProgress(0, string.Concat(novelInfo.GetID, " | ", novelInfo.Name));
						if (!this.BCover)
						{
							novelInfo.Cover = null;
						}
						SpiderException.Debug(Localization.Get("更新小说信息完成!"));
						LocalProvider.GetInstance().UpdateNovel(novelInfo, this.BAuthor, this.BIntro, this.BDegree, this.bool_0, this.bool_1, this.BCover, this.BKeyword);
					}
					catch (Exception exception3)
					{
						Exception exception2 = exception3;
						SpiderException.Show(string.Concat(Localization.Get("更新小说信息："), novelInfo.GetID, " | ", exception2.Message), true);
						this.backgroundWorker_0.ReportProgress(0, string.Concat(novelInfo.GetID, " | ", exception2.Message));
					}
					minID++;
				}
			}
		}

		private void backgroundWorker_0_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			this.label_0.Text = e.UserState.ToString();
		}

		private void backgroundWorker_0_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (e.Error != null)
			{
				MessageBox.Show(e.Error.Message, Localization.Get("错误提示"));
			}
			else if (!e.Cancelled)
			{
				MessageBox.Show(Localization.Get("操作完成"), Localization.Get("信息提示"));
			}
			else
			{
				MessageBox.Show(Localization.Get("操作取消"), Localization.Get("信息提示"));
			}
			this.button_0.Enabled = false;
			this.button_1.Enabled = true;
			this.groupBox_1.Enabled = true;
		}

		private void button_0_Click(object sender, EventArgs e)
		{
			this.button_0.Enabled = false;
			if (this.backgroundWorker_0.IsBusy)
			{
				this.backgroundWorker_0.CancelAsync();
			}
		}

		private void button_1_Click(object sender, EventArgs e)
		{
			this.rInfo = (RuleConfigInfo)ConfigFileManager.LoadConfig(this.comboBox_0.Text, this.rInfo);
			this.BAuthor = this.checkBox_0.Checked;
			this.BIntro = this.checkBox_4.Checked;
			this.BDegree = this.checkBox_3.Checked;
			this.bool_0 = this.checkBox_1.Checked;
			this.bool_1 = this.checkBox_2.Checked;
			this.BCover = this.checkBox_6.Checked;
			this.BKeyword = this.checkBox_5.Checked;
			this.MinID = int.Parse(this.textBox_1.Text);
			this.MaxID = int.Parse(this.textBox_0.Text);
			this.meminID = int.Parse(this.meminid.Text);
			this.memaxID = int.Parse(this.memaxid.Text);
			this.button_0.Enabled = true;
			this.button_1.Enabled = false;
			this.groupBox_1.Enabled = false;
			this.backgroundWorker_0.RunWorkerAsync();
		}

		protected override void Dispose(bool disposing)
		{
			if ((!disposing ? false : this.icontainer_0 != null))
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		private void HelpUpdateNovel_Load(object sender, EventArgs e)
		{
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
					}
				}
			}
			this.comboBox_0.EndUpdate();
		}

		private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(HelpUpdateNovel));
			this.checkBox_0 = new CheckBox();
			this.checkBox_1 = new CheckBox();
			this.checkBox_2 = new CheckBox();
			this.checkBox_3 = new CheckBox();
			this.checkBox_4 = new CheckBox();
			this.checkBox_5 = new CheckBox();
			this.checkBox_6 = new CheckBox();
			this.textBox_0 = new TextBox();
			this.textBox_1 = new TextBox();
			this.radioButton_0 = new RadioButton();
			this.groupBox_0 = new GroupBox();
			this.label_0 = new Label();
			this.label_1 = new Label();
			this.button_0 = new Button();
			this.button_1 = new Button();
			this.groupBox_1 = new GroupBox();
			this.numericUpDown1 = new NumericUpDown();
			this.label1 = new Label();
			this.comboBox_0 = new ComboBox();
			this.BymeRad = new RadioButton();
			this.memaxid = new TextBox();
			this.meminid = new TextBox();
			this.backgroundWorker_0 = new BackgroundWorker();
			this.groupBox_0.SuspendLayout();
			this.groupBox_1.SuspendLayout();
			((ISupportInitialize)this.numericUpDown1).BeginInit();
			base.SuspendLayout();
			this.checkBox_0.AutoSize = true;
			this.checkBox_0.Location = new Point(7, 144);
			this.checkBox_0.Name = "checkBox_0";
			this.checkBox_0.Size = new System.Drawing.Size(48, 16);
			this.checkBox_0.TabIndex = 0;
			this.checkBox_0.Text = Localization.Get("作者");
			this.checkBox_0.UseVisualStyleBackColor = true;
			this.checkBox_1.AutoSize = true;
			this.checkBox_1.Location = new Point(61, 144);
			this.checkBox_1.Name = "checkBox_1";
			this.checkBox_1.Size = new System.Drawing.Size(48, 16);
			this.checkBox_1.TabIndex = 1;
			this.checkBox_1.Text = Localization.Get("大类");
			this.checkBox_1.UseVisualStyleBackColor = true;
			this.checkBox_2.AutoSize = true;
			this.checkBox_2.Location = new Point(115, 144);
			this.checkBox_2.Name = "checkBox_2";
			this.checkBox_2.Size = new System.Drawing.Size(48, 16);
			this.checkBox_2.TabIndex = 2;
			this.checkBox_2.Text = Localization.Get("小类");
			this.checkBox_2.UseVisualStyleBackColor = true;
			this.checkBox_3.AutoSize = true;
			this.checkBox_3.Checked = true;
			this.checkBox_3.CheckState = CheckState.Checked;
			this.checkBox_3.Location = new Point(7, 166);
			this.checkBox_3.Name = "checkBox_3";
			this.checkBox_3.Size = new System.Drawing.Size(72, 16);
			this.checkBox_3.TabIndex = 3;
			this.checkBox_3.Text = Localization.Get("写作进程");
			this.checkBox_3.UseVisualStyleBackColor = true;
			this.checkBox_4.AutoSize = true;
			this.checkBox_4.Location = new Point(85, 166);
			this.checkBox_4.Name = "checkBox_4";
			this.checkBox_4.Size = new System.Drawing.Size(72, 16);
			this.checkBox_4.TabIndex = 4;
			this.checkBox_4.Text = Localization.Get("内容简介");
			this.checkBox_4.UseVisualStyleBackColor = true;
			this.checkBox_5.AutoSize = true;
			this.checkBox_5.Location = new Point(163, 166);
			this.checkBox_5.Name = "checkBox_5";
			this.checkBox_5.Size = new System.Drawing.Size(96, 16);
			this.checkBox_5.TabIndex = 5;
			this.checkBox_5.Text = Localization.Get("关键词(主角)");
			this.checkBox_5.UseVisualStyleBackColor = true;
			this.checkBox_6.AutoSize = true;
			this.checkBox_6.Location = new Point(169, 144);
			this.checkBox_6.Name = "checkBox_6";
			this.checkBox_6.Size = new System.Drawing.Size(48, 16);
			this.checkBox_6.TabIndex = 6;
			this.checkBox_6.Text = Localization.Get("封面");
			this.checkBox_6.UseVisualStyleBackColor = true;
			this.textBox_0.Location = new Point(115, 68);
			this.textBox_0.Name = "textBox_0";
			this.textBox_0.Size = new System.Drawing.Size(104, 21);
			this.textBox_0.TabIndex = 9;
			this.textBox_0.Text = "1";
			this.textBox_1.Location = new Point(9, 68);
			this.textBox_1.Name = "textBox_1";
			this.textBox_1.Size = new System.Drawing.Size(100, 21);
			this.textBox_1.TabIndex = 8;
			this.textBox_1.Text = "1";
			this.radioButton_0.AutoSize = true;
			this.radioButton_0.Checked = true;
			this.radioButton_0.Location = new Point(9, 46);
			this.radioButton_0.Name = "radioButton_0";
			this.radioButton_0.Size = new System.Drawing.Size(119, 16);
			this.radioButton_0.TabIndex = 10;
			this.radioButton_0.TabStop = true;
			this.radioButton_0.Text = Localization.Get("按目标站编号顺序");
			this.radioButton_0.UseVisualStyleBackColor = true;
			this.groupBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.groupBox_0.Controls.Add(this.label_0);
			this.groupBox_0.Controls.Add(this.label_1);
			this.groupBox_0.Location = new Point(12, 210);
			this.groupBox_0.Name = "groupBox_0";
			this.groupBox_0.Size = new System.Drawing.Size(381, 85);
			this.groupBox_0.TabIndex = 11;
			this.groupBox_0.TabStop = false;
			this.groupBox_0.Text = Localization.Get("生成进度");
			this.label_0.AutoSize = true;
			this.label_0.Location = new Point(77, 21);
			this.label_0.Name = "label_0";
			this.label_0.Size = new System.Drawing.Size(17, 12);
			this.label_0.TabIndex = 14;
			this.label_0.Text = "--";
			this.label_1.AutoSize = true;
			this.label_1.Location = new Point(6, 21);
			this.label_1.Name = "label_1";
			this.label_1.Size = new System.Drawing.Size(65, 12);
			this.label_1.TabIndex = 11;
			this.label_1.Text = Localization.Get("当前小说：");
			this.button_0.Anchor = AnchorStyles.Bottom;
			this.button_0.Location = new Point(205, 300);
			this.button_0.Name = "button_0";
			this.button_0.Size = new System.Drawing.Size(75, 21);
			this.button_0.TabIndex = 19;
			this.button_0.Text = Localization.Get("停止");
			this.button_0.UseVisualStyleBackColor = true;
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.button_1.Anchor = AnchorStyles.Bottom;
			this.button_1.Location = new Point(124, 301);
			this.button_1.Name = "button_1";
			this.button_1.Size = new System.Drawing.Size(75, 21);
			this.button_1.TabIndex = 18;
			this.button_1.Text = Localization.Get("开始");
			this.button_1.UseVisualStyleBackColor = true;
			this.button_1.Click += new EventHandler(this.button_1_Click);
			this.groupBox_1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.groupBox_1.Controls.Add(this.numericUpDown1);
			this.groupBox_1.Controls.Add(this.label1);
			this.groupBox_1.Controls.Add(this.comboBox_0);
			this.groupBox_1.Controls.Add(this.BymeRad);
			this.groupBox_1.Controls.Add(this.radioButton_0);
			this.groupBox_1.Controls.Add(this.checkBox_0);
			this.groupBox_1.Controls.Add(this.checkBox_1);
			this.groupBox_1.Controls.Add(this.checkBox_2);
			this.groupBox_1.Controls.Add(this.memaxid);
			this.groupBox_1.Controls.Add(this.checkBox_3);
			this.groupBox_1.Controls.Add(this.textBox_0);
			this.groupBox_1.Controls.Add(this.meminid);
			this.groupBox_1.Controls.Add(this.checkBox_4);
			this.groupBox_1.Controls.Add(this.textBox_1);
			this.groupBox_1.Controls.Add(this.checkBox_5);
			this.groupBox_1.Controls.Add(this.checkBox_6);
			this.groupBox_1.Location = new Point(12, 12);
			this.groupBox_1.Name = "groupBox_1";
			this.groupBox_1.Size = new System.Drawing.Size(381, 192);
			this.groupBox_1.TabIndex = 20;
			this.groupBox_1.TabStop = false;
			this.groupBox_1.Text = Localization.Get("更新设置");
			this.numericUpDown1.Location = new Point(226, 117);
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(102, 21);
			this.numericUpDown1.TabIndex = 33;
			NumericUpDown num = this.numericUpDown1;
			int[] numArray = new int[] { 30, 0, 0, 0 };
			num.Value = new decimal(numArray);
			this.label1.AutoSize = true;
			this.label1.Location = new Point(227, 97);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(101, 12);
			this.label1.TabIndex = 32;
			this.label1.Text = Localization.Get("循环搜索间隔(秒)");
			this.comboBox_0.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_0.FormattingEnabled = true;
			this.comboBox_0.Location = new Point(9, 20);
			this.comboBox_0.Name = "comboBox_0";
			this.comboBox_0.Size = new System.Drawing.Size(210, 20);
			this.comboBox_0.TabIndex = 31;
			this.BymeRad.AutoSize = true;
			this.BymeRad.Checked = true;
			this.BymeRad.Location = new Point(9, 95);
			this.BymeRad.Name = "BymeRad";
			this.BymeRad.Size = new System.Drawing.Size(107, 16);
			this.BymeRad.TabIndex = 10;
			this.BymeRad.TabStop = true;
			this.BymeRad.Text = Localization.Get("按本站编号顺序");
			this.BymeRad.UseVisualStyleBackColor = true;
			this.memaxid.Location = new Point(115, 117);
			this.memaxid.Name = "memaxid";
			this.memaxid.Size = new System.Drawing.Size(104, 21);
			this.memaxid.TabIndex = 9;
			this.memaxid.Text = "1";
			this.meminid.Location = new Point(9, 117);
			this.meminid.Name = "meminid";
			this.meminid.Size = new System.Drawing.Size(100, 21);
			this.meminid.TabIndex = 8;
			this.meminid.Text = "1";
			this.backgroundWorker_0.WorkerReportsProgress = true;
			this.backgroundWorker_0.WorkerSupportsCancellation = true;
			this.backgroundWorker_0.DoWork += new DoWorkEventHandler(this.backgroundWorker_0_DoWork);
			this.backgroundWorker_0.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker_0_RunWorkerCompleted);
			this.backgroundWorker_0.ProgressChanged += new ProgressChangedEventHandler(this.backgroundWorker_0_ProgressChanged);
			base.ClientSize = new System.Drawing.Size(405, 334);
			base.Controls.Add(this.groupBox_1);
			base.Controls.Add(this.button_0);
			base.Controls.Add(this.groupBox_0);
			base.Controls.Add(this.button_1);
			this.Font = new System.Drawing.Font(Localization.Font, 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
			base.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "HelpUpdateNovel";
			this.Text = Localization.Get("更新小说信息");
			base.Load += new EventHandler(this.HelpUpdateNovel_Load);
			this.groupBox_0.ResumeLayout(false);
			this.groupBox_0.PerformLayout();
			this.groupBox_1.ResumeLayout(false);
			this.groupBox_1.PerformLayout();
			((ISupportInitialize)this.numericUpDown1).EndInit();
			base.ResumeLayout(false);
		}
	}
}