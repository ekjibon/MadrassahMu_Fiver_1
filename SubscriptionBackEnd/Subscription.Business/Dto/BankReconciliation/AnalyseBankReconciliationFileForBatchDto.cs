using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Business.Dto
{
    public class AnalyseBankReconciliationFileForBatchDto
    {
        public long IdBatch { get; set; }

        public long IdBankStatementStaging { get; set; }
    }
}
