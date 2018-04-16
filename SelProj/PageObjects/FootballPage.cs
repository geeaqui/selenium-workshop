using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SelProj.Generics;
using System.Diagnostics;

namespace SelProj.PageObjects
{
    public class FootballPage
    {
        private IWebDriver driver;
        private FootballTableRow tableRow;
        public string teamName;
        
        public FootballPage(IWebDriver driver)
        {
            this.driver = driver;
            tableRow = new FootballTableRow(this.driver);
        }

        public void NavigatePremiereTable()
        {
            var tablePage = driver.FindElement(By.ClassName("secondary-nav__items-wrap"));
            tablePage.FindElement(By.PartialLinkText("Tables")).Click();
        }

        public string GetTeamFromTable(int posNumber)
        {
            tableRow.NagigateTheTableRows();
            var foundAtRowPosition = tableRow.rows.FirstOrDefault(x => x.Text.StartsWith(posNumber.ToString()));
            string foundTeamName = tableRow.getTeamNameFromTableRow(foundAtRowPosition);
            
            return foundTeamName;
        }

        public int FindtheRankPosition(string teamName)
        {
            int rankNumber = 0;
            tableRow.NagigateTheTableRows();

            foreach (var row in tableRow.rows)
            {
                try
                {
                    string foundTeamName = tableRow.getTeamNameFromTableRow(row);

                    if (foundTeamName.ToLower() == teamName.ToLower())
                    {
                        string getRankNumber = row.Text.Substring(0, 2);
                        rankNumber = int.Parse(getRankNumber);
                        break;
                    }
                }
                catch 
                {
                    Debug.WriteLine("row does not contain 'abbr tag', continue looking to the next row");
                }  
            }

            return rankNumber;
        }

        public void CheckTeamExistInTheRankList(string team)
        {
            List<string> teams = new List<string>() { "Manchester City", "Manchester United", "Liverpool", "Tottenham Hotspur", "Chelsea", "Arsenal",
                "Burnley", "Leicester City", "Everton", "Newcastle United", "AFC Bournemouth", "Watford", "Brighton & Hove Albion", "West Ham United", "Swansea City", "Huddersfield Town",
                "Crystal Palace", "Southampton", "Stoke City", "West Bromwich Albion", };

            Assert.IsTrue(teams.Contains(team));
        }

        public void RankOfTheSelectedTeam(string expectedTeamOntheRank, string actualTeamOnTheRank)
        {
            Assert.AreEqual(expectedTeamOntheRank, actualTeamOnTheRank);
        }

        public void GetTheTeamOnSelectedRank(int rankNumber)
        {
            NavigatePremiereTable();
            teamName = GetTeamFromTable(rankNumber);
        }
    }
}
