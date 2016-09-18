using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeespringUploader.Model
{
    public class LogoModel
    {
        public string filePath { get; set; }
        public string fileType { get; set; }
        public LogoModel()
        {

        }


        public LogoModel(string filePath, string fileType)
        {
            this.filePath = filePath;
            this.fileType = fileType;
        }
    }

    public class SignedResponse
    {
        public string signed_request { get; set; }
        public string url { get; set; }
        public SignedResponse()
        {

        }

        public SignedResponse(string signedRequest, string url)
        {
            this.signed_request = signedRequest;
            this.url = url;
        }


        public override string ToString()
        {
            return "Signed_request: " + signed_request + ", url: " + url;
        }
    }
}
