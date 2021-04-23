using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _01Selenium
{
    [TestClass]
    public class _06Synchronization
    {
        //not recomended
        //hard wait
        [TestMethod]
        public void SynchronizationUsingThreadSleep()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com/Students/Contact";

            driver.FindElement(By.PartialLinkText("This is")).Click();
            Thread.Sleep(14000);
            string result = driver.FindElement(By.ClassName("ContactUs")).Text;

            Assert.IsTrue(result.Contains("Python"));

            driver.Quit();
        }
        [TestMethod]
        public void SynchronizationUsingImplicitWait()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            Console.WriteLine("Before setting implicit wait : " + driver.Manage().Timeouts().ImplicitWait);
            //since this is at driver level, implicit will wait for all elements till the element appears or for max 14 secs
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(14000);  //we are setting the property implicit wait
            Console.WriteLine("After setting implicit wait : " + driver.Manage().Timeouts().ImplicitWait);
            driver.Url = "http://uitestpractice.com/Students/Contact";

            driver.FindElement(By.PartialLinkText("This is")).Click();
            //Thread.Sleep(14000);
            string result = driver.FindElement(By.ClassName("ContactUs")).Text;

            Assert.IsTrue(result.Contains("Python"));

            driver.Quit();
        }
        [TestMethod]
        public void SynchronizationUsingExplicitWait()
        {

            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(14000);

            driver.Url = "http://uitestpractice.com/Students/Contact";

            driver.FindElement(By.PartialLinkText("This is")).Click();
            
            //for explicit wait, we need to create object of Webdriverwait class
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(14000));
            wait.PollingInterval = TimeSpan.FromMilliseconds(100);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("ContactUs")));
            

            string result = driver.FindElement(By.ClassName("ContactUs")).Text;
            Assert.IsTrue(result.Contains("Python"));
            driver.Quit();





        }
    }
}
