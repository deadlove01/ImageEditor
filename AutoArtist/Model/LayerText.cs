using AutoArtist.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoArtist.Model
{
    public class LayerText
    {
        public int FontSize { get; set; }
        public Font Font { get; set; }
        public int OutlineSize { get; set; }
        public StringFormat StringFormat { get; set; }
        public string Content { get; set; }
        public Color TextColor { get; set; }
        public Color OutlineColor { get; set; }
        public LineJoin OutlineStyle { get; set; }

        public float HeightRate { get; set; }
        public float WidthRate { get; set; }

        public LayerText()
        {
            StringFormat = new StringFormat();
            StringFormat.Alignment = StringAlignment.Center;
            StringFormat.LineAlignment = StringAlignment.Center;
            StringFormat.FormatFlags = StringFormatFlags.FitBlackBox | StringFormatFlags.NoWrap;
            StringFormat.Trimming = StringTrimming.Character;
            HeightRate = WidthRate = 1;
        }
        public LayerText(string content, Font font, int FontSize, Color textColor, int OutlineSize, Color OutlineColor, LineJoin OutlineStyle)
        {
            this.Content = content;
            this.Font = font;
            this.TextColor = textColor;
            this.OutlineColor = OutlineColor;
            this.OutlineSize = OutlineSize;
            this.OutlineStyle = OutlineStyle;
            this.FontSize = FontSize;
            StringFormat = new StringFormat();
            StringFormat.Alignment = StringAlignment.Center;
            StringFormat.LineAlignment = StringAlignment.Center;
            StringFormat.FormatFlags = StringFormatFlags.FitBlackBox | StringFormatFlags.NoWrap;
            StringFormat.Trimming = StringTrimming.Character;
            HeightRate = WidthRate = 1;
        }


        private void Draw(Graphics e, Rectangle rect)
        {
            e.DrawString(Content, Font, new SolidBrush(TextColor),
                            rect, StringFormat);
        }

        private void DrawOutline(Graphics e, Rectangle rect)
        {
            //out line
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath(FillMode.Winding);
            path.AddString(Content, Font.FontFamily, (int)Font.Style, Font.Size, rect, StringFormat);
            
            //draw the outline
            Pen pen = new Pen(OutlineColor, OutlineSize);
            if (OutlineSize == 0)
            {
                pen = new Pen(OutlineColor);
            }

            pen.LineJoin = OutlineStyle;
            e.SmoothingMode = SmoothingMode.AntiAlias;
            e.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            e.PixelOffsetMode = PixelOffsetMode.HighQuality;

            int offetX = (int)OutlineSize;
            int offetY = (int)OutlineSize;
            Rectangle shadowRect = new Rectangle(rect.X, rect.Y,
                rect.Width + offetX, rect.Height + offetY);

            e.DrawPath(pen, path);
            e.FillPath(new SolidBrush(TextColor), path);
            pen.Dispose();
        }

        public void Draw(Graphics e, Transform trans)
        {
            var size = trans.Size;
            Rectangle textRect = new Rectangle(0, 0, (int)size.X, (int)size.Y);
            SizeF f = e.MeasureString(Content, Font);
            Bitmap bm = new Bitmap((int)f.Width + 10, (int)f.Height + 10);
            using (Graphics gg = Graphics.FromImage(bm))
            {
                gg.SmoothingMode = SmoothingMode.AntiAlias;
                gg.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gg.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                gg.PixelOffsetMode = PixelOffsetMode.HighQuality;

                Rectangle newRect = new Rectangle(0, 0, bm.Width, bm.Height);
                if(OutlineSize > 0)
                {
                    DrawOutline(gg, newRect);
                }else
                {
                    Draw(gg, newRect);
                }             
            }
            // resize image
            int w, h;
            w = textRect.Width;
            h = textRect.Height;
            if (bm.Width < w || w == 0)
                w = bm.Width;
            if (bm.Height < h || h == 0)
                h = bm.Height;

            float hRate = (float)h / bm.Height;
            float wRate = (float)w / bm.Width;
            if(HeightRate > hRate)
                this.HeightRate = hRate;
            if(WidthRate > wRate)
                this.WidthRate = wRate;
            Console.WriteLine("hRate: " + HeightRate + ", wRate: " + WidthRate);
            int width = (int)Math.Ceiling(WidthRate * bm.Width);
            int height = (int)Math.Ceiling(HeightRate * bm.Height);
            var img = ImageUtil.ResizeImage(bm, width, height);
            if (size.X == 0 || size.Y == 0)
                trans.Size = new Vector3(w, h, 0);
            //var img = ImageUtil.ResizeImage(bm, w, h);
            //if(size.X == 0 || size.Y == 0)
            //    trans.Size = new Vector3(w, h, 0);

            var pos = trans.Position;
            float posX = pos.X;
            float posY = pos.Y;
            posX += (textRect.Width - img.Width) / 2;
            e.DrawImage(img, posX, posY);
            img.Dispose();
            bm.Dispose();
        }
    }
}
