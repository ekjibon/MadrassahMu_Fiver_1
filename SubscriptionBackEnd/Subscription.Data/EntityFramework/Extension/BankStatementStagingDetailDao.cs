using System;
using Subscription.Business;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subscription.Data.EntityFramework;
using Subscription.Business.Common;
using System.Linq.Expressions;
using Subscription.Business.ExtensionMethod;
using System.Linq.Dynamic;
using Subscription.Data.Common;

namespace Subscription.Data
{
    public partial class BankStatementStagingDetailDao : IBankStatementStagingDetailDao
    {
        public void SaveBankStatementStagingDetailList(List<BankStatementStagingDetail> bankStatementStagingDetails)
        {
            using (SubscriptionEntities db = new SubscriptionEntities())
            {
                SaveBankStatementStagingDetailList(bankStatementStagingDetails, db);
            }
        }

        public void SaveBankStatementStagingDetailList(List<BankStatementStagingDetail> bankStatementStagingDetails, SubscriptionEntities db)
        {
            db.BankStatementStagingDetails.AddRange(bankStatementStagingDetails);
            db.SaveChanges();
        }
    }

}
