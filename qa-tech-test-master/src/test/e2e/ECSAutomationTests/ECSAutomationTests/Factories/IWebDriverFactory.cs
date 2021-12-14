using OpenQA.Selenium;

namespace ECSAutomationTests.Factories
{
    public interface IWebDriverFactory
    {
        IWebDriver GetChrome();
        IWebDriver GetFirefox();
    }
}
