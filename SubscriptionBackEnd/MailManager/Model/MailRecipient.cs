using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailManager
{
    public class MailRecipient
    {
        public string Name { get; set; }
        public string MailAddress { get; set; }
        public MailRecipientTypeEnum MailRecipientType { get; set; }
    }
}
