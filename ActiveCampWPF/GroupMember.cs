namespace ActiveCamp
{
    public class GroupMember
    {
        public int? GroupID { get; set; }
        public int? UserID { get; set; }
        //связь с другими таблицами
        public virtual ICollection<User> User { get; set; }
        public virtual ICollection<Group> Group {  get; set; }
    }
}
