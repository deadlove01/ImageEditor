using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunfrogUploader.Util
{
    public class SunfrogUtil
    {


        /// <summary>
        /// Convert Mockup name to sunfrog color
        /// ex: Name_Guys_Dark-Grey.jpg -> Dark Grey_8
        /// Hoodie_Black -> Black_19
        /// Ladie_Black -> Black_34
        /// </summary>
        /// <param name="nameColor"></param>
        /// <returns></returns>
        public static string ConvertMockupNameToSunfrogColor(string mockupName)
        {
            string[] temp = mockupName.Split('_');
            string color = temp[2].Replace("-", " ");
            switch (temp[1])
            {
                case "Guys":
                    return color + "_" + 8;
                case "Hoodie":
                    return color + "_" + 19;
                case "Ladies":
                    return color + "_" + 34;
            }
            return null;
        }

        public static string GetGroupIDFromHtml(string html)
        {
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);

            var groupInput = doc.DocumentNode.SelectSingleNode("//input[@name='GroupID']");
            return groupInput.GetAttributeValue("value", string.Empty);
        }

        public static string GetDefaultMockupIDFromHtml(string html)
        {
            return string.Empty;
        }

        public static bool IsLoggedIn(string html)
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
    }
}
