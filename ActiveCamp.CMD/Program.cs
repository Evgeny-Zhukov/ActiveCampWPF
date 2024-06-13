using ActiveCamp.BL;
using ActiveCamp.BL.Controller;
using ActiveCamp.BL.Model;
using System;
using System.Collections.Generic;

namespace ActiveCamp.CMD
{

    internal class Program
    {
        static void Main(string[] args)
        {
            ActiveCampDbContext activeCampDbContext = new ActiveCampDbContext();
            UserManager userManager = new UserManager();
            User user = new User("Name1", "123");
            int a;
            a = userManager.RegisterUser(user);
            Console.WriteLine(a);
        }
    }
}

