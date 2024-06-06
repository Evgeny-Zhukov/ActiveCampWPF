using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActiveCamp.BL.Model;
using System.Data.Common;

namespace ActiveCamp.BL.Controller
{
    public class FoodConsumptionManager
    {
        private ActiveCampDbContext dbContext;
        private SqlConnection _connection;

        /// <summary>
        /// Создает экземпляр FoodConsumptionManager и устанавливает соединение с базой данных.
        /// </summary>
        public FoodConsumptionManager()
        {
            dbContext = new ActiveCampDbContext();
            _connection = dbContext.GetSqlConnection();
        }

        /// <summary>
        /// Добавляет потребление пищи в базу данных.
        /// </summary>
        /// <param name="foodConsumption">Экземпляр потребления пищи</param>
        /// <returns>Возвращает true, если потребление пищи успешно добавлено; в противном случае false</returns>
        public bool AddFoodConsumption(FoodConsumption foodConsumption)
        {
            using (_connection)
            {
                SqlCommand command = new SqlCommand("AddFoodConsumption", _connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                successParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(successParameter);

                command.Parameters.AddWithValue("@RouteID", foodConsumption.RouteID);
                command.Parameters.AddWithValue("@StringNumber", foodConsumption.StringNumber);
                command.Parameters.AddWithValue("@Dish", foodConsumption.Dish);
                command.Parameters.AddWithValue("@ConsumptionTime", foodConsumption.ConsumptionTime);
                command.Parameters.AddWithValue("@DayOfRoute", foodConsumption.DayOfRoute);
                command.Parameters.AddWithValue("@AmountPerPerson", foodConsumption.AmountPerPerson);
                command.Parameters.AddWithValue("@AmountPerGroup", foodConsumption.AmountPerGroup);

                _connection.Open();
                command.ExecuteNonQuery();
                bool success = (bool)successParameter.Value;
                return success;
            }
        }

        /// <summary>
        /// Получает потребление пищи из базы данных по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор потребления пищи</param>
        /// <returns>Возвращает экземпляр потребления пищи</returns>
        public FoodConsumption GetFoodConsumptionByID(int id)
        {
            FoodConsumption foodConsumption = new FoodConsumption();

            using (_connection)
            {
                string query = "SELECT * FROM FoodConsumption WHERE ID = @Id";

                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    _connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        foodConsumption.SetFCId(Convert.ToInt32(reader["ID"]));
                        foodConsumption.SetRoute(Convert.ToInt32(reader["RouteID"]));
                        foodConsumption.SetStringNumber(Convert.ToInt32(reader["StringNumber"]));
                        foodConsumption.SetDish(reader["Dish"].ToString());
                        foodConsumption.SetConsumptionTime(reader["ConsumptionTime"].ToString());
                        foodConsumption.SetDayOfRoute(Convert.ToInt32(reader["DayOfRoute"]));
                        foodConsumption.SetStringNumber(Convert.ToInt32(reader["AmountPerPerson"]));
                        foodConsumption.SetStringNumber(Convert.ToInt32(reader["AmountPerGroup"]));
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return foodConsumption;
        }

        /// <summary>
        /// Удаляет потребление пищи из базы данных по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор потребления пищи</param>
        /// <returns>Возвращает true, если потребление пищи успешно удалено; в противном случае false</returns>
        public bool DeleteFoodConsumption(int id)
        {
            using (_connection)
            {
                SqlCommand command = new SqlCommand("DeleteFoodConsumptionById", _connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ID", id);

                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                successParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(successParameter);

                _connection.Open();
                command.ExecuteNonQuery();
                bool success = (bool)successParameter.Value;
                return success;
            }
        }
        /*public int GetFoodConsumptionID(FoodConsumption foodConsumption)
        {
            int fcID = -1;
            using (_connection)
            {
                string query = "SELECT * FROM FoodConsumption WHERE equipmentName = @equipmentName"; // TODO: Этот класс неактуален и не будет использоваться

                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@Name", foodConsumption.);
                try
                {
                    _connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        fcID = Convert.ToInt32(reader["equipmentID"]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }

            }
            if (fcID <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(fcID), "ID снаряжения должен быть положительным числом.");
            }
            return fcID;
        }*/
    }

}
