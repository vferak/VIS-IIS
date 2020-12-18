using System;
using System.Windows.Forms;
using DesktopApplication.Engine;

namespace DesktopApplication.Clients
{
    public partial class Form : UserControl
    {
        private DomainLayer.Models.Clients Client { get; set; }
        
        public Form(DomainLayer.Models.Clients client = null)
        {
            InitializeComponent();

            if (client == null) return;

            Client = client;
            nameTextBox.Text = client.Name;
            contactFirstNameTextBox.Text = client.ContactFirstName;
            contactLastNameTextBox.Text = client.ContactLastName;
            contactEmailTextBox.Text = client.ContactEmail;
            contactPhoneTextBox.Text = client.ContactPhoneNumber.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Client ??= new DomainLayer.Models.Clients(Program.Connection);
            
            Client.Name = nameTextBox.Text;
            Client.ContactFirstName = contactFirstNameTextBox.Text;
            Client.ContactLastName = contactLastNameTextBox.Text;
            Client.ContactEmail = contactEmailTextBox.Text;
            Client.ContactPhoneNumber = int.Parse(contactPhoneTextBox.Text);

            Client.Save();

            this.Redirect(new Show(Client));
        }
    }
}