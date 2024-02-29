using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;

namespace ActiveCampWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var serviceProvider = new ServiceCollection()
                .AddDbContext<ApplicationContext>(options =>
                    options.UseMySql("server=localhost;user=root;password=root;database=userdb;",
                        new MySqlServerVersion(new Version(8, 0, 34)))) 
                .BuildServiceProvider();

            var mainWindow = new MainWindow(serviceProvider.GetRequiredService<ApplicationContext>());
            mainWindow.Show();
        }

    }

}
