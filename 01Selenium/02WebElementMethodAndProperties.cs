using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _01Selenium
{
    [TestClass]
    public class WebElementMethodAndProperties
    {
        [TestMethod]
        public void ClearTextBox()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com/Students/Create";
            driver.FindElement(By.Id("FirstName")).SendKeys("Nisha");
            Thread.Sleep(3000);
            driver.FindElement(By.Id("FirstName")).Clear();
            Thread.Sleep(3000);
            driver.Quit();
        }
        [TestMethod]
        public void GetAttribute()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com/Students/Create";
            String att = driver.FindElement(By.Id("FirstName")).GetAttribute("type");
            Console.WriteLine(att);
            Thread.Sleep(3000);

            driver.Quit();
        }

        [TestMethod]
        public void GetCssValue()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com/Students/Create";
            String cssval = driver.FindElement(By.TagName("h2")).GetCssValue("font-size");
            Console.WriteLine(cssval);
            cssval = driver.FindElement(By.TagName("h2")).GetCssValue("font-family");
            Console.WriteLine(cssval);
            Thread.Sleep(3000);

            driver.Quit();
        }

        [TestMethod]
        public void Submit()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com/Students/Create";
            driver.FindElement(By.Id("FirstName")).SendKeys("Harsha");
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//input[@value='Create']")).Submit();
            Thread.Sleep(3000);

            driver.Quit();
        }
        [TestMethod]
        public void IsDisplayed()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com/Students/Create";
            bool isdisplayed = driver.FindElement(By.Id("FirstName")).Displayed;
            Console.WriteLine(isdisplayed);
            Thread.Sleep(3000);
            isdisplayed = driver.FindElement(By.Name("__RequestVerificationToken")).Displayed;
            Console.WriteLine(isdisplayed);
            Thread.Sleep(3000);
            driver.Quit();
        }
        [TestMethod]
        public void IsEnabled()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com/Students/Create";
            bool isenabled = driver.FindElement(By.Id("FirstName")).Enabled;
            Console.WriteLine(isenabled);
            Thread.Sleep(3000);
            driver.Quit();
        }
        [TestMethod]
        public void IsEnabled1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://demos.jquerymobile.com/1.4.5/forms-disabled/";
            bool isenabled = driver.FindElement(By.Id("textinput-1")).Enabled;
            Console.WriteLine(isenabled);
            Thread.Sleep(3000);
            driver.Quit();
        }
        [TestMethod]
        public void GetLocation()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com/Students/Create";
            Point location = driver.FindElement(By.Id("FirstName")).Location;
            Console.WriteLine(location);
            Console.WriteLine("x=" + location.X + "and y=" + location.Y);
            Thread.Sleep(3000);
            driver.Quit();
        }
        [TestMethod]
        public void IsSelected()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com/Students/Form";
            driver.FindElement(By.XPath("//input[@value='read']")).Click();
            bool isselected = driver.FindElement(By.XPath("//input[@value='read']")).Selected;
            Console.WriteLine(isselected);
            isselected = driver.FindElement(By.XPath("//input[@value='dance']")).Selected;
            Console.WriteLine(isselected);
            Thread.Sleep(3000);
            driver.Quit();
        }
        [TestMethod]
        public void GetSize()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com/Students/Create";
            Size size = driver.FindElement(By.Id("FirstName")).Size;
            Console.WriteLine(size);

            Console.WriteLine($"Height={size.Height}\nWidth={size.Width}"); //string interpolation-new feature in c# 

            Thread.Sleep(3000);
            driver.Quit();
        }
        [TestMethod]
        public void GetTagName()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com/Students/Create";
            string tagname = driver.FindElement(By.Id("FirstName")).TagName;
            Console.WriteLine(tagname);
            Thread.Sleep(3000);
            driver.Quit();

        }
        [TestMethod]
        public void FindElementInAnElement()
        { // to restrict search to a particular area 
           // this is used in case where our reqd. element doesnt have proper locator
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com/Students/Create";
             driver.FindElement(By.XPath("//*[@Class='form-group'][2]")).FindElement(By.TagName("input")).SendKeys("SM");
           
            Thread.Sleep(3000);
            driver.Quit();
        }
    }
}
