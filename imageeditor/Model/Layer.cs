using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace imageeditor.Model
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
            Img = Image.FromFile(imgPath);
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



        public void Draw(Graphics e, float zoomPercent)
        {
            var pos = Transform.Position;
            var scale = Transform.Scale;
            var rot = Transform.Rotation;
            var size = Transform.Size;
            //int offsetX = Transform.Size.X - (int)(scale.X * layers[i].Size.Width);
            Rectangle rect = new Rectangle((int)pos.X, (int)pos.Y,
              (int)Math.Round(size.X * scale.X * zoomPercent), (int)Math.Round(size.Y * scale.Y * zoomPercent));
            if(Img != null)
            {
                e.DrawImage(Img, rect);
            }

            if(LayerText != null)
            {
                LayerText.Draw(e);
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
