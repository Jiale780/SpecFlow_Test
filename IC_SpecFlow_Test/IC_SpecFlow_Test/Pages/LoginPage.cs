using IC_SpecFlow_Test.Utilities;
using NUnit.Framework;
using NUnit_Test_Script.TestDatabase;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace IC_SpecFlow_Test.Pages
{
    class LoginPage
    {
        public void GoToLoginPage(IWebDriver testDriver)
        {
            // Launch turn up portal and maximize window
            string loginPagePath = "http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f";
            testDriver.Navigate().GoToUrl(loginPagePath);
            testDriver.Manage().Window.Maximize();
            testDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            testDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20);
        }

        public void KeyInCredentials(IWebDriver testDriver)
        {
            // Identify the username textbox enter valid username
            IWebElement usernameTextBox = testDriver.FindElement(By.Id("UserName"));
            string username = "hari";
            usernameTextBox.SendKeys(username);

            // Identify password textbox enter valid password
            IWebElement passwordTextBox = testDriver.FindElement(By.Id("Password"));
            string password = "123123";
            passwordTextBox.SendKeys(password);
        }

        public void ClickLoginBtn(IWebDriver testDriver)
        {
            // Identify login button and click
            Wait.WaitForElementToBeClickable(testDriver, "XPath", "//*[@id='loginForm']/form/div[3]/input[1]", 2);
            IWebElement loginButton = testDriver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
            loginButton.Click();
        }

        public string ValidateUser(IWebDriver testDriver)
        {
            Wait.WaitForElementToBeClickable(testDriver, "XPath", "//*[@id='logoutForm']/ul/li/a", 2);
            IWebElement actualUser = testDriver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));
            return actualUser.Text;
        }
    }
}
