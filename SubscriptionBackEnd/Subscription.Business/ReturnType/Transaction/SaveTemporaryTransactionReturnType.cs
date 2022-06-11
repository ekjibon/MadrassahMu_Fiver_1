using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Business.ReturnType
{
    public class SaveTemporaryTransactionReturnType
    {
        public TemporaryTransactionOrder TemporaryTransaction { get; set; }
        public string OrderCodeUrl { get; set; }
    }
}