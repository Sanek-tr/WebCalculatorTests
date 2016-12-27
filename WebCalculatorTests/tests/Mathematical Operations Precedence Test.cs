using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebCalculatorTests.tests
{
    public class Mathematical_Operations_Precedence_Test : TestBase
    {
        /// <summary>
        /// This test combines the different mathematical operations. The main sense of it is checking if precedence of mathematical operations corresponds mathematical norms.
        /// </summary>
        [Test]
        public void MathematicalOperationsPrecedence()
        {
            app.Operators.Clear();
            double firstOperand = app.Operands.EnterSeveralDigits();
            app.Operators.ClickPlusButton();
            double secondOperand = app.Operands.EnterSeveralDigits();
            app.Operators.ClickMultiplyButton();
            double thirdOperand = app.Operands.EnterSeveralDigits();
            app.Operators.ClickMinusButton();
            double fourthOperand = app.Operands.EnterSeveralDigits();
            app.Operators.ClickDivideButton();
            double fifthOperand = app.Operands.EnterSeveralDigits();
            app.Operators.ClickEqualsButton();
            double calcResult = app.Operands.GetInput();
            double cSharpResult = firstOperand + secondOperand * thirdOperand - fourthOperand / fifthOperand;
            Assert.AreEqual(calcResult, cSharpResult);
        }
    }
}
