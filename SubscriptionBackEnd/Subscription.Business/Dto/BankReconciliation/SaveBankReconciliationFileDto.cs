using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Business
{
    public class SaveBankReconciliationFileDto
    {
        public List<SaveBankReconciliationFileBankStatementDto> BankStatements { get; set; }
        public long IdBankStatementStaging { get; set; }
        public long IdBatch { get; set; }
    }

    public class SaveBankReconciliationFileBankStatementDto
    {
        public long IdBankStatementStagingDetail { get; set; }
        public List<SaveBankReconciliationFileBankStatementTransactionDto> Transactions { get; set; }
    }

    public class SaveBankReconciliationFileBankStatementTransactionDto : Transaction
    {
        public long? IdBankStatementHitList { get; set; }
        public long? IdBankStatementStagingHit { get; set; }
    }
}
