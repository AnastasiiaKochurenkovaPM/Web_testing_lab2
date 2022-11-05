using NUnit.Framework;
using PageObject;
using OpenQA.Selenium;
using SpecFlowPageObjectWebDriver.Steps;
using System;
using TechTalk.SpecFlow;

namespace Tests.Steps
{
    [Binding]
    public class LoginSteps : BaseSteps
    {
        private LoginPage loginPage;

        [Given(@"open login page")]
        public void GivenOpenLoginPage()
        {
            driver.Url = "https://www.saucedemo.com/";

            loginPage = new LoginPage(driver);
        }


        [Given(@"type (.*) and (.*)")]
        public void GivenTypeAnd(string userName, string password)
        {
            loginPage.LoginWithNameAndPassword(userName, password);
        }


        [When(@"click login")]
        public void WhenClickLogin()
        {
            loginPage.ClickLogin();
        }


        [Then(@"the result should contain (.*)")]
        public void ThenTheResultShouldContain(string text)
        {
            IWebElement element = loginPage.CheckThatAlertMessageContainsText(text);
            Assert.That(element.Text.Contains(text));
        }


    }
}