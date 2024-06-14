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
            User user = new User("1233", "1233");
            int a;
            a = userManager.VerifyUserByLogin(user.Username, user.Password);
            Console.WriteLine(a);
        }
    }
}

