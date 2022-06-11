using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MailManager
{
    public class MailManager
    {
        public MailCredential MailCredential { get; set; }
        public MailContent MailContent { get; set; }

        public MailManager(MailCredential mailCredential)
        {
            this.MailCredential = mailCredential;
        }

        public MailManager()
        {

        }

        public void SendMail(MailContent mailContent)
        {
            MailContent = mailContent;
            SendMail();
        }

        public void SendMail()
        {
            using (SmtpClient client = new SmtpClient())
            {
                client.Port = MailCredential.Port;
                client.Host = MailCredential.Host;
                client.EnableSsl = MailCredential.UseSsl;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(MailCredential.Username, MailCredential.Password);
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(MailCredential.Username, !string.IsNullOrEmpty(MailCredential.DefaultName) ? MailCredential.DefaultName : MailCredential.Username);
                MailContent.MailRecipients.ForEach(mr =>
                {
                    if (mr.MailRecipientType == MailRecipientTypeEnum.To)
                    {
                        mail.To.Add(mr.MailAddress);
                    }
                    else if (mr.MailRecipientType == MailRecipientTypeEnum.Cc)
                    {
                        mail.CC.Add(mr.MailAddress);
                    }
                    else if (mr.MailRecipientType == MailRecipientTypeEnum.Bcc)
                    {
                        mail.Bcc.Add(mr.MailAddress);
                    }

                });

                MailContent.MailAttachments.ForEach(ma =>
                {
                    System.Net.Mail.Attachment attachment;

                    if (!String.IsNullOrWhiteSpace(ma.Name))
                    {
                        System.Net.Mime.ContentType contentType = new System.Net.Mime.ContentType();
                        contentType.MediaType = System.Net.Mime.MediaTypeNames.Application.Octet;
                        contentType.Name = ma.Name;
                        attachment = new System.Net.Mail.Attachment(ma.FilePath, contentType);
                    }
                    else
                    {
                        attachment = new System.Net.Mail.Attachment(ma.FilePath);
                    }
                    mail.Attachments.Add(attachment);
                });

                mail.BodyEncoding = UTF8Encoding.UTF8;
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                mail.Subject = MailContent.Subject;
                mail.IsBodyHtml = true;
                mail.Body = MailContent.Body;
                client.Send(mail);
            }
        }
    }
}
