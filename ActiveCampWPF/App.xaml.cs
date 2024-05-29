using ActiveCamp.BL.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
// TestLogin
namespace ActiveCampWPF
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //SessionManager.ClearSession();
            MainWindow mainWindow = new MainWindow();
            bool sessionLoaded = false;

            try
            {
                Session session = SessionManager.LoadSession();
                if (session != null)
                {
                    mainWindow.ShowMainContent(session);
                    sessionLoaded = true;
                }
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show($"Файл сессии не найден: {ex.Message}", "Ошибка загрузки сессии", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show($"Ошибка при загрузке сессии: {ex.Message}", "Ошибка загрузки сессии", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Неизвестная ошибка: {ex.Message}", "Ошибка загрузки сессии", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (!sessionLoaded)
            {
                mainWindow.ShowLoginContent();
            }

            //mainWindow.Show();
        }
    }
}
