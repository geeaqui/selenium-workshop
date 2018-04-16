using System;
using OpenQA.Selenium;

namespace SeleniumDemo.Helpers
{
    public static class Extensions
    {
        public static void EnterText(this IWebElement element, IWebDriver driver, string text)
        {
            Waits.WaitForElementToBeClickable(driver, element);
            element.SendKeys(text + Keys.Enter);
        }

        public static string GetText(this IWebElement element, IWebDriver driver)
        {
            return Waits.WaitForElementToBeClickable(driver, element) ? element.Text : string.Empty;
        }
        
    }
}
