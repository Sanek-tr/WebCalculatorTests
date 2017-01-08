using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebCalculatorTests.tests
{
    public class Division_by_zero : TestBase
    {
        /// <summary>
        /// Check if division by zero returns "Infinity"
        /// </summary>
        [Test]
        public void DivideByZero()
        {
            app.Operands.EnterSeveralDigits();
            app.Operators.ClickDivideButton();
            app.Operands.ClickZeroButton();
            app.Operators.ClickEqualsButton();
            string inputContent = app.Operands.GetInputContentAsString();
            Assert.AreEqual(inputContent, "Infinity");
        }
    }
}
