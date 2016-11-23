using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoUpload.Models.Viralstyle
{
    public class Template
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public string CampUrl { get; set; }
        public string Tags { get; set; }

        public int Goal { get; set; }
        public bool AutoRelaunch { get; set; }

        public bool AutoExtend { get; set; }
        public bool HideMarketPlace { get; set; }
        public bool CampaignPageTimer { get; set; }
        public bool ShowGoal { get; set; }
        public bool ShowBackDefault { get; set; }
        public string TemplateName { get; set; }
    }
}
