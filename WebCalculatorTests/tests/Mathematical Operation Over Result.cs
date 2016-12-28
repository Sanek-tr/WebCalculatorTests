using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebCalculatorTests.tests
{
    public class Mathematical_Operation_Over_Result : TestBase
    {
        /// <summary>
        /// This test checks if any mathematical operation can be performed over the result of first mathematical operation 
        /// </summary>
        [Test]
        public void MathOperationOverResult()
        {
            app.Operators.Clear();
            //The operations using calculator

            //First operation
            double firstOperand = app.Operands.EnterSeveralDigits();
            string firstRandomOperator = app.Operators.ClickRandomOperator();
            double secondOperand = app.Operands.EnterSeveralDigits();
            app.Operators.ClickEqualsButton();

            //The operation over result;
            string secondRandomOperator = app.Operators.ClickRandomOperator();
            double thirdOperand = app.Operands.EnterSeveralDigits();
            app.Operators.ClickEqualsButton();
            double calcResult = app.Operands.GetInput();

            //The same operations using c#
            double result = app.Operators.PerformMathOperation(firstOperand, firstRandomOperator, secondOperand);
            double finalResult = app.Operators.PerformMathOperation(result, secondRandomOperator, thirdOperand);

            Assert.AreEqual(calcResult, finalResult);
        }
    }
}
