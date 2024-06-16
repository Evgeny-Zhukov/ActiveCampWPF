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
            Route route = new Route();
            List<Route> routes = new List<Route>();
            RouteManager routeManager = new RouteManager();
            routes = routeManager.GetRouteById(25);
            Console.WriteLine(routes);
            //assert

        }
    }
}

