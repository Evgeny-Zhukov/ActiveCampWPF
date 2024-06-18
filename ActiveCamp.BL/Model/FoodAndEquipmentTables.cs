using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ActiveCamp.BL.Model
{

    public class RecordOfUserEquipment : INotifyPropertyChanged, IEditableObject
    {

        private int _userID;
        private string _userName;
        private string _equipmentName;
        private int _weigth;
        private int _count;
        private string _description;



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

        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                if(_userName != value)
                {
                    _userName = value;
                    NotifyPropertyChanged(nameof(UserName));
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
                if (value != this._description)
                {
                    this._description = value;
                    NotifyPropertyChanged("Description");
                }
            }
        }

        public RecordOfUserEquipment() { }
        public RecordOfUserEquipment(string userName, int userID, int weigth, int count = 0, string equipmentName = "")
        {
            this._userName = userName;
            this._userID = userID;
            this._weigth = weigth;
            this._count = count;
            this._equipmentName = equipmentName;
        }

        private RecordOfUserEquipment temp_Record = null;
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
                temp_Record = this.MemberwiseClone() as RecordOfUserEquipment;
                m_Editing = true;
            }
        }

        public void CancelEdit()
        {
            if (m_Editing == true)
            {
                _userName = temp_Record.UserName;
                _equipmentName = temp_Record.EquipmentName;
                _description = temp_Record.Description;
                _weigth = temp_Record.Weigth;
                _count = temp_Record.Count;

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
    
    public class RecordsOfEqipmentsTable : ObservableCollection<RecordOfUserEquipment>
    {

    }
    
    public class RecordOfFoodTable : INotifyPropertyChanged, IEditableObject
    {

        private string m_foodTime;
        private string m_foodName;
        private string m_day;
        private int m_amountPerPerson;
        private int m_amountPerGroup;
        private string m_description;

        private RecordOfFoodTable temp_Record = null;
        private bool m_Editing = false;


        public string FoodTime
        {
            get { return this.m_foodTime;}
            set
            {
                if(value != this.m_foodTime)
                {
                    this.m_foodTime = value;
                    NotifyPropertyChanged("foodTime");
                }
            }
        }
        public string Day 
        { 
            get {return this.m_day; } 
            set 
            { 
                if (value != this.m_day) 
                { 
                    this.m_day = value; 
                    NotifyPropertyChanged("day"); 
                } 
            } 
        }
        public string FoodName
        {
            get { return this.m_foodName; }
            set
            {
                if (value != this.m_foodName)
                {
                    this.m_foodName = value;
                    NotifyPropertyChanged("foodName");
                }
            }
        }
        public string Description 
        { 
            get { return this.m_description; } 
            set 
            { 
                if(value != this.m_description)
                {
                    this.m_description = value;
                    NotifyPropertyChanged("description");
                }
            } 
        }
        public int AmountPerPerson
        {
            get { return this.m_amountPerPerson; }
            set
            {
                if( value != this.m_amountPerPerson)
                {
                    this.m_amountPerPerson = value;
                    NotifyPropertyChanged("amountPerPerson");
                }
            }
        }
        public int AmountPerGroup 
        {
            get { return this.m_amountPerGroup; }
            set
            {
                if (value != this.m_amountPerGroup)
                {
                    this.m_amountPerGroup = value;
                    NotifyPropertyChanged("amountPerGroup");
                }
            }
        }

        public RecordOfFoodTable(string foodTime = "", string day = null, string foodName = null, string description = null, int amountPerGroup = 0, int amountPerPerson = 0)
        {
            this.m_foodTime = foodTime;
            this.m_day = day;
            this.m_foodName = foodName;
            this.m_description = description;
            this.m_amountPerPerson = amountPerPerson;
            this.m_amountPerGroup = amountPerGroup;
        }

        public RecordOfFoodTable(){ }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void BeginEdit()
        {
            if (m_Editing == false)
            {
                temp_Record = this.MemberwiseClone() as RecordOfFoodTable;
                m_Editing = true;
            }
        }

        public void CancelEdit()
        {
            if (m_Editing == true)
            {
                this.Day = temp_Record.Day;
                this.FoodTime = temp_Record.FoodTime;
                this.FoodName = temp_Record.FoodName;
                this.Description = temp_Record.Description;
                this.AmountPerPerson = temp_Record.AmountPerPerson;
                this.AmountPerGroup = temp_Record.AmountPerGroup;

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

    public class RecordsOfFoodTable : ObservableCollection<RecordOfFoodTable>
    {

    }

    public class RecordOfFoodTablePerPerson : INotifyPropertyChanged, IEditableObject
    {
        private string _person;
        private string _FoodName;
        private int m_amountPerPerson;
        private string _description;


        private RecordOfFoodTablePerPerson temp_Record = null;
        private bool m_Editing = false;

        public RecordOfFoodTablePerPerson(string Person, string FoodName, int AmaountPerPerson, string Description)
        {
            this._person = Person;
            this._FoodName = FoodName;
            this.m_amountPerPerson = AmaountPerPerson;
            this._description = Description;
        }

        public RecordOfFoodTablePerPerson()
        {

        }

        public string Person
        {
            get { return this._person; }
            set
            {
                if (this._person != value)
                {
                    this._person = value;
                    NotifyPropertyChanged("Person");
                }
            }
        }

        public string Foodname
        {
            get { return this._FoodName; }
            set
            {
                if (this._FoodName != value)
                {
                    this._FoodName = value;
                    NotifyPropertyChanged("Foodname");
                }
            }
        }

        public int AmountPerPerson
        {
            get { return this.m_amountPerPerson; }
            set
            {
                if (this.m_amountPerPerson != value)
                {
                    this.m_amountPerPerson = value;
                    NotifyPropertyChanged("AmountPerPerson");
                }
            }
        }

        public string Description
        {
            get { return this._description; }
            set
            {
                if (value != this._description)
                {
                    this._description = value;
                    NotifyPropertyChanged("Description");
                }
            }
        }

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
                temp_Record = this.MemberwiseClone() as RecordOfFoodTablePerPerson;
                m_Editing = true;
            }
        }

        public void CancelEdit()
        {
            if (m_Editing == true)
            {
                this._person = temp_Record.Person;
                this._FoodName = temp_Record.Foodname;
                this.m_amountPerPerson = temp_Record.AmountPerPerson;
                this._description = temp_Record.Description;
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

    public class RecordsOfFoodTablePerPerson : ObservableCollection<RecordOfFoodTablePerPerson>
    {

    }

}
