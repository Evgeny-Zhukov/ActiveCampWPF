namespace ActiveCamp
{
    public class GroupMember
    {
        public int? GroupID { get; set; }
        public Group? Group { get; set; }

        public int? UserID { get; set; }
        public Users? User { get; set; }
    }
}
