using System;
using System.Windows.Forms;
using DesktopApplication.Engine;

namespace DesktopApplication.Clients
{
    public partial class Show : UserControl
    {
        private DomainLayer.Models.Clients Client { get; set; }
        
        public Show(DomainLayer.Models.Clients client)
        {
            InitializeComponent();

            Client = client;
            nameLabel.Text = client.Name;
            contactFirstNameLabel.Text = client.ContactFirstName;
            contactLastNameLabel.Text = client.ContactLastName;
            contactEmailLabel.Text = client.ContactEmail;
            contactPhoneLabel.Text = client.ContactPhoneNumber.ToString();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Redirect(new Index());
        }
        
        private void Edit_Click(object sender, EventArgs e)
        {
            this.Redirect(new Form(Client));
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            Client.Delete();
            this.Redirect(new Index());
        }
    }
}