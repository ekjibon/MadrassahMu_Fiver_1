using Subscription.Business;
using Subscription.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Data
{
    public partial class MailToSendDao : IMailToSendDao
    {
        public List<MailToSend> SaveBulkMailToSend(List<MailToSend> mailToSends)
        {
            using (SubscriptionEntities db = new EntityFramework.SubscriptionEntities())
            {
                return SaveBulkMailToSend(mailToSends,db);
            }
        }
        public List<MailToSend> SaveBulkMailToSend(List<MailToSend> mailToSends,SubscriptionEntities db)
        {
            db.MailToSends.AddRange(mailToSends);
            db.SaveChanges();
            return mailToSends;
        }

        //public List<long> GetIdMailToSendByStatus(List<long> idStatuses)
        //{
        //    using (SubscriptionEntities db = new EntityFramework.SubscriptionEntities())
        //    {
        //        return SaveBulkMailToSend(idStatuses, db);
        //    }
        //}
        //public List<long> GetIdMailToSendByStatus(List<long> idStatuses, bool shouldGetNull,SubscriptionEntities db)
        //{
        //    db.MailToSends.Where(m=> idStatuses.Contains(m.IdEmailStatus))
        //    db.SaveChanges();
        //    return mailToSends;
        //}
    }
}