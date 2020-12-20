using System;
using System.Windows.Forms;

namespace DesktopApplication.Users
{
    public partial class Index : UserControl
    {
        public Index()
        {
            InitializeComponent();
            
            foreach (var user in new DomainLayer.Models.Users(Program.Connection).Load())
            {
                listBox.Items.Add(new Item<DomainLayer.Models.Users>(user, user.GetFullName()));
            }
        }

        private void listBox_DoubleClick(object sender, EventArgs e)
        {
            if (listBox.SelectedItem == null) return;
            
            var user = ((Item<DomainLayer.Models.Users>)listBox.SelectedItem).Model;
            this.Redirect(new Show(user));
        }
    }
}