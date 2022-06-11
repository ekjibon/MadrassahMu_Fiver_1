using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subscription.Data.EntityFramework;

namespace Subscription.Data
{
    public partial interface IReceiptDao
    {
        double GetNextReceiptIdForUser(long idUser);
        double GetNextReceiptIdForUser(SubscriptionEntities db, long idUser);
    }
}
