using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ActiveCamp.BL.Model
{
    public class RecordOfFoodTablePerPerson : INotifyPropertyChanged ,IEditableObject
    {
        private int _id;
        private string _person;
        private string _FoodName;
        private int m_amountPerPerson;
        private string _description;


        private RecordOfFoodTablePerPerson temp_Record = null;
        private bool m_Editing = false;

        public RecordOfFoodTablePerPerson(int id, string Person, string FoodName, int AmaountPerPerson, string Description)
        {
            this._id = id;
            this._person = Person;
            this._FoodName = FoodName;
            this.m_amountPerPerson = AmaountPerPerson;
            this._description = Description;
        }

        public RecordOfFoodTablePerPerson()
        {

        }

        public int Id 
        {
            get { return this._id; }
            set
            { 
                if(this._id != value)
                {
                    this._id = value;
                    NotifyPropertyChanged("Id");
                }
            } 
        } 

        public string Person
        {
            get { return this._person; }
            set
            {
                if(this._person != value)
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
                if(this._FoodName != value)
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
                if(this.m_amountPerPerson != value)
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
                if(value != this._description)
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
                this._id = temp_Record.Id;
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
