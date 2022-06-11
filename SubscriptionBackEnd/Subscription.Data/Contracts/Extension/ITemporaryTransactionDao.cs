using Subscription.Business;
using Subscription.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Data
{
    public partial interface ITemporaryTransactionDao
    {
        List<TemporaryTransaction> SaveBulkTemporaryTransaction(List<TemporaryTransaction> temporaryTransactions);
        List<TemporaryTransaction> SaveBulkTemporaryTransaction(SubscriptionEntities db, List<TemporaryTransaction> temporaryTransactions);
        bool ProcessTemporaryTransactionForBankStatement(long idBatch);
        bool ProcessTemporaryTransactionForBankStatement(SubscriptionEntities db, long idBatch);

        void DeleteTemporaryTransactionForBankStatement(long idBankStatementStaging);
        void DeleteTemporaryTransactionForBankStatement(SubscriptionEntities db, long idBankStatementStaging);
    }
}


