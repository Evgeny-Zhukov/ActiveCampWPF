using Microsoft.EntityFrameworkCore;
using System.Windows;


namespace ActiveCampWPF
{
    public partial class MainWindow : Window
    {
        private readonly ApplicationContext _dbContext;
        public MainWindow(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
            InitializeComponent();
        }

        private void addUser_Click(object sender, RoutedEventArgs e)
        {
            User user1 = new User { Username = "username1", Email = "test1@test.com", Password = "password1", Name = "name1" };
            User user2 = new User { Username = "username2", Email = "test2@test.com", Password = "password2", Name = "name2" };

            try
            {
                _dbContext.Users.AddRange(user1, user2);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}