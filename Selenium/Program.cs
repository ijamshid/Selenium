using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace LiveJournalTest
{
    class Program
    {
        static void Main(string[] args)
        {

            IWebDriver driver = new ChromeDriver();

            try
            {
                driver.Navigate().GoToUrl("https://www.livejournal.com/login/");
                driver.Manage().Window.Maximize();
                Thread.Sleep(3000); 

                IWebElement iframeElement = driver.FindElement(By.CssSelector("iframe[class*='b-loginform-loginframe']"));
                driver.SwitchTo().Frame(iframeElement);


                driver.FindElement(By.Name("user")).SendKeys("syneltest");
                driver.FindElement(By.Name("password")).SendKeys("123qweASD");


                driver.FindElement(By.CssSelector("button[type='submit']")).Click();
                Thread.Sleep(3000); 


                driver.SwitchTo().DefaultContent();


                driver.Navigate().GoToUrl("https://www.livejournal.com/post");
                Thread.Sleep(5000); 


                var titleInput = driver.FindElement(By.CssSelector("input[data-lj-meta='entryTitle']"));
                titleInput.Click();
                titleInput.SendKeys("Your Name");


                var bodyInput = driver.FindElement(By.CssSelector("div[data-lj-meta='entryText'] div[role='textbox']"));
                bodyInput.Click();
                bodyInput.SendKeys("This is a test post created via Selenium C# script on LiveJournal.");

                Thread.Sleep(1000);


                var postButton = driver.FindElement(By.CssSelector("button[data-lj-meta='entrySubmit']"));
                postButton.Click();

                Thread.Sleep(5000); 

                Console.WriteLine("✅ Post successfully submitted!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Test failed: " + ex.Message);
            }
            finally
            {
                driver.Quit();
            }
        }
    }
}
