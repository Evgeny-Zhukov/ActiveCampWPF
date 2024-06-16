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
            Route route = new Route("name", 28, DateTime.Now, DateTime.MaxValue, "asg","1", "2",100,"1", 3, false);
            List<Route> routes = new List<Route>();
            RouteManager routeManager = new RouteManager();
            //routeManager.AddRoute(route);
            routes = routeManager.GetAllRoutes();
            Console.WriteLine(routes);
            //assert

        }
    }
}

