using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using AutoArtist.Util;
using System.Drawing.Drawing2D;
using System.IO;

namespace AutoArtist.Model
{
    public class Layer : IDisposable
    {
        public Image Img { get; set; }
        public LayerText LayerText { get; set; }
        public Transform Transform { get; set; }
        public string LayerName { get; set; }
        public int Order { get; set; }

        public Layer()
        {
            Transform = new Transform();
            Img = null;
            LayerText = null;
            Order = 1;
        }

        public Layer(int index, string imgPath)
        {
            //FileStream bitmapFile = new FileStream(imgPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            Img = Image.FromFile(imgPath);
            //Img = (Image)new Bitmap(bitmapFile);
            Transform = new Transform();
            Transform.Size.X = Img.Width;
            Transform.Size.Y = Img.Height;
            LayerName = "Layer_" + (index + 1);
            Order = index + 1;
        }

        public Layer(LayerText text)
        {
            this.LayerText = text;
            Transform = new Transform();
        }

        public void UpdateLayer(Vector3 pos, Vector3 scale, Vector3 rot, Vector3 size)
        {
            this.Transform.Position = pos;
            this.Transform.Scale = scale;
            this.Transform.Rotation = rot;
            this.Transform.Size = size;
        }

        public void Draw(Graphics e, float zoomPercent, float heightRate=1.0f, float widthRate=1.0f)
        {
            var pos = Transform.Position;
            var scale = Transform.Scale;
            var rot = Transform.Rotation;
            var size = Transform.Size;
            //int offsetX = Transform.Size.X - (int)(scale.X * layers[i].Size.Width);
            Rectangle rect = new Rectangle((int)(pos.X), (int)(pos.Y),
              (int)Math.Round(size.X * scale.X * zoomPercent), (int)Math.Round(size.Y * scale.Y * zoomPercent));
            if(Img != null)
            {
                e.DrawImage(Img, rect);
            }

            if(LayerText != null)
            {
                Bitmap bitmap = new Bitmap(2400, 3200);
                using(Graphics g = Graphics.FromImage(bitmap))
                {
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                    LayerText.HeightRate = heightRate;
                    LayerText.WidthRate = widthRate;
                    LayerText.Draw(g, this.Transform);
                }

                rect = new Rectangle((int)(pos.X), (int)(pos.Y),
                 (int)Math.Round(bitmap.Width * scale.X * zoomPercent), (int)Math.Round(bitmap.Height * scale.Y * zoomPercent));
               
                e.DrawImage(bitmap, rect);
                bitmap.Dispose();
            }
            
        }
        public void DrawToExport(Graphics e, float zoomPercent, float heightRate = 1.0f, float widthRate = 1.0f)
        {
            var pos = Transform.Position;
            var scale = Transform.Scale;
            var rot = Transform.Rotation;
            var size = Transform.Size;
            //int offsetX = Transform.Size.X - (int)(scale.X * layers[i].Size.Width);
            Rectangle rect = new Rectangle((int)(pos.X / zoomPercent), (int)(pos.Y / zoomPercent),
              (int)Math.Round(size.X * scale.X), (int)Math.Round(size.Y * scale.Y));
            if (Img != null)
            {
                e.DrawImage(Img, rect);
            }
            if (LayerText != null)
            {
                Bitmap bitmap = new Bitmap(2400, 3200);
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                    LayerText.HeightRate = heightRate;
                    LayerText.WidthRate = widthRate;
                    LayerText.Draw(g, this.Transform);
                }

                rect = new Rectangle((int)(pos.X / zoomPercent), (int)(pos.Y / zoomPercent),
                 (int)Math.Round(bitmap.Width * scale.X), (int)Math.Round(bitmap.Height * scale.Y));

                e.DrawImage(bitmap, rect);
                bitmap.Dispose();
            }
          
        }

        public void Dispose()
        {
            Transform = null;
            if(Img != null)
                Img.Dispose();
            LayerText = null;
        }
    }
}
