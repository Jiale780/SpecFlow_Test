using IC_SpecFlow_Test.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace IC_SpecFlow_Test.Utilities
{
    public class CommonDriver
    {
        public IWebDriver testDriver;

        [BeforeScenario]
        public void GoToLoginPage()
        {
            // Open chrome browser
            testDriver = new ChromeDriver();
   
            // Login Page object initialization and definition
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.GoToLoginPage(testDriver);
        }
   
        [AfterScenario]
        public void CloseTestRun() => testDriver.Quit();
    }
}
