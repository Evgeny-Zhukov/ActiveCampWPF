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
                command.Parameters.AddWithValue("@username", user.Username);
                command.Parameters.AddWithValue ("Password", user.Password);
                connection.Open();
                command.ExecuteNonQuery();
                int count = (int)command.ExecuteScalar();
                bool isValid = count > 0;
                return isValid;
                
                
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
        public bool AddRoute(Route route)//  TODO: Почему-то создает 2 записи в БД
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand("AddRoute", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Difficulty", route.Difficulty);
                command.Parameters.AddWithValue("@StartData", route.startDate);
                command.Parameters.AddWithValue("@EndData", route.endDate);
                command.Parameters.AddWithValue("@Description", route.Description);
                command.Parameters.AddWithValue("@StartPoint", route.startPoint);
                command.Parameters.AddWithValue("@EndPoint", route.endPoint);
                connection.Open();
                command.ExecuteNonQuery();
                int count = (int)command.ExecuteScalar();
                bool isValid = count > 0;
                return isValid;
            }
        }
        public bool UpdateRoute(Route route)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand("UpdateRoute", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@routeName", route.RouteName);
                command.Parameters.AddWithValue("@DurationInDays", route.Duration);
                command.Parameters.AddWithValue("@LengthInKm", route.Length);
                command.Parameters.AddWithValue("@Difficulty", route.Difficulty);
                command.Parameters.AddWithValue("@AuthorID", route.AuthorId);
                connection.Open();
                command.ExecuteNonQuery();
                int count = (int)command.ExecuteScalar();
                bool isValid = count > 0;
                return isValid;
            }
        }
        public bool DeleteRoute(int  routeId) 
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("DeleateRouteById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@RouteID", routeId);
                connection.Open();
                command.ExecuteNonQuery();
                int count = (int)command.ExecuteScalar();
                bool isValid = count > 0;
                return isValid;
            }
        }
    }
}
