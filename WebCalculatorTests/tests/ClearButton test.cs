using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebCalculatorTests.tests
{
    public class ClearButton_test : TestBase
    {
        /// <summary>
        /// This test checks if pressing C button clears the input.
        /// </summary>
        [Test]
        public void ClearInputTest()
        {
            app.Operators.Clear();
            app.Operands.EnterSeveralDigits();
            app.Operators.Clear();
            double resultAfterClearance = app.Operands.GetInput();
            Assert.AreEqual(resultAfterClearance, 0);
        }
    }
}