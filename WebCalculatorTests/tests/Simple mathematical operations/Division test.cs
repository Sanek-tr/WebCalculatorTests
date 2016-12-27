using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebCalculatorTests.tests
{
    public class Division_test : TestBase
    {
        /// <summary>
        /// This test divides two numbers using calculator and checks the result against division of the same numbers using C# math operations
        /// </summary>
        [Test]
        public void DivideTwoNumbers()
        {
            app.Operators.Clear();
            double firstOperand = app.Operands.EnterSeveralDigits();
            app.Operators.ClickDivideButton();
            double secondOperand = app.Operands.EnterSeveralDigits();
            app.Operators.ClickEqualsButton();
            double calcQuotient = app.Operands.GetInput();
            double quotient = firstOperand / secondOperand;
            Assert.AreEqual(calcQuotient, quotient);
        }
    }
}