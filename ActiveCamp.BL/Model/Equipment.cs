using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ActiveCamp
{
    /// <summary>
    /// Снаряжение
    /// </summary>
    public class Equipment : INotifyPropertyChanged, IEditableObject
    {
        private int _equipmentID;
        private string _equipmentName;
        private double _equipmentWeight;

        public event PropertyChangedEventHandler PropertyChanged;

        #region Свойства
        /// <summary>
        /// ИД снаряжения.
        /// </summary>
        public int equipmentID
        {
            get { return this._equipmentID; }
            set
            {
                if (value != this._equipmentID)
                {
                    this._equipmentID = value;
                    NotifyPropertyChanged("equipmentID");

                }
            }
        }
        /// <summary>
        /// Название снаряжения.
        /// </summary>
        public string equipmentName
        {
            get { return this._equipmentName; }
            set
            {
                if (value != this._equipmentName)
                {
                    this._equipmentName = value;
                    NotifyPropertyChanged("equipmentName");

                }
            }
        }
        /// <summary>
        /// Вес снаряжения.
        /// </summary>
        public double equipmentWeight
        {
            get { return this._equipmentWeight; }
            set
            {
                if (value != this._equipmentWeight)
                {
                    this._equipmentWeight = value;
                    NotifyPropertyChanged("equipmentWeight");

                }
            }
        }
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
            this._equipmentName= equipmentName;
            this._equipmentWeight= equipmentWeight;
        }
        /// <summary>
        /// Создает снаряжение.
        /// </summary>
        /// <param name="equipmentName">Название снаряжения</param>
        /// <exception cref="ArgumentNullException"></exception>
        private Equipment temp_Record = null;
        private bool m_Editing = false;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void BeginEdit()
        {
            if(m_Editing == false)
            {
                temp_Record = this.MemberwiseClone() as Equipment;
                m_Editing = true;
            }
        }

        public void EndEdit()
        {
            if(m_Editing == true)
            {
                _equipmentName = temp_Record.equipmentName;
                _equipmentWeight = temp_Record.equipmentWeight;

                m_Editing = false;
            }
            
        }

        public void CancelEdit()
        {
            if (m_Editing == true)
            {
                temp_Record = null;
                m_Editing = false;
            }
        }
    }


}