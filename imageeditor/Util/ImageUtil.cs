using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imageeditor.Util
{
    public class ImageUtil
    {
        public static Image ResizeImage(Image image, int desWidth, int desHeight)
        {
            int x, y, w, h;
            x = 0;
            y = 0;
            w = desWidth;
            h = desHeight;
            var bmp = new Bitmap(desWidth, desHeight);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(image, x, y, w, h);
            }

            return bmp;
        }
    }
}
