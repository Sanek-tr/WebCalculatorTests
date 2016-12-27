using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebCalculatorTests.tests
{
    public class InputMatchesPressedButtonsTest : TestBase
    {
        /// <summary>
        /// This test checks if the sequence of clicked digit buttons matches the input field 
        /// </summary>
        [Test]
        public void InputMatchesPressedButtons()
        {
            app.Operators.Clear();
            double operandFromEnteredKeys;
            double operandFromInput = app.Operands.EnterSeveralDigits(out operandFromEnteredKeys);
            Assert.AreEqual(operandFromEnteredKeys, operandFromInput);
        }
    }
}
