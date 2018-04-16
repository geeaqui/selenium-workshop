using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumDemo.Helpers
{
    internal static class Waits
    {
        private static readonly TimeSpan Timeout = TimeSpan.FromSeconds(20);

        internal static bool WaitForElementToBeClickable(IWebDriver driver, IWebElement element)
        {
            return WaitCondition(driver, ExpectedConditions.ElementToBeClickable(element));
        }

        internal static bool WaitForElementToExist(IWebDriver driver, By pageSelector)
        {
            return WaitCondition(driver, ExpectedConditions.ElementExists(pageSelector));
        }

        private static bool WaitCondition(IWebDriver driver, Func<IWebDriver, IWebElement> expectedConditions)
        {
            var wait = new WebDriverWait(driver, Timeout);
            var element = wait.Until(expectedConditions);
            if (element == null) throw new NoSuchElementException();
            return true;
        }
    }
}
