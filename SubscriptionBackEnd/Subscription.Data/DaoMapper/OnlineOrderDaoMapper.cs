using Subscription.Business.Common;
using Subscription.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;
using Subscription.Business.ReturnType;
using Subscription.Data.DaoMapper;
using Subscription.Business.Dto;
using System.Data.Common;
using Subscription.Business;
using Subscription.Business.BusinessObject;
using Subscription.Business.ReturnType.OrderOnline;

namespace Subscription.Data.DaoMapper
{
    public class OnlineOrderDaoMapper
    {
        internal BaseListReturnType<OnlineOrder> MapLoadOnlineOrders(SubscriptionEntities db, DbDataReader reader)
        {
            BaseListReturnType<OnlineOrder> baseListReturnType = new BaseListReturnType<OnlineOrder>();

            List<LoadOnlineOrdersOrderQueryReturnType> orders = ((IObjectContextAdapter)db)
                 .ObjectContext
                 .Translate<LoadOnlineOrdersOrderQueryReturnType>(reader).ToList();

            reader.NextResult();

            List<LoadOnlineOrdersOrderDetailQueryReturnType> orderDetails = ((IObjectContextAdapter)db)
                .ObjectContext
                .Translate<LoadOnlineOrdersOrderDetailQueryReturnType>(reader).ToList();

            reader.NextResult();

            List<LoadOnlineOrdersOrderConceptQueryReturnType> orderConcepts = ((IObjectContextAdapter)db)
                .ObjectContext
                .Translate<LoadOnlineOrdersOrderConceptQueryReturnType>(reader).ToList();


            baseListReturnType.EntityList = new List<OnlineOrder>();

            orders.ForEach(s =>
            {
                var concept = orderConcepts.Where(o => o.IdOrder == s.IdOrder).FirstOrDefault();
                OnlineOrder onlineOrder = new OnlineOrder()
                {
                    IdOrder = s.IdOrder,
                    IdOrderCompany = concept?.IdOrderCompany,
                    IdOrderConcept = concept?.IdOrderConcept,
                    IdOrderPerson = concept?.IdOrderPerson,
                    IdOrderSource = s.IdOrderSource,
                    IdOrderState = s.IdOrderState,
                    IdUserAuthor = s.IdUserAuthor,
                    Name = concept?.Name,
                    OrderDate = s.OrderDate,
                    OrderNumber = s.OrderNumber,
                    TotalAmount = s.TotalAmount,
                    Products = orderDetails.Where(od => od.IdOrder == s.IdOrder).Select(od => new OnlineOrderProduct()
                    {
                        IdOrder = od.IdOrder,
                        IdOrderDetail = od.IdOrderDetail,
                        IdProduct = od.IdProduct,
                        ProductName = od.ProductName,
                        Quantity = od.Quantity,
                        Rate = od.Rate
                    }).ToList()
                };
                baseListReturnType.EntityList.Add(onlineOrder);
            });


            return baseListReturnType;
        }

        internal List<OnlineOrder> GetOnlineOrderDetailForBankRecon(SubscriptionEntities db, DbDataReader reader)
        {
            List<OnlineOrder> onlineOrders = new List<OnlineOrder>();

            List<LoadOnlineOrdersOrderQueryReturnType> orders = ((IObjectContextAdapter)db)
                 .ObjectContext
                 .Translate<LoadOnlineOrdersOrderQueryReturnType>(reader).ToList();

            reader.NextResult();

            List<LoadOnlineOrdersOrderDetailQueryReturnType> orderDetails = ((IObjectContextAdapter)db)
              .ObjectContext
              .Translate<LoadOnlineOrdersOrderDetailQueryReturnType>(reader).ToList();

            reader.NextResult();

            List<LoadOnlineOrdersOrderConceptQueryReturnType> orderConcepts = ((IObjectContextAdapter)db)
                .ObjectContext
                .Translate<LoadOnlineOrdersOrderConceptQueryReturnType>(reader).ToList();

            orders.ForEach(s =>
            {
                var concept = orderConcepts.Where(o => o.IdOrder == o.IdOrder).FirstOrDefault();
                OnlineOrder onlineOrder = new OnlineOrder()
                {
                    IdOrder = s.IdOrder,
                    IdOrderCompany = concept?.IdOrderCompany,
                    IdOrderConcept = concept?.IdOrderConcept,
                    IdOrderPerson = concept?.IdOrderPerson,
                    IdOrderSource = s.IdOrderSource,
                    IdOrderState = s.IdOrderState,
                    IdUserAuthor = s.IdUserAuthor,
                    Name = concept?.Name,
                    OrderDate = s.OrderDate,
                    OrderNumber = s.OrderNumber,
                    TotalAmount = s.TotalAmount,
                    Products = orderDetails.Where(od => od.IdOrder == s.IdOrder).Select(od => new OnlineOrderProduct()
                    {
                        IdOrder = od.IdOrder,
                        IdOrderDetail = od.IdOrderDetail,
                        IdProduct = od.IdProduct,
                        ProductName = od.ProductName,
                        Quantity = od.Quantity,
                        Rate = od.Rate
                    }).ToList()
                };
                onlineOrders.Add(onlineOrder);
            });
            return onlineOrders;
        }
    }
}
