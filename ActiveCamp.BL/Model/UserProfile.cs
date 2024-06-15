using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ActiveCamp.BL.Model
{
    public class UserProfile : INotifyPropertyChanged, IEditableObject
    {
        #region Свойства
        private int _userID;
        private string _firstName;
        private string _secondName;
        private float _weight;
        private float _height;
        private List<UserIllness> _userIllness;
        private List<UserEquipment> _userEquipment;
        private List<UserDish> _userDish;
        private int _experienceID;
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
        /// Получает имя пользователя.
        /// </summary>
        public string FirstName
        {
            get { return this._firstName; }
            set
            {
                if (value != this._firstName)
                {
                    this._firstName = value;
                    NotifyPropertyChanged("FirstName");
                }
            }
        }
        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        public string SecondName
        {
            get { return this._secondName; }
            set
            {
                if (value != this._secondName)
                {
                    this._secondName = value;
                    NotifyPropertyChanged("SecondName");
                }
            }
        }

        /// <summary>
        /// Получает вес пользователя.
        /// </summary>
        public float Weight
        {
            get { return this._weight; }
            set
            {
                if (value != this._weight)
                {
                    this._weight = value;
                    NotifyPropertyChanged("Weight");
                }
            }
        }

        /// <summary>
        /// Получает рост пользователя.
        /// </summary>
        public float Height
        {
            get { return this._height; }
            set
            {
                if (value != this._height)
                {
                    this._height = value;
                    NotifyPropertyChanged("Height");
                }
            }
        }

        /// <summary>
        /// Получает список заболеваний пользователя.
        /// </summary>
        public List<UserIllness> UserIllnesses
        {
            get { return this._userIllness; }
            set
            {
                if (value != this._userIllness)
                {
                    this._userIllness = value;
                    NotifyPropertyChanged("UserIllness");
                }
            }
        }

        /// <summary>
        /// Получает список оборудования пользователя.
        /// </summary>
        public List<UserEquipment> UserEquipment
        {
            get { return this._userEquipment; }
            set
            {
                if (value != this._userEquipment)
                {
                    this._userEquipment = value;
                    NotifyPropertyChanged("UserEquipment");
                }
            }
        }

        /// <summary>
        /// Получает список потребленной еды пользователя.
        /// </summary>
        public List<UserDish> UserDish
        {
            get { return this._userDish; }
            set
            {
                if (value != this._userDish)
                {
                    this._userDish = value;
                    NotifyPropertyChanged("UserDish");
                }
            }
        }

        /// <summary>
        /// Получает опыт пользователя.
        /// </summary>
        public int ExperienceID
        {
            get { return this._experienceID; }
            set
            {
                if (value != this._experienceID)
                {
                    this._experienceID = value;
                    NotifyPropertyChanged("ExperienceID");
                }
            }
        }
        #endregion

        /// <summary>
        /// Создает профиль пользователя.
        /// </summary>
        public UserProfile() { }

        /// <summary>
        /// Создает профиль пользователя с указанными параметрами.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="name">Имя пользователя</param>
        /// <param name="weight">Вес пользователя</param>
        /// <param name="height">Рост пользователя</param>
        /// <param name="gender">Пол пользователя</param>
        /// <param name="experience">Опыт пользователя</param>
        public UserProfile(int userId, string firstName, string secondName, float weight, float height)
        {
            this._userID = userId;
            this._firstName = firstName;
            this._secondName = secondName;
            this._weight = weight;
            this._height = height;
        }

        private UserProfile temp_Record = null;
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
                temp_Record = this.MemberwiseClone() as UserProfile;
                m_Editing = true;
            }
        }

        public void CancelEdit()
        {
            if (m_Editing == true)
            {
                _userID = temp_Record.UserID;
                _firstName = temp_Record.FirstName;
                _secondName = temp_Record.SecondName;
                _weight = temp_Record.Weight;
                _height = temp_Record.Height;
                _userIllness = temp_Record._userIllness;
                _userEquipment = temp_Record._userEquipment;
                _userDish = temp_Record._userDish;
                _experienceID = temp_Record._experienceID;

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
