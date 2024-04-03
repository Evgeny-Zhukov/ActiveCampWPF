using System.ComponentModel.DataAnnotations;

namespace ActiveCamp
{
    public class Equipment
    {
        public int EquipmentID { get; set; }
        public string EquipmentName { get; set; }
        public string? EquipmentWeight { get; set; }
        //связь с другими таблицами
        public virtual ICollection<UserEquipment> UserEquipments { get; set; }
    }
    public class User
    {
        [Key]  // Атрибут указывает, что это первичный ключ
        public int UserID { get; set; }

        public string UserName { get; set; }
    }

}
