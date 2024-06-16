using ActiveCamp.BL.Controller;
using ActiveCamp.BL.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ActiveCamp.BLTests.Controller
{
    [TestClass]
    public class DishTests
    {
        [TestMethod]
        public void AddDish_Dish_True()
        {
            //arrange
            Dish dish = new Dish("TestName",24,12,64,123);
            DishManager manager = new DishManager();
            bool expected = true;
            //act
            bool actual = manager.AddDish(dish);
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetDish_Dish_List()
        {
            //arrange
            int id = 15;
            DishManager manager = new DishManager();
            List<Dish> expected = new List<Dish>(); 
            //act
            List<Dish> actual = manager.GetDish(id);
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void UpdateDish_Dish_True()
        {
            //arrange
            Dish dish = new Dish("TestName", 24, 12, 64, 123);
            dish.DishID = 15;
            DishManager manager = new DishManager();
            bool expected = true;
            //act
            bool actual = manager.UpdateDish(dish);
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void DeleteDish_Dish_True()
        {
            //arrange
            int dishID = 15;
            DishManager manager = new DishManager();
            bool expected = true;
            //act
            bool actual = manager.DeleteDish(dishID);
            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
