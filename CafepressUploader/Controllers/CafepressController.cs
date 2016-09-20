using CafepressUploader.Models;
using CafepressUploader.Utils;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafepressUploader.Controllers
{
    public class CafepressController:  Singleton<CafepressController>
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(CafepressController));
        private CustomWeb web;
        private string memberNo;
        private string imageNo;
        public string MemberNo
        {
            get
            {
                return memberNo;
            }
        }
        public CafepressController()
        {
            web = new CustomWeb();
        }


        public bool Login(string email, string pass)
        {
            try
            {
                string loginUrl = "https://members.cafepress.com/login";
                NameValueCollection nvc = new NameValueCollection();
                nvc.Add("txtEmail", email);
                nvc.Add("txtPassword", pass);
                nvc.Add("staySignedIn", "false");
                string result = web.SendRequest(loginUrl, "POST", nvc, true, "application/x-www-form-urlencoded");
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(result);
                string memberNoInput = doc.DocumentNode.SelectSingleNode("//input[@id='memberNo']").GetAttributeValue("value", string.Empty);
                memberNo = memberNoInput;
                return true;
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("Login: {0}, stacktrace: {1}", ex.Message, ex.StackTrace);
                
            }
            return false;
        }

        public bool UploadImage(string imagePath)
        {
            try
            {
                Image img = Image.FromFile(imagePath);
                NameValueCollection nvc = new NameValueCollection();
                Bitmap resizedImg = ImageUtil.ResizeImage(img, 300, 400);
                nvc.Add("ThumbnailStream", "data:image/png;base64," +
                    ImageUtil.ImageToBase64(resizedImg,
                    System.Drawing.Imaging.ImageFormat.Png));
                img.Dispose();
                resizedImg.Dispose();
                string uploadUrl = "http://upload.cafepresscloud.com/DesignAndListCloudAPI/DesignAndListCloudAPIRestful.svc/GetProductUrlsForThumbnailBase64?ImageFullSizeHeight=3200&ImageFullSizeWidth=2400&FileName=5.png&ImageCaption=&ImageDescription=&MemberNo={0}";
                string result = web.HttpUploadFile(string.Format(uploadUrl, memberNo), null, null, null, nvc);
                
                dynamic rs = JsonConvert.DeserializeObject(result);
                dynamic suggests = rs.GetProductUrlsForThumbnailBase64Result.Suggestions;
                if(suggests != null && suggests.Count > 0)
                {
                    imageNo = suggests[0].ImageNo;
                }else
                {
                    // request to designs url to get image no
                    string reqUrl = "http://members.cafepress.com/m/MemberDesigns/GetMemberDesigns";
                    nvc.Clear();
                    nvc.Add("page", "1");
                    nvc.Add("sort", "recent");
                    nvc.Add("design-type", "all");
                    nvc.Add("designsRemovedCount", "0");

                    result = web.SendRequest(reqUrl, "POST", nvc, false, "application/x-www-form-urlencoded; charset=UTF-8");
                    dynamic designResult = JsonConvert.DeserializeObject(result);
                    foreach (var design in designResult.Data.Designs)
                    {
                        if(design.TotalProductCount == 0)
                        {
                            imageNo = design.Id;
                            break;
                        }
                    }
                }
             
                return true;
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("Login: {0}, stacktrace: {1}", ex.Message, ex.StackTrace);

            }
            return false;
        }


        public bool UpdateDesign(string imagePath, string nameFormat, string tagsFormat, string descriptionFormat)
        {
            try
            {
                NameValueCollection nvc = new NameValueCollection();
                string fileName = Path.GetFileNameWithoutExtension(imagePath);
                nvc.Add("design-name", string.Format(nameFormat, fileName));
                nvc.Add("design-tags", string.Format(tagsFormat, fileName));
                nvc.Add("design-description", string.Format(descriptionFormat, fileName));
                //nvc.Add("design-name", "");
                //nvc.Add("design-name", "");

                string uploadUrl = "http://members.cafepress.com/m/MemberDesigns/SaveDesign/{0}";
                web.SendRequest(string.Format(uploadUrl, imageNo), "POST", nvc, false, "application/x-www-form-urlencoded");
                
                return true;
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("Login: {0}, stacktrace: {1}", ex.Message, ex.StackTrace);

            }
            return false;
        }

        public bool UploadProducts(ref string imageUrl)
        {
            try
            {
                string defaultContent = File.ReadAllText(Directory.GetCurrentDirectory() + "\\Data\\default.json");
                defaultContent = defaultContent.Replace("{image_no}", imageNo);
                dynamic newRS = JsonConvert.DeserializeObject(defaultContent);
                string postData = ConvertToPostData(newRS.GetProductUrlsForThumbnailBase64Result.Suggestions);
                string uploadUrl = "http://members.cafepress.com/s/productinfo/createproductsforrecommendationsandsuggestionsrestful";
                string result = web.SendRequest(uploadUrl, "POST", postData, "application/x-www-form-urlencoded");
                
                dynamic rs = JsonConvert.DeserializeObject(result);
                imageUrl = rs.Products[0].Url;
                return true;
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("Login: {0}, stacktrace: {1}", ex.Message, ex.StackTrace);

            }
            return false;
        }

        private string ConvertToPostData(dynamic resData)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("");
            sb.AppendFormat("imageNo={0}&", imageNo);
            sb.AppendFormat("memberNo={0}&", memberNo);

            foreach (var product in resData)
            {
                sb.AppendFormat("merchandiseUrls[]={0}&", product.ProductCrunchUrls[0].ToString().Replace("{image_no}", imageNo));
                //sb.AppendFormat("guids[]={0}&", product.GUID);
            }


            string result = sb.ToString();
            if (result == null || result == "")
                return "";
            result = result.Remove(result.LastIndexOf('&'), 1);
            return result;
        }

        public void Reset()
        {
            imageNo = string.Empty;
        }
    }
}
