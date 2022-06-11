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
    public partial class BankStatementStagingDetailBatchDao : IBankStatementStagingDetailBatchDao
    {
        public void SaveBankStatementStagingDetailBatchList(List<BankStatementStagingDetailBatch> BankStatementStagingDetailBatchs)
        {
            using (SubscriptionEntities db = new SubscriptionEntities())
            {
                SaveBankStatementStagingDetailBatchList(BankStatementStagingDetailBatchs, db);
            }
        }

        public void SaveBankStatementStagingDetailBatchList(List<BankStatementStagingDetailBatch> BankStatementStagingDetailBatchs, SubscriptionEntities db)
        {
            db.BankStatementStagingDetailBatches.AddRange(BankStatementStagingDetailBatchs);
            db.SaveChanges();
        }
    }

}
