using ActiveCamp.BL.Controller;
using ActiveCamp.BL.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ActiveCamp.BLTests.Controller
{
    [TestClass]
    public class RouteTests
    {
        [TestMethod]
        public void AddRoute_Route_True()
        {
            //arrange
            Route dish = new Route("Name", 25, DateTime.Now, DateTime.MaxValue, "Descript","Start", "Point", 100, "2", 3, false);
            RouteManager manager = new RouteManager();
            bool expected = true;
            //act
            bool actual = manager.AddRoute(dish);
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetRoute_Route_List()
        {
            //arrange
            int id = 25;
            RouteManager manager = new RouteManager();
            Route Route = new Route("Name", 25, DateTime.Now, DateTime.MaxValue, "Descript", "Start", "Point", 100, "2", 3, false);
            List<Route> expected = new List<Route> { Route };
            //act
            List<Route> actual = manager.GetRouteById(id);
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void UpdateRoute_Route_True()
        {
            //arrange
            Route dish = new Route("Name", 25, DateTime.Now, DateTime.MaxValue, "Descript1", "Start1", "Point", 100, "2", 3, false);
            RouteManager manager = new RouteManager();
            dish.RouteId = 1;
            bool expected = true;
            //act
            bool actual = manager.UpdateRoute(dish);
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void DeleteRoute_Route_True()
        {
            //arrange
            int dishID = 1;
            RouteManager manager = new RouteManager();
            bool expected = true;
            //act
            bool actual = manager.DeleteRoute(dishID);
            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
