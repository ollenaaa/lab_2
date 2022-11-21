using lab_2;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObject
{
    public class ManagerPage:BasePage
    {
        public static WebDriverWait wait;

        public ManagerPage(IWebDriver webDriver):base(webDriver)
        {
            wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
        }
        private IWebElement btnCustomers => wait.Until(e => e.FindElement(By.XPath("//button[@ng-click ='showCust()']")));
        public void ClickCustomers() => btnCustomers.Click();
    }
}
