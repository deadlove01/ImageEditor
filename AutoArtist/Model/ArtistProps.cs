using AutoArtist.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoArtist.Model
{
    public class ArtistProps
    {
        public Font LogoFont { get; set; }
        public String LogoRootPath { get; set; }

        public string LogoTypeName { get; set; }

        public ScriptConfig ScriptConfig { get; set; }

        public StringFormat StringFormat { get; set; }
    }
}
