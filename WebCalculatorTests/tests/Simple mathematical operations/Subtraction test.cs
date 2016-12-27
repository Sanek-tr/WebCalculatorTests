using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebCalculatorTests.tests
{
    public class Subtraction_test : TestBase
    {
        /// <summary>
        /// This test subtracts two numbers using calculator and checks the result against subtraction of the same numbers using C# math operations
        /// </summary>
        [Test]
        public void SubtractTwoNumbers()
        {
            app.Operators.Clear();
            double firstOperand = app.Operands.EnterSeveralDigits();
            app.Operators.ClickMinusButton();
            double secondOperand = app.Operands.EnterSeveralDigits();
            app.Operators.ClickEqualsButton();
            double calcSub = app.Operands.GetInput();
            double sub = firstOperand - secondOperand;
            Assert.AreEqual(sub, calcSub);
        }
    }
}