using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subscription.Business;
using Subscription.Business.ReturnType.BankReconciliation;
using Subscription.Data.EntityFramework;

namespace Subscription.Data
{
    public partial interface IBankReconciliationDao
    {
        List<BankStatementStagingHit> ReconcialeBankStatement(long idBankStatementStaging, long idBatch);
        List<BankStatementStagingHit> ReconcialeBankStatement(long idBankStatementStaging, long idBatch, SubscriptionEntities db);

        List<BankStatementStagingDetailBatch> GetBatchesForBankStatmentStaging(long idBankStatementStaging);
        List<BankStatementStagingDetailBatch> GetBatchesForBankStatmentStaging(long idBankStatementStaging, SubscriptionEntities db);

        ReconcileBankOrderReturnType ReconcileBankOrder(long idBankStatementStaging);
        ReconcileBankOrderReturnType ReconcileBankOrder(long idBankStatementStaging, SubscriptionEntities db);

        bool SaveReconcileBankOrder(List<long> idBankStatementStagingDetails);
        bool SaveReconcileBankOrder(List<long> idBankStatementStagingDetails, SubscriptionEntities db);

        

    }
}
