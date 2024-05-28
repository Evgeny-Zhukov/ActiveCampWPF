using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActiveCamp.BL;
using ActiveCamp.BL.Controller;
using ActiveCamp.BL.Model;

namespace ActiveCamp.CMD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string name = Console.ReadLine();
            //double weight = double.Parse(Console.ReadLine());
            /*ActiveCampDbContext activeCampDbContext = new ActiveCampDbContext(connectionString);
                    string username = Console.ReadLine();
                    string password = Console.ReadLine();
                    User user = new User { Username = username, Password = password };

                    if (activeCampDbContext.RegisterUser(user))
                    {
                        Console.WriteLine("Access");
                    }
                    else
                    {
                        Console.WriteLine("Error");
                    }*/
            Session userSession = new Session("User");
            Console.WriteLine($"Initial Session: {userSession.SessionId}, {userSession.LoginTime}");

            // Save session
            SessionManager.SaveSession(userSession);

            // Load session
            Session loadedSession = SessionManager.LoadSession();
            Console.WriteLine($"Loaded Session: {loadedSession.SessionId}, {loadedSession.LoginTime}");

            // Clear session (delete from storage)
            SessionManager.ClearSession();

            // In-memory objects remain unaffected
            Console.WriteLine($"Session still in memory: {userSession.SessionId}, {userSession.LoginTime}");
            Console.WriteLine($"Loaded session still in memory: {loadedSession.SessionId}, {loadedSession.LoginTime}");

            // Attempt to load session after clearing
            Session afterClearSession = SessionManager.LoadSession();
            if (afterClearSession == null)
            {
                Console.WriteLine("Session file deleted. No session loaded.");
            }

            /*using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sqlQuery = "SELECT * FROM dbo.GetUserById(@UserId)";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.Add("@UserId", SqlDbType.Int).Value = 1; // тут 1 это по какому id ищем

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0); 
                            string username = reader.GetString(1); 
                            string password = reader.GetString(2);

                            Console.WriteLine($"ID: {id}, Username: {username}, Password: {password}");
                        }
                    }
                }
            }*/
            /*using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("AddEquipment", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@equipmentName", name);
                command.Parameters.AddWithValue("@equipmentWeight", weight); 

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Хранимая процедура успешно выполнена.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                }
            }*/
            /*Console.WriteLine("Введите ID снаряжения для удаления");
            int id = int.Parse(Console.ReadLine());
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("DeleteEquipmentByID", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@equipmentID", id);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Хранимая процедура успешно выполнена.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                }
            }*/
            //Пример работы скалярной функции
            /*using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT dbo.MyFunction(@Param1, @Param2)", connection))
                {
                    command.Parameters.Add("@Param1", SqlDbType.Int).Value = 5;
                    command.Parameters.Add("@Param2", SqlDbType.VarChar).Value = "Hello";

                    int result = (int)command.ExecuteScalar();

                    Console.WriteLine("Результат функции: " + result);
                }
            }*/
        }
    }
}

