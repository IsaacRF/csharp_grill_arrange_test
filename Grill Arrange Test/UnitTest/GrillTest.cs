using Microsoft.VisualStudio.TestTools.UnitTesting;
using Grill_Arrange_Test.ViewModels;
using Grill_Arrange_Test.Models;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class GrillTest
    {
        GrillViewModel grill = new GrillViewModel(20, 30);
        GrillMenuModel menu1;
        GrillMenuModel menu2;
        List<GrillMenuModel> menuList;

        [TestInitialize]
        public void TestInitialize()
        {
            grill = new GrillViewModel(20, 30);

            //Mock Grill Menus
            menu1 = new GrillMenuModel(
                new System.Guid("99a08d4b-8e20-4811-beee-1b56ac545f90"),
                "Menu 04",
                new List<GrillMenuItemModel>()
                {
                    new GrillMenuItemModel(new System.Guid("90ed4d57-7921-4c66-b208-4e312a9852e6"), "Paprika Sausage", 6, 3, "00:08:00", 40),
                    new GrillMenuItemModel(new System.Guid("47614f4d-2621-40de-8be7-e35abed8ed44"), "Veal", 8, 4, "00:08:00", 10),
                });

            menu2 = new GrillMenuModel(
                new System.Guid("3d88e518-0779-47b5-b395-492ce2a090ee"),
                "Menu 13",
                new List<GrillMenuItemModel>()
                {
                    new GrillMenuItemModel(new System.Guid("2513c0e6-a8ec-412c-b8b7-b9b8695f3290"), "Item 3", 5, 3, "00:08:00", 20),
                    new GrillMenuItemModel(new System.Guid("1f399e24-7c20-4f18-afb5-3a748cc79ce0"), "Item 4", 12, 5, "00:08:00", 10),
                });

            menuList = new List<GrillMenuModel>();
        }

        [TestMethod]
        public void GrillInitializationTest()
        {
            Assert.IsNotNull(grill);
        }

        [TestMethod]
        public void GrillCookMenu1Test()
        {
            menuList.Add(menu1);
            Assert.AreEqual(grill.CookMenus(menuList), 2, "Error Menu 1: Expected 2 rounds");
        }

        [TestMethod]
        public void GrillCookMenu2Test()
        {            
            menuList.Add(menu2);
            Assert.AreEqual(grill.CookMenus(menuList), 2, "Error Menu 2: Expected 2 rounds");
        }

        [TestMethod]
        public void GrillCookAllMenus()
        {
            menuList.Add(menu1);
            menuList.Add(menu2);
            Assert.AreEqual(grill.CookMenus(menuList), 4, "Error Menu 1+2: Expected 4 rounds");
        }
    }
}
