using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TeespringWebUploader.Model;

namespace TeespringWebUploader.Controller
{
    public class WebController : Singleton<WebController>
    {
        private IWebDriver webDriver;
        public WebController()
        {
        }


        public void Init()
        {
            if (webDriver != null)
                webDriver.Quit();

            webDriver = new ChromeDriver();
            webDriver.Manage().Window.Maximize();
        }


        public void Navigate(string url, int sleep=500)
        {
            webDriver.Navigate().GoToUrl(url);
            Thread.Sleep(sleep);
        }

        public void SendText(string text, By by, int sleep=500)
        {
            var ele = GetElement(webDriver, by, 10);
            // var ele = webDriver.FindElement(by);
            ele.Click();
           
            ele.Clear();
            ele.SendKeys(text);
            Thread.Sleep(sleep);
        }

        public void ClickButton(By by, int sleep=1000)
        {
            var ele = webDriver.FindElement(by);
            ele.Click();
            Thread.Sleep(sleep);
        }

        private IWebElement GetElement(IWebDriver driver, By by, int timeoutInSeconds=0)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(ExpectedConditions.ElementExists(by));
                //return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }
    }
}
