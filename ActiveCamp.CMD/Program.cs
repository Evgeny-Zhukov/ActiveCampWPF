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
            RecordOfUserEquipment equipment1 = new RecordOfUserEquipment();
            equipment1.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == "EquipmentName")
                {
                    Console.WriteLine($"{e.PropertyName} has changed");
                    equipment1.CountOfEquipment += 1;
                };
                
            };
            equipment1.EquipmentName = "TestName";
            Console.WriteLine(equipment1.CountOfEquipment);
        }
    }
}

