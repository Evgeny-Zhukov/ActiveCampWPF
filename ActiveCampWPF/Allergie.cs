namespace ActiveCamp
{
    public class Allergie
    {
        public int AllergiesID { get; set; }
        public string Allergies {  get; set; }
        //связь с другими таблицами
        //public virtual ICollection<UserDietaryPreferences> UserDietaryPreferences { get; set; }
    }
}
