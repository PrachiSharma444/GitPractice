using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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

            //Get the Top 5 results 
            var searchResults = driver.FindElements(By.CssSelector("h3 a"));
            List<Dictionary<string, string>> topResults = new List<Dictionary<string, string>>();
            for (int i = 0; i < Math.Min(5, searchResults.Count); i++)
            {
                string title = searchResults[i].Text;
                string url = searchResults[i].GetAttribute("href");

                if(!string.IsNullOrEmpty(title))
                {
                    topResults.Add(new Dictionary<string, string>
                    {
                    { "Title", title  },
                    { "URL", url }

                    });
                }
               
            }

            //Convert List to Json
            string jsonOutput = JsonConvert.SerializeObject(topResults , Formatting.Indented);

            //Save Json to file
         
            string Filepath = "YahooSearchResults.json";
            File.WriteAllText(Filepath, jsonOutput);
            Console.WriteLine("Top 5 search results saved to YahooSearchResults.json");

            //Read and display Json Results
            string jsonContent = File.ReadAllText(Filepath);
            Console.WriteLine("\nJson File Content");
            Console.WriteLine(jsonContent);

        }
        [TearDown]
        public void tearDown() 
        {
            driver.Quit();
        }
    }
}
