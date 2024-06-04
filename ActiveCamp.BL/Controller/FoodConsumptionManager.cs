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
        public FoodConsumptionManager()
        {
            dbContext = new ActiveCampDbContext();
            _connection = dbContext.GetSqlConnection();
        }
        public bool AddFoodConsumption(FoodConsumption foodConsuption)
        {
            using (_connection)
            {
                SqlCommand command = new SqlCommand("AddFoodConsumption", _connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                successParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(successParameter);
                command.Parameters.AddWithValue("@RouteID", foodConsuption.Route.RouteId);
                command.Parameters.AddWithValue("@StringNumber", foodConsuption.StringNumber);
                command.Parameters.AddWithValue("@Dish", foodConsuption.Dish);
                command.Parameters.AddWithValue("@ConsumptionTime", foodConsuption.ConsumptionTime);
                command.Parameters.AddWithValue("@DayOfRoute", foodConsuption.DayOfRoute);
                command.Parameters.AddWithValue("@AmountPerPerson", foodConsuption.AmountPerPerson);
                command.Parameters.AddWithValue("@AmountPerGroup", foodConsuption.AmountPerGroup);
                _connection.Open();
                command.ExecuteNonQuery();
                bool success = (bool)successParameter.Value;
                return success;
            }
        }
        public FoodConsumption GetFoodConsumptionByID(int id)
        {
            FoodConsumption foodConsuption = new FoodConsumption();

            using (_connection)
            {
                string query = "SELECT * FROM HikingRoutes WHERE RouteId = @Id";

                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    _connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        foodConsuption.FCId = Convert.ToInt32(reader["ID"]);
                        foodConsuption.Route.RouteId = Convert.ToInt32(reader["RouteID"]);
                        foodConsuption.StringNumber = Convert.ToInt32(reader["StringNumber"]);
                        foodConsuption.Dish = reader["Dish"].ToString();
                        foodConsuption.ConsumptionTime = reader["ConsumptionTime"].ToString();
                        foodConsuption.DayOfRoute = Convert.ToInt32(reader["DayOfRoute"]);
                        foodConsuption.AmountPerPerson = Convert.ToInt32(reader["AmountPerPerson"]);
                        foodConsuption.AmountPerGroup = Convert.ToInt32(reader["AmountPerGroup"]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return foodConsuption;
        }
        public bool DeleteFoodConsumption(int id)
        {
            using (_connection)
            {
                SqlCommand command = new SqlCommand("DeleateFoodConsumptionById", _connection);
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
    }
}
