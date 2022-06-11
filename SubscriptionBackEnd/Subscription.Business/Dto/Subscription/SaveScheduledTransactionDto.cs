using Subscription.Business.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Business.Dto.Subscription
{
    public class SaveScheduledTransactionDto
    {
        public Transaction Transaction { get; set; }
        public DefineFrequency Frequency { get; set; }
    }
}
