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
            UserProfileManager userProfileManager = new UserProfileManager();
            string email = "123@mail.com";
            userProfileManager.ValidateEmail(email);


        }
    }
}

