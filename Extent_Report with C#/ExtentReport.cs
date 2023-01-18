using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SeleniumCsharp.Tests
{
    [TestFixture]
    public class ExtentReport
    {
        ExtentReports extent = null;
       
        [OneTimeSetUp]
        public void ExtentStart()
        {
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\Lenovo\source\repos\SeleniumCsharp\SeleniumCsharp\Reports\Demo05.html");
            extent.AttachReporter(htmlReporter);

        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            extent.Flush();
        }


        [Test]
        public void Test1()
        {

            ExtentTest test = extent.CreateTest("Test1").Info("Test Started");

            IWebDriver driver = null;

            driver = new ChromeDriver();
            test.Log(Status.Info, "Chrome Browser Lauched");
            Thread.Sleep(3000);
            driver.Manage().Window.Maximize();
            Thread.Sleep(3000);

            driver.Url = "https://www.youtube.com/";
            Thread.Sleep(3000);
            test.Log(Status.Info, "Youtube URL launched");
            driver.FindElement(By.Id("search")).SendKeys("API Testing");


        }


    }
}
