using NovelSpider.Config;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace NovelSpider
{
	public class NovelSpiderUpdate : DockContent
	{
		private BackgroundWorker backgroundWorker_0;

		private ProgressBar CheckprogressBar;

		private IContainer icontainer_0;

		private Label label1;

		private Label label2;

		private Label label3;

		private Label label4;

		private Label NowVersion;

		private PictureBox pictureBox1;

		private ProgressBar progressBar1;

		private ProgressBar progressBar2;

		private Label RemoteVersion;

		private Button StartUpdateButton;

		private Button StopUpdateButton;

		private TextBox UpdateLog;

		public NovelSpiderUpdate()
		{
			Class19.Q77LubhzKM3NS();
			this.InitializeComponent();
		}

		private void backgroundWorker_0_DoWork(object sender, DoWorkEventArgs e)
		{
			this.backgroundWorker_0.ReportProgress(10, "开始检查采集器最新版本");
		}

		private void backgroundWorker_0_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			int progressPercentage = e.ProgressPercentage;
			if (progressPercentage == 10)
			{
				this.CheckprogressBar.Value = 10;
				this.UpdateLog.Text = string.Concat(this.UpdateLog.Text, "\r\n", e.UserState.ToString());
			}
			else if (progressPercentage == 20)
			{
				this.CheckprogressBar.Value = 20;
				this.UpdateLog.Text = string.Concat(this.UpdateLog.Text, "\r\n", e.UserState.ToString());
			}
		}

		private void backgroundWorker_0_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (e.Error != null)
			{
				this.UpdateLog.Text = string.Concat(this.UpdateLog.Text, "\r\n出现错误：", e.Error.Message);
			}
			else if (!e.Cancelled)
			{
				this.UpdateLog.Text = string.Concat(this.UpdateLog.Text, "\r\n版本检测完成");
			}
			else
			{
				this.UpdateLog.Text = string.Concat(this.UpdateLog.Text, "\r\n操作被用户取消");
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(NovelSpiderUpdate));
			this.UpdateLog = new TextBox();
			this.label1 = new Label();
			this.CheckprogressBar = new ProgressBar();
			this.progressBar1 = new ProgressBar();
			this.label2 = new Label();
			this.progressBar2 = new ProgressBar();
			this.label3 = new Label();
			this.StartUpdateButton = new Button();
			this.StopUpdateButton = new Button();
			this.label4 = new Label();
			this.NowVersion = new Label();
			this.RemoteVersion = new Label();
			this.backgroundWorker_0 = new BackgroundWorker();
			this.pictureBox1 = new PictureBox();
			((ISupportInitialize)this.pictureBox1).BeginInit();
			base.SuspendLayout();
			this.UpdateLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.UpdateLog.Location = new Point(174, 12);
			this.UpdateLog.Multiline = true;
			this.UpdateLog.Name = "UpdateLog";
			this.UpdateLog.ReadOnly = true;
			this.UpdateLog.ScrollBars = ScrollBars.Vertical;
			this.UpdateLog.Size = new System.Drawing.Size(436, 230);
			this.UpdateLog.TabIndex = 0;
			this.UpdateLog.Text = "欢迎使用关关采集更新管理器";
			this.label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			this.label1.AutoSize = true;
			this.label1.Location = new Point(172, 255);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(77, 12);
			this.label1.TabIndex = 2;
			this.label1.Text = "最新版本检测";
			this.CheckprogressBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.CheckprogressBar.Location = new Point(255, 255);
			this.CheckprogressBar.Name = "CheckprogressBar";
			this.CheckprogressBar.Size = new System.Drawing.Size(355, 12);
			this.CheckprogressBar.TabIndex = 11;
			this.progressBar1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.progressBar1.Location = new Point(255, 282);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(355, 12);
			this.progressBar1.TabIndex = 13;
			this.label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			this.label2.AutoSize = true;
			this.label2.Location = new Point(172, 282);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(77, 12);
			this.label2.TabIndex = 12;
			this.label2.Text = "文件下载进度";
			this.progressBar2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.progressBar2.Location = new Point(255, 311);
			this.progressBar2.Name = "progressBar2";
			this.progressBar2.Size = new System.Drawing.Size(355, 12);
			this.progressBar2.TabIndex = 15;
			this.label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			this.label3.AutoSize = true;
			this.label3.Location = new Point(172, 311);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(77, 12);
			this.label3.TabIndex = 14;
			this.label3.Text = "版本更新状态";
			this.StartUpdateButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			this.StartUpdateButton.Location = new Point(453, 329);
			this.StartUpdateButton.Name = "StartUpdateButton";
			this.StartUpdateButton.Size = new System.Drawing.Size(75, 23);
			this.StartUpdateButton.TabIndex = 16;
			this.StartUpdateButton.Text = "开始更新";
			this.StartUpdateButton.UseVisualStyleBackColor = true;
			this.StartUpdateButton.Click += new EventHandler(this.StartUpdateButton_Click);
			this.StopUpdateButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			this.StopUpdateButton.Location = new Point(534, 329);
			this.StopUpdateButton.Name = "StopUpdateButton";
			this.StopUpdateButton.Size = new System.Drawing.Size(75, 23);
			this.StopUpdateButton.TabIndex = 17;
			this.StopUpdateButton.Text = "取消";
			this.StopUpdateButton.UseVisualStyleBackColor = true;
			this.label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			this.label4.AutoSize = true;
			this.label4.ForeColor = Color.Red;
			this.label4.Location = new Point(221, 370);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(389, 12);
			this.label4.TabIndex = 18;
			this.label4.Text = "请在提示更新完成后关闭所有正在进行的采集并重新打开采集器完成更新";
			this.NowVersion.AutoSize = true;
			this.NowVersion.BackColor = Color.Transparent;
			this.NowVersion.ForeColor = Color.White;
			this.NowVersion.Location = new Point(12, 355);
			this.NowVersion.Name = "NowVersion";
			this.NowVersion.Size = new System.Drawing.Size(59, 12);
			this.NowVersion.TabIndex = 19;
			this.NowVersion.Text = "当前版本:";
			this.RemoteVersion.AutoSize = true;
			this.RemoteVersion.BackColor = Color.Transparent;
			this.RemoteVersion.ForeColor = Color.White;
			this.RemoteVersion.Location = new Point(12, 374);
			this.RemoteVersion.Name = "RemoteVersion";
			this.RemoteVersion.Size = new System.Drawing.Size(59, 12);
			this.RemoteVersion.TabIndex = 20;
			this.RemoteVersion.Text = "最新版本:";
			this.backgroundWorker_0.WorkerReportsProgress = true;
			this.backgroundWorker_0.WorkerSupportsCancellation = true;
			this.backgroundWorker_0.DoWork += new DoWorkEventHandler(this.backgroundWorker_0_DoWork);
			this.backgroundWorker_0.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker_0_RunWorkerCompleted);
			this.backgroundWorker_0.ProgressChanged += new ProgressChangedEventHandler(this.backgroundWorker_0_ProgressChanged);
			this.pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
			this.pictureBox1.InitialImage = null;
			this.pictureBox1.Location = new Point(0, -1);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(166, 425);
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			base.ClientSize = new System.Drawing.Size(622, 393);
			base.Controls.Add(this.RemoteVersion);
			base.Controls.Add(this.NowVersion);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.StopUpdateButton);
			base.Controls.Add(this.StartUpdateButton);
			base.Controls.Add(this.progressBar2);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.progressBar1);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.CheckprogressBar);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.pictureBox1);
			base.Controls.Add(this.UpdateLog);
			this.Font = new System.Drawing.Font(Localization.Get("宋体"), 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
			base.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "NovelSpiderUpdate";
			this.Text = "關關更新器";
			base.Load += new EventHandler(this.NovelSpiderUpdate_Load);
			((ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private void NovelSpiderUpdate_Load(object sender, EventArgs e)
		{
			this.pictureBox1.Controls.Add(this.NowVersion);
			this.pictureBox1.Controls.Add(this.RemoteVersion);
			this.NowVersion.Text = string.Concat(this.NowVersion.Text, "V", Configs.AssemblyVersion);
			this.backgroundWorker_0.RunWorkerAsync();
		}

		private void StartUpdateButton_Click(object sender, EventArgs e)
		{
		}
	}
}