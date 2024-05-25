using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int IllnessID { get; set; }
        /// <summary>
        /// Название недуга.
        /// </summary>
        public string IllnessName { get; set; }
        /// <summary>
        /// ИД пользователя к которому относится недуг
        /// </summary>
        public string IllnessDescription { get; set; }
        #endregion
        public Illness() { }
        /// <summary>
        /// Создает алеергию
        /// </summary>
        /// <param name="name">Название аллергии</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Illness(string name)
        {
            IllnessName = name ?? throw new ArgumentNullException("Название недуга не может быть пустым или NULL", nameof(name));
        }
    }
}
