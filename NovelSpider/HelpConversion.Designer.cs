using NovelSpider.Common;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace NovelSpider
{
	public class HelpConversion : DockContent
	{
		private Button button_0;

		private Button button_1;

		private DateTimePicker dateTimePicker_0;

		private IContainer icontainer_0;

		private NumericUpDown numericUpDown_0;

		public HelpConversion()
		{
			Class19.Q77LubhzKM3NS();
			this.InitializeComponent();
		}

		private void button_0_Click(object sender, EventArgs e)
		{
			this.dateTimePicker_0.Value = FormatText.GetTime((long)Convert.ToInt32(this.numericUpDown_0.Value));
		}

		private void button_1_Click(object sender, EventArgs e)
		{
			this.numericUpDown_0.Value = FormatText.GetTime(this.dateTimePicker_0.Value);
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(HelpConversion));
			this.dateTimePicker_0 = new DateTimePicker();
			this.button_0 = new Button();
			this.button_1 = new Button();
			this.numericUpDown_0 = new NumericUpDown();
			((ISupportInitialize)this.numericUpDown_0).BeginInit();
			base.SuspendLayout();
			this.dateTimePicker_0.CustomFormat = "yyyy/MM/dd HH:mm:ss";
			this.dateTimePicker_0.Format = DateTimePickerFormat.Custom;
			this.dateTimePicker_0.Location = new Point(12, 12);
			this.dateTimePicker_0.Name = "dateTimePicker_0";
			this.dateTimePicker_0.Size = new System.Drawing.Size(156, 21);
			this.dateTimePicker_0.TabIndex = 0;
			this.button_0.Location = new Point(12, 39);
			this.button_0.Name = "button_0";
			this.button_0.Size = new System.Drawing.Size(75, 23);
			this.button_0.TabIndex = 1;
			this.button_0.Text = Localization.Get("换算↑");
			this.button_0.UseVisualStyleBackColor = true;
			this.button_0.Click += new EventHandler(this.button_0_Click);
			this.button_1.Location = new Point(93, 39);
			this.button_1.Name = "button_1";
			this.button_1.Size = new System.Drawing.Size(75, 23);
			this.button_1.TabIndex = 2;
			this.button_1.Text = Localization.Get("换算↓");
			this.button_1.UseVisualStyleBackColor = true;
			this.button_1.Click += new EventHandler(this.button_1_Click);
			this.numericUpDown_0.Location = new Point(12, 68);
			NumericUpDown numericUpDown0 = this.numericUpDown_0;
			int[] numArray = new int[] { 1215752191, 23, 0, 0 };
			numericUpDown0.Maximum = new decimal(numArray);
			this.numericUpDown_0.Name = "numericUpDown_0";
			this.numericUpDown_0.Size = new System.Drawing.Size(156, 21);
			this.numericUpDown_0.TabIndex = 3;
			base.ClientSize = new System.Drawing.Size(180, 102);
			base.Controls.Add(this.numericUpDown_0);
			base.Controls.Add(this.button_1);
			base.Controls.Add(this.button_0);
			base.Controls.Add(this.dateTimePicker_0);
			this.Font = new System.Drawing.Font(Localization.Font, 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
			base.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "HelpConversion";
			this.Text = Localization.Get("换算");
			((ISupportInitialize)this.numericUpDown_0).EndInit();
			base.ResumeLayout(false);
		}
	}
}