using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace SeleniumDemo.Tests
{
    public class TestBase
    {
        public IWebDriver Driver { get; set; }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            var gridStartupTimeout = TimeSpan.FromSeconds(150);
            //DesiredCapabilities caps = GetiPhone6SPlusSettings;
            //Driver = new RemoteWebDriver(GridWebDriverUrl, caps, gridStartupTimeout);


            Driver = new ChromeDriver();
        }

        [SetUp]
        public void SetUp()
        {
            Driver.Navigate().GoToUrl("http://google.co.uk");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Driver?.Quit();
        }

        public static Uri GridWebDriverUrl { get; set; } = new Uri(Environment.GetEnvironmentVariable("WebDriverUrl") ?? "http://localhost:4444/wd/hub");
        
        public static DesiredCapabilities GetChromeSettings
        {
            get
            {
                var options = new ChromeOptions();
                options.AddArguments("--test-type");
                options.AddArguments("--disable-extensions");
                DesiredCapabilities dc = options.ToCapabilities() as DesiredCapabilities;
                return dc;
            }
        }

        public static DesiredCapabilities GetEdgeSettings
        {
            get
            {
                var caps = GetBrowserStackSettings;
                caps.SetCapability("browser", "Edge");
                caps.SetCapability("os", "Windows");
                caps.SetCapability("os_version", "10");
                return caps;
            }
        }

        public static DesiredCapabilities GetiPhone6SPlusSettings
        {
            get
            {
                var caps = GetBrowserStackSettings;
                caps.SetCapability("browserName", "iPhone");
                caps.SetCapability("platform", "MAC");
                caps.SetCapability("device", "iPhone 6S Plus");
                return caps;
            }
        }

        private static DesiredCapabilities GetBrowserStackSettings
        {
            get
            {
                GridWebDriverUrl = new Uri("http://hub-cloud.browserstack.com/wd/hub/");
                var caps = new DesiredCapabilities();
                caps.SetCapability("browserstack.user", "digitalautomatio1");
                caps.SetCapability("browserstack.key", "E342Tx6WJUAqyNfm3B62");
                caps.SetCapability("browserstack.local", true);
                caps.SetCapability("acceptSslCerts", "true");
                //caps.SetCapability("browserstack.debug", "true");
                return caps;
            }
        }


    }
}
