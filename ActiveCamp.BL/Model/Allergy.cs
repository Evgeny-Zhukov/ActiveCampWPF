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
    internal class Allergy
    {
        #region Свойства
        /// <summary>
        /// ИД аллергии.
        /// </summary>
        public int AllergyId { get;}
        /// <summary>
        /// Название аллергии.
        /// </summary>
        public string Name { get;}
        /// <summary>
        /// Список аллергий.
        /// </summary>
        public List<Allergy> allergies { get;}
        #endregion
        public Allergy() { }
        /// <summary>
        /// Создает алеергию
        /// </summary>
        /// <param name="name">Название аллергии</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Allergy(string name)
        {
            Name = name ?? throw new ArgumentNullException("Название аллергии не может быть пустым или NULL", nameof(name));
        }
    }
}
