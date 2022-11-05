using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObject
{
    public class LoginPage : BasePage
    {
        private static WebDriverWait wait;
        public LoginPage(IWebDriver webDriver) : base(webDriver)
        {
            wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
        }


        private IWebElement UserName => driver.FindElement(By.Name("user-name"));
        private IWebElement Password => driver.FindElement(By.Name("password"));
        private IWebElement Login => driver.FindElement(By.Name("login-button"));

        public void LoginWithNameAndPassword(string name, string pwd)
        {
            UserName.SendKeys(name);
            Password.SendKeys(pwd);
        }


        public void ClickLogin()
        {
            Login.Click();
        }

        public IWebElement CheckThatAlertMessageContainsText(string text) =>
            wait.Until(ExpectedConditions.ElementExists(By.XPath($"//h3[contains(text(), '{text}')]")));

    }
}
