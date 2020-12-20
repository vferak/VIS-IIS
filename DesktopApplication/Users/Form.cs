using System;
using System.Windows.Forms;

namespace DesktopApplication.Users
{
    public partial class Form : UserControl
    {
        private DomainLayer.Models.Users User { get; set; }
        
        public Form(DomainLayer.Models.Users user = null)
        {
            InitializeComponent();

            var seniors = new DomainLayer.Models.Users(Program.Connection).LoadSeniors();
            
            foreach (var senior in seniors)
            {
                seniorComboBox.Items.Add(new Item<DomainLayer.Models.Users>(senior, senior.GetFullName()));
            }
            
            if (user == null) return;

            var selectedSenior = seniors.Find(i => i.ModelId == user.SeniorModelId);

            User = user;
            firstNameTextBox.Text = User.FirstName;
            lastNameTextBox.Text = User.LastName;
            usernameTextBox.Text = User.Username;
            passwordTextBox.Text = User.Password;
            emailTextBox.Text = User.Email;
            phoneTextBox.Text = User.PhoneNumber.ToString();
            seniorComboBox.SelectedIndex = seniorComboBox.FindStringExact(selectedSenior?.GetFullName());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User ??= new DomainLayer.Models.Users(Program.Connection);

            User.FirstName = firstNameTextBox.Text;
            User.LastName = lastNameTextBox.Text;
            User.Username = usernameTextBox.Text;
            User.Password = passwordTextBox.Text;
            User.Email = emailTextBox.Text;
            User.PhoneNumber = int.Parse(phoneTextBox.Text);
            User.SeniorModelId = ((Item<DomainLayer.Models.Users>)seniorComboBox.SelectedItem)?.Model.ModelId;

            User.Save();

            this.Redirect(new Show(User.LoadOne()));
        }
    }
}