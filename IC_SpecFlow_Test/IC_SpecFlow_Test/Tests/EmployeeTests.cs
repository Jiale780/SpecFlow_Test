using IC_SpecFlow_Test.Pages;
using IC_SpecFlow_Test.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace IC_SpecFlow_Test.Tests
{
    [TestFixture, Description("Navigate to the Employee Page")]
    [Parallelizable]
    public class EmployeeTests : CommonDriver
    {
        // Home Page object initialization and definition
        HomePage homePageObj = new HomePage();
        // TM Page object initialization and definition
        EmployeePage employeePageObj = new EmployeePage();

        [Test, Order(1), Description("Check if the user is able to create Employee record with valid data")]
        public void CreateEmployeeTest()
        {
            homePageObj.GoToEmployeePage(testDriver);
            employeePageObj.CreateEmployee(testDriver);
        }

        [Test, Order(2), Description("Check if the user is able to edit Employee record with valid data")]
        public void EditEmployeeTest(string Name, string UserName)
        {
            homePageObj.GoToEmployeePage(testDriver);
            employeePageObj.EditEmployee(testDriver, Name, UserName);
        }

        [Test, Order(3), Description("Check if the user is able to delete Employee record with valid data")]
        public void DeleteEmployeeTest()
        {
            homePageObj.GoToEmployeePage(testDriver);
            employeePageObj.DeleteEmployee(testDriver);
        }
    }
}
