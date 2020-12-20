using System;
using System.Windows.Forms;

namespace DesktopApplication.UsersVacations
{
    public partial class Show : UserControl
    {
        private DomainLayer.Models.UsersVacations Vacation { get; set; }
        
        public Show(DomainLayer.Models.UsersVacations vacation)
        {
            InitializeComponent();
            
            Vacation = vacation;
            userLabel.Text = vacation.GetUser().GetFullName();
            dateFromLabel.Text = vacation.DateFrom.ToString();
            dateToLabel.Text = vacation.DateTo.ToString();
            acceptedLabel.Text = vacation.Accepted() ? "Ano" : "Ne";
            textLabel.Text = vacation.Text;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Redirect(new Index());
        }
        
        private void Edit_Click(object sender, EventArgs e)
        {
            this.Redirect(new Form(Vacation));
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            Vacation.Delete();
            this.Redirect(new Index());
        }
    }
}