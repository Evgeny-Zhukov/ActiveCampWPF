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
            GroupMembershipManager gm = new GroupMembershipManager();
            List<GroupMembership> groups = new List<GroupMembership>();
            groups = gm.GetGroupMembership(7);
            

        }
    }
}

