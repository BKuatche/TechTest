using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ECSAutomationTests.Pages
{
    public class TableGridComponent
    {

        private readonly IWebDriver _driver;
        private readonly IWebElement _container;
        public TableGridComponent(IWebDriver driver)
        {
            _driver = driver;
            _container = _driver.FindElement(_dateWidgetLocator);
        }

        #region Locators
        private readonly By _rowLocator = By.TagName("tr");
        private readonly By _dataColumnLocator = By.TagName("td");
        private readonly By _dateWidgetLocator = By.CssSelector("table tbody");
        #endregion


        private IEnumerable<IWebElement> DataRows => _container.FindElements(_rowLocator);



        public List<int[]> GetDetails()
        {
            List<int[]> arrList = new();

            List<int> result = new();

            foreach (var (row, columns) in from row in DataRows
                                           let columns = row.FindElements(_dataColumnLocator)
                                           select (row, columns))
            {
                var data = row.FindElements(_dataColumnLocator);

                data.ToList().ForEach(column =>
                {
                    var index = Convert.ToInt32(column.Text);
                    result.Add(index);
                });

                arrList.Add(result.ToArray());

                result.Clear();
            }

            return arrList;
        }

    }
}
