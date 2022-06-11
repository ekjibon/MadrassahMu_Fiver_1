using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subscription.Business.ReturnType;
using Subscription.Data.EntityFramework;

namespace Subscription.Data
{
    public partial interface IUserDao
    {
        GetUserDetailForSessionReturnType GetUserDetailForSession(long idUser);

        GetUserDetailForSessionReturnType GetUserDetailForSession(long idUser, SubscriptionEntities db);
    }
}
