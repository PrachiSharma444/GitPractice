
using GitPrcatice.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitPrcatice.Tests
{
    public class LoginTests
    {
        IWebDriver driver;
        LoginPage loginpage;

        [SetUp]
        public void setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.browserstack.com/users/sign_in");
            loginpage = new LoginPage(driver);
        }

        [Test]
        public void logintests()
        {
            loginpage.Loginm("prachish74@gmail.com", "123456");
            string AfterLoginUrl = "https://live.browserstack.com/dashboard";
            Assert.AreNotEqual(AfterLoginUrl, driver.Url);

        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}