using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ActiveCamp.BL.Model
{
    public class Group : INotifyPropertyChanged, IEditableObject
    {
        #region Свойства
        private int _groupID;
        private int _routeID;
        private string _invitationLink;
        private List<int> _userIDs;
        private int _groupSupervisor;

        public event PropertyChangedEventHandler PropertyChanged;

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
                    NotifyPropertyChanged("UserEquipmentID");

                }
            }
        }
        /// <summary>
        /// ИД маршрута.
        /// </summary>
        public int RouteId
        {
            get { return this._routeID; }
            set
            {
                if (value != this._routeID)
                {
                    this._routeID = value;
                    NotifyPropertyChanged("RouteID");

                }
            }
        }

        /// <summary>
        /// Ссылка-приглашение.
        /// </summary>
        public string InvitationLink
        {
            get { return this._invitationLink; }
            set
            {
                if (value != this._invitationLink)
                {
                    this._invitationLink = value;
                    NotifyPropertyChanged("InvitationLink");

                }
            }
        }

        /// <summary>
        /// Идентификаторы пользователей.
        /// </summary>
        public List<int> UserIds
        {
            get { return this._userIDs; }
            set
            {
                if (value != this._userIDs)
                {
                    this._userIDs = value;
                    NotifyPropertyChanged("UserIDs");

                }
            }
        }

        /// <summary>
        /// Руководитель группы.
        /// </summary>
        public int GroupSupervisor
        {
            get { return this._groupSupervisor; }
            set
            {
                if (value != this._groupSupervisor)
                {
                    this._groupSupervisor = value;
                    NotifyPropertyChanged("GroupSupervisor");

                }
            }
        }
        #endregion

        public Group() { }

        /// <summary>
        /// Создает новую группу.
        /// </summary>
        /// <param name="routeId">ИД маршрута</param>
        /// <param name="invitationLink">Ссылка-приглашение</param>
        /// <param name="groupSupervisor">Руководитель группы</param>
        /// <param name="userIds">Идентификаторы пользователей</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Group(int routeId, string invitationLink, int groupSupervisor, List<int> userIds)
        {
            this._routeID = routeId;
            this._invitationLink = invitationLink;
            this._groupID = groupSupervisor;
            this._userIDs = userIds;
        }
        private Group temp_Record = null;
        private bool m_Editing = false;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void BeginEdit()
        {
            if(m_Editing == false)
            {
                temp_Record = this.MemberwiseClone() as Group;
                m_Editing = true;
            }
        }

        public void EndEdit()
        {
            if (!m_Editing == true)
            {
                _groupID = temp_Record._groupID;
                _invitationLink = temp_Record._invitationLink;
                _groupID = temp_Record._groupID;
                _userIDs = temp_Record._userIDs;
            }
        }

        public void CancelEdit()
        {
            if(m_Editing == true)
            {
                temp_Record = null;
                m_Editing = false;
            }
        }
    }

}
