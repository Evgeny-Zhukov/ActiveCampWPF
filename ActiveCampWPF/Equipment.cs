namespace ActiveCamp
{
    public class Equipment
    {
        public int EquipmentID { get; set; }
        public string EquipmentName { get; set; }
        public double EquipmentWeight { get; set; }
        public User User { get; set; }
        //связь с другими таблицами
        public virtual ICollection<UserEquipment> UserEquipment { get; set; }
    }
}
