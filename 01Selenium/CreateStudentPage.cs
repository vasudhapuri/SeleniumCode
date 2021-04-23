using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Selenium
{
   //model class- wch creates only properties, hence the name page object model
    class CreateStudentPage
    {
        //driver is reqd for init(ialize) elements
        public CreateStudentPage(IWebDriver driver) //constructor
        {
            PageFactory.InitElements(driver, this);
        }
        //auto implemented properties> they have property type, name and get set
        //FindBy is an attribute which takes 3 parameters> how, using, priority
        [FindsBy(How = How.Id, Using = "FirstName", Priority = 1)] //metadata for page factory
        [FindsBy(How = How.Name, Using = "FirstName", Priority = 2)]
        public IWebElement FirstName { get; set; }

        [FindsBy(How = How.Id, Using = "LastName")]
        public IWebElement LastName { get; set; }

        [FindsBy(How = How.Id, Using = "EnrollmentDate")]
        public IWebElement EnrollmentDate { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='Create']")]
        public IWebElement CreateButton { get; set; }

        [FindsBy(How = How.LinkText, Using = "Back to List")]
        public IWebElement BackToListLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@for='EnrollmentDate']")]
        public IWebElement EnrollmentDateErrorMessage { get; set; }

        
    }
}
