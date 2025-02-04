using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitPrcatice.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        IWebElement username => driver.FindElement(By.Id("user_email_login"));
        IWebElement userpass => driver.FindElement(By.Id("user_password"));
        IWebElement login => driver.FindElement(By.Name("commit"));

        public void Entername(string name)
        {
            username.SendKeys(name);
        }
        public void Enterpass(string pass)
        {
            userpass.SendKeys(pass);
        }
        public void ClickLoginButton()
        {
            login.Click();
        }

        public void Loginm(string name, string pass)
        {
            Entername(name);
            Enterpass(pass);
            ClickLoginButton();

        }
    }

}