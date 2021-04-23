using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _01Selenium
{
    [TestClass]
    public class _09FileUploadingAndDownloading
    {
        [TestMethod]
            public void DownloadFileForChrome()
        {
            ChromeOptions op = new ChromeOptions();
            //need to change download default directory to our required path
            op.AddUserProfilePreference("download.default_directory", "C:\\Selenium_downloadfile");
            IWebDriver driver = new ChromeDriver(op);
            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com/Students/Widgets";
            driver.FindElement(By.CssSelector("button a")).Click();
            //Thread.Sleep(4000);
            bool fileExists = false;
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(4));
                //parul
                wait.Until<bool>(x => fileExists = File.Exists(@"C:\Selenium_downloadfile\images.png"));
                // wait.Until<IWebDriver, bool>(IsFileDownloaded( @"C:\Selenium_downloadfile\images.png"));
                Console.WriteLine(fileExists);
                FileInfo fileinfo = new FileInfo(@"C:\Selenium_downloadfile\images.png");
                Console.WriteLine(fileinfo.FullName);
                Console.WriteLine(fileinfo.Length);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);                
            }
            finally
            {
                if (fileExists)
                   
                    File.Delete(@"C:\Selenium_downloadfile\images.png");
            }
            
            driver.Quit();

        }
        [TestMethod]
        public void DownloadFileForFirefox()
        {
           
            FirefoxOptions firefoxOptions = new FirefoxOptions();
            firefoxOptions.SetPreference("browser.download.dir", "C:\\Selenium_downloadfile");
            firefoxOptions.SetPreference("browser.helperApps.neverAsk.saveToDisk", "image/png");
            IWebDriver driver = new FirefoxDriver(firefoxOptions);
            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com/Students/Widgets";
            driver.FindElement(By.CssSelector("button a")).Click();
            //Thread.Sleep(4000);
            bool fileExists = false;
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(4));
                wait.Until<bool>(x => fileExists = File.Exists(@"C:\Selenium_downloadfile\images.png"));
                // wait.Until<IWebDriver, bool>(IsFileDownloaded( @"C:\Selenium_downloadfile\images.png"));
                Console.WriteLine(fileExists);
                FileInfo fileinfo = new FileInfo(@"C:\Selenium_downloadfile\images.png");
                Console.WriteLine(fileinfo.FullName);
                Console.WriteLine(fileinfo.Length);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (fileExists)
                    //(File.Exists(@"C:\Selenium_downloadfile\images.png")==true)
                    File.Delete(@"C:\Selenium_downloadfile\images.png");
            }

            driver.Quit();

        }
        //public static bool IsFileDownloaded( string filepath)
        // {
        //  return File.Exists(filepath);
        //}
        [TestMethod]
        public void UploadFileForChrome()
        {

           
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com/Students/Widgets";
            driver.FindElement(By.Id("image_file")).SendKeys(@"C:\Selenium\sample image\image.png");
            driver.FindElement(By.XPath("//input[@value='Upload']")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(4));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.ClassName("ContactUs")));
            Console.WriteLine(driver.FindElement(By.XPath("//div[@class='ContactUs']/p")).Text);

            driver.Quit();

        }

    }
}
 