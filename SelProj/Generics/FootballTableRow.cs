using OpenQA.Selenium;
using System.Collections.Generic;

namespace SelProj.Generics
{
    public class FootballTableRow
    {
        private IWebDriver driver;
        public System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> rows;

        public FootballTableRow(IWebDriver driver)
        {
            this.driver = driver;
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> NagigateTheTableRows()
        {
            var getTableContainer = driver.FindElement(By.ClassName("gs-o-table-container"));
            var getTableData = getTableContainer.FindElement(By.ClassName("gel-long-primer "));
            rows = getTableData.FindElements(By.TagName("tr"));

            return rows;
        }

        public string getTeamNameFromTableRow(IWebElement fromRow)
        {
            var tagName = fromRow.FindElement(By.CssSelector("abbr"));
            string teamName = tagName.GetAttribute("title");

            return teamName;
        }
    }
}
