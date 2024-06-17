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
/*            RouteManager routeManager = new RouteManager();
            List<Route> routes = new List<Route>();
            routes = routeManager.GetAllUserRoutes(34);*/
            GroupDish groupDish1 = new GroupDish(7,1,420,"Завтрак");
            GroupDish groupDish2= new GroupDish(7,1,50,"Обед");
            GroupDish groupDish3 = new GroupDish(7,1,60,"Ужин");
            List<GroupDish> groupDishes = new List<GroupDish>();
            groupDishes.Add(groupDish1);
            groupDishes.Add(groupDish2);
            groupDishes.Add(groupDish3);
            GroupDishManager group = new GroupDishManager();
            //group.AddGroupDish(groupDishes);
            //group.GetGroupDishById(7);
            group.DeleteGroupDish(1);
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

