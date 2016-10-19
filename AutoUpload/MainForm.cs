using AutoUpload.Controllers;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoUpload
{
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {
        public MainForm()
        {
            InitializeComponent();

            XmlConfigurator.Configure();
        }

        string RandomString(int size)
        {
            Random random = new Random((int)DateTime.Now.Ticks);//thanks to McAden
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            ViralStyleController.Instance.GetCookieSession();
            ViralStyleController.Instance.GetToken();
            ViralStyleController.Instance.Login();

            string url = "this-is-my-url-" + RandomString(5);
            ViralStyleController.Instance.CheckUrl(url);
            ViralStyleController.Instance.RequestBeta();
            ViralStyleController.Instance.Upload();
        }
    }
}
