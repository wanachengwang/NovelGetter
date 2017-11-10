using NovelSpider.Common;
using NovelSpider.Config;
using NovelSpider.Local;
using NovelSpider.Local.Jieqi;
using NovelSpider.Local.Qiwen;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Resources;
using System.Threading;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace NovelSpider
{
	public class ConfigForm : DockContent
	{
		private Button button_0;

		private Button button_1;

		private Button button1;

		private Button button2;

		private CheckBox checkBox_0;

		private CheckBox checkBox_1;

		private CheckBox checkBox_10;

		private CheckBox checkBox_11;

		private CheckBox checkBox_13;

		private CheckBox checkBox_14;

		private CheckBox checkBox_15;

		private CheckBox checkBox_16;

		private CheckBox checkBox_17;

		private CheckBox checkBox_18;

		private CheckBox checkBox_19;

		private CheckBox checkBox_2;

		private CheckBox checkBox_25;

		private CheckBox checkBox_26;

		private CheckBox checkBox_5;

		private CheckBox checkBox_6;

		private CheckBox checkBox_7;

		private CheckBox checkBox2;

		private CheckBox checkBox3;

		private CheckedListBox checkedListBox_0;

		private ComboBox comboBox_0;

		private ComboBox comboBox_1;

		private ComboBox comboBox_3;

		private ComboBox comboBox_4;

		private ComboBox comboBox3;

		private FolderBrowserDialog folderBrowserDialog_0;

		private FontDialog fontDialog_0;

		private GroupBox groupBox_0;

		private GroupBox groupBox_1;

		private GroupBox groupBox_3;

		private GroupBox groupBox_4;

		private GroupBox groupBox_6;

		private GroupBox groupBox_8;

		private GroupBox groupBox1;

		private GroupBox groupBox2;

		private GroupBox groupBox3;

		private GroupBox groupBox4;

		private GroupBox groupBox5;

		private IContainer icontainer_0;

		private Label label_0;

		private Label label_1;

		private Label label_11;

		private Label label_15;

		private Label label_16;

		private Label label_17;

		private Label label_18;

		private Label label_19;

		private Label label_2;

		private Label label_20;

		private Label label_29;

		private Label label_3;

		private Label label_31;

		private Label label_32;

		private Label label_37;

		private Label label_38;

		private Label label_39;

		private Label label_4;

		private Label label_40;

		private Label label_49;

		private Label label_5;

		private Label label_50;

		private Label label_51;

		private Label label_54;

		private Label label_55;

		private Label label_58;

		private Label label_63;

		private Label label_64;

		private Label label_65;

		private Label label_66;

		private Label label_7;

		private Label label_8;

		private Label label_9;

		private Label label1;

		private Label label10;

		private Label label11;

		private Label label12;

		private Label label13;

		private Label label14;

		private Label label15;

		private Label label17;

		private Label label19;

		private Label label2;

		private Label label20;

		private Label label21;

		private Label label22;

		private Label label23;

		private Label label24;

		private Label label25;

		private Label label3;

		private Label label4;

		private Label label5;

		private Label label6;

		private Label label7;

		private Label label8;

		private Label label9;

		private LinkLabel linkLabel_11;

		private LinkLabel linkLabel_5;

		private LinkLabel linkLabel_6;

		private LinkLabel linkLabel_7;

		private LinkLabel linkLabel_8;

		private LinkLabel linkLabel_9;

		private MaskedTextBox maskedTextBox2;

		private MaskedTextBox maskedTextBox3;

		private MaskedTextBox maskedTextBox4;

		private TextBox NullchapterBox;

		private NumericUpDown numericUpDown_0;

		private NumericUpDown numericUpDown_2;

		private NumericUpDown numericUpDown1;

		private NumericUpDown numericUpDown2;

		private NumericUpDown numericUpDown3;

		private NumericUpDown numericUpDown5;

		private NumericUpDown numericUpDown6;

		private NumericUpDown numericUpDown7;

		private NumericUpDown numericUpDown8;

		private ComboBox NumOrPinyincomboBox;

		private ComboBox NumOrPinyinDircomboBox;

		private OpenFileDialog openFileDialog_0;

		private CheckBox OpenNullChapterBox;

		private ComboBox sqliteTime;

		private string[] string_0;

		public TabControl tabControl1;

		private TabPage tabPage_0;

		private TabPage tabPage_1;

		private TabPage tabPage_2;

		private TabPage tabPage_4;

		private TabPage tabPage_5;

		private TabPage tabPage_8;

		private TabPage tabPage1;

		private TabPage tabPage2;

		private TextBox textBox_0;

		private TextBox textBox_1;

		private TextBox textBox_10;

		private TextBox textBox_12;

		private TextBox textBox_14;

		private TextBox textBox_2;

		private TextBox textBox_20;

		private TextBox textBox_21;

		private TextBox textBox_29;

		private TextBox textBox_3;

		private TextBox textBox_30;

		private TextBox textBox_31;

		private TextBox textBox_32;

		private TextBox textBox_33;

		private TextBox textBox_36;

		private TextBox textBox_37;

		private TextBox textBox_4;

		private TextBox textBox_40;

		private TextBox textBox_41;

		private TextBox textBox_45;

		private TextBox textBox_46;

		private TextBox textBox_47;

		private TextBox textBox_49;

		private TextBox textBox_5;

		private TextBox textBox_65;

		private TextBox textBox_66;

		private TextBox textBox_67;

		private TextBox textBox_7;

		private TextBox textBox_8;

		private ToolTip toolTip_0;

		private MaskedTextBox WebSiteName;

		private IContainer components;

		private Label label28;

		private TextBox textBox2;

		private Label label29;

		private TextBox textBox3;

		private NumericUpDown numericUpDown9;

		private Label label30;

		private TextBox textBox4;

		private Label label31;

		private Button button3;

		public BackgroundWorker MailWorker;

		private Button button4;

		private ComboBox comboBox1;

		private Label label32;

		private Label label33;

		private TextBox textBox5;

		private NumericUpDown numericUpDown10;

		private Label label35;

		private Label label34;

		private LinkLabel linkLabel1;

		private TextBox textBox6;

		private NumericUpDown numericUpDown4;

		private Label label18;

		private Label label16;

		private Label label36;

		private Label label37;

		private TextBox textBox1;

		private Label label26;

		public BackgroundWorker backgroundWorker1;

		private CheckBox ZhanQun;

		private WebBrowser webBrowser;

		private string picPath;

		private string imgPath;

		private bool picEnd;

		private int imgWidth;

		private int imgHeight;

		private string text;

		public ConfigForm()
		{
			Class19.Q77LubhzKM3NS();
			string[] strArrays = new string[] {
                Localization.Get("0 未知错误"),
                Localization.Get("21 FTP负载失败"),
                Localization.Get("101 子窗口冲突"),
                Localization.Get("102 检查子窗口冲突失败"),
                Localization.Get("120 对比最新章节失败"),
                Localization.Get("121 空章节"),
                Localization.Get("122 检查到重复章节"),
                Localization.Get("124 只采集文字章节时发现图片章节"),
                Localization.Get("125 设置不添加新书"),
                Localization.Get("130 限制章节字数小于多少字的章节不采集"),
                Localization.Get("131 章节数量小于限制"),
                Localization.Get("132 对比最新章节成功！但需要采集到章节数超限。"),
                Localization.Get("134 限制小说_黑名单"),
                Localization.Get("135 限制小说_不在白名单"),
                Localization.Get("136 过滤分卷名"),
                Localization.Get("137 章节名过滤（章节名过滤作者名、自定义过滤）"),
                Localization.Get("200 小说信息页发生问题"),
                Localization.Get("210 小说目录页发生问题"),
                Localization.Get("214 章节组为空"),
                Localization.Get("220 小说内容页发生问题"),
                Localization.Get("410 操作本站小说列表发生问题"),
                Localization.Get("420 操作本站小说信息发生问题"),
                Localization.Get("430 操作本站章节列表发生问题"),
                Localization.Get("440 操作本站章节信息发生问题"),
                Localization.Get("441 InsertChapter发生问题"),
                Localization.Get("442 UpdateChapter发生问题"),
            };
			this.string_0 = strArrays;
			this.picPath = string.Concat(Application.StartupPath, "\\images\\test.jpg");
			this.imgPath = string.Empty;
			this.picEnd = false;
			this.imgWidth = 0;
			this.imgHeight = 0;
			this.text = string.Empty;
			this.InitializeComponent();
		}

		private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
		{
			if (!this.backgroundWorker1.CancellationPending)
			{
				if (File.Exists(this.imgPath))
				{
					Image image = Image.FromFile(this.imgPath);
					this.imgWidth = image.Width;
					this.imgHeight = image.Height;
					image.Dispose();
				}
				this.webBrowser.Navigate(this.imgPath);
				int num = 0;
				while (true)
				{
					if (num < 10000)
					{
						Thread.Sleep(100);
						if (this.picEnd)
						{
							break;
						}
						else
						{
							num++;
						}
					}
					else
					{
						break;
					}
				}
				try
				{
					this.text = WaterMark.ImgToText(this.picPath);
				}
				catch (Exception exception)
				{
					this.text = exception.Message;
				}
			}
			else
			{
				e.Cancel = true;
			}
		}

		private void button_0_Click(object sender, EventArgs e)
		{
			this.method_1();
			NovelSpider.Local.LocalProvider.ResetProvider();
			base.Close();
		}

		private void button_1_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (Configs.CmsName == "Qiwen")
			{
				MessageBox.Show(Localization.Get("暂不支持"));
			}
			else
			{
				NovelSpider.Local.LocalProvider.GetInstance().PinyinHua("");
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Configs.BaseConfig.MailSmtp = this.textBox3.Text;
			Configs.BaseConfig.MailUser = this.textBox2.Text;
			Configs.BaseConfig.MailPass = this.textBox4.Text;
			Configs.BaseConfig.MailTitle = this.textBox_36.Text;
			this.button3.Enabled = false;
			if (!this.MailWorker.IsBusy)
			{
				this.MailWorker.RunWorkerAsync();
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			Configs.BaseConfig.ConnectionString = this.textBox_7.Text.Trim();
			string str = "";
			if (Configs.BaseConfig.ConnectionString.IndexOf("Server=") < 0)
			{
				str = "select VERSION()";
				try
				{
					str = MySql.Data.MySqlClient.MySqlHelper.ExecuteScalar(Configs.BaseConfig.ConnectionString, CommandType.Text, str.ToString(), null).ToString();
				}
				catch (Exception exception)
				{
					str = exception.Message;
				}
			}
			else
			{
				str = "select @@version";
				try
				{
					str = SqlHelper.ExecuteScalar(Configs.BaseConfig.ConnectionString, CommandType.Text, str.ToString(), null).ToString();
				}
				catch (Exception exception1)
				{
					str = exception1.Message;
				}
			}
			MessageBox.Show(str);
		}

		private void comboBox_1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.comboBox_1.Text.ToLower() != "jieqi".ToLower())
			{
				this.comboBox_0.Items.Clear();
				this.comboBox_0.Items.Add("201312");
				this.comboBox_0.Items.Add("201501");
			}
			else
			{
				this.comboBox_0.Items.Clear();
				this.comboBox_0.Items.Add("1.7");
				this.comboBox_0.Items.Add("1.8");
			}
		}

		private void ConfigForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason.ToString() != "MdiFormClosing")
			{
				base.Hide();
			}
			else
			{
				Application.Exit();
			}
			e.Cancel = true;
		}

		private void ConfigForm_Load(object sender, EventArgs e)
		{
			this.button_1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			if (Configs.CmsName.ToLower() != Localization.Get("杰奇小说").ToLower())
			{
				this.comboBox_0.Items.Add("201312");
				this.comboBox_0.Items.Add("201501");
			}
			else
			{
				this.comboBox_0.Items.Clear();
				this.comboBox_0.Items.Add("1.7");
				this.comboBox_0.Items.Add("1.8");
			}
			this.method_0();
			if (!Configs.BaseConfig.LicenseVip)
			{
				this.groupBox1.Enabled = false;
				this.groupBox4.Enabled = false;
			}
			if (Configs.HaveFunction.IndexOf("ZhanQun") < 0)
			{
				this.ZhanQun.Enabled = false;
				this.button2.Enabled = false;
			}
			this.checkBox_26.Checked = false;
			this.checkBox_26.Enabled = false;
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(ConfigForm));
			this.tabControl1 = new TabControl();
			this.tabPage_2 = new TabPage();
			this.textBox1 = new TextBox();
			this.label26 = new Label();
			this.button4 = new Button();
			this.button3 = new Button();
			this.label28 = new Label();
			this.textBox2 = new TextBox();
			this.label29 = new Label();
			this.textBox3 = new TextBox();
			this.numericUpDown9 = new NumericUpDown();
			this.label30 = new Label();
			this.textBox4 = new TextBox();
			this.label31 = new Label();
			this.sqliteTime = new ComboBox();
			this.label17 = new Label();
			this.WebSiteName = new MaskedTextBox();
			this.checkBox_26 = new CheckBox();
			this.comboBox_4 = new ComboBox();
			this.label_66 = new Label();
			this.label_58 = new Label();
			this.comboBox_3 = new ComboBox();
			this.label_55 = new Label();
			this.label_54 = new Label();
			this.linkLabel_11 = new LinkLabel();
			this.textBox_36 = new TextBox();
			this.label_38 = new Label();
			this.label_39 = new Label();
			this.textBox_37 = new TextBox();
			this.numericUpDown_2 = new NumericUpDown();
			this.label_37 = new Label();
			this.linkLabel_9 = new LinkLabel();
			this.linkLabel_8 = new LinkLabel();
			this.checkBox_7 = new CheckBox();
			this.linkLabel_7 = new LinkLabel();
			this.linkLabel_5 = new LinkLabel();
			this.linkLabel_6 = new LinkLabel();
			this.textBox_29 = new TextBox();
			this.label_29 = new Label();
			this.comboBox_1 = new ComboBox();
			this.label_7 = new Label();
			this.comboBox_0 = new ComboBox();
			this.label_31 = new Label();
			this.label_8 = new Label();
			this.textBox_7 = new TextBox();
			this.label1 = new Label();
			this.label_9 = new Label();
			this.textBox_8 = new TextBox();
			this.tabPage_0 = new TabPage();
			this.checkBox_5 = new CheckBox();
			this.checkBox_6 = new CheckBox();
			this.label_0 = new Label();
			this.textBox_0 = new TextBox();
			this.label_1 = new Label();
			this.textBox_1 = new TextBox();
			this.textBox_2 = new TextBox();
			this.label_2 = new Label();
			this.textBox_3 = new TextBox();
			this.label_3 = new Label();
			this.tabPage1 = new TabPage();
			this.groupBox1 = new GroupBox();
			this.textBox5 = new TextBox();
			this.label33 = new Label();
			this.comboBox1 = new ComboBox();
			this.label32 = new Label();
			this.numericUpDown7 = new NumericUpDown();
			this.label23 = new Label();
			this.numericUpDown6 = new NumericUpDown();
			this.label21 = new Label();
			this.comboBox3 = new ComboBox();
			this.numericUpDown3 = new NumericUpDown();
			this.numericUpDown2 = new NumericUpDown();
			this.maskedTextBox4 = new MaskedTextBox();
			this.label9 = new Label();
			this.label4 = new Label();
			this.label11 = new Label();
			this.label10 = new Label();
			this.groupBox4 = new GroupBox();
			this.label37 = new Label();
			this.label36 = new Label();
			this.numericUpDown4 = new NumericUpDown();
			this.label18 = new Label();
			this.label16 = new Label();
			this.numericUpDown10 = new NumericUpDown();
			this.label35 = new Label();
			this.label34 = new Label();
			this.linkLabel1 = new LinkLabel();
			this.textBox6 = new TextBox();
			this.button2 = new Button();
			this.numericUpDown1 = new NumericUpDown();
			this.ZhanQun = new CheckBox();
			this.label15 = new Label();
			this.label8 = new Label();
			this.groupBox3 = new GroupBox();
			this.label19 = new Label();
			this.button1 = new Button();
			this.label12 = new Label();
			this.label7 = new Label();
			this.label6 = new Label();
			this.label5 = new Label();
			this.NumOrPinyinDircomboBox = new ComboBox();
			this.NumOrPinyincomboBox = new ComboBox();
			this.label14 = new Label();
			this.groupBox2 = new GroupBox();
			this.checkBox3 = new CheckBox();
			this.numericUpDown5 = new NumericUpDown();
			this.maskedTextBox3 = new MaskedTextBox();
			this.maskedTextBox2 = new MaskedTextBox();
			this.label3 = new Label();
			this.checkBox2 = new CheckBox();
			this.label2 = new Label();
			this.label13 = new Label();
			this.tabPage_1 = new TabPage();
			this.textBox_65 = new TextBox();
			this.label_63 = new Label();
			this.label_64 = new Label();
			this.textBox_67 = new TextBox();
			this.textBox_66 = new TextBox();
			this.checkBox_25 = new CheckBox();
			this.checkBox_18 = new CheckBox();
			this.textBox_49 = new TextBox();
			this.checkBox_19 = new CheckBox();
			this.checkBox_17 = new CheckBox();
			this.textBox_45 = new TextBox();
			this.checkBox_14 = new CheckBox();
			this.textBox_46 = new TextBox();
			this.checkBox_15 = new CheckBox();
			this.textBox_47 = new TextBox();
			this.checkBox_16 = new CheckBox();
			this.label_11 = new Label();
			this.textBox_10 = new TextBox();
			this.textBox_12 = new TextBox();
			this.textBox_14 = new TextBox();
			this.checkBox_0 = new CheckBox();
			this.checkBox_1 = new CheckBox();
			this.checkBox_2 = new CheckBox();
			this.tabPage2 = new TabPage();
			this.groupBox5 = new GroupBox();
			this.label25 = new Label();
			this.numericUpDown8 = new NumericUpDown();
			this.label24 = new Label();
			this.label22 = new Label();
			this.OpenNullChapterBox = new CheckBox();
			this.NullchapterBox = new TextBox();
			this.label20 = new Label();
			this.tabPage_4 = new TabPage();
			this.checkBox_13 = new CheckBox();
			this.groupBox_8 = new GroupBox();
			this.textBox_40 = new TextBox();
			this.label_49 = new Label();
			this.textBox_41 = new TextBox();
			this.label_50 = new Label();
			this.checkBox_10 = new CheckBox();
			this.checkBox_11 = new CheckBox();
			this.groupBox_0 = new GroupBox();
			this.textBox_20 = new TextBox();
			this.groupBox_1 = new GroupBox();
			this.label_40 = new Label();
			this.numericUpDown_0 = new NumericUpDown();
			this.label_19 = new Label();
			this.textBox_21 = new TextBox();
			this.label_20 = new Label();
			this.tabPage_5 = new TabPage();
			this.groupBox_6 = new GroupBox();
			this.textBox_33 = new TextBox();
			this.groupBox_3 = new GroupBox();
			this.textBox_30 = new TextBox();
			this.groupBox_4 = new GroupBox();
			this.label_32 = new Label();
			this.textBox_32 = new TextBox();
			this.textBox_31 = new TextBox();
			this.tabPage_8 = new TabPage();
			this.label_65 = new Label();
			this.checkedListBox_0 = new CheckedListBox();
			this.textBox_4 = new TextBox();
			this.label_4 = new Label();
			this.textBox_5 = new TextBox();
			this.label_5 = new Label();
			this.button_0 = new Button();
			this.button_1 = new Button();
			this.label_15 = new Label();
			this.label_16 = new Label();
			this.label_17 = new Label();
			this.label_18 = new Label();
			this.fontDialog_0 = new FontDialog();
			this.openFileDialog_0 = new OpenFileDialog();
			this.toolTip_0 = new ToolTip(this.components);
			this.folderBrowserDialog_0 = new FolderBrowserDialog();
			this.label_51 = new Label();
			this.MailWorker = new BackgroundWorker();
			this.backgroundWorker1 = new BackgroundWorker();
			this.webBrowser = new WebBrowser();
			this.tabControl1.SuspendLayout();
			this.tabPage_2.SuspendLayout();
			((ISupportInitialize)this.numericUpDown9).BeginInit();
			((ISupportInitialize)this.numericUpDown_2).BeginInit();
			this.tabPage_0.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((ISupportInitialize)this.numericUpDown7).BeginInit();
			((ISupportInitialize)this.numericUpDown6).BeginInit();
			((ISupportInitialize)this.numericUpDown3).BeginInit();
			((ISupportInitialize)this.numericUpDown2).BeginInit();
			this.groupBox4.SuspendLayout();
			((ISupportInitialize)this.numericUpDown4).BeginInit();
			((ISupportInitialize)this.numericUpDown10).BeginInit();
			((ISupportInitialize)this.numericUpDown1).BeginInit();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((ISupportInitialize)this.numericUpDown5).BeginInit();
			this.tabPage_1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.groupBox5.SuspendLayout();
			((ISupportInitialize)this.numericUpDown8).BeginInit();
			this.tabPage_4.SuspendLayout();
			this.groupBox_8.SuspendLayout();
			this.groupBox_0.SuspendLayout();
			this.groupBox_1.SuspendLayout();
			((ISupportInitialize)this.numericUpDown_0).BeginInit();
			this.tabPage_5.SuspendLayout();
			this.groupBox_6.SuspendLayout();
			this.groupBox_3.SuspendLayout();
			this.groupBox_4.SuspendLayout();
			this.tabPage_8.SuspendLayout();
			base.SuspendLayout();
			this.tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.tabControl1.Controls.Add(this.tabPage_2);
			this.tabControl1.Controls.Add(this.tabPage_0);
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage_1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage_4);
			this.tabControl1.Controls.Add(this.tabPage_5);
			this.tabControl1.Controls.Add(this.tabPage_8);
			this.tabControl1.Location = new Point(12, 12);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(820, 350);
			this.tabControl1.TabIndex = 0;
			this.tabPage_2.Controls.Add(this.textBox1);
			this.tabPage_2.Controls.Add(this.label26);
			this.tabPage_2.Controls.Add(this.button4);
			this.tabPage_2.Controls.Add(this.button3);
			this.tabPage_2.Controls.Add(this.label28);
			this.tabPage_2.Controls.Add(this.textBox2);
			this.tabPage_2.Controls.Add(this.label29);
			this.tabPage_2.Controls.Add(this.textBox3);
			this.tabPage_2.Controls.Add(this.numericUpDown9);
			this.tabPage_2.Controls.Add(this.label30);
			this.tabPage_2.Controls.Add(this.textBox4);
			this.tabPage_2.Controls.Add(this.label31);
			this.tabPage_2.Controls.Add(this.sqliteTime);
			this.tabPage_2.Controls.Add(this.label17);
			this.tabPage_2.Controls.Add(this.WebSiteName);
			this.tabPage_2.Controls.Add(this.checkBox_26);
			this.tabPage_2.Controls.Add(this.comboBox_4);
			this.tabPage_2.Controls.Add(this.label_66);
			this.tabPage_2.Controls.Add(this.label_58);
			this.tabPage_2.Controls.Add(this.comboBox_3);
			this.tabPage_2.Controls.Add(this.label_55);
			this.tabPage_2.Controls.Add(this.label_54);
			this.tabPage_2.Controls.Add(this.linkLabel_11);
			this.tabPage_2.Controls.Add(this.textBox_36);
			this.tabPage_2.Controls.Add(this.label_38);
			this.tabPage_2.Controls.Add(this.label_39);
			this.tabPage_2.Controls.Add(this.textBox_37);
			this.tabPage_2.Controls.Add(this.numericUpDown_2);
			this.tabPage_2.Controls.Add(this.label_37);
			this.tabPage_2.Controls.Add(this.linkLabel_9);
			this.tabPage_2.Controls.Add(this.linkLabel_8);
			this.tabPage_2.Controls.Add(this.checkBox_7);
			this.tabPage_2.Controls.Add(this.linkLabel_7);
			this.tabPage_2.Controls.Add(this.linkLabel_5);
			this.tabPage_2.Controls.Add(this.linkLabel_6);
			this.tabPage_2.Controls.Add(this.textBox_29);
			this.tabPage_2.Controls.Add(this.label_29);
			this.tabPage_2.Controls.Add(this.comboBox_1);
			this.tabPage_2.Controls.Add(this.label_7);
			this.tabPage_2.Controls.Add(this.comboBox_0);
			this.tabPage_2.Controls.Add(this.label_31);
			this.tabPage_2.Controls.Add(this.label_8);
			this.tabPage_2.Controls.Add(this.textBox_7);
			this.tabPage_2.Controls.Add(this.label1);
			this.tabPage_2.Controls.Add(this.label_9);
			this.tabPage_2.Controls.Add(this.textBox_8);
			this.tabPage_2.Location = new Point(4, 22);
			this.tabPage_2.Name = "tabPage_2";
			this.tabPage_2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage_2.Size = new System.Drawing.Size(812, 324);
			this.tabPage_2.TabIndex = 0;
			this.tabPage_2.Text = Localization.Get("基本设置");
			this.tabPage_2.UseVisualStyleBackColor = true;
			this.textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.textBox1.Location = new Point(10, 297);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ScrollBars = ScrollBars.Vertical;
			this.textBox1.Size = new System.Drawing.Size(796, 22);
			this.textBox1.TabIndex = 60;
			this.label26.AutoSize = true;
			this.label26.Location = new Point(9, 282);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(329, 12);
			this.label26.TabIndex = 59;
			this.label26.Text = Localization.Get("单词循环后笤俑页面地址，一行一个(可用于更新网站地图等)");
			this.button4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.button4.Location = new Point(717, 58);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(89, 23);
			this.button4.TabIndex = 58;
			this.button4.Text = Localization.Get("测试数据库");
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new EventHandler(this.button4_Click);
			this.button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.button3.Location = new Point(731, 255);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 57;
			this.button3.Text = Localization.Get("测试发信");
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new EventHandler(this.button3_Click);
			this.label28.AutoSize = true;
			this.label28.Location = new Point(160, 201);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(71, 12);
			this.label28.TabIndex = 56;
			this.label28.Text = Localization.Get("EMail用户名");
			this.textBox2.Location = new Point(162, 216);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(146, 21);
			this.textBox2.TabIndex = 55;
			this.label29.AutoSize = true;
			this.label29.Location = new Point(7, 201);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(113, 12);
			this.label29.TabIndex = 54;
			this.label29.Text = Localization.Get("发送报告Smtp服务器");
			this.textBox3.Location = new Point(9, 216);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(145, 21);
			this.textBox3.TabIndex = 53;
			this.numericUpDown9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.numericUpDown9.Location = new Point(630, 256);
			NumericUpDown num = this.numericUpDown9;
			int[] numArray = new int[] { 180, 0, 0, 0 };
			num.Maximum = new decimal(numArray);
			NumericUpDown numericUpDown = this.numericUpDown9;
			numArray = new int[] { 10, 0, 0, 0 };
			numericUpDown.Minimum = new decimal(numArray);
			this.numericUpDown9.Name = "numericUpDown9";
			this.numericUpDown9.Size = new System.Drawing.Size(94, 21);
			this.numericUpDown9.TabIndex = 52;
			NumericUpDown num1 = this.numericUpDown9;
			numArray = new int[] { 60, 0, 0, 0 };
			num1.Value = new decimal(numArray);
			this.label30.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.label30.AutoSize = true;
			this.label30.Location = new Point(630, 241);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(89, 12);
			this.label30.TabIndex = 51;
			this.label30.Text = Localization.Get("发送间隔(分钟)");
			this.textBox4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.textBox4.Location = new Point(318, 216);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(305, 21);
			this.textBox4.TabIndex = 50;
			this.label31.AutoSize = true;
			this.label31.Location = new Point(316, 201);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(143, 12);
			this.label31.TabIndex = 49;
			this.label31.Text = Localization.Get("EMail密码(不用邮件留空)");
			this.toolTip_0.SetToolTip(this.label31, Localization.Get("当获取分卷名为空的时候替换此分卷名"));
			this.sqliteTime.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.sqliteTime.FormattingEnabled = true;
			ComboBox.ObjectCollection items = this.sqliteTime.Items;
			object[] objArray = new object[] { "1", "7", "30" };
			items.AddRange(objArray);
			this.sqliteTime.Location = new Point(629, 176);
			this.sqliteTime.Name = "sqliteTime";
			this.sqliteTime.Size = new System.Drawing.Size(177, 20);
			this.sqliteTime.TabIndex = 48;
			this.label17.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.label17.AutoSize = true;
			this.label17.Location = new Point(627, 161);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(77, 12);
			this.label17.TabIndex = 47;
			this.label17.Text = Localization.Get("日志保存周期");
			this.WebSiteName.Location = new Point(8, 21);
			this.WebSiteName.Name = "WebSiteName";
			this.WebSiteName.Size = new System.Drawing.Size(113, 21);
			this.WebSiteName.TabIndex = 46;
			this.checkBox_26.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.checkBox_26.AutoSize = true;
			this.checkBox_26.Location = new Point(715, 100);
			this.checkBox_26.Name = "checkBox_26";
			this.checkBox_26.Size = new System.Drawing.Size(60, 16);
			this.checkBox_26.TabIndex = 45;
			this.checkBox_26.Text = Localization.Get("中译英");
			this.checkBox_26.UseVisualStyleBackColor = true;
			this.comboBox_4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.comboBox_4.FormattingEnabled = true;
			ComboBox.ObjectCollection objectCollections = this.comboBox_4.Items;
			objArray = new object[] { "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)", "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.0)", "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1)", "Mozilla/5.0 (compatible; Googlebot/2.1; +http://www.google.com/bot.html)", "Mozilla/5.0 (compatible; Yahoo! Slurp; http://help.yahoo.com/help/us/ysearch/slurp)", "Mozilla/5.0 (Windows; U; Windows NT 5.1; sv-SE; rv:1.7.5) Gecko/20041108 Firefox/1.0", "Mozilla/5.0 (iPhone; U; CPU iPhone OS 3_0 like Mac OS X; en-us) AppleWebKit/528.18 (KHTML, like Gecko) Version/4.0 Mobile/7A341 Safari/528.16", "Mozilla/5.0 (Windows; U; Windows NT 5.1; de; rv:1.8.1.8) Gecko/20071008 SeaMonkey/1.0", "Mozilla/5.0 (Macintosh; U; PPC Mac OS X Mach-O; en-US; rv:1.7.2) Gecko/20040825 Camino/0.8.1", "msnbot/1.1 (+http://search.msn.com/msnbot.htm)", "Baiduspider+(+http://www.baidu.com/search/spider.htm)" };
			objectCollections.AddRange(objArray);
			this.comboBox_4.Location = new Point(8, 136);
			this.comboBox_4.Name = "comboBox_4";
			this.comboBox_4.Size = new System.Drawing.Size(615, 20);
			this.comboBox_4.TabIndex = 44;
			this.label_66.AutoSize = true;
			this.label_66.Location = new Point(6, 121);
			this.label_66.Name = "label_66";
			this.label_66.Size = new System.Drawing.Size(89, 12);
			this.label_66.TabIndex = 43;
			this.label_66.Text = "Http UserAgent";
			this.label_58.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.label_58.AutoSize = true;
			this.label_58.Location = new Point(627, 199);
			this.label_58.Name = "label_58";
			this.label_58.Size = new System.Drawing.Size(77, 12);
			this.label_58.TabIndex = 42;
			this.label_58.Text = Localization.Get("日志记录模式");
			this.comboBox_3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.comboBox_3.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_3.FormattingEnabled = true;
			ComboBox.ObjectCollection items1 = this.comboBox_3.Items;
			objArray = new object[] { Localization.Get("Log文本模式"), Localization.Get("SQLite模式") };
			items1.AddRange(objArray);
			this.comboBox_3.Location = new Point(629, 214);
			this.comboBox_3.Name = "comboBox_3";
			this.comboBox_3.Size = new System.Drawing.Size(177, 20);
			this.comboBox_3.TabIndex = 41;
			this.label_55.AutoSize = true;
			this.label_55.ForeColor = Color.Red;
			this.label_55.Location = new Point(113, 45);
			this.label_55.Name = "label_55";
			this.label_55.Size = new System.Drawing.Size(89, 12);
			this.label_55.TabIndex = 36;
			this.label_55.Text = Localization.Get("需要重启采集器");
			this.label_54.AutoSize = true;
			this.label_54.ForeColor = Color.Red;
			this.label_54.Location = new Point(208, 6);
			this.label_54.Name = "label_54";
			this.label_54.Size = new System.Drawing.Size(89, 12);
			this.label_54.TabIndex = 35;
			this.label_54.Text = Localization.Get("需要重启采集器");
			this.linkLabel_11.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.linkLabel_11.AutoSize = true;
			this.linkLabel_11.Location = new Point(552, 177);
			this.linkLabel_11.Name = "linkLabel_11";
			this.linkLabel_11.Size = new System.Drawing.Size(71, 12);
			this.linkLabel_11.TabIndex = 34;
			this.linkLabel_11.TabStop = true;
			this.linkLabel_11.Text = Localization.Get("获取COOKIES");
			this.textBox_36.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.textBox_36.Location = new Point(11, 255);
			this.textBox_36.Name = "textBox_36";
			this.textBox_36.ScrollBars = ScrollBars.Vertical;
			this.textBox_36.Size = new System.Drawing.Size(612, 21);
			this.textBox_36.TabIndex = 33;
			this.label_38.AutoSize = true;
			this.label_38.Location = new Point(7, 242);
			this.label_38.Name = "label_38";
			this.label_38.Size = new System.Drawing.Size(461, 12);
			this.label_38.TabIndex = 32;
			this.label_38.Text = Localization.Get("接收报告的邮箱(多个用半角逗号分开，留空为不发送，接收邮箱不要与发信邮箱相同)");
			this.label_39.AutoSize = true;
			this.label_39.Location = new Point(6, 159);
			this.label_39.Name = "label_39";
			this.label_39.Size = new System.Drawing.Size(329, 12);
			this.label_39.TabIndex = 31;
			this.label_39.Text = Localization.Get("本地网站后台COOKIES (调用后台功能时需要，一般不用设置)");
			this.textBox_37.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.textBox_37.Location = new Point(9, 176);
			this.textBox_37.Name = "textBox_37";
			this.textBox_37.Size = new System.Drawing.Size(538, 21);
			this.textBox_37.TabIndex = 30;
			this.numericUpDown_2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.numericUpDown_2.Location = new Point(629, 137);
			this.numericUpDown_2.Name = "numericUpDown_2";
			this.numericUpDown_2.Size = new System.Drawing.Size(177, 21);
			this.numericUpDown_2.TabIndex = 29;
			this.label_37.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.label_37.AutoSize = true;
			this.label_37.Location = new Point(629, 122);
			this.label_37.Name = "label_37";
			this.label_37.Size = new System.Drawing.Size(77, 12);
			this.label_37.TabIndex = 28;
			this.label_37.Text = Localization.Get("HTTP超时(秒)");
			this.linkLabel_9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.linkLabel_9.AutoSize = true;
			this.linkLabel_9.Location = new Point(674, 63);
			this.linkLabel_9.Name = "linkLabel_9";
			this.linkLabel_9.Size = new System.Drawing.Size(35, 12);
			this.linkLabel_9.TabIndex = 27;
			this.linkLabel_9.TabStop = true;
			this.linkLabel_9.Text = "MYSQL";
			this.linkLabel_9.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel_9_LinkClicked);
			this.linkLabel_8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.linkLabel_8.AutoSize = true;
			this.linkLabel_8.Location = new Point(631, 63);
			this.linkLabel_8.Name = "linkLabel_8";
			this.linkLabel_8.Size = new System.Drawing.Size(35, 12);
			this.linkLabel_8.TabIndex = 26;
			this.linkLabel_8.TabStop = true;
			this.linkLabel_8.Text = "MSSQL";
			this.linkLabel_8.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel_8_LinkClicked);
			this.checkBox_7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.checkBox_7.AutoSize = true;
			this.checkBox_7.Location = new Point(631, 101);
			this.checkBox_7.Name = "checkBox_7";
			this.checkBox_7.Size = new System.Drawing.Size(78, 16);
			this.checkBox_7.TabIndex = 25;
			this.checkBox_7.Text = Localization.Get("Debug模式");
			this.checkBox_7.UseVisualStyleBackColor = true;
			this.linkLabel_7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.linkLabel_7.AutoSize = true;
			this.linkLabel_7.Enabled = false;
			this.linkLabel_7.Location = new Point(748, 24);
			this.linkLabel_7.Name = "linkLabel_7";
			this.linkLabel_7.Size = new System.Drawing.Size(53, 12);
			this.linkLabel_7.TabIndex = 24;
			this.linkLabel_7.TabStop = true;
			this.linkLabel_7.Text = Localization.Get("载入设置");
			this.linkLabel_5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.linkLabel_5.AutoSize = true;
			this.linkLabel_5.Enabled = false;
			this.linkLabel_5.Location = new Point(689, 24);
			this.linkLabel_5.Name = "linkLabel_5";
			this.linkLabel_5.Size = new System.Drawing.Size(53, 12);
			this.linkLabel_5.TabIndex = 23;
			this.linkLabel_5.TabStop = true;
			this.linkLabel_5.Text = Localization.Get("查看配置");
			this.linkLabel_6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.linkLabel_6.AutoSize = true;
			this.linkLabel_6.Location = new Point(629, 24);
			this.linkLabel_6.Name = "linkLabel_6";
			this.linkLabel_6.Size = new System.Drawing.Size(53, 12);
			this.linkLabel_6.TabIndex = 22;
			this.linkLabel_6.TabStop = true;
			this.linkLabel_6.Text = Localization.Get("选择目录");
			this.linkLabel_6.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel_6_LinkClicked);
			this.textBox_29.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.textBox_29.Location = new Point(226, 99);
			this.textBox_29.Name = "textBox_29";
			this.textBox_29.Size = new System.Drawing.Size(399, 21);
			this.textBox_29.TabIndex = 21;
			this.label_29.AutoSize = true;
			this.label_29.Location = new Point(224, 84);
			this.label_29.Name = "label_29";
			this.label_29.Size = new System.Drawing.Size(65, 12);
			this.label_29.TabIndex = 20;
			this.label_29.Text = Localization.Get("默认分卷名");
			this.toolTip_0.SetToolTip(this.label_29, Localization.Get("当获取分卷名为空的时候替换此分卷名"));
			this.comboBox_1.FormattingEnabled = true;
			ComboBox.ObjectCollection objectCollections1 = this.comboBox_1.Items;
			objArray = new object[] { Localization.Get("杰奇小说"), Localization.Get("奇文站群") };
			objectCollections1.AddRange(objArray);
			this.comboBox_1.Location = new Point(8, 99);
			this.comboBox_1.Name = "comboBox_1";
			this.comboBox_1.Size = new System.Drawing.Size(100, 20);
			this.comboBox_1.TabIndex = 19;
			this.comboBox_1.SelectedIndexChanged += new EventHandler(this.comboBox_1_SelectedIndexChanged);
			this.label_7.AutoSize = true;
			this.label_7.Location = new Point(6, 84);
			this.label_7.Name = "label_7";
			this.label_7.Size = new System.Drawing.Size(77, 12);
			this.label_7.TabIndex = 15;
			this.label_7.Text = Localization.Get("入库小说系统");
			this.comboBox_0.FormattingEnabled = true;
			ComboBox.ObjectCollection items2 = this.comboBox_0.Items;
			objArray = new object[] { "201312", "201501" };
			items2.AddRange(objArray);
			this.comboBox_0.Location = new Point(114, 99);
			this.comboBox_0.Name = "comboBox_0";
			this.comboBox_0.Size = new System.Drawing.Size(100, 20);
			this.comboBox_0.TabIndex = 14;
			this.label_31.AutoSize = true;
			this.label_31.Location = new Point(112, 84);
			this.label_31.Name = "label_31";
			this.label_31.Size = new System.Drawing.Size(77, 12);
			this.label_31.TabIndex = 13;
			this.label_31.Text = Localization.Get("小说系统版本");
			this.label_8.AutoSize = true;
			this.label_8.Location = new Point(6, 45);
			this.label_8.Name = "label_8";
			this.label_8.Size = new System.Drawing.Size(101, 12);
			this.label_8.TabIndex = 11;
			this.label_8.Text = Localization.Get("数据库连接字符串");
			this.textBox_7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.textBox_7.Location = new Point(8, 60);
			this.textBox_7.Name = "textBox_7";
			this.textBox_7.Size = new System.Drawing.Size(615, 21);
			this.textBox_7.TabIndex = 10;
			this.label1.AutoSize = true;
			this.label1.Location = new Point(6, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 12);
			this.label1.TabIndex = 3;
			this.label1.Text = Localization.Get("网站名称");
			this.label_9.AutoSize = true;
			this.label_9.Location = new Point(125, 6);
			this.label_9.Name = "label_9";
			this.label_9.Size = new System.Drawing.Size(77, 12);
			this.label_9.TabIndex = 3;
			this.label_9.Text = Localization.Get("本地网站目录");
			this.textBox_8.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.textBox_8.Location = new Point(127, 21);
			this.textBox_8.Name = "textBox_8";
			this.textBox_8.Size = new System.Drawing.Size(496, 21);
			this.textBox_8.TabIndex = 2;
			this.tabPage_0.Controls.Add(this.checkBox_5);
			this.tabPage_0.Controls.Add(this.checkBox_6);
			this.tabPage_0.Controls.Add(this.label_0);
			this.tabPage_0.Controls.Add(this.textBox_0);
			this.tabPage_0.Controls.Add(this.label_1);
			this.tabPage_0.Controls.Add(this.textBox_1);
			this.tabPage_0.Controls.Add(this.textBox_2);
			this.tabPage_0.Controls.Add(this.label_2);
			this.tabPage_0.Controls.Add(this.textBox_3);
			this.tabPage_0.Controls.Add(this.label_3);
			this.tabPage_0.Location = new Point(4, 22);
			this.tabPage_0.Name = "tabPage_0";
			this.tabPage_0.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage_0.Size = new System.Drawing.Size(812, 324);
			this.tabPage_0.TabIndex = 1;
			this.tabPage_0.Text = Localization.Get("分类对应");
			this.tabPage_0.UseVisualStyleBackColor = true;
			this.checkBox_5.AutoSize = true;
			this.checkBox_5.Location = new Point(311, 169);
			this.checkBox_5.Name = "checkBox_5";
			this.checkBox_5.Size = new System.Drawing.Size(108, 16);
			this.checkBox_5.TabIndex = 10;
			this.checkBox_5.Text = Localization.Get("不使用默认小类");
			this.checkBox_5.UseVisualStyleBackColor = true;
			this.checkBox_6.AutoSize = true;
			this.checkBox_6.Location = new Point(311, 8);
			this.checkBox_6.Name = "checkBox_6";
			this.checkBox_6.Size = new System.Drawing.Size(108, 16);
			this.checkBox_6.TabIndex = 9;
			this.checkBox_6.Text = Localization.Get("不使用默认大类");
			this.checkBox_6.UseVisualStyleBackColor = true;
			this.label_0.AutoSize = true;
			this.label_0.Location = new Point(7, 170);
			this.label_0.Name = "label_0";
			this.label_0.Size = new System.Drawing.Size(65, 12);
			this.label_0.TabIndex = 8;
			this.label_0.Text = Localization.Get("小类对应：");
			this.textBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.textBox_0.Location = new Point(7, 194);
			this.textBox_0.Multiline = true;
			this.textBox_0.Name = "textBox_0";
			this.textBox_0.ScrollBars = ScrollBars.Vertical;
			this.textBox_0.Size = new System.Drawing.Size(799, 124);
			this.textBox_0.TabIndex = 7;
			this.label_1.AutoSize = true;
			this.label_1.Location = new Point(7, 9);
			this.label_1.Name = "label_1";
			this.label_1.Size = new System.Drawing.Size(65, 12);
			this.label_1.TabIndex = 6;
			this.label_1.Text = Localization.Get("大类对应：");
			this.textBox_1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.textBox_1.Location = new Point(7, 33);
			this.textBox_1.Multiline = true;
			this.textBox_1.Name = "textBox_1";
			this.textBox_1.ScrollBars = ScrollBars.Vertical;
			this.textBox_1.Size = new System.Drawing.Size(799, 128);
			this.textBox_1.TabIndex = 5;
			this.textBox_2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.textBox_2.Location = new Point(656, 167);
			this.textBox_2.Name = "textBox_2";
			this.textBox_2.Size = new System.Drawing.Size(150, 21);
			this.textBox_2.TabIndex = 3;
			this.label_2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.label_2.AutoSize = true;
			this.label_2.Location = new Point(585, 170);
			this.label_2.Name = "label_2";
			this.label_2.Size = new System.Drawing.Size(65, 12);
			this.label_2.TabIndex = 2;
			this.label_2.Text = Localization.Get("默认小类：");
			this.textBox_3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.textBox_3.Location = new Point(656, 6);
			this.textBox_3.Name = "textBox_3";
			this.textBox_3.Size = new System.Drawing.Size(150, 21);
			this.textBox_3.TabIndex = 1;
			this.label_3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.label_3.AutoSize = true;
			this.label_3.Location = new Point(585, 9);
			this.label_3.Name = "label_3";
			this.label_3.Size = new System.Drawing.Size(65, 12);
			this.label_3.TabIndex = 0;
			this.label_3.Text = Localization.Get("默认大类：");
			this.tabPage1.Controls.Add(this.groupBox1);
			this.tabPage1.Controls.Add(this.groupBox4);
			this.tabPage1.Controls.Add(this.groupBox3);
			this.tabPage1.Controls.Add(this.groupBox2);
			this.tabPage1.Location = new Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(812, 324);
			this.tabPage1.TabIndex = 10;
			this.tabPage1.Text = Localization.Get("高级设置");
			this.tabPage1.UseVisualStyleBackColor = true;
			this.groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.groupBox1.Controls.Add(this.textBox5);
			this.groupBox1.Controls.Add(this.label33);
			this.groupBox1.Controls.Add(this.comboBox1);
			this.groupBox1.Controls.Add(this.label32);
			this.groupBox1.Controls.Add(this.numericUpDown7);
			this.groupBox1.Controls.Add(this.label23);
			this.groupBox1.Controls.Add(this.numericUpDown6);
			this.groupBox1.Controls.Add(this.label21);
			this.groupBox1.Controls.Add(this.comboBox3);
			this.groupBox1.Controls.Add(this.numericUpDown3);
			this.groupBox1.Controls.Add(this.numericUpDown2);
			this.groupBox1.Controls.Add(this.maskedTextBox4);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Location = new Point(6, 92);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(800, 120);
			this.groupBox1.TabIndex = 69;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = Localization.Get("SEO优化（高级授权服务）");
			this.textBox5.Location = new Point(76, 78);
			this.textBox5.Multiline = true;
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(611, 36);
			this.textBox5.TabIndex = 79;
			this.toolTip_0.SetToolTip(this.textBox5, Localization.Get("模版设置说明：\r\n小说地址\t\t{NovelUrl}\r\n\r\n小说名称\t\t{NovelTitle}\r\n小说封面\t            {NovelPic}\t"));
			this.label33.AutoSize = true;
			this.label33.Location = new Point(9, 81);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(65, 12);
			this.label33.TabIndex = 78;
			this.label33.Text = Localization.Get("内链接模版");
			AutoCompleteStringCollection autoCompleteCustomSource = this.comboBox1.AutoCompleteCustomSource;
			string[] strArrays = new string[] { Localization.Get("默认"), "/", Localization.Get("无需后缀") };
			autoCompleteCustomSource.AddRange(strArrays);
			this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox1.FormattingEnabled = true;
			ComboBox.ObjectCollection objectCollections2 = this.comboBox1.Items;
			objArray = new object[] {
                Localization.Get("后台推荐"),
                Localization.Get("日点击榜"),
                Localization.Get("周点击榜"),
                Localization.Get("总点击榜"),
                Localization.Get("日投票榜"),
                Localization.Get("周投票榜"),
                Localization.Get("月投票榜"),
                Localization.Get("总投票榜"),
            };
			objectCollections2.AddRange(objArray);
			this.comboBox1.Location = new Point(581, 46);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(106, 20);
			this.comboBox1.TabIndex = 77;
			this.toolTip_0.SetToolTip(this.comboBox1, Localization.Get("提取推荐榜的形式，自行推荐可在后台推荐。"));
			this.label32.AutoSize = true;
			this.label32.Location = new Point(486, 49);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(89, 12);
			this.label32.TabIndex = 76;
			this.label32.Text = Localization.Get("推荐榜获取形式");
			this.numericUpDown7.Location = new Point(428, 43);
			this.numericUpDown7.Name = "numericUpDown7";
			this.numericUpDown7.Size = new System.Drawing.Size(41, 21);
			this.numericUpDown7.TabIndex = 75;
			this.toolTip_0.SetToolTip(this.numericUpDown7, Localization.Get("0为不推荐，调用使用{?$tuijian?}"));
			this.label23.AutoSize = true;
			this.label23.Location = new Point(363, 49);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(65, 12);
			this.label23.TabIndex = 74;
			this.label23.Text = Localization.Get("内容推荐数");
			this.numericUpDown6.Location = new Point(314, 43);
			this.numericUpDown6.Name = "numericUpDown6";
			this.numericUpDown6.Size = new System.Drawing.Size(41, 21);
			this.numericUpDown6.TabIndex = 73;
			this.toolTip_0.SetToolTip(this.numericUpDown6, Localization.Get("0为不推荐，调用使用{?$tuijian?}"));
			this.label21.AutoSize = true;
			this.label21.Location = new Point(249, 49);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(65, 12);
			this.label21.TabIndex = 72;
			this.label21.Text = Localization.Get("目录推荐数");
			AutoCompleteStringCollection autoCompleteStringCollections = this.comboBox3.AutoCompleteCustomSource;
			strArrays = new string[] { Localization.Get("默认"), "/", Localization.Get("无需后缀") };
			autoCompleteStringCollections.AddRange(strArrays);
			this.comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox3.FormattingEnabled = true;
			ComboBox.ObjectCollection items3 = this.comboBox3.Items;
			objArray = new object[] { Localization.Get("后台默认"), "/" };
			items3.AddRange(objArray);
			this.comboBox3.Location = new Point(581, 14);
			this.comboBox3.Name = "comboBox3";
			this.comboBox3.Size = new System.Drawing.Size(106, 20);
			this.comboBox3.TabIndex = 71;
			this.toolTip_0.SetToolTip(this.comboBox3, Localization.Get("内容页上一页下一页后缀调说明：\r\n后台默认    直接读取网站后台的设置\r\n/               章节ID后面带/\r\n不需要       直接为章节ID"));
			this.numericUpDown3.Location = new Point(196, 43);
			this.numericUpDown3.Name = "numericUpDown3";
			this.numericUpDown3.Size = new System.Drawing.Size(42, 21);
			this.numericUpDown3.TabIndex = 70;
			this.toolTip_0.SetToolTip(this.numericUpDown3, Localization.Get("0为不推荐，调用使用{?$linju?}"));
			this.numericUpDown2.Location = new Point(76, 43);
			this.numericUpDown2.Name = "numericUpDown2";
			this.numericUpDown2.Size = new System.Drawing.Size(40, 21);
			this.numericUpDown2.TabIndex = 70;
			this.toolTip_0.SetToolTip(this.numericUpDown2, Localization.Get("0为不推荐，调用使用{?$linju?}"));
			this.maskedTextBox4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.maskedTextBox4.Location = new Point(76, 13);
			this.maskedTextBox4.Name = "maskedTextBox4";
			this.maskedTextBox4.Size = new System.Drawing.Size(393, 21);
			this.maskedTextBox4.TabIndex = 1;
			this.toolTip_0.SetToolTip(this.maskedTextBox4, Localization.Get("内链地址格式设置说明：\r\n小说编号\t\t{NovelId}\r\n小说编号除以1000\t{NovelId/1000}\r\n小说名称拼音\t\t{Pinyin}\r\n小说名称拼音前三\t{Pinyin/3}\r\n地址格式如http://www.xxx.com/{NovelId/1000}/{NovelId}/"));
			this.label9.AutoSize = true;
			this.label9.Location = new Point(9, 49);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(65, 12);
			this.label9.TabIndex = 55;
			this.label9.Text = Localization.Get("目录邻居数");
			this.label4.AutoSize = true;
			this.label4.Location = new Point(9, 17);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(65, 12);
			this.label4.TabIndex = 0;
			this.label4.Text = Localization.Get("排行榜地址");
			this.label11.AutoSize = true;
			this.label11.Location = new Point(486, 17);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(89, 12);
			this.label11.TabIndex = 57;
			this.label11.Text = Localization.Get("内容上下页后缀");
			this.label10.AutoSize = true;
			this.label10.Location = new Point(129, 49);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(65, 12);
			this.label10.TabIndex = 56;
			this.label10.Text = Localization.Get("内容邻居数");
			this.groupBox4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.groupBox4.Controls.Add(this.label37);
			this.groupBox4.Controls.Add(this.label36);
			this.groupBox4.Controls.Add(this.numericUpDown4);
			this.groupBox4.Controls.Add(this.label18);
			this.groupBox4.Controls.Add(this.label16);
			this.groupBox4.Controls.Add(this.numericUpDown10);
			this.groupBox4.Controls.Add(this.label35);
			this.groupBox4.Controls.Add(this.label34);
			this.groupBox4.Controls.Add(this.linkLabel1);
			this.groupBox4.Controls.Add(this.textBox6);
			this.groupBox4.Controls.Add(this.button2);
			this.groupBox4.Controls.Add(this.numericUpDown1);
			this.groupBox4.Controls.Add(this.ZhanQun);
			this.groupBox4.Controls.Add(this.label15);
			this.groupBox4.Controls.Add(this.label8);
			this.groupBox4.Location = new Point(6, 218);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(800, 103);
			this.groupBox4.TabIndex = 68;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = Localization.Get("防采集及站群模式设置（高级授权服务）");
			this.label37.AutoSize = true;
			this.label37.ForeColor = Color.Blue;
			this.label37.Location = new Point(225, 48);
			this.label37.Name = "label37";
			this.label37.Size = new System.Drawing.Size(329, 12);
			this.label37.TabIndex = 80;
			this.label37.Text = Localization.Get("PS:目录页最新章节不参与防采集，调用使用标签{?$new9?}！");
			this.label36.AutoSize = true;
			this.label36.Location = new Point(169, 78);
			this.label36.Name = "label36";
			this.label36.Size = new System.Drawing.Size(41, 12);
			this.label36.TabIndex = 79;
			this.label36.Text = Localization.Get("个章节");
			this.numericUpDown4.Location = new Point(112, 48);
			NumericUpDown numericUpDown1 = this.numericUpDown4;
			numArray = new int[] { 9, 0, 0, 0 };
			numericUpDown1.Maximum = new decimal(numArray);
			this.numericUpDown4.Name = "numericUpDown4";
			this.numericUpDown4.Size = new System.Drawing.Size(51, 21);
			this.numericUpDown4.TabIndex = 78;
			this.toolTip_0.SetToolTip(this.numericUpDown4, Localization.Get("提取目录也最新真实章节数，最多9个章节，调用使用参数{?$new9?}"));
			this.label18.AutoSize = true;
			this.label18.Location = new Point(169, 51);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(41, 12);
			this.label18.TabIndex = 77;
			this.label18.Text = Localization.Get("个章节");
			this.label16.AutoSize = true;
			this.label16.Location = new Point(9, 50);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(101, 12);
			this.label16.TabIndex = 76;
			this.label16.Text = Localization.Get("目录页最新章节数");
			this.numericUpDown10.Location = new Point(112, 76);
			this.numericUpDown10.Name = "numericUpDown10";
			this.numericUpDown10.Size = new System.Drawing.Size(51, 21);
			this.numericUpDown10.TabIndex = 75;
			this.label35.AutoSize = true;
			this.label35.Location = new Point(9, 78);
			this.label35.Name = "label35";
			this.label35.Size = new System.Drawing.Size(101, 12);
			this.label35.TabIndex = 74;
			this.label35.Text = Localization.Get("目录页模拟章节数");
			this.label34.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.label34.AutoSize = true;
			this.label34.Location = new Point(224, 78);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(77, 12);
			this.label34.TabIndex = 73;
			this.label34.Text = Localization.Get("模拟章节目录");
			this.linkLabel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Location = new Point(590, 78);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(53, 12);
			this.linkLabel1.TabIndex = 72;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = Localization.Get("选择目录");
			this.linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			this.textBox6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.textBox6.Location = new Point(307, 75);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(274, 21);
			this.textBox6.TabIndex = 71;
			this.toolTip_0.SetToolTip(this.textBox6, Localization.Get("留空为程序根目录下 Txtdir"));
			this.button2.Location = new Point(424, 15);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(97, 23);
			this.button2.TabIndex = 19;
			this.button2.Text = Localization.Get("自动配置站群系统");
			this.button2.UseVisualStyleBackColor = true;
			this.numericUpDown1.Location = new Point(112, 18);
			NumericUpDown num2 = this.numericUpDown1;
			numArray = new int[] { 10000, 0, 0, 0 };
			num2.Maximum = new decimal(numArray);
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(51, 21);
			this.numericUpDown1.TabIndex = 70;
			this.toolTip_0.SetToolTip(this.numericUpDown1, Localization.Get("些处设置章节列表页最后几个章节进行防采集\r\n如：设置2的话则倒数两个章节为防采集章节"));
			this.ZhanQun.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.ZhanQun.AutoSize = true;
			this.ZhanQun.Location = new Point(226, 20);
			this.ZhanQun.Name = "ZhanQun";
			this.ZhanQun.Size = new System.Drawing.Size(192, 16);
			this.ZhanQun.TabIndex = 64;
			this.ZhanQun.Text = Localization.Get("开启站群模式（只对新站使用）");
			this.ZhanQun.UseVisualStyleBackColor = true;
			this.label15.AutoSize = true;
			this.label15.Location = new Point(169, 21);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(41, 12);
			this.label15.TabIndex = 63;
			this.label15.Text = Localization.Get("个章节");
			this.label8.AutoSize = true;
			this.label8.Location = new Point(9, 21);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(101, 12);
			this.label8.TabIndex = 54;
			this.label8.Text = Localization.Get("目录页防采集倒数");
			this.groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.groupBox3.Controls.Add(this.label19);
			this.groupBox3.Controls.Add(this.button1);
			this.groupBox3.Controls.Add(this.label12);
			this.groupBox3.Controls.Add(this.label7);
			this.groupBox3.Controls.Add(this.label6);
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.Controls.Add(this.NumOrPinyinDircomboBox);
			this.groupBox3.Controls.Add(this.NumOrPinyincomboBox);
			this.groupBox3.Controls.Add(this.label14);
			this.groupBox3.Location = new Point(6, 12);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(800, 74);
			this.groupBox3.TabIndex = 67;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = Localization.Get("拼音、数字选择（无需授权）");
			this.label19.AutoSize = true;
			this.label19.ForeColor = Color.Blue;
			this.label19.Location = new Point(355, 47);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(203, 12);
			this.label19.TabIndex = 18;
			this.label19.Text = Localization.Get("PS:数字拼音选择后自动升级数据库！");
			this.button1.Location = new Point(357, 14);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(104, 23);
			this.button1.TabIndex = 17;
			this.button1.Text = Localization.Get("拼音化已有小说");
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new EventHandler(this.button1_Click);
			this.label12.AutoSize = true;
			this.label12.Location = new Point(467, 20);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(161, 12);
			this.label12.TabIndex = 16;
			this.label12.Text = Localization.Get("将数据库已有小说进行拼音化");
			this.label7.AutoSize = true;
			this.label7.Location = new Point(199, 47);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(113, 12);
			this.label7.TabIndex = 12;
			this.label7.Text = Localization.Get("选择生成目录的格式");
			this.label6.AutoSize = true;
			this.label6.Location = new Point(199, 20);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(137, 12);
			this.label6.TabIndex = 11;
			this.label6.Text = Localization.Get("选择生成目录为拼音或ID");
			this.label5.AutoSize = true;
			this.label5.Location = new Point(6, 20);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(89, 12);
			this.label5.TabIndex = 7;
			this.label5.Text = Localization.Get("数字、拼音选择");
			this.NumOrPinyinDircomboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.NumOrPinyinDircomboBox.FormattingEnabled = true;
			ComboBox.ObjectCollection objectCollections3 = this.NumOrPinyinDircomboBox.Items;
			objArray = new object[] { "ID除1000/ID", "ID" };
			objectCollections3.AddRange(objArray);
			this.NumOrPinyinDircomboBox.Location = new Point(101, 44);
			this.NumOrPinyinDircomboBox.Name = "NumOrPinyinDircomboBox";
			this.NumOrPinyinDircomboBox.Size = new System.Drawing.Size(92, 20);
			this.NumOrPinyinDircomboBox.TabIndex = 10;
			AutoCompleteStringCollection autoCompleteCustomSource1 = this.NumOrPinyincomboBox.AutoCompleteCustomSource;
			strArrays = new string[] { Localization.Get("数字"), Localization.Get("拼音") };
			autoCompleteCustomSource1.AddRange(strArrays);
			this.NumOrPinyincomboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.NumOrPinyincomboBox.FormattingEnabled = true;
			ComboBox.ObjectCollection items4 = this.NumOrPinyincomboBox.Items;
			objArray = new object[] { Localization.Get("数字ID目录"), Localization.Get("拼音目录") };
			items4.AddRange(objArray);
			this.NumOrPinyincomboBox.Location = new Point(101, 17);
			this.NumOrPinyincomboBox.Name = "NumOrPinyincomboBox";
			this.NumOrPinyincomboBox.Size = new System.Drawing.Size(92, 20);
			this.NumOrPinyincomboBox.TabIndex = 9;
			this.NumOrPinyincomboBox.SelectedIndexChanged += new EventHandler(this.NumOrPinyincomboBox_SelectedIndexChanged);
			this.label14.AutoSize = true;
			this.label14.Location = new Point(6, 47);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(89, 12);
			this.label14.TabIndex = 8;
			this.label14.Text = Localization.Get("生成目录样式：");
			this.groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.groupBox2.Controls.Add(this.checkBox3);
			this.groupBox2.Controls.Add(this.numericUpDown5);
			this.groupBox2.Controls.Add(this.maskedTextBox3);
			this.groupBox2.Controls.Add(this.maskedTextBox2);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.checkBox2);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.label13);
			this.groupBox2.Location = new Point(8, 323);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(800, 99);
			this.groupBox2.TabIndex = 53;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = Localization.Get("内链设置");
			this.groupBox2.Visible = false;
			this.checkBox3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.checkBox3.AutoSize = true;
			this.checkBox3.Location = new Point(728, 20);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(72, 16);
			this.checkBox3.TabIndex = 66;
			this.checkBox3.Text = Localization.Get("启用内链");
			this.toolTip_0.SetToolTip(this.checkBox3, Localization.Get("启用内链说明：\r\n这里设置的整个内链设置里的总开关\r\n如果关闭其他相关的内链设置将无效"));
			this.checkBox3.UseVisualStyleBackColor = true;
			this.numericUpDown5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.numericUpDown5.Location = new Point(610, 16);
			NumericUpDown numericUpDown2 = this.numericUpDown5;
			numArray = new int[] { 5000, 0, 0, 0 };
			numericUpDown2.Maximum = new decimal(numArray);
			this.numericUpDown5.Name = "numericUpDown5";
			this.numericUpDown5.Size = new System.Drawing.Size(112, 21);
			this.numericUpDown5.TabIndex = 70;
			this.toolTip_0.SetToolTip(this.numericUpDown5, Localization.Get("内链密度设置说明：\r\n些处设置章节页内链的密度为多少字加入一个链接\r\n默认为1000字加一个链接"));
			NumericUpDown num3 = this.numericUpDown5;
			numArray = new int[] { 1000, 0, 0, 0 };
			num3.Value = new decimal(numArray);
			this.maskedTextBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.maskedTextBox3.Location = new Point(85, 70);
			this.maskedTextBox3.Name = "maskedTextBox3";
			this.maskedTextBox3.Size = new System.Drawing.Size(709, 21);
			this.maskedTextBox3.TabIndex = 5;
			this.toolTip_0.SetToolTip(this.maskedTextBox3, Localization.Get("长尾词设置说明：\r\n如HTML代码：\r\n其他书友正在看<a href=\"内链地址格式\">XXX最新章节</a>\r\n其中“最新章节”为长尾词\r\n多个推荐词中间可用半角“,”号分开\r\n[NoLink]不加链接的内容[/NoLink]\r\n"));
			this.maskedTextBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.maskedTextBox2.Location = new Point(85, 43);
			this.maskedTextBox2.Name = "maskedTextBox2";
			this.maskedTextBox2.Size = new System.Drawing.Size(589, 21);
			this.maskedTextBox2.TabIndex = 4;
			this.toolTip_0.SetToolTip(this.maskedTextBox2, Localization.Get("推荐词设置说明：\r\n如HTML代码：\r\n其他书友正在看<a href=\"内链地址格式\">XXX小说</a>\r\n其中“其他书友正在看”为推荐词\r\n多个推荐词中间可用半角“,”号分开"));
			this.label3.AutoSize = true;
			this.label3.Location = new Point(7, 74);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(77, 12);
			this.label3.TabIndex = 3;
			this.label3.Text = Localization.Get("长尾词（后）");
			this.checkBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.checkBox2.AutoSize = true;
			this.checkBox2.Location = new Point(680, 45);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(120, 16);
			this.checkBox2.TabIndex = 1;
			this.checkBox2.Text = Localization.Get("启用章节名数字化");
			this.checkBox2.UseVisualStyleBackColor = true;
			this.label2.AutoSize = true;
			this.label2.Location = new Point(7, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(77, 12);
			this.label2.TabIndex = 2;
			this.label2.Text = Localization.Get("推荐词（前）");
			this.label13.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.label13.AutoSize = true;
			this.label13.Location = new Point(527, 21);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(77, 12);
			this.label13.TabIndex = 59;
			this.label13.Text = Localization.Get("内链密度设置");
			this.tabPage_1.Controls.Add(this.textBox_65);
			this.tabPage_1.Controls.Add(this.label_63);
			this.tabPage_1.Controls.Add(this.label_64);
			this.tabPage_1.Controls.Add(this.textBox_67);
			this.tabPage_1.Controls.Add(this.textBox_66);
			this.tabPage_1.Controls.Add(this.checkBox_25);
			this.tabPage_1.Controls.Add(this.checkBox_18);
			this.tabPage_1.Controls.Add(this.textBox_49);
			this.tabPage_1.Controls.Add(this.checkBox_19);
			this.tabPage_1.Controls.Add(this.checkBox_17);
			this.tabPage_1.Controls.Add(this.textBox_45);
			this.tabPage_1.Controls.Add(this.checkBox_14);
			this.tabPage_1.Controls.Add(this.textBox_46);
			this.tabPage_1.Controls.Add(this.checkBox_15);
			this.tabPage_1.Controls.Add(this.textBox_47);
			this.tabPage_1.Controls.Add(this.checkBox_16);
			this.tabPage_1.Controls.Add(this.label_11);
			this.tabPage_1.Controls.Add(this.textBox_10);
			this.tabPage_1.Controls.Add(this.textBox_12);
			this.tabPage_1.Controls.Add(this.textBox_14);
			this.tabPage_1.Controls.Add(this.checkBox_0);
			this.tabPage_1.Controls.Add(this.checkBox_1);
			this.tabPage_1.Controls.Add(this.checkBox_2);
			this.tabPage_1.Location = new Point(4, 22);
			this.tabPage_1.Name = "tabPage_1";
			this.tabPage_1.Size = new System.Drawing.Size(812, 324);
			this.tabPage_1.TabIndex = 2;
			this.tabPage_1.Text = Localization.Get("生成设置");
			this.tabPage_1.UseVisualStyleBackColor = true;
			this.textBox_65.Location = new Point(147, 214);
			this.textBox_65.Multiline = true;
			this.textBox_65.Name = "textBox_65";
			this.textBox_65.ReadOnly = true;
			this.textBox_65.ScrollBars = ScrollBars.Vertical;
			this.textBox_65.Size = new System.Drawing.Size(303, 75);
			this.textBox_65.TabIndex = 55;
			this.label_63.AutoSize = true;
			this.label_63.Location = new Point(456, 250);
			this.label_63.Name = "label_63";
			this.label_63.Size = new System.Drawing.Size(101, 12);
			this.label_63.TabIndex = 54;
			this.label_63.Text = Localization.Get("最后一页的下一页");
			this.label_64.AutoSize = true;
			this.label_64.Location = new Point(454, 211);
			this.label_64.Name = "label_64";
			this.label_64.Size = new System.Drawing.Size(89, 12);
			this.label_64.TabIndex = 53;
			this.label_64.Text = Localization.Get("第一页的上一页");
			this.textBox_67.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.textBox_67.Location = new Point(456, 226);
			this.textBox_67.Name = "textBox_67";
			this.textBox_67.Size = new System.Drawing.Size(350, 21);
			this.textBox_67.TabIndex = 52;
			this.toolTip_0.SetToolTip(this.textBox_67, Localization.Get("自定义第一页的上一页的链接地址,可使用{NovelId}"));
			this.textBox_66.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.textBox_66.Location = new Point(456, 265);
			this.textBox_66.Name = "textBox_66";
			this.textBox_66.Size = new System.Drawing.Size(350, 21);
			this.textBox_66.TabIndex = 51;
			this.toolTip_0.SetToolTip(this.textBox_66, Localization.Get("自定义最后一页的下一页的链接地址,可使用{NovelId}"));
			this.checkBox_25.AutoSize = true;
			this.checkBox_25.Location = new Point(9, 216);
			this.checkBox_25.Name = "checkBox_25";
			this.checkBox_25.Size = new System.Drawing.Size(132, 16);
			this.checkBox_25.TabIndex = 46;
			this.checkBox_25.Text = Localization.Get("启用JS调用真实内容");
			this.checkBox_25.UseVisualStyleBackColor = true;
			this.checkBox_18.AutoSize = true;
			this.checkBox_18.Location = new Point(9, 243);
			this.checkBox_18.Name = "checkBox_18";
			this.checkBox_18.Size = new System.Drawing.Size(132, 16);
			this.checkBox_18.TabIndex = 45;
			this.checkBox_18.Text = Localization.Get("启用自定义生成路径");
			this.checkBox_18.UseVisualStyleBackColor = true;
			this.textBox_49.Location = new Point(147, 106);
			this.textBox_49.Name = "textBox_49";
			this.textBox_49.Size = new System.Drawing.Size(659, 21);
			this.textBox_49.TabIndex = 43;
			this.checkBox_19.AutoSize = true;
			this.checkBox_19.Location = new Point(9, 108);
			this.checkBox_19.Name = "checkBox_19";
			this.checkBox_19.Size = new System.Drawing.Size(114, 16);
			this.checkBox_19.TabIndex = 42;
			this.checkBox_19.Text = Localization.Get("生成索引文件OPF");
			this.checkBox_19.UseVisualStyleBackColor = true;
			this.checkBox_17.AutoSize = true;
			this.checkBox_17.Location = new Point(9, 270);
			this.checkBox_17.Name = "checkBox_17";
			this.checkBox_17.Size = new System.Drawing.Size(132, 16);
			this.checkBox_17.TabIndex = 41;
			this.checkBox_17.Text = Localization.Get("启用自定义HTML模板");
			this.checkBox_17.UseVisualStyleBackColor = true;
			this.textBox_45.Location = new Point(147, 187);
			this.textBox_45.Name = "textBox_45";
			this.textBox_45.Size = new System.Drawing.Size(659, 21);
			this.textBox_45.TabIndex = 40;
			this.checkBox_14.AutoSize = true;
			this.checkBox_14.Enabled = false;
			this.checkBox_14.Location = new Point(9, 189);
			this.checkBox_14.Name = "checkBox_14";
			this.checkBox_14.Size = new System.Drawing.Size(72, 16);
			this.checkBox_14.TabIndex = 39;
			this.checkBox_14.Text = Localization.Get("封面位置");
			this.toolTip_0.SetToolTip(this.checkBox_14, Localization.Get("小说封面储存路径。"));
			this.checkBox_14.UseVisualStyleBackColor = true;
			this.textBox_46.Location = new Point(147, 160);
			this.textBox_46.Name = "textBox_46";
			this.textBox_46.Size = new System.Drawing.Size(659, 21);
			this.textBox_46.TabIndex = 38;
			this.checkBox_15.AutoSize = true;
			this.checkBox_15.Location = new Point(9, 162);
			this.checkBox_15.Name = "checkBox_15";
			this.checkBox_15.Size = new System.Drawing.Size(114, 16);
			this.checkBox_15.TabIndex = 37;
			this.checkBox_15.Text = Localization.Get("生成TXT全文阅读");
			this.toolTip_0.SetToolTip(this.checkBox_15, Localization.Get("把所有章节内容打包TXT的储存位置。"));
			this.checkBox_15.UseVisualStyleBackColor = true;
			this.textBox_47.Location = new Point(147, 133);
			this.textBox_47.Name = "textBox_47";
			this.textBox_47.Size = new System.Drawing.Size(659, 21);
			this.textBox_47.TabIndex = 36;
			this.checkBox_16.AutoSize = true;
			this.checkBox_16.Enabled = false;
			this.checkBox_16.Location = new Point(9, 135);
			this.checkBox_16.Name = "checkBox_16";
			this.checkBox_16.Size = new System.Drawing.Size(96, 16);
			this.checkBox_16.TabIndex = 35;
			this.checkBox_16.Text = Localization.Get("章节实际内容");
			this.toolTip_0.SetToolTip(this.checkBox_16, Localization.Get("杰奇的TXT，奇文的WAR，实际储存的章节内容的位置。"));
			this.checkBox_16.UseVisualStyleBackColor = true;
			this.label_11.AutoSize = true;
			this.label_11.Location = new Point(145, 10);
			this.label_11.Name = "label_11";
			this.label_11.Size = new System.Drawing.Size(149, 12);
			this.label_11.TabIndex = 31;
			this.label_11.Text = Localization.Get("将文件生成至网站虚拟路径");
			this.textBox_10.Location = new Point(147, 79);
			this.textBox_10.Name = "textBox_10";
			this.textBox_10.Size = new System.Drawing.Size(659, 21);
			this.textBox_10.TabIndex = 14;
			this.textBox_12.Location = new Point(147, 52);
			this.textBox_12.Name = "textBox_12";
			this.textBox_12.Size = new System.Drawing.Size(659, 21);
			this.textBox_12.TabIndex = 10;
			this.textBox_14.Location = new Point(147, 25);
			this.textBox_14.Name = "textBox_14";
			this.textBox_14.Size = new System.Drawing.Size(659, 21);
			this.textBox_14.TabIndex = 8;
			this.checkBox_0.AutoSize = true;
			this.checkBox_0.Location = new Point(9, 81);
			this.checkBox_0.Name = "checkBox_0";
			this.checkBox_0.Size = new System.Drawing.Size(96, 16);
			this.checkBox_0.TabIndex = 7;
			this.checkBox_0.Text = Localization.Get("生成全文阅读");
			this.checkBox_0.UseVisualStyleBackColor = true;
			this.checkBox_1.AutoSize = true;
			this.checkBox_1.Location = new Point(9, 54);
			this.checkBox_1.Name = "checkBox_1";
			this.checkBox_1.Size = new System.Drawing.Size(108, 16);
			this.checkBox_1.TabIndex = 5;
			this.checkBox_1.Text = Localization.Get("生成内容页HTML");
			this.checkBox_1.UseVisualStyleBackColor = true;
			this.checkBox_2.AutoSize = true;
			this.checkBox_2.Location = new Point(9, 27);
			this.checkBox_2.Name = "checkBox_2";
			this.checkBox_2.Size = new System.Drawing.Size(108, 16);
			this.checkBox_2.TabIndex = 4;
			this.checkBox_2.Text = Localization.Get("生成目录页HTML");
			this.checkBox_2.UseVisualStyleBackColor = true;
			this.tabPage2.Controls.Add(this.groupBox5);
			this.tabPage2.ForeColor = Color.Black;
			this.tabPage2.Location = new Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(812, 324);
			this.tabPage2.TabIndex = 11;
			this.tabPage2.Text = Localization.Get("附加设置");
			this.tabPage2.UseVisualStyleBackColor = true;
			this.groupBox5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.groupBox5.Controls.Add(this.label25);
			this.groupBox5.Controls.Add(this.numericUpDown8);
			this.groupBox5.Controls.Add(this.label24);
			this.groupBox5.Controls.Add(this.label22);
			this.groupBox5.Controls.Add(this.OpenNullChapterBox);
			this.groupBox5.Controls.Add(this.NullchapterBox);
			this.groupBox5.Controls.Add(this.label20);
			this.groupBox5.Location = new Point(3, 3);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(800, 318);
			this.groupBox5.TabIndex = 0;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = Localization.Get("空章节自定义生成");
			this.label25.AutoSize = true;
			this.label25.Location = new Point(183, 20);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(77, 12);
			this.label25.TabIndex = 73;
			this.label25.Text = Localization.Get("章节字数小于");
			this.numericUpDown8.Location = new Point(266, 14);
			NumericUpDown numericUpDown3 = this.numericUpDown8;
			numArray = new int[] { 10000, 0, 0, 0 };
			numericUpDown3.Maximum = new decimal(numArray);
			this.numericUpDown8.Name = "numericUpDown8";
			this.numericUpDown8.Size = new System.Drawing.Size(48, 21);
			this.numericUpDown8.TabIndex = 72;
			this.toolTip_0.SetToolTip(this.numericUpDown8, Localization.Get("这里指的是章节内容TXT文本字数。"));
			NumericUpDown num4 = this.numericUpDown8;
			numArray = new int[] { 30, 0, 0, 0 };
			num4.Value = new decimal(numArray);
			this.label24.AutoSize = true;
			this.label24.Location = new Point(320, 19);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(113, 12);
			this.label24.TabIndex = 71;
			this.label24.Text = Localization.Get("字数时使用替换生成");
			this.label22.AutoSize = true;
			this.label22.ForeColor = Color.Blue;
			this.label22.Location = new Point(10, 294);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(113, 12);
			this.label22.TabIndex = 46;
			this.label22.Text = Localization.Get("这里改成你的保存下");
			this.OpenNullChapterBox.AutoSize = true;
			this.OpenNullChapterBox.Location = new Point(9, 19);
			this.OpenNullChapterBox.Name = "OpenNullChapterBox";
			this.OpenNullChapterBox.Size = new System.Drawing.Size(132, 16);
			this.OpenNullChapterBox.TabIndex = 1;
			this.OpenNullChapterBox.Text = Localization.Get("启用空章节替换生成");
			this.OpenNullChapterBox.UseVisualStyleBackColor = true;
			this.NullchapterBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.NullchapterBox.Location = new Point(9, 66);
			this.NullchapterBox.Multiline = true;
			this.NullchapterBox.Name = "NullchapterBox";
			this.NullchapterBox.ScrollBars = ScrollBars.Vertical;
			this.NullchapterBox.Size = new System.Drawing.Size(785, 226);
			this.NullchapterBox.TabIndex = 45;
			this.toolTip_0.SetToolTip(this.NullchapterBox, Localization.Get("生成HTML的时候替换，不是替换章节实际内容。"));
			this.label20.AutoSize = true;
			this.label20.ForeColor = Color.RoyalBlue;
			this.label20.Location = new Point(6, 43);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(473, 12);
			this.label20.TabIndex = 2;
			this.label20.Text = Localization.Get("该设置生效后按设置会将少于设置字数、空章节、无TXT文本的章节内容规则为以下内容!");
			this.tabPage_4.Controls.Add(this.checkBox_13);
			this.tabPage_4.Controls.Add(this.groupBox_8);
			this.tabPage_4.Controls.Add(this.checkBox_10);
			this.tabPage_4.Controls.Add(this.checkBox_11);
			this.tabPage_4.Controls.Add(this.groupBox_0);
			this.tabPage_4.Controls.Add(this.groupBox_1);
			this.tabPage_4.Location = new Point(4, 22);
			this.tabPage_4.Name = "tabPage_4";
			this.tabPage_4.Size = new System.Drawing.Size(812, 324);
			this.tabPage_4.TabIndex = 5;
			this.tabPage_4.Text = Localization.Get("文字广告");
			this.tabPage_4.UseVisualStyleBackColor = true;
			this.checkBox_13.AutoSize = true;
			this.checkBox_13.Location = new Point(375, 9);
			this.checkBox_13.Name = "checkBox_13";
			this.checkBox_13.Size = new System.Drawing.Size(192, 16);
			this.checkBox_13.TabIndex = 7;
			this.checkBox_13.Text = Localization.Get("最后生成电子书时添加文字广告");
			this.checkBox_13.UseVisualStyleBackColor = true;
			this.groupBox_8.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.groupBox_8.Controls.Add(this.textBox_40);
			this.groupBox_8.Controls.Add(this.label_49);
			this.groupBox_8.Controls.Add(this.textBox_41);
			this.groupBox_8.Controls.Add(this.label_50);
			this.groupBox_8.Location = new Point(244, 53);
			this.groupBox_8.Name = "groupBox_8";
			this.groupBox_8.Size = new System.Drawing.Size(562, 158);
			this.groupBox_8.TabIndex = 6;
			this.groupBox_8.TabStop = false;
			this.groupBox_8.Text = Localization.Get("固定位置添加广告");
			this.textBox_40.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.textBox_40.Location = new Point(6, 100);
			this.textBox_40.Multiline = true;
			this.textBox_40.Name = "textBox_40";
			this.textBox_40.ScrollBars = ScrollBars.Vertical;
			this.textBox_40.Size = new System.Drawing.Size(550, 50);
			this.textBox_40.TabIndex = 16;
			this.label_49.AutoSize = true;
			this.label_49.Location = new Point(6, 85);
			this.label_49.Name = "label_49";
			this.label_49.Size = new System.Drawing.Size(209, 12);
			this.label_49.TabIndex = 15;
			this.label_49.Text = Localization.Get("章节尾部(可以用回车控制是否分段落)");
			this.textBox_41.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.textBox_41.Location = new Point(6, 32);
			this.textBox_41.Multiline = true;
			this.textBox_41.Name = "textBox_41";
			this.textBox_41.ScrollBars = ScrollBars.Vertical;
			this.textBox_41.Size = new System.Drawing.Size(550, 50);
			this.textBox_41.TabIndex = 14;
			this.label_50.AutoSize = true;
			this.label_50.Location = new Point(6, 17);
			this.label_50.Name = "label_50";
			this.label_50.Size = new System.Drawing.Size(209, 12);
			this.label_50.TabIndex = 0;
			this.label_50.Text = Localization.Get("章节头部(可以用回车控制是否分段落)");
			this.checkBox_10.AutoSize = true;
			this.checkBox_10.Location = new Point(9, 31);
			this.checkBox_10.Name = "checkBox_10";
			this.checkBox_10.Size = new System.Drawing.Size(444, 16);
			this.checkBox_10.TabIndex = 5;
			this.checkBox_10.Text = Localization.Get("最后生成时添加文字广告(生成HTML的时候添加，使用后台生成还是没有广告的)");
			this.checkBox_10.UseVisualStyleBackColor = true;
			this.checkBox_11.AutoSize = true;
			this.checkBox_11.Checked = true;
			this.checkBox_11.CheckState = CheckState.Checked;
			this.checkBox_11.Location = new Point(9, 9);
			this.checkBox_11.Name = "checkBox_11";
			this.checkBox_11.Size = new System.Drawing.Size(360, 16);
			this.checkBox_11.TabIndex = 4;
			this.checkBox_11.Text = Localization.Get("入库章节时添加文字广告(真实入库，使用后台生成的时候也会)");
			this.checkBox_11.UseVisualStyleBackColor = true;
			this.groupBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.groupBox_0.Controls.Add(this.textBox_20);
			this.groupBox_0.Location = new Point(244, 217);
			this.groupBox_0.Name = "groupBox_0";
			this.groupBox_0.Size = new System.Drawing.Size(562, 101);
			this.groupBox_0.TabIndex = 3;
			this.groupBox_0.TabStop = false;
			this.groupBox_0.Text = Localization.Get("文字广告集合(一行一条广告语)");
			this.textBox_20.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.textBox_20.Location = new Point(6, 20);
			this.textBox_20.Multiline = true;
			this.textBox_20.Name = "textBox_20";
			this.textBox_20.ScrollBars = ScrollBars.Vertical;
			this.textBox_20.Size = new System.Drawing.Size(550, 75);
			this.textBox_20.TabIndex = 13;
			this.toolTip_0.SetToolTip(this.textBox_20, Localization.Get("一行写一个广告条，可以很多个，会随机抽取的"));
			this.groupBox_1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
			this.groupBox_1.Controls.Add(this.label_40);
			this.groupBox_1.Controls.Add(this.numericUpDown_0);
			this.groupBox_1.Controls.Add(this.label_19);
			this.groupBox_1.Controls.Add(this.textBox_21);
			this.groupBox_1.Controls.Add(this.label_20);
			this.groupBox_1.Location = new Point(6, 53);
			this.groupBox_1.Name = "groupBox_1";
			this.groupBox_1.Size = new System.Drawing.Size(232, 265);
			this.groupBox_1.TabIndex = 2;
			this.groupBox_1.TabStop = false;
			this.groupBox_1.Text = Localization.Get("添加文字广告");
			this.label_40.AutoSize = true;
			this.label_40.Location = new Point(6, 32);
			this.label_40.Name = "label_40";
			this.label_40.Size = new System.Drawing.Size(113, 12);
			this.label_40.TabIndex = 12;
			this.label_40.Text = Localization.Get("留空表示不限制分卷");
			this.numericUpDown_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			this.numericUpDown_0.Location = new Point(6, 238);
			this.numericUpDown_0.Name = "numericUpDown_0";
			this.numericUpDown_0.Size = new System.Drawing.Size(220, 21);
			this.numericUpDown_0.TabIndex = 11;
			this.label_19.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			this.label_19.AutoSize = true;
			this.label_19.Location = new Point(6, 223);
			this.label_19.Name = "label_19";
			this.label_19.Size = new System.Drawing.Size(125, 12);
			this.label_19.TabIndex = 10;
			this.label_19.Text = Localization.Get("每个章节添加几个广告");
			this.textBox_21.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
			this.textBox_21.Location = new Point(6, 47);
			this.textBox_21.Multiline = true;
			this.textBox_21.Name = "textBox_21";
			this.textBox_21.ScrollBars = ScrollBars.Vertical;
			this.textBox_21.Size = new System.Drawing.Size(220, 173);
			this.textBox_21.TabIndex = 9;
			this.toolTip_0.SetToolTip(this.textBox_21, Localization.Get("一行写一个分卷名\n留空就表示在所有文字章节中都添加"));
			this.label_20.AutoSize = true;
			this.label_20.Location = new Point(6, 17);
			this.label_20.Name = "label_20";
			this.label_20.Size = new System.Drawing.Size(185, 12);
			this.label_20.TabIndex = 8;
			this.label_20.Text = Localization.Get("限制只在以下分卷中添加文字广告");
			this.tabPage_5.Controls.Add(this.groupBox_6);
			this.tabPage_5.Controls.Add(this.groupBox_3);
			this.tabPage_5.Controls.Add(this.groupBox_4);
			this.tabPage_5.Location = new Point(4, 22);
			this.tabPage_5.Name = "tabPage_5";
			this.tabPage_5.Size = new System.Drawing.Size(812, 324);
			this.tabPage_5.TabIndex = 6;
			this.tabPage_5.Text = Localization.Get("过滤替换");
			this.tabPage_5.UseVisualStyleBackColor = true;
			this.groupBox_6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.groupBox_6.Controls.Add(this.textBox_33);
			this.groupBox_6.Location = new Point(221, 154);
			this.groupBox_6.Name = "groupBox_6";
			this.groupBox_6.Size = new System.Drawing.Size(585, 164);
			this.groupBox_6.TabIndex = 16;
			this.groupBox_6.TabStop = false;
			this.groupBox_6.Text = Localization.Get("章节内容非法字符替换(仅在最后生成时)");
			this.textBox_33.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.textBox_33.Location = new Point(6, 14);
			this.textBox_33.Multiline = true;
			this.textBox_33.Name = "textBox_33";
			this.textBox_33.ScrollBars = ScrollBars.Vertical;
			this.textBox_33.Size = new System.Drawing.Size(573, 144);
			this.textBox_33.TabIndex = 13;
			this.toolTip_0.SetToolTip(this.textBox_33, Localization.Get("生成HTML的时候替换，不是替换章节实际内容。\n一行一个，格式如下：\n101du.net|yfxsw.com\n性|<img src=\"images/xing.gif\">\n高潮|高氵朝"));
			this.groupBox_3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
			this.groupBox_3.Controls.Add(this.textBox_30);
			this.groupBox_3.Location = new Point(6, 6);
			this.groupBox_3.Name = "groupBox_3";
			this.groupBox_3.Size = new System.Drawing.Size(209, 312);
			this.groupBox_3.TabIndex = 5;
			this.groupBox_3.TabStop = false;
			this.groupBox_3.Text = Localization.Get("违禁小说过滤(一行一个)");
			this.textBox_30.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.textBox_30.Location = new Point(6, 14);
			this.textBox_30.Multiline = true;
			this.textBox_30.Name = "textBox_30";
			this.textBox_30.ScrollBars = ScrollBars.Vertical;
			this.textBox_30.Size = new System.Drawing.Size(197, 292);
			this.textBox_30.TabIndex = 13;
			this.groupBox_4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.groupBox_4.Controls.Add(this.label_32);
			this.groupBox_4.Controls.Add(this.textBox_32);
			this.groupBox_4.Controls.Add(this.textBox_31);
			this.groupBox_4.Location = new Point(221, 6);
			this.groupBox_4.Name = "groupBox_4";
			this.groupBox_4.Size = new System.Drawing.Size(585, 142);
			this.groupBox_4.TabIndex = 4;
			this.groupBox_4.TabStop = false;
			this.groupBox_4.Text = Localization.Get("章节内容非法字符过滤(正则过滤)(仅在最后生成时)");
			this.label_32.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			this.label_32.AutoSize = true;
			this.label_32.Location = new Point(6, 118);
			this.label_32.Name = "label_32";
			this.label_32.Size = new System.Drawing.Size(89, 12);
			this.label_32.TabIndex = 15;
			this.label_32.Text = Localization.Get("默认替换字符：");
			this.textBox_32.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.textBox_32.Location = new Point(101, 115);
			this.textBox_32.Name = "textBox_32";
			this.textBox_32.Size = new System.Drawing.Size(478, 21);
			this.textBox_32.TabIndex = 14;
			this.textBox_32.Text = "**";
			this.textBox_31.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.textBox_31.Location = new Point(6, 14);
			this.textBox_31.Multiline = true;
			this.textBox_31.Name = "textBox_31";
			this.textBox_31.ScrollBars = ScrollBars.Vertical;
			this.textBox_31.Size = new System.Drawing.Size(573, 95);
			this.textBox_31.TabIndex = 13;
			this.toolTip_0.SetToolTip(this.textBox_31, Localization.Get("生成HTML的时候替换，不是替换章节实际内容。"));
			this.tabPage_8.Controls.Add(this.label_65);
			this.tabPage_8.Controls.Add(this.checkedListBox_0);
			this.tabPage_8.Location = new Point(4, 22);
			this.tabPage_8.Name = "tabPage_8";
			this.tabPage_8.Size = new System.Drawing.Size(812, 324);
			this.tabPage_8.TabIndex = 9;
			this.tabPage_8.Text = Localization.Get("日志选择");
			this.tabPage_8.UseVisualStyleBackColor = true;
			this.label_65.AutoSize = true;
			this.label_65.Location = new Point(6, 6);
			this.label_65.Name = "label_65";
			this.label_65.Size = new System.Drawing.Size(161, 12);
			this.label_65.TabIndex = 1;
			this.label_65.Text = Localization.Get("请选择需要记录的日志项目：");
			this.checkedListBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.checkedListBox_0.CheckOnClick = true;
			this.checkedListBox_0.ColumnWidth = 300;
			this.checkedListBox_0.FormattingEnabled = true;
			this.checkedListBox_0.Location = new Point(8, 21);
			this.checkedListBox_0.MultiColumn = true;
			this.checkedListBox_0.Name = "checkedListBox_0";
			this.checkedListBox_0.Size = new System.Drawing.Size(795, 260);
			this.checkedListBox_0.TabIndex = 0;
			this.textBox_4.Location = new Point(116, 78);
			this.textBox_4.Name = "textBox_4";
			this.textBox_4.Size = new System.Drawing.Size(100, 21);
			this.textBox_4.TabIndex = 1;
			this.label_4.AutoSize = true;
			this.label_4.Location = new Point(45, 81);
			this.label_4.Name = "label_4";
			this.label_4.Size = new System.Drawing.Size(65, 12);
			this.label_4.TabIndex = 0;
			this.label_4.Text = Localization.Get("默认大类：");
			this.textBox_5.Location = new Point(116, 78);
			this.textBox_5.Name = "textBox_5";
			this.textBox_5.Size = new System.Drawing.Size(100, 21);
			this.textBox_5.TabIndex = 1;
			this.label_5.AutoSize = true;
			this.label_5.Location = new Point(45, 81);
			this.label_5.Name = "label_5";
			this.label_5.Size = new System.Drawing.Size(65, 12);
			this.label_5.TabIndex = 0;
			this.label_5.Text = Localization.Get("默认大类：");
			this.button_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			this.button_0.Location = new Point(676, 368);
			this.button_0.Name = "button_0";
			this.button_0.Size = new System.Drawing.Size(75, 23);
			this.button_0.TabIndex = 1;
			this.button_0.Text = Localization.Get("确定");
			this.button_0.UseVisualStyleBackColor = true;
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.button_1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			this.button_1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button_1.Location = new Point(757, 368);
			this.button_1.Name = "button_1";
			this.button_1.Size = new System.Drawing.Size(75, 23);
			this.button_1.TabIndex = 2;
			this.button_1.Text = Localization.Get("取消");
			this.button_1.UseVisualStyleBackColor = true;
			this.button_1.Click += new EventHandler(this.button_1_Click);
			this.label_15.AutoSize = true;
			this.label_15.Location = new Point(6, 77);
			this.label_15.Name = "label_15";
			this.label_15.Size = new System.Drawing.Size(65, 12);
			this.label_15.TabIndex = 8;
			this.label_15.Text = Localization.Get("根 目 录：");
			this.label_16.AutoSize = true;
			this.label_16.Location = new Point(6, 50);
			this.label_16.Name = "label_16";
			this.label_16.Size = new System.Drawing.Size(65, 12);
			this.label_16.TabIndex = 7;
			this.label_16.Text = Localization.Get("帐户密码：");
			this.label_17.AutoSize = true;
			this.label_17.Location = new Point(6, 50);
			this.label_17.Name = "label_17";
			this.label_17.Size = new System.Drawing.Size(0, 12);
			this.label_17.TabIndex = 6;
			this.label_18.AutoSize = true;
			this.label_18.Location = new Point(6, 23);
			this.label_18.Name = "label_18";
			this.label_18.Size = new System.Drawing.Size(65, 12);
			this.label_18.TabIndex = 5;
			this.label_18.Text = Localization.Get("ＩＰ端口：");
			this.openFileDialog_0.Filter = "watermark|*.gif";
			this.openFileDialog_0.RestoreDirectory = true;
			this.toolTip_0.AutomaticDelay = 100;
			this.toolTip_0.AutoPopDelay = 50000;
			this.toolTip_0.InitialDelay = 100;
			this.toolTip_0.IsBalloon = true;
			this.toolTip_0.ReshowDelay = 20;
			this.toolTip_0.ShowAlways = true;
			this.toolTip_0.ToolTipIcon = ToolTipIcon.Info;
			this.toolTip_0.ToolTipTitle = Localization.Get("提示");
			this.label_51.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			this.label_51.AutoSize = true;
			this.label_51.Location = new Point(14, 373);
			this.label_51.Name = "label_51";
			this.label_51.Size = new System.Drawing.Size(197, 12);
			this.label_51.TabIndex = 3;
			this.label_51.Text = Localization.Get("小提示：鼠标停留会有相关帮助信息");
			this.MailWorker.WorkerReportsProgress = true;
			this.MailWorker.WorkerSupportsCancellation = true;
			this.MailWorker.DoWork += new DoWorkEventHandler(this.MailWorker_DoWork);
			this.MailWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.MailWorker_RunWorkerCompleted);
			this.backgroundWorker1.WorkerReportsProgress = true;
			this.backgroundWorker1.WorkerSupportsCancellation = true;
			this.backgroundWorker1.DoWork += new DoWorkEventHandler(this.backgroundWorker1_DoWork);
			this.webBrowser.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			this.webBrowser.Location = new Point(9, 736);
			this.webBrowser.Margin = new System.Windows.Forms.Padding(0);
			this.webBrowser.Name = "webBrowser";
			this.webBrowser.ScriptErrorsSuppressed = true;
			this.webBrowser.ScrollBarsEnabled = false;
			this.webBrowser.Size = new System.Drawing.Size(592, 119);
			this.webBrowser.TabIndex = 13;
			this.webBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(this.webBrowser_DocumentCompleted);
			base.CancelButton = this.button_1;
			base.ClientSize = new System.Drawing.Size(844, 403);
			base.Controls.Add(this.webBrowser);
			base.Controls.Add(this.label_51);
			base.Controls.Add(this.button_1);
			base.Controls.Add(this.button_0);
			base.Controls.Add(this.tabControl1);
			this.Font = new System.Drawing.Font(Localization.Font, 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
			base.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "ConfigForm";
			this.Text = Localization.Get("系统设置");
			base.Load += new EventHandler(this.ConfigForm_Load);
			base.FormClosing += new FormClosingEventHandler(this.ConfigForm_FormClosing);
			this.tabControl1.ResumeLayout(false);
			this.tabPage_2.ResumeLayout(false);
			this.tabPage_2.PerformLayout();
			((ISupportInitialize)this.numericUpDown9).EndInit();
			((ISupportInitialize)this.numericUpDown_2).EndInit();
			this.tabPage_0.ResumeLayout(false);
			this.tabPage_0.PerformLayout();
			this.tabPage1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((ISupportInitialize)this.numericUpDown7).EndInit();
			((ISupportInitialize)this.numericUpDown6).EndInit();
			((ISupportInitialize)this.numericUpDown3).EndInit();
			((ISupportInitialize)this.numericUpDown2).EndInit();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			((ISupportInitialize)this.numericUpDown4).EndInit();
			((ISupportInitialize)this.numericUpDown10).EndInit();
			((ISupportInitialize)this.numericUpDown1).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((ISupportInitialize)this.numericUpDown5).EndInit();
			this.tabPage_1.ResumeLayout(false);
			this.tabPage_1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			((ISupportInitialize)this.numericUpDown8).EndInit();
			this.tabPage_4.ResumeLayout(false);
			this.tabPage_4.PerformLayout();
			this.groupBox_8.ResumeLayout(false);
			this.groupBox_8.PerformLayout();
			this.groupBox_0.ResumeLayout(false);
			this.groupBox_0.PerformLayout();
			this.groupBox_1.ResumeLayout(false);
			this.groupBox_1.PerformLayout();
			((ISupportInitialize)this.numericUpDown_0).EndInit();
			this.tabPage_5.ResumeLayout(false);
			this.groupBox_6.ResumeLayout(false);
			this.groupBox_6.PerformLayout();
			this.groupBox_3.ResumeLayout(false);
			this.groupBox_3.PerformLayout();
			this.groupBox_4.ResumeLayout(false);
			this.groupBox_4.PerformLayout();
			this.tabPage_8.ResumeLayout(false);
			this.tabPage_8.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private void linkLabel_6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (this.folderBrowserDialog_0.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				this.textBox_8.Text = this.folderBrowserDialog_0.SelectedPath;
			}
		}

		private void linkLabel_8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			this.textBox_7.Text = Localization.Get("Server=(local);User id=用户名;Pwd=密码;Database=数据库名");
		}

		private void linkLabel_9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			this.textBox_7.Text = Localization.Get("Data Source=127.0.0.1;Database=数据库名;User ID=用户名;Password=密码;port=3306;charset=gbk");
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (this.folderBrowserDialog_0.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				this.textBox6.Text = this.folderBrowserDialog_0.SelectedPath;
			}
		}

		private void MailWorker_DoWork(object sender, DoWorkEventArgs e)
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
			string[] webSiteName = new string[] { Localization.Get("【"), Configs.BaseConfig.WebSiteName, Localization.Get("】测试采集报告("), str, ")" };
			emailBase.Subject = string.Concat(webSiteName);
			emailBase.Content = Localization.Get("这是一封测试邮件，收到此邮件表明你的邮箱可以接收采集器时段报告和错误日志。<br /><br />开发任何网站系统，任何软件，请联系biqu01.com");
			string[] strArrays = Configs.BaseConfig.MailTitle.Trim().Split(new char[] { ',' });
			string str1 = Localization.Get("测试结果如下：");
			string[] strArrays1 = strArrays;
			int num1 = 0;
			while (true)
			{
				if (num1 < (int)strArrays1.Length)
				{
					string str2 = strArrays1[num1];
					if (str2 == string.Empty)
					{
						break;
					}
					else
					{
						emailBase.ToEmail = str2;
						string str3 = str1;
						webSiteName = new string[] { str3, "\r\n[", str2, "]", emailSendServer1.SendMail(emailBase) };
						str1 = string.Concat(webSiteName);
						num1++;
					}
				}
				else
				{
					MessageBox.Show(str1);
					break;
				}
			}
		}

		private void MailWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.button3.Enabled = true;
		}

		private void method_0()
		{
			this.WebSiteName.Text = Configs.BaseConfig.WebSiteName;
			this.checkBox_7.Checked = Configs.BaseConfig.Debug;
			this.textBox_8.Text = Configs.BaseConfig.WebSitePath;
			this.textBox_7.Text = Configs.BaseConfig.ConnectionString;
			this.comboBox_0.Text = Configs.BaseConfig.CmsVersion;
			this.comboBox_1.Text = Configs.BaseConfig.CmsName;
			this.sqliteTime.Text = Configs.BaseConfig.sqliteTime;
			this.NullchapterBox.Text = Configs.BaseConfig.NullChapter;
			this.OpenNullChapterBox.Checked = Configs.BaseConfig.OpenNullChapter;
			this.checkBox_6.Checked = Configs.BaseConfig.DonotUserDefaultLagerSort;
			this.checkBox_5.Checked = Configs.BaseConfig.DonotUserDefaultSmallSort;
			TextBox textBox3 = this.textBox_3;
			int defaultLagerSortID = Configs.BaseConfig.DefaultLagerSortID;
			textBox3.Text = string.Concat(defaultLagerSortID.ToString(), "|", Configs.BaseConfig.DefaultLagerSort);
			TextBox textBox2 = this.textBox_2;
			defaultLagerSortID = Configs.BaseConfig.DefaultSmallSortID;
			textBox2.Text = string.Concat(defaultLagerSortID.ToString(), "|", Configs.BaseConfig.DefaultSmallSort);
			this.textBox_1.Text = Configs.BaseConfig.LagerSortCorresponding.Replace("♂", "\r\n");
			this.textBox_0.Text = Configs.BaseConfig.SmallSortCorresponding.Replace("♂", "\r\n");
			this.textBox_29.Text = Configs.BaseConfig.DefaultVolumeName;
			this.numericUpDown_2.Value = Configs.BaseConfig.HttpTimeOut;
			this.comboBox_4.Text = Configs.BaseConfig.HttpUserAgent;
			this.textBox_37.Text = Configs.BaseConfig.WebSiteCookies;
			this.comboBox_3.SelectedIndex = Configs.BaseConfig.LogType;
			this.checkBox_26.Checked = Configs.BaseConfig.Translate;
			this.comboBox_1.Text = Configs.CmsName;
			this.checkBox_2.Checked = Configs.BaseConfig.IndexHtml;
			this.checkBox_1.Checked = Configs.BaseConfig.ChapterHtml;
			this.checkBox_19.Checked = Configs.BaseConfig.bool_10;
			this.checkBox_0.Checked = Configs.BaseConfig.FullHtml;
			this.checkBox_16.Checked = Configs.BaseConfig.CustomRealTxt;
			this.checkBox_15.Checked = Configs.BaseConfig.CreateTxt;
			this.checkBox_14.Checked = Configs.BaseConfig.CustomCover;
			this.checkBox_25.Checked = Configs.BaseConfig.AddJsRealTxt;
			this.checkBox_18.Checked = Configs.BaseConfig.CustomCreatePath;
			this.checkBox_17.Checked = Configs.BaseConfig.CustomHtmlTemplets;
			this.textBox_14.Text = Configs.BaseConfig.IndexHtmlDir;
			this.textBox_12.Text = Configs.BaseConfig.ChapterHtmlDir;
			this.textBox_10.Text = Configs.BaseConfig.FullHtmlDir;
			this.textBox_47.Text = Configs.BaseConfig.RealTxtDir;
			this.textBox_49.Text = Configs.BaseConfig.OpfDir;
			this.textBox_46.Text = Configs.BaseConfig.ImageDir;
			this.textBox_45.Text = Configs.BaseConfig.CoverDir;
			this.textBox_67.Text = Configs.BaseConfig.PrevFirstHtmlUrl;
			this.textBox_66.Text = Configs.BaseConfig.NextEndHtmlUrl;
			if (Configs.BaseConfig.TextMarkOfVulmeName != null)
			{
				this.textBox_21.Text = string.Join("\r\n", Configs.BaseConfig.TextMarkOfVulmeName);
			}
			if (Configs.BaseConfig.TextMarkOfArrayText != null)
			{
				this.textBox_20.Text = string.Join("\r\n", Configs.BaseConfig.TextMarkOfArrayText);
			}
			if (Configs.BaseConfig.UpdateDefaultUrls != null)
			{
				this.textBox1.Text = string.Join("\r\n", Configs.BaseConfig.UpdateDefaultUrls);
			}
			this.numericUpDown_0.Value = Configs.BaseConfig.TextMarkOfNumber;
			this.textBox_41.Text = Configs.BaseConfig.TextMarkOfTop;
			this.textBox_40.Text = Configs.BaseConfig.TextMarkOfBottom;
			this.checkBox_11.Checked = Configs.BaseConfig.TextMarkOfData;
			this.checkBox_10.Checked = Configs.BaseConfig.TextMarkOfHtml;
			this.checkBox_13.Checked = Configs.BaseConfig.TextMarkOfEBook;
			if (Configs.BaseConfig.FilterNovelName != null)
			{
				this.textBox_30.Text = Configs.BaseConfig.FilterNovelName.Replace("♂", "\r\n").Replace(" ", "");
			}
			this.textBox_31.Text = Configs.BaseConfig.BadWords;
			this.textBox_32.Text = Configs.BaseConfig.ReplaceBadWords;
			if (Configs.BaseConfig.BadwordsReplaceImages != null)
			{
				this.textBox_33.Text = string.Join("\r\n", Configs.BaseConfig.BadwordsReplaceImages);
			}
			for (int i = 0; i < (int)this.string_0.Length; i++)
			{
				this.checkedListBox_0.Items.Add(this.string_0[i]);
				string string0 = this.string_0[i];
				char[] chrArray = new char[] { ' ' };
				string str = string.Concat(",", string0.Split(chrArray)[0], ",");
				if (Configs.BaseConfig.SelectLog.IndexOf(str) >= 0)
				{
					this.checkedListBox_0.SetItemChecked(i, true);
				}
			}
			string lower = Configs.BaseConfig.NumOrPinyin.ToString().ToLower();
			if (lower != null)
			{
				if (lower == Localization.Get("数字id目录").ToLower())
				{
					this.NumOrPinyincomboBox.Text = Configs.BaseConfig.NumOrPinyin;
					this.NumOrPinyinDircomboBox.Text = Configs.BaseConfig.NumOrPinyinDir;
				}
				else if (lower == Localization.Get("拼音目录").ToLower())
				{
					if (Configs.HaveFunction.IndexOf("PinyinDir") < 0)
					{
						this.NumOrPinyincomboBox.Text = Localization.Get("数字ID目录");
						this.NumOrPinyinDircomboBox.Text = Localization.Get("拼音目录");
					}
					else if (Configs.HaveFunction.IndexOf("PinyinDir") < 0)
					{
						MessageBox.Show(Localization.Get("警告：当前数字/拼音化设置与您的授权不相符,自动恢复默认的数字ID目录"));
						this.NumOrPinyincomboBox.Text = Localization.Get("数字ID目录");
						this.NumOrPinyinDircomboBox.Text = Localization.Get("拼音目录");
					}
					else
					{
						this.NumOrPinyincomboBox.Text = Configs.BaseConfig.NumOrPinyin;
						this.NumOrPinyinDircomboBox.Text = Configs.BaseConfig.NumOrPinyinDir.Replace("{NovelId/1000}/{NovelId}", "ID除1000/ID").Replace("{NovelId}", "ID").Replace("{Pinyin/3}/{Pinyin}", "拼音前三字母/拼音").Replace("{Pinyin}", "拼音");
					}
				}
			}
			this.comboBox3.Text = Configs.BaseConfig.PrevNextPageSuffix;
			this.numericUpDown2.Value = Configs.BaseConfig.IndexNeighbor;
			this.numericUpDown3.Value = Configs.BaseConfig.ChapterNeighbor;
			this.numericUpDown6.Value = Configs.BaseConfig.IndexTuijian;
			this.numericUpDown7.Value = Configs.BaseConfig.ChapterTuijian;
			this.checkBox2.Checked = Configs.BaseConfig.ChapterName2Num;
			this.numericUpDown1.Value = Configs.BaseConfig.IndexAntiCollectNum;
			this.ZhanQun.Checked = Configs.BaseConfig.ZhanQun;
			this.numericUpDown4.Value = Configs.BaseConfig.ChapterPagingNum;
			this.numericUpDown8.Value = Configs.BaseConfig.SizeNullChapter;
			this.maskedTextBox4.Text = Configs.BaseConfig.InternalLinkUrl;
			this.numericUpDown5.Value = Configs.BaseConfig.InternalLinkDensity;
			this.checkBox3.Checked = Configs.BaseConfig.InternalLink;
			this.maskedTextBox2.Text = Configs.BaseConfig.InternalLinkHead;
			this.maskedTextBox3.Text = Configs.BaseConfig.InternalLinkFoot;
			this.textBox3.Text = Configs.BaseConfig.MailSmtp;
			this.textBox2.Text = Configs.BaseConfig.MailUser;
			this.textBox4.Text = Configs.BaseConfig.MailPass;
			this.textBox_36.Text = Configs.BaseConfig.MailTitle;
			this.numericUpDown9.Value = Configs.BaseConfig.MailTimeNum;
			this.comboBox1.Text = Configs.BaseConfig.TuijianType;
			this.textBox5.Text = Configs.BaseConfig.TuijianTemplates;
			this.numericUpDown4.Value = Configs.BaseConfig.NewAntiCollectNum;
			this.numericUpDown10.Value = Configs.BaseConfig.OnAntiCollectNum;
			this.textBox6.Text = Configs.BaseConfig.OnAntiCollectDir;
		}

		private void method_1()
		{
			Configs.BaseConfig.sqliteTime = this.sqliteTime.Text;
			Configs.BaseConfig.NullChapter = this.NullchapterBox.Text;
			Configs.BaseConfig.OpenNullChapter = this.OpenNullChapterBox.Checked;
			Configs.BaseConfig.Debug = this.checkBox_7.Checked;
			Configs.BaseConfig.WebSiteName = this.WebSiteName.Text;
			Configs.BaseConfig.WebSitePath = this.textBox_8.Text;
			Configs.BaseConfig.ConnectionString = this.textBox_7.Text;
			Configs.BaseConfig.CmsVersion = this.comboBox_0.Text;
			Configs.BaseConfig.CmsName = this.comboBox_1.Text;
			Configs.BaseConfig.DonotUserDefaultLagerSort = this.checkBox_6.Checked;
			BaseConfigInfo baseConfig = Configs.BaseConfig;
			string text = this.textBox_3.Text;
			char[] chrArray = new char[] { '|' };
			baseConfig.DefaultLagerSortID = Convert.ToInt32(text.Split(chrArray)[0]);
			BaseConfigInfo baseConfigInfo = Configs.BaseConfig;
			string str = this.textBox_3.Text;
			chrArray = new char[] { '|' };
			baseConfigInfo.DefaultLagerSort = str.Split(chrArray)[1];
			Configs.BaseConfig.DonotUserDefaultSmallSort = this.checkBox_5.Checked;
			BaseConfigInfo num = Configs.BaseConfig;
			string text1 = this.textBox_2.Text;
			chrArray = new char[] { '|' };
			num.DefaultSmallSortID = Convert.ToInt32(text1.Split(chrArray)[0]);
			BaseConfigInfo baseConfig1 = Configs.BaseConfig;
			string str1 = this.textBox_2.Text;
			chrArray = new char[] { '|' };
			baseConfig1.DefaultSmallSort = str1.Split(chrArray)[1];
			Configs.BaseConfig.LagerSortCorresponding = this.textBox_1.Text.Replace("\r\n", "♂");
			Configs.BaseConfig.SmallSortCorresponding = this.textBox_0.Text.Replace("\r\n", "♂");
			Configs.BaseConfig.DefaultVolumeName = this.textBox_29.Text;
			Configs.BaseConfig.HttpTimeOut = Convert.ToInt32(this.numericUpDown_2.Value);
			Configs.BaseConfig.HttpUserAgent = this.comboBox_4.Text;
			Configs.BaseConfig.WebSiteCookies = this.textBox_37.Text;
			Configs.BaseConfig.OpenNullChapter = this.OpenNullChapterBox.Checked;
			Configs.BaseConfig.MailSmtp = this.textBox3.Text;
			Configs.BaseConfig.MailUser = this.textBox2.Text;
			Configs.BaseConfig.MailPass = this.textBox4.Text;
			Configs.BaseConfig.MailTitle = this.textBox_36.Text;
			Configs.BaseConfig.MailTimeNum = Convert.ToInt32(this.numericUpDown9.Value);
			if (Configs.BaseConfig.MailTimeNum < 10)
			{
				Configs.BaseConfig.MailTimeNum = 10;
			}
			Configs.BaseConfig.LogType = this.comboBox_3.SelectedIndex;
			Configs.BaseConfig.Translate = this.checkBox_26.Checked;
			BaseConfigInfo baseConfigInfo1 = Configs.BaseConfig;
			string str2 = this.textBox_21.Text.Replace("\r\n", "♂");
			chrArray = new char[] { '\u2642' };
			baseConfigInfo1.TextMarkOfVulmeName = str2.Split(chrArray);
			BaseConfigInfo baseConfig2 = Configs.BaseConfig;
			string str3 = this.textBox_20.Text.Replace("\r\n", "♂");
			chrArray = new char[] { '\u2642' };
			baseConfig2.TextMarkOfArrayText = str3.Split(chrArray);
			Configs.BaseConfig.TextMarkOfNumber = Convert.ToInt32(this.numericUpDown_0.Value);
			Configs.BaseConfig.TextMarkOfTop = this.textBox_41.Text;
			Configs.BaseConfig.TextMarkOfBottom = this.textBox_40.Text;
			Configs.BaseConfig.TextMarkOfData = this.checkBox_11.Checked;
			Configs.BaseConfig.TextMarkOfHtml = this.checkBox_10.Checked;
			Configs.BaseConfig.TextMarkOfEBook = this.checkBox_13.Checked;
			Configs.BaseConfig.IndexHtml = this.checkBox_2.Checked;
			Configs.BaseConfig.ChapterHtml = this.checkBox_1.Checked;
			Configs.BaseConfig.FullHtml = this.checkBox_0.Checked;
			Configs.BaseConfig.bool_10 = this.checkBox_19.Checked;
			Configs.BaseConfig.CustomRealTxt = this.checkBox_16.Checked;
			Configs.BaseConfig.CreateTxt = this.checkBox_15.Checked;
			Configs.BaseConfig.CustomCover = this.checkBox_14.Checked;
			Configs.BaseConfig.AddJsRealTxt = this.checkBox_25.Checked;
			Configs.BaseConfig.CustomCreatePath = this.checkBox_18.Checked;
			Configs.BaseConfig.CustomHtmlTemplets = this.checkBox_17.Checked;
			Configs.BaseConfig.IndexHtmlDir = this.textBox_14.Text;
			Configs.BaseConfig.ChapterHtmlDir = this.textBox_12.Text;
			Configs.BaseConfig.FullHtmlDir = this.textBox_10.Text;
			Configs.BaseConfig.RealTxtDir = this.textBox_47.Text;
			Configs.BaseConfig.OpfDir = this.textBox_49.Text;
			Configs.BaseConfig.ImageDir = this.textBox_46.Text;
			Configs.BaseConfig.CoverDir = this.textBox_45.Text;
			Configs.BaseConfig.PrevFirstHtmlUrl = this.textBox_67.Text;
			Configs.BaseConfig.NextEndHtmlUrl = this.textBox_66.Text;
			BaseConfigInfo baseConfigInfo2 = Configs.BaseConfig;
			string str4 = this.textBox1.Text.Replace("\r\n", "♂");
			chrArray = new char[] { '\u2642' };
			baseConfigInfo2.UpdateDefaultUrls = str4.Split(chrArray);
			Configs.BaseConfig.FilterNovelName = this.textBox_30.Text.Replace("\r\n", "♂");
			Configs.BaseConfig.BadWords = this.textBox_31.Text;
			Configs.BaseConfig.ReplaceBadWords = this.textBox_32.Text;
			BaseConfigInfo baseConfig3 = Configs.BaseConfig;
			string str5 = this.textBox_33.Text.Replace("\r\n", "♂");
			chrArray = new char[] { '\u2642' };
			baseConfig3.BadwordsReplaceImages = str5.Split(chrArray);
			Configs.BaseConfig.MailTimeNum = Convert.ToInt32(this.numericUpDown9.Value);
			Configs.BaseConfig.MailSmtp = this.textBox3.Text;
			Configs.BaseConfig.MailUser = this.textBox2.Text;
			Configs.BaseConfig.MailPass = this.textBox4.Text;
			Configs.BaseConfig.MailTitle = this.textBox_36.Text;
			string str6 = ",";
			for (int i = 0; i < this.checkedListBox_0.CheckedItems.Count; i++)
			{
				string str7 = this.checkedListBox_0.CheckedItems[i].ToString();
				chrArray = new char[] { ' ' };
				str6 = string.Concat(str6, str7.Split(chrArray)[0], ",");
			}
			Configs.BaseConfig.SelectLog = str6;
			Configs.BaseConfig.NumOrPinyin = this.NumOrPinyincomboBox.Text;
			Configs.BaseConfig.NumOrPinyinDir = this.NumOrPinyinDircomboBox.Text.Replace(Localization.Get("ID除1000/ID"), "{NovelId/1000}/{NovelId}").Replace("ID", "{NovelId}").Replace(Localization.Get("拼音前三字母/拼音"), "{Pinyin/3}/{Pinyin}").Replace(Localization.Get("拼音"), "{Pinyin}");
			Configs.BaseConfig.IndexNeighbor = Convert.ToInt32(this.numericUpDown2.Value);
			Configs.BaseConfig.ChapterNeighbor = Convert.ToInt32(this.numericUpDown3.Value);
			Configs.BaseConfig.IndexTuijian = Convert.ToInt32(this.numericUpDown6.Value);
			Configs.BaseConfig.ChapterTuijian = Convert.ToInt32(this.numericUpDown7.Value);
			Configs.BaseConfig.PrevNextPageSuffix = this.comboBox3.Text;
			Configs.BaseConfig.ChapterName2Num = this.checkBox2.Checked;
			Configs.BaseConfig.IndexAntiCollectNum = Convert.ToInt32(this.numericUpDown1.Value);
			Configs.BaseConfig.ZhanQun = this.ZhanQun.Checked;
			Configs.BaseConfig.ChapterPagingNum = Convert.ToInt32(this.numericUpDown4.Value);
			Configs.BaseConfig.SizeNullChapter = Convert.ToInt32(this.numericUpDown8.Value);
			Configs.BaseConfig.InternalLinkUrl = this.maskedTextBox4.Text;
			Configs.BaseConfig.InternalLinkDensity = Convert.ToInt32(this.numericUpDown5.Value);
			Configs.BaseConfig.InternalLink = this.checkBox3.Checked;
			Configs.BaseConfig.InternalLinkHead = this.maskedTextBox2.Text;
			Configs.BaseConfig.InternalLinkFoot = this.maskedTextBox3.Text;
			Configs.BaseConfig.TuijianType = this.comboBox1.Text;
			Configs.BaseConfig.TuijianTemplates = this.textBox5.Text;
			Configs.BaseConfig.NewAntiCollectNum = Convert.ToInt32(this.numericUpDown4.Value);
			Configs.BaseConfig.OnAntiCollectNum = Convert.ToInt32(this.numericUpDown10.Value);
			Configs.BaseConfig.OnAntiCollectDir = this.textBox6.Text;
			ConfigFileManager.SaveConfig("BaseConfig.xml", Configs.BaseConfig);
		}

		private void NumOrPinyincomboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.NumOrPinyincomboBox.Text.ToLower() == Localization.Get("数字id目录").ToLower())
			{
				this.NumOrPinyinDircomboBox.Items.Clear();
				this.NumOrPinyinDircomboBox.Items.Add("ID");
				this.NumOrPinyinDircomboBox.Items.Add(Localization.Get("ID除1000/ID"));
				this.NumOrPinyinDircomboBox.Text = Localization.Get("ID除1000/ID");
			}
			else if (this.NumOrPinyincomboBox.Text.ToLower() == Localization.Get("拼音目录").ToLower())
			{
				this.NumOrPinyinDircomboBox.Items.Clear();
				this.NumOrPinyinDircomboBox.Items.Add(Localization.Get("拼音"));
				this.NumOrPinyinDircomboBox.Items.Add(Localization.Get("拼音前三字母/拼音"));
				this.NumOrPinyinDircomboBox.Text = Localization.Get("拼音");
				if (Configs.HaveFunction.IndexOf("PinyinDir") < 0)
				{
					MessageBox.Show(Localization.Get("警告：当前数字/拼音化设置与您的版本不相符,自动恢复默认的数字ID目录"));
					this.NumOrPinyincomboBox.Text = Localization.Get("数字ID目录");
				}
			}
		}

		private void SaveImage()
		{
			if (File.Exists(this.picPath))
			{
				File.Delete(this.picPath);
			}
			this.webBrowser.Width = this.imgWidth;
			this.webBrowser.Height = this.imgHeight;
			int width = this.webBrowser.Width;
			int height = this.webBrowser.Height;
			try
			{
				Snapshot snapshot = new Snapshot();
				Bitmap bitmap = snapshot.TakeSnapshot(this.webBrowser.ActiveXInstance, new Rectangle(0, 0, width, height), width, height);
				try
				{
					bitmap.Save(this.picPath, ImageFormat.Jpeg);
					bitmap.Dispose();
				}
				finally
				{
					if (bitmap != null)
					{
						((IDisposable)bitmap).Dispose();
					}
				}
			}
			catch (Exception exception)
			{
			}
			this.picEnd = true;
		}

		private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
			((WebBrowser)sender).Document.Window.Error += new HtmlElementErrorEventHandler(this.Window_Error);
			if (this.webBrowser.ReadyState == WebBrowserReadyState.Complete && !this.webBrowser.IsBusy)
			{
				this.SaveImage();
			}
		}

		private void Window_Error(object sender, HtmlElementErrorEventArgs e)
		{
			e.Handled = true;
		}
	}
}