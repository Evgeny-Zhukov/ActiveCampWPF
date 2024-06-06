using System;

namespace ActiveCamp.BL
{
    /// <summary>
    /// Пол.
    /// </summary>
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
        /// <summary>
        /// Внутренний метод для установки ИД пола, доступен только внутри сборки.
        /// </summary>
        /// <param name="genderId">ИД пола</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        internal void SetGenderId(int genderId)
        {
            if (genderId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(genderId), "ID пола должен быть положительным числом.");
            }
            GenderId = genderId;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}