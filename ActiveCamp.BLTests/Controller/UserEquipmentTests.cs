using ActiveCamp.BL.Controller;
using ActiveCamp.BL.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ActiveCamp.BLTests.Controller
{
    [TestClass]
    public class UserEquipmentTests
    {
        [TestMethod]
        public void AddUserEquipment_UserEquipment_True()
        {
            //arrange
            UserEquipment dish = new UserEquipment(25,21);
            UserEquipmentManager manager = new UserEquipmentManager();
            bool expected = true;
            //act
            bool actual = manager.AddUserEquipment(dish);
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetUserEquipment_UserEquipment_List()
        {
            //arrange
            int id = 1;
            UserEquipmentManager manager = new UserEquipmentManager();
            UserEquipment UserEquipment = new UserEquipment(25, 21);
            List<UserEquipment> expected = new List<UserEquipment> { UserEquipment };
            //act
            List<UserEquipment> actual = manager.GetUserEquipment(id);
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void DeleteUserEquipment_UserEquipment_True()
        {
            //arrange
            int dishID = 2;
            UserEquipmentManager manager = new UserEquipmentManager();
            bool expected = true;
            //act
            bool actual = manager.DeleteUserEquipment(dishID);
            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
