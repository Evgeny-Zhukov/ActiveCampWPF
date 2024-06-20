using ActiveCamp.BL.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ActiveCamp.BL.Controller
{
    public class UserProfileManager
    {
        private ActiveCampDbContext dbContext;
        private SqlConnection _connection;
        private readonly string _connectionString = "Server=DESKTOP-VJNL8L9;Database = HikingAppDB;Trusted_Connection=True;MultipleActiveResultSets=True";
        public UserProfileManager()
        {
            dbContext = new ActiveCampDbContext();
            _connection = dbContext.GetSqlConnection();
        }

        public UserProfile GetUserProfile(int UserID)
        {
            
            UserProfile userProfile = new UserProfile();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM UserProfile WHERE UserID = @UserID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", UserID);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        userProfile.UserID = User.UserID;
                        userProfile.FirstName = (reader["Name"].ToString());
                        userProfile.SecondName = (reader["SecondName"].ToString());
                        userProfile.Email = (reader["Email"].ToString());
                        userProfile.Height = (Convert.ToInt32(reader["Height"]));
                        userProfile.Weight = (Convert.ToInt32(reader["Weight"]));
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            
            return userProfile;
        }

        public bool ValidateEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }

        public bool UpdateUserProfile(UserProfile userProfile)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("UpdateUserProfile", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                successParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(successParameter);

                command.Parameters.AddWithValue("@UserID", User.UserID);
                command.Parameters.AddWithValue("@FirstName", userProfile.FirstName);
                command.Parameters.AddWithValue("@SecondName", userProfile.SecondName);
                command.Parameters.AddWithValue("@Height", userProfile.Height);
                command.Parameters.AddWithValue("@Weight", userProfile.Weight);
                command.Parameters.AddWithValue("@Email", userProfile.Email);

                connection.Open();
                command.ExecuteNonQuery();
                bool success = (bool)successParameter.Value;
                return success;
            }
        }
        public bool DeleteUserProfile(int userId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("DeleteUserProfileById", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@UserID", userId);

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
