using NovelSpider.Common;
using NovelSpider.Config;
using NovelSpider.Entity;
using NovelSpider.Target;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Threading;
using System.Windows.Forms;

namespace NovelSpider
{
	public class RuleTestForm : Form
	{
		private BackgroundWorker backgroundWorker_0;

		private IContainer icontainer_0;

		private RuleConfigInfo ruleConfigInfo_0;

		private string string_0;

		private string string_1;

		private TaskConfigInfo taskConfigInfo_0;

		private RichTextBox TestResult;

		public string ChapterID
		{
			get
			{
				return this.string_1;
			}
			set
			{
				this.string_1 = value;
			}
		}

		public string NovelID
		{
			get
			{
				return this.string_0;
			}
			set
			{
				this.string_0 = value;
			}
		}

		public RuleConfigInfo Rule
		{
			get
			{
				return this.ruleConfigInfo_0;
			}
			set
			{
				this.ruleConfigInfo_0 = value;
			}
		}

		public TaskConfigInfo Task
		{
			get
			{
				return this.taskConfigInfo_0;
			}
			set
			{
				this.taskConfigInfo_0 = value;
			}
		}

		public RuleTestForm()
		{
			Class19.Q77LubhzKM3NS();
			this.InitializeComponent();
		}

		private void backgroundWorker_0_DoWork(object sender, DoWorkEventArgs e)
		{
			NovelInfo novelInfo;
			string[] getID;
			NovelInfo chapterInfo;
			object[] chapterUrl;
			BackgroundWorker backgroundWorker = sender as BackgroundWorker;
			Page page = new Page(this.ruleConfigInfo_0, this.taskConfigInfo_0);
			backgroundWorker.ReportProgress(0, Localization.Get("====== 开始测试获得最新列表 ======"));
			string str = this.ruleConfigInfo_0.NovelListUrl.Pattern.Replace("\r\n", "♂");
			char[] chrArray = new char[] { '\u2642' };
			NovelInfo[] novelList = page.GetNovelList(str.Split(chrArray));
			if ((int)novelList.Length == 0)
			{
				throw new ApplicationException(Localization.Get("没有获得小说列表"));
			}
			string str1 = "";
			for (int i = 0; i < (int)novelList.Length; i++)
			{
				getID = new string[] { str1, novelList[i].GetID, "\t", novelList[i].Name, "\n" };
				str1 = string.Concat(getID);
			}
			backgroundWorker.ReportProgress(0, str1);
			backgroundWorker.ReportProgress(0, "");
			backgroundWorker.ReportProgress(0, Localization.Get("====== 开始测试小说信息页 ======"));
			Random random = new Random();
			novelInfo = ((this.string_0 == "0" ? true : this.string_0 == "") ? novelList[random.Next((int)novelList.Length)] : new NovelInfo()
			{
				GetID = this.string_0
			});
			NovelInfo novelInfo1 = page.GetNovelInfo(novelInfo);
			string str2 = "获取失败";
			if (novelInfo1.Cover != null)
			{
				str2 = "获取成功";
			}
			getID = new string[] { "NovelUrl:\t", novelInfo1.NovelUrl.AbsolutePath, "\nNovelName:\t", novelInfo1.Name, "\nNovelAuthor:\t", novelInfo1.Author, "\nLagerSort:\t", novelInfo1.LagerSort, "\nSmallSort:\t", novelInfo1.SmallSort, "\nNovelIntro:\t", novelInfo1.Intro, "\nNovelKeyword:\t", novelInfo1.Keyword, "\nNovelCover:\t", str2, "\nNovelDegree:\t", novelInfo1.Degree.ToString() };
			backgroundWorker.ReportProgress(0, string.Concat(getID));
			backgroundWorker.ReportProgress(0, "");
			backgroundWorker.ReportProgress(0, Localization.Get("====== 开始测试章节目录页 ======"));
			Thread.Sleep(100);
			backgroundWorker.ReportProgress(0, string.Concat("PubIndexUrl\t", novelInfo1.IndexUrl));
			ChapterInfo[] chapterList = page.GetChapterList(novelInfo1, true);
			if ((int)chapterList.Length == 0)
			{
				throw new ApplicationException(Localization.Get("没有获得章节列表"));
			}
			string str3 = "";
			int num = FormatText.GetInt(this.ruleConfigInfo_0.PubContentChapterNum.Pattern, 0);
			for (int j = 0; j < (int)chapterList.Length; j++)
			{
				getID = new string[] { str3, chapterList[j].GetID, "\t", chapterList[j].VolumeName, "\t", chapterList[j].ChapterName };
				str3 = string.Concat(getID);
				str3 = (((int)chapterList.Length - j > num ? true : !(this.ruleConfigInfo_0.PubContentChapterName.Pattern != "")) ? string.Concat(str3, "\n") : string.Concat(str3, "\t[新]\n"));
			}
			backgroundWorker.ReportProgress(0, str3);
			backgroundWorker.ReportProgress(0, "");
			backgroundWorker.ReportProgress(0, Localization.Get("====== 开始测试章节内容页 ======"));
			Thread.Sleep(100);
			if (this.string_1 != "0")
			{
				int num1 = 0;
				while (num1 < (int)chapterList.Length)
				{
					if (chapterList[num1].GetID == this.string_1)
					{
						novelInfo1.LastChapter = chapterList[num1];
						chapterInfo = page.GetChapterInfo(novelInfo1, false);
						chapterUrl = new object[] { "PubContentUrl:\t", chapterInfo.LastChapter.ChapterUrl, "\nPubTextUrl:\t", chapterInfo.LastChapter.TextUrl };
						backgroundWorker.ReportProgress(0, string.Concat(chapterUrl));
						chapterInfo.LastChapter.ChapterText = page.Replace(chapterInfo.LastChapter.ChapterText, this.ruleConfigInfo_0.PubContentReplace);
						backgroundWorker.ReportProgress(0, string.Concat("PubContentText:\t", chapterInfo.LastChapter.ChapterText));
						return;
					}
					else
					{
						num1++;
					}
				}
			}
			else
			{
				novelInfo1.LastChapter = chapterList[random.Next((int)chapterList.Length)];
			}
			chapterInfo = page.GetChapterInfo(novelInfo1, false);
			chapterUrl = new object[] { "PubContentUrl:\t", chapterInfo.LastChapter.ChapterUrl, "\nPubTextUrl:\t", chapterInfo.LastChapter.TextUrl };
			backgroundWorker.ReportProgress(0, string.Concat(chapterUrl));
			chapterInfo.LastChapter.ChapterText = page.Replace(chapterInfo.LastChapter.ChapterText, this.ruleConfigInfo_0.PubContentReplace);
			backgroundWorker.ReportProgress(0, string.Concat("PubContentText:\t", chapterInfo.LastChapter.ChapterText));
		}

