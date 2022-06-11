using Subscription.Business.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Business.Dto
{
    public class SavePaymentForTransactionDueDto
    {
        public List<TransactionDue> TransactionDues { get; set; }
        public List<PaymentDetail> PaymentDetails { get; set; }
    }
}
