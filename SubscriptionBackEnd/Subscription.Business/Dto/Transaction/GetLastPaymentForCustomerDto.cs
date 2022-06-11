using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subscription.Business.Common;

namespace Subscription.Business.Dto
{
    public class GetLastPaymentForCustomerDto : SortingPagingInfo
    {
        public long? IdCustomer { get; set; }

        public long? IdTransaction { get; set; }
    }
}
