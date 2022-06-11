using Subscription.Business.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Business.ReturnType.Subscription
{
    public class GetPaymentDueDetailReturnType
    {
        public Transaction Transaction { get; set; }

        public Payment Payment { get; set; }
    }
}
