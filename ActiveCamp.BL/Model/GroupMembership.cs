using System;

namespace ActiveCamp.BL.Model
{
    public class GroupMembership
    {
        public int GroupMembershipId { get; set; }
        public int GroupId { get; set; }
        public int UserId { get; set; }
        public DateTime JoinedDate { get; set; }
    }
}
