using ECSAutomationTests.Helpers;
using ECSAutomationTests.Pages.Home;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace ECSAutomationTests.Fixtures
{
    public class SubmitDataFixture
    {
        private readonly ECSHomePage _home;

        public SubmitDataFixture(IWebDriver driver)
        {
            _home = new ECSHomePage(driver);
        }


        public List<int> ReturnIndexWhereSumLeftEqualSumRight()
        {

            var list = new List<int>();

            try
            {
                _home.CLickOnRenderTheChallenge();

                var ListOfTableData = _home.TableGrid().GetDetails();

                foreach (var listData in ListOfTableData)
                {

                    var data = DataTableHelper.FindIndex(listData, listData.Length);

                    list.Add(data);
                }

            }
            catch (Exception)
            {

                throw;
            }

            return list;
        }


        public void SubmitYourAnswer(List<int> answers,string name)
        {
            try
            {
                var answer = _home.Submit();

                for (int i = 1; i <= answers.Count; i++)
                {
                    answer.SubmitChallenge(i,answers[i -1].ToString());
                }

                answer.SubmitName(name).SubmitAnswer();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
