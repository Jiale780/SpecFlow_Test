using IC_SpecFlow_Test.Pages;
using IC_SpecFlow_Test.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace IC_SpecFlow_Test.StepDefinitions
{
    [Binding]
    public class TMFeatureSteps : CommonDriver
    {
        // TM Page object initialization and definition
        TMPage tmPageObj = new TMPage();
        // Home Page object initialization and definition
        HomePage homePageObj = new HomePage();
        // Login Page object initialization and definition
        LoginPage loginPageObj = new LoginPage();

        [Given(@"I logged into turn up portal successfully")]
        public void GivenILoggedIntoTurnUpPortalSuccessfully()
        {
            // Open chrome browser
            testDriver = new ChromeDriver();

            loginPageObj.GoToLoginPage(testDriver);
        }
        
        [Given(@"I navigate to time and material page")]
        public void GivenINavigateToTimeAndMaterialPage()
        {
            homePageObj.GoToTMPage(testDriver);
        }
        
        [When(@"I create time and material record")]
        public void WhenICreateTimeAndMaterialRecord()
        {
            tmPageObj.CreateTM(testDriver);
        }
        
        [Then(@"the record should be created successfully")]
        public void ThenTheRecordShouldBeCreatedSuccessfully()
        {
            string newCode = tmPageObj.GetCode(testDriver);
            string newTypeCode = tmPageObj.GetTypeCode(testDriver);
            string newDescription = tmPageObj.GetDescription(testDriver);
            string newPrice = tmPageObj.GetPrice(testDriver);

            // Assertion that Time record has been created.
            Assert.That(newCode == "AutomatedScript", "Actual Code and expected code don't match");
            Assert.That(newTypeCode == "T", "Actual TypeCode and expected typecode don't match");
            Assert.That(newDescription == "AutomatedScript", "Actual Description and expected description don't match");
            Assert.That(newPrice == "$37.00", "Actual Price and expected price don't match");
        }

        [When(@"I update '(.*)', '(.*)', '(.*)', '(.*)' on an time and material record")]
        public void WhenIUpdateOnAnTimeAndMaterialRecord(string Code, string TypeCode, string Description, decimal Price)
        {
            tmPageObj.EditTM(testDriver, Code, TypeCode, Description, Price);
        }

        [Then(@"the record should have the updated '(.*)', '(.*)', '(.*)', '(.*)'")]
        public void ThenTheRecordShouldHaveTheUpdated(string Code, string TypeCode, string Description, decimal Price)
        {
            // Assertion that Time record has been edited.
            Assert.That(tmPageObj.GetCode(testDriver) == Code, "Actual Code and expected code don't match");
            Assert.That(tmPageObj.GetTypeCode(testDriver) == TypeCode, "Actual TypeCode and expected typeCode don't match");
            Assert.That(tmPageObj.GetDescription(testDriver) == Description, "Actual Description and expected description don't match");
            Assert.That(tmPageObj.GetPrice(testDriver) != Price.ToString(), "Actual Price and expected price don't match");
        }

        [When(@"I delete on an time and material record")]
        public void WhenIDeleteOnAnTimeAndMaterialRecord()
        {
            tmPageObj.DeleteTM(testDriver);
        }

        [Then(@"the record should have the deleted")]
        public void ThenTheRecordShouldHaveTheDeleted()
        {
            string editedCode = tmPageObj.GetCode(testDriver);
            string editedTypeCode = tmPageObj.GetTypeCode(testDriver);
            string editedDescription = tmPageObj.GetDescription(testDriver);
            string editedPrice = tmPageObj.GetPrice(testDriver);

            // Assertion that Time record has been created.
            Assert.That(editedCode == "Automated Script", "Actual Code and expected code don't match");
            Assert.That(editedTypeCode == "M", "Actual TypeCode and expected typecode don't match");
            Assert.That(editedDescription == "Automated Script is changed", "Actual Description and expected description don't match");
            Assert.That(editedPrice == "$170.00", "Actual Price and expected price don't match");
        }
    }
}
