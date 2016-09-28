using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViralStyleUploader.Models
{
    public class LoginModel
    {
        [JsonProperty("email_address")]
        public string Email { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("remember")]
        public bool Remember { get; set; }

        public LoginModel()
        {

        }

        public LoginModel(string email, string pass, bool remember)
        {
            this.Email = email;
            this.Password = pass;
            this.Remember = remember;
        }
    }
}
