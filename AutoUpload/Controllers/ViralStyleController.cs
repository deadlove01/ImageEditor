using AutoUpload.Models;
using log4net;
using Newtonsoft.Json;
using RaviLib.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoUpload.Controllers
{
    public class ViralStyleController : Singleton<ViralStyleController>
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(ViralStyleController));
        private CustomWeb web;
        private string token;

        public ViralStyleController()
        {
            web = new CustomWeb();
        }

        public void GetCookieSession()
        {
            try
            {
                string url = "https://viralstyle.com/design.beta/product-categories?api_campaign=false";
                
                string result = web.SendRequest(url, "GET", "viralstyle.com", null, true);
            
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("Error: {0}, stacktrace: {1}", ex.Message, ex.StackTrace);
            }
        }

        public void GetToken()
        {
            try
            {
                string url = "https://viralstyle.com/api/v2/token";
                NameValueCollection nvc = new NameValueCollection();
                //grant_type=client_credentials&client_id=frontend&client_secret=frontend&scope=public
                nvc.Add("grant_type", "client_credentials");
                nvc.Add("client_id", "frontend");
                nvc.Add("client_secret", "frontend");
                nvc.Add("scope", "public");
                string result = web.SendRequest(url, "POST", "viralstyle.com", nvc, false, "application/x-www-form-urlencoded");
                dynamic jsonResult = JsonConvert.DeserializeObject(result);
                token = jsonResult.access_token;
                Console.WriteLine(token);
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("Error: {0}, stacktrace: {1}", ex.Message, ex.StackTrace);
            }
        }

        public void Login()
        {
            try
            {
                //{"email_address":"deadlove011011@gmail.com","password":"19001560","remember":true}
                string url = "https://viralstyle.com/api/v2/auth/login";
                dynamic reqModel = new ExpandoObject();
                reqModel.email_address = "deadlove011011@gmail.com";
                reqModel.password = "19001560";
                reqModel.remember = true;
                string result = web.SendRequestByJson(url, "POST", "viralstyle.com",
                    "Bearer " + token, JsonConvert.SerializeObject(reqModel));
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("Error: {0}, stacktrace: {1}", ex.Message, ex.StackTrace);
            }
        }

        public void CheckUrl(string checkUrl)
        {
            try
            {
                //{"email_address":"deadlove011011@gmail.com","password":"19001560","remember":true}
                string url = "https://viralstyle.com/design.beta/check-url";
                dynamic reqModel = new ExpandoObject();
                reqModel.url = checkUrl;
                string result = web.SendRequestByJson(url, "POST", "viralstyle.com",
                    "Bearer " + token, JsonConvert.SerializeObject(reqModel));
                dynamic jsonResult = JsonConvert.DeserializeObject(result);
                Console.WriteLine(jsonResult.status);
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("Error: {0}, stacktrace: {1}", ex.Message, ex.StackTrace);
            }
        }


        public void RequestBeta()
        {
            try
            {
                string productUrl = "https://viralstyle.com/design.beta/product-categories?api_campaign=false";
                string result = web.SendRequest(productUrl, "GET", "viralstyle.com");
                //Console.WriteLine(result);

                result = web.SendRequest("https://viralstyle.com/design.beta/pricing?goal=10", "GET", "viralstyle.com");
               // Console.WriteLine(result);
                //{"email_address":"deadlove011011@gmail.com","password":"19001560","remember":true}
                string url = "https://viralstyle.com/design.beta";
                result = web.SendRequest(url, "GET", "viralstyle.com");
                //Console.WriteLine(result);
                
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("Error: {0}, stacktrace: {1}", ex.Message, ex.StackTrace);
            }
        }

        public void Upload()
        {
            try
            {
                //{"email_address":"deadlove011011@gmail.com","password":"19001560","remember":true}
                string url = "https://viralstyle.com/design.beta/upload-asset";
                NameValueCollection nvc = new NameValueCollection();
                //nvc.Add("extension", "png");
                //nvc.Add("width", "218");
                //nvc.Add("identifier", "NEW");
                //nvc.Add("campaign_identifier", "NEW");
                //nvc.Add("sublimation", "0");
                //nvc.Add("is_phone_case", "0");
                //nvc.Add("is_embroidery", "0");
                //nvc.Add("product_id", "1");

                nvc.Add("is_api_order", "0");
                nvc.Add("product_id", "5");
                nvc.Add("is_embroidery", "0");
                nvc.Add("is_phone_case", "0");
                nvc.Add("sublimation", "0");
                nvc.Add("campaign_identifier", "NEW");
                nvc.Add("identifier", "NEW");
                nvc.Add("sublimation", "0");
                nvc.Add("width", "258");
                nvc.Add("extension", "png");
                //string result = web.HttpUploadFile(url, 
                //    @"C:\Users\RAVI\Desktop\Logo\BAKER.png", "image_file", "image/png", nvc);

                string result = web.HttpUploadFile2(url, @"C:\Users\RAVI\Desktop\Logo\BAKER.png",
               "image_file", "image/png", nvc);
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("Error: {0}, stacktrace: {1}", ex.Message, ex.StackTrace);
            }
        }

    }
}
