using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Business.ReturnType.Subscription
{
    public class SaveScheduledTransactionReturnType
    {
        public Transaction Transaction { get; set; }

        public List<TransactionDue> TransactionDues { get; set; }

        public ScheduleSetting ScheduleSetting { get; set; }
    }
}
