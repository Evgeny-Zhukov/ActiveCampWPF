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
            //Route route = new Route(29, "NameemaN", DateTime.Now, DateTime.MaxValue, "Jsfsi", "11", "22", 103, "1", 2, false);
            RouteManager routeManager = new RouteManager();
            List<Route> routes = new List<Route>();
            routes = routeManager.GetAllUserRoutes(34);
            /*Group group = new Group(16, "Kuk", "Link", 25);
            GroupManager groupM = new GroupManager();
            group.GroupId = groupM.CreateGroup(group);*/
            /*GroupMembership groupMembership = new GroupMembership( 7, 32, DateTime.Now);
            GroupMembershipManager groupMembershipManager = new GroupMembershipManager();
            groupMembershipManager.AddGroupMembership(groupMembership);*/
            //assert

        }
    }
}

