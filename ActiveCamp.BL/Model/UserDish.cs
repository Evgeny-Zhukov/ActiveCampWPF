namespace ActiveCamp.BL.Model
{
    public class UserDish
    {

        public int UserDishID { get; set; }
        public int DishID { get; set; }
        public int UserID { get; set; }
        public UserDish() { }
        public UserDish(int dishID, int userID)
        {
            DishID = dishID;
            UserID = userID;
        }

    }
}