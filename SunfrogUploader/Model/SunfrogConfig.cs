using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunfrogUploader.Model
{
    public class SunfrogConfig
    {
        public string SFAcc { get; set; }
        public string SFPass { get; set; }
        public int StartRange { get; set; }
        public int EndRange { get; set; }
        public string Logo { get; set; }
        public string Content { get; set; }
        public bool IsAutoLogo { get; set; }
        public bool IsSaveDB { get; set; }

        public SunfrogConfig() { }
        public SunfrogConfig(string acc, string pass, int start, int end, string logo, string content, bool autoLogo, bool saveDB)
        {
            this.SFAcc = acc;
            this.SFPass = pass;
            this.StartRange = start;
            this.EndRange = end;
            this.Logo = logo;
            this.Content = content;
            this.IsAutoLogo = autoLogo;
            this.IsSaveDB = saveDB;
        }
    }
}
