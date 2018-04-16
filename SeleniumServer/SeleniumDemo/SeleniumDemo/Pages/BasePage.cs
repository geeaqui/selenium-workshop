using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumDemo.Helpers;

namespace SeleniumDemo.Pages
{
    internal class BasePage
    {
        protected BasePage(IWebDriver driver, By pageSelector)
        {
            Waits.WaitForElementToExist(driver, pageSelector);
            PageFactory.InitElements(driver, this);
        }

        //protected BasePage(IWebDriver driver, IWebElement webElement)
        //{
        //    PageFactory.InitElements(webElement, this);
        //}

    }
}
