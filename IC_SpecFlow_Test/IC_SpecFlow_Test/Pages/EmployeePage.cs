using IC_SpecFlow_Test.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace IC_SpecFlow_Test.Pages
{
    class EmployeePage
    {
        public void CreateEmployee(IWebDriver testDriver)
        {
            // Click on "Create New" button
            //Wait.WaitForElementToBeClickable(testDriver, "XPath", "//*[@id='container']/p/a", 2);
            IWebElement createNewButton = testDriver.FindElement(By.XPath("//*[@id='container']/p/a"));
            createNewButton.Click();

            // Identify "Name" from Textbox and Input name
            //Wait.WaitForElementToExist(testDriver, "XPath", "//*[@id='Name']", 2);
            IWebElement employeeName = testDriver.FindElement(By.Id("Name"));
            employeeName.SendKeys("Fay Adios");

            // Identify "Username" from Textbox and Input username
            //Wait.WaitForElementToExist(testDriver, "XPath", "//*[@id='Username']", 2);
            IWebElement usernameTextBox = testDriver.FindElement(By.Id("Username"));
            usernameTextBox.SendKeys("Fay");

            // Identify "Password" from Textbox and Input password
            //Wait.WaitForElementToExist(testDriver, "XPath", "//*[@id='Password']", 2);
            IWebElement passwordTextBox = testDriver.FindElement(By.Id("Password"));
            passwordTextBox.SendKeys("Tests123%");

            // Identify "reTypePassword" from Textbox and Input RetypePassword
            //Wait.WaitForElementToExist(testDriver, "XPath", "//*[@id='RetypePassword']", 2);
            IWebElement reTypePasswordTextBox = testDriver.FindElement(By.Id("RetypePassword"));
            reTypePasswordTextBox.SendKeys("Tests123%");

            // Selecting CheckBox
            //Wait.WaitForElementToExist(testDriver, "XPath", "//*[@id='IsAdmin']", 2);
            IWebElement checkBox = testDriver.FindElement(By.Id("IsAdmin"));
            // This will Toggle the Check box
            checkBox.Click();

            // Identify "GroupsList" textbox and Input Groupslist
            //Wait.WaitForElementToBeClickable(testDriver, "XPath", "//*[@id='UserEditForm']/div/div[8]/div/div/div[1]", 2);
            IWebElement groupsListTextBox = testDriver.FindElement(By.XPath("//*[@id='UserEditForm']/div/div[8]/div/div/div[1]"));
            groupsListTextBox.Click();

            Thread.Sleep(2000);
            IWebElement groupsListIDTextBox = testDriver.FindElement(By.XPath("//*[@id='groupList_listbox']/li[13]"));
            groupsListIDTextBox.Click();

            // Click on "Save" button
            IWebElement saveButton = testDriver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            //Thread.Sleep(4000);

            // Click on "Back To List" url link
            //Wait.WaitForElementToBeClickable(testDriver, "XPath", "//*[@id='container']/div/a", 2);
            IWebElement backToListUrlLink = testDriver.FindElement(By.XPath("//*[@id='container']/div/a"));
            backToListUrlLink.Click();

            // Click on "Go to the last page" button
            Thread.Sleep(5000);
            IWebElement goToLastPageButton = testDriver.FindElement(By.XPath("//*[@id='usersGrid']/div[4]/a[4]/span"));
            goToLastPageButton.Click();
        }

        public string GetEmployeeName(IWebDriver testDriver)
        {
            IWebElement newEmployeeName = testDriver.FindElement(By.XPath("//*[@id='usersGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            return newEmployeeName.Text;
        }

        public string GetUsername(IWebDriver testDriver)
        {
            IWebElement newUsername = testDriver.FindElement(By.XPath("//*[@id='usersGrid']/div[3]/table/tbody/tr[last()]/td[2]"));
            return newUsername.Text;
        }

        public void EditEmployee(IWebDriver testDriver, string Name, string UserName)
        {
            // Click on "Go to the last page" button
            Thread.Sleep(5000);
            IWebElement goToLastPageButton = testDriver.FindElement(By.XPath("//*[@id='usersGrid']/div[4]/a[4]/span"));
            goToLastPageButton.Click();

            IWebElement findRecordCreated = testDriver.FindElement(By.XPath("//*[@id='usersGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            if (findRecordCreated.Text == "Fay Adios")
            {
                // Click on the Edit Button
                Wait.WaitForElementToBeClickable(testDriver, "XPath", "//*[@id='usersGrid']/div[3]/table/tbody/tr[last()]/td[3]/a[1]", 2);
                IWebElement editButton = testDriver.FindElement(By.XPath("//*[@id='usersGrid']/div[3]/table/tbody/tr[last()]/td[3]/a[1]"));
                editButton.Click();

                // Select "Name" from Textbox and Input name
                Wait.WaitForElementToExist(testDriver, "XPath", "//*[@id='Name']", 2);
                IWebElement employeeName = testDriver.FindElement(By.Id("Name"));
                employeeName.Clear();
                employeeName.SendKeys(Name);

                // Identify "Username" from Textbox and Input username
                Wait.WaitForElementToExist(testDriver, "XPath", "//*[@id='Username']", 2);
                IWebElement usernameTextBox = testDriver.FindElement(By.Id("Username"));
                usernameTextBox.Clear();
                usernameTextBox.SendKeys(UserName);

                // Identify "Password" from Textbox and Input password
                Wait.WaitForElementToExist(testDriver, "XPath", "//*[@id='Password']", 2);
                IWebElement passwordTextBox = testDriver.FindElement(By.Id("Password"));
                passwordTextBox.Clear();
                passwordTextBox.SendKeys("Sample123%");

                // Identify "reTypePassword" from Textbox and Input RetypePassword
                Wait.WaitForElementToExist(testDriver, "XPath", "//*[@id='RetypePassword']", 2);
                IWebElement reTypePasswordTextBox = testDriver.FindElement(By.Id("RetypePassword"));
                reTypePasswordTextBox.Clear();
                reTypePasswordTextBox.SendKeys("Sample123%");

                // Selecting CheckBox
                Wait.WaitForElementToExist(testDriver, "XPath", "//*[@id='IsAdmin']", 2);
                IWebElement checkBox = testDriver.FindElement(By.Id("IsAdmin"));

                // Check whether the Check box is toggled on 
                Assert.That(checkBox.Selected);

                //// Identify "GroupsList" textbox and Input Groupslist
                //Wait.WaitForElementToBeClickable(testDriver, "XPath", "//*[@id='UserEditForm']/div/div[8]/div/div/div[1]", 3);
                //IWebElement groupsListTextBox = testDriver.FindElement(By.XPath("//*[@id='UserEditForm']/div/div[8]/div/div/div[1]"));
                //groupsListTextBox.Click();
                //
                //Wait.WaitForElementToBeClickable(testDriver, "XPath", "//*[@id='groupList_listbox']/li[11]", 2);
                //IWebElement groupsListIDTextBox = testDriver.FindElement(By.XPath("//*[@id='groupList_listbox']/li[11]"));
                //groupsListIDTextBox.Click();

                // Click on "Save" button
                //Wait.WaitForElementToBeClickable(testDriver, "XPath", "//*[@id='SaveButton']", 4);
                IWebElement saveButton1 = testDriver.FindElement(By.Id("SaveButton"));
                saveButton1.Click();
                //Thread.Sleep(4000);

                // Click on "Back To List" url link
                Wait.WaitForElementToBeClickable(testDriver, "XPath", "//*[@id='container']/div/a", 2);
                IWebElement backToListUrlLink = testDriver.FindElement(By.XPath("//*[@id='container']/div/a"));
                backToListUrlLink.Click();

                // Click on "Go to the last page" button
                Thread.Sleep(5000);
                IWebElement goToLastPageButton1 = testDriver.FindElement(By.XPath("//*[@id='usersGrid']/div[4]/a[4]/span"));
                goToLastPageButton1.Click();
            }
            else
            {
                Assert.Fail("Record to be edited hasn't been found. Record is not edited.");
            }
        }
        public void DeleteEmployee(IWebDriver testDriver)
        {
            // Click on "Go to the last page" button
            Thread.Sleep(5000);
            IWebElement goToLastPageButton = testDriver.FindElement(By.XPath("//*[@id='usersGrid']/div[4]/a[4]/span"));
            goToLastPageButton.Click();

            IWebElement findRecordCreated = testDriver.FindElement(By.XPath("//*[@id='usersGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            if (findRecordCreated.Text == "Fin Adios")
            {
                // Click on the Delete Button
                IWebElement deleteButton = testDriver.FindElement(By.XPath("//*[@id='usersGrid']/div[3]/table/tbody/tr[last()]/td[3]/a[2]"));
                deleteButton.Click();

                // Alert of the display prompt message for the delete button
                testDriver.SwitchTo().Alert().Accept();
            }
            else
            {
                Assert.Fail("Record to be deleted hasn't been found. Record is not deleted.");
            }
        }
    }
}
