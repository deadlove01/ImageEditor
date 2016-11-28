using AutoUpload.Models;
using AutoUpload.Models.Viralstyle;
using AutoUpload.Properties;
using log4net;
using Newtonsoft.Json;
using RaviLib.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoUpload.Controllers
{
    public class ViralStyleDataController: Singleton<ViralStyleDataController>
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(ViralStyleDataController));

        private ViralStyleProduct viralStyleProduct;
        public ViralStyleProduct ViralStyleProduct
        {
            get
            {
                return viralStyleProduct;
            }
        }
        public ViralStyleDataController()
        {

        }

        public void LoadProductJson()
        {
            try
            {
                CustomWeb web = new CustomWeb();
                string result = web.SendRequest("https://viralstyle.com/design.beta/product-categories?api_campaign=false",
                    "GET", "viralstyle.com", null, false);
                result = "{\"ProductData\":" + result + "}";
                viralStyleProduct = JsonConvert.DeserializeObject<ViralStyleProduct>(result);
                //ViralStyleProductData jsonData = JsonConvert.DeserializeObject<ViralStyleProductData>(result);

                //viralStyleProduct = new ViralStyleProduct();
                //viralStyleProduct.ProductData.Add(jsonData);
                //string rootPath = Directory.GetCurrentDirectory() + "\\";
                //string jsonData = File.ReadAllText(rootPath + Settings.Default.ViralStyle_Product_Path);
                //jsonData = jsonData.Replace("\r\n", "");
                //viralStyleProduct = JsonConvert.DeserializeObject<ViralStyleProduct>(jsonData);
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("Error: {0}, stacktrace: {1}", ex.Message, ex.StackTrace);
            }
        }
        public Products GetProductByName(string uniqueName)
        {
            try
            {
                for (int i = 0; i < viralStyleProduct.ProductData.Count; i++)
                {
                    var product = viralStyleProduct.ProductData[i];
                    for (int k = 0; k < product.category_products.Count; k++)
                    {
                        var proc = product.category_products[k].products;
                        if (proc.name.ToLower() == uniqueName.ToLower())
                        {
                            return proc;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("Error: {0}, stacktrace: {1}", ex.Message, ex.StackTrace);
            }

            return null;
        }

        public Dictionary<string, string> GetMockupImagesbyNames(List<string> names)
        {
            try
            {
                Dictionary<string, string> pairs = new Dictionary<string, string>();
                for (int i = 0; i < viralStyleProduct.ProductData.Count; i++)
                {
                    var product = viralStyleProduct.ProductData[i];
                    for (int k = 0; k < product.category_products.Count; k++)
                    {
                        var proc = product.category_products[k].products;
                        var found = names.Find(p => p.ToLower() == proc.front_base.ToLower());
                        if(!string.IsNullOrEmpty(found) && !pairs.ContainsKey(found))
                        {
                            pairs.Add(found, proc.name);
                        }
                    }
                }
                return pairs;
            }
            catch (Exception ex)
            {
                logger.ErrorFormat("Error: {0}, stacktrace: {1}", ex.Message, ex.StackTrace);
            }

            return null;
        }



    }
}
