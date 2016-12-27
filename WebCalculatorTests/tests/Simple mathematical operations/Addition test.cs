using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebCalculatorTests.tests
{
    public class Addition_test : TestBase
    {
        /// <summary>
        /// This test adds two numbers using calculator and checks them against addition of the same numbers using Math operation of the same
        /// </summary>
        [Test]
        public void AddTwoNumbers()
        {
            app.Operators.Clear();
            double firstOperand = app.Operands.EnterSeveralDigits();
            app.Operators.ClickPlusButton();
            double secondOperand = app.Operands.EnterSeveralDigits();
            app.Operators.ClickEqualsButton();
            double calcSum = app.Operands.GetInput();
            double sum = firstOperand + secondOperand;
            Assert.AreEqual(sum, calcSum);
        }
    }
}