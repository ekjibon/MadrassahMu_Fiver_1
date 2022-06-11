using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Subscription.Business;
using Subscription.Business.Common;
using Subscription.Data.Common;
using Subscription.Data.EntityFramework;
using System.Linq.Dynamic;

namespace Subscription.Data
{
    public partial class CustomerDao : ICustomerDao
    {
        public BaseListReturnType<Customer> GetAllCustomersByNameByPage(Business.Common.SortingPagingInfo sortingPagingInfo, Expression<Func<Customer, bool>> expression = null, List<string> includes = null, bool shouldRemap = false, Func<Customer, dynamic> orderExpression = null)
        {
            using (SubscriptionEntities db = new EntityFramework.SubscriptionEntities())
            {
                return GetAllCustomersByNameByPage(sortingPagingInfo, db, expression, includes, shouldRemap, orderExpression);
            }
        }

        public BaseListReturnType<Customer> GetAllCustomersByNameByPage(Business.Common.SortingPagingInfo sortingPagingInfo, SubscriptionEntities db, Expression<Func<Customer, bool>> expression = null, List<string> includes = null, bool shouldRemap = false, Func<Customer, dynamic> orderExpression = null)
        {
            IQueryable<Customer> query = db.Customers;

            if (includes != null)
            {
                query = query.WithIncludes(includes);
            }

            BaseListReturnType<Customer> baseListReturnType = new BaseListReturnType<Customer>();

            IQueryable<Customer> orderedQuery = null;
            if (orderExpression != null)
            {
                orderedQuery = query.OrderBy(orderExpression).AsQueryable();
            }
            else
            {
                string sortField = String.IsNullOrEmpty(sortingPagingInfo.SortField) ? "IdCustomer" : sortingPagingInfo.SortField;
                if (sortingPagingInfo.SortByDesc)
                    orderedQuery = query.OrderBy(DbUtilStringBuilder.BuildSortString(sortField, SortEnum.DESC));
                else
                    orderedQuery = query.OrderBy(DbUtilStringBuilder.BuildSortString(sortField, SortEnum.ASC));
            }
            if (!string.IsNullOrWhiteSpace(sortingPagingInfo.Search) || expression != null)
            {
                Expression<Func<Customer, bool>> expressionBuilder = expression;

                if (expressionBuilder == null)
                    expressionBuilder = property => property.FullName.Trim().ToLower().Contains(sortingPagingInfo.Search.Trim().ToLower()) && property.IsDeactivated != true;
                orderedQuery = orderedQuery.Where(expressionBuilder);
            }

            baseListReturnType.TotalCount = orderedQuery.Count();

            if (sortingPagingInfo.PageSize == -1)
            {
                baseListReturnType.EntityList = orderedQuery.ToList();
            }
            else
            {
                baseListReturnType.EntityList = orderedQuery.Skip(sortingPagingInfo.PageSize * sortingPagingInfo.CurrentPageIndex)
                    .Take(sortingPagingInfo.PageSize)
                    .ToList();
            }
            if (shouldRemap)
                baseListReturnType.EntityList = Mapper.MapCustomerList(baseListReturnType.EntityList);

            return baseListReturnType;
        }
    }
}
 