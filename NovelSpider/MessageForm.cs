using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace NovelSpider
{
	public class MessageForm : Form
	{
		private IContainer icontainer_0;

		public TextBox MessageText;

		public MessageForm()
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MessageForm));
			base.SuspendLayout();
			base.ClientSize = new System.Drawing.Size(284, 262);
			base.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "MessageForm";
			base.ResumeLayout(false);
		}
	}
}