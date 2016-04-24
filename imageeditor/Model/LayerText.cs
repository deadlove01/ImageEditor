using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imageeditor.Model
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

        public LayerText()
        {
            StringFormat = new StringFormat();
            StringFormat.Alignment = StringAlignment.Center;
            StringFormat.LineAlignment = StringAlignment.Center;
            StringFormat.FormatFlags = StringFormatFlags.FitBlackBox | StringFormatFlags.NoWrap;
            StringFormat.Trimming = StringTrimming.Character;
        }
        public LayerText(string content, Font font, Color textColor, int OutlineSize, Color OutlineColor, LineJoin OutlineStyle)
        {
            this.Content = content;
            this.Font = font;
            this.TextColor = textColor;
            this.OutlineColor = OutlineColor;
            this.OutlineSize = OutlineSize;
            this.OutlineStyle = OutlineStyle;
            StringFormat = new StringFormat();
            StringFormat.Alignment = StringAlignment.Center;
            StringFormat.LineAlignment = StringAlignment.Center;
            StringFormat.FormatFlags = StringFormatFlags.FitBlackBox | StringFormatFlags.NoWrap;
            StringFormat.Trimming = StringTrimming.Character;
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

        public void Draw(Graphics e, Vector3 pos)
        {
            Rectangle textRect = new Rectangle(0, 0, 2400, 3200);
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

            float posX = pos.X;
            float posY = pos.Y;
            e.DrawImage(bm, posX, posY);
            bm.Dispose();
        }
    }
}
