using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public  class SelectDropdown
    {
        private IWebDriver _driver;

        
        private DropdownPom _menu;


        [SetUp]
        public void setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://demoqa.com/select-menu");
            _menu = new DropdownPom(_driver);
            ScrollDown(300);


        }
        [Test]
        public void test()
        {
            _menu.fillvalue();
            _menu.Diffrent("Red");
        }

        [TearDown]
        public void tearDown()
        {
            _driver.Close();
        }

        public void ScrollDown(int yOffset)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript($"window.scrollBy(0,{yOffset})");
        }
    }
}
