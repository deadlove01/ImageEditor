using AutoUpload.Models;
using AutoUpload.Models.Viralstyle;
using AutoUpload.Utils;
using log4net;
using Newtonsoft.Json;
using RaviLib.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViralStyleUploader.Utils;

namespace AutoUpload.Controllers
{
    public class ViralStyleController : Singleton<ViralStyleController>
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(ViralStyleController));
        private CustomWeb web;
        private string token;
        private string newToken;
        private dynamic uploadAssetResult;
        public bool IsLogged { get; set; }
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

        public void GetNewToken()
        {
            try
            {
                string url = "https://viralstyle.com/design.beta";
                NameValueCollection nvc = new NameValueCollection();
                string result = web.SendRequest(url, "GET", nvc);
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(result);

                newToken =  doc.DocumentNode.SelectSingleNode("//input[@id='_token']")
                    .GetAttributeValue("value", string.Empty);
                
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("Error: {0}, stacktrace: {1}", ex.Message, ex.StackTrace);
            }
        }

        public void Login(string email, string password)
        {
            try
            {
                //{"email_address":"deadlove011011@gmail.com","password":"19001560","remember":true}
                //string url = "https://viralstyle.com/api/v2/auth/login";
                //dynamic reqModel = new ExpandoObject();
                //reqModel.email_address = email;
                //reqModel.password = password;
                //reqModel.remember = true;
                //string result = web.SendRequestJsonType(url, "POST", "viralstyle.com",
                //    "Bearer " + token, JsonConvert.SerializeObject(reqModel));
                //Console.WriteLine(result);

                string loginUrl = "https://viralstyle.com/api/v2/auth/login";

                LoginModel loginModel = new LoginModel("deadlove011011@gmail.com", "19001560", false);
                string loginJson = JsonConvert.SerializeObject(loginModel);
                string result = web.SendRequestJsonType(loginUrl, "POST", "application/json", 
                    loginJson, token, true);
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("Error: {0}, stacktrace: {1}", ex.Message, ex.StackTrace);
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        public void CheckUrl(string checkUrl, string newToken)
        {
            try
            {
                //{"email_address":"deadlove011011@gmail.com","password":"19001560","remember":true}
                string uniqueCampUrl = "here-is-my-url-" + StringUtil.RandomString(8);
                string url = "https://viralstyle.com/design.beta/check-url";
                dynamic urlObj = new ExpandoObject();
                urlObj.url = uniqueCampUrl;
                string checkResult = web.HttpUploadFileByJson(url,
                    JsonConvert.SerializeObject(urlObj), token, newToken);
                Console.WriteLine(checkResult);
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

        public void Upload(string logoPath)
        {
            try
            {
                string url = "https://viralstyle.com/design.beta/upload-asset";
                NameValueCollection nvc = new NameValueCollection();
                
                nvc.Add("product_id", "1");
                nvc.Add("is_embroidery", "0");
                nvc.Add("is_phone_case", "0");
                nvc.Add("sublimation", "0");
                nvc.Add("campaign_identifier", "NEW");
                nvc.Add("identifier", "NEW");
                nvc.Add("sublimation", "0");
                nvc.Add("width", "218");
                nvc.Add("extension", "png");
                //string result = web.HttpUploadFile(url, 
                //    @"C:\Users\RAVI\Desktop\Logo\BAKER.png", "image_file", "image/png", nvc);

                string result = web.HttpUploadFile(url, logoPath,
               "image_file", "image/png", nvc);
                Console.WriteLine(result);

                uploadAssetResult = JsonConvert.DeserializeObject(result);
                //string campId = uploadResult.data.campaign_identifier;
                //string imageId = Path.GetFileNameWithoutExtension(uploadResult.data.original_file.ToString());
                //string id = uploadResult.data.identifier;

                //string orgUrl = uploadResult.data.original_file;
                //string resizeUrl = uploadResult.data.trimmed_image;
                //string trimmedUrl = uploadResult.data.resized_image;

            }
            catch (Exception ex)
            {
                logger.ErrorFormat("Error: {0}, stacktrace: {1}", ex.Message, ex.StackTrace);
            }
        }

        public void UploadStore(Template template, string logoPath)
        {
            try
            {
                // string token = "tkMyMmQDXpeeLkFaLv5wb3lPx0KdEsNV269PnepU";
                int tryCount = 0;               
                string uniqueCampUrl = template.CampUrl+"-" + StringUtil.RandomString(8);

                // check url
                dynamic urlObj = new ExpandoObject();
                urlObj.url = uniqueCampUrl;
                string checkResult = web.HttpUploadFileByJson("https://viralstyle.com/design.beta/check-url",
                    JsonConvert.SerializeObject(urlObj), token, newToken);
                Console.WriteLine(checkResult);

                //string jsonData = File.ReadAllText(Directory.GetCurrentDirectory() + "\\data3.json");
                //System.Drawing.Image img = System.Drawing.Image.FromFile(logoPath);
                string newPath = Directory.GetCurrentDirectory() + "\\" + Path.GetFileNameWithoutExtension(logoPath)
                    + "_temp.png";
                Resize(logoPath, newPath, 0.5f);
                string base64String;
                System.Drawing.Image img = System.Drawing.Image.FromFile(newPath);
                using (var ms = new MemoryStream())
                {
                    img.Save(ms, img.RawFormat);
                    base64String = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                }
                //img.Dispose();
                img.Dispose();
                File.Delete(newPath);

                string campId = uploadAssetResult.data.campaign_identifier;
                string imageId = Path.GetFileNameWithoutExtension(uploadAssetResult.data.original_file.ToString());
                string id = uploadAssetResult.data.identifier;

                string orgUrl = uploadAssetResult.data.original_file;
                string resizeUrl = uploadAssetResult.data.trimmed_image;
                string trimmedUrl = uploadAssetResult.data.resized_image;

                /*
                 * camp time format 
                 * \"campaign_end_date\":\"Friday, Nov. 18 2016 - 21 PM\",
\"campaign_end_date_obj\":\"2016-11-18T21:18:37.818Z\",\"campaign_end_date_utc\":1479503917819,
*/
                string jsonData = File.ReadAllText(Directory.GetCurrentDirectory() + "\\data3.json");
                jsonData = jsonData.Replace("\r\n", "");
                var tempData = JsonConvert.DeserializeObject<ViralStyleRequestJsonData>(jsonData);
                ViralStyleRequestData data = new ViralStyleRequestData();
                data._token = tempData._token;
                data.campaign_data = JsonConvert.DeserializeObject<Campaign>(tempData.campaign_data);

                //string loadedJsonData = File.ReadAllText(Directory.GetCurrentDirectory() + "\\data4.json");
                //    jsonData = jsonData.Replace("\\", "").Replace("\r\n", "");
                //var data = JsonConvert.DeserializeObject<ViralStyleRequestData>(jsonData);
                DateTime now = DateTime.Now;
                DateTime endDate = now.AddDays(7);
                data.campaign_data.campaign_end_date = DateTimeUtil.DateToStrCampEndDate(endDate);
                data.campaign_data.campaign_end_date_obj = DateTimeUtil.DateToStrCampEndDateObj(endDate);
                data.campaign_data.campaign_end_date_utc = DateTimeUtil.DateToCampUTC(endDate);
                data.campaign_data.campaignUniqueId = campId;
                data.campaign_data.imageIdentifier = id;
                data.campaign_data.mainProduct.front.designerItems[0].value = resizeUrl;
                data.campaign_data.mainProduct.front.designerItems[0].imageData.original_url = trimmedUrl;
                data.campaign_data.mainProduct.front.designerItems[0].imageData.thumbnail_url = resizeUrl;
                data.campaign_data.mainProduct.front.designerItems[0].imageData.original_upload_url = orgUrl;
                data.campaign_data.campaign_length = 7;
                data.campaign_data.campaign_name = template.Title;
                data.campaign_data.campaign_description = template.Description;
                data.campaign_data.campaign_url = uniqueCampUrl;
                data._token = newToken;
                data.campaign_data.design.front.upscaled = base64String;

                tempData.campaign_data = JsonConvert.SerializeObject(data.campaign_data);
                string encodeJson = JsonConvert.SerializeObject(tempData);
                //jsonData = jsonData.Replace("\\", "").Replace("\r\n", "");
                //jsonData = jsonData.Replace("\r\n", "");
                //jsonData = jsonData.Replace("{CAMP_ID}", campId)
                //    .Replace("{IMAGE_ID}", id)
                //    .Replace("{RESIZE_IMAGE_URL}", resizeUrl)
                //    .Replace("{TRIMMED_IMAGE_URL}", trimmedUrl)
                //    .Replace("{ORG_IMAGE_URL}", orgUrl)
                //    .Replace("{TITLE}", template.Title)
                //    .Replace("{DESCRIPTION}", template.Description)
                //    .Replace("{CAMP_URL}", uniqueCampUrl)
                //    .Replace("{TOKEN}", newToken)
                //    .Replace("{IMAGE_64}", base64String);


                //Console.WriteLine(result);
                string campUrl = "https://viralstyle.com/api/v2/designer/store";
                string result = web.HttpUploadFileByJson(campUrl, encodeJson, token, newToken);
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("Error: {0}, stacktrace: {1}", ex.Message, ex.StackTrace);
            }
        }

        public void Resize(string imageFile, string outputFile, double scaleFactor)
        {
            using (var srcImage = System.Drawing.Image.FromFile(imageFile))
            {
                var newWidth = (int)(srcImage.Width * scaleFactor);
                var newHeight = (int)(srcImage.Height * scaleFactor);
                using (var newImage = new Bitmap(newWidth, newHeight))
                using (var graphics = Graphics.FromImage(newImage))
                {
                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    graphics.DrawImage(srcImage, new Rectangle(0, 0, newWidth, newHeight));
                    //return newImage;
                    newImage.Save(outputFile);
                }
            }
        }
    }
}
