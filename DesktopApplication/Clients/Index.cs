using System;
using System.Windows.Forms;
using DesktopApplication.Engine;

namespace DesktopApplication.Clients
{
    public partial class Index : UserControl
    {
        public Index()
        {
            InitializeComponent();
            
            foreach (var client in new DomainLayer.Models.Clients(Program.Connection).Load())
            {
                listBox.Items.Add(new Item<DomainLayer.Models.Clients>(client, client.Name));
            }
        }

        private void listBox_DoubleClick(object sender, EventArgs e)
        {
            if (listBox.SelectedItem == null) return;
            
            var client = ((Item<DomainLayer.Models.Clients>)listBox.SelectedItem).Model;
            this.Redirect(new Show(client));
        }
    }
}