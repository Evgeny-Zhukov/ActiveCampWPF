using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ActiveCamp.BL.Model
{
    public class GroupDish : INotifyPropertyChanged, IEditableObject
    {
        private int _groupDishID;
        private int _groupID;
        private int _routeDay;
        private string _dishName;
        private int _weigth1;
        private int _weigthAll;
        private string _dishTime;
        private string _comment;


        public int GroupDishID
        {
            get { return this._groupDishID; }
            set
            {
                if (value != this._groupDishID)
                {
                    this._groupDishID = value;
                    NotifyPropertyChanged("GroupDishID");

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
        public int RouteDay
        {
            get { return this._routeDay; }
            set
            {
                if (value != this._routeDay)
                {
                    this._routeDay = value;
                    NotifyPropertyChanged("RouteDay");
                }
            }
        }
        public string DishName
        {
            get { return this._dishName; }
            set
            {
                if (value != this._dishName)
                {
                    this._dishName = value;
                    NotifyPropertyChanged("DishName");
                }
            }
        }
        public int Weigth1
        {
            get { return this._weigth1; }
            set
            {
                if (value != this._weigth1)
                {
                    this._weigth1 = value;
                    NotifyPropertyChanged("Weigth1");
                }
            }
        }
        public int WeigthAll
        {
            get { return this._weigthAll; }
            set
            {
                if (value != this._weigthAll)
                {
                    this._weigthAll = value;
                    NotifyPropertyChanged("WeigthAll");
                }
            }
        }
        public string DishTime
        {
            get { return this._dishTime; }
            set
            {
                if (value != this._dishTime)
                {
                    this._dishTime = value;
                    NotifyPropertyChanged("DishTime");
                }
            }
        }
        public string Comment
        {
            get { return this._comment; }
            set
            {
                if (value != this._comment)
                {
                    this._comment = value;
                    NotifyPropertyChanged("Comment");
                }
            }
        }
        public GroupDish() { }
        public GroupDish(int groupID, int routeDay,int weigth1, string dishTime, string comment = "", string dishName = "")
        {
            this._groupID = groupID;
            this._routeDay = routeDay;
            this._weigth1 = weigth1;
            this._dishTime = dishTime;
            this._comment = comment;
            this._dishTime = dishTime;
        }
        private GroupDish temp_Record = null;
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
                temp_Record = this.MemberwiseClone() as GroupDish;
                m_Editing = true;
            }
        }

        public void CancelEdit()
        {
            if (m_Editing == true)
            {
                _groupDishID = temp_Record.GroupDishID;
                _groupID = temp_Record.GroupID;
                _dishName = temp_Record.DishName;
                _weigth1 = temp_Record.Weigth1;
                _weigthAll = temp_Record.WeigthAll;
                _dishTime = temp_Record.DishTime;
                _comment = temp_Record.Comment;

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
