using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeespringUploader.Model;

namespace TeespringUploader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IWebDriver webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("https://teespring.com/login");

            var divRoot = webDriver.FindElement(By.XPath("//div[@class='authentication__standalone js-user-auth-standalone authentication--email authentication--login_open']"));
            var divAuth = divRoot.FindElement(By.XPath("//div[@class='authentication authentication--login js-user-login']"));
            var emailInput = divAuth.FindElement(By.Name("email"));
            DivClick(webDriver, emailInput, "deadlove011011@gmail.com", 1000);

            var passInput = divAuth.FindElement(By.Name("password"));
            DivClick(webDriver, passInput, "19001560", 1000);

            var loginBtn = divAuth.FindElement(By.XPath("//input[@class='button button--primary authentication__button js-email-login-submit']"));
            loginBtn.Click();
            Thread.Sleep(1500);


            var tag = webDriver.FindElement(By.XPath("//meta[@name='csrf-token']"));

            CookieContainer container = new CookieContainer();
            foreach (var cc in webDriver.Manage().Cookies.AllCookies)
            {
                container.Add(new System.Net.Cookie(cc.Name, cc.Value, cc.Path, cc.Domain));
            }
            
            CustomWeb web = new CustomWeb(container);
            string token = tag.GetAttribute("content");
            web.TOKEN = token;
            
            //string result = web.SendRequest("https://teespring.com/login", "GET", null, true);
            //var doc = new HtmlAgilityPack.HtmlDocument();
            //doc.LoadHtml(result);
            //var metaNode = doc.DocumentNode.SelectSingleNode("//meta[@name='csrf-token']");
            //token = metaNode.GetAttributeValue("content", string.Empty);
            ////web.TOKEN = token;

            //var htmlWeb = new HtmlAgilityPack.HtmlWeb();
            //doc = htmlWeb.Load("https://teespring.com/login");
            //metaNode = doc.DocumentNode.SelectSingleNode("//meta[@name='csrf-token']");
            //token = metaNode.GetAttributeValue("content", string.Empty);
            ////web.TOKEN = token;

            //string url = "https://teespring.com/sessions";
            NameValueCollection nvc = new NameValueCollection();
            //nvc.Add("email", "deadlove011011@gmail.com");
            //nvc.Add("password", "19001560");

            //string result = web.SendRequest(url, "POST", nvc, false, "application/x-www-form-urlencoded");

            //Console.WriteLine("login: " + result);

         
           // web.CookieContainer.Add(new Cookie("csrftoken", token, "/", "teespring.com"));
            //Console.WriteLine("result: "+result);

            string responseUrl = "";
            string result = web.SendRequest("https://teespring.com/designs", "GET", null, ref responseUrl);
            Console.WriteLine("response url: "+responseUrl);

            // signed request
            string imageName = RandomStringOnly(8) + ".png";
            string signedUrl = "https://teespring.com/designs/sign_s3?s3_object_type=image/png&s3_object_name=" + imageName;
            result = web.SendRequest(signedUrl, "GET", null);
            Console.WriteLine("signed url: "+ result);
            SignedResponse signedRes = JsonConvert.DeserializeObject<SignedResponse>(result);
            Console.WriteLine(signedUrl);

            // regist 1 signal
            string sign1Url = WebUtility.UrlDecode(signedRes.signed_request);
            Console.WriteLine(sign1Url);
            nvc.Clear();
            string tempUrl = sign1Url.Split('?')[1];
            string[] temp2 = tempUrl.Split('&');
            //nvc.Add("X-Amz-Algorithm", temp2[0].Replace("X-Amz-Algorithm=", ""));
            //nvc.Add("X-Amz-Credential", temp2[1].Replace("X-Amz-Algorithm=", ""));
            //nvc.Add("X-Amz-Date", temp2[2].Replace("X-Amz-Algorithm=", ""));
            //nvc.Add("X-Amz-Expires", temp2[3].Replace("X-Amz-Algorithm=", ""));
            //nvc.Add("X-Amz-SignedHeaders", temp2[4].Replace("X-Amz-Algorithm=", ""));
            //nvc.Add("x-amz-acl", temp2[5].Replace("X-Amz-Algorithm=", ""));
            //nvc.Add("X-Amz-Signature", temp2[6].Replace("X-Amz-Algorithm=", ""));
            nvc.Add("PNG", 
                ImageToBase64(Image.FromFile(@"D:\Auto\Logo\test.png"),
                System.Drawing.Imaging.ImageFormat.Png));
            result = web.SendCustomRequest(sign1Url, "OPTIONS", "teespring-usercontent.s3.amazonaws.com", null, true, "PUT");
            result = web.SendCustomRequest2(sign1Url, "PUT", "teespring-usercontent.s3.amazonaws.com", @"D:\Auto\Logo\test.png", false, "", false, "image/png");
            // result = web.SendCustomRequest(sign1Url, "POST", "teespring-usercontent.s3.amazonaws.com", null);
            Console.WriteLine("sign1url result: "+result);
            string uploadUrl = responseUrl.Replace("edit", "uploads");

            // string uploadImageUrl = "https://teespring.com/designs/lu32t4/uploads";
            string randName = RandomStringOnly(8);
            //LogoModel logo = new LogoModel(@"D:\Auto\Logo\1.png", "png");
            LogoModel logo = new LogoModel(imageName, "png");
            result = web.HttpUploadFileByJson(uploadUrl, JsonConvert.SerializeObject(logo));
            Console.WriteLine(result);


            // check valid url
            string title = "this-is-ultimate-113";
            string checkUrl = "https://teespring.com/url/availability?url="+title;
            result = web.SendCustomRequest(checkUrl, "GET", "teespring.com", null);
            Console.WriteLine("check url result: "+ result);


            // put upload design
            string uploadDesignUrl = responseUrl.Replace("/edit", "");
            string lookupId = uploadDesignUrl.Substring(uploadDesignUrl.LastIndexOf("/")+1);
            //UploadDesignParameters desginParams = new UploadDesignParameters(lookupId, title.Replace("-", " "),
            //    title, "I will write some description on here!", "#ipshirt", imageName,
            //    "https://teespring-usercontent.s3.amazonaws.com/"+ imageName, "test.png");

            DesignParameter designs = new DesignParameter(lookupId, title.Replace("-", " "),
                title, "I will write some description on here!", "#ipshirt", imageName, 
                "https://teespring-usercontent.s3.amazonaws.com/" + imageName, "test.png");

            
            string uploadResult = web.SendCustomRequest(uploadDesignUrl, "PUT", "teespring.com",
                designs.ConvertToNVC(), false, "", false, "application/x-www-form-urlencoded", "application/json");
            //dynamic uploadResult = web.SendRequestWithStringData(uploadDesignUrl, "PUT", "teespring.com",
            //   desginParams.ToString(), false, "", false, "application/json");
            Console.WriteLine("upload reuslt: "+uploadResult);
            // camp id
            dynamic dResult = JsonConvert.DeserializeObject(uploadResult);
            string campId = dResult.campaign_id;
            // launch campaign
            string launchUrl = string.Format("https://teespring.com/campaigns/{0}/launch", campId);
            dynamic launchResult = web.SendRequestWithStringData(launchUrl, "POST", "teespring.com",
              "partnership=", false, "", false, "application/x-www-form-urlencoded; charset=UTF-8");
            //Console.WriteLine(launchResult);
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(launchResult);
            var metaNode = doc.DocumentNode.SelectSingleNode("//meta[@name='csrf-token']");
            token = metaNode.GetAttributeValue("content", string.Empty);
            web.TOKEN = token;

            string url = "https://teespring.com/sessions";
            nvc.Clear();
            nvc.Add("email", "deadlove011011@gmail.com");
            nvc.Add("password", "19001560");

            result = web.SendRequest(url, "POST", nvc, false, "application/x-www-form-urlencoded");


            Console.WriteLine("login2 : " + result);

            launchResult = web.SendRequestWithStringData(launchUrl, "POST", "teespring.com",
           "partnership=", false, "", false, "application/x-www-form-urlencoded; charset=UTF-8");

            string readyUrl = "https://teespring.com/designs/" + lookupId + "/assets_ready";
            //for (int i = 0; i < 5; i++)
            //{
                string finalResult = web.SendRequest(readyUrl, "GET", null);
                Console.WriteLine(finalResult);
                Thread.Sleep(2000);
            //}
        }

        public static string RandomStringOnly(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public string ImageToBase64(Image image,
        System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }


        private IWebElement GetElement(IWebDriver driver, By by, int sleep = 0)
        {
            if (sleep > 0)
            {
                return new WebDriverWait(driver, TimeSpan.FromSeconds(sleep)).Until(ExpectedConditions.ElementExists(by));
            }

            return driver.FindElement(by);
        }

        private IWebElement GetElementVisible(IWebDriver driver, By by, int sleep = 0)
        {
            if (sleep > 0)
            {
                return new WebDriverWait(driver, TimeSpan.FromSeconds(sleep)).Until(ExpectedConditions.ElementIsVisible(by));
            }

            return driver.FindElement(by);
        }


        private void DivClick(IWebDriver driver, IWebElement div, string content, int sleep = 0)
        {
            try
            {
                Actions actions = new Actions(driver);
                actions.MoveToElement(div);
                actions.Click();
                actions.SendKeys(content);
                actions.Build().Perform();

                if (sleep > 0)
                    Thread.Sleep(sleep);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //logger.Error(ex.Message);
                //logger.Error(ex.StackTrace);
            }

        }


        private void DivClick(IWebDriver driver, IWebElement div, int sleep = 0)
        {
            try
            {
                Actions actions = new Actions(driver);
                actions.MoveToElement(div);
                actions.Click();
                actions.Build().Perform();

                if (sleep > 0)
                    Thread.Sleep(sleep);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //logger.Error(ex.Message);
                //logger.Error(ex.StackTrace);
            }

        }

    }
}
