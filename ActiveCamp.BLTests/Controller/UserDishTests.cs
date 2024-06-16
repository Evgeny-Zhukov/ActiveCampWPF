using ActiveCamp.BL.Controller;
using ActiveCamp.BL.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ActiveCamp.BLTests.Controller
{
    [TestClass]
    public class UserDishTests
    {
        [TestMethod]
        public void AddUserDish_UserDish_True()
        {
            //arrange
            UserDish dish = new UserDish(16,25);
            UserDishManager manager = new UserDishManager();
            bool expected = true;
            //act
            bool actual = manager.AddUserDish(dish);
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetUserDish_UserDish_List()
        {
            //arrange
            int id = 1;
            UserDishManager manager = new UserDishManager();
            UserDish UserDish = new UserDish( 16, 25);
            List<UserDish> expected = new List<UserDish> { UserDish };
            //act
            List<UserDish> actual = manager.GetUserDish(id);
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void UpdateUserDish_UserDish_True()
        {
            //arrange
            UserDish dish = new UserDish( 17, 25);
            UserDishManager manager = new UserDishManager();
            dish.UserDishID = 1;
            bool expected = true;
            //act
            bool actual = manager.UpdateUserDish(dish);
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void DeleteUserDish_UserDish_True()
        {
            //arrange
            int dishID = 2;
            UserDishManager manager = new UserDishManager();
            bool expected = true;
            //act
            bool actual = manager.DeleteUserDish(dishID);
            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
