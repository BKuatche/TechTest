using ECSAutomationTests.Fixtures;
using ECSAutomationTests.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace ECSAutomationTests.Scenarios
{
    public class ChallengeTechniclaTests
    {

        private IWebDriver _driver;
        private SubmitDataFixture _submitDataFixture;
        private List<int> GetList;
        private BrowserFixture _browserFixture;

        public ChallengeTechniclaTests()
        {
            _browserFixture = new BrowserFixture();
        }

        [SetUp]
        public void BrowserIntialisation()
        {
            _driver = _browserFixture.BeforeScenario();
            _submitDataFixture = new SubmitDataFixture(_driver);
        }


        [Test]
        public void ReturnIndexAndSubmitAnswer()
        {

            // Retrieve data from the table
            GetList = _submitDataFixture.ReturnIndexWhereSumLeftEqualSumRight();

            // Submit your Answer and name

            _submitDataFixture.SubmitYourAnswer(GetList, ConfigurationHelper.Name);
        }



        [TearDown]
        public void CloseBrowser()
        {
            _browserFixture.AfterScenario(_driver);
        }
    }
}
