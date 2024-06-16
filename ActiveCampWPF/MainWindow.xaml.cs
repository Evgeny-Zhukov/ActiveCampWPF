using System;
using ActiveCamp.BL;
using ActiveCamp.BL.Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.ComponentModel;
using System.Windows.Data;
using ActiveCamp.BL.Controller;
using System.Collections.Generic;
using System.Windows.Documents;

namespace ActiveCampWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region Sections_Button_Events
        
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
        }
        
        private void NewsButton_Click(object sender, RoutedEventArgs e)
        {
            DisableAllControlOfsections();

            News_Section.Visibility = Visibility.Visible;
            News_Section.IsEnabled = true;
            
            HeaderOfSection.Text = "Новости";

            UpdateNewsList();
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

            this.Settings.Visibility = Visibility.Visible;
            this.Settings.IsEnabled = true;

            HeaderOfSection.Text = "";
            CloseMenu();
            
            //Treatment of Setting button.

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

            MainMenuPanel.BeginAnimation(Grid.WidthProperty, MenuCloseAnimation);
            MainMenuPanel.Focusable = false;
            MainMenuPanel.Visibility = Visibility.Hidden;
        }
        
        private void DisableAllControlOfsections()
        {
            News_Section.Visibility = Visibility.Hidden;
            News_Section.IsEnabled = false;

            Hikking_Section .Visibility = Visibility.Hidden;
            Hikking_Section.IsEnabled = false;

            PreperingForHiking.Visibility = Visibility.Hidden;
            PreperingForHiking.IsEnabled = false;    
        
            this.Settings.Visibility = Visibility.Hidden;
            this.Settings.IsEnabled = false;
        }
        
        #endregion

        #region  Prepering_for_Hiking

        private void Food_ToggleButton_Checked(object sender, RoutedEventArgs e)
        { 

            Equipment.IsChecked = false;
            TabControlOfEquipmentInfo.Visibility = Visibility.Hidden;
            TabControlOfEquipmentInfo.IsEnabled = false;

            HikingInfo.IsChecked = false;
            MainInfoAboutHiking.Visibility = Visibility.Hidden;
            MainInfoAboutHiking.IsEnabled = false;

            TabControlOfFoodInfo.IsEnabled = true;
            TabControlOfFoodInfo.Visibility = Visibility.Visible;

            AddNewRecordInFoodTable.IsEnabled = true;
            AddNewRecordInFoodTable.Visibility = Visibility.Visible;

            ////////////////////////////////////////////////////////////////////////////////////

            RecordsOfFoodTable _records = (RecordsOfFoodTable)this.Resources["foodRecords"];

            _records.Add( new RecordOfFoodTable(0, "Ужин", "День 1", 1, "Сахар", "Пробное описание", 30, 150));
            _records.Add( new RecordOfFoodTable(0, "Завтрак", "День 1", 2, "Гречка", "Пробное описание", 40, 200));
            _records.Add( new RecordOfFoodTable(0, "Обед", "День 1", 1, "Гречка", "Пробное описание", 30, 300));
            _records.Add( new RecordOfFoodTable(1, "Завтрак", "День 2", 1, "Гречка", "Пробное описание", 40, 200));
            _records.Add( new RecordOfFoodTable(1, "Ужин", "День 2", 1, "Перловка", "Пробное описание", 40, 200));
            _records.Add( new RecordOfFoodTable(2, "Завтрак", "День 3", 2, "Гречка", "Пробное описание", 40, 200));
            _records.Add( new RecordOfFoodTable(2, "Обед", "День 3", 1, "Гречка", "Пробное описание", 40, 200));

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

            AddNewRecordInFoodTable.IsEnabled = false;
            AddNewRecordInFoodTable.Visibility = Visibility.Hidden;
        }

        private void Equipment_Checked(object sender, RoutedEventArgs e)
        {
            Food_ToggleButton.IsChecked = false;
            TabControlOfFoodInfo.IsEnabled = false;
            TabControlOfFoodInfo.Visibility = Visibility.Hidden;

            HikingInfo.IsChecked = false;
            MainInfoAboutHiking.IsEnabled = false;
            MainInfoAboutHiking.Visibility = Visibility.Hidden;

            TabControlOfEquipmentInfo.IsEnabled = true;
            TabControlOfEquipmentInfo.Visibility = Visibility.Visible;

            AddNewRecordInEquipmentTable.IsEnabled = true;
            AddNewRecordInEquipmentTable.Visibility = Visibility.Visible;

            ////////////////////////////////////////////////////////////////////////////////////

            RecordsOfEqipmentsTable equipments = (RecordsOfEqipmentsTable)this.Resources["recordsOfEqipmentsTable"];
            
            equipments.Add(new RecordOfUserEquipment(1, "Отверетка", 1, 1.0, 1, "Zurav", ""));
            equipments.Add(new RecordOfUserEquipment(2, "Зажигалка", 1, 0.4, 1, "Zurav", ""));

            ICollectionView cvRecordOfEquipment = CollectionViewSource.GetDefaultView(EquipmentTable.ItemsSource);
            if(cvRecordOfEquipment != null && cvRecordOfEquipment.CanGroup == true)
            {
                cvRecordOfEquipment.GroupDescriptions.Clear();
                cvRecordOfEquipment.GroupDescriptions.Add(new PropertyGroupDescription("OwnerID"));
            }

            EquipmentTable.ItemsSource = cvRecordOfEquipment;
        }
        
        private void Equipment_Unchecked(object sender, RoutedEventArgs e)
        {
            TabControlOfEquipmentInfo.IsEnabled = false;
            TabControlOfEquipmentInfo.Visibility = Visibility.Hidden;

            AddNewRecordInEquipmentTable.IsEnabled = false;
            AddNewRecordInEquipmentTable.Visibility = Visibility.Hidden;
        }
        
        private void HikingInfo_Checked(object sender, RoutedEventArgs e)
        {

            Food_ToggleButton.IsChecked = false;
            TabControlOfFoodInfo.IsEnabled = false;
            TabControlOfFoodInfo.Visibility = Visibility.Hidden;

            Equipment.IsChecked = false;
            TabControlOfEquipmentInfo.IsEnabled = false;
            TabControlOfEquipmentInfo.Visibility = Visibility.Hidden;

            MainInfoAboutHiking.IsEnabled = true;
            MainInfoAboutHiking.Visibility = Visibility.Visible;

            AddNewRecordInEquipmentTable.IsEnabled = false;
            AddNewRecordInEquipmentTable.Visibility = Visibility.Hidden;

            AddNewRecordInFoodTable.IsEnabled = false;
            AddNewRecordInFoodTable.Visibility = Visibility.Hidden;

        }

        private void HikingInfo_Unchecked(object sender, RoutedEventArgs e)
        {
            MainInfoAboutHiking.Visibility = Visibility.Hidden;
            MainInfoAboutHiking.IsEnabled = false;
        }

        private void AddNewRecordInEquipmentTable_Click(object sender, RoutedEventArgs e)
        {
            
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            CreateNewRecord_grid.IsEnabled = true;
            CreateNewRecord_grid.Visibility = Visibility.Visible;

            AddNewRecordForEquipmentTable.IsEnabled = true;
            AddNewRecordForEquipmentTable.Visibility= Visibility.Visible;
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        }

        private void AddNewRecordInFoodTable_Click(object sender, RoutedEventArgs e)
        {
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            CreateNewRecord_grid.IsEnabled = true;
            CreateNewRecord_grid.Visibility = Visibility.Visible;
            
            AddNewRecordForFoodTable.IsEnabled = true;
            AddNewRecordForFoodTable.Visibility = Visibility.Visible;
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        }

        #region Filling_Events
        
        private void BackFromFiilingButton_Click(object sender, RoutedEventArgs e)
        {
            
            DataGridForFillingEquipmentData.Items.Clear();
            DataGridForFillingFoodData.Items.Clear();

            EquipmentOwnersList.ItemsSource = null;
            DaysList.ItemsSource = null;

            CreateNewRecord_grid.IsEnabled = false;
            CreateNewRecord_grid.Visibility = Visibility.Hidden;

            AddNewRecordForFoodTable.IsEnabled= false;
            AddNewRecordForFoodTable.Visibility = Visibility.Hidden;

            AddNewRecordForEquipmentTable.IsEnabled = false;
            AddNewRecordForEquipmentTable.Visibility = Visibility.Hidden;

        }

        private void AddNewRowForFillingEquipmentData_DataGrid_Click(object sender, RoutedEventArgs e)
        {

        }
        
        private void RemoveRowFromEquipmentData_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddNewRowForFillingFoodData_DataGrid_Click(object sender, RoutedEventArgs e)
        {

        }
        
        private void RemoveRowFromFoodData_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveChangesOfEquipmentData_Click(object sender, RoutedEventArgs e)
        {

            MenuButton.IsEnabled = true;
            MenuButton.Visibility = Visibility.Visible;

            HeaderOfSection.IsEnabled = true;
            HeaderOfSection.Visibility = Visibility.Visible;
        
        }

        private void SaveChangesOfFoodData_Click(object sender, RoutedEventArgs e)
        {

            MenuButton.IsEnabled = true;
            MenuButton.Visibility = Visibility.Visible;

            HeaderOfSection.IsEnabled = true;
            HeaderOfSection.Visibility = Visibility.Visible;
        
        }
        
        private void DaysList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var SV = DaysList.SelectedValue;
            if(SV != null)
            {
                ((ActiveCampWPF.DayElement)SV).RecordOfFoodTable = new RecordOfFoodTable();
            }
        }
        
        #endregion


        #endregion

        #region Registration/Login_events
        
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
            
            if (Login(user))
            {
                Background_of_window.IsEnabled = true;
                UpdateNewsList();
                Person_Validate.IsEnabled = false;
                Person_Validate.Visibility = Visibility.Hidden;
            }
            else
            {
                MessageBox.Show($"Неверный логин или пароль, попробуйте снова");
            }
        }

        private bool Login(User user)
        {
            UserManager userManager = new UserManager();
            int UserId = userManager.VerifyUserByLogin(user.Username, user.Password);
            if (UserId != -1)
            {
                Session session = new Session(user.Username);
                SessionManager.SaveSession(session);

                ActiveCamp.BL.User.UserID = UserId;

                return true;
            }
            else
            {
                return false;
            }
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            SessionManager.ClearSession();
            this.Close();
        }

        private void Sign_up_button_Click(object sender, RoutedEventArgs e)
        {
            string username = Login_textbox.Text;
            string password = PasswordBox_UserPassword.Password;

            User user = new User(username, password);
            UserManager userManager = new UserManager();

            int UserId = userManager.RegisterUser(user);

            if (UserId != -1)
            {
                //Background_of_window.IsEnabled = true;
                //Person_Validate.IsEnabled = false;
                //Person_Validate.Visibility = Visibility.Hidden;
            
                ActiveCamp.BL.User.UserID = UserId;

                SucssesRegistrationNotify.Visibility = Visibility.Visible;

                SucssesRegistrationNotify.Text = "Регистрация прошла успешно!\n" +
                                                 "Вы можете войти, нажав кнопку\n\"Войти\"";

                DoubleAnimation openAnimation = new DoubleAnimation();

                openAnimation.From = 0;
                openAnimation.To = 1;
                openAnimation.Duration = new Duration(TimeSpan.Parse("0:0:2"));
                
                SucssesRegistrationNotify.BeginAnimation(OpacityProperty, openAnimation);

                DoubleAnimation closeAnimation = new DoubleAnimation();

                closeAnimation.From = 1;
                closeAnimation.To = 0;
                closeAnimation.Duration = new Duration(TimeSpan.Parse("0:0:3.5"));
                
                SucssesRegistrationNotify.BeginAnimation(OpacityProperty, closeAnimation);
            }
            else 
            { 
                MessageBox.Show("ОШИБКА, такой Username уже существует, пожалуйста, выберите другой."); 
            }
        }

        #endregion

        //++ Хз что это и для чего нужно 
        public void ShowMainContent(Session session)
        {
            Person_Validate.Visibility = Visibility.Collapsed;
            Main_controls.Visibility = Visibility.Visible;
        }

        public void ShowLoginContent()
        {
            Person_Validate.Visibility = Visibility.Visible;

            Main_controls.Visibility = Visibility.Collapsed;
        }
        //--

        #region Window Events

        private void Window_Initialized(object sender, EventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
        
        #endregion

        #region News 

        private void NewsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string descriptionOfnews = ((ActiveCampWPF.NewHikkingListItem)NewsList.SelectedValue).NewsItem.NewsText;
            string newsTitle = ((ActiveCampWPF.NewHikkingListItem)NewsList.SelectedValue).NewsItem.NewsTitle;

            Paragraph title = new Paragraph();
            Paragraph mainBodyOfNews = new Paragraph();
            title.Inlines.Add(new Bold(new Run(newsTitle)));            
            mainBodyOfNews.Inlines.Add(new Run(descriptionOfnews));
            
            List newsBodyList = new List();
            newsBodyList.ListItems.Add(new ListItem(title));
            newsBodyList.ListItems.Add(new ListItem(mainBodyOfNews));

            FlowDocument flowDocument = new FlowDocument();
            flowDocument.Blocks.Add(newsBodyList);

            NewsDescription.Document = flowDocument;

        }

        private void UpdateNewsList()
        {
            NewsList.ItemsSource = null;
            List<News> newses = new List<News> {};
            NewsManager newsController = new NewsManager();
            newses = newsController.GetNews(ActiveCamp.BL.User.UserID);
            
            List<NewHikkingListItem> source = new List<NewHikkingListItem> { };

            foreach(News news in newses)
            {
                source.Add(new NewHikkingListItem(news));
            }

            NewsList.ItemsSource = source;
        }

        private void NewsSorting()
        {
            if (SortbyFavorFlag.IsChecked == true && SortbyFavorAdminMessage.IsChecked == false)
            {
                List<NewHikkingListItem> sortedNews = new List<NewHikkingListItem>();
                
                foreach(NewHikkingListItem elementOfNews in NewsList.Items)
                {
                    if(elementOfNews.ItsFavorMessage == true && elementOfNews.ItsAdminMessage == false)
                    {
                        sortedNews.Add(elementOfNews);
                    }
                }

                NewsList.ItemsSource = null;
                NewsList.ItemsSource = sortedNews;

            }
            else if(SortbyFavorFlag.IsChecked == false && SortbyFavorAdminMessage.IsChecked == true)
            {
                List<NewHikkingListItem> sortedNews = new List<NewHikkingListItem>();

                foreach (NewHikkingListItem elementOfNews in NewsList.Items)
                {
                    if (elementOfNews.ItsFavorMessage == false && elementOfNews.ItsAdminMessage == true)
                    {
                        sortedNews.Add(elementOfNews);
                    }
                }

                NewsList.ItemsSource = null;
                NewsList.ItemsSource = sortedNews;
            }
            else if(SortbyFavorFlag.IsChecked == true && SortbyFavorAdminMessage.IsChecked == true)
            {
                List<NewHikkingListItem> sortedNews = new List<NewHikkingListItem>();

                foreach (NewHikkingListItem elementOfNews in NewsList.Items)
                {
                    if (elementOfNews.ItsFavorMessage == true && elementOfNews.ItsAdminMessage == true)
                    {
                        sortedNews.Add(elementOfNews);
                    }
                }

                NewsList.ItemsSource = null;
                NewsList.ItemsSource = sortedNews;
            }

        }

        private void SortbyFavorFlag_Checked(object sender, RoutedEventArgs e)
        {
            NewsSorting();
        }

        private void SortbyFavorFlag_Unchecked(object sender, RoutedEventArgs e)
        {
            UpdateNewsList();
            NewsSorting();
        }

        private void SortbyFavorAdminMessage_Checked(object sender, RoutedEventArgs e)
        {
            NewsSorting();
        }

        private void SortbyFavorAdminMessage_Unchecked(object sender, RoutedEventArgs e)
        {
            UpdateNewsList();
            NewsSorting();
        }
        
        #endregion

        #region Hiking
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
            RouteManager routeManager = new RouteManager();
            Route NewRoute = new Route(ActiveCamp.BL.User.UserID, DateTime.Parse(DateFrom.SelectedDate.ToString()), DateTime.Parse(DateTo.SelectedDate.ToString()), LittleDiscription.Text, PointFrom.Text, PointTo.Text, LevelOfHiking.Text, 0, false);
            routeManager.AddRoute(NewRoute);

            DoubleAnimation openAnimation = new DoubleAnimation();

            openAnimation.AutoReverse = true;
            openAnimation.SpeedRatio = 2;
            openAnimation.From = 0;
            openAnimation.To = 1;
            openAnimation.Duration = new Duration(TimeSpan.Parse("0:0:5"));

            SavingSucssesfulMessage.BeginAnimation(OpacityProperty, openAnimation);

            NewHikkingFormBorder.Visibility = Visibility.Hidden;
            NewHikkingFormBorder.IsEnabled = false;

            LittleDiscription.Text = "";
            PointFrom.Text = "";
            PointTo.Text = "";
            DateTo.Text = "Выберете дату";
            DateFrom.Text = "Выберете дату";
            LevelOfHiking.Text = "";
        }
        #endregion

        #region AI Agent 
        
        private void AI_agent_Click(object sender, RoutedEventArgs e)
        {
            
            Main_controls.IsEnabled = false;
            
            AgentMenu_grid.IsEnabled = true;
            AgentMenu_grid.Visibility = Visibility.Visible;
        
        }
        
        private void BackFromAgentMenuButton_Click(object sender, RoutedEventArgs e)
        {
            
            Main_controls.IsEnabled= true;
            
            AgentMenu_grid.IsEnabled = false;
            AgentMenu_grid.Visibility= Visibility.Hidden;

        }

        #endregion

        #region Settings
        private void BackFromSettingButton_Click(object sender, RoutedEventArgs e)
        {
            MenuBackground.Visibility = Visibility.Visible;
            MenuBackground.IsEnabled = true;
            
            MainMenuPanel.Visibility = Visibility.Visible;
            MainMenuPanel.IsEnabled = true;

            DoubleAnimation openMenu = new DoubleAnimation();

            openMenu.From = 0;
            openMenu.To = 320;
            openMenu.Duration = new Duration(TimeSpan.Parse("0:0:0.28"));

            MainMenuPanel.BeginAnimation(Grid.WidthProperty, openMenu);


        }
        #endregion

    }
}