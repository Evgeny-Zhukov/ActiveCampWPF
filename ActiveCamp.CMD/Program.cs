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
            GroupMembershipManager groupMembershipManager = new GroupMembershipManager();
            groupMembershipManager.DeleteGroupMembership(25, 7);
            
            Console.WriteLine();
            //assert

        }
    }
}

