using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveCamp.BL.Model
{
    // TODO: Можно выгрузить в xml 
    public class ActiveCampDbContext
    {
        private readonly string connectionString = "Server=DESKTOP-VJNL8L9;Database = HikingAppDB;Trusted_Connection=True;MultipleActiveResultSets=True";

        public ActiveCampDbContext()
        {
        }

        public static SqlConnection GetSqlConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Server=DESKTOP-VJNL8L9;Database = HikingAppDB;Trusted_Connection=True;MultipleActiveResultSets=True"].ConnectionString; // TODO: Сделать явное преобразование (string)
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }

        public bool ValidateCredentials(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password", connection);
                using (command)
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    int count = (int)command.ExecuteScalar();
                    bool isValid = count > 0;
                    return isValid;
                }

            }
        }
        public bool RegisterUser(User user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                
                SqlCommand command = new SqlCommand("CreateUser", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                successParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(successParameter);
                command.Parameters.AddWithValue("@username", user.Username);
                command.Parameters.AddWithValue ("Password", user.Password);
                connection.Open();
                command.ExecuteNonQuery();
                bool success = (bool)successParameter.Value;
                return success;

            }
        }
        public void GetUser(int Id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sqlQuery = "SELECT * FROM dbo.GetUserById(@UserId)";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.Add("@UserId", SqlDbType.Int).Value = Id;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Id;
                            string username = reader.GetString(1);
                            string password = reader.GetString(2);
                        }
                    }
                }
            }
        }
        public Route GetRouteById(int id)
        {
            Route route = new Route();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM HikingRoutes WHERE RouteId = @Id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    connection.Open();
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
                        //route.Duration = Convert.ToInt32(reader["DurationInDays"].);
                        //route.Length = Convert.ToDouble(reader["LengthInKm"]);
                        route.Difficulty = reader["Difficulty"].ToString();
                        //route.AuthorId = Convert.ToInt32(reader["AuthorId"]);
                        Console.WriteLine($"RouteID { route.RouteId} RouteName {route.RouteName} Description {route.Description} StartDate {route.StartDate} EndDate {route.EndDate} StartPoint {route.StartPoint} EndPoint {route.EndPoint} Difficulty {route.Difficulty}");
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
        public bool AddRoute(Route route)//  TODO: Почему-то создает 2 записи в БД
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand("AddRoute", connection);
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
                connection.Open();
                command.ExecuteNonQuery();
                bool success = (bool)successParameter.Value;
                return success;
            }
        }
        public bool UpdateRoute(Route route) 
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand("UpdateRoute", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                successParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(successParameter);
                command.Parameters.AddWithValue("@routeName", route.RouteName);
                command.Parameters.AddWithValue("@DurationInDays", route.Duration);
                command.Parameters.AddWithValue("@LengthInKm", route.Length);
                command.Parameters.AddWithValue("@Difficulty", route.Difficulty);
                command.Parameters.AddWithValue("@AuthorID", route.AuthorId);
                connection.Open();
                command.ExecuteNonQuery();
                bool success = (bool)successParameter.Value;
                return success;
            }
        }
        public bool DeleteRoute(int  routeId) 
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("DeleateRouteById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@RouteID", routeId);
                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                successParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(successParameter);
                connection.Open();
                command.ExecuteNonQuery();
                bool success = (bool)successParameter.Value;
                return success;
            }
        }
    }
}
