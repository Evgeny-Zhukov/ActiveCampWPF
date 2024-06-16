using ActiveCamp.BL.Controller;
using ActiveCamp.BL.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ActiveCamp.BLTests.Controller
{
    [TestClass]
    public class FavorNewsTests
    {
        [TestMethod]
        public void AddFavorNews_FavorNews_True()
        {
            //arrange
            FavorNews dish = new FavorNews(25, 2);
            FavorNewsManager manager = new FavorNewsManager();
            bool expected = true;
            //act
            bool actual = manager.AddFavorNews(dish);
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetFavorNews_FavorNews_List()
        {
            //arrange
            int id = 1;
            FavorNewsManager manager = new FavorNewsManager();
            List<FavorNews> expected = new List<FavorNews>();
            //act
            List<FavorNews> actual = manager.GetFavorNews(id);
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void UpdateFavorNews_FavorNews_True()
        {
            //arrange
            FavorNews dish = new FavorNews(25,1);
            FavorNewsManager manager = new FavorNewsManager();
            dish.FavorNewsID = 2;
            bool expected = true;
            //act
            bool actual = manager.UpdateFavorNews(dish);
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void DeleteFavorNews_FavorNews_True()
        {
            //arrange
            int dishID = 2;
            FavorNewsManager manager = new FavorNewsManager();
            bool expected = true;
            //act
            bool actual = manager.DeleteFavorNews(dishID,25);
            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
