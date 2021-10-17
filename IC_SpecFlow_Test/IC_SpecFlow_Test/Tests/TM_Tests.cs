using IC_SpecFlow_Test.Pages;
using IC_SpecFlow_Test.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace IC_SpecFlow_Test.Tests
{
    [TestFixture, Description("Navigate to the Time & Material Page")]
    [Parallelizable]
    public class TM_Tests : CommonDriver
    {
        // Home Page object initialization and definition
        HomePage homePageObj = new HomePage();
        // TM Page object initialization and definition
        TMPage tmPageObj = new TMPage();

        [Test, Order(1), Description("Check if the user is able to create Time record with valid data")]
        public void CreateTMTest(string Code, string Description, Decimal Price)
        {
            homePageObj.GoToTMPage(testDriver);
            tmPageObj.CreateTM(testDriver, Code, Description, Price);
        }

        [Test, Order(2), Description("Check if the user is able to edit Time record with valid data")]
        public void EditTMTest(string Code, string TypeCode, string Description, Decimal Price)
        {
            homePageObj.GoToTMPage(testDriver);
            tmPageObj.EditTM(testDriver, Code, TypeCode, Description, Price);
        }

        [Test, Order(3), Description("Check if the user is able to delete Material record")]
        public void DeleteTMTest()
        {
            homePageObj.GoToTMPage(testDriver);
            tmPageObj.DeleteTM(testDriver);
        }
    }
}
