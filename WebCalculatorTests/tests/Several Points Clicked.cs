using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebCalculatorTests.tests
{
    class Several_Points_Clicked : TestBase
    {
        /// <summary>
        /// This test checks if it is possible for two successive points to be displayed in the input field (apparently it shouldn't be)
        /// </summary>
        [Test]
        public void SeveralPointsInANumber()
        {
            app.Operators.Clear();
            app.Operands.EnterSeveralDigits();
            app.Operands.PressPointButton();
            app.Operands.PressPointButton();
            app.Operands.EnterSeveralDigits();

            //When more then one point is displayed in input next to each other
            //apparently the input string cannot be converted to double.
            //As a result GetInput() fallback 0.0 get returned in this case.
            //Apparently in the current case this test will always fail till the possibility of 
            //using two points in one number is banned in the code

            double inputValue = app.Operands.GetInput();
            Assert.AreNotEqual(inputValue, 0.0, "Most possibly two points in a number in the input field");
        }
    }
}
