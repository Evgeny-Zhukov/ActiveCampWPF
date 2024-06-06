using ActiveCamp.BL.Model;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ActiveCamp.BL.Controller
{
    public class DishManager
    {
        private ActiveCampDbContext dbContext;
        private SqlConnection _connection;

        /// <summary>
        /// Создает экземпляр DishManager и устанавливает соединение с базой данных.
        /// </summary>
        public DishManager()
        {
            dbContext = new ActiveCampDbContext();
            _connection = dbContext.GetSqlConnection();
        }

        /// <summary>
        /// Добавляет блюдо в базу данных.
        /// </summary>
        /// <param name="dish">Экземпляр блюда</param>
        /// <returns>Возвращает true, если блюдо успешно добавлено; в противном случае false</returns>
        public bool AddDish(Dish dish)
        {
            using (_connection)
            {
                SqlCommand command = new SqlCommand("AddDish", _connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                successParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(successParameter);

                command.Parameters.AddWithValue("@DishName", dish.Name);
                command.Parameters.AddWithValue("@Proteins", dish.Proteins);
                command.Parameters.AddWithValue("@Fats", dish.Fats);
                command.Parameters.AddWithValue("@Carbohydrates", dish.Carbohydrates);
                command.Parameters.AddWithValue("@Calories", dish.Calories);

                _connection.Open();
                command.ExecuteNonQuery();
                bool success = (bool)successParameter.Value;
                return success;
            }
        }

        /// <summary>
        /// Получает блюдо из базы данных по идентификатору.
        /// </summary>
        /// <param name="DishID">Идентификатор блюда</param>
        /// <returns>Возвращает экземпляр блюда</returns>
        public Dish GetDish(int DishID)
        {
            Dish dish = new Dish();

            using (_connection)
            {
                string query = "SELECT * FROM Dish WHERE DishID = @DishID";

                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@DishID", DishID);

                try
                {
                    _connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        // Чтение данных блюда из результата запроса
                        dish.SetDishID(dish);
                        dish.SetName(reader["Name"].ToString());
                        dish.SetProteins(Convert.ToDouble(reader["Proteins"]));
                        dish.SetFats(Convert.ToDouble(reader["Fats"]));
                        dish.SetCarbohydrates(Convert.ToDouble(reader["Carbohydrates"]));
                        dish.SetCalories(Convert.ToDouble(reader["Calories"]));
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return dish;
        }

        /// <summary>
        /// Обновляет информацию о блюде в базе данных.
        /// </summary>
        /// <param name="dish">Экземпляр блюда</param>
        /// <returns>Возвращает true, если информация успешно обновлена; в противном случае false</returns>
        public bool UpdateDish(Dish dish)
        {
            using (_connection)
            {
                SqlCommand command = new SqlCommand("UpdateDish", _connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                successParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(successParameter);

                command.Parameters.AddWithValue("@DishID", dish.DishID);
                command.Parameters.AddWithValue("@Name", dish.Name);
                command.Parameters.AddWithValue("@Proteins", dish.Proteins);
                command.Parameters.AddWithValue("@Fats", dish.Fats);
                command.Parameters.AddWithValue("@Carbohydrates", dish.Carbohydrates);
                command.Parameters.AddWithValue("@Calories", dish.Calories);

                _connection.Open();
                command.ExecuteNonQuery();
                bool success = (bool)successParameter.Value;
                return success;
            }
        }
        /// <summary>
        /// Удаляет блюдо из базы данных по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор блюда</param>
        /// <returns>Возвращает true, если блюдо успешно удалено; в противном случае false</returns>
        public bool DeleteDish(int id)
        {
            using (_connection)
            {
                SqlCommand command = new SqlCommand("DeleteDishById", _connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@DishID", id);

                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                successParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(successParameter);

                _connection.Open();
                command.ExecuteNonQuery();
                bool success = (bool)successParameter.Value;
                return success;
            }
        }
        public int GetDishID(Dish dish)
        {
            int dishID = -1;
            using (_connection)
            {
                string query = "SELECT * FROM Dish WHERE Name = @Name";

                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@Name", dish.Name);
                try
                {
                    _connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        dishID = Convert.ToInt32(reader["DishID"]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            
            }
            if (dishID <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(dishID), "ID блюда должен быть положительным числом.");
            }
            return dishID;
        }

    }

}
