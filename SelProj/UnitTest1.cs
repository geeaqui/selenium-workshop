using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome; //to use google chrome browser.
using SelProj.Generics;
using SelProj.PageObjects;

namespace SelProj
{
    [TestClass]
    public class UnitTest1
    {
        private static IWebDriver driver;
        private string url = "https://www.bbc.co.uk/";
        private BasePage basePage;
        private SportPage sport;
        private int rankNumber = 20;
        private string teamName = "Crystal Palace";

        [TestInitialize]
        public void TestSetUp()
        {
            driver = new ChromeDriver(@"C:\Users\geeKy\desktop\SelProj\SeleniumServer");
            driver.Navigate().GoToUrl(url);
            basePage = new BasePage(driver);
            sport = basePage.NavigateSportPage();
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Quit();
        }

        [TestMethod]
        public void GetTheTeamOnSpecifiedRank()
        {
            sport.NavigateFootballPage();
            sport.football.GetTheTeamOnSelectedRank(rankNumber);
            sport.football.CheckTeamExistInTheRankList(sport.football.teamName);//Assertion
        }

        [TestMethod]
        public void GetTeamRankPosition()
        {
            sport.NavigateFootballPage();
            int rankNumber = sport.football.FindtheRankPosition(teamName);
            sport.football.GetTheTeamOnSelectedRank(rankNumber);
            sport.football.RankOfTheSelectedTeam(teamName, sport.football.teamName);//Assertion
        }
    }
}
