using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailManager
{
    public class MailContent
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Footer { get; set; }
        public List<MailRecipient> MailRecipients { get; set; }
        public List<MailAttachment> MailAttachments { get; set; }
    }
}