		private void backgroundWorker_0_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			this.TestResult.AppendText(string.Concat(e.UserState.ToString(), "\n"));
			this.TestResult.Focus();
			this.TestResult.Select(this.TestResult.TextLength, 0);
			this.TestResult.ScrollToCaret();
		}

		private void backgroundWorker_0_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (e.Error == null)
			{
				this.TestResult.AppendText(Localization.Get("测试结束！"));
				this.TestResult.Focus();
				this.TestResult.Select(this.TestResult.TextLength, 0);
				this.TestResult.ScrollToCaret();
			}
			else
			{
				this.TestResult.AppendText(string.Concat(Localization.Get("发生错误："), e.Error.Message, "\n"));
				this.TestResult.Focus();
				this.TestResult.Select(this.TestResult.TextLength, 0);
				this.TestResult.ScrollToCaret();
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(RuleTestForm));
			this.TestResult = new RichTextBox();
			this.backgroundWorker_0 = new BackgroundWorker();
			base.SuspendLayout();
			this.TestResult.Dock = DockStyle.Fill;
			this.TestResult.Location = new Point(0, 0);
			this.TestResult.Name = "TestResult";
			this.TestResult.Size = new System.Drawing.Size(530, 302);
			this.TestResult.TabIndex = 3;
			this.TestResult.Text = "";
			this.backgroundWorker_0.WorkerReportsProgress = true;
			this.backgroundWorker_0.WorkerSupportsCancellation = true;
			this.backgroundWorker_0.DoWork += new DoWorkEventHandler(this.backgroundWorker_0_DoWork);
			this.backgroundWorker_0.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker_0_RunWorkerCompleted);
			this.backgroundWorker_0.ProgressChanged += new ProgressChangedEventHandler(this.backgroundWorker_0_ProgressChanged);
			base.ClientSize = new System.Drawing.Size(530, 302);
			base.Controls.Add(this.TestResult);
			base.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "RuleTestForm";
			base.ShowInTaskbar = false;
			base.StartPosition = FormStartPosition.CenterParent;
			this.Text = Localization.Get("规则测试");
			base.Load += new EventHandler(this.RuleTestForm_Load);
			base.ResumeLayout(false);
		}

		private void RuleTestForm_Load(object sender, EventArgs e)
		{
			this.TestResult.Text = "";
			if (!this.backgroundWorker_0.IsBusy)
			{
				this.backgroundWorker_0.RunWorkerAsync();
			}
		}
	}
}