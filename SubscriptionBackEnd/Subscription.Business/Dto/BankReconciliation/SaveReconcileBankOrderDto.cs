using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Business.Dto.BankReconciliation
{
    public class SaveReconcileBankOrderDto
    {
        public List<long> IdBankStatementStagingDetails { get; set; }
    }
}
