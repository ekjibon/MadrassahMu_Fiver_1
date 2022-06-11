using Subscription.Business;
using Subscription.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Data
{
    public partial interface IMailServerSettingDao
    {
        MailServerSetting GetDefaultMailServerSetting();
        MailServerSetting GetDefaultMailServerSetting(SubscriptionEntities db);
    }
}
