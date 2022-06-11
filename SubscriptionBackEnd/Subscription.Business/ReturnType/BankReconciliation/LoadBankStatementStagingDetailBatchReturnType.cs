using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subscription.Business.Common;

namespace Subscription.Business.ReturnType.BankReconciliation
{
   public class LoadBankStatementStagingDetailBatchReturnType
    {
        public BaseListReturnType<BankStatementStagingDetailBatch> Batches { get; set; }
        public BankStatementStaging BankStatementStaging { get; set; }
    }
}
