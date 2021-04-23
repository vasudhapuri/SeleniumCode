using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _01Selenium
{
    [TestClass]
    public class _07TakeScreenshotAndExecuteJavascript
    {
        [TestMethod]
        public void TakeScreenshot()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com/Students/Contact";
            //usually we wl have only one driver object throughout our aurtomation and we will typecast it
            ITakesScreenshot ss = (ITakesScreenshot)driver;
            ss.GetScreenshot().SaveAsFile("demofile.png");
            driver.Quit();
        }
        [TestMethod]
        public void ExecuteJavaScriptAlert()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com/Students/Contact";
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("alert('hi')");
            Thread.Sleep(5000);
            driver.Quit();
        }
        [TestMethod]
        public void ExecuteJavaScriptScroll()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://www.selenium.dev";
            Thread.Sleep(3000);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0,500)");
            Thread.Sleep(3000);
            driver.Quit();


        }
    }


}







