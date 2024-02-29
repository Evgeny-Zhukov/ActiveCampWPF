// User.cs
using ActiveCamp;

public class User
{
    public int UserID { get;   set; }
    public string Username { get;  set; }
    public string Email { get;  set; }
    public string Password { get;  set; }
    public string Name { get;  set; }
    public int? EquipmentListID { get; set; }
    public int? PreferencesID { get; set; }
    
    //связь с другими таблицами
    /*public virtual ICollection<UserEquipment> UserEquipments { get; set; }
    public virtual ICollection<UserDietaryPreferences> UserDietaryPreferences { get; set; }
    public virtual GroupMember GroupMember { get; set; }
    public virtual DietaryPreference DietaryPreference { get; set; }
    public virtual Group Group { get; set; }*/
}
