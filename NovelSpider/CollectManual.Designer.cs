using NovelSpider.Common;
using NovelSpider.Config;
using NovelSpider.Entity;
using NovelSpider.Local;
using NovelSpider.Local.Jieqi;
using NovelSpider.Local.Qiwen;
using NovelSpider.Target;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
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
	public class CollectManual : DockContent
	{
		private TextBox articlenameBox;

		private BackgroundWorker backgroundWorker_0;

		private BackgroundWorker backgroundWorker_1;

		private BackgroundWorker backgroundWorker_10;

		private BackgroundWorker backgroundWorker_11;

		private BackgroundWorker backgroundWorker_12;

		private BackgroundWorker backgroundWorker_2;

		private BackgroundWorker backgroundWorker_3;

		private BackgroundWorker backgroundWorker_4;

		private BackgroundWorker backgroundWorker_5;

		private BackgroundWorker backgroundWorker_6;

		private BackgroundWorker backgroundWorker_7;

		private BackgroundWorker backgroundWorker_8;

		private BackgroundWorker backgroundWorker_9;

		private bool bool_0;

		private Button button_0;

		private Button button_1;

		private Button button_2;

		private Button button_3;

		private Button button1;

		private Button button2;

		private ChapterInfo[] chapterInfo_0;

		private ChapterInfo[] chapterInfo_1;

		private TextBox chapterNameBox;

		private TextBox chapterTXTBox;

		private ColumnHeader columnHeader_0;

		private ColumnHeader columnHeader_1;

		private ColumnHeader columnHeader_10;

		private ColumnHeader columnHeader_11;

		private ColumnHeader columnHeader_12;

		private ColumnHeader columnHeader_13;

		private ColumnHeader columnHeader_14;

		private ColumnHeader columnHeader_15;

		private ColumnHeader columnHeader_2;

		private ColumnHeader columnHeader_3;

		private ColumnHeader columnHeader_4;

		private ColumnHeader columnHeader_5;

		private ColumnHeader columnHeader_6;

		private ColumnHeader columnHeader_7;

		private ColumnHeader columnHeader_8;

		private ColumnHeader columnHeader_9;

		private ComboBox comboBox_0;

		private ComboBox comboBox_1;

		private ComboBox comboBox_2;

		private ComboBox comboBox_3;

		private ComboBox comboBox_4;

		private Button Db3InsertButton;

		private ToolStripMenuItem DelSelectLog;

		private ComboBox ErrIdcomboBox;

		private GroupBox groupBox1;

		private IContainer icontainer_0;

		private int int_0;

		private int int_1;

		private int int_2;

		private int int_3;

		private Label label_0;

		private Label label_1;

		private Label label1;

		private Label label10;

		private Label label11;

		private Label label12;

		private Label label2;

		private Label label3;

		private Label label4;

		private Label label5;

		private Label label6;

		private Label label7;

		private Label label8;

		private Label label9;

		private ListView listView_0;

		private ListView listView_1;

		private ListView listView_2;

		private ListView listView1;

		private System.Windows.Forms.ContextMenuStrip LocalMenuStrip;

		private System.Windows.Forms.ContextMenuStrip LocalMenuStrip_1;

		private NovelInfo novelInfo_0;

		private System.Windows.Forms.ContextMenuStrip NovelMenuStrip;

		private Page page_0;

		private Panel panel_0;

		private Panel panel_1;

		private Panel panel_2;

		private TextBox posterBox;

		private RadioButton radioButton_0;

		private RadioButton radioButton_1;

		private RadioButton radioButton_2;

		private RadioButton radioButton_3;

		private RadioButton radioButton_4;

		private ReplaceConfigInfo replaceConfigInfo_0;

		private Panel ReviseChapter;

		private RuleConfigInfo ruleConfigInfo_0;

		private ComboBox sortBox;

		private SplitContainer splitContainer_0;

		private SplitContainer splitContainer_1;

		private SplitContainer splitContainer1;

		private StatusStrip statusStrip_0;

		private string string_0;

		private string string_1;

		private System.Windows.Forms.ContextMenuStrip TargetMenuStrip;

		private TaskConfigInfo taskConfigInfo_0;

		private ToolStrip toolStrip_0;

		private ToolStripButton toolStripButton_0;

		private ToolStripButton toolStripButton_1;

		private ToolStripButton toolStripButton_3;

		private ToolStripMenuItem toolStripMenuItem_1;

		private ToolStripMenuItem toolStripMenuItem_10;

		private ToolStripMenuItem toolStripMenuItem_11;

		private ToolStripMenuItem toolStripMenuItem_12;

		private ToolStripMenuItem toolStripMenuItem_13;

		private ToolStripMenuItem toolStripMenuItem_14;

		private ToolStripMenuItem toolStripMenuItem_15;

		private ToolStripMenuItem toolStripMenuItem_16;

		private ToolStripMenuItem toolStripMenuItem_17;

		private ToolStripMenuItem toolStripMenuItem_18;

		private ToolStripMenuItem toolStripMenuItem_19;

		private ToolStripMenuItem toolStripMenuItem_2;

		private ToolStripMenuItem toolStripMenuItem_20;

		private ToolStripMenuItem toolStripMenuItem_21;

		private ToolStripMenuItem toolStripMenuItem_22;

		private ToolStripMenuItem toolStripMenuItem_23;

		private ToolStripMenuItem toolStripMenuItem_24;

		private ToolStripMenuItem toolStripMenuItem_25;

		private ToolStripMenuItem toolStripMenuItem_3;

		private ToolStripMenuItem toolStripMenuItem_4;

		private ToolStripMenuItem toolStripMenuItem_5;

		private ToolStripMenuItem toolStripMenuItem_6;

		private ToolStripMenuItem toolStripMenuItem_7;

		private ToolStripMenuItem toolStripMenuItem_8;

		private ToolStripMenuItem toolStripMenuItem_9;

		private ToolStripSeparator toolStripSeparator_0;

		private ToolStripSeparator toolStripSeparator_1;

		private ToolStripSeparator toolStripSeparator_2;

		private ToolStripSeparator toolStripSeparator_3;

		private ToolStripSeparator toolStripSeparator_4;

		private ToolStripSeparator toolStripSeparator_5;

		private ToolStripSeparator toolStripSeparator_6;

		private ToolStripSeparator toolStripSeparator1;

		private ToolStripStatusLabel toolStripStatusLabel_0;

		private ToolStripStatusLabel toolStripStatusLabel_1;

		private ToolTip toolTip_0;

		private ToolStripMenuItem 反选章节ToolStripMenuItem;

		private ToolStripMenuItem 检测TXTToolStripMenuItem;

		private ToolStripMenuItem 检查重复章节ToolStripMenuItem;

		private ToolStripMenuItem 全不选章节ToolStripMenuItem;

		private ToolStripMenuItem 全选章节ToolStripMenuItem;

		private ToolStripMenuItem 删除本章数据库ToolStripMenuItem;

		private ToolStripMenuItem 删除分卷ToolStripMenuItem;

		private ToolStripMenuItem 设选中小说为全本ToolStripMenuItem;

		private ToolStripMenuItem 修改选中章节ToolStripMenuItem;

		private ToolStripMenuItem 选中后续并采集ToolStripMenuItem;

		private ToolStripMenuItem 选中后续章节ToolStripMenuItem;

		private ToolStripMenuItem 选中中间章节ToolStripMenuItem;

		private IContainer components;

		private ToolStripMenuItem 选中中间章节ToolStripMenuItem1;

		private BackgroundWorker backgroundWorker1;

		private Thread thr;

		public CollectManual()
		{
			Class19.Q77LubhzKM3NS();
			this.replaceConfigInfo_0 = new ReplaceConfigInfo();
			this.ruleConfigInfo_0 = new RuleConfigInfo();
			this.string_0 = "GetId";
			this.string_1 = "";
			this.taskConfigInfo_0 = new TaskConfigInfo();
			this.InitializeComponent();
		}

		private void backgroundWorker_0_DoWork(object sender, DoWorkEventArgs e)
		{
			BackgroundWorker backgroundWorker = sender as BackgroundWorker;
			NovelInfo novelInfo0 = this.novelInfo_0;
			ChapterInfo[] argument = (ChapterInfo[])e.Argument;
			for (int i = 0; i < (int)argument.Length && !backgroundWorker.CancellationPending; i++)
			{
				bool flag = argument[i].chaptertype == 0;
				NovelSpider.Local.LocalProvider.GetInstance().DeleteChapter(novelInfo0, novelInfo0.PutID, argument[i].PutID, flag, true);
			}
			NovelSpider.Local.LocalProvider.GetInstance().CreateIndex(novelInfo0, Configs.BaseConfig.IndexHtml, Configs.BaseConfig.FullHtml, Configs.BaseConfig.bool_10, Configs.BaseConfig.CreateTxt, false, false, 0);
			ChapterInfo[] chapterList = NovelSpider.Local.LocalProvider.GetInstance().GetChapterList(novelInfo0.PutID);
			ChapterInfo[] volumeNameList = NovelSpider.Local.LocalProvider.GetInstance().GetVolumeNameList(novelInfo0.PutID);
			backgroundWorker.ReportProgress(30, chapterList);
			backgroundWorker.ReportProgress(34, volumeNameList);
			if ((int)chapterList.Length > 0)
			{
				novelInfo0.LastChapter = chapterList[(int)chapterList.Length - 1];
			}
			backgroundWorker.ReportProgress(12, novelInfo0);
			backgroundWorker.ReportProgress(13, novelInfo0);
		}

		private void backgroundWorker_1_DoWork(object sender, DoWorkEventArgs e)
		{
			BackgroundWorker backgroundWorker = sender as BackgroundWorker;
			NovelInfo novelInfo0 = this.novelInfo_0;
			ChapterInfo[] argument = (ChapterInfo[])e.Argument;
			for (int i = 0; i < (int)argument.Length && !backgroundWorker.CancellationPending; i++)
			{
				ChapterInfo chapterInfo = NovelSpider.Local.LocalProvider.GetInstance().GetChapterInfo(novelInfo0.PutID, argument[i].PutID);
				chapterInfo.ItemIndex = argument[i].ItemIndex;
				chapterInfo.VolumeName = argument[i].VolumeName;
				backgroundWorker.ReportProgress(32, chapterInfo);
			}
		}

		private void backgroundWorker_10_DoWork(object sender, DoWorkEventArgs e)
		{
			BackgroundWorker backgroundWorker = sender as BackgroundWorker;
			NovelInfo argument = (NovelInfo)e.Argument;
			if (argument.NovelUrl == null)
			{
				argument = this.page_0.GetNovelInfo(argument);
			}
			this.int_0 = 0;
			backgroundWorker.ReportProgress(11, argument);
			if (argument.PutID == 0)
			{
				argument = NovelSpider.Local.LocalProvider.GetInstance().GetNovelInfo(argument, this.taskConfigInfo_0.NameAndAuthor);
			}
			NovelSpider.Local.LocalProvider.GetInstance().UpdateNovel(argument, false, false, true, false, false, false, false);
		}

		private void backgroundWorker_11_DoWork(object sender, DoWorkEventArgs e)
		{
			BackgroundWorker backgroundWorker = sender as BackgroundWorker;
			string[] argument = (string[])e.Argument;
			for (int i = 0; i < (int)argument.Length; i++)
			{
				string[] strArrays = argument[i].Split(new char[] { '\u005E' });
				if ((int)strArrays.Length == 5)
				{
					try
					{
						SpiderException.removeSqlite(Convert.ToInt32(strArrays[1]), Convert.ToInt32(strArrays[2]), strArrays[3], strArrays[4]);
					}
					catch (Exception exception)
					{
						backgroundWorker.ReportProgress(35, exception.Message);
					}
				}
				else
				{
					backgroundWorker.ReportProgress(35, Localization.Get("参数错误,请确认您选中的小说来自错误日志"));
				}
			}
			backgroundWorker.ReportProgress(36, "");
			backgroundWorker.ReportProgress(35, Localization.Get("删除成功"));
		}

		private void backgroundWorker_12_DoWork(object sender, DoWorkEventArgs e)
		{
			BackgroundWorker backgroundWorker = sender as BackgroundWorker;
			NovelInfo novelInfo0 = this.novelInfo_0;
			ChapterInfo[] argument = (ChapterInfo[])e.Argument;
			for (int i = 0; i < (int)argument.Length && !backgroundWorker.CancellationPending; i++)
			{
				NovelSpider.Local.LocalProvider.GetInstance().DeleteChapter(novelInfo0, novelInfo0.PutID, argument[i].PutID, true, false);
			}
			NovelSpider.Local.LocalProvider.GetInstance().CreateIndex(novelInfo0, Configs.BaseConfig.IndexHtml, Configs.BaseConfig.FullHtml, Configs.BaseConfig.bool_10, Configs.BaseConfig.CreateTxt, false, false, 0);
			ChapterInfo[] chapterList = NovelSpider.Local.LocalProvider.GetInstance().GetChapterList(novelInfo0.PutID);
			ChapterInfo[] volumeNameList = NovelSpider.Local.LocalProvider.GetInstance().GetVolumeNameList(novelInfo0.PutID);
			backgroundWorker.ReportProgress(30, chapterList);
			backgroundWorker.ReportProgress(34, volumeNameList);
			if ((int)chapterList.Length > 0)
			{
				novelInfo0.LastChapter = chapterList[(int)chapterList.Length - 1];
			}
			backgroundWorker.ReportProgress(12, novelInfo0);
			backgroundWorker.ReportProgress(13, novelInfo0);
		}

		private void backgroundWorker_12_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			string[] getID;
			double num;
			DateTime lastTime;
			switch (e.ProgressPercentage)
			{
				case 10:
				{
					NovelInfo userState = (NovelInfo)e.UserState;
					userState.ItemIndex = this.listView_2.Items.Count;
					string str = "";
					DateTime now = DateTime.Now;
					DateTime localTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
					long num1 = long.Parse(string.Concat(userState.LastupDate, "0000000 "));
					now = localTime.Add(new TimeSpan(num1));
					str = now.ToString("MM-dd hh:mm");
					getID = new string[] { userState.GetID, null, null, null, null };
					getID[1] = string.Concat((userState.Degree == 0 ? Localization.Get(Localization.Get("[载]")) : Localization.Get(Localization.Get("[完]"))), userState.Name);
					getID[2] = userState.PutID.ToString();
					getID[3] = userState.LastChapter.ChapterName;
					getID[4] = (userState.PutID != 0 ? str : Localization.Get(Localization.Get("新作品")));
					string[] strArrays = getID;
					this.listView_2.Items.Insert(userState.ItemIndex, new ListViewItem(strArrays));
					this.listView_2.Items[userState.ItemIndex].Tag = userState;
					this.listView_2.Items[userState.ItemIndex].UseItemStyleForSubItems = false;
					if (userState.Degree != 0)
					{
						this.listView_2.Items[userState.ItemIndex].SubItems[1].ForeColor = Color.Red;
					}
					TimeSpan timeSpan = DateTime.Now - now;
					if (timeSpan.Days < 1)
					{
						this.listView_2.Items[userState.ItemIndex].SubItems[4].BackColor = Color.Orange;
					}
					if ((timeSpan.Days >= 4 ? false : timeSpan.Days > 0))
					{
						this.listView_2.Items[userState.ItemIndex].SubItems[4].BackColor = Color.SeaGreen;
					}
					if ((timeSpan.Days <= 3 ? false : timeSpan.Days < 8))
					{
						this.listView_2.Items[userState.ItemIndex].SubItems[4].BackColor = Color.DeepPink;
					}
					if (timeSpan.Days <= 7)
					{
						return;
					}
					this.listView_2.Items[userState.ItemIndex].SubItems[4].BackColor = Color.Red;
					return;
				}
				case 11:
				{
					NovelInfo mistyRose = (NovelInfo)e.UserState;
					this.listView_2.Items[mistyRose.ItemIndex].SubItems[1].Text = string.Concat((mistyRose.Degree == 0 ? Localization.Get("[载]") : Localization.Get("[完]")), mistyRose.Name);
					this.listView_2.Items[mistyRose.ItemIndex].UseItemStyleForSubItems = true;
					this.listView_2.Items[mistyRose.ItemIndex].BackColor = Color.MistyRose;
					this.listView_2.Items[mistyRose.ItemIndex].EnsureVisible();
					return;
				}
				case 12:
				{
					NovelInfo chapterName = (NovelInfo)e.UserState;
					this.listView_2.Items[chapterName.ItemIndex].UseItemStyleForSubItems = true;
					this.listView_2.Items[chapterName.ItemIndex].SubItems[0].Text = chapterName.GetID;
					this.listView_2.Items[chapterName.ItemIndex].SubItems[1].Text = string.Concat((chapterName.Degree == 0 ? Localization.Get("[载]") : Localization.Get("[完]")), chapterName.Name);
					this.listView_2.Items[chapterName.ItemIndex].SubItems[2].Text = chapterName.PutID.ToString();
					this.listView_2.Items[chapterName.ItemIndex].SubItems[3].Text = chapterName.LastChapter.ChapterName;
					this.listView_2.Items[chapterName.ItemIndex].Tag = chapterName;
					return;
				}
				case 13:
				{
					NovelInfo novelInfo = (NovelInfo)e.UserState;
					this.listView_0.Tag = novelInfo;
					this.listView_1.Tag = novelInfo;
					return;
				}
				case 14:
				case 15:
				case 16:
				case 17:
				case 18:
				case 19:
				case 23:
				case 24:
				case 25:
				case 26:
				case 27:
				case 28:
				case 29:
				{
					return;
				}
				case 20:
				{
					ChapterInfo[] defaultVolumeName = (ChapterInfo[])e.UserState;
					NovelInfo tag = (NovelInfo)this.listView_0.Tag;
					if (defaultVolumeName != null)
					{
						bool flag = false;
						this.listView_0.BeginUpdate();
						this.listView_0.Items.Clear();
						int num2 = 0;
						int red = -1;
						for (int i = 0; i < (int)defaultVolumeName.Length; i++)
						{
							defaultVolumeName[i].ItemIndex = i;
							if ((string.IsNullOrEmpty(this.taskConfigInfo_0.FilterContinueVolume[0].Trim()) ? false : Regex.Match(defaultVolumeName[i].VolumeName, this.taskConfigInfo_0.FilterContinueVolume[0].ToString(), RegexOptions.IgnoreCase).Success))
							{
								if ((i != 0 ? true : string.IsNullOrEmpty(defaultVolumeName[0].VolumeName.Trim())))
								{
									defaultVolumeName[i].VolumeName = "";
								}
								else
								{
									defaultVolumeName[0].VolumeName = Configs.BaseConfig.DefaultVolumeName;
								}
							}
							getID = new string[4];
							num = Convert.ToDouble(defaultVolumeName[i].ItemIndex) + Convert.ToDouble(1);
							getID[0] = num.ToString();
							getID[1] = defaultVolumeName[i].VolumeName;
							getID[2] = defaultVolumeName[i].ChapterName;
							getID[3] = "";
							string[] strArrays1 = getID;
							this.listView_0.Items.Insert(i, new ListViewItem(strArrays1));
							this.listView_0.Items[i].Tag = defaultVolumeName[i];
							switch (this.taskConfigInfo_0.EqualsChapter)
							{
								case 0:
								{
									if (defaultVolumeName[i].ChapterName != tag.LastChapter.ChapterName)
									{
										break;
									}
									red = i;
									this.listView_0.Items[i].BackColor = Color.Red;
									flag = true;
									break;
								}
								case 1:
								{
									if ((defaultVolumeName[i].ChapterName != tag.LastChapter.ChapterName ? true : !(defaultVolumeName[i].VolumeName == tag.LastChapter.VolumeName)))
									{
										break;
									}
									red = i;
									this.listView_0.Items[i].BackColor = Color.Red;
									flag = true;
									break;
								}
								case 2:
								{
									if (!FormatText.CompareToChapter(defaultVolumeName[i].ChapterName, tag.LastChapter.ChapterName))
									{
										break;
									}
									red = i;
									this.listView_0.Items[i].BackColor = Color.Red;
									flag = true;
									break;
								}
								case 3:
								{
									int chapter2 = FormatText.CompareToChapter2(defaultVolumeName[i].ChapterName, tag.LastChapter.ChapterName, defaultVolumeName[i].VolumeName, tag.LastChapter.VolumeName);
									if (chapter2 <= 6)
									{
										break;
									}
									if (chapter2 >= num2)
									{
										num2 = chapter2;
										red = i;
									}
									SpiderException.Debug(this.taskConfigInfo_0.ID, string.Concat(defaultVolumeName[i].ChapterName, " ", chapter2.ToString()));
									this.listView_0.Items[i].BackColor = Color.Pink;
									flag = true;
									break;
								}
								case 4:
								{
									int chapter3 = FormatText.CompareToChapter3(defaultVolumeName[i].ChapterName, tag.LastChapter.ChapterName, defaultVolumeName[i].VolumeName, tag.LastChapter.VolumeName);
									if (chapter3 <= 0)
									{
										break;
									}
									if (chapter3 >= num2)
									{
										num2 = chapter3;
										red = i;
									}
									SpiderException.Debug(this.taskConfigInfo_0.ID, string.Concat(defaultVolumeName[i].ChapterName, " ", chapter3.ToString()));
									this.listView_0.Items[i].BackColor = Color.Pink;
									flag = true;
									break;
								}
							}
						}
						if (red >= 0)
						{
							this.listView_0.Items[red].BackColor = Color.Red;
							if ((red <= 5 ? true : this.listView_0.Items.Count <= red))
							{
								this.listView_0.Items[red].EnsureVisible();
							}
							else if (this.listView_0.Items.Count - red <= 3)
							{
								this.listView_0.Items[this.listView_0.Items.Count - 1].EnsureVisible();
							}
							else
							{
								this.listView_0.Items[red + 2].EnsureVisible();
							}
						}
						if ((flag ? false : (int)defaultVolumeName.Length > 0))
						{
							this.listView_0.Items[(int)defaultVolumeName.Length - 1].EnsureVisible();
						}
						this.listView_0.EndUpdate();
						return;
					}
					else
					{
						this.listView_0.Items.Clear();
						return;
					}
				}
				case 21:
				{
					ChapterInfo chapterInfo = (ChapterInfo)e.UserState;
					this.listView_0.Items[chapterInfo.ItemIndex].BackColor = Color.MistyRose;
					this.listView_0.Items[chapterInfo.ItemIndex].EnsureVisible();
					return;
				}
				case 22:
				{
					ChapterInfo volumeName = (ChapterInfo)e.UserState;
					this.listView_0.Items[volumeName.ItemIndex].SubItems[1].Text = volumeName.VolumeName;
					this.listView_0.Items[volumeName.ItemIndex].SubItems[2].Text = volumeName.ChapterName;
					this.listView_0.Items[volumeName.ItemIndex].SubItems[3].Text = Localization.Get("文");
					this.listView_0.Items[volumeName.ItemIndex].Checked = false;
					return;
				}
				case 30:
				{
					ChapterInfo[] chapterInfoArray = (ChapterInfo[])e.UserState;
					NovelInfo tag1 = (NovelInfo)this.listView_0.Tag;
					if ((chapterInfoArray == null ? false : (int)chapterInfoArray.Length != 0))
					{
						this.listView_1.BeginUpdate();
						this.listView_1.Items.Clear();
						for (int j = 0; j < (int)chapterInfoArray.Length; j++)
						{
							chapterInfoArray[j].ItemIndex = j;
							getID = new string[5];
							num = Convert.ToDouble(chapterInfoArray[j].ItemIndex) + Convert.ToDouble(1);
							getID[0] = num.ToString();
							getID[1] = chapterInfoArray[j].VolumeName;
							getID[2] = chapterInfoArray[j].ChapterName;
							lastTime = chapterInfoArray[j].LastTime;
							getID[3] = lastTime.ToString("MM-dd hh:mm");
							getID[4] = "";
							string[] strArrays2 = getID;
							this.listView_1.Items.Insert(j, new ListViewItem(strArrays2));
							this.listView_1.Items[j].UseItemStyleForSubItems = false;
							TimeSpan now1 = DateTime.Now - chapterInfoArray[j].LastTime;
							if (now1.Days < 1)
							{
								this.listView_1.Items[j].SubItems[3].BackColor = Color.Orange;
							}
							if ((now1.Days >= 4 ? false : now1.Days > 0))
							{
								this.listView_1.Items[j].SubItems[3].BackColor = Color.SeaGreen;
							}
							if ((now1.Days <= 3 ? false : now1.Days < 8))
							{
								this.listView_1.Items[j].SubItems[3].BackColor = Color.DeepPink;
							}
							if (now1.Days > 7)
							{
								this.listView_1.Items[j].SubItems[3].BackColor = Color.Red;
							}
							this.listView_1.Items[j].Tag = chapterInfoArray[j];
							this.listView_1.Items[j].EnsureVisible();
						}
						this.listView_1.Items[(int)chapterInfoArray.Length - 1].EnsureVisible();
						this.listView_1.EndUpdate();
						return;
					}
					else
					{
						this.listView_1.Items.Clear();
						return;
					}
				}
				case 31:
				{
					ChapterInfo userState1 = (ChapterInfo)e.UserState;
					this.listView_1.Items[userState1.ItemIndex].BackColor = Color.MistyRose;
					this.listView_1.Items[userState1.ItemIndex].EnsureVisible();
					return;
				}
				case 32:
				{
					ChapterInfo volumeName1 = (ChapterInfo)e.UserState;
					this.listView_1.Items[volumeName1.ItemIndex].UseItemStyleForSubItems = true;
					this.listView_1.Items[volumeName1.ItemIndex].SubItems[1].Text = volumeName1.VolumeName;
					this.listView_1.Items[volumeName1.ItemIndex].SubItems[2].Text = volumeName1.ChapterName;
					ListViewItem.ListViewSubItem item = this.listView_1.Items[volumeName1.ItemIndex].SubItems[3];
					lastTime = volumeName1.LastTime;
					item.Text = lastTime.ToString("MM-dd hh:mm");
					this.listView_1.Items[volumeName1.ItemIndex].SubItems[4].Text = Localization.Get("文");
					this.listView_1.Items[volumeName1.ItemIndex].Tag = volumeName1;
					this.listView_1.Items[volumeName1.ItemIndex].Checked = false;
					return;
				}
				case 33:
				{
					this.listView_1.Items[this.int_3].EnsureVisible();
					return;
				}
				case 34:
				{
					ChapterInfo[] chapterInfoArray1 = (ChapterInfo[])e.UserState;
					NovelInfo novelInfo1 = (NovelInfo)this.listView_0.Tag;
					if (chapterInfoArray1 == null)
					{
						return;
					}
					this.listView1.BeginUpdate();
					this.listView1.Items.Clear();
					for (int k = 0; k < (int)chapterInfoArray1.Length; k++)
					{
						chapterInfoArray1[k].ItemIndex = k;
						getID = new string[2];
						int itemIndex = chapterInfoArray1[k].ItemIndex;
						getID[0] = itemIndex.ToString();
						getID[1] = chapterInfoArray1[k].VolumeName;
						string[] strArrays3 = getID;
						this.listView1.Items.Insert(k, new ListViewItem(strArrays3));
						this.listView1.Items[k].Tag = chapterInfoArray1[k];
					}
					this.listView1.EndUpdate();
					return;
				}
				case 35:
				{
					MessageBox.Show((string)e.UserState);
					return;
				}
				case 36:
				{
					ArrayList arrayLists = new ArrayList();
					for (int l = 0; l < this.listView_2.Items.Count; l++)
					{
						if (!this.listView_2.Items[l].Checked)
						{
							arrayLists.Add(this.listView_2.Items[l].Tag);
						}
					}
					this.listView_2.Items.Clear();
					for (int m = 0; m < arrayLists.Count; m++)
					{
						NovelInfo item1 = (NovelInfo)arrayLists[m];
						item1.ItemIndex = m;
						getID = new string[] { item1.GetID, item1.Name, item1.PutID.ToString(), item1.LastChapter.ChapterName };
						string[] strArrays4 = getID;
						this.listView_2.Items.Insert(item1.ItemIndex, new ListViewItem(strArrays4));
						this.listView_2.Items[item1.ItemIndex].Tag = item1;
					}
					this.listView_0.Items.Clear();
					this.listView_1.Items.Clear();
					this.listView1.Items.Clear();
					return;
				}
				default:
				{
					return;
				}
			}
		}

		private void backgroundWorker_12_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (e.Error != null)
			{
				this.toolStripStatusLabel_0.Text = Localization.Get("发生错误");
				MessageBox.Show(e.Error.Message);
			}
			else if (!e.Cancelled)
			{
				this.toolStripStatusLabel_0.Text = Localization.Get("操作完成");
			}
			else
			{
				this.toolStripStatusLabel_0.Text = Localization.Get("取消操作");
			}
			this.panel_0.Visible = false;
			this.panel_1.Visible = false;
			this.button_0.Enabled = true;
			this.button_3.Enabled = true;
			this.bool_0 = false;
			this.panel_2.Enabled = true;
		}

		private void backgroundWorker_2_DoWork(object sender, DoWorkEventArgs e)
		{
			BackgroundWorker backgroundWorker = sender as BackgroundWorker;
			NovelInfo novelInfo0 = this.novelInfo_0;
			int num = 0;
			while (true)
			{
				if ((num >= (int)this.chapterInfo_0.Length ? true : backgroundWorker.CancellationPending))
				{
					break;
				}
				novelInfo0.LastChapter = this.chapterInfo_0[num];
				backgroundWorker.ReportProgress(21, novelInfo0.LastChapter);
				novelInfo0 = this.page_0.GetChapterInfo(novelInfo0, false);
				backgroundWorker.ReportProgress(22, novelInfo0.LastChapter);
				if ((novelInfo0.LastChapter.ChapterText == null ? true : novelInfo0.LastChapter.ChapterText.Trim() == ""))
				{
					string str = string.Concat(this.comboBox_2.Text, " | ", this.comboBox_3.Text);
					SpiderException.Show(Localization.Get("发现空章节"), novelInfo0, this.taskConfigInfo_0.Log, str);
					break;
				}
				else if ((!Regex.Match(novelInfo0.LastChapter.ChapterText, "<img", RegexOptions.IgnoreCase).Success ? false : this.taskConfigInfo_0.OnlyText))
				{
					string str1 = string.Concat(this.comboBox_2.Text, " | ", this.comboBox_3.Text);
					SpiderException.Show(Localization.Get("发现图片章节"), novelInfo0, this.taskConfigInfo_0.Log, str1);
					break;
				}
				else
				{
					novelInfo0.LastChapter.PutID = this.chapterInfo_1[num].PutID;
					this.chapterInfo_1[num].ChapterName = novelInfo0.LastChapter.ChapterName;
					this.chapterInfo_1[num].ChapterText = novelInfo0.LastChapter.ChapterText;
					backgroundWorker.ReportProgress(31, this.chapterInfo_1[num]);
					novelInfo0.LastChapter.LastTime = DateTime.Now;
					NovelSpider.Local.LocalProvider.GetInstance().UpdateChapter(novelInfo0, this.replaceConfigInfo_0);
					if (Configs.BaseConfig.ChapterHtml)
					{
						NovelSpider.Local.LocalProvider.GetInstance().CreateChapter(novelInfo0);
					}
					backgroundWorker.ReportProgress(32, this.chapterInfo_1[num]);
					num++;
				}
			}
			NovelSpider.Local.LocalProvider.GetInstance().UpdateLastChapter(novelInfo0);
			NovelSpider.Local.LocalProvider.GetInstance().CreateIndex(novelInfo0, Configs.BaseConfig.IndexHtml, Configs.BaseConfig.FullHtml, Configs.BaseConfig.bool_10, Configs.BaseConfig.CreateTxt, false, false, 0);
		}

		private void backgroundWorker_3_DoWork(object sender, DoWorkEventArgs e)
		{
			NovelInfo[] novelInfo;
			char[] chrArray;
			BackgroundWorker backgroundWorker = (BackgroundWorker)sender;
			Page page = new Page(this.ruleConfigInfo_0, this.taskConfigInfo_0);
			NovelInfo[] novelList = null;
			string string0 = this.string_0;
			if (string0 != null)
			{
				if (string0 == "Get")
				{
					string string1 = this.string_1;
					chrArray = new char[] { ',' };
					novelList = page.GetNovelList(string1.Split(chrArray));
					for (int i = 0; i < (int)novelList.Length; i++)
					{
						novelList[i] = this.page_0.GetNovelInfo(novelList[i]);
						novelList[i] = NovelSpider.Local.LocalProvider.GetInstance().GetNovelInfo(novelList[i], this.taskConfigInfo_0.NameAndAuthor);
						if (novelList[i] != null)
						{
							backgroundWorker.ReportProgress(10, novelList[i]);
						}
					}
				}
				else if (string0 == "Put")
				{
					novelList = NovelSpider.Local.LocalProvider.GetInstance().GetNovelList(this.string_1);
					for (int j = 0; j < (int)novelList.Length; j++)
					{
						backgroundWorker.ReportProgress(10, novelList[j]);
					}
				}
				else if (string0 == "NovelName")
				{
					novelInfo = new NovelInfo[] { new NovelInfo() };
					novelList = novelInfo;
					novelList[0].Name = this.string_1;
					novelList[0] = page.GetNovelInfo(novelList[0]);
					novelList[0] = NovelSpider.Local.LocalProvider.GetInstance().GetNovelInfo(novelList[0], this.taskConfigInfo_0.NameAndAuthor);
					for (int k = 0; k < (int)novelList.Length; k++)
					{
						backgroundWorker.ReportProgress(10, novelList[k]);
					}
				}
				else if (string0 == "GetId")
				{
					novelInfo = new NovelInfo[] { new NovelInfo() };
					novelList = novelInfo;
					if (this.string_1.IndexOf(',') <= 0)
					{
						novelList[0].GetID = this.string_1;
						novelList[0] = page.GetNovelInfo(novelList[0]);
						novelList[0] = NovelSpider.Local.LocalProvider.GetInstance().GetNovelInfo(novelList[0], this.taskConfigInfo_0.NameAndAuthor);
						for (int l = 0; l < (int)novelList.Length; l++)
						{
							backgroundWorker.ReportProgress(10, novelList[l]);
						}
					}
					else
					{
						string str = this.string_1;
						chrArray = new char[] { ',' };
						string[] strArrays = str.Split(chrArray);
						novelList = new NovelInfo[(int)strArrays.Length];
						for (int m = 0; m < (int)strArrays.Length; m++)
						{
							novelList[m] = new NovelInfo();
							novelList[m].GetID = strArrays[m];
							try
							{
								novelList[m] = page.GetNovelInfo(novelList[m]);
							}
							catch (Exception exception)
							{
                                continue;
							}
							novelList[m] = NovelSpider.Local.LocalProvider.GetInstance().GetNovelInfo(novelList[m], this.taskConfigInfo_0.NameAndAuthor);
							if (novelList[m] != null)
							{
								backgroundWorker.ReportProgress(10, novelList[m]);
							}
						}
					}
				}
				else if (string0 == "PutId")
				{
					novelInfo = new NovelInfo[] { new NovelInfo() };
					novelList = novelInfo;
					novelList[0].PutID = Convert.ToInt32(this.string_1);
					novelList[0] = NovelSpider.Local.LocalProvider.GetInstance().GetNovelInfo(novelList[0], this.taskConfigInfo_0.NameAndAuthor);
					novelList[0] = page.GetNovelInfo(novelList[0]);
					for (int n = 0; n < (int)novelList.Length; n++)
					{
						backgroundWorker.ReportProgress(10, novelList[n]);
					}
				}
			}
			e.Result = novelList;
		}

		private void backgroundWorker_5_DoWork(object sender, DoWorkEventArgs e)
		{
			BackgroundWorker backgroundWorker = (BackgroundWorker)sender;
			NovelInfo[] argument = (NovelInfo[])e.Argument;
			for (int i = 0; i < (int)argument.Length; i++)
			{
				backgroundWorker.ReportProgress(11, argument[i]);
				if (argument[i].PutID == 0)
				{
					argument[i] = NovelSpider.Local.LocalProvider.GetInstance().GetNovelInfo(argument[i], this.taskConfigInfo_0.NameAndAuthor);
				}
				else if ((argument[i].GetID == "" ? true : argument[i].GetID == null))
				{
					argument[i] = (new Page(this.ruleConfigInfo_0, this.taskConfigInfo_0)).GetNovelInfo(argument[i]);
				}
				backgroundWorker.ReportProgress(12, argument[i]);
			}
		}

		private void backgroundWorker_6_DoWork(object sender, DoWorkEventArgs e)
		{
			BackgroundWorker backgroundWorker = sender as BackgroundWorker;
			NovelInfo novelInfo0 = this.novelInfo_0;
			ChapterInfo[] argument = (ChapterInfo[])e.Argument;
			int num = 0;
			try
			{
				while (true)
				{
					if ((num >= (int)argument.Length ? true : backgroundWorker.CancellationPending))
					{
						break;
					}
					novelInfo0.LastChapter = null;
					novelInfo0.LastChapter = argument[num];
					backgroundWorker.ReportProgress(21, novelInfo0.LastChapter);
					novelInfo0 = this.page_0.GetChapterInfo(novelInfo0, false);
					backgroundWorker.ReportProgress(22, novelInfo0.LastChapter);
					if ((novelInfo0.LastChapter.ChapterText == null ? true : novelInfo0.LastChapter.ChapterText.Trim() == ""))
					{
						string empty = string.Empty;
						base.Invoke(new EventHandler((object argument0, EventArgs argument1) => empty = string.Concat(this.comboBox_2.Text, " | ", this.comboBox_3.Text)));
						SpiderException.Show(Localization.Get("发现空章节"), novelInfo0, this.taskConfigInfo_0.Log, empty);
						break;
					}
					else if ((!Regex.IsMatch(novelInfo0.LastChapter.ChapterText, "<img", RegexOptions.IgnoreCase) ? false : this.taskConfigInfo_0.OnlyText))
					{
						string str = string.Empty;
						base.Invoke(new EventHandler((object argument2, EventArgs argument3) => str = string.Concat(this.comboBox_2.Text, " | ", this.comboBox_3.Text)));
						SpiderException.Show(Localization.Get("发现图片章节"), novelInfo0, this.taskConfigInfo_0.Log, str);
						break;
					}
					else if (novelInfo0.LastChapter.ChapterText.Length <= this.taskConfigInfo_0.MinChapterTextLength)
					{
						string empty1 = string.Empty;
						base.Invoke(new EventHandler((object argument4, EventArgs argument5) => empty1 = string.Concat(this.comboBox_2.Text, " | ", this.comboBox_3.Text)));
						SpiderException.Show(Localization.Get("空章节或字数过少"), novelInfo0, this.taskConfigInfo_0.Log, empty1);
						break;
					}
					else
					{
						NovelSpider.Local.LocalProvider.GetInstance().InsertChapter(novelInfo0, this.taskConfigInfo_0);
						if (Configs.BaseConfig.ChapterHtml)
						{
							NovelSpider.Local.LocalProvider.GetInstance().CreateChapter(novelInfo0);
						}
						num++;
					}
				}
				if (Configs.BaseConfig.IndexHtml)
				{
					NovelSpider.Local.LocalProvider.GetInstance().CreateIndex(novelInfo0, Configs.BaseConfig.IndexHtml, Configs.BaseConfig.FullHtml, Configs.BaseConfig.bool_10, Configs.BaseConfig.CreateTxt, false, false, 0);
				}
				ChapterInfo[] chapterList = NovelSpider.Local.LocalProvider.GetInstance().GetChapterList(novelInfo0.PutID);
				backgroundWorker.ReportProgress(30, chapterList);
				if ((int)chapterList.Length > 0)
				{
					novelInfo0.LastChapter = chapterList[(int)chapterList.Length - 1];
				}
				backgroundWorker.ReportProgress(12, novelInfo0);
				backgroundWorker.ReportProgress(13, novelInfo0);
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		private void backgroundWorker_7_DoWork(object sender, DoWorkEventArgs e)
		{
			BackgroundWorker backgroundWorker = sender as BackgroundWorker;
			NovelInfo argument = (NovelInfo)e.Argument;
			if (argument.NovelUrl == null)
			{
				argument = this.page_0.GetNovelInfo(argument);
			}
			this.int_0 = 0;
			backgroundWorker.ReportProgress(11, argument);
			if (argument.PutID == 0)
			{
				argument = NovelSpider.Local.LocalProvider.GetInstance().GetNovelInfo(argument, this.taskConfigInfo_0.NameAndAuthor);
			}
			else if ((argument.GetID == "" ? true : argument.GetID == null))
			{
				argument = this.page_0.GetNovelInfo(argument);
			}
			ChapterInfo[] chapterList = NovelSpider.Local.LocalProvider.GetInstance().GetChapterList(argument.PutID);
			backgroundWorker.ReportProgress(30, chapterList);
			if ((chapterList == null ? false : (int)chapterList.Length > 0))
			{
				argument.LastChapter = chapterList[(int)chapterList.Length - 1];
				backgroundWorker.ReportProgress(12, argument);
				backgroundWorker.ReportProgress(13, argument);
			}
			ChapterInfo[] chapterInfoArray = this.page_0.GetChapterList(argument);
			ChapterInfo[] volumeNameList = NovelSpider.Local.LocalProvider.GetInstance().GetVolumeNameList(argument.PutID);
			backgroundWorker.ReportProgress(20, chapterInfoArray);
			backgroundWorker.ReportProgress(34, volumeNameList);
		}

		private void backgroundWorker_8_DoWork(object sender, DoWorkEventArgs e)
		{
			BackgroundWorker backgroundWorker = (BackgroundWorker)sender;
			NovelInfo[] argument = (NovelInfo[])e.Argument;
			for (int i = 0; i < (int)argument.Length; i++)
			{
				backgroundWorker.ReportProgress(11, argument[i]);
				if (argument[i].PutID == 0)
				{
					argument[i] = NovelSpider.Local.LocalProvider.GetInstance().GetNovelInfo(argument[i], this.taskConfigInfo_0.NameAndAuthor);
				}
				if (argument[i].PutID == 0)
				{
					argument[i] = (new Page(this.ruleConfigInfo_0, this.taskConfigInfo_0)).GetNovelInfo(argument[i]);
					argument[i] = NovelSpider.Local.LocalProvider.GetInstance().InsertNovel(argument[i]);
				}
				backgroundWorker.ReportProgress(12, argument[i]);
			}
		}

		private void backgroundWorker_9_DoWork(object sender, DoWorkEventArgs e)
		{
			BackgroundWorker backgroundWorker = sender as BackgroundWorker;
			NovelInfo novelInfo0 = this.novelInfo_0;
			int length = (int)this.chapterInfo_0.Length;
			int[] numArray = NovelSpider.Local.LocalProvider.GetInstance().UpdateChapterOrder(novelInfo0, length, this.int_1);
			if ((numArray[1] == -1 || numArray[1] == -1 && length > 1 ? false : numArray[0] != 0))
			{
				int num = 0;
				while (true)
				{
					if ((num >= (int)this.chapterInfo_0.Length ? true : backgroundWorker.CancellationPending))
					{
						break;
					}
					novelInfo0.LastChapter = this.chapterInfo_0[num];
					backgroundWorker.ReportProgress(21, novelInfo0.LastChapter);
					novelInfo0 = this.page_0.GetChapterInfo(novelInfo0, false);
					backgroundWorker.ReportProgress(22, novelInfo0.LastChapter);
					if ((novelInfo0.LastChapter.ChapterText == null ? true : novelInfo0.LastChapter.ChapterText.Trim() == ""))
					{
						string str = string.Concat(this.comboBox_2.Text, " | ", this.comboBox_3.Text);
						SpiderException.Show(Localization.Get("发现空章节"), novelInfo0, this.taskConfigInfo_0.Log, str);
						break;
					}
					else if ((!Regex.Match(novelInfo0.LastChapter.ChapterText, "<img", RegexOptions.IgnoreCase).Success ? false : this.taskConfigInfo_0.OnlyText))
					{
						string str1 = string.Concat(this.comboBox_2.Text, " | ", this.comboBox_3.Text);
						SpiderException.Show(Localization.Get("发现图片章节"), novelInfo0, this.taskConfigInfo_0.Log, str1);
						break;
					}
					else
					{
						NovelSpider.Local.LocalProvider.GetInstance().InsertChapterByOrder(novelInfo0, this.taskConfigInfo_0, numArray[0] + num);
						if (Configs.BaseConfig.ChapterHtml)
						{
							NovelSpider.Local.LocalProvider.GetInstance().CreateChapter(novelInfo0);
						}
						ChapterInfo[] chapterList = NovelSpider.Local.LocalProvider.GetInstance().GetChapterList(novelInfo0.PutID);
						backgroundWorker.ReportProgress(30, chapterList);
						ChapterInfo[] volumeNameList = NovelSpider.Local.LocalProvider.GetInstance().GetVolumeNameList(novelInfo0.PutID);
						backgroundWorker.ReportProgress(34, volumeNameList);
						backgroundWorker.ReportProgress(33, null);
						num++;
					}
				}
				ChapterInfo chapterInfo = new ChapterInfo()
				{
					PutID = numArray[1]
				};
				ChapterInfo chapterInfo1 = new ChapterInfo()
				{
					PutID = this.int_1
				};
				NovelSpider.Local.LocalProvider.GetInstance().CreateChapter(novelInfo0, chapterInfo);
				NovelSpider.Local.LocalProvider.GetInstance().CreateChapter(novelInfo0, chapterInfo1);
				NovelSpider.Local.LocalProvider.GetInstance().UpdateLastChapter(novelInfo0);
				NovelSpider.Local.LocalProvider.GetInstance().CreateIndex(novelInfo0, Configs.BaseConfig.IndexHtml, Configs.BaseConfig.FullHtml, Configs.BaseConfig.bool_10, Configs.BaseConfig.CreateTxt, false, false, 0);
			}
		}

		private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
		{
			NovelInfo argument = (NovelInfo)e.Argument;
			NovelSpider.Local.LocalProvider.GetInstance().UpdateNovel(argument, true, false, false, true, false, false, false);
			NovelSpider.Local.LocalProvider.GetInstance().CreateIndex(argument, Configs.BaseConfig.IndexHtml, Configs.BaseConfig.FullHtml, Configs.BaseConfig.bool_10, Configs.BaseConfig.CreateTxt, false, false, 0);
		}

		private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.ReviseChapter.Visible = false;
			for (int i = 0; i < this.listView_1.Items.Count; i++)
			{
				this.listView_1.Items[i].Checked = false;
			}
			this.sortBox.Enabled = true;
			this.button2.Enabled = true;
			this.button1.Enabled = true;
			this.toolStripStatusLabel_0.Text = Localization.Get("操作完成");
		}

		private void button_0_Click(object sender, EventArgs e)
		{
			if (!Configs.BaseConfig.LicenseOk)
			{
				MessageBox.Show(Localization.Get("授权码无效，请删除或清空根目录下xxxxxxx.ini文件"));
			}
			else if ((this.bool_0 ? false : !this.backgroundWorker_3.IsBusy))
			{
				this.toolStripStatusLabel_0.Text = Localization.Get("正在单本载入.请勿进行其他操作..");
				this.bool_0 = true;
				this.panel_2.Enabled = false;
				this.listView_1.Items.Clear();
				this.listView_0.Items.Clear();
				this.button_0.Enabled = false;
				if ((this.comboBox_0.Text == "" ? false : !this.backgroundWorker_3.IsBusy))
				{
					if (this.radioButton_2.Checked)
					{
						this.string_0 = "GetId";
					}
					if (this.radioButton_1.Checked)
					{
						this.string_0 = "NovelName";
					}
					if (this.radioButton_0.Checked)
					{
						this.string_0 = "PutId";
					}
					this.string_1 = this.comboBox_0.Text;
					this.listView_2.Items.Clear();
					this.backgroundWorker_3.RunWorkerAsync();
				}
			}
		}

		private void button_1_Click(object sender, EventArgs e)
		{
			this.panel_0.Visible = false;
		}

		private void button_2_Click(object sender, EventArgs e)
		{
			this.panel_1.Visible = false;
		}

		private void button_3_Click(object sender, EventArgs e)
		{
			if (!Configs.BaseConfig.LicenseOk)
			{
				MessageBox.Show(Localization.Get("授权码无效，请删除或清空根目录下xxxxxxx.ini文件"));
			}
			else if ((this.bool_0 ? false : !this.backgroundWorker_3.IsBusy))
			{
				this.toolStripStatusLabel_0.Text = Localization.Get("正在批量载入.请勿进行其他操作..");
				this.bool_0 = true;
				this.panel_2.Enabled = false;
				this.listView_1.Items.Clear();
				this.listView_0.Items.Clear();
				this.button_3.Enabled = false;
				if ((this.comboBox_1.Text == "" ? false : !this.backgroundWorker_3.IsBusy))
				{
					if (this.radioButton_4.Checked)
					{
						this.string_0 = "Get";
					}
					if (this.radioButton_3.Checked)
					{
						this.string_0 = "Put";
					}
					this.string_1 = this.comboBox_1.Text;
					this.listView_2.Items.Clear();
					this.backgroundWorker_3.RunWorkerAsync();
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			NovelInfo tag;
			int i;
			ChapterInfo chapterInfo;
			object[] waterSoftPath;
			int putID;
			StreamWriter streamWriter;
			bool flag;
			bool flag1;
			this.button2.Enabled = false;
			this.button1.Enabled = false;
			this.toolStripStatusLabel_0.Text = Localization.Get("正在执行");
			if (Configs.CmsName == "Qiwen")
			{
				if (!(this.articlenameBox.Text != "") || !(this.posterBox.Text != ""))
				{
					flag = true;
				}
				else
				{
					flag = (this.chapterNameBox.Text == "" ? true : !(this.chapterTXTBox.Text != ""));
				}
				if (!flag)
				{
					ArrayList arrayLists = new ArrayList();
					for (i = 0; i < this.listView_1.Items.Count; i++)
					{
						if (this.listView_1.Items[i].Checked)
						{
							tag = (NovelInfo)this.listView_0.Tag;
							chapterInfo = (ChapterInfo)this.listView_1.Items[i].Tag;
							tag.ReviseChapterID = chapterInfo.PutID;
							tag.LastChapter.ChapterText = this.chapterTXTBox.Text;
							tag.ReviseChapter = this.chapterNameBox.Text;
							tag.Name = this.articlenameBox.Text;
							this.listView_1.Items[i].SubItems[2].Text = tag.ReviseChapter;
							tag.Author = this.posterBox.Text;
							if (tag.LastChapter.ChapterText != Localization.Get("恭喜中奖了！又碰到无TXT文本的章节！或些章节为图片章节！"))
							{
								waterSoftPath = new object[] { NovelSpider.Local.Qiwen.Config.WaterSoftPath, "/files/article/image/", tag.PutID / 1000, "/", tag.PutID.ToString(), "/", null, null };
								putID = chapterInfo.PutID;
								waterSoftPath[6] = putID.ToString();
								waterSoftPath[7] = ".txt";
								streamWriter = new StreamWriter(string.Concat(waterSoftPath), false, Encoding.Default);
								streamWriter.Write(tag.LastChapter.ChapterText);
								streamWriter.Close();
							}
							this.backgroundWorker1.RunWorkerAsync(tag);
						}
					}
				}
				else if (this.articlenameBox.Text == "")
				{
					MessageBox.Show(Localization.Get("小说名不能为空"));
				}
				else if (this.posterBox.Text == "")
				{
					MessageBox.Show(Localization.Get("作者不能为空"));
				}
				else if (this.chapterNameBox.Text == "")
				{
					MessageBox.Show(Localization.Get("章节名不能为空"));
				}
				else if (this.articlenameBox.Text == "")
				{
					MessageBox.Show(Localization.Get("小说名不能为空"));
				}
				else if (this.chapterTXTBox.Text == "")
				{
					MessageBox.Show(Localization.Get("章节内容不能为空"));
				}
			}
			else
			{
				if (!(this.articlenameBox.Text != "") || !(this.posterBox.Text != ""))
				{
					flag1 = true;
				}
				else
				{
					flag1 = (this.chapterNameBox.Text == "" ? true : !(this.chapterTXTBox.Text != ""));
				}
				if (!flag1)
				{
					ArrayList arrayLists1 = new ArrayList();
					for (i = 0; i < this.listView_1.Items.Count; i++)
					{
						if (this.listView_1.Items[i].Checked)
						{
							tag = (NovelInfo)this.listView_0.Tag;
							chapterInfo = (ChapterInfo)this.listView_1.Items[i].Tag;
							tag.ReviseChapterID = chapterInfo.PutID;
							tag.LastChapter.ChapterText = this.chapterTXTBox.Text;
							tag.ReviseChapter = this.chapterNameBox.Text;
							tag.Name = this.articlenameBox.Text;
							this.listView_1.Items[i].SubItems[2].Text = tag.ReviseChapter;
							tag.Author = this.posterBox.Text;
							int num = 0;
							while (true)
							{
								if (num >= (int)NovelSpider.Local.Jieqi.Config.JieqiSort.Length)
								{
									break;
								}
								else if (this.sortBox.SelectedItem.ToString().Equals(NovelSpider.Local.Jieqi.Config.JieqiSort[num]))
								{
									tag.MLagerSortID = num;
									tag.string_0 = this.sortBox.SelectedItem.ToString();
									break;
								}
								else
								{
									num++;
								}
							}
							if (tag.LastChapter.ChapterText != Localization.Get("恭喜中奖了！又碰到无TXT文本的章节！或些章节为图片章节！"))
							{
								waterSoftPath = new object[] { NovelSpider.Local.Jieqi.Config.TxtDir, "/", tag.PutID / 1000, "/", tag.PutID.ToString(), "/", null, null };
								putID = chapterInfo.PutID;
								waterSoftPath[6] = putID.ToString();
								waterSoftPath[7] = ".txt";
								streamWriter = new StreamWriter(string.Concat(waterSoftPath), false, Encoding.Default);
								streamWriter.Write(tag.LastChapter.ChapterText);
								streamWriter.Close();
							}
							this.backgroundWorker1.RunWorkerAsync(tag);
						}
					}
				}
				else if (this.articlenameBox.Text == "")
				{
					MessageBox.Show(Localization.Get("小说名不能为空"));
				}
				else if (this.posterBox.Text == "")
				{
					MessageBox.Show(Localization.Get("作者不能为空"));
				}
				else if (this.chapterNameBox.Text == "")
				{
					MessageBox.Show(Localization.Get("章节名不能为空"));
				}
				else if (this.articlenameBox.Text == "")
				{
					MessageBox.Show(Localization.Get("小说名不能为空"));
				}
				else if (this.chapterTXTBox.Text == "")
				{
					MessageBox.Show(Localization.Get("章节内容不能为空"));
				}
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show(Localization.Get("你确定要放弃当前操作？"), "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
			{
				this.ReviseChapter.Visible = false;
			}
		}

		private void CollectManual_Load(object sender, EventArgs e)
		{
			this.taskConfigInfo_0 = (TaskConfigInfo)ConfigFileManager.LoadConfig("TaskConfig.xml", this.taskConfigInfo_0);
			try
			{
				this.comboBox_3.BeginUpdate();
				string[] strArrays = IO.LoadRules();
				if ((int)strArrays.Length > 0)
				{
					for (int i = 0; i < (int)strArrays.Length; i++)
					{
						this.comboBox_3.Items.Add(strArrays[i]);
						if (strArrays[i] == this.taskConfigInfo_0.RuleFile)
						{
							this.comboBox_3.Text = this.taskConfigInfo_0.RuleFile;
							this.ruleConfigInfo_0 = (RuleConfigInfo)ConfigFileManager.LoadConfig(this.taskConfigInfo_0.RuleFile, this.ruleConfigInfo_0);
						}
					}
				}
				this.comboBox_3.EndUpdate();
				this.comboBox_2.BeginUpdate();
				this.comboBox_2.Items.Clear();
				this.comboBox_2.Items.Add("TaskConfig.xml");
				this.comboBox_2.Text = "TaskConfig.xml";
				string[] strArrays1 = IO.LoadTasks();
				if ((int)strArrays1.Length > 0)
				{
					for (int j = 0; j < (int)strArrays1.Length; j++)
					{
						this.comboBox_2.Items.Add(strArrays1[j]);
					}
				}
				this.comboBox_2.EndUpdate();
				this.replaceConfigInfo_0 = (ReplaceConfigInfo)ConfigFileManager.LoadConfig("ReplaceConfig.xml", this.replaceConfigInfo_0);
				this.page_0 = new Page(this.ruleConfigInfo_0, this.taskConfigInfo_0);
				this.method_0();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message, Localization.Get("程序错误"));
			}
			this.comboBox_1.Text = this.ruleConfigInfo_0.NovelListUrl.Pattern;
		}

		private void comboBox_2_SelectedIndexChanged(object sender, EventArgs e)
		{
			string text = this.comboBox_2.Text;
			FileInfo fileInfo = new FileInfo(text);
			this.taskConfigInfo_0 = (TaskConfigInfo)ConfigFileManager.LoadConfig(text, this.taskConfigInfo_0);
			this.comboBox_3.Text = this.taskConfigInfo_0.RuleFile;
			this.ruleConfigInfo_0 = (RuleConfigInfo)ConfigFileManager.LoadConfig(this.comboBox_3.Text, this.ruleConfigInfo_0);
			this.page_0 = new Page(this.ruleConfigInfo_0, this.taskConfigInfo_0);
			this.method_0();
		}

		private void comboBox_3_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.taskConfigInfo_0.RuleFile = this.comboBox_3.Text;
			this.ruleConfigInfo_0 = (RuleConfigInfo)ConfigFileManager.LoadConfig(this.taskConfigInfo_0.RuleFile, this.ruleConfigInfo_0);
			this.comboBox_1.Text = this.ruleConfigInfo_0.NovelListUrl.Pattern;
			this.page_0 = new Page(this.ruleConfigInfo_0, this.taskConfigInfo_0);
			this.listView_2.Items.Clear();
			this.listView_1.Items.Clear();
			this.listView_0.Items.Clear();
		}

		private void Db3InsertButton_Click(object sender, EventArgs e)
		{
			char[] chrArray;
			if (this.comboBox_4.Text.Length >= 5)
			{
				FileInfo fileInfo = new FileInfo(string.Concat("Log\\", this.comboBox_4.Text));
				if (fileInfo.Exists)
				{
					this.listView_2.Items.Clear();
					string str = string.Concat("Data Source=", fileInfo.FullName);
					string str1 = string.Concat("Select * From [TaskLog] Where RULEFILE='", this.comboBox_3.Text, "' And NovelName<>''");
					if ((this.ErrIdcomboBox.Text == "EXIT" ? false : this.ErrIdcomboBox.Text != ""))
					{
						if (this.ErrIdcomboBox.Text == "")
						{
							this.ErrIdcomboBox.Text = "EXID";
						}
						if (this.ErrIdcomboBox.Text != "EXID")
						{
							ComboBox errIdcomboBox = this.ErrIdcomboBox;
							string text = this.ErrIdcomboBox.Text;
							chrArray = new char[] { ' ' };
							errIdcomboBox.Text = text.Split(chrArray)[0];
						}
						str1 = string.Concat(str1, " And EXID= ", this.ErrIdcomboBox.Text);
					}
					DataSet dataSet = SQLiteHelper.ExecuteDataset(str, str1);
					if ((dataSet == null ? false : dataSet.Tables[0].Rows.Count >= 1))
					{
						string str2 = "";
						for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
						{
							NovelInfo novelInfo = new NovelInfo()
							{
								GetID = dataSet.Tables[0].Rows[i]["GETID"].ToString()
							};
							NovelInfo novelInfo1 = novelInfo;
							if ((str2.Contains(string.Concat(",", novelInfo1.GetID, ",")) ? false : novelInfo1.GetID != "0"))
							{
								str2 = string.Concat(str2, novelInfo1.GetID, ",");
							}
						}
						chrArray = new char[] { ',' };
						str2 = str2.Trim(chrArray);
						this.panel_0.Visible = false;
						if (!this.panel_0.Visible)
						{
							this.panel_0.Visible = true;
						}
						else
						{
							this.panel_0.Visible = false;
						}
						this.comboBox_0.Text = str2;
						if ((this.bool_0 ? false : !this.backgroundWorker_3.IsBusy))
						{
							this.toolStripStatusLabel_0.Text = Localization.Get("正在单本载入.请勿进行其他操作..");
							this.bool_0 = true;
							this.panel_2.Enabled = false;
							this.listView_1.Items.Clear();
							this.listView_0.Items.Clear();
							this.button_0.Enabled = false;
							if ((this.comboBox_0.Text == "" ? false : !this.backgroundWorker_3.IsBusy))
							{
								this.string_0 = "GetId";
								this.string_1 = this.comboBox_0.Text;
								this.listView_2.Items.Clear();
								this.backgroundWorker_3.RunWorkerAsync();
							}
						}
					}
				}
			}
		}

		private void DelSelectLog_Click(object sender, EventArgs e)
		{
			if ((this.listView_2.CheckedItems.Count < 1 || this.bool_0 ? true : this.backgroundWorker_11.IsBusy))
			{
				this.bool_0 = true;
			}
			this.panel_2.Enabled = false;
			this.toolStripStatusLabel_0.Text = Localization.Get("正在从日志中删除.请勿进行其他操作..");
			ArrayList arrayLists = new ArrayList();
			for (int i = 0; i < this.listView_2.Items.Count; i++)
			{
				if (this.listView_2.Items[i].Checked)
				{
					NovelInfo tag = (NovelInfo)this.listView_2.Items[i].Tag;
					object[] putID = new object[] { i, "^", tag.PutID, "^", tag.GetID, "^", tag.Name, "^", this.comboBox_4.Text };
					arrayLists.Add(string.Concat(putID));
				}
			}
			this.backgroundWorker_11.RunWorkerAsync((string[])arrayLists.ToArray(typeof(string)));
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(CollectManual));
			this.toolStrip_0 = new ToolStrip();
			this.toolStripButton_0 = new ToolStripButton();
			this.toolStripButton_1 = new ToolStripButton();
			this.toolStripButton_3 = new ToolStripButton();
			this.statusStrip_0 = new StatusStrip();
			this.toolStripStatusLabel_0 = new ToolStripStatusLabel();
			this.toolStripStatusLabel_1 = new ToolStripStatusLabel();
			this.splitContainer_0 = new SplitContainer();
			this.panel_0 = new Panel();
			this.button_1 = new Button();
			this.label_0 = new Label();
			this.button_0 = new Button();
			this.comboBox_0 = new ComboBox();
			this.radioButton_0 = new RadioButton();
			this.radioButton_1 = new RadioButton();
			this.radioButton_2 = new RadioButton();
			this.panel_1 = new Panel();
			this.label_1 = new Label();
			this.button_2 = new Button();
			this.button_3 = new Button();
			this.comboBox_1 = new ComboBox();
			this.radioButton_3 = new RadioButton();
			this.radioButton_4 = new RadioButton();
			this.splitContainer1 = new SplitContainer();
			this.listView_2 = new ListView();
			this.columnHeader_6 = new ColumnHeader();
			this.columnHeader_7 = new ColumnHeader();
			this.columnHeader_8 = new ColumnHeader();
			this.columnHeader_9 = new ColumnHeader();
			this.columnHeader_14 = new ColumnHeader();
			this.NovelMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.toolStripMenuItem_20 = new ToolStripMenuItem();
			this.toolStripSeparator_0 = new ToolStripSeparator();
			this.toolStripMenuItem_19 = new ToolStripMenuItem();
			this.toolStripMenuItem_1 = new ToolStripMenuItem();
			this.toolStripMenuItem_2 = new ToolStripMenuItem();
			this.toolStripSeparator_6 = new ToolStripSeparator();
			this.toolStripMenuItem_3 = new ToolStripMenuItem();
			this.toolStripMenuItem_21 = new ToolStripMenuItem();
			this.toolStripMenuItem_4 = new ToolStripMenuItem();
			this.toolStripMenuItem_18 = new ToolStripMenuItem();
			this.toolStripSeparator_1 = new ToolStripSeparator();
			this.设选中小说为全本ToolStripMenuItem = new ToolStripMenuItem();
			this.DelSelectLog = new ToolStripMenuItem();
			this.toolStripMenuItem_5 = new ToolStripMenuItem();
			this.listView1 = new ListView();
			this.columnHeader_12 = new ColumnHeader();
			this.columnHeader_13 = new ColumnHeader();
			this.LocalMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.删除分卷ToolStripMenuItem = new ToolStripMenuItem();
			this.toolStripSeparator1 = new ToolStripSeparator();
			this.全选章节ToolStripMenuItem = new ToolStripMenuItem();
			this.全不选章节ToolStripMenuItem = new ToolStripMenuItem();
			this.反选章节ToolStripMenuItem = new ToolStripMenuItem();
			this.选中后续章节ToolStripMenuItem = new ToolStripMenuItem();
			this.panel_2 = new Panel();
			this.Db3InsertButton = new Button();
			this.ErrIdcomboBox = new ComboBox();
			this.comboBox_4 = new ComboBox();
			this.comboBox_3 = new ComboBox();
			this.comboBox_2 = new ComboBox();
			this.splitContainer_1 = new SplitContainer();
			this.listView_0 = new ListView();
			this.columnHeader_10 = new ColumnHeader();
			this.columnHeader_0 = new ColumnHeader();
			this.columnHeader_1 = new ColumnHeader();
			this.columnHeader_4 = new ColumnHeader();
			this.TargetMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.toolStripMenuItem_6 = new ToolStripMenuItem();
			this.选中后续并采集ToolStripMenuItem = new ToolStripMenuItem();
			this.toolStripMenuItem_7 = new ToolStripMenuItem();
			this.toolStripSeparator_2 = new ToolStripSeparator();
			this.toolStripMenuItem_8 = new ToolStripMenuItem();
			this.toolStripMenuItem_22 = new ToolStripMenuItem();
			this.toolStripMenuItem_9 = new ToolStripMenuItem();
			this.toolStripMenuItem_10 = new ToolStripMenuItem();
			this.选中中间章节ToolStripMenuItem1 = new ToolStripMenuItem();
			this.toolStripSeparator_3 = new ToolStripSeparator();
			this.toolStripMenuItem_11 = new ToolStripMenuItem();
			this.toolStripMenuItem_23 = new ToolStripMenuItem();
			this.listView_1 = new ListView();
			this.columnHeader_11 = new ColumnHeader();
			this.columnHeader_2 = new ColumnHeader();
			this.columnHeader_3 = new ColumnHeader();
			this.columnHeader_15 = new ColumnHeader();
			this.columnHeader_5 = new ColumnHeader();
			this.LocalMenuStrip_1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.toolStripMenuItem_12 = new ToolStripMenuItem();
			this.toolStripSeparator_4 = new ToolStripSeparator();
			this.toolStripMenuItem_25 = new ToolStripMenuItem();
			this.修改选中章节ToolStripMenuItem = new ToolStripMenuItem();
			this.删除本章数据库ToolStripMenuItem = new ToolStripMenuItem();
			this.toolStripMenuItem_17 = new ToolStripMenuItem();
			this.检查重复章节ToolStripMenuItem = new ToolStripMenuItem();
			this.检测TXTToolStripMenuItem = new ToolStripMenuItem();
			this.toolStripMenuItem_13 = new ToolStripMenuItem();
			this.toolStripSeparator_5 = new ToolStripSeparator();
			this.toolStripMenuItem_14 = new ToolStripMenuItem();
			this.toolStripMenuItem_24 = new ToolStripMenuItem();
			this.toolStripMenuItem_15 = new ToolStripMenuItem();
			this.toolStripMenuItem_16 = new ToolStripMenuItem();
			this.选中中间章节ToolStripMenuItem = new ToolStripMenuItem();
			this.backgroundWorker_3 = new BackgroundWorker();
			this.backgroundWorker_4 = new BackgroundWorker();
			this.backgroundWorker_5 = new BackgroundWorker();
			this.backgroundWorker_6 = new BackgroundWorker();
			this.backgroundWorker_7 = new BackgroundWorker();
			this.backgroundWorker_8 = new BackgroundWorker();
			this.toolTip_0 = new ToolTip(this.components);
			this.backgroundWorker_0 = new BackgroundWorker();
			this.backgroundWorker_1 = new BackgroundWorker();
			this.backgroundWorker_2 = new BackgroundWorker();
			this.backgroundWorker_9 = new BackgroundWorker();
			this.backgroundWorker_10 = new BackgroundWorker();
			this.backgroundWorker_11 = new BackgroundWorker();
			this.backgroundWorker_12 = new BackgroundWorker();
			this.ReviseChapter = new Panel();
			this.button2 = new Button();
			this.sortBox = new ComboBox();
			this.posterBox = new TextBox();
			this.articlenameBox = new TextBox();
			this.chapterNameBox = new TextBox();
			this.button1 = new Button();
			this.label4 = new Label();
			this.label3 = new Label();
			this.label2 = new Label();
			this.label1 = new Label();
			this.groupBox1 = new GroupBox();
			this.chapterTXTBox = new TextBox();
			this.label5 = new Label();
			this.label6 = new Label();
			this.label7 = new Label();
			this.label8 = new Label();
			this.label9 = new Label();
			this.label10 = new Label();
			this.label11 = new Label();
			this.label12 = new Label();
			this.backgroundWorker1 = new BackgroundWorker();
			this.toolStrip_0.SuspendLayout();
			this.statusStrip_0.SuspendLayout();
			this.splitContainer_0.Panel1.SuspendLayout();
			this.splitContainer_0.Panel2.SuspendLayout();
			this.splitContainer_0.SuspendLayout();
			this.panel_0.SuspendLayout();
			this.panel_1.SuspendLayout();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.NovelMenuStrip.SuspendLayout();
			this.LocalMenuStrip.SuspendLayout();
			this.panel_2.SuspendLayout();
			this.splitContainer_1.Panel1.SuspendLayout();
			this.splitContainer_1.Panel2.SuspendLayout();
			this.splitContainer_1.SuspendLayout();
			this.TargetMenuStrip.SuspendLayout();
			this.LocalMenuStrip_1.SuspendLayout();
			this.ReviseChapter.SuspendLayout();
			this.groupBox1.SuspendLayout();
			base.SuspendLayout();
			this.toolStrip_0.ImageScalingSize = new System.Drawing.Size(32, 32);
			ToolStripItemCollection items = this.toolStrip_0.Items;
			ToolStripItem[] toolStripButton0 = new ToolStripItem[] { this.toolStripButton_0, this.toolStripButton_1, this.toolStripButton_3 };
			items.AddRange(toolStripButton0);
			this.toolStrip_0.Location = new Point(0, 0);
			this.toolStrip_0.Name = "toolStrip_0";
			this.toolStrip_0.RenderMode = ToolStripRenderMode.System;
			this.toolStrip_0.Size = new System.Drawing.Size(834, 39);
			this.toolStrip_0.TabIndex = 0;
			this.toolStrip_0.Text = Localization.Get("工具栏");
			this.toolStripButton_0.Font = new System.Drawing.Font(Localization.Get("宋体"), 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.toolStripButton_0.Image = (Image)componentResourceManager.GetObject("toolStripButton_0.Image");
			this.toolStripButton_0.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_0.Name = "toolStripButton_0";
			this.toolStripButton_0.Size = new System.Drawing.Size(99, 36);
			this.toolStripButton_0.Text = Localization.Get("单本载入");
			this.toolStripButton_0.Click += new EventHandler(this.toolStripButton_0_Click);
			this.toolStripButton_1.Font = new System.Drawing.Font(Localization.Get("宋体"), 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.toolStripButton_1.Image = (Image)componentResourceManager.GetObject("toolStripButton_1.Image");
			this.toolStripButton_1.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_1.Name = "toolStripButton_1";
			this.toolStripButton_1.Size = new System.Drawing.Size(99, 36);
			this.toolStripButton_1.Text = Localization.Get("批量载入");
			this.toolStripButton_1.Click += new EventHandler(this.toolStripButton_1_Click);
			this.toolStripButton_3.Font = new System.Drawing.Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.toolStripButton_3.Image = (Image)componentResourceManager.GetObject("toolStripButton_3.Image");
			this.toolStripButton_3.ImageTransparentColor = Color.Magenta;
			this.toolStripButton_3.Name = "toolStripButton_3";
			this.toolStripButton_3.Size = new System.Drawing.Size(99, 36);
			this.toolStripButton_3.Text = Localization.Get("中断采集");
			this.toolStripButton_3.Click += new EventHandler(this.toolStripButton_3_Click);
			ToolStripItemCollection toolStripItemCollections = this.statusStrip_0.Items;
			toolStripButton0 = new ToolStripItem[] { this.toolStripStatusLabel_0, this.toolStripStatusLabel_1 };
			toolStripItemCollections.AddRange(toolStripButton0);
			this.statusStrip_0.Location = new Point(0, 434);
			this.statusStrip_0.Name = "statusStrip_0";
			this.statusStrip_0.Size = new System.Drawing.Size(834, 22);
			this.statusStrip_0.TabIndex = 1;
			this.statusStrip_0.Text = "statusStrip1";
			this.toolStripStatusLabel_0.Name = "toolStripStatusLabel_0";
			this.toolStripStatusLabel_0.Size = new System.Drawing.Size(56, 17);
			this.toolStripStatusLabel_0.Text = Localization.Get("准备就绪");
			this.toolStripStatusLabel_1.Name = "toolStripStatusLabel_1";
			this.toolStripStatusLabel_1.Size = new System.Drawing.Size(763, 17);
			this.toolStripStatusLabel_1.Spring = true;
			this.toolStripStatusLabel_1.TextAlign = ContentAlignment.MiddleRight;
			this.splitContainer_0.Dock = DockStyle.Fill;
			this.splitContainer_0.Location = new Point(0, 39);
			this.splitContainer_0.Name = "splitContainer_0";
			this.splitContainer_0.Orientation = Orientation.Horizontal;
			this.splitContainer_0.Panel1.Controls.Add(this.panel_0);
			this.splitContainer_0.Panel1.Controls.Add(this.panel_1);
			this.splitContainer_0.Panel1.Controls.Add(this.splitContainer1);
			this.splitContainer_0.Panel1.Controls.Add(this.panel_2);
			this.splitContainer_0.Panel2.Controls.Add(this.splitContainer_1);
			this.splitContainer_0.Size = new System.Drawing.Size(834, 395);
			this.splitContainer_0.SplitterDistance = 205;
			this.splitContainer_0.TabIndex = 2;
			this.panel_0.Anchor = AnchorStyles.None;
			this.panel_0.BorderStyle = BorderStyle.FixedSingle;
			this.panel_0.Controls.Add(this.button_1);
			this.panel_0.Controls.Add(this.label_0);
			this.panel_0.Controls.Add(this.button_0);
			this.panel_0.Controls.Add(this.comboBox_0);
			this.panel_0.Controls.Add(this.radioButton_0);
			this.panel_0.Controls.Add(this.radioButton_1);
			this.panel_0.Controls.Add(this.radioButton_2);
			this.panel_0.Location = new Point(325, 51);
			this.panel_0.Name = "panel_0";
			this.panel_0.Size = new System.Drawing.Size(264, 100);
			this.panel_0.TabIndex = 1;
			this.panel_0.Visible = false;
			this.button_1.Location = new Point(87, 54);
			this.button_1.Name = "button_1";
			this.button_1.Size = new System.Drawing.Size(75, 23);
			this.button_1.TabIndex = 6;
			this.button_1.Text = Localization.Get("取消");
			this.button_1.UseVisualStyleBackColor = true;
			this.button_1.Click += new EventHandler(this.button_1_Click);
			this.label_0.AutoSize = true;
			this.label_0.Location = new Point(4, 80);
			this.label_0.Name = "label_0";
			this.label_0.Size = new System.Drawing.Size(257, 12);
			this.label_0.TabIndex = 5;
			this.label_0.Text = Localization.Get("按小说名称和按本站ID，都需要目标站搜索支持");
			this.button_0.Location = new Point(6, 54);
			this.button_0.Name = "button_0";
			this.button_0.Size = new System.Drawing.Size(75, 23);
			this.button_0.TabIndex = 4;
			this.button_0.Text = Localization.Get("载入");
			this.button_0.UseVisualStyleBackColor = true;
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.comboBox_0.FormattingEnabled = true;
			this.comboBox_0.Location = new Point(6, 28);
			this.comboBox_0.Name = "comboBox_0";
			this.comboBox_0.Size = new System.Drawing.Size(249, 20);
			this.comboBox_0.TabIndex = 3;
			this.radioButton_0.AutoSize = true;
			this.radioButton_0.Location = new Point(184, 6);
			this.radioButton_0.Name = "radioButton_0";
			this.radioButton_0.Size = new System.Drawing.Size(71, 16);
			this.radioButton_0.TabIndex = 2;
			this.radioButton_0.Text = Localization.Get("按本站ID");
			this.radioButton_0.UseVisualStyleBackColor = true;
			this.radioButton_1.AutoSize = true;
			this.radioButton_1.Location = new Point(95, 6);
			this.radioButton_1.Name = "radioButton_1";
			this.radioButton_1.Size = new System.Drawing.Size(83, 16);
			this.radioButton_1.TabIndex = 1;
			this.radioButton_1.Text = Localization.Get("按小说名称");
			this.radioButton_1.UseVisualStyleBackColor = true;
			this.radioButton_2.AutoSize = true;
			this.radioButton_2.Checked = true;
			this.radioButton_2.Location = new Point(6, 6);
			this.radioButton_2.Name = "radioButton_2";
			this.radioButton_2.Size = new System.Drawing.Size(83, 16);
			this.radioButton_2.TabIndex = 0;
			this.radioButton_2.TabStop = true;
			this.radioButton_2.Text = Localization.Get("按目标站ID");
			this.radioButton_2.UseVisualStyleBackColor = true;
			this.panel_1.Anchor = AnchorStyles.None;
			this.panel_1.BorderStyle = BorderStyle.FixedSingle;
			this.panel_1.Controls.Add(this.label_1);
			this.panel_1.Controls.Add(this.button_2);
			this.panel_1.Controls.Add(this.button_3);
			this.panel_1.Controls.Add(this.comboBox_1);
			this.panel_1.Controls.Add(this.radioButton_3);
			this.panel_1.Controls.Add(this.radioButton_4);
			this.panel_1.Location = new Point(257, 56);
			this.panel_1.Name = "panel_1";
			this.panel_1.Size = new System.Drawing.Size(400, 86);
			this.panel_1.TabIndex = 2;
			this.panel_1.Visible = false;
			this.label_1.AutoSize = true;
			this.label_1.Location = new Point(171, 59);
			this.label_1.Name = "label_1";
			this.label_1.Size = new System.Drawing.Size(221, 12);
			this.label_1.TabIndex = 5;
			this.label_1.Text = Localization.Get("不熟悉SQL的朋友，请勿更改默认SQL语句");
			this.button_2.Location = new Point(87, 54);
			this.button_2.Name = "button_2";
			this.button_2.Size = new System.Drawing.Size(75, 23);
			this.button_2.TabIndex = 4;
			this.button_2.Text = Localization.Get("取消");
			this.button_2.UseVisualStyleBackColor = true;
			this.button_2.Click += new EventHandler(this.button_2_Click);
			this.button_3.Location = new Point(6, 54);
			this.button_3.Name = "button_3";
			this.button_3.Size = new System.Drawing.Size(75, 23);
			this.button_3.TabIndex = 3;
			this.button_3.Text = "载入";
			this.button_3.UseVisualStyleBackColor = true;
			this.button_3.Click += new EventHandler(this.button_3_Click);
			this.comboBox_1.FormattingEnabled = true;
			this.comboBox_1.Location = new Point(6, 28);
			this.comboBox_1.Name = "comboBox_1";
			this.comboBox_1.Size = new System.Drawing.Size(386, 20);
			this.comboBox_1.TabIndex = 2;
			this.radioButton_3.AutoSize = true;
			this.radioButton_3.Location = new Point(155, 6);
			this.radioButton_3.Name = "radioButton_3";
			this.radioButton_3.Size = new System.Drawing.Size(137, 16);
			this.radioButton_3.TabIndex = 1;
			this.radioButton_3.Text = Localization.Get("通过本站SQL结果载入");
			this.radioButton_3.UseVisualStyleBackColor = true;
			this.radioButton_3.CheckedChanged += new EventHandler(this.radioButton_3_CheckedChanged);
			this.radioButton_4.AutoSize = true;
			this.radioButton_4.Checked = true;
			this.radioButton_4.Location = new Point(6, 6);
			this.radioButton_4.Name = "radioButton_4";
			this.radioButton_4.Size = new System.Drawing.Size(143, 16);
			this.radioButton_4.TabIndex = 0;
			this.radioButton_4.TabStop = true;
			this.radioButton_4.Text = Localization.Get("从目标站列表进行载入");
			this.radioButton_4.UseVisualStyleBackColor = true;
			this.radioButton_4.CheckedChanged += new EventHandler(this.radioButton_4_CheckedChanged);
			this.splitContainer1.Dock = DockStyle.Fill;
			this.splitContainer1.Location = new Point(0, 26);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Panel1.Controls.Add(this.listView_2);
			this.splitContainer1.Panel2.Controls.Add(this.listView1);
			this.splitContainer1.Size = new System.Drawing.Size(834, 179);
			this.splitContainer1.SplitterDistance = 576;
			this.splitContainer1.TabIndex = 5;
			this.listView_2.CheckBoxes = true;
			ListView.ColumnHeaderCollection columns = this.listView_2.Columns;
			ColumnHeader[] columnHeader6 = new ColumnHeader[] { this.columnHeader_6, this.columnHeader_7, this.columnHeader_8, this.columnHeader_9, this.columnHeader_14 };
			columns.AddRange(columnHeader6);
			this.listView_2.ContextMenuStrip = this.NovelMenuStrip;
			this.listView_2.Dock = DockStyle.Fill;
			this.listView_2.FullRowSelect = true;
			this.listView_2.GridLines = true;
			this.listView_2.Location = new Point(0, 0);
			this.listView_2.Name = "listView_2";
			this.listView_2.Size = new System.Drawing.Size(576, 179);
			this.listView_2.TabIndex = 4;
			this.listView_2.UseCompatibleStateImageBehavior = false;
			this.listView_2.View = View.Details;
			this.listView_2.SelectedIndexChanged += new EventHandler(this.listView_1_SelectedIndexChanged);
			this.listView_2.DoubleClick += new EventHandler(this.listView_2_DoubleClick);
			this.columnHeader_6.Text = Localization.Get("目标站ID");
			this.columnHeader_6.Width = 61;
			this.columnHeader_7.Text = Localization.Get("小说名称");
			this.columnHeader_7.Width = 190;
			this.columnHeader_8.Text = Localization.Get("本站ID");
			this.columnHeader_8.Width = 49;
			this.columnHeader_9.Text = Localization.Get("本站最新章节情况(空表示新书)");
			this.columnHeader_9.Width = 204;
			this.columnHeader_14.Text = Localization.Get("更新时间");
			this.columnHeader_14.TextAlign = HorizontalAlignment.Center;
			this.columnHeader_14.Width = 80;
			ToolStripItemCollection items1 = this.NovelMenuStrip.Items;
			toolStripButton0 = new ToolStripItem[] { this.toolStripMenuItem_20, this.toolStripSeparator_0, this.toolStripMenuItem_19, this.toolStripMenuItem_1, this.toolStripMenuItem_2, this.toolStripSeparator_6, this.toolStripMenuItem_3, this.toolStripMenuItem_21, this.toolStripMenuItem_4, this.toolStripMenuItem_18, this.toolStripSeparator_1, this.设选中小说为全本ToolStripMenuItem, this.DelSelectLog, this.toolStripMenuItem_5 };
			items1.AddRange(toolStripButton0);
			this.NovelMenuStrip.Name = "NovelMenuStrip";
			this.NovelMenuStrip.Size = new System.Drawing.Size(157, 264);
			this.NovelMenuStrip.Opening += new CancelEventHandler(this.NovelMenuStrip_Opening);
			this.toolStripMenuItem_20.Name = "toolStripMenuItem_20";
			this.toolStripMenuItem_20.Size = new System.Drawing.Size(156, 22);
			this.toolStripMenuItem_20.Text = Localization.Get("列出章节");
			this.toolStripMenuItem_20.Click += new EventHandler(this.toolStripMenuItem_20_Click);
			this.toolStripSeparator_0.Name = "toolStripSeparator_0";
			this.toolStripSeparator_0.Size = new System.Drawing.Size(153, 6);
			this.toolStripMenuItem_19.Name = "toolStripMenuItem_19";
			this.toolStripMenuItem_19.Size = new System.Drawing.Size(156, 22);
			this.toolStripMenuItem_19.Text = Localization.Get("加载小说信息");
			this.toolStripMenuItem_19.Click += new EventHandler(this.toolStripMenuItem_19_Click);
			this.toolStripMenuItem_1.Name = "toolStripMenuItem_1";
			this.toolStripMenuItem_1.Size = new System.Drawing.Size(156, 22);
			this.toolStripMenuItem_1.Text = Localization.Get("添加小说");
			this.toolStripMenuItem_1.Click += new EventHandler(this.toolStripMenuItem_1_Click);
			this.toolStripMenuItem_2.Name = "toolStripMenuItem_2";
			this.toolStripMenuItem_2.Size = new System.Drawing.Size(156, 22);
			this.toolStripMenuItem_2.Text = Localization.Get("删除小说(真实)");
			this.toolStripMenuItem_2.Click += new EventHandler(this.toolStripMenuItem_2_Click);
			this.toolStripSeparator_6.Name = "toolStripSeparator_6";
			this.toolStripSeparator_6.Size = new System.Drawing.Size(153, 6);
			this.toolStripMenuItem_3.Name = "toolStripMenuItem_3";
			this.toolStripMenuItem_3.Size = new System.Drawing.Size(156, 22);
			this.toolStripMenuItem_3.Text = Localization.Get("全选小说");
			this.toolStripMenuItem_3.Click += new EventHandler(this.toolStripMenuItem_3_Click);
			this.toolStripMenuItem_21.Name = "toolStripMenuItem_21";
			this.toolStripMenuItem_21.Size = new System.Drawing.Size(156, 22);
			this.toolStripMenuItem_21.Text = "全不选小说";
			this.toolStripMenuItem_21.Click += new EventHandler(this.toolStripMenuItem_21_Click);
			this.toolStripMenuItem_4.Name = "toolStripMenuItem_4";
			this.toolStripMenuItem_4.Size = new System.Drawing.Size(156, 22);
			this.toolStripMenuItem_4.Text = Localization.Get("反选小说");
			this.toolStripMenuItem_4.Click += new EventHandler(this.toolStripMenuItem_4_Click);
			this.toolStripMenuItem_18.Name = "toolStripMenuItem_18";
			this.toolStripMenuItem_18.Size = new System.Drawing.Size(156, 22);
			this.toolStripMenuItem_18.Text = Localization.Get("选中后续小说");
			this.toolStripMenuItem_18.Click += new EventHandler(this.toolStripMenuItem_18_Click);
			this.toolStripSeparator_1.Name = "toolStripSeparator_1";
			this.toolStripSeparator_1.Size = new System.Drawing.Size(153, 6);
			this.设选中小说为全本ToolStripMenuItem.Name = "设选中小说为全本ToolStripMenuItem";
			this.设选中小说为全本ToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
			this.设选中小说为全本ToolStripMenuItem.Text = Localization.Get("更新连载状态");
			this.设选中小说为全本ToolStripMenuItem.Click += new EventHandler(this.设选中小说为全本ToolStripMenuItem_Click);
			this.DelSelectLog.Name = "DelSelectLog";
			this.DelSelectLog.Size = new System.Drawing.Size(156, 22);
			this.DelSelectLog.Text = Localization.Get("删除选中日志");
			this.DelSelectLog.Click += new EventHandler(this.DelSelectLog_Click);
			this.toolStripMenuItem_5.Name = "toolStripMenuItem_5";
			this.toolStripMenuItem_5.Size = new System.Drawing.Size(156, 22);
			this.toolStripMenuItem_5.Text = Localization.Get("清空列表");
			this.toolStripMenuItem_5.Click += new EventHandler(this.toolStripMenuItem_5_Click);
			this.listView1.CheckBoxes = true;
			ListView.ColumnHeaderCollection columnHeaderCollections = this.listView1.Columns;
			columnHeader6 = new ColumnHeader[] { this.columnHeader_12, this.columnHeader_13 };
			columnHeaderCollections.AddRange(columnHeader6);
			this.listView1.ContextMenuStrip = this.LocalMenuStrip;
			this.listView1.Dock = DockStyle.Fill;
			this.listView1.FullRowSelect = true;
			this.listView1.GridLines = true;
			this.listView1.Location = new Point(0, 0);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(254, 179);
			this.listView1.TabIndex = 3;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = View.Details;
			this.columnHeader_12.Text = Localization.Get("索引");
			this.columnHeader_12.Width = 50;
			this.columnHeader_13.Text = Localization.Get("分卷名");
			this.columnHeader_13.Width = 140;
			ToolStripItemCollection toolStripItemCollections1 = this.LocalMenuStrip.Items;
			toolStripButton0 = new ToolStripItem[] { this.删除分卷ToolStripMenuItem, this.toolStripSeparator1, this.全选章节ToolStripMenuItem, this.全不选章节ToolStripMenuItem, this.反选章节ToolStripMenuItem, this.选中后续章节ToolStripMenuItem };
			toolStripItemCollections1.AddRange(toolStripButton0);
			this.LocalMenuStrip.Name = "LocalMenuStrip";
			this.LocalMenuStrip.Size = new System.Drawing.Size(149, 120);
			this.删除分卷ToolStripMenuItem.Name = "删除分卷ToolStripMenuItem";
			this.删除分卷ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
			this.删除分卷ToolStripMenuItem.Text = Localization.Get("删除分卷");
			this.删除分卷ToolStripMenuItem.Click += new EventHandler(this.删除分卷ToolStripMenuItem_Click);
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(145, 6);
			this.全选章节ToolStripMenuItem.Name = "全选章节ToolStripMenuItem";
			this.全选章节ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
			this.全选章节ToolStripMenuItem.Text = Localization.Get("全选分卷");
			this.全选章节ToolStripMenuItem.Click += new EventHandler(this.全选章节ToolStripMenuItem_Click);
			this.全不选章节ToolStripMenuItem.Name = "全不选章节ToolStripMenuItem";
			this.全不选章节ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
			this.全不选章节ToolStripMenuItem.Text = Localization.Get("全不选分卷");
			this.全不选章节ToolStripMenuItem.Click += new EventHandler(this.全不选章节ToolStripMenuItem_Click);
			this.反选章节ToolStripMenuItem.Name = "反选章节ToolStripMenuItem";
			this.反选章节ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
			this.反选章节ToolStripMenuItem.Text = Localization.Get("反选分卷");
			this.反选章节ToolStripMenuItem.Click += new EventHandler(this.反选章节ToolStripMenuItem_Click);
			this.选中后续章节ToolStripMenuItem.Name = "选中后续章节ToolStripMenuItem";
			this.选中后续章节ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
			this.选中后续章节ToolStripMenuItem.Text = Localization.Get("选中后续分卷");
			this.选中后续章节ToolStripMenuItem.Click += new EventHandler(this.选中后续章节ToolStripMenuItem_Click);
			this.panel_2.Controls.Add(this.Db3InsertButton);
			this.panel_2.Controls.Add(this.ErrIdcomboBox);
			this.panel_2.Controls.Add(this.comboBox_4);
			this.panel_2.Controls.Add(this.comboBox_3);
			this.panel_2.Controls.Add(this.comboBox_2);
			this.panel_2.Dock = DockStyle.Top;
			this.panel_2.Location = new Point(0, 0);
			this.panel_2.Name = "panel_2";
			this.panel_2.Size = new System.Drawing.Size(834, 26);
			this.panel_2.TabIndex = 3;
			this.Db3InsertButton.Location = new Point(629, 1);
			this.Db3InsertButton.Name = "Db3InsertButton";
			this.Db3InsertButton.Size = new System.Drawing.Size(61, 23);
			this.Db3InsertButton.TabIndex = 14;
			this.Db3InsertButton.Text = Localization.Get("导入");
			this.Db3InsertButton.UseVisualStyleBackColor = true;
			this.Db3InsertButton.Click += new EventHandler(this.Db3InsertButton_Click);
			this.ErrIdcomboBox.FormattingEnabled = true;
			ComboBox.ObjectCollection objectCollections = this.ErrIdcomboBox.Items;
			object[] objArray = new object[] { "EXID", Localization.Get("0 未知错误"), "", Localization.Get("101 子窗口冲突"), Localization.Get("102 检查子窗口冲突失败"), "", Localization.Get("120 对比最新章节失败"), Localization.Get("121 空章节"), Localization.Get("122 检查到重复章节"), Localization.Get("124 只采集文字章节时发现图片章节"), Localization.Get("125 设置不添加新书"), "", Localization.Get("130 限制章节字数小于多少字的章节不采集"), Localization.Get("131 章节数量小于限制"), Localization.Get("132 对比最新章节成功！但需要采集到章节数超限。"), Localization.Get("134 限制小说_黑名单"), Localization.Get("135 限制小说_不在白名单"), Localization.Get("136 过滤分卷名"), Localization.Get("137 章节名过滤（章节名过滤作者名、自定义过滤）"), "", Localization.Get("200 小说信息页发生问题"), Localization.Get("210 小说目录页发生问题"), Localization.Get("214 章节组为空"), Localization.Get("220 小说内容页发生问题"), "", Localization.Get("410 操作本站小说列表发生问题"), Localization.Get("420 操作本站小说信息发生问题"), Localization.Get("430 操作本站章节列表发生问题"), Localization.Get("440 操作本站章节信息发生问题"), Localization.Get("441 InsertChapter发生问题"), Localization.Get("442 UpdateChapter发生问题") };
			objectCollections.AddRange(objArray);
			this.ErrIdcomboBox.Location = new Point(443, 3);
			this.ErrIdcomboBox.Name = "ErrIdcomboBox";
			this.ErrIdcomboBox.Size = new System.Drawing.Size(180, 20);
			this.ErrIdcomboBox.TabIndex = 12;
			this.ErrIdcomboBox.Text = "EXID";
			this.comboBox_4.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_4.FormattingEnabled = true;
			this.comboBox_4.Location = new Point(338, 3);
			this.comboBox_4.Name = "Db3comboBox";
			this.comboBox_4.Size = new System.Drawing.Size(99, 20);
			this.comboBox_4.TabIndex = 11;
			this.comboBox_3.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_3.FormattingEnabled = true;
			this.comboBox_3.Location = new Point(169, 3);
			this.comboBox_3.Name = "comboBox_3";
			this.comboBox_3.Size = new System.Drawing.Size(163, 20);
			this.comboBox_3.TabIndex = 10;
			this.comboBox_3.SelectedIndexChanged += new EventHandler(this.comboBox_3_SelectedIndexChanged);
			this.comboBox_2.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_2.FormattingEnabled = true;
			this.comboBox_2.Location = new Point(12, 3);
			this.comboBox_2.Name = "comboBox_2";
			this.comboBox_2.Size = new System.Drawing.Size(151, 20);
			this.comboBox_2.TabIndex = 1;
			this.comboBox_2.SelectedIndexChanged += new EventHandler(this.comboBox_2_SelectedIndexChanged);
			this.splitContainer_1.Dock = DockStyle.Fill;
			this.splitContainer_1.Location = new Point(0, 0);
			this.splitContainer_1.Name = "splitContainer_1";
			this.splitContainer_1.Panel1.Controls.Add(this.listView_0);
			this.splitContainer_1.Panel2.Controls.Add(this.listView_1);
			this.splitContainer_1.Size = new System.Drawing.Size(834, 186);
			this.splitContainer_1.SplitterDistance = 380;
			this.splitContainer_1.TabIndex = 0;
			this.listView_0.CheckBoxes = true;
			ListView.ColumnHeaderCollection columns1 = this.listView_0.Columns;
			columnHeader6 = new ColumnHeader[] { this.columnHeader_10, this.columnHeader_0, this.columnHeader_1, this.columnHeader_4 };
			columns1.AddRange(columnHeader6);
			this.listView_0.ContextMenuStrip = this.TargetMenuStrip;
			this.listView_0.Dock = DockStyle.Fill;
			this.listView_0.FullRowSelect = true;
			this.listView_0.GridLines = true;
			this.listView_0.Location = new Point(0, 0);
			this.listView_0.Name = "listView_0";
			this.listView_0.Size = new System.Drawing.Size(380, 186);
			this.listView_0.TabIndex = 1;
			this.listView_0.UseCompatibleStateImageBehavior = false;
			this.listView_0.View = View.Details;
			this.listView_0.SelectedIndexChanged += new EventHandler(this.listView_1_SelectedIndexChanged);
			this.listView_0.DoubleClick += new EventHandler(this.listView_0_DoubleClick);
			this.columnHeader_10.Text = Localization.Get("索引");
			this.columnHeader_10.Width = 56;
			this.columnHeader_0.Text = Localization.Get("分卷名");
			this.columnHeader_0.Width = 66;
			this.columnHeader_1.Text = Localization.Get("章节名(目标站)");
			this.columnHeader_1.Width = 230;
			this.columnHeader_4.Text = Localization.Get("内容");
			this.columnHeader_4.Width = 40;
			ToolStripItemCollection items2 = this.TargetMenuStrip.Items;
			toolStripButton0 = new ToolStripItem[] { this.toolStripMenuItem_6, this.选中后续并采集ToolStripMenuItem, this.toolStripMenuItem_7, this.toolStripSeparator_2, this.toolStripMenuItem_8, this.toolStripMenuItem_22, this.toolStripMenuItem_9, this.toolStripMenuItem_10, this.选中中间章节ToolStripMenuItem1, this.toolStripSeparator_3, this.toolStripMenuItem_11, this.toolStripMenuItem_23 };
			items2.AddRange(toolStripButton0);
			this.TargetMenuStrip.Name = "TargetMenuStrip";
			this.TargetMenuStrip.Size = new System.Drawing.Size(161, 236);
			this.TargetMenuStrip.Opening += new CancelEventHandler(this.TargetMenuStrip_Opening);
			this.toolStripMenuItem_6.Name = "toolStripMenuItem_6";
			this.toolStripMenuItem_6.Size = new System.Drawing.Size(160, 22);
			this.toolStripMenuItem_6.Text = Localization.Get("采集章节");
			this.toolStripMenuItem_6.Click += new EventHandler(this.toolStripMenuItem_6_Click);
			this.选中后续并采集ToolStripMenuItem.Name = "选中后续并采集ToolStripMenuItem";
			this.选中后续并采集ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.选中后续并采集ToolStripMenuItem.Text = Localization.Get("选中后续并采集");
			this.选中后续并采集ToolStripMenuItem.Click += new EventHandler(this.选中后续并采集ToolStripMenuItem_Click);
			this.toolStripMenuItem_7.Name = "toolStripMenuItem_7";
			this.toolStripMenuItem_7.Size = new System.Drawing.Size(160, 22);
			this.toolStripMenuItem_7.Text = Localization.Get("预采集章节内容");
			this.toolStripMenuItem_7.Visible = false;
			this.toolStripSeparator_2.Name = "toolStripSeparator_2";
			this.toolStripSeparator_2.Size = new System.Drawing.Size(157, 6);
			this.toolStripMenuItem_8.Name = "toolStripMenuItem_8";
			this.toolStripMenuItem_8.Size = new System.Drawing.Size(160, 22);
			this.toolStripMenuItem_8.Text = Localization.Get("全选章节");
			this.toolStripMenuItem_8.Click += new EventHandler(this.toolStripMenuItem_8_Click);
			this.toolStripMenuItem_22.Name = "toolStripMenuItem_22";
			this.toolStripMenuItem_22.Size = new System.Drawing.Size(160, 22);
			this.toolStripMenuItem_22.Text = Localization.Get("全不选章节");
			this.toolStripMenuItem_22.Click += new EventHandler(this.toolStripMenuItem_22_Click);
			this.toolStripMenuItem_9.Name = "toolStripMenuItem_9";
			this.toolStripMenuItem_9.Size = new System.Drawing.Size(160, 22);
			this.toolStripMenuItem_9.Text = Localization.Get("反选章节");
			this.toolStripMenuItem_9.Click += new EventHandler(this.toolStripMenuItem_9_Click);
			this.toolStripMenuItem_10.Name = "toolStripMenuItem_10";
			this.toolStripMenuItem_10.Size = new System.Drawing.Size(160, 22);
			this.toolStripMenuItem_10.Text = Localization.Get("选中后续章节");
			this.toolStripMenuItem_10.Click += new EventHandler(this.toolStripMenuItem_10_Click);
			this.选中中间章节ToolStripMenuItem1.Name = "选中中间章节ToolStripMenuItem1";
			this.选中中间章节ToolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
			this.选中中间章节ToolStripMenuItem1.Text = Localization.Get("选中中间章节");
			this.选中中间章节ToolStripMenuItem1.Click += new EventHandler(this.选中中间章节ToolStripMenuItem1_Click);
			this.toolStripSeparator_3.Name = "toolStripSeparator_3";
			this.toolStripSeparator_3.Size = new System.Drawing.Size(157, 6);
			this.toolStripMenuItem_11.Name = "toolStripMenuItem_11";
			this.toolStripMenuItem_11.Size = new System.Drawing.Size(160, 22);
			this.toolStripMenuItem_11.Text = Localization.Get("清空列表");
			this.toolStripMenuItem_11.Click += new EventHandler(this.toolStripMenuItem_11_Click);
			this.toolStripMenuItem_23.Name = "toolStripMenuItem_23";
			this.toolStripMenuItem_23.Size = new System.Drawing.Size(160, 22);
			this.toolStripMenuItem_23.Text = Localization.Get("复制章节名");
			this.toolStripMenuItem_23.Click += new EventHandler(this.toolStripMenuItem_23_Click);
			this.listView_1.CheckBoxes = true;
			ListView.ColumnHeaderCollection columnHeaderCollections1 = this.listView_1.Columns;
			columnHeader6 = new ColumnHeader[] { this.columnHeader_11, this.columnHeader_2, this.columnHeader_3, this.columnHeader_15, this.columnHeader_5 };
			columnHeaderCollections1.AddRange(columnHeader6);
			this.listView_1.ContextMenuStrip = this.LocalMenuStrip_1;
			this.listView_1.Dock = DockStyle.Fill;
			this.listView_1.FullRowSelect = true;
			this.listView_1.GridLines = true;
			this.listView_1.Location = new Point(0, 0);
			this.listView_1.Name = "listView_1";
			this.listView_1.Size = new System.Drawing.Size(450, 186);
			this.listView_1.TabIndex = 2;
			this.listView_1.UseCompatibleStateImageBehavior = false;
			this.listView_1.View = View.Details;
			this.listView_1.SelectedIndexChanged += new EventHandler(this.listView_1_SelectedIndexChanged);
			this.columnHeader_11.Text = Localization.Get("索引");
			this.columnHeader_11.Width = 56;
			this.columnHeader_2.Text = Localization.Get("分卷名");
			this.columnHeader_2.Width = 66;
			this.columnHeader_3.Text = Localization.Get("章节名(自己站)");
			this.columnHeader_3.Width = 219;
			this.columnHeader_15.Text = Localization.Get("更新时间");
			this.columnHeader_15.Width = 80;
			this.columnHeader_5.Text = Localization.Get("内容");
			this.columnHeader_5.Width = 40;
			ToolStripItemCollection toolStripItemCollections2 = this.LocalMenuStrip_1.Items;
			toolStripButton0 = new ToolStripItem[] { this.toolStripMenuItem_12, this.toolStripSeparator_4, this.toolStripMenuItem_25, this.修改选中章节ToolStripMenuItem, this.删除本章数据库ToolStripMenuItem, this.toolStripMenuItem_17, this.检查重复章节ToolStripMenuItem, this.检测TXTToolStripMenuItem, this.toolStripMenuItem_13, this.toolStripSeparator_5, this.toolStripMenuItem_14, this.toolStripMenuItem_24, this.toolStripMenuItem_15, this.toolStripMenuItem_16, this.选中中间章节ToolStripMenuItem };
			toolStripItemCollections2.AddRange(toolStripButton0);
			this.LocalMenuStrip_1.Name = "LocalMenuStrip";
			this.LocalMenuStrip_1.Size = new System.Drawing.Size(169, 302);
			this.LocalMenuStrip_1.Opening += new CancelEventHandler(this.LocalMenuStrip_1_Opening);
			this.toolStripMenuItem_12.Name = "toolStripMenuItem_12";
			this.toolStripMenuItem_12.Size = new System.Drawing.Size(168, 22);
			this.toolStripMenuItem_12.Text = Localization.Get("替换采集");
			this.toolStripMenuItem_12.Click += new EventHandler(this.toolStripMenuItem_12_Click);
			this.toolStripSeparator_4.Name = "toolStripSeparator_4";
			this.toolStripSeparator_4.Size = new System.Drawing.Size(165, 6);
			this.toolStripMenuItem_25.Name = "toolStripMenuItem_25";
			this.toolStripMenuItem_25.Size = new System.Drawing.Size(168, 22);
			this.toolStripMenuItem_25.Text = Localization.Get("在选中前插入");
			this.toolStripMenuItem_25.Click += new EventHandler(this.toolStripMenuItem_25_Click);
			this.修改选中章节ToolStripMenuItem.Name = "修改选中章节ToolStripMenuItem";
			this.修改选中章节ToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
			this.修改选中章节ToolStripMenuItem.Text = Localization.Get("修改选中章节");
			this.修改选中章节ToolStripMenuItem.Click += new EventHandler(this.修改选中章节ToolStripMenuItem_Click);
			this.删除本章数据库ToolStripMenuItem.Name = "删除本章数据库ToolStripMenuItem";
			this.删除本章数据库ToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
			this.删除本章数据库ToolStripMenuItem.Text = Localization.Get("删除本章(数据库)");
			this.删除本章数据库ToolStripMenuItem.Click += new EventHandler(this.删除本章数据库ToolStripMenuItem_Click);
			this.toolStripMenuItem_17.Name = "toolStripMenuItem_17";
			this.toolStripMenuItem_17.Size = new System.Drawing.Size(168, 22);
			this.toolStripMenuItem_17.Text = Localization.Get("删除本章(真实)");
			this.toolStripMenuItem_17.Click += new EventHandler(this.toolStripMenuItem_17_Click);
			this.检查重复章节ToolStripMenuItem.Name = "检查重复章节ToolStripMenuItem";
			this.检查重复章节ToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
			this.检查重复章节ToolStripMenuItem.Text = Localization.Get("检查重复章节");
			this.检查重复章节ToolStripMenuItem.Click += new EventHandler(this.检查重复章节ToolStripMenuItem_Click);
			this.检测TXTToolStripMenuItem.Name = "检测TXTToolStripMenuItem";
			this.检测TXTToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
			this.检测TXTToolStripMenuItem.Text = Localization.Get("检测TXT文本");
			this.检测TXTToolStripMenuItem.Click += new EventHandler(this.检测TXTToolStripMenuItem_Click);
			this.toolStripMenuItem_13.Name = "toolStripMenuItem_13";
			this.toolStripMenuItem_13.Size = new System.Drawing.Size(168, 22);
			this.toolStripMenuItem_13.Text = Localization.Get("检查章节内容");
			this.toolStripMenuItem_13.Click += new EventHandler(this.toolStripMenuItem_13_Click);
			this.toolStripSeparator_5.Name = "toolStripSeparator_5";
			this.toolStripSeparator_5.Size = new System.Drawing.Size(165, 6);
			this.toolStripMenuItem_14.Name = "toolStripMenuItem_14";
			this.toolStripMenuItem_14.Size = new System.Drawing.Size(168, 22);
			this.toolStripMenuItem_14.Text = Localization.Get("全选章节");
			this.toolStripMenuItem_14.Click += new EventHandler(this.toolStripMenuItem_14_Click);
			this.toolStripMenuItem_24.Name = "toolStripMenuItem_24";
			this.toolStripMenuItem_24.Size = new System.Drawing.Size(168, 22);
			this.toolStripMenuItem_24.Text = Localization.Get("全不选章节");
			this.toolStripMenuItem_24.Click += new EventHandler(this.toolStripMenuItem_24_Click);
			this.toolStripMenuItem_15.Name = "toolStripMenuItem_15";
			this.toolStripMenuItem_15.Size = new System.Drawing.Size(168, 22);
			this.toolStripMenuItem_15.Text = Localization.Get("反选章节");
			this.toolStripMenuItem_15.Click += new EventHandler(this.toolStripMenuItem_15_Click);
			this.toolStripMenuItem_16.Name = "toolStripMenuItem_16";
			this.toolStripMenuItem_16.Size = new System.Drawing.Size(168, 22);
			this.toolStripMenuItem_16.Text = Localization.Get("选中后续章节");
			this.toolStripMenuItem_16.Click += new EventHandler(this.toolStripMenuItem_16_Click);
			this.选中中间章节ToolStripMenuItem.Name = "选中中间章节ToolStripMenuItem";
			this.选中中间章节ToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
			this.选中中间章节ToolStripMenuItem.Text = Localization.Get("选中中间章节");
			this.选中中间章节ToolStripMenuItem.Click += new EventHandler(this.选中中间章节ToolStripMenuItem_Click);
			this.backgroundWorker_3.WorkerReportsProgress = true;
			this.backgroundWorker_3.WorkerSupportsCancellation = true;
			this.backgroundWorker_3.DoWork += new DoWorkEventHandler(this.backgroundWorker_3_DoWork);
			this.backgroundWorker_3.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker_12_RunWorkerCompleted);
			this.backgroundWorker_3.ProgressChanged += new ProgressChangedEventHandler(this.backgroundWorker_12_ProgressChanged);
			this.backgroundWorker_4.WorkerReportsProgress = true;
			this.backgroundWorker_4.WorkerSupportsCancellation = true;
			this.backgroundWorker_5.WorkerReportsProgress = true;
			this.backgroundWorker_5.WorkerSupportsCancellation = true;
			this.backgroundWorker_5.DoWork += new DoWorkEventHandler(this.backgroundWorker_5_DoWork);
			this.backgroundWorker_5.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker_12_RunWorkerCompleted);
			this.backgroundWorker_5.ProgressChanged += new ProgressChangedEventHandler(this.backgroundWorker_12_ProgressChanged);
			this.backgroundWorker_6.WorkerReportsProgress = true;
			this.backgroundWorker_6.WorkerSupportsCancellation = true;
			this.backgroundWorker_6.DoWork += new DoWorkEventHandler(this.backgroundWorker_6_DoWork);
			this.backgroundWorker_6.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker_12_RunWorkerCompleted);
			this.backgroundWorker_6.ProgressChanged += new ProgressChangedEventHandler(this.backgroundWorker_12_ProgressChanged);
			this.backgroundWorker_7.WorkerReportsProgress = true;
			this.backgroundWorker_7.WorkerSupportsCancellation = true;
			this.backgroundWorker_7.DoWork += new DoWorkEventHandler(this.backgroundWorker_7_DoWork);
			this.backgroundWorker_7.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker_12_RunWorkerCompleted);
			this.backgroundWorker_7.ProgressChanged += new ProgressChangedEventHandler(this.backgroundWorker_12_ProgressChanged);
			this.backgroundWorker_8.WorkerReportsProgress = true;
			this.backgroundWorker_8.WorkerSupportsCancellation = true;
			this.backgroundWorker_8.DoWork += new DoWorkEventHandler(this.backgroundWorker_8_DoWork);
			this.backgroundWorker_8.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker_12_RunWorkerCompleted);
			this.backgroundWorker_8.ProgressChanged += new ProgressChangedEventHandler(this.backgroundWorker_12_ProgressChanged);
			this.toolTip_0.AutomaticDelay = 100;
			this.toolTip_0.AutoPopDelay = 50000;
			this.toolTip_0.InitialDelay = 100;
			this.toolTip_0.ReshowDelay = 20;
			this.toolTip_0.ShowAlways = true;
			this.toolTip_0.ToolTipIcon = ToolTipIcon.Info;
			this.toolTip_0.ToolTipTitle = Localization.Get("提示");
			this.backgroundWorker_0.WorkerReportsProgress = true;
			this.backgroundWorker_0.WorkerSupportsCancellation = true;
			this.backgroundWorker_0.DoWork += new DoWorkEventHandler(this.backgroundWorker_0_DoWork);
			this.backgroundWorker_0.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker_12_RunWorkerCompleted);
			this.backgroundWorker_0.ProgressChanged += new ProgressChangedEventHandler(this.backgroundWorker_12_ProgressChanged);
			this.backgroundWorker_1.WorkerReportsProgress = true;
			this.backgroundWorker_1.WorkerSupportsCancellation = true;
			this.backgroundWorker_1.DoWork += new DoWorkEventHandler(this.backgroundWorker_1_DoWork);
			this.backgroundWorker_1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker_12_RunWorkerCompleted);
			this.backgroundWorker_1.ProgressChanged += new ProgressChangedEventHandler(this.backgroundWorker_12_ProgressChanged);
			this.backgroundWorker_2.WorkerReportsProgress = true;
			this.backgroundWorker_2.WorkerSupportsCancellation = true;
			this.backgroundWorker_2.DoWork += new DoWorkEventHandler(this.backgroundWorker_2_DoWork);
			this.backgroundWorker_2.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker_12_RunWorkerCompleted);
			this.backgroundWorker_2.ProgressChanged += new ProgressChangedEventHandler(this.backgroundWorker_12_ProgressChanged);
			this.backgroundWorker_9.WorkerReportsProgress = true;
			this.backgroundWorker_9.WorkerSupportsCancellation = true;
			this.backgroundWorker_9.DoWork += new DoWorkEventHandler(this.backgroundWorker_9_DoWork);
			this.backgroundWorker_9.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker_12_RunWorkerCompleted);
			this.backgroundWorker_9.ProgressChanged += new ProgressChangedEventHandler(this.backgroundWorker_12_ProgressChanged);
			this.backgroundWorker_10.WorkerReportsProgress = true;
			this.backgroundWorker_10.WorkerSupportsCancellation = true;
			this.backgroundWorker_10.DoWork += new DoWorkEventHandler(this.backgroundWorker_10_DoWork);
			this.backgroundWorker_10.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker_12_RunWorkerCompleted);
			this.backgroundWorker_10.ProgressChanged += new ProgressChangedEventHandler(this.backgroundWorker_12_ProgressChanged);
			this.backgroundWorker_11.WorkerReportsProgress = true;
			this.backgroundWorker_11.WorkerSupportsCancellation = true;
			this.backgroundWorker_11.DoWork += new DoWorkEventHandler(this.backgroundWorker_11_DoWork);
			this.backgroundWorker_11.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker_12_RunWorkerCompleted);
			this.backgroundWorker_11.ProgressChanged += new ProgressChangedEventHandler(this.backgroundWorker_12_ProgressChanged);
			this.backgroundWorker_12.WorkerReportsProgress = true;
			this.backgroundWorker_12.WorkerSupportsCancellation = true;
			this.backgroundWorker_12.DoWork += new DoWorkEventHandler(this.backgroundWorker_12_DoWork);
			this.backgroundWorker_12.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker_12_RunWorkerCompleted);
			this.backgroundWorker_12.ProgressChanged += new ProgressChangedEventHandler(this.backgroundWorker_12_ProgressChanged);
			this.ReviseChapter.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.ReviseChapter.Controls.Add(this.button2);
			this.ReviseChapter.Controls.Add(this.sortBox);
			this.ReviseChapter.Controls.Add(this.posterBox);
			this.ReviseChapter.Controls.Add(this.articlenameBox);
			this.ReviseChapter.Controls.Add(this.chapterNameBox);
			this.ReviseChapter.Controls.Add(this.button1);
			this.ReviseChapter.Controls.Add(this.label4);
			this.ReviseChapter.Controls.Add(this.label3);
			this.ReviseChapter.Controls.Add(this.label2);
			this.ReviseChapter.Controls.Add(this.label1);
			this.ReviseChapter.Controls.Add(this.groupBox1);
			this.ReviseChapter.Location = new Point(76, 193);
			this.ReviseChapter.Name = "ReviseChapter";
			this.ReviseChapter.Size = new System.Drawing.Size(681, 208);
			this.ReviseChapter.TabIndex = 5;
			this.ReviseChapter.Visible = false;
			this.button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			this.button2.Location = new Point(603, 182);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 13;
			this.button2.Text = Localization.Get("取消");
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new EventHandler(this.button2_Click);
			this.sortBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.sortBox.FormattingEnabled = true;
			this.sortBox.Location = new Point(571, 9);
			this.sortBox.Name = "sortBox";
			this.sortBox.Size = new System.Drawing.Size(101, 20);
			this.sortBox.TabIndex = 12;
			this.posterBox.Location = new Point(354, 9);
			this.posterBox.Name = "posterBox";
			this.posterBox.Size = new System.Drawing.Size(172, 21);
			this.posterBox.TabIndex = 10;
			this.articlenameBox.Location = new Point(62, 9);
			this.articlenameBox.Name = "articlenameBox";
			this.articlenameBox.ReadOnly = true;
			this.articlenameBox.Size = new System.Drawing.Size(246, 21);
			this.articlenameBox.TabIndex = 9;
			this.chapterNameBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.chapterNameBox.Location = new Point(62, 38);
			this.chapterNameBox.Name = "chapterNameBox";
			this.chapterNameBox.Size = new System.Drawing.Size(607, 21);
			this.chapterNameBox.TabIndex = 8;
			this.button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			this.button1.Location = new Point(522, 182);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 6;
			this.button1.Text = Localization.Get("确认");
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new EventHandler(this.button1_Click);
			this.label4.AutoSize = true;
			this.label4.Location = new Point(532, 12);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(41, 12);
			this.label4.TabIndex = 5;
			this.label4.Text = Localization.Get("分类：");
			this.label3.AutoSize = true;
			this.label3.Location = new Point(314, 13);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(41, 12);
			this.label3.TabIndex = 4;
			this.label3.Text = Localization.Get("作者：");
			this.label2.AutoSize = true;
			this.label2.Location = new Point(10, 13);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 12);
			this.label2.TabIndex = 3;
			this.label2.Text = Localization.Get("小说名：");
			this.label1.AutoSize = true;
			this.label1.Location = new Point(10, 41);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 12);
			this.label1.TabIndex = 1;
			this.label1.Text = Localization.Get("章节名：");
			this.groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.groupBox1.Controls.Add(this.chapterTXTBox);
			this.groupBox1.Location = new Point(3, 66);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(675, 110);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = Localization.Get("章节内容");
			this.chapterTXTBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.chapterTXTBox.Location = new Point(9, 20);
			this.chapterTXTBox.Multiline = true;
			this.chapterTXTBox.Name = "chapterTXTBox";
			this.chapterTXTBox.ScrollBars = ScrollBars.Vertical;
			this.chapterTXTBox.Size = new System.Drawing.Size(660, 84);
			this.chapterTXTBox.TabIndex = 3;
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font(Localization.Get("宋体"), 12f, FontStyle.Bold, GraphicsUnit.Point, 134);
			this.label5.ForeColor = Color.Orange;
			this.label5.Location = new Point(457, 10);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(25, 16);
			this.label5.TabIndex = 6;
			this.label5.Text = "▆";
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font(Localization.Get("宋体"), 12f, FontStyle.Bold, GraphicsUnit.Point, 134);
			this.label6.ForeColor = Color.SeaGreen;
			this.label6.Location = new Point(547, 10);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(25, 16);
			this.label6.TabIndex = 6;
			this.label6.Text = "▆";
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font(Localization.Get("宋体"), 12f, FontStyle.Bold, GraphicsUnit.Point, 134);
			this.label7.ForeColor = Color.Red;
			this.label7.Location = new Point(739, 10);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(25, 16);
			this.label7.TabIndex = 6;
			this.label7.Text = "▆";
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font(Localization.Get("宋体"), 12f, FontStyle.Bold, GraphicsUnit.Point, 134);
			this.label8.ForeColor = Color.DeepPink;
			this.label8.Location = new Point(643, 10);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(25, 16);
			this.label8.TabIndex = 6;
			this.label8.Text = "▆";
			this.label9.AutoSize = true;
			this.label9.Location = new Point(488, 14);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(53, 12);
			this.label9.TabIndex = 7;
			this.label9.Text = Localization.Get("当天更新");
			this.label10.AutoSize = true;
			this.label10.Location = new Point(578, 14);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(59, 12);
			this.label10.TabIndex = 7;
			this.label10.Text = Localization.Get("2~3天更新");
			this.label11.AutoSize = true;
			this.label11.Location = new Point(674, 14);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(59, 12);
			this.label11.TabIndex = 7;
			this.label11.Text = Localization.Get("3~7天更新");
			this.label12.AutoSize = true;
			this.label12.Location = new Point(770, 14);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(59, 12);
			this.label12.TabIndex = 7;
			this.label12.Text = Localization.Get("7天前更新");
			this.backgroundWorker1.WorkerReportsProgress = true;
			this.backgroundWorker1.WorkerSupportsCancellation = true;
			this.backgroundWorker1.DoWork += new DoWorkEventHandler(this.backgroundWorker1_DoWork);
			this.backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
			base.ClientSize = new System.Drawing.Size(834, 456);
			base.Controls.Add(this.label12);
			base.Controls.Add(this.label11);
			base.Controls.Add(this.label10);
			base.Controls.Add(this.label9);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.label7);
			base.Controls.Add(this.label6);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.ReviseChapter);
			base.Controls.Add(this.splitContainer_0);
			base.Controls.Add(this.statusStrip_0);
			base.Controls.Add(this.toolStrip_0);
			this.Font = new System.Drawing.Font(Localization.Get("宋体"), 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
			base.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "CollectManual";
			this.Text = Localization.Get("手动控制");
			base.Load += new EventHandler(this.CollectManual_Load);
			this.toolStrip_0.ResumeLayout(false);
			this.toolStrip_0.PerformLayout();
			this.statusStrip_0.ResumeLayout(false);
			this.statusStrip_0.PerformLayout();
			this.splitContainer_0.Panel1.ResumeLayout(false);
			this.splitContainer_0.Panel2.ResumeLayout(false);
			this.splitContainer_0.ResumeLayout(false);
			this.panel_0.ResumeLayout(false);
			this.panel_0.PerformLayout();
			this.panel_1.ResumeLayout(false);
			this.panel_1.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.NovelMenuStrip.ResumeLayout(false);
			this.LocalMenuStrip.ResumeLayout(false);
			this.panel_2.ResumeLayout(false);
			this.splitContainer_1.Panel1.ResumeLayout(false);
			this.splitContainer_1.Panel2.ResumeLayout(false);
			this.splitContainer_1.ResumeLayout(false);
			this.TargetMenuStrip.ResumeLayout(false);
			this.LocalMenuStrip_1.ResumeLayout(false);
			this.ReviseChapter.ResumeLayout(false);
			this.ReviseChapter.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private void listView_0_DoubleClick(object sender, EventArgs e)
		{
			bool flag = false;
			for (int i = 0; i < this.listView_0.Items.Count; i++)
			{
				this.listView_0.Items[i].Checked = flag;
				if (this.listView_0.Items[i].BackColor == Color.Red)
				{
					flag = true;
				}
			}
			if ((this.listView_0.CheckedItems.Count == 0 || this.bool_0 ? false : !this.backgroundWorker_6.IsBusy))
			{
				this.bool_0 = true;
				this.panel_2.Enabled = false;
				this.toolStripStatusLabel_0.Text = Localization.Get("正在采集章节.请勿进行其他操作..");
				ArrayList arrayLists = new ArrayList();
				for (int j = 0; j < this.listView_0.Items.Count; j++)
				{
					if (this.listView_0.Items[j].Checked)
					{
						ChapterInfo tag = (ChapterInfo)this.listView_0.Items[j].Tag;
						arrayLists.Add(tag);
					}
				}
				this.novelInfo_0 = (NovelInfo)this.listView_0.Tag;
				ChapterInfo[] array = (ChapterInfo[])arrayLists.ToArray(typeof(ChapterInfo));
				arrayLists.Clear();
				this.backgroundWorker_6.RunWorkerAsync(array);
			}
		}

		private void listView_1_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool flag;
			ListView listView = (ListView)sender;
			if (listView.SelectedItems.Count > 0)
			{
				this.int_2 = listView.SelectedItems[0].Index;
				string name = listView.Name;
				string str = name;
				if (name == null)
				{
					flag = true;
				}
				else
				{
					flag = (str == "listView_0" ? false : !(str == "listView_1"));
				}
				if (flag)
				{
					this.toolStripStatusLabel_1.Text = string.Concat(listView.SelectedItems[0].Text, " ", listView.SelectedItems[0].SubItems[1].Text);
				}
				else
				{
					this.toolStripStatusLabel_1.Text = string.Concat(listView.SelectedItems[0].SubItems[1].Text, " ", listView.SelectedItems[0].SubItems[2].Text);
				}
				listView.SelectedItems[0].Selected = false;
			}
		}

		private void listView_2_DoubleClick(object sender, EventArgs e)
		{
			if ((this.bool_0 || this.backgroundWorker_7.IsBusy ? false : this.int_2 != -1))
			{
				this.bool_0 = true;
				this.panel_2.Enabled = false;
				this.toolStripStatusLabel_0.Text = Localization.Get("正在列出章节.请勿进行其他操作..");
				this.listView_2.Items[this.int_2].Checked = !this.listView_2.Items[this.int_2].Checked;
				NovelInfo tag = (NovelInfo)this.listView_2.Items[this.int_2].Tag;
				this.listView_0.Tag = tag;
				this.backgroundWorker_7.RunWorkerAsync(tag);
			}
		}

		private void LocalMenuStrip_1_Opening(object sender, CancelEventArgs e)
		{
		}

		private void method_0()
		{
			this.comboBox_3.BeginUpdate();
			string[] strArrays = IO.LoadRules();
			this.comboBox_3.Items.Clear();
			if ((int)strArrays.Length > 0)
			{
				for (int i = 0; i < (int)strArrays.Length; i++)
				{
					this.comboBox_3.Items.Add(strArrays[i]);
					if (strArrays[i] == this.taskConfigInfo_0.RuleFile)
					{
						this.comboBox_3.Text = this.taskConfigInfo_0.RuleFile;
						this.ruleConfigInfo_0 = (RuleConfigInfo)ConfigFileManager.LoadConfig(this.taskConfigInfo_0.RuleFile, this.ruleConfigInfo_0);
						this.comboBox_1.Text = this.ruleConfigInfo_0.NovelListUrl.Pattern;
					}
				}
			}
			this.comboBox_3.EndUpdate();
			this.comboBox_3.Text = this.taskConfigInfo_0.RuleFile;
			this.comboBox_4.BeginUpdate();
			this.comboBox_4.Items.Clear();
			string[] strArrays1 = IO.LoadLogs();
			int num = -1;
			string[] strArrays2 = strArrays1;
			for (int j = 0; j < (int)strArrays2.Length; j++)
			{
				string str = strArrays2[j];
				if (str.EndsWith("db3"))
				{
					num++;
					this.comboBox_4.Items.Insert(num, str.Replace("Log\\", ""));
				}
			}
			if (num >= 0)
			{
				this.comboBox_4.SelectedIndex = num;
			}
			this.comboBox_4.EndUpdate();
		}

		private void method_1(object sender, EventArgs e)
		{
			if ((new CollectAuto(true)).ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				this.taskConfigInfo_0 = (TaskConfigInfo)ConfigFileManager.LoadConfig("TaskConfig.xml", this.taskConfigInfo_0);
				this.ruleConfigInfo_0 = (RuleConfigInfo)ConfigFileManager.LoadConfig(this.taskConfigInfo_0.RuleFile, this.ruleConfigInfo_0);
				this.page_0 = new Page(this.ruleConfigInfo_0, this.taskConfigInfo_0);
				this.method_0();
			}
		}

		private void NovelMenuStrip_Opening(object sender, CancelEventArgs e)
		{
		}

		private void radioButton_3_CheckedChanged(object sender, EventArgs e)
		{
			if (Configs.CmsName == "Qiwen")
			{
				this.comboBox_1.Text = "SELECT TOP 30 * FROM [Ws_BookList]";
			}
			else if (Configs.CmsName != "Jieqi")
			{
				this.comboBox_1.Text = Localization.Get("请输入SQL查询语句");
			}
			else
			{
				this.comboBox_1.Text = "SELECT * FROM `jieqi_article_article` LIMIT  0,30";
			}
		}

		private void radioButton_4_CheckedChanged(object sender, EventArgs e)
		{
			this.comboBox_1.Text = this.ruleConfigInfo_0.NovelListUrl.Pattern;
		}

		private void TargetMenuStrip_Opening(object sender, CancelEventArgs e)
		{
		}

		private void toolStripButton_0_Click(object sender, EventArgs e)
		{
			this.panel_1.Visible = false;
			if (!this.panel_0.Visible)
			{
				this.panel_0.Visible = true;
			}
			else
			{
				this.panel_0.Visible = false;
			}
		}

		private void toolStripButton_1_Click(object sender, EventArgs e)
		{
			this.panel_0.Visible = false;
			if (!this.panel_1.Visible)
			{
				this.panel_1.Visible = true;
			}
			else
			{
				this.panel_1.Visible = false;
			}
		}

		private void toolStripButton_3_Click(object sender, EventArgs e)
		{
			if (this.backgroundWorker_6.IsBusy)
			{
				this.backgroundWorker_6.CancelAsync();
			}
			if (this.backgroundWorker_4.IsBusy)
			{
				this.backgroundWorker_4.CancelAsync();
			}
		}

		private void toolStripMenuItem_1_Click(object sender, EventArgs e)
		{
			if ((this.listView_2.CheckedItems.Count == 0 || this.bool_0 ? false : !this.backgroundWorker_8.IsBusy))
			{
				this.bool_0 = true;
				this.panel_2.Enabled = false;
				this.toolStripStatusLabel_0.Text = Localization.Get("正在添加小说.请勿进行其他操作..");
				NovelInfo[] tag = new NovelInfo[this.listView_2.CheckedItems.Count];
				int num = 0;
				for (int i = 0; i < this.listView_2.Items.Count; i++)
				{
					if (this.listView_2.Items[i].Checked)
					{
						tag[num] = (NovelInfo)this.listView_2.Items[i].Tag;
						num++;
					}
				}
				this.backgroundWorker_8.RunWorkerAsync(tag);
			}
		}

		private void toolStripMenuItem_10_Click(object sender, EventArgs e)
		{
			bool flag = false;
			for (int i = 0; i < this.listView_0.Items.Count; i++)
			{
				if (this.listView_0.Items[i].Checked)
				{
					flag = true;
				}
				if (flag)
				{
					this.listView_0.Items[i].Checked = true;
				}
			}
		}

		private void toolStripMenuItem_11_Click(object sender, EventArgs e)
		{
			this.listView_0.Items.Clear();
		}

		private void toolStripMenuItem_12_Click(object sender, EventArgs e)
		{
			bool flag;
			if (this.listView_0.CheckedItems.Count != this.listView_1.CheckedItems.Count || this.listView_0.CheckedItems.Count == 0)
			{
				flag = true;
			}
			else
			{
				flag = (this.bool_0 ? true : this.backgroundWorker_2.IsBusy);
			}
			if (!flag)
			{
				this.bool_0 = true;
				this.panel_2.Enabled = false;
				this.toolStripStatusLabel_0.Text = Localization.Get("正在替换章节.请勿进行其他操作..");
				this.novelInfo_0 = (NovelInfo)this.listView_0.Tag;
				ArrayList arrayLists = new ArrayList();
				for (int i = 0; i < this.listView_0.Items.Count; i++)
				{
					if (this.listView_0.Items[i].Checked)
					{
						ChapterInfo tag = (ChapterInfo)this.listView_0.Items[i].Tag;
						arrayLists.Add(tag);
					}
				}
				this.chapterInfo_0 = (ChapterInfo[])arrayLists.ToArray(typeof(ChapterInfo));
				arrayLists.Clear();
				for (int j = 0; j < this.listView_1.Items.Count; j++)
				{
					if (this.listView_1.Items[j].Checked)
					{
						ChapterInfo chapterInfo = (ChapterInfo)this.listView_1.Items[j].Tag;
						arrayLists.Add(chapterInfo);
					}
				}
				this.chapterInfo_1 = (ChapterInfo[])arrayLists.ToArray(typeof(ChapterInfo));
				this.backgroundWorker_2.RunWorkerAsync();
			}
		}

		private void toolStripMenuItem_13_Click(object sender, EventArgs e)
		{
			if ((this.listView_1.CheckedItems.Count == 0 || this.bool_0 ? false : !this.backgroundWorker_1.IsBusy))
			{
				this.bool_0 = true;
				this.panel_2.Enabled = false;
				this.toolStripStatusLabel_0.Text = Localization.Get("正在检查章节.请勿进行其他操作..");
				ArrayList arrayLists = new ArrayList();
				for (int i = 0; i < this.listView_1.Items.Count; i++)
				{
					if (this.listView_1.Items[i].Checked)
					{
						ChapterInfo tag = (ChapterInfo)this.listView_1.Items[i].Tag;
						arrayLists.Add(tag);
					}
				}
				this.novelInfo_0 = (NovelInfo)this.listView_0.Tag;
				this.backgroundWorker_1.RunWorkerAsync((ChapterInfo[])arrayLists.ToArray(typeof(ChapterInfo)));
			}
		}

		private void toolStripMenuItem_14_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.listView_1.Items.Count; i++)
			{
				this.listView_1.Items[i].Checked = true;
			}
		}

		private void toolStripMenuItem_15_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.listView_1.Items.Count; i++)
			{
				this.listView_1.Items[i].Checked = !this.listView_1.Items[i].Checked;
			}
		}

		private void toolStripMenuItem_16_Click(object sender, EventArgs e)
		{
			bool flag = false;
			for (int i = 0; i < this.listView_1.Items.Count; i++)
			{
				if (this.listView_1.Items[i].Checked)
				{
					flag = true;
				}
				if (flag)
				{
					this.listView_1.Items[i].Checked = true;
				}
			}
		}

		private void toolStripMenuItem_17_Click(object sender, EventArgs e)
		{
			if ((this.listView_1.CheckedItems.Count == 0 || this.bool_0 ? false : !this.backgroundWorker_0.IsBusy))
			{
				this.bool_0 = true;
				this.panel_2.Enabled = false;
				this.toolStripStatusLabel_0.Text = Localization.Get("正在删除章节.请勿进行其他操作..");
				ArrayList arrayLists = new ArrayList();
				for (int i = 0; i < this.listView_1.Items.Count; i++)
				{
					if (this.listView_1.Items[i].Checked)
					{
						ChapterInfo tag = (ChapterInfo)this.listView_1.Items[i].Tag;
						tag.chaptertype = 0;
						arrayLists.Add(tag);
					}
				}
				this.novelInfo_0 = (NovelInfo)this.listView_0.Tag;
				NovelInfo novelInfo = (NovelInfo)this.listView_0.Tag;
				this.backgroundWorker_0.RunWorkerAsync((ChapterInfo[])arrayLists.ToArray(typeof(ChapterInfo)));
			}
		}

		private void toolStripMenuItem_18_Click(object sender, EventArgs e)
		{
			bool flag = false;
			for (int i = 0; i < this.listView_2.Items.Count; i++)
			{
				if (this.listView_2.Items[i].Checked)
				{
					flag = true;
				}
				if (flag)
				{
					this.listView_2.Items[i].Checked = true;
				}
			}
		}

		private void toolStripMenuItem_19_Click(object sender, EventArgs e)
		{
			if (this.listView_2.CheckedItems.Count != 0)
			{
				NovelInfo[] tag = new NovelInfo[this.listView_2.CheckedItems.Count];
				int num = 0;
				for (int i = 0; i < this.listView_2.Items.Count; i++)
				{
					if (this.listView_2.Items[i].Checked)
					{
						tag[num] = (NovelInfo)this.listView_2.Items[i].Tag;
						num++;
					}
				}
				this.backgroundWorker_5.RunWorkerAsync(tag);
			}
		}

		private void toolStripMenuItem_2_Click(object sender, EventArgs e)
		{
			if (this.listView_2.CheckedItems.Count <= 1)
			{
				if (this.listView_2.CheckedItems.Count == 1)
				{
					this.bool_0 = true;
				}
				this.panel_2.Enabled = false;
				ArrayList arrayLists = new ArrayList();
				string name = "";
				for (int i = 0; i < this.listView_2.Items.Count; i++)
				{
					if (this.listView_2.Items[i].Checked)
					{
						NovelInfo tag = (NovelInfo)this.listView_2.Items[i].Tag;
						object[] putID = new object[] { i, "^", tag.PutID, "^", tag.GetID, "^", tag.Name, "^", this.comboBox_4.Text };
						string str = string.Concat(putID);
						NovelSpider.Local.LocalProvider.GetInstance().ClearNovel(tag);
						NovelSpider.Local.LocalProvider.GetInstance().DeteleNovel(tag.PutID);
						name = tag.Name;
						arrayLists.Add(str);
					}
				}
				this.toolStripStatusLabel_0.Text = string.Concat(Localization.Get("正在删除《"), name, Localization.Get("》"));
				this.backgroundWorker_11.RunWorkerAsync((string[])arrayLists.ToArray(typeof(string)));
			}
			else
			{
				MessageBox.Show(Localization.Get("本功能只支持单本删除，你确认你只选择了一本小说！"));
			}
		}

		private void toolStripMenuItem_20_Click(object sender, EventArgs e)
		{
			if ((this.listView_2.CheckedItems.Count != 1 || this.bool_0 ? false : !this.backgroundWorker_7.IsBusy))
			{
				this.bool_0 = true;
				this.panel_2.Enabled = false;
				this.toolStripStatusLabel_0.Text = Localization.Get("正在列出章节.请勿进行其他操作..");
				NovelInfo tag = (NovelInfo)this.listView_2.CheckedItems[0].Tag;
				this.listView_0.Tag = tag;
				this.backgroundWorker_7.RunWorkerAsync(tag);
			}
		}

		private void toolStripMenuItem_21_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.listView_2.Items.Count; i++)
			{
				this.listView_2.Items[i].Checked = false;
			}
		}

		private void toolStripMenuItem_22_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.listView_0.Items.Count; i++)
			{
				this.listView_0.Items[i].Checked = false;
			}
		}

		private void toolStripMenuItem_23_Click(object sender, EventArgs e)
		{
			NovelInfo tag = (NovelInfo)this.listView_0.Tag;
			string[] getID = new string[] { Localization.Get("===对比信息===\n"), tag.GetID, " | ", tag.Name, " | ", tag.PutID.ToString(), "\n" };
			string str = string.Concat(getID);
			for (int i = 0; i < this.listView_0.Items.Count; i++)
			{
				if (this.listView_0.Items[i].BackColor == Color.Red)
				{
					ChapterInfo chapterInfo = (ChapterInfo)this.listView_0.Items[i].Tag;
					getID = new string[] { str, chapterInfo.VolumeName, "\n", chapterInfo.ChapterName, "\n" };
					str = string.Concat(getID);
				}
			}
			getID = new string[] { str, tag.LastChapter.VolumeName, "\n", tag.LastChapter.ChapterName, "\n" };
			Clipboard.SetDataObject(string.Concat(getID));
			MessageBox.Show(Localization.Get("复制成功，可直接Ctrl+V复制到QQ中。"));
		}

		private void toolStripMenuItem_24_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.listView_1.Items.Count; i++)
			{
				this.listView_1.Items[i].Checked = false;
			}
		}

		private void toolStripMenuItem_25_Click(object sender, EventArgs e)
		{
			bool flag;
			if (this.listView_0.CheckedItems.Count == 0 || this.listView_1.CheckedItems.Count != 1)
			{
				flag = false;
			}
			else
			{
				flag = (this.bool_0 ? false : !this.backgroundWorker_9.IsBusy);
			}
			if (flag)
			{
				this.bool_0 = true;
				this.panel_2.Enabled = false;
				this.toolStripStatusLabel_0.Text = Localization.Get("正在插入章节.请勿进行其他操作..");
				this.novelInfo_0 = (NovelInfo)this.listView_0.Tag;
				ArrayList arrayLists = new ArrayList();
				for (int i = 0; i < this.listView_0.Items.Count; i++)
				{
					if (this.listView_0.Items[i].Checked)
					{
						ChapterInfo tag = (ChapterInfo)this.listView_0.Items[i].Tag;
						arrayLists.Add(tag);
					}
				}
				this.chapterInfo_0 = (ChapterInfo[])arrayLists.ToArray(typeof(ChapterInfo));
				arrayLists.Clear();
				int num = 0;
				while (true)
				{
					if (num >= this.listView_1.Items.Count)
					{
						break;
					}
					else if (this.listView_1.Items[num].Checked)
					{
						ChapterInfo chapterInfo = (ChapterInfo)this.listView_1.Items[num].Tag;
						this.int_1 = chapterInfo.PutID;
						this.int_3 = num;
						break;
					}
					else
					{
						num++;
					}
				}
				this.backgroundWorker_9.RunWorkerAsync();
			}
			else
			{
				MessageBox.Show(Localization.Get("远程章节未选择/本地章节选择数量不等于1/后台线程正忙"));
			}
		}

		private void toolStripMenuItem_3_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.listView_2.Items.Count; i++)
			{
				this.listView_2.Items[i].Checked = true;
			}
		}

		private void toolStripMenuItem_4_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.listView_2.Items.Count; i++)
			{
				this.listView_2.Items[i].Checked = !this.listView_2.Items[i].Checked;
			}
		}

		private void toolStripMenuItem_5_Click(object sender, EventArgs e)
		{
			this.listView_2.Items.Clear();
		}

		private void toolStripMenuItem_6_Click(object sender, EventArgs e)
		{
			if ((this.listView_0.CheckedItems.Count == 0 || this.bool_0 ? false : !this.backgroundWorker_6.IsBusy))
			{
				this.bool_0 = true;
				this.panel_2.Enabled = false;
				this.toolStripStatusLabel_0.Text = Localization.Get("正在采集章节.请勿进行其他操作..");
				ArrayList arrayLists = new ArrayList();
				for (int i = 0; i < this.listView_0.Items.Count; i++)
				{
					if (this.listView_0.Items[i].Checked)
					{
						ChapterInfo tag = (ChapterInfo)this.listView_0.Items[i].Tag;
						arrayLists.Add(tag);
					}
				}
				this.novelInfo_0 = (NovelInfo)this.listView_0.Tag;
				ChapterInfo[] array = (ChapterInfo[])arrayLists.ToArray(typeof(ChapterInfo));
				arrayLists.Clear();
				this.backgroundWorker_6.RunWorkerAsync(array);
			}
		}

		private void toolStripMenuItem_8_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.listView_0.Items.Count; i++)
			{
				this.listView_0.Items[i].Checked = true;
			}
		}

		private void toolStripMenuItem_9_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.listView_0.Items.Count; i++)
			{
				this.listView_0.Items[i].Checked = !this.listView_0.Items[i].Checked;
			}
		}

		private void 反选章节ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.listView1.Items.Count; i++)
			{
				if (!this.listView1.Items[i].Checked)
				{
					this.listView1.Items[i].Checked = true;
				}
				else
				{
					this.listView1.Items[i].Checked = false;
				}
			}
		}

		private void 检测TXTToolStripMenuItem_Click(object sender, EventArgs e)
		{
			object[] txtDir;
			if (MessageBox.Show(Localization.Get("章节数过多时检测TXT可能出现卡顿、无响现象，请务进行其他的操作！"), "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
			{
				this.bool_0 = true;
				this.panel_2.Enabled = false;
				this.toolStripStatusLabel_0.Text = Localization.Get("正在检测重新章节请误进行其他操作...");
				for (int i = 0; i < this.listView_1.Items.Count; i++)
				{
					this.listView_1.Items[i].Checked = false;
				}
				for (int j = 0; j < this.listView_0.Items.Count; j++)
				{
					this.listView_0.Items[j].Checked = false;
				}
				string str = "";
				int num = 0;
				for (int k = 0; k < this.listView_1.Items.Count; k++)
				{
					NovelInfo tag = (NovelInfo)this.listView_0.Tag;
					ChapterInfo chapterInfo = (ChapterInfo)this.listView_1.Items[k].Tag;
					txtDir = new object[] { NovelSpider.Local.Jieqi.Config.TxtDir, "/", tag.PutID / 1000, "/", tag.PutID.ToString(), "/", null, null };
					txtDir[6] = chapterInfo.PutID.ToString();
					txtDir[7] = ".txt";
					if (!File.Exists(string.Concat(txtDir)))
					{
						this.listView_1.Items[k].Checked = true;
						if (this.listView_1.Items[k].Checked)
						{
							num++;
						}
						int num1 = 0;
						while (num1 < this.listView_0.Items.Count)
						{
							if (this.listView_1.Items[k].SubItems[2].Text == this.listView_0.Items[num1].SubItems[2].Text)
							{
								this.listView_0.Items[num1].Checked = true;
								break;
							}
							else if ((this.listView_1.Items[k].SubItems[2].Text == this.listView_0.Items[num1].SubItems[2].Text ? false : this.listView_0.Items.Count - 1 == num1))
							{
								this.listView_1.Items[k].Checked = false;
								object obj = str;
								txtDir = new object[] { obj, Localization.Get("\n索引 "), k, "、", this.listView_1.Items[k].SubItems[2].Text };
								str = string.Concat(txtDir);
                                break;
							}
							else
							{
								num1++;
							}
						}
					}
				}
				if (num <= 0)
				{
					MessageBox.Show(Localization.Get("当前小说章节TXT完整！"));
				}
				else
				{
					txtDir = new object[] { Localization.Get("检测到本站"), num, Localization.Get("个章节无TXT文本,与目标站对比成功"), this.listView_0.CheckedItems.Count, "个章节，", num - this.listView_0.CheckedItems.Count, Localization.Get("个章节对比失败！\n失败章节如下："), str };
					MessageBox.Show(string.Concat(txtDir));
				}
				this.toolStripStatusLabel_0.Text = Localization.Get("操作完成");
				this.panel_0.Visible = false;
				this.panel_1.Visible = false;
				this.button_0.Enabled = true;
				this.button_3.Enabled = true;
				this.bool_0 = false;
				this.panel_2.Enabled = true;
			}
		}

		private void 检查重复章节ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show(Localization.Get("章节数过多时检测重复章节可能出现卡顿、无响现象，请务进行其他的操作！"), "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
			{
				this.bool_0 = true;
				this.panel_2.Enabled = false;
				this.toolStripStatusLabel_0.Text = Localization.Get("正在检测重复章节请误进行其他操作...");
				for (int i = this.listView_1.Items.Count - 1; i >= 0; i--)
				{
					if ((i >= this.listView_1.Items.Count ? false : i > 0))
					{
						string text = this.listView_1.Items[i].SubItems[2].Text;
						for (int j = i; j >= 0; j--)
						{
							if ((text != this.listView_1.Items[j].SubItems[2].Text ? false : i != j))
							{
								this.listView_1.Items[i].Checked = true;
							}
						}
					}
				}
				if (this.listView_1.CheckedItems.Count <= 0)
				{
					MessageBox.Show(Localization.Get("当前小说无重复章节！"));
				}
				else
				{
					MessageBox.Show(string.Concat(Localization.Get("检测到当前小说存在"), this.listView_1.CheckedItems.Count, Localization.Get("个重复章节，此数据只供参考，请自己认真后再删除！")));
				}
				this.toolStripStatusLabel_0.Text = Localization.Get("操作完成");
				this.panel_0.Visible = false;
				this.panel_1.Visible = false;
				this.button_0.Enabled = true;
				this.button_3.Enabled = true;
				this.bool_0 = false;
				this.panel_2.Enabled = true;
			}
		}

		private void 全不选章节ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.listView1.Items.Count; i++)
			{
				this.listView1.Items[i].Checked = false;
			}
		}

		private void 全选章节ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.listView1.Items.Count; i++)
			{
				this.listView1.Items[i].Checked = true;
			}
		}

		private void 删除本章数据库ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if ((this.listView_1.CheckedItems.Count == 0 || this.bool_0 ? false : !this.backgroundWorker_12.IsBusy))
			{
				this.bool_0 = true;
				this.panel_2.Enabled = false;
				this.toolStripStatusLabel_0.Text = Localization.Get("正在删除章节.请勿进行其他操作..");
				ArrayList arrayLists = new ArrayList();
				for (int i = 0; i < this.listView_1.Items.Count; i++)
				{
					if (this.listView_1.Items[i].Checked)
					{
						ChapterInfo tag = (ChapterInfo)this.listView_1.Items[i].Tag;
						tag.chaptertype = 0;
						arrayLists.Add(tag);
					}
				}
				this.novelInfo_0 = (NovelInfo)this.listView_0.Tag;
				NovelInfo novelInfo = (NovelInfo)this.listView_0.Tag;
				this.backgroundWorker_12.RunWorkerAsync((ChapterInfo[])arrayLists.ToArray(typeof(ChapterInfo)));
			}
		}

		private void 删除分卷ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if ((this.listView1.CheckedItems.Count == 0 || this.bool_0 ? false : !this.backgroundWorker_0.IsBusy))
			{
				this.bool_0 = true;
				this.panel_2.Enabled = false;
				this.toolStripStatusLabel_0.Text = Localization.Get("正在删除分卷.请勿进行其他操作..");
				ArrayList arrayLists = new ArrayList();
				for (int i = 0; i < this.listView1.Items.Count; i++)
				{
					if (this.listView1.Items[i].Checked)
					{
						ChapterInfo tag = (ChapterInfo)this.listView1.Items[i].Tag;
						arrayLists.Add(tag);
					}
				}
				this.novelInfo_0 = (NovelInfo)this.listView_0.Tag;
				this.backgroundWorker_0.RunWorkerAsync((ChapterInfo[])arrayLists.ToArray(typeof(ChapterInfo)));
			}
		}

		private void 设选中小说为全本ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if ((this.bool_0 || this.backgroundWorker_10.IsBusy ? false : this.listView_2.CheckedItems.Count >= 1))
			{
				if (this.listView_2.CheckedItems.Count <= 1)
				{
					this.toolStripStatusLabel_0.Text = Localization.Get("正准备设为全本..");
					NovelInfo tag = (NovelInfo)this.listView_2.CheckedItems[0].Tag;
					switch (MessageBox.Show(string.Concat(Localization.Get("是否把《"), tag.Name, Localization.Get("》设置为完结小说！是为全本，否为连载！")), "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
					{
						case System.Windows.Forms.DialogResult.Yes:
						{
							this.bool_0 = true;
							this.panel_2.Enabled = false;
							this.listView_0.Tag = tag;
							tag.MDegree = 1;
							tag.Degree = 1;
							this.backgroundWorker_10.RunWorkerAsync(tag);
							break;
						}
						case System.Windows.Forms.DialogResult.No:
						{
							this.bool_0 = true;
							this.panel_2.Enabled = false;
							this.listView_0.Tag = tag;
							tag.MDegree = 0;
							tag.Degree = 0;
							this.backgroundWorker_10.RunWorkerAsync(tag);
							break;
						}
					}
					for (int i = 0; i < this.listView_2.Items.Count; i++)
					{
						this.listView_2.Items[i].Checked = false;
					}
				}
				else
				{
					MessageBox.Show(Localization.Get("请确认你只选择了一本小说！"));
				}
			}
		}

		private void 修改选中章节ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ChapterInfo tag;
			int i;
			NovelInfo novelInfo;
			object[] txtDir;
			int putID;
			string str;
			this.ReviseChapter.Dock = DockStyle.Fill;
			if (Configs.CmsName != "Qiwen")
			{
				if ((this.listView_1.CheckedItems.Count == 1 || this.bool_0 ? true : this.backgroundWorker_0.IsBusy))
				{
					this.ReviseChapter.Visible = true;
					ArrayList arrayLists = new ArrayList();
					for (i = 0; i < this.listView_1.Items.Count; i++)
					{
						if (this.listView_1.Items[i].Checked)
						{
							novelInfo = (NovelInfo)this.listView_0.Tag;
							tag = (ChapterInfo)this.listView_1.Items[i].Tag;
							this.articlenameBox.Text = novelInfo.Name;
							this.posterBox.Text = novelInfo.Author;
							this.sortBox.Items.Clear();
							for (int j = 1; j < (int)NovelSpider.Local.Jieqi.Config.JieqiSort.Length; j++)
							{
								this.sortBox.Items.Add(NovelSpider.Local.Jieqi.Config.JieqiSort[j]);
							}
							this.sortBox.SelectedItem = novelInfo.LagerSort;
							this.chapterNameBox.Text = tag.ChapterName;
							txtDir = new object[] { NovelSpider.Local.Jieqi.Config.TxtDir, "/", novelInfo.PutID / 1000, "/", novelInfo.PutID.ToString(), "/", null, null };
							putID = tag.PutID;
							txtDir[6] = putID.ToString();
							txtDir[7] = ".txt";
							str = string.Concat(txtDir);
							if (!File.Exists(str))
							{
								tag.ChapterText = Localization.Get("恭喜中奖了！又碰到无TXT文本的章节！或些章节为图片章节！");
							}
							else
							{
								tag.ChapterText = File.ReadAllText(str, Encoding.Default);
							}
							this.chapterTXTBox.Text = tag.ChapterText;
						}
					}
				}
				else if (this.listView_1.CheckedItems.Count <= 1)
				{
					MessageBox.Show(Localization.Get("你妹的，你不选择章节我应该怎么处理？"));
				}
				else
				{
					MessageBox.Show(Localization.Get("我干你选择这么多章节让准备让我修改那个章节！"));
				}
			}
			else if ((this.listView_1.CheckedItems.Count == 1 || this.bool_0 ? true : this.backgroundWorker_0.IsBusy))
			{
				this.ReviseChapter.Visible = true;
				ArrayList arrayLists1 = new ArrayList();
				for (i = 0; i < this.listView_1.Items.Count; i++)
				{
					if (this.listView_1.Items[i].Checked)
					{
						novelInfo = (NovelInfo)this.listView_0.Tag;
						tag = (ChapterInfo)this.listView_1.Items[i].Tag;
						this.articlenameBox.Text = novelInfo.Name;
						this.posterBox.Text = novelInfo.Author;
						this.sortBox.Items.Clear();
						this.sortBox.Items.Add(novelInfo.LagerSort);
						this.sortBox.SelectedItem = novelInfo.LagerSort;
						this.sortBox.Enabled = false;
						this.chapterNameBox.Text = tag.ChapterName;
						txtDir = new object[] { NovelSpider.Local.Qiwen.Config.WaterSoftPath, "/files/article/txt/", novelInfo.PutID / 1000, "/", novelInfo.PutID.ToString(), "/", null, null };
						putID = tag.PutID;
						txtDir[6] = putID.ToString();
						txtDir[7] = ".txt";
						str = string.Concat(txtDir);
						if (!File.Exists(str))
						{
							tag.ChapterText = Localization.Get("恭喜中奖了！又碰到无TXT文本的章节！或些章节为图片章节！");
						}
						else
						{
							tag.ChapterText = File.ReadAllText(str, Encoding.Default);
						}
						this.chapterTXTBox.Text = tag.ChapterText;
					}
				}
			}
			else if (this.listView_1.CheckedItems.Count <= 1)
			{
				MessageBox.Show(Localization.Get("你妹的，你不选择章节我应该怎么处理？"));
			}
			else
			{
				MessageBox.Show(Localization.Get("我干你选择这么多章节让准备让我修改那个章节！"));
			}
		}

		private void 选中后续并采集ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			bool flag = false;
			for (int i = 0; i < this.listView_0.Items.Count; i++)
			{
				if (this.listView_0.Items[i].Checked)
				{
					flag = true;
				}
				if (flag)
				{
					this.listView_0.Items[i].Checked = true;
				}
			}
			if ((this.listView_0.CheckedItems.Count == 0 || this.bool_0 ? false : !this.backgroundWorker_6.IsBusy))
			{
				this.bool_0 = true;
				this.panel_2.Enabled = false;
				this.toolStripStatusLabel_0.Text = Localization.Get("正在采集章节.请勿进行其他操作..");
				ArrayList arrayLists = new ArrayList();
				for (int j = 0; j < this.listView_0.Items.Count; j++)
				{
					if (this.listView_0.Items[j].Checked)
					{
						ChapterInfo tag = (ChapterInfo)this.listView_0.Items[j].Tag;
						arrayLists.Add(tag);
					}
				}
				this.novelInfo_0 = (NovelInfo)this.listView_0.Tag;
				ChapterInfo[] array = (ChapterInfo[])arrayLists.ToArray(typeof(ChapterInfo));
				arrayLists.Clear();
				this.backgroundWorker_6.RunWorkerAsync(array);
			}
		}

		private void 选中后续章节ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			bool flag = false;
			for (int i = 0; i < this.listView1.Items.Count; i++)
			{
				if (this.listView1.Items[i].Checked)
				{
					flag = true;
				}
				if (flag)
				{
					this.listView1.Items[i].Checked = true;
				}
			}
		}

		private void 选中中间章节ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int num = 0;
			int num1 = -1;
			int num2 = -1;
			for (int i = 0; i < this.listView_1.Items.Count; i++)
			{
				if (this.listView_1.Items[i].Checked)
				{
					num++;
					if (num1 != -1)
					{
						num2 = i;
					}
					else
					{
						num1 = i;
					}
				}
			}
			if (num == 2)
			{
				for (int j = num1 + 1; j < num2; j++)
				{
					this.listView_1.Items[j].Checked = true;
				}
			}
			else
			{
				MessageBox.Show(Localization.Get("只能选择前后两项"));
			}
		}

		private void 选中中间章节ToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			int num = 0;
			int num1 = -1;
			int num2 = -1;
			for (int i = 0; i < this.listView_0.Items.Count; i++)
			{
				if (this.listView_0.Items[i].Checked)
				{
					num++;
					if (num1 != -1)
					{
						num2 = i;
					}
					else
					{
						num1 = i;
					}
				}
			}
			if (num == 2)
			{
				for (int j = num1 + 1; j < num2; j++)
				{
					this.listView_0.Items[j].Checked = true;
				}
			}
			else
			{
				MessageBox.Show(Localization.Get("只能选择前后两项"));
			}
		}
	}
}