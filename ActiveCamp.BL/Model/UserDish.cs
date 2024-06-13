using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ActiveCamp.BL.Model
{
    public class UserDish : INotifyPropertyChanged, IEditableObject
    {

        private int _userID;
        private int _dishID;
        private int _userDishID;


        public int UserDishID { get; set; }
        public int DishID { get; set; }
        public int UserID { get; set; }
        public UserDish() { }
        public UserDish(int dishID, int userID)
        {
            this._dishID = dishID;
            this._userID = userID;
        }
        private UserDish temp_Record = null;
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
                temp_Record = this.MemberwiseClone() as UserDish;
                m_Editing = true;
            }
        }

        public void CancelEdit()
        {
            if (m_Editing == true)
            {
                _userDishID = temp_Record.UserDishID;
                _dishID = temp_Record.DishID;
                _userID = temp_Record.UserID;

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