using ChangePassword.Models;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChangePassword.Controller
{
    public class PhantomController : Singleton<PhantomController>, IDisposable
    {
        private static readonly ILog logger =
              LogManager.GetLogger(typeof(DriverController));


        private PhantomJSDriver webDriver;

        public PhantomController()
        {

        }


        public void Login(Gmail gmail)
        {
            try
            {
                Init();
                string loginUrl = "https://accounts.google.com";
                webDriver.Navigate().GoToUrl(loginUrl);

                // id tab
                var emailInput = GetElement(webDriver, By.Id("Email"), 2);
                emailInput.Clear();
                emailInput.SendKeys(gmail.ID);
                Thread.Sleep(500);
                var nextBtn = GetElement(webDriver, By.Id("next"), 1);
                nextBtn.Click();
                Thread.Sleep(1000);

                // pass tab
                var passInput = GetElement(webDriver, By.Id("Passwd"), 1);
                passInput.Clear();
                passInput.SendKeys(gmail.OldPass);
                Thread.Sleep(500);
                var signInBtn = GetElement(webDriver, By.Id("signIn"), 1);
                signInBtn.Click();
                Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("ID: " + gmail.ID + ", {0}, stacktrace: {1}", ex.Message, ex.StackTrace);
            }

        }


        public void ChangePassword(Gmail gmail)
        {
            try
            {
                string changePassUrl = "https://myaccount.google.com/security/signinoptions/password";
                webDriver.Navigate().GoToUrl(changePassUrl);

                try
                {
                    var passInput = GetElement(webDriver, By.Id("Passwd"), 2);
                    passInput.Clear();
                    passInput.SendKeys(gmail.OldPass);
                    Thread.Sleep(500);
                    var signInBtn = GetElement(webDriver, By.Id("signIn"), 1);
                    signInBtn.Click();
                    Thread.Sleep(1000);
                }
                catch (Exception e)
                {
                    logger.InfoFormat("{0}, stacktrace: {1}", e.Message, e.StackTrace);
                }

                var passInputs = webDriver.FindElements(By.XPath("//input[@type='password']"));

                foreach (var passInput in passInputs)
                {
                    passInput.Clear();
                    passInput.SendKeys(gmail.NewPass);
                    Thread.Sleep(900);
                }

                //var divRole = webDriver.FindElement(By.XPath("//div[@role='button']"));
                //var spanBtn = divRole.FindElement(By.XPath(".//span"));
                var spanBtn = webDriver.FindElement(By.XPath("//div[@role='main']/div/div/div/div/div/content/span"));
                spanBtn.Click();

                Thread.Sleep(1500);
                //var divPass = webDriver.FindElement(By.XPath("//div[contains(text(), 'New password')]"));
                //var parent = divPass.FindElement(By.XPath(".."));
                //var pass1Input = parent.FindElement(By.XPath(".//input"));
                //pass1Input.Clear();
                //pass1Input.SendKeys(gmail.NewPass);
                //Thread.Sleep(900);


                //var divPass2 = webDriver.FindElement(By.XPath("//div[contains(text(), 'Confirm new password')]"));
                //var parent2 = divPass2.FindElement(By.XPath(".."));
                //var pass2Input = parent2.FindElement(By.XPath(".//input"));
                //pass2Input.Clear();
                //pass2Input.SendKeys(gmail.NewPass);
                //Thread.Sleep(900);

                //var changeBtn = webDriver.FindElement(By.XPath("//span[contains(text(), 'Change password')]"));
                //changeBtn.Click();
                //Thread.Sleep(600);


            }
            catch (Exception ex)
            {
                logger.ErrorFormat("ID: " + gmail.ID + ", {0}, stacktrace: {1}", ex.Message, ex.StackTrace);
                File.AppendAllLines(Directory.GetCurrentDirectory() + "\\error_accounts.txt", new string[] { gmail.ID });
            }
        }


        public void TurnOnLessSecureApp(Gmail gmail)
        {
            try
            {
                string changePassUrl = "https://myaccount.google.com/security#signin";
                webDriver.Navigate().GoToUrl(changePassUrl);

                try
                {
                    var passInput = GetElement(webDriver, By.Id("Passwd"), 2);
                    passInput.Clear();
                    passInput.SendKeys(gmail.OldPass);
                    Thread.Sleep(500);
                    var signInBtn = GetElement(webDriver, By.Id("signIn"), 1);
                    signInBtn.Click();
                    Thread.Sleep(1000);
                }
                catch (Exception e)
                {
                    logger.InfoFormat("{0}, stacktrace: {1}", e.Message, e.StackTrace);
                }

                var passInputs = webDriver.FindElements(By.XPath("//input[@type='password']"));

                foreach (var passInput in passInputs)
                {
                    passInput.Clear();
                    passInput.SendKeys(gmail.NewPass);
                    Thread.Sleep(900);
                }

                //var divRole = webDriver.FindElement(By.XPath("//div[@role='button']"));
                //var spanBtn = divRole.FindElement(By.XPath(".//span"));
                var spanBtn = webDriver.FindElement(By.XPath("//div[@role='main']/div/div/div/div/div/content/span"));
                spanBtn.Click();

                Thread.Sleep(1500);

            }
            catch (Exception ex)
            {
                logger.ErrorFormat("ID: " + gmail.ID + ", {0}, stacktrace: {1}", ex.Message, ex.StackTrace);
                File.AppendAllLines(Directory.GetCurrentDirectory() + "\\error_accounts.txt", new string[] { gmail.ID });
            }
        }





        #region private methods
        private void Init()
        {
            if (webDriver != null)
                webDriver.Quit();
            webDriver = new PhantomJSDriver();
        }


        private IWebElement GetElement(IWebDriver driver, By by, int sleep = 5)
        {
            if (sleep > 0)
            {
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1));
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(sleep));
                //return wait.Until(drv => drv.FindElement(by));
                return wait.Until(ExpectedConditions.ElementExists(by));
            }
            return driver.FindElement(by);

        }

        public void Dispose()
        {
            if (webDriver != null)
                webDriver.Quit();
        }

        #endregion
    }
}
