namespace ActiveCamp
{
    public class UserEquipment
    {
        public int EquipmentListID { get; set; }
        public int? UserID { get; set; }
        public string EquipmentName { get; set; }
        public double? EquipmentWeight { get; set; }
        public int? EquipmentCount { get; set; }
        //связь с другими таблицами
        //public virtual Equipment Equipment { get; set; }
        //public virtual User User { get; set; }
    }
}   
