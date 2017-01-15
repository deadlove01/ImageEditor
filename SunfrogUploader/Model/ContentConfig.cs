using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunfrogUploader.Model
{
    public class ContentConfig
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public string Category { get; set; }
        public string SiteTags { get; set; }
        public double GuysPrice { get; set; }
        public double LadiesPrice { get; set; }
        public double HoodiesPrice { get; set; }

        public double YouthTeePrice { get; set; }


        public double SweatShirtPrice { get; set; }
        public double GuysVNeckPrice { get; set; }
        public double LadiesVNeckPrice { get; set; }
        public double UnisexTankTopPrice { get; set; }
        public double UnisexLongSleeve { get; set; }
    }
}
