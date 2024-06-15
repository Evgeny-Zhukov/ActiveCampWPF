using ActiveCamp;
using ActiveCamp.BL.Controller;
using ActiveCamp.BL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;


namespace ActiveCampWPF
{
    /// <summary>
    /// Логика взаимодействия для NewHikkingListItem.xaml
    /// </summary>
    public partial class NewHikkingListItem : UserControl, INotifyPropertyChanged, IEditableObject
    {

        private News _newsItem;
        private bool _itsAdminMessage;
        private bool _itsFavorMessage;

        public News NewsItem 
        { 
            get 
            { 
                return _newsItem; 
            }
            set
            {
                if (_newsItem != value)
                {
                    _newsItem = value;
                    NotifyPropertyChanged(nameof(NewsItem));
                }
            }
        }

        public bool ItsAdminMessage
        {
            get { return _itsAdminMessage; }
        }

        public bool ItsFavorMessage
        {
            get { return _itsFavorMessage; }
        }

        public NewHikkingListItem(News news)
        {
            InitializeComponent();
            _newsItem = news;
            NewsHeader.Text = news.NewsTitle;
            
            if(news.IsAdminNews == true)
            {
                _itsAdminMessage = true;
                MarkOfAdminMassage.Visibility = Visibility.Visible;
            }

            List<FavorNews> favorNews = new List<FavorNews>();
            FavorNewsController controller = new FavorNewsController();
            favorNews = controller.GetNews(ActiveCamp.BL.User.UserID);
            foreach(FavorNews favor in favorNews) 
            { 
                if(favor.NewsID == _newsItem.NewsID)
                {
                    FavouriteFlag.IsChecked = true;
                }
            }
        }

        private NewHikkingListItem temp_Record = null;
        private bool m_Editing = false;

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void BeginEdit()
        {
            if (m_Editing == false)
            {
                temp_Record = this.MemberwiseClone() as NewHikkingListItem;
                m_Editing = true;
            }
        }

        public void CancelEdit()
        {
            if (m_Editing == true)
            {
                this._newsItem = temp_Record.NewsItem;
                m_Editing = false;
            }
        }

        public void EndEdit()
        {
            if (m_Editing == true)
            {
                temp_Record = null;
                m_Editing = false;
            }
        }

        private void FavouriteFlag_Checked(object sender, RoutedEventArgs e)
        {
            _itsFavorMessage = true;
            FavorNews favornews = new FavorNews(ActiveCamp.BL.User.UserID, _newsItem.NewsID);
            FavorNewsController controller = new FavorNewsController();
            controller.AddNews(favornews);
        }

        private void FavouriteFlag_Unchecked(object sender, RoutedEventArgs e)
        {
            _itsFavorMessage = false;
            FavorNewsController controller = new FavorNewsController();
            controller.DeleteNews(_newsItem.NewsID, ActiveCamp.BL.User.UserID);
        }
    }
}
