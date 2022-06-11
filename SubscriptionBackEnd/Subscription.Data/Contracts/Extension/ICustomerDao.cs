using System;
using Subscription.Business;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subscription.Data.EntityFramework;
using Subscription.Business.Common;
using System.Linq.Expressions;

namespace Subscription.Data
{
    public partial interface ICustomerDao
    {
        BaseListReturnType<Customer> GetAllCustomersByNameByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Customer, bool>> expression = null, List<string> includes = null, bool shouldRemap = false, Func<Customer, dynamic> orderExpression = null);
        BaseListReturnType<Customer> GetAllCustomersByNameByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Customer, bool>> expression = null, List<string> includes = null, bool shouldRemap = false, Func<Customer, dynamic> orderExpression = null);
    }
}