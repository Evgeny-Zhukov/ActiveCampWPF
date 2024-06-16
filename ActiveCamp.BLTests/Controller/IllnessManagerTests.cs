using ActiveCamp.BL.Controller;
using ActiveCamp.BL.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ActiveCamp.BLTests.Controller
{
    [TestClass]
    public class IllnessManagerTests
    {
        [TestMethod]
        public void AddIllness_Illness_True()
        {
            //arrange
            Illness dish = new Illness("IllnessName","sosjdsidi");
            IllnessManager manager = new IllnessManager();
            bool expected = true;
            //act
            bool actual = manager.AddIllness(dish);
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetIllness_Illness_List()
        {
            //arrange
            int id = 1;
            IllnessManager manager = new IllnessManager();
            Illness expected = new Illness("IllnessName", "sosjdsidi");
            //act
            Illness actual = manager.GetIllness(id);
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void UpdateIllness_Illness_True()
        {
            //arrange
            Illness dish = new Illness("IllnessName1", "sosjdsidi");
            IllnessManager manager = new IllnessManager();
            dish.IllnessID = 1;
            bool expected = true;
            //act
            bool actual = manager.UpdateIllness(dish);
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void DeleteIllness_Illness_True()
        {
            //arrange
            int dishID = 1;
            IllnessManager manager = new IllnessManager();
            bool expected = true;
            //act
            bool actual = manager.DeleteIllness(dishID);
            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
