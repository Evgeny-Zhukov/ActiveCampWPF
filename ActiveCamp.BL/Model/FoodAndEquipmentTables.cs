using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ActiveCamp.BL.Model
{

    public class RecordOfUserEquipment : INotifyPropertyChanged, IEditableObject
    {

        private string _ownerName;
        private string _equipmentName;
        private int _countOfEquipment;
        private double _wightOfEquipment;
        private string _equipmentDescription;

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

        public int CountOfEquipment
        {
            get
            {
                return this._countOfEquipment;
            }
            set
            {
                if (this._countOfEquipment != value)
                {
                    this._countOfEquipment = value;
                    NotifyPropertyChanged("CountOfEquipment");
                }
            }
        }

        public double WightOfEquipment
        {
            get { return this._wightOfEquipment; }
            set
            {
                this._wightOfEquipment = value;
                NotifyPropertyChanged("WightOfEquipment");
            }
        }

        public string EquipmentDescription
        {
            get { return _equipmentDescription; }
            set
            {
                if (value != this._equipmentDescription)
                {
                    this._equipmentDescription = value;
                    NotifyPropertyChanged("EquipmentDescription");
                }
            }
        }

        public string OwnerName
        {
            get => _ownerName;
            set
            {
                if(value != _ownerName)
                {
                    _ownerName = value;
                    NotifyPropertyChanged(nameof(OwnerName));
                }
            }
        }

        public RecordOfUserEquipment() { }

        public RecordOfUserEquipment(string ownerName, string equipmentName, int countOfEquipment, double wightOfEquipment, string equipmentDescription)
        {
            this._ownerName = ownerName;
            this._equipmentName = equipmentName;
            this._countOfEquipment = countOfEquipment;
            this._wightOfEquipment = wightOfEquipment;
            this._equipmentDescription = equipmentDescription;
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
                _equipmentName = temp_Record.EquipmentName;
                _equipmentDescription = temp_Record.EquipmentDescription;
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
