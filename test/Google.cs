using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class Google
    {
        private IWebDriver driver;

        [SetUp]
        public void set()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.google.com");

        }

        [Test]
        public void test()
        {
            IWebElement searchBox = driver.FindElement(By.Id("APjFqb"));
           
            searchBox.SendKeys("Selenium Webdriver");
            //searchBox.Submit();
            searchBox.SendKeys(Keys.Enter);            
            //Assert.IsTrue(driver.Title.Contains("Selenium Webdriver"), "Selenium search results is not displayed");
            
        }
        [TearDown]
        public void tearDown() 
        {
            driver.Quit();
        }
    }
}
