using lab_2;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PageObject
{
    public class CustomersPage : BasePage
    {
        public static WebDriverWait wait;

        private CustomersPage(IWebDriver webDriver) : base(webDriver)
        {
            wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
        }

        private IWebElement hrefPostCode => wait.Until(e => e.FindElement(By.XPath("//tr/td[3]/a[@href='#']")));
        private List<IWebElement> PostCode => driver.FindElements(By.XPath("//tr/td[3][@class='ng-binding]")).ToList<IWebElement>();

        public void ClickSortPostCode() => hrefPostCode.Click();
        public List<string> GetPostCode() => PostCode.Select(el => el.Text).ToList<string>();
    }
}
