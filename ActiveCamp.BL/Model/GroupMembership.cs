using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ActiveCamp.BL.Model
{
    public class GroupMembership : INotifyPropertyChanged, IEditableObject
    {
        #region Свойства
        private int _groupMembershipID;
        private int _groupID;
        private int _userID;
        private bool _isAproved;
        private DateTime _joinedDate;
        /// <summary>
        /// ИД группы.
        /// </summary>
        public int GroupId
        {
            get { return this._groupID; }
            set
            {
                if (value != this._groupID)
                {
                    this._groupID = value;
                    NotifyPropertyChanged("GroupId");
                }
            }
        }
        public int GroupMembershipID
        {
            get { return this._groupMembershipID; }
            set
            {
                if (value != this._groupMembershipID)
                {
                    this._groupMembershipID = value;
                    NotifyPropertyChanged("GroupMembershipID");
                }
            }
        }
        /// <summary>
        /// ИД пользователя.
        /// </summary>
        public int UserId
        {
            get { return this._userID; }
            set
            {
                if (value != this._userID)
                {
                    this._userID = value;
                    NotifyPropertyChanged("UserId");
                }
            }
        }
        public bool IsAproved
        {
            get { return this._isAproved; }
            set
            {
                if (value != this._isAproved)
                {
                    this._isAproved = value;
                    NotifyPropertyChanged("IsAproved");
                }
            }
        }
        /// <summary>
        /// Дата присоединения.
        /// </summary>
        public DateTime JoinedDate
        {
            get { return this._joinedDate; }
            set
            {
                if (value != this._joinedDate)
                {
                    this._joinedDate = value;
                    NotifyPropertyChanged("JoinedDate");
                }
            }
        }
        #endregion

        public GroupMembership() { }

        /// <summary>
        /// Создает членство в группе.
        /// </summary>
        /// <param name="groupId">ИД группы</param>
        /// <param name="userId">ИД пользователя</param>
        /// <param name="joinedDate">Дата присоединения</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public GroupMembership(int groupId, int userId, DateTime joinedDate)
        {
            this._groupID = groupId;
            this._userID = userId;
            this._joinedDate = joinedDate;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private GroupMembership temp_Record = null;
        private bool m_Editing = false;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void BeginEdit()
        {
            if(m_Editing == false)
            {
                temp_Record = this.MemberwiseClone() as GroupMembership;
                m_Editing = true;
            }
        }

        public void EndEdit()
        {
            if (m_Editing == true)
            {
                _groupID = temp_Record._groupID;
                _userID = temp_Record._userID;
                _joinedDate = temp_Record._joinedDate;
                _isAproved = temp_Record._isAproved;
                _groupMembershipID = temp_Record._groupMembershipID;

                m_Editing = false;
            }
        }

        public void CancelEdit()
        {
            if (m_Editing == true)
            {
                temp_Record = null;
                m_Editing = false;
            }
        }

        /// <summary>
        /// Внутренний метод для установки ИД членства в группе, доступен только внутри сборки.
        /// </summary>
        /// <param name="groupMembershipId">ИД членства в группе</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
    }

}
