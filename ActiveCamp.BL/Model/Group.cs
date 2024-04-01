namespace ActiveCamp
{
    public class Group
    {
        public int? GroupID { get; set; }
        public string? GroupName { get; set; }
        public int? CreatorID { get; set; } // Вторичный ключ 
        public string? Destination { get; set; } 
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public User User { get; set; } // Навигационное свойство
        //связь с другими таблицами
        public virtual ICollection<GroupMember> GroupMember { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
