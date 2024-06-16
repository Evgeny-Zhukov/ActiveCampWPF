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
using ActiveCamp.BL.Model;

namespace ActiveCampWPF
{
    /// <summary>
    /// Логика взаимодействия для hikingItem.xaml
    /// </summary>
    public partial class hikingItem : UserControl, INotifyPropertyChanged, IEditableObject
    {

        private Route _routeitem;

        public Route RouteItem
        {
            get
            {
                return _routeitem;
            }
            set
            {
                if (value != _routeitem)
                {
                    _routeitem = value;
                    NotifyPropertyChanged(nameof(RouteItem));
                }
            }
        }

        public hikingItem(Route routeItem)
        {
            InitializeComponent();
            _routeitem = routeItem;
        }

        private hikingItem temp_Record = null;
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
                temp_Record = this.MemberwiseClone() as hikingItem;
                m_Editing = true;
            }
        }

        public void CancelEdit()
        {
            if (m_Editing == true)
            {
                this._routeitem = temp_Record.RouteItem;
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
