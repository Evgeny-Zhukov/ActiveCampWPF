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
            Group group = new Group(17, 34, "", "");
            GroupManager manager = new GroupManager();
            manager.CreateGroup(group);


        }
    }
}

