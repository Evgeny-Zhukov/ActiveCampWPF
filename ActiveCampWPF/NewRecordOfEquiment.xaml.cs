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
    /// Логика взаимодействия для NewRecordOfEquiment.xaml
    /// </summary>
    public partial class NewRecordOfEquiment : UserControl, INotifyPropertyChanged, IEditableObject
    {

        private GroupMembership membership;
        private DataGrid data;

        public GroupMembership Membership
        {
            get { return membership; }
            set
            {
                if (membership != value)
                {
                    value = membership;
                    NotifyPropertyChanged(nameof(Membership));
                }
            }
        }

        public DataGrid Data
        {
            get => data;
            set
            {
                if(data != value)
                {
                    data = value;
                    NotifyPropertyChanged(nameof(Data));
                }
            }
        }

        public NewRecordOfEquiment(GroupMembership membership)
        {
            InitializeComponent();
            Membership = membership;
        }

        private NewRecordOfEquiment temp_Record = null;
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
                temp_Record = this.MemberwiseClone() as NewRecordOfEquiment;
                m_Editing = true;
            }
        }

        public void CancelEdit()
        {
            if (m_Editing == true)
            {
                data = temp_Record.Data;
                membership = temp_Record.Membership;
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
