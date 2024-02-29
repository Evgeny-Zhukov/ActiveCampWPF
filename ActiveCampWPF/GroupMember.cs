namespace ActiveCamp
{
    public class GroupMember
    {
        public int? GroupId { get; set; }
        public int? UserID { get; set; }
        //связь с другими таблицами
        //public virtual ICollection<User> Users { get; set; }
        //public virtual ICollection<Group> Group {  get; set; }
    }
}
