using ActiveCamp.BL.Controller;
using ActiveCamp.BL.Model;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace ActiveCamp.BL
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    public class User : INotifyPropertyChanged, IEditableObject
    {
        #region Свойства
        
        static private int _userID;
        private string _userName;
        private string _password;
        
        /// <summary>
        /// Id пользователя.
        /// </summary>
        static public int UserID
        {
            get { return _userID; }
            set
            {
                if (value != _userID)
                {
                    _userID = value;
                    //NotifyPropertyChanged(nameof(ActiveCamp.BL.User.UserID));
                }
            }
        }

        /// <summary>
        /// Псевдоним пользователя.
        /// </summary>
        public string Username
        {
            get { return this._userName; }
            set
            {
                if (value != this._userName)
                {
                    this._userName = value;
                    NotifyPropertyChanged("Username");
                }
            }
        }

        /// <summary>
        /// Пароль пользователя.
        /// </summary>
        public string Password
        {
            get { return this._password; }
            set
            {
                if (value != this._password)
                {
                    this._password = value;
                    NotifyPropertyChanged("Password");
                }
            }
        }
        #endregion

        /// <summary>
        /// Создает пользователя.
        /// </summary>
        /// <param name="username">Псевдоним</param>
        /// <param name="password">Пароль</param>
        /// <exception cref="ArgumentNullException"></exception>
        public User(string username, string password)
        {
            this._userName = username ?? throw new ArgumentNullException(nameof(username), "Псевдоним пользователя не может быть пустым или null.");
            this._password = password ?? throw new ArgumentNullException(nameof(password), "Пароль не может быть пустым или null.");
        }

        /// <summary>
        /// Создает пользователя с ID и псевдонимом.
        /// </summary>
        /// <param name="userID">ID пользователя</param>
        /// <param name="username">Псевдоним</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public User(int userID, string username)
        {
            Username = username ?? throw new ArgumentNullException(nameof(username), "Псевдоним пользователя не может быть пустым или null.");
            UserID = userID > 0 ? userID : throw new ArgumentException(nameof(userID), "ID пользователя должен быть положительным.");
        }

        /// <summary>
        /// Создает пользователя.
        /// </summary>
        public User() { }

        public event PropertyChangedEventHandler PropertyChanged;

        private User temp_Record = null;
        private bool m_Editing = false;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void BeginEdit()
        {
            if (m_Editing == false)
            {
                temp_Record = this.MemberwiseClone() as User;
                m_Editing = true;
            }
        }

        public void CancelEdit()
        {
            if (m_Editing == true)
            {
                _userID = ActiveCamp.BL.User.UserID;
                _userName = temp_Record.Username;
                _password = temp_Record.Password;

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
