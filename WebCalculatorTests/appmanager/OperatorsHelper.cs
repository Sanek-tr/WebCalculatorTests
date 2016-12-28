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

        /// <summary>
        /// Clicks random operator and returns clicked operator as a string
        /// </summary>
        /// <returns></returns>
        public string ClickRandomOperator()
        {
            Random rnd = new Random();
            int randomOperatorIndex = rnd.Next(GetOperatorsCollection().Count);
            GetOperatorsCollection()[randomOperatorIndex].Click();
            return GetOperatorsCollection()[randomOperatorIndex].Text;
        }
        
        /// <summary>
        /// Performs mathematical operations using the operator returned as a string from the calculator
        /// </summary>
        /// <param name="firstOperand"></param>
        /// <param name="randomOperator"></param>
        /// <param name="secondOperand"></param>
        /// <returns>The result of the operation</returns>
        public double PerformMathOperation(double firstOperand, string randomOperator, double secondOperand)
        {
            switch (randomOperator)
            {
                case "+": return firstOperand + secondOperand;
                case "-": return firstOperand - secondOperand;
                case "×": return firstOperand * secondOperand;
                case "÷": return firstOperand / secondOperand;
                default: throw new Exception("The operator isn't found");
            }
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
