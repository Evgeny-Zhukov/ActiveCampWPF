using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System;
using ActiveCamp.BL.Model;

namespace ActiveCamp.BL.Controller
{
    public class UserManager
    {
        private ActiveCampDbContext dbContext;
        private SqlConnection _connection;
        public UserManager()
        {
            dbContext = new ActiveCampDbContext();
            _connection = dbContext.GetSqlConnection();
        }
        public bool RegisterUser(User user)
        {
            using (_connection)
            {

                SqlCommand command = new SqlCommand("CreateUser", _connection)
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

                _connection.Open();
                command.ExecuteNonQuery();
                
                return (bool)successParameter.Value;
            }
        }
        public bool VerifyUserByLogin(string username, string password)
        {
            using (_connection)
            {
                using (SqlCommand cmd = new SqlCommand("VerifyUserByLogin", _connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    SqlParameter isLoginSuccessfulParam = new SqlParameter("@IsLoginSuccessful", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(isLoginSuccessfulParam);

                    _connection.Open();
                    cmd.ExecuteNonQuery();

                    return (bool)isLoginSuccessfulParam.Value;
                }
            }
        }
        public User GetUserById(int userId)
        {
            using (_connection)
            {
                SqlCommand command = new SqlCommand("GetUserById", _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@UserID", userId);

                _connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new User((int)reader["UserId"], reader["Username"].ToString());
                    }
                }
            }

            return null;
        }
        public bool DeleteUser(int id)
        {
            using (_connection)
            {
                SqlCommand command = new SqlCommand("DeleteUserById", _connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@userID", id);
                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                successParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(successParameter);
                _connection.Open();
                command.ExecuteNonQuery();
                bool success = (bool)successParameter.Value;
                return success;
            }
        }
        public int GetUserID(User user)
        {
            int userID = -1;
            using (_connection)
            {
                string query = "SELECT * FROM Users WHERE Username = @Username";

                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@Username", user.Username);
                try
                {
                    _connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        userID = Convert.ToInt32(reader["UserID"]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }

            }
            if (userID <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(userID), "ID пользователя должен быть положительным числом.");
            }
            return userID;
        }
    }

}
