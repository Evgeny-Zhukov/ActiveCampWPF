using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveCamp.BL.Model
{
    internal class Group
    {
        public int GroupId { get;}
        public int RouteId { get; set; }
        public string InvitationLink { get; set; }
        public User GroupSupervisor { get;}
        // Добавить роли для участников

    }
}
