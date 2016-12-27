using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebCalculatorTests
{
    public class OperatorsHelper : HelperBase
    {
        public OperatorsHelper(ApplicationManager manager) : base(manager)
        {

        }

        public void Clear()
        {
            driver.FindElement(By.Id("clear")).Click();
        }

        public IList<IWebElement> GetOperatorsCollection()
        {
            return driver.FindElements(By.XPath("//div[@class='operators']/div"));
        }

        public void ClickPlusButton()
        {
            GetOperatorsCollection()[0].Click();
        }

        public void ClickMinusButton()
        {
            GetOperatorsCollection()[1].Click();
        }

        public void ClickMultiplyButton()
        {
            GetOperatorsCollection()[2].Click();
        }

        public void ClickDivideButton()
        {
            GetOperatorsCollection()[3].Click();
        }

        public void ClickEqualsButton()
        {
            driver.FindElement(By.Id("result")).Click();
        }
    }
}
