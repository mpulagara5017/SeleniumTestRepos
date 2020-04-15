
using AventStack.ExtentReports;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtentReportsDemo
{
    [TestFixture]
    public class CreatingStepLogs
    {
        //public ExtentReports extent;
        //public ExtentTest test;

        //[OneTimeSetUp]
        //public void StartReport()
        //{
        //    string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
        //    string actualPath = path.Substring(0, path.LastIndexOf("bin"));
        //    string projectPath = new Uri(actualPath).LocalPath;
        //    string reportPath = projectPath + "Reports\\ExtentStepLogs.html";
        //    extent = new ExtentReports(reportPath, true);
        //}

        //[Test]
        //public void StepLogsGeneration()
        //{
        //    test = extent.StartTest("StepLogsGeneration");
        //    test.Log(LogStatus.Info, "StartTest() method will return the Extent Test object ");
        //    test.Log(LogStatus.Info, "I am in actual test method");
        //    test.Log(LogStatus.Info, "We Can Write The Actual Test Logic In This Test");
        //}

        //[OneTimeTearDown]
        //public void TearDown()
        //{
        //    extent.EndTest(test);
        //    test.Log(LogStatus.Info, "EndTest() method will stop capturing information about the test log");
        //    extent.Flush();
        //    test.Log(LogStatus.Info, "Flush() method of ExtentReports wil push/write everything to the document");
        //    test.Log(LogStatus.Info, "Close() method will clear/close all resource of the ExtentReports object");
        //    extent.Close();
        //}
    }
}