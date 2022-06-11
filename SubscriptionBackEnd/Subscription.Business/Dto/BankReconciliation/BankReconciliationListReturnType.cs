using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Business.Dto
{
    public class BankReconciliationListReturnType : BankStatementStaging
    {
        public int TotalTransaction { get; set; }
    }
}
