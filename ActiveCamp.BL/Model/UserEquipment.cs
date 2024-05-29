using System.ComponentModel;

namespace ActiveCamp.BL.Model
{
    public class UserEquipment : INotifyPropertyChanged, IEditableObject
    {
        private int _userEquipmentID;
        private int _equipmentID;
        private string _equipmentName;
        private string _equipmentDescription;
        private string _userID;

        public int UserEquipmentID 
        { 
            get { return this._userEquipmentID; }
            set 
            { 
                if(value != this._userEquipmentID)
                {
                    this._userEquipmentID = value;

                }
            } 
        }
        public int UserID { get; set; }
        public int EquipmentID { get; set; }
        
        public UserEquipment() { }

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
