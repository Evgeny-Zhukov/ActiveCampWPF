using ActiveCamp.BL.Controller;
using ActiveCamp.BL.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ActiveCamp.BLTests.Controller
{
    [TestClass]
    public class EquipmentTests
    {
        [TestMethod]
        public void AddEquipment_Equipment_True()
        {
            //arrange
            Equipment dish = new Equipment("TestName",1.23);
            EquipmentManager manager = new EquipmentManager();
            bool expected = true;
            //act
            bool actual = manager.AddEquipment(dish);
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetEquipment_Equipment_List()
        {
            //arrange
            int id = 15;
            EquipmentManager manager = new EquipmentManager();
            List<Equipment> expected = new List<Equipment>();
            //act
            List<Equipment> actual = manager.GetEquipment(id);
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void UpdateEquipment_Equipment_True()
        {
            //arrange
            Equipment dish = new Equipment("TestName", 1.24);
            EquipmentManager manager = new EquipmentManager();
            dish.equipmentID = 22;
            bool expected = true;
            //act
            bool actual = manager.UpdateEquipment(dish);
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void DeleteEquipment_Equipment_True()
        {
            //arrange
            int dishID = 22;
            EquipmentManager manager = new EquipmentManager();
            bool expected = true;
            //act
            bool actual = manager.DeleteEquipment(dishID);
            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
