using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Business.ReturnType
{
    public class AnalyseBankReconciliationFileForBatchReturnType
    {
        public List<BankStatementStagingDetail> BankStatementStagingDetails { get; set; }
        public long IdBankStatementStaging { get; set; }
        public Bank Bank { get; set; }
    }
}
