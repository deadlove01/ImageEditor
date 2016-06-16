using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoArtist.Util
{
    public class LogoUtil
    {
        public static Color ConvertStringToColor(string strColor)
        {
            return Color.FromArgb(255, Color.FromArgb(int.Parse(strColor, NumberStyles.HexNumber)));
        }

        public static String ColorToHex(Color c)
        {
            return  c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }
    }
}
