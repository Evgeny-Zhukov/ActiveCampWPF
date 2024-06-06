using ActiveCamp.BL.Controller;
using System;

namespace ActiveCamp.BL.Model
{
    /// <summary>
    /// Недуг.
    /// </summary>
    public class Illness
    {
        #region Свойства
        /// <summary>
        /// ИД недуга.
        /// </summary>
        public int IllnessID { get; private set; }

        /// <summary>
        /// Название недуга.
        /// </summary>
        public string IllnessName { get; private set; }

        /// <summary>
        /// Описание недуга.
        /// </summary>
        public string IllnessDescription { get; private set; }
        #endregion

        public Illness() { }

        /// <summary>
        /// Создает недуг.
        /// </summary>
        /// <param name="name">Название недуга</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Illness(string name)
        {
            IllnessName = name ?? throw new ArgumentNullException("Название недуга не может быть пустым или NULL", nameof(name));
        }
        public Illness(string name, string description)
        {
            IllnessName = name ?? throw new ArgumentNullException("Название недуга не может быть пустым или NULL", nameof(name));
            IllnessDescription = description ?? throw new ArgumentNullException("Описание недуга не может быть пустым или NULL", nameof(description));
        }
        /// <summary>
        /// Устанавливает название недуга.
        /// </summary>
        /// <param name="name">Название недуга</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void SetIllnessName(string name)
        {
            IllnessName = name ?? throw new ArgumentNullException(nameof(name), "Название недуга не может быть пустым или NULL");
        }

        /// <summary>
        /// Устанавливает описание недуга.
        /// </summary>
        /// <param name="description">Описание недуга</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void SetIllnessDescription(string description)
        {
            IllnessDescription = description ?? throw new ArgumentNullException(nameof(description), "Описание недуга не может быть пустым или NULL");
        }

        /// <summary>
        /// Внутренний метод для установки ИД недуга, доступен только внутри сборки.
        /// </summary>
        /// <param name="illnessID">ИД недуга</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        internal void SetIllnessID(Illness illness)
        {
            IllnessManager illnessManager = new IllnessManager();
            int illnessID = illnessManager.GetIllnessID(illness);
            IllnessID = illnessID;
        }
    }

}
