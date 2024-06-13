
using ActiveCamp.BL.Controller;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ActiveCamp.BL.Model
{
    public class UserIllness : INotifyPropertyChanged, IEditableObject
    {
        #region Свойства
        private int _userIllnessID;
        private int _userID;
        private int _illnessID;
        /// <summary>
        /// Получает идентификатор заболевания пользователя.
        /// </summary>
        public int UserIllnessId
        {
            get { return this._userIllnessID; }
            set
            {
                if (value != this._userIllnessID)
                {
                    this._userIllnessID = value;
                    NotifyPropertyChanged("UserIllnessId");

                }
            }
        }

        /// <summary>
        /// Получает идентификатор пользователя.
        /// </summary>
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

        /// <summary>
        /// Получает идентификатор заболевания.
        /// </summary>
        public int IllnessID
        {
            get { return this._illnessID; }
            set
            {
                if (value != this._illnessID)
                {
                    this._illnessID = value;
                    NotifyPropertyChanged("IllnessID");
                }
            }
        }
        #endregion

        /// <summary>
        /// Создает заболевание пользователя.
        /// </summary>
        public UserIllness() { }

        /// <summary>
        /// Создает заболевание пользователя с указанными идентификаторами.
        /// </summary>
        /// <param name="userIllnessId">Идентификатор заболевания пользователя</param>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="illnessId">Идентификатор заболевания</param>
        public UserIllness( int userId, int illnessId)
        {
            this._userID = userId;
            this._illnessID = illnessId;
        }

        private UserIllness temp_Record = null;
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
                temp_Record = this.MemberwiseClone() as UserIllness;
                m_Editing = true;
            }
        }

        public void CancelEdit()
        {
            if (m_Editing == true)
            {
                _userIllnessID = temp_Record.UserIllnessId;
                _userID = temp_Record.UserID;
                _illnessID = temp_Record._illnessID;

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
