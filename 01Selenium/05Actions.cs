using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Drawing;
using System.Threading;


namespace _01Selenium
{
    [TestClass]
    public class _05Actions
    {
        [TestMethod]
        public void DragAndDrop()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com/Students/Actions";

            Console.WriteLine(driver.FindElement(By.CssSelector("#droppable p")).Text);
            
           Actions actions = new Actions(driver);
           
           actions.DragAndDrop(driver.FindElement(By.Id("draggable")), driver.FindElement(By.Id("droppable"))).Build().Perform();

           Console.WriteLine(driver.FindElement(By.CssSelector("#droppable p")).Text);
            Thread.Sleep(3000);
            driver.Quit();
        }
        [TestMethod]
        public void DragAndDropToOffset()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com/Students/Actions";

            Console.WriteLine(driver.FindElement(By.CssSelector("#droppable p")).Text);

            Actions actions = new Actions(driver);
            actions
                .DragAndDropToOffset(driver.FindElement(By.Id("draggable")), 120, 30)
                .Build().Perform();

            Console.WriteLine(driver.FindElement(By.CssSelector("#droppable p")).Text);
            Thread.Sleep(3000);
            driver.Quit();
        }


        [TestMethod]
            public void Click()
            {
                IWebDriver driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
                driver.Url = "http://uitestpractice.com/Students/Actions";
            Actions actions = new Actions(driver);
            actions.Click(driver.FindElement(By.Name("click"))).Build().Perform();
            Thread.Sleep(3000);
            string text = driver.SwitchTo().Alert().Text;
            Console.WriteLine(text);
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(3000);
            driver.Quit();

        }
        [TestMethod]
        public void DoubleClick()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com/Students/Actions";
            Actions actions = new Actions(driver);
            actions.DoubleClick(driver.FindElement(By.Name("dblClick"))).Build().Perform();
            Thread.Sleep(3000);
            string text = driver.SwitchTo().Alert().Text;
            Console.WriteLine(text);
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(3000);
            driver.Quit();
        }
        [TestMethod]
        public void KeyDownAndKeyUp()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com/Students/Actions";
            Actions actions = new Actions(driver);
            actions.
                   KeyDown(Keys.Control)
                   .Click(driver.FindElement(By.Name("one")))
                   .Click(driver.FindElement(By.Name("twelve")))
                   .Click(driver.FindElement(By.Name("seven")))
                   .KeyUp(Keys.Control)
                   .Build().Perform();
            Thread.Sleep(3000);
            driver.Quit();
        }
        [TestMethod]
        public void MoveToElement()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com/Students/Actions";
            string bakgroundcolour=driver.FindElement(By.Id("div2")).GetCssValue("background-color");
            Console.WriteLine(bakgroundcolour);
            Actions actions = new Actions(driver);
            actions.
                   MoveToElement(driver.FindElement(By.Id("div2")));
             bakgroundcolour = driver.FindElement(By.Id("div2")).GetCssValue("background-color");
            Console.WriteLine(bakgroundcolour);
            Thread.Sleep(3000);
            driver.Quit();
        }
        [TestMethod]
        public void MoveToOffset()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com/Students/Actions";
            Point point = driver.FindElement(By.Id("div2")).Location;
            Console.WriteLine("X= "+point.X+"\tY= : "+point.Y);
            //before mouse goes to offset
            string bakgroundcolour = driver.FindElement(By.Id("div2")).GetCssValue("background-color");
            Console.WriteLine(bakgroundcolour);

            Actions actions = new Actions(driver);
            actions
                   .MoveByOffset(point.X + 2, point.Y + 2)
                   .Build().Perform();
            //after mouse moves to offset
            bakgroundcolour = driver.FindElement(By.Id("div2")).GetCssValue("background-color");
            Console.WriteLine(bakgroundcolour);

            Thread.Sleep(3000);
            driver.Quit();
        }

        [TestMethod]
        public void ContextClick()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com/Students/Actions";
           

            Actions actions = new Actions(driver);
            actions
                   .ContextClick(driver.FindElement(By.Id("div2")))
                   .Build().Perform();
      //context click (right click) will not show any browser extenstions which are normally shown when we right clik manually
                       Thread.Sleep(3000);
            driver.Quit();
        }
    }
}


















