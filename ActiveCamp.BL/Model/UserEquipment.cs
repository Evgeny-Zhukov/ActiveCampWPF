using ActiveCamp.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveCamp.BL.Model
{
    public class UserEquipment
    {
        #region Свойства
        /// <summary>
        /// Получает идентификатор снаряжения пользователя.
        /// </summary>
        public int UserEquipmentId { get; private set; }

        /// <summary>
        /// Получает идентификатор пользователя.
        /// </summary>
        public int UserID { get; private set; }

        /// <summary>
        /// Получает идентификатор снаряжения.
        /// </summary>
        public int EquipmentID { get; private set; }
        #endregion

        /// <summary>
        /// Создает снаряжение пользователя.
        /// </summary>
        public UserEquipment() { }

        /// <summary>
        /// Создает снаряжения пользователя с указанными идентификаторами.
        /// </summary>
        /// <param name="userIllnessId">Идентификатор снаряжения пользователя</param>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="illnessId">Идентификатор снаряжения</param>
        public UserEquipment(int userEquipmentId, int userId, int equipmentID)
        {
            UserEquipmentId = userEquipmentId;
            UserID = userId;
            EquipmentID = equipmentID;
        }
        /// <summary>
        /// Создает снаряжения пользователя с указанными идентификаторами.
        /// </summary>
        /// <param name="userIllnessId">Идентификатор снаряжения пользователя</param>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="illnessId">Идентификатор снаряжения</param>
        public UserEquipment(int userId, int equipmentID)
        {
            UserID = userId;
            EquipmentID = equipmentID;
        }
        /// <summary>
        /// Устанавливает идентификатор снаряжения пользователя.
        /// </summary>
        /// <param name="equipmentID">Идентификатор снаряжения</param>
        public void SetIllnessId(UserEquipment userEquipment)
        {
            UserEquipmentManager userEquipmentManager = new UserEquipmentManager();
            int userEquipmentID = userEquipmentManager.GetUserEquipmentID(userEquipment);
            UserEquipmentId = userEquipmentID;
        }
    }
}
