using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ActiveCampWPF
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        
        
        void App_Startup(object sender, StartupEventArgs e)
        {
            // Application is running
            // Process command line args
            //bool startMinimized = false;
            //for (int i = 0; i != e.Args.Length; ++i)
            //{
            //    if (e.Args[i] == "/StartMinimized")
            //    {
            //        startMinimized = true;
            //    }
            //}

            // Create main application window, starting minimized if specified
            MainWindow mainWindow = new MainWindow();
            mainWindow.Person_Validate.IsEnabled = true;
            mainWindow.Person_Validate.Visibility = Visibility.Visible;
            mainWindow.Show();
        }
    }
}
