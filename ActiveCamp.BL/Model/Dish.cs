using ActiveCamp.BL.Controller;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

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
        public int DishID {  get; private set; }

        /// <summary>
        /// Название блюда.
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Белки.
        /// </summary>
        public int Proteins { get; private set; }
        /// <summary>
        /// Жиры.
        /// </summary>
        public int Fats { get; private set; }
        /// <summary>
        /// Углеводы.
        /// </summary>
        public int Carbohydrates { get; private set; }
        /// <summary>
        /// Калории.
        /// </summary>
        public int Calories { get; private set; }

        public virtual ICollection<Dish> DishList { get; set; }

        #endregion
        private ActiveCampDbContext dbContext;
        private SqlConnection _connection;
        public Dish() 
        {
            dbContext = new ActiveCampDbContext();
            _connection = dbContext.GetSqlConnection();
        }
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

        public void SetName(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name), "Название блюда не может быть пустым или NULL");
        }

        public void SetProteins(int proteins)
        {
            if (proteins < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(proteins), "Количество белков должно быть неотрицательным числом.");
            }
            Proteins = proteins;
        }

        public void SetFats(int fats)
        {
            if (fats < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(fats), "Количество жиров должно быть неотрицательным числом.");
            }
            Fats = fats;
        }

        public void SetCarbohydrates(int carbohydrates)
        {
            if (carbohydrates < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(carbohydrates), "Количество углеводов должно быть неотрицательным числом.");
            }
            Carbohydrates = carbohydrates;
        }

        public void SetCalories(int calories)
        {
            if (calories < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(calories), "Количество калорий должно быть неотрицательным числом.");
            }
            Calories = calories;
        }
        public void SetDishID(Dish dish)
        {
            DishManager dishManager = new DishManager();
            int dishID = dishManager.GetDishID(dish);
            DishID = dishID;
        }
        public override string ToString()
        {
            return $"DishID: {DishID}, Name: {Name}, Proteins: {Proteins}g, Fats: {Fats}g, Carbohydrates: {Carbohydrates}g, Calories: {Calories}kcal";
        }
    }
}