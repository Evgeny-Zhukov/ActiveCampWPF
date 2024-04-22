using System;
using System.Collections.Generic;
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
            string connectionString = "Server=DESKTOP-VJNL8L9;Database = HikingAppDB;Trusted_Connection=True;MultipleActiveResultSets=True";
            UserController userController = new UserController(connectionString);
            string username = Console.ReadLine();
            string password = Console.ReadLine();
            User user = new User { Username = username, Password = password };

            if (userController.RegisterUser(user))
            {
                Console.WriteLine("Access");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
    }
}

