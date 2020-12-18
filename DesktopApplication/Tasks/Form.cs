using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DesktopApplication.Engine;

namespace DesktopApplication.Tasks
{
    public partial class Form : UserControl
    {
        private DomainLayer.Models.Tasks Task { get; set; }
        
        public Form(DomainLayer.Models.Tasks task = null)
        {
            InitializeComponent();

            var clients = new DomainLayer.Models.Clients(Program.Connection).Load().ToList();
            
            foreach (var client in clients)
            {
                clientComboBox.Items.Add(new Item<DomainLayer.Models.Clients>(client, client.Name));
            }

            var rates = new DomainLayer.Models.Tasks(Program.Connection).GetRates();
            
            foreach (var rate in rates)
            {
                rateComboBox.Items.Add(new Item<KeyValuePair<string, int>>(rate, rate.Key));
            }

            if (task == null)
            {
                rateComboBox.SelectedItem = rateComboBox.Items[0];
                return;
            }

            var selectedClient = clients.Find(i => i.ModelId == task.ClientModelId);
            var selectedRate = rates.ToList().Find(i => i.Value == task.Rate);
            
            Task = task;
            clientComboBox.SelectedIndex = clientComboBox.FindStringExact(selectedClient?.Name);
            titleTextBox.Text = task.Title;
            expectedTimeTextBox.Text = task.ExpectedTime.ToString();
            expectedDatePicker.Value = task.ExpectedDate.GetValueOrDefault();
            rateComboBox.SelectedIndex = rateComboBox.FindStringExact(selectedRate.Key);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task ??= new DomainLayer.Models.Tasks(Program.Connection);
            
            Task.ClientModelId = ((Item<DomainLayer.Models.Clients>)clientComboBox.SelectedItem)?.Model.ModelId;
            Task.Title = titleTextBox.Text;
            Task.ExpectedTime = int.Parse(expectedTimeTextBox.Text);
            Task.ExpectedDate = expectedDatePicker.Value;
            Task.Rate = ((Item<KeyValuePair<string, int>>)rateComboBox.SelectedItem).Model.Value;

            Task.Save();

            this.Redirect(new Show(Task));
        }
    }
}