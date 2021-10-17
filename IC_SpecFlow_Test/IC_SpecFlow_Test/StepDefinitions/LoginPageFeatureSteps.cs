using IC_SpecFlow_Test.Pages;
using IC_SpecFlow_Test.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace IC_SpecFlow_Test.StepDefinitions
{
    [Binding]
    public class LoginPageFeatureSteps : CommonDriver
    {
        // Login Page object initialization and definition
        LoginPage loginPageObj = new LoginPage();

        [Given(@"I navigate to the login page website")]
        public void GivenINavigateToTheLoginPageWebsite()
        {
            // Open chrome browser
            testDriver = new ChromeDriver();

            loginPageObj.GoToLoginPage(testDriver);
        }

        [Given(@"I enter valid useranme and password records")]
        public void GivenIEnterValidUseranmeAndPasswordRecords()
        {
            loginPageObj.KeyInCredentials(testDriver);
        }

        [When(@"I click on the login button")]
        public void WhenIClickOnTheLoginButton()
        {
            loginPageObj.ClickLoginBtn(testDriver);
        }

        [Then(@"The username should be seen on the Dashboard Page")]
        public void ThenTheUsernameShouldBeSeenOnTheDashboardPage()
        {
            string validateUser = loginPageObj.ValidateUser(testDriver);

            // Assertion that Time record has been created.
            Assert.That(validateUser == "Hello hari!", "Actual user and expected user don't match");
        }
    }
}
