using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace seleniumlrn
{
    [TestFixture]
    public class Tests
    {

        IWebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [TestCase(4)]
        [TestCase(5)]
        [TestCase(45)]
        [TestCase(14)]
        [TestCase(6784)]
        public void TestAgeRange(int age)
        {
            driver.Url = "file:///home/harman/Desktop/seleniumlrn/web/page.html";
            IWebElement txtAge = driver.FindElement(By.Id("txtAge"));
            IWebElement validations = driver.FindElement(By.Id("validations"));

            txtAge.SendKeys(age.ToString());
            txtAge.SendKeys("\t");

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
            driver.Close();
        }
    }
}