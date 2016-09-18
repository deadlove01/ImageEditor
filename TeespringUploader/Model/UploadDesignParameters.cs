using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TeespringUploader.Model
{

    public class DesignParameter
    {
        public string id { get; set; }
        public string lookup_id { get; set; }
        public string last_saved { get; set; }
        public bool assets_generated { get; set; }
        public string partnership { get; set; }
        public string partnership_banner { get; set; }
        public string currency { get; set; }
        public string region { get; set; }
        public string additionalMerchSide { get; set; }
        public string priorPrintableArea { get; set; }
        public string micro_id { get; set; }
        public string launch_stage { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string description { get; set; }
        public int length { get; set; }
        public string pickupinstructions { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string address { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public bool backDefaultSide { get; set; }
        public string products { get; set; }
        public string default_arts { get; set; }
        public string additional_merchandise { get; set; }
        public string client { get; set; }
        public string selling_price { get; set; }
        public string item_profit { get; set; }
        public string cost { get; set; }
        public string defaultProduct { get; set; }
        public bool hadInvalidProductOption { get; set; }
        public bool pickup { get; set; }
        public string design { get; set; }
        public int tipping_point { get; set; }
        public string facebook_snippet { get; set; }
        public string store_ids { get; set; }
        public string audience_ids { get; set; }
        public string tags { get; set; }
        public string recentArts { get; set; }
        public string stage { get; set; }


        public DesignParameter()
        {

        }


        public DesignParameter(string lookupId, string name, string title, string description, string tags, string randImgName, string imageUrl, string orgImgName)
        {
            this.lookup_id = lookupId;
            this.assets_generated = false;
            this.currency = "USD";
            this.region = "USA";
            this.additionalMerchSide = "front";

            PrintableArea printableArea = new PrintableArea("160,140,205,240", "155,120,215,330");
            this.priorPrintableArea = JsonConvert.SerializeObject(printableArea);
            this.launch_stage = "Details";
            this.name = name;
            this.description = description;
            this.length = 3;
            this.url = title;

            this.backDefaultSide = false;
            Product product = new Product(212, 38.99f, new int[] { 5819}, "USD", "Portrait");
            List<Product> products = new List<Product>();
            products.Add(product);
            this.products = JsonConvert.SerializeObject(products) ;
            //this.products = "[{ \"id\":212, \"price\":38.99, \"colors\":[5819],\"currency\":\"USD\", \"orientation\":\"Portrait\" }]";
            Product defProduct = new Product(2, new int[] { 2122 });
            //this.defaultProduct = "{ \"id\":2,\"colors\":[2122]}";
            this.defaultProduct = JsonConvert.SerializeObject(defProduct);
            this.hadInvalidProductOption = false;
            this.pickup = false;


            // colors
            TeeColor[] teeColors = new TeeColor[] {
                new TeeColor
                {
                    id = "",
                    value = "rgb(252,252,252)",
                    texture = ""
                },
                new TeeColor
                {
                    id = "",
                    value = "rgb(252,188,60)",
                    texture = ""
                }
            };

            // layers
            TeeLayer teeLayer = new TeeLayer
            {
                filename = randImgName,
                originalFilename = imageUrl,
                sourceFilename = orgImgName,
                format = "png",
                initialScale = 1,
                matrix = new Matrix
                {
                    a = 0.075f,
                    b = 0,
                    c = 0,
                    d = 0.075f,
                    e =172.5f,
                    f = 140
                },
                colors = teeColors,
                width = 2400,
                height = 3200,
                origin = "Upload",
                bbox = new Box
                {
                    x = 172.5f,
                    y = 140,
                    width = 180,
                    height = 240
                },
                absoluteBBox = new Box
                {
                    x = 37,
                    y = 393,
                    width = 2355,
                    height = 916
                },
                type = "image",
                preservecolors = true,
                outlineThickness = 0,
                outlineColor = new Outlinecolor
                {
                    id = "default0",
                    value = "#000000",
                    texture = ""
                },
                newDesignData = new NewDesignData
                {
                    transform = new Transform
                    {
                        flipX = 1,
                        flipY = 1,
                        height = 3200,
                        rotate  =0,
                        scaleX = 0.075f,
                        scaleY = 0.075f,
                        translateX = 262.5f,
                        translateY = 260,
                        width = 2400
                    }
                }
            };

            RasterImageInfo rii = new RasterImageInfo
            {
                width = 2400,
                height =  3200,
                format = "png"
            };

            SideLayer frontLayer = new SideLayer
            {
                name = "front",
                layers = new TeeLayer[] { teeLayer },
                bbox = new Box
                {
                    height = 240,
                    width = 180,
                    x = 172.5f,
                    y = 140
                },
                absoluteBBox = new Box
                {
                    x = 175.275f,
                    y = 169.475f,
                    width = 176.62499999999997f,
                    height = 68.70000000000002f
                },
                referencePoint = new RefPoint
                {
                    x = 182.5f,
                    y = 88
                },
                ppi = 17.4545454545455f,

                priorPrintableBox = "160,140,205,240",
                colors = teeColors,
                rasterImageInfo = new RasterImageInfo[] { rii },
                svg = "<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"854px\" height=\"1000px\" viewBox=\"160 140 205 240\"> \t <defs data-element=\"defs\"> \t <clipPath data-element=\"globalClipPath\" id=\"global-clip-path-front-4\"> \t <rect x=\"160\" y=\"140\" width=\"205\" height=\"240\" data-element=\"globalClipRect\"></rect> \t </clipPath> \t </defs> \t <g data-element=\"rootTag\" clip-path=\"url(#global-clip-path-front-4)\"><g data-id=\"front-layer-0\" data-width=\"2400\" data-height=\"3200\" transform=\"matrix(0.075, 0, 0, 0.075, 172.5, 140)\"><image data-imageuri=\"https://s3.amazonaws.com//teespring-usercontent/{rand_name}\" xlink:href=\"https://s3.amazonaws.com//teespring-usercontent/{rand_name}\" width=\"2400\" height=\"3200\"></image></g></g> \t </svg>",
                sequence = 1,
            };
            frontLayer.svg = (frontLayer.svg.Replace("{rand_name}", randImgName));

            SideLayer backLayer = new SideLayer
            {
                name = "back",
                referencePoint = new RefPoint
                {
                    x = 185,
                    y = 111
                },
                bbox = new Box(),
                ppi = 17.4545454545455f,
                colors = new TeeColor[] { },
                rasterImageInfo = new RasterImageInfo[] { },
                layers = new TeeLayer[] {},

                svg = "<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"651px\" height=\"1000px\" viewBox=\"155 120 215 330\"> \t <defs data-element=\"defs\"> \t <clipPath data-element=\"globalClipPath\" id=\"global-clip-path-back-5\"> \t <rect x=\"155\" y=\"120\" width=\"215\" height=\"330\" data-element=\"globalClipRect\"></rect> \t </clipPath> \t </defs> \t <g data-element=\"rootTag\" clip-path=\"url(#global-clip-path-back-5)\"></g> \t </svg>"
            };


            Sides sides = new Sides
            {
                front = frontLayer,
                back = backLayer
            };
            DesignModel designModel = new DesignModel
            {
                lookupId = lookupId,
                sides = sides,
                activeSide = "front",
                high_quality_artwork = true,
                product_type_id = 5,
                frontColors = 3,
                flashFront = true,
                backColors = 0,
                flashBack = false,
                
            };
            this.design = JsonConvert.SerializeObject(designModel);
            //this.design = "{\"lookupId\":\"{lookupid}\",\"sides\":{\"front\":{\"removeLayerBinding\":{},\"name\":\"front\",\"layers\":[{\"filename\":\"{filename}\",\"originalFilename\":\"{image_url}\",\"sourceFilename\":\"{original_name}\",\"ratio\":null,\"format\":\"png\",\"initialScale\":1,\"transformations\":[],\"matrix\":{\"a\":0.075,\"b\":0,\"c\":0,\"d\":0.075,\"e\":172.5,\"f\":140},\"colors\":[{\"id\":\"\",\"value\":\"rgb(180, 228, 236)\",\"origin\":null,\"heather\":false,\"texture\":\"\"}],\"minimumPPI\":null,\"width\":2400,\"height\":3200,\"beingEdited\":false,\"origin\":\"Upload\",\"absoluteBBox\":{\"x\":53,\"y\":103,\"width\":2269,\"height\":2283},\"type\":\"Image\",\"bbox\":{\"x\":172.5,\"y\":140,\"width\":180,\"height\":240},\"preserve-colors\":true,\"fillColor\":null,\"outlineThickness\":0,\"outlineColor\":{\"id\":\"default0\",\"value\":\"#000000\",\"origin\":null,\"heather\":false,\"texture\":\"\"},\"newDesignData\":{\"transform\":{\"translateX\":262.5,\"translateY\":260,\"scaleX\":0.075,\"scaleY\":0.075,\"flipX\":1,\"flipY\":1,\"rotate\":0,\"width\":2400,\"height\":3200}}}],\"bbox\":{\"x\":172.5,\"y\":140,\"width\":180,\"height\":240},\"absoluteBBox\":{\"x\":176.475,\"y\":147.725,\"width\":170.17499999999998,\"height\":171.225},\"beingViewed\":false,\"initialFreeTransformAttrs\":null,\"initialPrintableArea\":null,\"referencePoint\":{\"x\":182.5,\"y\":88},\"ppi\":17.4545454545455,\"editable\":null,\"sequence\":1,\"priorPrintableBox\":\"160,140,205,240\",\"scaleAndMove\":null,\"colors\":[{\"id\":\"\",\"value\":\"rgb(180, 228, 236)\",\"origin\":null,\"heather\":false,\"texture\":\"\"}],\"rasterImageInfo\":[{\"width\":2400,\"height\":3200,\"format\":\"png\"}],\"svg\":\"<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"854px\" height=\"1000px\" viewBox=\"160 140 205 240\"> \t          <defs data-element=\"defs\"> \t              <clipPath data-element=\"globalClipPath\" id=\"global-clip-path-front-4\"> \t                  <rect x=\"160\" y=\"140\" width=\"205\" height=\"240\" data-element=\"globalClipRect\"></rect> \t              </clipPath> \t          </defs> \t          <g data-element=\"rootTag\" clip-path=\"url(#global-clip-path-front-4)\"><g data-id=\"front-layer-0\" data-width=\"2400\" data-height=\"3200\" transform=\"matrix(0.075, 0, 0, 0.075, 172.5, 140)\"><image data-imageuri=\"https://s3.amazonaws.com//teespring-usercontent/{filename}\" xlink:href=\"https://s3.amazonaws.com//teespring-usercontent/{filename}\" width=\"2400\" height=\"3200\"></image></g></g> \t      </svg>\"},\"back\":{\"removeLayerBinding\":{},\"name\":\"back\",\"layers\":[],\"bbox\":{\"x\":null,\"y\":null,\"width\":null,\"height\":null},\"absoluteBBox\":{},\"beingViewed\":false,\"initialFreeTransformAttrs\":null,\"initialPrintableArea\":null,\"referencePoint\":{\"x\":185,\"y\":111},\"ppi\":17.4545454545455,\"editable\":null,\"priorPrintableBox\":\"155,120,215,330\",\"scaleAndMove\":null,\"colors\":[],\"rasterImageInfo\":[],\"svg\":\"<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"651px\" height=\"1000px\" viewBox=\"155 120 215 330\"> \t          <defs data-element=\"defs\"> \t              <clipPath data-element=\"globalClipPath\" id=\"global-clip-path-back-5\"> \t                  <rect x=\"155\" y=\"120\" width=\"215\" height=\"330\" data-element=\"globalClipRect\"></rect> \t              </clipPath> \t          </defs> \t          <g data-element=\"rootTag\" clip-path=\"url(#global-clip-path-back-5)\"></g> \t      </svg>\"}},\"activeSide\":\"front\",\"high_quality_artwork\":true,\"product_type_id\":5,\"frontColors\":2,\"flashFront\":true,\"backColors\":0,\"flashBack\":false}";
            //this.design.Replace("{lookupid}", lookupId);
            //this.design.Replace("{filename}", randImgName);
            //this.design.Replace("{image_url}", imageUrl);
            //this.design.Replace("{original_name}", orgImgName);
            this.tipping_point = 4;
            this.tags = tags;
            this.stage = "details";
            this.default_arts =  additional_merchandise = store_ids = audience_ids = recentArts = "[]";

        }

        public NameValueCollection ConvertToNVC()
        {
            NameValueCollection nvc = new NameValueCollection();
            var props = this.GetType().GetProperties();
            for (int i = 0; i < props.Length; i++)
            {
                var prop = props[i];
                object val = prop.GetValue(this, null);
                nvc.Add(prop.Name, val == null ? "" : (val.ToString()));
            }

            return nvc;
        }
    }


    public class UploadDesignParameters
    {
        public string id { get; set; }
        public string lookup_id { get; set; }
        public string last_saved { get; set; }
        public bool assets_generated { get; set; }
        public string partnership { get; set; }
        public string partnership_banner { get; set; }
        public string currency { get; set; }
        public string region { get; set; }
        public string additionalMerchSide { get; set; }
        public string priorPrintableArea { get; set; }
        public string micro_id { get; set; }
        public string launch_stage { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string description { get; set; }
        public int length { get; set; }
        public string pickupinstructions { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string address { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public bool backDefaultSide { get; set; }
        public string products { get; set; }
        public string[] additional_merchandise { get; set; }
        public string[] defaultArts { get; set; }
        public string client { get; set; }
        public string selling_price { get; set; }
        public string item_profit { get; set; }
        public string cost { get; set; }
        public string defaultProduct { get; set; }
        public bool hadInvalidProductOption { get; set; }
        public bool pickup { get; set; }
        public string design { get; set; }
        public int tipping_point { get; set; }
        public string facebook_snippet { get; set; }
        public string[] store_ids { get; set; }
        public string[] audience_ids { get; set; }
        public string tags { get; set; }
        public string[] recentArts { get; set; }
        public string stage { get; set; }
        public string title { get; set; }

        public UploadDesignParameters()
        {

        }


        public UploadDesignParameters(string lookupId, string name, string title, string description, string tags, string randImgName, string imageUrl, string orgImgName)
        {
            this.lookup_id = lookupId;
            this.assets_generated = false;
            this.currency = "USD";
            this.region = "USA";
            this.additionalMerchSide = "front";
            this.priorPrintableArea = "{ \"front\":\"160,140,205,240\",\"back\":\"155,120,215,330\"}";
            this.launch_stage = "Details";
            this.name = name;
            this.title = title;
            this.description = description;
            this.length = 3;
            this.url = title;

            this.backDefaultSide = false;
            this.products = "[{ \"id\":212, \"price\":38.99, \"colors\":[5819],\"currency\":\"USD\", \"orientation\":\"Portrait\" }]";
            this.defaultProduct = "{ \"id\":2,\"colors\":[2122]}";
            this.hadInvalidProductOption = false;
            this.pickup = false;

            this.design = "{\"lookupId\":\"{lookupid}\",\"sides\":{\"front\":{\"removeLayerBinding\":{},\"name\":\"front\",\"layers\":[{\"filename\":\"{filename}\",\"originalFilename\":\"{image_url}\",\"sourceFilename\":\"{original_name}\",\"ratio\":null,\"format\":\"png\",\"initialScale\":1,\"transformations\":[],\"matrix\":{\"a\":0.075,\"b\":0,\"c\":0,\"d\":0.075,\"e\":172.5,\"f\":140},\"colors\":[{\"id\":\"\",\"value\":\"rgb(180, 228, 236)\",\"origin\":null,\"heather\":false,\"texture\":\"\"}],\"minimumPPI\":null,\"width\":2400,\"height\":3200,\"beingEdited\":false,\"origin\":\"Upload\",\"absoluteBBox\":{\"x\":53,\"y\":103,\"width\":2269,\"height\":2283},\"type\":\"Image\",\"bbox\":{\"x\":172.5,\"y\":140,\"width\":180,\"height\":240},\"preserve-colors\":true,\"fillColor\":null,\"outlineThickness\":0,\"outlineColor\":{\"id\":\"default0\",\"value\":\"#000000\",\"origin\":null,\"heather\":false,\"texture\":\"\"},\"newDesignData\":{\"transform\":{\"translateX\":262.5,\"translateY\":260,\"scaleX\":0.075,\"scaleY\":0.075,\"flipX\":1,\"flipY\":1,\"rotate\":0,\"width\":2400,\"height\":3200}}}],\"bbox\":{\"x\":172.5,\"y\":140,\"width\":180,\"height\":240},\"absoluteBBox\":{\"x\":176.475,\"y\":147.725,\"width\":170.17499999999998,\"height\":171.225},\"beingViewed\":false,\"initialFreeTransformAttrs\":null,\"initialPrintableArea\":null,\"referencePoint\":{\"x\":182.5,\"y\":88},\"ppi\":17.4545454545455,\"editable\":null,\"sequence\":1,\"priorPrintableBox\":\"160,140,205,240\",\"scaleAndMove\":null,\"colors\":[{\"id\":\"\",\"value\":\"rgb(180, 228, 236)\",\"origin\":null,\"heather\":false,\"texture\":\"\"}],\"rasterImageInfo\":[{\"width\":2400,\"height\":3200,\"format\":\"png\"}],\"svg\":\"<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"854px\" height=\"1000px\" viewBox=\"160 140 205 240\"> \t          <defs data-element=\"defs\"> \t              <clipPath data-element=\"globalClipPath\" id=\"global-clip-path-front-4\"> \t                  <rect x=\"160\" y=\"140\" width=\"205\" height=\"240\" data-element=\"globalClipRect\"></rect> \t              </clipPath> \t          </defs> \t          <g data-element=\"rootTag\" clip-path=\"url(#global-clip-path-front-4)\"><g data-id=\"front-layer-0\" data-width=\"2400\" data-height=\"3200\" transform=\"matrix(0.075, 0, 0, 0.075, 172.5, 140)\"><image data-imageuri=\"https://s3.amazonaws.com//teespring-usercontent/{filename}\" xlink:href=\"https://s3.amazonaws.com//teespring-usercontent/{filename}\" width=\"2400\" height=\"3200\"></image></g></g> \t      </svg>\"},\"back\":{\"removeLayerBinding\":{},\"name\":\"back\",\"layers\":[],\"bbox\":{\"x\":null,\"y\":null,\"width\":null,\"height\":null},\"absoluteBBox\":{},\"beingViewed\":false,\"initialFreeTransformAttrs\":null,\"initialPrintableArea\":null,\"referencePoint\":{\"x\":185,\"y\":111},\"ppi\":17.4545454545455,\"editable\":null,\"priorPrintableBox\":\"155,120,215,330\",\"scaleAndMove\":null,\"colors\":[],\"rasterImageInfo\":[],\"svg\":\"<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"651px\" height=\"1000px\" viewBox=\"155 120 215 330\"> \t          <defs data-element=\"defs\"> \t              <clipPath data-element=\"globalClipPath\" id=\"global-clip-path-back-5\"> \t                  <rect x=\"155\" y=\"120\" width=\"215\" height=\"330\" data-element=\"globalClipRect\"></rect> \t              </clipPath> \t          </defs> \t          <g data-element=\"rootTag\" clip-path=\"url(#global-clip-path-back-5)\"></g> \t      </svg>\"}},\"activeSide\":\"front\",\"high_quality_artwork\":true,\"product_type_id\":5,\"frontColors\":2,\"flashFront\":true,\"backColors\":0,\"flashBack\":false}";
            this.design.Replace("{lookupid}", lookupId);
            this.design.Replace("{filename}", randImgName);
            this.design.Replace("{image_url}", imageUrl);
            this.design.Replace("{original_name}", orgImgName);
            this.tipping_point = 4;
            this.tags = tags;
            this.stage = "details";

        }


        public override string ToString()
        {
            var props = this.GetType().GetProperties();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < props.Length; i++)
            {
                var prop = props[i];
                if (i != props.Length - 1)
                {
                    sb.Append(string.Format("{0}={1}&", prop.Name, prop.GetValue(this, null)));
                }
                else
                {
                    sb.Append(string.Format("{0}={1}", prop.Name, prop.GetValue(this, null)));
                }
            }

            return sb.ToString();

        }


        public NameValueCollection ConvertToNVC()
        {
            NameValueCollection nvc = new NameValueCollection();
            var props = this.GetType().GetProperties();
            for (int i = 0; i < props.Length; i++)
            {
                var prop = props[i];
                object val = prop.GetValue(this, null);
                nvc.Add(prop.Name, val == null ? "" : (val.ToString()));
            }

            return nvc;
        }
    }
}
