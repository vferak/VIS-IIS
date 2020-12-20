using System;
using System.Windows.Forms;

namespace DesktopApplication.Tasks
{
    public partial class Show : UserControl
    {
        private DomainLayer.Models.Tasks Task { get; set; }
        
        public Show(DomainLayer.Models.Tasks task)
        {
            InitializeComponent();

            Task = task;
            clientLabel.Text = new DomainLayer.Models.Clients(Program.Connection){ ModelId = task.ClientModelId }.Database.LoadOne().Name;
            titleLabel.Text = task.Title;
            expectedTimeLabel.Text = task.ExpectedTime.ToString();
            expectedDateLabel.Text = task.ExpectedDate.ToString();
            rateLabel.Text = task.Rate.ToString();
            
            foreach (var taskEvent in new DomainLayer.Models.TasksEvents(Program.Connection){TaskModelId = task.ModelId}.Load())
            {
                eventsListBox.Items.Add(new Item<DomainLayer.Models.TasksEvents>(taskEvent, taskEvent.Status));
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Redirect(new Index());
        }
        
        private void Edit_Click(object sender, EventArgs e)
        {
            this.Redirect(new Form(Task));
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            Task.Delete();
            this.Redirect(new Index());
        }
    }
}