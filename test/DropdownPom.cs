using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class DropdownPom
    {
        private readonly IWebDriver _driver;

        public DropdownPom(IWebDriver driver)
        {
            _driver = driver;
        }

        IWebElement selectValuePath => _driver.FindElement(By.XPath("//body/div[@id='app']/div[1]/div[1]/div[1]/div[2]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]"));
        IWebElement selectValue => _driver.FindElement(By.XPath("//div[contains(text(),'Group 2, option 1')]"));
        IWebElement SelectOnePath => _driver.FindElement(By.XPath("//body/div[@id='app']/div[1]/div[1]/div[1]/div[2]/div[2]/div[4]/div[1]/div[1]/div[1]/div[1]"));
        IWebElement SelectOne => _driver.FindElement(By.XPath("//div[contains(text() , 'Ms')]"));
        IWebElement SelectOldColorPath => _driver.FindElement(By.XPath("//body/div[@id='app']/div[1]/div[1]/div[1]/div[2]/div[2]/div[6]/div[1]/div[1]/Select[@id='oldSelectMenu']"));

        IWebElement SelectColor => _driver.FindElement(By.XPath("//option[contains(text(),'Black')]"));
        IWebElement diffColour => _driver.FindElement(By.Id("react-select-4-input"));


        public void fillvalue()
        {
            ClickElement(selectValuePath);
            ClickElement(selectValue);
            ClickElement(SelectOnePath);
            ClickElement(SelectOne);
            ClickElement(SelectOldColorPath);
            ClickElement(SelectColor);


        }
        public void Diffrent(string colours)
        {
            diffColour.SendKeys(colours);
            diffColour.SendKeys(Keys.Enter);
        }

        public void ClickElement(IWebElement element, int TimeOutInSeconds = 30)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(TimeOutInSeconds));
            wait.Until(driver => element.Displayed && element.Enabled);
            element.Click();
        }
    }
}
    

     