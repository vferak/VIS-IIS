using System;
using System.Windows.Forms;

namespace DesktopApplication
{
    public partial class Window : Form
    {
        public Window()
        {
            InitializeComponent();
            
            ShowContent(new Home());
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

        private void novýToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ShowContent(new Users.Form());
        }

        private void výpisToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ShowContent(new Users.Index());
        }

        private void novýToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ShowContent(new UsersVacations.Form());
        }

        private void výpisToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ShowContent(new UsersVacations.Index());
        }

        private void iISToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowContent(new Home());
        }
    }
}