using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumDemo.Helpers;

namespace SeleniumDemo.Pages
{
    internal class Home : BasePage
    {
        private IWebDriver Driver { get; }
        private static readonly By PageSelector = By.Id("hplogo");
        
        internal Home(IWebDriver driver) : base(driver, PageSelector)
        {
            Driver = driver;
        }

        [FindsBy(How = How.Id, Using = "lst-ib")]
        private IWebElement SearchBox;

        internal void EnterSearchText(string searchValue)
        {
            SearchBox.EnterText(Driver, searchValue);
        }
    }
}
