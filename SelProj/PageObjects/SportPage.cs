using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SelProj.PageObjects
{
    public class SportPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        public string teamName;
        public FootballPage football;

        public SportPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void NavigateFootballPage()
        {
            var footBallPage = driver.FindElement(By.CssSelector("div[id='sport']"));
            var nav = footBallPage.FindElement(By.ClassName("nav-top"));
            nav.FindElement(By.PartialLinkText("Football")).Click();
            football = new FootballPage(driver);
        }
    }
}
