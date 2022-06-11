using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Business.Enums
{
    public enum EntityStateEnum
    {
        AWAITING_SYNC = 1,
        SYNCING = 2,
        SYNCED = 3
    }
}
