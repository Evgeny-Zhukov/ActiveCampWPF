using Microsoft.EntityFrameworkCore;
using System.Windows;


namespace ActiveCampWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                User user1 = new User { Username = "username1", Email = "test1@test.com", Password = "password1", Name = "name1" };

                db.User.AddRange(user1);
                db.SaveChanges();
            }
            MessageBox.Show("Пользователь добавлен");
        }
        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            string password = txtPassword.Password;
            string login = txtLogin.Text;
            string email = txtEmail.Text;

            using (ApplicationContext db = new ApplicationContext())
            {
                if (db.User.Any(u => u.Username == login))
                {
                    MessageBox.Show("Логин недоступен. Пожалуйста, выберите другой логин.");
                    return;
                }

                if (db.User.Any(u => u.Email == email))
                {
                    MessageBox.Show("Данная почта уже зарегистрирована");
                    return;
                }
            }
            
            User newUser = new User
            {
                Name = name,
                Password = password,
                Username = login,
                Email = email
            };
            using (ApplicationContext db = new ApplicationContext())
            {
                db.User.Add(newUser);
                db.SaveChanges();
            }
            
            MessageBox.Show("Пользователь успешно добавлен!");
        }
        private void ChangeUserData_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            string password = txtPassword.Password;
            string login = txtLogin.Text;
            string email = txtEmail.Text;

            using (ApplicationContext db = new ApplicationContext())
            {
                User selectedUser = db.User.FirstOrDefault(u => u.Username == login);

                if (selectedUser != null)
                {
                    selectedUser.Name = name;
                    selectedUser.Password = password;
                    selectedUser.Email = email;
                    db.SaveChanges();

                    MessageBox.Show("Данные пользователя успешно изменены!");
                }
                else
                {
                    MessageBox.Show("Что-то пошло не так...");
                }
            }
            
        }

        private void Exit_Click(Object sender, RoutedEventArgs e) 
        {
            Application.Current.Shutdown();
        }
    }
}