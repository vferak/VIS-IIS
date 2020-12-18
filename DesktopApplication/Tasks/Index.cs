using System;
using System.Windows.Forms;
using DesktopApplication.Engine;

namespace DesktopApplication.Tasks
{
    public partial class Index : UserControl
    {
        public Index()
        {
            InitializeComponent();
            
            foreach (var task in new DomainLayer.Models.Tasks(Program.Connection).Load())
            {
                listBox.Items.Add(new Item<DomainLayer.Models.Tasks>(task, task.Title));
            }
        }

        private void listBox_DoubleClick(object sender, EventArgs e)
        {
            if (listBox.SelectedItem == null) return;
            
            var task = ((Item<DomainLayer.Models.Tasks>)listBox.SelectedItem).Model;
            this.Redirect(new Show(task));
        }
    }
}