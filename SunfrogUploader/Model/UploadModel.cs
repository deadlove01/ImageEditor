using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunfrogUploader.Model
{

    public class ImageLink
    {
        public string id { get; set; }
        public string uri { get; set; }
    }

    public class ShirtType
    {
        public string id { get; set; }
        public string name { get; set; }
        public string price { get; set; }

        public List<string> colors { get; set; }

        public ShirtType()
        {
            colors = new List<string>();
        }
    }
    public class UploadModel
    {
        public string ArtOwnerID { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public bool IAgree { get; set; }
        public List<string> Keywords { get; set; }
        public string Title { get; set; }
        public string imageFront { get; set; }
        public string imageBack { get; set; }
        public List<ImageLink> images { get; set; }

        public List<ShirtType> types { get; set; }


        public UploadModel()
        {
            Keywords = new List<string>();
            images = new List<ImageLink>();

            types = new List<ShirtType>();
        }

    }
}
