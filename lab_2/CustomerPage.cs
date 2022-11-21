using System;
using System.Collections.Generic;
using System.Linq;
using lab_2;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PageObject
{
    public class CustomerPage : BasePage
    {
        public static WebDriverWait wait;
        public CustomerPage(IWebDriver webDriver) : base(webDriver)
        {
            wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
        }
        public IWebElement hrefPostCode => wait.Until(e => e.FindElement(By.XPath("//tr/td[3]/a[@href='#']")));

        public List<IWebElement> PostCode => wait.Until(e => e.FindElements(By.XPath("//tr/td[3][@class = 'ng-binding']"))).ToList<IWebElement>();
        //public List<IWebElement> PostCode => driver.FindElements(By.XPath("//tr/td[3][@class='ng-binding]")).ToList<IWebElement>();
        public void ClickSortPostCode() => hrefPostCode.Click();
        public List<string> GetPostCode() => PostCode.Select(el => el.Text).ToList<string>();
    }
}

