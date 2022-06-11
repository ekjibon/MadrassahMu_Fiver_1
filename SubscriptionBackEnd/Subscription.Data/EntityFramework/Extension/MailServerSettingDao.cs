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
    public partial class MailServerSettingDao : IMailServerSettingDao
    {
        public MailServerSetting GetDefaultMailServerSetting()
        {
            using (SubscriptionEntities db = new EntityFramework.SubscriptionEntities())
            {
                return GetDefaultMailServerSetting(db);
            }
        }
        public MailServerSetting GetDefaultMailServerSetting(SubscriptionEntities db)
        {
            return db.MailServerSettings.Where(m => m.IsDeactivated != true).OrderBy(m => m.Priority).FirstOrDefault();
        }
    }
}
