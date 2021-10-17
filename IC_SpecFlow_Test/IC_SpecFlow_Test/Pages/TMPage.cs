using IC_SpecFlow_Test.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace IC_SpecFlow_Test.Pages
{
    class TMPage
    {
        public void CreateTM(IWebDriver testDriver, string Code, string Description, Decimal Price)
        {
            // Click on "Create New" button
            IWebElement CreateNewButton = testDriver.FindElement(By.XPath("//*[@id='container']/p/a"));
            CreateNewButton.Click();

            // Select Time from "Type Code" dropdown list
            IWebElement typeCodeDropdown = testDriver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[2]/span"));
            typeCodeDropdown.Click();

            Wait.WaitForElementToBeClickable(testDriver, "XPath", "//*[@id='TypeCode_listbox']/li[2]", 2);
            IWebElement selectTime = testDriver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[2]"));
            selectTime.Click();

            // Identify "Code" from Textbox and Input code
            IWebElement codeTextBox = testDriver.FindElement(By.Id("Code"));
            codeTextBox.SendKeys(Code);

            // Identify "Description" from Textbox and Input description
            IWebElement descriptionTextBox = testDriver.FindElement(By.Id("Description"));
            descriptionTextBox.SendKeys(Description);

            // Identify "Price per unit" textbox and input price
            testDriver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]")).Click();

            IWebElement pricePerUnit = testDriver.FindElement(By.Id("Price"));
            pricePerUnit.SendKeys(Price.ToString());

            // Click on "Save" button
            IWebElement saveButton = testDriver.FindElement(By.Id("SaveButton"));
            saveButton.Click();

            // Click on "Go to the last page" button
            Thread.Sleep(5000);
            IWebElement goToLastPageButton = testDriver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToLastPageButton.Click();
        }

        public string GetCode(IWebDriver testDriver)
        {
            IWebElement newCode = testDriver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            return newCode.Text;
        }

        public string GetTypeCode(IWebDriver testDriver)
        {
            IWebElement newTypeCode = testDriver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[2]"));
            return newTypeCode.Text;
        }

        public string GetDescription(IWebDriver testDriver)
        {
            IWebElement newDescription = testDriver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            return newDescription.Text;
        }

        public string GetPrice(IWebDriver testDriver)
        {
            IWebElement newPrice = testDriver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));
            return newPrice.Text;
        }

        public void EditTM(IWebDriver testDriver, string Code, string TypeCode, string Description, Decimal Price)
        {
            // Click on "Go to the last page" button
            Thread.Sleep(5000);
            IWebElement goToLastPageButton = testDriver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToLastPageButton.Click();

            IWebElement findRecordCreated = testDriver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            if(findRecordCreated.Text == "AutomatedScript")
            {
                // Click on the Edit Button
                IWebElement editButton = testDriver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
                editButton.Click();

                // Click on "TypeCode" from dropdown list and set the Type Code
                Wait.WaitForElementToBeClickable(testDriver, "XPath", "//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[2]/span", 3);
                IWebElement typeCodeDropdown1 = testDriver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[2]/span"));
                typeCodeDropdown1.Click();

                if (TypeCode == "M")
                {
                    Wait.WaitForElementToBeClickable(testDriver, "XPath", "//*[@id='TypeCode_listbox']/li[1]", 2);
                    IWebElement selectMaterial = testDriver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[1]"));
                    selectMaterial.Click();
                }
                else
                {
                    Wait.WaitForElementToBeClickable(testDriver, "XPath", "//*[@id='TypeCode_listbox']/li[2]", 2);
                    IWebElement selectTime = testDriver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[2]"));
                    selectTime.Click();
                }

                // Click on "Code" from Textbox and set the code
                IWebElement codeTextBox1 = testDriver.FindElement(By.Id("Code"));
                codeTextBox1.Clear();
                codeTextBox1.SendKeys(Code);

                // Click on "Description" from Textbox and set the description
                IWebElement descriptionTextBox1 = testDriver.FindElement(By.Id("Description"));
                descriptionTextBox1.Clear();
                descriptionTextBox1.SendKeys(Description);

                // Click on "Price per unit" textbox and clear the price
                IWebElement priceTag = testDriver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span"));
                priceTag.Click();

                IWebElement pricePerUnit1 = testDriver.FindElement(By.Id("Price"));
                pricePerUnit1.Clear();
                priceTag.Click();

                // IWebElement pricePerUnit2 = testDriver.FindElement(By.Id("Price"));
                pricePerUnit1.SendKeys(Price.ToString());

                // Click on "Save" button
                IWebElement saveButton1 = testDriver.FindElement(By.Id("SaveButton"));
                saveButton1.Click();

                // Click on "Go to the last page" button
                Thread.Sleep(5000);
                IWebElement goToLastPageButton1 = testDriver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
                goToLastPageButton1.Click();
            }
            else
            {
                Assert.Fail("Record to be edited hasn't been found. Record is not edited.");
            }
        }

        public void DeleteTM(IWebDriver testDriver)
        {
            // Click on "Go to the last page" button
            Thread.Sleep(5000);
            IWebElement goToLastPageButton = testDriver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToLastPageButton.Click();

            IWebElement findRecordCreated = testDriver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            if (findRecordCreated.Text == "Automated Script")
            {
                // Click on the Delete Button
                IWebElement deleteButton = testDriver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
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
