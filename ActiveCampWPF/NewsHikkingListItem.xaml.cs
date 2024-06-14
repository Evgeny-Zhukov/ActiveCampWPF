using ActiveCamp;
using ActiveCamp.BL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ActiveCampWPF
{
    /// <summary>
    /// Логика взаимодействия для NewHikkingListItem.xaml
    /// </summary>
    public partial class NewHikkingListItem : UserControl, INotifyPropertyChanged, IEditableObject
    {

        private News _newsItem;
        private bool _itsAdminMessage;

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


    }
}
