using System;

namespace ActiveCamp.BL
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    public class User
    {
        #region Свойства
        /// <summary>
        /// Id пользователя.
        /// </summary>
        public int UserID { get; private set; }
        /// <summary>
        /// Псевдоним пользователя.
        /// </summary>
        public string Username { get; private set; }
        /// <summary>
        /// Пароль пользователя.
        /// </summary>
        public string Password { get; private set; }
        /// <summary>
        /// Имя пользователя.
        /// </summary>
        #endregion

        /// <summary>
        /// Создает пользователя.
        /// </summary>
        /// <param name="username"> Псевдоним</param>
        /// <param name="password">Пароль</param>
        /// <exception cref="ArgumentNullException"></exception>
        public User(string username,string password)
        {
            Username = username ?? throw new ArgumentNullException("Псевдоним пользователя не может быть пустым или null.", nameof(username));
            Password = password ?? throw new ArgumentNullException("Password", nameof(password));
        }
        public User(int userID, string username)
        {
            Username = username ?? throw new ArgumentNullException("Псевдоним пользователя не может быть пустым или null.", nameof(username));
            if (userID >0)
            {
                UserID = userID;
            }
            else
                throw new ArgumentException("userID", nameof(userID));

        }
        /// <summary>
        /// Создает пользователя.
        /// </summary>
        public User() { }
        public override string ToString()
        {
            return Username;
        }
    }
}
