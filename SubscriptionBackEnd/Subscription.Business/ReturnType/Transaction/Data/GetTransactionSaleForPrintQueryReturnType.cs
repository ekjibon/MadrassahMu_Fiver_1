using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Business.ReturnType
{
    public class GetTransactionSaleForPrintQueryReturnType
    {
        public long? IdTransaction { get; set; }
        public string ReceiptNo { get; set; }
        public string FullName { get; set; }
        public string TransactionDate { get; set; }
        public string Address { get; set; }
        public string PaymentMethod { get; set; }
        public string ChequeNo { get; set; }
        public string ProductName { get; set; }
        public string TransactionDescription { get; set; }
        public string Quantity { get; set; }
        public string Rate { get; set; }
        public string Amount { get; set; }
        public string TotalAmount { get; set; }
    }
}