using ActiveCamp.BL.Controller;
using ActiveCamp.BL.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ActiveCamp.BLTests.Controller
{
    [TestClass]
    public class NewsTests
    {
        [TestMethod]
        public void AddNews_News_True()
        {
            //arrange
            News dish = new News(1,"Title","Text dksj", DateTime.Now, false);
            NewsManager manager = new NewsManager();
            bool expected = true;
            //act
            bool actual = manager.AddNews(dish);
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetNews_News_List()
        {
            //arrange
            int id = 3;
            NewsManager manager = new NewsManager();
            News news = new News(1, "Title", "Text dksj", DateTime.Now, false);
            List<News> expected = new List<News> {news};
            //act
            List<News> actual = manager.GetNews(id);
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void UpdateNews_News_True()
        {
            //arrange
            News dish = new News(1, "Title1", "Text dksj2", DateTime.Now, false);
            NewsManager manager = new NewsManager();
            dish.NewsID = 3;
            bool expected = true;
            //act
            bool actual = manager.UpdateNews(dish);
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void DeleteNews_News_True()
        {
            //arrange
            int dishID = 3;
            NewsManager manager = new NewsManager();
            bool expected = true;
            //act
            bool actual = manager.DeleteNews(dishID);
            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
