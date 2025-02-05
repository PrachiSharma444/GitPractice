using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.DropdownPage;

namespace test.DropdownTest
{
    public class AlertTest
    {
        IWebDriver driver;
        AlertPage alertpage;

        [SetUp]
        public void setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://demoqa.com/alerts");
            alertpage = new AlertPage(driver);

        }

        [Test]
        public void test()
        {
            alertpage.ClickButton();
        }

        [TearDown]
        public void tearDown()
        {
            driver.Quit();
        }
    }
}
