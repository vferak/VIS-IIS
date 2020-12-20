using System;
using System.Windows.Forms;

namespace DesktopApplication.UsersVacations
{
    public partial class Index : UserControl
    {
        public Index()
        {
            InitializeComponent();
            
            foreach (var vacation in new DomainLayer.Models.UsersVacations(Program.Connection).Load())
            {
                listBox.Items.Add(new Item<DomainLayer.Models.UsersVacations>(vacation, vacation.Text));
            }
        }

        private void listBox_DoubleClick(object sender, EventArgs e)
        {
            if (listBox.SelectedItem == null) return;
            
            var vacation = ((Item<DomainLayer.Models.UsersVacations>)listBox.SelectedItem).Model;
            this.Redirect(new Show(vacation));
        }
    }
}