using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebCalculatorTests.tests
{
    public class Multiplication_test : TestBase
    {
        /// <summary>
        /// This test multiplies two numbers using calculator and checks the result against multiplication of the same numbers using C# math operations
        /// </summary>
        [Test]
        public void MultiplyTwoNumbers()
        {
            app.Operators.Clear();            
            double firstOperand = app.Operands.EnterSeveralDigits();
            app.Operators.ClickMultiplyButton();
            double secondOperand = app.Operands.EnterSeveralDigits();
            app.Operators.ClickEqualsButton();
            double calcProduct = app.Operands.GetInput();
            double product = firstOperand * secondOperand;
            Assert.AreEqual(product, calcProduct);
        }
    }
}
