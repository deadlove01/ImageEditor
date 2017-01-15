using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangePassword.Models
{
    public class Gmail
    {
        public string ID { get; set; }
        public string OldPass { get; set; }
        public string NewPass { get; set; }
        public string RecoveryEmail { get; set; }

        public Gmail()
        {

        }

        public Gmail(string id, string oldPass, string newPass)
        {
            this.ID = id;
            this.OldPass = oldPass;
            this.NewPass = newPass;
        }

        public Gmail(string rawString)
        {
            string[] temp = rawString.Split('/');
            this.ID = temp[0];
            this.OldPass = temp[1];
            this.RecoveryEmail = temp[2];
            //this.NewPass = temp[2];
        }
    }
}
