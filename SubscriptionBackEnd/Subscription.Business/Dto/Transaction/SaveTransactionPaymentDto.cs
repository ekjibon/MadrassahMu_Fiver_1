using Subscription.Business.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Business.Dto
{
    public class SaveTransactionPaymentDto
    {
        public Transaction Transaction { get; set; }
        public TransactionDue TransactionDue { get; set; }
        public List<PaymentDetail> PaymentDetails { get; set; }
        public long? IdTemporaryTransactionSignature { get; set; }
    }
}