using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace Assignment2_Selenium
{

    public class EmployeeTests
    {
        IWebDriver driver;
        AllFunctions funcs;


        public void Setup()
        {
            driver = Driver.GetDriver();
            funcs = new AllFunctions(driver);
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
            driver.Manage().Window.Maximize();
            funcs.SendKeys("Admin", "//input[@name='username']");
            funcs.SendKeys("admin123", "//input[@name='password']");
            funcs.Click("//button[@type='submit']");
        }
     public void CreateEmployeeTest()
        {
            funcs.Click("//span[text()='PIM']");
            funcs.Click("//a[text()='Add Employee']");
            funcs.SendKeys("Saher", "//input[@name='firstName']");
            funcs.SendKeys("Irfan", "//input[@name='lastName']");
            funcs.Click("//button[@type='submit']");

           // Assert.That(driver.Url.Contains("pim/viewPersonalDetails"), "Sucessfully Updated.");
        }

    
        public void EditEmployeeTest()
        {
            funcs.Click("//span[text()='PIM']");
            funcs.SendKeys("Saher", "//input[@placeholder='Type for hints...']");
            funcs.Click("//button[@type='submit']");
            funcs.Click("(//div[@class='oxd-table-cell-actions']//button)[1]");

            funcs.Click("(//input[@class='oxd-input oxd-input--active'])[1]");
            funcs.SendKeys("", "(//input[@class='oxd-input oxd-input--active'])[1]");

            funcs.Click("//button[@type='submit']");

           // Assert.That(driver.PageSource.Contains("Successfully Updated"), "Employee edit failed.");
        }

        public void LogoutTest()
        {
            funcs.Click("//span[@class='oxd-userdropdown-tab']");
            funcs.Click("//a[text()='Logout']");

            Assert.That(driver.Url.Contains("auth/login"), "Logout failed.");
        }

        public void Teardown()
        {
            driver.Quit();
        }
    }
}