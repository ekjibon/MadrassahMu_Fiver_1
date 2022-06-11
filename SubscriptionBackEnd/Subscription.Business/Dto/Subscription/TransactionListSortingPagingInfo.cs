using Subscription.Business.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Business.Dto.Subscription
{
    public class TransactionListSortingPagingInfo : SortingPagingInfo
    {
        public int IdTransaction { get; set; }
        public int IdCustomer { get; set; }
        public int IdTransactionType { get; set; }
    }
}
