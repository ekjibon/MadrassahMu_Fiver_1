using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Business.ReturnType.Subscription
{
    public class SaveTransactionPaymentReturnType
    {
        public Payment Payment { get; set; }
        public Transaction Transaction { get; set; }
        public TransactionDue TransactionDue { get; set; }
        
    }
}
