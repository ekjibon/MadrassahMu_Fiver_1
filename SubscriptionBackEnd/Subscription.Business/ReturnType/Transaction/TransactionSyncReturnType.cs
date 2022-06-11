using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Business.ReturnType
{


    public class TransactionSyncReturnType// : BaseSyncClientEntityReturnType
    {
        public string Customer { get; set; }
        public string TransactionTemplate { get; set; }
        public DateTime TransactionDate { get; set; }
        public string PaymentMethod { get; set; }
        public string ChequeNo { get; set; }
        public string TransactionAccount { get; set; }
        public string ReceiptNo { get; set; }
        public string TranasctionClass { get; set; }
        public string Memo { get; set; }

        public List<TransactionSyncLineItemReturnType> TransactionSyncLineItemReturnTypes { get; set; }
    }

    public class TransactionSyncLineItemReturnType
    {
        public string Product { get; set; }
        public string Description { get; set; }
        public double Quantity { get; set; }
        public string TransactionClass { get; set; }
        public double Rate { get; set; }
        public double Amount { get; set; }
        public string IdServerId { get; set; }

    }
}
