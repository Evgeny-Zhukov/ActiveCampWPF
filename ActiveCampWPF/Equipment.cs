namespace ActiveCamp
{
    public class Equipment
    {
        public int EquipmentID { get; set; }
        public string EquipmentName { get; set; }
        public string EquipmentWeight { get; set; }
        //связь с другими таблицами
        //public virtual UserEquipment UserEquipment { get; set; }
    }
}
