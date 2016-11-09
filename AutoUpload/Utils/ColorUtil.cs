using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoUpload.Utils
{
    public class ColorUtil
    {
        public static String ColorToHexStr(System.Drawing.Color c)
        {
            return ColorTranslator.ToHtml(c);
            //return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }

        public static String ColorToRGBStr(System.Drawing.Color c)
        {
            return "RGB(" + c.R.ToString() + "," + c.G.ToString() + "," + c.B.ToString() + ")";
        }

        public static Color HexStrToColor(string hexStr)
        {
            return ColorTranslator.FromHtml(hexStr);       
        }
    }
}
