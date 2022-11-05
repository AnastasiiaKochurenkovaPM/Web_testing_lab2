using OpenQA.Selenium;
using System;

namespace PageObject
{
	public class BasePage
	{
		protected static IWebDriver driver;

		public BasePage(IWebDriver webDriver)
		{
			driver = webDriver;

		}

        public IWebElement Element(By by)
        {
            return driver.FindElement(by);
        }
        public void Click(By by)
        {
            Element(by).Click();
        }

        public void SendKeys(By by, string text)
        {
            Element(by).SendKeys(text);
        }

        public string GetText(By by)
        {
            return Element(by).Text;
        }
    }
}
