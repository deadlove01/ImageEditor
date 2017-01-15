using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Diagnostics;
using System.Drawing.Imaging;
using AutoArtist.Model;
using AutoArtist.Util;
using EnvelopeDistortion.Distortions;
using System.Threading;
namespace AutoArtist.Controller
{
    public class ArtistController : Singleton<ArtistController>
    {
        private ArtistProps props;
        private StringFormat stringFormat;
        private LayerManager layerManager;

        public ArtistController()
        {
            stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            stringFormat.FormatFlags = StringFormatFlags.FitBlackBox | StringFormatFlags.NoWrap;
            stringFormat.Trimming = StringTrimming.Character;
            
            layerManager = new LayerManager();
            layerManager.ZoomPercent = 0.15f;
        }


        private Font GetCustomFont(String path, int size)
        {
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile(path);
            return new Font(pfc.Families[0], size, FontStyle.Regular, GraphicsUnit.Pixel);
        }


        private void Init(string logoRootPath, string logoName)
        {
            props = new ArtistProps();
            props.StringFormat = stringFormat;
            props.LogoRootPath = logoRootPath + logoName + "\\";
            props.ScriptConfig = FileUtil.ReadConfig<ScriptConfig>(props.LogoRootPath + "script.xml");
            props.LogoTypeName = logoName;

            layerManager.RemoveAllLayer();
            layerManager.AddLayer(props.LogoRootPath + "logo.png");
        }

        public void DrawByName(string name, string exportPath, string logoName,
            string splitString, string exportSplitString, bool isScaleAll)
        {
            if (!Directory.Exists(exportPath))
            {
                Directory.CreateDirectory(exportPath);
            }

            // get list logo order behind main logo
            ScriptConfig config = props.ScriptConfig;
            List<ScriptObject> logoList = config.LogoList.OrderBy(p => p.Order).ToList();
            string[] names = name.Trim().Split(new string[] { splitString}, StringSplitOptions.None);
            string exportName = name.Replace(splitString, exportSplitString);
            for (int i = 0; i < names.Length; i++)
            {
                ScriptObject obj = logoList[i];
                string fontPath = props.LogoRootPath + obj.FontName;
                Font ff = GetCustomFont(fontPath, obj.FontSize);
                {
                    Layer layer = new Layer(new LayerText(names[i], ff, obj.FontSize, LogoUtil.ConvertStringToColor(obj.TextColor)
                        , (int)obj.OutlineSize, LogoUtil.ConvertStringToColor(obj.OutlineColorHex)
                        , (LineJoin)obj.LineJoin));

                    layer.UpdateLayer(obj.LogoPosition, obj.LogoScale, obj.LogoRotation, obj.LogoContainer);
                    layerManager.AddTextLayer(layer);
                }

            }
            if (logoList.Count > 0)
            {
                layerManager.ExportImage(exportPath + exportName + ".png", new Size(2400, 3200), isScaleAll);
            }

        }
    
        public void ExportLogo(string name, string exportPath, string logoRootPath, string logoName,
            string splitString, string exportSplitString, bool isScaleAll)
        {
             Init(logoRootPath, logoName);
            if (exportPath[exportPath.Length - 1] != '\\')
                exportPath += "\\";
            DrawByName(name, exportPath, logoName, splitString, exportSplitString, isScaleAll);
        }


    }
}
