using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveCamp.BL.Model
{
    /// <summary>
    /// Аллергия.
    /// </summary>
    public class UserAllergy
    {
        #region Свойства
        /// <summary>
        /// ИД аллергии.
        /// </summary>
        public int AllergyId { get; set; }
        /// <summary>
        /// Название аллергии.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// ИД пользователя к которому относится аллергия
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// Список аллергий.
        /// </summary>
        public List<UserAllergy> allergies { get; set; }
        #endregion
        public UserAllergy() { }
        /// <summary>
        /// Создает алеергию
        /// </summary>
        /// <param name="name">Название аллергии</param>
        /// <exception cref="ArgumentNullException"></exception>
        public UserAllergy(string name)
        {
            Name = name ?? throw new ArgumentNullException("Название аллергии не может быть пустым или NULL", nameof(name));
        }
    }
}
