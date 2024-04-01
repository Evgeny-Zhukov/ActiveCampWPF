using ActiveCamp;
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

        private void AddEquipment_Click(object sender, RoutedEventArgs e)
        {
            string equipmentName = txtEquipmentName.Text;
            string equipmentWeight = txtEquipmentWeight.Text;

                
                using (ApplicationContext db = new ApplicationContext())
                {
                    Equipment newEquipment = new Equipment
                    {
                        EquipmentName = equipmentName,
                        EquipmentWeight = equipmentWeight
                    };
                    db.Equipment.Add(newEquipment);
                    db.SaveChanges();
                }

                MessageBox.Show("Equipment added successfully!");   
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            string password = txtPassword.Password;
            string login = txtLogin.Text;
            string email = txtEmail.Text;




            using (ApplicationContext db = new ApplicationContext())
            {
                if (db.Users.Any(u => u.Username == login))
                {
                    MessageBox.Show("Логин недоступен. Пожалуйста, выберите другой логин.");
                    return;
                }

                if (db.Users.Any(u => u.Email == email))
                {
                    MessageBox.Show("Данная почта уже зарегистрирована");
                    return;
                }
            }
            
            Users newUser = new Users
            {
                Name = name,
                Password = password,
                Username = login,
                Email = email
            };
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Users.Add(newUser);
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
                Users selectedUser = db.Users.FirstOrDefault(u => u.Username == login);

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