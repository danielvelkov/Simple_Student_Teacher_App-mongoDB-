using MongoDB.Driver;
using StudentTest.Model;
using StudentTest.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace StudentTest
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // set the starting window to be the Main View
            ApplicationMainView app = new ApplicationMainView();
            
            MainViewModel context = new MainViewModel();
            app.DataContext = context;
            app.Show();
            
        }
    }
}
