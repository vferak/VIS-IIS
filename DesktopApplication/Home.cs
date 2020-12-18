using System;
using System.Windows.Forms;

namespace DesktopApplication
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }
        
        private void ShowContent(Control content)
        {
            ContentPanel.Controls.Clear();
            ContentPanel.Controls.Add(content);
            content.Dock = DockStyle.Fill;
        }

        private void výpisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowContent(new Tasks.Index());
        }

        private void novýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowContent(new Tasks.Form());
        }

        private void výpisToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowContent(new Clients.Index());
        }

        private void novýToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowContent(new Clients.Form());
        }
    }
}