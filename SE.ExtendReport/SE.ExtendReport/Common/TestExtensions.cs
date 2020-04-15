using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SE.ExtendReport.Common
{
    public static class TestExtensions
    {
        public static void QuitFromTheBrowser(this IWebDriver driver)
        {
            Thread.Sleep(1000);
            driver.Close();
            driver.Quit();
        }

        public static void NavigateUrl(this IWebDriver driver)
        {
            //driver.Navigate().GoToUrl("https://admin-qa.shmarinas.com");
            driver.Navigate().GoToUrl("https://www.google.com/");
            driver.Manage().Window.Maximize();
            /*Login to SHM Site*/
            Thread.Sleep(2000);
        }

        public static void LoginIntoApplication(this IWebDriver driver)
        {
            driver.FindElement(By.Name("email")).SendKeys("admin@shm.com");
            driver.FindElement(By.Name("password")).SendKeys("3ngIq&22M(NX*y3");
            driver.FindElement(By.Name("submit")).Click();
            Thread.Sleep(2000);
        }

        public static void ChangeMarina(this IWebDriver driver, string marina)
        {
            /*Navigating to Safe Harbor Pier 121*/
            IWebElement marina_selector = driver.FindElement(By.Id("marinaSelector"));
            marina_selector.Click();

            var marina_selector_options = marina_selector.FindElements(By.CssSelector("ul > li"));

            var selectedMarina = marina_selector_options.FirstOrDefault(element => element.FindElement(By.TagName("span")).Text == marina);
            selectedMarina.Click();

            Thread.Sleep(2000);
        }
    }
}
