using imageeditor.Util;
using imageEditor.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imageeditor.Model
{
    public class LayerManager
    {
        public int SelectedIndex { get; set; }
        public float ZoomPercent { get; set; }

        public List<Layer> Layers { get; set; }
        public LayerManager()
        {
            SelectedIndex = -1;
            Layers = new List<Layer>();
            ZoomPercent = 1;
        }


        public void AddLayer(string imgPath)
        {
            Layers.Add(new Layer(Layers.Count, imgPath));
            this.SelectedIndex = Layers.Count - 1;

        }
        public void AddLayer(Image img)
        {

        }

        public void AddTextLayer(Layer textlayer)
        {
            Layers.Add(textlayer);
            textlayer.LayerName = "TextLayer_" + Layers.Count;
            textlayer.Order = Layers.Count;
            this.SelectedIndex = Layers.Count - 1;
        }

        public void MoveLayer(int curIndex, int nextIndex)
        {
            Layer temp = Layers[curIndex];
            Layers[curIndex] = Layers[nextIndex];
            Layers[nextIndex] = temp;            
        }


        public void RemoveAllLayer()
        {
            if(Layers.Count > 0)
            {
                for (int i = 0; i < Layers.Count; i++)
                {
                    Layer img = Layers[i];
                    img.Dispose();
                    Layers.RemoveAt(i);
                    i--;
                }
            }
        }
        public void RemoveLayer()
        {
            if (SelectedIndex >= 0 && Layers.Count > 0 && SelectedIndex < Layers.Count)
            {
                Layer img = Layers[SelectedIndex];
                img.Dispose();
                Layers.RemoveAt(SelectedIndex);
                if (Layers.Count > 0)
                    SelectedIndex = Layers.Count - 1;
                else
                    SelectedIndex = -1;
            }
        }
        public Transform GetCurrentLayerTransform()
        {
            if (Layers.Count > 0 && SelectedIndex != -1)
            {
                return Layers[SelectedIndex].Transform;
            }
            return null;
        }

        public Layer GetCurrentLayer()
        {
            if (Layers.Count > 0 && SelectedIndex != -1)
            {
                return Layers[SelectedIndex];
            }
            return null;
        }


        public void UpdatePosition(int x, int y)
        {
            if(Layers.Count > 0 && SelectedIndex != -1)
            {
                Layers[SelectedIndex].Transform.Position = new Vector3(x, y, 0);
            }
        }

        public void UpdateCenterPosition(float x, float y)
        {
            if (Layers.Count > 0 && SelectedIndex != -1)
            {
                var pos = Layers[SelectedIndex].Transform.Position;
                var size = Layers[SelectedIndex].Transform.Size;
                var scale = Layers[SelectedIndex].Transform.Scale;
                pos.X = x - size.X / 2 * scale.X * ZoomPercent;
                pos.Y = y - size.Y / 2 * scale.Y * ZoomPercent;


                Layers[SelectedIndex].Transform.Position = pos;
            }
        }
       

        public void DrawLayers(Graphics e)
        {
            if (Layers.Count > 0)
            {
                e.SmoothingMode = SmoothingMode.AntiAlias;
                e.InterpolationMode = InterpolationMode.HighQualityBicubic;
                e.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                e.PixelOffsetMode = PixelOffsetMode.HighQuality;
                Layers = Layers.OrderBy(p=> p.Order).ToList();
                for (int i = 0; i < Layers.Count; i++)
                {
                    Layers[i].Draw(e, ZoomPercent);
                }
            }
        }

        public void ExportImage(string path, Size exportSize)
        {
            if (Layers.Count > 0)
            {
                Bitmap bm = new Bitmap(exportSize.Width, exportSize.Height);
                using (Graphics g = Graphics.FromImage(bm))
                {
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                    g.Clear(Color.Transparent);
                    for (int i = 0; i < Layers.Count; i++)
                    {
                        Layers[i].DrawToExport(g, ZoomPercent);
                    }
                }
                bm.Save(path);
                bm.Dispose();

            }
        }

        public void ConvertToScriptConfig(string savePath)
        {
            if(Layers.Count > 0)
            {
                ScriptConfig config = new ScriptConfig();
                for (int i = 0; i < Layers.Count; i++)
                {
                    Layer layer = Layers[i];
                    if(layer.LayerName.ToLower().StartsWith("textlayer"))
                    {
                        ScriptObject obj = new ScriptObject();
                        obj.LineJoin = (int)layer.LayerText.OutlineStyle;
                        obj.LogoContainer = layer.Transform.Size;
                        obj.LogoPosition = layer.Transform.Position;
                        obj.LogoRotation = layer.Transform.Rotation;
                        obj.LogoScale = layer.Transform.Scale;
                        obj.Order = layer.Order;
                        obj.OutlineColorHex = LogoUtil.ColorToHex(layer.LayerText.OutlineColor);
                        obj.OutlineSize = layer.LayerText.OutlineSize;
                        obj.TextColor = LogoUtil.ColorToHex(layer.LayerText.TextColor);
                        obj.FontSize = layer.LayerText.FontSize;
                        obj.FontName = "font.ttf";
                        config.LogoList.Add(obj);
                    }
                }
                FileUtil.WriteConfig<ScriptConfig>(config, savePath);
            }
        }

    }
}
