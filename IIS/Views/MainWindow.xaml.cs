using System;
using System.Windows;
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
            var connection = new MSSQLConnection();

            var test = Test(connection);

            InitializeComponent();
        }

        private bool Test(Connection connection)
        {
            var task = new Tasks(connection)
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
            
            task.Save();

            task = task.LoadOne();

            task.Title = "Jsem updatnutý";
            task.ModifiedAt = DateTime.Now;
            task.Save();
            
            task.Delete();

            return true;
        }
        
    }
}