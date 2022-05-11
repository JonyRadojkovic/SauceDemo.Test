using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace SauceDemo.Test
{
    public class BaseTest : IDisposable
    {
        protected IWebDriver driver;
        protected IWebElement element;
        protected const string url = "https://www.saucedemo.com/";
        bool disposed;

        public BaseTest()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        protected void Navigate(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }
            if (disposing)
            {
                driver.Quit();
            }

            disposed = true;
        }
        ~BaseTest()
        {
            Dispose(false);
        }
    }
}
