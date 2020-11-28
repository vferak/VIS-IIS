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
            //var sql = new Tasks(new MSSQL<Tasks>()) {ModelId = 5}.Connection.Load();
            
            
            var task1 = new Tasks(new XML<Tasks>()){ModelId = 1}.Connection.LoadOne();

            var task = new Tasks(new XML<Tasks>())
            {
                ModelId = 10,
                ClientModelId = 4,
                UserModelId = 2,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
                Title = "Update úkol",
                ExpectedTime = 50,
                ExpectedDate = DateTime.Now
            };
            task.Connection.Save();

            InitializeComponent();
        }
        
    }
}