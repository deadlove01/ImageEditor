using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SunfrogUploader.Model
{
    public class CustomWeb : System.Net.WebClient
    {
        private string userAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.85 Safari/537.36";
        public CookieContainer CookieContainer { get; private set; }

        public CustomWeb(CookieContainer container)
        {
            CookieContainer = container;

        }

        public CustomWeb()
            : this(new CookieContainer())
        { }

        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = (HttpWebRequest)base.GetWebRequest(address);
            request.CookieContainer = CookieContainer;
            return request;
        }

        public string SendRequest(string url, string method, NameValueCollection nvc, bool isCreateCookie = false, string contentType = "")
        {
            string result = string.Empty;
            try
            {
                CookieContainer container = new CookieContainer();
                string data = ConvertNVCToString(nvc);

                string finalUrl = (data != "") ? url + "?" + data : url;
                if (method.ToLower().Equals("post"))
                    finalUrl = url;

                var request = (HttpWebRequest)WebRequest.Create(finalUrl);
                request.Method = method;
                request.AllowAutoRedirect = true;
                request.Accept = "*/*";
                request.UserAgent = userAgent;

                if (!isCreateCookie)
                {
                    request.CookieContainer = CookieContainer;
                }
                else
                {
                    container = request.CookieContainer = new CookieContainer();
                }


                if (contentType != "")
                {
                    request.ContentType = contentType;
                }
                if (method.ToLower().Equals("post"))
                {
                    var byteData = Encoding.ASCII.GetBytes(data);
                    request.ContentLength = byteData.Length;
                    using (var stream = request.GetRequestStream())
                        stream.Write(byteData, 0, byteData.Length);
                }


                using (var res = request.GetResponse())
                {
                    using (var sr = new StreamReader(res.GetResponseStream()))
                    {
                        result = sr.ReadToEnd();
                    }
                }

                if (isCreateCookie)
                {
                    CookieContainer = container;
                }

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                Console.WriteLine("error: " + ex.StackTrace);
            }

            return result;
        }

        public string WebClientRequest(string url, NameValueCollection nvc, string method)
        {

            var responseData = this.UploadValues(url, method, nvc);
            WebHeaderCollection whc = this.ResponseHeaders;
            string result = string.Empty;

            using (var mr = new MemoryStream(responseData))
            {
                using (var sr = new StreamReader(mr))
                {
                    result = sr.ReadToEnd();
                }
            }
            return result;
        }

        public string HttpUploadFile(string url, string file, string paramName, string contentType, NameValueCollection nvc)
        {
            Console.WriteLine(string.Format("Uploading {0} to {1}", file, url));
            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("--" + boundary + "\r\n");


            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
            wr.ServicePoint.Expect100Continue = false;
            wr.ContentType = "multipart/form-data; boundary=" + boundary;
            wr.Method = "POST";
            //    wr.KeepAlive = true;
            wr.Host = "manager.sunfrogshirts.com";
            //  wr.Referer = url;
            //wr.Headers[HttpRequestHeader.AcceptEncoding] = "gzip, deflate";
            wr.Headers[HttpRequestHeader.KeepAlive] = "true";
            //wr.Headers[HttpRequestHeader.CacheControl] = "max-age=0";
            //wr.AllowAutoRedirect = true;
            //wr.Accept = "*/*";
            // wr.Credentials = System.Net.CredentialCache.DefaultCredentials;
            //  wr.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore); 


            wr.CookieContainer = CookieContainer;
            wr.UserAgent = userAgent;

            Stream rs = wr.GetRequestStream();
            rs.Flush();
            string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}\r\n";
            foreach (string key in nvc.Keys)
            {
                rs.Write(boundarybytes, 0, boundarybytes.Length);
                string formitem = string.Format(formdataTemplate, key, nvc[key]);
                byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
                rs.Write(formitembytes, 0, formitembytes.Length);
            }
            rs.Write(boundarybytes, 0, boundarybytes.Length);


            if (!string.IsNullOrEmpty(file))
            {
                string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
                string header = string.Format(headerTemplate, paramName, Path.GetFileName(file), contentType);
                byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
                rs.Write(headerbytes, 0, headerbytes.Length);

                FileStream fileStream = new FileStream(file, FileMode.Open, FileAccess.Read);
                byte[] buffer = new byte[4096];
                int bytesRead = 0;
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    rs.Write(buffer, 0, bytesRead);
                }
                fileStream.Close();
            }


            byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
            rs.Write(trailer, 0, trailer.Length);
            rs.Close();

            WebResponse wresp = null;
            try
            {
                wresp = wr.GetResponse();
                Stream stream2 = wresp.GetResponseStream();
                StreamReader reader2 = new StreamReader(stream2);
                return reader2.ReadToEnd();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error uploading file", ex);
                if (wresp != null)
                {
                    wresp.Close();
                    wresp = null;
                }
            }
            finally
            {
                wr = null;
            }

            return null;
        }


        public string HttpUploadFileByJson(string url, string jsonModel)
        {
            Console.WriteLine(string.Format("Uploading {0}", url));

            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
            wr.ServicePoint.Expect100Continue = false;
            wr.ContentType = "application/json; charset=utf-8";
            wr.Method = "POST";
            wr.Host = "manager.sunfrogshirts.com";
            wr.Headers[HttpRequestHeader.KeepAlive] = "true";
            wr.CookieContainer = CookieContainer;
            wr.UserAgent = userAgent;

            using (var streamWriter = new StreamWriter(wr.GetRequestStream()))
            {
                streamWriter.Write(jsonModel);
                streamWriter.Flush();
            }


            WebResponse wresp = null;
            try
            {
                wresp = wr.GetResponse();
                Stream stream2 = wresp.GetResponseStream();
                StreamReader reader2 = new StreamReader(stream2);
                return reader2.ReadToEnd();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error uploading file", ex);
                if (wresp != null)
                {
                    wresp.Close();
                    wresp = null;
                }
            }
            finally
            {
                wr = null;
            }

            return null;
        }


        public string ConvertNVCToString(NameValueCollection nvc)
        {
            if (nvc == null)
                return "";
            StringBuilder sb = new StringBuilder();
            sb.Append("");
            foreach (var item in nvc)
            {
                sb.AppendFormat("{0}={1}&", item.ToString(), nvc.Get(item.ToString()));
            }


            string result = sb.ToString();
            if (result == null || result == "")
                return "";
            result = result.Remove(result.LastIndexOf('&'), 1);
            return result;
        }

    }
}
