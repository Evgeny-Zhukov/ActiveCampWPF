namespace ActiveCamp
{
    public class DietaryPreference
    {
        public int DietaryPreferencesID { get; set; }
        public string DietaryPreferences { get; set; }
        //связь с другими таблицами
        public virtual ICollection<UserDietaryPreferences> UserDietaryPreferences { get; set; }
    }
}
