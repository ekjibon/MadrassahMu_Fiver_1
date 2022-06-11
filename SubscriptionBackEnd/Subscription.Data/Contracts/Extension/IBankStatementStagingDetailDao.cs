using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subscription.Business;
using Subscription.Data.EntityFramework;

namespace Subscription.Data
{
    public partial interface IBankStatementStagingDetailDao
    {
        void SaveBankStatementStagingDetailList(List<BankStatementStagingDetail> BankStatementStagingDetailBatchs);
        void SaveBankStatementStagingDetailList(List<BankStatementStagingDetail> BankStatementStagingDetailBatchs, SubscriptionEntities db);
    }
}
