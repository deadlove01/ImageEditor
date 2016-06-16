using AutoArtist.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoArtist.Model
{

    public class ScriptObject
    {
        public Vector3 LogoContainer { get; set; }
        public Vector3 LogoPosition { get; set; }
        public Vector3 LogoRotation { get; set; }
        public Vector3 LogoScale { get; set; }
        public Vector3 LogoBendSize { get; set; }

        public int LineJoin { get; set; }

        public float OutlineSize { get; set; }

        public string OutlineColorHex { get; set; }

        public int Order { get; set; }
        public string TextColor { get; set; }


        //public WrapStyle BeizerStyle { get; set; }

        public bool UsePathSize { get; set; }
        public Vector3 Shear { get; set; }

        public float BeizerIntensity { get; set; }
        public string FontName { get; set; }

        public int FontSize { get; set; }

        public ScriptObject()
        {
            OutlineColorHex = "000000";
            LineJoin = 2;
            Order = 0;
            TextColor = "000000";
            //BeizerStyle = WrapStyle.None;
            Shear = Vector3.Zero;
            BeizerIntensity = 0;
        }

    }

    public class ScriptConfig
    {
        public List<ScriptObject> LogoList { get; set; }
        public bool AutoScaleAll { get; set; }
        public ScriptConfig()
        {
            LogoList = new List<ScriptObject>();
        }
    }
}
