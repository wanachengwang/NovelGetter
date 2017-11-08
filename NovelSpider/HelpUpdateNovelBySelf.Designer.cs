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
	public class HelpUpdateNovelBySelf : DockContent
	{
		private BackgroundWorker backgroundWorker_0;

		private Button button_0;

		private Button button_1;

		private IContainer icontainer_0;

		private int int_0;

		private int int_1;

		private Label label_0;

		private Label label_1;

		private Label label_2;

		private TextBox textBox_0;

		private TextBox textBox_1;

		public HelpUpdateNovelBySelf()
		{
			Class19.Q77LubhzKM3NS();
			this.InitializeComponent();
		}

		private void backgroundWorker_0_DoWork(object sender, DoWorkEventArgs e)
		{
			int int0 = this.int_0;
			while (int0 <= this.int_1)
			{
				if (this.backgroundWorker_0.CancellationPending)
				{
					e.Cancel = true;
					break;
				}
				else
				{
					this.backgroundWorker_0.ReportProgress(0, int0);
					try
					{
						NovelInfo novelInfo = new NovelInfo()
						{
							PutID = int0
						};
						LocalProvider.GetInstance().UpdateLastChapter(novelInfo);
					}
					catch
					{
					}
					int0++;
				}
			}
		}

		private void backgroundWorker_0_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			this.label_2.Text = e.UserState.ToString();
		}

		private void backgroundWorker_0_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.button_0.Enabled = true;
		}

		private void button_0_Click(object sender, EventArgs e)
		{
			this.int_0 = Convert.ToInt32(this.textBox_0.Text);
			this.int_1 = Convert.ToInt32(this.textBox_1.Text);
			if (!this.backgroundWorker_0.IsBusy)
			{
				this.button_0.Enabled = false;
				this.backgroundWorker_0.RunWorkerAsync();
			}
		}

		private void button_1_Click(object sender, EventArgs e)
		{
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(HelpUpdateNovelBySelf));
			this.textBox_0 = new TextBox();
			this.label_0 = new Label();
			this.label_1 = new Label();
			this.textBox_1 = new TextBox();
			this.button_0 = new Button();
			this.button_1 = new Button();
			this.label_2 = new Label();
			this.backgroundWorker_0 = new BackgroundWorker();
			base.SuspendLayout();
			this.textBox_0.Location = new Point(71, 12);
			this.textBox_0.Name = "textBox_0";
			this.textBox_0.Size = new System.Drawing.Size(156, 21);
			this.textBox_0.TabIndex = 0;
			this.label_0.AutoSize = true;
			this.label_0.Location = new Point(12, 15);
			this.label_0.Name = "label_0";
			this.label_0.Size = new System.Drawing.Size(53, 12);
			this.label_0.TabIndex = 1;
			this.label_0.Text = Localization.Get("最小ID：");
			this.label_1.AutoSize = true;
			this.label_1.Location = new Point(12, 42);
			this.label_1.Name = "label_1";
			this.label_1.Size = new System.Drawing.Size(53, 12);
			this.label_1.TabIndex = 3;
			this.label_1.Text = Localization.Get("最大ID：");
			this.textBox_1.Location = new Point(71, 39);
			this.textBox_1.Name = "textBox_1";
			this.textBox_1.Size = new System.Drawing.Size(156, 21);
			this.textBox_1.TabIndex = 2;
			this.button_0.Location = new Point(71, 66);
			this.button_0.Name = "button_0";
			this.button_0.Size = new System.Drawing.Size(75, 23);
			this.button_0.TabIndex = 4;
			this.button_0.Text = Localization.Get("运行");
			this.button_0.UseVisualStyleBackColor = true;
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.button_1.Location = new Point(152, 66);
			this.button_1.Name = "button_1";
			this.button_1.Size = new System.Drawing.Size(75, 23);
			this.button_1.TabIndex = 5;
			this.button_1.Text = Localization.Get("停止");
			this.button_1.UseVisualStyleBackColor = true;
			this.button_1.Click += new EventHandler(this.button_1_Click);
			this.label_2.AutoSize = true;
			this.label_2.Location = new Point(12, 111);
			this.label_2.Name = "label_2";
			this.label_2.Size = new System.Drawing.Size(41, 12);
			this.label_2.TabIndex = 6;
			this.label_2.Text = "label3";
			this.backgroundWorker_0.WorkerReportsProgress = true;
			this.backgroundWorker_0.WorkerSupportsCancellation = true;
			this.backgroundWorker_0.DoWork += new DoWorkEventHandler(this.backgroundWorker_0_DoWork);
			this.backgroundWorker_0.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker_0_RunWorkerCompleted);
			this.backgroundWorker_0.ProgressChanged += new ProgressChangedEventHandler(this.backgroundWorker_0_ProgressChanged);
			base.ClientSize = new System.Drawing.Size(253, 144);
			base.Controls.Add(this.label_2);
			base.Controls.Add(this.button_1);
			base.Controls.Add(this.button_0);
			base.Controls.Add(this.label_1);
			base.Controls.Add(this.textBox_1);
			base.Controls.Add(this.label_0);
			base.Controls.Add(this.textBox_0);
			this.Font = new System.Drawing.Font(Localization.Get("宋体"), 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
			base.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "HelpUpdateNovelBySelf";
			this.Text = Localization.Get("更新小说信息");
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}