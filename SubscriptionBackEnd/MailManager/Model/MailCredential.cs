using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailManager
{
    public class MailCredential
    {
        public string DefaultName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool UseSsl { get; set; }
        public int Port { get; set; }
        public string Host { get; set; }
    }
}
