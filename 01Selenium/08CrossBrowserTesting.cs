using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Selenium
{
    [TestClass]
   public class _08CrossBrowserTesting
    {
       [TestMethod]   
       public void ChromeBrowser()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.selenium.dev/";
            driver.Quit();

        }
        [TestMethod]
        public void FirefoxBrowser()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.selenium.dev/";
            driver.Quit();

        }
        [TestMethod]

        //windows 10 doesn't have IE, so cant execute below method
        public void InternetExplorerBrowser()
        {
            IWebDriver driver = new InternetExplorerDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.selenium.dev/";
            driver.Quit();

        }
        [TestMethod]
        //for edge dont rely on driver from nuget> download latest from developer.microsoft.com
        //since edge is in programFiles(X86),we need to install 32-bit edge driver>put it in bin folder and rename it to MicrosoftEdgeDriver
        public void EdgeBrowser()
        {
            IWebDriver driver = new EdgeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.selenium.dev/";
            driver.Quit();

        }
        [TestMethod]
        public void ChromeHeadless()
        {
            ChromeOptions op = new ChromeOptions();
            op.AddArgument("--headless");
            IWebDriver driver = new ChromeDriver(op);
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.selenium.dev/";
            Console.WriteLine(driver.Title);
            driver.Quit();

        }
        [TestMethod]
        public void FirefoxHeadless()
        {
            FirefoxOptions op = new FirefoxOptions();
            op.AddArgument("--headless");
            IWebDriver driver = new FirefoxDriver(op);
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.selenium.dev/";
            Console.WriteLine(driver.Title);
            driver.Quit();

        }
        



    }
}
