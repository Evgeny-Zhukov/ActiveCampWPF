using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveCamp.BL.Model
{
    public class RecordOfFoodTable : INotifyPropertyChanged, IEditableObject
    {

        private int m_id;
        private string m_foodTime;
        private string m_foodName;
        private string m_day;
        private int m_amountPerPerson;
        private int m_amountPerGroup;
        private string m_description;

        private RecordOfFoodTable temp_Record = null;
        private bool m_Editing = false;

        public int Id 
        { 
            get { return this.m_id;} 
            set 
            { 
                if (value != this.m_id)
                {
                    this.m_id = value;
                    NotifyPropertyChanged("id");
                }
            } 
        }
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

        public RecordOfFoodTable(int id, string foodTime, string day = null, string foodName = null, string description = null, int amountPerGroup = 0, int amountPerPerson = 0)
        {
            this.m_id = id;
            this.m_foodTime = foodTime;
            this.m_day = day;
            this.m_foodName = foodName;
            this.m_description = description;
            this.m_amountPerPerson = amountPerPerson;
            this.m_amountPerGroup = amountPerGroup;
        }

        public RecordOfFoodTable(){ }

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
                temp_Record = this.MemberwiseClone() as RecordOfFoodTable;
                m_Editing = true;
            }
        }

        public void CancelEdit()
        {
            if (m_Editing == true)
            {
                this.Id = temp_Record.Id;
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


}
