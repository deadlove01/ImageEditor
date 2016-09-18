using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeespringUploader.Model
{
    

    public class Product
    {
        public int id { get; set; }
        public float price { get; set; }
        public int[] colors { get; set; }
        public string currency { get; set; }
        public string orientation { get; set; }

        public Product()
        {

        }

        public Product(int id, float price, int[] colors, string currency, string orientation)
        {
            this.id = id;
            this.price = price;
            this.colors = colors;
            this.currency = currency;
            this.orientation = orientation;
        }

        public Product(int id, int[] colors)
        {
            this.id = id;
            this.colors = colors;
        }
    }


    public class PrintableArea
    {
        public string front { get; set; }
        public string back { get; set; }

        public PrintableArea()
        {

        }

        public PrintableArea(string front, string back)
        {
            this.front = front;
            this.back = back;
        }
    }


    public class DesignModel
    {
        public string lookupId { get; set; }
        public Sides sides { get; set; }
        public string activeSide { get; set; }
        public bool high_quality_artwork { get; set; }
        public int product_type_id { get; set; }
        public int frontColors { get; set; }
        public bool flashFront { get; set; }
        public int backColors { get; set; }
        public bool flashBack { get; set; }

        public DesignModel()
        {

        }
        public DesignModel(string looupId, Sides sides, string activeSide, bool high_quality_artwork,
            int product_type_id, int frontColors, bool flashFront, int backColors, bool flashBack)
        {
            this.lookupId = lookupId;
            this.sides = sides;
            this.activeSide = activeSide;
            this.high_quality_artwork = high_quality_artwork;
            this.product_type_id = product_type_id;
            this.flashBack = flashBack;
            this.flashFront = flashFront;
            this.frontColors = frontColors;
            this.backColors = backColors;
        }

       


    }


    public class Sides
    {
        public SideLayer front { get; set; }
        public SideLayer back { get; set; }
    }


    public class RemoveLayerBinding
    {

    }
    public class SideLayer
    {
        public RemoveLayerBinding removeLayerBinding { get; set; }
        public string name { get; set; }
        public TeeLayer[] layers { get; set; }
        public Box bbox { get; set; }
        public Box absoluteBBox { get; set; }
        public bool beingViewed { get; set; }
        public object initialFreeTransformAttrs { get; set; }
        public object initialPrintableArea { get; set; }
        public RefPoint referencePoint { get; set; }
        public float ppi { get; set; }
        public object editable { get; set; }
        public int sequence { get; set; }
        public string priorPrintableBox { get; set; }
        public object scaleAndMove { get; set; }
        public TeeColor[] colors { get; set; }
        public RasterImageInfo[] rasterImageInfo { get; set; }
        public string svg { get; set; }


        public SideLayer(string name, TeeLayer[] layers, Box bbox, Box absoluteBBox, bool beingViewed,
            RefPoint referencePoint, float ppi, int sequence, string priorPrintableBox, TeeColor[] colors,
            RasterImageInfo[] rasterImageInfo)
        {
            this.name = name;
            this.layers = layers;
            this.bbox = bbox;
            this.absoluteBBox = absoluteBBox;
            this.beingViewed = beingViewed;
            this.referencePoint = referencePoint;
            this.ppi = ppi;
            this.sequence = sequence;
            this.priorPrintableBox = priorPrintableBox;
            this.colors = colors;
            this.rasterImageInfo = rasterImageInfo;
        }

        public SideLayer()
        {

        }
    }


    public class Box
    {
        public float x { get; set; }
        public float y { get; set; }
        public float width { get; set; }
        public float height { get; set; }
    }


    public class RefPoint
    {
        public float x { get; set; }
        public int y { get; set; }
    }

    public class TeeLayer
    {
        public string filename { get; set; }
        public string originalFilename { get; set; }
        public string sourceFilename { get; set; }
        public object ratio { get; set; }
        public string format { get; set; }
        public int initialScale { get; set; }
        public object[] transformations { get; set; }
        public Matrix matrix { get; set; }
        public TeeColor[] colors { get; set; }
        public object minimumPPI { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public bool beingEdited { get; set; }
        public string origin { get; set; }
        public Box absoluteBBox { get; set; }
        public string type { get; set; }
        public Box bbox { get; set; }
        public bool preservecolors { get; set; }
        public object fillColor { get; set; }
        public int outlineThickness { get; set; }
        public Outlinecolor outlineColor { get; set; }
        public NewDesignData newDesignData { get; set; }
    }

    public class Matrix
    {
        public float a { get; set; }
        public int b { get; set; }
        public int c { get; set; }
        public float d { get; set; }
        public float e { get; set; }
        public int f { get; set; }
    }

    public class Outlinecolor
    {
        public string id { get; set; }
        public string value { get; set; }
        public object origin { get; set; }
        public bool heather { get; set; }
        public string texture { get; set; }
    }

    public class NewDesignData
    {
        public Transform transform { get; set; }
    }

    public class Transform
    {
        public float translateX { get; set; }
        public int translateY { get; set; }
        public float scaleX { get; set; }
        public float scaleY { get; set; }
        public int flipX { get; set; }
        public int flipY { get; set; }
        public int rotate { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class TeeColor
    {
        public string id { get; set; }
        public string value { get; set; }
        public object origin { get; set; }
        public bool heather { get; set; }
        public string texture { get; set; }
    }

    public class RasterImageInfo
    {
        public int width { get; set; }
        public int height { get; set; }
        public string format { get; set; }
    }


}
