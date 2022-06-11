using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Business.Enums
{
    public enum TemporaryTransactionOrderStateEnum
    {
        AWAITING_SIGNATURE = 1,
        SIGNATURE_DONE = 2,
        SIGNATURE_SAVED = 3,
        ORDER_DONE = 10001
    }
}
