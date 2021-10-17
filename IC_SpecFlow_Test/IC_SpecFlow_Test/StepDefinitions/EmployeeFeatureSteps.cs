using IC_SpecFlow_Test.Pages;
using IC_SpecFlow_Test.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace IC_SpecFlow_Test.StepDefinitions
{
    [Binding]
    public class EmployeeFeatureSteps : CommonDriver
    {
        // TM Page object initialization and definition
        EmployeePage employeePageObj = new EmployeePage();
        // Home Page object initialization and definition
        HomePage homePageObj = new HomePage();
        // Login Page object initialization and definition
        LoginPage loginPageObj = new LoginPage();

        [Given(@"I logged into turn up portal of employee page successfully")]
        public void GivenILoggedIntoTurnUpPortalOfEmployeePageSuccessfully()
        {
            // Open chrome browser
            testDriver = new ChromeDriver();

            loginPageObj.GoToLoginPage(testDriver);
            loginPageObj.KeyInCredentials(testDriver);
            loginPageObj.ClickLoginBtn(testDriver);
            loginPageObj.ValidateUser(testDriver);
        }
        
        [Given(@"I navigate to employee page")]
        public void GivenINavigateToEmployeePage()
        {
            homePageObj.GoToEmployeePage(testDriver);
        }
        
        [When(@"I create employee record")]
        public void WhenICreateEmployeeRecord()
        {
            employeePageObj.CreateEmployee(testDriver);
        }
        
        [Then(@"the employee record should be created successfully")]
        public void ThenTheEmployeeRecordShouldBeCreatedSuccessfully()
        {
            string newEmployeeName = employeePageObj.GetEmployeeName(testDriver);
            string newUsername = employeePageObj.GetUsername(testDriver);

            // Assertion that Time record has been created.
            Assert.That(newEmployeeName == "Fay Adios", "Actual Employee Name and expected employee name don't match");
            Assert.That(newUsername == "Fay", "Actual Username and expected username don't match");
        }

        [When(@"I update '(.*)', '(.*)' on an employee record")]
        public void WhenIUpdateOnAnEmployeeRecord(string Name, string UserName)
        {
            employeePageObj.EditEmployee(testDriver, Name, UserName);
        }

        [Then(@"the record should have the updated '(.*)', '(.*)' successfully")]
        public void ThenTheRecordShouldHaveTheUpdatedSuccessfully(string Name, string UserName)
        {
            // Assertion that Time record has been edited.
            Assert.That(employeePageObj.GetEmployeeName(testDriver) == Name, "Actual Name and expected name don't match");
            Assert.That(employeePageObj.GetUsername(testDriver) == UserName, "Actual UserName and expected username don't match");
        }

        [When(@"I delete on an employee record")]
        public void WhenIDeleteOnAnEmployeeRecord()
        {
            employeePageObj.DeleteEmployee(testDriver);
        }

        [Then(@"the employee record should be deleted successfully")]
        public void ThenTheEmployeeRecordShouldBeDeletedSuccessfully()
        {
            string editedEmployeeName = employeePageObj.GetEmployeeName(testDriver);
            string editedUsername = employeePageObj.GetUsername(testDriver);

            // Assertion that Time record has been created.
            Assert.That(editedEmployeeName == "Fin Adios", "Actual Employee Name and expected employee name don't match");
            Assert.That(editedUsername == "Fin", "Actual Username and expected username don't match");
        }
    }
}
