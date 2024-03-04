using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Windows;
using System.Windows.Forms;


namespace ActiveCampWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
                    System.Windows.Forms.MessageBox.Show("Логин недоступен. Пожалуйста, выберите другой логин.");
                    return;
                }

                if (db.User.Any(u => u.Email == email))
                {
                    System.Windows.Forms.MessageBox.Show("Данная почта уже зарегистрирована");
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

            System.Windows.Forms.MessageBox.Show("Пользователь успешно добавлен!");
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

                    System.Windows.Forms.MessageBox.Show("Данные пользователя успешно изменены!");
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Что-то пошло не так...");
                }
            }
            
        }

        private void Exit_Click(Object sender, RoutedEventArgs e) 
        {
            System.Windows.Application.Current.Shutdown();
        } 
    }
}