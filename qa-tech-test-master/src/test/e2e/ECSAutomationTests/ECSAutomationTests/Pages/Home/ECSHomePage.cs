using OpenQA.Selenium;

namespace ECSAutomationTests.Pages.Home
{
    public class ECSHomePage
    {
        private readonly IWebDriver _driver;

        public ECSHomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        #region Locator
        private readonly By _renderTheChallengeLocator = By.CssSelector("section#home>div>div>button>div>div");
        #endregion


        private IWebElement RenderTheChallengeBtn => _driver.FindElement(_renderTheChallengeLocator);



        public void CLickOnRenderTheChallenge() => RenderTheChallengeBtn.Click();

        public SubmitYourAnswersComponent Submit() => new(_driver);

        public TableGridComponent TableGrid() => new(_driver);
    }



}
