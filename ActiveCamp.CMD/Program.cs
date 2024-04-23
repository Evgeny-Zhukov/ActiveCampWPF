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
            string connectionString = "Server=DESKTOP-VJNL8L9;Database = HikingAppDB;Trusted_Connection=True;MultipleActiveResultSets=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
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
            }
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

