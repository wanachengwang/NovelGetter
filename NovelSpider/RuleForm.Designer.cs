using NovelSpider.Common;
using NovelSpider.Config;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Resources;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace NovelSpider
{
	public class RuleForm : DockContent
	{
		private Button button_0;

		private Button button_1;

		private Button button_2;

		private Button button_3;

		private CheckBox checkBox_0;

		private CheckBox checkBox_1;

		private ComboBox comboBox_0;

		private ComboBox comboBox_1;

		private GroupBox groupBox_0;

		private GroupBox groupBox_1;

		private GroupBox groupBox_2;

		private Hashtable hashtable_0;

		private IContainer icontainer_0;

		private int int_0;

		private ListBox listBox_0;

		private PropertyInfo[] propertyInfo_0;

		private RuleConfigInfo ruleConfigInfo_0;

		private RuleTestForm ruleTestForm_0;

		private TaskConfigInfo taskConfigInfo_0;

		private TextBox textBox_0;

		private TextBox textBox_1;

		private TextBox textBox_2;

		private TextBox textBox_3;

		private TextBox textBox_4;

		private TextBox textBox_5;

		private IContainer components;

		private ToolTip toolTip_0;

		public RuleForm()
		{
			Class19.Q77LubhzKM3NS();
			this.hashtable_0 = new Hashtable();
			this.int_0 = -1;
			this.ruleConfigInfo_0 = new RuleConfigInfo();
			this.ruleTestForm_0 = new RuleTestForm();
			this.taskConfigInfo_0 = new TaskConfigInfo();
			this.InitializeComponent();
			this.hashtable_0.Add("RuleVersion", Localization.Get("规则版本"));
			this.hashtable_0.Add("RuleID", Localization.Get("规则编号"));
			this.hashtable_0.Add("GetSiteName", Localization.Get("站点名称"));
			this.hashtable_0.Add("GetSiteCharset", Localization.Get("站点编码"));
			this.hashtable_0.Add("GetSiteUrl", Localization.Get("站点地址"));
			this.hashtable_0.Add("NovelSearchUrl", Localization.Get("站点搜索地址"));
			this.hashtable_0.Add("NovelSearchData", Localization.Get("搜索提交内容\r\n{SearchKey} 表示搜索提交的内容"));
			this.hashtable_0.Add("NovelSearch_GetNovelKey", Localization.Get("从搜索结果中获得小说编号\r\n{SearchKey} 表示搜索提交的内容\r\n此获得结果存入{NovelKey}变量"));
			this.hashtable_0.Add("NovelListUrl", Localization.Get("站点最新列表地址"));
			this.hashtable_0.Add("NovelList_GetNovelKey", Localization.Get("从最新列表中获得小说编号\r\n此规则中可以同时获得书名以方便手动时查看\r\n此获得结果存入{NovelKey}变量"));
			this.hashtable_0.Add("NovelUrl", Localization.Get("小说信息页地址 可调用{NovelKey}变量\r\n{NovelKey}一般情况表示小说编号"));
			this.hashtable_0.Add("NovelErr", Localization.Get("小说信息页错误识别标记"));
			this.hashtable_0.Add("NovelName", Localization.Get("获得小说名称正则，替换标签♂\r\n支持多模板"));
			this.hashtable_0.Add("NovelAuthor", Localization.Get("获得小说作者正则，替换标签♂\r\n支持多模板"));
			this.hashtable_0.Add("LagerSort", Localization.Get("获得小说大类正则，替换标签♂\r\n支持多模板"));
			this.hashtable_0.Add("SmallSort", Localization.Get("获得小说小类正则，替换标签♂\r\n支持多模板\r\n如果目标站点没有小类，这里就重复输入一次大类规则"));
			this.hashtable_0.Add("NovelIntro", Localization.Get("获得小说简介正则，替换标签♂\r\n支持多模板"));
			this.hashtable_0.Add("NovelKeyword", Localization.Get("获得小说主角(关键字)正则，替换标签♂\r\n支持多模板"));
			this.hashtable_0.Add("NovelDegree", Localization.Get("获得写作进程正则(请把全本小说替换成完成、完结、完本)，替换标签♂\r\n支持多模板"));
			this.hashtable_0.Add("NovelCover", Localization.Get("获得小说封面正则，替换标签♂\r\n支持多模板"));
			this.hashtable_0.Add("NovelDefaultCoverUrl", Localization.Get("目标站默认封面地址\n遇到这个地址就不采集它的封面"));
			this.hashtable_0.Add("NovelInfo_GetNovelPubKey", Localization.Get("获得小说公众目录页地址正则\r\n支持多模板"));
			this.hashtable_0.Add("NovelInfo_GetNovelVipKey", Localization.Get("获得小说VIP目录页地址正则\r\n支持多模板\r\n这个一般无用，可留空"));
			this.hashtable_0.Add("PubCookies", Localization.Get("访问公众版需要登陆的Cookies\r\n一般无关，小说阅读网需要这个"));
			this.hashtable_0.Add("PubIndexUrl", Localization.Get("公众目录页地址 可调用{NovelPubKey} {NovelKey}变量"));
			this.hashtable_0.Add("PubIndexErr", Localization.Get("公众目录页错误识别标记"));
			this.hashtable_0.Add("PubVolumeContent", Localization.Get("获得目录部分关键HTML，一般可留空，替换标签♂\r\n替换支持{$分类名称$} {$小说名称$} {$小说作者$}变量"));
			this.hashtable_0.Add("PubVolumeSplit", Localization.Get("分割分卷"));
			this.hashtable_0.Add("PubVolumeName", Localization.Get("获得分卷名，替换标签♂\r\n支持多模板"));
			this.hashtable_0.Add("PubChapterName", Localization.Get("获得章节名，替换标签♂\r\n替换支持{$分类名称$} {$小说名称$} {$小说作者$} {$书卷名称$}变量"));
			this.hashtable_0.Add("PubChapter_GetChapterKey", Localization.Get("获得章节地址(章节编号)，所获得的数量必须和章节名相同。记录变量{ChapterKey}"));
			this.hashtable_0.Add("PubContentUrl", Localization.Get("章节内容页地址 可调用{ChapterKey} {NovelKey}变量"));
			this.hashtable_0.Add("PubContentErr", Localization.Get("章节内容页错误识别标记"));
			this.hashtable_0.Add("PubContent_GetTextKey", Localization.Get("内容页中真实内容有JS调用的，获得JS地址 记录变量{TextKey}"));
			this.hashtable_0.Add("PubTextUrl", Localization.Get("组合真实内容地址"));
			this.hashtable_0.Add("PubContentText", Localization.Get("获得章节内容的正则，替换标签♂\r\n支持多模板"));
			this.hashtable_0.Add("PubContentChapterName", Localization.Get("获得章节修正名称的正则，自动修复列表名称，替换标签♂\r\n支持多模板\r\n(此为高级功能，用于防采集列表替换章节名称)"));
			this.hashtable_0.Add("PubContentChapterNum", Localization.Get("获得章节修正名称的数量(此为高级功能，用于防采集列表替换章节名称的数量，从尾章节向前数)"));
			this.hashtable_0.Add("PubContentReplace", Localization.Get("章节内容替换规则(替换获取图片后)\r\n每行一个替换，格式如下\r\n需要替换的内容♂替换结果\r\n<div.+?>  这个表示过滤\r\n<div.+?>♂<br>  这个表示替换"));
		}

		private void button_0_Click(object sender, EventArgs e)
		{
			this.ruleConfigInfo_0 = (RuleConfigInfo)ConfigFileManager.LoadConfig(this.comboBox_0.Text, this.ruleConfigInfo_0);
			this.propertyInfo_0 = this.ruleConfigInfo_0.GetType().GetProperties();
			for (int i = 0; i < (int)this.propertyInfo_0.Length; i++)
			{
				this.listBox_0.Items.Add(this.propertyInfo_0[i].Name);
			}
			this.button_0.Enabled = false;
			this.comboBox_0.Enabled = false;
			this.button_1.Enabled = true;
			ConfigFileManager.SaveConfig(this.comboBox_0.Text, this.ruleConfigInfo_0);
		}

		private void button_1_Click(object sender, EventArgs e)
		{
			this.method_0();
			this.int_0 = -1;
			ConfigFileManager.SaveConfig(this.comboBox_0.Text, this.ruleConfigInfo_0);
			this.button_0.Enabled = true;
			this.comboBox_0.Enabled = true;
			this.listBox_0.Items.Clear();
			this.comboBox_0.Items.Clear();
			string[] strArrays = IO.LoadRules();
			if ((int)strArrays.Length > 0)
			{
				string[] strArrays1 = strArrays;
				for (int i = 0; i < (int)strArrays1.Length; i++)
				{
					object obj = strArrays1[i];
					this.comboBox_0.Items.Add(obj);
				}
				this.comboBox_0.Text = this.comboBox_0.Items[0].ToString();
			}
		}

		private void button_2_Click(object sender, EventArgs e)
		{
			string[] strArrays = IO.LoadRules();
			this.comboBox_0.Items.Clear();
			if ((int)strArrays.Length > 0)
			{
				string[] strArrays1 = strArrays;
				for (int i = 0; i < (int)strArrays1.Length; i++)
				{
					object obj = strArrays1[i];
					this.comboBox_0.Items.Add(obj);
				}
				this.comboBox_0.Text = this.comboBox_0.Items[0].ToString();
			}
			this.listBox_0.Items.Clear();
			this.button_0.Enabled = true;
			this.comboBox_0.Enabled = true;
		}

		private void button_3_Click(object sender, EventArgs e)
		{
			if (!this.button_0.Enabled)
			{
				this.method_0();
				this.ruleTestForm_0.Rule = this.ruleConfigInfo_0;
				this.ruleTestForm_0.Task = this.taskConfigInfo_0;
				this.ruleTestForm_0.NovelID = this.textBox_4.Text;
				this.ruleTestForm_0.ChapterID = this.textBox_5.Text;
				this.ruleTestForm_0.ShowDialog();
			}
			else
			{
				MessageBox.Show(Localization.Get("我靠，你也得先把规则载入了再测试啊。"));
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(RuleForm));
			this.listBox_0 = new ListBox();
			this.comboBox_0 = new ComboBox();
			this.textBox_0 = new TextBox();
			this.textBox_1 = new TextBox();
			this.comboBox_1 = new ComboBox();
			this.checkBox_0 = new CheckBox();
			this.button_0 = new Button();
			this.button_1 = new Button();
			this.button_2 = new Button();
			this.checkBox_1 = new CheckBox();
			this.toolTip_0 = new ToolTip(this.components);
			this.textBox_4 = new TextBox();
			this.textBox_5 = new TextBox();
			this.button_3 = new Button();
			this.textBox_2 = new TextBox();
			this.textBox_3 = new TextBox();
			this.groupBox_0 = new GroupBox();
			this.groupBox_1 = new GroupBox();
			this.groupBox_2 = new GroupBox();
			this.groupBox_0.SuspendLayout();
			this.groupBox_1.SuspendLayout();
			this.groupBox_2.SuspendLayout();
			base.SuspendLayout();
			this.listBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
			this.listBox_0.DrawMode = DrawMode.OwnerDrawFixed;
			this.listBox_0.FormattingEnabled = true;
			this.listBox_0.ItemHeight = 12;
			this.listBox_0.Location = new Point(12, 38);
			this.listBox_0.Name = "listBox_0";
			this.listBox_0.Size = new System.Drawing.Size(200, 340);
			this.listBox_0.TabIndex = 0;
			this.listBox_0.DrawItem += new DrawItemEventHandler(this.listBox_0_DrawItem);
			this.listBox_0.SelectedIndexChanged += new EventHandler(this.listBox_0_SelectedIndexChanged);
			this.comboBox_0.FormattingEnabled = true;
			this.comboBox_0.Location = new Point(12, 12);
			this.comboBox_0.Name = "comboBox_0";
			this.comboBox_0.Size = new System.Drawing.Size(200, 20);
			this.comboBox_0.TabIndex = 1;
			this.textBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.textBox_0.Location = new Point(6, 42);
			this.textBox_0.Multiline = true;
			this.textBox_0.Name = "textBox_0";
			this.textBox_0.ScrollBars = ScrollBars.Vertical;
			this.textBox_0.Size = new System.Drawing.Size(458, 70);
			this.textBox_0.TabIndex = 2;
			this.textBox_0.Text = Localization.Get("采集规则框");
			this.textBox_1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.textBox_1.Location = new Point(6, 20);
			this.textBox_1.Name = "textBox_1";
			this.textBox_1.ReadOnly = true;
			this.textBox_1.Size = new System.Drawing.Size(458, 21);
			this.textBox_1.TabIndex = 3;
			this.textBox_1.Text = Localization.Get("规则名称框");
			this.comboBox_1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.comboBox_1.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_1.FormattingEnabled = true;
			ComboBox.ObjectCollection items = this.comboBox_1.Items;
			object[] objArray = new object[] { "Url", "Match", "Matches", "Spilt", "Replace", "Other" };
			items.AddRange(objArray);
			this.comboBox_1.Location = new Point(346, 18);
			this.comboBox_1.Name = "comboBox_1";
			this.comboBox_1.Size = new System.Drawing.Size(118, 20);
			this.comboBox_1.TabIndex = 4;
			this.checkBox_0.AutoSize = true;
			this.checkBox_0.Location = new Point(6, 20);
			this.checkBox_0.Name = "checkBox_0";
			this.checkBox_0.Size = new System.Drawing.Size(96, 16);
			this.checkBox_0.TabIndex = 5;
			this.checkBox_0.Text = Localization.Get("不区分大小写");
			this.toolTip_0.SetToolTip(this.checkBox_0, Localization.Get("指定不区分大小写的匹配"));
			this.checkBox_0.UseVisualStyleBackColor = true;
			this.button_0.Location = new Point(218, 12);
			this.button_0.Name = "button_0";
			this.button_0.Size = new System.Drawing.Size(75, 20);
			this.button_0.TabIndex = 7;
			this.button_0.Text = Localization.Get("载入");
			this.button_0.UseVisualStyleBackColor = true;
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.button_1.Enabled = false;
			this.button_1.Location = new Point(299, 11);
			this.button_1.Name = "button_1";
			this.button_1.Size = new System.Drawing.Size(75, 20);
			this.button_1.TabIndex = 8;
			this.button_1.Text = Localization.Get("保存");
			this.button_1.UseVisualStyleBackColor = true;
			this.button_1.Click += new EventHandler(this.button_1_Click);
			this.button_2.Location = new Point(380, 12);
			this.button_2.Name = "button_2";
			this.button_2.Size = new System.Drawing.Size(75, 20);
			this.button_2.TabIndex = 9;
			this.button_2.Text = Localization.Get("刷新");
			this.button_2.UseVisualStyleBackColor = true;
			this.button_2.Click += new EventHandler(this.button_2_Click);
			this.checkBox_1.AutoSize = true;
			this.checkBox_1.Location = new Point(108, 20);
			this.checkBox_1.Name = "checkBox_1";
			this.checkBox_1.Size = new System.Drawing.Size(72, 16);
			this.checkBox_1.TabIndex = 10;
			this.checkBox_1.Text = Localization.Get("单行模式");
			this.toolTip_0.SetToolTip(this.checkBox_1, Localization.Get("制定单行模式。使 . 匹配任意字符(包括换行字符)"));
			this.checkBox_1.UseVisualStyleBackColor = true;
			this.textBox_4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.textBox_4.Location = new Point(472, 11);
			this.textBox_4.Name = "textBox_4";
			this.textBox_4.Size = new System.Drawing.Size(65, 21);
			this.textBox_4.TabIndex = 14;
			this.textBox_4.Text = "0";
			this.toolTip_0.SetToolTip(this.textBox_4, Localization.Get("单本测试 - 小说ID"));
			this.textBox_5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.textBox_5.Location = new Point(543, 11);
			this.textBox_5.Name = "textBox_5";
			this.textBox_5.Size = new System.Drawing.Size(65, 21);
			this.textBox_5.TabIndex = 16;
			this.textBox_5.Text = "0";
			this.toolTip_0.SetToolTip(this.textBox_5, Localization.Get("单本测试 - 章节ID"));
			this.button_3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.button_3.Location = new Point(613, 11);
			this.button_3.Name = "button_3";
			this.button_3.Size = new System.Drawing.Size(75, 20);
			this.button_3.TabIndex = 11;
			this.button_3.Text = Localization.Get("测试规则");
			this.button_3.UseVisualStyleBackColor = true;
			this.button_3.Click += new EventHandler(this.button_3_Click);
			this.textBox_2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.textBox_2.Location = new Point(6, 47);
			this.textBox_2.Multiline = true;
			this.textBox_2.Name = "textBox_2";
			this.textBox_2.ReadOnly = true;
			this.textBox_2.ScrollBars = ScrollBars.Vertical;
			this.textBox_2.Size = new System.Drawing.Size(458, 64);
			this.textBox_2.TabIndex = 13;
			this.textBox_2.Text = Localization.Get("规则说明框");
			this.textBox_3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.textBox_3.Location = new Point(6, 20);
			this.textBox_3.Multiline = true;
			this.textBox_3.Name = "textBox_3";
			this.textBox_3.ScrollBars = ScrollBars.Vertical;
			this.textBox_3.Size = new System.Drawing.Size(458, 68);
			this.textBox_3.TabIndex = 15;
			this.textBox_3.Text = Localization.Get("替换规则框");
			this.groupBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.groupBox_0.Controls.Add(this.textBox_1);
			this.groupBox_0.Controls.Add(this.textBox_2);
			this.groupBox_0.Location = new Point(218, 38);
			this.groupBox_0.Name = "groupBox_0";
			this.groupBox_0.Size = new System.Drawing.Size(470, 117);
			this.groupBox_0.TabIndex = 16;
			this.groupBox_0.TabStop = false;
			this.groupBox_0.Text = Localization.Get("规则名称");
			this.groupBox_1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.groupBox_1.Controls.Add(this.checkBox_0);
			this.groupBox_1.Controls.Add(this.comboBox_1);
			this.groupBox_1.Controls.Add(this.checkBox_1);
			this.groupBox_1.Controls.Add(this.textBox_0);
			this.groupBox_1.Location = new Point(218, 161);
			this.groupBox_1.Name = "groupBox_1";
			this.groupBox_1.Size = new System.Drawing.Size(470, 118);
			this.groupBox_1.TabIndex = 17;
			this.groupBox_1.TabStop = false;
			this.groupBox_1.Text = Localization.Get("采集规则");
			this.groupBox_2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.groupBox_2.Controls.Add(this.textBox_3);
			this.groupBox_2.Location = new Point(218, 285);
			this.groupBox_2.Name = "groupBox_2";
			this.groupBox_2.Size = new System.Drawing.Size(470, 94);
			this.groupBox_2.TabIndex = 18;
			this.groupBox_2.TabStop = false;
			this.groupBox_2.Text = Localization.Get("替换规则");
			base.ClientSize = new System.Drawing.Size(700, 390);
			base.Controls.Add(this.textBox_5);
			base.Controls.Add(this.groupBox_2);
			base.Controls.Add(this.textBox_4);
			base.Controls.Add(this.groupBox_1);
			base.Controls.Add(this.groupBox_0);
			base.Controls.Add(this.button_3);
			base.Controls.Add(this.button_2);
			base.Controls.Add(this.button_1);
			base.Controls.Add(this.button_0);
			base.Controls.Add(this.comboBox_0);
			base.Controls.Add(this.listBox_0);
			this.Font = new System.Drawing.Font(Localization.Get("宋体"), 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
			base.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "RuleForm";
			this.Text = Localization.Get("规则管理器");
			base.Load += new EventHandler(this.RuleForm_Load);
			this.groupBox_0.ResumeLayout(false);
			this.groupBox_0.PerformLayout();
			this.groupBox_1.ResumeLayout(false);
			this.groupBox_1.PerformLayout();
			this.groupBox_2.ResumeLayout(false);
			this.groupBox_2.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private void listBox_0_DrawItem(object sender, DrawItemEventArgs e)
		{
			Brush black = Brushes.Black;
			if (e.Index > -1)
			{
				if ((this.listBox_0.Items[e.Index].ToString() == "PubContentChapterName" ? true : this.listBox_0.Items[e.Index].ToString() == "PubContentChapterNum"))
				{
					black = Brushes.Red;
				}
				e.DrawBackground();
				e.Graphics.DrawString(this.listBox_0.Items[e.Index].ToString(), e.Font, black, e.Bounds);
				e.DrawFocusRectangle();
			}
		}

		private void listBox_0_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.method_0();
			if (!this.button_0.Enabled)
			{
				int selectedIndex = this.listBox_0.SelectedIndex;
				if (selectedIndex != -1)
				{
					this.textBox_1.Text = this.propertyInfo_0[selectedIndex].Name;
					this.textBox_2.Text = this.hashtable_0[this.propertyInfo_0[selectedIndex].Name].ToString();
					if (this.propertyInfo_0[selectedIndex].PropertyType != typeof(RegexInfo))
					{
						this.comboBox_1.Text = "Other";
						try
						{
							this.textBox_0.Text = this.propertyInfo_0[selectedIndex].GetValue(this.ruleConfigInfo_0, null).ToString();
							this.textBox_3.Text = "";
						}
						catch
						{
							this.textBox_0.Text = "";
							this.textBox_3.Text = "";
						}
					}
					else
					{
						RegexInfo value = (RegexInfo)this.propertyInfo_0[selectedIndex].GetValue(this.ruleConfigInfo_0, null) ?? new RegexInfo();
						this.comboBox_1.Text = value.Method;
						this.textBox_0.Text = value.Pattern.Trim().Replace("\r", "").Replace("\n\n", "\n").Replace("\n\n", "\n").Replace("\n\n", "\n").Replace("\n", "\r\n");
						this.textBox_3.Text = value.FilterPattern.Replace("\r", "").Replace("\n\n", "\n").Replace("\n\n", "\n").Replace("\n\n", "\n").Replace("\n", "\r\n");
						this.checkBox_0.Checked = false;
						this.checkBox_1.Checked = false;
						if (value.Options == RegexOptions.IgnoreCase)
						{
							this.checkBox_0.Checked = true;
						}
						if (value.Options == RegexOptions.Singleline)
						{
							this.checkBox_1.Checked = true;
						}
						if (value.Options == (RegexOptions.IgnoreCase | RegexOptions.Singleline))
						{
							this.checkBox_0.Checked = true;
							this.checkBox_1.Checked = true;
						}
					}
				}
			}
		}

		private void method_0()
		{
			if (this.int_0 >= 0)
			{
				int int0 = this.int_0;
				this.textBox_1.Text = this.propertyInfo_0[int0].Name;
				if (this.propertyInfo_0[int0].PropertyType != typeof(RegexInfo))
				{
					this.propertyInfo_0[int0].SetValue(this.ruleConfigInfo_0, this.textBox_0.Text, null);
				}
				else
				{
					RegexInfo regexInfo = new RegexInfo()
					{
						RegexName = this.textBox_1.Text,
						Method = this.comboBox_1.Text,
						Pattern = this.textBox_0.Text,
						FilterPattern = this.textBox_3.Text,
						Options = RegexOptions.None
					};
					RegexInfo regexInfo1 = regexInfo;
					if (this.checkBox_0.Checked)
					{
						regexInfo1.Options = RegexOptions.IgnoreCase;
					}
					if (this.checkBox_1.Checked)
					{
						regexInfo1.Options = RegexOptions.Singleline;
					}
					if ((!this.checkBox_0.Checked ? false : this.checkBox_1.Checked))
					{
						regexInfo1.Options = RegexOptions.IgnoreCase | RegexOptions.Singleline;
					}
					this.propertyInfo_0[int0].SetValue(this.ruleConfigInfo_0, regexInfo1, null);
				}
			}
			this.int_0 = this.listBox_0.SelectedIndex;
		}

		private void RuleForm_Load(object sender, EventArgs e)
		{
			string[] strArrays = IO.LoadRules();
			if ((int)strArrays.Length > 0)
			{
				string[] strArrays1 = strArrays;
				for (int i = 0; i < (int)strArrays1.Length; i++)
				{
					object obj = strArrays1[i];
					this.comboBox_0.Items.Add(obj);
				}
				this.comboBox_0.Text = this.comboBox_0.Items[0].ToString();
			}
			this.taskConfigInfo_0 = (TaskConfigInfo)ConfigFileManager.LoadConfig("TaskConfig.xml", this.taskConfigInfo_0);
		}
	}
}