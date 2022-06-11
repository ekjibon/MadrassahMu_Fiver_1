using CoreWeb.Business.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subscription.Business;
using Subscription.Business.Enums;
using Subscription.Service;

namespace MailSender
{
    public class MailSenderService
    {
        public void FetchAndSendMail()
        {
            List<long?> idMailStatuses = new List<long?>() { null, (long)MailStatusEnum.FAILED, (long)MailStatusEnum.PENDING, (long)MailStatusEnum.READY };
            List<long> idMailToSends = ServiceFactory.Instance.MailToSendService.GetMailToSendCustomList(m => idMailStatuses.Contains(m.IdEmailStatus)).Result.EntityList.Select(m => m.IdMailToSend.Value).ToList();

            BusinessResponse<MailServerSetting> mailServerSetting = ServiceFactory.Instance.MailServerSettingService.GetDefaultMailServerSetting();
            if (mailServerSetting.HasException())
            {
                new BusinessLayerException("Could not fetch mail server setting");
                return;
            }

            Parallel.ForEach(idMailToSends, new ParallelOptions() { MaxDegreeOfParallelism = 1 }, m =>
            {
                try
                {
                    SendMail(m, mailServerSetting.Result);
                    Console.WriteLine("Process terminated for" + m);

                }
                catch (Exception ex)
                {
                    new BusinessLayerException(ex);
                    Console.WriteLine("Failed to send mail with id" + m);
                }
            });
        }

        public void SendMail(long idMailToSend, MailServerSetting mailServerSetting)
        {
            MailToSend mailToSend = null;
            try
            {
                List<string> includes = new List<string>()
                {
                    MailToSendDatabaseReferences.MAILRECIPIENTS,
                    MailToSendDatabaseReferences.MAILTOSENDDOCUMENTS,
                    MailToSendDatabaseReferences.MAILSERVERSETTING
                };

                BusinessResponse<MailToSend> mailToSendResponse = ServiceFactory.Instance.MailToSendService.GetMailToSendCustom(m => m.IdMailToSend == idMailToSend, includes);

                if (mailToSendResponse.HasException())
                {
                    throw new Exception("Mail with id " + idMailToSend + " could not be fetched");
                }
                mailToSend = mailToSendResponse.Result;
                if (mailToSend.MailServerSetting == null)
                {
                    mailToSend.MailServerSetting = mailServerSetting;
                    mailToSend.IdMailServerSetting = mailServerSetting.IdMailServerSetting;
                }

                BusinessResponse<bool> mailSendingResponse = ServiceFactory.Instance.MailToSendService.SendMail(mailToSend);
                if (mailSendingResponse.HasException())
                {
                    throw new Exception("Mail with id " + idMailToSend + " could not be sent due to " + mailSendingResponse?.Exception?.Message);
                }
                mailToSend.IdEmailStatus = (long)MailStatusEnum.SUCCESS;
                ServiceFactory.Instance.MailToSendService.SaveOnlyMailToSend(mailToSend);
            }
            catch (Exception ex)
            {
                new BusinessLayerException(ex);
                if (mailToSend != null)
                {
                    mailToSend.IdEmailStatus = (long)MailStatusEnum.FAILED;
                    mailToSend.FailureCount = (mailToSend.FailureCount ?? 0) + 1;
                    ServiceFactory.Instance.MailToSendService.SaveOnlyMailToSend(mailToSend);
                }
            }
        }
    }
}
