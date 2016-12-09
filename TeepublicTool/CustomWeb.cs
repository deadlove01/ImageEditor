using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AutoUpload.Models
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


        protected override WebResponse GetWebResponse(WebRequest request)
        {
            WebResponse response = base.GetWebResponse(request);
            String setCookieHeader = response.Headers[HttpResponseHeader.SetCookie];
            if (setCookieHeader != null)
            {
                CookieCollection cookiesList = GetAllCookiesFromHeader(setCookieHeader, BaseAddress);
                if (cookiesList != null)
                    CookieContainer.Add(new Uri(BaseAddress), cookiesList);
            }
            return response;
        }
        private CookieCollection GetAllCookiesFromHeader(string strHeader, string strHost)
        {
            CookieCollection cc = new CookieCollection();
            if (strHeader != string.Empty)
            {
                ArrayList al = ConvertCookieHeaderToArrayList(strHeader);
                cc = ConvertCookieArraysToCookieCollection(al, strHost);
            }
            return cc;
        }
        private ArrayList ConvertCookieHeaderToArrayList(string strCookHeader)
        {
            strCookHeader = strCookHeader.Replace("\r", "");
            strCookHeader = strCookHeader.Replace("\n", "");
            string[] strCookTemp = strCookHeader.Split(',');
            ArrayList al = new ArrayList();
            int i = 0;
            int n = strCookTemp.Length;
            while (i < n)
            {
                if (strCookTemp[i].IndexOf("expires=", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    al.Add(strCookTemp[i] + "," + strCookTemp[i + 1]);
                    i = i + 1;
                }
                else
                {
                    al.Add(strCookTemp[i]);
                }
                i = i + 1;
            }
            return al;
        }
        private CookieCollection ConvertCookieArraysToCookieCollection(ArrayList al, string strHost)
        {
            CookieCollection cc = new CookieCollection();
            int alcount = al.Count;
            for (int i = 0; i < alcount; i++)
            {
                string strEachCook = al[i].ToString();
                string[] strEachCookParts = strEachCook.Split(';');
                int intEachCookPartsCount = strEachCookParts.Length;

                Cookie cookTemp = new Cookie();
                for (int j = 0; j < intEachCookPartsCount; j++)
                {
                    if (j == 0)
                    {
                        string strCNameAndCValue = strEachCookParts[j];
                        if (strCNameAndCValue != string.Empty)
                        {
                            int firstEqual = strCNameAndCValue.IndexOf("=", StringComparison.InvariantCultureIgnoreCase);
                            string firstName = strCNameAndCValue.Substring(0, firstEqual);
                            string allValue = strCNameAndCValue.Substring(firstEqual + 1, strCNameAndCValue.Length - (firstEqual + 1));
                            cookTemp.Name = firstName;
                            Encoding iso = Encoding.GetEncoding("utf-8");//may be utf-8
                            allValue = WebUtility.UrlEncode(allValue);
                            cookTemp.Value = allValue;
                        }
                        continue;
                    }
                    string strPNameAndPValue;
                    string[] nameValuePairTemp;
                    if (strEachCookParts[j].IndexOf("path", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        strPNameAndPValue = strEachCookParts[j];
                        if (strPNameAndPValue != string.Empty)
                        {
                            nameValuePairTemp = strPNameAndPValue.Split('=');
                            cookTemp.Path = nameValuePairTemp[1] != string.Empty ? nameValuePairTemp[1] : "/";
                        }
                        continue;
                    }
                    if (strEachCookParts[j].IndexOf("domain", StringComparison.OrdinalIgnoreCase) < 0)
                        continue;
                    strPNameAndPValue = strEachCookParts[j];

                    if (strPNameAndPValue == string.Empty)
                        continue;

                    nameValuePairTemp = strPNameAndPValue.Split('=');
                    cookTemp.Domain = nameValuePairTemp[1] != string.Empty ? nameValuePairTemp[1] : strHost;
                }
                if (cookTemp.Path == string.Empty)
                {
                    cookTemp.Path = "/";
                }
                if (cookTemp.Domain == string.Empty)
                {
                    cookTemp.Domain = strHost;
                }
                cc.Add(cookTemp);
            }
            return cc;
        }
        public string SendRequest(string url, string method, string host, NameValueCollection nvc, ref string responseUrl, bool isCreateCookie = false, string contentType = "")
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
                request.Host = host;
                request.Headers["Origin"] = "https://www.teepublic.com";
                request.Timeout = 1000000;
                // request.Timeout = 1000 * 60 * 5;

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
                    responseUrl = res.ResponseUri.AbsoluteUri;
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
                request.Timeout = 1000000;
                //request.Headers[HttpRequestHeader.Host] = "www.teepublic.com";
                request.Host = "www.teepublic.com";
                // request.Timeout = 1000 * 60 * 5;

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


        public string SendRequest(string url, string method, string data, string contentType = "")
        {
            string result = string.Empty;
            try
            {
                CookieContainer container = new CookieContainer();

                string finalUrl = (data != "") ? url + "?" + data : url;
                if (method.ToLower().Equals("post"))
                    finalUrl = url;

                var request = (HttpWebRequest)WebRequest.Create(finalUrl);
                request.Method = method;
                request.AllowAutoRedirect = true;
                request.Accept = "*/*";
                request.UserAgent = userAgent;
                // request.Timeout = 1000 * 60 * 5;

                request.CookieContainer = CookieContainer;

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
            //  wr.ServicePoint.Expect100Continue = false;
            wr.ContentType = "multipart/form-data; boundary=" + boundary;
            wr.Method = "POST";
            //    wr.KeepAlive = true;
            wr.Host = "viralstyle.com";
            //  wr.Referer = url;
            //wr.Headers[HttpRequestHeader.AcceptEncoding] = "gzip, deflate";
            //wr.Headers[HttpRequestHeader.KeepAlive] = "true";
            //wr.Headers[HttpRequestHeader.CacheControl] = "max-age=0";
            wr.AllowAutoRedirect = true;
            //wr.Accept = "*/*";
            // wr.Credentials = System.Net.CredentialCache.DefaultCredentials;
            //  wr.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore); 


            wr.CookieContainer = CookieContainer;
            wr.UserAgent = userAgent;

            Stream rs = wr.GetRequestStream();
            rs.Flush();
            //string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}\r\n";
            string formdataTemplate = "Content-Type: text/plain; charset=utf-8\r\nContent-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}\r\n";
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
                string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\" ;filename*=utf-8''{1}\r\n\r\n";
                //string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
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


        public string HttpUploadFileByJson(string url, string jsonModel, string authToken, string xtoken)
        {
            Console.WriteLine(string.Format("Uploading {0}", url));

            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
            //wr.ServicePoint.Expect100Continue = false;
            wr.ContentType = "application/json; charset=utf-8";
            wr.Method = "POST";
            wr.Host = "viralstyle.com";
            wr.Headers[HttpRequestHeader.KeepAlive] = "true";
            wr.CookieContainer = CookieContainer;
            wr.UserAgent = userAgent;
            wr.Timeout = 1000 * 60 * 5;
            wr.Headers.Add("authorization", "Bearer " + authToken);
            wr.Headers.Add("X-CSRF-TOKEN", xtoken);
            if (url.Contains("/store"))
            {
                wr.Referer = "https://viralstyle.com/design.beta";
            }

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

        public string SendRequestJsonType(string url, string method, string contentType, string jsonModel, string token, bool isCreateCookie = false)
        {
            Console.WriteLine(string.Format("Uploading {0}", url));
            CookieContainer container = new CookieContainer();
            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
            //wr.ServicePoint.Expect100Continue = false;
            wr.ContentType = contentType;
            wr.Host = "viralstyle.com";
            wr.Method = method;
            wr.Timeout = 1000000;
            wr.Headers[HttpRequestHeader.KeepAlive] = "true";
            if (isCreateCookie)
            {
                container = wr.CookieContainer = new CookieContainer();
                wr.Headers[HttpRequestHeader.Authorization] = "Bearer " + token;
                //NrE5g3pfDKSGoF1DOuTk7IoYYBJBQMkLBehF5IFv
            }
            else
                wr.CookieContainer = CookieContainer;
            wr.UserAgent = userAgent;
            wr.Timeout = 1000 * 60 * 5;


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

                if (isCreateCookie)
                {
                    CookieContainer = container;
                }
                return reader2.ReadToEnd();



            }
            catch (Exception ex)
            {
                Console.WriteLine("Send json request error: ", ex);
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


        public string SendUploadOptionRequest(string url, string method, string referer)
        {
            string result = string.Empty;
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = method;
                request.AllowAutoRedirect = true;
                request.Accept = "*/*";
                request.UserAgent = userAgent;
                request.Timeout = 1000000;
                request.Host = "api.cloudinary.com";
                request.Headers["Origin"] = "https://www.teepublic.com";
                request.Referer = referer;
                //request.Headers["Access-Control-Request-Method"] = "POST";
                //request.Headers["Access-Control-Request-Headers"] = "x-requested-with, x-unique-upload-id";
             
                request.CookieContainer = CookieContainer;
                
                using (var res = request.GetResponse())
                {
                    using (var sr = new StreamReader(res.GetResponseStream()))
                    {
                        result = sr.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                Console.WriteLine("error: " + ex.StackTrace);
            }

            return result;
        }


        public string HttpUploadFile(string url, string file, string paramName, string contentType, NameValueCollection nvc,
            string host, string origin, string referer)
        {
            Console.WriteLine(string.Format("Uploading {0} to {1}", file, url));
            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("--" + boundary + "\r\n");


            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
            //  wr.ServicePoint.Expect100Continue = false;
            wr.ContentType = "multipart/form-data; boundary=" + boundary;
            wr.Method = "POST";
            //    wr.KeepAlive = true;
            wr.Host = host;
            wr.Headers["Origin"] = origin;
            wr.Referer = referer;
            wr.Headers[HttpRequestHeader.KeepAlive] = "true";
            //wr.Headers[HttpRequestHeader.CacheControl] = "max-age=0";
            wr.AllowAutoRedirect = true;
            //wr.Accept = "*/*";
            // wr.Credentials = System.Net.CredentialCache.DefaultCredentials;
            //  wr.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore); 


            wr.CookieContainer = CookieContainer;
            wr.UserAgent = userAgent;

            Stream rs = wr.GetRequestStream();
            rs.Flush();
            //string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}\r\n";
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
                //string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\" \r\n\r\n";
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
    }
}
