using System;
using System.Collections.Generic;
using System.Drawing;
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

        public LayerText()
        {
            StringFormat = new StringFormat();
            StringFormat.Alignment = StringAlignment.Center;
            StringFormat.LineAlignment = StringAlignment.Center;
            StringFormat.FormatFlags = StringFormatFlags.FitBlackBox | StringFormatFlags.NoWrap;
            StringFormat.Trimming = StringTrimming.Character;
        }
        public LayerText(string content, Font font)
        {
            this.Content = content;
            this.Font = font;
            StringFormat = new StringFormat();
            StringFormat.Alignment = StringAlignment.Center;
            StringFormat.LineAlignment = StringAlignment.Center;
            StringFormat.FormatFlags = StringFormatFlags.FitBlackBox | StringFormatFlags.NoWrap;
            StringFormat.Trimming = StringTrimming.Character;
        }


        public void Draw(Graphics e)
        {
            e.DrawString(Content, Font, Brushes.Aqua, 0, 0, StringFormat);
        }
    }
}
