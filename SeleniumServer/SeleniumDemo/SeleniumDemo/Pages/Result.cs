using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumDemo.Helpers;

namespace SeleniumDemo.Pages
{
    internal class Result : BasePage
    {
        private IWebDriver Driver { get; }
        private static readonly By PageSelector = By.Id("hdtb-msb-vis");

        internal Result(IWebDriver driver) : base(driver, PageSelector)
        {
            Driver = driver;
        }

        [FindsBy(How = How.CssSelector, Using = "div[class='ads-visurl'] cite")]
        private IWebElement AdvertLinkAddress;

        internal string GetAdvertLinkText()
        {
            return AdvertLinkAddress.GetText(Driver);
        }

    }
}
