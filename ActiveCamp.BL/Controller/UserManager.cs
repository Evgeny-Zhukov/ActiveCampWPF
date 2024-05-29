using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System;

namespace ActiveCamp.BL.Controller
{
    public class UserManager
    {
        private readonly string _connectionString;

        public UserManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool RegisterUser(User user)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                SqlCommand command = new SqlCommand("CreateUser", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@Password", user.Password);

                SqlParameter successParameter = new SqlParameter("@Success", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(successParameter);

                connection.Open();
                command.ExecuteNonQuery();
                
                return (bool)successParameter.Value;
            }
        }
        public bool VerifyUserByLogin(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("VerifyUserByLogin", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    SqlParameter isLoginSuccessfulParam = new SqlParameter("@IsLoginSuccessful", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(isLoginSuccessfulParam);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    return (bool)isLoginSuccessfulParam.Value;
                }
            }
        }
        
        public static string GenerateSalt()
        {
            byte[] saltBytes = new byte[32];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }
        public User GetUserById(int userId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("GetUserById", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@UserID", userId);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new User((int)reader["UserId"], reader["Username"].ToString());
                    }
                }
            }

            return null;
        }

        public void UpdatePassword(int userId, string newPassword)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("UpdateUserPassword", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@UserID", userId);
                command.Parameters.AddWithValue("@NewPassword", newPassword);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }

}
