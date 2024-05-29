using System.Collections.Generic;

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
