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
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Data;



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

            MainMenuPanel.Visibility = Visibility.Visible;
            MainMenuPanel.Focusable = true;
        }

        private void MenuBackgroundButton_Click(object sender, RoutedEventArgs e)
        {
            CloseMenu();
            //Treatment of BackGaround button.
        }
        
        private void NewsButton_Click(object sender, RoutedEventArgs e)
        {
            DisableAllControlOfsections();

            News_Section.Visibility = Visibility.Visible;
            News_Section.IsEnabled = true;
            
            HeaderOfSection.Text = "Новости";
            CloseMenu();
            //Treatment of News button.
        }
        private void HikingButton_Click(object sender, RoutedEventArgs e)
        {
            DisableAllControlOfsections();

            Hikking_Section.Visibility = Visibility.Visible;
            Hikking_Section.IsEnabled = true;

            HeaderOfSection.Text = "Походы";
            CloseMenu();
            //Treatment of Hiking button.
        }
        private void EquipmentButton_Click(object sender, RoutedEventArgs e)
        {
            DisableAllControlOfsections();

            PreperingForHiking.Visibility = Visibility.Visible;
            PreperingForHiking.IsEnabled = true;

            MainInfoAboutHiking.IsEnabled = true;
            MainInfoAboutHiking.Visibility = Visibility.Visible;
            HikingInfo.IsChecked = true;

            HeaderOfSection.Text = "Подготовка";
            CloseMenu();
            //Treatment of Equipment button.
        }
        
        private void SettingButton_Click(object sender, RoutedEventArgs e)
        {
            DisableAllControlOfsections();
            HeaderOfSection.Text = "Настройки";
            CloseMenu();
            //Treatment of Setting button.
        }
        
        #region  Prepering_for_Hiking
        private void Food_ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            Equipment.IsChecked = false;
            TabControlOfEquipmentInfo.Visibility = Visibility.Hidden;
            TabControlOfEquipmentInfo.IsEnabled = false;

            HikingInfo.IsChecked = false;
            TabControlOfFoodInfo.Visibility = Visibility.Hidden;
            TabControlOfFoodInfo.IsEnabled = false;

            TabControlOfFoodInfo.IsEnabled = true;
            TabControlOfFoodInfo.Visibility = Visibility.Visible;

            RecordsOfFoodTable _records = (RecordsOfFoodTable)this.Resources["food_records"];

            _records.Add( new RecordOfFoodTable(0, "Ужин", "День 1", "Сахар", "Пробное описание", 30, 150));
            _records.Add( new RecordOfFoodTable(0, "Завтрак", "День 1", "Гречка", "Пробное описание", 40, 200));
            _records.Add( new RecordOfFoodTable(0, "Обед", "День 1", "Гречка", "Пробное описание", 30, 300));
            _records.Add( new RecordOfFoodTable(1, "Завтрак", "День 2", "Гречка", "Пробное описание", 40, 200));
            _records.Add( new RecordOfFoodTable(1, "Ужин", "День 2", "Перловка", "Пробное описание", 40, 200));
            _records.Add( new RecordOfFoodTable(2, "Завтрак", "День 3", "Гречка", "Пробное описание", 40, 200));
            _records.Add( new RecordOfFoodTable(2, "Обед", "День 3", "Гречка", "Пробное описание", 40, 200));

            ICollectionView cvRecords = CollectionViewSource.GetDefaultView(FoodTable.ItemsSource);
            if(cvRecords != null && cvRecords.CanGroup == true)
            {
                cvRecords.GroupDescriptions.Clear();
                cvRecords.GroupDescriptions.Add(new PropertyGroupDescription("Day"));
                cvRecords.GroupDescriptions.Add(new PropertyGroupDescription("FoodTime"));
            }

            FoodTable.ItemsSource = cvRecords;


            RecordsOfFoodTablePerPerson _recordPerPerson = (RecordsOfFoodTablePerPerson)this.Resources["recordsOfFoodTablePerPerson"];

            _recordPerPerson.Add(new RecordOfFoodTablePerPerson(0, "Zurab", "Kasha", 30, ""));
            _recordPerPerson.Add(new RecordOfFoodTablePerPerson(1, "Bulvar", "Kasha", 40, ""));
            _recordPerPerson.Add(new RecordOfFoodTablePerPerson(2, "Kostya", "Grechka", 30, ""));
            _recordPerPerson.Add(new RecordOfFoodTablePerPerson(3, "Miver", "Makaronyu", 40, ""));


            ICollectionView cvRecordOfFoodTablePerPerson = CollectionViewSource.GetDefaultView(FoodTablePerPerson.ItemsSource);
            if (cvRecords != null && cvRecords.CanGroup == true)
            {
                cvRecordOfFoodTablePerPerson.GroupDescriptions.Clear();
                cvRecordOfFoodTablePerPerson.GroupDescriptions.Add(new PropertyGroupDescription("Person"));
            }

            FoodTablePerPerson.ItemsSource = cvRecordOfFoodTablePerPerson;

        }

        private void Food_ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            TabControlOfFoodInfo.IsEnabled = false;
            TabControlOfFoodInfo.Visibility = Visibility.Hidden;
        }

        private void Equipment_Checked(object sender, RoutedEventArgs e)
        {
            Food_ToggleButton.IsChecked = false;
            TabControlOfFoodInfo.IsEnabled = false;
            TabControlOfFoodInfo.Visibility = Visibility.Hidden;

            HikingInfo.IsChecked = false;
            MainInfoAboutHiking.Visibility = Visibility.Hidden;
            MainInfoAboutHiking.IsEnabled = false;

            TabControlOfEquipmentInfo.Visibility = Visibility.Visible;
            TabControlOfEquipmentInfo.IsEnabled = true;

        }
        
        private void Equipment_Unchecked(object sender, RoutedEventArgs e)
        {
            TabControlOfEquipmentInfo.Visibility = Visibility.Hidden;
            TabControlOfEquipmentInfo.IsEnabled = false;
        }
        
        private void HikingInfo_Checked(object sender, RoutedEventArgs e)
        {
            Food_ToggleButton.IsChecked = false;
            TabControlOfFoodInfo.IsEnabled = false;
            TabControlOfFoodInfo.Visibility = Visibility.Hidden;

            Equipment.IsChecked = false;
            TabControlOfEquipmentInfo.Visibility = Visibility.Hidden;
            TabControlOfEquipmentInfo.IsEnabled = false;

            MainInfoAboutHiking.Visibility = Visibility.Visible;
            MainInfoAboutHiking.IsEnabled = true;
        }

        private void HikingInfo_Unchecked(object sender, RoutedEventArgs e)
        {
            MainInfoAboutHiking.Visibility = Visibility.Hidden;
            MainInfoAboutHiking.IsEnabled = false;
        }

        #endregion


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
            MainMenuPanel.BeginAnimation(Grid.WidthProperty, MenuCloseAnimation);
            MainMenuPanel.Focusable = false;
            MainMenuPanel.Visibility = Visibility.Hidden;
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
            
            if (activeCampDbContext.ValidateUser(user.Username, user.Password))
            {
                Background_of_window.IsEnabled = true;
                Person_Validate.IsEnabled = false;
                Person_Validate.Visibility = Visibility.Hidden;
            }
            else
            {
                MessageBox.Show($"Incorrect password or login, please, try again.");
            }
        }

        private void Sign_up_button_Click(object sender, RoutedEventArgs e)
        {
            string username = Login_textbox.Text;
            string password = PasswordBox_UserPassword.Password;

            User user = new User(username, password);
            ActiveCampDbContext activeCampDbContext = new ActiveCampDbContext();

            if (activeCampDbContext.RegisterUser(user))
            {
                Background_of_window.IsEnabled = true;
                Person_Validate.IsEnabled = false;
                Person_Validate.Visibility = Visibility.Hidden;
            } 
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void NewsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void DisableAllControlOfsections()
        {
            News_Section.Visibility = Visibility.Hidden;
            News_Section.IsEnabled = false;

            Hikking_Section .Visibility = Visibility.Hidden;
            Hikking_Section.IsEnabled = false;

            PreperingForHiking.Visibility = Visibility.Hidden;
            PreperingForHiking.IsEnabled = false;    
        }

        private void BackFromCreatingWindow_Click(object sender, RoutedEventArgs e)
        {
            BorderOfCancelAproovingform.Visibility = Visibility.Visible;
            BorderOfCancelAproovingform.IsEnabled = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            BorderOfCancelAproovingform.Visibility = Visibility.Hidden;
            BorderOfCancelAproovingform.IsEnabled = false;

            NewHikkingFormBorder.Visibility = Visibility.Hidden;
            NewHikkingFormBorder.IsEnabled = false;

            LittleDiscription.Text = "";
            PointFrom.Text = "";
            PointTo.Text = "";
            DateTo.Text = "Выберете дату";
            DateFrom.Text = "Выберете дату";
            LevelOfHiking.Text = "";
        }

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            BorderOfCancelAproovingform.Visibility = Visibility.Hidden;
            BorderOfCancelAproovingform.IsEnabled = false;
        }

        private void AddNewHikking_Click(object sender, RoutedEventArgs e)
        {
            NewHikkingFormBorder.Visibility = Visibility.Visible;
            NewHikkingFormBorder.IsEnabled = true;
        }

        private void SaveAndContinue_Click(object sender, RoutedEventArgs e)
        {
            ActiveCampDbContext activeCampDbContext = new ActiveCampDbContext();
            Route NewRoute = new Route(DateTime.Parse(DateFrom.SelectedDate.ToString()), DateTime.Parse(DateTo.SelectedDate.ToString()), LittleDiscription.Text, PointFrom.Text, PointTo.Text, LevelOfHiking.Text, false);
            activeCampDbContext.AddRoute(NewRoute);
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}