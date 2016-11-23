using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoUpload.Models.Viralstyle;
using AutoUpload.Utils;
using AutoUpload.Properties;
using System.IO;

namespace AutoUpload.Controls
{
    public partial class Mockup : MetroFramework.Controls.MetroUserControl
    {
        public List<string> Colors { get; set; }
        public string Name { get; set; }

        private List<CheckBox> checkboxList;
        private MockupInfo mockupInfo;
        public static string NameDefault = string.Empty;
        public static List<string> ChosenNames = new List<string>();
        public static int TotalColors = 0;
        private static object lastSender = null;
     
        public Mockup()
        {
            InitializeComponent();
        }


        public Mockup(MockupInfo mockupInfo)
        {
            InitializeComponent();

            checkboxList = new List<CheckBox>();
            checkboxList.AddRange(new CheckBox[] {checkBox1, checkBox1a, checkBox1b, checkBox1c,
                checkBox1e, checkBox1f, checkBox1g , checkBox1h, checkBox2, checkBox2a,
                checkBox2d, checkBox2b, checkBox2e, checkBox2f, checkBox2c, checkBox2g,
                checkBox3, checkBox3a, checkBox4, checkBox3d, checkBox4a, checkBox3b,
                checkBox4d, checkBox3e, checkBox4b, checkBox3f, checkBox4e, checkBox4f,
                checkBox3c, checkBox4c, checkBox3g, checkBox4g});
            checkboxList = checkboxList.OrderBy(n => n.Name).ToList();

            this.Name = mockupInfo.Name;
            this.Colors = mockupInfo.Colors;

            this.mockupInfo = mockupInfo;
        }

        private void Mockup_Load(object sender, EventArgs e)
        {
           
            if(this.mockupInfo != null)
            {
                for (int i = 0; i < this.Colors.Count; i++)
                {
                    checkboxList[i].BackColor = ColorUtil.HexStrToColor(this.Colors[i]);
                    checkboxList[i].Visible = true;
                }

                lblName.Text = Name;

                var img = System.Drawing.Image.FromFile(mockupInfo.ImagePath);          
                picture.Image = img;

                lblSellingPrice.Text = mockupInfo.Product.suggested_price;
            }
     
        }

        private void chbDefault_CheckedChanged(object sender, EventArgs e)
        {
            if (chbDefault.Checked)
            {
                NameDefault = this.Name;
                if(lastSender != null)
                {
                    var chb = (CheckBox)lastSender;
                    chb.Checked = false;
                }
                lastSender = sender;
            }
            else
            {
                NameDefault = string.Empty;
                lastSender = null;
            }
        }

        private void chbSelect_CheckedChanged(object sender, EventArgs e)
        {
            
            if(chbSelect.Checked)
            {
                if (!ChosenNames.Contains(this.Name))
                {
                    ChosenNames.Add(this.Name);
                }
            }
            else
            {
                ChosenNames.Remove(this.Name);
            }
            
        }

        private void checkBox4g_CheckedChanged(object sender, EventArgs e)
        {
            var chb = (CheckBox)sender;
            if(chb.Checked)
            {
                int maxColors = int.Parse(Settings.Default.MAX_COLORS);
                if(TotalColors >= maxColors)
                {
                    MessageBox.Show("Only allow 20 colors!");
                    chb.Checked = false;
                    TotalColors++;
                }
                else
                {
                    TotalColors++;
                }
            }else
            {
                TotalColors--;
                if (TotalColors < 0)
                    TotalColors = 0;
            }
        }
    }
}
