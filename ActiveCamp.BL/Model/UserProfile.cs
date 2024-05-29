using System.Collections.Generic;

namespace ActiveCamp.BL.Model
{
    internal class UserProfile
    {
        public int userID {  get; set; }
        public string name { get; set; }
        public float weight { get; set; }
        public float height { get; set; }
        public string gender { get; set; }
        public List<UserIllness> userIllnesses { get; set; }
        public List<UserEquipment> UserEquipment { get; set; }
        public List<UserDish> userFoodConsumptions { get; set; }
        public string experience { get; set; }
        public UserProfile() { }
    }
}
