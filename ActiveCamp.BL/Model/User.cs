using System;

namespace ActiveCamp.BL
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    [Serializable]
    public class User
    {
        #region Свойства
        /// <summary>
        /// Id пользователя.
        /// </summary>
        public int UserID { get; }
        /// <summary>
        /// Псевдоним пользователя.
        /// </summary>
        public string Username { get; }
        /// <summary>
        /// Электронная почта пользователя.
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Пароль пользователя.
        /// </summary>
        private string Password { get; set; }
        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string Name { get; }
        public Gender Gender { get; set; }
        #endregion

        /// <summary>
        /// Создает пользователя.
        /// </summary>
        /// <param name="username"> Псевдоним</param>
        /// <param name="email">Электронная почта</param>
        /// <param name="password">Пароль</param>
        /// <param name="name">Имя</param>
        /// <exception cref="ArgumentNullException"></exception>
        public User(string username, string email, string password, string name)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentNullException("Псевдоним пользователя не может быть пустым или null.", nameof(username));
            }
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException("Почта не может быть пустым или null.", nameof(email));
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException("Пароль не может быть пустым или null.", nameof(password));
            }
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя не может быть пустым или null.", nameof(name));
            }
            Username = username;
            Email = email;
            Password = password;
            Name = name;
        }
        /// <summary>
        /// Создает пользователя.
        /// </summary>
        public User() { }
        /// <summary>
        /// Создает пользователя.
        /// </summary>
        /// <param name="name">Имя</param>
        /// <exception cref="ArgumentNullException"></exception>
        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя не может быть пустым или null.", nameof(name));
            }
            Name = name;
        }
        public override string ToString()
        {
            return Username + " " + Email + " " + Name;
        }
    }
}
 
