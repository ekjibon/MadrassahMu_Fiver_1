using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Business.ReturnType
{
    public class AnalyseBankReconciliationFileReturnType
    {
        public long IdBankStatementStaging { get; set; }
        public BankStatementStaging BankStatementStaging { get; set; }
        public List<BankStatementStagingDetailBatch> BankStatementStagingDetailBatches { get; set; }
    }
}
