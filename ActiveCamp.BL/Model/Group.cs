using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveCamp.BL.Model
{
    public class Group
    {
        public int GroupId { get; set; }
        public int RouteId { get; set; }
        public string InvitationLink { get; set; }
        public List<int> UserIds { get; set; } = new List<int>();
        public User GroupSupervisor { get;}
        // Добавить роли для участников

    }
}
