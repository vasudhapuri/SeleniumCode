using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace _01Selenium
{
    [TestClass]
    public class _12EventFiringWebdriver
    {
        [TestMethod]        
        public void EventFiringDriverDemo()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com/Students/Create";
            EventFiringWebDriver eventFiringWebDriver = new EventFiringWebDriver(driver);
            //when an event occurs> the associated method gets called
            //methods are binded to event
            eventFiringWebDriver.ElementClicking += EventFiringWebDriver_ElementClicking;
            eventFiringWebDriver.ElementClicked += EventFiringWebDriver_ElementClicked;
            eventFiringWebDriver.ElementValueChanging += EventFiringWebDriver_ElementValueChanging;
            eventFiringWebDriver.ElementValueChanged += EventFiringWebDriver_ElementValueChanged;
            eventFiringWebDriver.FindingElement += EventFiringWebDriver_FindingElement;
            eventFiringWebDriver.FindElementCompleted += EventFiringWebDriver_FindElementCompleted;
            eventFiringWebDriver.Navigating += EventFiringWebDriver_Navigating;
            eventFiringWebDriver.Navigated += EventFiringWebDriver_Navigated;
            eventFiringWebDriver.NavigatingForward += EventFiringWebDriver_NavigatingForward;
            eventFiringWebDriver.NavigatedForward += EventFiringWebDriver_NavigatedForward;
            eventFiringWebDriver.NavigatingBack += EventFiringWebDriver_NavigatingBack;
            eventFiringWebDriver.NavigatedBack += EventFiringWebDriver_NavigatedBack;
            eventFiringWebDriver.ScriptExecuting += EventFiringWebDriver_ScriptExecuting;
            eventFiringWebDriver.ScriptExecuted += EventFiringWebDriver_ScriptExecuted;
            eventFiringWebDriver.ExceptionThrown += EventFiringWebDriver_ExceptionThrown;

            // since driver is of type IWebdriver and also EventFiringdriver implements IWebdriver,
            // we can write below line , so that we can call using eg. "driver.FindElement"
            driver = eventFiringWebDriver;
            driver.FindElement(By.Id("FirstName")).SendKeys("Nithin");
            driver.FindElement(By.XPath("//input[@value='Create']")).Click();
            driver.Url = "http://google.com";
            driver.Navigate().Back();
            driver.Navigate().Forward();

            ((IJavaScriptExecutor)driver).ExecuteScript("alert('Hi from Javascript')");
            Thread.Sleep(3000);

            driver.FindElement(By.Id("xyz")).Click();

            driver.Quit();
        }
        private void EventFiringWebDriver_ExceptionThrown(object sender, WebDriverExceptionEventArgs e)
        {
            Console.WriteLine("Exception thrown : " + e.ThrownException.Message);
        }

        private void EventFiringWebDriver_ScriptExecuted(object sender, WebDriverScriptEventArgs e)
        {
            Console.WriteLine("Javascript executed");
        }

        private void EventFiringWebDriver_ScriptExecuting(object sender, WebDriverScriptEventArgs e)
        {
            Console.WriteLine("Javascript executing");
        }

        private void EventFiringWebDriver_NavigatedBack(object sender, WebDriverNavigationEventArgs e)
        {
            Console.WriteLine("Navigated back " + e.Url);
        }

        private void EventFiringWebDriver_NavigatingBack(object sender, WebDriverNavigationEventArgs e)
        {
            Console.WriteLine("Navigating back " + e.Url);
        }

        private void EventFiringWebDriver_NavigatedForward(object sender, WebDriverNavigationEventArgs e)
        {
            Console.WriteLine("Navigated forward " + e.Url);
        }

        private void EventFiringWebDriver_NavigatingForward(object sender, WebDriverNavigationEventArgs e)
        {
            Console.WriteLine("Navigating forward " + e.Url);
        }

        private void EventFiringWebDriver_Navigated(object sender, WebDriverNavigationEventArgs e)
        {
            Console.WriteLine("Navigated to new page " + e.Url);
        }

        private void EventFiringWebDriver_Navigating(object sender, WebDriverNavigationEventArgs e)
        {
            Console.WriteLine("Navigating to new page " + e.Url);
        }

        private void EventFiringWebDriver_FindElementCompleted(object sender, FindElementEventArgs e)
        {
            Console.WriteLine("Finding element completed");
        }

        private void EventFiringWebDriver_FindingElement(object sender, FindElementEventArgs e)
        {
            Console.WriteLine("Finding element");
        }

        private void EventFiringWebDriver_ElementValueChanged(object sender, WebElementValueEventArgs e)
        {
            Console.WriteLine("Element value changed");
        }

        private void EventFiringWebDriver_ElementValueChanging(object sender, WebElementValueEventArgs e)
        {
            Console.WriteLine("Element value changing");
        }

        private void EventFiringWebDriver_ElementClicked(object sender, WebElementEventArgs e)
        {
            Console.WriteLine("Element clicked");
        }

        private void EventFiringWebDriver_ElementClicking(object sender, WebElementEventArgs e)
        {
            Console.WriteLine("Element getting clicked");
        }


      

    }
}

