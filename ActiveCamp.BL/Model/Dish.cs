using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ActiveCamp.BL.Model
{
    /// <summary>
    /// Блюдо
    /// </summary>
    public class Dish : INotifyPropertyChanged, IEditableObject
    {
        private int _DishID;
        private string _Name;
        private int _Proteins;
        private int _Fats;
        private int _Carbohydrates;
        private int _Calories;

        #region Свойства
        /// <summary>
        /// ИД блюда.
        /// </summary>
        public int DishID
        {
            get { return this._DishID; }
            set
            {
                if (value != this._DishID)
                {
                    this._DishID = value;
                    NotifyPropertyChanged("DishID");

                }
            }
        }

        /// <summary>
        /// Название блюда.
        /// </summary>
        public string Name
        {
            get { return this._Name; }
            set
            {
                if (value != this._Name)
                {
                    this._Name = value;
                    NotifyPropertyChanged("Name");

                }
            }
        }
        /// <summary>
        /// Белки.
        /// </summary>
        public int Proteins
        {
            get { return this._Proteins; }
            set
            {
                if (value != this._Proteins)
                {
                    this._Proteins = value;
                    NotifyPropertyChanged("Proteins");

                }
            }
        }
        /// <summary>
        /// Жиры.
        /// </summary>
        public int Fats
        {
            get { return this._Fats; }
            set
            {
                if (value != this._Fats)
                {
                    this._Fats = value;
                    NotifyPropertyChanged("Fats");

                }
            }
        }
        /// <summary>
        /// Углеводы.
        /// </summary>
        public int Carbohydrates
        {
            get { return this._Carbohydrates; }
            set
            {
                if (value != this._Carbohydrates)
                {
                    this._Carbohydrates = value;
                    NotifyPropertyChanged("Carbohydrates");

                }
            }
        }
        /// <summary>
        /// Калории.
        /// </summary>
        public int Calories
        {
            get { return this._Calories; }
            set
            {
                if (value != this._Calories)
                {
                    this._Calories = value;
                    NotifyPropertyChanged("Calories");

                }
            }
        }

        public virtual ICollection<Dish> DishList { get; set; }

        #endregion

        private Dish temp_Record = null;
        private bool m_Editing = false;

        public event PropertyChangedEventHandler PropertyChanged;

        public Dish() { }

        public Dish(string name)
        { 
            Name = name;
        }
        /// <summary>
        /// Создает блюдо
        /// </summary>
        /// <param name="name">Название блюда</param>
        /// <param name="proteins">Белки</param>
        /// <param name="fats">Жиры</param>
        /// <param name="carbohydrates">Углеводы</param>
        /// <param name="calories">Калории</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public Dish(string name, int proteins, int fats, int carbohydrates, int calories)
        {
            Name = name ?? throw new ArgumentNullException("Название блюда не может быть пустым или NULL", nameof(name));
            if (proteins <= 0)
            {
                throw new ArgumentOutOfRangeException("Количество белков должно быть положительным числом и не равен нулю.", nameof(proteins));
            }
            if (fats <= 0)
            {
                throw new ArgumentOutOfRangeException("Количество жиров должно быть положительным числом и не равен нулю.", nameof(fats));
            }
            if (carbohydrates <= 0)
            {
                throw new ArgumentOutOfRangeException("Количество углеводов должно быть положительным числом и не равен нулю.", nameof(carbohydrates));
            }
            if (calories <= 0)
            {
                throw new ArgumentOutOfRangeException("Количество калорий должно быть положительным числом и не равен нулю.", nameof(calories));
            }
            Proteins = proteins;
            Fats = fats;
            Carbohydrates = carbohydrates;
            Calories = calories;
        }
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public override string ToString()
        {
            return $"DishID: {DishID}, Name: {Name}, Proteins: {Proteins}g, Fats: {Fats}g, Carbohydrates: {Carbohydrates}g, Calories: {Calories}kcal";
        }

        public void BeginEdit()
        {
            if (m_Editing == false)
            {
                temp_Record = this.MemberwiseClone() as Dish;
                m_Editing = true;
            }
        }

        public void CancelEdit()
        {
            if (m_Editing == true)
            {
                _DishID = temp_Record.DishID;
                _Name = temp_Record.Name;
                _Proteins = temp_Record.Proteins;
                _Fats = temp_Record.Fats;
                _Carbohydrates = temp_Record.Carbohydrates;
                _Calories = temp_Record.Calories;

                m_Editing = false;
            }
        }
        public void EndEdit()
        {
            if (m_Editing == true)
            {
                temp_Record = null;
                m_Editing = false;
            }
        }
    }
}