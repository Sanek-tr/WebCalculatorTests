using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebCalculatorTests
{
    public class OperandsHelper : HelperBase
    {
        public OperandsHelper(ApplicationManager manager) : base(manager)
        {

        }

        

        /// <summary>
        /// //Selects all the digit buttons (point is not included)
        /// </summary>
        /// <returns></returns>
        public IList<IWebElement> GetCollectionOfDigitButtonsPointExcl()
        {
            return driver.FindElements(By.XPath("(//div[@class='numbers']/div)[position()<last()-1]"));
        }

        

        /// <summary>
        /// //Selects all the digit buttons (point is included)
        /// </summary>
        /// <returns></returns>
        public IList<IWebElement> GetCollectionOfDigitButtonsPointIncl()
        {
            return driver.FindElements(By.XPath("(//div[@class='numbers']/div)[position()<last()]"));
        }

        /// <summary>
        /// Randomly presses several digits
        /// </summary>
        /// <param name="operandFromEnteredKeys">returns the value of the number which results in merging the values of pressed digits</param>
        /// <returns>returns the value of the number which is displayed in the input</returns>
        public double EnterSeveralDigits(out double operandFromEnteredKeys)
        {
            IList<IWebElement> collectionOfNumberButtons = GetCollectionOfDigitButtonsPointExcl();
            double operandFromInput;

            //Getting initial input
            string initialInputContent = GetInputContentAsString();
            string enteredNumberAsString = ""; 
            int pointCounter = 0;
            Random rand = new Random();

            //Generates a number from the digit values excluding unnecessary points (is needed when point is included in number generation)
            for (int i = 0; i < 8; i++)
            {
                int index = (rand.Next(collectionOfNumberButtons.Count));
                collectionOfNumberButtons[index].Click();
                string digit = collectionOfNumberButtons[index].Text;
                if (digit == ".")
                if (digit == "." && pointCounter > 0)
                {
                    continue;
                }
                else
                {
                    pointCounter++;
                }
                enteredNumberAsString += digit;
            }

            //Getting final input
            string finalInputContent = GetInputContentAsString();
            try
            {
                //Parses the string in the input field returning the number put in last
                operandFromInput = double.Parse(finalInputContent.Substring(initialInputContent.Length), CultureInfo.InvariantCulture);
            }
            catch (FormatException e) 
            {
                //CustomException myException = new CustomException("Unable to access the configured data source");
                throw new FormatException(e.Message + " Comment by A.Kuzich: The most possible problem is the presence of two points in a number in the input field");
            } 
            operandFromEnteredKeys = double.Parse(enteredNumberAsString, CultureInfo.InvariantCulture);
            return operandFromInput;
        }

        /// <summary>
        /// Randomly presses several digits
        /// </summary>
        /// <returns>returns the number which is generated after pressing</returns>
        public double EnterSeveralDigits()
        {
            IList<IWebElement> collectionOfNumberButtons = GetCollectionOfDigitButtonsPointExcl();
            double operandFromInput;

            //Getting initial input
            string initialInputContent = GetInputContentAsString();
            Random rand = new Random();
            for (int i = 0; i < 8; i++)
            {
                int index = (rand.Next(collectionOfNumberButtons.Count));
                collectionOfNumberButtons[index].Click();
            }
            //Getting final input
            string finalInputContent = GetInputContentAsString();
            try
            {
                //Parses the string in the input field returning the number put in last
                operandFromInput = double.Parse(finalInputContent.Substring(initialInputContent.Length), CultureInfo.InvariantCulture);
            }
            catch (FormatException e)
            {
                //CustomException myException = new CustomException("Unable to access the configured data source");
                throw new FormatException(e.Message + " Comment by A.Kuzich: The most possible problem is the presence of two points in a number in the input field");
            }
            return operandFromInput;
        }

        /// <summary>
        /// Gets the content of the input field in string format
        /// </summary>
        /// <returns></returns>
        public string GetInputContentAsString()
        {
            return driver.FindElement(By.Id("input")).Text;
        }

        /// <summary>
        /// Gets the content of the input field and converts it to double
        /// </summary>
        /// <returns></returns>
        public double GetInput()
        {
            string result = GetInputContentAsString();
            double number;
            if (double.TryParse(result, NumberStyles.Number, CultureInfo.InvariantCulture, out number))
            {
                return number;
            }
            else
            {
                return 0.0;
            }
        }

        public void PressPointButton()
        {
            driver.FindElement(By.XPath("(//div[@class='numbers'][position() > last() - 2])[last()]")).Click();
        }

        public void ClickZeroButton()
        {
            GetCollectionOfDigitButtonsPointExcl()[9].Click();
        }
    }
}
