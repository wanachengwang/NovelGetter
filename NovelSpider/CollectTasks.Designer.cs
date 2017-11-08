using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace NovelSpider
{
	public class CollectTasks : DockContent
	{
		private Button button1;

		private TextBox FilterVolumeTextBox1;

		private GroupBox groupBox1;

		private IContainer icontainer_0;

		private Label label1;

		private MaskedTextBox maskedTextBox1;

		public CollectTasks()
		{
			Class19.Q77LubhzKM3NS();
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(CollectTasks));
			base.SuspendLayout();
			base.ClientSize = new System.Drawing.Size(284, 262);
			this.Font = new System.Drawing.Font(Localization.Get("宋体"), 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
			base.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "CollectTasks";
			base.ResumeLayout(false);
		}

		private void method_0()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(CollectTasks));
			this.button1 = new Button();
			this.maskedTextBox1 = new MaskedTextBox();
			this.label1 = new Label();
			this.groupBox1 = new GroupBox();
			this.FilterVolumeTextBox1 = new TextBox();
			this.groupBox1.SuspendLayout();
			base.SuspendLayout();
			this.button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			this.button1.Location = new Point(330, 205);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 6;
			this.button1.Text = Localization.Get("确认修改");
			this.button1.UseVisualStyleBackColor = true;
			this.maskedTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.maskedTextBox1.Location = new Point(81, 35);
			this.maskedTextBox1.Name = "maskedTextBox1";
			this.maskedTextBox1.Size = new System.Drawing.Size(318, 21);
			this.maskedTextBox1.TabIndex = 7;
			this.label1.AutoSize = true;
			this.label1.Location = new Point(16, 38);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 12);
			this.label1.TabIndex = 8;
			this.label1.Text = Localization.Get("章节名称");
			this.groupBox1.Controls.Add(this.FilterVolumeTextBox1);
			this.groupBox1.Location = new Point(12, 65);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(393, 134);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = Localization.Get("章节内容");
			this.FilterVolumeTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			this.FilterVolumeTextBox1.Location = new Point(6, 20);
			this.FilterVolumeTextBox1.Multiline = true;
			this.FilterVolumeTextBox1.Name = "FilterVolumeTextBox1";
			this.FilterVolumeTextBox1.ScrollBars = ScrollBars.Vertical;
			this.FilterVolumeTextBox1.Size = new System.Drawing.Size(381, 108);
			this.FilterVolumeTextBox1.TabIndex = 1;
			base.ClientSize = new System.Drawing.Size(417, 240);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.maskedTextBox1);
			base.Controls.Add(this.button1);
			this.Font = new System.Drawing.Font(Localization.Get("宋体"), 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
			base.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "CollectTasks";
			this.Text = Localization.Get("章节内容");
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}