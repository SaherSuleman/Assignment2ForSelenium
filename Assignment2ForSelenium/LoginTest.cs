using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace Assignment2_Selenium
{
    [TestFixture]
    public class LoginTest
    {
        IWebDriver driver;
        AllFunctions funcs;

        [SetUp]
        public void Setup()
        {
            driver = Driver.GetDriver();
            funcs = new AllFunctions(driver);
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
            driver.Manage().Window.Maximize();
            Thread.Sleep(2000);
        }

        [Test]
        public void ValidLoginTest()
        {
            funcs.SendKeys("Admin", "//input[@name='username']");
            funcs.SendKeys("admin123", "//input[@name='password']");
            funcs.Click("//button[@type='submit']");

            Assert.That(driver.Url.Contains("dashboard"), Is.True, "System is unable to logged in.");
            Logout();
        }

        [Test]
        public void InvalidLoginTest()
        {
            funcs.SendKeys("xyz", "//input[@name='username']");
            funcs.SendKeys("admin123", "//input[@name='password']");
            funcs.Click("//button[@type='submit']");
            Thread.Sleep(20000);
            var error = funcs.FindElement("//div/p[text()='Invalid credentials']");
            Assert.That(error.Displayed, Is.True, "Error message not shown.");
             Assert.That(error.Text.Trim(), Is.EqualTo("Invalid credentials"), "Unexpected error message.");
        }

        public void Logout()
        {
            // Click on the user dropdown
            funcs.Click("//span[@class='oxd-userdropdown-tab']");

            // Click on the Logout link
            funcs.Click("//a[text()='Logout']");
        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }
    }
}