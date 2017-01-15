using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunfrogUploader.Model
{
    public class UpdateMockupModel
    {
        public List<ShirtType> types { get; set; }
        public List<ShirtStyle> styles { get; set; }

        public string ArtOwnerID { get; set; }
        public bool IAgree { get; set; }
        public string IsAddVariantGroup { get; set; }
        public bool isAddVariant { get; set; }

        public UpdateMockupModel()
        {
            types = new List<ShirtType>();
            styles = new List<ShirtStyle>();
        }

    }


    public class ShirtStyle
    {
        public string id { get; set; }
        public string name { get; set; }
    }
}
