using MongoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunfrogUploader.Model
{
    public class ArtModel: Entity
    {
        public string Name { get; set; }
        public string LogoName { get; set; }
        public string Title { get; set; }
        public string HoodieLink { get; set; }
        public string HoodieImage { get; set; }
        public string GuysLink { get; set; }
        public string GuysImage { get; set; }
        public string LadiesLink { get; set; }
        public string LadiesImage { get; set; }
        public string AccountUpload { get; set; }


        public ArtModel()
        {

        }
        
    }
}
