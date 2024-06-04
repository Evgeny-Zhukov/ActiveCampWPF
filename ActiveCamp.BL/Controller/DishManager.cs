using ActiveCamp.BL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace ActiveCamp.BL.Controller
{
    public class DishManager
    {
        private ActiveCampDbContext dbContext;
        private SqlConnection _connection;
        public DishManager()
        {
            dbContext = new ActiveCampDbContext();
            _connection = dbContext.GetSqlConnection();
        }
        public bool AddDish(Dish dish)
        {
            using (_connection)
            {
                SqlCommand command = new SqlCommand("AddDish", _connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                successParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(successParameter);
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
                        // Чтение данных маршрута из результата запроса
                        dish.DishID = Convert.ToInt32(reader["DishID"]);
                        dish.Name = reader["Name"].ToString();
                        dish.Proteins = Convert.ToDouble(reader["Proteins"]);
                        dish.Fats = Convert.ToDouble(reader["Fats"]);
                        dish.Carbohydrates = Convert.ToDouble(reader["Carbohydrates"]);
                        dish.Calories = Convert.ToDouble(reader["Calories"]);
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
        public bool UpdateDish(Dish dish) // TODO: Уточнить как будет работать
        {
            using (_connection)
            {
                SqlCommand command = new SqlCommand("UpdateDish", _connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                command.Parameters.AddWithValue("@equipmentName", dish.Name);
                command.Parameters.AddWithValue("@equipmentWeight", dish.Proteins);
                command.Parameters.AddWithValue("@equipmentWeight", dish.Fats);
                command.Parameters.AddWithValue("@equipmentWeight", dish.Carbohydrates);
                command.Parameters.AddWithValue("@equipmentWeight", dish.Calories);
                _connection.Open();
                command.ExecuteNonQuery();
                bool success = (bool)successParameter.Value;
                return success;
            }
        }
        public bool DeleteDish(int id)
        {
            using (_connection)
            {
                SqlCommand command = new SqlCommand("DeleateDishById", _connection);
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
