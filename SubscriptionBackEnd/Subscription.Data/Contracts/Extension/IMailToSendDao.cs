using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subscription.Business;
using Subscription.Data.EntityFramework;

namespace Subscription.Data
{
    public partial interface IMailToSendDao
    {
        List<MailToSend> SaveBulkMailToSend(List<MailToSend> mailToSends);

        List<MailToSend> SaveBulkMailToSend(List<MailToSend> mailToSends, SubscriptionEntities db);


        //List<long> GetIdMailToSendByStatus(List<long> idStatuses);

        //List<long> GetIdMailToSendByStatus(List<long> idStatuses, SubscriptionEntities db);
    }
}