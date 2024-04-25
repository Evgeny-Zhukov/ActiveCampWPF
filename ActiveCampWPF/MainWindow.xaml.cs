using System;
using ActiveCamp.BL;
using ActiveCamp.BL.Controller;
using ActiveCamp.BL.Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using ActiveCamp;
using System.ComponentModel;



namespace ActiveCampWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
  
        //private User currentUser;   
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            MenuBackground.Visibility = Visibility.Visible;
            MenuBackground.Focusable = true;

            MenuPanel.Visibility = Visibility.Visible;
            MenuPanel.Focusable = true;
        }

        private void AccountButton_Click(object sender, RoutedEventArgs e)
        {
            HeaderOfSection.Text = "Account";
            CloseMenu();
            //Treatment of account button.
        }

        private void NewsButton_Click(object sender, RoutedEventArgs e)
        {
            HeaderOfSection.Text = "News";
            CloseMenu();
            //Treatment of News button.
        }
        private void HikingButton_Click(object sender, RoutedEventArgs e)
        {
            CloseMenu();
            //Treatment of Hiking button.
        }
        private void EquipmentButton_Click(object sender, RoutedEventArgs e)
        {
            HeaderOfSection.Text = "Equipment";
            CloseMenu();
            //Treatment of Equipment button.
        }

        private void SettingButton_Click(object sender, RoutedEventArgs e)
        {
            HeaderOfSection.Text = "Setting";
            CloseMenu();
            //Treatment of Setting button.
        }

        private void MenuBackgroundButton_Click(object sender, RoutedEventArgs e)
        {
            CloseMenu();
            //Treatment of BackGaround button.
        }

        private void CloseMenu()
        {
            MenuBackground.Focusable = false;
            MenuBackground.Visibility = Visibility.Hidden;

            DoubleAnimation MenuCloseAnimation = new DoubleAnimation
            {
                From = 320,
                To = 0,
                Duration = new Duration(TimeSpan.Parse("0:0:0.5"))
            };
            MenuPanel.BeginAnimation(Grid.WidthProperty, MenuCloseAnimation);
            MenuPanel.Focusable = false;
            MenuPanel.Visibility = Visibility.Hidden;
        }

        private void ClientStatus_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Login_textbox_MouseEnter(object sender, MouseEventArgs e)
        {
            TextBox tb = sender as TextBox;

            if (tb != null)
            { 

            }
        }

        private void Login_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Log_In_button_Click(object sender, RoutedEventArgs e)
        {
            string username = Login_textbox.Text;
            string password = PasswordBox_UserPassword.Password;
            
            User user = new User(username, password);
            ActiveCampDbContext activeCampDbContext = new ActiveCampDbContext();
            
            if (activeCampDbContext.ValidateCredentials(user.Username, user.Password))
            {
                Background_of_window.IsEnabled = true;
                Person_Validate.IsEnabled = false;
                Person_Validate.Visibility = Visibility.Hidden;
            }
            else
            {
                MessageBox.Show($"Error");
            }
        }

        private void Sign_up_button_Click(object sender, RoutedEventArgs e)
        {
            // ActiveCampDbContext activeCampDbContext;
            
            string username = Login_textbox.Text;
            string password = PasswordBox_UserPassword.Password;
            User user = new User { Username = username, Password = password };
            ActiveCampDbContext activeCampDbContext = new ActiveCampDbContext();
            if(activeCampDbContext.RegisterUser(user))
            {
                MessageBox.Show($"{username}, {password}");
            }
            else
            {
                MessageBox.Show($"Error");
            }
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            Window gd = sender as Window;
            if (gd != null)
            {
                Person_Validate.IsEnabled = true;
                Person_Validate.Visibility = Visibility.Visible;
                Person_Validate.Focusable = true;
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Window gd = sender as Window;
            if (gd != null)
            {
                Person_Validate.IsEnabled = true;
                Person_Validate.Visibility = Visibility.Visible;
                Person_Validate.Focusable = true;
            }
        }
    }
}