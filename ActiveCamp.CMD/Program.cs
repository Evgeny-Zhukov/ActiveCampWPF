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
            /*Group group = new Group(17, "Kuk", "Link", 34);
            
            group.GroupId = groupM.CreateGroup(group);*/
            GroupManager groupM = new GroupManager();
            RouteManager routeManager = new RouteManager();
            List<GroupMembership> groups = new List<GroupMembership>();
            groups = routeManager.GetGroupMembershipsByRoute(17);
            Console.WriteLine();
            //assert

        }
    }
}

