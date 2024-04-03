using System;

namespace ActiveCamp.BL
{
    /// <summary>
    /// Пол.
    /// </summary>
    [Serializable]
    public class Gender
    {
        public int GenderId { get; set; }
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }

        public Gender() { }
        /// <summary>
        /// Создать новый пол.
        /// </summary>
        /// <param name="name"> Название пола</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пола не может быть пустым или null", nameof(name));
            }
            Name = name;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}