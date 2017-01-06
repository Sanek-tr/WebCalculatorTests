using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

//Test comment (checking TeamCity binding)
namespace WebCalculatorTests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        public string baseURL;

        private static ApplicationManager app = new ApplicationManager();
        protected OperandsHelper operands;
        protected OperatorsHelper operators;

        private ApplicationManager()

        {
            driver = new ChromeDriver(@"D:\\Soft\");
            baseURL = "http://test.job.klika-tech.com.s3-website.eu-central-1.amazonaws.com/";
            driver.Navigate().GoToUrl(baseURL);
            operands = new OperandsHelper(this);
            operators = new OperatorsHelper(this);
        }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public static ApplicationManager GetInstance()
        {
            return app;
        }

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }

        public OperandsHelper Operands
        {
            get
            {
                return operands;
            }
        }

        public OperatorsHelper Operators
        {
            get
            {
                return operators;
            }
        }
    }
}
