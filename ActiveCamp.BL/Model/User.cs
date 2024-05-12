﻿using System;

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
        public int UserID { get; }
        /// <summary>
        /// Псевдоним пользователя.
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Электронная почта пользователя.
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Пароль пользователя.
        /// </summary>
        public string Password { get; set; }
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
        /// <param name="password">Пароль</param>
        /// <exception cref="ArgumentNullException"></exception>
        public User(string username,string password)
        {
            Username = username ?? throw new ArgumentNullException("Псевдоним пользователя не может быть пустым или null.", nameof(username));
            Password = password ?? throw new ArgumentNullException("Password", nameof(password));
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
            Name = name ?? throw new ArgumentNullException("Имя не может быть пустым или null.", nameof(name));
        }
        public override string ToString()
        {
            return Username;
        }
    }
}
