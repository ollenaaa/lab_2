using NUnit.Framework;
using OpenQA.Selenium;
using PageObject;
using System;
using TechTalk.SpecFlow;
using lab_2;
using OpenQA.Selenium.Support.UI;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class SortPostCodeStepDefinitions:BaseSteps
    {
        private CustomerPage customerPage;
        private LoginPage loginPage;
        private ManagerPage managerPage;
        List<string> actualListOfPostCodes = new List<string>();
        List<string> expectedListOfPostCodes = new List<string>();

        [Given(@"I launch the application")]
        public void GivenILaunchTheApplication()
        {
            driver.Url = "https://www.globalsqa.com/angularJs-protractor/BankingProject/#/login";
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            loginPage = new LoginPage(driver);
        }


        [Given(@"I click on the Bank Manager Login link")]
        public void GivenIClickOnTheBankManagerLoginLink()
        {
            loginPage.ClickLogin();
            managerPage = new ManagerPage(driver);
        }

        [Given(@"I click on the Customers menu item")]
        public void GivenIClickOnTheCustomersMenuItem()
        {
            managerPage.ClickCustomers();
        }

        [When(@"I click on the Sorting Button header")]
        public void WhenIClickOnTheSortingButtonHeader()
        {
            customerPage = new CustomerPage(driver);
            Thread.Sleep(1000);
            expectedListOfPostCodes = customerPage.GetPostCode();
            expectedListOfPostCodes.Sort();
            expectedListOfPostCodes.Reverse();
            customerPage.ClickSortPostCode();
            Thread.Sleep(1000);
            actualListOfPostCodes = customerPage.GetPostCode();
        }

        [Then(@"I should see sort post code")]
        public void ThenIShouldSeeSortPostCode()
        {
            Assert.AreEqual(expectedListOfPostCodes, actualListOfPostCodes);
        }
    }
}
