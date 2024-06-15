using ActiveCamp.BL.Model;
using System;
using System.Collections.Generic;
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
        public List<Dish> GetDish(int DishID)
        {
            List<Dish> dishes = new List<Dish>(); 

            using (_connection)
            {
                string query = "SELECT * FROM Dish WHERE DishID = @DishID";

                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@DishID", DishID);

                try
                {
                    _connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read()) 
                        {
                            Dish dish = new Dish();
                            {
                                dish.DishID = Convert.ToInt32(reader["DishID"]);
                                dish.Name = (reader["Name"].ToString());
                                dish.Proteins = (Convert.ToInt32(reader["Proteins"]));
                                dish.Fats = (Convert.ToInt32(reader["Fats"]));
                                dish.Carbohydrates = (Convert.ToInt32(reader["Carbohydrates"]));
                                dish.Calories = (Convert.ToInt32(reader["Calories"]));
                            }
                            dishes.Add(dish);
                        }               
                    }
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return dishes;
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
    }

}
