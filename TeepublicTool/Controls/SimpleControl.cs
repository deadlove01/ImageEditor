using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Dynamic;
using TeepublicTool.Models;

namespace TeepublicTool.Controls
{
    public partial class SimpleControl : UserControl
    {

        public static List<SimpleControl> SimpleControlsList = new List<SimpleControl>();
        public Color? CurrentColor { get; set; }
        public float SizePercent { get; set; }
        public string MyName { get; set; }

        public bool UseDefault { get; set; }
        public bool FullBleed { get; set; }
        public string OrientationType { get; set; }
        public string AspectRatio { get; set; }

        private ProductType productType;
     
        public ProductData ConvertToDynamicObj()
        {
            List<ShirtColor> shirtList = new List<ShirtColor>();
            if(groupApparel.Enabled )
            {
                shirtList.Add(new ShirtColor("T-Shirt", cbbTshirt.SelectedItem.ToString()));
                shirtList.Add(new ShirtColor("Tank", cbbTank.SelectedItem.ToString()));
                shirtList.Add(new ShirtColor("Long Sleeve T-Shirt", cbbLongSleeve.SelectedItem.ToString()));
                shirtList.Add(new ShirtColor("Baseball Tee", cbbBaseballTee.SelectedItem.ToString()));
                shirtList.Add(new ShirtColor("Kids", cbbKids.SelectedItem.ToString()));
                shirtList.Add(new ShirtColor("Crewneck", cbbCrewneck.SelectedItem.ToString()));
                shirtList.Add(new ShirtColor("Hoodie", cbbHoodie.SelectedItem.ToString()));
            }


            return new ProductData {
                Name = MyName,
                HexColor = CurrentColor!= null?ToHexValue((Color)CurrentColor): null,
                SizePercent = SizePercent,
                CenterHorizontal = true,
                CenterVertical = true,
                UseDefault = UseDefault,
                ProductType = (int)productType,
                FullBleedPrint = FullBleed,
                OrientationType = OrientationType,
                AspectRatio = AspectRatio,
                ShirtColors = shirtList
            };

            //dynamic obj = new ExpandoObject();
            //obj.color = CurrentColor;
            //obj.size_percent = SizePercent;
            //obj.Name = MyName;
            //return obj;
        }

        public SimpleControl()
        {
            InitializeComponent();
            CurrentColor = null;
            UseDefault = chbSetDefault.Checked;
          //  SimpleControlsList.Add(this);
        }

        public SimpleControl(string name, ProductType productType)
        {
            InitializeComponent();
            UseDefault = chbSetDefault.Checked;
            CurrentColor = null;
            MyName = name;
            this.productType = productType;
            if(productType == ProductType.APPAREL)
            {
                groupPrint.Enabled = false;
                groupApparel.Enabled = true;
                cbbTshirt.SelectedIndex = 0;
                cbbTank.SelectedIndex = 0;
                cbbLongSleeve.SelectedIndex = 0;
                cbbBaseballTee.SelectedIndex = 0;
                cbbCrewneck.SelectedIndex = 0;
                cbbKids.SelectedIndex = 0;
                cbbHoodie.SelectedIndex = 0;

                tbColor.Enabled = false;
                btnChooseColor.Enabled = false;
            }else if (productType == ProductType.PRINTS)
            {
                groupPrint.Enabled = true;
                groupApparel.Enabled = false;
                tbColor.Enabled = true;
                btnChooseColor.Enabled = true;
            }
            else
            {
                groupPrint.Enabled = false;
                groupApparel.Enabled = false;
                tbColor.Enabled = true;
                btnChooseColor.Enabled = true;
            }
        }

        private void btnChooseColor_Click(object sender, EventArgs e)
        {
            var result = colorDialog1.ShowDialog();
            if(result == DialogResult.OK)
            {
                CurrentColor = colorDialog1.Color;
                tbColor.Text = ToHexValue((Color)CurrentColor);
            }

        }

        public string ToHexValue(Color color)
        {
            return "#" + color.R.ToString("X2") +
                         color.G.ToString("X2") +
                         color.B.ToString("X2");
        }

        private void trackBarPercent_ValueChanged(object sender, EventArgs e)
        {
            lblPercent.Text = trackBarPercent.Value + "%";
            SizePercent = trackBarPercent.Value;
        }


        public static bool ContainsControl(string controlName)
        {
            foreach (var item in SimpleControlsList)
            {
                if(item.MyName == controlName)
                {
                    return true;
                
                }
            }
            return false;
        }

        public static void RemoveControl(string controlName)
        {
            for (int i = 0; i < SimpleControlsList.Count; i++)
            {
                var item = SimpleControlsList[i];
                if(item.MyName == controlName)
                {
                    SimpleControlsList.RemoveAt(i);
                    break;
                }
            }
        }

        public static SimpleControl FindControl(string controlName)
        {
            for (int i = 0; i < SimpleControlsList.Count; i++)
            {
                var item = SimpleControlsList[i];
                if (item.MyName == controlName)
                {
                    return item;
                }
            }
            return null;
        }

        private void SimpleControl_Load(object sender, EventArgs e)
        {
            lblName.Text = MyName;
            lblPercent.Text = trackBarPercent.Value + "%";
            SizePercent = trackBarPercent.Value;
            FullBleed = chbFullbleedPrint.Checked;
            if(radPortrait.Checked)
            {
                OrientationType = "Portrait";
            }else
            {
                OrientationType = "Landscape";
            }

            if (rad1vs1.Checked)
            {
                AspectRatio = "1:1";
            }
            else if(rad5vs6.Checked)
            {
                AspectRatio = "5:6";
            }
            else if (rad4vs5.Checked)
            {
                AspectRatio = "4:5";
            }
            else if (rad3vs4.Checked)
            {
                AspectRatio = "3:4";
            }
            else if (rad2vs3.Checked)
            {
                AspectRatio = "2:3";
            }
            else if (rad9vs16.Checked)
            {
                AspectRatio = "9:16";
            }

        }

        private void chbSetDefault_CheckedChanged(object sender, EventArgs e)
        {
            UseDefault = chbSetDefault.Checked;
        }

        private void rad1vs1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rad = sender as RadioButton;
            if(rad.Checked)
            {
                AspectRatio = rad.Text;
                Console.WriteLine(AspectRatio);
            }
        }

        private void radLanscape_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rad = sender as RadioButton;
            if (rad.Checked)
            {
                OrientationType = rad.Text;
                Console.WriteLine(AspectRatio);
            }
        }
    }
}
