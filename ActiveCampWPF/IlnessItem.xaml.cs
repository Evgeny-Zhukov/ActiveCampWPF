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
    /// Логика взаимодействия для IlnessItem.xaml
    /// </summary>
    public partial class IlnessItem : UserControl, INotifyPropertyChanged, IEditableObject
    {

        private IlnessItem ilness;
        private UserIllness userIllness;


        public IlnessItem Ilness
        {
            get { return ilness; }
            set
            {
                if (ilness != value)
                {
                    ilness = value;
                    NotifyPropertyChanged(nameof(ilness));
                }
            }
        }

        public UserIllness UserIllness
        {
            get => userIllness;
            set
            {
                if(userIllness != value)
                {
                    userIllness = value;
                    NotifyPropertyChanged(nameof(UserIllness));
                }
            }
        }

        public IlnessItem()
        {
            InitializeComponent();
        }

        private IlnessItem temp_Record = null;
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
                temp_Record = this.MemberwiseClone() as IlnessItem;
                m_Editing = true;
            }
        }

        public void CancelEdit()
        {
            if (m_Editing == true)
            {
                this.ilness = temp_Record.Ilness;
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
