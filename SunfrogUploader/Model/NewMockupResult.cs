using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoArtist.Model
{
    public class NewMockupModel
    {
        public string id { get; set; }
        public string pageName { get; set; }
        public string color { get; set; }
        public string imageFront { get; set; }
        public string imageBack { get; set; }
    }


    public class UploadNewResult
    {
        public double executionTime { get; set; }
        public string result { get; set; }
        public string description { get; set; }
        public string artBack { get; set; }
        public string artFront { get; set; }
        public List<NewMockupModel> products { get; set; }

        public UploadNewResult()
        {
            products = new List<NewMockupModel>();
        }
    }
}
