using ActiveCamp.BL.Model;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ActiveCamp.BL.Controller
{
    public class RouteManager
    {
        private ActiveCampDbContext dbContext;
        private SqlConnection _connection;
        public RouteManager()
        {
            dbContext = new ActiveCampDbContext();
            _connection = dbContext.GetSqlConnection();
        }
        public bool AddRoute(Route route)
        {
            using (_connection)
            {

                SqlCommand command = new SqlCommand("AddRoute", _connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                successParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(successParameter);
                command.Parameters.AddWithValue("@Difficulty", route.Difficulty);
                command.Parameters.AddWithValue("@StartData", route.StartDate);
                command.Parameters.AddWithValue("@EndData", route.EndDate);
                command.Parameters.AddWithValue("@Description", route.Description);
                command.Parameters.AddWithValue("@StartPoint", route.StartPoint);
                command.Parameters.AddWithValue("@EndPoint", route.EndPoint);
                _connection.Open();
                command.ExecuteNonQuery();
                bool success = (bool)successParameter.Value;
                return success;
            }
        }
        public Route GetRouteById(int id)
        {
            Route route = new Route();

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
                        // Чтение данных маршрута из результата запроса
                        route.RouteId = Convert.ToInt32(reader["RouteId"]);
                        route.RouteName = reader["RouteName"].ToString();
                        route.Description = reader["Description"].ToString();
                        route.StartDate = Convert.ToDateTime(reader["StartDate"]);
                        route.EndDate = Convert.ToDateTime(reader["EndDate"]);
                        route.StartPoint = reader["StartPoint"].ToString();
                        route.EndPoint = reader["EndPoint"].ToString();
                        route.Difficulty = reader["Difficulty"].ToString();
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return route;
        }
        public bool UpdateRoute(Route route)
        {
            using (_connection)
            {

                SqlCommand command = new SqlCommand("UpdateRoute", _connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                successParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(successParameter);
                command.Parameters.AddWithValue("@routeName", route.RouteName);
                command.Parameters.AddWithValue("@DurationInDays", route.Duration);
                command.Parameters.AddWithValue("@LengthInKm", route.Length);
                command.Parameters.AddWithValue("@Difficulty", route.Difficulty);
                command.Parameters.AddWithValue("@AuthorID", route.AuthorId);
                _connection.Open();
                command.ExecuteNonQuery();
                bool success = (bool)successParameter.Value;
                return success;
            }
        }
        public bool DeleteRoute(int routeId)
        {
            using (_connection)
            {
                SqlCommand command = new SqlCommand("DeleateRouteById", _connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@RouteID", routeId);
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
