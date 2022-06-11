using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Business.ReturnType
{
    public class GetTransactionTotalForDateReturnType
    {
        public string Date { get; set; }
        public string User { get; set; }
        public List<GetTransactionTotalForDateTransactionGroupReturnType> TransactionGroup { get; set; }
    }

    public class GetTransactionTotalForDateTransactionGroupReturnType
    {
        public double Amount { get; set; }
        public string PaymentType { get; set; }
        public DateTime TransactionDate { get; set; }
        public string ReceiptNo { get; set; }
    }
}
