using NovelSpider.Common;
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
	public class HelpLog : DockContent
	{
		private Button button_0;

		private ComboBox comboBox_0;

		private ComboBox comboBox_1;

		private ComboBox comboBox_2;

		private ComboBox comboBox_3;

		private DataGridView dataGridView_0;

		private IContainer icontainer_0;

		public HelpLog()
		{
			Class19.Q77LubhzKM3NS();
			this.InitializeComponent();
		}

		private void button_0_Click(object sender, EventArgs e)
		{
			FileInfo fileInfo = new FileInfo(this.comboBox_0.Text);
			if (fileInfo.Exists)
			{
				string str = string.Concat("Data Source=", fileInfo.FullName);
				string str1 = "Select * From [TaskLog] Where 1=1";
				if ((this.comboBox_1.Text == "EXIT" ? false : this.comboBox_1.Text != ""))
				{
					if (this.comboBox_1.Text == "")
					{
						this.comboBox_1.Text = "EXID";
					}
					if (this.comboBox_1.Text != "EXID")
					{
						ComboBox comboBox1 = this.comboBox_1;
						string text = this.comboBox_1.Text;
						char[] chrArray = new char[] { ' ' };
						comboBox1.Text = text.Split(chrArray)[0];
					}
					str1 = string.Concat(str1, " And EXID= ", this.comboBox_1.Text);
				}
				if ((this.comboBox_2.Text == Localization.Get("书名") ? false : this.comboBox_2.Text != ""))
				{
					str1 = string.Concat(str1, " And NovelName= '", this.comboBox_2.Text, "'");
				}
				if ((this.comboBox_3.Text == Localization.Get("提示信息") ? false : this.comboBox_3.Text != ""))
				{
					str1 = string.Concat(str1, " And Exmsg Like '%", this.comboBox_3.Text, "%'");
				}
				this.dataGridView_0.DataSource = SQLiteHelper.ExecuteDataset(str, str1).Tables[0];
				this.dataGridView_0.AutoResizeColumns();
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

		private void HelpLog_Load(object sender, EventArgs e)
		{
			string[] strArrays = IO.LoadLogs();
			int num = -1;
			string[] strArrays1 = strArrays;
			for (int i = 0; i < (int)strArrays1.Length; i++)
			{
				string str = strArrays1[i];
				if (str.EndsWith("db3"))
				{
					num++;
					this.comboBox_0.Items.Insert(num, str);
				}
			}
			if (num >= 0)
			{
				this.comboBox_0.SelectedIndex = num;
			}
		}

		private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(HelpLog));
			this.dataGridView_0 = new DataGridView();
			this.comboBox_0 = new ComboBox();
			this.comboBox_1 = new ComboBox();
			this.comboBox_2 = new ComboBox();
			this.comboBox_3 = new ComboBox();
			this.button_0 = new Button();
			((ISupportInitialize)this.dataGridView_0).BeginInit();
			base.SuspendLayout();
			this.dataGridView_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.dataGridView_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView_0.Location = new Point(12, 38);
			this.dataGridView_0.Name = "dataGridView_0";
			this.dataGridView_0.RowTemplate.Height = 23;
			this.dataGridView_0.Size = new System.Drawing.Size(598, 373);
			this.dataGridView_0.TabIndex = 0;
			this.comboBox_0.FormattingEnabled = true;
			this.comboBox_0.Location = new Point(12, 12);
			this.comboBox_0.Name = "comboBox_0";
			this.comboBox_0.Size = new System.Drawing.Size(150, 20);
			this.comboBox_0.TabIndex = 1;
			this.comboBox_1.DropDownWidth = 300;
			this.comboBox_1.FormattingEnabled = true;
			ComboBox.ObjectCollection items = this.comboBox_1.Items;
			object[] objArray = new object[] { "EXID", Localization.Get("0 未知错误"), "", Localization.Get("21 FTP负载失败"), "", Localization.Get("101 子窗口冲突"), Localization.Get("102 检查子窗口冲突失败"), "", Localization.Get("120 对比最新章节失败"), Localization.Get("121 空章节"), Localization.Get("122 检查到重复章节"), Localization.Get("124 只采集文字章节时发现图片章节"), Localization.Get("125 设置不添加新书"), "", Localization.Get("130 限制章节字数小于多少字的章节不采集"), Localization.Get("131 章节数量小于限制"), Localization.Get("132 对比最新章节成功！但需要采集到章节数超限。"), Localization.Get("134 限制小说_黑名单"), Localization.Get("135 限制小说_不在白名单"), Localization.Get("136 过滤分卷名"), "", Localization.Get("200 小说信息页发生问题"), Localization.Get("210 小说目录页发生问题"), Localization.Get("214 章节组为空"), Localization.Get("220 小说内容页发生问题"), "", Localization.Get("410 操作本站小说列表发生问题"), Localization.Get("420 操作本站小说信息发生问题"), Localization.Get("430 操作本站章节列表发生问题"), Localization.Get("440 操作本站章节信息发生问题"), Localization.Get("441 InsertChapter发生问题"), Localization.Get("442 UpdateChapter发生问题") };
			items.AddRange(objArray);
			this.comboBox_1.Location = new Point(168, 12);
			this.comboBox_1.Name = "comboBox_1";
			this.comboBox_1.Size = new System.Drawing.Size(50, 20);
			this.comboBox_1.TabIndex = 2;
			this.comboBox_1.Text = "EXID";
			this.comboBox_2.FormattingEnabled = true;
			ComboBox.ObjectCollection objectCollections = this.comboBox_2.Items;
			objArray = new object[] { Localization.Get("书名") };
			objectCollections.AddRange(objArray);
			this.comboBox_2.Location = new Point(224, 12);
			this.comboBox_2.Name = "comboBox_2";
			this.comboBox_2.Size = new System.Drawing.Size(108, 20);
			this.comboBox_2.TabIndex = 3;
			this.comboBox_2.Text = Localization.Get("书名");
			this.comboBox_3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.comboBox_3.FormattingEnabled = true;
			ComboBox.ObjectCollection items1 = this.comboBox_3.Items;
			objArray = new object[] { Localization.Get("提示信息") };
			items1.AddRange(objArray);
			this.comboBox_3.Location = new Point(338, 12);
			this.comboBox_3.Name = "comboBox_3";
			this.comboBox_3.Size = new System.Drawing.Size(191, 20);
			this.comboBox_3.TabIndex = 4;
			this.comboBox_3.Text = Localization.Get("提示信息");
			this.button_0.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.button_0.Location = new Point(535, 12);
			this.button_0.Name = "button_0";
			this.button_0.Size = new System.Drawing.Size(75, 20);
			this.button_0.TabIndex = 5;
			this.button_0.Text = Localization.Get("列出日志");
			this.button_0.UseVisualStyleBackColor = true;
			this.button_0.Click += new EventHandler(this.button_0_Click);
			base.AcceptButton = this.button_0;
			base.ClientSize = new System.Drawing.Size(622, 423);
			base.Controls.Add(this.button_0);
			base.Controls.Add(this.comboBox_3);
			base.Controls.Add(this.comboBox_2);
			base.Controls.Add(this.comboBox_1);
			base.Controls.Add(this.comboBox_0);
			base.Controls.Add(this.dataGridView_0);
			this.Font = new System.Drawing.Font(Localization.Get("宋体"), 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
			base.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "HelpLog";
			this.Text = Localization.Get("查看日志");
			base.Load += new EventHandler(this.HelpLog_Load);
			((ISupportInitialize)this.dataGridView_0).EndInit();
			base.ResumeLayout(false);
		}
	}
}