using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subscription.Business;
using Subscription.Business.BusinessObject;
using Subscription.Data.EntityFramework;

namespace Subscription.Data.DaoMapper
{
    class StockDaoMapper
    {
        public List<Stock> MapMainStockForLocation(SubscriptionEntities db, DbDataReader reader)
        {
            List<Stock> stocks = ((IObjectContextAdapter)db)
               .ObjectContext
               .Translate<Stock>(reader).ToList();

            return stocks;
        }

        public List<StockPosition> MapStockPosition(SubscriptionEntities db, DbDataReader reader)
        {
            List<StockPosition> stockPositions = ((IObjectContextAdapter)db)
               .ObjectContext
               .Translate<StockPosition>(reader).ToList();

            return stockPositions;
        }

    }
}
