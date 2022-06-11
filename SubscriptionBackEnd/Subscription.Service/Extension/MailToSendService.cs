using CoreWeb.Business.Common;
using MailManager;
using Subscription.Business;
using Subscription.Business.Common;
using Subscription.Business.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subscription.Data;
using Subscription.Service;

namespace Subscription.Service
{
    public partial class MailToSendService : BaseService
    {
        public BusinessResponse<MailToSend> SaveMailToSendCustom(MailToSend mailToSend)
        {
            BusinessResponse<MailToSend> response = new BusinessResponse<MailToSend>();

            UnitOfWork unitOfWork = new UnitOfWork();
            try
            {
                unitOfWork.Begin();
                response.Result = SaveMailToSendCustomRaw(mailToSend, unitOfWork);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollbackTransaction();
                response.Result = null;
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }
            return response;
        }

        internal MailToSend SaveMailToSendCustomRaw(MailToSend mailToSend, UnitOfWork unitOfWork)
        {
            daoFactory.MailToSendDao.SaveOnlyMailToSend(mailToSend, unitOfWork.Db);
            daoFactory.MailToSendDao.UpdateMailRecipientsForMailToSend(mailToSend.MailRecipients.ToList(), mailToSend.IdMailToSend.Value, unitOfWork.Db);
            daoFactory.MailToSendDao.UpdateMailToSendDocumentsForMailToSend(mailToSend.MailToSendDocuments.ToList(), mailToSend.IdMailToSend.Value, unitOfWork.Db);

            return mailToSend;
        }

        public BusinessResponse<MailToSend> GetMailToSendById(long idMailToSend)
        {
            BusinessResponse<MailToSend> response = new BusinessResponse<MailToSend>();

            try
            {
                response.Result = GetMailToSendByIdRaw(idMailToSend);
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        internal MailToSend GetMailToSendByIdRaw(long idMailToSend)
        {

            List<string> includes = new List<string>() {
                MailToSendDatabaseReferences.MAILRECIPIENTS,
                MailToSendDatabaseReferences.MAILSERVERSETTING,
                MailToSendDatabaseReferences.MAILSTATU,
                MailToSendDatabaseReferences.MAILTOSENDDOCUMENTS
            };
            return ServiceFactory.Instance.MailToSendService.GetMailToSendCustomRaw(property => property.IdMailToSend == idMailToSend && property.IsDeactivated != true, includes);
        }

        public BusinessResponse<bool> SendMail(MailToSend mailToSend)
        {
            BusinessResponse<bool> response = new BusinessResponse<bool>();
            try
            {
                response.Result = SendMailRaw(mailToSend);
            }
            catch (Exception ex)
            {
                response.Result = false;
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }
        internal bool SendMailRaw(MailToSend mailToSend)
        {
            if (mailToSend != null)
            {
                MailServerSetting mailServerSetting = mailToSend.MailServerSetting;
                if (mailToSend.IdMailServerSetting == null)
                {
                    mailServerSetting = daoFactory.MailServerSettingDao.GetDefaultMailServerSetting();
                }
                MailCredential mailCredential = new MailCredential() { DefaultName = mailServerSetting.DefaultName, Host = mailServerSetting.Host, Password = mailServerSetting.Password, Port = mailServerSetting.ClientPort.Value, Username = mailServerSetting.Username, UseSsl = mailServerSetting.UseSSL.Value };
                MailContent mailContent = ConverMailToSendToMailContent(mailToSend);
                new MailManager.MailManager(mailCredential).SendMail(mailContent);
                return true;
            }

            throw new Exception("MailToSend is null");
        }


        public BusinessResponse<bool> SendMail(long idMailToSend)
        {
            BusinessResponse<bool> response = new BusinessResponse<bool>();
            try
            {
                response.Result = SendMailRaw(idMailToSend);
            }
            catch (Exception ex)
            {
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        internal bool SendMailRaw(long idMailToSend)
        {
            MailToSend mailToSend = GetMailToSendByIdRaw(idMailToSend);
            return SendMailRaw(mailToSend);
        }

        internal MailContent ConverMailToSendToMailContent(MailToSend mailToSend)
        {
            MailContent mailContent = new MailContent()
            {
                Body = mailToSend.EmailBody,
                Subject = mailToSend.EmailSubject,
                MailAttachments = mailToSend.MailToSendDocuments.Select(m => new MailAttachment() { Name = m.DocumentName, FilePath = m.RelativeDocumentPath }).ToList(),
                MailRecipients = mailToSend.MailRecipients.Select(m => new MailManager.MailRecipient() { MailAddress = m.EmailAddress, Name = m.Name, MailRecipientType = (MailManager.MailRecipientTypeEnum)m.IdMailRecipientType.Value }).ToList()
            };

            return mailContent;
        }

        public BusinessResponse<bool> SaveAndSendMailToSend(MailToSend mailToSend)
        {

            BusinessResponse<bool> response = new BusinessResponse<bool>();
            UnitOfWork unitOfWork = new UnitOfWork();
            try
            {
                unitOfWork.Begin();
                response.Result = SaveAndSendMailToSendRaw(mailToSend, unitOfWork);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.RollbackTransaction();
                response.Result = false;
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }
            return response;
        }

        internal bool SaveAndSendMailToSendRaw(MailToSend mailToSend, UnitOfWork unitOfWork)
        {
            SaveMailToSendCustomRaw(mailToSend, unitOfWork);
            SendMailRaw(mailToSend);
            mailToSend.IdEmailStatus = (long)MailStatusEnum.SUCCESS;
            daoFactory.MailToSendDao.SaveOnlyMailToSend(mailToSend, unitOfWork.Db);
            return true;
        }
    }
}