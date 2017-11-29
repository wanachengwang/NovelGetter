//#define FONT_SELECT
using NovelSpider.Config;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace NovelSpider
{
	public class WelcomeForm : DockContent
	{
		private IContainer icontainer_0;

		private Label label_0;

#if FONT_SELECT
        private ComboBox comboFontSelect;
        private Button btnFontSelect;
#endif

        private Panel panel_0;

		private WebBrowser webBwr;

		public WelcomeForm()
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

		private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(WelcomeForm));
			this.panel_0 = new Panel();
			this.label_0 = new Label();
			this.webBwr = new WebBrowser();
			this.panel_0.SuspendLayout();
			base.SuspendLayout();
			this.panel_0.Controls.Add(this.label_0);

            int hPanel = 24;
#if FONT_SELECT
            this.comboFontSelect = new ComboBox();
            this.btnFontSelect = new Button();
            this.panel_0.Controls.Add(this.comboFontSelect);
            this.panel_0.Controls.Add(this.btnFontSelect);

            System.Drawing.Text.InstalledFontCollection fonts = new System.Drawing.Text.InstalledFontCollection();
            bool bPrevFontExist = false;
            foreach (System.Drawing.FontFamily ff in fonts.Families) {
                this.comboFontSelect.Items.Add(ff.Name);
                if (!bPrevFontExist && ff.Name == Localization.Font)
                    bPrevFontExist = true;
            }
            this.comboFontSelect.Location = new Point(12, 30);
            this.comboFontSelect.Name = "combo_fontselect";
            this.comboFontSelect.Size = new System.Drawing.Size(150, 12);
            this.comboFontSelect.TabIndex = 1;
            this.comboFontSelect.Text = Localization.Font;

            this.btnFontSelect.Location = new Point(180, 30);
            this.btnFontSelect.Name = "btn_fontselect";
            this.btnFontSelect.Size = new System.Drawing.Size(80, 20);
            this.btnFontSelect.TabIndex = 2;
            this.btnFontSelect.Text = "OK";
            this.btnFontSelect.Font = new System.Drawing.Font(Localization.Font, 9f, FontStyle.Bold, GraphicsUnit.Point, 134);
            this.btnFontSelect.Click += (a, b) => Localization.Font = this.comboFontSelect.Text;
            hPanel += 30;
#endif
            this.panel_0.Dock = DockStyle.Top;
			this.panel_0.Location = new Point(0, 0);
			this.panel_0.Name = "panel_0";
			this.panel_0.Size = new System.Drawing.Size(584, hPanel);
			this.panel_0.TabIndex = 0;
			this.label_0.AutoSize = true;
			this.label_0.Location = new Point(12, 9);
			this.label_0.Name = "label_0";
			this.label_0.Size = new System.Drawing.Size(305, 12);
			this.label_0.TabIndex = 0;
			this.label_0.Text = Localization.Get("本软件只为替代用户重复手工劳动。严禁用于非法转载。");

            this.webBwr.Dock = DockStyle.Fill;
			this.webBwr.Location = new Point(0, hPanel);
            this.webBwr.MinimumSize = new System.Drawing.Size(20, 20);
			this.webBwr.Name = "webBwr";
			this.webBwr.Size = new System.Drawing.Size(584, 262);
			this.webBwr.TabIndex = 3;
			base.ClientSize = new System.Drawing.Size(584, 316);
			base.Controls.Add(this.webBwr);
			base.Controls.Add(this.panel_0);
			this.Font = new System.Drawing.Font(Localization.Font, 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
			base.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "WelcomeForm";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = Localization.Get("最新消息");
			base.Load += new EventHandler(this.WelcomeForm_Load);
			this.panel_0.ResumeLayout(false);
			this.panel_0.PerformLayout();
			base.ResumeLayout(false);
		}

		private void WelcomeForm_Load(object sender, EventArgs e)
		{
			int num = (new Random()).Next(0, 1000);
			this.webBwr.Url = new Uri("http://biqu01.com/", UriKind.Absolute);
			Label label0 = this.label_0;
			object[] text = new object[] { label0.Text, " V", Configs.AssemblyVersion, " Build ", Configs.Build.ToShortDateString() };
			label0.Text = string.Concat(text);
		}
	}
}