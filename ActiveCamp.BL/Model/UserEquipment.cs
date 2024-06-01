using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ActiveCamp.BL.Model
{
    public class UserEquipment : INotifyPropertyChanged, IEditableObject
    {
        private int _userEquipmentID;
        private string _equipmentName;
        private int _countOfEquipment;
        private double _wightOfEquipment;
        private string _equipmentDescription;
        private int _ownerID;

        public int UserEquipmentID 
        { 
            get { return this._userEquipmentID; }
            set 
            { 
                if(value != this._userEquipmentID)
                {
                    this._userEquipmentID = value;
                    NotifyPropertyChanged("UserEquipmentID");
                }
            } 
        }

        public string EquipmentName
        {
            get { return this._equipmentName; }
            set 
            { 
                if(value != this._equipmentName)
                {
                    this._equipmentName = value;
                    NotifyPropertyChanged("EquipmentName");
                }
            }
        }

        public int CountOfEquipment
        {
            get
            {
                return this._countOfEquipment;
            }
            set
            {
                if(this._countOfEquipment != value)
                {
                    this._countOfEquipment = value;
                    NotifyPropertyChanged("CountOfEquipment");
                }
            }
        }

        public double WightOfEquipment
        {
            get { return this._wightOfEquipment;}
            set
            {
                this._wightOfEquipment = value;
                NotifyPropertyChanged("WightOfEquipment");
            }
        }

        public int OwnerID 
        { 
            get { return _ownerID; } 
            set
            {
                if(value != this._ownerID)
                {
                    this._ownerID = value;
                    NotifyPropertyChanged("OwnerID");
                }
            }
        }

        public string EquipmentDescription
        {
            get { return _equipmentDescription; }
            set
            {
                if(value != this._equipmentDescription)
                {
                    this._equipmentDescription = value;
                    NotifyPropertyChanged("EquipmentDescription");
                }
            } 
        }
        
        public UserEquipment() { }

        public UserEquipment(int userEquipmentID, string equipmentName, int countOfEquipment, double wightOfEquipment, int ownerID, string equipmentDescription) 
        { 
            this._userEquipmentID = userEquipmentID;
            this._equipmentName = equipmentName;
            this._countOfEquipment = countOfEquipment;
            this._wightOfEquipment= wightOfEquipment;
            this._ownerID = ownerID;
            this._equipmentDescription = equipmentDescription;
        }

        private UserEquipment temp_Record = null;
        private bool m_Editing = false;

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void BeginEdit()
        {
            if (m_Editing == false)
            {
                temp_Record = this.MemberwiseClone() as UserEquipment;
                m_Editing = true;
            }
        }

        public void CancelEdit()
        {
            if (m_Editing == true)
            {
                _ownerID = temp_Record.OwnerID;
                _equipmentName = temp_Record.EquipmentName;
                _equipmentDescription = temp_Record.EquipmentDescription;
                _userEquipmentID = temp_Record.UserEquipmentID;
                _wightOfEquipment = temp_Record.WightOfEquipment;
                _countOfEquipment = temp_Record.CountOfEquipment;

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

    public class RecordsOfEqipmentsTable : ObservableCollection<UserEquipment>
    {

    }
}
