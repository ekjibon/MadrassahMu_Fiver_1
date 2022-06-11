using Subscription.Business;
using Subscription.Business.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Business.ReturnType
{
    public class GetScheduledTransactionReturnType
    {
        public Transaction Transaction { get; set; }

        public BaseListReturnType<TransactionDue> TransactionDues { get; set; } 
    }
}
