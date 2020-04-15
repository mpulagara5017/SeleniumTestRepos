using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SE.ExtendReport.Common
{
    [TestClass]
    public class BaseWebTest
    {
        private readonly IWebDriver _driver;
        public BaseWebTest()
        {
            _driver = new ChromeDriver();
            _driver.NavigateUrl();
        }
    }
}
