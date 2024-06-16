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
            groupM.AddUserToGroup(7, 34);
            //assert

        }
    }
}

