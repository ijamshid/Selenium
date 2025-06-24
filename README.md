Q1 Test script
Write a test script for checking the work of a coffee machine

Answer

Test Script: Check the work of a coffee machine
Precondition:

Coffee machine is plugged in and powered on.
Water tank is filled.
Coffee beans are loaded.


Test Steps and Expected Results:

Step No	 Action	                                        Expected Result
1	Turn on the coffee machine	                The power light turns on
2	Select "Espresso" option	                Option is highlighted
3	Press the "Start" button	                Machine starts brewing process
4	Wait for the brewing process to complete	Coffee is dispensed into the cup
5	Check the coffee cup	                        Cup contains the correct amount of coffee
6	Check the used coffee grounds container	        Used grounds are present in the container
7	Turn off the coffee machine	                Machine powers off


Postcondition:
1. Coffee machine is ready for the next use.
2. No errors on display.
3. Used grounds container has grounds.



Q2 SQL
There are 2 tables:
Employees table: EMP
Departments table: DEP

Write a query that returns all employees with a number under 1000, showing the following info:
Employee number
employee name
employment start date
name of the department employee works in


select e.Emp_no, e.Emp_Name,e.Date_start,d.Descr
from EMP e
join Dep d on e.Dep==d.No
where  e.Emp_no<1000



1. If Person 1 saw 2 red hats (on Person 2 and Person 3), he would immediately know his own hat is black, because only 2 red hats exist. But he didn't know, so there cannot be 2 red hats among Person 2 and Person 3.


2. If Person 2 saw 1 red hat on Person 3 and was wearing a red hat himself, knowing Person 1 didn’t know, Person 2 could reason: “If I and Person 3 were both red, Person 1 would have seen 2 reds and known his was black.” Since Person 1 didn’t know, this means it’s not possible that both Person 2 and Person 3 are red.


3. Person 3, knowing both Person 1 and Person 2 were uncertain, realizes: If he were wearing a red hat, then based on the reasoning above, one of the others might have figured out their own hat colour. Since neither of them did, the only possible explanation is that Person 3 is wearing a black hat.



Q4 Selenium
Answer
Screen recording link - 
Link to source codes - https://github.com/ijamshid/Selenium


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
