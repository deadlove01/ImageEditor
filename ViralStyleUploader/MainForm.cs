using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViralStyleUploader.Models;

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
            //nvc.Add("email", "deadlove011011@gmail.com");
           // nvc.Add("password", "19001560");
            string loginUrl = " https://viralstyle.com/api/v2/auth/login";

            LoginModel loginModel = new LoginModel("deadlove011011@gmail.com", "19001560", false);
            string loginJson = JsonConvert.SerializeObject(loginModel);

            string result = web.SendRequestJsonType(loginUrl, "POST", "application/json", loginJson, true);
            // Console.WriteLine(result);

            string uploadUrl = "https://viralstyle.com/design.beta/upload-asset";
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
            Console.WriteLine(result);

            string campUrl = "https://viralstyle.com/api/v2/designer/store";
        }
    }
}
