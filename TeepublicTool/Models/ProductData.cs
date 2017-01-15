using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeepublicTool.Models
{

    public enum ProductType
    {
        APPAREL = 1,
        PRINTS,
        OTHERS
    }

    public enum OrientationType
    {
        Postrait = 1,
        Landscape
    }
    public class ProductTemplate
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
        public string MainTag { get; set; }

        public List<ProductData> Products { get; set; }

        public ProductTemplate()
        {
            Products = new List<ProductData>();
        }

    }

    public class ProductData
    {
        public string Name { get; set; }
        public int ProductType { get; set; }
        public float SizePercent { get; set; }
        public bool CenterVertical { get; set; }
        public bool CenterHorizontal { get; set; }
        public string HexColor { get; set; }

        public bool FullBleedPrint { get; set; }
        public string OrientationType { get; set; }
        public string AspectRatio { get; set; }
        public bool UseDefault { get; set; }
        public List<ShirtColor> ShirtColors { get; set; }

        public ProductData()
        {
            ShirtColors = new List<ShirtColor>();
        }
    }


    public enum PRODUCT_TYPE
    {
        Simple = 1,
        Printer,
        TShirt
    }


    public enum ORIENTATION_TYPE
    {
        Portrait = 1,
        Landscape
    }

    public enum ASPECT_RATIO
    {
        Ratio_1_1 = 1,
        Ratio_5_6,
        Ratio_4_5,
        Ratio_3_4,
        Ratio_2_3,
        Ratio_9_16
        //1:1 5:6 4:5 3:4 2:3 9:16
    }


    public class ShirtModel
    {
        public string Name { get; set; }
        public string MainColor { get; set; }
        public List<string> OtherColors { get; set; }
    }

    public class ShirtColor
    {
        public string Name { get; set; }
        public string Color { get; set; }

        public ShirtColor()
        {

        }


        public ShirtColor(string name, string color)
        {
            this.Name = name;
            this.Color = color;
        }
    }
}
