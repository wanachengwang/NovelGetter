using NovelSpider.Config;
using NovelSpider.Entity;
using NovelSpider.Local;
using NovelSpider.Local.Qiwen;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Resources;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace NovelSpider
{
	public class HelpDeleteNovel : DockContent
	{
		private BackgroundWorker backgroundWorker_0;

		private bool bool_0;

		private Button button_0;

		private Button button_1;

		private Button button_2;

		private CheckBox checkBox_0;

		private CheckBox checkBox_1;

		private CheckBox checkBox_2;

		private CheckBox checkBox_3;

		private CheckBox checkBox_4;

		private CheckBox checkBox_5;

		private CheckBox checkBox_6;

		private CheckBox checkBox_7;

		private CheckBox checkBox1;

		private DateTimePicker dateTimePicker_0;

		private DateTimePicker dateTimePicker_1;

		private GroupBox groupBox_0;

		private GroupBox groupBox_1;

		private IContainer icontainer_0;

		private int int_0;

		private Label label_0;

		private Label label_1;

		private Label label_2;

		private Label label_3;

		private MaskedTextBox maskedTextBox1;

		private NumericUpDown numericUpDown_0;

		private NumericUpDown numericUpDown_1;

		private NumericUpDown numericUpDown_2;

		private NumericUpDown numericUpDown_3;

		private NumericUpDown numericUpDown_4;

		private NumericUpDown numericUpDown_5;

		private TextBox textBox_0;

		public HelpDeleteNovel()
		{
			Class19.Q77LubhzKM3NS();
			this.InitializeComponent();
		}

		private void backgroundWorker_0_DoWork(object sender, DoWorkEventArgs e)
		{
			if (Configs.CmsName != "Qiwen")
			{
				if (this.textBox_0.Text != "")
				{
					NovelInfo[] novelList = NovelSpider.Local.LocalProvider.GetInstance().GetNovelList(this.textBox_0.Text.ToString());
					int num = 0;
					while (num < (int)novelList.Length)
					{
						if (this.backgroundWorker_0.CancellationPending)
						{
							e.Cancel = true;
							return;
						}
						else
						{
							int putID = novelList[num].PutID;
							this.backgroundWorker_0.ReportProgress(0, string.Concat(putID.ToString(), " | ", novelList[num].Name.ToString()));
							this.backgroundWorker_0.ReportProgress(1, string.Concat(num + 1, " / ", (int)novelList.Length));
							if ((!this.bool_0 ? true : (int)NovelSpider.Local.LocalProvider.GetInstance().GetChapterList(putID).Length < this.int_0))
							{
								NovelInfo novelInfo = new NovelInfo()
								{
									PutID = putID
								};
								NovelSpider.Local.LocalProvider.GetInstance().ClearNovel(novelInfo);
								NovelSpider.Local.LocalProvider.GetInstance().DeteleNovel(putID);
								File.AppendAllText("Delete.log", string.Concat(putID.ToString(), " | ", novelList[num].Name.ToString(), "\r\n"));
							}
							num++;
						}
					}
				}
				else
				{
					MessageBox.Show(Localization.Get("请输入自定义SQL，选择单本或批量方式的请先生成自定义SQL。"));
				}
			}
			else if (!this.backgroundWorker_0.IsBusy)
			{
				DataTable dataTable = SqlHelper.ExecuteDataTable(SqlHelper.ConnectionString, CommandType.Text, e.Argument.ToString(), null);
				int num1 = 0;
				while (num1 < dataTable.Rows.Count)
				{
					if (this.backgroundWorker_0.CancellationPending)
					{
						e.Cancel = true;
						return;
					}
					else
					{
						int num2 = Convert.ToInt32(dataTable.Rows[num1]["id"]);
						this.backgroundWorker_0.ReportProgress(0, string.Concat(num2.ToString(), " | ", dataTable.Rows[num1]["booktitle"].ToString()));
						this.backgroundWorker_0.ReportProgress(1, string.Concat(num1 + 1, " / ", dataTable.Rows.Count));
						if ((!this.bool_0 ? true : (int)NovelSpider.Local.LocalProvider.GetInstance().GetChapterList(num2).Length < this.int_0))
						{
							NovelSpider.Local.LocalProvider.GetInstance().DeteleNovel(num2);
							File.AppendAllText("Delete.log", string.Concat(num2.ToString(), " | ", dataTable.Rows[num1]["booktitle"].ToString(), "\r\n"));
						}
						num1++;
					}
				}
			}
			else
			{
				MessageBox.Show(Localization.Get("正在删除小说请稍后操作"));
			}
		}

		private void backgroundWorker_0_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			if (e.ProgressPercentage != 0)
			{
				this.label_3.Text = string.Concat(Localization.Get("当前进度："), e.UserState.ToString());
			}
			else
			{
				this.label_0.Text = string.Concat(Localization.Get("当前小说："), e.UserState.ToString());
			}
		}

		private void backgroundWorker_0_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (e.Error != null)
			{
				MessageBox.Show(e.Error.Message, Localization.Get("错误提示"));
				this.label_1.Text = Localization.Get("当前动作：发生错误");
			}
			else if (!e.Cancelled)
			{
				this.label_1.Text = Localization.Get("当前动作：操作完成");
			}
			else
			{
				this.label_1.Text = Localization.Get("当前动作：操作取消");
			}
			this.button_0.Enabled = true;
			this.button_1.Enabled = false;
			this.groupBox_0.Enabled = true;
		}

		private void button_0_Click(object sender, EventArgs e)
		{
			if ((Configs.CmsName == "Qiwen" ? true : this.backgroundWorker_0.IsBusy))
			{
				this.bool_0 = this.checkBox_5.Checked;
				this.int_0 = Convert.ToInt32(this.numericUpDown_1.Value);
				this.groupBox_0.Enabled = false;
				this.button_0.Enabled = false;
				this.button_1.Enabled = true;
				this.backgroundWorker_0.RunWorkerAsync(this.textBox_0.Text);
			}
			else
			{
				this.bool_0 = this.checkBox_5.Checked;
				this.int_0 = Convert.ToInt32(this.numericUpDown_1.Value);
				this.groupBox_0.Enabled = false;
				this.button_0.Enabled = false;
				this.button_1.Enabled = true;
				this.backgroundWorker_0.RunWorkerAsync(this.textBox_0.Text);
			}
		}

		private void button_1_Click(object sender, EventArgs e)
		{
			if (this.backgroundWorker_0.IsBusy)
			{
				this.backgroundWorker_0.CancelAsync();
				this.button_1.Enabled = false;
			}
		}

		private void button_2_Click(object sender, EventArgs e)
		{
			decimal value;
			DateTime dateTime;
			if (Configs.CmsName != "Qiwen")
			{
				bool flag = false;
				string str = "SELECT * FROM `jieqi_article_article` WHERE";
				if (this.checkBox_4.Checked)
				{
					if (flag)
					{
						str = string.Concat(str, " And");
					}
					value = this.numericUpDown_4.Value;
					str = string.Concat(str, " `articleid` >= '", value.ToString(), "'");
					flag = true;
				}
				if (this.checkBox_3.Checked)
				{
					if (flag)
					{
						str = string.Concat(str, " And");
					}
					value = this.numericUpDown_3.Value;
					str = string.Concat(str, " `articleid` <= '", value.ToString(), "'");
					flag = true;
				}
				if (this.checkBox_7.Checked)
				{
					if (flag)
					{
						str = string.Concat(str, " And");
					}
					value = this.numericUpDown_5.Value;
					str = string.Concat(str, " `articleid` = '", value.ToString(), "'");
					flag = true;
				}
				if (this.checkBox_5.Checked)
				{
					if (flag)
					{
						str = string.Concat(str, " And");
					}
					value = this.numericUpDown_1.Value;
					str = string.Concat(str, " `chapters` < '", value.ToString(), "'");
					flag = true;
				}
				if (this.checkBox_6.Checked)
				{
					if (flag)
					{
						str = string.Concat(str, " And");
					}
					value = this.numericUpDown_0.Value;
					str = string.Concat(str, " `allvisit` < '", value.ToString(), "'");
					flag = true;
				}
				if (this.checkBox_2.Checked)
				{
					if (flag)
					{
						str = string.Concat(str, " And");
					}
					value = this.numericUpDown_2.Value;
					str = string.Concat(str, " `allvote` < '", value.ToString(), "'");
					flag = true;
				}
				if (this.checkBox_0.Checked)
				{
					if (flag)
					{
						str = string.Concat(str, " And");
					}
					dateTime = this.dateTimePicker_1.Value;
					str = string.Concat(str, " `postdate` < '", dateTime.ToShortDateString(), "'");
					flag = true;
				}
				if (this.checkBox_1.Checked)
				{
					if (flag)
					{
						str = string.Concat(str, " And");
					}
					dateTime = this.dateTimePicker_0.Value;
					str = string.Concat(str, " `lastupdate` < '", dateTime.ToShortDateString(), "'");
				}
				if (this.checkBox1.Checked)
				{
					if (flag)
					{
						str = string.Concat(str, " And");
					}
					str = string.Concat(str, " `articleid` in(", this.maskedTextBox1.Text.ToString(), ")");
					flag = true;
				}
				this.textBox_0.Text = string.Concat(str, " Order By `articleid` Asc");
			}
			else
			{
				bool flag1 = false;
				string str1 = "Select id,booktitle From WS_BookList Where";
				if (this.checkBox_4.Checked)
				{
					if (flag1)
					{
						str1 = string.Concat(str1, " And");
					}
					value = this.numericUpDown_4.Value;
					str1 = string.Concat(str1, " id>=", value.ToString());
					flag1 = true;
				}
				if (this.checkBox_3.Checked)
				{
					if (flag1)
					{
						str1 = string.Concat(str1, " And");
					}
					value = this.numericUpDown_3.Value;
					str1 = string.Concat(str1, " id<=", value.ToString());
					flag1 = true;
				}
				if (this.checkBox_6.Checked)
				{
					if (flag1)
					{
						str1 = string.Concat(str1, " And");
					}
					value = this.numericUpDown_0.Value;
					str1 = string.Concat(str1, " bookhits<", value.ToString());
					flag1 = true;
				}
				if (this.checkBox_2.Checked)
				{
					if (flag1)
					{
						str1 = string.Concat(str1, " And");
					}
					value = this.numericUpDown_2.Value;
					str1 = string.Concat(str1, " bookrecom<", value.ToString());
					flag1 = true;
				}
				if (this.checkBox_0.Checked)
				{
					if (flag1)
					{
						str1 = string.Concat(str1, " And");
					}
					dateTime = this.dateTimePicker_1.Value;
					str1 = string.Concat(str1, " bookaddtime<'", dateTime.ToShortDateString(), "'");
					flag1 = true;
				}
				if (this.checkBox_1.Checked)
				{
					if (flag1)
					{
						str1 = string.Concat(str1, " And");
					}
					dateTime = this.dateTimePicker_0.Value;
					str1 = string.Concat(str1, " bookupdatetime<'", dateTime.ToShortDateString(), "'");
				}
				this.textBox_0.Text = string.Concat(str1, " Order By id Asc");
			}
		}

		private void checkBox_7_CheckedChanged(object sender, EventArgs e)
		{
			this.checkBox_0.Checked = true;
			this.checkBox_0.Checked = false;
			this.checkBox_1.Checked = false;
			this.checkBox_2.Checked = false;
			this.checkBox_3.Checked = false;
			this.checkBox_4.Checked = false;
			this.checkBox_5.Checked = false;
			this.checkBox_6.Checked = false;
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(HelpDeleteNovel));
			this.groupBox_0 = new GroupBox();
			this.checkBox1 = new CheckBox();
			this.maskedTextBox1 = new MaskedTextBox();
			this.label_2 = new Label();
			this.button_2 = new Button();
			this.textBox_0 = new TextBox();
			this.checkBox_4 = new CheckBox();
			this.checkBox_5 = new CheckBox();
			this.checkBox_6 = new CheckBox();
			this.checkBox_0 = new CheckBox();
			this.checkBox_2 = new CheckBox();
			this.checkBox_1 = new CheckBox();
			this.checkBox_7 = new CheckBox();
			this.checkBox_3 = new CheckBox();
			this.dateTimePicker_0 = new DateTimePicker();
			this.dateTimePicker_1 = new DateTimePicker();
			this.numericUpDown_3 = new NumericUpDown();
			this.numericUpDown_4 = new NumericUpDown();
			this.numericUpDown_2 = new NumericUpDown();
			this.numericUpDown_5 = new NumericUpDown();
			this.numericUpDown_0 = new NumericUpDown();
			this.numericUpDown_1 = new NumericUpDown();
			this.groupBox_1 = new GroupBox();
			this.label_0 = new Label();
			this.label_1 = new Label();
			this.label_3 = new Label();
			this.button_0 = new Button();
			this.button_1 = new Button();
			this.backgroundWorker_0 = new BackgroundWorker();
			this.groupBox_0.SuspendLayout();
			((ISupportInitialize)this.numericUpDown_3).BeginInit();
			((ISupportInitialize)this.numericUpDown_4).BeginInit();
			((ISupportInitialize)this.numericUpDown_2).BeginInit();
			((ISupportInitialize)this.numericUpDown_5).BeginInit();
			((ISupportInitialize)this.numericUpDown_0).BeginInit();
			((ISupportInitialize)this.numericUpDown_1).BeginInit();
			this.groupBox_1.SuspendLayout();
			base.SuspendLayout();
			this.groupBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.groupBox_0.Controls.Add(this.checkBox1);
			this.groupBox_0.Controls.Add(this.maskedTextBox1);
			this.groupBox_0.Controls.Add(this.label_2);
			this.groupBox_0.Controls.Add(this.button_2);
			this.groupBox_0.Controls.Add(this.textBox_0);
			this.groupBox_0.Controls.Add(this.checkBox_4);
			this.groupBox_0.Controls.Add(this.checkBox_5);
			this.groupBox_0.Controls.Add(this.checkBox_6);
			this.groupBox_0.Controls.Add(this.checkBox_0);
			this.groupBox_0.Controls.Add(this.checkBox_2);
			this.groupBox_0.Controls.Add(this.checkBox_1);
			this.groupBox_0.Controls.Add(this.checkBox_7);
			this.groupBox_0.Controls.Add(this.checkBox_3);
			this.groupBox_0.Controls.Add(this.dateTimePicker_0);
			this.groupBox_0.Controls.Add(this.dateTimePicker_1);
			this.groupBox_0.Controls.Add(this.numericUpDown_3);
			this.groupBox_0.Controls.Add(this.numericUpDown_4);
			this.groupBox_0.Controls.Add(this.numericUpDown_2);
			this.groupBox_0.Controls.Add(this.numericUpDown_5);
			this.groupBox_0.Controls.Add(this.numericUpDown_0);
			this.groupBox_0.Controls.Add(this.numericUpDown_1);
			this.groupBox_0.Location = new Point(12, 12);
			this.groupBox_0.Name = "groupBox_0";
			this.groupBox_0.Size = new System.Drawing.Size(608, 248);
			this.groupBox_0.TabIndex = 16;
			this.groupBox_0.TabStop = false;
			this.groupBox_0.Text = Localization.Get("限制条件");
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new Point(8, 102);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(60, 16);
			this.checkBox1.TabIndex = 32;
			this.checkBox1.Text = Localization.Get("自定义");
			this.checkBox1.UseVisualStyleBackColor = true;
			this.maskedTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.maskedTextBox1.Location = new Point(98, 100);
			this.maskedTextBox1.Name = "maskedTextBox1";
			this.maskedTextBox1.Size = new System.Drawing.Size(498, 21);
			this.maskedTextBox1.TabIndex = 31;
			this.label_2.AutoSize = true;
			this.label_2.Location = new Point(240, 132);
			this.label_2.Name = "label_2";
			this.label_2.Size = new System.Drawing.Size(155, 12);
			this.label_2.TabIndex = 30;
			this.label_2.Text = Localization.Get("PS:章节数在执行过程中判断");
			this.button_2.Location = new Point(6, 127);
			this.button_2.Name = "button_2";
			this.button_2.Size = new System.Drawing.Size(126, 23);
			this.button_2.TabIndex = 29;
			this.button_2.Text = Localization.Get("↓生成SQL语句↓");
			this.button_2.UseVisualStyleBackColor = true;
			this.button_2.Click += new EventHandler(this.button_2_Click);
			this.textBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.textBox_0.Location = new Point(8, 156);
			this.textBox_0.Multiline = true;
			this.textBox_0.Name = "textBox_0";
			this.textBox_0.Size = new System.Drawing.Size(588, 86);
			this.textBox_0.TabIndex = 28;
			this.checkBox_4.AutoSize = true;
			this.checkBox_4.Location = new Point(8, 20);
			this.checkBox_4.Name = "checkBox_4";
			this.checkBox_4.Size = new System.Drawing.Size(84, 16);
			this.checkBox_4.TabIndex = 27;
			this.checkBox_4.Text = Localization.Get("最小小说ID");
			this.checkBox_4.UseVisualStyleBackColor = true;
			this.checkBox_5.AutoSize = true;
			this.checkBox_5.Location = new Point(8, 47);
			this.checkBox_5.Name = "checkBox_5";
			this.checkBox_5.Size = new System.Drawing.Size(84, 16);
			this.checkBox_5.TabIndex = 26;
			this.checkBox_5.Text = Localization.Get("章节数小于");
			this.checkBox_5.UseVisualStyleBackColor = true;
			this.checkBox_6.AutoSize = true;
			this.checkBox_6.Location = new Point(204, 51);
			this.checkBox_6.Name = "checkBox_6";
			this.checkBox_6.Size = new System.Drawing.Size(84, 16);
			this.checkBox_6.TabIndex = 25;
			this.checkBox_6.Text = Localization.Get("点击数小于");
			this.checkBox_6.UseVisualStyleBackColor = true;
			this.checkBox_0.AutoSize = true;
			this.checkBox_0.Location = new Point(8, 76);
			this.checkBox_0.Name = "checkBox_0";
			this.checkBox_0.Size = new System.Drawing.Size(72, 16);
			this.checkBox_0.TabIndex = 24;
			this.checkBox_0.Text = Localization.Get("入库时间");
			this.checkBox_0.UseVisualStyleBackColor = true;
			this.checkBox_2.AutoSize = true;
			this.checkBox_2.Location = new Point(401, 51);
			this.checkBox_2.Name = "checkBox_2";
			this.checkBox_2.Size = new System.Drawing.Size(84, 16);
			this.checkBox_2.TabIndex = 22;
			this.checkBox_2.Text = Localization.Get("推荐数小于");
			this.checkBox_2.UseVisualStyleBackColor = true;
			this.checkBox_1.AutoSize = true;
			this.checkBox_1.Location = new Point(205, 76);
			this.checkBox_1.Name = "checkBox_1";
			this.checkBox_1.Size = new System.Drawing.Size(72, 16);
			this.checkBox_1.TabIndex = 23;
			this.checkBox_1.Text = Localization.Get("最后更新");
			this.checkBox_1.UseVisualStyleBackColor = true;
			this.checkBox_7.AutoSize = true;
			this.checkBox_7.Location = new Point(401, 24);
			this.checkBox_7.Name = "checkBox_7";
			this.checkBox_7.Size = new System.Drawing.Size(84, 16);
			this.checkBox_7.TabIndex = 21;
			this.checkBox_7.Text = Localization.Get("小说ID等于");
			this.checkBox_7.UseVisualStyleBackColor = true;
			this.checkBox_7.CheckedChanged += new EventHandler(this.checkBox_7_CheckedChanged);
			this.checkBox_3.AutoSize = true;
			this.checkBox_3.Location = new Point(205, 20);
			this.checkBox_3.Name = "checkBox_3";
			this.checkBox_3.Size = new System.Drawing.Size(84, 16);
			this.checkBox_3.TabIndex = 20;
			this.checkBox_3.Text = Localization.Get("最大小说ID");
			this.checkBox_3.UseVisualStyleBackColor = true;
			this.dateTimePicker_0.Format = DateTimePickerFormat.Short;
			this.dateTimePicker_0.Location = new Point(295, 73);
			this.dateTimePicker_0.Name = "dateTimePicker_0";
			this.dateTimePicker_0.Size = new System.Drawing.Size(100, 21);
			this.dateTimePicker_0.TabIndex = 19;
			this.dateTimePicker_1.Format = DateTimePickerFormat.Short;
			this.dateTimePicker_1.Location = new Point(98, 73);
			this.dateTimePicker_1.Name = "dateTimePicker_1";
			this.dateTimePicker_1.Size = new System.Drawing.Size(100, 21);
			this.dateTimePicker_1.TabIndex = 17;
			this.numericUpDown_3.Location = new Point(295, 19);
			NumericUpDown numericUpDown3 = this.numericUpDown_3;
			int[] numArray = new int[] { 100000000, 0, 0, 0 };
			numericUpDown3.Maximum = new decimal(numArray);
			this.numericUpDown_3.Name = "numericUpDown_3";
			this.numericUpDown_3.Size = new System.Drawing.Size(100, 21);
			this.numericUpDown_3.TabIndex = 11;
			this.numericUpDown_4.Location = new Point(98, 19);
			NumericUpDown numericUpDown4 = this.numericUpDown_4;
			numArray = new int[] { 100000000, 0, 0, 0 };
			numericUpDown4.Maximum = new decimal(numArray);
			this.numericUpDown_4.Name = "numericUpDown_4";
			this.numericUpDown_4.Size = new System.Drawing.Size(100, 21);
			this.numericUpDown_4.TabIndex = 9;
			this.numericUpDown_2.Location = new Point(491, 50);
			NumericUpDown numericUpDown2 = this.numericUpDown_2;
			numArray = new int[] { 100000000, 0, 0, 0 };
			numericUpDown2.Maximum = new decimal(numArray);
			this.numericUpDown_2.Name = "numericUpDown_2";
			this.numericUpDown_2.Size = new System.Drawing.Size(100, 21);
			this.numericUpDown_2.TabIndex = 7;
			this.numericUpDown_5.Location = new Point(491, 23);
			NumericUpDown numericUpDown5 = this.numericUpDown_5;
			numArray = new int[] { 100000000, 0, 0, 0 };
			numericUpDown5.Maximum = new decimal(numArray);
			this.numericUpDown_5.Name = "numericUpDown_5";
			this.numericUpDown_5.Size = new System.Drawing.Size(100, 21);
			this.numericUpDown_5.TabIndex = 5;
			this.numericUpDown_0.Location = new Point(294, 47);
			NumericUpDown numericUpDown0 = this.numericUpDown_0;
			numArray = new int[] { 100000000, 0, 0, 0 };
			numericUpDown0.Maximum = new decimal(numArray);
			this.numericUpDown_0.Name = "numericUpDown_0";
			this.numericUpDown_0.Size = new System.Drawing.Size(100, 21);
			this.numericUpDown_0.TabIndex = 3;
			this.numericUpDown_1.Location = new Point(98, 46);
			NumericUpDown numericUpDown1 = this.numericUpDown_1;
			numArray = new int[] { 100000000, 0, 0, 0 };
			numericUpDown1.Maximum = new decimal(numArray);
			this.numericUpDown_1.Name = "numericUpDown_1";
			this.numericUpDown_1.Size = new System.Drawing.Size(100, 21);
			this.numericUpDown_1.TabIndex = 1;
			this.groupBox_1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.groupBox_1.Controls.Add(this.label_0);
			this.groupBox_1.Controls.Add(this.label_1);
			this.groupBox_1.Controls.Add(this.label_3);
			this.groupBox_1.Location = new Point(12, 266);
			this.groupBox_1.Name = "groupBox_1";
			this.groupBox_1.Size = new System.Drawing.Size(608, 94);
			this.groupBox_1.TabIndex = 17;
			this.groupBox_1.TabStop = false;
			this.groupBox_1.Text = Localization.Get("进度显示");
			this.label_0.AutoSize = true;
			this.label_0.Location = new Point(6, 22);
			this.label_0.Name = "label_0";
			this.label_0.Size = new System.Drawing.Size(65, 12);
			this.label_0.TabIndex = 21;
			this.label_0.Text = Localization.Get("当前小说：");
			this.label_1.AutoSize = true;
			this.label_1.Location = new Point(6, 71);
			this.label_1.Name = "label_1";
			this.label_1.Size = new System.Drawing.Size(65, 12);
			this.label_1.TabIndex = 19;
			this.label_1.Text = Localization.Get("当前动作：");
			this.label_3.AutoSize = true;
			this.label_3.Location = new Point(6, 46);
			this.label_3.Name = "label_3";
			this.label_3.Size = new System.Drawing.Size(65, 12);
			this.label_3.TabIndex = 18;
			this.label_3.Text = Localization.Get("当前进度：");
			this.button_0.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.button_0.Location = new Point(464, 371);
			this.button_0.Name = "button_0";
			this.button_0.Size = new System.Drawing.Size(75, 23);
			this.button_0.TabIndex = 18;
			this.button_0.Text = Localization.Get("开始");
			this.button_0.UseVisualStyleBackColor = true;
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.button_1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.button_1.Location = new Point(545, 371);
			this.button_1.Name = "button_1";
			this.button_1.Size = new System.Drawing.Size(75, 23);
			this.button_1.TabIndex = 19;
			this.button_1.Text = Localization.Get("停止");
			this.button_1.UseVisualStyleBackColor = true;
			this.button_1.Click += new EventHandler(this.button_1_Click);
			this.backgroundWorker_0.WorkerReportsProgress = true;
			this.backgroundWorker_0.WorkerSupportsCancellation = true;
			this.backgroundWorker_0.DoWork += new DoWorkEventHandler(this.backgroundWorker_0_DoWork);
			this.backgroundWorker_0.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker_0_RunWorkerCompleted);
			this.backgroundWorker_0.ProgressChanged += new ProgressChangedEventHandler(this.backgroundWorker_0_ProgressChanged);
			base.ClientSize = new System.Drawing.Size(632, 406);
			base.Controls.Add(this.button_1);
			base.Controls.Add(this.button_0);
			base.Controls.Add(this.groupBox_1);
			base.Controls.Add(this.groupBox_0);
			this.Font = new System.Drawing.Font(Localization.Font, 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
			base.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "HelpDeleteNovel";
			this.Text = Localization.Get("批量删除小说");
			this.groupBox_0.ResumeLayout(false);
			this.groupBox_0.PerformLayout();
			((ISupportInitialize)this.numericUpDown_3).EndInit();
			((ISupportInitialize)this.numericUpDown_4).EndInit();
			((ISupportInitialize)this.numericUpDown_2).EndInit();
			((ISupportInitialize)this.numericUpDown_5).EndInit();
			((ISupportInitialize)this.numericUpDown_0).EndInit();
			((ISupportInitialize)this.numericUpDown_1).EndInit();
			this.groupBox_1.ResumeLayout(false);
			this.groupBox_1.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}