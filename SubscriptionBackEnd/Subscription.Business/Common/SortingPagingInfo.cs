using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Business.Common
{
    public class SortingPagingInfo
    {
        public string SortField { get; set; }
        public bool SortByDesc { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }
        public int CurrentPageIndex { get; set; }
        public string Search { get; set; }
    }
}
