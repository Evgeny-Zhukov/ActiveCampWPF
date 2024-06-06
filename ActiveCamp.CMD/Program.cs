using ActiveCamp.BL;
using ActiveCamp.BL.Controller;
using ActiveCamp.BL.Model;
using System;

namespace ActiveCamp.CMD
{

    internal class Program
    {
        private static readonly string _connectionString = "Server=DESKTOP-VJNL8L9;Database = HikingAppDB;Trusted_Connection=True;MultipleActiveResultSets=True";
        static void Main(string[] args)
        {
            ActiveCampDbContext activeCampDbContext = new ActiveCampDbContext();
            Equipment equipment = new Equipment("Name",1.1);
            EquipmentManager equipmentManager = new EquipmentManager();
            equipmentManager.AddEquipment(equipment);

            Dish dish = new Dish("Neme", 1,1,1,1);
            DishManager dishManager = new DishManager();
            dishManager.AddDish(dish); // TODO: не добавляется еда

            Illness illness = new Illness("Name", "Description");
            IllnessManager illnessManager = new IllnessManager();
            illnessManager.AddIllness(illness);// TODO: не добавляется недуг

            User user = new User("Name","sdfs");
            UserManager userManager = new UserManager();
            userManager.RegisterUser(user);

            UserDish userDish = new UserDish(1,2);
            UserDishManager userDishManager = new UserDishManager();
            userDishManager.AddUserDish(userDish);// TODO: не добавляется DISH

            RecordOfUserEquipment userEquipment = new RecordOfUserEquipment(12, "eds",2, 42,1,"sdj");
            UserEquipmentManager userEquipmentManager = new UserEquipmentManager();
            userEquipmentManager.AddUserEquipment(userEquipment);

        }
    }
}

