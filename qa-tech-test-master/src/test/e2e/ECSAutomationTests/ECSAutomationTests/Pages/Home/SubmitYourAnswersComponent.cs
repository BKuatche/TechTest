using OpenQA.Selenium;

namespace ECSAutomationTests.Pages.Home
{
    public class SubmitYourAnswersComponent
    {

        private readonly IWebDriver _driver;
        private readonly IWebElement _container;
        public SubmitYourAnswersComponent(IWebDriver driver)
        {
            _driver = driver;
            _container = _driver.FindElement(_dataWidgetLocator);
        }

        #region Locators
        private static By SubmitLocator(int index) => By.CssSelector("input[data-test-id='submit-"+index+"']");
        private readonly By _dataWidgetLocator = By.CssSelector("div > div:nth-of-type(2) > div > div:nth-of-type(1)");
        private readonly By _submitAnswerLocator = By.XPath("//span[contains(text(),'Submit Answers')]");
        #endregion


        private IWebElement SubmitField(int index) => _container.FindElement(SubmitLocator(index));
        private IWebElement SubmitAnswerBtn => _driver.FindElement(_submitAnswerLocator);


        public SubmitYourAnswersComponent SubmitChallenge(int answerNumber, string response)
        {
            SubmitField(answerNumber).Clear();
            SubmitField(answerNumber).SendKeys(response);

            return this;
        }


        public SubmitYourAnswersComponent SubmitName(string name)
        {
            SubmitField(4).Clear();
            SubmitField(4).SendKeys(name);

            return this;
        }

        public void SubmitAnswer() => SubmitAnswerBtn.Click();


    }
}
