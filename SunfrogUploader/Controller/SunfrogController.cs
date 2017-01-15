using AutoArtist.Model;
using log4net;
using SunfrogUploader.Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunfrogUploader.Controller
{
    public class SunfrogController : Singleton<SunfrogController>
    {
        public CustomWeb web;
        
        private static readonly ILog logger = LogManager.GetLogger(typeof(SunfrogController));
        public string GuysLink { get; set; }
        public string AM { get; set; }

        public string SFAcc { get; set; }

        public SunfrogController()
        {
            web = new CustomWeb();
        }

        public bool Login(string sfAcc, string sfPass)
        {
            this.SFAcc = sfAcc;
            string url = "https://manager.sunfrogshirts.com/Login.cfm";
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("username", sfAcc);
            nvc.Add("password", sfPass);

            string result = web.SendRequest(url, "POST", nvc, true, "application/x-www-form-urlencoded");
            if (!string.IsNullOrEmpty(result))
            {
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(result);
                try
                {
                    string aff = doc.DocumentNode.SelectSingleNode("//a[@id='showAffiliateID']")
                        .SelectSingleNode(".//strong[@class='clearfix']").InnerText.Trim().Replace("?", "");
                    if (aff != null)
                        AM = aff;
                }
                catch
                {

                }

            }
            return IsLoggedIn(result);
        }


        private bool IsLoggedIn(string html)
        {
            try
            {
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);
                var node = doc.DocumentNode.SelectSingleNode("//input[@id='exampleInputEmail1']");
                if (null == node)
                    return true;

            }
            catch
            {

            }

            return false;
        }

        public string UplodNewMockup(string jsonData)
        {
            string uploadUrl = "https://manager.sunfrogshirts.com/Designer/php/upload-handler.cfm";
            return web.HttpUploadFileByJson(uploadUrl, jsonData);
        }

        public async Task<string> UpdateMockup(string jsonData)
        {
            string uploadUrl = "https://manager.sunfrogshirts.com/Designer/php/upload-handler.cfm";
            return await web.UpdateMockupByJson(uploadUrl, jsonData);
        }

    }
}
