using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using teste.StepDefinitions;

namespace teste.Drivers
{
    internal class Browser
    {
        ChromeOptions chromeOptions;
        IWebDriver driver;
        public void abreNavegador(IWebDriver driver, String url) 
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
        }

        public void driveClose(IWebDriver driver)
        {
            driver.Close();
        }

    }
}
