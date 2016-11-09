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

namespace AutoUpload.Controls
{
    public partial class Mockup : MetroFramework.Controls.MetroUserControl
    {
        public List<string> Colors { get; set; }
        public string Name { get; set; }

        private List<CheckBox> checkboxList;
        private MockupInfo mockupInfo;

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
    }
}
