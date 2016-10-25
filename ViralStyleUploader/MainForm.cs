using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViralStyleUploader.Models;
using ViralStyleUploader.Utils;

namespace ViralStyleUploader
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CustomWeb web = new CustomWeb();
            NameValueCollection nvc = new NameValueCollection();

            string url = "https://viralstyle.com/design.beta/product-categories?api_campaign=false";

            string result = web.SendRequest(url, "GET", "viralstyle.com", null, true);

            //Console.WriteLine(result);
            url = "https://viralstyle.com/api/v2/token";

            nvc.Clear();
            //grant_type=client_credentials&client_id=frontend&client_secret=frontend&scope=public
            nvc.Add("grant_type", "client_credentials");
            nvc.Add("client_id", "frontend");
            nvc.Add("client_secret", "frontend");
            nvc.Add("scope", "public");
            result = web.SendRequest(url, "POST", "viralstyle.com", nvc, false, "application/x-www-form-urlencoded");
            dynamic jsonResult = JsonConvert.DeserializeObject(result);
            string token = jsonResult.access_token;
            Console.WriteLine(token);

            //nvc.Add("email", "deadlove011011@gmail.com");
            // nvc.Add("password", "19001560");
            string loginUrl = " https://viralstyle.com/api/v2/auth/login";

            LoginModel loginModel = new LoginModel("deadlove011011@gmail.com", "19001560", false);
            string loginJson = JsonConvert.SerializeObject(loginModel);

            result = web.SendRequestJsonType(loginUrl, "POST", "application/json", loginJson, token, true);
            // Console.WriteLine(result);

            string uploadUrl = "https://viralstyle.com/design.beta/upload-asset";
            nvc.Clear();
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
            result = web.HttpUploadFile(uploadUrl, @"C:\Users\RAVI\Desktop\Logo\BROWN.png", 
                "image_file", "image/png", nvc);
            dynamic uploadResult = JsonConvert.DeserializeObject(result);
            string campId = uploadResult.data.campaign_identifier;
            string imageId = Path.GetFileNameWithoutExtension( uploadResult.data.original_file.ToString());
            string id = uploadResult.data.identifier;

            string orgUrl = uploadResult.data.original_file;
            string resizeUrl = uploadResult.data.trimmed_image;
            string trimmedUrl = uploadResult.data.resized_image;
            Console.WriteLine(result);


            string title = "this is my title";
            string description = "this is another description";
           // string token = "tkMyMmQDXpeeLkFaLv5wb3lPx0KdEsNV269PnepU";
            string uniqueCampUrl = "here-is-my-url-"+ StringUtil.RandomString(8);
            string jsonData = File.ReadAllText(Directory.GetCurrentDirectory() + "\\data.json");

            nvc.Clear();
            result = web.SendRequest("https://viralstyle.com/design.beta", "GET", nvc);
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(result);
           
            string newToken = doc.DocumentNode.SelectSingleNode("//input[@id='_token']")
                .GetAttributeValue("value", string.Empty);
            System.Drawing.Image img = System.Drawing.Image.FromFile(@"C:\Users\RAVI\Desktop\Logo\BROWN.png");
            string base64String;
            using (var ms = new MemoryStream())
            {
                img.Save(ms, img.RawFormat);
                base64String = "data:image/png;base64,"+ Convert.ToBase64String(ms.ToArray());
            }
            img.Dispose();
            jsonData = jsonData.Replace("{CAMP_ID}", campId)
                .Replace("{IMAGE_ID}", id)
                .Replace("{RESIZE_IMAGE_URL}", resizeUrl)
                .Replace("{TRIMMED_IMAGE_URL}", trimmedUrl)
                .Replace("{ORG_IMAGE_URL}", orgUrl)
                .Replace("{TITLE}", title)
                .Replace("{DESCRIPTION}", description)
                .Replace("{CAMP_URL}", uniqueCampUrl)
                .Replace("{TOKEN}", newToken)
                .Replace("{IMAGE_64}", base64String);


            // check url
            dynamic urlObj = new ExpandoObject();
            urlObj.url = uniqueCampUrl;
            string checkResult = web.HttpUploadFileByJson("https://viralstyle.com/design.beta/check-url", 
                JsonConvert.SerializeObject(urlObj), token, newToken);
            Console.WriteLine(result);
            string campUrl = "https://viralstyle.com/api/v2/designer/store";
            result = web.HttpUploadFileByJson(campUrl, jsonData, token, newToken);
            Console.WriteLine(result);
        }
    }
}
