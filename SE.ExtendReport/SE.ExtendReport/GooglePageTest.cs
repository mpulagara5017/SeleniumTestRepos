using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SE.ExtendReport.Common;
using NUnit.Framework;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework.Interfaces;
using System.Net.Mail;
using System.Linq;
using OpenQA.Selenium.Support.PageObjects;

namespace SE.ExtendReport
{
    [TestFixture]
    public class GooglePageTest
    {
        private static IWebDriver _driver;
        private ExtentReports extent = new ExtentReports();
        public ExtentTest test;

        //[SetUp]
        //public void SetUp()
        //{
        //    _driver.NavigateUrl();
        //}

        [OneTimeSetUp]
        public void StartReport()
        {
            ChromeOptions chromeOptions = new ChromeOptions()
            {
                BinaryLocation = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe"
            };
            _driver = new ChromeDriver(chromeOptions);
            _driver.NavigateUrl();
            var domainPath = string.Format("{0}TestResult\\", AppDomain.CurrentDomain.SetupInformation.ApplicationBase);
            var reporter = new ExtentHtmlReporter(domainPath);
            extent.AttachReporter(reporter);
        }

        [Test]
        public void LoginGmail()
        {

            test = extent.CreateTest("LoginGmail");
            _driver.FindElement(By.ClassName("gb_g")).Click();
            Thread.Sleep(2000);
            test.Pass("Navigate to gmail");
            _driver.FindElement(By.LinkText("Sign in")).Click();
            //_driver.SwitchTo().Window("Gmail");
            test.Pass("Switch to gmail");
            //_driver.FindElement(By.Id("identifierId")).SendKeys("murali.5017@gmail.com");
            //test.Pass("entered username");
            Thread.Sleep(5000);
        }

        [Test]
        public void LoadGooglePage()
        {
            test = extent.CreateTest("LoadGooglePage");
            List<string> searches = CommonTestHelper.GetTestData("LoadGooglePage");
            test.Log(Status.Info, "This step shows usage of log(status, details)");

            foreach (var search in searches)
            {
                _driver.FindElement(By.Name("q")).SendKeys(search);

                Thread.Sleep(1000);

                IWebElement searchBtn = _driver.FindElement(By.ClassName("gNO89b"));
                searchBtn.Click();
                test.Info("Search with " + search);
                _driver.Navigate().Back();
                Thread.Sleep(1000);
                test.Pass("Search with " + search);
            }
        }

        //[TearDown]
        //public void GetResult()
        //{
        //    _driver.QuitFromTheBrowser();
        //    extent.Flush();
        //    Thread.Sleep(2000);
        //    //var status = TestContext.CurrentContext.Result.Outcome.Status;
        //    //var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
        //    //var errorMessage = TestContext.CurrentContext.Result.Message;

        //    //if (status == TestStatus.Failed)
        //    //{
        //    //    test.Log(Status.Fail, stackTrace + errorMessage);
        //    //}
        //    //extent.RemoveTest(test);
        //}

        [OneTimeTearDown]
        public void EndReport()
        {
            _driver.QuitFromTheBrowser();
            extent.Flush();
            Thread.Sleep(2000);
            //Send_Report_In_Mail();
        }


        public void Send_Report_In_Mail()
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("murali.pulagara@tekzenit.com");
            mail.To.Add("janaki.Lakshmi@tekzenit.com");
            mail.To.Add("murali.pulagara@tekzenit.com");

            StringBuilder TimeAndDate = new StringBuilder(DateTime.Now.ToString());
            TimeAndDate.Replace("/", "_");
            TimeAndDate.Replace(":", "_");

            mail.Subject = "Automation Test Report_" + TimeAndDate;

            mail.Body = "Please find the attached report to get details.";

            string actualPath = string.Format("{0}TestResult\\", AppDomain.CurrentDomain.SetupInformation.ApplicationBase);

            var mostRecentlyModified = Directory.GetFiles(actualPath, "*.html")
            .Select(f => new FileInfo(f).FullName).ToList();
            //.OrderByDescending(fi => fi.LastWriteTime)
            //.First()
            //.FullName;
            foreach (var attach in mostRecentlyModified)
            {
                Attachment attachment;
                attachment = new Attachment(attach);
                mail.Attachments.Add(attachment);
            }


            SmtpClient SmtpServer = new SmtpClient("smtp.mandrillapp.com");
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("network.admins@tekzenit.com", "qcBeBK_dlJIqSg5w6HZljQ");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
        }
    }
}
