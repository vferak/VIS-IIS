using System;
using System.Windows.Forms;

namespace DesktopApplication.UsersVacations
{
    public partial class Form : UserControl
    {
        private DomainLayer.Models.UsersVacations Vacation { get; set; }
        
        public Form(DomainLayer.Models.UsersVacations vacation = null)
        {
            InitializeComponent();

            if (vacation == null) return;

            Vacation = vacation;
            dateFromPicker.Value = vacation.DateFrom.GetValueOrDefault();
            dateToPicker.Value = vacation.DateTo.GetValueOrDefault();
            textBox.Text = vacation.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Vacation ??= new DomainLayer.Models.UsersVacations(Program.Connection);

            Vacation.UserModelId ??= Program.LoggedUserId;
            Vacation.DateFrom = dateFromPicker.Value;
            Vacation.DateTo = dateToPicker.Value;
            Vacation.Text = textBox.Text;

            Vacation.Save();

            this.Redirect(new Show(Vacation.LoadOne()));
        }
    }
}