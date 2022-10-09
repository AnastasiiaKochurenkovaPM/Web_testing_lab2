using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Web_testing_lab_2
{
    public class DemoTestsClass
    {
        private IWebDriver driver;
        private const string LOGIN = "locked_out_user";
        private const string PASSWORD = "secret_sauce";

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Close();
        }

        [Test]
        public void LoginLockedOutUserTest()
        {
            driver.FindElement(By.Id("user-name")).SendKeys(LOGIN);
            driver.FindElement(By.Id("password")).SendKeys(PASSWORD);
            driver.FindElement(By.Id("login-button")).Click();

            Assert.That(driver.FindElement(By.CssSelector("*[data-test='error']")).Text, Is.EqualTo("Epic sadface: Sorry, this user has been locked out."));
        }

        [Test]
        public void CheckErrorWhenInvalidUserName()
        {
            driver.FindElement(By.Id("user-name")).SendKeys("name");
            driver.FindElement(By.Id("password")).SendKeys("secret");
            driver.FindElement(By.Id("login-button")).Click();

            Assert.That(driver.FindElement(By.CssSelector("*[data-test='error']")).Text, Is.EqualTo("Epic sadface: Username and password do not match any user in this service"));
        }
    }
}