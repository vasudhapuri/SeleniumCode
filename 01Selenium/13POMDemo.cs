using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Selenium
{
    [TestClass]
    public class _13POMDemo
    {
        private IWebDriver driver; //since driver has to be shared with multiple test methods, so we give as instance variable
        private CreateStudentPage createStudentPage;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com/Students/Create";
            createStudentPage = new CreateStudentPage(driver); //due to parameterized constructur we pass driver as parameter here
        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }

        [TestMethod]
        public void POMDemo()
        {
            //
            createStudentPage.FirstName.SendKeys("Nirmala");
            createStudentPage.LastName.SendKeys("Sitharam");
            createStudentPage.EnrollmentDate.SendKeys("12/12/2021");
            createStudentPage.CreateButton.Click();
        }
    }
}
