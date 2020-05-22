using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace seleniumlrn
{
    [TestFixture]
    public class Tests
    {
        //instantiation of webdriver
        IWebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {   
            //to use chrome for testing
            driver = new ChromeDriver();
        }
        
        
        //this will generate multiple testcases (code reuse)
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(45)]
        [TestCase(14)]
        [TestCase(6784)]
        public void TestAgeRange(int age)
        {
            //give the path of your html page
            driver.Url = "file:///home/harman/Desktop/seleniumlrn/web/page.html";
            IWebElement txtAge = driver.FindElement(By.Id("txtAge"));
            IWebElement validations = driver.FindElement(By.Id("validations"));
            
            //convert age to a string as Sendkeys() accepts a string val.
            txtAge.SendKeys(age.ToString());
            txtAge.SendKeys("\t");
            
            //main test
            string validationText = validations.GetAttribute("innerHTML");
            if (validationText == "")
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        [OneTimeTearDown]
        public void close()
        {
            //close the chrome tab
            driver.Close();
        }
    }
}
