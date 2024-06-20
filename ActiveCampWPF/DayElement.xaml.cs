using System;
using ActiveCampWPF;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ActiveCamp.BL.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace ActiveCampWPF
{
    /// <summary>
    /// Логика взаимодействия для DayElement.xaml
    /// </summary>
    public partial class DayElement : UserControl, INotifyPropertyChanged, IEditableObject
    {

        private RecordOfFoodTable _recordOfFoodTable;
        private string _display;
        private DataGrid _grid;

        private DayElement temp_Record = null;
        private bool m_Editing = false;

        public RecordOfFoodTable RecordOfFoodTable 
        { 
            get { return _recordOfFoodTable; }
            set
            {
                if (_recordOfFoodTable != value)
                {
                    _recordOfFoodTable = value;
                    NotifyPropertyChanged(nameof(RecordOfFoodTable));
                }
            }
        }

        public string Display
        {
            get 
            { 
                return _display; 
            }
            set
            {
                if (_display != value)
                {
                    _display = value;
                    DayInfo_DisplayOfElement.Content = _display;
                    NotifyPropertyChanged(nameof(Display));
                }
            }
        }

        public DataGrid Grid 
        { 
            get { return _grid; }
            set
            {
                if( _grid != value)
                {
                    _grid = value;
                }
            }
        }

        public DayElement(string display)
        {
            InitializeComponent();
            this._display = display;
            DayInfo_DisplayOfElement.Content = display;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void BeginEdit()
        {
            if (m_Editing == false)
            {
                temp_Record = this.MemberwiseClone() as DayElement;
                m_Editing = true;
            }
        }

        public void CancelEdit()
        {
            if (m_Editing == true)
            {
                this.RecordOfFoodTable = temp_Record.RecordOfFoodTable;
                this.Display = temp_Record.Display;

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
