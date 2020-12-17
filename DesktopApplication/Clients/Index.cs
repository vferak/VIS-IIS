using System.Linq;
using System.Windows.Forms;

namespace DesktopApplication.Clients
{
    public partial class Index : UserControl
    {
        public Index()
        {
            InitializeComponent();
            
            foreach (var client in new DomainLayer.Models.Clients(Program.Connection).Load())
            {
                listBox.Items.Insert(client.ModelId.GetValueOrDefault(), client.Name);
            }
        }
    }
}