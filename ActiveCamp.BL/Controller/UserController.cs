using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ActiveCamp.BL.Controller
{
    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController
    {
        private readonly string connectionString = "";

        public User CurrentUser { get; private set; }

        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException(nameof(userName));
            }

            // TODO: Получить пользователя из базы данных по имени пользователя
            CurrentUser = GetUserByUsername(userName);
        }

        public void RegisterUser(User user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Users (Username, Email, Password, Name) VALUES (@Username, @Email, @Password, @Name)", connection);
                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@Name", user.Name);
                command.ExecuteNonQuery();
            }
        }

        public bool Login(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password", connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }
        private User GetUserByUsername(string username)
        {
            // TODO: Получить пользователя из базы данных по имени пользователя
            throw new NotImplementedException();
        }
    }
}