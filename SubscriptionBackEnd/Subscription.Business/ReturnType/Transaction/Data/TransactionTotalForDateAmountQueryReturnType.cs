using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Business.ReturnType
{
    public class TransactionTotalForDateAmountQueryReturnType
    {
        public double? TotalAmount { get; set; }
        public string TransactionPaymentType { get; set; }
        public DateTime TransactionDate { get; set; }
        public string ReceiptNo { get; set; }
    }
}
