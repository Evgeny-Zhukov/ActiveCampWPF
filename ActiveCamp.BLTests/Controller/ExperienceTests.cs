using ActiveCamp.BL.Controller;
using ActiveCamp.BL.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ActiveCamp.BLTests.Controller
{
    [TestClass]
    public class ExperienceTests
    {
        [TestMethod]
        public void AddExperience_Experience_True()
        {
            //arrange
            Experience dish = new Experience(1);
            ExperienceManager manager = new ExperienceManager();
            bool expected = true;
            //act
            bool actual = manager.AddExperience(dish);
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetExperience_Experience_List()
        {
            //arrange
            int id = 1;
            ExperienceManager manager = new ExperienceManager();
            List<Experience> expected = new List<Experience>();
            //act
            List<Experience> actual = manager.GetExperience(id);
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void DeleteExperience_Experience_True()
        {
            //arrange
            int dishID = 2;
            ExperienceManager manager = new ExperienceManager();
            bool expected = true;
            //act
            bool actual = manager.DeleteExperience(dishID);
            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
