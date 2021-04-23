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
using System.Threading.Tasks;

namespace _01Selenium
{
    [TestClass]
    public class HandlingElements
    {

        [TestMethod]
        public void SelectingRadioButtonAndCheckbox()
        {


            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com/Students/Form";
            driver.FindElement(By.XPath("//label[normalize-space()='Single']")).Click();
            driver.FindElement(By.XPath("//input[@value='read']")).Click();
            Thread.Sleep(3000);
            driver.Quit();
        }
        [TestMethod]
        public void SelectingDropDown()
        { // can use select by value, select by index, select by text


            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com/Students/Select";
           IWebElement element= driver.FindElement(By.Id("countriesSingle"));
            SelectElement s = new SelectElement(element); // call parametrized constructor of SelectElement class
            s.SelectByText("United states of America");
            Thread.Sleep(3000);
            s.SelectByValue("india");
            Thread.Sleep(3000);
            s.SelectByIndex(2);
            Thread.Sleep(3000);
            driver.Quit();
        }

        [TestMethod]
        public void MultiSelectDropDown()
        {


            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com/Students/Select";
            IWebElement element = driver.FindElement(By.Id("countriesSingle"));
            SelectElement s = new SelectElement(element);
            Console.WriteLine(s.IsMultiple);
            IWebElement element2 = driver.FindElement(By.Id("countriesMultiple"));
            SelectElement s2 = new SelectElement(element2);
            Console.WriteLine(s2.IsMultiple);
            Console.WriteLine("Options "+s2.Options.Count);
            foreach (var option in s2.Options)
            {
                Console.WriteLine(option.Text);

            }

            s2.SelectByText("India");
            s2.SelectByText("England");
            Console.WriteLine(s2.SelectedOption.Text);
            Thread.Sleep(3000);
            s2.DeselectByText("England");
            
            Thread.Sleep(3000);
            driver.Quit();
        }

        [TestMethod]
        public void BootStrapDropdown()
        {
            //Regular dropdown has select and options tags, bootstrap dropdwon doesnt have select tag

            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com/Students/Select";
            driver.FindElement(By.Id("dropdownMenu1")).Click(); //click on dropdown
            driver.FindElement(By.LinkText("China")).Click(); //select china value

            Thread.Sleep(3000);
            driver.Quit();
        }
    }
}

