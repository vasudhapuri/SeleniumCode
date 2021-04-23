using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Threading;

namespace _01Selenium
{
    [TestClass]
    public class SeleniumSelectors
    {
        [TestMethod]
        public void LaunchBrowserAndNavigateToUrl()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
           
            driver.Url = "http://UItestpractice.com";
            driver.Quit();
        }

        [TestMethod]
        public void EnterTextInElement()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com/Students/Form";

          // By by = By.Id("firstname");// Id is static method with string parameter and returns object of By class
          // IWebElement element = driver.FindElement(by);//objectname.function(parameter)

          //  element.SendKeys("Ramesh");

            driver.FindElement(By.Id("firstname")).SendKeys("Ramesh");
            Thread.Sleep(3000);

            driver.Quit();
        }

        [TestMethod]
        public void GetPageTitle()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com/Students/Form";

            string title= driver.Title;
            Console.WriteLine(title);


            Thread.Sleep(3000);

            driver.Quit();
        }

        [TestMethod]
        public void GetPageSource()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com/Students/Form";

            string pageSource = driver.PageSource;
            Console.WriteLine(pageSource);


            Thread.Sleep(3000);

            driver.Quit();
        }

        [TestMethod]
        public void GetPageUrl()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com/Students/Form";

            string url = driver.Url;
            Console.WriteLine(url);


            Thread.Sleep(3000);

            driver.Quit();
        }


        [TestMethod]
        public void NavigateToUrls()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com/Students/Form";
            Thread.Sleep(3000);
            driver.Url = "http://google.com";
            Thread.Sleep(3000);
            driver.Navigate().Back();
            Thread.Sleep(3000);
            driver.Navigate().Forward();
            Thread.Sleep(3000);
            driver.Navigate().Refresh();
            Thread.Sleep(3000);
           // driver.Navigate().GoToUrl("http://facebook.com");
            Thread.Sleep(3000);

            driver.Quit();
        }

        [TestMethod]
        public void FindElementById()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com/Students/Form";
            driver.FindElement(By.Id("firstname")).SendKeys("Ramesh");
            Thread.Sleep(3000);


            driver.Quit();
        }
        [TestMethod]
        public void FindElementByName()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com/Students/Create";
            driver.FindElement(By.Name("FirstName")).SendKeys("Ramesh");
            Thread.Sleep(3000);


            driver.Quit();
        }
        [TestMethod]
        public void FindElementByTagName()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com/Students/Create";
            string text= driver.FindElement(By.TagName("h2")).Text;
            Console.WriteLine(text);
            Thread.Sleep(3000);


            driver.Quit();
        }

        [TestMethod]
        public void FindElementByClassName()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com/Students/Select";
            string text = driver.FindElement(By.ClassName("navbar-brand")).Text;
            Console.WriteLine(text);
            Thread.Sleep(3000);


            driver.Quit();
        }
        [TestMethod]
        public void FindElementByLinkText()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com/Students/Contact";
            driver.FindElement(By.LinkText("This is a Ajax link")).Click();
            
            Thread.Sleep(3000);


            driver.Quit();
        }
        [TestMethod]
        public void FindElementByPartialLinkText()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com/Students/Contact";
            driver.FindElement(By.PartialLinkText("This is")).Click();

            Thread.Sleep(3000);


            driver.Quit();
        }

        [TestMethod]
        public void FindElementByCssSelector()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.facebook.com/";
             driver.FindElement(By.CssSelector("input[name = 'email']")).SendKeys("abc@gmail.com");
            //driver.FindElement(By.CssSelector("input[name ^= 'ema']")).SendKeys("abc@gmail.com");
            // driver.FindElement(By.CssSelector("input[name $= 'il']")).SendKeys("abc@gmail.com");
           // driver.FindElement(By.CssSelector("#email")).SendKeys("abc@gmail.com");
          //  driver.FindElement(By.CssSelector(".inputtext _55r1 _6luy")).SendKeys("abc@gmail.com");
            Thread.Sleep(3000);


            driver.Quit();
        }
        [TestMethod]
        public void FindElements()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com/Students/Create";
           ReadOnlyCollection<IWebElement> inputs=driver.FindElements(By.TagName("input"));

            Console.WriteLine(inputs.Count);
            inputs[2].SendKeys("Modi");
            foreach (var i in inputs)
                Console.WriteLine(  i.GetAttribute("id"));
            
            Thread.Sleep(3000);


            driver.Quit();
        }

        [TestMethod]
        public void FindElementsWhenNoElementExists()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com/Students/Create";
            ReadOnlyCollection<IWebElement> inputs = driver.FindElements(By.Id("xyz"));

            Console.WriteLine(inputs.Count);
            foreach (var i in inputs)
                Console.WriteLine(i.GetAttribute("id"));
           
            Thread.Sleep(3000);


            driver.Quit();
        }
        
      


    }
}
