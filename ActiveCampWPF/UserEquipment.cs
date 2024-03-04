namespace ActiveCamp
{
    public class UserEquipment
    {
        public int UserEquipmentID { get; set; }
        public int? UserID { get; set; }
        public string EquipmentName { get; set; } = string.Empty;
        public float? EquipmentWeight { get; set; } = (float?)0.0;
        public int? EquipmentCount { get; set; } = 0;
        //связь с другими таблицами
        public virtual Equipment Equipment { get; set; }
        public virtual User User { get; set; }
    }
}   
