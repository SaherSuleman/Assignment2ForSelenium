using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Assignment2_Selenium
{
    public class Driver
    {
        public static IWebDriver GetDriver()
        {

            var driver = new ChromeDriver();

            return driver;

        }
    }
}