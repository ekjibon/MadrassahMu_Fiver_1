using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subscription.Business.BusinessObject;
using Subscription.Business.Common;
using Subscription.Business.Dto;
using Subscription.Data.EntityFramework;

namespace Subscription.Data
{
    public partial interface IOnlineOrderDao
    {
        BaseListReturnType<OnlineOrder> LoadOnlineOrders(OnlineOrdersSortingPagingInfo sortingPagingInfo);
        BaseListReturnType<OnlineOrder> LoadOnlineOrders(OnlineOrdersSortingPagingInfo sortingPagingInfo, SubscriptionEntities db);

        List<OnlineOrder> GetOnlineOrderDetailForBankRecon(long idBankStatementStaging);
        List<OnlineOrder> GetOnlineOrderDetailForBankRecon(long idBankStatementStaging, SubscriptionEntities db);
    }
}