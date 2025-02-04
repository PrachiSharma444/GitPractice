using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class Yahoo
    {
        private IWebDriver driver;

        [SetUp]
        public void setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.yahoo.com/");

     
        }
        [Test]
        public void test()
        {
            IWebElement searchbox = driver.FindElement(By.Id("ybar-sbq"));
            searchbox.SendKeys("Selenium Webdriver");
            searchbox.SendKeys(Keys.Enter);
            Thread.Sleep(2000);

            //switch to new window
             var windowHandles = driver.WindowHandles;
            driver.SwitchTo().Window(windowHandles[1]);
            Assert.IsTrue(driver.Title.Contains("Selenium Webdriver"), "Its not locating");
        }
        [TearDown]
        public void tearDown() 
        {
            driver.Quit();
        }
    }
}
