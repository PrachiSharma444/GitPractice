using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.DropdownPage
{
    public class AlertPage
    {
        private readonly IWebDriver driver;

        public AlertPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement button => driver.FindElement(By.Id("alertButton"));

        public void ClickButton()
        {
            ClickElement(button);
            IAlert alert = driver.SwitchTo().Alert();
           
            Assert.AreEqual("You clicked a button" , alert.Text);
            alert.Accept();
        }

        public void ClickElement(IWebElement ele)
        {
            ele.Click();
        }
    }
}
