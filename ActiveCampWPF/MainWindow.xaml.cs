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
using ActiveCamp;
using System.Xml.Schema;

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

            NewsList.SelectionMode = SelectionMode.Single;

            News_Section.Visibility = Visibility.Visible;
            News_Section.IsEnabled = true;
            
            HeaderOfSection.Text = "Новости";

            //NewsList.SelectedIndex = 0;
            //NewsList.SelectionChanged += NewsList_SelectionChanged;

            UpdateNewsList();
            CloseMenu();
            //Treatment of News button.
        }
        
        private void HikingButton_Click(object sender, RoutedEventArgs e)
        {
            DisableAllControlOfsections();

            HikkingList.SelectionMode = SelectionMode.Single;

            Hikking_Section.Visibility = Visibility.Visible;
            Hikking_Section.IsEnabled = true;

            HeaderOfSection.Text = "Походы";

            //HikkingList.SelectedIndex = 0;
            //HikkingList.SelectionChanged += HikkingList_SelectionChanged;

            UpdateHikingList();
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

            //ActiveHikingList.SelectedIndex = 0;
            //ActiveHikingList.SelectionChanged += ActiveHikingList_SelectionChanged;

            HeaderOfSection.Text = "Подготовка";

            UpdateActiveHiking();
            CloseMenu();
            
            //Treatment of Equipment button.
        
        }
        
        private void SettingButton_Click(object sender, RoutedEventArgs e)
        {
            DisableAllControlOfsections();

            this.Settings.Visibility = Visibility.Visible;
            this.Settings.IsEnabled = true;

            HeaderOfSection.Text = "";
            
            UpdateSetting();
            CloseMenu();
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

        private void UpdateActiveHiking()
        {
            ActiveHikingList.ItemsSource = null;
            List<Route> routes = new List<Route> { };
            RouteManager routeController = new RouteManager();
            routes = routeController.GetAllUserRoutes(ActiveCamp.BL.User.UserID);

            List<ActiveHikingItem> source = new List<ActiveHikingItem> { };

            foreach (Route route in routes)
            {
                source.Add(new ActiveHikingItem(route));
            }

            ActiveHikingList.ItemsSource = source;
        }
        
        private void ActiveHikingList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Основная информация                                                                     ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            Route routeInfo = ((ActiveCampWPF.ActiveHikingItem)ActiveHikingList.SelectedValue).RouteItem;

            Paragraph title = new Paragraph();
            title.Inlines.Add(new Bold(new Run(routeInfo.RouteName)));

            Paragraph description = new Paragraph();
            description.Inlines.Add(new Run($"Описание:\n\n{routeInfo.Description}"));

            Paragraph dates = new Paragraph();
            dates.Inlines.Add($"Данный поход будет проходить с {routeInfo.StartDate} по {routeInfo.EndDate}");

            Paragraph tripInfo = new Paragraph();
            tripInfo.Inlines.Add($"Маршрут начинается с точки {routeInfo.StartPoint} и заканчивается в точке {routeInfo.EndPoint}, протяженность маршрута состовляет {routeInfo.Length} км.");

            Paragraph level = new Paragraph();
            level.Inlines.Add($"Уровень сложеность маршрута: {routeInfo.Difficulty}");

            Paragraph count = new Paragraph();
            count.Inlines.Add($"Планируемое чило участников: {routeInfo.MemberCount}");

            List newsBodyList = new List();
            newsBodyList.ListItems.Add(new ListItem(level));
            newsBodyList.ListItems.Add(new ListItem(description));
            newsBodyList.ListItems.Add(new ListItem(dates));
            newsBodyList.ListItems.Add(new ListItem(tripInfo));
            newsBodyList.ListItems.Add(new ListItem(count));

            FlowDocument flowDocument = new FlowDocument();
            flowDocument.Blocks.Add(title);
            flowDocument.Blocks.Add(newsBodyList);

            Discription_of_ActiveHikking.Document = flowDocument;

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Заполненние данных по еде                                                                     /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            UpdateFoodTabControl(routeInfo);

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Заполненние данных по инвентарю                                                                     ///////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            UpdateEquipmentTabControl(routeInfo);

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Заполненние данных по участникам группы                                                                     ///////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            UpdateGroupMembershipList(routeInfo);

        }

        private void UpdateFoodTabControl(Route routeInfo)
        {

            AddNewRecordInFoodTable.IsEnabled = true;
            AddNewRecordInFoodTable.Visibility = Visibility.Visible;

            GroupManager manager = new GroupManager();
            Group group = manager.GetGroup(routeInfo.RouteId);

            GroupDishManager dishManager = new GroupDishManager();
            List<GroupDish> dishList = new List<GroupDish>();
            dishList = dishManager.GetGroupDishById(routeInfo.RouteId);

            RecordsOfFoodTable _records = (RecordsOfFoodTable)this.Resources["foodRecords"];
            
            foreach(GroupDish dish in dishList)
            {
                _records.Add(new RecordOfFoodTable(dish.DishTime, dish.RouteDay.ToString(), dish.DishName, dish.Comment, dish.WeigthAll, dish.Weigth1));
            }

            ICollectionView cvRecords = CollectionViewSource.GetDefaultView(FoodTable.ItemsSource);
            if (cvRecords != null && cvRecords.CanGroup == true)
            {
                cvRecords.GroupDescriptions.Clear();
                cvRecords.GroupDescriptions.Add(new PropertyGroupDescription("Day"));
                cvRecords.GroupDescriptions.Add(new PropertyGroupDescription("FoodTime"));
            }

            FoodTable.ItemsSource = cvRecords;

            GroupMembershipManager groupMembershipManager = new GroupMembershipManager();
            List<GroupMembership> groupMemberships = new List<GroupMembership>();
            groupMemberships = groupMembershipManager.GetGroupMembership(group.GroupId);

            RecordsOfFoodTablePerPerson _recordPerPerson = (RecordsOfFoodTablePerPerson)this.Resources["recordsOfFoodTablePerPerson"];

            UserProfileManager userManager = new UserProfileManager();

            foreach(GroupMembership membership in groupMemberships)
            {

                UserProfile user = userManager.GetUserProfile(membership.UserId);

                foreach (GroupDish dish in dishList)
                {
                    _recordPerPerson.Add(new RecordOfFoodTablePerPerson(user.FirstName + user.SecondName, dish.DishName, dish.Weigth1, dish.Comment));
                }
            }

            ICollectionView cvRecordOfFoodTablePerPerson = CollectionViewSource.GetDefaultView(FoodTablePerPerson.ItemsSource);
            if (cvRecords != null && cvRecords.CanGroup == true)
            {
                cvRecordOfFoodTablePerPerson.GroupDescriptions.Clear();
                cvRecordOfFoodTablePerPerson.GroupDescriptions.Add(new PropertyGroupDescription("Person"));
            }

            FoodTablePerPerson.ItemsSource = cvRecordOfFoodTablePerPerson;
        }

        private void UpdateEquipmentTabControl(Route routeInfo)
        {

            RecordsOfEqipmentsTable equipments = (RecordsOfEqipmentsTable)this.Resources["recordsOfEqipmentsTable"];
            
            GroupManager manager = new GroupManager();
            Group group = manager.GetGroup(routeInfo.RouteId);

            GroupMembershipManager groupMembershipManager = new GroupMembershipManager();
            List<GroupMembership> groupMemberships = new List<GroupMembership>();
            groupMemberships = groupMembershipManager.GetGroupMembership(group.GroupId);

            GroupEquipmentManager equipmentsManager = new GroupEquipmentManager();
            List<GroupEquipment> groupEquipments = new List<GroupEquipment>();
            groupEquipments = equipmentsManager.GetGroupEquipmentById(group.GroupId);

            UserProfileManager userProfileManager = new UserProfileManager();

            foreach (GroupEquipment equipment in groupEquipments)
            {
                UserProfile profile = userProfileManager.GetUserProfile(equipment.UserID);
                equipments.Add(new RecordOfUserEquipment(profile.FirstName, equipment.EquipmentName, equipment.Count, equipment.Weigth, equipment.Description));
                
            }

            ICollectionView cvRecordOfEquipment = CollectionViewSource.GetDefaultView(EquipmentTable.ItemsSource);
            if (cvRecordOfEquipment != null && cvRecordOfEquipment.CanGroup == true)
            {
                cvRecordOfEquipment.GroupDescriptions.Clear();
                cvRecordOfEquipment.GroupDescriptions.Add(new PropertyGroupDescription("OwnerName"));
            }

            EquipmentTable.ItemsSource = cvRecordOfEquipment;
        }

        private void UpdateGroupMembershipList(Route routeInfo)
        {
            GroupManager manager = new GroupManager();
            Group group = manager.GetGroup(routeInfo.RouteId);

            GroupMembershipManager groupMembershipManager = new GroupMembershipManager();
            List<GroupMembership> groupMemberships = new List<GroupMembership>();
            groupMemberships = groupMembershipManager.GetGroupMembership(group.GroupId);
            
            List<HikingMembersItem> hikingMembersItems = new List<HikingMembersItem>();

            UserProfileManager userProfileManager = new UserProfileManager();

            foreach (GroupMembership membership in groupMemberships)
            {
                UserProfile profile = userProfileManager.GetUserProfile(membership.UserId);
                hikingMembersItems.Add(new HikingMembersItem(membership, profile));
            }

            ListOfMemebers.ItemsSource = hikingMembersItems;

        }

        private void Food_ToggleButton_Checked(object sender, RoutedEventArgs e)
        { 

            Equipment.IsChecked = false;
            TabControlOfEquipmentInfo.Visibility = Visibility.Hidden;
            TabControlOfEquipmentInfo.IsEnabled = false;

            HikingInfo.IsChecked = false;
            MainInfoAboutHiking.Visibility = Visibility.Hidden;
            MainInfoAboutHiking.IsEnabled = false;

            GroupMembers.IsChecked = false;
            ListOfMemebers.IsEnabled = false;
            ListOfMemebers.Visibility = Visibility.Hidden;

            TabControlOfFoodInfo.IsEnabled = true;
            TabControlOfFoodInfo.Visibility = Visibility.Visible;
            
            if(ActiveHikingList.SelectedValue != null)
            {
                UpdateFoodTabControl(((ActiveCampWPF.ActiveHikingItem)ActiveHikingList.SelectedValue).RouteItem);

                if (((ActiveCampWPF.ActiveHikingItem)ActiveHikingList.SelectedValue).RouteItem.AuthorId == ActiveCamp.BL.User.UserID)
                {
                    AddNewRecordInFoodTable.IsEnabled = true;
                    AddNewRecordInFoodTable.Visibility = Visibility.Visible;
                }
            }

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

            GroupMembers.IsChecked = false;
            ListOfMemebers.IsEnabled = false;
            ListOfMemebers.Visibility = Visibility.Hidden;

            TabControlOfEquipmentInfo.IsEnabled = true;
            TabControlOfEquipmentInfo.Visibility = Visibility.Visible;

            if(ActiveHikingList.SelectedValue != null)
            {
                UpdateEquipmentTabControl(((ActiveCampWPF.ActiveHikingItem)ActiveHikingList.SelectedValue).RouteItem);

                if (((ActiveCampWPF.ActiveHikingItem)ActiveHikingList.SelectedValue).RouteItem.AuthorId == ActiveCamp.BL.User.UserID)
                {
                    AddNewRecordInEquipmentTable.IsEnabled = true;
                    AddNewRecordInEquipmentTable.Visibility = Visibility.Visible;
                }
            }

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

            GroupMembers.IsChecked = false;
            ListOfMemebers.IsEnabled = false;
            ListOfMemebers.Visibility = Visibility.Hidden;

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

        private void GroupMembers_Checked(object sender, RoutedEventArgs e)
        {

            Food_ToggleButton.IsChecked = false;
            TabControlOfFoodInfo.IsEnabled = false;
            TabControlOfFoodInfo.Visibility = Visibility.Hidden;

            Equipment.IsChecked = false;
            TabControlOfEquipmentInfo.IsEnabled = false;
            TabControlOfEquipmentInfo.Visibility = Visibility.Hidden;

            this.HikingInfo.IsChecked = false;
            MainInfoAboutHiking.IsEnabled = false;
            MainInfoAboutHiking.Visibility = Visibility.Hidden;

            ListOfMemebers.IsEnabled = true;
            ListOfMemebers.Visibility = Visibility.Visible;

            AddNewRecordInEquipmentTable.IsEnabled = false;
            AddNewRecordInEquipmentTable.Visibility = Visibility.Hidden;

            AddNewRecordInFoodTable.IsEnabled = false;
            AddNewRecordInFoodTable.Visibility = Visibility.Hidden;

        }

        private void GroupMembers_Unchecked(object sender, RoutedEventArgs e)
        {
            ListOfMemebers.IsEnabled = false;
            ListOfMemebers.Visibility = Visibility.Hidden;
        }

        private void AddNewRecordInEquipmentTable_Click(object sender, RoutedEventArgs e)
        {
            
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            CreateNewRecord_grid.IsEnabled = true;
            CreateNewRecord_grid.Visibility = Visibility.Visible;

            AddNewRecordForEquipmentTable.IsEnabled = true;
            AddNewRecordForEquipmentTable.Visibility= Visibility.Visible;
            ////////////////////////////////////////////////////////////////////////////////////////////////////

            EquipmentOwnersList.ItemsSource = null;

            List<NewRecordOfEquiment> equipments = new List<NewRecordOfEquiment>();

            GroupManager groupManager = new GroupManager();
            Group group = groupManager.GetGroup(((ActiveCampWPF.ActiveHikingItem)ActiveHikingList.SelectedValue).RouteItem.RouteId);

            GroupMembershipManager manager = new GroupMembershipManager();
            List<GroupMembership> memberships = manager.GetGroupMembership(group.GroupId);

            foreach(GroupMembership membershipItem in memberships)
            {
                equipments.Add(new NewRecordOfEquiment(membershipItem));
            }

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

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void AddNewRowForFillingFoodData_DataGrid_Click(object sender, RoutedEventArgs e)
        {

        }
        
        private void RemoveRowFromFoodData_Click(object sender, RoutedEventArgs e)
        {

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
        
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        private void AddNewRowForFillingEquipmentData_DataGrid_Click(object sender, RoutedEventArgs e)
        {

            DataGridForFillingEquipmentData.Items.Add(new GroupEquipment());

        }

        private void RemoveRowFromEquipmentData_Click(object sender, RoutedEventArgs e)
        {
            DataGridForFillingEquipmentData.Items.RemoveAt(DataGridForFillingEquipmentData.SelectedIndex);
        }
        
        private void SaveChangesOfEquipmentData_Click(object sender, RoutedEventArgs e)
        {

            MenuButton.IsEnabled = true;
            MenuButton.Visibility = Visibility.Visible;

            HeaderOfSection.IsEnabled = true;
            HeaderOfSection.Visibility = Visibility.Visible;
        
            GroupEquipmentManager manager = new GroupEquipmentManager();

            List<GroupEquipment> groupEquipment = new List<GroupEquipment> { };

            foreach(NewRecordOfEquiment equiment in EquipmentOwnersList.Items)
            {

                GroupMembership membership = equiment.Membership;

                foreach (GroupEquipment equipment in equiment.Data.Items)
                {
                    equipment.UserID = membership.UserId;
                    groupEquipment.Add(equipment);
                }
            }

            manager.AddGroupEquipment(groupEquipment);

        }
        
        private void EquipmentOwnersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(e.RemovedItems[0] != null)
            {
                ((ActiveCampWPF.NewRecordOfEquiment)e.RemovedItems[0]).Data.ItemsSource = DataGridForFillingEquipmentData.ItemsSource;
            }
            if(EquipmentOwnersList.SelectedValue != null)
            {
                DataGridForFillingEquipmentData.ItemsSource = ((ActiveCampWPF.NewRecordOfEquiment)EquipmentOwnersList.SelectedValue).Data.ItemsSource;
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
            title.Inlines.Add(new Bold(new Run(newsTitle)));            

            Paragraph mainBodyOfNews = new Paragraph();
            mainBodyOfNews.Inlines.Add(new Run(descriptionOfnews));
            
            List newsBodyList = new List();
            newsBodyList.ListItems.Add(new ListItem(mainBodyOfNews));

            FlowDocument flowDocument = new FlowDocument();
            flowDocument.Blocks.Add(title);
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

        private void UpdateHikingList()
        {
            HikkingList.ItemsSource = null;
            List<Route> routes = new List<Route> { };
            RouteManager routeController = new RouteManager();
            routes = routeController.GetAllRoutes();

            List<hikingItem> source = new List<hikingItem> { };

            foreach (Route route in routes)
            {
                source.Add(new hikingItem(route));
            }

            HikkingList.ItemsSource = source;
        }

        private void HikkingList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Route routeInfo = ((ActiveCampWPF.hikingItem)HikkingList.SelectedValue).RouteItem;

            Paragraph title = new Paragraph();
            title.Inlines.Add(new Bold(new Run(routeInfo.RouteName)));

            Paragraph description = new Paragraph();
            description.Inlines.Add(new Run($"Описание:\n\n{routeInfo.Description}"));

            Paragraph dates = new Paragraph();
            dates.Inlines.Add($"Данный поход будет проходить с {routeInfo.StartDate} по {routeInfo.EndDate}");

            Paragraph tripInfo = new Paragraph();
            tripInfo.Inlines.Add($"Маршрут начинается с точки {routeInfo.StartPoint} и заканчивается в точке {routeInfo.EndPoint}, протяженность маршрута состовляет {routeInfo.Length} км.");
            
            Paragraph level = new Paragraph();
            level.Inlines.Add($"Уровень сложеность маршрута: {routeInfo.Difficulty}");

            Paragraph count = new Paragraph();
            count.Inlines.Add($"Планируемое чило участников: {routeInfo.MemberCount}");

            List newsBodyList = new List();
            newsBodyList.ListItems.Add(new ListItem(level));
            newsBodyList.ListItems.Add(new ListItem(description));
            newsBodyList.ListItems.Add(new ListItem(dates));
            newsBodyList.ListItems.Add(new ListItem(tripInfo));
            newsBodyList.ListItems.Add(new ListItem(count));

            FlowDocument flowDocument = new FlowDocument();
            flowDocument.Blocks.Add(title);
            flowDocument.Blocks.Add(newsBodyList);

            Discription_of_Hikking.Document = flowDocument;
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
            RouteManager routeManager = new RouteManager();
            Route NewRoute = new Route(ActiveCamp.BL.User.UserID, NameOfHiking.Text, DateTime.Parse(DateFrom.SelectedDate.ToString()), DateTime.Parse(DateTo.SelectedDate.ToString()), LittleDiscription.Text, PointFrom.Text, PointTo.Text, Double.Parse(TripLengthInKM.Text), LevelOfHiking.Text, Int32.Parse(CountOfMember.Text), false);
            routeManager.AddRoute(NewRoute);

            DoubleAnimation openAnimation = new DoubleAnimation();

            openAnimation.AutoReverse = true;
            openAnimation.SpeedRatio = 2;
            openAnimation.From = 0;
            openAnimation.To = 1;
            openAnimation.Duration = new Duration(TimeSpan.Parse("0:0:5"));

            SavingSucssesfulMessage.BeginAnimation(OpacityProperty, openAnimation);

            UpdateHikingList();

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

        private void UpdateSetting()
        {
            UserProfileManager manager = new UserProfileManager();
            UserProfile userProfile = manager.GetUserProfile(ActiveCamp.BL.User.UserID);

            //IllnessManager illnessManager = new IllnessManager();
            //Illness illness = illnessManager.GetIllness(;

            if (userProfile != null)
            {
                FirstName.Text = userProfile.FirstName;
                SecondName.Text = userProfile.SecondName;
                UserWeight.Text = userProfile.Weight.ToString();
                UserHeight.Text = userProfile.Height.ToString();


            }
        }
        
        private void SaveSetings_Click(object sender, RoutedEventArgs e)
        {
            UserProfileManager manager = new UserProfileManager();
            UserProfile userProfile = manager.GetUserProfile(ActiveCamp.BL.User.UserID);

            if (userProfile != null)
            {
                userProfile.FirstName = FirstName.Text;
                userProfile.SecondName = SecondName.Text;
                userProfile.Weight = float.Parse(UserWeight.Text);
                userProfile.Height = float.Parse(UserHeight.Text);
            }

            manager.UpdateUserProfile(userProfile);
        }

        #endregion

    }
}