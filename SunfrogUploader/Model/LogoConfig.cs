using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunfrogUploader.Model
{

    public enum NameType
    {
        LOWER = 0,
        UPPER = 1,
        FIRST_UPPER = 2
    }
    public class LogoConfig
    {
        public int NameType { get; set; }
        public string PrimaryMockupName { get; set; }
        public string GuysColor { get; set; }
        public string LadiesColor { get; set; }
        public string HoodieColor { get; set; }
        public string YouthTeeColor { get; set; }
        public string MockupPosition { get; set; }
        public string MockupScale { get; set; }
        

        public string SweatShirtColor { get; set; }
        public string GuysVNeck { get; set; }
        public string LadiesVNeck { get; set; }
        public string UnisexTankTop { get; set; }
        public string UnisexLongSleeve { get; set; }

        

        public LogoConfig()
        {

        }

        public LogoConfig(int nameType, string mockupName, string guysColor, 
            string ladiescolor, string hoodieColor, string mockupPosition,
            string mockupScale)
        {
            this.NameType = nameType;
            this.PrimaryMockupName = mockupName;
            this.GuysColor = guysColor;
            this.LadiesColor = ladiescolor;
            this.HoodieColor = hoodieColor;
            this.MockupPosition = mockupPosition;
            this.MockupScale = mockupScale;
        }
    }
}
