using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;

namespace _01Selenium
{
    [TestClass]
    public class _11DataDrivenTeating
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        [DataRow("Virat", "Kohli", "04/09/2021")]
        [DataRow("Mahendra", "Singh Dhoni", "01/01/2020")]
        [DataRow("Rohit", "Sharma", "12/12/2001")]
        public void DataDrivenTestUsingDataRow(string firstName, string lastName, string enrollmentDate)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com/Students/Create";
            driver.FindElement(By.Id("FirstName")).SendKeys(firstName);
            driver.FindElement(By.Id("LastName")).SendKeys(lastName);
            driver.FindElement(By.Id("EnrollmentDate")).SendKeys(enrollmentDate);
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe("http://uitestpractice.com/Students/Index"));
            driver.Quit();
        }

        [TestMethod]
        //dynamic data attribute
        //in below line we have 2 paremeters. 1st is name of method, 2nd is source of data
        [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
        public void DataDrivenTestUsingDynamicData(string firstName, string lastName, string enrollmentDate)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com/Students/Create";
            driver.FindElement(By.Id("FirstName")).SendKeys(firstName);
            driver.FindElement(By.Id("LastName")).SendKeys(lastName);
            driver.FindElement(By.Id("EnrollmentDate")).SendKeys(enrollmentDate);
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe("http://uitestpractice.com/Students/Index"));
            driver.Quit();
        }

        public static IEnumerable<object[]> GetData()//object array methodname
        {
            // Can generate dynamic data here
            //each object is array of different parameters
            //yield keyword keeps track of what it has already returned
            yield return new object[] { "Kamal", "Hasan", "12/15/2002" };
            yield return new object[] { "Dr", "Rajkumar", "01/02/2019" };
            yield return new object[] { "Amitabh", "Bachhan", "04/05/2021" };
        }
        [TestMethod]
        //to create csv: 
        // to copy csv file to output folder(bin/debug, we need to go to csv properties, and change advanced to 'copy always')
        //1st parameter provider means the one who reads the data
        //2nd parameter, is path of csv  file since we dnt have db, we dnt have conn string , so we give csv file       
        //3rd parameter is the file name to be given eg. data# csv, basically it should be the table name
        ///4th parameter- weather  we want to access data randomly or sequentially
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",    //add datasource attribute
            "|DataDirectory|\\Data.CSV",
            "data#csv", DataAccessMethod.Sequential)]
        public void DataDrivenTestingCSV()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com/Students/Create";
            //TestContext is a property which has a property called data row
            //DataRow is an array of object type where Datarow[0] refers to 1st column,datarow[2] refers to 2nd column and so on
            //to convert the DataRow object type to string, we use ToString method since sendkeys method can only take string
            driver.FindElement(By.Id("FirstName")).SendKeys(TestContext.DataRow[0].ToString());
            driver.FindElement(By.Id("LastName")).SendKeys(TestContext.DataRow[1].ToString());
            driver.FindElement(By.Id("EnrollmentDate")).SendKeys(TestContext.DataRow[2].ToString());
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe("http://uitestpractice.com/Students/Index"));
            driver.Quit();
        }




        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                    "|DataDirectory|\\Data.xml",
                    "cricketer", DataAccessMethod.Sequential)]
        public void DataDrivenTestingXML()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com/Students/Create";
            driver.FindElement(By.Id("FirstName")).SendKeys(TestContext.DataRow["firstName"].ToString());
            driver.FindElement(By.Id("LastName")).SendKeys(TestContext.DataRow["lastName"].ToString());
            driver.FindElement(By.Id("EnrollmentDate")).SendKeys(TestContext.DataRow["enrollmentDate"].ToString());
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe("http://uitestpractice.com/Students/Index"));
            driver.Quit();
        }


        [TestMethod]
        [DataSource("System.Data.sqlClient",    //datasource attribute
            "server=.\\SQLExpress;Database=DataDrivenTesting;User Id=sa;Password=Ankpro01*",//connection string
            "Student", DataAccessMethod.Sequential)]
        public void DataDrivenTestingSQL()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com/Students/Create";
            driver.FindElement(By.Id("FirstName")).SendKeys(TestContext.DataRow["fName"].ToString().Trim());//fName is column name
            driver.FindElement(By.Id("LastName")).SendKeys(TestContext.DataRow["lName"].ToString());
            driver.FindElement(By.Id("EnrollmentDate")).SendKeys(TestContext.DataRow["enrollmentDate"].ToString());
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe("http://uitestpractice.com/Students/Index"));
            driver.Quit();
        }
        [TestMethod]
        //For reading from excel, EP plus is installed from nuget , its a third party library 
        [DynamicData(nameof(ReadFromExcel), DynamicDataSourceType.Method)]
        public void DataDrivenTestingUsingExcel(string firstName, string lastName, string enrollmentDate)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com/Students/Create";
            driver.FindElement(By.Id("FirstName")).SendKeys(firstName);
            driver.FindElement(By.Id("LastName")).SendKeys(lastName);
            driver.FindElement(By.Id("EnrollmentDate")).SendKeys(enrollmentDate);
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe("http://uitestpractice.com/Students/Index"));
            driver.Quit();
        }


        public static IEnumerable<object[]> ReadFromExcel()
        {           
            
            //create an excel file separately and save in project location
            // to show all files in soln explorer> the file will come> right click> include in project
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            //when we use 'using' block within method>means, we are going to create a huge object and  it gets destroyed after use , idisposable disposes this object
            //create worksheet object
            using (ExcelPackage package = new ExcelPackage(new FileInfo("Data1.xlsx")))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets["Sheet1"];
                int rowCount = worksheet.Dimension.End.Row;//gives number of rows
                for (int i = 2; i <= rowCount; i++)
                {
                    yield return new object[] {
                        worksheet.Cells[i, 1].Value?.ToString().Trim(),//firstname
                        worksheet.Cells[i, 2].Value?.ToString().Trim(), //last name
                        worksheet.Cells[i, 3].Value?.ToString().Trim() //enrollment date
                    };

                }

            }
        }
    }
}
        
    
        

        