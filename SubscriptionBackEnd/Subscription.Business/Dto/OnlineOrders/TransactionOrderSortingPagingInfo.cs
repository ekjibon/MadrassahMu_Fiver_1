using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subscription.Business.Common;

namespace Subscription.Business.Dto
{
    public class OnlineOrdersSortingPagingInfo : SortingPagingInfo
    {
        public long IdOrder { get; set; }
        public long? IdOrderSource { get; set; }
        public long? IdOrderState { get; set; }
        public DateTime? Date { get; set; }
        public string OrderByColumn { get; set; }
    }
}
