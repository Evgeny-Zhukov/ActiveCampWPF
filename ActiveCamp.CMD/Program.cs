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
            string connectionString = "Server=DESKTOP-VJNL8L9;Database = HikingAppDB;Trusted_Connection=True;MultipleActiveResultSets=True";
            ActiveCampDbContext db = new ActiveCampDbContext();
            Route route = new Route("Name1",2,4.5,"A1",1);
            db.AddRoute(route);
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

