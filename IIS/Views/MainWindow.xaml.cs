using System;
using System.Windows;
using System.Xml;
using IIS.Engine;
using IIS.Models;

namespace IIS.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            var test = Test(new MSSQL<Tasks>());

            InitializeComponent();
        }

        private bool Test(Database<Tasks> database)
        {
            var task = new Tasks(database)
            {
                ClientModelId = 2,
                UserModelId = 2,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
                Title = "Update úkol",
                ExpectedTime = 50,
                ExpectedDate = DateTime.Now,
                Rate = 600
            };
            
            task.Connection.Save();

            task = task.Connection.LoadOne();

            task.Title = "Jsem updatnutý";
            task.ModifiedAt = DateTime.Now;
            task.Connection.Save();
            
            task.Connection.Delete();

            return true;
        }
        
    }
}