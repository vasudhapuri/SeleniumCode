using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace _01Selenium
{
    [TestClass]
    public class _04SwitchTo
    {
        [TestMethod]
        public void SwitchToFrame()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "http://uitestpractice.com/Students/Switchto";
            driver.Manage().Window.Maximize();
            driver.SwitchTo().Frame("iframe_a");

            driver.FindElement(By.Id("name")).SendKeys("vasudha");
            driver.SwitchTo().DefaultContent();

            driver.FindElement(By.Id("alert")).Click();
            Thread.Sleep(3000);
            driver.Quit();
        }
        [TestMethod]
        public void SwitchToWindow()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "http://uitestpractice.com/Students/Switchto";
            driver.Manage().Window.Maximize();

            Console.WriteLine("Window handles Before Click: " + driver.WindowHandles.Count);
            foreach (var handle in driver.WindowHandles)
            {
                Console.WriteLine(handle);
            }
            driver.FindElement(By.PartialLinkText("Opens")).Click();
            Console.WriteLine("Window handles After Click: " + driver.WindowHandles.Count);
            foreach (var handle in driver.WindowHandles)
            {

                Console.WriteLine(handle);
            }
            driver.SwitchTo().Window(driver.WindowHandles[1]); //switches to 2nd window handle
            Console.WriteLine(driver.FindElement(By.TagName("h3")).Text); //gets text of first h3 tag
            Thread.Sleep(3000);
            driver.Close();//closes only current window handle
            Console.WriteLine("Window handles after closing the 2nd window handle: " + driver.WindowHandles.Count);
            foreach (var handle in driver.WindowHandles)
            {
                Console.WriteLine(handle);
            }
            Thread.Sleep(3000);
            driver.Quit();
        }

        [TestMethod]
        public void SwitchToAlert()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "http://uitestpractice.com/Students/Switchto";
            driver.Manage().Window.Maximize();

            driver.FindElement(By.Id("alert")).Click();
            Thread.Sleep(2000);
            String txt = driver.SwitchTo().Alert().Text;
            Console.WriteLine(txt);
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(2000);
            txt = driver.FindElement(By.Id("demo")).Text;
            Console.WriteLine(txt);

            Thread.Sleep(2000);
            driver.Quit();
        }




        [TestMethod]
        public void SwitchToConfirm()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com/Students/Switchto";

            driver.FindElement(By.Id("confirm")).Click();
            Thread.Sleep(3000);
            string text = driver.SwitchTo().Alert().Text;

            Console.WriteLine(text);
            Thread.Sleep(3000);

            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(3000);
            text = driver.FindElement(By.Id("demo")).Text;
            Console.WriteLine(text);

            driver.FindElement(By.Id("confirm")).Click();
            Thread.Sleep(3000);
            driver.SwitchTo().Alert().Dismiss();
            Thread.Sleep(3000);
            text = driver.FindElement(By.Id("demo")).Text;
            Console.WriteLine(text);

            driver.Quit();
        }
        [TestMethod]
        public void SwitchToPrompt()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com/Students/Switchto";

            driver.FindElement(By.Id("prompt")).Click();
            Thread.Sleep(10000);
            driver.SwitchTo().Alert();
            Thread.Sleep(10000);
            string text = driver.SwitchTo().Alert().Text;
         Console.WriteLine(text);
            Thread.Sleep(10000);

            driver.SwitchTo().Alert().SendKeys("Narendra Modi");
           Thread.Sleep(10000);
            //   driver.SwitchTo().Alert();
            //    Thread.Sleep(3000);
            driver.SwitchTo().Alert().Accept();
                 Thread.Sleep(3000);
             text = driver.FindElement(By.Id("demo")).Text;
              Console.WriteLine(text);
            driver.Quit();





        }
        [TestMethod]
        public void WorkingWithBootstrapModalWindow()
            //modal window 
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com/Students/Switchto";

            driver.FindElement(By.XPath("//button[@data-target='#myModal']")).Click();
            string header = driver.FindElement(By.TagName("h4")).Text;
            Console.WriteLine("Modal window header : " + header);

            string body = driver.FindElement(By.XPath("//div[@class='modal-body']")).Text;
            Console.WriteLine("Modal window body : " + body);

            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//button[text()='Ok']")).Click();

            driver.Quit();
        }

    }
}
