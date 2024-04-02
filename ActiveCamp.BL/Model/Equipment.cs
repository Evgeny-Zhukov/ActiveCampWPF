
using System;

namespace ActiveCamp
{
    /// <summary>
    /// Снаряжение
    /// </summary>
    public class Equipment
    {
        #region Свойства
        /// <summary>
        /// ИД снаряжения.
        /// </summary>
        public int equipmentID { get;}
        /// <summary>
        /// Название снаряжения.
        /// </summary>
        public string equipmentName { get; set; }
        /// <summary>
        /// Вес снаряжения.
        /// </summary>
        public string equipmentWeight { get; set; }
        #endregion

        public Equipment(){}
        public Equipment(string equipmentName, string equipmentWeight)
        {
            this.equipmentName = equipmentName ?? throw new ArgumentNullException("Название снаряжение не может быть пустым или NULL", nameof(equipmentName));
            this.equipmentWeight = equipmentWeight ?? throw new ArgumentNullException("Вес снаряжение не может быть пустым или NULL", nameof(equipmentWeight));
        }

        public override string ToString()
        {
            return equipmentID + " " + equipmentName + " " + equipmentWeight;
        }
    }


}
