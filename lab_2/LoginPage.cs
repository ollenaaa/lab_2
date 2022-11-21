using lab_2;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;


namespace PageObject
{
    public class LoginPage:BasePage
    {
        public static WebDriverWait wait;

        public LoginPage(IWebDriver webDriver):base(webDriver)
        {
            wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
        }
        private IWebElement btnBankManagerLogin => wait.Until(e => e.FindElement(By.XPath("//button[@ng-click = 'manager()']")));
        public void ClickLogin() => btnBankManagerLogin.Click();
    }
}