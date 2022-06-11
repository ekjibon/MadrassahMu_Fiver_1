using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Business.ReturnType
{
    public class GetTransactionSaleForPrintReturnType
    {
        public long? IdTransaction { get; set; }
        public long IdTransactionType { get; set; }
        public string ReceiptNo { get; set; }
        public string Date { get; set; }
        public string PaymentMethod { get; set; }
        public string ChequeNo { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public List<GetTransactionSaleForPrintTransactionDetailReturnType> TransactionDetails { get; set; }
        public string Total { get; set; }
        public string TransactionDate { get; set; }
        public string SignatureFilePath { get; set; }
        public List<string> EmailAddresses { get; set; }
        public string AmountPaid { get; set; }
        public string AmountRemaining { get; set; }
    }

    public class GetTransactionSaleForPrintTransactionDetailReturnType
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Quantity { get; set; }
        public string Rate { get; set; }
        public string Amount { get; set; }

    }
}
