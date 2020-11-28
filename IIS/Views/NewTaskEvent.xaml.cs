using System;
using System.Windows;
using System.Xml;
using IIS.Models;

namespace IIS.Views
{
    /// <summary>
    /// Interaction logic for NewTaskEvent.xaml
    /// </summary>
    public partial class NewTaskEvent : Window
    {
        public NewTaskEvent()
        {
            // var task = new Tasks(new SQL()) {ModelId = 5}.Connection.Load();// XML
            // var task = new Tasks(new Xml()) {ModelId = 5} .Load();// SQL

            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}