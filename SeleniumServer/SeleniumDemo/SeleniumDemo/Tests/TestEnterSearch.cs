using NUnit.Framework;
using SeleniumDemo.Pages;

namespace SeleniumDemo.Tests
{
    [TestFixture]
    public class TestEnterSearch : TestBase
    {
        [Test]
        public void Test1()
        {
            var homePage = new Home(Driver);
            homePage.EnterSearchText("apple");
            var resultPage = new Result(Driver);
            Assert.That(resultPage.GetAdvertLinkText(), Is.EqualTo("www.apple.com/uk"));
        }

    }
}
