using ActiveCamp.BL.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ActiveCamp.BL.Model
{
    public class UserEquipment : INotifyPropertyChanged, IEditableObject
    {
        #region Свойства
        private int _userEquipmentID;
        private int _userID;
        private int _equipmentID;
        private int _countOfEquipment;
        /// <summary>
        /// Получает идентификатор снаряжения пользователя.
        /// </summary>
        public int UserEquipmentId
        {
            get { return this._userEquipmentID; }
            set
            {
                if (value != this._userEquipmentID)
                {
                    this._userEquipmentID = value;
                    NotifyPropertyChanged("UserEquipmentID");

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
        /// Получает идентификатор снаряжения.
        /// </summary>
        public int EquipmentID
        {
            get { return this._equipmentID; }
            set
            {
                if (value != this._equipmentID)
                {
                    this._equipmentID = value;
                    NotifyPropertyChanged("EquipmentID");

                }
            }
        }
        public int CountOfEquipment
        {
            get { return this._countOfEquipment; }
            set
            {
                if (value != this._countOfEquipment)
                {
                    this._countOfEquipment = value;
                    NotifyPropertyChanged("CountOfEquipment");
                }
            }
        }
        #endregion

        /// <summary>
        /// Создает снаряжение пользователя.
        /// </summary>
        public UserEquipment() { }

        /// <summary>
        /// Создает снаряжения пользователя с указанными идентификаторами.
        /// </summary>
        /// <param name="userIllnessId">Идентификатор снаряжения пользователя</param>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="illnessId">Идентификатор снаряжения</param>
        public UserEquipment(int userId, int equipmentID)
        {
            this._userID = userId;
            this._equipmentID = equipmentID;
        }

        private UserEquipment temp_Record = null;
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
                temp_Record = this.MemberwiseClone() as UserEquipment;
                m_Editing = true;
            }
        }

        public void CancelEdit()
        {
            if (m_Editing == true)
            {
                _userEquipmentID = temp_Record.UserEquipmentId;
                _userID = temp_Record.UserID;
                _equipmentID = temp_Record.EquipmentID;

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
