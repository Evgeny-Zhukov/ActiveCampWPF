using ActiveCamp.BL.Controller;
using ActiveCamp.BL.Model;
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
        public int equipmentID { get; private set; }
        /// <summary>
        /// Название снаряжения.
        /// </summary>
        public string equipmentName { get; private set; }
        /// <summary>
        /// Вес снаряжения.
        /// </summary>
        public double equipmentWeight { get; private set; }
        #endregion

        public Equipment() { }
        /// <summary>
        /// Создает снаряжение.
        /// </summary>
        /// <param name="equipmentName">Название снаряжения</param>
        /// <param name="equipmentWeight">Вес снаряжения</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public Equipment(string equipmentName, double equipmentWeight)
        {
            this.equipmentName = equipmentName ?? throw new ArgumentNullException("Название снаряжение не может быть пустым или NULL", nameof(equipmentName));

            if (equipmentWeight <= 0)
            {
                throw new ArgumentOutOfRangeException("Вес снаряжения должен быть положительным числом и не равен нулю.", nameof(equipmentWeight));
            }
            this.equipmentWeight = equipmentWeight;
        }
        /// <summary>
        /// Создает снаряжение.
        /// </summary>
        /// <param name="equipmentName">Название снаряжения</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Equipment(string equipmentName)
        {
            this.equipmentName = equipmentName ?? throw new ArgumentNullException("Название снаряжение не может быть пустым или NULL", nameof(equipmentName));
        }
        public void SetEquipmentName(string equipmentName)
        {
            this.equipmentName = equipmentName ?? throw new ArgumentNullException(nameof(equipmentName), "Название снаряжения не может быть пустым или NULL");
        }

        public void SetEquipmentWeight(double equipmentWeight)
        {
            if (equipmentWeight <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(equipmentWeight), "Вес снаряжения должен быть положительным числом и не равен нулю.");
            }
            this.equipmentWeight = equipmentWeight;
        }

        public void SetEquipmentID(Equipment equipment)
        {
            EquipmentManager equipmentManager = new EquipmentManager();
            int equipmentID = equipmentManager.GetEquipmentID(equipment);
            this.equipmentID = equipmentID;
        }
        public override string ToString()
        {
            return equipmentID + " " + equipmentName + " " + equipmentWeight;
        }
    }


}