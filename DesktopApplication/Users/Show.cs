using System;
using System.Windows.Forms;

namespace DesktopApplication.Users
{
    public partial class Show : UserControl
    {
        private DomainLayer.Models.Users User { get; set; }
        
        public Show(DomainLayer.Models.Users user)
        {
            InitializeComponent();

            User = user;
            firstNameLabel.Text = user.FirstName;
            lastNameLabel.Text = user.LastName;
            usernameLabel.Text = user.Username;
            passwordLabel.Text = user.Password;
            emailLabel.Text = user.Email;
            phoneLabel.Text = user.PhoneNumber.ToString();
            seniorLabel.Text = user.GetSenior()?.GetFullName();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Redirect(new Index());
        }
        
        private void Edit_Click(object sender, EventArgs e)
        {
            this.Redirect(new Form(User));
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            User.Delete();
            this.Redirect(new Index());
        }
    }
}