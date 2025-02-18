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
        IWebElement prompt => driver.FindElement(By.Id("promtButton"));
        IWebElement confirm => driver.FindElement(By.Id("confirmButton"));

        public void ClickButton()
        {
            ClickElement(button);
            IAlert alert = driver.SwitchTo().Alert();
           
            Assert.AreEqual("You clicked a button" , alert.Text);
            alert.Accept();
        }
        public void ClickPromt()
        {
            ClickElement(prompt);
            IAlert promtalert = driver.SwitchTo().Alert();
            
            promtalert.SendKeys("prachi");
           
            Thread.Sleep(2000);
            promtalert.Accept();
            string resultText = driver.FindElement(By.Id("promptResult")).Text;
            Assert.IsTrue(resultText.Contains("prachi"));
        }
        public void ClickConfirm()
        {
            ClickElement(confirm);
            IAlert confirmAlert = driver.SwitchTo().Alert();
            confirmAlert.Accept();
        }
        public void ClickElement(IWebElement ele)
        {
            ele.Click();
        }
    }
}
