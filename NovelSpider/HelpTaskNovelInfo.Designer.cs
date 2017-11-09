using NovelSpider.Config;
using NovelSpider.Entity;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace NovelSpider
{
	public class HelpTaskNovelInfo : DockContent
	{
		private ColumnHeader columnHeader_0;

		private ColumnHeader columnHeader_1;

		private ColumnHeader columnHeader_2;

		private IContainer icontainer_0;

		private ListView listView_0;

		private IContainer components;

		private Timer timer_0;

		public HelpTaskNovelInfo()
		{
			Class19.Q77LubhzKM3NS();
			this.InitializeComponent();
		}

		protected override void Dispose(bool disposing)
		{
			if ((!disposing ? false : this.icontainer_0 != null))
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		private void HelpTaskNovelInfo_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.timer_0.Stop();
		}

		private void HelpTaskNovelInfo_Load(object sender, EventArgs e)
		{
			this.timer_0.Start();
		}

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(HelpTaskNovelInfo));
			this.listView_0 = new ListView();
			this.columnHeader_0 = new ColumnHeader();
			this.columnHeader_1 = new ColumnHeader();
			this.columnHeader_2 = new ColumnHeader();
			this.timer_0 = new Timer(this.components);
			base.SuspendLayout();
			ListView.ColumnHeaderCollection columns = this.listView_0.Columns;
			ColumnHeader[] columnHeader0 = new ColumnHeader[] { this.columnHeader_0, this.columnHeader_1, this.columnHeader_2 };
			columns.AddRange(columnHeader0);
			this.listView_0.Dock = DockStyle.Fill;
			this.listView_0.FullRowSelect = true;
			this.listView_0.Location = new Point(0, 0);
			this.listView_0.Name = "listView_0";
			this.listView_0.Size = new System.Drawing.Size(452, 169);
			this.listView_0.TabIndex = 0;
			this.listView_0.UseCompatibleStateImageBehavior = false;
			this.listView_0.View = View.Details;
			this.columnHeader_0.Text = Localization.Get("子窗口ID");
			this.columnHeader_0.Width = 200;
			this.columnHeader_1.Text = Localization.Get("小说编号");
			this.columnHeader_2.Text = Localization.Get("小说名称");
			this.columnHeader_2.Width = 150;
			this.timer_0.Interval = 1000;
			this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
			base.ClientSize = new System.Drawing.Size(452, 169);
			base.Controls.Add(this.listView_0);
			this.Font = new System.Drawing.Font(Localization.Font, 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
			base.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "HelpTaskNovelInfo";
			base.ShowInTaskbar = false;
			this.Text = Localization.Get("子窗口冲突监控");
			base.Load += new EventHandler(this.HelpTaskNovelInfo_Load);
			base.FormClosing += new FormClosingEventHandler(this.HelpTaskNovelInfo_FormClosing);
			base.ResumeLayout(false);
		}

		private void timer_0_Tick(object sender, EventArgs e)
		{
			this.listView_0.Items.Clear();
			int num = 0;
			ICollection keys = Configs.TaskNovelInfo.Keys;
			if (Configs.TaskNovelInfo.Count != 0)
			{
				foreach (string key in keys)
				{
					if (Configs.TaskNovelInfo[key] == null)
					{
						this.listView_0.Items.Insert(num, key);
					}
					else
					{
						NovelInfo item = (NovelInfo)Configs.TaskNovelInfo[key];
						string[] str = new string[] { key, item.PutID.ToString(), item.Name };
						string[] strArrays = str;
						this.listView_0.Items.Insert(num, new ListViewItem(strArrays));
					}
					num++;
				}
			}
		}
	}
}