using ECSAutomationTests.Factories;
using ECSAutomationTests.Helpers;
using OpenQA.Selenium;
using System;

namespace ECSAutomationTests.Fixtures
{
    public class BrowserFixture
    {

       
        public IWebDriver BeforeScenario()
        {
            var driver = new BrowserFactory().GetBrowser();
            driver.Navigate().GoToUrl(ConfigurationHelper.BaseUrl);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ConfigurationHelper.ElementTimeout);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromMinutes(ConfigurationHelper.PageLoadTimeout);

            return driver;

        }


        public void AfterScenario(IWebDriver driver)
        {
            driver?.Quit();
            driver?.Dispose();
        }
    }
}
