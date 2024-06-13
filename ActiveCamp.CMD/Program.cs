using ActiveCamp.BL.Controller;
using ActiveCamp.BL.Model;
using System;
using System.Collections.Generic;

namespace ActiveCamp.CMD
{

    internal class Program
    {
        private static readonly string _connectionString = "Server=DESKTOP-VJNL8L9;Database = HikingAppDB;Trusted_Connection=True;MultipleActiveResultSets=True";
        static void Main(string[] args)
        {
            ActiveCampDbContext activeCampDbContext = new ActiveCampDbContext();
            RouteManager routeManager = new RouteManager();
            List<Route> routes = new List<Route>();
            routes = routeManager.GetRouteById(13);
            foreach (Route route in routes)
            {
                Console.WriteLine(route);
            }
        }
    }
}

