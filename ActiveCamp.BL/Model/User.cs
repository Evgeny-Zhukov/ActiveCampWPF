using ActiveCamp.BL.Controller;
using System;

namespace ActiveCamp.BL
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    public class User
    {

        static private int _userID;

        static public int UserID 
        { 
            get
            {
                return _userID;
            }
            set
            {
                if (value != _userID)
                {
                    _userID = value;
                }
            }
        }

        public string Username { get; private set; }

        public string Password { get; private set; }

        /// <summary>
        /// Создает пользователя.
        /// </summary>
        /// <param name="username">Псевдоним</param>
        /// <param name="password">Пароль</param>
        /// <exception cref="ArgumentNullException"></exception>
        public User(string username, string password)
        {
            Username = username ?? throw new ArgumentNullException(nameof(username), "Псевдоним пользователя не может быть пустым или null.");
            Password = password ?? throw new ArgumentNullException(nameof(password), "Пароль не может быть пустым или null.");
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

        /// <summary>
        /// Устанавливает ID пользователя.
        /// </summary>
        /// <param name="userID">ID пользователя</param>
        public void SetUserID(User user)
        {
            UserManager userManager = new UserManager();
            int userID = userManager.GetUserID(user);
            UserID = userID;
        }

        /// <summary>
        /// Устанавливает псевдоним пользователя.
        /// </summary>
        /// <param name="username">Псевдоним</param>
        public void SetUsername(string username)
        {
            Username = username ?? throw new ArgumentNullException(nameof(username), "Псевдоним пользователя не может быть пустым или null.");
        }

        /// <summary>
        /// Устанавливает пароль пользователя.
        /// </summary>
        /// <param name="password">Пароль</param>
        public void SetPassword(string password)
        {
            Password = password ?? throw new ArgumentNullException(nameof(password), "Пароль не может быть пустым или null.");
        }

        public override string ToString()
        {
            return Username;
        }
    }
}
