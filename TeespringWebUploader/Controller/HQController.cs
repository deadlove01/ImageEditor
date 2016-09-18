using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeespringWebUploader.Model;

namespace TeespringWebUploader.Controller
{
    public class HQController : Singleton<HQController>
    {


        public void Login(string email, string pass)
        {
            WebController.Instance.Init();
            string loginUrl = "https://teespring.com/login";
            WebController.Instance.Navigate(loginUrl, 1000);
            WebController.Instance.SendText(email, By.XPath("//input[@name='email']"));
            WebController.Instance.SendText(pass, By.Name("//input[@name='password']"));
            WebController.Instance.ClickButton(By.XPath("//input[@class='button button--primary authentication__button js-email-login-submit']"));

        }
    }
}
