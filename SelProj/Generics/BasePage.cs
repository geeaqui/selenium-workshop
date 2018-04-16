using OpenQA.Selenium;
using SelProj.PageObjects;

namespace SelProj.Generics
{
    public class BasePage
    {
        private IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public SportPage NavigateSportPage()
        {
            var nav = driver.FindElement(By.CssSelector("div[id='orb-nav-links']"));
            nav.FindElement(By.PartialLinkText("Sport")).Click();
            return new SportPage(driver);
        }
    }
}
