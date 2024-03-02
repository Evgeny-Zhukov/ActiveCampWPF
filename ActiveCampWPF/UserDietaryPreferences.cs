namespace ActiveCamp
{
    public class UserDietaryPreferences
    {
        public int PreferencesID { get; set; }
        public int? UserID { get; set; }
        public int? DietaryPreferencesID { get; set; }
        public int? AllergiesID { get; set; }
        public int? DislikesID { get; set; }
        //связь с другими таблицами
        /*public virtual ICollection<User> User  { get; set; }
        public virtual Allergie Allergie { get; set; }
        public virtual DietaryPreference DietaryPreference { get; set; }
        public virtual Dislike Dislike { get; set; }*/
    }
}
