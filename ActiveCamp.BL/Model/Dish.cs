using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveCamp.BL.Model
{
    /// <summary>
    /// Блюдо
    /// </summary>
    public class Dish
    {
        #region Свойства
        /// <summary>
        /// ИД блюда.
        /// </summary>
        public int DishID { get; set; }
        /// <summary>
        /// Название блюда.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Белки.
        /// </summary>
        public double Proteins { get; set; }
        /// <summary>
        /// Жиры.
        /// </summary>
        public double Fats { get; set; }
        /// <summary>
        /// Углеводы.
        /// </summary>
        public double Carbohydrates { get; set; }
        /// <summary>
        /// Калории.
        /// </summary>
        public double Calories { get; set; }

        public virtual ICollection<Dish> DishList { get; set; }

        #endregion
        public Dish() { }
        public Dish(string name) : this(name, 0, 0, 0, 0) { }
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
        public Dish(string name, double proteins, double fats, double carbohydrates, double calories)
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
        }
    }
}