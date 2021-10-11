using IC_SpecFlow_Test.Pages;
using IC_SpecFlow_Test.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace IC_SpecFlow_Test.Tests
{
    [TestFixture]
    [Parallelizable]
    public class TM_Tests : CommonDriver
    {
        [Test, Order(1), Description("Check if the user is able to create Time record with valid data")]
        public void CreateTMTest()
        {
            // Home Page object initialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.GoToTMPage(testDriver);

            // TM Page object initialization and definition
            TMPage tmPageObj = new TMPage();
            tmPageObj.CreateTM(testDriver);
        }

        [Test, Order(2), Description("Check if the user is able to edit Time record with valid data")]
        public void EditTMTest(string Code, string TypeCode, string Description, decimal Price)
        {
            // Home Page object initialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.GoToTMPage(testDriver);

            // Edit Time
            TMPage tmPageObj = new TMPage();
            tmPageObj.EditTM(testDriver, Code, TypeCode, Description, Price);
        }

        [Test, Order(3), Description("Check if the user is able to delete Material record")]
        public void DeleteTMTest()
        {
            // Home Page object initialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.GoToTMPage(testDriver);

            // Delete Material
            TMPage tmPageObj = new TMPage();
            tmPageObj.DeleteTM(testDriver);
        }

    }
}
