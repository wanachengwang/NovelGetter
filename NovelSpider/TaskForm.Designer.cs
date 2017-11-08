using NovelSpider.Common;
using NovelSpider.Config;
using NovelSpider.Entity;
using NovelSpider.Target;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace NovelSpider
{
	public class TaskForm : DockContent
	{
		private TextBox textBox_3;

		private ComboBox comboBox_4;

		private Label label_20;

		private Label label_1;

		private ComboBox comboBox_0;

		private RadioButton radioButton_0;

		private RadioButton radioButton_1;

		private Button button_3;

		private IContainer icontainer_0;

		public RuleConfigInfo rInfo;

		public TaskConfigInfo tInfo;

		private DateTime dateTime_0;

		private string string_2;

		private string string_1;

		private TextBox textBox_4;

		private BackgroundWorker backgroundWorker_0;

		private Label label7;

		private Label label13;

		private bool bool_0;

		public TaskForm()
		{
			Class19.Q77LubhzKM3NS();
			this.string_2 = "";
			this.string_1 = "";
			this.bool_0 = false;
			this.rInfo = new RuleConfigInfo();
			this.tInfo = new TaskConfigInfo();
			this.dateTime_0 = DateTime.Now;
			this.InitializeComponent();
		}

		private void backgroundWorker_0_DoWork(object sender, DoWorkEventArgs e)
		{
			string radioBy = this.tInfo.RadioBy;
			if (radioBy != null)
			{
				if (radioBy != "GetListUrl")
				{
					this.method_1(this.tInfo.GetSinceId, this.string_1);
				}
				else
				{
					try
					{
						string[] ids = (new Page(this.rInfo, this.tInfo)).GetIds(this.tInfo.GetListUrl);
						this.method_1(ids, this.string_1);
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
			}
		}

		private void button_3_Click(object sender, EventArgs e)
		{
			this.tInfo = (TaskConfigInfo)ConfigFileManager.LoadConfig(this.comboBox_4.Text, this.tInfo);
			this.method_5();
			this.label7.Text = Localization.Get("开始生成错误日志...");
			this.string_1 = this.comboBox_4.Text;
			this.tInfo.ID = this.string_2;
			this.button_3.Enabled = false;
			DateTime now = DateTime.Now;
			this.dateTime_0 = now.AddMinutes((double)this.tInfo.Interval);
			if (!this.backgroundWorker_0.IsBusy)
			{
				this.backgroundWorker_0.RunWorkerAsync();
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
				MessageForm messageForm = new MessageForm()
				{
					Text = Localization.Get("错误提示")
				};
				messageForm.MessageText.Text = Localization.Get("你没有选择任何项目");
				messageForm.ShowDialog();
			}
			this.textBox_3.Text = this.rInfo.NovelListUrl.Pattern;
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(TaskForm));
			this.textBox_3 = new TextBox();
			this.comboBox_4 = new ComboBox();
			this.label_20 = new Label();
			this.label_1 = new Label();
			this.comboBox_0 = new ComboBox();
			this.radioButton_0 = new RadioButton();
			this.radioButton_1 = new RadioButton();
			this.button_3 = new Button();
			this.textBox_4 = new TextBox();
			this.backgroundWorker_0 = new BackgroundWorker();
			this.label7 = new Label();
			this.label13 = new Label();
			base.SuspendLayout();
			this.textBox_3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.textBox_3.Location = new Point(8, 60);
			this.textBox_3.Multiline = true;
			this.textBox_3.Name = "textBox_3";
			this.textBox_3.ScrollBars = ScrollBars.Vertical;
			this.textBox_3.Size = new System.Drawing.Size(580, 110);
			this.textBox_3.TabIndex = 39;
			this.comboBox_4.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_4.FormattingEnabled = true;
			this.comboBox_4.Items.AddRange(new object[] { "TaskConfig.xml" });
			this.comboBox_4.Location = new Point(79, 12);
			this.comboBox_4.Name = "comboBox_4";
			this.comboBox_4.Size = new System.Drawing.Size(180, 20);
			this.comboBox_4.TabIndex = 52;
			this.label_20.AutoSize = true;
			this.label_20.Font = new System.Drawing.Font(Localization.Get("宋体"), 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
			this.label_20.Location = new Point(8, 15);
			this.label_20.Name = "label_20";
			this.label_20.Size = new System.Drawing.Size(65, 12);
			this.label_20.TabIndex = 51;
			this.label_20.Text = Localization.Get("采集方案：");
			this.label_1.AutoSize = true;
			this.label_1.Font = new System.Drawing.Font(Localization.Get("宋体"), 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
			this.label_1.Location = new Point(265, 15);
			this.label_1.Name = "label_1";
			this.label_1.Size = new System.Drawing.Size(65, 12);
			this.label_1.TabIndex = 50;
			this.label_1.Text = Localization.Get("采集规则：");
			this.comboBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.comboBox_0.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_0.FormattingEnabled = true;
			this.comboBox_0.Location = new Point(336, 12);
			this.comboBox_0.Name = "comboBox_0";
			this.comboBox_0.Size = new System.Drawing.Size(252, 20);
			this.comboBox_0.TabIndex = 37;
			this.comboBox_0.SelectedIndexChanged += new EventHandler(this.comboBox_0_SelectedIndexChanged);
			this.radioButton_0.AutoSize = true;
			this.radioButton_0.Checked = true;
			this.radioButton_0.Location = new Point(8, 38);
			this.radioButton_0.Name = "radioButton_0";
			this.radioButton_0.Size = new System.Drawing.Size(335, 16);
			this.radioButton_0.TabIndex = 38;
			this.radioButton_0.TabStop = true;
			this.radioButton_0.Text = Localization.Get("按目标站页面获得编号，一般监控最新列表，一个地址一行");
			this.radioButton_0.UseVisualStyleBackColor = true;
			this.radioButton_1.AutoSize = true;
			this.radioButton_1.Location = new Point(8, 176);
			this.radioButton_1.Name = "radioButton_1";
			this.radioButton_1.Size = new System.Drawing.Size(245, 16);
			this.radioButton_1.TabIndex = 43;
			this.radioButton_1.Text = Localization.Get("按目标站自定义编号，多个ID用\",\"分隔开");
			this.radioButton_1.UseVisualStyleBackColor = true;
			this.button_3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			this.button_3.Location = new Point(454, 325);
			this.button_3.Name = "button_3";
			this.button_3.Size = new System.Drawing.Size(134, 23);
			this.button_3.TabIndex = 57;
			this.button_3.Text = Localization.Get("批量生成错误日志");
			this.button_3.UseVisualStyleBackColor = true;
			this.button_3.Click += new EventHandler(this.button_3_Click);
			this.textBox_4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.textBox_4.Location = new Point(8, 198);
			this.textBox_4.Multiline = true;
			this.textBox_4.Name = "textBox_4";
			this.textBox_4.ScrollBars = ScrollBars.Vertical;
			this.textBox_4.Size = new System.Drawing.Size(580, 110);
			this.textBox_4.TabIndex = 58;
			this.backgroundWorker_0.WorkerReportsProgress = true;
			this.backgroundWorker_0.WorkerSupportsCancellation = true;
			this.backgroundWorker_0.DoWork += new DoWorkEventHandler(this.backgroundWorker_0_DoWork);
			this.label7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			this.label7.AutoSize = true;
			this.label7.Location = new Point(77, 330);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(17, 12);
			this.label7.TabIndex = 60;
			this.label7.Text = "--";
			this.label13.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			this.label13.AutoSize = true;
			this.label13.Location = new Point(12, 330);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(65, 12);
			this.label13.TabIndex = 59;
			this.label13.Text = Localization.Get("进程状态：");
			base.ClientSize = new System.Drawing.Size(600, 360);
			base.Controls.Add(this.label7);
			base.Controls.Add(this.label13);
			base.Controls.Add(this.textBox_4);
			base.Controls.Add(this.button_3);
			base.Controls.Add(this.textBox_3);
			base.Controls.Add(this.comboBox_4);
			base.Controls.Add(this.label_20);
			base.Controls.Add(this.label_1);
			base.Controls.Add(this.comboBox_0);
			base.Controls.Add(this.radioButton_0);
			base.Controls.Add(this.radioButton_1);
			this.Font = new System.Drawing.Font(Localization.Get("宋体"), 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
			base.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "TaskForm";
			this.Text = Localization.Get("错误生成器");
			base.Load += new EventHandler(this.TaskForm_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private void method_1(string[] string_3, string string_0)
		{
			for (int i = 0; i < (int)string_3.Length && !this.backgroundWorker_0.CancellationPending; i++)
			{
				NovelInfo novelInfo = new NovelInfo()
				{
					GetID = string_3[i],
					PutID = 0,
					Name = ""
				};
				SpiderException.Show(200, Localization.Get("错误生成器生成错误"), novelInfo, true, string_0, this.tInfo.RuleFile);
			}
			base.Invoke(new EventHandler((object sender, EventArgs e) => {
				this.button_3.Enabled = true;
				this.label7.Text = string.Concat(Localization.Get("已经生成错误日志"), (int)string_3.Length, Localization.Get("条"));
			}));
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
				if (this.radioButton_1.Checked)
				{
					this.tInfo.RadioBy = "GetSinceId";
				}
				TaskConfigInfo taskConfigInfo = this.tInfo;
				string str = this.textBox_3.Text.Trim().Replace("\r\n", "♂");
				char[] chrArray = new char[] { '\u2642' };
				taskConfigInfo.GetListUrl = str.Split(chrArray);
				TaskConfigInfo taskConfigInfo1 = this.tInfo;
				string text = this.textBox_4.Text;
				chrArray = new char[] { ',' };
				taskConfigInfo1.GetSinceId = text.Split(chrArray);
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

		private void TaskForm_Load(object sender, EventArgs e)
		{
			Guid guid = Guid.NewGuid();
			this.string_2 = guid.ToString().ToUpper();
			TaskForm taskForm = this;
			string str = string.Concat(taskForm.Text, " ", this.string_2);
			taskForm.Text = str;
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
							this.Text = string.Concat(this.rInfo.GetSiteName.Pattern, Localization.Get(" 错误生成器"));
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
		}
	}
}