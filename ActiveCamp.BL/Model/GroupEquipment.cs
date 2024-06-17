using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ActiveCamp.BL.Model
{
    public class GroupEquipment : INotifyPropertyChanged, IEditableObject
    {
        private int _groupEquipmentID;
        private int _groupID;
        private int _userID;
        private string _equipmentName;
        private int _weigth;
        private int _count;
        private string _description;


        public int GroupEquipmentID
        {
            get { return this._groupEquipmentID; }
            set
            {
                if (value != this._groupEquipmentID)
                {
                    this._groupEquipmentID = value;
                    NotifyPropertyChanged("GroupEquipmentID");
                }
            }
        }
        public int GroupID
        {
            get { return this._groupID; }
            set
            {
                if (value != this._groupID)
                {
                    this._groupID = value;
                    NotifyPropertyChanged("GroupID");

                }
            }
        }
        public int UserID
        {
            get { return this._userID; }
            set
            {
                if (value != this._userID)
                {
                    this._userID = value;
                    NotifyPropertyChanged("UserID");
                }
            }
        }
        public string EquipmentName
        {
            get { return this._equipmentName; }
            set
            {
                if (value != this._equipmentName)
                {
                    this._equipmentName = value;
                    NotifyPropertyChanged("EquipmentName");
                }
            }
        }
        public int Weigth
        {
            get { return this._weigth; }
            set
            {
                if (value != this._weigth)
                {
                    this._weigth = value;
                    NotifyPropertyChanged("Weigth");
                }
            }
        }
        public int Count
        {
            get { return this._count; }
            set
            {
                if (value != this._count)
                {
                    this._count = value;
                    NotifyPropertyChanged("Count");
                }
            }
        }

        public string Description
        {
            get => this._description;
            set
            {
                if(value != this._description)
                {
                    this._description = value;
                    NotifyPropertyChanged("Description");
                }
            }
        }

        public GroupEquipment() { }
        public GroupEquipment(int groupID, int userID, int weigth, int count = 0, string equipmentName = "")
        {
            this._groupID = groupID;
            this._userID = userID;
            this._weigth = weigth;
            this._count = count;
            this._equipmentName = equipmentName;
        }
        private GroupEquipment temp_Record = null;
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
                temp_Record = this.MemberwiseClone() as GroupEquipment;
                m_Editing = true;
            }
        }

        public void CancelEdit()
        {
            if (m_Editing == true)
            {
                _groupID = temp_Record.GroupID;
                _groupEquipmentID = temp_Record.GroupEquipmentID;
                _userID = temp_Record.UserID;
                _weigth = temp_Record.Weigth;
                _count = temp_Record.Count;
                _description = temp_Record.Description;
                _equipmentName = temp_Record.EquipmentName;


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

    public class GroupEquipments : ObservableCollection<GroupEquipment>
    {

    }
}
