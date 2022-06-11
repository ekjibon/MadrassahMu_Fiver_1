using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Subscription.Business;
using Subscription.Data.EntityFramework;

namespace Subscription.Data
{
    public partial class ReceiptDao : IReceiptDao
    {
        public double GetNextReceiptIdForUser(long idUser)
        {
            using (SubscriptionEntities db = new EntityFramework.SubscriptionEntities())
            {
                return GetNextReceiptIdForUser(db, idUser);
            }
        }
        public double GetNextReceiptIdForUser(SubscriptionEntities db, long idUser)
        {
            Receipt receipt = db.Receipts.Where(m => m.IdUser == idUser && m.IsDeactivated != true).OrderByDescending(m => m.Number).FirstOrDefault();
            double nextReceiptNumber = receipt == null ? 0 : receipt.Number.Value;
            nextReceiptNumber += 1;
            return nextReceiptNumber;
        }
    }
}
 