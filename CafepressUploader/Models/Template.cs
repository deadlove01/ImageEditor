using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafepressUploader.Models
{
    public class Template
    {
        public string Name { get; set; }
        public string Tags { get; set; }
        public string About { get; set; }

        public Template()
        {

        }

        public Template(string name, string tags, string about)
        {
            this.Name = name;
            this.Tags = tags;
            this.About = about;
        }
    }
}
