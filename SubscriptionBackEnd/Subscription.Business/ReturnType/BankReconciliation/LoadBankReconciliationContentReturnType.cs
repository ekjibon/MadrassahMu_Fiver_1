using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Business.ReturnType
{
    public class LoadBankReconciliationContentReturnType
    {
        public BankStatementStaging BankStatementStaging { get; set; }
        public List<string> WarningMessages { get; set; }
    }
}
